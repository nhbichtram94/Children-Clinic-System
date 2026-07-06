CREATE DATABASE QLPKND
USE QLPKND

-- Bảng Vai Trò
CREATE TABLE VAITRO (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

-- Bảng Người Dùng
CREATE TABLE NGUOIDUNG (
    UserID INT IDENTITY(1,1) PRIMARY KEY,	
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Matkhau NVARCHAR(255) NOT NULL,
    RoleID INT,

	FOREIGN KEY (RoleID) REFERENCES VAITRO(RoleID)
);

-- Bảng Bệnh Nhân
CREATE TABLE BENHNHAN (
    BenhNhanID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgSinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL
);

-- Bảng Loại Quan Hệ
CREATE TABLE LOAIQUANHE (
    LoaiQuanHeID INT IDENTITY(1,1) PRIMARY KEY,
    TenQuanHe NVARCHAR(50) NOT NULL -- Ví dụ: "Cha", "Mẹ", "Người giám hộ"
);

-- Bảng Người Giám Hộ
CREATE TABLE GIAMHO (
    GiamHoID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE,
	GTinh NVARCHAR(10),	
    Sodienthoai VARCHAR(50) UNIQUE,
    DChi NVARCHAR(255) UNIQUE,
    UserID INT NULL,

	FOREIGN KEY (UserID) REFERENCES NGUOIDUNG(UserID)
);

CREATE TABLE GIAMHO_BENHNHAN (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GiamHoID INT NOT NULL, -- Khóa ngoại tới bảng GIAMHO
    BenhNhanID INT NOT NULL, -- Khóa ngoại tới bảng BENHNHAN
    LoaiQuanHeID INT NOT NULL, -- Loại quan hệ (Cha, Mẹ, Giám hộ hợp pháp, ...)
    
    -- Khóa ngoại
    FOREIGN KEY (GiamHoID) REFERENCES GIAMHO(GiamHoID),
    FOREIGN KEY (BenhNhanID) REFERENCES BENHNHAN(BenhNhanID),
    FOREIGN KEY (LoaiQuanHeID) REFERENCES LOAIQUANHE(LoaiQuanHeID)
);

-- Bảng Phòng Làm Việc
CREATE TABLE PHONGLAMVIEC (
    PhongID INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(100) NOT NULL
);

-- Bảng Chuyên Khoa
CREATE TABLE CHUYENKHOA (
    ChuyenKhoaID INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyenKhoa NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255)
);

-- Bảng Dịch Vụ Khám
CREATE TABLE DICHVUKHAM (
    DichVuID INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL UNIQUE,
    Gia DECIMAL(18,2) NOT NULL
);

-- Bảng Liên Kết Dịch Vụ với Chuyên Khoa
CREATE TABLE DICHVUKHAM_CHUYENKHOA (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DichVuID INT NOT NULL,
    ChuyenKhoaID INT NOT NULL,
    FOREIGN KEY (DichVuID) REFERENCES DICHVUKHAM(DichVuID),
    FOREIGN KEY (ChuyenKhoaID) REFERENCES CHUYENKHOA(ChuyenKhoaID),
    CONSTRAINT UC_DICHVUKHAM_CHUYENKHOA UNIQUE (DichVuID, ChuyenKhoaID)
);

-- Bảng Bác Sĩ
CREATE TABLE BACSI (
    BacSiID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE,
	GTinh NVARCHAR(10),
    ChuyenKhoaID INT,
    Email NVARCHAR(255) UNIQUE,
    Sodienthoai VARCHAR(50) UNIQUE,
    DChi NVARCHAR(255),
	PhongID INT,                           -- Thêm ID phòng làm việc
    UserID int null,

	FOREIGN KEY (UserID) REFERENCES NGUOIDUNG(UserID),
    FOREIGN KEY (ChuyenKhoaID) REFERENCES CHUYENKHOA(ChuyenKhoaID),
    FOREIGN KEY (PhongID) REFERENCES PHONGLAMVIEC(PhongID)
);

CREATE TABLE NHANVIEN 
(
    NhanVienID INT IDENTITY(1,1) PRIMARY KEY,    -- ID nhân viên tự tăng
    HoTen NVARCHAR(100) NOT NULL,				 -- Họ và tên nhân viên
    NgaySinh DATE,                               -- Ngày sinh nhân viên
	GTinh NVARCHAR(10),							 -- Giới tính nhân viên
    ChucVu NVARCHAR(50),                         -- Chức vụ của nhân viên
    DChi NVARCHAR(200),                          -- Địa chỉ của nhân viên
    Sodienthoai NVARCHAR(15) UNIQUE,                    -- Số điện thoại nhân viên
    Email NVARCHAR(100) UNIQUE,                         -- Email nhân viên
    UserID INT NULL UNIQUE,                  -- Liên kết đến bảng User
    FOREIGN KEY (UserID) REFERENCES NGUOIDUNG(UserID) -- Ràng buộc khóa ngoại
);

