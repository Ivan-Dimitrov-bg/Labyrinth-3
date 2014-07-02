namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    
    public class GameEngine
    {
        private const string NEW_LINE = "\n";
        private const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n";
        private const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        private const string INVALID_MOVE_MESSAGE = "Invalid move!\n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!\n";
        private const string GOODBYE_MESSAGE = "Good bye!\n";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname: ";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";

        private readonly IScoreBoard scores;
        private readonly IMaze maze;
        private readonly IRenderer renderer;

        // We can set this as default position, if no other is entered
        private readonly Position playerInitialPosition = new Position(3, 3);

        private IPlayer player;
        private bool hasExitCommand; //game in progress.    

        // Here we can take initial position of player
        public GameEngine()
        {
            this.player = new Player(new Position(this.playerInitialPosition.X, this.playerInitialPosition.Y));
            this.maze = new Maze(this.player.Position);
            this.scores = new ScoreBoard();
            this.renderer = new Renderer();
        }

        public void Start()
        {
            while (!this.hasExitCommand)
            {
                this.player = new Player(new Position(this.playerInitialPosition.X, this.playerInitialPosition.Y));
                this.player.Score = new PlayerScore();
                this.maze.PlayerPosition = this.player.Position;
                this.maze.GenerateMaze();
                this.TypeCommand();
            }
        }

        private void TypeCommand()
        {
            while (true)
            {
                this.player.Move(this.maze);
                this.player.Score.Moves++;
                this.renderer.Render(WELCOME_MESSAGE);
                this.maze.Render(this.renderer);

                if (this.player.Direction == PlayerDirection.Invalid)
                {
                    this.renderer.Render(INVALID_MOVE_MESSAGE);
                }

                if (this.player.IsOutOfTheMaze(this.maze))
                {
                    this.renderer.Render(CONGRATULATIONS_MESSAGE, this.player.Score.Moves);
                    this.renderer.Render(NICKNAME_INPUT_MESSAGE);
                    this.player.Score.Name = Console.ReadLine();
                    this.scores.AddScore(this.player.Score);
                    this.scores.Render(this.renderer);
                    return;
                }

                this.renderer.Render(INPUT_MESSAGE);
                this.player.Direction = PlayerDirection.Idle;
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "d":
                        this.player.Direction = PlayerDirection.Down;
                        break;
                    case "u":
                        this.player.Direction = PlayerDirection.Up;
                        break;
                    case "r":
                        this.player.Direction = PlayerDirection.Right;
                        break;
                    case "l":
                        this.player.Direction = PlayerDirection.Left;
                        break;
                    case "top":
                        this.scores.Render(this.renderer);
                        this.renderer.Render(NEW_LINE);
                        break;
                    case "restart":
                        this.renderer.Clear();
                        return;
                    case "exit":
                        this.renderer.Render(GOODBYE_MESSAGE);
                        this.hasExitCommand = true;
                        return;
                    default:
                        this.renderer.Render(INVALID_COMMAND_MESSAGE);
                        break;
                }

                if (this.player.Direction != PlayerDirection.Idle)
                {
                    this.renderer.Clear();
                }
            }
        }
    }
}