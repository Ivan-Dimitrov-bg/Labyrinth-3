namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;
    using System;

    public abstract class MazeCreator
    {
        protected IMaze maze;
        private bool mazeHasSolution;
        private bool[,] visitedCells;

        public abstract IMaze CreateMaze();

        public void GenerateMaze()
        {
            this.maze.PlayerPosition.X = maze.Rows / 2;
            this.maze.PlayerPosition.Y = maze.Cols / 2;

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

        private void HasSolutuon(int row, int col)
        {
            if (!this.InRange(row, maze.Rows) || !this.InRange(col, maze.Cols))
            {
                this.mazeHasSolution = true;
                return;
            }
            else if (!this.visitedCells[row, col] && !this.mazeHasSolution && maze[row, col].IsEmpty)
            {
                this.visitedCells[row, col] = true;
                this.HasSolutuon(row, col + 1);
                this.HasSolutuon(row + 1, col);
                this.HasSolutuon(row - 1, col);
                this.HasSolutuon(row, col - 1);
            }
        }

        private bool InRange(int index, int length)
        {
            return 0 <= index && index < length;
        }
    }
}