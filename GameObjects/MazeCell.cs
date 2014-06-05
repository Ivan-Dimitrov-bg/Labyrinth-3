using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameEngine;

namespace Labyrinth.GameObjects
{
    public class MazeCell : Cell
    {
        
        private static readonly Random randomInt = new Random();

        public MazeCell(char value) : base(value)
        {
        }

        public override bool IsEmpty
        {
            get
            {
                return this.Value == GameConstants.EMPTY_CELL;
            }
        }

        public static MazeCell GenerateRandomCell()
        {
            int valueDecider = randomInt.Next(2);
            if (valueDecider == 0)
            {
                return new MazeCell(GameConstants.EMPTY_CELL);
            }
            else
            {
                return new MazeCell(GameConstants.WALL);
            }
        }
    }
}