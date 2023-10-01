namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 21
            int n = 5;
            int[][] massive = new int[n][];
            Random rnd = new Random();
            // Заполняем массив
            for (int i = 0; i < n; i++)
            {
                int lengtStr = rnd.Next(2, 31); // длина строки
                massive[i] = new int[lengtStr];
                for (int j = 0; j < lengtStr; j++)
                {
                    massive[i][j] = rnd.Next(0, 101);
                }
            }
            // Выводим массив
            Console.WriteLine("Ступенчатый массив: ");
            foreach (int[] row in massive)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            // Создаём новый массив с последними элементами каждого подмассива
            int[] massive2 = new int[n];          
            for (int i1 = 0; i1 < n; i1++)
            {
                massive2[i1] = massive[i1].Last();
            }
            Console.WriteLine("Массив из последних элементов каждой строки: ");
            Console.WriteLine(string.Join(" ", massive2)); // Выводим новый массив
            // Массив с максимальными элементами каждого подмассива
            int[] maxElems = new int[n];
            for (int i2 = 0; i2 < n; i2++)
            {
                maxElems[i2] = massive[i2].Max();
            }
            Console.WriteLine("Массив с максимальным элементом каждой строки: ");
            Console.WriteLine(string.Join(" ", maxElems));
            // Меняем местами первый элемент и максимальный
            for (int z = 0; z < n; z++)
            {
                int first = massive[z][0]; // первый элемент строки
                // индекс максимальнго элемента строки
                int indexMax = massive[z].ToList().IndexOf(massive[z].Max(), 0);
                // производим замену
                massive[z][0] = massive[z][indexMax];
                massive[z][indexMax] = first;
            }
            // Выводим обновлённый массив
            Console.WriteLine("Обновлённый массив(поменяны местами первый элемент и максимальный):");
            foreach (int[] rows2 in massive)
            {
                Console.WriteLine(string.Join(" ", rows2));
            }
            // Ревёрс каждой строки ступенчатого массива
            for (int x = 0; x < n; x++)
            {
                Array.Reverse(massive[x]);
            }
            Console.WriteLine("Ревёрс каждой строки массива: ");
            foreach (int[] rows3 in massive)
            {
                Console.WriteLine(string.Join(" ", rows3));
            }
            // Находим среднее для каждой строки
            Console.WriteLine("Средние значения строк: ");
            for (int c = 0; c < n; c++)
            {
                double sum = 0.0; // сумма чисел в строке
                for (int q = 0; q < massive[c].Length; q++)
                {
                    sum += massive[c][q];
                }
                double result = sum / massive[c].Length; // среднее 
                Console.WriteLine($"Среднее значение чисел для строки {c + 1} = {Math.Round(result, 2)}");
            }
        }
    }
}