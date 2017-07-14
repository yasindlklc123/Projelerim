using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metin_Belgesi
{
    public partial class Hakkında : Form
    {
        public Hakkında()
        {
            InitializeComponent();
        }

        private void Hakkında_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format("Ürün adı :{0}", Application.ProductName);
            label2.Text = string.Format("Ürün Versiyonu :{0}", Application.ProductVersion);
            label3.Text = string.Format("Şirket adı :{0}", Application.CompanyName);
            label4.Text = "Copyright ©  2016";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
