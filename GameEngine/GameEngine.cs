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

        private readonly ScoreBoard scores;
        private readonly Maze labyrinth;
        private readonly Player player;

        private bool isPlaying = true; //game in progress.    

        public GameEngine()
        {
            player = new Player();
            labyrinth = new Maze();
            scores = new ScoreBoard();
        }

        public void Start()
        {
            while (isPlaying)
            {
                Renderer.RenderMessage(WELCOME_MESSAGE);                               
                player.Score = new PlayerScore();
                labyrinth.GenerateMaze();
                Renderer.RenderMaze(labyrinth);
                TypeCommand(player.X, player.Y);
            }
        }

        private void TypeCommand(int x, int y)
        {
            while (true)
            {
                Renderer.RenderMessage(INPUT_MESSAGE);
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
                            Renderer.RenderMessage(INPUT_MESSAGE);
                        }
                      
                        Renderer.RenderMaze(labyrinth);

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
                            Renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }

                        Renderer.RenderMaze(labyrinth);

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
                            Renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }
                        Renderer.RenderMaze(labyrinth);
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
                            Renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        }
                        Renderer.RenderMaze(labyrinth);
                        break;
                    case "top":
                        scores.ShowScore();
                        Renderer.RenderMessage(NEW_LINE);
                        Renderer.RenderMaze(labyrinth);
                        break;
                    case "restart":
                        return;
                    case "exit":
                        Renderer.RenderMessage(GOODBYE_MESSAGE);
                        isPlaying = false;
                        return;
                    default:
                        Renderer.RenderMessage(INVALID_MOVE_MESSAGE);
                        break;
                }
                if (x == 0 || x == this.labyrinth.Rows - 1 || y == 0 || y == this.labyrinth.Cols - 1)
                {
                    Renderer.RenderScore(scores, player);
                    return;
                }
            }
        }
    }
}