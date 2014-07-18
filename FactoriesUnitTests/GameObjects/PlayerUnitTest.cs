﻿namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerUnitTest
    {
        private readonly IPlayer player = new Player();

        [TestMethod]
        public void Player_IsInstanceOfCell()
        {
            Assert.IsTrue(this.player is ICell);
        }

        [TestMethod]
        public void Player_IsNotNull()
        {
            Assert.IsNotNull(this.player);
        }

        [TestMethod]
        public void Player_IsCreatedAsPlayerCell()
        {
            Assert.AreEqual('*', this.player.Value);
        }
        
        [TestMethod]
        public void Player_IsPlayerExecuteCommandsSetsCurrectValues()
        { 
            this.player.ExecuteCommand("small");
            Assert.AreEqual(this.player.Command, PlayerCommand.CreateSmallMaze);
            this.player.ExecuteCommand("medium");
            Assert.AreEqual(this.player.Command, PlayerCommand.CreateMediumMaze);
            this.player.ExecuteCommand("large");
            Assert.AreEqual(this.player.Command, PlayerCommand.CreateLargeMaze);
            this.player.ExecuteCommand("top");
            Assert.AreEqual(this.player.Command, PlayerCommand.PrintTopScores);
            this.player.ExecuteCommand("restart");
            Assert.AreEqual(this.player.Command, PlayerCommand.Restart);
            this.player.ExecuteCommand("exit");
            Assert.AreEqual(this.player.Command, PlayerCommand.Exit);
            this.player.ExecuteCommand("Some Wrong Command");
            Assert.AreEqual(this.player.Command, PlayerCommand.InvalidCommand);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Player_TestNotAssignedMaze()
        {
            this.player.ExecuteCommand("u");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Player_TestNotAssignedScore()
        {
            this.player.ExecuteCommand("u");
        }

        [TestMethod]
        public void Player_TestMoveCommand()
        {
            var mazeBuilder = new SmallMazeCreator();
            this.player.Maze = mazeBuilder.CreateMaze();
            mazeBuilder.GenerateMaze();
            this.player.Score = new PlayerScore();                        
            this.player.ExecuteCommand("u");
            if (this.player.Maze.PlayerPosition.X == (this.player.Maze.Rows / 2) - 1)
            {
                Assert.IsTrue(this.player.PlayerMoved);
            }
            else
            {
                Assert.IsFalse(this.player.PlayerMoved);
            }        
        }
    }
}