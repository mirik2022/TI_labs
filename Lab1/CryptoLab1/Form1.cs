using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CryptoLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Установка начальных значений
            comboBoxAlgorithm.SelectedIndex = 0;
            comboBoxMode.SelectedIndex = 0;
        }

        // Кнопка "Выполнить"
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Сбрасываем глобальную переменную
            //CipherEngine.Reset();

            string inputText = txtInput.Text;  // Читаем из поля ввода
            string key = txtKey.Text.Trim();
            int algorithm = comboBoxAlgorithm.SelectedIndex;
            int mode = comboBoxMode.SelectedIndex; // 0 = Encrypt, 1 = Decrypt

            // Проверки
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Введите текст или загрузите файл.", "Ошибка",
                    MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Введите ключ.", "Ошибка",
                    MessageBoxButtons.OK);
                return;
            }

            string result = "";

            try
            {
                if (algorithm == 0) // Столбцовый метод
                {
                    if (mode == 0)
                        result = CipherEngine.ColumnarEncrypt(inputText, key);
                    else
                        result = CipherEngine.ColumnarDecrypt(inputText, key);
                }
                else // Шифр Виженера
                {
                    if (mode == 0)
                        result = CipherEngine.VigenereEncrypt(inputText, key);
                    else
                        result = CipherEngine.VigenereDecrypt(inputText, key);
                }

                // ВЫВОДИМ РЕЗУЛЬТАТ В ОТДЕЛЬНОЕ ПОЛЕ
                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Загрузить из файла"
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    txtInput.Text = fileContent;  // Загружаем в поле ввода
                    txtResult.Clear();             // Очищаем результат
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка "Сохранить в файл"
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                MessageBox.Show("Нет результата для сохранения.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Сохраняем РЕЗУЛЬТАТ, а не исходный текст
                    File.WriteAllText(saveFileDialog.FileName, txtResult.Text, Encoding.UTF8);
                    MessageBox.Show("Файл успешно сохранен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}