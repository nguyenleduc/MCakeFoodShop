using MCAKESHOP8;
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

namespace MCakeShop9.Model
{
    public partial class fStaffAdd : SampleAdd
    {
        public fStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)   //Insert
            {
                qry = "INSERT INTO staff (sName, sPhone, sRole) VALUES (@Name, @phone, @role)";
            }
            else //Update
            {
                qry = "UPDATE staff SET sName = @Name, sPhone = @phone, sRole = @role WHERE staffID = @id";
            }


            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);

            try
            {
                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Lưu thành công.");
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                    cbRole.SelectedIndex = -1;
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

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
