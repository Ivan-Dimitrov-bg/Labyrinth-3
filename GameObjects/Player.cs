namespace Labyrinth.GameObjects
{ 
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public class Player : Cell, IPlayer
    {
        private readonly IMaze maze;

        private PlayerDirection direction;
        private PlayerCommand command;

        public Player(IMaze maze) : base(PLAYER_VALUE)
        {
            this.maze = maze;
        }

        public Position Position { get; set; }
        
        public PlayerScore Score { get; set; }

        public PlayerCommand Command
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
                //Observer pattern...
                this.Move();
            }
        }

        public PlayerDirection Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
                //Observer pattern...
                this.Command = PlayerCommand.Move;
            }
        }

        public bool IsOutOfTheMaze()
        {
            if (this.Position.X == 0 ||
                this.Position.X == this.maze.Rows - 1 ||
                this.Position.Y == 0 ||
                this.Position.Y == this.maze.Cols - 1)
            {
                return true;
            }

            return false;
        }

        private void Move()
        {
            if (this.Command == PlayerCommand.Move)
            {
                maze[this.Position.X, this.Position.Y].Value = EMPTY_CELL;

                switch (this.Direction)
                {
                    case PlayerDirection.Up:
                        if (this.maze[this.Position.X - 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X--;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Down:
                        if (this.maze[this.Position.X + 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X++;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Left:
                        if (this.maze[this.Position.X, this.Position.Y - 1].IsEmpty)
                        {
                            this.Position.Y--;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Right:
                        if (this.maze[this.Position.X, this.Position.Y + 1].IsEmpty)
                        {
                            this.Position.Y++;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;                   
                }
            }
        }
    }
}