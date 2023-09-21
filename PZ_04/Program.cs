namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Задание №1");
            for (int i = 20; 20 <= i && 90 >= i; i += 5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("********************");
           // Задание 2
            Console.WriteLine("Задание №2");
            char myChar = 'Ж';
            for (int j = 0; j < 5; j++)
            {
                Console.Write(myChar++);
            }
            Console.WriteLine("\n********************");
            // Задание 3
            Console.WriteLine("Задание №3");
            int n = 7;
            int m = 8;
            for (int z = 0; z != m; z++)
            {
                for(int x = 0; x != n; x++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            Console.WriteLine("********************");
            // Задание 4
            Console.WriteLine("Задание №4");
            int count = 0;
            for (int e = -100; e >= -100 && e <= 0; e++)
            {
                if(e % 13 == 0)
                {
                    Console.Write(e + " ");
                    count++;
                }
            }
            Console.WriteLine("\nКоличество кратных чисел: " + count);
            Console.WriteLine("********************");
            // Задание 5
            Console.WriteLine("Задание №5");
            for(int i1 = 5, j1 = 100; j1 - i1 > 9;)
            {
                Console.WriteLine("i = " + i1 + "; j = " + j1);
                j1--;
                i1++;
            }
        }
    }
}