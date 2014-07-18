namespace FactoriesUnitTests.Factories
{
    using Labyrinth.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class MazeCreatorUnitTests
    {
        [TestMethod]
        public void MazeCreator_LargeMazeIsNotNull()
        {
            MazeCreator maze = new LargeMazeCreator();
            Assert.IsNotNull(maze);
        }

        [TestMethod]
        public void MazeCreator_MediumMazeIsNotNull()
        {
            MazeCreator maze = new MediumMazeCreator();
            Assert.IsNotNull(maze);
        }

        [TestMethod]
        public void MazeCreator_SmallMazeIsNotNull()
        {
            MazeCreator maze = new SmallMazeCreator();
            Assert.IsNotNull(maze);
        }
    }
}
