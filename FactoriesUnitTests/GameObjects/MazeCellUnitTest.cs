namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.GameObjects;

    [TestClass]
    public class MazeCellUnitTest
    {

        readonly MazeCell mazeCell = new MazeCell();

        [TestMethod]
        public void Mazecell_IsInstanceOfCell()
        {
            Assert.IsTrue(this.mazeCell is MazeCell);
        }

        [TestMethod]
        public void MazeCell_IsNotNull()
        {
            Assert.IsNotNull(this.mazeCell);         
        }

        [TestMethod]
        public void MazeCell_IsCreatedAsEmptyCell()
        {
            Assert.AreEqual('-', this.mazeCell.Value);
        }

        //probably unnecessary method clone is using c# object.MemberwiseClone(); So it is tested by Microsoft
        [TestMethod]
        public void MazeCell_DoCloneMethodReturnsMazeCell()
        {
            var clonedMazeCell = this.mazeCell.Clone();
            Assert.IsTrue(clonedMazeCell is MazeCell);
        }
    }
}
