using System.IO;

namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вариант 19
            Console.Write("Введите полный путь к каталогу: ");
            string path = @$"{Console.ReadLine()}";
            try
            {
                // Получаем список файлов
                string[] files = Directory.GetFiles(path);
                Console.WriteLine("Файлы в каталоге размером больше 10 МБ:");
                if (files.Length == 0)
                {
                    Console.WriteLine("Файлы отсутствуют в каталоге");
                }
                else
                {
                    // В цикле получаем длину каждого файла
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        long size = fileInfo.Length;
                        if (size > 10 * 1024 * 1024)
                        {
                            Console.WriteLine($"Имя файла: {fileInfo.Name}\tРазмер: {size / (1024 * 1024)} МБ.");
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Неверно указан путь к директории!");
            }
        }
    }
}