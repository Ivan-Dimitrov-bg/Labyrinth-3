namespace FactoriesUnitTests.ScoreUtils
{   
    using System;
    using System.IO;
    using Labyrinth.GameEngine;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardUnitTest
    {
        private readonly ScoreBoard scoreBoard = new ScoreBoard();

        [TestMethod]
        public void ScoreBoard_IsInstanceOfIScore()
        {
            Assert.IsTrue(this.scoreBoard is IScoreBoard);
        }

        [TestMethod]
        public void ScoreBoard_IsNotNull()
        {
            Assert.IsNotNull(this.scoreBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ScoreBoard_TestAddScoreNull()
        {
            this.scoreBoard.AddScore(null);
        }

        /// To try to find way to test ordering result in addScore method without rendering the final result
        [TestMethod]
        public void ScoreBoard_TestOrderingAddedScoresAndProperRendering()
        {
            PlayerScore firstPlayerScore = new PlayerScore();
            PlayerScore secondPlayerScore = new PlayerScore();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            ConsoleRenderer renderer = new ConsoleRenderer();
            firstPlayerScore.Moves = 10;
            firstPlayerScore.Name = "Ivan";
            secondPlayerScore.Moves = 9;
            secondPlayerScore.Name = "Gosho";
            this.scoreBoard.AddScore(secondPlayerScore);
            this.scoreBoard.AddScore(firstPlayerScore);
            this.scoreBoard.Render(renderer);
            string expected = string.Format("Top 5: \n{0}. {1} ---> {2} moves \n{3}. {4} ---> {5} moves \n", secondPlayerScore.Position, secondPlayerScore.Name, secondPlayerScore.Moves, firstPlayerScore.Position, firstPlayerScore.Name, firstPlayerScore.Moves);
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod]
        public void ScoreBoard_TryToAddMoreThanMaxAllowedTopScores()
        {
            const int NUMBER_OF_SCORES_TO_ADD = 10;
            const int NUMBER_OF_SCORES_TO_EXPECT = 5;
            const int TEST_MOVES = 9;
            const string TEST_NAME = "Ivan";
             
            for (int i = 0; i < NUMBER_OF_SCORES_TO_ADD; i++)
            {
                PlayerScore score = new PlayerScore();
                score.Name = TEST_NAME;
                score.Moves = TEST_MOVES;
                this.scoreBoard.AddScore(score);
            }

            StringWriter writer = new StringWriter();

            Console.SetOut(writer);
            ConsoleRenderer renderer = new ConsoleRenderer();

            this.scoreBoard.Render(renderer);
            string expected = "Top 5: \n";
            for (int i = 0; i < NUMBER_OF_SCORES_TO_EXPECT; i++)
            {
                expected += string.Format("{0}. {1} ---> {2} moves \n", i + 1, TEST_NAME, TEST_MOVES);
            }

            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Can't pass to AddScore wrong value for moves!")]
        public void ScoreBoard_AddScorePassWrongValueInMoves()
        {
            PlayerScore wrongTypeOfScore = new PlayerScore();
            wrongTypeOfScore.Moves = -7;
            this.scoreBoard.AddScore(wrongTypeOfScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Can't pass to AddScore wrong value for position!")]
        public void ScoreBoard_AddScorePassWrongValueInPosition()
        {
            PlayerScore wrongTypeOfScore = new PlayerScore();
            wrongTypeOfScore.Position = -4;
            this.scoreBoard.AddScore(wrongTypeOfScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Can't pass to AddScore wrong value for name!")]
        public void ScoreBoard_AddScorePassWrongValueInName()
        {
            PlayerScore wrongTypeOfScore = new PlayerScore();
            wrongTypeOfScore.Name = string.Empty;
            this.scoreBoard.AddScore(wrongTypeOfScore);
        }
    }
}
