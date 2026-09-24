# BÀI TẬP VỀ NHÀ SỐ 3 (LAB 09 - LẬP TRÌNH XỬ LÝ DỮ LIỆU)
## Đề tài: HỆ THỐNG QUẢN LÝ KINH DOANH CỬA HÀNG (QLKD)
**Ngôn ngữ lập trình:** C# (Windows Forms, ADO.NET)  
**Hệ quản trị CSDL:** Microsoft SQL Server  
**Công cụ hỗ trợ:** Tự động biên dịch bằng script `run.bat` hoặc mở qua `QuanLyKinhDoanh.csproj` (Visual Studio 2010 - 2022)

---

## 1. Cấu trúc Cơ sở dữ liệu QLKD (Công việc 1)
Cơ sở dữ liệu gồm **7 bảng** với đầy đủ các khóa chính, khóa ngoại và ràng buộc toàn vẹn:

1. **`NCC` (Nhà cung cấp):**
   - `Mancc` (VARCHAR(20), PK): Mã nhà cung cấp
   - `Tenncc` (NVARCHAR(100)): Tên nhà cung cấp
   - `DiachiNCC` (NVARCHAR(200)): Địa chỉ nhà cung cấp

2. **`HANG` (Hàng hóa):**
   - `Mahang` (VARCHAR(20), PK): Mã hàng
   - `Tenhang` (NVARCHAR(100)): Tên hàng
   - `DVT` (NVARCHAR(50)): Đơn vị tính

3. **`KHACH` (Khách hàng):**
   - `Makh` (VARCHAR(20), PK): Mã khách
   - `Tenkh` (NVARCHAR(100)): Tên khách
   - `Diachikh` (NVARCHAR(200)): Địa chỉ khách

4. **`HDMUA` (Hóa đơn mua):**
   - `SoHD` (VARCHAR(20), PK): Số hóa đơn mua
   - `Ngaymua` (DATETIME): Ngày mua hàng
   - `Mancc` (VARCHAR(20), FK -> `NCC(Mancc)`): Mã nhà cung cấp

5. **`CHITIETMUA` (Chi tiết hóa đơn mua):**
   - `SoHD` (VARCHAR(20), FK -> `HDMUA(SoHD)` ON DELETE CASCADE)
   - `Mahang` (VARCHAR(20), FK -> `HANG(Mahang)`)
   - `Soluongmua` (INT, CHECK > 0): Số lượng mua
   - `Dongiamua` (DECIMAL(18,2), CHECK >= 0): Đơn giá mua
   - *Khóa chính tổng hợp:* `PRIMARY KEY (SoHD, Mahang)`

6. **`HDBAN` (Hóa đơn bán):**
   - `SoHDB` (VARCHAR(20), PK): Số hóa đơn bán
   - `Ngayban` (DATETIME): Ngày bán hàng
   - `Makh` (VARCHAR(20), FK -> `KHACH(Makh)`): Mã khách hàng

7. **`CHITIETBAN` (Chi tiết hóa đơn bán):**
   - `SoHDB` (VARCHAR(20), FK -> `HDBAN(SoHDB)` ON DELETE CASCADE)
   - `Mahang` (VARCHAR(20), FK -> `HANG(Mahang)`)
   - `Soluongban` (INT, CHECK > 0): Số lượng bán
   - `Dongiaban` (DECIMAL(18,2), CHECK >= 0): Đơn giá bán
   - *Khóa chính tổng hợp:* `PRIMARY KEY (SoHDB, Mahang)`

*Toàn bộ script tạo bảng, thiết lập ràng buộc và nhập dữ liệu mẫu từ 5 đến 8 bản ghi thực tế được lưu tại file `QLKD.sql`.*

---

## 2. Chi tiết các Form chức năng trong ứng dụng

### 🔹 Công việc 2: Form Quản lý Mua hàng (`frmMuaHang.cs`)
- Cho phép lập và quản lý thông tin mua hàng từ các Nhà cung cấp.
- **Thông tin hóa đơn:** Số HĐ mua, Ngày mua (`DateTimePicker`), Nhà cung cấp (`ComboBox`), Địa chỉ NCC (tự động hiển thị).
- **Thông tin chi tiết mặt hàng:** Chọn Mặt hàng (`ComboBox`), Đơn vị tính (tự hiển thị), Số lượng mua, Đơn giá mua, Thành tiền (tự động tính).
- **Lưới hiển thị dữ liệu (`DataGridView`):** Hiển thị chi tiết các lần mua hàng, căn lề tiền tệ sang phải, định dạng số đẹp mắt.
- **Các nút chức năng:**
  + **Thêm:** Chuyển sang chế độ nhập mới, gợi ý Số HĐ tiếp theo, mở khóa ô nhập, bật nút Lưu.
  + **Sửa:** Cho phép sửa ngày mua, NCC, số lượng mua, đơn giá mua của bản ghi được chọn.
  + **Lưu:** Kiểm tra tính hợp lệ dữ liệu (số lượng > 0, đơn giá >= 0, không rỗng), ghi vào `HDMUA` và `CHITIETMUA`.
  + **Xóa:** Xóa mặt hàng khỏi hóa đơn mua, có hộp thoại xác nhận.
  + **Hủy:** Hủy bỏ thao tác đang nhập.
  + **Thoát:** Đóng form có xác nhận.

