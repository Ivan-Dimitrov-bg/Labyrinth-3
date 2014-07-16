namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.GameObjects;

    [TestClass]
    public class PlayerUnitTest
    {
        readonly Player player = new Player();

        [TestMethod]
        public void Player_IsInstanceOfCell()
        {
            Assert.IsTrue(this.player is Cell);
        }

        [TestMethod]
        public void Player_IsNotNull()
        {
            Assert.IsNotNull(this.player);
        }

        [TestMethod]
        public void MazeCell_IsCreatedAsEmptyCell()
        {
            Assert.AreEqual('*', this.player.Value);
        }

        //TODO ALL IMPORTANT TOMORROW
    }
}
