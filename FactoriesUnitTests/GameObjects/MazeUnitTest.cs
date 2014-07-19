namespace FactoriesUnitTests.GameObjects
{
    using Labyrinth.GameEngine;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MazeUnitTest
    {
        private const int SMALL_ROWS = 11;
        private const int SMALL_COLS = 11;

        private readonly Maze maze = new Maze(SMALL_ROWS, SMALL_COLS);

        [TestMethod]
        public void Maze_IsInstanceOfMaze()
        {
            Assert.IsTrue(this.maze is IMaze);
        }

        [TestMethod]
        public void Maze_IsNotNull()
        {
            Assert.IsNotNull(this.maze);
        }

        [TestMethod]
        public void Maze_ColsAndRowsAreNotNulls()
        {
            Assert.IsNotNull(this.maze.Cols);
            Assert.IsNotNull(this.maze.Rows);
        }

        [TestMethod]
        public void Maze_AreColsAndRowsEqualToMazeColsAndRows()
        {
            Assert.AreEqual(SMALL_COLS, this.maze.Cols);
            Assert.AreEqual(SMALL_ROWS, this.maze.Rows);         
        }

        [TestMethod]
        public void Maze_IsPlayerPossitionSetCurrectly()
        {
            Position mazePlayerPosition = this.maze.PlayerPosition;
            Position expectedPlayerPosition = new Position(SMALL_COLS / 2, SMALL_ROWS / 2);
            Assert.AreEqual(expectedPlayerPosition.X, mazePlayerPosition.X);
            Assert.AreEqual(expectedPlayerPosition.Y, mazePlayerPosition.Y);           
        }

        // TODO maze.Renderer TESTS if possible 
        public void Maze_Renderer()
        {
            IRenderer dummyRenderer = new ConsoleRenderer();
        }
    }
}