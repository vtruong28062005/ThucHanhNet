-- =========================================================================
-- BÀI TẬP VỀ NHÀ 3 (LAB 09 - LẬP TRÌNH XỬ LÝ DỮ LIỆU)
-- TÊN CƠ SỞ DỮ LIỆU: QLKD (Quản lý kinh doanh cửa hàng)
-- GỒM 7 BẢNG: NCC, HDMUA, CHITIETMUA, HANG, HDBAN, CHITIETBAN, KHACH
-- =========================================================================

USE master;
GO

-- 1. Nếu CSDL QLKD đã tồn tại thì ngắt kết nối và xóa để tạo mới sạch sẽ
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLKD')
BEGIN
    ALTER DATABASE QLKD SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLKD;
END
GO

-- 2. Tạo CSDL QLKD mới
CREATE DATABASE QLKD;
GO

USE QLKD;
GO

-- =========================================================================
-- CÔNG VIỆC 1: TẠO CẤU TRÚC 7 BẢNG VÀ CÁC RÀNG BUỘC KHÓA CHÍNH, KHÓA NGOẠI
-- =========================================================================

-- Bảng 1: Nhà cung cấp (NCC)
CREATE TABLE NCC (
    Mancc VARCHAR(20) NOT NULL,
    Tenncc NVARCHAR(100) NOT NULL,
    DiachiNCC NVARCHAR(200) NULL,
    CONSTRAINT PK_NCC PRIMARY KEY (Mancc)
);
GO

-- Bảng 2: Hàng hóa (HANG)
CREATE TABLE HANG (
    Mahang VARCHAR(20) NOT NULL,
    Tenhang NVARCHAR(100) NOT NULL,
    DVT NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_HANG PRIMARY KEY (Mahang)
);
GO

-- Bảng 3: Khách hàng (KHACH)
CREATE TABLE KHACH (
    Makh VARCHAR(20) NOT NULL,
    Tenkh NVARCHAR(100) NOT NULL,
    Diachikh NVARCHAR(200) NULL,
    CONSTRAINT PK_KHACH PRIMARY KEY (Makh)
);
GO

-- Bảng 4: Hóa đơn mua (HDMUA)
CREATE TABLE HDMUA (
    SoHD VARCHAR(20) NOT NULL,
    Ngaymua DATETIME NOT NULL,
    Mancc VARCHAR(20) NOT NULL,
    CONSTRAINT PK_HDMUA PRIMARY KEY (SoHD),
    CONSTRAINT FK_HDMUA_NCC FOREIGN KEY (Mancc) REFERENCES NCC(Mancc) ON UPDATE CASCADE
);
GO

-- Bảng 5: Chi tiết hóa đơn mua hàng (CHITIETMUA)
CREATE TABLE CHITIETMUA (
    SoHD VARCHAR(20) NOT NULL,
    Mahang VARCHAR(20) NOT NULL,
    Soluongmua INT NOT NULL CHECK (Soluongmua > 0),
    Dongiamua DECIMAL(18, 2) NOT NULL CHECK (Dongiamua >= 0),
    CONSTRAINT PK_CHITIETMUA PRIMARY KEY (SoHD, Mahang),
    CONSTRAINT FK_CHITIETMUA_HDMUA FOREIGN KEY (SoHD) REFERENCES HDMUA(SoHD) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_CHITIETMUA_HANG FOREIGN KEY (Mahang) REFERENCES HANG(Mahang) ON UPDATE CASCADE
);
GO

-- Bảng 6: Hóa đơn bán (HDBAN)
CREATE TABLE HDBAN (
    SoHDB VARCHAR(20) NOT NULL,
    Ngayban DATETIME NOT NULL,
    Makh VARCHAR(20) NOT NULL,
    CONSTRAINT PK_HDBAN PRIMARY KEY (SoHDB),
    CONSTRAINT FK_HDBAN_KHACH FOREIGN KEY (Makh) REFERENCES KHACH(Makh) ON UPDATE CASCADE
);
GO

-- Bảng 7: Chi tiết hóa đơn bán hàng (CHITIETBAN)
CREATE TABLE CHITIETBAN (
    SoHDB VARCHAR(20) NOT NULL,
    Mahang VARCHAR(20) NOT NULL,
    Soluongban INT NOT NULL CHECK (Soluongban > 0),
    Dongiaban DECIMAL(18, 2) NOT NULL CHECK (Dongiaban >= 0),
    CONSTRAINT PK_CHITIETBAN PRIMARY KEY (SoHDB, Mahang),
    CONSTRAINT FK_CHITIETBAN_HDBAN FOREIGN KEY (SoHDB) REFERENCES HDBAN(SoHDB) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_CHITIETBAN_HANG FOREIGN KEY (Mahang) REFERENCES HANG(Mahang) ON UPDATE CASCADE
);
GO

-- =========================================================================
-- NHẬP DỮ LIỆU MẪU THỰC TẾ (MỖI BẢNG TỪ 4 ĐẾN 8 BẢN GHI)
-- =========================================================================

-- Nhập dữ liệu bảng NCC
INSERT INTO NCC (Mancc, Tenncc, DiachiNCC) VALUES
('NCC01', N'Công ty TNHH Samsung Vina', N'Số 2 Hải Triều, Q.1, TP. Hồ Chí Minh'),
('NCC02', N'Công ty TNHH LG Electronics Việt Nam', N'KCN Tràng Duệ, An Dương, Hải Phòng'),
('NCC03', N'Công ty Cổ phần Sony Electronics Việt Nam', N'Tầng 6 tòa nhà President Place, Q.1, TP.HCM'),
('NCC04', N'Tập đoàn Điện tử Panasonic Việt Nam', N'Lô J1-J2, KCN Thăng Long, Đông Anh, Hà Nội'),
('NCC05', N'Công ty TNHH Daikin Air Conditioning VN', N'Tầng 12 Viettel Tower, Q.10, TP. Hồ Chí Minh');
GO

