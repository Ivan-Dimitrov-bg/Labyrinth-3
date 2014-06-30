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
        private const string INVALID_MOVE_MESSAGE = "\nInvalid move! \n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!";
        private const string GOODBYE_MESSAGE = "Good bye!";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname: ";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";

        private readonly IScoreBoard scores;
        private readonly IMaze labyrinth;
        private readonly IRenderer renderer;

        // We can set this as default position, if no other is entered
        private readonly Position playerInitialPosition = new Position(3, 3);

        private IPlayer player;
        private bool isPlaying = true; //game in progress.    

        // Here we can take initial position of player
        public GameEngine()
        {
            player = new Player(new Position(playerInitialPosition.X, playerInitialPosition.Y));
            labyrinth = new Maze(player.Position);
            scores = new ScoreBoard();
            renderer = new Renderer();
        }

        public void Start()
        {
            while (isPlaying)
            {
                renderer.Render(WELCOME_MESSAGE);               
                player = new Player(new Position(playerInitialPosition.X, playerInitialPosition.Y));
                player.Score = new PlayerScore();
                labyrinth.PlayerPosition = player.Position;
                labyrinth.GenerateMaze();
                labyrinth.Render(renderer);                
                TypeCommand();
            }
        }

        private void TypeCommand()
        {
            while (true)
            {
                renderer.Render(INPUT_MESSAGE);
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "d":
                        player.Direction = PlayerDirection.Down;
                        break;
                    case "u":
                        player.Direction = PlayerDirection.Up;
                        break;
                    case "r":
                        player.Direction = PlayerDirection.Right;
                        break;
                    case "l":
                        player.Direction = PlayerDirection.Left;
                        break;
                    case "top":
                        scores.Render(renderer);
                        renderer.Render(NEW_LINE);
                        labyrinth.Render(renderer);
                        break;
                    case "restart":
                        renderer.Clear();
                        return;
                    case "exit":
                        renderer.Render(GOODBYE_MESSAGE);
                        isPlaying = false;
                        return;
                    default:
                        break;
                }
               
                player.Move(labyrinth);
                player.Score.Moves++;
                player.Direction = PlayerDirection.Idle;
                renderer.Clear();
                renderer.Render(WELCOME_MESSAGE);
                labyrinth.Render(renderer);
                if (labyrinth.IsEndOfLabyrinthReached())
                {
                    renderer.Render(CONGRATULATIONS_MESSAGE, player.Score.Moves);
                    renderer.Render(NICKNAME_INPUT_MESSAGE);
                    player.Score.Name = Console.ReadLine();
                    scores.AddScore(player.Score);
                    scores.Render(renderer);
                    return;
                }
            }
        }
    }
}