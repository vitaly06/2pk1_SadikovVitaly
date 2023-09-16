namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Отгадайте загадку:");
            Console.WriteLine("Вокруг носа вьется, а в руки не дается.");
            string answer = "";
            while (!answer.Equals("запах") && !answer.Equals("сдаюсь")) 
            {
                Console.Write("Введите ответ: ");
                answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "запах":
                        Console.WriteLine("Это верный ответ");
                        break;
                    case "сдаюсь":
                        Console.WriteLine("Правильный ответ: запах.");
                        break;
                    default:
                        Console.WriteLine("Неверно. Попробуйте ещё раз");
                        break;
                }
            }            
        }
    }
}