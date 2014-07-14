﻿namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    public class Maze : IMaze, IRenderable
    {
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";

        private readonly ICell[,] lab;

        public Maze(int rows, int cols)
        {
            this.lab = new Cell[rows, cols];
            this.PlayerPosition = new Position(this.Rows / 2, this.Cols / 2);
        }

        public Position PlayerPosition { get; private set; }

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

        // Strategy pattern.The object recieves concrete strategy implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            this.lab[this.PlayerPosition.X, this.PlayerPosition.Y].Value = Cell.PLAYER_VALUE;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    // Composite pattern... rendering the maze renders all the cells in it 
                    this.lab[row, col].Render(renderer);
                }

                renderer.Render("\n");
            }
        }

        private bool InRange(int index, int length)
        {
            return 0 <= index && index < length;
        }
    }
}