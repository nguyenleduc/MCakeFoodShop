using Guna.UI.WinForms;
using MCAKESHOP8;
using MCakeShop9.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCakeShop9.View
{
    public partial class fTableView : SampleView
    {
        public fTableView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From tables where tName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, gunaDataGridView1, lb);

        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            fTableAdd fAdd = new fTableAdd();
            fAdd.ShowDialog();
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                fTableAdd fAdd = new fTableAdd();
                fAdd.id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                fAdd.txtName.Text = Convert.ToString(gunaDataGridView1.CurrentRow.Cells["dgvName"].Value);
                fAdd.ShowDialog();
                GetData();
            }
            if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                // Lấy ID của dòng được chọn
                int id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);

                // Hiển thị hộp thoại cảnh báo
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNoCancel);

                // Xử lý lựa chọn của người dùng
                if (result == DialogResult.Yes)
                {
                    // Người dùng chọn "Yes", thực hiện xóa
                    string qry = "Delete from tables where tID = " + id;
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    MessageBox.Show("Xóa thành công");

                    // Cập nhật dữ liệu
                    GetData();
                }
                else if (result == DialogResult.No)
                {
                    // Người dùng chọn "No", không làm gì cả
                }
                else if (result == DialogResult.Cancel)
                {
                    // Người dùng chọn "Cancel", không làm gì cả
                }
            }
        }

        private void fTableView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng", "Đóng ứng dụng", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
