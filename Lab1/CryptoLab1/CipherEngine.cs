using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CryptoLab1
{
    // Класс для  алгоритмов шифрования
    public static class CipherEngine
    {
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public static int OriginalTextLength { get; private set; }

        // Очищает строку, оставляя только русские буквы (приводит к ВЕРХНЕМУ регистру)
        private static string FilterRussianText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                char upperC = char.ToUpperInvariant(c);
                if (RussianAlphabet.Contains(upperC))
                {
                    result.Append(upperC);
                }
            }
            return result.ToString();
        }

        // Возвращает индекс буквы в русском алфавите
        private static int GetLetterIndex(char c)
        {
            char upperC = char.ToUpperInvariant(c);
            int index = RussianAlphabet.IndexOf(upperC);
            if (index == -1)
            {
                throw new ArgumentException($"Символ '{c}' не является русской буквой");
            }
            return index;
        }

        /// Возвращает букву по индексу
        private static char GetLetterByIndex(int index)
        {
            if (index < 0 || index >= RussianAlphabet.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index} выходит за пределы алфавита (0-{RussianAlphabet.Length - 1})");
            return RussianAlphabet[index];
        }

        /// Создает список с номерами для повторяющихся букв в ключе
        private static List<(char letter, int occurrence, int originalIndex)> ProcessKeyWithOccurrences(string key)
        {
            var result = new List<(char, int, int)>();
            var occurrenceCount = new Dictionary<char, int>();

            for (int i = 0; i < key.Length; i++)
            {
                char letter = key[i];
                if (occurrenceCount.ContainsKey(letter))
                {
                    occurrenceCount[letter]++;
                }
                else
                {
                    occurrenceCount[letter] = 1;
                }
                result.Add((letter, occurrenceCount[letter], i));
            }
            return result;
        }

        public static void Reset()
        {
            OriginalTextLength = 0;
        }

        //СТОЛБЦОВЫЙ МЕТОД
        public static string ColumnarEncrypt(string plainText, string key)
        {
            try
            {
                Debug.WriteLine("\nСТОЛБЦОВЫЙ МЕТОД (ШИФРОВАНИЕ)");

                string filteredText = FilterRussianText(plainText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                // СОХРАНЯЕМ ДЛИНУ В ГЛОБАЛЬНУЮ ПЕРЕМЕННУЮ
                OriginalTextLength = filteredText.Length;
                Debug.WriteLine($"1. Текст: {filteredText}");
                Debug.WriteLine($"   Длина: {OriginalTextLength}");

                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    string errorMsg = "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                    Debug.WriteLine(errorMsg);
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }

                var keyWithOccurrences = ProcessKeyWithOccurrences(filteredKey);
                Debug.WriteLine($"2. Ключ: {filteredKey}");
                Debug.WriteLine($"   Длина: {filteredKey.Length}");

                int numCols = filteredKey.Length;
                int numRows = (int)Math.Ceiling((double)filteredText.Length / numCols);
                Debug.WriteLine($"3. Таблица: {numRows} × {numCols}");

                // Заполняем таблицу
                char[,] table = new char[numRows, numCols];
                int textIndex = 0;

                // Счетчик для заполнителей
                int paddingCount = 0;

                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        if (textIndex < filteredText.Length)
                        {
                            table[r, c] = filteredText[textIndex++];
                        }
                        else
                        {
                            table[r, c] = RussianAlphabet[paddingCount % RussianAlphabet.Length];
                            paddingCount++;
                        }
                    }
                }

                Debug.WriteLine("\n4. Заполненная таблица:");

                string keyHeader = "   ";
                for (int c = 0; c < numCols; c++)
                {
                    keyHeader += $" {filteredKey[c]}  ";
                }
                Debug.WriteLine(keyHeader);


                // Выводим строки таблицы
                for (int r = 0; r < numRows; r++)
                {
                    string rowStr = $"{r + 1,2} |";
                    for (int c = 0; c < numCols; c++)
                    {
                        rowStr += $" {table[r, c]}  ";
                    }
                    Debug.WriteLine(rowStr);
                }
                

                var sortedColumns = keyWithOccurrences
                    .OrderBy(x => x.letter)
                    .ThenBy(x => x.occurrence)
                    .ToList();

                // Чтение столбцов
                StringBuilder cipherText = new StringBuilder();
                
                foreach (var col in sortedColumns)
                {
                    int colIndex = col.originalIndex;
                    string columnData = "";
                    for (int r = 0; r < numRows; r++)
                    {
                        cipherText.Append(table[r, colIndex]);
                        columnData += table[r, colIndex];
                    }
                    
                }

                string result = cipherText.ToString();
                Debug.WriteLine($"\n7. РЕЗУЛЬТАТ: {result}");

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ОШИБКА: {ex.Message}");
                return "ОШИБКА";
            }
        }

        public static string ColumnarDecrypt(string cipherText, string key)
        {
            try
            {
                Debug.WriteLine("\nСТОЛБЦОВЫЙ МЕТОД (ДЕШИФРОВАНИЕ)");

                if (OriginalTextLength == 0)
                {
                    Debug.WriteLine(" Ошибка! ");
                }
                else
                {
                    Debug.WriteLine($"0. Длина: {OriginalTextLength}");
                }

                // Фильтруем шифротекст
                string filteredText = FilterRussianText(cipherText);
                if (string.IsNullOrEmpty(filteredText)) return "";
                Debug.WriteLine($"1. Шифротекст: {filteredText}");

                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    string errorMsg = "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                    Debug.WriteLine(errorMsg);
                    throw new ArgumentException("Ключ должен содержать хотя бы одну русскую букву");
                }
                ;

                var keyWithOccurrences = ProcessKeyWithOccurrences(filteredKey);
                Debug.WriteLine($"2. Ключ: {filteredKey}");

                int numCols = filteredKey.Length;
                int numRows = (int)Math.Ceiling((double)filteredText.Length / numCols);
                Debug.WriteLine($"3. Размер: {numRows}× {numCols}");

                var sortedKey = keyWithOccurrences
                    .OrderBy(x => x.letter)
                    .ThenBy(x => x.occurrence)
                    .ToList();

                char[,] table = new char[numRows, numCols];

                // Заполняем таблицу по столбцам
                int textIndex = 0;

                foreach (var item in sortedKey)
                {
                    int colToWrite = item.originalIndex;
                    string columnData = "";
                    for (int r = 0; r < numRows; r++)
                    {
                        if (textIndex < filteredText.Length)
                        {
                            table[r, colToWrite] = filteredText[textIndex++];
                        }
                        else
                        {
                            table[r, colToWrite] = '?';
                        }
                        columnData += table[r, colToWrite];
                    }
                }

                string keyHeader = "   ";
                for (int c = 0; c < numCols; c++)
                {
                    keyHeader += $" {filteredKey[c]}  ";
                }
                Debug.WriteLine(keyHeader);

                for (int r = 0; r < numRows; r++)
                {
                    string rowStr = $"{r + 1,2} |";
                    for (int c = 0; c < numCols; c++)
                    {
                        rowStr += $" {table[r, c]}  ";
                    }
                    Debug.WriteLine(rowStr);
                }

                // Читаем таблицу построчно
                StringBuilder plainText = new StringBuilder();
                for (int r = 0; r < numRows; r++)
                {
                    string rowData = "";
                    for (int c = 0; c < numCols; c++)
                    {
                        plainText.Append(table[r, c]);
                        rowData += table[r, c];
                    }
                }

                string fullText = plainText.ToString();
                string result;

                if (OriginalTextLength > 0 && OriginalTextLength <= fullText.Length)
                {
                    result = fullText.Substring(0, OriginalTextLength);
                }
                else
                {
                    result = fullText.TrimEnd(RussianAlphabet.ToCharArray());
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ОШИБКА: {ex.Message}");
                return "ОШИБКА";
            }
        }

        //ШИФР ВИЖЕНЕР
        public static string VigenereEncrypt(string plainText, string key)
        {
            try
            {
                Debug.WriteLine("\nШИФР ВИЖЕНЕРА (ШИФРОВАНИЕ)");

                string filteredText = FilterRussianText(plainText);
                if (string.IsNullOrEmpty(filteredText)) return "";

                OriginalTextLength = filteredText.Length;
                Debug.WriteLine($"Текст: {filteredText} (длина: {OriginalTextLength})");

                string filteredKey = FilterRussianText(key);
                if(string.IsNullOrEmpty(filteredKey))
        {
                    string errorMsg = "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                    Debug.WriteLine(errorMsg);
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }
                
                Debug.WriteLine($"Ключ: {filteredKey}");

                List<char> keyStream = new List<char>(filteredKey.ToCharArray());
                StringBuilder result = new StringBuilder();

                Debug.WriteLine("\n3. Процесс шифрования:");
                Debug.WriteLine("   i | Текст | Индекс | Ключ | Индекс | Сумма | Результат");
                Debug.WriteLine("   -------------------------------------------------");

                for (int i = 0; i < filteredText.Length; i++)
                {
                    int pIndex = GetLetterIndex(filteredText[i]);
                    int kIndex = GetLetterIndex(keyStream[i]);

                    int cIndex = (pIndex + kIndex) % RussianAlphabet.Length;
                    char cipherChar = GetLetterByIndex(cIndex);

                    result.Append(cipherChar);
                    keyStream.Add(filteredText[i]);

                    Debug.WriteLine($"   {i,2} | {filteredText[i]}     | {pIndex,3}   | {keyStream[i]}     | {kIndex,3}   | {pIndex + kIndex,3}   | {cipherChar}");
                }

                Debug.WriteLine($"\n4. РЕЗУЛЬТАТ: {result}");
                return result.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ОШИБКА: {ex.Message}");
                return "ОШИБКА";
            }
        }

        public static string VigenereDecrypt(string cipherText, string key)
        {
            try
            {
                Debug.WriteLine("\nШИФР ВИЖЕНЕРА (ДЕШИФРОВАНИЕ)");

                string filteredCipher = FilterRussianText(cipherText);
                if (string.IsNullOrEmpty(filteredCipher)) return "";
                Debug.WriteLine($"1. Шифротекст: {filteredCipher}");

                string filteredKey = FilterRussianText(key);
                if (string.IsNullOrEmpty(filteredKey))
                {
                    string errorMsg = "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                    Debug.WriteLine(errorMsg);
                    return "ОШИБКА: Ключ не содержит ни одной русской буквы!";
                }

                Debug.WriteLine($"2. Ключ: {filteredKey}");

                List<char> keyStream = new List<char>(filteredKey.ToCharArray());
                StringBuilder result = new StringBuilder();

                Debug.WriteLine("\n3. Процесс дешифрования:");
                Debug.WriteLine("   i | Шифр | Индекс | Ключ | Индекс | Разность | Результат");
                Debug.WriteLine("   ----------------------------------------------------");

                for (int i = 0; i < filteredCipher.Length; i++)
                {
                    int cIndex = GetLetterIndex(filteredCipher[i]);
                    int kIndex = GetLetterIndex(keyStream[i]);

                    int pIndex = (cIndex - kIndex + RussianAlphabet.Length) % RussianAlphabet.Length;
                    char plainChar = GetLetterByIndex(pIndex);

                    result.Append(plainChar);
                    keyStream.Add(plainChar);

                    Debug.WriteLine($"   {i,2} | {filteredCipher[i]}     | {cIndex,3}   | {keyStream[i]}     | {kIndex,3}   | {cIndex - kIndex,5}   | {plainChar}");
                }

                Debug.WriteLine($"\n4. РЕЗУЛЬТАТ: {result}");
                return result.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ОШИБКА: {ex.Message}");
                return "ОШИБКА";
            }
        }
    }
}