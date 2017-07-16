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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Dogum Tarihi Aralıgına Göre Daralt")
                {
                    label1.Text = dateTimePicker1.Value.ToShortDateString();
                    label2.Text = dateTimePicker2.Value.ToShortDateString();
                    string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id where dogum_tarihi>@a AND dogum_tarihi<@b";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    komutt.Parameters.AddWithValue("@a", Convert.ToDateTime(label1.Text));
                    komutt.Parameters.AddWithValue("@b", Convert.ToDateTime(label2.Text));
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    dataGridView1.DataSource = dt;

                    bagla.Close();
                }
                label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                label8.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
          
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Dogum Tarihi Aralıgına Göre Daralt")
                {
                    label3.Visible = true;
                    label4.Visible = true;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    textBox1.Hide();
                    label6.Hide();
                    dataGridView2.Hide();
                    dataGridView1.Visible = true;

                }
                else
                {
                    label6.Text = "Daraltmak İstediginiz Seçenege Uygun Kaydı Giriniz";
                    textBox1.Visible = true;
                    label3.Hide();
                    label4.Hide();
                    dateTimePicker2.Hide();
                    dateTimePicker1.Hide();
                    label6.Visible = true;
                    dataGridView1.Hide();
                    dataGridView2.Visible = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.ogrenciTableAdapter.Fill(this.kayıtDataSet.ogrenci);
            dataGridView2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Öğrenci Adına Göre Daralt")
                {
                    ogrenciBindingSource2.Filter = "ogr_ad like '" + textBox1.Text + "%'";
                    label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                    label8.Text = dataGridView2.Rows.Count.ToString();
                }
                else if (comboBox1.SelectedItem.ToString() == "Tc Kimlik No Göre Daralt")
                {
                    ogrenciBindingSource2.Filter = "tc like '" + textBox1.Text + "%'";
                    label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                    label8.Text = dataGridView2.Rows.Count.ToString();
                }
                else if (comboBox1.SelectedItem.ToString() == "Kan Grubuna Göre Daralt")
                {
                    ogrenciBindingSource2.Filter = "kan_grubu like'" + textBox1.Text + "%'";
                    label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                    label8.Text = dataGridView2.Rows.Count.ToString();
                }
                else if (comboBox1.SelectedItem.ToString() == "Medeni Hale Göre Daralt")
                {
                    ogrenciBindingSource2.Filter = "medeni_hal like '" + textBox1.Text.ToLower() + "%'";
                    label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                    label8.Text = dataGridView2.Rows.Count.ToString();
                }
                else if (comboBox1.SelectedItem.ToString() == "Dogum Yerine Göre Daralt")
                {
                    ogrenciBindingSource2.Filter = "dogum_yeri like '" + textBox1.Text.ToLower() + "%'";
                    label7.Text = comboBox1.SelectedItem.ToString() + " " + "Kaydına Uyan Kişi Sayısı :";
                    label8.Text = dataGridView2.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }

        }
    }
}



/*İle Göre Daralt
Dogum Tarihi Aralıgına Göre Daralt
Öğrenci Adına Göre Daralt
Kan Grubuna Göre Daralt
Tc Kimlik No Göre Daralt*/