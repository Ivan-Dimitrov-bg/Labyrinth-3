using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameEngine;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IPlayer
    {
        int X { get; set; }
        
        int Y { get; set; }

        Direction Direction { get; set; }

        PlayerScore Score { get; set; }

    }
}