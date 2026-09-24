# HƯỚNG DẪN BÀI THỰC HÀNH .NET - LAB 9 - BÀI 2 (QUẢN LÝ ĐIỂM)

Dự án đã được triển khai hoàn chỉnh bằng **C# Windows Forms (.NET Framework)** và **SQL Server**, đáp ứng 100% tất cả các yêu cầu từ Công việc 1 đến Công việc 4 theo đúng hình ảnh mô tả trong giáo trình.

---

## 📁 Cấu trúc thư mục dự án

- **`QuanLyDiem.sql`**: Script tạo CSDL `QL_Diem`, các bảng (`tblKhoa`, `tblSinhVien`, `tblMonHoc`, `tblDiem`), khóa chính, khóa ngoại, ràng buộc CHECK và nạp dữ liệu mẫu (Công việc 1).
- **`frmMain.cs`**: Form chính `frmMain` (Hình 9.44) với menu Hệ thống, Quản lý (Quản lý điểm, Quản lý môn học), Help (Công việc 2).
- **`frmMonHoc.cs`**: Form Quản lý môn học `Frmonhoc` (Hình 9.45) với đầy đủ 4 yêu cầu a, b, c, d (Công việc 3).
- **`frmDiem.cs`**: Form Quản lý điểm `frDiem` (Hình 9.46) với đầy đủ 5 yêu cầu: hiển thị, thêm (có kiểm tra tính đúng đắn), xóa đa dòng, sửa điểm, tìm kiếm theo Mã SV / Tên SV, và in ấn (Công việc 4).
- **`DatabaseHelper.cs`**: Lớp xử lý kết nối ADO.NET với SQL Server, hỗ trợ tự động khởi tạo CSDL từ file SQL, tự động đổi Server qua cấu hình.
- **`server.txt`**: Tên instance SQL Server của máy tính (mặc định là `.`, bạn có thể đổi thành `.\SQLEXPRESS` hoặc `(localdb)\MSSQLLocalDB` nếu cần).
- **`run.bat`**: File script 1-click tự động biên dịch và chạy file `QuanLyDiem.exe`.
- **`QuanLyDiem.csproj`**: File project Visual Studio (có thể mở trực tiếp bằng Visual Studio).

---

## 🚀 Cách chạy chương trình

### Cách 1: Chạy nhanh bằng file `run.bat` (Không cần cài đặt Visual Studio)
1. Nháy đúp chuột vào file **`run.bat`**.
2. Script sẽ tự động gọi trình biên dịch C# của Windows (`csc.exe`), biên dịch toàn bộ mã nguồn và khởi chạy chương trình `QuanLyDiem.exe`.

### Cách 2: Mở bằng Visual Studio
1. Nháy đúp vào file **`QuanLyDiem.csproj`** trong thư mục này.
2. Bấm phím **F5** (hoặc nút **Start**) trên thanh công cụ của Visual Studio.

---

## 🗄️ Khởi tạo Cơ sở dữ liệu SQL Server (Công việc 1)

Bạn có 2 cách cực kỳ đơn giản để khởi tạo database `QL_Diem`:

1. **Cách tự động ngay trên phần mềm:**
   - Mở chương trình lên, trên thanh menu chọn **`Hệ thống` -> `Khởi tạo CSDL & Dữ liệu mẫu`** (hoặc click vào nút `[ ⚡ Tạo CSDL Mẫu ]` ở góc dưới bên phải).
   - Phần mềm sẽ tự động kết nối đến SQL Server, tạo cơ sở dữ liệu `QL_Diem`, tạo 4 bảng và nạp sẵn 10 dòng dữ liệu mẫu chuẩn chỉ.

2. **Cách chạy trong SQL Server Management Studio (SSMS):**
   - Mở file **`QuanLyDiem.sql`** trong SSMS.
   - Nhấn **F5** (Execute) để chạy toàn bộ script.

---

## 📋 Chi tiết các công việc đã thực hiện

### Công việc 1: SQL Server (File `QuanLyDiem.sql`)
- Tạo 4 bảng: `tblKhoa`, `tblSinhVien`, `tblMonHoc`, `tblDiem`.
- Ràng buộc toàn vẹn: Khóa chính (Primary Key), Khóa ngoại (Foreign Key) với `ON UPDATE CASCADE ON DELETE CASCADE`, ràng buộc `CHECK` điểm từ 0 đến 10, số học phần > 0.
- Nạp đầy đủ 5 đến 10 dòng dữ liệu mẫu theo đúng mẫu trong ảnh đề bài.

### Công việc 2: Form `frmMain` (Hình 9.44)
- Thiết kế chuẩn MDI Container với menu bar: `Hệ thống`, `Quản lý`, `Help`.
- Chọn `Quản lý` -> `Quản lý điểm`: Mở form `frmDiem`.
- Chọn `Quản lý` -> `Quản lý môn học`: Mở form `frmMonHoc`.

### Công việc 3: Form `frmMonHoc` (Hình 9.45)
- **a)** Khi khởi chạy: nạp toàn bộ danh sách môn học vào ListView; các nút Xóa, Sửa và các ô nhập liệu mờ đi (`Enabled = false`).
- **b)** Nhấn nút "Thêm": nút chuyển thành "Lưu", các ô nhập liệu và combobox sáng lên, nạp danh sách mã khoa từ `tblKhoa`. Khi nhấn "Lưu": kiểm tra trùng mã môn học trong CSDL, lưu vào CSDL, cập nhật ListView và chuyển nút về "Thêm".
- **c)** Nút "Xóa": sáng lên khi click vào ListView; khi bấm sẽ xóa môn học khỏi CSDL và cập nhật lại ListView.
- **d)** Nút "Sửa": sáng lên khi click vào ListView; cho phép cập nhật thông tin môn học và lưu lại vào CSDL.

### Công việc 4: Form `frmDiem` (Hình 9.46)
- **1.** Hiển thị toàn bộ danh sách điểm lên ListView; click vào dòng nào thì đổ thông tin lên các ô nhập tương ứng.
- **2.** Chức năng "Thêm": kiểm tra dữ liệu nghiêm ngặt (không để trống, điểm phải từ 0 - 10, môn học phải tồn tại trong `tblMonHoc`, không cho phép trùng điểm). Nếu sai thì báo lỗi và không thêm.
- **3.** Chức năng "Xóa điểm": xóa tất cả các phần tử được chọn trên ListView (hỗ trợ chọn nhiều dòng cùng lúc).
- **4.** Chức năng "Sửa điểm": cho phép chỉnh sửa điểm và thông tin sinh viên, cập nhật CSDL và ListView.
- **5.** Chức năng "Tìm kiếm": tìm kiếm sinh viên theo từ khóa là Mã SV hoặc Tên SV.
- **6.** Chức năng "In": xem trước và in bảng điểm sinh viên rõ ràng, chuyên nghiệp.
