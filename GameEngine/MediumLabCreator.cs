namespace Labyrinth.GameEngine
{
    using Labyrinth.GameObjects;
    using System;
    using System.Linq;

    public class MediumLabCreator : LabCreator
    {
        private const int MEDIUM_LAB_SIZE = 20;

        public override Maze CreateLabyrinth()
        {
            return new Maze(new Position(MEDIUM_LAB_SIZE/2, MEDIUM_LAB_SIZE/2),MEDIUM_LAB_SIZE, MEDIUM_LAB_SIZE);
        }
    }
}
