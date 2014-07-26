namespace FactoriesUnitTests.GameEngine
{
    using System;
    using System.IO;
    using Labyrinth.Factories;
    using Labyrinth.GameEngine;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommanderUnitTest 
    {
        private Commander commander;

        private IRenderer renderer;

        private IPlayer player;

        private MazeCreator mazeFactory;

        [TestInitialize]
        public void Initliaze()
        {
            this.player = new Player();
            this.commander = new Commander();
            this.renderer = new ConsoleRenderer();
        }

        [TestMethod]
        public void Commander_IsExitCommandEntered()
        {
            bool exit = this.commander.IsExitCommandEntered;
            Assert.IsFalse(exit);
        }

        [TestMethod]
        public void Commander_IsRestartCommandEntered()
        {
            bool restart = this.commander.IsRestartCommandEntered;
            Assert.IsFalse(restart);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Small()
        {
            this.commander.SetCommand(CommandCreator.CreateMazeCreatorCommand(this.player, "small"));
            this.commander.ExecuteCommand();
            this.mazeFactory = this.commander.GetMaze(this.renderer);
            this.player.Maze = this.mazeFactory.CreateMaze();
            Assert.AreEqual(this.player.Maze.Cols, 11);
            Assert.AreEqual(this.player.Maze.Rows, 11);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Medium()
        {
            this.commander.SetCommand(CommandCreator.CreateMazeCreatorCommand(this.player, "medium"));
            this.commander.ExecuteCommand();
            this.mazeFactory = this.commander.GetMaze(this.renderer);
            this.player.Maze = this.mazeFactory.CreateMaze();
            Assert.AreEqual(this.player.Maze.Cols, 21);
            Assert.AreEqual(this.player.Maze.Rows, 21);
        }

        [TestMethod]
        public void Command_Initialize_Maze_Large()
        {
            this.commander.SetCommand(CommandCreator.CreateMazeCreatorCommand(this.player, "large"));
            this.commander.ExecuteCommand();
            this.mazeFactory = this.commander.GetMaze(this.renderer);
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
            this.commander.SetCommand(CommandCreator.CreateMoveCommand(this.player, "u"));    
            this.commander.ExecuteCommand();

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
        public void Command_Initialize_MoveDown()
        {
            var mazeBuilder = new SmallMazeCreator();
            this.player.Maze = mazeBuilder.CreateMaze();
            mazeBuilder.GenerateMaze();
            this.player.Score = new PlayerScore();
            this.commander.SetCommand(CommandCreator.CreateMoveCommand(this.player, "d"));    
            this.commander.ExecuteCommand();

            if (this.player.Maze.PlayerPosition.X == (this.player.Maze.Rows / 2) + 1)
            {
                Assert.IsTrue(this.player.PlayerMoved);
            }
            else
            {
                Assert.IsFalse(this.player.PlayerMoved);
            }
        }

        [TestMethod]
        public void Command_Initialize_MoveLeft()
        {
            var mazeBuilder = new SmallMazeCreator();
            this.player.Maze = mazeBuilder.CreateMaze();
            mazeBuilder.GenerateMaze();
            this.player.Score = new PlayerScore();
            this.commander.SetCommand(CommandCreator.CreateMoveCommand(this.player, "l"));    
            this.commander.ExecuteCommand();

            if (this.player.Maze.PlayerPosition.Y == (this.player.Maze.Cols / 2) - 1)
            {
                Assert.IsTrue(this.player.PlayerMoved);
            }
            else
            {
                Assert.IsFalse(this.player.PlayerMoved);
            }
        }

        [TestMethod]
        public void Command_Initialize_MoveRight()
        {
            var mazeBuilder = new SmallMazeCreator();
            this.player.Maze = mazeBuilder.CreateMaze();
            mazeBuilder.GenerateMaze();
            this.player.Score = new PlayerScore();
            this.commander.SetCommand(CommandCreator.CreateMoveCommand(this.player, "r"));    
            this.commander.ExecuteCommand();

            if (this.player.Maze.PlayerPosition.Y == (this.player.Maze.Cols / 2) + 1)
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
            this.commander.SetCommand(CommandCreator.CreatePrintCommand(this.player, "top"));    
            this.commander.ExecuteCommand();
            this.commander.ParseCommand(this.renderer, board);         
            Assert.IsTrue(writer.ToString() != string.Empty);
        }
    }
}