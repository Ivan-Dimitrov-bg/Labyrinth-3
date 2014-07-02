﻿namespace Labyrinth.GameObjects
{
    using System;

    public class MazeCell : Cell
    {
        private const char WALL = 'x';
        private const char DEFAULT_CELL_VALUE = '-';

        private static readonly Random RandomInt = new Random();
        
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