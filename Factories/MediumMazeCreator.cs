namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MediumMazeCreator : MazeCreator
    {
        private const int MEDIUM_LAB_SIZE = 21;

        public override IMaze CreateMaze()
        {
            return new Maze(MEDIUM_LAB_SIZE, MEDIUM_LAB_SIZE);
        }
    }
}
