using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace okul_kayıtt
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet.iller' table. You can move, or remove it, as needed.
            this.illerTableAdapter.Fill(this.kayıtDataSet.iller);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    kayıtDataSet.illerRow il = kayıtDataSet.iller.NewillerRow();
                    il.il_ad = textBox1.Text.ToLower();
                    kayıtDataSet.iller.AddillerRow(il);
                    illerTableAdapter.Update(il);
                    textBox1.ResetText();
                }
              
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message.ToString());
            }
         
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int sayi = dataGridView1.SelectedRows.Count;
            
                
            //    for (int i = 0; i < sayi; i++)
            //    {
            //        int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //        kayıtDataSet.illerRow r = kayıtDataSet.iller.FindByil_id(id);
            //        r.Delete();
            //        illerTableAdapter.Update(r);
            //        MessageBox.Show(r.il_id.ToString()+" " +"Numaralı İl Silindi");
            //    }
            //int id2 = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //kayıtDataSet.illerRow rr = kayıtDataSet.iller.FindByil_id(id2);
            //rr.Delete();
            //illerTableAdapter.Update(rr);
            try
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    int id = (int)item.Cells[0].Value;
                    kayıtDataSet.illerRow r = kayıtDataSet.iller.FindByil_id(id);
                    r.Delete();
                    illerTableAdapter.Update(r);
                    MessageBox.Show(id.ToString()+" "+"Numaralı İl/İller Silindi");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label3.Text);
            kayıtDataSet.illerRow r = kayıtDataSet.iller.FindByil_id(id);
            r.il_ad = textBox2.Text.ToLower();
            illerTableAdapter.Update(r);
            textBox2.ResetText();
            label3.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox2.Text) && e.KeyCode == Keys.Enter)
                {
                    button3_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                textBox2.ResetText();
            }
        }

        private void Form16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button4_Click(sender, e);
            }
        }

    }
}
