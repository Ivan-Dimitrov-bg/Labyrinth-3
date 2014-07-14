namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;
    using Labyrinth.ScoreUtils;

    public interface IPlayer : ICell
    {
        PlayerCommand Command { get; set; }

        IMaze Maze { get; set; }

        PlayerScore Score { get; set; }

        void ExecuteCommand(string command);

        bool IsOutOfTheMaze();

        bool PlayerMoved { get; }
    }
}