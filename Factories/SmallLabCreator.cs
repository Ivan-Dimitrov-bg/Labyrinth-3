namespace Labyrinth.Factories
{
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class SmallLabCreator : LabCreator
    {
        private const int SMALL_LAB_SIZE = 10;

        public override IMaze CreateLabyrinth()
        {
            return new Maze(SMALL_LAB_SIZE, SMALL_LAB_SIZE);
        }
    }
}
