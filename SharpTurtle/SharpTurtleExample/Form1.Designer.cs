namespace SharpTurtleExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.turtleViewer1 = new SharpTurtle.TurtleViewer();
            this.SuspendLayout();
            // 
            // turtleViewer1
            // 
            this.turtleViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turtleViewer1.Location = new System.Drawing.Point(0, 0);
            this.turtleViewer1.Name = "turtleViewer1";
            this.turtleViewer1.Screen = null;
            this.turtleViewer1.Size = new System.Drawing.Size(625, 619);
            this.turtleViewer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 619);
            this.Controls.Add(this.turtleViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpTurtle.TurtleViewer turtleViewer1;

    }
}

