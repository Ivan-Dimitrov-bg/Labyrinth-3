using Labyrinth.Interfaces;
using Labyrinth.ScoreUtils;

namespace Labyrinth.GameObjects
{
    public class Player : Cell, IPlayer
    {
        public readonly Position PLAYER_INITIAL_POSITION;

        private const char PLAYER_VALUE = '*';
        private Position position;

        public Position Position {
            get { return this.position; }
            private set
            {
                if (value == null)
                {
                    this.position = new Position(PLAYER_INITIAL_POSITION.X, PLAYER_INITIAL_POSITION.Y);
                }
                else
                {
                    this.position = new Position(value.X, value.Y);
                }
            }
        }

        public PlayerScore Score { get; set; }

        public PlayerDirection Direction { get; set; }

        public Player(Position position) : base(PLAYER_VALUE)
        {
            this.Position = position;
            this.PLAYER_INITIAL_POSITION = new Position(this.Position.X, this.Position.Y);
        }
    }
}