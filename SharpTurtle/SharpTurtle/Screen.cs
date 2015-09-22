using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTurtle
{
    public class Screen
    {
        private Bitmap frame;
        private Bitmap final;

        private float lastX;
        private float lastY;

        public delegate void ScreenUpdateHandler(Bitmap bmp);
        public event ScreenUpdateHandler ScreenUpdate;

        public Screen()
        {
            frame = new Bitmap(256, 256);
        }

        public Screen(int x, int y)
        {
            frame = new Bitmap(x, y);

            using(Graphics g = Graphics.FromImage(frame))
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, frame.Width, frame.Height));
            }

            this.lastX = x / 2;
            this.lastY = y / 2;
        }

        public Bitmap GetLastFrame()
        {
            return this.final;
        }

        public void Update(Turtle t)
        {
            using (Graphics g = Graphics.FromImage(frame))
            {
                float newX = TurtleToScreenX(t.X);
                float newY = TurtleToScreenY(t.Y);

                if (t.PenDrawing)
                {
                    g.DrawLine(t.Pen, lastX, lastY, newX, newY);
                }

                lastX = newX;
                lastY = newY;
            }

            if(final != null) final.Dispose();
            final = (Bitmap)frame.Clone();
            if(t.Visible)
            {
                // TODO: Image of turtle
                /*using(Graphics g = Graphics.FromImage(overlay))
                {
                    g.DrawImage()
                }*/
            }

            if(ScreenUpdate != null && !t.Fast)
            {
                ScreenUpdate(final);
            }
        }

        private float TurtleToScreenX(float tX)
        {
            return tX + (frame.Width / 2);
        }

        private float TurtleToScreenY(float tY)
        {
            return -tY + (frame.Height / 2);
        }
    }
}
