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
    public class HangHoaBLL
    {
        HangHoaDAL hangHoaDAL = new HangHoaDAL();

        public DataTable layTatCaHangHoa()
        {
            try
            {
                return hangHoaDAL.layTatCaHangHoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable layHangHoaTheoLoai(string sMaLoaiHang)
        {
            try
            {
                return hangHoaDAL.layHangHoaTheoLoai(sMaLoaiHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void themHangHoa(string sMaHang, string sTenHang, string fGia, string fSoLuong, string sDonViTinh, DateTime dNSX, DateTime dHSD, string sMaLoaiHang)
        {
            hangHoaDAL.themHangHoa(sMaHang, sTenHang, fGia, fSoLuong, sDonViTinh, dNSX, dHSD, sMaLoaiHang);
        }

        public void suaHangHoa(string sMaHang, string sTenHang, string fGia, string fSoLuong, string sDonViTinh, DateTime dNSX, DateTime dHSD, string sMaLoaiHang)
        {
            hangHoaDAL.suaHangHoa(sMaHang, sTenHang, fGia, fSoLuong, sDonViTinh, dNSX, dHSD, sMaLoaiHang);
        }

        public void xoaHangHoa(string sMaHang)
        {
            hangHoaDAL.xoaHangHoa(sMaHang);
        }

        public DataTable timKiemHangHoa(string maHang, string maLoaiHang, string tenHang, string soLuongStart, string soLuongEnd,
            string donGiaStart, string donGiaEnd, string donViTinh, string nsxStart, string nsxEnd, string hsdStart, string hsdEnd)
        {
            try
            {
                string condition = "";
                if (maHang != "")
                    condition += $"AND sMaHang = '{maHang.Replace("'", "''")}' ";
                if (tenHang != "")
                    condition += $"AND sTenHang LIKE N'%{tenHang.Replace("'", "''")}%' ";
                if (maLoaiHang != "")
                    condition += $"AND sMaLoaiHang = '{maLoaiHang.Replace("'", "''")}' ";
                if (donViTinh != "")
                    condition += $"AND sDonViTinh LIKE N'%{donViTinh.Replace("'", "''")}%' ";
                if (soLuongStart != "")
                    condition += $"AND fSoLuong >= {soLuongStart} ";
                if (soLuongEnd != "")
                    condition += $"AND fSoLuong <= {soLuongEnd} ";
                if (donGiaStart != "")
                    condition += $"AND fGia >= {donGiaStart} ";
                if (donGiaEnd != "")
                    condition += $"AND fGia <= {donGiaEnd} ";
                if (nsxStart != "")
                    condition += $"AND dNSX >= '{nsxStart}' ";
                if (nsxEnd != "")
                    condition += $"AND dNSX <= '{nsxEnd}' ";
                if (hsdStart != "")
                    condition += $"AND dHSD >= '{hsdStart}' ";
                if (hsdEnd != "")
                    condition += $"AND dHSD <= '{hsdEnd}' ";

                return hangHoaDAL.timkiemHangHoa(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
