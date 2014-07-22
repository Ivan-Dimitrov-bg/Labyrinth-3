namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// SmallMazeCreator class
    /// </summary>
    /// <remarks>
    /// Inherits MazeCreator
    /// </remarks>
    public class SmallMazeCreator : MazeCreator
    {
        private const int SMALL_LAB_SIZE = 11;

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
                this.Maze = new Maze(SMALL_LAB_SIZE, SMALL_LAB_SIZE);
            }

            return this.Maze;
        }
    }
}