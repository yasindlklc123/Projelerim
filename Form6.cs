using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace okul_kayıtt
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
       

        private void Form6_Load(object sender, EventArgs e)
        {

            this.ogrenciTableAdapter1.Fill(this.kayıtDataSet1.ogrenci);
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

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int a = dataGridView1.Rows.Count;
            //for (int i = 0; i < a; i++)
            //{
            //    Series seri = this.chart1.Series.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
            //    chart1.Series[i].Points.AddXY(DateTime.Now.ToShortDateString(), (int)dataGridView1.Rows[i].Cells[2].Value);

            //}

            //foreach (kayıtDataSet.bolumlerRow item in kayıtDataSet1.bolumler.Rows)
            //{
            //    int a = item.fakulte_id.ToString().Count();
            //    MessageBox.Show(a.ToString());
            //}
            
            
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection bagla2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\kayıt.mdf;Integrated Security=True;User Instance=True");
            //bagla2.Open();
            //SqlCommand komut2 = new SqlCommand("select fakulte_id,count(ogrenci_id) from ogrenci group by(fakulte_id) HAVING fakulte_id=2", bagla2);
            //SqlDataReader dr2 = komut2.ExecuteReader();
            //while (dr2.Read())
            //{

            //    // MessageBox.Show(dr[0].ToString() + " " + dr[1].ToString());
            //    Series s = this.chart1.Series.Add("İktisadi ve İdari Bilimler Fakültesi");
            //    chart1.Series[1].Points.AddXY("İktisadi ve İdari Bilimler Fakültesi", Convert.ToDouble(dr[1]));

            //}
            //bagla2.Close();
            //dr2.Close();
            
        }
    }
}
