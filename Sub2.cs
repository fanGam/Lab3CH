using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;

namespace Lab3CH
{
    class Sub2
    {
        private int n, m;
        private int[,] Matr;
        private Random rnd = new Random();
        public Sub2()
        {
            Matr = new int[5, 5];
            int elem;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Matr[i, j] = rnd.Next(25);
                }
            }
        }
        public Sub2(int a, int b)
        {
            this.n = a;
            this.m = b;
            Matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Matr[i, j] = rnd.Next(25);
                }
            }
        }
        public void Lab22()
        {
            double Avg = 0;
            uint Sum = 0;
            for (int i = 0; i < n; i++) Avg += Matr[i, 0];
            Avg = Avg / n;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Matr[i, j] > Avg) Sum++;
                }
            }
            Console.WriteLine($"Всего {Sum} чисел больше среднего арифметического 1ого столбца");
        }
        public static Sub2 operator +(Sub2 a, Sub2 b)
        {
            if (a.m != b.m)
            {
                Console.WriteLine("А вот так незя!");
                return null;
            }
            Sub2 c = new Sub2(a.m, b.n);
            int summ = 0;
            for (int i = 0; i < c.n; i++)
            {
                for (int j = 0; j < c.m; j++)
                {
                    summ = 0;
                    for (int o = i, p = j; o < c.n; o++, p++)
                    {
                        summ += a.Matr[i, p] + b.Matr[j, o];
                    }
                    c.Matr[i,j] = summ;
                }
            }
            return c;
        } 
    }
}
