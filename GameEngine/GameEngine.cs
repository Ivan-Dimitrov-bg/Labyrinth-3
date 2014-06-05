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
        
        private readonly Player player;
        private readonly ScoreBoard scores;
        private readonly Maze labyrinth;

        public GameEngine()
        {
            player = new Player(GameConstants.PLAYER_INITIAL,GameConstants.PLAYER_INITIAL);
            labyrinth = new Maze(GameConstants.LAB_DIMENSIONS, GameConstants.LAB_DIMENSIONS);
            scores = new ScoreBoard();
        }

        public void Start()
        {
            while (GameConstants.PLAYING)
            {
                Renderer.RenderMessage(GameConstants.WELCOME_MESSAGE);
               
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
                Renderer.RenderMessage(GameConstants.INPUT_MESSAGE);
                string i = Console.ReadLine();

                switch (i)
                {
                    case "d":
                    case "D":
                        if (labyrinth[x + 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell(GameConstants.EMPTY_CELL);
                            x++;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            Renderer.RenderMessage(GameConstants.INPUT_MESSAGE);
                        }
                      
                       Renderer.RenderMaze(labyrinth);

                        break;
                    case "u":                       
                    case "U":
                        if (labyrinth[x - 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell(GameConstants.EMPTY_CELL);
                            x--;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            Renderer.RenderMessage(GameConstants.INVALID_MOVE_MESSAGE);
                        }

                        Renderer.RenderMaze(labyrinth);

                        break;
                    case "r":                       
                    case "R":

                        if (labyrinth[x, y + 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell(GameConstants.EMPTY_CELL);
                            y++;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            Renderer.RenderMessage(GameConstants.INVALID_MOVE_MESSAGE);
                        }
                        Renderer.RenderMaze(labyrinth);
                        break;
                    case "l":
                    case "L":
                        if (labyrinth[x, y - 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell(GameConstants.EMPTY_CELL);
                            y--;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            Renderer.RenderMessage(GameConstants.INVALID_MOVE_MESSAGE);
                        }
                        Renderer.RenderMaze(labyrinth);
                        break;
                    case "top":
                        scores.ShowScore();
                        Renderer.RenderMessage(GameConstants.NEW_LINE);
                        Renderer.RenderMaze(labyrinth);
                        break;
                    case "restart":
                        return;
                    case "exit":
                        Renderer.RenderMessage(GameConstants.INVALID_MOVE_MESSAGE);
                        Environment.Exit(0);
                        break;
                    default:
                        Renderer.RenderMessage(GameConstants.INVALID_MOVE_MESSAGE);
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