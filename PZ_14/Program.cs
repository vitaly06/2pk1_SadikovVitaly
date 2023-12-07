namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 19
            try
            {
                using (FileStream file = new FileStream(@"inFile.txt", FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        Console.WriteLine("Вводите построчно текст(Для остановки введите 'stop'): ");
                        string line = Console.ReadLine();
                        // заполняем файл
                        while (line != "stop")
                        {
                            writer.WriteLine(line);
                            line = Console.ReadLine();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("error");
            }
            using (FileStream file = new FileStream(@"inFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    int count = 0;
                    string[] lines = reader.ReadToEnd().Split('\n');
                    foreach (string line in lines)
                    {
                        count += line.Split(' ').Count(token => int.TryParse(token, out _));
                    }
                    Console.WriteLine("Содержимое файла:");
                    foreach (string line in lines)
                        Console.WriteLine(line);
                    Console.WriteLine($"Количество чисел в тексте: {count}");
                }

            }
        }
    }
}