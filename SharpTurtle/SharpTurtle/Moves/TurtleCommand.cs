using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle.Moves
{
    public abstract class TurtleCommand
    {
        public abstract void Do(Turtle t);

        public abstract void Undo(Turtle t);
    }
}
