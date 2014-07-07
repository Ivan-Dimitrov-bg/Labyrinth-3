namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.Factories;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    
    public class GameEngine
    {
        private const string NEW_LINE = "\n";
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
        private IPlayer player;
        LabCreator labFactory;
       
        private bool hasExitCommand; //game in progress.    

        public GameEngine()
        {
            this.renderer = new Renderer();
            this.maze = InitMaze();
            this.scores = new ScoreBoard();
        }

        public void Start()
        {
            while (!this.hasExitCommand)
            {
                this.player = PlayerCreator.CreatePlayer(this.maze.PlayerInitialPosition);
                this.player.Score = new PlayerScore();
                this.maze.PlayerPosition = this.player.Position;
                this.maze.GenerateMaze();
                this.TypeCommand();
            }
        }

        private IMaze InitMaze()
        {
            string choise = string.Empty;
           
            renderer.Render(WELCOME_MESSAGE);
            renderer.Render(CHOOSE_LAB_MESAGE);

            while (choise != "small" && choise != "medium" && choise != "large")
            {
                choise = Console.ReadLine();

                switch (choise)
                {
                    case "small": labFactory = new SmallLabCreator(); break;
                    case "medium": labFactory = new MediumLabCreator(); break;
                    case "large": labFactory = new LargeLabCreator(); break;
                    default: renderer.Render(INVALID_COMMAND_MESSAGE);
                        renderer.Render(CHOOSE_LAB_MESAGE);
                        break;
                }
            }

            return labFactory.CreateLabyrinth();
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
                    this.scores.AddScore(this.player.Score);
                    this.scores.Render(this.renderer);
                    return;
                }

                switch (this.player.State)
                {
                    case PlayerState.InvalidMove:
                        this.renderer.Render(INVALID_MOVE_MESSAGE); break;
                    case PlayerState.Idle:
                        this.renderer.Render(INVALID_COMMAND_MESSAGE); break;
                    case PlayerState.PrintingTopScores:
                        this.scores.Render(this.renderer);
                        this.renderer.Render(NEW_LINE); break;
                    default:
                        this.renderer.Render(INPUT_MESSAGE);
                        this.player.State = PlayerState.Idle;
                        break;
                }
               
                string command = Console.ReadLine().ToLower();
                
                switch (command)
                {
                    case "d":
                        this.player.State = PlayerState.MoveDown;
                        break;
                    case "u":
                        this.player.State = PlayerState.MoveUp;
                        break;
                    case "r":
                        this.player.State = PlayerState.MoveRight;
                        break;
                    case "l":
                        this.player.State = PlayerState.MoveLeft;
                        break;
                    case "top":
                        this.player.State = PlayerState.PrintingTopScores;
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