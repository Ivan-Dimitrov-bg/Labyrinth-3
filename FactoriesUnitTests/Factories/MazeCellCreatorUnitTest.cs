namespace FactoriesUnitTests
{
    using Labyrinth.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class MazeCellCreatorUnitTest
    {
        [TestMethod]
        public void MazeCellCreator_CreatedCellIsNotNull()
        {
            MazeCellCreator mazeCellCreator = new MazeCellCreator();
            Assert.IsTrue(mazeCellCreator != null);
        }
    }
}
