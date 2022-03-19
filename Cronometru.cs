using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Pong
{
    public class Cronometru : Timer
    {
        public Cronometru(bool Stare, int Timp)
        {
            this.Enabled = Stare;
            this.Interval = Timp;
        }
    }
}
