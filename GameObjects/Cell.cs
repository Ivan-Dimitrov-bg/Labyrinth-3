namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    /// <summary>
    /// Cell class
    /// <remarks>
    /// Inhertis the ICell and IRenderable interfaces
    /// </remarks>
    /// </summary>
    public abstract class Cell : ICell, IRenderable
    {
        public const char EMPTY_CELL = '-';
        public const char PLAYER_VALUE = '*';
        public const char WALL = 'x';
        private char value;

        /// <summary>
        /// Cell consturctor
        /// <remarks>
        /// Will set the new cell character accordingly
        /// </remarks>
        /// <param name="value">
        /// Must be valid char value
        /// </param>
        /// </summary>
        public Cell(char value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Get or set the current cell value
        /// <remarks>
        /// Value is checked to be only from the allowed characters
        /// </remarks>
        /// </summary>
        public char Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value != Cell.EMPTY_CELL && value != Cell.WALL && value != Cell.PLAYER_VALUE)
                {
                    throw new ArgumentException("Invalid cell value.");
                }

                this.value = value;
            }
        }

        /// <summary>
        /// Check the IsEmpty value
        /// <remarks>
        /// Can be overriden and changed
        /// <returns>
        /// Returns the IsEmpty value wtih a getter
        /// </returns>
        /// </remarks>
        /// </summary>
        public virtual bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Bridge pattern
        /// <remarks>
        /// The object recieves particular implementation of the renderer
        /// </remarks>
        /// <param name="renderer">
        /// Accepts an instance of IRenderer interface
        /// </param>
        /// </summary>
        public void Render(IRenderer renderer)
        {
            switch (this.Value)
            {
                case WALL:
                    renderer.Color = ConsoleColor.Red;
                    break;
                case PLAYER_VALUE:
                    renderer.Color = ConsoleColor.Green;
                    break;
                default:
                    renderer.Color = ConsoleColor.White;
                    break;
            }

            renderer.Render(this.ToString());
        }

        /// <summary>
        /// Method for getting the Value in the cell
        /// <remarks>
        /// Can be overriden and changed
        /// <returns>
        /// Returns the value
        /// </returns>
        /// </remarks>
        /// </summary>
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}