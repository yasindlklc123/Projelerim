using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;

namespace okul_kayıtt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int say = 0;
        Random xr = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox5.Hide();
            label12.Hide();
            button1.Hide();
            checkBox1.Hide();
            label13.Hide();
            label14.Hide();
            textBox4.Hide();
            button4.Hide();
            textBox3.Hide();
            label15.Hide();
           
            linkLabel1.Hide();
            label7.Text = DateTime.Now.Hour.ToString();
            label8.Text = DateTime.Now.Minute.ToString();
            label9.Text = DateTime.Now.Second.ToString();
            label5.Text = DateTime.Now.ToLongDateString();
            timer1.Enabled = true;
           
            






            
            // TODO: This line of code loads data into the 'kayıtDataSet.ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.kayıtDataSet.ogrenci);
         

        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (label1.Left < 400)
            {
                label1.Left = label1.Left + 5;
            }
            else
            {
                label1.Left = -5;
            }
            label7.Text = DateTime.Now.Hour.ToString();
            label8.Text = DateTime.Now.Minute.ToString();
            label9.Text = DateTime.Now.Second.ToString();
            //this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Focus();

                SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from kullanci where kullanici_adi=@ad  AND kullanici_sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox1.Text.ToLower());
                komut.Parameters.AddWithValue("@sifre", textBox2.Text.ToLower());
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    Form3 giris = new Form3();

                    giris.Show();
                    giris.WindowState = FormWindowState.Maximized;

                    giris.label1.Text = textBox1.Text;
                    giris.label1.Hide();


                    //string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    // bagla.Open();
                    //SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    //SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    // DataTable dt = new DataTable();
                    // ap.Fill(dt);
                    // giris.dataGridView1.DataSource = dt;

                    //bagla.Close();

                    string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    SqlDataAdapter adap = new SqlDataAdapter(komutt);
                    adap.Fill(dt);
                    giris.dataGridView1.DataSource = dt;

                    this.Hide();
                }
                else
                {
                    say++;
                    MessageBox.Show("Kullanıcı Adı Veya Parola Yanlış Tekrar Deneyiniz");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
                if (say == 3)
                {

                    linkLabel1.Visible = true;
                    checkBox1.Checked = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox2.Hide();
            linkLabel2.Hide();
            button3.Hide();
            button2.Hide();
           label14.Text = xr.Next(0, 9999).ToString();
            label2.Hide();
            textBox1.Hide();
            button4.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label12.Visible = true;
            button1.Visible = true;
            checkBox1.Visible = true;
            label15.Visible = true;
            textBox3.Visible = true;


            label3.Hide();
            linkLabel1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            checkBox1.Hide();
            label13.Hide();
            label14.Hide();
            label12.Hide();
            button1.Hide();
            button4.Hide();
            textBox5.Hide();
            textBox4.Hide();
            label15.Hide();
            textBox3.Hide();
            textBox2.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                baglantı.Open();
                SqlCommand cmd = new SqlCommand("select kullanici_adi,kullanici_sifre from kullanci where kullanici_adi=@ad", baglantı);
                cmd.Parameters.AddWithValue("@ad", textBox3.Text.ToLower());
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // if ( textBox3.Text.ToUpper()) 
                    if (checkBox1.Checked == true && textBox4.Text == label14.Text)
                    {
                        if (textBox5.Text != "")
                        {
                            MailMessage mesaj = new MailMessage();
                            SmtpClient sunucu = new SmtpClient();
                            sunucu.Credentials = new System.Net.NetworkCredential("ysndlklc66@hotmail.com", "Baskan0293");
                            sunucu.Port = 587;
                            sunucu.Host = "smtp.live.com";
                            sunucu.EnableSsl = true;
                            mesaj.To.Add(textBox5.Text);
                            mesaj.From = new MailAddress("ysndlklc66@hotmail.com");
                            mesaj.Subject = "KULLANICI ADI VE ŞİFRE BİLGİSİ";
                            mesaj.Body = "KULLANICI ADINIZ :" + dr[0].ToString() + "" + "\n" + "" + "ŞİFRENİZ :" + "" + dr[1].ToString();
                            sunucu.Send(mesaj);
                            MessageBox.Show("Mesaj Başarıyla Gönderildi");
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox3.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Lütfen Alıcı Kişiye Ait E-Posta Adresini Giriniz");
                        }


                    }
                    else
                    {
                        label14.Text = xr.Next(0, 9999).ToString();
                        MessageBox.Show("Lütfen E-Posta İle Gönder Seçeneğini Seçtikten Sonra Güvenlik Kodunu Giriniz");
                    }

                }
                baglantı.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form2 kullanici = new Form2();
                kullanici.kullanici = true;
                kullanici.r = kayıtDataSet.kullanci.NewkullanciRow();


                if (kullanici.ShowDialog() == DialogResult.OK)
                {
                    kayıtDataSet.kullanci.AddkullanciRow(kullanici.r);
                    kullanciTableAdapter1.Update(kullanici.r);

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text !="" || textBox2.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button2_Click(sender, e);
                }
            }
            else
            {

            }
        }

    


      
        //private void button1_Click(object sender, EventArgs e)
        //{


      
	

        //    string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
        //    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
        //    bagla.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, bagla);
        //    SqlDataAdapter ap = new SqlDataAdapter(komut);
        //    DataTable dt = new DataTable();
        //    ap.Fill(dt);
        //    dataGridView1.DataSource = dt;
          
        //    bagla.Close();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    kayıtDataSet.ogrenciRow r = kayıtDataSet.ogrenci.NewogrenciRow();
        //    r.ogr_ad = "melisa";
        //    r.ogr_soyad = "uslu";
        //    r.medeni_hal = "bekar";
        //    r.anne_ad = "deniz";
        //    r.baba_ad = "burak";
        //    r.tc = "11887272220";
        //    r.dogum_yeri = "edirne";
        //    r.dogum_tarihi = Convert.ToDateTime("22.02.1995");
        //    r.yas = 22;
        //    r.kan_grubu = "0 rh(-)";
        //    r.il_id = 3;
        //    r.fakulte_id = 2;
        //    r.bolum_id = 4;
        //    r.dil_id = 2;
        //    r.sekil_id = 1;
        //    r.kullanici_id = 1;
        //    r.e_posta = "201724@cumhuriyet.edu.tr";
        //    kayıtDataSet.ogrenci.AddogrenciRow(r);
        //    ogrenciTableAdapter.Update(r);
        //    MessageBox.Show("Test");

        //}
      
    }
}
