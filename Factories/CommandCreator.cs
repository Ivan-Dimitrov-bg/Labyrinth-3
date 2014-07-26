namespace Labyrinth.Factories
{
    using Labyrinth.Commands;
    using Labyrinth.Interfaces;

    public static class CommandCreator
    {
        // <summary>
        /// MoveCommand creation method
        /// </summary>
        /// <remarks>
        /// Will retunr instance of MoveCommand
        /// </remarks>
        /// <param name="player">
        /// Must be an instance of IPlayer
        /// </param>
        /// <param name="command">
        /// Must be a valid string
        /// </param>
        public static ICommand CreateMoveCommand(IPlayer player, string command)
        {
            return new MoveCommand(player, command);
        }

        // <summary>
        /// CreateCommand creation method
        /// </summary>
        /// <remarks>
        /// Will retunr instance of CreateCommand
        /// </remarks>
        /// <param name="player">
        /// Must be an instance of IPlayer
        /// </param>
        /// <param name="command">
        /// Must be a valid string
        /// </param>
        public static ICommand CreatePrintCommand(IPlayer player, string command)
        {
            return new PrintCommand(player, command);
        }

        // <summary>
        /// MazeCreateCommand creation method
        /// </summary>
        /// <remarks>
        /// Will retunr instance of MazeCreateCommand
        /// </remarks>
        /// <param name="player">
        /// Must be an instance of IPlayer
        /// </param>
        /// <param name="command">
        /// Must be a valid string
        /// </param>
        public static ICommand CreateMazeCreatorCommand(IPlayer player, string command)
        {
            return new MazeCreateCommand(player, command);
        }
    }
}