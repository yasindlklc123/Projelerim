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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet.bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.kayıtDataSet.bolumler);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
            //bagla.Open();
            //SqlCommand komut = new SqlCommand("select fakulte_id,count(bolum_id) from bolumler group by(fakulte_id) HAVING fakulte_id = 1 ", bagla);
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    MessageBox.Show(dr[0].ToString()+" " +dr[1].ToString());
            //}
            //bagla.Close();
            if (textBox1.Text != "")
            {
                try
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komt = new SqlCommand("select bolum_id,count(ogrenci_id) from ogrenci group by(bolum_id) HAVING bolum_id=@id  ", bagla);
                    komt.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    SqlDataReader ddr = komt.ExecuteReader();
                    while (ddr.Read())
                    {
                        label2.Text = "Bölüm Numarası " + " " + ddr[0].ToString() + " " + "olan bölümden " + " " + ddr[1].ToString() + " " + "adet öğrenci var";
                        //MessageBox.Show(ddr[0].ToString()+""+ddr[1].ToString());

                    }
                    bagla.Close();
                    label3.Visible = true;
                    label2.Visible = true;
                    textBox1.ResetText();
                }
                catch (FormatException aa)
                {
                    MessageBox.Show(aa.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Lütfen Değer Girinz","Değer Girilmedi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bolumlerBindingSource.Filter = "bolum_ad like'" + textBox2.Text.ToLower()+"%'"; 
        }
        //    bagla.Open();
        //    komt.CommandText="select bolum_id,count(ogrenci_id) from ogrenci group by(bolum_id) HAVING bolum_id=2  ";
        //    komt.Connection = bagla;
        //    ddr = komt.ExecuteReader();
        //    while (ddr.Read())
        //    {
        //         label3.Text = "Bölüm Numarası " + "" + ddr[0].ToString() + "olan bölümden "+" "+ddr[1].ToString()+" " + "öğrenci var" ;
        //    }
        //}
        }
    }

