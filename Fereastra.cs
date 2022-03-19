using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Pong
{
    public class Fereastra : Form
    {
        private int x, y, z, w, ok = 0;
        private Random Rm;
        private Cronometru Tm, Tm2;
        private int vdir=1, speed=15, hdir=1;
        Rectangle Rectangle1;
        Rectangle Ellipse1;
        public Fereastra(String Text, int Sus, int Stanga, int Inaltime, int Latime, Color Culoare)
        {
            this.Text = Text;
            this.Top = Sus;
            this.Left = Stanga;
            this.Height = Inaltime;
            this.Width = Latime;
            this.BackColor = Culoare;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            Rm = new Random();
            //x = Rm.Next(1, 750);
            //y = Rm.Next(1, 500);
            x = 0;
            y = 0;
            z = this.Width / 2 - 80;
            w = this.Height - 63;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Paint += new PaintEventHandler(this.Deseneaza_Cerc);
            this.Paint += new PaintEventHandler(this.Deseneaza_Jucator);
            Tm = new Cronometru(true, 100);
            
            Tm2 = new Cronometru(true, 100);
            Tm.Tick += new EventHandler(this.Bataie_Ceas_vertical);
            //Tm2.Tick += new EventHandler(this.Bataie_Ceas_orizontal);
            this.KeyDown += new KeyEventHandler(this.Apasa_Tasta);

        }
        public void Deseneaza_Cerc(object sender, PaintEventArgs e)
        {
            Ellipse1 = new Rectangle(x, y, 20, 20);
            e.Graphics.FillEllipse(Brushes.BlueViolet, Ellipse1);
        }
        public void Deseneaza_Jucator(object sender, PaintEventArgs e)
        {
            Rectangle Rectangle1;
            Rectangle1 = new Rectangle(z, w, 100, 200);
            e.Graphics.DrawRectangle(Pens.BlueViolet, Rectangle1);
            e.Graphics.FillRectangle(Brushes.BlueViolet, Rectangle1);
        }
        public void Bataie_Ceas_vertical(object sender, EventArgs e)
        {
            if (Rectangle1.IntersectsWith(Ellipse1))
            {
                vdir = -1;
                ok = 1;
            }
                
            if (y < 0 && ok==0)
            {
                vdir = +1;
            }
            else
                if (y >= this.Height - 68)
            {
                vdir = -1;
            }
            y = y + speed * vdir;
            if (x <= 5)
            {
                hdir = +1;
            }
            else
                //if(x+20>=this.Width-29)                  y >= this.Height - 68 ||
                if (x + 20 >= this.Width - 29)
            {
                hdir = -1;
            }
            x = x + speed * hdir;
            ok = 0;
            Invalidate();
        }
        /*public void Bataie_Ceas_orizontal(object sender, EventArgs e)
        {
            if(x<=5)
            {
                hdir = +1;
            }
            else
                //if(x+20>=this.Width-29)                  y >= this.Height - 68 ||
                if (x + 20 >= this.Width - 29)
                {
                    hdir = -1;
                }
            x = x + speed * hdir;
            Invalidate();
        }*/
        public void Apasa_Tasta(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                z = z + 8;
                //sau this.ClientSize.Width, etc;
                if (z >= this.Width - 120)
                    z = this.Width - 120;
            }
            if (e.KeyData == Keys.Left)
            {
                z = z - 8;
                if (z - 20 <= 0)
                    z = 0;
            }
            /*if (e.KeyData == Keys.Up)
            {
                w -= 5;
                if (w <= 0)
                    w = 0;
            }
            if (e.KeyData == Keys.Down)
            {
                w += 5;
                if (w >= this.Height - 61)
                    w = this.Height - 61;
            }*/
        }
    }
}
