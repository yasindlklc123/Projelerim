using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int islem = 0;
        double sayi1 = 0, sayi2 = 0;
        //double fakte;
        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text != "0")
            {
                label2.Text = label2.Text + (sender as Button).Text;
            }
           // label2.Text = label2.Text + (sender as Button).Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Width = 295;
            this.Height = 325;
            label2.Width = 279;
            label2.Height = 29;
            label2.Focus(); 
         
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
            try
            {
                islem = 1;
                //sayi1 = Convert.ToDouble(textBox1.Text);
                sayi1 = double.Parse(label2.Text);
                sil();

            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
              
            }
        }
        private void button13_Click_1(object sender, EventArgs e)
        {
          
            try
            {
                islem = 2;
                sayi1 = Convert.ToDouble(label2.Text);
                sil();

            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
        }
        public void sil()
        {
            label2.ResetText();
            if (islem == 1)
            {
                label1.Text = sayi1.ToString() + " " + " + ";
                label1.Visible = true;
            }
            else if (islem == 2)
            {
                label1.Text = sayi1.ToString() + " " + " - ";
                label1.Visible = true;
            }
            else if (islem == 3)
            {
                label1.Text = sayi1.ToString() + " " + " * ";
                label1.Visible = true;
            }
            else if (islem == 4)
            {
                label1.Text = sayi1.ToString() + " " + " / ";
                label1.Visible = true;
            }
            else if(islem ==10)
            {
                label1.Text = sayi1.ToString() + " " + "^";
                label1.Visible = true;
            }
            else if (islem == 11)
            {
                label1.Text = sayi1.ToString() + " " + "Mod";
                label1.Visible = true;
            }
            else if (islem == 12)
            {
                label1.Text = sayi1.ToString() + " " + "√(a^2+b^2 ) ";
                label1.Visible = true;
            }
            else if (islem == 13)
            {
                label1.Text = sayi1.ToString() + " " + "% ";
                label1.Visible = true;
            }
           
        }
       

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                sayi2 = double.Parse(label2.Text);
                label2.Text = hesap().ToString();
                
            }
            catch (FormatException a)
            {
                MessageBox.Show(a.ToString());
               
            }
            
        }
       
        public double hesap()
        {
            double sonuc = 0;
            if (islem == 1)
            {
                sonuc = sayi1 + sayi2;
                label1.Hide();
            }
            else if (islem == 2)
            {
                sonuc = sayi1 - sayi2;
                label1.Hide();

            }
            else if (islem == 3)
            {
                label1.Hide();
                sonuc = sayi1 * sayi2;
            }
            else if (islem == 4)
            {
                label1.Hide();
                sonuc = sayi1 / sayi2;
            }
            else if (islem == 10)
            {
                label1.Hide();
                sonuc = Math.Pow(sayi1, sayi2);
            }
            else if (islem == 11)
            {
                label1.Hide();
                sonuc = sayi1 % sayi2;
            }
            else if (islem == 12)
            {
                label1.Hide();
                sonuc = Math.Sqrt((sayi1 * sayi1) + (sayi2 * sayi2));
            }
            else if (islem == 13)
            {

                sonuc = (sayi1 / 100) * sayi2;
            }
            return sonuc;
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
            try
            {
                islem = 3;
                sayi1 = Convert.ToDouble(label2.Text);
                sil();

            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 4;
                sayi1 = Convert.ToDouble(label2.Text);
                sil();

            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           

     
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label2.ResetText();
            label1.ResetText();
            label2.Focus();
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 5;
                sayi1 = double.Parse(label2.Text);
                label2.Text = Math.Sqrt(sayi1).ToString();
                label1.Text = sayi1.ToString() + " " + " √  ";
            }
            catch (FormatException b) 
            {
                label1.Text = " ";
                MessageBox.Show(b.ToString());
                label2.ResetText();
            }
           
           
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 6;
                sayi1 = double.Parse(label2.Text);
                label2.Text = Math.Pow(sayi1, 2).ToString();
                label1.Text = sayi1.ToString() + " " + " x²";
            }
            catch (FormatException af)
            {
                label1.Text = " ";
                MessageBox.Show(af.ToString());
                label2.ResetText();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 7;
                double fk = 1;
                sayi1 = double.Parse(label2.Text);
                for (int i = 1; i <= sayi1; i++)
                {
                    fk = fk * i;

                }
                label2.Text = fk.ToString();
                label1.Text = sayi1.ToString() + "" + " n! ";
            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            islem = 8;
            try
            {
                sayi1 = double.Parse(label2.Text);
                if (sayi1 > 0)
                {
                    label2.Text = Math.Log10(sayi1).ToString();
                }
                else
                    label2.Text="0";
                 
                label1.Text = "Geçersiz Giriş";
                
            }
            catch (DivideByZeroException sd)
            {
                label1.Text = " ";

                MessageBox.Show(sd.ToString());
            }
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 9;
                sayi1 = double.Parse(label2.Text);
                label2.Text = Math.Pow(sayi1, 3).ToString();
                label1.Text = sayi1.ToString() + "" + " x³"; 
            }
            catch (FormatException hh)
            {
                label1.Text = " ";
                MessageBox.Show(hh.ToString());
                label2.ResetText();
            }
           
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 10;
                sayi1 = double.Parse(label2.Text);
                sil();
            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
           
        }

        private void button25_Click(object sender, EventArgs e)
        {
            label2.Text = Math.PI.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 11;
                sayi1 = double.Parse(label2.Text);
                sil();
            }
            catch (FormatException z)
            {
                label1.Text = " ";
                MessageBox.Show(z.ToString());
                label2.ResetText();
            }
          
             
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 12;
                sayi1 = double.Parse(label2.Text);
                sil();
            }
            catch (FormatException ss)
            {

                MessageBox.Show(ss.ToString());
            }
          
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                islem = 13;
                sayi1 = double.Parse(label2.Text);
                sil();
            }
            catch (FormatException ss)
            {
                label1.Text = " ";
                MessageBox.Show(ss.ToString());
                label2.ResetText();
            }
           
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            this.Width = 516;
            this.Height = 325;
            label2.Width = 491;
            label2.Height = 29;
            label2.Focus();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            this.Width = 302;
            this.Height = 325;
            label2.Width = 279;
            label2.Height = 29;
            label2.Focus();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + (sender as Button).Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + ",";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.G && e.Control)
            {
                button18_Click(sender, e);
            }
            if (e.KeyCode == Keys.B && e.Control)
            {
                button29_Click(sender, e);
            }
            try
            {
                if (e.KeyCode == Keys.Add)//toplama
                {
                    
                 
                   button12_Click(sender, e);
                   

                }
                if (e.KeyCode == Keys.Divide)//bölme
                {
                    button15_Click(sender, e);
                }
                if (e.KeyCode == Keys.Subtract)//çıkarma
                {
                    button13_Click_1(sender, e);
                }
                if (e.KeyCode == Keys.Multiply)//carpma
                {
                    button14_Click(sender, e);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    button11_Click(sender, e);
                    
                  
                }
                if (e.KeyCode == Keys.NumPad0)
                {
                    if (label2.Text != "0")
                    {
                        label2.Text = label2.Text + "0";
                     
                       
                    }
                }
                if (e.KeyCode == Keys.NumPad1)
                {
                    label2.Text = label2.Text + "1";
                }
                if (e.KeyCode == Keys.NumPad2)
                {
                    label2.Text = label2.Text+"2";
                }
                if (e.KeyCode == Keys.NumPad3)
                {
                    label2.Text = label2.Text + "3";
                }
                if (e.KeyCode == Keys.NumPad4)
                {
                    label2.Text = label2.Text + "4";
                }
                if (e.KeyCode == Keys.NumPad5)
                {
                    label2.Text = label2.Text + "5";
                }
                if (e.KeyCode == Keys.NumPad6)
                {
                    label2.Text = label2.Text + "6";
                }
                if (e.KeyCode == Keys.NumPad7)
                {
                    label2.Text = label2.Text + "7";
                }
                if (e.KeyCode == Keys.NumPad8)
                {
                    label2.Text = label2.Text + "8";
                }
                if (e.KeyCode == Keys.NumPad9)
                {
                    label2.Text = label2.Text + "9";
                }
                if (e.KeyCode == Keys.D0)
                {
                    label2.Text = label2.Text + "0";
                }
                if (e.KeyCode == Keys.D1)
                {
                    label2.Text = label2.Text + "1";
                }
                if (e.KeyCode == Keys.D2)
                {
                    label2.Text = label2.Text + "2";
                }
                if (e.KeyCode == Keys.D3)
                {
                    label2.Text = label2.Text + "3";
                }
                if (e.KeyCode == Keys.D4)
                {
                    label2.Text = label2.Text + "4";
                }
                if (e.KeyCode == Keys.D5)
                {
                    label2.Text = label2.Text + "5";
                }
                if (e.KeyCode == Keys.D6)
                {
                    label2.Text = label2.Text + "6";
                }
                if (e.KeyCode == Keys.D7)
                {
                    label2.Text = label2.Text + "7";
                }
                if (e.KeyCode == Keys.D8)
                {
                    label2.Text = label2.Text + "8";
                }
                if (e.KeyCode == Keys.D9)
                {
                    label2.Text = label2.Text + "9";
                }
               
            }
            catch (FormatException af)
            {
                label1.Text = " ";
                MessageBox.Show(af.ToString());
                label2.ResetText();

            }
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            
        }

      

     

      
    }
}
