using MCAKESHOP8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCakeShop9.Model
{
    public partial class fProductAdd : SampleAdd
    {
        public fProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;
        private void fProductAdd_Load(object sender, EventArgs e)
        {
            //for cb fill

            string qry = "Select catID 'id' , catName 'name' from category";
            MainClass.CBFill(qry,cbCat);

            if(cID > 0)//for update
            {
                cbCat.SelectedValue = cID;
            }
        }

        string filePath;
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            // Trong phương thức btnSave_Click
            if (id == 0)   //Insert
            {
                qry = "INSERT INTO products (pName, pPrice, CategoryID, pImage) VALUES (@Name, @Price, @cat, @img)";
            }
            else //Update
            {
                if (filePath != null)  // Kiểm tra nếu có hình ảnh mới được chọn
                {
                    qry = "UPDATE products SET pName = @Name, pPrice = @Price, CategoryID = @cat, pImage = @img WHERE pID = @id";
                }
                else  // Nếu không có hình ảnh mới được chọn, chỉ cập nhật thông tin sản phẩm không cập nhật hình ảnh
                {
                    qry = "UPDATE products SET pName = @Name, pPrice = @Price, CategoryID = @cat WHERE pID = @id";
                }
            }


            //For image
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@price", txtPrice.Text);
            ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img", imageByteArray);

            try
            {
                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Lưu thành công.");
                    id = 0;
                    txtName.Text = "";
                    txtPrice.Text = "";
                    cbCat.SelectedIndex = -1;
                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show("Lưu không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


    }
}
