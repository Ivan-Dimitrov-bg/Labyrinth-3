namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.GameObjects;

    [TestClass]
    public class PlayerUnitTest
    {
        readonly Player player = new Player();
       

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
            Assert.AreEqual(this.player.Command,PlayerCommand.CreateSmallMaze);
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


        //TODO to find way to test method Move()
    }
}