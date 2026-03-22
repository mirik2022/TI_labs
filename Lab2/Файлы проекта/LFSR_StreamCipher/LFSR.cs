using System;

namespace LFSR_StreamCipher
{
    public class LFSR
    {
        private uint state;
        private uint mask;

        public LFSR(string initialState, uint polynomialMask)
        {
            // Преобразуем строку битов в число
            state = 0;
            for (int i = 0; i < 32; i++)
            {
                state = state << 1;
                if (initialState[i] == '1')
                {
                    state = state | 1;
                }
            }

            mask = polynomialMask;
        }

        // Получить следующий бит
        public byte NextBit()
        {
            // Старший бит - выходной
            byte output = (byte)((state >> 31) & 1);

            // Вычисляем бит обратной связи
            uint feedback = 0;
            uint m = mask;

            for (int i = 0; i < 32; i++)
            {
                if ((m & 1) == 1)
                {
                    feedback = feedback ^ ((state >> i) & 1);
                }
                m = m >> 1;
            }

            // Сдвигаем и вставляем бит
            state = (state << 1) | (feedback & 1);

            return output;
        }

        // Получить следующий байт
        public byte NextByte()
        {
            byte result = 0;
            for (int i = 0; i < 8; i++)
            {
                result = (byte)((result << 1) | NextBit());
            }
            return result;
        }
    }
}