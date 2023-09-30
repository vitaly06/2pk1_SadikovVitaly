namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер квадратной матрицы: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            int[,] massive = new int[n, n];
            int min = 101;
            // Заполняем массив
            for (int i = 0; i <= (n - 1); i++)
            {
                for(int j = 0; j <= (n - 1); j++)
                {
                    massive[i, j] = rnd.Next(0, 101);
                }
            }
            // Выводим исходный массив
            Console.WriteLine("Исходная матрица: ");
            for (int z = 0; z <= (n - 1); z++)
            {
                for (int x = 0; x <= (n - 1); x++)
                {
                    Console.Write($"{massive[z, x]}\t"); // Выводим строку
                }
                Console.WriteLine(); // Переход на следующую строку
            }
            // Элементы ниже побочной диагонали
            Console.WriteLine("Элементы матрицы ниже побочной диагонали: ");
            for (int i1 = 0; i1 <= (n - 1); i1++)
            {
                for (int j1 = n - i1; j1 < n; j1++)
                {
                    Console.Write($"{massive[i1, j1]}\t");
                    if (massive[i1, j1] < min)
                    {
                        min = massive[i1, j1];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Минимальный элемент массива ниже побочной диагонали: {min}");

        }
    }
}