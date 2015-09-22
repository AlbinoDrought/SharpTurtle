using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle.Moves
{
    public class TurtleRotate : TurtleCommand
    {
        private double angle;

        public TurtleRotate(double angle)
        {
            this.angle = angle;
        }

        public override void Do(Turtle t)
        {
            t.Angle += this.angle;
        }

        public override void Undo(Turtle t)
        {
            t.Angle -= this.angle;
        }

        public override string ToString()
        {
            return string.Format("Rotates the turtle by {0} degrees", this.angle); ;
        }
    }
}
