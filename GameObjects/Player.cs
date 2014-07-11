namespace Labyrinth.GameObjects
{ 
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public class Player : Cell, IPlayer
    {
        private readonly IMaze maze;
        private readonly IPlayer currentPlayer;

        private PlayerDirection direction;

        public Player(IMaze maze) : base(PLAYER_VALUE)
        {
            //Since we have one observer and it is the same type we attach it here.
            this.currentPlayer = this;
            this.maze = maze;
        }

        public Position Position { get; set; }
        
        public PlayerScore Score { get; set; }

        public PlayerCommand Command { get; set; }

        public PlayerDirection Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
                //Observer pattern...player notifies himself to move when his direction is changed...
                this.Notify();
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

        public void Move()
        {
            bool playerMoved = false;
            this.maze[this.Position.X, this.Position.Y].Value = EMPTY_CELL;
            this.Command = PlayerCommand.Move;

            if (this.Command == PlayerCommand.Move)
            {
                switch (this.Direction)
                {
                    case PlayerDirection.Up:
                        if (this.maze[this.Position.X - 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X--;
                            playerMoved = true;
                        }
                        break;
                    case PlayerDirection.Down:
                        if (this.maze[this.Position.X + 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X++;
                            playerMoved = true;
                        }
                        break;
                    case PlayerDirection.Left:
                        if (this.maze[this.Position.X, this.Position.Y - 1].IsEmpty)
                        {
                            this.Position.Y--;
                            playerMoved = true;
                        }
                        break;
                    case PlayerDirection.Right:
                        if (this.maze[this.Position.X, this.Position.Y + 1].IsEmpty)
                        {
                            this.Position.Y++;
                            playerMoved = true;
                        }
                        break;
                }
            }
            if (!playerMoved)
            {
                this.Command = PlayerCommand.InvalidMove;
            }
        }

        private void Notify()
        {
            this.currentPlayer.Move();
        }
    }
}