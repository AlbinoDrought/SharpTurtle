using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle.Moves
{
    public class TurtleTranslate : TurtleCommand
    {
        private float x, y;

        public TurtleTranslate(float offsetX, float offsetY)
        {
            this.x = offsetX;
            this.y = offsetY;
        }

        public TurtleTranslate(Turtle t, float x, float y)
        {
            float offsetX = x - t.X;
            float offsetY = y - t.Y;

            this.x = offsetX;
            this.y = offsetY;
        }

        public override void Do(Turtle t)
        {
            t.X += x;
            t.Y += y;
        }

        public override void Undo(Turtle t)
        {
            t.X -= x;
            t.Y -= y;
        }

        public override string ToString()
        {
            return string.Format("Moves the turtle to ({0},{1})", this.x, this.y);
        }
    }
}
