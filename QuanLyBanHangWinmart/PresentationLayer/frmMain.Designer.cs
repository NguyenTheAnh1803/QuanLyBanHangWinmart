namespace QuanLyBanHangWinmart
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGiaoDichBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGiaoDichTraHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTraCuuHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLichSuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoaiHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKhachHangThanThiet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNhapXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHoaDonBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLuanChuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoCaoThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHangTon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDoanhSo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHeThong,
            this.tsmiBanHang,
            this.tsmiDanhMuc,
            this.tsmiNhapXuat,
            this.tsmiBaoCaoThongKe,
            this.tsmiDoiMatKhau});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1312, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiHeThong
            // 
            this.tsmiHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuanLyTaiKhoan,
            this.tsmiDangXuat});
            this.tsmiHeThong.Name = "tsmiHeThong";
            this.tsmiHeThong.Size = new System.Drawing.Size(85, 24);
            this.tsmiHeThong.Text = "Hệ thống";
            // 
            // tsmiQuanLyTaiKhoan
            // 
            this.tsmiQuanLyTaiKhoan.Name = "tsmiQuanLyTaiKhoan";
            this.tsmiQuanLyTaiKhoan.Size = new System.Drawing.Size(224, 26);
            this.tsmiQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.tsmiQuanLyTaiKhoan.Click += new System.EventHandler(this.tsmiQuanLyTaiKhoan_Click);
            // 
            // tsmiDangXuat
            // 
            this.tsmiDangXuat.Name = "tsmiDangXuat";
            this.tsmiDangXuat.Size = new System.Drawing.Size(224, 26);
            this.tsmiDangXuat.Text = "Đăng xuất";
            this.tsmiDangXuat.Click += new System.EventHandler(this.tsmiDangXuat_Click);
            // 
            // tsmiBanHang
            // 
            this.tsmiBanHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGiaoDichBanHang,
            this.tsmiGiaoDichTraHang,
            this.tsmiTraCuuHangHoa,
            this.tsmiLichSuBanHang});
            this.tsmiBanHang.Name = "tsmiBanHang";
            this.tsmiBanHang.Size = new System.Drawing.Size(85, 24);
            this.tsmiBanHang.Text = "Bán hàng";
            // 
            // tsmiGiaoDichBanHang
            // 
            this.tsmiGiaoDichBanHang.Name = "tsmiGiaoDichBanHang";
            this.tsmiGiaoDichBanHang.Size = new System.Drawing.Size(224, 26);
            this.tsmiGiaoDichBanHang.Text = "Giao dịch bán hàng";
            this.tsmiGiaoDichBanHang.Click += new System.EventHandler(this.tsmiGiaoDichBanHang_Click);
            // 
            // tsmiGiaoDichTraHang
            // 
            this.tsmiGiaoDichTraHang.Name = "tsmiGiaoDichTraHang";
            this.tsmiGiaoDichTraHang.Size = new System.Drawing.Size(224, 26);
            this.tsmiGiaoDichTraHang.Text = "Giao dịch trả hàng";
            this.tsmiGiaoDichTraHang.Click += new System.EventHandler(this.tsmiGiaoDichTraHang_Click);
            // 
            // tsmiTraCuuHangHoa
            // 
            this.tsmiTraCuuHangHoa.Name = "tsmiTraCuuHangHoa";
            this.tsmiTraCuuHangHoa.Size = new System.Drawing.Size(224, 26);
            this.tsmiTraCuuHangHoa.Text = "Tra cứu hàng hóa";
            this.tsmiTraCuuHangHoa.Click += new System.EventHandler(this.tsmiTraCuuHangHoa_Click);
            // 
            // tsmiLichSuBanHang
            // 
            this.tsmiLichSuBanHang.Name = "tsmiLichSuBanHang";
            this.tsmiLichSuBanHang.Size = new System.Drawing.Size(224, 26);
            this.tsmiLichSuBanHang.Text = "Lịch sử bán hàng";
            this.tsmiLichSuBanHang.Click += new System.EventHandler(this.tsmiLichSuBanHang_Click);
            // 
            // tsmiDanhMuc
            // 
            this.tsmiDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNhanVien,
            this.tsmiLoaiHang,
            this.tsmiHangHoa,
            this.tsmiNhaCungCap,
            this.tsmiKhachHangThanThiet});
            this.tsmiDanhMuc.Name = "tsmiDanhMuc";
            this.tsmiDanhMuc.Size = new System.Drawing.Size(90, 24);
            this.tsmiDanhMuc.Text = "Danh mục";
            // 
            // tsmiNhanVien
            // 
            this.tsmiNhanVien.Name = "tsmiNhanVien";
            this.tsmiNhanVien.Size = new System.Drawing.Size(236, 26);
            this.tsmiNhanVien.Text = "Nhân viên";
            this.tsmiNhanVien.Click += new System.EventHandler(this.tsmiNhanVien_Click);
            // 
            // tsmiLoaiHang
            // 
            this.tsmiLoaiHang.Name = "tsmiLoaiHang";
            this.tsmiLoaiHang.Size = new System.Drawing.Size(236, 26);
            this.tsmiLoaiHang.Text = "Loại hàng";
            this.tsmiLoaiHang.Click += new System.EventHandler(this.tsmiLoaiHang_Click);
            // 
            // tsmiHangHoa
            // 
            this.tsmiHangHoa.Name = "tsmiHangHoa";
            this.tsmiHangHoa.Size = new System.Drawing.Size(236, 26);
            this.tsmiHangHoa.Text = "Hàng hóa";
            this.tsmiHangHoa.Click += new System.EventHandler(this.tsmiHangHoa_Click);
            // 
            // tsmiNhaCungCap
            // 
            this.tsmiNhaCungCap.Name = "tsmiNhaCungCap";
            this.tsmiNhaCungCap.Size = new System.Drawing.Size(236, 26);
            this.tsmiNhaCungCap.Text = "Nhà cung cấp";
            this.tsmiNhaCungCap.Click += new System.EventHandler(this.tsmiNhaCungCap_Click);
            // 
            // tsmiKhachHangThanThiet
            // 
            this.tsmiKhachHangThanThiet.Name = "tsmiKhachHangThanThiet";
            this.tsmiKhachHangThanThiet.Size = new System.Drawing.Size(236, 26);
            this.tsmiKhachHangThanThiet.Text = "Khách hàng thân thiết";
            this.tsmiKhachHangThanThiet.Click += new System.EventHandler(this.tsmiKhachHangThanThiet_Click);
            // 
            // tsmiNhapXuat
            // 
            this.tsmiNhapXuat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHoaDonBan,
            this.tsmiLuanChuyen});
            this.tsmiNhapXuat.Name = "tsmiNhapXuat";
            this.tsmiNhapXuat.Size = new System.Drawing.Size(134, 24);
            this.tsmiNhapXuat.Text = "Nhập/ xuất hàng";
            // 
            // tsmiHoaDonBan
            // 
            this.tsmiHoaDonBan.Name = "tsmiHoaDonBan";
            this.tsmiHoaDonBan.Size = new System.Drawing.Size(224, 26);
            this.tsmiHoaDonBan.Text = "Nhập hàng";
            this.tsmiHoaDonBan.Click += new System.EventHandler(this.tsmiHoaDonBan_Click);
            // 
            // tsmiLuanChuyen
            // 
            this.tsmiLuanChuyen.Name = "tsmiLuanChuyen";
            this.tsmiLuanChuyen.Size = new System.Drawing.Size(224, 26);
            this.tsmiLuanChuyen.Text = "Luân chuyển";
            this.tsmiLuanChuyen.Click += new System.EventHandler(this.tsmiLuanChuyen_Click);
            // 
            // tsmiBaoCaoThongKe
            // 
            this.tsmiBaoCaoThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHangTon,
            this.tsmiDoanhSo});
            this.tsmiBaoCaoThongKe.Name = "tsmiBaoCaoThongKe";
            this.tsmiBaoCaoThongKe.Size = new System.Drawing.Size(139, 24);
            this.tsmiBaoCaoThongKe.Text = "Báo cáo thống kê";
            this.tsmiBaoCaoThongKe.Click += new System.EventHandler(this.tsmiBaoCaoThongKe_Click);
            // 
            // tsmiHangTon
            // 
            this.tsmiHangTon.Name = "tsmiHangTon";
            this.tsmiHangTon.Size = new System.Drawing.Size(224, 26);
            this.tsmiHangTon.Text = "Hàng tồn";
            this.tsmiHangTon.Click += new System.EventHandler(this.tsmiHangTon_Click);
            // 
            // tsmiDoanhSo
            // 
            this.tsmiDoanhSo.Name = "tsmiDoanhSo";
            this.tsmiDoanhSo.Size = new System.Drawing.Size(224, 26);
            this.tsmiDoanhSo.Text = "Doanh số";
            this.tsmiDoanhSo.Click += new System.EventHandler(this.tsmiDoanhSo_Click);
            // 
            // tsmiDoiMatKhau
            // 
            this.tsmiDoiMatKhau.Name = "tsmiDoiMatKhau";
            this.tsmiDoiMatKhau.Size = new System.Drawing.Size(112, 24);
            this.tsmiDoiMatKhau.Text = "Đổi mật khẩu";
            this.tsmiDoiMatKhau.Click += new System.EventHandler(this.tsmiDoiMatKhau_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán hàng WinMart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeThong;
        private System.Windows.Forms.ToolStripMenuItem tsmiDangXuat;
        private System.Windows.Forms.ToolStripMenuItem tsmiDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem tsmiNhapXuat;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaoCaoThongKe;
        private System.Windows.Forms.ToolStripMenuItem tsmiHoaDonBan;
        private System.Windows.Forms.ToolStripMenuItem tsmiLuanChuyen;
        private System.Windows.Forms.ToolStripMenuItem tsmiNhanVien;
        private System.Windows.Forms.ToolStripMenuItem tsmiNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem tsmiBanHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiGiaoDichBanHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiGiaoDichTraHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiTraCuuHangHoa;
        private System.Windows.Forms.ToolStripMenuItem tsmiLichSuBanHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiHangHoa;
        private System.Windows.Forms.ToolStripMenuItem tsmiKhachHangThanThiet;
        private System.Windows.Forms.ToolStripMenuItem tsmiHangTon;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoanhSo;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoaiHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoiMatKhau;
    }
}