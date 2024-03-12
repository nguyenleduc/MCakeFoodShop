using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCakeShop9
{
    public partial class fPOS : Form
    {
        public fPOS()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fPOS_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
