namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;
    
    public class Maze : IMaze, IRenderable
    {
        private const int LAB_DIMENSIONS = 7;
        private const char VISITED_CELL_MARKER = '0';
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";

        private readonly ICell[,] lab;

        private Position playerPosition;
        private bool mazeHasSolution;
        private bool[,]visitedCells;
        
        public ICell this[int row, int col]
        {
            get
            {
                return this.lab[row, col];
            }
            set
            {
                if (!InRange(row, this.Rows) || !InRange(col, this.Cols))
                {
                    throw new IndexOutOfRangeException(OUTOFRANGE_MSG);
                }
                this.lab[row, col] = value;
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

        public Position PlayerPosition
        {
            get
            {
                return this.playerPosition;
            }
            set
            {
                this.playerPosition = value;
            }
        }

        public Maze(Position playerInitialPosition, int rows = LAB_DIMENSIONS, int cols = LAB_DIMENSIONS)
        {
            lab = new Cell[rows, cols];
            this.PlayerPosition = playerInitialPosition;
        }

        public void GenerateMaze()
        {
            mazeHasSolution = false;

            while (!mazeHasSolution)
            {
                for (int row = 0; row < this.Rows; row++)
                {
                    for (int col = 0; col < this.Cols; col++)
                    {
                        this.lab[row, col] = MazeCell.GenerateRandomCell();
                    }
                }

                visitedCells = new bool[this.Rows, this.Cols];
                this.HasSolutuon(this.PlayerPosition.X, this.PlayerPosition.Y);
            }
        }

        //Bridge pattern.The object recieves particular implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            this.lab[this.PlayerPosition.X, this.PlayerPosition.Y] = new Player(this.PlayerPosition);

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
            if (!InRange(row, this.Rows) || !InRange(col, this.Cols))
            {
                mazeHasSolution = true;
                return;
            }
            else if (!visitedCells[row, col] && this[row, col].IsEmpty)
            {
                visitedCells[row, col] = true;
                HasSolutuon(row, col + 1);
                HasSolutuon(row + 1, col);
                HasSolutuon(row - 1, col);
                HasSolutuon(row, col - 1);
            }
        }

        private bool InRange(int index, int length)
        {
            return 0 <= index && index < length;
        }
    }
}