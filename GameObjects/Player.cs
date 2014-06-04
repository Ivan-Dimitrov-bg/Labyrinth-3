using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Interfaces;
using Labyrinth.ScoreUtils;

namespace Labyrinth.GameObjects
{
    public class Player : Cell, IPlayer
    {
        private const char PLAYER_VALUE = '*';

        public int X { get; set; }

        public int Y { get; set; }

        public PlayerScore Score { get; set; }

        public Direction Direction { get; set; }

        public Player(int x, int y) : base(PLAYER_VALUE)
        {
            this.X = x;
            this.Y = y;
        }
    }
}