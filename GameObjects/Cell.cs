namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    public abstract class Cell : ICell, IRenderable
    {
        public const char EMPTY_CELL = '-';

        public const char PLAYER_VALUE = '*';

        public const char WALL = 'x';

        private char value;

        public Cell(char value)
        {
            this.Value = value;
        }

        public char Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value != Cell.EMPTY_CELL && value != Cell.WALL && value != Cell.PLAYER_VALUE)
                {
                    throw new ArgumentException("Invalid cell value.");
                }

                this.value = value;
            }
        }

        public virtual bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        // Bridge pattern.The object recieves particular implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            switch (this.Value)
            {
                case WALL:
                    renderer.Color = ConsoleColor.Red;
                    break;
                case PLAYER_VALUE:
                    renderer.Color = ConsoleColor.Green;
                    break;
                default:
                    renderer.Color = ConsoleColor.White;
                    break;
            }

            renderer.Render(this.ToString());
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}