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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        Random r = new Random();
        private void Form21_Load(object sender, EventArgs e)
        {
            label6.Text = r.Next(0, 9999).ToString();
            // TODO: This line of code loads data into the 'kayıtDataSet.kullanci' table. You can move, or remove it, as needed.
            this.kullanciTableAdapter.Fill(this.kayıtDataSet.kullanci);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
                {
                    label6.Text = r.Next(0, 9999).ToString();
                    MessageBox.Show("Şifre Alanları Boş Geçilemez");
                   
                }
                else if (textBox3.Text.ToLower() != textBox4.Text.ToLower())
                {
                    label6.Text = r.Next(0, 9999).ToString();
                    MessageBox.Show("Şifreler Uyuşmuyor");
                    
                }
                else if (String.IsNullOrEmpty(textBox1.Text))
                {
                    label6.Text = r.Next(0, 9999).ToString();
                    MessageBox.Show("Lütfen Kullanıcı Adı Alanını Doldurunuz");
                   
                }
                else if (textBox5.Text != label6.Text)
                {
                    label6.Text = r.Next(0, 9999).ToString();
                    MessageBox.Show("Güvenlik Kodu Hatalı Tekrar Deneyiniz");
                  
                }
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                //bagla.Open();
                else 
                {
                    foreach (kayıtDataSet.kullanciRow item in kayıtDataSet.kullanci.Rows)
                    {
                        if (item.kullanici_adi == textBox1.Text.ToLower() && item.kullanici_sifre == textBox2.Text.ToLower())
                        {
                            if (!String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && textBox3.Text.ToLower() == textBox4.Text.ToLower() && textBox5.Text == label6.Text)
                            {
                                item.kullanici_sifre = textBox3.Text.ToLower();
                                kullanciTableAdapter.Update(item);
                            }
                            MessageBox.Show("Şifreniz Başarı İle Değiştirildi");
                        }
                    }
                    
                  

                }
              
                textBox5.ResetText();
                textBox4.ResetText();
                textBox3.ResetText();
                textBox2.ResetText();
                textBox1.ResetText();
               // label6.ResetText();
            }
            catch (Exception ee)
            {
                textBox1.ResetText();
                textBox2.ResetText();
                textBox3.ResetText();
                textBox4.ResetText();
                textBox5.ResetText();
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
