namespace Labyrinth.GameEngine
{
    using System;
    using System.Linq;
    using Labyrinth.GameObjects;

    public class SmallLabCreator : LabCreator
    {
        private const int SMALL_LAB_SIZE = 20;

        public override Maze CreateLabyrinth()
        {
            return new Maze(new Position(SMALL_LAB_SIZE/2, SMALL_LAB_SIZE/2),SMALL_LAB_SIZE, SMALL_LAB_SIZE);
        }
    }
}
