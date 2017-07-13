using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListboxSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && checkBox1.Checked == true)
            {
                if (!listBox1.Items.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                }
            }
            if (e.KeyCode == Keys.Enter && e.Control && checkBox2.Checked == true)
            {
                if (!listBox2.Items.Contains(textBox1.Text))
                {
                    listBox2.Items.Add(textBox1.Text);
                    textBox1.Clear();
                }
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true && e.KeyCode==Keys.Down)
            {
             
                listBox1.Items.Add(textBox1.Text.ToUpper());
                listBox2.Items.Add(textBox1.Text.Substring(0,1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                if (!listBox2.Items.Contains(item))
                {
                    listBox2.Items.Add(item);
                }
            }
        }

    
    }
}
