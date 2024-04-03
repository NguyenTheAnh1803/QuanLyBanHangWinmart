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
    public class LoaiHangHoaDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QuanLyWinMart"].ConnectionString;

        public DataTable layTatCaLoaiHang()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prLayTatCaLoaiHang", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblLoaiHang");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable layMaLoaiHang()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prLayMaLoaiHang", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("MaLoaiHang");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void themLoaiHang(string sMaLoaiHang, string sTenLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prThemLoaiHang", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    cm.Parameters.AddWithValue("@TenLoaiHang", sTenLoaiHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public void suaLoaiHang(string sMaLoaiHang, string sTenLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prSuaLoaiHang", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    cm.Parameters.AddWithValue("@TenLoaiHang", sTenLoaiHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public void xoaLoaiHang(string sMaLoaiHang)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand("prXoaLoaiHang", con))
                {
                    con.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@MaLoaiHang", sMaLoaiHang);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public DataTable timkiemHangHoa(string condition)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT * FROM dbo.tblLoaiHang
		            WHERE 1=1 {condition}"
                    , con))
                {
                    con.Open();
                    cm.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblLoaiHangTimKiem");
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
