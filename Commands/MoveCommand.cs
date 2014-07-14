namespace Labyrinth.Commands
{
    using Labyrinth.Interfaces;

    public class MoveCommand : Command
    {
        public MoveCommand(IPlayer player, string operation) : base(player, operation)
        {
            
        }

        //There is no parse method here... the obeserver in the player takes care of the player movement...
    }
}