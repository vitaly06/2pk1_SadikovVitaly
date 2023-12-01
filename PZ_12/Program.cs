namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 20
            double[] temperatures = new double[7];
            // Вводим данные в массив с клавиатуры
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Введите температуру в {i + 1} день: ");
                temperatures[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"Количество дней с минусовой температурой: {minusDays(temperatures)}");
        }

        static int minusDays(double[] temps)
        {
            int count = 0;
            foreach(double temp in temps)
            {
                if (temp < 0)
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}