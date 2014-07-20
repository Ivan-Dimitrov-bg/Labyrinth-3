namespace Labyrinth.GameObjects
{
    using System;

    /// <summary>
    /// Position class
    /// <remarks>
    /// Validates and computes the position in the correct format
    /// </remarks>
    /// </summary>
    public class Position
    {
        private int x, y;

        /// <summary>
        /// Constructor for the current position
        /// <remarks>
        /// Accepts an int in the correct limits
        /// </remarks>
        /// </summary>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Getter and setter for the X position
        /// <remarks>
        /// Validates the input
        /// <returns>
        /// Returns X with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
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

        /// <summary>
        /// Getter and setter for the Y position
        /// <remarks>
        /// Validates the input
        /// <returns>
        /// Returns Y with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
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