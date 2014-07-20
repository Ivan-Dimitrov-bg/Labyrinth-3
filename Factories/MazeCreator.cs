namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;

    /// <summary>
    /// MazeCreator class
    /// </summary>
    public abstract class MazeCreator
    {
        protected IMaze maze;
        private bool mazeHasSolution;
        private bool[,] visitedCells;

        /// <summary>
        /// Can override if needed
        /// </summary>
        public abstract IMaze CreateMaze();

        /// <summary>
        /// Generate the maze
        /// <remarks>
        /// Internally validate if maze can be exited. If can't regenerate again
        /// </remarks>
        /// </summary>
        public void GenerateMaze()
        {
            this.maze.PlayerPosition.X = this.maze.Rows / 2;
            this.maze.PlayerPosition.Y = this.maze.Cols / 2;

            this.mazeHasSolution = false;

            while (!this.mazeHasSolution)
            {
                for (int row = 0; row < this.maze.Rows; row++)
                {
                    for (int col = 0; col < this.maze.Cols; col++)
                    {
                        this.maze[row, col] = MazeCellCreator.CreateCell();
                    }
                }

                this.visitedCells = new bool[this.maze.Rows, this.maze.Cols];
                this.HasSolutuon(this.maze.PlayerPosition.X, this.maze.PlayerPosition.Y);
            }
        }

        /// <summary>
        /// Try to find a solution to the maze
        /// <remarks>
        /// If a solution exists then the maze is playable and valid
        /// </remarks>
        /// </summary>
        private void HasSolutuon(int row, int col)
        {
            if (!this.InRange(row, this.maze.Rows) || !this.InRange(col, this.maze.Cols))
            {
                this.mazeHasSolution = true;
                return;
            }
            else if (!this.visitedCells[row, col] && !this.mazeHasSolution && this.maze[row, col].IsEmpty)
            {
                this.visitedCells[row, col] = true;
                this.HasSolutuon(row, col + 1);
                this.HasSolutuon(row + 1, col);
                this.HasSolutuon(row - 1, col);
                this.HasSolutuon(row, col - 1);
            }
        }

        /// <summary>
        /// Check if is in range
        /// <param name="index">
        /// Must be valid Int32 number
        /// </param>
        /// <param name="length">
        /// Must be valid Int32 number
        /// </param>
        /// </summary>
        private bool InRange(int index, int length)
        {
            return 0 <= index && index < length;
        }
    }
}