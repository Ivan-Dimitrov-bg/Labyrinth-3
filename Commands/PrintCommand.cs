namespace Labyrinth.Commands
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class PrintCommand : Command
    {
        private const string INVALID_MOVE_MESSAGE = "Invalid move!\n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";
        private const string GOODBYE_MESSAGE = "Good bye!\n";
        
        public PrintCommand(IPlayer player, string command) : base(player,command)
        {
        }

        public bool IsExitCommandEntered { get; set; }

        public bool IsRestartCommandEntered { get; set; }
        
        //Strategy pattern.The object recieves concrete strategy implementation of the renderer.
        public void Parse(IRenderer renderer, IScoreBoard score)
        {
            switch (this.player.Command)
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