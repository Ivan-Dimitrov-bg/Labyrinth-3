namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// MazeCellCreator class
    /// </summary>
    public static class MazeCellCreator
    {
        private static readonly Random RandomInt = new Random();

        private static readonly ICloneable Cell = new MazeCell();

        /// <summary>
        /// Cell creator
        /// <remarks>
        /// Prototype pattern
        /// </remarks>
        /// </summary>
        public static ICell CreateCell()
        {
            int valueDecider = RandomInt.Next(2);

            // Prototype pattern...
            ICell cellToReturn = Cell.Clone() as ICell;           
            if (valueDecider != 0)
            {
                cellToReturn.Value = GameObjects.Cell.WALL;                
            }
                
            return cellToReturn;
        }
    }
}