CREATE TABLE CongViec (
    MaCV INT PRIMARY KEY, 
    TenCV NVARCHAR(100), 
    MucLuong MONEY
);

CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY, 
    TenNV NVARCHAR(100), 
    GioiTinh NVARCHAR(10), 
    NgaySinh DATE, 
    DienThoai NVARCHAR(15), 
    DiaChi NVARCHAR(255), 
    MaCV INT,  -- Liên kết với Công việc
    CONSTRAINT FK_NhanVien_CongViec FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV) ON DELETE CASCADE
);

CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY, 
    TenNCC NVARCHAR(100), 
    DiaChi NVARCHAR(255), 
    DienThoai NVARCHAR(15)
);

CREATE TABLE KhachHang (
    MaKhach INT PRIMARY KEY, 
    TenKhach NVARCHAR(100), 
    DiaChi NVARCHAR(255), 
    DienThoai NVARCHAR(15)
);

CREATE TABLE DacDiem (
    MaDacDiem INT PRIMARY KEY, 
    TenDacDiem NVARCHAR(100)  -- Ví dụ: rắn, mềm, nước
);

CREATE TABLE DonViTinh (
    MaDonVi INT PRIMARY KEY, 
    TenDonVi NVARCHAR(50)
);

CREATE TABLE NoiSanXuat (
    MaNoiSX INT PRIMARY KEY, 
    TenNoiSX NVARCHAR(100)
);

CREATE TABLE MauSac (
    MaMau INT PRIMARY KEY, 
    TenMau NVARCHAR(50)
);

CREATE TABLE CongDung (
    MaCongDung INT PRIMARY KEY, 
    TenCongDung NVARCHAR(100)
);

CREATE TABLE DMHangHoa (
    MaHang INT PRIMARY KEY, 
    TenHang NVARCHAR(100), 
    MaDonVi INT,  -- Liên kết với Đơn vị tính
    MaNoiSX INT,  -- Liên kết với Nơi sản xuất
    MaCongDung INT,  -- Liên kết với Công dụng
    MaMau INT,  -- Liên kết với Màu sắc
    SoLuong INT, 
    DonGiaNhap MONEY, 
    DonGiaBan MONEY, 
    MaDacDiem INT,  -- Liên kết với Đặc điểm
    CONSTRAINT FK_DMHangHoa_DonViTinh FOREIGN KEY (MaDonVi) REFERENCES DonViTinh(MaDonVi),
    CONSTRAINT FK_DMHangHoa_NoiSanXuat FOREIGN KEY (MaNoiSX) REFERENCES NoiSanXuat(MaNoiSX),
    CONSTRAINT FK_DMHangHoa_CongDung FOREIGN KEY (MaCongDung) REFERENCES CongDung(MaCongDung),
    CONSTRAINT FK_DMHangHoa_MauSac FOREIGN KEY (MaMau) REFERENCES MauSac(MaMau),
    CONSTRAINT FK_DMHangHoa_DacDiem FOREIGN KEY (MaDacDiem) REFERENCES DacDiem(MaDacDiem)
);

CREATE TABLE HoaDonBan (
    SoHDB INT PRIMARY KEY, 
    MaNV INT,  -- Liên kết với Nhân viên
    MaKhach INT,  -- Liên kết với Khách hàng
    NgayBan DATE, 
    TongTien MONEY,
    CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach)
);

CREATE TABLE ChiTietHoaDonBan (
    SoHDB INT,  -- Liên kết với Hóa đơn bán
    MaHang INT,  -- Liên kết với Hàng hóa
    SoLuong INT, 
    GiamGia DECIMAL(5, 2),  -- Giảm giá theo phần trăm
    ThanhTien MONEY, 
    CONSTRAINT FK_ChiTietHDB_HoaDonBan FOREIGN KEY (SoHDB) REFERENCES HoaDonBan(SoHDB) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietHDB_DMHangHoa FOREIGN KEY (MaHang) REFERENCES DMHangHoa(MaHang)
);

