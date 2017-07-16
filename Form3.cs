using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms.DataVisualization.Charting;
using excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
namespace okul_kayıtt
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string cmle;
        private void yeniÖğrenciKayıtıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 yeni = new Form4();
                yeni.yenin = true;
                yeni.label8.Text = this.label1.Text;
                yeni.textBox11.Enabled = false;
                yeni.satır = kayıtDataSet1.ogrenci.NewogrenciRow();
                if (yeni.ShowDialog() == DialogResult.OK)
                {
                    kayıtDataSet1.ogrenci.AddogrenciRow(yeni.satır);
                    ogrenciTableAdapter.Update(yeni.satır);
                    ogrenciBindingSource.Position = ogrenciBindingSource.Find("tc", yeni.satır.tc);
                    MessageBox.Show("Kayıt Başarı İle Eklendi");
                }
                button1_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                dataGridView1.DataSource = dt;

                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void mevcutÖğrenciKayıtDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 duzelt = new Form4();

                duzelt.yenin = false;
                duzelt.label23.Hide();
                duzelt.label8.Hide();
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                duzelt.satır = kayıtDataSet1.ogrenci.FindByogrenci_id(id);
                if (duzelt.ShowDialog() == DialogResult.OK)
                {
                    ogrenciTableAdapter.Update(duzelt.satır);
                    MessageBox.Show(duzelt.satır.ogrenci_id.ToString() + "Numaralı" + "Kayıt Düzenlendi");
                    button1_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Hide();
            this.ogrenciTableAdapter.Fill(this.kayıtDataSet1.ogrenci);
            // TODO: This line of code loads data into the 'kayıtDataSet1.sekil' table. You can move, or remove it, as needed.
            this.sekilTableAdapter1.Fill(this.kayıtDataSet1.sekil);
            // TODO: This line of code loads data into the 'kayıtDataSet1.diller' table. You can move, or remove it, as needed.
            this.dillerTableAdapter1.Fill(this.kayıtDataSet1.diller);
            // TODO: This line of code loads data into the 'kayıtDataSet1.bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter1.Fill(this.kayıtDataSet1.bolumler);
            // TODO: This line of code loads data into the 'kayıtDataSet1.fakulte' table. You can move, or remove it, as needed.
            this.fakulteTableAdapter1.Fill(this.kayıtDataSet1.fakulte);
            // TODO: This line of code loads data into the 'kayıtDataSet1.iller' table. You can move, or remove it, as needed.
            this.illerTableAdapter1.Fill(this.kayıtDataSet1.iller);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void seçiliÖğrenciKaydınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {

                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                kayıtDataSet.ogrenciRow r = kayıtDataSet1.ogrenci.FindByogrenci_id(id);
                r.Delete();
                ogrenciTableAdapter.Update(r);
                MessageBox.Show(id.ToString() + "Numaralı Kayıt Silindi");
                button1_Click(sender, e);
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.ToString());
                //MessageBox.Show(ee.Source.ToString());
                //MessageBox.Show(ee.InnerException.ToString());
                MessageBox.Show(ee.Message.ToString());
                //MessageBox.Show(ee.Data.ToString());
                //MessageBox.Show(ee.HelpLink.ToString());
            }

            //else
            //{
            //int say = dataGridView1.SelectedRows.Count;
            //    for (int i = 0; i < say; i++)
            //    {
            //        int id2 = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //        kayıtDataSet.ogrenciRow r = kayıtDataSet1.ogrenci.FindByogrenci_id(id2);
            //        r.Delete();
            //        ogrenciTableAdapter.Update(r);
            //        button1_Click(sender, e);
            //    }

        }

        private void öğrenciBilgileriniPostalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int sayı = dataGridView1.SelectedRows.Count;
                Form5 mail = new Form5();
                mail.textBox2.Text = "Suçlu Bilgileri";
                for (int i = 0; i < sayı; i++)
                {
                    int id = (int)dataGridView1.SelectedRows[i].Cells[0].Value;
                    kayıtDataSet.ogrenciRow r = kayıtDataSet1.ogrenci.FindByogrenci_id(id);
                    cmle = "Öğr No :" + r.ogrenci_id.ToString() + "\n" + "Öğr Adı :" + r.ogr_ad + "\n" + "Öğr Soyadı :" + r.ogr_soyad + "\n" + "Öğr Tc :" + r.tc + "\n" + "Fakulte : " + dataGridView1.SelectedRows[i].Cells[12].Value.ToString() + "\n" + "Bölümü :" + dataGridView1.SelectedRows[i].Cells[13].Value.ToString() + "\n" + cmle;


                }
                mail.richTextBox1.Text = cmle;
                mail.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void öğrencilerinİstatistikleriniGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 istatistik = new Form6();
                istatistik.chart1.Titles.Add("Fakülte Ve Öğrenci Dağılımı");
                istatistik.label2.Text = kayıtDataSet1.ogrenci.Rows.Count.ToString();
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komut = new SqlCommand("select fakulte_id,count(ogrenci_id) from ogrenci group by(fakulte_id) HAVING fakulte_id=1", bagla);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                    // MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString());
                    Series s = istatistik.chart1.Series.Add("Edebiyat Fakültesi");
                    istatistik.chart1.Series[1].Points.AddXY(DateTime.Now.ToShortDateString() + " " + "Tarihli Öğrenci Sayıları", Convert.ToDouble(dr[1]));
                    istatistik.label4.Text = dr[1].ToString();

                }
                bagla.Close();

                SqlConnection bagla2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla2.Open();
                SqlCommand komut2 = new SqlCommand("select fakulte_id,count(ogrenci_id) from ogrenci group by(fakulte_id) HAVING fakulte_id=2", bagla2);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {

                    // MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString());
                    Series ss = istatistik.chart1.Series.Add("İktisadi ve İdari Bilimler Fakültesi");
                    istatistik.chart1.Series[2].Points.Add(Convert.ToDouble(dr2[1]));
                    istatistik.label6.Text = dr2[1].ToString();

                }
                bagla2.Close();
                istatistik.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void detaylıÖğrenciTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 ayrıntı = new Form7();
                string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                ayrıntı.dataGridView1.DataSource = dt;
                ayrıntı.dataGridView2.Hide();
                bagla.Close();
                ayrıntı.label1.Hide();
                ayrıntı.label2.Hide();
                ayrıntı.label3.Hide();
                ayrıntı.label4.Hide();
                ayrıntı.dateTimePicker1.Hide();
                ayrıntı.dateTimePicker2.Hide();
                ayrıntı.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }


        }

        private void mevcutBölümleriGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form8 bolum = new Form8();
                //string sorgu = "select ogrenci_id,ogr_ad,ogr_soyad,medeni_hal,anne_ad,baba_ad,tc,dogum_yeri,dogum_tarihi,yas,kan_grubu,il_ad,fakulte_ad,bolum_ad,dil_ad,sekil_ad,kullanici_adi,nakilse_geldigi_üniversite,e_posta from ogrenci e JOIN iller i on e.il_id=i.il_id JOIN fakulte f on f.fakulte_id = e.fakulte_id JOIN bolumler b on e.bolum_id = b.bolum_id JOIN diller d on e.dil_id = d.dil_id JOIN sekil s on e.sekil_id = s.sekil_id JOIN kullanci k on e.kullanici_id=k.kullanici_id";
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                //bagla.Open();
                //SqlCommand komutt = new SqlCommand(sorgu, bagla);
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //ds.Tables.Add(dt);
                //SqlDataAdapter adap = new SqlDataAdapter(komutt);
                //adap.Fill(dt);
                //giris.dataGridView1.DataSource = dt;
                string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                SqlDataAdapter adap = new SqlDataAdapter(komutt);
                adap.Fill(dt);
                bolum.dataGridView1.DataSource = dt;
                bolum.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void iİBFFakültesineEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 iibf = new Form9();
            iibf.label1.Text = this.iİBFFakültesineEkleToolStripMenuItem.Text;
            iibf.ShowDialog();
        }

        private void edebiyatFakültesineEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 edebiyat = new Form9();
            edebiyat.label1.Text = this.edebiyatFakültesineEkleToolStripMenuItem.Text;
            edebiyat.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void edebiyatFakültesiBölümleriniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 edebiyatd = new Form10();
            edebiyatd.label1.Text = this.edebiyatFakültesiBölümleriniDüzenleToolStripMenuItem.Text;
            edebiyatd.ShowDialog();
        }

        private void iktisadiVeİdariBilimlerFakültesiniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 iibfd = new Form10();
            iibfd.label1.Text = this.iktisadiVeİdariBilimlerFakültesiniDüzenleToolStripMenuItem.Text;
            iibfd.ShowDialog();
        }




        private void tümKayıtlarıExceleAktarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void seçiliÖğrenciKaydınıMetinBelgesineAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string yol=@"C:\Users\Administrator\Desktop\Öğrenci";
                //Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\Öğrenci");
                //File.Create(@"C:\Users\Administrator\Desktop\Öğrenci\Aktarım.txt");

                saveFileDialog1.OverwritePrompt = true; ;
                saveFileDialog1.CreatePrompt = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFileDialog1.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
                    MessageBox.Show(saveFileDialog1.FileName.ToString());
                    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    kayıtDataSet.ogrenciRow r = kayıtDataSet1.ogrenci.FindByogrenci_id(id);
                    StreamWriter yaz = new StreamWriter(saveFileDialog1.FileName, true, Encoding.UTF8);
                    //StreamWriter sw = new StreamWriter("", true, Encoding.UTF8);
                    yaz.WriteLine(r.ogrenci_id + " " + r.ogr_ad + " " + r.ogr_soyad);
                    // sw.WriteLine(r.ogrenci_id + " " + r.ogr_ad + " " + r.ogr_soyad);
                    // sw.Close();
                    yaz.Close();
                    MessageBox.Show("Kayıt Başarıyla Aktarıldı");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bölümBilgileriniAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form12 aktar = new Form12();
                string sorgu = "select bolum_id,bolum_ad,fakulte_ad from bolumler b JOIN fakulte f on b.fakulte_id = f.fakulte_id";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                SqlDataAdapter adap = new SqlDataAdapter(komutt);
                adap.Fill(dt);
                aktar.dataGridView1.DataSource = dt;

                aktar.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void bölümDetaylarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 detay = new Form11();
            detay.label2.Hide();
            detay.label3.Hide();
            detay.ShowDialog();
        }

        private void metinBelgesindekiKayıtlarıAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıt Aktarırken Metin Belgesinin içerisine Ad,Soyad,Anne adı,Baba adı,Medeni hali,Dogum yeri,Yaşı,Tcsi,Kan grubu,İl kodu,Fakulte kodu,Bölüm kodu,Yabancıdil kodu,Üniversite Kayıt Kodu,Nakilse Geldigi Üniversite,Ve İşlemi Yapanın Kullanıcı Kodu Aralarına virgül koyularak yazılmalıdır eğer nakil olarak gelmediyse virgülden sonra bir boşluk bırakıp tekrar virgül atılarak devam edilmelidir Örn " + "\n" + " Ali,akar,isa,derya,bekar,istanbul,21,12345678932,abrh(+),1,1,1,1,1, ,1/ nakilse 2,üniversite adı,1", "Kayıt Aktarma Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Random g = new Random();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog1.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);

                    while (!sr.EndOfStream)
                    {
                        kayıtDataSet.ogrenciRow r = kayıtDataSet1.ogrenci.NewogrenciRow();
                        //string aktr=sr.ReadLine();
                        String[] aktar = sr.ReadLine().Split(',');
                        //MessageBox.Show(sr.ReadLine());
                        r.ogr_ad = aktar[0].ToString();
                        r.ogr_soyad = aktar[1].ToString();
                        r.anne_ad = aktar[2].ToString();
                        r.baba_ad = aktar[3].ToString();
                        r.medeni_hal = aktar[4].ToString();
                        r.dogum_yeri = aktar[5].ToString();
                        r.dogum_tarihi = DateTime.Now.AddYears(-int.Parse(aktar[6]));
                        r.yas = int.Parse(aktar[6]);
                        r.tc = aktar[7].ToString();
                        r.kan_grubu = aktar[8].ToString();
                        r.il_id = int.Parse(aktar[9]);
                        r.fakulte_id = int.Parse(aktar[10]);
                        r.bolum_id = int.Parse(aktar[11]);
                        r.dil_id = int.Parse(aktar[12]);
                        r.sekil_id = int.Parse(aktar[13]);
                        r.nakilse_geldigi_üniversite = aktar[14].ToString();
                        r.e_posta = DateTime.Now.Year.ToString() + aktar[11].ToString() + g.Next(0, 9999).ToString() + "@cumhuriyet.edu.tr";
                        r.kullanici_id = int.Parse(aktar[15]);
                        kayıtDataSet1.ogrenci.AddogrenciRow(r);
                        ogrenciTableAdapter.Update(r);
                        //ogrenciTableAdapter1.Update(r);
                        button1_Click(sender, e);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void sadToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ogrenci.xlsx; Extended Properties='Excel 12.0 xml;HDR=YES;'");
                baglanti.Open();  //www.ahmetcansever.com
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                baglanti.Close();
            }
        }

        private void fakültelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form13 fakulte = new Form13();
            fakulte.ShowDialog();
        }

        private void faküToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 detay = new Form14();
            foreach (kayıtDataSet.fakulteRow item in kayıtDataSet1.fakulte.Rows)
            {
                ListViewItem l = detay.listView1.Items.Add(item.fakulte_id.ToString());
                l.SubItems.Add(item.fakulte_ad.ToString());

            }
            detay.ShowDialog();
        }

        private void fakülteBilgileriniAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 aktar = new Form15();
            aktar.ShowDialog();
        }

        private void mevcutİllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 il = new Form16();
            il.textBox1.Visible = false;
            il.button1.Visible = false;
            il.label2.Visible = false;
            il.button2.Visible = false;
            il.button3.Visible = false;
            il.textBox2.Visible = false;
            il.label1.Visible = false;
            il.label3.Visible = false;
            il.button4.Hide();
            il.Width = 294;
            il.Height = 399;
            il.ShowDialog();
        }

        private void ilEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 ilekle = new Form16();
            ilekle.Width = 418;
            ilekle.Height = 514;
            ilekle.button1.Visible = true;
            ilekle.label2.Visible = true;
            ilekle.button4.Visible = true;
            ilekle.textBox1.Visible = true;
            ilekle.button2.Visible = false;
            ilekle.button3.Visible = false;
            ilekle.textBox2.Visible = false;
            ilekle.label3.Visible = false;
            ilekle.label1.Visible = false;
            ilekle.textBox1.Focus();
            ilekle.ShowDialog();
        }

        private void ilDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 düzen = new Form16();
            düzen.button1.Visible = false;
            düzen.textBox1.Visible = false;
            düzen.label2.Visible = true;
            düzen.button2.Visible = true;
            düzen.button3.Visible = true;
            düzen.textBox2.Visible = true;
            düzen.button4.Visible = true;
            düzen.label1.Visible = true;
            düzen.label3.Visible = true;
            düzen.textBox2.Focus();
            düzen.Width = 418;
            düzen.Height = 514;
            düzen.ShowDialog();
        }

        private void ilDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 detay = new Form17();
            detay.ShowDialog();
        }

        private void ilAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 aktar = new Form18();
            aktar.ShowDialog();
        }

        private void mevcutKullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 kullanici = new Form19();
            kullanici.Width = 326;
            kullanici.Height = 364;
            try
            {
                string sorgu = "select kullanici_id,kullanici_adi from kullanci ";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                kullanici.dataGridView1.DataSource = dt;

                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            kullanici.ShowDialog();
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 kullanici = new Form2();
                kullanici.kullanici = true;
                kullanici.r = kayıtDataSet1.kullanci.NewkullanciRow();


                if (kullanici.ShowDialog() == DialogResult.OK)
                {
                    kayıtDataSet1.kullanci.AddkullanciRow(kullanici.r);
                    kullanciTableAdapter1.Update(kullanici.r);

                }
              
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void kullanıcıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 düzenle = new Form19();
            düzenle.Width = 369;
            düzenle.Height = 511;
           

            try
            {

                string sorgu = "select kullanici_id,kullanici_adi from kullanci ";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                düzenle.dataGridView1.DataSource = dt;

                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());

            }
            düzenle.ShowDialog();
        }

        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 hakkında = new Form20();
            hakkında.label2.Text = Application.ProductName.ToString();
            hakkında.label3.Text = Application.ProductVersion.ToString();
            hakkında.label5.Text = Application.CompanyName.ToString();
            hakkında.label8.Text = "Copyright ©  2017";
            hakkında.ShowDialog();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Form21 sifre = new Form21();
            sifre.label6.Text = r.Next(0, 9999).ToString();
            sifre.ShowDialog();
        }

        //try
        //{
        //    int yas;
        //    int id = (int)comboBox6.SelectedValue;
        //    Random rr = new Random();
        //    int a = rr.Next(0, 99999);

        //    DateTime dogum = new DateTime();
        //    TimeSpan fark;

        //    dogum = DateTime.Parse(maskedTextBox1.Text); //convert ediliyor datetime oldugu için
        //    fark = DateTime.Now.Date.Subtract(dogum); //şimdiki zamandan dogum çıkarılıyor
        //    yas = Convert.ToInt32(fark.TotalDays);
        //    yas = yas / 365;

        //    string tarih = Convert.ToString(DateTime.Now.Year);
        //    string bolkod = Convert.ToString(comboBox6.SelectedValue);
        //    //kayıtDataSet.ogrenciRow satır = kayıtDataSet1.ogrenci.NewogrenciRow();
        //    satır.ogr_ad = textBox1.Text.ToLower();
        //    satır.ogr_soyad = textBox2.Text.ToLower();
        //    satır.anne_ad = textBox3.Text.ToLower();
        //    satır.baba_ad = textBox4.Text.ToLower();
        //    satır.medeni_hal = comboBox1.SelectedItem.ToString().ToLower();
        //    satır.dogum_yeri = textBox6.Text.ToLower();
        //    satır.dogum_tarihi = Convert.ToDateTime(maskedTextBox1.Text);
        //    satır.yas = yas;
        //    satır.tc = textBox9.Text;
        //    satır.kan_grubu = textBox10.Text.ToLower();
        //    satır.il_id = (int)comboBox2.SelectedValue;
        //    foreach (kayıtDataSet.bolumlerRow item in kayıtDataSet1.bolumler.Rows)
        //    {
        //        if (item.bolum_id == id)
        //        {
        //            satır.fakulte_id = item.fakulte_id;
        //        }
        //    }
        //    satır.bolum_id = id;
        //    satır.dil_id = (int)comboBox8.SelectedValue;
        //    satır.sekil_id = (int)comboBox10.SelectedValue;
        //    satır.nakilse_geldigi_üniversite = textBox11.Text;
        //    string posta = tarih + bolkod + a.ToString() + "@cumhuriyet.edu.tr";

        //    satır.e_posta = posta.ToLower();



        //    SqlConnection bag = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
        //    bag.Open();
        //    SqlCommand kmt = new SqlCommand("select kullanici_id from kullanci where kullanici_adi=@adi", bag);
        //    kmt.Parameters.AddWithValue("@adi", label8.Text);
        //    SqlDataReader dr = kmt.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        satır.kullanici_id = Convert.ToInt32(dr[0]);
        //    }

        //    bag.Close();

        //    temizle();
        //}
        //catch (FormatException ee)
        //{
        //    MessageBox.Show(ee.Message.ToString());
        //}
    }
}

       
