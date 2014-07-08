namespace Labyrinth.GameObjects
{ 
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public class Player : Cell, IPlayer
    { 

        
        public Player() : base(PLAYER_VALUE)
        {
        }

        public Position Position { get; set; }
        
        public PlayerScore Score { get; set; }

        public PlayerCommand Command { get; set; }

        public PlayerDirection Direction { get; set; }

        public void Move(IMaze labyrinth)
        {
            if (this.Command == PlayerCommand.Move)
            {
                labyrinth[this.Position.X, this.Position.Y].Value = EMPTY_CELL;

                switch (this.Direction)
                {
                    case PlayerDirection.Up:
                        if (labyrinth[this.Position.X - 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X--;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Down:
                        if (labyrinth[this.Position.X + 1, this.Position.Y].IsEmpty)
                        {
                            this.Position.X++;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Left:
                        if (labyrinth[this.Position.X, this.Position.Y - 1].IsEmpty)
                        {
                            this.Position.Y--;
                        }
                        else
                        {
                            this.Command = PlayerCommand.InvalidMove;
                        }
                        break;
                    case PlayerDirection.Right:
                        if (labyrinth[this.Position.X, this.Position.Y + 1].IsEmpty)
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

        public bool IsOutOfTheMaze(IMaze maze)
        {
            if (this.Position.X == 0 ||
                this.Position.X == maze.Rows - 1 ||
                this.Position.Y == 0 ||
                this.Position.Y == maze.Cols - 1)
            {
                return true;
            }

            return false;
        }
    }
}