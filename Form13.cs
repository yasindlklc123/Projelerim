using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace okul_kayıtt
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayıtDataSet.fakulte' table. You can move, or remove it, as needed.
            this.fakulteTableAdapter.Fill(this.kayıtDataSet.fakulte);

        }
    }
}