-- Nhập dữ liệu bảng HANG
INSERT INTO HANG (Mahang, Tenhang, DVT) VALUES
('MH01', N'Tivi Samsung 4K 55 inch Crystal UHD', N'Chiếc'),
('MH02', N'Tủ lạnh LG Smart Inverter 335 lít', N'Chiếc'),
('MH03', N'Máy giặt lồng ngang LG AI DD 9kg', N'Chiếc'),
('MH04', N'Điều hòa Panasonic Inverter 1.5 HP', N'Bộ'),
('MH05', N'Smart Tivi Sony Bravia 65 inch OLED', N'Chiếc'),
('MH06', N'Nồi cơm điện tử cao tần Panasonic', N'Chiếc'),
('MH07', N'Tủ lạnh Samsung Bespoke 4 cánh', N'Chiếc');
GO

-- Nhập dữ liệu bảng KHACH
INSERT INTO KHACH (Makh, Tenkh, Diachikh) VALUES
('KH01', N'Nguyễn Văn An', N'125 Hoàng Hoa Thám, Ba Đình, Hà Nội'),
('KH02', N'Trần Thị Mai', N'45 Lê Lợi, TP. Nam Định'),
('KH03', N'Lê Hoàng Long', N'78 Nguyễn Văn Cừ, Long Biên, Hà Nội'),
('KH04', N'Phạm Minh Tuấn', N'12 Điện Biên Phủ, TP. Hải Phòng'),
('KH05', N'Vũ Thị Hồng', N'88 Trần Phú, Hà Đông, Hà Nội');
GO

-- Nhập dữ liệu bảng HDMUA (Hóa đơn mua hàng từ các NCC)
INSERT INTO HDMUA (SoHD, Ngaymua, Mancc) VALUES
('HDM01', '2026-01-10 08:30:00', 'NCC01'),
('HDM02', '2026-01-15 09:15:00', 'NCC02'),
('HDM03', '2026-02-05 14:00:00', 'NCC03'),
('HDM04', '2026-02-20 10:45:00', 'NCC04'),
('HDM05', '2026-03-01 16:20:00', 'NCC05');
GO

-- Nhập dữ liệu bảng CHITIETMUA (Chi tiết các mặt hàng mua)
INSERT INTO CHITIETMUA (SoHD, Mahang, Soluongmua, Dongiamua) VALUES
('HDM01', 'MH01', 15, 10500000),
('HDM01', 'MH07', 5, 28000000),
('HDM02', 'MH02', 10, 8200000),
('HDM02', 'MH03', 12, 7500000),
('HDM03', 'MH05', 8, 24000000),
('HDM04', 'MH04', 20, 11000000),
('HDM04', 'MH06', 15, 2300000),
('HDM05', 'MH04', 10, 10800000);
GO

-- Nhập dữ liệu bảng HDBAN (Hóa đơn bán hàng cho khách hàng)
INSERT INTO HDBAN (SoHDB, Ngayban, Makh) VALUES
('HDB01', '2026-01-18 10:00:00', 'KH01'),
('HDB02', '2026-01-22 15:30:00', 'KH02'),
('HDB03', '2026-02-12 11:20:00', 'KH03'),
('HDB04', '2026-02-28 16:45:00', 'KH04'),
('HDB05', '2026-03-10 09:10:00', 'KH05');
GO

-- Nhập dữ liệu bảng CHITIETBAN (Chi tiết các mặt hàng bán)
INSERT INTO CHITIETBAN (SoHDB, Mahang, Soluongban, Dongiaban) VALUES
('HDB01', 'MH01', 2, 12800000),
('HDB01', 'MH02', 1, 9900000),
('HDB02', 'MH03', 2, 9200000),
('HDB03', 'MH05', 1, 28500000),
('HDB03', 'MH06', 2, 2900000),
('HDB04', 'MH04', 3, 13200000),
('HDB05', 'MH07', 1, 33500000),
('HDB05', 'MH01', 1, 12800000);
GO

-- =========================================================================
-- TẠO CÁC VIEW PHỤC VỤ CÔNG VIỆC 3: THỐNG KÊ HÀNG MUA & HÀNG BÁN
-- =========================================================================

-- View Thống kê hàng mua (Công việc 3a)
CREATE VIEW v_ThongKeHangMua AS
SELECT 
    H.Tenhang,
    H.DVT,
    NCC.Tenncc,
    HD.Ngaymua,
    CT.Soluongmua,
    CT.Dongiamua,
    (CT.Soluongmua * CT.Dongiamua) AS ThanhTien,
    HD.SoHD,
    H.Mahang,
    NCC.Mancc
FROM CHITIETMUA CT
INNER JOIN HDMUA HD ON CT.SoHD = HD.SoHD
INNER JOIN HANG H ON CT.Mahang = H.Mahang
INNER JOIN NCC NCC ON HD.Mancc = NCC.Mancc;
GO

-- View Thống kê hàng bán (Công việc 3b)
CREATE VIEW v_ThongKeHangBan AS
SELECT 
    H.Tenhang,
    H.DVT,
    K.Tenkh,
    HD.Ngayban,
    CT.Soluongban,
    CT.Dongiaban,
    (CT.Soluongban * CT.Dongiaban) AS ThanhTien,
    HD.SoHDB,
    H.Mahang,
    K.Makh
FROM CHITIETBAN CT
INNER JOIN HDBAN HD ON CT.SoHDB = HD.SoHDB
INNER JOIN HANG H ON CT.Mahang = H.Mahang
INNER JOIN KHACH K ON HD.Makh = K.Makh;
GO
