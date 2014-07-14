namespace Labyrinth.Commands
{
    using Labyrinth.Interfaces;
    
    public abstract class Command : ICommand
    {
        protected readonly IPlayer player;
        private readonly string operation;

        public Command(IPlayer player, string operation)
        {
            this.player = player;
            this.operation = operation;
        }

        public void Execute()
        {
            this.player.ExecuteCommand(this.operation);
        }
    }
}