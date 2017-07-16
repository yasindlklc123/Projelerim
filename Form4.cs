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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Boolean yenin;
        public kayıtDataSet.ogrenciRow satır;
        private void kayt()
        {
            textBox1.Text = satır.ogr_ad;
            textBox2.Text = satır.ogr_soyad;
            textBox3.Text = satır.anne_ad;
            textBox4.Text = satır.baba_ad;
            textBox6.Text = satır.dogum_yeri;
            comboBox1.Text = satır.medeni_hal;
            maskedTextBox1.Text = satır.dogum_tarihi.ToShortDateString();
            textBox9.Text = satır.tc;
            textBox10.Text = satır.kan_grubu;
            textBox11.Text = satır.nakilse_geldigi_üniversite;
            comboBox4.SelectedValue = satır.fakulte_id;
            comboBox6.SelectedValue = satır.bolum_id;
            comboBox8.SelectedValue = satır.dil_id;
            comboBox10.SelectedValue = satır.sekil_id;
            comboBox2.SelectedValue = satır.il_id;
            label8.Visible = false;
            label23.Visible = false;
        }

        public void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            maskedTextBox1.Clear();
            comboBox1.Text = "";
        }
        private void doldur()
        {
            try
            {
                int yas;
                int id = (int)comboBox6.SelectedValue;
                Random rr = new Random();
                int a = rr.Next(0, 99999);

                DateTime dogum = new DateTime();
                TimeSpan fark;

                dogum = DateTime.Parse(maskedTextBox1.Text); //convert ediliyor datetime oldugu için
                fark = DateTime.Now.Date.Subtract(dogum); //şimdiki zamandan dogum çıkarılıyor
                yas = Convert.ToInt32(fark.TotalDays);
                yas = yas / 365;

                string tarih = Convert.ToString(DateTime.Now.Year);
                string bolkod = Convert.ToString(comboBox6.SelectedValue);
                //kayıtDataSet.ogrenciRow satır = kayıtDataSet1.ogrenci.NewogrenciRow();
                satır.ogr_ad = textBox1.Text.ToLower();
                satır.ogr_soyad = textBox2.Text.ToLower();
                satır.anne_ad = textBox3.Text.ToLower();
                satır.baba_ad = textBox4.Text.ToLower();
                satır.medeni_hal = comboBox1.SelectedItem.ToString().ToLower();
                satır.dogum_yeri = textBox6.Text.ToLower();
                satır.dogum_tarihi = Convert.ToDateTime(maskedTextBox1.Text);
                satır.yas = yas;
                satır.tc = textBox9.Text;
                satır.kan_grubu = textBox10.Text.ToLower();
                satır.il_id = (int)comboBox2.SelectedValue;
                foreach (kayıtDataSet.bolumlerRow item in kayıtDataSet1.bolumler.Rows)
                {
                    if (item.bolum_id == id)
                    {
                        satır.fakulte_id = item.fakulte_id;
                    }
                }
                satır.bolum_id = id;
                satır.dil_id = (int)comboBox8.SelectedValue;
                satır.sekil_id = (int)comboBox10.SelectedValue;
                satır.nakilse_geldigi_üniversite = textBox11.Text;
                string posta = tarih + bolkod + a.ToString() + "@cumhuriyet.edu.tr";

                satır.e_posta = posta.ToLower();



                SqlConnection bag = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bag.Open();
                SqlCommand kmt = new SqlCommand("select kullanici_id from kullanci where kullanici_adi=@adi", bag);
                kmt.Parameters.AddWithValue("@adi", label8.Text);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    satır.kullanici_id = Convert.ToInt32(dr[0]);
                }

                bag.Close();

                temizle();
            }
            catch (FormatException ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet1.sekil' table. You can move, or remove it, as needed.
            this.sekilTableAdapter.Fill(this.kayıtDataSet1.sekil);
            // TODO: This line of code loads data into the 'kayıtDataSet1.diller' table. You can move, or remove it, as needed.
            this.dillerTableAdapter.Fill(this.kayıtDataSet1.diller);
            // TODO: This line of code loads data into the 'kayıtDataSet1.bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.kayıtDataSet1.bolumler);
            // TODO: This line of code loads data into the 'kayıtDataSet1.fakulte' table. You can move, or remove it, as needed.
            this.fakulteTableAdapter.Fill(this.kayıtDataSet1.fakulte);
            // TODO: This line of code loads data into the 'kayıtDataSet1.iller' table. You can move, or remove it, as needed.
            this.illerTableAdapter.Fill(this.kayıtDataSet1.iller);
            if (yenin)
            {
                temizle();
            }
            else
            {
                kayt();
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "DGS")
            {
                textBox11.Enabled = true;
            }
            else
            {
                textBox11.Enabled = false;
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                doldur();
                this.DialogResult = DialogResult.OK;
            }
            catch (FormatException ss)
            {

               // MessageBox.Show(ss.ToString()+"\n"+"Hataları İle Karşılaşıldı");
                MessageBox.Show(ss.Message.ToString());
            }
          
           
           
              //Form3 f = new Form3();
              //string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
              //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
              //bagla.Open();

              //SqlCommand komutt = new SqlCommand(sorgu, bagla);
              //SqlDataAdapter ap = new SqlDataAdapter(komutt);
              //DataTable dt = new DataTable();
              //ap.Fill(dt);
              //f.dataGridView1.DataSource = dt;

              //bagla.Close();
          
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;


        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //}
            Control fControl;
            if (e.KeyCode == Keys.Enter)
            {
                //fControl = GetNextControl(ActiveControl, !e.Shift);
               // if (fControl == null)
                   // fControl = GetNextControl(null, true);
                    fControl = GetNextControl(ActiveControl, true);
                    fControl.Focus();
                //e.SuppressKeyPress = true;
                   
            }
        }

   

     
       

       
    }
}
