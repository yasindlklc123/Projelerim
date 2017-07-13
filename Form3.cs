using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace projee
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        
        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

    }
}
