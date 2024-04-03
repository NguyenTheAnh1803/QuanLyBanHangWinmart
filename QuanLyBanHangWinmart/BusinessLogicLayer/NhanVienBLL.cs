using QuanLyBanHangWinmart.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart.BusinessLogicLayer
{
    public class NhanVienBLL
    {
        NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public DataTable getALLNhanVien()
        {
            try
            {
                return nhanVienDAL.getALLNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void themNhanVien(string sMaNV, string sTenNV, bool bGioiTinh, string sQueQuan, DateTime dNgaySinh, DateTime dNgayVaoLam, string sSDT, bool bTrangThai)
        {
            nhanVienDAL.themNhanVien(sMaNV, sTenNV, bGioiTinh, sQueQuan, dNgaySinh, dNgayVaoLam, sSDT, bTrangThai);
        }

        public void suaNhanVien(string sMaNV, string sTenNV, bool bGioiTinh, string sQueQuan, DateTime dNgaySinh, DateTime dNgayVaoLam, string sSDT, bool bTrangThai)
        {
            nhanVienDAL.suaNhanVien(sMaNV, sTenNV, bGioiTinh, sQueQuan, dNgaySinh, dNgayVaoLam, sSDT, bTrangThai);
        }

        public void xoaNhanVien(string sMaNV)
        {
            nhanVienDAL.xoaNhanVien(sMaNV);
        }

        public string taoMaNhanVien()
        {
            try
            {
                return nhanVienDAL.taoMaNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo mã nhân viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public DataTable timKiemNhanVien(string maNV, string tenNV, string gioiTinh, string queQuan, string ngaySinhStart, string ngaySinhEnd,
            string ngayVaoLamStart, string ngayVaoLamEnd, string sdt, string trangThai)
        {
            try
            {
                string condition = "";

                if (maNV != "")
                    condition += $"AND sMaNV = '{maNV.Replace("'", "''")}' ";
                if (tenNV != "")
                    condition += $"AND sTenNV LIKE N'%{tenNV.Replace("'", "''")}%' ";
                if (gioiTinh != "")
                    condition += $"AND bGioiTinh = {(gioiTinh == "Nam" ? "1" : "0")} ";
                if (queQuan != "")
                    condition += $"AND sQueQuan LIKE N'%{queQuan.Replace("'", "''")}%' ";
                if (ngaySinhStart != "")
                    condition += $"AND dNgaySinh >= '{ngaySinhStart}' ";
                if (ngaySinhEnd != "")
                    condition += $"AND dNgaySinh <= '{ngaySinhEnd}' ";
                if (ngayVaoLamStart != "")
                    condition += $"AND dNgayVaoLam >= '{ngayVaoLamStart}' ";
                if (ngayVaoLamEnd != "")
                    condition += $"AND dNgayVaoLam <= '{ngayVaoLamEnd}' ";
                if (sdt != "")
                    condition += $"AND sSDT LIKE '%{sdt.Replace("'", "''")}%' ";
                if (trangThai != "")
                    condition += $"AND bTrangThai = {(trangThai == "Đang làm" ? "1" : "0")} ";

                return nhanVienDAL.timkiemNhanVien(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
