using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameEngine;

namespace Labyrinth.GameObjects
{
    public class MazeCell : Cell
    {
        private const char WALL = 'x';
        private const char DEFAULT_CELL_VALUE = '-';

        private static readonly Random randomInt = new Random();
        
        public MazeCell(char value = DEFAULT_CELL_VALUE) : base(value)
        {
        }

        public override bool IsEmpty
        {
            get
            {
                return this.Value == DEFAULT_CELL_VALUE;
            }
        }

        public static MazeCell GenerateRandomCell()
        {
            int valueDecider = randomInt.Next(2);
            
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