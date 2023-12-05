namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 20
            // №1
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double first = -100.0;
            double step = 0.5;
            double first_res = progress(first, step, n);
            Console.WriteLine($"{n} член арифметической прогрессии при a1 = {first}, d = {step}: {first_res}");
            // №2
            Console.Write("Введите n2: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int d = 9;
            int q = -3;
            int second_res = GetGeom(d, q, n2);
            Console.WriteLine($"{n2} член геометрической прогрессии при b1 = {d}, q = {q}: {second_res}");
            // №3
            Console.Write("Введите A: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите B: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Все числа от {a} до {b}: ");
            int third_res = getNums(a, b);
            Console.WriteLine();
            // №4(4)
            Console.Write("Введите число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Перевёрнутое число: ");
            Reverse(num);
        }

        public static double progress(double fst, double stp, int n)
        {
            double res;
            if (n == 1)
            {
                return fst;
            }
            res = progress(fst + stp, stp, n - 1);
            return res;
        }

        public static int GetGeom(int d, int q, int n2)
        {
            int res;
            if (n2 == 1)
            {
                return 1;
            }
            else if (n2 == 2)
            {
                res = d * q;
            }
            else
            {
                res = q * GetGeom(n2 - 1, d, q);
            }
            return res;
        }

        public static int getNums(int a, int b)
        {
            Console.Write(a + " ");
            if (a == b)
            {
                return 0;
            }
            else if(a > b)
            {
                return getNums(a - 1, b);
            }
            return getNums(a + 1, b);
        }

        public static int Reverse(int num)
        {
            int cifra = num % 10;
            Console.Write(cifra);
            num /= 10;
            if (num > 0)
            {
                Reverse(num);
            }
            return 0;
        }
    }
}