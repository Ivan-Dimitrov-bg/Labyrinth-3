namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;

    /// <summary>
    /// MazeCreator class
    /// </summary>
    public abstract class MazeCreator
    {
        private bool mazeHasSolution;

        private bool[,] visitedCells;
        
        /// <summary>
        /// Gets and sets the only instance of the maze creator
        /// </summary>
        protected IMaze Maze { get; set; }

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
            this.Maze.PlayerPosition.X = this.Maze.Rows / 2;
            this.Maze.PlayerPosition.Y = this.Maze.Cols / 2;

            this.mazeHasSolution = false;

            while (!this.mazeHasSolution)
            {
                for (int row = 0; row < this.Maze.Rows; row++)
                {
                    for (int col = 0; col < this.Maze.Cols; col++)
                    {
                        this.Maze[row, col] = MazeCellCreator.CreateCell();
                    }
                }

                this.visitedCells = new bool[this.Maze.Rows, this.Maze.Cols];
                this.HasSolutuon(this.Maze.PlayerPosition.X, this.Maze.PlayerPosition.Y);
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
            if (!this.InRange(row, this.Maze.Rows) || !this.InRange(col, this.Maze.Cols))
            {
                this.mazeHasSolution = true;
                return;
            }
            else if (!this.visitedCells[row, col] && !this.mazeHasSolution && this.Maze[row, col].IsEmpty)
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