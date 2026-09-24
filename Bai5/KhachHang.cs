using System;
using System.Globalization;

namespace QuanLyHoaDonTienDien
{
    // Lớp cơ sở trừu tượng Khách Hàng
    public abstract class KhachHang
    {
        // Các thuộc tính theo yêu cầu đề bài
        protected string maKhachHang;
        protected string hoTen;
        protected DateTime ngayHoaDon;
        protected double soLuong;      // Số lượng điện tiêu thụ (KW)
        protected double donGia;       // Đơn giá (VNĐ/KW)
        protected double thanhTien;    // Thành tiền (VNĐ)

        // ================= 1. HÀM TẠO (CONSTRUCTORS) =================
        // Hàm tạo không tham số (mặc định)
        public KhachHang()
        {
            this.maKhachHang = "";
            this.hoTen = "";
            this.ngayHoaDon = DateTime.Now;
            this.soLuong = 0;
            this.donGia = 0;
            this.thanhTien = 0;
        }

        // Hàm tạo có tham số
        public KhachHang(string maKhachHang, string hoTen, DateTime ngayHoaDon, double soLuong, double donGia)
        {
            this.maKhachHang = maKhachHang;
            this.hoTen = hoTen;
            this.ngayHoaDon = ngayHoaDon;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thanhTien = 0; // Sẽ được tính bởi lớp con
        }

        // ================= 2. HÀM HỦY (DESTRUCTOR) =================
        ~KhachHang()
        {
            // Giải phóng tài nguyên nếu có
        }

        // ================= 3. GETTER / SETTER =================
        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgayHoaDon
        {
            get { return ngayHoaDon; }
            set { ngayHoaDon = value; }
        }

        public double SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        // ================= 4. PHƯƠNG THỨC TÍNH THÀNH TIỀN =================
        // Phương thức trừu tượng để từng lớp con hiện thực theo quy tắc riêng
        public abstract double TinhThanhTien();

        // ================= 5. PHƯƠNG THỨC NHẬP =================
        public virtual void Nhap()
        {
            // Nhập Mã khách hàng
            Console.Write("  - Nhập mã khách hàng: ");
            maKhachHang = Console.ReadLine();
            while (string.IsNullOrEmpty(maKhachHang) || maKhachHang.Trim().Length == 0)
            {
                Console.Write("  [!] Mã khách hàng không được để trống, nhập lại: ");
                maKhachHang = Console.ReadLine();
            }
            maKhachHang = maKhachHang.Trim();

            // Nhập Họ tên khách hàng
            Console.Write("  - Nhập họ tên khách hàng: ");
            hoTen = Console.ReadLine();
            while (string.IsNullOrEmpty(hoTen) || hoTen.Trim().Length == 0)
            {
                Console.Write("  [!] Họ tên không được để trống, nhập lại: ");
                hoTen = Console.ReadLine();
            }
            hoTen = hoTen.Trim();

            // Nhập Ngày hóa đơn (ngày, tháng, năm)
            Console.Write("  - Nhập ngày hóa đơn (dd/MM/yyyy, ví dụ 15/09/2020): ");
            DateTime dt;
            string inputDate = Console.ReadLine();
            string[] formats = new string[] { "d/M/yyyy", "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy" };
            while (!DateTime.TryParseExact(inputDate != null ? inputDate.Trim() : "", formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                Console.Write("  [!] Định dạng ngày không đúng (dd/MM/yyyy), nhập lại: ");
                inputDate = Console.ReadLine();
            }
            ngayHoaDon = dt;

            // Nhập Số lượng (KW tiêu thụ)
            Console.Write("  - Nhập số lượng điện tiêu thụ (KW > 0): ");
            double sl;
            string inputSl = Console.ReadLine();
            while (!double.TryParse(inputSl != null ? inputSl.Replace(',', '.') : "", NumberStyles.Any, CultureInfo.InvariantCulture, out sl) || sl <= 0)
            {
                Console.Write("  [!] Số lượng phải là số thực lớn hơn 0, nhập lại: ");
                inputSl = Console.ReadLine();
            }
            soLuong = sl;

            // Nhập Đơn giá
            Console.Write("  - Nhập đơn giá (VNĐ/KW > 0): ");
            double dg;
            string inputDg = Console.ReadLine();
            while (!double.TryParse(inputDg != null ? inputDg.Replace(',', '.') : "", NumberStyles.Any, CultureInfo.InvariantCulture, out dg) || dg <= 0)
            {
                Console.Write("  [!] Đơn giá phải là số thực lớn hơn 0, nhập lại: ");
                inputDg = Console.ReadLine();
            }
            donGia = dg;
        }

        // ================= 6. PHƯƠNG THỨC XUẤT =================
        // Xuất thông tin chi tiết
        public virtual void Xuat()
        {
            Console.WriteLine(string.Format("  + Mã khách hàng : {0}", maKhachHang));
            Console.WriteLine(string.Format("  + Họ tên        : {0}", hoTen));
            Console.WriteLine(string.Format("  + Ngày hóa đơn  : {0:dd/MM/yyyy}", ngayHoaDon));
            Console.WriteLine(string.Format("  + Số lượng điện : {0:N1} KW", soLuong));
            Console.WriteLine(string.Format("  + Đơn giá       : {0:N0} VNĐ/KW", donGia));
            Console.WriteLine(string.Format("  + Thành tiền    : {0:N0} VNĐ", thanhTien));
        }

        // Xuất một dòng trong bảng hiển thị
        public abstract void XuatDong(int stt);
    }
}
