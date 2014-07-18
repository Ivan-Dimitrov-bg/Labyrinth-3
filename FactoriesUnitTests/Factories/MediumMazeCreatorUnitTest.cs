namespace FactoriesUnitTests.Factories
{
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
            Assert.AreEqual(maze.Cols, 21);
            Assert.AreEqual(maze.Rows, 21);
        }
    }
}
