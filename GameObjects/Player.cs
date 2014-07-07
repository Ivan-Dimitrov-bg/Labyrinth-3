namespace Labyrinth.GameObjects
{ 
    using System;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public class Player : Cell, IPlayer
    {
        private const char PLAYER_VALUE = '*'; 
        private const char EMPTY_VALUE = '-'; 

        private Position position;
     
        public Player(Position position) : base(PLAYER_VALUE)
        {
            this.Position = position;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                this.position = new Position(value.X, value.Y);
            }
        }

        public PlayerScore Score { get; set; }

        public PlayerState State { get; set; }

        public void Move(IMaze labyrinth)
        {
            if (this.IsCellEmpty(labyrinth))
            {
                labyrinth[this.Position.X, this.Position.Y].Value = EMPTY_VALUE;

                switch (this.State)
                {
                    case PlayerState.MoveUp:
                        this.Position.X--;
                        break;
                    case PlayerState.MoveDown:
                        this.Position.X++;
                        break;
                    case PlayerState.MoveLeft:
                        this.Position.Y--;
                        break;
                    case PlayerState.MoveRight:
                        this.Position.Y++;
                        break;
                }
            }
            else
            {
                if (this.State != PlayerState.Idle)
                {
                    this.State = PlayerState.PrintingTopScores;
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

            switch (this.State)
            {
                case PlayerState.MoveUp:
                    isCellEmpty = labyrinth[this.Position.X - 1, this.Position.Y].IsEmpty;
                    break;
                case PlayerState.MoveDown:
                    isCellEmpty = labyrinth[this.Position.X + 1, this.position.Y].IsEmpty;
                    break;
                case PlayerState.MoveLeft:
                    isCellEmpty = labyrinth[this.Position.X, this.Position.Y - 1].IsEmpty;
                    break;
                case PlayerState.MoveRight:
                    isCellEmpty = labyrinth[this.Position.X, this.Position.Y + 1].IsEmpty;
                    break;
            }

            return isCellEmpty;
        }
    }
}