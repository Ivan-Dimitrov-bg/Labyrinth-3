namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    public abstract class Cell : ICell, IRenderable
    {
        public Cell(char value)
        {
            this.Value = value;
        }

        public char Value { get; set; }

        public virtual bool IsEmpty
        {
            get
            {
                return true;
            }
        }
          
        //Bridge pattern.The object recieves particular implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            renderer.Render(this.ToString());
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}