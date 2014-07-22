namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// MediumMazeCreator class
    /// </summary>
    /// <remarks>
    /// Inherits MazeCreator
    /// </remarks>
    public class MediumMazeCreator : MazeCreator
    {
        private const int MEDIUM_LAB_SIZE = 21;

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
                this.Maze = new Maze(MEDIUM_LAB_SIZE, MEDIUM_LAB_SIZE);
            }

            return this.Maze;
        }
    }
}
