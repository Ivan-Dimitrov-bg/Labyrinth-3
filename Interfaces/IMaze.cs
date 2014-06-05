using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Interfaces
{
    public interface IMaze
    {
        int Rows { get; }

        int Cols { get; }

        ICell this[int row, int col] { get; set; }

        void GenerateMaze();

        void DisplayMaze();
    }
}