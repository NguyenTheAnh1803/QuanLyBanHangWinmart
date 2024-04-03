using QuanLyBanHangWinmart.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsmiQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDangXuat_Click(object sender, EventArgs e)
        {
            Program.nhanvien = new NhanVien();
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            Close();
        }

        private void tsmiGiaoDichBanHang_Click(object sender, EventArgs e)
        {

        }

        private void tsmiGiaoDichTraHang_Click(object sender, EventArgs e)
        {

        }

        private void tsmiTraCuuHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void tsmiLichSuBanHang_Click(object sender, EventArgs e)
        {

        }

        private void tsmiNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiLoaiHang_Click(object sender, EventArgs e)
        {
            frmLoaiHang frm = new frmLoaiHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiHangHoa_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiNhaCungCap_Click(object sender, EventArgs e)
        {

        }

        private void tsmiKhachHangThanThiet_Click(object sender, EventArgs e)
        {

        }

        private void tsmiHoaDonBan_Click(object sender, EventArgs e)
        {

        }

        private void tsmiLuanChuyen_Click(object sender, EventArgs e)
        {

        }

        private void tsmiHangTon_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDoanhSo_Click(object sender, EventArgs e)
        {

        }

     

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmiBaoCaoThongKe_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
            Close();

        }
    }
}
