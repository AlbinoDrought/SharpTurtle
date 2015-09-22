using SharpTurtle.Moves;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle
{
    public class Turtle
    {
        public Screen Screen { get; private set; }

        public float X = 0;
        public float Y = 0;

        public Pen Pen = new Pen(Color.Black, 1);
        public bool PenDrawing = false;
        public Color PenColor
        {
            get
            {
                return this.Pen.Color;
            }
            set
            {
                this.Pen.Color = value;
            }
        }
        public float PenWidth
        {
            get
            {
                return this.Pen.Width;
            }
            set
            {
                this.Pen.Width = value;
            }
        }

        public int Sleep = 10;

        public bool Visible = true;

        public double Angle
        {
            get
            {
                return this._angle;
            }
            set
            {
                // cut off at 0 and 360 degrees, full circle
                double newAngle = value;

                while (newAngle < 0)
                {
                    newAngle += 360;
                }

                newAngle %= 360;
                
                _angle = newAngle;
            }
        }
        private double _angle = 0;

        public double Radians
        {
            get
            {
                return this.Angle * Math.PI / 180;
            }
            set
            {
                this.Angle = value * 180 / Math.PI;
            }
        }

        public double Degrees
        {
            get
            {
                return this.Angle;
            }
            set
            {
                this.Angle = value;
            }
        }

        public bool Fast = false;

        private Stack<TurtleCommand> turtleCommands = new Stack<TurtleCommand>();

        public Turtle(Screen screen)
        {
            this.Screen = screen;
        }

        public Turtle()
        {
            this.Screen = new Screen();
        }

        private void Execute(TurtleCommand command)
        {
            command.Do(this);
            this.turtleCommands.Push(command);
            this.Screen.Update(this);

            if (Fast) return;
            System.Threading.Thread.Sleep(Sleep);
        }

        public void Undo()
        {
            TurtleCommand command = this.turtleCommands.Pop();
            if (command == null) throw new Exception("No commands to undo");

            command.Undo(this);
            this.Screen.Update(this);
            System.Threading.Thread.Sleep(Sleep);
        }

        public void ForceUpdate()
        {
            this.Screen.Update(this);
        }

        public void Forward(float distance)
        {
            this.Execute(new TurtleMove(distance));
        }

        public void Backward(float distance)
        {
            this.Forward(-distance);
        }

        public void Left(double angle)
        {
            this.Execute(new TurtleRotate(angle));
        }

        public void Right(double angle)
        {
            this.Left(-angle);
        }

        public void Goto(float x, float y)
        {
            this.Execute(new TurtleTranslate(this, x, y));
        }
    }
}
