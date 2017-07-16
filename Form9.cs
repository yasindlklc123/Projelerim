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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet.bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.kayıtDataSet.bolumler);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kayıtDataSet.bolumlerRow r = kayıtDataSet.bolumler.NewbolumlerRow();
                if (label1.Text == "İdari ve İktisadi Bilimler Fakültesine Ekle")
                {
                    r.fakulte_id = 2;
                    r.bolum_ad = textBox1.Text.ToLower();
                    kayıtDataSet.bolumler.AddbolumlerRow(r);
                    bolumlerTableAdapter.Update(r);
                    MessageBox.Show("İktisadi ve İdari Bilimler Fakültesine " + " " +textBox1.Text + " " + "Bölümü Eklendi");
                    Form8 frm = new Form8();

                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    frm.dataGridView1.DataSource = dt;
                    frm.ShowDialog();
                    textBox1.Text = "";
                    this.Hide();
                }
                else if (label1.Text == "Edebiyat Fakültesine Ekle")
                {
                    r.fakulte_id = 1;
                    r.bolum_ad = textBox1.Text.ToLower();
                    kayıtDataSet.bolumler.AddbolumlerRow(r);
                    bolumlerTableAdapter.Update(r);
                    MessageBox.Show("Edebiyat Fakültesine"+" " + textBox1.Text + " " + "Bölümü Eklendi");
                    Form8 frm = new Form8();

                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    frm.dataGridView1.DataSource = dt;
                    frm.ShowDialog();
                    textBox1.Clear();
                    this.Hide();
                }
            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message.ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
