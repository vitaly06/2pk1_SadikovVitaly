using System.ComponentModel;
using System.IO;

namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 26; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта
        //static Random rand = new Random();
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int stopBuff = -1;
        static int health = 5;  // количество аптечек
        static int personHP = 50; // здоровье игрока
        static int personPower = 10; // сила персонажа
        static int steps = 0; // шаги
        // враги
        static int enemyHP = 30;
        static int enemyPower = 5; 
        static int enemyCount = 0;
        // босс
        static int bossX = mapSize / 2;
        static int bossY = mapSize / 2;
        static int bossHP = 75;
        static int bossPower = 25;
        static bool isBoss = false;


        static void Main(string[] args)
        {
            StartGame();
            Move();
        }

        ///
        /// генерация карты с расставлением врагов, аптечек, баффов
        ///
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
                x = random.Next(0, mapSize - 2);
                y = random.Next(0, mapSize - 2);

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
                x = random.Next(0, mapSize - 2);
                y = random.Next(0, mapSize - 2);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(1, mapSize - 2);
                y = random.Next(1, mapSize - 2);

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
            {   // появление босса
                if (enemyCount <= 0 && !isBoss)
                {
                    map[bossY, bossX] = 'K';
                    Console.SetCursorPosition(bossY, bossX);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine('K');
                    isBoss = true;
                    Console.ResetColor();
                 
                }
                // проигрыш
                if (personHP <= 0)
                {
                    Loose();
                }
                // остановка действия баффа
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
                        Console.WriteLine("Действительно ли вы хотите покинуть игру(Enter - да; Escape - нет)?");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            Console.WriteLine("Сохранить игру(Enter - да; Escape - нет)?");
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {   // делаем сохранение
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
                                Environment.Exit(0);
                            }
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            UpdateMap();
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (playerX > 0)
                        {
                            playerX--;
                            steps++;
                            break;
                        }
                        playerOldX++;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerX < 25)
                        {
                            playerX++;
                            steps++;
                            break;
                        }
                        playerOldX--;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerY > 0)
                        {
                            playerY--;
                            steps++;
                            break;
                        }
                        playerOldY++;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerY < 25)
                        {
                            playerY++;
                            steps++;
                            break;
                        }
                        playerOldY--;
                        break;
                        
                }
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
                    case 'K':
                        BossFight();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('P');
                Console.ResetColor();
                Console.CursorVisible = false; //скрытный курсов

                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(0, 26);
                Console.WriteLine($"Здоровье игрока: {personHP} ");
                Console.WriteLine($"Сила удара: {personPower} ");
                Console.WriteLine($"Пройдено шагов: {steps} ");


            }
        }
        // битва с врагами
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
                enemyCount -= 1;
                map[playerX, playerY] = '_';
                enemyHP = 30;
            }
        }
        // битва с боссом
        static void BossFight()
        {
            while (personHP > 0 && bossHP > 0)
            {
                bossHP -= personPower;
                personHP -= bossPower;
                Console.SetCursorPosition(playerY, playerX);

            }
            if (personHP <= 0)
            {
                Loose();
            }
            else
            {
                Win();
            }
        }
        // хилл
        static void Health()
        {
            personHP = 50;
            map[playerX, playerY] = '_';
            health--;
        }
        // бафф
        static void Buff()
        {
            personPower *= 2;
            stopBuff = steps + 20;
        }
        // победа
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
        // проигрыш
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


        // стартовое окно
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
        // загрузка сохранения
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
                            // заполняем массив карты из файла
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
            
        }
        /// вывод карты на консоль
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {   if (j == 25)
                    {
                        continue;
                    }
                    if (map[i, j] == 'E')
                    {
                        enemyCount += 1;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (map[i, j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (map[i, j] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (map[i, j] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine(map[i, 0]);
            }
        }
    }
}