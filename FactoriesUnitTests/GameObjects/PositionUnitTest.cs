namespace FactoriesUnitTests.GameObjects
{
    using System;
    using Labyrinth.GameObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PositionUnitTest
    {
        private Position position;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "When setting a cell value can be only -, *, x!")]
        public void Position_XIsNegative()
        {
            this.position = new Position(0, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "When setting a cell value can be only -, *, x!")]
        public void Position_YIsNegative()
        {
            this.position = new Position(-10, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "When setting a cell value can be only -, *, x!")]
        public void Position_XYAreNegative()
        {
            this.position = new Position(-10, -10);
        }
    }
}
