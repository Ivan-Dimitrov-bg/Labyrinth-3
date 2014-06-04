using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.GameObjects
{
    public class MazeCell : Cell
    {
        private const char WALL = 'x';
        private static Random randomInt = new Random();

        public MazeCell(char value) : base(value)
        {
        }

        public override bool IsEmpty
        {
            get
            {
                return this.Value == EMPTY_CELL;
            }
        }

        public static MazeCell GenerateRandomCell()
        {
            int valueDecider = randomInt.Next(2);
            if (valueDecider == 0)
            {
                return new MazeCell(EMPTY_CELL);
            }
            else
            {
                return new MazeCell(WALL);
            }
        }
    }
}