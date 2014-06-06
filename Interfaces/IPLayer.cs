using Labyrinth.GameObjects;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IPlayer : ICell
    {
        int X { get; set; }
        
        int Y { get; set; }

        PlayerDirection Direction { get; set; }

        PlayerScore Score { get; set; }
    }
}