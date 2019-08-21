using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = (CheckBox)sender;
            if (checkBox1.Checked == true)
            {
                Sounds.SoundOn();
                
            }
            else if(checkBox1.Checked == false)
            {
                Sounds.SoundOff();
                Sounds.Stop();
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShopForm shop = new ShopForm();
            shop.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HowForm howform = new HowForm();
            howform.Show();
        }
    }
}
