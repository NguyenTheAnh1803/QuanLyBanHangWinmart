using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart.DataAccessLayer
{
    public class TaiKhoanDAL
    {
        public DataTable dangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyWinMart"].ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("prDangNhap", con))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cm.Parameters.AddWithValue("@MatKhau", matKhau);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataTable dt = new DataTable("tblDangNhap");
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
