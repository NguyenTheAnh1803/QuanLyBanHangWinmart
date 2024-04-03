USE QuanLyWinMart
--Thêm dữ liệu (Cho con trỏ chuột vào đầu dòng -> bấm ctrl shift end -> f5 để thêm dữ liệu)
--NhanVien
INSERT INTO tblNhanVien (sMaNV, sTenNV, bGioiTinh, sQueQuan, dNgaySinh, dNgayVaoLam, sSDT, bTrangThai)
VALUES
('NV001', N'Trần Văn A', 1, N'Hà Nội', '1990-01-01', '2020-01-01', '0123456789', 1),
('NV002', N'Nguyễn Thị B', 0, N'Hồ Chí Minh', '1995-02-03', '2019-05-10', '0987654321', 1),
('NV003', N'Lê Văn C', 1, N'Đà Nẵng', '1985-11-15', '2021-03-20', '0912345678', 1),
('NV004', N'Phạm Thị D', 0, N'Hải Phòng', '1992-07-29', '2018-09-30', '0845678901', 1),
('NV005', N'Vũ Văn E', 1, N'Hưng Yên', '1998-06-12', '2022-07-05', '0765432198', 1),
('NV006', N'Đinh Thị F', 0, N'Đồng Nai', '1993-03-25', '2017-11-11', '0956789012', 0),
('NV007', N'Lý Văn G', 1, N'Thanh Hóa', '1988-08-08', '2023-02-14', '0912345678', 1),
('NV008', N'Huỳnh Thị H', 0, N'Bình Dương', '1996-09-17', '2016-04-25', '0987654321', 0),
('NV009', N'Đặng Văn I', 1, N'Nam Định', '1991-04-05', '2023-08-18', '0123456789', 1),
('NV010', N'Trương Thị K', 0, N'Cần Thơ', '1994-12-20', '2015-12-31', '0845678901', 1);

SELECT * FROM dbo.tblNhanVien

--LoaiTaiKhoan
INSERT INTO tblLoaiTaiKhoan (sMaLoaiTK, sTenLoaiTK)
VALUES
('LTK001', N'Quản lý'),
('LTK002', N'Nhân viên bán hàng'),
('LTK003', N'Kế toán'),
('LTK004', N'Quản lý kho')

SELECT * FROM dbo.tblLoaiTaiKhoan

--TaiKhoan
INSERT INTO tblTaiKhoan (sMaTK, sTenDangNhap, sMatKhau, sMaNV, sMaLoaiTK)
VALUES
('TK001', N'user1', 'password1', 'NV001', 'LTK001'),
('TK002', N'user2', 'password2', 'NV002', 'LTK002'),
('TK003', N'user3', 'password3', 'NV003', 'LTK001'),
('TK004', N'user4', 'password4', 'NV004', 'LTK002'),
('TK005', N'user5', 'password5', 'NV005', 'LTK001'),
('TK006', N'user6', 'password6', 'NV006', 'LTK002'),
('TK007', N'user7', 'password7', 'NV007', 'LTK001'),
('TK008', N'user8', 'password8', 'NV008', 'LTK002'),
('TK009', N'user9', 'password9', 'NV009', 'LTK001'),
('TK010', N'user10', 'password10', 'NV010', 'LTK002');

SELECT * FROM dbo.tblTaiKhoan

--NhaCungCap
INSERT INTO tblNhaCungCap (sMaNCC, sTenNCC, sDiaChi, sSDT)
VALUES
('NCC001', N'Nhà cung cấp A', N'Hà Nội', '0123456789'),
('NCC002', N'Nhà cung cấp B', N'Hồ Chí Minh', '0987654321'),
('NCC003', N'Nhà cung cấp C', N'Đà Nẵng', '0912345678'),
('NCC004', N'Nhà cung cấp D', N'Hải Phòng', '0845678901'),
('NCC005', N'Nhà cung cấp E', N'Hưng Yên', '0765432198'),
('NCC006', N'Nhà cung cấp F', N'Đồng Nai', '0956789012'),
('NCC007', N'Nhà cung cấp G', N'Thanh Hóa', '0912345678'),
('NCC008', N'Nhà cung cấp H', N'Bình Dương', '0987654321'),
('NCC009', N'Nhà cung cấp I', N'Nam Định', '0123456789'),
('NCC010', N'Nhà cung cấp K', N'Cần Thơ', '0845678901');

SELECT * FROM dbo.tblNhaCungCap

--LoaiHang
INSERT INTO tblLoaiHang (sMaLoaiHang, sTenLoaiHang)
VALUES
('LH001', N'Loại hàng 1'),
('LH002', N'Loại hàng 2'),
('LH003', N'Loại hàng 3'),
('LH004', N'Loại hàng 4'),
('LH005', N'Loại hàng 5'),
('LH006', N'Loại hàng 6'),
('LH007', N'Loại hàng 7'),
('LH008', N'Loại hàng 8'),
('LH009', N'Loại hàng 9'),
('LH010', N'Loại hàng 10');

SELECT * FROM dbo.tblLoaiHang

