namespace Labyrinth.GameObjects
{
    using System;

    public class MazeCell : Cell
    {
      
        private const char DEFAULT_CELL_VALUE = '-';
    
        
        public MazeCell(char value = DEFAULT_CELL_VALUE) : base(value)
        {
        }

        public override bool IsEmpty
        {
            get
            {
                return this.Value == DEFAULT_CELL_VALUE;
            }
        }

       
    }
}