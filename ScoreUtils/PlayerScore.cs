namespace Labyrinth.ScoreUtils
{
    using System;
    using Labyrinth.Interfaces;

    public class PlayerScore : IScore
    {
        private const string SCORELIST_ROW_TEMPLATE = "{0}. {1} ---> {2} moves";

        private int playerMoves;
        private string playerName;
        private int position;

        /// <summary>
        /// Get & Set player moves
        /// </summary>
        public int Moves
        {
            get
            {
                return this.playerMoves;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Moves cannot be negative!", "moves");
                }

                this.playerMoves = value;
            }
        }

        /// <summary>
        /// Get & Set player name
        /// </summary>
        public string Name
        {
            get
            {
                return this.playerName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!", "name");
                }

                this.playerName = value;
            }
        }

        /// <summary>
        /// Get & Set player position
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value <= 0 || 5 < value)
                {
                    throw new ArgumentException("Player score position must be between 0 and 5.");
                }

                this.position = value;
            }
        }

        /// <summary>
        /// Render the score result on the screen
        /// </summary>
        /// <param name="renderer"></param>
        public void Render(IRenderer renderer)
        {
            renderer.Color = ConsoleColor.Cyan;
            renderer.Render(SCORELIST_ROW_TEMPLATE, this.Position, this.Name, this.Moves);
        }
    }
}