--HangHoa
INSERT INTO tblHangHoa (sMaHang, sTenHang, fGia, fSoLuong, sDonViTinh, dNSX, dHSD, sMaLoaiHang)
VALUES
('HH001', N'Hàng hóa 1', 1000000, 50, N'Cái', '2023-09-01', '2023-12-01', 'LH001'),
('HH002', N'Hàng hóa 2', 500000, 30, N'Hộp', '2023-09-02', '2024-03-01', 'LH002'),
('HH003', N'Hàng hóa 3', 2000000, 20, N'Cái', '2023-09-03', '2023-11-01', 'LH003'),
('HH004', N'Hàng hóa 4', 1500000, 40, N'Cái', '2023-09-04', '2024-02-01', 'LH001'),
('HH005', N'Hàng hóa 5', 800000, 35, N'Hộp', '2023-09-05', '2023-10-01', 'LH002'),
('HH006', N'Hàng hóa 6', 1200000, 25, N'Cái', '2023-09-06', '2024-01-01', 'LH003'),
('HH007', N'Hàng hóa 7', 1800000, 15, N'Cái', '2023-09-07', '2023-12-01', 'LH001'),
('HH008', N'Hàng hóa 8', 900000, 18, N'Hộp', '2023-09-08', '2024-03-01', 'LH002'),
('HH009', N'Hàng hóa 9', 2500000, 10, N'Cái', '2023-09-09', '2023-11-01', 'LH003'),
('HH010', N'Hàng hóa 10', 3000000, 12, N'Hộp', '2023-09-10', '2024-02-01', 'LH001');

SELECT * FROM dbo.tblHangHoa

--HoaDonNhap
INSERT INTO tblHoaDonNhap (sMaHDNhap, dNgayLap, fTongTien, bTrangThai, sMaNV, sMaNCC)
VALUES
('HDN001', '2023-09-01', 5000000, 1, 'NV001', 'NCC001'),
('HDN002', '2023-09-02', 3500000, 1, 'NV002', 'NCC002'),
('HDN003', '2023-09-03', 4000000, 1, 'NV003', 'NCC003'),
('HDN004', '2023-09-04', 4500000, 1, 'NV001', 'NCC004'),
('HDN005', '2023-09-05', 3800000, 1, 'NV002', 'NCC005'),
('HDN006', '2023-09-06', 5500000, 1, 'NV003', 'NCC006'),
('HDN007', '2023-09-07', 4200000, 1, 'NV001', 'NCC007'),
('HDN008', '2023-09-08', 4900000, 1, 'NV002', 'NCC008'),
('HDN009', '2023-09-09', 5100000, 1, 'NV003', 'NCC009'),
('HDN010', '2023-09-10', 4300000, 1, 'NV001', 'NCC010');

SELECT * FROM dbo.tblHoaDonNhap

--ChiTietHDN
INSERT INTO tblChiTietHDN (sMaHDNhap, sMaHang, fSoLuongNhap, fGiaNhap)
VALUES
('HDN001', 'HH001', 50, 900000),
('HDN002', 'HH002', 30, 500000),
('HDN003', 'HH003', 20, 1500000),
('HDN004', 'HH004', 40, 1200000),
('HDN005', 'HH005', 35, 800000),
('HDN006', 'HH006', 25, 1100000),
('HDN007', 'HH007', 15, 1700000),
('HDN008', 'HH008', 18, 950000),
('HDN009', 'HH009', 10, 2300000),
('HDN010', 'HH010', 12, 2800000);

SELECT * FROM dbo.tblChiTietHDN

--HoaDonBan
INSERT INTO tblHoaDonBan (sMaHDBan, dNgayLap, fTongTien, bTrangThai, sMaNV)
VALUES
('HDB001', '2023-09-01', 5000000, 1, 'NV001'),
('HDB002', '2023-09-02', 7500000, 1, 'NV002'),
('HDB003', '2023-09-03', 3000000, 1, 'NV003'),
('HDB004', '2023-09-04', 2000000, 1, 'NV004'),
('HDB005', '2023-09-05', 6000000, 1, 'NV005'),
('HDB006', '2023-09-06', 3500000, 1, 'NV006'),
('HDB007', '2023-09-07', 4000000, 1, 'NV007'),
('HDB008', '2023-09-08', 4500000, 1, 'NV008'),
('HDB009', '2023-09-09', 2500000, 1, 'NV009'),
('HDB010', '2023-09-10', 8000000, 1, 'NV010');

SELECT * FROM dbo.tblHoaDonBan

--ChiTietHDB
INSERT INTO tblChiTietHDB (sMaHDBan, sMaHang, fSoLuongBan)
VALUES
('HDB001', 'HH001', 5),
('HDB002', 'HH002', 3),
('HDB003', 'HH003', 2.5),
('HDB004', 'HH004', 1),
('HDB005', 'HH005', 7),
('HDB006', 'HH006', 4),
('HDB007', 'HH007', 2),
('HDB008', 'HH008', 3.5),
('HDB009', 'HH009', 2),
('HDB010', 'HH010', 6);

SELECT * FROM dbo.tblChiTietHDB

--KhachHangThanThiet
INSERT INTO tblKhachHangThanThiet (sMaKH, sTenKH, sSDT)
VALUES
('KH001', N'Nguyễn Văn A', '0123456789'),
('KH002', N'Trần Thị B', '0987654321'),
('KH003', N'Lê Văn C', '0369548210'),
('KH004', N'Phạm Thị D', '0909123456'),
('KH005', N'Huỳnh Văn E', '0774071309'),
('KH006', N'Dương Thị F', '0848712345'),
('KH007', N'Võ Văn G', '0932154875'),
('KH008', N'Hoàng Thị H', '0789632145'),
('KH009', N'Bùi Văn I', '0912345678'),
('KH010', N'Đoàn Thị K', '0898765432');

SELECT * FROM dbo.tblKhachHangThanThiet