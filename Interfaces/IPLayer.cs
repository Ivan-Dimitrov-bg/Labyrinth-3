namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;
    using Labyrinth.ScoreUtils;

    public interface IPlayer : ICell
    {
        PlayerCommand Command { get; set; }

        IMaze Maze { get; set; }

        IScore Score { get; set; }

        bool PlayerMoved { get; }

        void ExecuteCommand(string command);

        bool IsOutOfTheMaze();
    }
}