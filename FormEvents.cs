using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormMouseEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X + "/" + e.Y);//Form üzerinde tıklanan yerin x ve y kordinatlarını  verir
            MessageBox.Show(e.Button.ToString());//formma maousun hangi tuşu ile tıklandıgının bilgisini verir
            MessageBox.Show(e.Location.ToString());//formun x ve y noktasının bilgisini verir

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + " " + e.Y;//formda fareyi gezdirdigimiz yerin x y bilgisini verir
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Fare Basılı tutuluyor");//farenin basılı tutulması 
        }

      

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
           Text=this.Location.ToString();//Farenin formun üzerinde oldugu anda devreye girer
        }

      

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
         //   MessageBox.Show("Fare formdan ayrıldı");//farenin formdan ayrılma olayı
        }

        

        private void Form1_Move(object sender, EventArgs e)
        {
           Text=this.Location.ToString();//Formun taşınması olayı
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Formu Kapatmak İstiyor musunuz?", "Form Kapanma Olayı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;

            }
            else
            {
                e.Cancel = true;
            }
           
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Renk Değişti");//formun arkaplan renginin değişmesi olayının bilgisini verir
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            openFileDialog1.ShowDialog();
            BackgroundImage =Image.FromFile(openFileDialog1.FileName);
           
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forma Tıklandı");//formun tıklanma olayı
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Form Kapanınca Verilen Mesaj");//form kapanınca verilen bilgi
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Formun Boyutları Değişti");//formun boyutunu değiştirilmesinin bilgisini tutar
        }

        private void Form1_BackgroundImageChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Arka plan resmi değişti");//arkaplan resminin değişiğ değişmediginin bilgisini tutarw
        }

    
       
     


   


    



    }
}
