namespace Labyrinth.GameObjects
{
    using Labyrinth.Interfaces;

    public abstract class Cell : ICell
    {
        public char Value { get; set; }

        public virtual bool IsEmpty
        {
            get
            {
                return true;
            }
        }
        
        public Cell(char value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}