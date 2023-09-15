namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число h: ");
            double h = Convert.ToDouble(Console.ReadLine());
            double x = 0.0;
            double y = 0.0;
            if (h > 3.5) // обработка первого условия первой системы
            {
                x = h * Math.Cos(a + Math.Sqrt(a + h));
            }
            else if (h <= 3.5) // обработка второго условия первой системы
            {
                x = a * Math.Sin(h + 1) + 4.5 * a;
            }
            if (x <= 7) // обработка первого условия второй системы
            {
                y = a * Math.Pow(h, 2) + 4 * Math.Sin(x) + x;
            }
            else if(x > 7) // // обработка второго условия второй системы
            {
                y = Math.Pow(Math.E, a) + Math.Pow(x, 2) - h * x;
            }
            double z = (a * Math.Pow(h, 3)) / (Math.Pow(x, 2) + Math.Abs(y) + 10); // находим значение z по формуле
            Console.WriteLine("a = " + a);
            Console.WriteLine("h = " + h);
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z); // 123
        }
    }
}