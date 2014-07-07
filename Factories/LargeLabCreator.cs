namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    class LargeLabCreator : LabCreator
    {
        private const int LARGE_LAB_SIZE = 30;

        public override IMaze CreateLabyrinth()
        {
            return new Maze(LARGE_LAB_SIZE, LARGE_LAB_SIZE);
        }
    }
}
