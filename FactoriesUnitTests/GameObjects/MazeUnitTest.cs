namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    [TestClass]
    public class MazeUnitTest
    {

        private const int ROWS = 10;
        private const int COLS = 10;

        readonly Maze maze = new Maze(ROWS, COLS);

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
            Assert.AreEqual(COLS,this.maze.Cols);
            Assert.AreEqual(ROWS,this.maze.Rows);         
        }

        [TestMethod]
        public void Maze_IsPlayerPossitionSetCurrectly()
        {
            Position mazePlayerPosition = this.maze.PlayerPosition;
            Position expectedPlayerPosition = new Position(COLS / 2, ROWS / 2);
            Assert.AreEqual(expectedPlayerPosition.X,mazePlayerPosition.X);
            Assert.AreEqual( expectedPlayerPosition.Y,mazePlayerPosition.Y);           
        }

       //TODO maze.Renderer TESTS if possible 
    }
}
