using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Metin_Belgesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dosya = "";
        string a = "";
        Değiştir değiş = new Değiştir();
        Bul bull = new Bul();
        int d;
        int sa = 0;

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog aç = new OpenFileDialog();
            aç.Filter = "Tüm Dosyalar|*.*|Metin Dosyaları|*.txt";
            aç.ShowDialog();
            StreamReader sr = new StreamReader(aç.FileName, Encoding.Default);
            dosya = aç.FileName;
            this.Text = aç.FileName;
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();

        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosya = "";
            richTextBox1.Text = dosya;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog yazdır = new PrintDialog();
            
            if (yazdır.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sa++;
            SaveFileDialog farklıkaydet = new SaveFileDialog();
            farklıkaydet.Filter = "txt dosyaları(*.txt)|*.txt";
            if (farklıkaydet.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(farklıkaydet.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            richTextBox1.ClearUndo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bull.ShowDialog();
            bull.button1.Click += bul1;
            bull.button2.Click += bul2;
            bull.button3.Click += bul3;
            bull.textBox1.KeyDown += deneme;
        }

        private void deneme(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bull.textBox1.Text == "")
                {
                    MessageBox.Show("Lütfen Değer Girin", "Boş Değer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bull.textBox1.Clear();
                }
                else
                {
                    if (!richTextBox1.Text.Contains(bull.textBox1.Text))
                    {
                        MessageBox.Show("Aradığınız Değer Bulunamadı", "Bulunamayan Değer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bull.textBox1.Clear();
                    }
                    else
                    {
                        d = richTextBox1.Find(bull.textBox1.Text);

                    }
                }
            }
        }

        private void bul1(object sender, EventArgs e)
        {
            if (bull.textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Değer Girin","Boş Değer",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                bull.textBox1.Clear();
            }
            else
            {
                if(!richTextBox1.Text.Contains(bull.textBox1.Text))
                {
                    MessageBox.Show("Aradığınız Değer Bulunamadı","Bulunamayan Değer",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    bull.textBox1.Clear();
                }
                else
                {
                    d = richTextBox1.Find(bull.textBox1.Text);
                    
                }
            }
          
        }
        private void bul2(object sender, EventArgs e)
        {
            if (bull.textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Değer Girin", "Boş Değer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bull.textBox1.Clear();
            }
            else
            {
                if (!richTextBox1.Text.Contains(bull.textBox1.Text))
                {
                    MessageBox.Show("Aradığınız Değer Bulunamadı", "Bulunamayan Değer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bull.textBox1.Clear();
                }
                else
                {
                    richTextBox1.Find(bull.textBox1.Text, (d + 1), RichTextBoxFinds.None);
                }
            }
           
        }
        private void bul3(object sender, EventArgs e)
        {
            bull.Close();
        }

        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            değiş.ShowDialog();
            değiş.button1.Click += Button1_Click;
            değiş.button2.Click += Button2_Click;
            değiş.textBox1.KeyDown += TextBox1_KeyDown;
            değiş.textBox2.KeyDown += TextBox2_KeyDown;
        
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (değiş.textBox1.Text == "")
                {
                    MessageBox.Show("Lütfen Değer Girin", "Boş Değer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (richTextBox1.Text.Contains(değiş.textBox1.Text))
                    {
                        richTextBox1.Text = richTextBox1.Text.Replace(değiş.textBox1.Text, değiş.textBox2.Text);
                        değiş.textBox1.Clear();
                        değiş.textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Aradığınız Değer Bulunamadı", "Bulunamayan Değer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        değiş.textBox1.Clear();
                        değiş.textBox2.Clear();
                    }
                }
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                değiş.textBox2.Focus();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            değiş.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (değiş.textBox1.Text =="")
            {
                MessageBox.Show("Lütfen Değer Girin","Boş Değer",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (richTextBox1.Text.Contains(değiş.textBox1.Text))
                {
                    richTextBox1.Text = richTextBox1.Text.Replace(değiş.textBox1.Text, değiş.textBox2.Text);
                    değiş.textBox1.Clear();
                    değiş.textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Aradığınız Değer Bulunamadı","Bulunamayan Değer",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    değiş.textBox1.Clear();
                    değiş.textBox2.Clear();
                }
            }
            
        }

        private void takvimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void saatTarihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            richTextBox1.Text = DateTime.Now.ToLongTimeString() + "      " + DateTime.Now.ToLongDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            geriAlToolStripMenuItem.Enabled = false;
            kesToolStripMenuItem.Enabled = false;
            kopyalaToolStripMenuItem.Enabled = false;
            tümünüSeçToolStripMenuItem.Enabled = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = renk.Color;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = renk.Color;
            }
        }

        private void arkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            if (renk.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = renk.Color;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            dosya = "";
            richTextBox1.Text = dosya;
        }

        private void sağaYaslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ortalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void solaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = font.Font;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = font.Font;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog aç = new OpenFileDialog();
            aç.Filter = "Tüm Dosyalar|*.*|Metin Dosyaları|*.txt";
            aç.ShowDialog();
            StreamReader sr = new StreamReader(aç.FileName, Encoding.Default);
            dosya = aç.FileName;
            this.Text = aç.FileName;
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            sa++;
            SaveFileDialog farklıkaydet = new SaveFileDialog();
            farklıkaydet.Filter = "txt dosyaları(*.txt)|*.txt";
            if (farklıkaydet.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(farklıkaydet.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDialog yazdır = new PrintDialog();

            if (yazdır.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void yarıdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkında hak = new Hakkında();
            hak.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                geriAlToolStripMenuItem.Enabled = true;
                kesToolStripMenuItem.Enabled = true;
                kopyalaToolStripMenuItem.Enabled = true;
                tümünüSeçToolStripMenuItem.Enabled = true;
            }
            else
            {
                geriAlToolStripMenuItem.Enabled = false;
                kesToolStripMenuItem.Enabled = false;
                kopyalaToolStripMenuItem.Enabled = false;
                tümünüSeçToolStripMenuItem.Enabled = false;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Hakkında hak = new Hakkında();
            hak.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sa == 0)
            {
                DialogResult dr = MessageBox.Show("Gerçekten programı kapatmak istiyor musunuz?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            
            //if ((MessageBox.Show("Çıkış Yapmak İstiyor Musunuz", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK))
            // {
            //     e.Cancel = true;   
            // }
            // else
            // {
            //     e.Cancel = false;
            // }

        }
    }
}
