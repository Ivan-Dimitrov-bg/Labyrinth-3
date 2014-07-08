namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.Factories;

    public class Maze : IMaze, IRenderable
    {
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";

        private readonly ICell[,] lab;

        private Position playerPosition;
        private bool mazeHasSolution;
        private bool[,] visitedCells;

        public Maze(int rows, int cols)
        {
            this.lab = new Cell[rows, cols];
        }

        public ICell this[int row, int col]
        {
            get
            {
                return this.lab[row, col];
            }

            set
            {
                if (!this.InRange(row, this.Rows) || !this.InRange(col, this.Cols))
                {
                    throw new IndexOutOfRangeException(OUTOFRANGE_MSG);
                }

                this.lab[row, col] = value;
            }
        }

        public Position PlayerPosition
        {
            private get
            {
                return this.playerPosition;
            }

            set
            {
                if (!this.InRange(value.X, this.Rows) || !this.InRange(value.Y, this.Cols))
                {
                    throw new IndexOutOfRangeException(OUTOFRANGE_MSG);
                }

                this.playerPosition = value;
            }
        }

        public int Rows
        {
            get
            {
                return this.lab.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.lab.GetLength(1);
            }
        }

        public void GenerateMaze()
        {
            this.mazeHasSolution = false;

            while (!this.mazeHasSolution)
            {
                for (int row = 0; row < this.Rows; row++)
                {
                    for (int col = 0; col < this.Cols; col++)
                    {
                        this.lab[row, col] = MazeCellCreator.CreateCell();
                    }
                }

                this.visitedCells = new bool[this.Rows, this.Cols];
                this.HasSolutuon(this.PlayerPosition.X, this.PlayerPosition.Y);
            }
        }

        //Bridge pattern.The object recieves particular implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            this.lab[this.PlayerPosition.X, this.PlayerPosition.Y].Value = Cell.PLAYER_VALUE;

            for (int row = 0; row < this.Rows; row++)
            { 
                for (int col = 0; col < this.Cols; col++)
                {
                    //Composite pattern... rendering the maze renders all the cells in it 
                    this.lab[row, col].Render(renderer);
                }

                renderer.Render("\n");
            }
        }

        private void HasSolutuon(int row, int col)
        {
            if (!this.InRange(row, this.Rows) || !this.InRange(col, this.Cols))
            {
                this.mazeHasSolution = true;
                return;
            }
            else if (!this.visitedCells[row, col] && this[row, col].IsEmpty)
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