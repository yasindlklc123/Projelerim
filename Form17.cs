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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand kmt = new SqlCommand("select il_id,count(ogrenci_id) from ogrenci group by (il_id)", bagla);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {

                    string[] dizi = new string[2] { dr[0].ToString(), dr[1].ToString() };
                    //MessageBox.Show(dizi[0].ToString() + " " + "000");
                    //MessageBox.Show(dizi[1].ToString() + " " + "111");
                    //MessageBox.Show(dr[0].ToString()+" "+dr[1].ToString());
                    // textBox1.Text = dizi[0].ToString() + " " + "Numaralı İle Ait Öğrenci Sayısı : " + " " + dr[1].ToString();
                    textBox1.AppendText(dizi[0].ToString() + " " + "Numaralı İle Ait Öğrenci Sayısı : " + " " + dr[1].ToString() + Environment.NewLine);
                }
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                textBox1.ResetText();
            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            // TODO: This line of code loads data into the 'kayıtDataSet.iller' table. You can move, or remove it, as needed.
            this.illerTableAdapter.Fill(this.kayıtDataSet.iller);
            // TODO: This line of code loads data into the 'kayıtDataSet.ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.kayıtDataSet.ogrenci);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand kmt = new SqlCommand("select il_id,count(ogrenci_id) from ogrenci group by (il_id) HAVING il_id=@id", bagla);
                kmt.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {

                    string[] dizi = new string[2] { dr[0].ToString(), dr[1].ToString() };
                    //MessageBox.Show(dizi[0].ToString() + " " + "000");
                    //MessageBox.Show(dizi[1].ToString() + " " + "111");
                    //MessageBox.Show(dr[0].ToString()+" "+dr[1].ToString());
                    // textBox1.Text = dizi[0].ToString() + " " + "Numaralı İle Ait Öğrenci Sayısı : " + " " + dr[1].ToString();
                    textBox1.AppendText(dizi[0].ToString() + " " + "Numaralı İle Ait Öğrenci Sayısı : " + " " + dr[1].ToString() + Environment.NewLine);
                }
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                textBox1.ResetText();
            }
            textBox2.ResetText();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                illerBindingSource.Filter = "il_ad like'" + textBox3.Text.ToLower() + "%'";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
