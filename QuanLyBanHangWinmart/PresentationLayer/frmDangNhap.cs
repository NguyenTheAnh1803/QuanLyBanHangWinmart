using QuanLyBanHangWinmart.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart
{
    public partial class frmDangNhap : Form
    {
        DangNhapBLL dangNhapBLL = new DangNhapBLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraDangNhap())
                {
                    DataTable dt = dangNhapBLL.dangNhap(txtTenDangNhap.Text, mtxtMatKhau.Text);
                    Program.nhanvien = new NhanVien(
                        (string)dt.Rows[0]["sMaNV"],
                        (string)dt.Rows[0]["sTenNV"],
                        (string)dt.Rows[0]["sTenLoaiTK"]
                    );
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    Close(); 
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    lblLoi.Text = error.Message;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KiemTraDangNhap()
        {
            lblLoi.Text = ""; 

            if (txtTenDangNhap.Text.Trim() == "")
            {
                lblLoi.Text = "Vui lòng nhập tài khoản.";
                txtTenDangNhap.Focus();
                return false;
            }

            if (mtxtMatKhau.Text.Trim() == "")
            {
                lblLoi.Text = "Vui lòng nhập mật khẩu.";
                mtxtMatKhau.Focus();
                return false;
            } 

            return true;
        }
    }
}
