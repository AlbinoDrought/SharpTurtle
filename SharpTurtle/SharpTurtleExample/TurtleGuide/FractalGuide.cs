using SharpTurtle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtleExample.Turtles
{
    public class FractalGuide
    {
        private Turtle t;

        private int currentR = 100;
        private int currentDir = 1;

        public FractalGuide(ref Turtle t)
        {
            this.t = t;
        }

        public void Guide()
        {
            t.Goto(-100, 100);
            t.PenWidth = 1;
            t.PenDrawing = true;
            t.Sleep = 1;

            for (int i = 0; i < 9; i++)
            {
                Fractal(100, 4);
                t.Right(40);
            }

            //t.Fast = true;
            //drawFractal(5, 90, 5, "FX", 'X', "X+YF+", 'Y', "-FX-Y");
            //drawFractal(1, 60, 5, "X++X++X", 'X', "FX-FX++XF-XF", ' ', "");
            //drawFractal(2, 45, 10, "F", 'F', "+F--F+", ' ', "");
            //t.Fast = false;
            //t.ForceUpdate();
        }

        //http://code.activestate.com/recipes/576982-dragon-fractal-curve/
        private void drawFractal(float length, double angle, int level, string initial_state, char target, string replacement, char target2, string replacement2)
        {
            string state = initial_state;

            for (int i = 0; i < level; i++)
            {
                string nextState = "";
                foreach (char c in state)
                {
                    if (c == target)
                        nextState += replacement;
                    if (c == target2)
                    {
                        nextState += replacement2;
                    }
                    else
                    {
                        nextState += c;
                    }
                }
                state = nextState;
            }

            foreach (char c in state)
            {
                NextColor();
                if (c == 'F')
                {
                    t.Forward(length);
                }
                else if (c == '+')
                {
                    t.Right(angle);
                }
                else if (c == '-')
                {
                    t.Left(angle);
                }
            }
        }

        private void Fractal(float length, int depth)
        {
            NextColor();

            if (depth <= 0)
            {
                t.Forward(length);
            }
            else
            {
                Fractal(length / 3, depth - 1);
                t.Right(60);
                Fractal(length / 3, depth - 1);
                t.Left(120);
                Fractal(length / 3, depth - 1);
                t.Right(60);
                Fractal(length / 3, depth - 1);
            }
        }

        private void NextColor()
        {
            currentR += currentDir;
            if (currentR >= 255 || currentR <= 100) currentDir = -currentDir;
            t.PenColor = Color.FromArgb(255, currentR, 0, 0);
        }
    }
}
