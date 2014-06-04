using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameObjects;
using Labyrinth.Interfaces;
using Labyrinth.ScoreUtils;

namespace Labyrinth
{
    public class GameEngine
    {
        private const bool PLAYING = true; //game in progress.      
        private const int PLAYER_INITIAL_XY = 3;
        private const int LAB_DIMENSIONS = 7;

        private readonly Player player;
        private readonly ScoreBoard scores;
        private readonly Maze labyrinth ;

        public GameEngine()
        {
            player = new Player(PLAYER_INITIAL_XY, PLAYER_INITIAL_XY);
            scores = new ScoreBoard();
            labyrinth = new Maze(LAB_DIMENSIONS, LAB_DIMENSIONS);
        }

        public void Start()
        {
            while (PLAYING)
            {
                Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ");
                
                player.Score = new PlayerScore();

                labyrinth.GenerateLabyrinth();
                labyrinth.DisplayLabyrint();
                TypeCommand(player.X, player.Y);
            }
        }

        private void TypeCommand(int x, int y)
        {
            while (true)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string i = string.Empty;
                i = Console.ReadLine();

                switch (i)
                {
                    case "d":
                    case "D":
                        if (labyrinth[x + 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell('-');
                            x++;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }
                      
                        labyrinth.DisplayLabyrint();

                        break;
                    case "u":                       
                    case "U":
                        if (labyrinth[x - 1, y].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell('-');
                            x--;
                            labyrinth[x, y] = player;
                            player.Score.Moves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        labyrinth.DisplayLabyrint();

                        break;
                    case "r":                       
                    case "R":

                        if (labyrinth[x, y + 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell('-');
                            y++;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }
                        labyrinth.DisplayLabyrint();
                        break;
                    case "l":
                    case "L":
                        if (labyrinth[x, y - 1].IsEmpty)
                        {
                            labyrinth[x, y] = new MazeCell('-');
                            y--;
                            labyrinth[x, y] = player;

                            player.Score.Moves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }
                        labyrinth.DisplayLabyrint();
                        break;
                    case "top":
                        scores.ShowScore();
                        Console.WriteLine("\n");
                        labyrinth.DisplayLabyrint();
                        break;
                    case "restart":
                        return;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
                if (x == 0 || x == this.labyrinth.Rows - 1 || y == 0 || y == this.labyrinth.Cols - 1)
                {
                    this.PrintHighScores();
                }
            }
        }

        private void PrintHighScores()
        {
            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", player.Score.Moves);
            scores.AddScore(player.Score);
            scores.ShowScore();
            
        }
    }
}