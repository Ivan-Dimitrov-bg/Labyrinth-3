namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    public class Player : Cell, IPlayer
    {
        private Position position;
        private PlayerDirection direction;

        public Player()
            : base(Cell.PLAYER_VALUE)
        {
        }

        public IMaze Maze { get; set; }

        public IScore Score { get; set; }

        public PlayerCommand Command { get; set; }

        public bool PlayerMoved { get; private set; }

        private PlayerDirection Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;

                // Observer pattern...player notifies himself to move when his direction is changed...
                this.Move();
            }
        }

        public void ExecuteCommand(string @operator)
        {
            switch (@operator)
            {
                case "small":
                    this.Command = PlayerCommand.CreateSmallMaze;
                    break;
                case "medium":
                    this.Command = PlayerCommand.CreateMediumMaze;
                    break;
                case "large":
                    this.Command = PlayerCommand.CreateLargeMaze;
                    break;
                case "d":
                    this.Direction = PlayerDirection.Down;
                    break;
                case "u":
                    this.Direction = PlayerDirection.Up;
                    break;
                case "r":
                    this.Direction = PlayerDirection.Right;
                    break;
                case "l":
                    this.Direction = PlayerDirection.Left;
                    break;
                case "top":
                    this.Command = PlayerCommand.PrintTopScores;
                    break;
                case "restart":
                    this.Command = PlayerCommand.Restart;
                    break;
                case "exit":
                    this.Command = PlayerCommand.Exit;
                    break;
                default:
                    this.Command = PlayerCommand.InvalidCommand;
                    break;
            }
        }

        public bool IsOutOfTheMaze()
        {
            this.position = this.Maze.PlayerPosition;

            if (this.position.X == 0 ||
                this.position.X == this.Maze.Rows - 1 ||
                this.position.Y == 0 ||
                this.position.Y == this.Maze.Cols - 1)
            {
                return true;
            }

            return false;
        }

        private void Move()
        {
            this.PlayerMoved = false;
            this.position = this.Maze.PlayerPosition;
            this.Maze[this.position.X, this.position.Y].Value = Cell.EMPTY_CELL;

            switch (this.Direction)
            {
                case PlayerDirection.Up:
                    if (this.Maze[this.position.X - 1, this.position.Y].IsEmpty)
                    {
                        this.position.X--;
                        this.PlayerMoved = true;
                    }

                    break;
                case PlayerDirection.Down:
                    if (this.Maze[this.position.X + 1, this.position.Y].IsEmpty)
                    {
                        this.position.X++;
                        this.PlayerMoved = true;
                    }

                    break;
                case PlayerDirection.Left:
                    if (this.Maze[this.position.X, this.position.Y - 1].IsEmpty)
                    {
                        this.position.Y--;
                        this.PlayerMoved = true;
                    }

                    break;
                case PlayerDirection.Right:
                    if (this.Maze[this.position.X, this.position.Y + 1].IsEmpty)
                    {
                        this.position.Y++;
                        this.PlayerMoved = true;
                    }

                    break;
            }

            if (!this.PlayerMoved)
            {
                this.Command = PlayerCommand.InvalidMove;
            }
            else
            {
                this.Score.Moves++;
            }
        }
    }
}