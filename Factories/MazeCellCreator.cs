namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MazeCellCreator
    {
        private static readonly Random randomInt = new Random();
        private static readonly MazeCell cell = new MazeCell();

        public static ICell CreateCell()
        {
            int valueDecider = randomInt.Next(2);

            //Prototype pattern...
            ICell cellToReturn = cell.Clone() as ICell;           
            if (valueDecider == 0)
            {
                return cellToReturn;
            }
            else
            {
                cellToReturn.Value = Cell.WALL;
                return cellToReturn;
            }
        }
    }
}