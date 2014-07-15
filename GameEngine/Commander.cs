namespace Labyrinth.GameEngine
{
    using Labyrinth.Commands;
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;

    public class Commander
    {
        private ICommand command;

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

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            if (this.command != null)
            {
                this.command.Execute();
            }
        }

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

        public MazeCreator GetMaze(IRenderer renderer, MazeCreator creator)
        {
            if (this.command != null)
            {
                if (this.command is MazeCreateCommand)
                {
                    return (this.command as MazeCreateCommand).CreateMaze(renderer, creator);
                }
            }

            return null;
        }
    }
}