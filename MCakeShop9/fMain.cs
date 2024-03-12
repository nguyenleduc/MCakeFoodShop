using MCAKESHOP8;
using MCakeShop9;
using MCakeShop9.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCAKESHOP8
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            // Gọi hàm UpdateUserLabel để cập nhật giá trị của lblUser
            UpdateUserLabel();
        }

        // Hàm cập nhật giá trị của lblUser
        private void UpdateUserLabel()
        {
            // Kiểm tra xem biến USER từ MainClass có giá trị không
            if (!string.IsNullOrEmpty(MainClass.USER))
            {
                // Nếu có, hiển thị giá trị của USER trong lblUser
                lblUser.Text = "Xin chào, " + MainClass.USER;
            }
        }

        // Hàm thêm các controls vào CenterPanel
        public void AddControls(Form f)
        {
            GetData();
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        // Xử lý sự kiện click của button Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new fHome());
        }

        // Xử lý sự kiện load của form
        private void fMain_Load(object sender, EventArgs e)
        {
            // Gọi hàm UpdateUserLabel khi form được load
            UpdateUserLabel();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new fCategoryView());
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            AddControls(new fTableView());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new fTableView());
        }

        private void GetData()
        {
        }
        //btn staff click
        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            AddControls(new fStaffView());
        }
        //btn product click
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            AddControls(new fProductView());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            fPOS f = new fPOS();
            f.Show();
        }
    }
}
