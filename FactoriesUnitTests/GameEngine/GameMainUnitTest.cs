namespace FactoriesUnitTests.GameEngine
{
    using System;
    using System.IO;
    using Labyrinth.GameEngine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameMainUnitTest
    {
        [TestMethod]
        public void GameMain_StartDoesNotResultInException()
        {
            LabyrinthGame game = new LabyrinthGame();

            using (StringWriter swOutput = new StringWriter())
            {
                Console.SetOut(swOutput);

                using (StringReader srSmall = new StringReader(string.Format("small{0}", Environment.NewLine)))
                {
                    game.Start();
                    Console.SetIn(srSmall);
                    StringReader srExit = new StringReader(string.Format("exit{0}", Environment.NewLine));
                    Console.SetIn(srExit);
                    var collectedOutput = swOutput.ToString();
                    Assert.IsTrue(collectedOutput.Length > 0);
                }
            }
        }
    }
}
