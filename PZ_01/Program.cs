namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c; // инициализация переменных
            Console.WriteLine("Введите значение a: "); // выводим текст в консоль
            a = Convert.ToDouble(Console.ReadLine()); // считываем 1-ое число с клавиатуры
            Console.WriteLine("Введите значение b: "); // выводим текст в консоль
            b = Convert.ToDouble(Console.ReadLine()); // считываем 2-ое число с клавиатуры
            Console.WriteLine("Введите значение c: "); // выводим текст в консоль
            c = Convert.ToDouble(Console.ReadLine()); // считываем 3-ое число с клавиатуры
            double res1 = Math.Pow(10, 4) * Math.Pow(Math.Sin(2.5 * c), 2); // 1-ая часть выражения
            double res2 = (0.32 * Math.Pow(c, 3) + (4 * c) + b) / Math.Cos(2 * a); // 2-ая часть выражения
            double res3 = Math.Pow(0.32 * Math.Pow(c, 3) - b, 1 / 6); // 3 часть выражения
            double finalyRes = res1 - res2 * res3 + Math.Abs(b); // итоговый результат выражения
            Console.WriteLine("Результат: " + finalyRes); // вывод результата в консоль
        }
    }
}