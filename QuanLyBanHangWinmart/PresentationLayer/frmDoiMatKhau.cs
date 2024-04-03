using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHangWinmart.PresentationLayer
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JCE3KO8\SQLEXPRESS;Initial Catalog=QuanLyWinMart;Integrated Security=True");

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();

                string queryCheckUser = "SELECT COUNT(*) FROM tblTaiKhoan WHERE sTenDangNhap = @UserName AND sMatKhau = @OldPassword";
                SqlCommand cmdCheckUser = new SqlCommand(queryCheckUser, cn);
                cmdCheckUser.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmdCheckUser.Parameters.AddWithValue("@OldPassword", txtMatKhau.Text);

                int userCount = (int)cmdCheckUser.ExecuteScalar();

                if (userCount == 1)
                {
                    if (txtMatKhauMoi.Text == txtNhaplaimatkhaumoi.Text)
                    {
                        string queryUpdatePassword = "UPDATE tblTaiKhoan SET sMatKhau = @NewPassword WHERE sTenDangNhap = @UserName AND sMatKhau = @OldPassword";
                        SqlCommand cmdUpdatePassword = new SqlCommand(queryUpdatePassword, cn);
                        cmdUpdatePassword.Parameters.AddWithValue("@NewPassword", txtMatKhauMoi.Text);
                        cmdUpdatePassword.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmdUpdatePassword.Parameters.AddWithValue("@OldPassword", txtMatKhau.Text);

                        cmdUpdatePassword.ExecuteNonQuery();

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.ShowDialog();
                        Close();


                    }
                    else
                    {
                        errorProvider1.SetError(txtNhaplaimatkhaumoi, "Mật khẩu nhập lại không khớp");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtUserName, "Tên người dùng hoặc mật khẩu không đúng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
               
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            Close();
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
