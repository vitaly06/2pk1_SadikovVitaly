namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Таблица умножения на 7:");
            int z = 0;
            while(z <= 10)
            {
                Console.WriteLine($"7 * {z} = {z * 7}");
                z++;
            }
            Console.WriteLine("***************");
            // Задание 2
            Console.Write("Введите целое положительное число n: ");
            int n  = Convert.ToInt32(Console.ReadLine());
            if (n < 0)
            {
                Console.WriteLine("Вы ввели отрицательное число!");
            }
            else
            {
                int sum = 0;
                int i = 0;
                while (i <= n)
                {
                    sum += i;
                    i++;
                }
                Console.WriteLine($"Сумма чисел от 0 до {n}: {sum}");
            }           
        }
    }
}