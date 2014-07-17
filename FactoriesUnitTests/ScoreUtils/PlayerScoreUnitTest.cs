namespace FactoriesUnitTests.ScoreUtils
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.ScoreUtils;
    using Labyrinth.GameEngine;
    using System.IO;

    [TestClass]
    public class PlayerScoreUnitTest
    {
        private const int INVALID_NEGATIVE_POSSITION = -312311310;
        private const int INVALID_POSSITIVE_POSSITION = 7;
        private const int INVALID_NEGATIVE_MOVE = -2;
        private const string INVALID_NAME = "";

        readonly PlayerScore score = new PlayerScore();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithInvalidName()
        {
            this.score.Name = INVALID_NAME;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithNegativePossition()
        {
            this.score.Position = INVALID_NEGATIVE_POSSITION;         
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithTooBigPossition()
        {
            this.score.Position = INVALID_POSSITIVE_POSSITION;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithNegativeMoves()
        {
            this.score.Moves = INVALID_NEGATIVE_MOVE;
        }

        [TestMethod]
        
        public void PlayerScore_TestRenderMethodIfSetsProperMassageToConsole()
        {
            const int TEST_MOVES = 4;
            const int TEST_Position = 1;
            const string TEST_NAME = "Ivan";
            //gets console input
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ConsoleRenderer renderer = new ConsoleRenderer();
        
            this.score.Moves = TEST_MOVES;
            this.score.Name = TEST_NAME;
            this.score.Position = TEST_Position;
            this.score.Render(renderer);

            string expected = string.Format("{0}. {1} ---> {2} moves", this.score.Position, this.score.Name, this.score.Moves);
            
            Assert.AreEqual(expected, writer.ToString());
        }
    }
}
