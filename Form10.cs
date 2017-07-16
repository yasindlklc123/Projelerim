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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=1";
            //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
            //bagla.Open();
            //SqlCommand komutt = new SqlCommand(sorgu, bagla);
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //ds.Tables.Add(dt);
            //SqlDataAdapter adap = new SqlDataAdapter(komutt);
            //adap.Fill(dt);
            //dataGridView1.DataSource = dt;
            try
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                kayıtDataSet.bolumlerRow r = kayıtDataSet.bolumler.FindBybolum_id(id);
                r.bolum_ad = textBox1.Text.ToLower();
                comboBox1.SelectedValue = r.fakulte_id;
                r.fakulte_id = (int)comboBox1.SelectedValue;
                bolumlerTableAdapter.Update(r);
                MessageBox.Show(id.ToString()+ " " + "Numaralı Kayıt Düzenlendi");
                if (label1.Text == "Edebiyat Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=1";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (label1.Text == "İktisadi ve İdari Bilimler Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=2";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'kayıtDataSet.fakulte' table. You can move, or remove it, as needed.
                this.fakulteTableAdapter.Fill(this.kayıtDataSet.fakulte);
                // TODO: This line of code loads data into the 'kayıtDataSet.bolumler' table. You can move, or remove it, as needed.
                this.bolumlerTableAdapter.Fill(this.kayıtDataSet.bolumler);
                if (label1.Text == "Edebiyat Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=1";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (label1.Text == "İktisadi ve İdari Bilimler Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=2";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int a = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                kayıtDataSet.bolumlerRow r = kayıtDataSet.bolumler.FindBybolum_id(a);
                r.Delete();
                bolumlerTableAdapter.Update(r);
                if (label1.Text == "Edebiyat Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=1";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (label1.Text == "İktisadi ve İdari Bilimler Fakültesi Bölümlerini Düzenle")
                {
                    string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id where b.fakulte_id=2";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
