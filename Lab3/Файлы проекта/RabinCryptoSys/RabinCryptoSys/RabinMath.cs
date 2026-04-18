using System;

namespace RabinCryptoSys
{
    public static class RabinMath
    {
        private static Random rnd = new Random();

        // Быстрое возведение в степень по модулю
        public static long FastExp(long a, long z, long mod)
        {
            long a1 = a % mod;
            long z1 = z;
            long x = 1;

            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 /= 2;
                    a1 = (a1 * a1) % mod;
                }
                z1--;
                x = (x * a1) % mod;
            }
            return x;
        }

        // Расширенный алгоритм Евклида
        public static long ExtendedEuclidean(long a, long b, out long gcd, out long x, out long y)
        {
            if (b == 0)
            {
                gcd = a;
                x = 1;
                y = 0;
                return gcd;
            }

            long x2 = 1, x1 = 0, y2 = 0, y1 = 1;
            while (b > 0)
            {
                long q = a / b;
                long r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            gcd = a;
            x = x2;
            y = y2;
            return gcd;
        }

        // Квадратный корень по модулю p (p mod 4 = 3)
        public static long ModSqrt(long a, long mod)
        {
            if (mod % 4 != 3)
                throw new ArgumentException("Модуль должен быть ≡ 3 (mod 4)");

            long exp = (mod + 1) / 4;
            return FastExp(a, exp, mod);
        }

        // Проверка на простоту
        public static bool IsPrime(long num)
        {
            if (num < 2) return false;
            if (num == 2 || num == 3) return true;
            if (num % 2 == 0) return false;

            long limit = (long)Math.Sqrt(num);
            for (long i = 3; i <= limit; i += 2)
                if (num % i == 0) return false;
            return true;
        }

        // Генерация случайного простого числа mod 4 = 3
        public static long GenerateRandomPrime(int minValue, int maxValue)
        {
            long value = rnd.Next(minValue, maxValue);

            if (value % 2 == 0) value++;
            while (value % 4 != 3)
                value += 2;

            while (!IsPrime(value))
                value += 4;

            return value;
        }

        // Решение квадратного уравнения, возвращает 4 корня
        public static long[] SolveQuadratic(long c, long b, long n, long p, long q)
        {
            long D = (b * b + 4 * c) % n;
            if (D < 0) D += n;

            long mp = ModSqrt(D % p, p);
            long mq = ModSqrt(D % q, q);

            long gcd, u, v;
            ExtendedEuclidean(p, q, out gcd, out u, out v);

            long invP = ((u % q) + q) % q;
            long invQ = ((v % p) + p) % p;

            long d1 = (invP * p * mq + invQ * q * mp) % n;
            if (d1 < 0) d1 += n;

            long d2 = n - d1;

            long d3 = (invP * p * mq - invQ * q * mp) % n;
            if (d3 < 0) d3 += n;

            long d4 = n - d3;

            long[] result = new long[4];
            long[] ds = { d1, d2, d3, d4 };

            for (int i = 0; i < 4; i++)
            {
                long di = ds[i];
                long numerator;

                if ((di - b) % 2 == 0)
                    numerator = -b + di;
                else
                    numerator = -b + n + di;

                if (numerator % 2 != 0)
                    numerator += n;

                result[i] = ((numerator / 2) % n + n) % n;
            }

            return result;
        }

        // Проверка параметров
        public static string ValidateParameters(long p, long q, long b)
        {
            if (!IsPrime(p))
                return "p должно быть простым числом";

            if (!IsPrime(q))
                return "q должно быть простым числом";

            if (p % 4 != 3)
                return "p = 3 (mod 4)";

            if (q % 4 != 3)
                return "q = 3 (mod 4)";

            if (p == q)
                return "p и q должны быть разными";

            long n = p * q;
            if (b < 0 || b >= n)
                return $"b должно быть < {n}";

            if (n <= 256)
                return $"n = p*q должно быть > 256 (сейчас {n})";

            return null;
        }
    }
}