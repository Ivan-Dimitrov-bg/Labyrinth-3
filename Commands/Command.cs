namespace Labyrinth.Commands
{
    using Labyrinth.Interfaces;

    /// <summary>
    /// Command class
    /// </summary>
    /// <remarks>
    /// Inherits ICommand interface
    /// </remarks>
    public abstract class Command : ICommand
    {
        protected readonly IPlayer Player;
        private readonly string operation;

        /// <summary>
        /// Command constructor
        /// </summary>
        /// <remarks>
        /// Will call the base constructor
        /// </remarks>
        /// <param name="player">
        /// Must be an instance of IPlayer
        /// </param>
        /// <param name="operation">
        /// Must be a valid string
        /// </param>
        public Command(IPlayer player, string operation)
        {
            this.Player = player;
            this.operation = operation;
        }

        /// <summary>
        /// Interpret the supplied command
        /// </summary>
        public void Execute()
        {
            this.Player.ExecuteCommand(this.operation);
        }
    }
}