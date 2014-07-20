namespace FactoriesUnitTests.GameObjects
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MazeCellUnitTest
    {
        private readonly MazeCell mazeCell = new MazeCell();

        [TestMethod]
        public void Mazecell_IsInstanceOfICell()
        {
            Assert.IsTrue(this.mazeCell is ICell);
        }

        [TestMethod]
        public void MazeCell_IsNotNull()
        {
            Assert.IsNotNull(this.mazeCell);         
        }

        [TestMethod]
        public void MazeCell_IsCreatedAsEmptyCell()
        {
            Assert.IsTrue(this.mazeCell.IsEmpty);
        }

        // probably unnecessary method clone is using c# object.MemberwiseClone(); So it is tested by Microsoft
        [TestMethod]
        public void MazeCell_DoCloneMethodReturnsMazeCell()
        {
            var clonedMazeCell = this.mazeCell.Clone() as ICell;
            Assert.IsTrue(clonedMazeCell.Value == this.mazeCell.Value && clonedMazeCell.IsEmpty == this.mazeCell.IsEmpty);
        }
    }
}