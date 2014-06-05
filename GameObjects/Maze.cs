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
                    throw new IndexOutOfRangeException("Position is out of the maze!");
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

        public Maze(int rows, int cols)
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
                this.HasSolutuon(GameConstants.PLAYER_INITIAL, GameConstants.PLAYER_INITIAL);
                this.lab[GameConstants.PLAYER_INITIAL, GameConstants.PLAYER_INITIAL] = 
                    new Player(GameConstants.PLAYER_INITIAL, GameConstants.PLAYER_INITIAL);
            }
        }

        public void DisplayMaze()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                ICell s1 = this.lab[i, 0];
                ICell s2 = this.lab[i, 1];
                ICell s3 = this.lab[i, 2];
                ICell s4 = this.lab[i, 3];
                ICell s5 = this.lab[i, 4];
                ICell s6 = this.lab[i, 5];
                ICell s7 = this.lab[i, 6];

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", s1, s2, s3, s4, s5, s6, s7);
            }
            Console.WriteLine();
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
                        lab[row + 1, col].Value = GameConstants.VISITED_CELL_MARKER;
                        row++;
                    }
                    else if (lab[row, col + 1].IsEmpty)
                    {
                        lab[row, col + 1].Value = GameConstants.VISITED_CELL_MARKER;
                        col++;
                    }
                    else if (lab[row - 1, col].IsEmpty)
                    {
                        lab[row - 1, col].Value = GameConstants.VISITED_CELL_MARKER;
                        row--;
                    }
                    else if (lab[row, col - 1].IsEmpty)
                    {
                        lab[row, col - 1].Value = GameConstants.VISITED_CELL_MARKER;
                        col--;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                catch (Exception)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (lab[i, j].Value == GameConstants.VISITED_CELL_MARKER)
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