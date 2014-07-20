namespace Labyrinth.GameObjects
{
    /// <summary>
    /// Enumeration for all valid internal commands
    /// <remarks>
    /// Must be computed accordingly
    /// </remarks>
    /// </summary>
    public enum PlayerCommand
    {
        CreateLargeMaze,
        CreateMediumMaze,
        CreateSmallMaze,
        InvalidCommand,
        InvalidMove,
        PrintTopScores,
        Restart,
        Exit
    }
}