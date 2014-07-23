namespace Labyrinth.Factories
{
    using Labyrinth.Commands;
    using Labyrinth.Interfaces;

    public static class CommandCreator
    {
        public static ICommand CreateMoveCommand(IPlayer player, string command)
        {
            return new MoveCommand(player, command);
        }

        public static ICommand CreatePrintCommand(IPlayer player, string command)
        {
            return new PrintCommand(player, command);
        }

        public static ICommand CreateMazeCreatorCommand(IPlayer player, string command)
        {
            return new MazeCreateCommand(player, command);
        }
    }
}