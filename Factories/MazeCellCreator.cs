namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public  class MazeCellCreator 
    {
        private static readonly Random randomInt = new Random();       
        private static readonly MazeCell emptyCell = new MazeCell();
        private static readonly MazeCell wall = new MazeCell(Cell.WALL);
        
        public static ICell CreateCell()       
        {
            int valueDecider = randomInt.Next(2);
            
            //Prototype pattern...
            if (valueDecider == 0)
            {
                return emptyCell.Clone() as ICell;
            }
            else
            {
                return wall.Clone() as ICell;
            }
        }
    }
}