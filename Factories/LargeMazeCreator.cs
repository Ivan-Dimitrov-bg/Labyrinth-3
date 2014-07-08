namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    class LargeMazeCreator : MazeCreator
    {
        private const int LARGE_LAB_SIZE = 31;

        public override IMaze CreateMaze()
        {
            return new Maze(LARGE_LAB_SIZE, LARGE_LAB_SIZE);
        }
    }
}
