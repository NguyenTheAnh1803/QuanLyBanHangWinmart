using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangWinmart.DataAccessLayer
{
    public class HangHoaDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanLyWinMart"].ConnectionString;

        public DataTable layTatCaHangHoa()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prLayTatCaHangHoa", con))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblHangHoa");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable layHangHoaTheoLoai(string sMaLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prLayHangHoaTheoLoai", con))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblHangHoaTheoLoai");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void themHangHoa(string sMaHang, string sTenHang, string fGia, string fSoLuong, string sDonViTinh, DateTime dNSX, DateTime dHSD, string sMaLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prThemHangHoa", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaHang", sMaHang);
                    cm.Parameters.AddWithValue("@TenHang", sTenHang);
                    cm.Parameters.AddWithValue("@Gia", fGia);
                    cm.Parameters.AddWithValue("@SoLuong", fSoLuong);
                    cm.Parameters.AddWithValue("@DonViTinh", sDonViTinh);
                    cm.Parameters.AddWithValue("@NSX", dNSX);
                    cm.Parameters.AddWithValue("@HSD", dHSD);
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public void suaHangHoa(string sMaHang, string sTenHang, string fGia, string fSoLuong, string sDonViTinh, DateTime dNSX, DateTime dHSD, string sMaLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prSuaHangHoa", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaHang", sMaHang);
                    cm.Parameters.AddWithValue("@TenHang", sTenHang);
                    cm.Parameters.AddWithValue("@Gia", fGia);
                    cm.Parameters.AddWithValue("@SoLuong", fSoLuong);
                    cm.Parameters.AddWithValue("@DonViTinh", sDonViTinh);
                    cm.Parameters.AddWithValue("@NSX", dNSX);
                    cm.Parameters.AddWithValue("@HSD", dHSD);
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public void xoaHangHoa(string sMaHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prXoaHangHoa", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaHang", sMaHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public DataTable timkiemHangHoa(string condition)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT * FROM dbo.tblHangHoa
		            WHERE 1=1 {condition}"
                    , con))
                {
                    con.Open();
                    cm.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblHangHoaTimKiem");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
