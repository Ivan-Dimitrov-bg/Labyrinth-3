namespace FactoriesUnitTests.Factories
{
    using Labyrinth.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SmallMazeCreatorUnitTest
    {
        [TestMethod]
        public void CreateMaze_IsCreatedSmall()
        {
            SmallMazeCreator mazeCreator = new SmallMazeCreator();
            var maze = mazeCreator.CreateMaze();
            Assert.AreEqual(maze.Cols, 11);
            Assert.AreEqual(maze.Rows, 11);
        }
    }
}
