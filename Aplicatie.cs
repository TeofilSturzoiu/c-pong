using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Pong
{
    public class Aplicatie
    {
        public static void Main()
        {
            Fereastra F = new Fereastra("Patratel", 10, 10, 600, 800, Color.AntiqueWhite);
            Application.Run(F);
        }
    }
}