namespace FactoriesUnitTests
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
            Assert.IsTrue(maze != null);
        }

        [TestMethod]
        public void MazeCreator_MediumMazeIsNotNull()
        {
            MazeCreator maze = new MediumMazeCreator();
            Assert.IsTrue(maze != null);
        }

        [TestMethod]
        public void MazeCreator_SmallMazeIsNotNull()
        {
            MazeCreator maze = new SmallMazeCreator();
            Assert.IsTrue(maze != null);
        }
    }
}
