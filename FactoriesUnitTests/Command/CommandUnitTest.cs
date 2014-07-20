namespace FactoriesUnitTests.Command
{
    using Labyrinth.Commands;
    using Labyrinth.GameObjects;
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandUnitTest
    {
        private Command command;
        private MazeCreator mazeCreator;

        [TestMethod]
        public void Command_Initialize_Maze_Small()
        {
            IPlayer player = new Player();
            this.command = new MazeCreateCommand(player, "CreateSmallMaze");
            this.command.Execute();
        }

        [TestMethod]
        public void Command_Initialize_Maze_Medium()
        {
            IPlayer player = new Player();
            this.command = new MazeCreateCommand(player, "CreateMediumMaze");
            this.command.Execute();
        }

        [TestMethod]
        public void Command_Initialize_Maze_Large()
        {
            IPlayer player = new Player();
            this.command = new MazeCreateCommand(player, "CreateLargeMaze");
            this.command.Execute();
        }

        [TestMethod]
        public void Command_Initialize_Move()
        {
            IPlayer player = new Player();
            this.command = new MoveCommand(player, "up");
        }

        [TestMethod]
        public void Command_Initialize_Print()
        {
            IPlayer player = new Player();
            this.command = new PrintCommand(player, "score");
        }

        [TestMethod]
        public void Command_Initialize_Command_Execute()
        {
            IPlayer player = new Player();
            this.command = new PrintCommand(player, "exit");
            this.command.Execute();
        }
    }
}
