using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SnakeGame
{
    public class Snake
    {
        public struct SnakeElementsBodyPosition
        {
            public SnakeElementsBodyPosition(int _positionX, int _positionY)
            {
                positionX = _positionX;
                positionY = _positionY;
            }

            public int positionX;
            public int positionY;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string direction = "D";

            int difficult;

            Console.WriteLine("Выберите сложность уровня (введите число от 1 до 3):");

        linkOne:

            try
            {
                Console.WriteLine("1 - легко, 2 - нормально, 3 - сложно.");

                difficult = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (difficult == 1) difficult = 10;
                else if (difficult == 2) difficult = 15;
                else if (difficult == 3) difficult = 20;
                else goto linkOne;
                Paint.Pole(difficult);


            }
            catch
            {
                Console.WriteLine("Некоректные данные, введите повторно.");

                goto linkOne;
            }

            try
            {
                Console.OutputEncoding = Encoding.ASCII;
                Console.InputEncoding = Encoding.ASCII;

                bool alive = true, spawnFeed = true;
                Random rnd = new Random();
                ConsoleKey key = ConsoleKey.Enter;

                #region FirstIppo
                SnakeElementsBodyPosition[] SnakeBody = new SnakeElementsBodyPosition[101];

                SnakeBody[0] = new SnakeElementsBodyPosition(3, 1);
                SnakeBody[1] = new SnakeElementsBodyPosition(2, 1);
                SnakeBody[2] = new SnakeElementsBodyPosition(1, 1);

                Paint.Dot(SnakeBody, "*");
                #endregion

                while (alive)
                {
                    alive = SimpleMove(ref SnakeBody, "*", direction, difficult);

                    Paint.Dot(SnakeBody, "*");

                    if (Console.KeyAvailable) direction = Convert.ToString(Console.ReadKey(true).Key);

                    Thread.Sleep(400 / (difficult / 5) - difficult);

                    if (SnakeBody[75].positionX != 0 || SnakeBody[75].positionY != 0)
                    {
                        break;
                    }

                    if (spawnFeed)
                    {
                        SnakeBody[100] = new SnakeElementsBodyPosition(rnd.Next(1, difficult - 1), rnd.Next(1, difficult - 1));
                        Paint.Dot(SnakeBody[100], "@");

                        spawnFeed = false;
                    }

                    if (SnakeBody[0].positionX == SnakeBody[100].positionX && SnakeBody[0].positionY == SnakeBody[100].positionY)
                    {
                        spawnFeed = true;

                        for (var i = 0; i < SnakeBody.Length; i++)
                        {
                            if (SnakeBody[i].positionX == 0 || SnakeBody[i].positionY == 0)
                            {
                                switch (direction)
                                {
                                    case "W":
                                        if (SnakeBody[i - 1].positionY - 1 == 0)
                                        {
                                            if (SnakeBody[i - 1].positionX - 1 == 0)
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                            else
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                        }
                                        else
                                        {
                                            SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                            SnakeBody[i].positionY = SnakeBody[i - 1].positionY - 1;

                                            Paint.Dot(SnakeBody, "*");
                                        }
                                        break;
                                    case "A":
                                        if (SnakeBody[i - 1].positionX + 1 == difficult)
                                        {
                                            if (SnakeBody[i - 1].positionY - 1 == 0)
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                            else
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY - 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                        }
                                        else
                                        {
                                            SnakeBody[i].positionX = SnakeBody[i - 1].positionX + 1;
                                            SnakeBody[i].positionY = SnakeBody[i - 1].positionY;

                                            Paint.Dot(SnakeBody, "*");
                                        }
                                        break;
                                    case "S":
                                        if (SnakeBody[i - 1].positionY + 1 == difficult)
                                        {
                                            if (SnakeBody[i - 1].positionX - 1 == 0)
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY - 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                            else
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                        }
                                        else
                                        {
                                            SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                            SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                            Paint.Dot(SnakeBody, "*");
                                        }
                                        break;
                                    case "D":
                                        if (SnakeBody[i - 1].positionX - 1 == 0)
                                        {
                                            if (SnakeBody[i - 1].positionY - 1 == 0)
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY + 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                            else
                                            {
                                                SnakeBody[i].positionX = SnakeBody[i - 1].positionX;
                                                SnakeBody[i].positionY = SnakeBody[i - 1].positionY - 1;

                                                Paint.Dot(SnakeBody, "*");
                                            }
                                        }
                                        else
                                        {
                                            SnakeBody[i].positionX = SnakeBody[i - 1].positionX - 1;
                                            SnakeBody[i].positionY = SnakeBody[i - 1].positionY;

                                            Paint.Dot(SnakeBody, "*");
                                        }
                                        break;
                                }

                                break;
                            }
                        }
                    }
                }
                if (alive)
                {
                    MessageBox.Show("Победа!");
                }
                else
                {
                    MessageBox.Show("Паражение!");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }            
        }
        static bool SimpleMove(ref SnakeElementsBodyPosition[] SnakeBody, string symbolб, string direction, int difficult)
        {
            for (var i = 0; i < SnakeBody.Length; i++)
            {
                if (SnakeBody[0].positionX - 1 == 0 && direction == "A") return false;
                if (SnakeBody[0].positionY - 1 == 0 && direction == "W") return false;
                if (SnakeBody[0].positionY + 1 == difficult && direction == "S") return false;
                if (SnakeBody[0].positionX + 1 == difficult && direction == "D") return false;

                if (SnakeBody[i].positionX == 0 || SnakeBody[i].positionY == 0)
                {
                    Console.SetCursorPosition(SnakeBody[i - 1].positionX, SnakeBody[i - 1].positionY);
                    Console.WriteLine(" ");

                    for (var j = i - 1; j >= 1; j--)
                    {
                        SnakeBody[j] = SnakeBody[j - 1];
                    }

                    SnakeBody[1] = SnakeBody[0];

                    if (direction == "W") SnakeBody[0].positionY--;
                    if (direction == "A") SnakeBody[0].positionX--;
                    if (direction == "S") SnakeBody[0].positionY++;
                    if (direction == "D") SnakeBody[0].positionX++;

                    return true;
                }
            }

            return true;
        }      
    }
}
