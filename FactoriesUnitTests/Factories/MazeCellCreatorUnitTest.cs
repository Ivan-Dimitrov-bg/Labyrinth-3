namespace FactoriesUnitTests.Factories
{
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class MazeCellCreatorUnitTest
    {
        [TestMethod]
        public void MazeCellCreator_CreatedCellIsEmpty()
        {
            ICell mazeCellCreator = MazeCellCreator.CreateCell();
            Assert.IsTrue(mazeCellCreator.IsEmpty == (mazeCellCreator.Value == '-'));
        }

        [TestMethod]
        public void MazeCellCreator_CreatedCellIsNotEmpty()
        {
            ICell mazeCellCreator = MazeCellCreator.CreateCell();
            Assert.IsFalse(mazeCellCreator.IsEmpty == (mazeCellCreator.Value == 'x'));
        }
    }
}