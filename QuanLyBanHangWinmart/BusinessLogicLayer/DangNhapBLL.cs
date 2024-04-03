using QuanLyBanHangWinmart.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangWinmart.BusinessLogicLayer
{
    public class DangNhapBLL
    {
        TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public DataTable dangNhap(string tenDangNhap, string matKhau)
        {
            return taiKhoanDAL.dangNhap(tenDangNhap, matKhau);
        }
    }
}
