namespace FactoriesUnitTests
{
    using System;
    using Labyrinth.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MediumMazeCreatorUnitTest
    {
        [TestMethod]
        public void CreateMaze_IsCreatedMedium()
        {
            MediumMazeCreator mazeCreator = new MediumMazeCreator();
            var maze = mazeCreator.CreateMaze();
            // TODO: Large maze dimensions must be exactly 21x21
            Assert.AreEqual(maze.Cols, 21);
            Assert.AreEqual(maze.Rows, 21);
        }
    }
}
