namespace FactoriesUnitTests.GameEngine
{
    using System;
    using Labyrinth.GameEngine;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleRendererUnitTest
    {
        private readonly ConsoleRenderer consoleRenderer = new ConsoleRenderer();

        public void ConsoleRenderer_IsInstanceOfIRenderer()
        {
            Assert.IsTrue(this.consoleRenderer is IRenderer);
        }

        [TestMethod]
        public void ConsoleRenderer_IsNotNull()
        {
            Assert.IsTrue(this.consoleRenderer != null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "A null object was inappropriately supplied.")]
        public void ConsoleRenderer_OutputToConsoleIsSuppliedNullObject()
        {
            this.consoleRenderer.Render("Dummy command #1", null);
        }

        [TestMethod]
        public void ConsoleRenderer_Clear()
        {
            this.consoleRenderer.Clear();
        }

        [TestMethod]
        public void ConsoleRenderer_ReadCommand()
        {
            string dummyText = "Exit";
            //this.consoleRenderer.ReadCommand();
        }
    }
}
