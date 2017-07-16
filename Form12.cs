using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;
using System.IO;
namespace okul_kayıtt
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
           
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            excel.Application dosya = new excel.Application();//excel acar
            dosya.Visible = true;//exceli gösterir 
            object a = Type.Missing;
            excel.Workbook kitap = dosya.Workbooks.Add(a);//calısma sayfası olusturur.
            excel.Worksheet sayfa = (excel.Worksheet)kitap.Sheets[1];//calısma alanı çalısma sayfası 1 rakamı kacıncı sayfada calısacaksak
            int sutun = 1;//excele yazdıracagımız satır
            int satır = 1;//excele yazdıracagımız sutun
            for (int i = 0; i < dataGridView1.Columns.Count; i++)//5 alan varsa 5 dönecek
            {
                excel.Range hücre = (excel.Range)sayfa.Cells[satır, sutun + i];//alan hangi alan hücre biri sıfırdan digeri biroldugu için +2
                hücre.Value2 = dataGridView1.Columns[i].HeaderText;//alanın o degerine
            }
            satır++;
            for (int z = 0; z < dataGridView1.Rows.Count; z++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    try
                    {
                        excel.Range hücre = (excel.Range)sayfa.Cells[satır + z, sutun + i];
                        hücre.Value2 = dataGridView1[i, z].Value;
                    }
                    catch (Exception bb)
                    {

                        MessageBox.Show(bb.Message.ToString());
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.OverwritePrompt = true; ;
                saveFileDialog1.CreatePrompt = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFileDialog1.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";


                    StreamWriter yaz = new StreamWriter(saveFileDialog1.FileName, true, Encoding.UTF8);
                    yaz.WriteLine(dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    yaz.Close();
                    MessageBox.Show("Kayıt Başarıyla Aktarıldı");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
