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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems[0].Text == "1")
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komut = new SqlCommand("select fakulte_id,count(bolum_id) from bolumler group by(fakulte_id) HAVING fakulte_id = 1 ", bagla);
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        //MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString());
                        label1.Text = dr[0].ToString() + " " + "Numaralı Fakülteye Ait " + " " + dr[1].ToString() + " " + "Bölüm Bulunmaktadır. "+"\n" + "Bölüm Adları :  "+"\n"+"Bölümlere Ait Öğrenci Sayıları Sırasıyla Aşşagıdaki Gibidir";
                    }
                    bagla.Close();
                    foreach (kayıtDataSet.bolumlerRow item in kayıtDataSet.bolumler.Rows)
                    {
                        if (item.fakulte_id == int.Parse(listView1.SelectedItems[0].Text))
                        {
                            //MessageBox.Show(item.bolum_ad.ToString());
                            label1.Text = label1.Text + "\n" + item.bolum_ad.ToString().ToUpper();
                        }
                    }
                    try
                    {

                        //MessageBox.Show(a.ToString());
                        SqlConnection baglam = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                        baglam.Open();
                        SqlCommand komt = new SqlCommand("select bolum_id,fakulte_id,count(ogrenci_id) from ogrenci group by bolum_id,fakulte_id HAVING fakulte_id=1;", baglam);

                        SqlDataReader ddr = komt.ExecuteReader();
                        while (ddr.Read())
                        {
                            //label2.Text = "Bölüm Numarası " + " " + ddr[0].ToString() + " " + "olan bölümden " + " " + ddr[1].ToString() + " " + "adet öğrenci var";
                           // MessageBox.Show(ddr[2].ToString());
                            //label2.Text = label2.Text + ddr[2].ToString();
                            label1.Text = label1.Text + "\n"+ ddr[2].ToString();

                        }
                        baglam.Close();

                        //label2.Visible = true;


                    }
                    catch (FormatException aa)
                    {
                        MessageBox.Show(aa.Message.ToString());
                    }


                }
                else if (listView1.SelectedItems[0].Text == "2")
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komut = new SqlCommand("select fakulte_id,count(bolum_id) from bolumler group by(fakulte_id) HAVING fakulte_id = 2 ", bagla);
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        //MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString());
                        label1.Text = dr[0].ToString() + " " + "Numaralı Fakülteye Ait " + " " + dr[1].ToString() + " " + "Bölüm Bulunmaktadır." + "\n" + "Bölüm Adları :  ";
                    }
                    bagla.Close();
                    foreach (kayıtDataSet.bolumlerRow item in kayıtDataSet.bolumler.Rows)
                    {
                        if (item.fakulte_id == int.Parse(listView1.SelectedItems[0].Text))
                        {
                            //MessageBox.Show(item.bolum_ad.ToString());
                            label1.Text = label1.Text + "\n" + item.bolum_ad.ToString().ToUpper();
                        }
                    }
                    try
                    {

                        //MessageBox.Show(a.ToString());
                        SqlConnection baglam = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                        baglam.Open();
                        SqlCommand komt = new SqlCommand("select bolum_id,fakulte_id,count(ogrenci_id) from ogrenci group by bolum_id,fakulte_id HAVING fakulte_id=2;", baglam);

                        SqlDataReader ddr = komt.ExecuteReader();
                        while (ddr.Read())
                        {
                            //label2.Text = "Bölüm Numarası " + " " + ddr[0].ToString() + " " + "olan bölümden " + " " + ddr[1].ToString() + " " + "adet öğrenci var";
                            // MessageBox.Show(ddr[2].ToString());
                            //label2.Text = label2.Text + ddr[2].ToString();
                            label1.Text = label1.Text + "\n" + ddr[2].ToString();

                        }
                        baglam.Close();

                        //label2.Visible = true;


                    }
                    catch (FormatException aa)
                    {
                        MessageBox.Show(aa.Message.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }



        private void Form14_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet.bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.kayıtDataSet.bolumler);
            // TODO: This line of code loads data into the 'kayıtDataSet.fakulte' table. You can move, or remove it, as needed.
            this.fakulteTableAdapter.Fill(this.kayıtDataSet.fakulte);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // int a = 3;


           
            }

        }
    }

    

