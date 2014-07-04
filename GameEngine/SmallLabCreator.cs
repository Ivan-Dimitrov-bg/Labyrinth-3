namespace Labyrinth.GameEngine
{
    using System;
    using System.Linq;
    using Labyrinth.GameObjects;

    public class SmallLabCreator : LabCreator
    {
        private const int SMALL_LAB_SIZE = 10;

        public override Maze CreateLabyrinth()
        {
            return new Maze(SMALL_LAB_SIZE, SMALL_LAB_SIZE);
        }
    }
}
