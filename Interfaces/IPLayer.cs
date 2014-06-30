namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;
    using Labyrinth.ScoreUtils;

    public interface IPlayer : ICell
    {
        Position Position { get; }

        PlayerDirection Direction { get; set; }

        PlayerScore Score { get; set; }

        void Move(IMaze maze);

        bool IsOutOfTheMaze(IMaze maze);
    }
}