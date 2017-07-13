using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackBar_Kullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayı = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(trackBar1.Value.ToString());
            trackBar1.Maximum = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 1000;
            trackBar1.LargeChange = 10000;
            timer1.Enabled = true;
            label1.Text = sayı.ToString();
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayı++;
            label1.Text = sayı.ToString();
        }
    }
}
