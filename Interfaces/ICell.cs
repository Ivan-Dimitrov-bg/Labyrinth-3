using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Interfaces
{
    public interface ICell
    {
        char Value { get; set; }

        bool IsEmpty { get; }
    }
}