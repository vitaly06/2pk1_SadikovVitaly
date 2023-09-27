namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] randomList = new int[20];
            Random rnd = new Random();
            bool checkUnic = true; // уникальность элемента
            for (int i = 0; i < 20; i++)
            {
                // сделал в небольшом диапазоне, т.к получались огромные числа
                randomList[i] = rnd.Next(0, 101);
            }
            Console.Write("Элементы массива: ");
            foreach (int item in randomList) // выводим элементы массива
            {
                Console.Write($"{item} ");
            }
            Console.Write("\nУникальные элементы массива: ");
            for (int i1 = 0; i1 < 20; i1++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (randomList[i1] == randomList[j] && i1 != j) // если есть повторяющийся элемент
                    {
                        checkUnic = false;
                    }
                }
                if (checkUnic == true) // если элемент уникален
                {
                    Console.Write(randomList[i1] + " ");
                }
                checkUnic = true;
            }
        }
    }
}