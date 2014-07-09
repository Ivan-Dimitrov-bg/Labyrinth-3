namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    
    public class LabyrinthGame
    {
        private const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. \n";
        private const string CHOOSE_LAB_MESAGE = "Please enter what kind of labyrinth you want to play in: 'small', 'medium' or 'large':";
        private const string IN_GAME_MESSAGE = "Try to escape! Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n";
        private const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        private const string INVALID_MOVE_MESSAGE = "Invalid move!\n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";
        private const string GOODBYE_MESSAGE = "Good bye!\n";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname: ";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";

        private readonly IScoreBoard scores;
        private readonly IMaze maze;
        private readonly IRenderer renderer;
        private readonly IPlayer player;

        private MazeCreator mazeFactory;

       
        private bool hasExitCommand; //game in progress.    

        public LabyrinthGame()
        {
            this.renderer = new Renderer();
            this.maze = this.InitMaze();
            this.scores = new ScoreBoard();
            this.player = PlayerCreator.CreatePlayer();
        }

        public void Start()
        {
            while (!this.hasExitCommand)
            {
                this.player.Score = new PlayerScore();
                this.player.Position = this.maze.PlayerPosition;
                this.mazeFactory.GenerateMaze();
                this.TypeCommand();
            }
        }

        private IMaze InitMaze()
        {
            string labSizeChoice = string.Empty;
           
            this.renderer.Render(WELCOME_MESSAGE);
            this.renderer.Render(CHOOSE_LAB_MESAGE);           

            while (labSizeChoice != "small" && labSizeChoice != "medium" && labSizeChoice != "large")
            {
                labSizeChoice = Console.ReadLine();

                switch (labSizeChoice)
                {
                    case "small":
                        this.mazeFactory = new SmallMazeCreator();
                        break;
                    case "medium":
                        this.mazeFactory = new MediumMazeCreator();
                        break;
                    case "large":
                        this.mazeFactory = new LargeMazeCreator();
                        break;
                    default:
                        this.renderer.Render(INVALID_COMMAND_MESSAGE);
                        this.renderer.Render(CHOOSE_LAB_MESAGE);
                        break;
                }
            }

            return this.mazeFactory.CreateMaze();
        }

        private void TypeCommand()
        {
            while (true)
            { 
                this.renderer.Render(IN_GAME_MESSAGE);
                this.maze.Render(this.renderer);

                if (this.player.IsOutOfTheMaze(this.maze))
                {
                    this.renderer.Render(CONGRATULATIONS_MESSAGE, this.player.Score.Moves);
                    this.renderer.Render(NICKNAME_INPUT_MESSAGE);
                    this.player.Score.Name = Console.ReadLine();
                    this.renderer.Clear();
                    this.scores.AddScore(this.player.Score);
                    this.scores.Render(this.renderer);
                    return;
                }

                switch (this.player.Command)
                {
                    case PlayerCommand.InvalidMove:
                        this.renderer.Render(INVALID_MOVE_MESSAGE);
                        break;
                    case PlayerCommand.InvalidCommand:
                        this.renderer.Render(INVALID_COMMAND_MESSAGE);
                        break;
                    case PlayerCommand.PrintTopScores:
                        this.scores.Render(this.renderer);
                        break;
                    default:
                        this.player.Command = PlayerCommand.InvalidCommand;
                        break;
                }

                this.renderer.Render(INPUT_MESSAGE);
                string command = Console.ReadLine().ToLower();
                
                switch (command)
                {
                    case "d":
                        this.player.Direction = PlayerDirection.Down;
                        this.player.Command = PlayerCommand.Move;
                        break;
                    case "u":
                        this.player.Direction = PlayerDirection.Up;
                        this.player.Command = PlayerCommand.Move;
                        break;
                    case "r":
                        this.player.Direction = PlayerDirection.Right;
                        this.player.Command = PlayerCommand.Move;
                        break;
                    case "l":
                        this.player.Direction = PlayerDirection.Left;
                        this.player.Command = PlayerCommand.Move;
                        break;
                    case "top":
                        this.player.Command = PlayerCommand.PrintTopScores;
                        break;
                    case "restart":
                        this.renderer.Clear();
                        return;
                    case "exit":
                        this.renderer.Render(GOODBYE_MESSAGE);
                        this.hasExitCommand = true;
                        return;
                    default:
                        break;
                }
              
                this.renderer.Clear();               
                this.player.Move(this.maze);
                this.player.Score.Moves++;
            }
        }
    }
}