namespace Labyrinth.Commands
{
    using Labyrinth.Interfaces;

    /// <summary>
    /// MoveCommand class
    /// </summary>
    /// <remarks>
    /// Inherits Command class
    /// </remarks>
    public class MoveCommand : Command
    {
        /// <summary>
        /// MoveCommand constructor
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
        public MoveCommand(IPlayer player, string operation)
            : base(player, operation)
        {
        }

        // There is no parse method here... the obeserver in the player takes care of the player movement...
    }
}