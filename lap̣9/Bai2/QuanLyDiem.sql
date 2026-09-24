-- ===================================================================
-- BÀI TẬP THỰC HÀNH .NET - LAB 9 - BÀI 2
-- HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN
-- CÔNG VIỆC 1: TẠO CƠ SỞ DỮ LIỆU, CÁC BẢNG, RÀNG BUỘC & DỮ LIỆU MẪU
-- ===================================================================

-- 1. Tạo cơ sở dữ liệu QL_Diem nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_Diem')
BEGIN
    CREATE DATABASE QL_Diem;
    PRINT N'Đã tạo cơ sở dữ liệu QL_Diem thành công!';
END
GO

USE QL_Diem;
GO

-- 2. Xóa các bảng cũ theo thứ tự quan hệ nếu đã tồn tại để tránh xung đột
IF OBJECT_ID(N'dbo.tblDiem', N'U') IS NOT NULL DROP TABLE dbo.tblDiem;
IF OBJECT_ID(N'dbo.tblMonHoc', N'U') IS NOT NULL DROP TABLE dbo.tblMonHoc;
IF OBJECT_ID(N'dbo.tblSinhVien', N'U') IS NOT NULL DROP TABLE dbo.tblSinhVien;
IF OBJECT_ID(N'dbo.tblKhoa', N'U') IS NOT NULL DROP TABLE dbo.tblKhoa;
GO

-- ===================================================================
-- a) TẠO CÁC BẢNG VÀ CHỈ RA KHÓA CHÍNH (PRIMARY KEY)
-- b) TẠO CÁC RÀNG BUỘC GIỮA CÁC BẢNG (FOREIGN KEY, CHECK, NOT NULL)
-- ===================================================================

-- Bảng 1: tblKhoa(Makhoa, Tenkhoa)
CREATE TABLE tblKhoa (
    Makhoa VARCHAR(10) NOT NULL,
    Tenkhoa NVARCHAR(100) NOT NULL,

    -- Khóa chính: Makhoa
    CONSTRAINT PK_tblKhoa PRIMARY KEY (Makhoa)
);
GO

-- Bảng 2: tblSinhVien(MaSV, Hoten, Ngaysinh, Noisinh, Gioitinh, Diachi, Makhoa)
CREATE TABLE tblSinhVien (
    MaSV VARCHAR(10) NOT NULL,
    Hoten NVARCHAR(100) NOT NULL,
    Ngaysinh DATETIME NULL,
    Noisinh NVARCHAR(100) NULL,
    Gioitinh NVARCHAR(10) NULL,
    Diachi NVARCHAR(200) NULL,
    Makhoa VARCHAR(10) NOT NULL,

    -- Khóa chính: MaSV
    CONSTRAINT PK_tblSinhVien PRIMARY KEY (MaSV),

    -- Ràng buộc khóa ngoại: Makhoa tham chiếu tới tblKhoa(Makhoa)
    CONSTRAINT FK_tblSinhVien_tblKhoa FOREIGN KEY (Makhoa)
        REFERENCES tblKhoa(Makhoa)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    -- Ràng buộc kiểm tra giới tính hợp lệ
    CONSTRAINT CHK_tblSinhVien_GioiTinh CHECK (Gioitinh IN (N'Nam', N'Nữ', N'Khác'))
);
GO

-- Bảng 3: tblMonHoc(Mamon, Tenmon, Makhoa, Sohocphan, Giaovien)
CREATE TABLE tblMonHoc (
    Mamon VARCHAR(10) NOT NULL,
    Tenmon NVARCHAR(100) NOT NULL,
    Makhoa VARCHAR(10) NOT NULL,
    Sohocphan INT NOT NULL,
    Giaovien NVARCHAR(100) NULL,

    -- Khóa chính: Mamon
    CONSTRAINT PK_tblMonHoc PRIMARY KEY (Mamon),

    -- Ràng buộc khóa ngoại: Makhoa tham chiếu tới tblKhoa(Makhoa)
    CONSTRAINT FK_tblMonHoc_tblKhoa FOREIGN KEY (Makhoa)
        REFERENCES tblKhoa(Makhoa)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    -- Ràng buộc kiểm tra số học phần phải lớn hơn 0
    CONSTRAINT CHK_tblMonHoc_Sohocphan CHECK (Sohocphan > 0)
);
GO

