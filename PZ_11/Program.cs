namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 20
            double AMean, GMean;
            double A, B, C, D;
            Console.Write("Введите A: ");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите B: ");
            B = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите C: ");
            C = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите D: ");
            D = Convert.ToDouble(Console.ReadLine());
            Mean(A, B, out AMean, out GMean);
            Console.WriteLine("A, B:");
            Console.WriteLine($"Среднее арифметическое: {AMean}");
            Console.WriteLine($"Среднее геометрическое: {GMean}");
            Mean(A, C, out AMean, out GMean);
            Console.WriteLine("A, C:");
            Console.WriteLine($"Среднее арифметическое: {AMean}");
            Console.WriteLine($"Среднее геометрическое: {GMean}");
            Mean(A, D, out AMean, out GMean);
            Console.WriteLine("A, D:");
            Console.WriteLine($"Среднее арифметическое: {AMean}");
            Console.WriteLine($"Среднее геометрическое: {GMean}");

        }
        static void Mean(double X, double Y, out double AMean, out double GMean)
        {
            AMean = (X + Y) / 2;
            GMean = Math.Sqrt(X * Y);
        }
    }
}