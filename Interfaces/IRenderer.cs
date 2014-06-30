using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Interfaces
{
    public interface IRenderer
    {
        void Render(string message, params object[] args);

        void Clear();
    }
}
