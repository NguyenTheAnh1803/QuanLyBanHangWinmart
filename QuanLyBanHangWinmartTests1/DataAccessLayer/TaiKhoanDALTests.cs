using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHangWinmart.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangWinmart.DataAccessLayer.Tests
{
    [TestClass()]
    public class TaiKhoanDALTests
    {
        [TestMethod]
        public void dangNhapTest_Success()
        {
            // Test thành công khi kết quả trả về datatable chứa 1 row
            // Test thất bại khi catch được lỗi
            try
            {
                TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

                int expected = 1;

                DataTable dt = taiKhoanDAL.dangNhap("user1", "password1");
                int actual = dt.Rows.Count;

                Assert.AreEqual(actual, expected);
            }
            catch (SqlException ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void dangNhapTest_User_Not_Exits()
        {
            // Test thành công khi catch được lỗi "Tài khoản không tồn tại!"
            // Test thất bại khi không catch được lỗi
            try
            {
                TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
                DataTable dt = taiKhoanDAL.dangNhap("user21", "password1");
                Assert.Fail();
            }
            catch (SqlException ex)
            {
                string expected = "Tài khoản không tồn tại!";
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestMethod]
        public void dangNhapTest_Password_Incorrect()
        {
            // Test thành công khi catch được lỗi "Mật khẩu không đúng!"
            // Test thất bại khi không catch được lỗi
            try
            {
                TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
                DataTable dt = taiKhoanDAL.dangNhap("user1", "password2");
                Assert.Fail();
            }
            catch (SqlException ex)
            {
                string expected = "Mật khẩu không đúng!";
                Assert.AreEqual(ex.Message, expected);
            }
        }
    }
}