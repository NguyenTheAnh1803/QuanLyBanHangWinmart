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
    class LoaiHangHoaBLL
    {
        LoaiHangHoaDAL loaiHangHoaDAL = new LoaiHangHoaDAL();

        public DataTable layTatCaLoaiHang()
        {
            try
            {
                return loaiHangHoaDAL.layTatCaLoaiHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable layMaLoaiHang()
        {
            try
            {
                return loaiHangHoaDAL.layMaLoaiHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void themLoaiHang(string sMaLoaiHang, string sTenLoaiHang)
        {
            loaiHangHoaDAL.themLoaiHang(sMaLoaiHang, sTenLoaiHang);
        }

        public void suaLoaiHang(string sMaLoaiHang, string sTenLoaiHang)
        {
            loaiHangHoaDAL.suaLoaiHang(sMaLoaiHang, sTenLoaiHang);
        }

        public void xoaLoaiHang(string sMaLoaiHang)
        {
            loaiHangHoaDAL.xoaLoaiHang(sMaLoaiHang);
        }

        public DataTable timKiemLoaiHang(string sMaLoaiHang, string sTenLoaiHang)
        {
            try
            {
                string condition = "";

                if (sMaLoaiHang != "")
                    condition += $"AND sMaLoaiHang = '{sMaLoaiHang.Replace("'", "''")}' ";
                if (sTenLoaiHang != "")
                    condition += $"AND sTenLoaiHang LIKE N'%{sTenLoaiHang.Replace("'", "''")}%' ";

                return loaiHangHoaDAL.timkiemHangHoa(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
