namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;

    /// <summary>
    /// Inherits the ICell interface
    /// <remarks>
    /// Creates the player interface with appropriate getters and setters accordingly
    /// </remarks>
    /// </summary>
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