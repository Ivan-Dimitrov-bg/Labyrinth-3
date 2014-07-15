namespace Labyrinth.Commands
{
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    public class MazeCreateCommand : Command
    {
        private const string CHOOSE_LAB_MESSAGE = "Please enter what kind of labyrinth you want to play in: 'small', 'medium' or 'large':";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";

        public MazeCreateCommand(IPlayer player, string command)
            : base(player, command)
        {
        }

        // Strategy pattern.The object recieves concrete strategy implementation of the renderer.
        public MazeCreator CreateMaze(IRenderer renderer,  MazeCreator creator)
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