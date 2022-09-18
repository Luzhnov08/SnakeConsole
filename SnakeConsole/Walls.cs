using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsole
{
    internal class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight) 
        {
            wallList = new List<Figure>();

            //Отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, 0, mapHeight - 1, '+');
            VerticalLine rightLine = new VerticalLine(mapWidth - 2, 0, mapHeight - 1, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();
        }

        internal bool IsHit(Figure figure) 
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure)) 
                {
                    return true;
                }
            }
            return false;
        }

        public void Drow()
        {
            foreach (var wall in wallList) 
            {
                wall.Drow();
            }
        }

    }
}
