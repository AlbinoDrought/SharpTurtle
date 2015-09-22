using SharpTurtle;
using SharpTurtleExample.Turtles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpTurtleExample
{
    public partial class Form1 : Form
    {
        Thread turtleThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            turtleThread = new Thread(TurtleActions);
            turtleThread.Start();
        }

        private void TurtleActions()
        {
            Turtle t = new Turtle(new SharpTurtle.Screen(turtleViewer1.Size.Width, turtleViewer1.Size.Height));
            turtleViewer1.Screen = t.Screen;

            FractalGuide fg = new FractalGuide(ref t);
            fg.Guide();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turtleThread.Abort();
        }
    }
}
