using System;
using System.Text;

namespace CryptoLab1
{
    // Класс с алгоритмами шифрования
    public static class CipherEngine
    {

        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const char PaddingChar = '#';
        public static int OriginalTextLength { get; private set; }

        public static void Reset()
        {
            OriginalTextLength = 0;
        }

        // Оставляет в тексте только русские буквы (Для обычного текста и ключа)
        private static string FilterRussianText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char upperC = char.ToUpperInvariant(input[i]);
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

        // фильтр для шифротекста (в столбцовом методе)
        private static string FilterCipherText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == PaddingChar)
                {
                    result += c;
                    continue;
                }

                char upperC = char.ToUpperInvariant(c);
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

        // Пузырьковая сортировка для получения порядка столбцов
        private static int[] GetColumnOrder(string key)
        {
            int[] indices = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
                indices[i] = i;

            // Сортируем индексы по соответствующим буквам ключа
            for (int i = 0; i < key.Length - 1; i++)
            {
                for (int j = 0; j < key.Length - i - 1; j++)
                {
                    if (key[indices[j]] > key[indices[j + 1]])
                    {
                        int temp = indices[j];
                        indices[j] = indices[j + 1];
                        indices[j + 1] = temp;
                    }
                }
            }
            return indices;
        }

        // Шифрование Столбцовым методом
        public static string ColumnarEncrypt(string plainText, string key)
        {
            try
            {
                string filteredText = FilterRussianText(plainText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                OriginalTextLength = filteredText.Length;

                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";

                int cols = filteredKey.Length;
                int rows = (int)Math.Ceiling((double)filteredText.Length / cols);

                // Создаем таблицу и заполняем
                char[,] table = new char[rows, cols];
                int textPos = 0;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (textPos < filteredText.Length)
                        {
                            table[r, c] = filteredText[textPos];
                            textPos++;
                        }
                        else
                        {
                            table[r, c] = PaddingChar;
                        }
                    }
                }

                // Получаем порядок столбцов
                int[] columnOrder = GetColumnOrder(filteredKey);

                // Читаем по столбцам
                string result = "";
                for (int i = 0; i < cols; i++)
                {
                    int col = columnOrder[i];
                    for (int r = 0; r < rows; r++)
                    {
                        result += table[r, col];
                    }
                }

                return result;
            }
            catch
            {
                return "ОШИБКА";
            }
        }

        // Расшифрование Столбцового метода
        public static string ColumnarDecrypt(string cipherText, string key)
        {
            try
            {
                // используем специальный фильтр для шифротекста
                string filteredText = FilterCipherText(cipherText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";

                int cols = filteredKey.Length;
                int rows = (int)Math.Ceiling((double)filteredText.Length / cols);

                // Получаем порядок столбцов
                int[] columnOrder = GetColumnOrder(filteredKey);

                // Создаем пустую таблицу
                char[,] table = new char[rows, cols];
                int textPos = 0;

                // Заполняем по столбцам в правильном порядке
                for (int i = 0; i < cols; i++)
                {
                    int col = columnOrder[i];
                    for (int r = 0; r < rows; r++)
                    {
                        if (textPos < filteredText.Length)
                        {
                            table[r, col] = filteredText[textPos];
                            textPos++;
                        }
                    }
                }

                // Читаем по строкам
                string result = "";
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        result += table[r, c];
                    }
                }

                // Удаляем все символы # в конце
                result = result.TrimEnd(PaddingChar);
                return result;
            }
            catch
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

