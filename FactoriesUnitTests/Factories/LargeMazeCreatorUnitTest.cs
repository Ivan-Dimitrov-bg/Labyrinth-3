namespace FactoriesUnitTests
{
    using Labyrinth.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LargeMazeCreatorUnitTest
    {
        [TestMethod]
        public void CreateMaze_IsCreatedLarge()
        {
            LargeMazeCreator mazeCreator = new LargeMazeCreator();
            var maze = mazeCreator.CreateMaze();
            /// TODO: Large maze dimensions must be exactly 31x31
            Assert.AreEqual(maze.Cols, 31);
            Assert.AreEqual(maze.Rows, 31);
        }
    }
}
