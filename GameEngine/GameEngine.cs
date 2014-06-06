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
        private readonly Player player;
        private readonly IRenderer renderer;

        private bool isPlaying = true; //game in progress.    

        public GameEngine()
        {
            player = new Player();
            labyrinth = new Maze();
            scores = new ScoreBoard();
            renderer = new Renderer();
        }

        public void Start()
        {
            while (isPlaying)
            {
                renderer.RenderMessage(WELCOME_MESSAGE);                               
                player.Score = new PlayerScore();
                labyrinth.GenerateMaze();
                renderer.RenderMaze(labyrinth);
                TypeCommand(player.X, player.Y);
            }
        }

        private void TypeCommand(int x, int y)
        {
            while (true)
            {
                renderer.RenderMessage(INPUT_MESSAGE);
                string i = Console.ReadLine();

                switch (i)
                {
                    case "d":
                    case "D":
                        if (labyrinth[x + 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell();
                            x++;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            renderer.RenderMessage(INPUT_MESSAGE);
                        }
                      
                        renderer.RenderMaze(labyrinth);

                        break;
                    case "u":                       
                    case "U":
                        if (labyrinth[x - 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell();
                            x--;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }

                        renderer.RenderMaze(labyrinth);

                        break;
                    case "r":                       
                    case "R":

                        if (labyrinth[x, y + 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell();
                            y++;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }
                        renderer.RenderMaze(labyrinth);
                        break;
                    case "l":
                    case "L":
                        if (labyrinth[x, y - 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell();
                            y--;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }
                        renderer.RenderMaze(labyrinth);
                        break;
                    case "top":
                        renderer.RenderScore(scores, player);
                        renderer.RenderMessage(NEW_LINE);
                        renderer.RenderMaze(labyrinth);
                        break;
                    case "restart":
                        return;
                    case "exit":
                        renderer.RenderMessage(GOODBYE_MESSAGE);
                        isPlaying = false;
                        return;
                    default:
                        renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        break;
                }
                if (x == 0 || x == this.labyrinth.Rows - 1 || y == 0 || y == this.labyrinth.Cols - 1)
                {
                    renderer.RenderMessage(CONGRATULATIONS_MESSAGE, player.Score.Moves);   
                    renderer.RenderMessage(NICKNAME_INPUT_MESSAGE);
                    player.Score.Name = Console.ReadLine();
                    scores.AddScore(player.Score);  
                    renderer.RenderScore(scores, player);
                    return;
                }
            }
        }
    }
}