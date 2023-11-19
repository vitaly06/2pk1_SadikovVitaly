namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 20
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string[] words = str.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            var uniqueWords = words.DistinctBy(w => w.Length);
            string result = string.Join(" ", uniqueWords);
            Console.WriteLine(result);
        }
    }
}