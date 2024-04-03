USE QuanLyWinMart

-- Xóa tất cả các bảng
DROP TABLE dbo.tblKhachHangThanThiet
DROP TABLE dbo.tblChiTietHDB
DROP TABLE dbo.tblHoaDonBan
DROP TABLE dbo.tblChiTietHDN
DROP TABLE dbo.tblHoaDonNhap
DROP TABLE dbo.tblLoaiHang
DROP TABLE dbo.tblHangHoa
DROP TABLE dbo.tblNhaCungCap
DROP TABLE dbo.tblLoaiTaiKhoan
DROP TABLE dbo.tblTaiKhoan
DROP TABLE dbo.tblNhanVien

-- Xóa dữ liệu tất cả các bảng
DELETE FROM dbo.tblKhachHangThanThiet
DELETE FROM dbo.tblChiTietHDB
DELETE FROM dbo.tblHoaDonBan
DELETE FROM dbo.tblChiTietHDN
DELETE FROM dbo.tblHoaDonNhap
DELETE FROM dbo.tblLoaiHang
DELETE FROM dbo.tblHangHoa
DELETE FROM dbo.tblNhaCungCap
DELETE FROM dbo.tblLoaiTaiKhoan
DELETE FROM dbo.tblTaiKhoan
DELETE FROM dbo.tblNhanVien

-- Hiển thị toàn bộ bảng
SELECT * FROM dbo.tblNhanVien
SELECT * FROM dbo.tblLoaiTaiKhoan
SELECT * FROM dbo.tblTaiKhoan
SELECT * FROM dbo.tblNhaCungCap
SELECT * FROM dbo.tblLoaiHang
SELECT * FROM dbo.tblHangHoa
SELECT * FROM dbo.tblHoaDonNhap
SELECT * FROM dbo.tblChiTietHDN
SELECT * FROM dbo.tblHoaDonBan
SELECT * FROM dbo.tblChiTietHDB
SELECT * FROM dbo.tblKhachHangThanThiet