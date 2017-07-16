using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace okul_kayıtt
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'kayıtDataSet.kullanci' table. You can move, or remove it, as needed.
            this.kullanciTableAdapter.Fill(this.kayıtDataSet.kullanci);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                kayıtDataSet.kullanciRow r = kayıtDataSet.kullanci.FindBykullanici_id(id);
                r.Delete();
                kullanciTableAdapter.Update(r);
                MessageBox.Show(id.ToString()+" " +"Numaralı kullanıcı Silindi");
                label2.ResetText();
                textBox1.ResetText();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            try
            {
                string sorgu = "select kullanici_id,kullanici_adi from kullanci ";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                dataGridView1.DataSource = dt;

                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label2.Text);
            kayıtDataSet.kullanciRow r = kayıtDataSet.kullanci.FindBykullanici_id(id);
            r.kullanici_adi = textBox1.Text.ToLower();
            kullanciTableAdapter.Update(r);
            try
            {
                string sorgu = "select kullanici_id,kullanici_adi from kullanci ";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                dataGridView1.DataSource = dt;

                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            textBox1.ResetText();
            label2.ResetText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text) && e.KeyCode == Keys.Enter)
                {
                    button2_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

   
    }
}
