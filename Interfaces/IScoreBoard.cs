using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IScoreBoard
    {
        void AddScore(PlayerScore currentPlayer);

        void ShowScore();
    }
}