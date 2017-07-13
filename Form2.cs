using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projee
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Boolean ekle;
        public randevuDataSet.suclularRow r;
        private void bos()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is ComboBox)
                {
                    item.Text = "";
                }
              
            }
          
        }
        private void dolu()
        {
            textBox1.Text = r.suclu_ad;
            textBox2.Text = r.suclu_soyad;
            textBox3.Text = r.suclu_tc;
         
          maskedTextBox1.Text = r.suclu_d_tarihi.ToShortDateString();
            textBox6.Text = r.kan_grubu;
            textBox7.Text = r.giris_tarih.ToShortDateString();
            comboBox1.Text = r.suc_ad;
            comboBox9.Text = r.suc_id.ToString();
            comboBox2.Text = r.ceza_id.ToString();
            comboBox3.Text=r.ceza_yil.ToString();
            comboBox4.Text = r.saglik_durum_aciklama;
            comboBox8.Text = r.saglik_durum_aciklama_id.ToString();
            comboBox5.Text = r.saglik_sorun_durum;
            comboBox10.Text = r.saglik_sorun_id.ToString();
            comboBox6.Text = r.durum;
            comboBox7.Text = r.durum_id.ToString();

        }
        private void kayt()
        {
            DateTime cikistarih = DateTime.Now.AddYears(+(int)comboBox3.SelectedValue);
          
            r.suclu_ad = textBox1.Text.ToUpper();
            r.suclu_soyad = textBox2.Text.ToUpper();
            r.suclu_tc = textBox3.Text.ToUpper();
            r.suclu_cinsiyet = "E";
            r.suclu_d_tarihi = Convert.ToDateTime(maskedTextBox1.Text);
            r.kan_grubu = textBox6.Text.ToUpper();
            r.giris_tarih = Convert.ToDateTime(textBox7.Text);
            r.cikis_tarih = cikistarih;
            r.suc_id = (int)comboBox9.SelectedValue;
            r.suc_ad = comboBox1.SelectedValue.ToString().ToUpper();
            r.ceza_id = (int)comboBox2.SelectedValue;
            r.ceza_yil = (int)comboBox3.SelectedValue;
            r.saglik_sorun_id = (int)comboBox10.SelectedValue;
            r.saglik_sorun_durum = comboBox5.SelectedValue.ToString().ToUpper();
            if (r.saglik_sorun_durum == "VAR")
            {
                r.saglik_durum_aciklama_id = (int)comboBox8.SelectedValue;
                r.saglik_durum_aciklama = comboBox4.SelectedValue.ToString().ToUpper();
            }
            else
            {
           
                r.saglik_durum_aciklama = "HASTALIK YOKTUR";
            }
            r.durum_id = (int)comboBox7.SelectedValue;
            r.durum = comboBox6.SelectedValue.ToString();
           
           
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox3.MaxLength = 11;
            textBox4.Enabled = false;
            // TODO: This line of code loads data into the 'randevuDataSet.durum' table. You can move, or remove it, as needed.
            this.durumTableAdapter.Fill(this.randevuDataSet.durum);
            // TODO: This line of code loads data into the 'randevuDataSet.saglik_sorun' table. You can move, or remove it, as needed.
            this.saglik_sorunTableAdapter.Fill(this.randevuDataSet.saglik_sorun);
            // TODO: This line of code loads data into the 'randevuDataSet.saglik_durum_aciklama' table. You can move, or remove it, as needed.
            this.saglik_durum_aciklamaTableAdapter.Fill(this.randevuDataSet.saglik_durum_aciklama);
            // TODO: This line of code loads data into the 'randevuDataSet.suclar' table. You can move, or remove it, as needed.
            this.suclarTableAdapter.Fill(this.randevuDataSet.suclar);
            if (ekle)
            {
                bos();
                textBox7.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                dolu();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayt();
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = DateTime.Now.ToShortDateString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime cikistarih = DateTime.Now.AddYears(+(int)comboBox3.SelectedValue);
            textBox4.Text = cikistarih.ToShortDateString();
            if (textBox7.Text != textBox4.Text)
            {
                comboBox6.Text = "AKTİF";
                comboBox7.Text = "1";
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "YOK")
            {
                comboBox4.Enabled = false;
                comboBox8.Enabled = false;
            }
            else
            {
                comboBox8.Enabled = true;
                comboBox4.Enabled = true;
            }
        }
    }
}
