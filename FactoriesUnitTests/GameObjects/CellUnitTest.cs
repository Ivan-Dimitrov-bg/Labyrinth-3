using Labyrinth.GameObjects;

namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CellUnitTest
    {
        private Cell cell;

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Must be null when initialized!")]
        public void Cell_InitialValueIsNotSetToASpecificChar()
        {
            Assert.IsNull(this.cell.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "When setting a cell value can be only -, *, x!")]
        public void Cell_TryToSetWrongValue()
        {
            this.cell = new MazeCell('?');

        }
    }
}
