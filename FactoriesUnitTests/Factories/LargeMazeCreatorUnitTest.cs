namespace FactoriesUnitTests.Factories
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
            Assert.AreEqual(maze.Cols, 31);
            Assert.AreEqual(maze.Rows, 31);
        }
    }
}
