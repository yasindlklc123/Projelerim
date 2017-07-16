using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace okul_kayıtt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Boolean kullanici;
        public kayıtDataSet.kullanciRow r;
        Random rr = new Random();

        private void Form2_Load(object sender, EventArgs e)
        {
            label6.Text = rr.Next(0, 9999).ToString();
            textBox1.Focus();
            if (kullanici)
            {


                kay();



            }
            else
            {
                this.Close();
            }
        }
        public void kay()
        {

            r.kullanici_adi = textBox1.Text.ToLower();





            if (textBox2.Text == textBox3.Text && textBox2.Text.Length>7 && textBox3.Text.Length>7)
            {
                r.kullanici_sifre = textBox2.Text.ToLower();
            }



           


        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı Alanını Doldurunuz");

                }
                if (textBox4.Text != label6.Text)
                {
                    label6.Text = rr.Next(0, 9999).ToString();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                if (textBox1.Text != "" && textBox2.Text == textBox3.Text && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == label6.Text && textBox2.Text.Length > 7 && textBox3.Text.Length > 7)
                {
                    kay();

                    this.DialogResult = DialogResult.OK;
                }
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Şifreleriniz Uyuşmuyor Lütfen Kontrol Ediniz");
                    textBox2.Clear();
                    textBox3.Clear();
                    label6.Text = rr.Next(0, 9999).ToString();
                }
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Şifre Alanını Doldurunuz");
                    label6.Text = rr.Next(0, 9999).ToString();
                }
                if (textBox2.Text.Length < 7 || textBox3.Text.Length < 7)
                {
                    MessageBox.Show("Şifreniz minumum 8 karakter olmalıdır");
                    textBox2.Clear();
                    textBox3.Clear();
                    label6.Text = rr.Next(0, 9999).ToString();
                }
                MessageBox.Show("Kullanici Oluşturuldu");
            }
            catch(FormatException ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    button2_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
