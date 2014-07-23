namespace Labyrinth.Commands
{
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// MazeCreateCommand class
    /// </summary>
    /// <remarks>
    /// Inherits Command class
    /// </remarks>
    public class MazeCreateCommand : Command
    {
        private const string CHOOSE_LAB_MESSAGE = "Please enter what kind of labyrinth you want to play in: 'small', 'medium' or 'large':";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";

        /// <summary>
        /// MazeCreateCommand constructor
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
        public MazeCreateCommand(IPlayer player, string command)
            : base(player, command)
        {
        }

        /// <summary>
        /// Create the maze utilizing the Strategy pattern
        /// </summary>
        /// <remarks>
        /// The object recieves concrete strategy implementation of the renderer
        /// </remarks>
        /// <param name="renderer">
        /// Must be an instance of IRenderer
        /// </param>
        /// <returns>
        /// MazeCreator object and null if invalid
        /// </returns>
        public MazeCreator CreateMaze(IRenderer renderer)
        {
            switch (this.Player.Command)
            {
                case PlayerCommand.CreateSmallMaze:
                    return new SmallMazeCreator();

                case PlayerCommand.CreateMediumMaze:
                    return new MediumMazeCreator();

                case PlayerCommand.CreateLargeMaze:
                    return new LargeMazeCreator();
                default:
                    renderer.Render(INVALID_COMMAND_MESSAGE);
                    renderer.Render(CHOOSE_LAB_MESSAGE);
                    return null;
            }
        }
    }
}