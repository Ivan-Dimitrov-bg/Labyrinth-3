using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameObjects;
using Labyrinth.Interfaces;

namespace Labyrinth.Factories
{
    public static class MazeCellCreator 
    {
        private static readonly Random RandomInt = new Random();
        private const char WALL = 'x';

        public  static ICell CreateCell()       
        {
            int valueDecider = RandomInt.Next(2);
            
            if (valueDecider == 0)
            {
                return new MazeCell();
            }
            else
            {
                return new MazeCell(WALL);
            }
        }
    }
}