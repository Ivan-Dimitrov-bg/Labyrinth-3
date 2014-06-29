using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth;
using Labyrinth.GameObjects;
using Labyrinth.Interfaces;
using Labyrinth.ScoreUtils;

namespace Labyrinth.GameEngine
{
    public class GameEngine
    {
        private const string NEW_LINE = "\n";
        private const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ";
        private const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        private const string INVALID_MOVE_MESSAGE = "\nInvalid move! \n ";
        private const string INVALID_COMMAND_MESSAGE = "Invalid command!";
        private const string GOODBYE_MESSAGE = "Good bye!";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";

        private readonly ScoreBoard scores;
        private readonly Maze labyrinth;
        private readonly Renderer renderer;
        // We can set this as default position, if no other is entered
        private readonly Position playerInitialPosition = new Position(3, 3);

        private Player player;
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
                renderer.Render(new GameMessage(WELCOME_MESSAGE));
                
                player = new Player(new Position(playerInitialPosition.X, playerInitialPosition.Y));
                player.Score = new PlayerScore();
                labyrinth.GenerateMaze();
                renderer.Render(labyrinth);
                TypeCommand(player.Position);
            }
        }

        private void TypeCommand(Position position)
        {
            while (true)
            {
                renderer.Render(new GameMessage(INPUT_MESSAGE));
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "d":
                        Move(PlayerDirection.Down, position);
                        break;
                    case "u":
                        Move(PlayerDirection.Up, position);
                        break;
                    case "r":
                        Move(PlayerDirection.Right, position);
                        break;
                    case "l":
                        Move(PlayerDirection.Left, position);
                        break;
                    case "top":
                        renderer.Render(scores);
                        renderer.Render(new GameMessage(NEW_LINE));
                        renderer.Render(labyrinth);
                        break;
                    case "restart":
                        renderer.Clear();
                        return;
                    case "exit":
                        renderer.Render(new GameMessage(GOODBYE_MESSAGE));
                        isPlaying = false;
                        return;
                    default:
                        //renderer.Render(new GameMessage(GOODBYE_MESSAGE));
                        break;
                }
                if (IsEndOfLabyrinthReached(position))
                {
                    renderer.Render(new GameMessage(CONGRATULATIONS_MESSAGE, player.Score.Moves));
                    renderer.Render(new GameMessage(NICKNAME_INPUT_MESSAGE));
                    player.Score.Name = Console.ReadLine();
                    scores.AddScore(player.Score);
                    renderer.Render(scores);
                    return;
                }
            }
        }

        private bool IsCellEmpty(PlayerDirection direction, Position position)
        {
            bool isCellEmpty = false;

            switch (direction)
            {
                case PlayerDirection.Up:
                    isCellEmpty = labyrinth[position.X - 1, position.Y].IsEmpty;
                    break;
                case PlayerDirection.Down:
                    isCellEmpty = labyrinth[position.X + 1, position.Y].IsEmpty;
                    break;
                case PlayerDirection.Left:
                    isCellEmpty = labyrinth[position.X, position.Y - 1].IsEmpty;
                    break;
                case PlayerDirection.Right:
                    isCellEmpty = labyrinth[position.X, position.Y + 1].IsEmpty;
                    break;
                default:
                    throw new ArgumentException("Incorrect player direction!");
            }

            return isCellEmpty;
        }

        private void Move(PlayerDirection direction, Position position)
        {
            if (IsCellEmpty(direction, position))
            {
                labyrinth[position.X, position.Y] = new MazeCell();

                switch (direction)
                {
                    case PlayerDirection.Up:
                        position.X--;
                        break;
                    case PlayerDirection.Down:
                        position.X++;
                        break;
                    case PlayerDirection.Left:
                        position.Y--;
                        break;
                    case PlayerDirection.Right:
                        position.Y++;
                        break;
                    default:
                        throw new ArgumentException("Incorrect player direction!");
                }

                labyrinth[position.X, position.Y] = player;
                player.Score.Moves++;
                renderer.Clear();
                renderer.Render(new GameMessage(WELCOME_MESSAGE));
                renderer.Render(labyrinth);
            }
        }

        private bool IsEndOfLabyrinthReached(Position position)
        {
            if (position.X == 0 || 
                position.X == this.labyrinth.Rows - 1 || 
                position.Y == 0 || 
                position.Y == this.labyrinth.Cols - 1)
            {
                return true;
            }

            return false;
        }
    }
}