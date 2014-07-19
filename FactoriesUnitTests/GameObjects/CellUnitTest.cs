namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Labyrinth.GameEngine;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
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
        public void Cell_ValueIsEmpty()
        {
            this.cell = new MazeCell();
            Assert.IsTrue(this.cell.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "When setting a cell value can be only -, *, x!")]
        public void Cell_TryToSetWrongValue()
        {
            this.cell = new MazeCell('?');
        }

        [TestMethod]
        public void Cell_ReturnedValueToStringIsCorrect()
        {
            this.cell = new MazeCell('*');
            Assert.IsTrue(this.cell.ToString() == this.cell.Value.ToString());
        }

        [TestMethod]
        public void Renderer_TestWall()
        {
            this.cell = new MazeCell();
            IRenderer dummyRenderer = new ConsoleRenderer();
            dummyRenderer.Render("dummy command", 'x');
            this.cell.Render(dummyRenderer);
        }

        [TestMethod]
        public void Renderer_TestPlayerValue()
        {
            this.cell = new MazeCell();
            IRenderer dummyRenderer = new ConsoleRenderer();
            dummyRenderer.Render("dummy command", '*');
            this.cell.Render(dummyRenderer);
        }

        [TestMethod]
        public void Renderer_TestEmptyCell()
        {
            this.cell = new MazeCell();
            IRenderer dummyRenderer = new ConsoleRenderer();
            dummyRenderer.Render("dummy command", '-');
            this.cell.Render(dummyRenderer);
        }
    }
}
