using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpTurtle
{
    public partial class TurtleViewer : UserControl
    {
        private Bitmap bmp;

        public Screen Screen
        {
            get
            {
                return this._screen;
            }

            set
            {
                // remove old event handler
                if (this._screen != null) this._screen.ScreenUpdate -= this.ScreenUpdate;

                this._screen = value;
                if(this._screen != null) this._screen.ScreenUpdate += this.ScreenUpdate;
            }
        }
        private Screen _screen;

        public TurtleViewer()
        {
            InitializeComponent();

            this.Screen = new Screen();
            this.DoubleBuffered = true;
        }

        public void ScreenUpdate(Bitmap bmp)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { ScreenUpdate(bmp); }));
                return;
            }

            this.bmp = bmp;
            //this.Invalidate();
            this.Refresh();
        }

        private void pbScreen_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null) return;
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void pbScreen_Click(object sender, EventArgs e)
        {

        }
    }
}
