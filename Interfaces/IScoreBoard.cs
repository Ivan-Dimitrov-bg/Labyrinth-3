using System.Collections.Generic;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IScoreBoard :IRenderable
    {
        int Count { get; }
        
        void AddScore(PlayerScore currentPlayer);
    }
}