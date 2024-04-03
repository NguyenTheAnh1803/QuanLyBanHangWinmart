using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart
{
    internal static class Program
    {
        public static NhanVien nhanvien = new NhanVien();
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }

    class NhanVien
    {
        public NhanVien()
        {
        }

        public NhanVien(string ma, string ten, string loaiTK)
        {
            Ma = ma;
            Ten = ten;
            LoaiTK = loaiTK;
        }

        public string Ma { get; set; }
        public string Ten { get; set; }
        public string LoaiTK { get; set; }
    }
}
