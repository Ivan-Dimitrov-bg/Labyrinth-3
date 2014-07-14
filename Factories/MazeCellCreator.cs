namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MazeCellCreator
    {
        private static readonly Random RandomInt = new Random();
        private static readonly MazeCell Cell = new MazeCell();

        public static ICell CreateCell()
        {
            int valueDecider = RandomInt.Next(2);

            // Prototype pattern...
            ICell cellToReturn = Cell.Clone() as ICell;           
            if (valueDecider == 0)
            {
                return cellToReturn;
            }
            else
            {
                cellToReturn.Value = GameObjects.Cell.WALL;
                return cellToReturn;
            }
        }
    }
}