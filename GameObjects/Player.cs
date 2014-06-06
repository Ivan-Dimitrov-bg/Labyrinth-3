using Labyrinth.Interfaces;
using Labyrinth.ScoreUtils;

namespace Labyrinth.GameObjects
{
    public class Player : Cell, IPlayer
    {
        public const int PLAYER_INITIAL = 3;

        private const char PLAYER_VALUE = '*';

        public int X { get; set; }

        public int Y { get; set; }

        public PlayerScore Score { get; set; }

        public PlayerDirection Direction { get; set; }
        
        public Player(int x=PLAYER_INITIAL, int y=PLAYER_INITIAL) : base(PLAYER_VALUE)
        {
            this.X = x;
            this.Y = y;
        }
    }
}