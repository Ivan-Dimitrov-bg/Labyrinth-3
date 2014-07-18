namespace FactoriesUnitTests.Factories
{
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerCreatorUnitTest
    {
        private int _large = 31;
        private int _medium = 21;
        private int _small = 11;

        [TestMethod]
        public void PlayerCreator_IsProducedInLargeMaze()
        {
            IMaze maze = new Maze(this._large, this._large);
            Assert.AreEqual(maze.Cols, this._large);
            Assert.AreEqual(maze.Rows, this._large);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player != null);
        }

        [TestMethod]
        public void PlayerCreator_IsProducedAsValidIPlayerInLargeMaze()
        {
            IMaze maze = new Maze(this._large, this._large);
            Assert.AreEqual(maze.Cols, this._large);
            Assert.AreEqual(maze.Rows, this._large);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player is IPlayer);
        }

        [TestMethod]
        public void PlayerCreator_IsProducedInMediumMaze()
        {
            IMaze maze = new Maze(this._medium, this._medium);
            Assert.AreEqual(maze.Cols, this._medium);
            Assert.AreEqual(maze.Rows, this._medium);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player != null);
        }

        [TestMethod]
        public void PlayerCreator_IsProducedAsValidIPlayerInMediumMaze()
        {
            IMaze maze = new Maze(this._medium, this._medium);
            Assert.AreEqual(maze.Cols, this._medium);
            Assert.AreEqual(maze.Rows, this._medium);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player is IPlayer);
        }

        [TestMethod]
        public void PlayerCreator_IsProducedInSmallMaze()
        {
            IMaze maze = new Maze(this._small, this._small);
            Assert.AreEqual(maze.Cols, this._small);
            Assert.AreEqual(maze.Rows, this._small);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player != null);
        }

        [TestMethod]
        public void PlayerCreator_IsProducedAsValidIPlayerInSmallMaze()
        {
            IMaze maze = new Maze(this._small, this._small);
            Assert.AreEqual(maze.Cols, this._small);
            Assert.AreEqual(maze.Rows, this._small);
            var player = PlayerCreator.CreatePlayer();
            Assert.IsTrue(player is IPlayer);
        }
    }
}
