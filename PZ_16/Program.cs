using System.ComponentModel;
using System.IO;

namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта
        //static Random rand = new Random();
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 5; //количество врагов
        static byte buffs = 5; //количество усилений
        static int stopBuff = -1;
        static int health = 5;  // количество аптечек
        static int personHP = 50; // здоровье игрока
        static int personPower = 10; // сила персонажа
        static int steps = 0; // шаги
        static int enemyHP = 30; // здоровье врага
        static int enemyPower = 5; // сила врага
        static int enemyCount = 5;
        static int kills = 0;


        static void Main(string[] args)
        {
            StartGame();
            //GenerationMap();
            Move();
        }

        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в чередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли
        }
        /// перемещение персонажа
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (true)
            {
                if (kills == 5 && enemyCount == 0)
                {
                    Win();
                }
                if (personHP <= 0)
                {
                    Loose();
                }
                if (steps == stopBuff)
                {
                    stopBuff = -1;
                    personPower = 10;
                }
                playerOldX = playerX;
                playerOldY = playerY;

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Действительно ли вы хотите покинуть игру?");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            Console.WriteLine("Сохранить игру(Enter - да; Escape - нет)?");
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                using (FileStream fs = new FileStream(@"save.txt", FileMode.Create, FileAccess.Write))
                                {
                                    using (StreamWriter sw = new StreamWriter(fs))
                                    {
                                        for (int i = 0; i < 25; i++)
                                        {
                                            for (int j = 0; j < 25; j++)
                                            {
                                                sw.Write(map[i, j]);
                                            }
                                            sw.Write('\n');
                                        }
                                        sw.WriteLine($"Здоровье игрока: {personHP} ");
                                        sw.WriteLine($"Сила удара: {personPower}");
                                        sw.WriteLine($"Пройдено шагов: {steps}");
                                    }
                                }
                                Environment.Exit(0);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                                GenerationMap();
                            }
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            GenerationMap();
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (playerX > 0)
                        {
                            playerX--;
                            steps++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerX < 24)
                        {
                            playerX++;
                            steps++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerY > 0)
                        {
                            playerY--;
                            steps++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerY < 26)
                        {
                            playerY++;
                            steps++;
                        }
                        break;
                }
                Console.WriteLine(playerX + " " + playerY);
                Console.SetCursorPosition(playerY, playerX);
                switch (map[playerX, playerY])
                {
                    case 'E':
                        Fight();
                        break;
                    case 'H':
                        Health();
                        break;
                    case 'B':
                        Buff();
                        break;
                }
                Console.Write('P');

                Console.CursorVisible = false; //скрытный курсов

                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"Здоровье игрока: {personHP} ");
                Console.WriteLine($"Сила удара: {personPower}");
                Console.WriteLine($"Пройдено шагов: {steps}");


            }
        }
        static void Fight()
        {
            while (personHP > 0 && enemyHP > 0)
            {
                enemyHP -= personPower;
                personHP -= enemyPower;
                Console.SetCursorPosition(playerY, playerX);

            }
            if (personHP <= 0)
            {
                Console.Write("E");
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("Вы проиграли!");
            }
            else
            {
                map[playerX, playerY] = '_';
                kills++;
                enemyHP = 30;
            }
        }

        static void Health()
        {
            personHP = 50;
            map[playerX, playerY] = '_';
            health--;
        }

        static void Buff()
        {
            personPower *= 2;
            stopBuff = steps + 20;
        }
        static void Win()
        {
            Console.Clear();
            string text1 = "Вы выиграли!";
            string text2 = $"Количество шагов: {steps}";
            int centerX = (Console.WindowWidth / 2) - (text1.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(text1);
            Console.WriteLine(text2);
            Environment.Exit(0);
        }

        static void Loose()
        {
            Console.Clear();

            string text1 = "Вы проиграли!";
            string text2 = $"Количество шагов: {steps}";
            int centerX = (Console.WindowWidth / 2) - (text1.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(text1);
            Console.WriteLine(text2);
            Environment.Exit(0);
        }



        static void StartGame()
        {
            string text1 = "N - начать новую игру";
            string text2 = "L - загрузить последнее сохрание";
            int centerX = (Console.WindowWidth / 2) - (text1.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.WriteLine(text1);
            centerX = (Console.WindowWidth / 2) - (text2.Length / 2);
            Console.SetCursorPosition(centerX, centerY + 1);
            Console.WriteLine(text2);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    GenerationMap();
                    break;
                case ConsoleKey.L:
                    LoadSave();
                    break;

            }
        }

        static void LoadSave()
        {
            try
            {
                using (FileStream fs = new FileStream(@"save.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        Console.Clear();
                        int a = 0;
                        int b = 0;
                        for (int i = 0; i < 25; i++)
                        {
                            string[] line = sr.ReadLine().Split("");

                            foreach (string s in line)
                            {
                                foreach (char c in s)
                                {
                                    if (c == 'P')
                                    {
                                        playerY = b;
                                        playerX = a;
                                    }
                                    map[a, b] = c;
                                    b++;
                                }
                            }
                            b = 0;
                            a++;
                        }
                    }
                    UpdateMap();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка: {e}");
            }
            /// вывод карты на консоль
        }
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'E')
                    {
                        enemyCount--;
                    }
                    Console.Write(map[i, j]);
                }
                Console.WriteLine(map[i, 0]);
            }
        }
    }
}