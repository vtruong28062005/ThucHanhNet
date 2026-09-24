-- ========================================================
-- BÀI TẬP THỰC HÀNH .NET - LAB 9 - BÀI 1
-- HỆ THỐNG QUẢN LÝ KHÁCH SẠN
-- ========================================================

-- 1. Tạo cơ sở dữ liệu (Nếu chưa tồn tại)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_KhachSan')
BEGIN
    CREATE DATABASE QL_KhachSan;
    PRINT N'Tạo database QL_KhachSan thành công!';
END
GO

USE QL_KhachSan;
GO

-- 2. Xóa các bảng cũ nếu đã tồn tại (theo thứ tự quan hệ)
IF OBJECT_ID(N'dbo.ThueP', N'U') IS NOT NULL DROP TABLE dbo.ThueP;
IF OBJECT_ID(N'dbo.KH', N'U') IS NOT NULL DROP TABLE dbo.KH;
IF OBJECT_ID(N'dbo.Phong', N'U') IS NOT NULL DROP TABLE dbo.Phong;
GO

-- ========================================================
-- a) TẠO CẤU TRÚC CÁC BẢNG & CHỈ RA KHÓA CHÍNH
-- ========================================================

-- Bảng 1: Phong (Lưu thông tin về các phòng của khách sạn)
CREATE TABLE Phong (
    MaPH VARCHAR(10) NOT NULL,
    LoaiP NVARCHAR(50) NOT NULL,
    HangP NVARCHAR(50) NOT NULL,
    DonGia DECIMAL(18, 0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL,
    
    -- Khóa chính: MaPH
    CONSTRAINT PK_Phong PRIMARY KEY (MaPH),
    -- Ràng buộc kiểm tra tính hợp lệ của dữ liệu
    CONSTRAINT CHK_Phong_LoaiP CHECK (LoaiP IN (N'Phòng đơn', N'Phòng đôi', N'Phòng ba')),
    CONSTRAINT CHK_Phong_HangP CHECK (HangP IN (N'Thường', N'VIP', N'Sang')),
    CONSTRAINT CHK_Phong_TinhTrang CHECK (TinhTrang IN (N'Có', N'Không')),
    CONSTRAINT CHK_Phong_DonGia CHECK (DonGia >= 0)
);
GO

-- Bảng 2: KH (Lưu thông tin về khách hàng thuê phòng)
CREATE TABLE KH (
    SoCMT VARCHAR(20) NOT NULL,
    Hoten NVARCHAR(100) NOT NULL,
    Gioitinh NVARCHAR(10) NOT NULL,
    
    -- Khóa chính: SoCMT
    CONSTRAINT PK_KH PRIMARY KEY (SoCMT),
    -- Ràng buộc kiểm tra giới tính
    CONSTRAINT CHK_KH_Gioitinh CHECK (Gioitinh IN (N'Nam', N'Nữ'))
);
GO

-- Bảng 3: ThueP (Lưu thông tin về quá trình thuê phòng của khách hàng)
CREATE TABLE ThueP (
    SoCMT VARCHAR(20) NOT NULL,
    MaPH VARCHAR(10) NOT NULL,
    NgayDen DATETIME NOT NULL,
    NgayDi DATETIME NULL,
    TienSDDV DECIMAL(18, 0) DEFAULT 0,
    
    -- Khóa chính: (SoCMT, MaPH, NgayDen)
    CONSTRAINT PK_ThueP PRIMARY KEY (SoCMT, MaPH, NgayDen),
    
    -- c) TẠO MỐI QUAN HỆ GIỮA CÁC BẢNG (KHÓA NGOẠI)
    CONSTRAINT FK_ThueP_KH FOREIGN KEY (SoCMT) REFERENCES KH(SoCMT)
        ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_ThueP_Phong FOREIGN KEY (MaPH) REFERENCES Phong(MaPH)
        ON UPDATE CASCADE ON DELETE CASCADE,
        
    -- Ràng buộc ngày đi >= ngày đến
    CONSTRAINT CHK_ThueP_NgayDi CHECK (NgayDi IS NULL OR NgayDi >= NgayDen),
    CONSTRAINT CHK_ThueP_TienSDDV CHECK (TienSDDV >= 0)
);
GO

-- ========================================================
-- b) NHẬP VÀO MỖI BẢNG ÍT NHẤT 3 BẢN GHI PHÙ HỢP THỰC TẾ
-- ========================================================

-- Nhập dữ liệu bảng Phong (4 bản ghi)
INSERT INTO Phong (MaPH, LoaiP, HangP, DonGia, TinhTrang) VALUES
('P101', N'Phòng đơn', N'Thường', 350000, N'Có'),
('P102', N'Phòng đôi', N'VIP',    600000, N'Có'),
('P201', N'Phòng ba',  N'Sang',   1200000, N'Không'),
('P202', N'Phòng đơn', N'Thường', 350000, N'Không');
GO

-- Nhập dữ liệu bảng KH (4 bản ghi)
INSERT INTO KH (SoCMT, Hoten, Gioitinh) VALUES
('001201003456', N'Nguyễn Văn An', N'Nam'),
('038202007891', N'Trần Thị Bích', N'Nữ'),
('024200001234', N'Lê Hoàng Long', N'Nam'),
('079203009876', N'Phạm Thu Hà',   N'Nữ');
GO

-- Nhập dữ liệu bảng ThueP (4 bản ghi)
INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV) VALUES
('001201003456', 'P101', '2026-09-20 14:00:00', '2026-09-23 12:00:00', 150000),
('038202007891', 'P102', '2026-09-22 09:30:00', '2026-09-25 11:00:00', 300000),
('024200001234', 'P201', '2026-09-18 15:00:00', '2026-09-21 10:00:00', 500000),
('079203009876', 'P101', '2026-09-24 13:00:00', NULL,                  0);
GO

-- ========================================================
-- KIỂM TRA DỮ LIỆU ĐÃ NHẬP
-- ========================================================
SELECT * FROM Phong;
SELECT * FROM KH;
SELECT * FROM ThueP;

-- Báo cáo tổng hợp tiền thuê phòng
SELECT 
    t.SoCMT,
    k.Hoten,
    k.Gioitinh,
    p.MaPH,
    p.LoaiP,
    p.HangP,
    p.DonGia,
    t.NgayDen,
    t.NgayDi,
    ISNULL(DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())), 1) AS SoNgayO,
    t.TienSDDV,
    (ISNULL(DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())), 1) * p.DonGia + t.TienSDDV) AS TongTien
FROM ThueP t
JOIN KH k ON t.SoCMT = k.SoCMT
JOIN Phong p ON t.MaPH = p.MaPH;
GO