### 🔹 Công việc 3a: Form Thống kê Hàng Mua (`frmThongKeMua.cs`)
- Đưa ra đúng các thông tin yêu cầu: **Tên hàng, Đơn vị tính, Nhà cung cấp, Ngày mua, Số lượng mua, Đơn giá mua, Thành tiền** (`Soluongmua * Dongiamua`).
- Tích hợp bộ lọc đa năng:
  + Lọc theo khoảng thời gian (Từ ngày - Đến ngày).
  + Lọc theo từng Nhà cung cấp hoặc Tất cả.
  + Lọc theo từng Mặt hàng hoặc Tất cả.
- Thanh tổng hợp bên dưới: Hiển thị Tổng số lượt mua, Tổng số lượng hàng nhập và Tổng tiền mua hàng (VNĐ).

### 🔹 Công việc 3b: Form Thống kê Hàng Bán (`frmThongKeBan.cs`)
- Đưa ra đúng các thông tin yêu cầu: **Tên hàng, Đơn vị tính, Khách hàng, Ngày bán, Số lượng bán, Đơn giá bán, Thành tiền** (`Soluongban * Dongiaban`).
- Bộ lọc đa năng:
  + Lọc theo khoảng ngày bán.
  + Lọc theo Khách hàng.
  + Lọc theo Mặt hàng.
- Thanh tổng hợp: Tổng số lượt bán, Tổng số lượng sản phẩm bán ra, Tổng doanh thu bán hàng (VNĐ).

### 🔹 Công việc 3c: Form Tìm kiếm Hàng Bán theo Số HĐB (`frmTimKiemBanHang.cs`)
- Cho phép nhập trực tiếp hoặc chọn nhanh Số hóa đơn bán (`SoHDB`) từ ComboBox.
- Bấm nút **"Tìm kiếm"**:
  + Hiển thị thông tin chung: Số HĐB, Ngày bán, Tên khách hàng, Địa chỉ khách hàng.
  + Lưới `DataGridView` hiển thị chi tiết toàn bộ các mặt hàng thuộc hóa đơn đó: STT, Mã hàng, Tên mặt hàng, ĐVT, Số lượng, Đơn giá, Thành tiền.
  + Hiển thị TỔNG TIỀN THANH TOÁN của cả hóa đơn.
  + Có nút **"Xem tất cả HĐ"** để xem toàn bộ chi tiết bán hàng.

### 🔹 Mở rộng: Form Quản lý Bán hàng (`frmBanHang.cs`) & Danh mục (`frmDanhMuc.cs`)
- `frmBanHang.cs`: Hỗ trợ thêm/sửa/xóa/lưu hóa đơn bán hàng cho khách hàng, giúp CSDL có dữ liệu thực tế 2 chiều.
- `frmDanhMuc.cs`: Quản lý thêm/sửa/xóa 3 danh mục gốc: Mặt hàng (`HANG`), Nhà cung cấp (`NCC`), Khách hàng (`KHACH`).

### 🔹 Công việc 4: Giao diện chính MDI Form (`frmMain.cs`)
- Thiết kế chuẩn MDI Container toàn màn hình (`WindowState = Maximized`).
- Hệ thống Menu đa cấp với phím nóng tiện lợi:
  + `Ctrl + M`: Mở Form Mua hàng (Công việc 2)
  + `Ctrl + B`: Mở Form Bán hàng
  + `Ctrl + 1`: Thống kê Hàng Mua (Công việc 3a)
  + `Ctrl + 2`: Thống kê Hàng Bán (Công việc 3b)
  + `Ctrl + F`: Tìm kiếm Hàng Bán theo Số HĐB (Công việc 3c)
  + `Ctrl + D`: Quản lý Danh mục (Hàng, NCC, Khách)
  + `Alt + F4`: Thoát chương trình
- Tích hợp StatusStrip:
  + Hiển thị tình trạng kết nối SQL Server và CSDL QLKD.
  + Nút nhanh `[ ⚙ Đổi Server ]`: Thay đổi SQL Server instance mà không cần sửa code.
  + Nút nhanh `[ ⚡ Tạo CSDL QLKD ]`: Tự động khởi tạo lại CSDL và nạp dữ liệu mẫu chỉ với 1 click!
  + Đồng hồ thời gian thực.

---

## 3. Hướng dẫn chạy chương trình

### Cách 1: Chạy nhanh bằng file `run.bat` (Khuyên dùng)
1. Mở thư mục `d:\ThucHanhNet\lap̣9\bai3`.
2. Nhấp đúp chuột vào file `run.bat`.
3. Script sẽ tự động gọi trình biên dịch C# (`csc.exe`), build ra `QuanLyKinhDoanh.exe` và tự động khởi chạy giao diện chính.

### Cách 2: Mở trong Visual Studio
1. Mở file `QuanLyKinhDoanh.csproj` bằng Visual Studio (2010, 2012, 2015, 2017, 2019, 2022).
2. Nhấn phím `F5` hoặc nút `Start` để biên dịch và chạy.

---

## 4. Cấu hình SQL Server
- Mặc định ứng dụng kết nối tới SQL Server cục bộ: `.` (hoặc `localhost`).
- Nếu SQL Server của bạn là một instance khác (ví dụ: `.\SQLEXPRESS` hoặc `DESKTOP-ABC\SQLEXPRESS`):
  + Bạn có thể chỉnh sửa file `server.txt`
  + Hoặc vào menu `Hệ thống` -> `Cấu hình SQL Server...` ngay trên form chính để nhập tên máy chủ.
  + Sau đó nhấn `[ ⚡ Tạo CSDL QLKD ]` trên menu hoặc thanh trạng thái để chương trình tự động tạo bảng và nạp dữ liệu mẫu!
