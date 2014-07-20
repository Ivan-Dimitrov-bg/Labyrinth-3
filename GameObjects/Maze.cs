namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    /// <summary>
    /// Maze class
    /// <remarks>
    /// Inherits the IMaze and IRenderable interfaces
    /// </remarks>
    /// </summary>
    public class Maze : IMaze, IRenderable
    {
        private const string OUTOFRANGE_MSG = "Position is out of the maze!";
        private readonly ICell[,] lab;

        /// <summary>
        /// Maze consturctor
        /// <remarks>
        /// Will set the new object with the specified rows and cols, and calculate the proper player starting position
        /// </remarks>
        /// <param name="rows">
        /// Must be valid Int32 number
        /// </param>
        /// <param name="cols">
        /// Must be valid Int32 number
        /// </param>
        /// </summary>
        public Maze(int rows, int cols)
        {
            this.lab = new Cell[rows, cols];
            this.PlayerPosition = new Position(this.Rows / 2, this.Cols / 2);
        }

        /// <summary>
        /// Getter and setter for the current PlayerPosition
        /// <remarks>
        /// None
        /// <returns>
        /// Utilizes automatic getter and private setter
        /// </returns>
        /// </remarks>
        /// </summary>
        public Position PlayerPosition { get; private set; }

        /// <summary>
        /// Get rows value
        /// <remarks>
        /// No setter allowed
        /// <returns>
        /// Rows as int
        /// </returns>
        /// </remarks>
        /// </summary>
        public int Rows
        {
            get
            {
                return this.lab.GetLength(0);
            }
        }

        /// <summary>
        /// Get cols value
        /// <remarks>
        /// No setter allowed
        /// <returns>
        /// Cols as int
        /// </returns>
        /// </remarks>
        /// </summary>
        public int Cols
        {
            get
            {
                return this.lab.GetLength(1);
            }
        }

        /// <summary>
        /// Prototyping the current maze
        /// <remarks>
        /// None
        /// </remarks>
        /// <param name="row">
        /// Must be valid Int32 number
        /// </param>
        /// <param name="col">
        /// Must be valid Int32 number
        /// </param>
        /// </summary>
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

        /// <summary>
        /// Strategy pattern
        /// <remarks>
        /// The object recieves concrete strategy implementation of the renderer
        /// </remarks>
        /// <param name="renderer">
        /// Accepts an instance of IRenderer interface
        /// </param>
        /// </summary>
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