namespace Labyrinth.GameObjects
{
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using System;
    
    public class Player : Cell, IPlayer
    {
        private const char PLAYER_VALUE = '*';

        public readonly Position PlayerInitialPosition;

        private Position position;

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
                    this.position = new Position(PlayerInitialPosition.X, PlayerInitialPosition.Y);
                }
                else
                {
                    this.position = new Position(value.X, value.Y);
                }
            }
        }

        public PlayerScore Score { get; set; }

        public PlayerDirection Direction { get; set; }

        public Player(Position position) : base(PLAYER_VALUE)
        {
            this.Position = position;
            this.PlayerInitialPosition = new Position(this.Position.X, this.Position.Y);
        }
        
        public void Move(IMaze labyrinth)
        {
            if (IsCellEmpty(labyrinth))
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
                    isCellEmpty = labyrinth[this.Position.X + 1, position.Y].IsEmpty;
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