using Labyrinth.GameObjects;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IPlayer : ICell
    {
        int X { get;  }
        
        int Y { get;  }

        PlayerDirection Direction { get; set; }

        PlayerScore Score { get; set; }
    }
}