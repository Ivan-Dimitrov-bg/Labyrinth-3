namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// LargeMazeCreator class
    /// </summary>
    /// <remarks>
    /// Inherits MazeCreator
    /// </remarks>
    public class LargeMazeCreator : MazeCreator
    {
        private const int LARGE_LAB_SIZE = 31;

        /// <summary>
        /// CreateMaze creator
        /// <remarks>
        /// Singleton pattern
        /// </remarks>
        /// </summary>
        public override IMaze CreateMaze()
        {
            // Singleton pattern...
            if (this.Maze == null)
            {
                this.Maze = new Maze(LARGE_LAB_SIZE, LARGE_LAB_SIZE);
            }

            return this.Maze;
        }
    }
}