using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace projee
{
    public partial class Form1 : Form
    {
        string cmle;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'randevuDataSet.suclular' table. You can move, or remove it, as needed.
            this.suclularTableAdapter.Fill(this.randevuDataSet.suclular);
            // TODO: This line of code loads data into the 'randevuDataSet.suclar' table. You can move, or remove it, as needed.
            this.suclarTableAdapter.Fill(this.randevuDataSet.suclar);
            // TODO: This line of code loads data into the 'randevuDataSet.ceza' table. You can move, or remove it, as needed.
            this.cezaTableAdapter.Fill(this.randevuDataSet.ceza);
            // TODO: This line of code loads data into the 'randevuDataSet.saglik_sorun' table. You can move, or remove it, as needed.
            this.saglik_sorunTableAdapter.Fill(this.randevuDataSet.saglik_sorun);
            // TODO: This line of code loads data into the 'randevuDataSet.saglik_durum_aciklama' table. You can move, or remove it, as needed.
            this.saglik_durum_aciklamaTableAdapter.Fill(this.randevuDataSet.saglik_durum_aciklama);
            // TODO: This line of code loads data into the 'randevuDataSet.durum' table. You can move, or remove it, as needed.
            this.durumTableAdapter.Fill(this.randevuDataSet.durum);

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            randevuDataSet.saglik_durum_aciklamaRow r = randevuDataSet.saglik_durum_aciklama.Newsaglik_durum_aciklamaRow();
            if (textBox1.Text != "")
            {
                r.aciklama = textBox1.Text.ToUpper();
                randevuDataSet.saglik_durum_aciklama.Addsaglik_durum_aciklamaRow(r);
                saglik_durum_aciklamaTableAdapter.Update(r);
                textBox1.Clear();
                
            }
            else
            {
                MessageBox.Show("Lütfen Acıklama Giriniz");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayı = dataGridView2.SelectedRows.Count;
            for (int i = 0; i <sayı; i++)
            {
                int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                randevuDataSet.saglik_durum_aciklamaRow r = randevuDataSet.saglik_durum_aciklama.FindBysaglik_durum_aciklama_id(id);
                r.Delete();
                saglik_durum_aciklamaTableAdapter.Update(r); 
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            randevuDataSet.suclarRow r = randevuDataSet.suclar.NewsuclarRow();
            r.suc_ad = textBox2.Text.ToUpper() ;
            r.ceza_id = (int)comboBox1.SelectedValue;
            r.ceza_yil = (int)comboBox2.SelectedValue;
            randevuDataSet.suclar.AddsuclarRow(r);
            suclarTableAdapter.Update(r);
            textBox2.Clear();
        
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                randevuDataSet.cezaRow r = randevuDataSet.ceza.NewcezaRow();
                r.ceza_yil = Convert.ToInt32(textBox3.Text);
                randevuDataSet.ceza.AddcezaRow(r);
                cezaTableAdapter.Update(r);
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Deger Giriniz");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                saglikdurumaciklamaBindingSource1.Filter = "aciklama like '" + textBox9.Text.ToUpper() + "%'";
            }
            else
            {
                MessageBox.Show("Lütfen Aranacak Kaydı Giriniz");
            }
          
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            saglikdurumaciklamaBindingSource1.Filter = "aciklama like '" + textBox9.Text.ToUpper() + "%'";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sayı = dataGridView4.SelectedRows.Count;
            for (int i = 0; i < sayı; i++)
            {
                int id = (int)dataGridView4.SelectedRows[0].Cells[0].Value;
                randevuDataSet.cezaRow r = randevuDataSet.ceza.FindByceza_id(id);
                r.Delete();
                cezaTableAdapter.Update(r);
                
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            if (textBox10.Text != "" )
            {
              
               
                    int id = Convert.ToInt32(textBox10.Text);
                    int yer = cezaBindingSource.Find("ceza_yil", id);
                    cezaBindingSource.Position = yer;
                    textBox10.Clear();
              
            }
            else 
            {
                MessageBox.Show("Lütfen Aranacak Kaydı Giriniz");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int sayı = dataGridView5.SelectedRows.Count;
            for (int i = 0; i < sayı; i++)
            {
                int id = (int)dataGridView5.SelectedRows[0].Cells[0].Value;
                randevuDataSet.suclarRow r = randevuDataSet.suclar.FindBysuc_id(id);
                r.Delete();
                suclarTableAdapter.Update(r);
            }
         
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);
            randevuDataSet.suclarRow r = randevuDataSet.suclar.FindBysuc_id(id);
            r.suc_ad = textBox4.Text.ToUpper();
           
            r.ceza_id =(int)comboBox5.SelectedValue;
            r.ceza_yil =(int) comboBox4.SelectedValue;
            suclarTableAdapter.Update(r);
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(textBox12.Text);

            randevuDataSet.saglik_durum_aciklamaRow r = randevuDataSet.saglik_durum_aciklama.FindBysaglik_durum_aciklama_id(id);
     
            r.aciklama = textBox11.Text.ToUpper();
            saglik_durum_aciklamaTableAdapter.Update(r);
            textBox12.Clear();
            textBox11.Clear();
            
          
        }

        private void button13_Click(object sender, EventArgs e)
        {


            int id = Convert.ToInt32(textBox13.Text);

            randevuDataSet.cezaRow r = randevuDataSet.ceza.FindByceza_id(id);
            
           
            r.ceza_yil = Convert.ToInt32(textBox14.Text);
            cezaTableAdapter.Update(r);
            textBox13.Clear();
            textBox14.Clear();
          
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form2 yeni = new Form2();
            yeni.ekle = true;
            
            yeni.r = randevuDataSet.suclular.NewsuclularRow();
            if (yeni.ShowDialog() == DialogResult.OK)
            {
              
                randevuDataSet.suclular.AddsuclularRow(yeni.r);
                suclularTableAdapter.Update(yeni.r);
               suclularBindingSource.Position=suclularBindingSource.Find("suclu_tc", yeni.r.suclu_tc);
            }
            
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.ekle = false;
            int id = (int)dataGridView6.SelectedRows[0].Cells[0].Value;
            a.r = randevuDataSet.suclular.FindBysuclu_id(id);
            if (a.ShowDialog() == DialogResult.OK)
            {
            
                suclularTableAdapter.Update(a.r);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int sayı = dataGridView6.SelectedRows.Count;
            for (int i = 0; i < sayı; i++)
            {
                int id = (int)dataGridView6.SelectedRows[0].Cells[0].Value;
                randevuDataSet.suclularRow r = randevuDataSet.suclular.FindBysuclu_id(id);
                r.Delete();
                suclularTableAdapter.Update(r);
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && comboBox6.SelectedItem.ToString()=="TC")
            {
                suclularBindingSource.Filter = "suclu_tc like '" + textBox15.Text + "%'";
                textBox15.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Aranacak Kaydı Giriniz");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //suclarBindingSource.Filter = "suc_ad like'" + comboBox3.SelectedValue.ToString() + "%'";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.ToString() == "TC")
            {
                suclularBindingSource.Filter = "suclu_tc like '" + textBox15.Text + "%'";
            }
            else if(comboBox6.SelectedItem.ToString()=="SOYAD")
            {
                suclularBindingSource.Filter = "suclu_soyad like '" + textBox15.Text + "%'";
            }
            else if (comboBox6.SelectedItem.ToString() == "AD")
            {
                suclularBindingSource.Filter = "suclu_ad like '" + textBox15.Text + "%'";
            }
            else if (comboBox6.SelectedItem.ToString() == "CEZA YIL")
            {
                if (textBox15.Text != "")
                {
                    suclularBindingSource.Filter = "ceza_yil =" + Convert.ToInt32(textBox15.Text);
                }  
            }
            else if(comboBox6.SelectedItem.ToString()=="KAN GRUBU")
            {
                suclularBindingSource.Filter = "kan_grubu like '" + textBox15.Text + "%'";
            }
            else if (comboBox6.SelectedItem.ToString()=="SUÇ TÜRÜ")
            {
                suclularBindingSource.Filter = "suc_ad like '" + textBox15.Text + "%'";
            }
            else if (comboBox6.SelectedItem.ToString()=="HASTALIK")
            {
                suclularBindingSource.Filter = "saglik_durum_aciklama like '" + textBox15.Text + "%'";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            
            int sayı = dataGridView6.SelectedRows.Count;
            Form3 mail = new Form3();
            mail.textBox2.Text = "Suçlu Bilgileri";
            for (int i = 0; i < sayı; i++)
            {
                int id = (int)dataGridView6.SelectedRows[i].Cells[0].Value;
                randevuDataSet.suclularRow r = randevuDataSet.suclular.FindBysuclu_id(id);
                cmle = "Suçlu Adı : " + r.suclu_ad + "\n" + "Suçlu SoyAdı :" + r.suclu_soyad + "\n" + "Tc Kimlik No :" + r.suclu_tc.ToString() + "\n" + "Suçlu Doğum Tarihi : " + r.suclu_d_tarihi.ToShortDateString() + "\n" +
              "Suç Adı :" + r.suc_ad + "\n" + "Ceza Yılı : " + r.ceza_yil + "\n" + "Sağlık Sorunu :" + r.saglik_sorun_durum + "\n" + "Hastalık Adı : " + r.saglik_durum_aciklama + "\n" + "Ceza Durumu : " + r.durum + "\n" + "\n" +
              cmle;
                
            }
            mail.richTextBox1.Text = cmle;
            mail.Show();
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox12.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
           
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a  = (int)dataGridView4.SelectedRows[0].Cells[0].Value;
            textBox13.Text = a.ToString();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
      
            saveFileDialog1.OverwritePrompt = true;;
               saveFileDialog1.CreatePrompt = true;  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
              
                int id = (int)dataGridView6.SelectedRows[0].Cells[0].Value;
                randevuDataSet.suclularRow r = randevuDataSet.suclular.FindBysuclu_id(id);
                StreamWriter yaz = new StreamWriter(saveFileDialog1.FileName, true, Encoding.UTF8);
                yaz.WriteLine(r.suclu_ad+" " + r.suclu_soyad);
                yaz.Close();
                MessageBox.Show("Kayıt Başarıyla Aktarıldı");
            }
         
         
        }

        private void button19_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
       
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


   
      
  

     
    }
}
