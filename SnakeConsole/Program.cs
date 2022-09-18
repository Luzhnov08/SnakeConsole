using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //зафиксировать размер окна
            Console.SetBufferSize(120, 80);

            Walls walls = new Walls(80, 25);
            walls.Drow();

            //Отричовка точек
            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1 , 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Drow();

            while (true) 
            {
                if (walls.IsHit(snake) || snake.IsHitTail()) 
                {
                    Console.WriteLine("Гамовер!");
                    Console.Write("Результат: " + snake.GetPoints());
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Drow();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable) 
                { 
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            
            Console.ReadLine();
        }
    }
}