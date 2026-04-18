using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RabinCryptoSys
{
    public partial class Form1 : Form
    {
        private string selectedFilePath = "";
        private long p, q, b, n;
        private bool parametersValid = false;

        public Form1()
        {
            InitializeComponent();

            buttonSelectFile.Click += ButtonSelectFile_Click;
            buttonProcess.Click += ButtonProcess_Click;
            buttonGenerate.Click += ButtonGenerate_Click;
            buttonCheck.Click += ButtonCheck_Click;

            // Устанавливаем начальные значения параметров
            textBoxP.Text = "11";
            textBoxQ.Text = "19";
            textBoxB.Text = "173";
        }

        // Создаём случайные параметры p, q, b
        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            // Генерируем простые числа p и q
            p = RabinMath.GenerateRandomPrime(100, 500);
            q = RabinMath.GenerateRandomPrime(100, 500);

            // Убеждаемся, что p и q разные
            while (q == p)
                q = RabinMath.GenerateRandomPrime(100, 500);

            // Генерируем случайное b
            b = new Random().Next(1, 100);

            // Отображаем сгенерированные значения в полях ввода
            textBoxP.Text = p.ToString();
            textBoxQ.Text = q.ToString();
            textBoxB.Text = b.ToString();

            // Очищаем поля вывода
            textBoxOriginal.Clear();
            textBoxEncrypted.Clear();

            // Показываем информацию о сгенерированных параметрах
            MessageBox.Show($"Сгенерированы параметры:\n\np = {p}\nq = {q}\nb = {b}\nn = p × q = {p * q}",
                "Генерация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Проверяем корректность введённых параметров
        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            // Пытаемся преобразовать введённые строки в числа
            if (!long.TryParse(textBoxP.Text, out p) ||
                !long.TryParse(textBoxQ.Text, out q) ||
                !long.TryParse(textBoxB.Text, out b))
            {
                MessageBox.Show("Введите корректные числа");
                return;
            }

            // Проверяем параметры на соответствие требованиям криптосистемы Рабина
            string error = RabinMath.ValidateParameters(p, q, b);

            if (error == null)
            {
                parametersValid = true;
                n = p * q;
                textBoxN.Text = n.ToString();

                // Показываем открытый и закрытый ключи
                MessageBox.Show("Параметры корректны!\n\nОткрытый ключ:\n  n = " + n + "\n  b = " + b + "\n\nЗакрытый ключ:\n  p = " + p + "\n  q = " + q,
                    "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametersValid = false;
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Выбор файла для шифрования/расшифрования
        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выберите файл";
            dlg.Filter = "Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = dlg.FileName;
                textBoxFilePath.Text = selectedFilePath;

                // Очищаем поля вывода при выборе нового файла
                textBoxOriginal.Clear();
                textBoxEncrypted.Clear();
            }
        }

        // Основная логика шифрования/расшифрования
        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            // Проверяем, что параметры проверены
            if (!parametersValid)
            {
                MessageBox.Show("Сначала проверьте параметры (кнопка 'Проверить')");
                return;
            }

            // Проверяем, что файл выбран и существует
            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("Выберите файл");
                return;
            }

            // Получаем части пути для формирования имени выходного файла
            string dir = Path.GetDirectoryName(selectedFilePath);    
            string name = Path.GetFileNameWithoutExtension(selectedFilePath); 
            string ext = Path.GetExtension(selectedFilePath);   

            // Максимальное количество отображаемых элементов
            const int MAX_DISPLAY = 500;

            // ШИФРОВАНИЕ
            if (radioEncrypt.Checked)
            {
                // Читаем все байты исходного файла в массив
                byte[] data = File.ReadAllBytes(selectedFilePath);

                // Создаём массив для зашифрованных данных
                long[] encrypted = new long[data.Length];

                // Шифруем каждый байт по формуле: c = m * (m + b) mod n
                for (int i = 0; i < data.Length; i++)
                {
                    encrypted[i] = (data[i] * (data[i] + b)) % n;
                }

                // Формируем имя выходного файла с суффиксом "_encrypted"
                string outPath = Path.Combine(dir, name + "_encrypted" + ext);

                // Сохраняем зашифрованные данные (каждое число как 4 байта)
                using (FileStream fs = new FileStream(outPath, FileMode.Create))
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    for (int i = 0; i < encrypted.Length; i++)
                    {
                        w.Write((uint)encrypted[i]); 
                    }
                }

                // Вывод исходных байт
                int show = Math.Min(data.Length, MAX_DISPLAY);
                StringBuilder sb1 = new StringBuilder();
                sb1.AppendLine($"ИСХОДНЫЙ ФАЙЛ: {data.Length} байт");

                for (int i = 0; i < show; i++)
                {
                    sb1.Append(data[i]);
                    if (i < show - 1) sb1.Append(", ");
                    if ((i + 1) % 20 == 0) sb1.AppendLine();
                }

                // Если байт больше, чем показываем, выводим сообщение
                if (data.Length > MAX_DISPLAY)
                    sb1.Append($"\n... и ещё {data.Length - MAX_DISPLAY} байт");

                textBoxOriginal.Text = sb1.ToString();

                // Вывод зашифрованных чисел
                show = Math.Min(encrypted.Length, MAX_DISPLAY);
                StringBuilder sb2 = new StringBuilder();
                sb2.AppendLine($"ЗАШИФРОВАНО: {encrypted.Length} чисел (в десятичной системе)");

                for (int i = 0; i < show; i++)
                {
                    sb2.Append(encrypted[i]);
                    if (i < show - 1) sb2.Append(", ");
                    if ((i + 1) % 10 == 0) sb2.AppendLine();
                }

                if (encrypted.Length > MAX_DISPLAY)
                    sb2.Append($"\n... и ещё {encrypted.Length - MAX_DISPLAY} чисел");

                textBoxEncrypted.Text = sb2.ToString();

                MessageBox.Show($"Файл зашифрован!\n\nИсходный размер: {data.Length} байт\nЗашифрованный размер: {encrypted.Length * 4} байт\nСохранён как: {Path.GetFileName(outPath)}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // РАСШИФРОВАНИЕ
            else
            {
                // Определяем количество зашифрованных блоков (размер файла / 4 байта)
                FileInfo fi = new FileInfo(selectedFilePath);
                int count = (int)(fi.Length / 4);

                // Читаем зашифрованные блоки из файла
                long[] encrypted = new long[count];
                using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open))
                using (BinaryReader r = new BinaryReader(fs))
                {
                    for (int i = 0; i < count; i++)
                    {
                        encrypted[i] = r.ReadUInt32();
                    }
                }

                // Вывод зашифрованных чисел
                int show = Math.Min(encrypted.Length, MAX_DISPLAY);
                StringBuilder sb1 = new StringBuilder();
                sb1.AppendLine($"ЗАШИФРОВАННЫЙ ФАЙЛ: {encrypted.Length} чисел (в десятичной системе)");

                for (int i = 0; i < show; i++)
                {
                    sb1.Append(encrypted[i]);
                    if (i < show - 1) sb1.Append(", ");
                    if ((i + 1) % 10 == 0) sb1.AppendLine();
                }

                if (encrypted.Length > MAX_DISPLAY)
                    sb1.Append($"\n... и ещё {encrypted.Length - MAX_DISPLAY} чисел");

                textBoxEncrypted.Text = sb1.ToString();

                // Расшифровываем каждый блок
                byte[] decrypted = new byte[count];
                for (int i = 0; i < encrypted.Length; i++)
                {
                    long c = encrypted[i];

                    // Решаем квадратное уравнение (получаем 4 возможных корня)
                    long[] roots = RabinMath.SolveQuadratic(c, b, n, p, q);

                    // Ищем корень, который меньше 256
                    for (int j = 0; j < 4; j++)
                    {
                        if (roots[j] >= 0 && roots[j] < 256)
                        {
                            // Проверяем, что корень действительно правильный
                            if ((roots[j] * (roots[j] + b)) % n == c)
                            {
                                decrypted[i] = (byte)roots[j];
                                break;
                            }
                        }
                    }
                }

                // Сохраняем расшифрованный файл
                string outPath = Path.Combine(dir, name + "_decrypted" + ext);
                File.WriteAllBytes(outPath, decrypted);

                // Вывод расшифрованных байт
                show = Math.Min(decrypted.Length, MAX_DISPLAY);
                StringBuilder sb2 = new StringBuilder();
                sb2.AppendLine($"РАСШИФРОВАННЫЙ ФАЙЛ: {decrypted.Length} байт");

                for (int i = 0; i < show; i++)
                {
                    sb2.Append(decrypted[i]);
                    if (i < show - 1) sb2.Append(", ");
                    if ((i + 1) % 20 == 0) sb2.AppendLine();
                }

                if (decrypted.Length > MAX_DISPLAY)
                    sb2.Append($"\n... и ещё {decrypted.Length - MAX_DISPLAY} байт");

                textBoxOriginal.Text = sb2.ToString();

                MessageBox.Show($"Файл расшифрован!\n\nБлоков: {count}\nБайт: {decrypted.Length}\nСохранён как: {Path.GetFileName(outPath)}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}