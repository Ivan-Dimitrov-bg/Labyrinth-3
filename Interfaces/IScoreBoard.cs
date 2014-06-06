using System.Collections.Generic;
namespace Labyrinth.Interfaces
{
    public interface IScoreBoard: IEnumerable<IScore>
    {
        int Count { get; }
        
        void AddScore(IScore currentPlayer);
    }
}