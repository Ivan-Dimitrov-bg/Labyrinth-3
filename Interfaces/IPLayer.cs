using Labyrinth.GameObjects;
using Labyrinth.ScoreUtils;

namespace Labyrinth.Interfaces
{
    public interface IPlayer : ICell
    {
        Position Position { get; }

        PlayerDirection Direction { get; set; }

        PlayerScore Score { get; set; }
    }
}