-- Bảng Khung Giờ
CREATE TABLE KHUNG_GIO (
    KhungGioID INT IDENTITY(1,1) PRIMARY KEY,
    NgayTrongTuan NVARCHAR(10) CHECK (NgayTrongTuan IN (N'Thứ Hai', N'Thứ Ba', N'Thứ Tư', N'Thứ Năm', N'Thứ Sáu', N'Thứ Bảy', N'Chủ Nhật')), -- Ngày trong tuần
    Buoi NVARCHAR(10) CHECK (Buoi IN (N'Sáng', N'Chiều')), -- Sáng hay Chiều
    BatDau TIME NOT NULL, -- Thời gian bắt đầu
    KetThuc TIME NOT NULL, -- Thời gian kết thúc
    SoLuongBenhNhan INT NOT NULL, -- Số lượng bệnh nhân tối đa
    CONSTRAINT CK_KhungGio UNIQUE (NgayTrongTuan, Buoi, BatDau) -- Đảm bảo không trùng lặp
);

-- Bảng Thuốc 
CREATE TABLE THUOC (
    ThuocID INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc NVARCHAR(255) NOT NULL UNIQUE,
    HamLuong NVARCHAR(100),
    CachDung NVARCHAR(255),
    Gia DECIMAL(18,2),
    TonKho INT NOT NULL
);

-- Bảng Phiếu Khám
CREATE TABLE PHIEUKHAM (
    PhieuKhamID INT IDENTITY(1,1) PRIMARY KEY,
    BenhNhanID INT,
    GiamHoID INT,
    ChuyenKhoaID INT,
    NgayKham DATETIME,
	KhungGioID INT,
    SoThuTu INT, -- Số thứ tự khám trong ngày
    FOREIGN KEY (BenhNhanID) REFERENCES BENHNHAN(BenhNhanID),
    FOREIGN KEY (GiamHoID) REFERENCES GIAMHO(GiamHoID),
    FOREIGN KEY (ChuyenKhoaID) REFERENCES CHUYENKHOA(ChuyenKhoaID),
	FOREIGN KEY (KhungGioID) REFERENCES KHUNG_GIO(KhungGioID)
);

-- Bảng Hồ Sơ Bệnh Án
CREATE TABLE HOSOBENHAN (
    HoSoID INT IDENTITY(1,1) PRIMARY KEY,
    BenhNhanID INT,
    BacSiID INT NULL,
    ChuyenKhoaID INT,
    ChuanDoan NVARCHAR(255) NULL,
    DieuTri NVARCHAR(255) NULL,
    NgayKham DATETIME,
	PhieuKhamID INT,

	FOREIGN KEY (PhieuKhamID) REFERENCES PHIEUKHAM(PhieuKhamID),
    FOREIGN KEY (BenhNhanID) REFERENCES BENHNHAN(BenhNhanID),
    FOREIGN KEY (BacSiID) REFERENCES BACSI(BacSiID),
    FOREIGN KEY (ChuyenKhoaID) REFERENCES CHUYENKHOA(ChuyenKhoaID)
);

-- Bảng Chi Tiết Hồ Sơ Bệnh Án - Thêm thông tin thuốc kê đơn
CREATE TABLE CHITIET_HOSOBENHAN (
    HoSoID INT,                  -- Mã hồ sơ bệnh án
    ThuocID INT,                 -- Mã thuốc
    SoLuong INT,                 -- Số lượng thuốc kê
    Cachdung NVARCHAR(255),      -- Cách dùng thuốc (ví dụ: 3 lần/ngày, sau ăn)
    FOREIGN KEY (HoSoID) REFERENCES HOSOBENHAN(HoSoID),
    FOREIGN KEY (ThuocID) REFERENCES THUOC(ThuocID)
);

-- Bảng Phương Thức Thanh Toán
CREATE TABLE PHUONGTHUCTHANHTOAN (
    PhuongThucID INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuongThuc NVARCHAR(50) NOT NULL -- Ví dụ: "Chuyển khoản", "Tiền mặt"
);

CREATE TABLE HOADON (
    HoaDonID INT IDENTITY(1,1) PRIMARY KEY,
    BenhNhanID INT,             -- Mã bệnh nhân
    HoSoID INT,                 -- Mã hồ sơ bệnh án
    NgayTao DATETIME,           -- Ngày tạo hóa đơn
    DichVuID INT,               -- Dịch vụ duy nhất trong hóa đơn
    PhuongThucID INT,           -- Phương thức thanh toán
    TongTien DECIMAL(18,2) NOT NULL,  -- Tổng tiền của hóa đơn
    FOREIGN KEY (BenhNhanID) REFERENCES BENHNHAN(BenhNhanID),
    FOREIGN KEY (HoSoID) REFERENCES HOSOBENHAN(HoSoID),   -- Liên kết với hồ sơ bệnh án
    FOREIGN KEY (DichVuID) REFERENCES DICHVUKHAM(DichVuID),
    FOREIGN KEY (PhuongThucID) REFERENCES PHUONGTHUCTHANHTOAN(PhuongThucID)
);

CREATE TABLE CHITIETHOADON (
    HoaDonID INT,              -- Mã hóa đơn
    ThuocID INT,               -- Mã thuốc 
    SoLuong INT,               -- Số lượng thuốc	
	Cachdung NVARCHAR(255),
    DonGia DECIMAL(18,2),      -- Đơn giá
    ThanhTien DECIMAL(18,2),   -- Thành tiền (SoLuong * DonGia)

    -- Khóa ngoại
    FOREIGN KEY (HoaDonID) REFERENCES HOADON(HoaDonID),
    FOREIGN KEY (ThuocID) REFERENCES THUOC(ThuocID)
);

set dateformat dmy;