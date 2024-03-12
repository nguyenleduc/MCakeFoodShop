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
using System.Xml.Linq;

namespace MCakeShop9.View
{
    public partial class fCategoryView : SampleView
    {
        public fCategoryView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From category where catName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, gunaDataGridView1, lb);

        }
        private void fCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            fCategoryAdd fAdd = new fCategoryAdd();
            fAdd.ShowDialog();
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                fCategoryAdd fAdd = new fCategoryAdd();
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
                    string qry = "Delete from category where catID = " + id;
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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

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
