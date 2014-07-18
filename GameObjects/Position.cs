namespace Labyrinth.GameObjects
{
    using System;

    public class Position
    {
        private int x, y;
        
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Position X cannot be negative.");
                }
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Position Y cannot be negative.");
                }
                this.y = value;
            }
        }
    }
}