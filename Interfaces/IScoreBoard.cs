using System.Collections.Generic;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IScoreBoard: IEnumerable<PlayerScore>
    {
        int Count { get; }
        
        void AddScore(PlayerScore currentPlayer);
    }
}