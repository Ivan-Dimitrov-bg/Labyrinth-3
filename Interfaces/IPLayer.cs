using Labyrinth.GameObjects;
namespace Labyrinth.Interfaces
{
    public interface IPlayer : ICell
    {
        int X { get; set; }
        
        int Y { get; set; }

        PlayerDirection Direction { get; set; }

        IScore Score { get; set; }
    }
}