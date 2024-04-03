USE QuanLyWinMart
/*CREATE TABLE*/
--Tạo bảng Nhân viên
GO
CREATE TABLE tblNhanVien (
    sMaNV VARCHAR(10) NOT NULL,
    sTenNV NVARCHAR(70) NOT NULL,
    bGioiTinh BIT NOT NULL,
	sQueQuan NVARCHAR(255) NOT NULL,
	dNgaySinh DATE NOT NULL,
	dNgayVaoLam DATE NOT NULL,
	sSDT VARCHAR(15) NOT NULL,
	bTrangThai BIT NOT NULL,
    CONSTRAINT PK_tblNhanVien PRIMARY KEY(sMaNV),
	CONSTRAINT CHK_dNgayVaoLam CHECK (dNgayVaoLam <= GETDATE()),
	CONSTRAINT CHK_du18Tuoi CHECK (dNgayVaoLam >= DATEADD(YEAR, 18, dNgaySinh))
)

--Tạo bảng Loại tài khoản
GO
CREATE TABLE tblLoaiTaiKhoan (
    sMaLoaiTK VARCHAR(10) NOT NULL,
    sTenLoaiTK NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblLoaiTaiKhoan PRIMARY KEY(sMaLoaiTK)
)

--Tạo bảng Tài khoản
GO
CREATE TABLE tblTaiKhoan (
    sMaTK VARCHAR(10) NOT NULL,
    sTenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    sMatKhau VARCHAR(50) NOT NULL,
	sMaNV VARCHAR(10) NOT NULL,
	sMaLoaiTK VARCHAR(10) NOT NULL,
    CONSTRAINT PK_tblTaiKhoan PRIMARY KEY(sMaTK),
	CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES dbo.tblNhanVien(sMaNV),
	CONSTRAINT FK_TaiKhoan_LoaiTaiKhoan FOREIGN KEY(sMaLoaiTK)
	REFERENCES dbo.tblLoaiTaiKhoan(sMaLoaiTK),
	CONSTRAINT CHK_sMatKhau CHECK (LEN(sMatKhau) >= 6)
)

--Tạo bảng Nhà cung cấp
GO
CREATE TABLE tblNhaCungCap (
    sMaNCC VARCHAR(10) NOT NULL,
    sTenNCC NVARCHAR(255) NOT NULL,
    sDiaChi NVARCHAR(255) NOT NULL,
	sSDT VARCHAR(15) NOT NULL
    CONSTRAINT PK_tblNhaCungCap PRIMARY KEY(sMaNCC)
)

--Tạo bảng Loại hàng
GO
CREATE TABLE tblLoaiHang (
    sMaLoaiHang VARCHAR(10) NOT NULL,
    sTenLoaiHang NVARCHAR(100) NOT NULL UNIQUE,
    CONSTRAINT PK_tblLoaiHang PRIMARY KEY(sMaLoaiHang)
)

--Tạo bảng Hàng hóa
GO
CREATE TABLE tblHangHoa (
    sMaHang VARCHAR(10) NOT NULL,
    sTenHang NVARCHAR(100) NOT NULL,
    fGia FLOAT NOT NULL,
	fSoLuong FLOAT NOT NULL,
	sDonViTinh NVARCHAR(50) NOT NULL,
	dNSX DATE NOT NULL,
	dHSD DATE NOT NULL,
	sMaLoaiHang VARCHAR(10) NOT NULL,
	CONSTRAINT CHK_fGia CHECK (fGia > 0),
	CONSTRAINT CHK_fSoLuong CHECK (fSoLuong >= 0),
	CONSTRAINT CHK_dNSX CHECK (dNSX <= GETDATE()),
	CONSTRAINT CHK_dHSD CHECK (dHSD >= dNSX),
    CONSTRAINT PK_tblHangHoa PRIMARY KEY(sMaHang),
	CONSTRAINT FK_HangHoa_LoaiHang FOREIGN KEY(sMaLoaiHang)
	REFERENCES dbo.tblLoaiHang(sMaLoaiHang)
)

--Tạo bảng Hóa đơn nhập
GO
CREATE TABLE tblHoaDonNhap (
    sMaHDNhap VARCHAR(10) NOT NULL,
    dNgayLap DATE NOT NULL,
    fTongTien FLOAT NOT NULL,
	bTrangThai BIT NOT NULL,
	sMaNV VARCHAR(10) NOT NULL,
	sMaNCC VARCHAR(10) NOT NULL,
    CONSTRAINT PK_tblHoaDonNhap PRIMARY KEY(sMaHDNhap),
	CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES dbo.tblNhanVien(sMaNV),
	CONSTRAINT FK_HoaDonNhap_NhaCungCap FOREIGN KEY(sMaNCC)
	REFERENCES dbo.tblNhaCungCap(sMaNCC)
)

--Tạo bảng Chi tiết hóa đơn nhập
GO
CREATE TABLE tblChiTietHDN (
    sMaHDNhap VARCHAR(10) NOT NULL,
    sMaHang VARCHAR(10) NOT NULL,
    fSoLuongNhap FLOAT NOT NULL,
	fGiaNhap FLOAT NOT NULL,
    CONSTRAINT FK_CT_HoaDonNhap_HoaDonNhap FOREIGN KEY(sMaHDNhap)
    REFERENCES dbo.tblHoaDonNhap(sMaHDNhap),
	CONSTRAINT FK_CT_HoaDonNhap_HangHoa FOREIGN KEY(sMaHang)
	REFERENCES dbo.tblHangHoa(sMaHang)
)

--Tạo bảng Hóa đơn bán
GO
CREATE TABLE tblHoaDonBan (
    sMaHDBan VARCHAR(10) NOT NULL,
    dNgayLap DATE NOT NULL,
    fTongTien FLOAT NOT NULL,
	bTrangThai BIT NOT NULL,
	sMaNV VARCHAR(10) NOT NULL,
    CONSTRAINT PK_tblHoaDonBan PRIMARY KEY(sMaHDBan),
	CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES dbo.tblNhanVien(sMaNV)
)

--Tạo bảng Chi tiết hóa đơn bán
GO
CREATE TABLE tblChiTietHDB (
    sMaHDBan VARCHAR(10) NOT NULL,
    sMaHang VARCHAR(10) NOT NULL,
    fSoLuongBan FLOAT NOT NULL,
    CONSTRAINT FK_CT_HoaDonBan_HoaDonBan FOREIGN KEY(sMaHDBan)
    REFERENCES dbo.tblHoaDonBan(sMaHDBan),
	CONSTRAINT FK_CT_HoaDonBan_HangHoa FOREIGN KEY(sMaHang)
	REFERENCES dbo.tblHangHoa(sMaHang)
)

--Tạo bảng Khách hàng thân thiết
GO
CREATE TABLE tblKhachHangThanThiet (
    sMaKH VARCHAR(10) NOT NULL,
    sTenKH NVARCHAR(255) NOT NULL,
    sSDT VARCHAR(15) NOT NULL,
    CONSTRAINT PK_tblKhachHangThanThiet PRIMARY KEY(sMaKH)
)