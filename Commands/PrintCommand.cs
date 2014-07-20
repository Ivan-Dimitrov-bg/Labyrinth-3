namespace Labyrinth.Commands
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// PrintCommand class
    /// </summary>
    /// <remarks>
    /// Inherits Command class
    /// </remarks>
    public class PrintCommand : Command
    {
        private const string INVALID_MOVE_MESSAGE = "Invalid move!\n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";
        private const string GOODBYE_MESSAGE = "Good bye!\n";

        /// <summary>
        /// PrintCommand constructor
        /// </summary>
        /// <remarks>
        /// Will call the base constructor
        /// </remarks>
        /// <param name="player">
        /// Must be an instance of IPlayer
        /// </param>
        /// <param name="command">
        /// Must be a valid string
        /// </param>
        public PrintCommand(IPlayer player, string command)
            : base(player, command)
        {
        }

        /// <summary>
        /// Automatig getter and setter for IsExitCommandEntered
        /// </summary>
        /// <returns>
        /// Returns a boolean value
        /// </returns>
        public bool IsExitCommandEntered { get; set; }

        /// <summary>
        /// Automatig getter and setter for IsRestartCommandEntered
        /// </summary>
        /// <returns>
        /// Returns a boolean value
        /// </returns>
        public bool IsRestartCommandEntered { get; set; }

        /// <summary>
        /// Parse method, implements the Strategy pattern.
        /// </summary>
        /// <remarks>
        /// The object recieves concrete strategy implementation of the renderer
        /// </remarks>
        /// <param name="renderer">
        /// Must be an instance of IRenderer
        /// </param>
        /// <param name="score">
        /// Must be an instance of IScoreBoard
        /// </param>
        public void Parse(IRenderer renderer, IScoreBoard score)
        {
            switch (this.Player.Command)
            {
                case PlayerCommand.InvalidMove:
                    renderer.Render(INVALID_MOVE_MESSAGE);
                    break;
                case PlayerCommand.InvalidCommand:
                    renderer.Render(INVALID_COMMAND_MESSAGE);
                    break;
                case PlayerCommand.PrintTopScores:
                    score.Render(renderer);
                    break;
                case PlayerCommand.Restart:
                    this.IsRestartCommandEntered = true;
                    renderer.Clear();
                    return;
                case PlayerCommand.Exit:
                    renderer.Render(GOODBYE_MESSAGE);
                    this.IsExitCommandEntered = true;
                    return;
            }
        }
    }
}