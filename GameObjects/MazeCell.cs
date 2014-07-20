namespace Labyrinth.GameObjects
{
    using System;

    /// <summary>
    /// Maze cell class
    /// <remarks>
    /// Inherits the Cell and ICloneable interfaces
    /// </remarks>
    /// </summary>
    public class MazeCell : Cell, ICloneable
    {
        /// <summary>
        /// MazeCell consturctor
        /// <remarks>
        /// Will call the base constructor
        /// </remarks>
        /// </summary>
        public MazeCell(char value = EMPTY_CELL) : base(value)
        {
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
        public override bool IsEmpty
        {
            get
            {
                return this.Value == Cell.EMPTY_CELL;
            }
        }

        /// <summary>
        /// Prototype pattern
        /// <remarks>
        /// Implementation of the prototype - clone itself.
        /// <returns>
        /// Returns the cloned object
        /// </returns>
        /// </remarks>
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}