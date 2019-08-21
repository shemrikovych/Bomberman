using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Form1.im = Properties.Resources.Right1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Form1.im = Properties.Resources.Right2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.sound = new SoundPlayer("game.wav");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.sound = new SoundPlayer("game1.wav");
        }
    }
}
