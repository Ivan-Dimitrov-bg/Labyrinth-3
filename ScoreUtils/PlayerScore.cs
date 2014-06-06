using System;
using Labyrinth.Interfaces;

namespace Labyrinth.ScoreUtils
{
    public class PlayerScore 
    {
        private int playerMoves;

        private string playerName;

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

    }
}