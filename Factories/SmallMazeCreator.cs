namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class SmallMazeCreator : MazeCreator
    {
        private const int SMALL_LAB_SIZE = 11;

        public override IMaze CreateMaze()
        {
            //Singleton pattern...
            if (this.maze == null)
            {
                this.maze = new Maze(SMALL_LAB_SIZE, SMALL_LAB_SIZE);
            }

            return maze;
        }
    }
}