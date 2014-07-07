namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MediumLabCreator : LabCreator
    {
        private const int MEDIUM_LAB_SIZE = 20;

        public override IMaze CreateLabyrinth()
        {
            return new Maze(MEDIUM_LAB_SIZE, MEDIUM_LAB_SIZE);
        }
    }
}
