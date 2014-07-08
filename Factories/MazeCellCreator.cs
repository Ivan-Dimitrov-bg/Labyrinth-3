namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public static class MazeCellCreator 
    {
        private static readonly Random RandomInt = new Random();       
        private static readonly MazeCell EmptyCell = new MazeCell();
        private static readonly MazeCell Wall = new MazeCell(Cell.WALL);
        
        public static ICell CreateCell()       
        {
            int valueDecider = RandomInt.Next(2);
            
            //Prototype pattern...
            if (valueDecider == 0)
            {
                return EmptyCell.Clone() as ICell;
            }
            else
            {
                return Wall.Clone() as ICell;
            }
        }
    }
}