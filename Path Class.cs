using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PathSınıfı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string yol = openFileDialog1.FileName;// @"C:\Users\Administrator\Desktop\Yeni klasör\12.txt";
                MessageBox.Show(Path.GetExtension(yol));//belirtilen yoldaki dosyanın uzantısını getirir
                MessageBox.Show(Path.GetFileName(yol)); //yoldaki dosyanın adı
                MessageBox.Show(Path.GetDirectoryName(yol));//yoldaki klasörün adı
                MessageBox.Show(Path.GetFileNameWithoutExtension(yol)); //uzantısını göstermeden tam adını alır
                MessageBox.Show(Path.GetFullPath(yol));//yoldaki tam ad
                MessageBox.Show(Path.GetPathRoot(yol));//dosya yada klasörün kök dizinini gösterir
                if (Path.HasExtension(yol)) //dosyanın uzantısının olup olmadıgını kontrol eder boolen değer döndürür
                {
                    MessageBox.Show("uzantılı");
                }
                else
                {
                    MessageBox.Show("uzantısız");
                }
                if (Path.IsPathRooted(yol))//bi üst dizini var mı yok mu belirtir
                {
                    MessageBox.Show("var");
                }
                else
                {
                    MessageBox.Show("yok");
                }
                MessageBox.Show(Path.GetTempPath());//program işlem yaparken oluşan geçici dosyaların ismini alır.
                MessageBox.Show(Path.GetTempFileName());
            }
        }
    }
}
