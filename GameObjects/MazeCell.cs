namespace Labyrinth.GameObjects
{
    using System;

    public class MazeCell : Cell, ICloneable
    {
        public MazeCell(char value = EMPTY_CELL) : base(value)
        {
        }

        public override bool IsEmpty
        {
            get
            {
                return this.Value == EMPTY_CELL;
            }
        }

        //Prototype pattern
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}