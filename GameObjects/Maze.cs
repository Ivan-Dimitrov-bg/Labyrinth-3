using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameEngine;
using Labyrinth.Interfaces;

namespace Labyrinth.GameObjects
{
    public class Maze : IMaze
    { 
        private const int LAB_DIMENSIONS = 7;
        private const char VISITED_CELL_MARKER = '0';
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";
        
        private readonly ICell[,] lab;
        private bool mazeHasSolution;

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

        public Maze(int rows=LAB_DIMENSIONS, int cols=LAB_DIMENSIONS)
        {
            lab = new Cell[rows, cols];
        }

        public void GenerateMaze()
        {
            mazeHasSolution = false;

            while (!mazeHasSolution)                
            {
                for (int i = 0; i < this.Rows; i++)
                {
                    for (int j = 0; j < this.Cols; j++)
                    {
                        this.lab[i, j] = MazeCell.GenerateRandomCell();
                    }
                }
                this.HasSolutuon(Player.PLAYER_INITIAL, Player.PLAYER_INITIAL);
            }
            this.lab[Player.PLAYER_INITIAL, Player.PLAYER_INITIAL] = new Player();
        }

        public void DisplayMaze()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < this.Cols; j++)
                {
                    row.Append(this.lab[i, j] + " ");
                }
                Renderer.RenderMessage(row.ToString());
            }
            Renderer.RenderMessage(string.Empty);
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
                    for (int i = 0; i < this.Rows; i++)
                    {
                        for (int j = 0; j < this.Cols; j++)
                        {
                            if (lab[i, j].Value == VISITED_CELL_MARKER)
                            {
                                lab[i, j].Value = '-';
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