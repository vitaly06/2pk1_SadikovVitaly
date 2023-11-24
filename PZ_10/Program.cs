namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 20
            string raw = Console.ReadLine();
            var items = raw.Split(' ');
            double sum = 0;
            foreach (var i in items)
            {
                int test = 0;
                double test1 = 0.0;
                if (int.TryParse(i, out test))
                {
                    sum += test;
                }
                else if(double.TryParse(i, out test1))
                {
                    sum += test1;
                }
            }
            Console.WriteLine($"Сумма для оплаты: {sum}");
        }
    }
}