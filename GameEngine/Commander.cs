namespace Labyrinth.GameEngine
{
    using Labyrinth.Commands;
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;

    /// <summary>
    /// Commander class
    /// </summary>
    public class Commander
    {
        private ICommand command;

        /// <summary>
        /// Provide info if command is entered
        /// </summary>
        /// <returns>
        /// Boolean value
        /// </returns>
        public bool IsExitCommandEntered
        {
            get
            {
                if (this.command is PrintCommand && this.command != null)
                {
                    return (this.command as PrintCommand).IsExitCommandEntered;
                }

                return false;
            }
        }

        /// <summary>
        /// If command is entered -> check if command is to restart
        /// </summary>
        /// <returns>
        /// Boolean value
        /// </returns>
        public bool IsRestartCommandEntered
        {
            get
            {
                if (this.command is PrintCommand && this.command != null)
                {
                    return (this.command as PrintCommand).IsRestartCommandEntered;
                }

                return false;    
            }
        }

        /// <summary>
        /// Set current command
        /// </summary>
        /// /// <param name="command">
        /// Must be an instance of ICommand
        /// </param>
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        /// <summary>
        ///  If current command is set then execute it
        /// </summary>
        public void ExecuteCommand()
        {
            if (this.command != null)
            {
                this.command.Execute();
            }
        }

        /// <summary>
        /// Parse the current command
        /// </summary>
        /// <param name="renderer">
        /// Must be an instance of IRenderer
        /// </param>
        /// <param name="score">
        /// Must be an instance of IScoreBoard
        /// </param>
        public void ParseCommand(IRenderer renderer, IScoreBoard score)
        {
            if (this.command != null)
            {
                if (this.command is PrintCommand)
                {
                    (this.command as PrintCommand).Parse(renderer, score);
                }
            }
        }

        /// <summary>
        /// Create the required maze
        /// </summary>
        /// <param name="renderer">
        /// Must be an instance of IRenderer
        /// </param>
        /// <returns></returns>
        public MazeCreator GetMaze(IRenderer renderer)
        {
            if (this.command != null)
            {
                if (this.command is MazeCreateCommand)
                {
                    return (this.command as MazeCreateCommand).CreateMaze(renderer);
                }
            }

            return null;
        }
    }
}