-- Bảng 4: tblDiem(Mamon, MaSV, Diem)
CREATE TABLE tblDiem (
    Mamon VARCHAR(10) NOT NULL,
    MaSV VARCHAR(10) NOT NULL,
    Diem FLOAT NULL,

    -- Khóa chính phức hợp gồm (Mamon, MaSV)
    CONSTRAINT PK_tblDiem PRIMARY KEY (Mamon, MaSV),

    -- Ràng buộc khóa ngoại: Mamon tham chiếu tới tblMonHoc(Mamon)
    CONSTRAINT FK_tblDiem_tblMonHoc FOREIGN KEY (Mamon)
        REFERENCES tblMonHoc(Mamon)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    -- Ràng buộc khóa ngoại: MaSV tham chiếu tới tblSinhVien(MaSV)
    CONSTRAINT FK_tblDiem_tblSinhVien FOREIGN KEY (MaSV)
        REFERENCES tblSinhVien(MaSV)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    -- Ràng buộc kiểm tra điểm phải trong thang điểm từ 0 đến 10
    CONSTRAINT CHK_tblDiem_Diem CHECK (Diem >= 0.0 AND Diem <= 10.0)
);
GO

-- ===================================================================
-- c) NHẬP VÀO MỖI BẢNG TỪ 5 ĐẾN 10 DÒNG DỮ LIỆU MẪU
-- ===================================================================

-- 1. Dữ liệu bảng tblKhoa (5 khoa)
INSERT INTO tblKhoa (Makhoa, Tenkhoa) VALUES 
('K01', N'Công nghệ thông tin'),
('K02', N'Điện tử viễn thông'),
('K03', N'Kinh tế số'),
('K04', N'Ngoại ngữ'),
('K05', N'Quản trị kinh doanh');
GO

-- 2. Dữ liệu bảng tblSinhVien (8 sinh viên - chuẩn theo dữ liệu hình ảnh 9.46)
INSERT INTO tblSinhVien (MaSV, Hoten, Ngaysinh, Noisinh, Gioitinh, Diachi, Makhoa) VALUES 
('SV01', N'Bùi Thị Thảo', '1985-07-07', N'Hà Nội', N'Nữ', N'12 Ba Đình, Hà Nội', 'K01'),
('SV02', N'Trần Tuấn Anh', '1984-05-06', N'Hải Phòng', N'Nam', N'45 Lê Hồng Phong, Hải Phòng', 'K01'),
('SV03', N'Nguyễn Thị Mai', '1982-04-03', N'Nam Định', N'Nữ', N'78 Trần Hưng Đạo, Nam Định', 'K01'),
('SV04', N'Trần Thị Yến', '1982-03-02', N'Thái Bình', N'Nữ', N'90 Quang Trung, Thái Bình', 'K02'),
('SV05', N'Bùi Thanh Mai', '2013-03-03', N'Hà Nam', N'Nữ', N'15 Phủ Lý, Hà Nam', 'K03'),
('SV06', N'Lê Hoàng Long', '2003-10-15', N'Đà Nẵng', N'Nam', N'22 Bạch Đằng, Đà Nẵng', 'K02'),
('SV07', N'Phạm Minh Đức', '2004-01-20', N'Quảng Ninh', N'Nam', N'68 Hạ Long, Quảng Ninh', 'K01'),
('SV08', N'Đỗ Phương Linh', '2003-08-12', N'Bắc Ninh', N'Nữ', N'10 Võ Cường, Bắc Ninh', 'K04');
GO

-- 3. Dữ liệu bảng tblMonHoc (6 môn học)
INSERT INTO tblMonHoc (Mamon, Tenmon, Makhoa, Sohocphan, Giaovien) VALUES 
('M01', N'Tin học đại cương', 'K01', 3, N'Nguyễn Văn An'),
('M02', N'Cơ sở dữ liệu', 'K01', 4, N'Trần Thị Bình'),
('M03', N'Lập trình C# .NET', 'K01', 3, N'Lê Quang Cường'),
('M04', N'Mạng máy tính', 'K01', 3, N'Hoàng Minh Dũng'),
('M05', N'Kỹ thuật số', 'K02', 3, N'Phạm Văn Em'),
('M06', N'Kinh tế vĩ mô', 'K03', 2, N'Vũ Thị Giang');
GO

-- 4. Dữ liệu bảng tblDiem (10 dòng điểm - khớp chuẩn dữ liệu Hình 9.46)
INSERT INTO tblDiem (Mamon, MaSV, Diem) VALUES 
('M02', 'SV01', 3.0),
('M01', 'SV01', 9.0),
('M04', 'SV01', 3.0),
('M04', 'SV02', 2.0),
('M02', 'SV02', 9.0),
('M02', 'SV03', 8.0),
('M02', 'SV04', 6.0),
('M04', 'SV04', 8.0),
('M01', 'SV05', 5.0),
('M03', 'SV02', 7.5);
GO

-- Kiểm tra dữ liệu vừa nhập
PRINT N'--- BẢNG tblKhoa ---';
SELECT * FROM tblKhoa;
PRINT N'--- BẢNG tblSinhVien ---';
SELECT * FROM tblSinhVien;
PRINT N'--- BẢNG tblMonHoc ---';
SELECT * FROM tblMonHoc;
PRINT N'--- BẢNG tblDiem ---';
SELECT * FROM tblDiem;
GO
