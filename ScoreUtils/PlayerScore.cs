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
        /// Getter and setter for the current player moves
        /// <remarks>
        /// With validation for wrong data input which can not be a string with length shorter than 0
        /// <returns>
        /// Returns the player moves with a getter
        /// </returns>
        /// </remarks>
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
        /// Getter and setter for the current player name
        /// <remarks>
        /// With validation for wrong data input which must not be empty or null
        /// <returns>
        /// Returns the player name with a getter
        /// </returns>
        /// </remarks>
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
        /// Getter and setter for the current player position
        /// <remarks>
        /// With validation for wrong data input. Position must be in the range [0;5]
        /// <returns>
        /// Returns the player position with a getter
        /// </returns>
        /// </remarks>
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
        /// Renders the score result for the current player
        /// <remarks>
        /// Will be visualized with the default color and the score template
        /// <param name="renderer">
        /// Accepts an object instance of IRenderer
        /// </param>
        /// <returns>
        /// Does not return anything
        /// </returns>
        /// </remarks>
        /// </summary>
        public void Render(IRenderer renderer)
        {
            renderer.Color = ConsoleColor.Cyan;
            renderer.Render(SCORELIST_ROW_TEMPLATE, this.Position, this.Name, this.Moves);
        }
    }
}