using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Interfaces;

namespace Labyrinth.GameObjects
{
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