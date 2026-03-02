using System;
using System.Text;

namespace CryptoLab1
{
    // Класс с алгоритмами шифрования
    public static class CipherEngine
    {

        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public static int OriginalTextLength { get; private set; }

        public static void Reset()
        {
            OriginalTextLength = 0;
        }

        // Оставляет в тексте только русские буквы
        private static string FilterRussianText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            string result = "";

            // Перебираем каждый символ во входной строке
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                char upperC = char.ToUpperInvariant(c); 

                // Проверяем, есть ли этот символ в нашем алфавите
                for (int j = 0; j < RussianAlphabet.Length; j++)
                {
                    if (RussianAlphabet[j] == upperC)
                    {
                        result += upperC;
                        break;
                    }
                }
            }
            return result;
        }

        // Получает индекс буквы в алфавите
        private static int GetLetterIndex(char c)
        {
            char upperC = char.ToUpperInvariant(c);

            // Ищем букву в алфавите
            for (int i = 0; i < RussianAlphabet.Length; i++)
            {
                if (RussianAlphabet[i] == upperC)
                {
                    return i;
                }
            }
            return -1;
        }

        // Получает букву по её индексу 
        private static char GetLetterByIndex(int index)
        {
            if (index < 0 || index >= RussianAlphabet.Length)
                return '?';

            return RussianAlphabet[index];
        }



        // Шифрование Столбцовым методом
        public static string ColumnarEncrypt(string plainText, string key)
        {
            try
            {
                //Фильтруем текст
                string filteredText = FilterRussianText(plainText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                OriginalTextLength = filteredText.Length;

                //Фильтруем ключ
                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }

                // Определяем размеры таблицы
                int numCols = filteredKey.Length;   
                int numRows = (int)Math.Ceiling((double)filteredText.Length / numCols);

                char[,] table = new char[numRows, numCols];
                int textIndex = 0;

                // Заполняем таблицу текстом по строкам
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        if (textIndex < filteredText.Length)
                        {
                            table[row, col] = filteredText[textIndex];
                            textIndex++;
                        }
                        else
                        {
                            // Текст закончился - заполняем пустые ячейки буквами по порядку
                            table[row, col] = RussianAlphabet[(row * numCols + col - filteredText.Length) % RussianAlphabet.Length];
                        }
                    }
                }

                // Определяем порядок чтения столбцов на основе ключа
                int[] columnOrder = new int[numCols];

                // Создаем массив для сортировки
                int[] keyIndices = new int[numCols];
                for (int i = 0; i < numCols; i++)
                {
                    keyIndices[i] = i;
                }

                // Сортируем пузырьком (keyIndices содержит порядок чтения столбцов)
                for (int i = 0; i < numCols - 1; i++)
                {
                    for (int j = 0; j < numCols - i - 1; j++)
                    {
                        if (filteredKey[keyIndices[j]] > filteredKey[keyIndices[j + 1]])
                        {
                            int temp = keyIndices[j];
                            keyIndices[j] = keyIndices[j + 1];
                            keyIndices[j + 1] = temp;
                        }
                    }
                }

                // Читаем столбцы в этом порядке
                string cipherText = "";

                for (int i = 0; i < numCols; i++)
                {
                    int colToRead = keyIndices[i];

                    for (int row = 0; row < numRows; row++)
                    {
                        cipherText += table[row, colToRead];
                    }
                }

                return cipherText;
            }
            catch (Exception)
            {
                return "ОШИБКА";
            }
        }

        // Расшифрование Столбцового метода
        public static string ColumnarDecrypt(string cipherText, string key)
        {
            try
            {
                // Фильтруем шифротекст
                string filteredText = FilterRussianText(cipherText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                // Фильтруем ключ
                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    throw new ArgumentException("Ключ должен содержать хотя бы одну русскую букву");
                }

                // Определяем размеры таблицы
                int numCols = filteredKey.Length;
                int numRows = (int)Math.Ceiling((double)filteredText.Length / numCols);

                // Определяем порядок чтения столбцов
                int[] keyIndices = new int[numCols];
                for (int i = 0; i < numCols; i++)
                {
                    keyIndices[i] = i;
                }

                // Сортируем пузырьком
                for (int i = 0; i < numCols - 1; i++)
                {
                    for (int j = 0; j < numCols - i - 1; j++)
                    {
                        if (filteredKey[keyIndices[j]] > filteredKey[keyIndices[j + 1]])
                        {
                            int temp = keyIndices[j];
                            keyIndices[j] = keyIndices[j + 1];
                            keyIndices[j + 1] = temp;
                        }
                    }
                }

                char[,] table = new char[numRows, numCols];

                // Заполняем таблицу по столбцам из шифротекста
                int textIndex = 0;

                for (int i = 0; i < numCols; i++)
                {
                    int colToWrite = keyIndices[i];

                    for (int row = 0; row < numRows; row++)
                    {
                        if (textIndex < filteredText.Length)
                        {
                            table[row, colToWrite] = filteredText[textIndex];
                            textIndex++;
                        }
                        else
                        {
                            table[row, colToWrite] = '?';
                        }
                    }
                }

                // Читаем таблицу построчно
                string plainText = "";

                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        plainText += table[row, col];
                    }
                }

                // Обрезаем до нужной длины
                if (OriginalTextLength > 0 && OriginalTextLength <= plainText.Length)
                {
                    plainText = plainText.Substring(0, OriginalTextLength);
                }

                return plainText;
            }
            catch (Exception)
            {
                return "ОШИБКА";
            }
        }

        // Шифрование Виженером
        public static string VigenereEncrypt(string plainText, string key)
        {
            try
            {
                // Фильтруем текст
                string filteredText = FilterRussianText(plainText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                OriginalTextLength = filteredText.Length;

                // Фильтруем ключ
                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }

                // Создаем ключ (самогенерирующийся)
                char[] keyStream = new char[filteredText.Length];

                for (int i = 0; i < filteredKey.Length && i < filteredText.Length; i++)
                {
                    keyStream[i] = filteredKey[i];
                }

                // Шифруем
                string result = "";

                for (int i = 0; i < filteredText.Length; i++)
                {
                    int pIndex = GetLetterIndex(filteredText[i]);

                    int kIndex = GetLetterIndex(keyStream[i]);

                    // Складываем индексы (Ci = Pi + Ki mod 33)
                    int cIndex = (pIndex + kIndex) % 33;
                    char cipherChar = GetLetterByIndex(cIndex);

                    result += cipherChar;

                    // Добавляем текущую букву текста в ключ
                    if (i + filteredKey.Length < filteredText.Length)
                    {
                        keyStream[i + filteredKey.Length] = filteredText[i];
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return "ОШИБКА";
            }
        }

        // Дешифрование Виженера
        public static string VigenereDecrypt(string cipherText, string key)
        {
            try
            {
                // Фильтруем шифротекст
                string filteredCipher = FilterRussianText(cipherText);
                if (string.IsNullOrEmpty(filteredCipher)) return "";

                // Фильтруем ключ
                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }

                // Создаем ключ
                char[] keyStream = new char[filteredCipher.Length];

                for (int i = 0; i < filteredKey.Length && i < filteredCipher.Length; i++)
                {
                    keyStream[i] = filteredKey[i];
                }

                // Дешифруем
                string result = "";

                for (int i = 0; i < filteredCipher.Length; i++)
                {
                    int cIndex = GetLetterIndex(filteredCipher[i]);

                    int kIndex = GetLetterIndex(keyStream[i]);

                    // Вычитаем индексы (Pi = Ci - Ki mod 33)
                    int pIndex = (cIndex - kIndex + 33) % 33;
                    char plainChar = GetLetterByIndex(pIndex);

                    result += plainChar;

                    // Добавляем расшифрованную букву в ключ
                    if (i + filteredKey.Length < filteredCipher.Length)
                    {
                        keyStream[i + filteredKey.Length] = plainChar;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return "ОШИБКА";
            }
        }
    }
}
