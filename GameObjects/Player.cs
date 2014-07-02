namespace Labyrinth.GameObjects
{    
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public class Player : Cell, IPlayer
    {
        public readonly Position PlayerInitialPosition;

        private const char PLAYER_VALUE = '*'; 

        private Position position;
     
        public Player(Position position) : base(PLAYER_VALUE)
        {
            this.Position = position;
            this.Direction = PlayerDirection.Idle;
            this.PlayerInitialPosition = new Position(this.Position.X, this.Position.Y);
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                if (value == null)
                {
                    this.position = new Position(this.PlayerInitialPosition.X, this.PlayerInitialPosition.Y);
                }
                else
                {
                    this.position = new Position(value.X, value.Y);
                }
            }
        }

        public PlayerScore Score { get; set; }

        public PlayerDirection Direction { get; set; }

        public void Move(IMaze labyrinth)
        {
            if (this.IsCellEmpty(labyrinth))
            {
                labyrinth[this.Position.X, this.Position.Y] = new MazeCell();

                switch (this.Direction)
                {
                    case PlayerDirection.Up:
                        this.Position.X--;
                        break;
                    case PlayerDirection.Down:
                        this.Position.X++;
                        break;
                    case PlayerDirection.Left:
                        this.Position.Y--;
                        break;
                    case PlayerDirection.Right:
                        this.Position.Y++;
                        break;
                }
            }
            else
            {
                if (this.Direction != PlayerDirection.Idle)
                {
                    this.Direction = PlayerDirection.Invalid;
                }
            }
        }

        public bool IsOutOfTheMaze(IMaze maze)
        {
            if (this.position.X == 0 ||
                this.position.X == maze.Rows - 1 ||
                this.position.Y == 0 ||
                this.position.Y == maze.Cols - 1)
            {
                return true;
            }

            return false;
        }
        
        private bool IsCellEmpty(IMaze labyrinth)
        {
            bool isCellEmpty = false;

            switch (this.Direction)
            {
                case PlayerDirection.Up:
                    isCellEmpty = labyrinth[this.Position.X - 1, this.Position.Y].IsEmpty;
                    break;
                case PlayerDirection.Down:
                    isCellEmpty = labyrinth[this.Position.X + 1, this.position.Y].IsEmpty;
                    break;
                case PlayerDirection.Left:
                    isCellEmpty = labyrinth[this.Position.X, this.Position.Y - 1].IsEmpty;
                    break;
                case PlayerDirection.Right:
                    isCellEmpty = labyrinth[this.Position.X, this.Position.Y + 1].IsEmpty;
                    break;
            }

            return isCellEmpty;
        }
    }
}