namespace Labyrinth.GameEngine
{
    using Labyrinth.Commands;
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    /// <summary>
    /// LabyrinthGame class
    /// </summary>
    public class LabyrinthGame
    {
        private const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. \n";
        private const string CHOOSE_LAB_MESAGE = "Please enter what kind of labyrinth you want to play in: 'small', 'medium' or 'large':";
        private const string IN_GAME_MESSAGE = "Try to escape! Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n";
        private const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname: ";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";
        private readonly string[] COMMANDS = new string[] { "u", "d", "l", "r", "small", "medium", "large" };
        private readonly IMaze maze;
        private readonly IRenderer renderer;
        private readonly IPlayer player;
        private readonly IScoreBoard scores;
        private Commander commander;
        private MazeCreator mazeFactory;

        /// <summary>
        /// LabyrinthGame consturctor
        /// <remarks>
        /// Will initiate the console renderer and all other required classes
        /// </remarks>
        /// </summary>
        public LabyrinthGame()
        {
            this.renderer = new ConsoleRenderer();
            this.scores = new ScoreBoard();
            this.commander = new Commander();           
            this.player = PlayerCreator.CreatePlayer();     
            this.maze = this.InitMaze();           
        }

        /// <summary>
        /// Start the game
        /// <remarks>
        /// Will initiate all required classes and loop until forced to exit or player wins
        /// </remarks>
        /// </summary>
        public void Start()
        {
            while (!this.commander.IsExitCommandEntered)
            {
                this.commander = new Commander();
                this.mazeFactory.GenerateMaze();
                this.player.Score = new PlayerScore();   
                this.player.Maze = this.maze;                
                this.TypeCommand();
            }
        }

        /// <summary>
        /// Command pattern and maze initialization after valid maze choice
        /// <remarks>
        /// Choice must be between the allowed maze size enumerations
        /// </remarks>
        /// </summary>
        private IMaze InitMaze()
        {
            string labSizeChoice = string.Empty;
           
            this.renderer.Render(WELCOME_MESSAGE);
            this.renderer.Render(CHOOSE_LAB_MESAGE);

            while (labSizeChoice != this.COMMANDS[4] && labSizeChoice != this.COMMANDS[5] && labSizeChoice != this.COMMANDS[6])
            {
                // Command pattern...
                labSizeChoice = this.renderer.ReadCommand().ToLower();
                this.commander.SetCommand(new MazeCreateCommand(this.player, labSizeChoice));
                this.commander.ExecuteCommand();
                this.mazeFactory = this.commander.GetMaze(this.renderer, this.mazeFactory);
            }
            
            return this.mazeFactory.CreateMaze();
        }

        /// <summary>
        /// More command pattern
        /// <remarks>
        /// Utilize the command pattern for correct game progress and evaluation
        /// </remarks>
        /// </summary>
        private void TypeCommand()
        {
            while (true)
            { 
                this.renderer.Render(IN_GAME_MESSAGE);
                this.maze.Render(this.renderer);

                if (this.player.IsOutOfTheMaze())
                {
                    this.renderer.Render(CONGRATULATIONS_MESSAGE, this.player.Score.Moves);
                    this.renderer.Render(NICKNAME_INPUT_MESSAGE);
                    this.player.Score.Name = this.renderer.ReadCommand();
                    this.renderer.Clear();
                    this.scores.AddScore(this.player.Score);
                    this.scores.Render(this.renderer);
                    return;
                }
               
                this.commander.ParseCommand(this.renderer, this.scores);
                
                if (this.commander.IsExitCommandEntered || this.commander.IsRestartCommandEntered)
                {
                    return;
                }

                this.renderer.Render(INPUT_MESSAGE);
                string command = this.renderer.ReadCommand().ToLower();

                // Command pattern...
                if (command == this.COMMANDS[0] || command == this.COMMANDS[1] || command == this.COMMANDS[2] || command == this.COMMANDS[3])
                {
                    this.commander.SetCommand(new MoveCommand(this.player, command));
                    this.commander.ExecuteCommand();   
                    
                    if (!this.player.PlayerMoved)
                    {
                        this.commander.SetCommand(new PrintCommand(this.player, command));
                    }
                }
                else
                {
                    this.commander.SetCommand(new PrintCommand(this.player, command));
                    this.commander.ExecuteCommand();        
                }
         
                this.renderer.Clear(); 
            }
        }
    }
}