using System;
using System.IO;
using System.Windows.Forms;

namespace LFSR_StreamCipher
{
    public partial class Form1 : Form
    {
        // Многочлен в двоичном виде
        private const uint POLYNOMIAL_MASK = 0b10011000001100000000000000000011;

        private string selectedFilePath = "";
        private bool isProcessing = false;

        public Form1()
        {
            InitializeComponent();

            // Настройка поля ввода
            textBoxState.KeyPress += TextBoxState_KeyPress;
            textBoxState.TextChanged += TextBoxState_TextChanged;
            buttonSelectFile.Click += ButtonSelectFile_Click;
            buttonProcess.Click += ButtonProcess_Click;
            textBoxState.ShortcutsEnabled = false;

            // Начальное состояние по умолчанию
            textBoxState.Text = "11001010101111001100110011110011";
        }

        // Разрешаем только 0 и 1
        private void TextBoxState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && e.KeyChar != '0' && e.KeyChar != '1')
            {
                e.Handled = true;
            }
        }

        // Ограничиваем длину до 32 символов
        private void TextBoxState_TextChanged(object sender, EventArgs e)
        {
            if (textBoxState.Text.Length > 32)
            {
                textBoxState.Text = textBoxState.Text.Substring(0, 32);
                textBoxState.SelectionStart = 32;
            }
        }

        // Выбор файла
        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                textBoxFilePath.Text = selectedFilePath;

                // Очищаем поля
                textBoxKey.Text = "";
                textBoxOriginal.Text = "";
                textBoxEncrypted.Text = "";
            }
        }

        // Кнопка выполнения
        private async void ButtonProcess_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("Операция уже выполняется");
                return;
            }

            // Проверки
            if (string.IsNullOrEmpty(textBoxState.Text) || textBoxState.Text.Length < 32)
            {
                MessageBox.Show("Введите 32 бита");
                return;
            }

            for (int i = 0; i < textBoxState.Text.Length; i++)
            {
                if (textBoxState.Text[i] != '0' && textBoxState.Text[i] != '1')
                {
                    MessageBox.Show("Только 0 и 1");
                    return;
                }
            }

            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("Выберите файл");
                return;
            }

            string operation = radioEncrypt.Checked ? "зашифрован" : "расшифрован";
            DialogResult result = MessageBox.Show("Файл будет " + operation + ". Продолжить?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            isProcessing = true;
            buttonProcess.Enabled = false;
            buttonSelectFile.Enabled = false;
            textBoxState.ReadOnly = true;
            radioEncrypt.Enabled = false;
            radioDecrypt.Enabled = false;

            try
            {
                await System.Threading.Tasks.Task.Run(() => ProcessFile());
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                });
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    isProcessing = false;
                    buttonProcess.Enabled = true;
                    buttonSelectFile.Enabled = true;
                    textBoxState.ReadOnly = false;
                    radioEncrypt.Enabled = true;
                    radioDecrypt.Enabled = true;
                });
            }
        }

        // Обработка файла
        private void ProcessFile()
        {
            string initialState = textBoxState.Text;
            bool encrypt = radioEncrypt.Checked;

            // Имя выходного файла
            string directory = Path.GetDirectoryName(selectedFilePath);
            string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
            string extension = Path.GetExtension(selectedFilePath);
            string outputFileName = encrypt ? fileName + "_encrypted" + extension : fileName + "_decrypted" + extension;
            string outputPath = Path.Combine(directory, outputFileName);

            // Создаем LFSR
            LFSR lfsr = new LFSR(initialState, POLYNOMIAL_MASK);

            // Массивы для первых 4 байт
            byte[] firstKey = new byte[4];
            byte[] firstOriginal = new byte[4];
            byte[] firstResult = new byte[4];

            // Массивы для последних 4 байт
            byte[] lastKey = new byte[4];
            byte[] lastOriginal = new byte[4];
            byte[] lastResult = new byte[4];

            // Буфер для последних 4 байт (кольцевой)
            byte[] ringKey = new byte[4];
            byte[] ringOriginal = new byte[4];
            byte[] ringResult = new byte[4];
            int ringPos = 0;

            long totalBytes = 0;
            int firstPos = 0;

            try
            {
                FileStream inputStream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read);
                FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

                totalBytes = inputStream.Length;

                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Запоминаем оригинал
                    byte[] original = new byte[bytesRead];
                    for (int i = 0; i < bytesRead; i++) original[i] = buffer[i];

                    // Генерируем ключ
                    byte[] key = new byte[bytesRead];
                    for (int i = 0; i < bytesRead; i++) key[i] = lfsr.NextByte();

                    // Сохраняем первые 4 байта
                    for (int i = 0; i < bytesRead && firstPos < 4; i++)
                    {
                        firstKey[firstPos] = key[i];
                        firstOriginal[firstPos] = original[i];
                        firstPos++;
                    }

                    // Обновляем кольцевой буфер (ДО XOR)
                    for (int i = 0; i < bytesRead; i++)
                    {
                        ringKey[ringPos % 4] = key[i];
                        ringOriginal[ringPos % 4] = original[i];
                        ringPos++;
                    }

                    // XOR
                    for (int i = 0; i < bytesRead; i++) buffer[i] ^= key[i];

                    // Сохраняем первые 4 байта результата
                    if (firstPos <= 4)
                    {
                        int start = (int)(inputStream.Position - bytesRead);
                        for (int i = 0; i < bytesRead && start + i < 4; i++)
                        {
                            firstResult[start + i] = buffer[i];
                        }
                    }

                    // Обновляем кольцевой буфер для результата (ПОСЛЕ XOR)
                    int startRing = ringPos - bytesRead;
                    for (int i = 0; i < bytesRead; i++)
                    {
                        ringResult[(startRing + i) % 4] = buffer[i];
                    }

                    outputStream.Write(buffer, 0, bytesRead);
                }

                inputStream.Close();
                outputStream.Close();

                // Копируем последние 4 байта из кольцевого буфера
                if (totalBytes >= 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int idx = (ringPos - 4 + i) % 4;
                        lastKey[i] = ringKey[idx];
                        lastOriginal[i] = ringOriginal[idx];
                        lastResult[i] = ringResult[idx];
                    }
                }

                // Отображаем результаты
                this.Invoke((MethodInvoker)delegate
                {
                    long fileSize = totalBytes;

                    // ИСХОДНЫЙ ФАЙЛ
                    string origText = "";
                    int firstCount = (int)Math.Min(4, fileSize);
                    origText += "ПЕРВЫЕ " + firstCount + " БАЙТА:\r\n";
                    for (int i = 0; i < firstCount; i++)
                    {
                        int b = firstOriginal[i];
                        string bits = "";
                        for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                        origText += bits;
                        if (i < firstCount - 1) origText += " ";
                    }

                    if (fileSize > 4)
                    {
                        origText += "\r\n\r\nПОСЛЕДНИЕ 4 БАЙТА:\r\n";
                        for (int i = 0; i < 4; i++)
                        {
                            int b = lastOriginal[i];
                            string bits = "";
                            for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                            origText += bits;
                            if (i < 3) origText += " ";
                        }
                    }
                    textBoxOriginal.Text = origText;

                    // КЛЮЧ
                    string keyText = "";
                    keyText += "ПЕРВЫЕ " + firstCount + " БАЙТА КЛЮЧА:\r\n";
                    for (int i = 0; i < firstCount; i++)
                    {
                        int b = firstKey[i];
                        string bits = "";
                        for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                        keyText += bits;
                        if (i < firstCount - 1) keyText += " ";
                    }

                    if (fileSize > 4)
                    {
                        keyText += "\r\n\r\nПОСЛЕДНИЕ 4 БАЙТА КЛЮЧА:\r\n";
                        for (int i = 0; i < 4; i++)
                        {
                            int b = lastKey[i];
                            string bits = "";
                            for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                            keyText += bits;
                            if (i < 3) keyText += " ";
                        }
                    }
                    textBoxKey.Text = keyText;

                    // РЕЗУЛЬТАТ
                    string resultText = "";
                    string operationName = encrypt ? "ЗАШИФРОВАННЫЙ" : "РАСШИФРОВАННЫЙ";
                    resultText += "ПЕРВЫЕ " + firstCount + " БАЙТА " + operationName + " ФАЙЛА:\r\n";
                    for (int i = 0; i < firstCount; i++)
                    {
                        int b = firstResult[i];
                        string bits = "";
                        for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                        resultText += bits;
                        if (i < firstCount - 1) resultText += " ";
                    }

                    if (fileSize > 4)
                    {
                        resultText += "\r\n\r\nПОСЛЕДНИЕ 4 БАЙТА " + operationName + " ФАЙЛА:\r\n";
                        for (int i = 0; i < 4; i++)
                        {
                            int b = lastResult[i];
                            string bits = "";
                            for (int j = 7; j >= 0; j--) bits += ((b >> j) & 1) == 1 ? "1" : "0";
                            resultText += bits;
                            if (i < 3) resultText += " ";
                        }
                    }
                    textBoxEncrypted.Text = resultText;

                    // Сообщение об успехе
                    string operation = encrypt ? "Зашифрован" : "Расшифрован";
                    MessageBox.Show(
                        operation + " файл сохранен:\n" + outputFileName + "\n\n" +
                        "Размер: " + totalBytes + " байт\n" +
                        "Путь: " + outputPath,
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                });
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}