CREATE TABLE HoaDonNhap (
    SoHDN INT PRIMARY KEY, 
    MaNV INT,  -- Liên kết với Nhân viên
    MaNCC INT,  -- Liên kết với Nhà cung cấp
    NgayNhap DATE, 
    TongTien MONEY, 
    CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDonNhap_NhaCungCap FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

CREATE TABLE ChiTietHoaDonNhap (
    SoHDN INT,  -- Liên kết với Hóa đơn nhập
    MaHang INT,  -- Liên kết với Hàng hóa
    SoLuong INT, 
    DonGia MONEY, 
    GiamGia DECIMAL(5, 2),  -- Giảm giá theo phần trăm
    ThanhTien MONEY, 
    CONSTRAINT FK_ChiTietHDN_HoaDonNhap FOREIGN KEY (SoHDN) REFERENCES HoaDonNhap(SoHDN) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietHDN_DMHangHoa FOREIGN KEY (MaHang) REFERENCES DMHangHoa(MaHang)
);

--Son
CREATE TABLE [dbo].[Account]
(
	[Username] VARCHAR(32) NOT NULL,
    [Password] VARCHAR(32) NOT NULL, 
    [MaNV] INT NULL,
	[IsAdmin] BIT NULL,
	LastLogin DATETIME NULL,
	KeepLoginExpDate DATETIME NULL,
	TimeOut INT NULL,
	PRIMARY KEY (Username),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
insert into Account(Username, Password, MaNV, IsAdmin) values
('Admin', '123', NULL, 1),
('NV1', '123', 1, 0),
('NV2', '123', 2, 0),
('NV3', '123', 3, 0);
--



-- Thêm dữ liệu cho bảng CongViec
INSERT INTO CongViec (MaCV, TenCV, MucLuong) VALUES
(1, N'Quản lý', 15000000),
(2, N'Nhân viên bán hàng', 9000000),
(3, N'Thủ kho', 8000000);

-- Thêm dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV) VALUES
(1, N'Nguyễn Văn A', N'Nam', '1990-05-20', '0123456789', N'123 Đường ABC, Hà Nội', 1),
(2, N'Trần Thị B', N'Nữ', '1995-09-15', '0987654321', N'456 Đường XYZ, TP. Hồ Chí Minh', 2),
(3, N'Phạm Văn C', N'Nam', '1992-07-10', '0912345678', N'789 Đường DEF, Đà Nẵng', 3);

-- Thêm dữ liệu cho bảng NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES
(1, N'Công ty TNHH Hoa Quả Miền Bắc', N'123 Đường Bắc, Hà Nội', '0911000011'),
(2, N'Công ty TNHH Hoa Quả Miền Nam', N'456 Đường Nam, TP. Hồ Chí Minh', '0911000022'),
(3, N'Công ty TNHH Hoa Quả Miền Trung', N'789 Đường Trung, Đà Nẵng', '0911000033');

-- Thêm dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) VALUES
(1, N'Nguyễn Văn D', N'101 Đường ABC, Hà Nội', '0123456789'),
(2, N'Lê Thị E', N'202 Đường XYZ, TP. Hồ Chí Minh', '0987654321'),
(3, N'Vũ Văn F', N'303 Đường DEF, Đà Nẵng', '0912345678');

-- Thêm dữ liệu cho bảng DacDiem
INSERT INTO DacDiem (MaDacDiem, TenDacDiem) VALUES
(1, N'Tươi'),
(2, N'Chín'),
(3, N'Ngọt');

-- Thêm dữ liệu cho bảng DonViTinh
INSERT INTO DonViTinh (MaDonVi, TenDonVi) VALUES
(1, N'Kg'),
(2, N'Quả'),
(3, N'Túi');

-- Thêm dữ liệu cho bảng NoiSanXuat
INSERT INTO NoiSanXuat (MaNoiSX, TenNoiSX) VALUES
(1, N'Việt Nam'),
(2, N'Thái Lan'),
(3, N'Mỹ');

-- Thêm dữ liệu cho bảng MauSac
INSERT INTO MauSac (MaMau, TenMau) VALUES
(1, N'Xanh'),
(2, N'Vàng'),
(3, N'Đỏ');

-- Thêm dữ liệu cho bảng CongDung
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES
(1, N'Giải khát'),
(2, N'Tốt cho sức khỏe'),
(3, N'Cung cấp vitamin');

-- Thêm dữ liệu cho bảng DMHangHoa
INSERT INTO DMHangHoa (MaHang, TenHang, MaDonVi, MaNoiSX, MaCongDung, MaMau, SoLuong, DonGiaNhap, DonGiaBan, MaDacDiem) VALUES
(1, N'Xoài', 1, 2, 2, 2, 100, 50000, 70000, 1),
(2, N'Táo', 1, 3, 3, 3, 200, 60000, 90000, 1),
(3, N'Cam', 1, 1, 1, 2, 150, 30000, 50000, 2);

-- Thêm dữ liệu cho bảng HoaDonBan
INSERT INTO HoaDonBan (SoHDB, MaNV, MaKhach, NgayBan, TongTien) VALUES
(1, 2, 1, '2024-10-10', 140000),
(2, 2, 2, '2024-10-12', 180000);

-- Thêm dữ liệu cho bảng ChiTietHoaDonBan
INSERT INTO ChiTietHoaDonBan (SoHDB, MaHang, SoLuong, GiamGia, ThanhTien) VALUES
(1, 1, 2, 0.05, 133000),  -- Xoài, giảm giá 5%
(1, 3, 3, 0.00, 150000),  -- Cam, không giảm giá
(2, 2, 2, 0.10, 162000);  -- Táo, giảm giá 10%

-- Thêm dữ liệu cho bảng HoaDonNhap
INSERT INTO HoaDonNhap (SoHDN, MaNV, MaNCC, NgayNhap, TongTien) VALUES
(1, 3, 1, '2024-10-08', 800000),
(2, 3, 2, '2024-10-09', 600000);

-- Thêm dữ liệu cho bảng ChiTietHoaDonNhap
INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, DonGia, GiamGia, ThanhTien) VALUES
(1, 1, 50, 50000, 0.00, 250000),  -- Nhập Xoài
(1, 2, 100, 60000, 0.05, 570000),  -- Nhập Táo, giảm giá 5%
(2, 3, 150, 30000, 0.00, 450000);  -- Nhập Cam

