﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
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
                    throw new ArgumentException("moves","Moves cannot be negative!");
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
                    throw new ArgumentException("name","Name cannot be null or empty!");
                }
                this.playerName = value;
            }
        }

        public PlayerScore(int moves, string name)
        {
            this.playerMoves = moves;
            this.playerName = name;
        }

        
    }
}