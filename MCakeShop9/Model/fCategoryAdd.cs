using MCAKESHOP8;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace MCakeShop9.Model
{
    public partial class fCategoryAdd : SampleAdd
    {
        public fCategoryAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)   //Insert
            {
                qry = "INSERT INTO category (catName) VALUES (@Name)";

            }
            else //Update
            {
                qry = "UPDATE category SET catName = @Name where catID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            
            try
            {
                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Lưu thành công.");
                    id = 0;
                    txtName.Text = "";
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
