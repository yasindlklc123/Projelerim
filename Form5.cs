using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
namespace okul_kayıtt
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient sunucu = new SmtpClient();
                    sunucu.Credentials = new System.Net.NetworkCredential("postaadresi@hotmail.com", "gerceksifren");
                    sunucu.Port = 587;
                    sunucu.Host = "smtp.live.com";
                    sunucu.EnableSsl = true;
                    mesaj.To.Add(textBox1.Text);
                    mesaj.From = new MailAddress("postaadresi@hotmail.com");
                    mesaj.Subject = textBox2.Text;
                    mesaj.Body = richTextBox1.Text;
                    sunucu.Send(mesaj);
                    MessageBox.Show("Mesaj Başarıyla Gönderildi");
                    textBox1.Clear();
                    textBox2.Clear();
                    richTextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Lütfen Alıcı Kişiye Ait E-Posta Adresini Giriniz");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            Control alt;
            if (e.KeyCode == Keys.Enter)
            {
                alt = GetNextControl(ActiveControl, true);
                alt.Focus();
            }
        }
    }
}
