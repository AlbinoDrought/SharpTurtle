using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle.Moves
{
    public class TurtleMove : TurtleCommand
    {
        private float distance;

        public TurtleMove(float distance)
        {
            this.distance = distance;
        }

        public override void Do(Turtle t)
        {
            this.Apply(t, this.distance);
        }

        public override void Undo(Turtle t)
        {
            this.Apply(t, -this.distance);
        }

        private void Apply(Turtle t, float distance)
        {
            float xDiff = (float)Math.Cos(t.Radians) * distance;
            float yDiff = (float)Math.Sin(t.Radians) * distance;

            t.X += xDiff;
            t.Y += yDiff;
        }

        public override string ToString()
        {
            return string.Format("Move turtle by {0} units", this.distance);
        }
    }
}
