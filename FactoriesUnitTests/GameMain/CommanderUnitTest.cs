
using Labyrinth.Commands;
using Labyrinth.GameObjects;

namespace FactoriesUnitTests
{
    using Labyrinth.GameEngine;
    using Labyrinth.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommanderUnitTest : Commander
    {
        private ICommand dummyCommand;
        private IRenderer dummyRenderer;
        private IScoreBoard dummyScore;
        private PlayerCommand command = PlayerCommand.Exit;

        [TestMethod]
        public void Commander_IsExitCommandEntered()
        {
            bool exit = this.IsExitCommandEntered;
            Assert.IsFalse(exit);
        }

        [TestMethod]
        public void Commander_IsRestartCommandEntered()
        {
            bool restart = this.IsRestartCommandEntered;
            Assert.IsFalse(restart);
        }

        [TestMethod]
        public void Commander_SetCommand()
        {
            this.SetCommand(this.dummyCommand);
        }

        [TestMethod]
        public void Commander_ParseCommand()
        {
            this.ParseCommand(this.dummyRenderer, this.dummyScore);
        }

        [TestMethod]
        public void Commander_ParseCommand_First_Is_Null()
        {
            this.ParseCommand(null, this.dummyScore);
        }

        [TestMethod]
        public void Commander_ParseCommand_Second_Is_Null()
        {
            this.ParseCommand(this.dummyRenderer, null);
        }

        [TestMethod]
        public void Commander_ParseCommand_Both_Are_Null()
        {
            this.ParseCommand(null, null);
        }

        [TestMethod]
        public void Commander_GetMaze()
        {
            var result = GetMaze(this.dummyRenderer);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Commander_ExecuteCommand()
        {
            this.ExecuteCommand();
        }
    }
}
