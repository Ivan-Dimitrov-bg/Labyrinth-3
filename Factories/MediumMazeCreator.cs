namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MediumMazeCreator : MazeCreator
    {
        private const int MEDIUM_LAB_SIZE = 21;

        public override IMaze CreateMaze()
        {
            //Singleton pattern...
            if (this.maze == null)
            {
                this.maze = new Maze(MEDIUM_LAB_SIZE, MEDIUM_LAB_SIZE);
            }
            return maze;
        }
    }
}
