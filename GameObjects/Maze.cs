using System;
using Labyrinth.Interfaces;
using System.Text;

namespace Labyrinth.GameObjects
{
    public class Maze : IMaze
    {
        private const int LAB_DIMENSIONS = 7;
        private const char VISITED_CELL_MARKER = '0';
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";

        private readonly ICell[,] lab;
        private bool mazeHasSolution;
        private Position playerInitialPosition;

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

        public Maze(Position playerInitialPosition, int rows = LAB_DIMENSIONS, int cols = LAB_DIMENSIONS)
        {
            lab = new Cell[rows, cols];
            this.playerInitialPosition = new Position(playerInitialPosition.X, playerInitialPosition.Y);
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

                this.HasSolutuon(playerInitialPosition.X, playerInitialPosition.Y);
            }

            this.lab[playerInitialPosition.X, playerInitialPosition.Y] = new Player(playerInitialPosition);
        }

        public void Render()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                StringBuilder rowSB = new StringBuilder();
                for (int col = 0; col < this.Cols; col++)
                {
                    rowSB.Append(this.lab[row, col] + " ");
                }
                new GameMessage(rowSB.ToString()).Render();
            }
            new GameMessage(string.Empty).Render();
        }

        private void HasSolutuon(int row, int col)
        {
            bool checking = true;

            if (!lab[row + 1, col].IsEmpty && !lab[row, col + 1].IsEmpty && !lab[row - 1, col].IsEmpty && !lab[row, col - 1].IsEmpty)
            {
                checking = false;
            }

            while (checking)
            {
                try
                {
                    if (lab[row + 1, col].IsEmpty)
                    {
                        lab[row + 1, col].Value = VISITED_CELL_MARKER;
                        row++;
                    }
                    else if (lab[row, col + 1].IsEmpty)
                    {
                        lab[row, col + 1].Value = VISITED_CELL_MARKER;
                        col++;
                    }
                    else if (lab[row - 1, col].IsEmpty)
                    {
                        lab[row - 1, col].Value = VISITED_CELL_MARKER;
                        row--;
                    }
                    else if (lab[row, col - 1].IsEmpty)
                    {
                        lab[row, col - 1].Value = VISITED_CELL_MARKER;
                        col--;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    for (int curRow = 0; curRow < this.Rows; curRow++)
                    {
                        for (int curCol = 0; curCol < this.Cols; curCol++)
                        {
                            if (lab[curRow, curCol].Value == VISITED_CELL_MARKER)
                            {
                                lab[curRow, curCol].Value = '-';
                            }
                        }

                        checking = false;
                        mazeHasSolution = true;
                    }
                }
            }
        }

        private bool InRange(int index, int length)
        {
            return 0 <= index && index < length;
        }
    }
}