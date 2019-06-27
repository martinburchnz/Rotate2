using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RotateObject
{
    public partial class Form1 : Form
    {
        Graphics g; //declare a graphics object called g so we can draw on the Form
        Spaceship spaceship = new Spaceship(); //create an instance of the Spaceship Class called spaceship
        bool turnLeft, turnRight;
        List<Missile> missiles = new List<Missile>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the Form control
            g = e.Graphics;
            //Draw the spaceship
            spaceship.drawSpaceship(g);
            //draw and move the missiles
            foreach (Missile m in missiles)
            {
                m.drawMissile(g);
                m.moveMissile(g);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            spaceship.moveSpaceship(e.X, e.Y);
        }

        private void tmrSpaceship_Tick(object sender, EventArgs e)
        {
            if (turnRight)
            { 
                spaceship.rotationAngle += 5;
            }
            if (turnLeft)
            {
                spaceship.rotationAngle -= 5;
            }
          
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = true; }
            if (e.KeyData == Keys.Right) { turnRight = true; }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                missiles.Add(new Missile(spaceship.spaceRec, spaceship.rotationAngle));
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = false; }
            if (e.KeyData == Keys.Right) { turnRight = false; }
        }
    }
}
