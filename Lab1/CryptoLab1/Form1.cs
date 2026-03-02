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

            comboBoxAlgorithm.SelectedIndex = 0;
            comboBoxMode.SelectedIndex = 0;
        }

        // Кнопка Выполнить
        private void btnExecute_Click(object sender, EventArgs e)
        {

            string inputText = txtInput.Text;
            string key = txtKey.Text.Trim();
            int algorithm = comboBoxAlgorithm.SelectedIndex;

            // 0 = Encrypt, 1 = Decrypt
            int mode = comboBoxMode.SelectedIndex;

            // Проверки
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Введите текст или загрузите файл.", "Ошибка");
                return;
            }

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Введите ключ.", "Ошибка");
                return;
            }

            string result = "";

            try
            {
                // Столбцовый метод
                if (algorithm == 0)
                {
                    if (mode == 0)
                        result = CipherEngine.ColumnarEncrypt(inputText, key);
                    else
                        result = CipherEngine.ColumnarDecrypt(inputText, key);
                }
                // Шифр Виженера
                else
                {
                    if (mode == 0)
                        result = CipherEngine.VigenereEncrypt(inputText, key);
                    else
                        result = CipherEngine.VigenereDecrypt(inputText, key);
                }

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        // Кнопка Загрузить из файла
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текстовые файлы (*.txt)";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    txtInput.Text = fileContent;
                    txtResult.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка");
                }
            }
        }

        // Кнопка Сохранить в файл
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                MessageBox.Show("Нет результата для сохранения.", "Ошибка");
                return;
            }

            saveFileDialog.Filter = "Текстовые файлы (*.txt)";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Сохраняем результат
                    File.WriteAllText(saveFileDialog.FileName, txtResult.Text, Encoding.UTF8);
                    MessageBox.Show("Файл успешно сохранен!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка");
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
