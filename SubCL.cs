namespace Lab3CH
{
    class SubCL
    {
        private int[,] Matr;
        private int n, m;
        private Random rnd = new Random();
        private void Init()
        {
            Console.WriteLine("Введите размер матрицы");
            n = 0;
            m = 0;
            while(n == 0 || m == 0)
            {
                try
                {
                    Console.WriteLine("Введите n ");
                    this.n = int.Parse(Console.ReadLine());
                    if (this.n <= 0)
                    {
                        Console.WriteLine("Попраим ввод за вас...");
                        n = 1;
                    }
                    Console.WriteLine("Введите m");
                    this.m = int.Parse(Console.ReadLine());
                    if (this.m <= 0)
                    {
                        Console.WriteLine("Попраим ввод за вас...");
                        m = 1;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Похоже кто-то в циферки не попал!");
                }
            }
            Matr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Matr[i, j] = 0;
                }
            }
        }
        private void Mass1()
        {
            int r = n + m - 1;
            int i = r;
            int i1;
            int j;
            int inp;
            while (i >= 0)
            {
                i1 = i;
                j = 0;
                while (i1 < r)
                {
                    if (i1 >= r - n && j < m)
                    {
                        try
                        {
                            inp = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Кто-то что-то не так написал!");
                            inp = 0;
                        }
                        this.Matr[i1 - r + n, j] = inp;
                    }
                    i1++;
                    j++;
                }
                i--;
            }

        }
        public SubCL()
        {
            Init();
            Mass1();
        }
        public SubCL(int n)
        {
            this.n = n;
            this.m = n;
            Matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr[i, j] = rnd.Next(25) + ((n - j) * 25);
                }
            }
        }
        private void Mass3(int i, int j, int numb, int t)
        {
            bool a = false;
            while (i < n - t)
            {
                a = true;
                Matr[i, j] = numb++;
                i++;
            }
            while (j < n - t)
            {
                a = true;
                Matr[i, j] = numb++;
                j++;
            }
            while (i > t - 1)
            {
                a = true;
                Matr[i, j] = numb++;
                i--;
            }
            while (j > t - 1)
            {
                a = true;
                Matr[i, j] = numb++;
                j--;
            }
            if (a)
            {
                Mass3(i + 1, j + 1, numb, t + 1);
            }
            else
            {
                if (i == n - t)
                {
                    Matr[i, j] = numb;
                }
            }
        }
        public SubCL(int n, int _)
        {
            this.n = n;
            this.m = n;
            Matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr[i, j] = 0;
                }
            }
            Mass3(0, 0, 1, 1);
        }
        public override string ToString()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0,5}", this.Matr[i, j]);
                }
                Console.WriteLine();
            }
            return "--------------------";
        }
    }
}
