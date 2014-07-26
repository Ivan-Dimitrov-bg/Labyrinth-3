namespace FactoriesUnitTests.Command
{
    using System;
    using Labyrinth.Commands;
    using Labyrinth.Factories;
    using Labyrinth.GameEngine;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class CommandUnitTest
    {
        private ICommand command;

        private IRenderer renderer;

        private IPlayer player;

        private MazeCreator mazeFactory;

        [TestInitialize]
        public void Initliaze()
        {
            this.player = new Player();
            this.renderer = new ConsoleRenderer();
        }

        [TestMethod]
        public void Commander_IsExitCommandEntered()
        {
            var command = CommandCreator.CreatePrintCommand(this.player,"exit");
            bool exit = (command as PrintCommand).IsExitCommandEntered;
            Assert.IsFalse(exit);          
        }

        [TestMethod]
        public void Commander_IsRestartCommandEntered()
        {
            var command = CommandCreator.CreatePrintCommand(this.player,"restart");
            bool exit = (command as PrintCommand).IsRestartCommandEntered;
            Assert.IsFalse(exit);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Small()
        {
            this.command = CommandCreator.CreateMazeCreatorCommand(this.player, "small");
            this.command.Execute();
            this.mazeFactory = (this.command as MazeCreateCommand).CreateMaze(this.renderer);
            this.player.Maze = this.mazeFactory.CreateMaze();
            Assert.AreEqual(this.player.Maze.Cols, 11);
            Assert.AreEqual(this.player.Maze.Rows, 11);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Medium()
        {
            this.command = CommandCreator.CreateMazeCreatorCommand(this.player, "medium");
            this.command.Execute();
            this.mazeFactory = (this.command as MazeCreateCommand).CreateMaze(this.renderer);
            this.player.Maze = this.mazeFactory.CreateMaze();
            Assert.AreEqual(this.player.Maze.Cols, 21);
            Assert.AreEqual(this.player.Maze.Rows, 21);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Large()
        {
            this.command = CommandCreator.CreateMazeCreatorCommand(this.player, "large");
            this.command.Execute();
            this.mazeFactory = (this.command as MazeCreateCommand).CreateMaze(this.renderer);
            this.player.Maze = this.mazeFactory.CreateMaze();
            Assert.AreEqual(this.player.Maze.Cols, 31);
            Assert.AreEqual(this.player.Maze.Rows, 31);
        }

        [TestMethod]
        public void Command_Initialize_MoveUp()
        {
            var mazeBuilder = new SmallMazeCreator();
            this.player.Maze = mazeBuilder.CreateMaze();
            mazeBuilder.GenerateMaze();
            this.player.Score = new PlayerScore();
            this.command = CommandCreator.CreateMoveCommand(this.player, "u");
            this.command.Execute();

            if (this.player.Maze.PlayerPosition.X == (this.player.Maze.Rows / 2) - 1)
            {
                Assert.IsTrue(this.player.PlayerMoved);
            }
            else
            {
                Assert.IsFalse(this.player.PlayerMoved);
            }
        }

        [TestMethod]
        public void Command_Initialize_Print()
        { 
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            var board = new ScoreBoard();
            this.command = CommandCreator.CreatePrintCommand(this.player, "top");
            this.command.Execute();
            (this.command as PrintCommand).Parse(this.renderer, board);         
            Assert.IsTrue(writer.ToString() != string.Empty);
        }
    }
}