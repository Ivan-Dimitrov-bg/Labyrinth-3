namespace FactoriesUnitTests.ScoreUtils
{
    using System;
    using System.IO;
    using Labyrinth.Factories;
    using Labyrinth.GameEngine;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerScoreUnitTest
    {
        private const int INVALID_NEGATIVE_POSSITION = -312311310;
        private const int INVALID_POSSITIVE_POSSITION = 7;
        private const int INVALID_NEGATIVE_MOVE = -2;
        private const string INVALID_NAME = "";

        private readonly PlayerScore playerScore = new PlayerScore();

        [TestMethod]
        public void PlayerScore_IsInstanceOfIScore()
        {
            Assert.IsTrue(this.playerScore is IScore);
        }

        [TestMethod]
        public void PlayerScore_IsNotNull()
        {
            Assert.IsNotNull(this.playerScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithInvalidName()
        {
            this.playerScore.Name = INVALID_NAME;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithNegativePossition()
        {
            this.playerScore.Position = INVALID_NEGATIVE_POSSITION;         
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithTooBigPossition()
        {
            this.playerScore.Position = INVALID_POSSITIVE_POSSITION;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScore_IsSetWithNegativeMoves()
        {
            this.playerScore.Moves = INVALID_NEGATIVE_MOVE;
        }

        [TestMethod]       
        public void PlayerScore_TestRenderMethodIfSetsProperMassageToConsole()
        {
            const int TEST_MOVES = 4;
            const int TEST_Position = 1;
            const string TEST_NAME = "Ivan";
            ///gets console input
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            ConsoleRenderer renderer = new ConsoleRenderer();
        
            this.playerScore.Moves = TEST_MOVES;
            this.playerScore.Name = TEST_NAME;
            this.playerScore.Position = TEST_Position;
            this.playerScore.Render(renderer);

            string expected = string.Format("{0}. {1} ---> {2} moves", this.playerScore.Position, this.playerScore.Name, this.playerScore.Moves);
            
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod]
        public void PlayerScore_InitialNameIsEmpty()
        {
            Assert.IsTrue(string.IsNullOrEmpty(this.playerScore.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value must be different than null or empty string!")]
        public void PlayerScore_GetNameCantBeSetToNull()
        {
            this.playerScore.Name = string.Empty;
            this.playerScore.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value must be in [0;5]")]
        public void PlayerScore_GetPositionSetCoordinatesToNegative()
        {
            this.playerScore.Position = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value must be in [0;5]")]
        public void PlayerScore_GetPositionSetCoordinatesToOver5()
        {
            this.playerScore.Position = 6;
        }

        [TestMethod]
        public void PlayerScore_GetPositionSetCoordinatesToWithingRange()
        {
            try
            {
                this.playerScore.Position = 3;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Setting the coords didn't work.");
            }
        }

        [TestMethod]
        public void PlayerScoreFactoryTest()
        {
            var score = ScoreBoardCreator.CreatePlayerScore();
            Assert.IsTrue(score is IScore);
        }

         [TestMethod]
        public void ScoreboardFactoryTest()
        {
            var score = ScoreBoardCreator.CreateScoreBoard();
            Assert.IsTrue(score is IScoreBoard);
        }
    }
}
