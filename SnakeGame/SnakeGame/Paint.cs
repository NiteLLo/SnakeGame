using System;
using static SnakeGame.Snake;

namespace SnakeGame
{
    public class Paint
    {
        public static void Pole(int difficult)
        {
            for (var i = 0; i < difficult; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("-");

                Console.SetCursorPosition(i, difficult);
                Console.WriteLine("-");

                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");

                Console.SetCursorPosition(difficult, i);
                Console.WriteLine("|");
            }
        }
        public static void Dot(SnakeElementsBodyPosition[] SnakeBody, string symbol)
        {
            for (var i = 0; i < SnakeBody.Length; i++)
            {
                if (SnakeBody[i].positionX == 0 || SnakeBody[i].positionY == 0)
                {
                    break;
                }

                if (i == 0)
                {
                    Console.SetCursorPosition(SnakeBody[i].positionX, SnakeBody[i].positionY);
                    Console.WriteLine("+");

                    i++;
                }
                
                Console.SetCursorPosition(SnakeBody[i].positionX, SnakeBody[i].positionY);
                Console.WriteLine(symbol);
            }
            
        }

        public static void Dot(SnakeElementsBodyPosition SnakeBody, string symbol)
        {           
            Console.SetCursorPosition(SnakeBody.positionX, SnakeBody.positionY);
            Console.WriteLine(symbol);
        }
    }
}
