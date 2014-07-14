namespace Labyrinth.Commands
{
    using Labyrinth.Interfaces;
    
    public abstract class Command : ICommand
    {
        protected readonly IPlayer Player;
        private readonly string operation;

        public Command(IPlayer player, string operation)
        {
            this.Player = player;
            this.operation = operation;
        }

        public void Execute()
        {
            this.Player.ExecuteCommand(this.operation);
        }
    }
}