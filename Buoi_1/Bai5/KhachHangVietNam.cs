using System;
using System.Globalization;

namespace QuanLyHoaDonTienDien
{
    // Lớp Khách Hàng Việt Nam thừa kế Khách Hàng
    public class KhachHangVietNam : KhachHang
    {
        // Các thuộc tính riêng của Khách hàng Việt Nam
        private string loaiKhachHang; // "Sinh hoạt", "Kinh doanh", "Sản xuất"
        private double dinhMuc;      // Định mức điện tiêu thụ (KW)

        // ================= 1. HÀM TẠO (CONSTRUCTORS) =================
        // Hàm tạo mặc định
        public KhachHangVietNam() : base()
        {
            this.loaiKhachHang = "";
            this.dinhMuc = 0;
        }

        // Hàm tạo có tham số
        public KhachHangVietNam(string maKhachHang, string hoTen, DateTime ngayHoaDon, 
                                double soLuong, double donGia, string loaiKhachHang, double dinhMuc)
            : base(maKhachHang, hoTen, ngayHoaDon, soLuong, donGia)
        {
            this.loaiKhachHang = loaiKhachHang;
            this.dinhMuc = dinhMuc;
            TinhThanhTien();
        }

        // ================= 2. HÀM HỦY (DESTRUCTOR) =================
        ~KhachHangVietNam()
        {
            // Giải phóng tài nguyên
        }

        // ================= 3. GETTER / SETTER =================
        public string LoaiKhachHang
        {
            get { return loaiKhachHang; }
            set { loaiKhachHang = value; }
        }

        public double DinhMuc
        {
            get { return dinhMuc; }
            set { dinhMuc = value; }
        }

        // ================= 4. TÍNH THÀNH TIỀN =================
        // Công thức tính tiền điện cho Khách hàng Việt Nam:
        // - Nếu số lượng <= định mức: Thành tiền = số lượng * đơn giá
        // - Nếu số lượng > định mức: Thành tiền = (định mức * đơn giá) + ((số lượng - định mức) * đơn giá * 2.5)
        public override double TinhThanhTien()
        {
            if (soLuong <= dinhMuc)
            {
                thanhTien = soLuong * donGia;
            }
            else
            {
                thanhTien = (dinhMuc * donGia) + ((soLuong - dinhMuc) * donGia * 2.5);
            }
            return thanhTien;
        }

        // ================= 5. PHƯƠNG THỨC NHẬP =================
        public override void Nhap()
        {
            base.Nhap();

            // Nhập loại khách hàng (Sinh hoạt / Kinh doanh / Sản xuất)
            Console.WriteLine("  - Chọn đối tượng khách hàng:");
            Console.WriteLine("      [1] Sinh hoạt");
            Console.WriteLine("      [2] Kinh doanh");
            Console.WriteLine("      [3] Sản xuất");
            Console.Write("    => Nhập lựa chọn (1 - 3) hoặc gõ trực tiếp tên loại: ");
            string inputLoai = Console.ReadLine();
            while (string.IsNullOrEmpty(inputLoai) || inputLoai.Trim().Length == 0)
            {
                Console.Write("    [!] Không được để trống, vui lòng chọn lại: ");
                inputLoai = Console.ReadLine();
            }
            inputLoai = inputLoai.Trim();
            if (inputLoai == "1") loaiKhachHang = "Sinh hoạt";
            else if (inputLoai == "2") loaiKhachHang = "Kinh doanh";
            else if (inputLoai == "3") loaiKhachHang = "Sản xuất";
            else loaiKhachHang = inputLoai;

            // Nhập định mức tiêu thụ
            Console.Write("  - Nhập định mức tiêu thụ (KW > 0): ");
            double dm;
            string inputDm = Console.ReadLine();
            while (!double.TryParse(inputDm != null ? inputDm.Replace(',', '.') : "", NumberStyles.Any, CultureInfo.InvariantCulture, out dm) || dm <= 0)
            {
                Console.Write("  [!] Định mức phải là số thực lớn hơn 0, nhập lại: ");
                inputDm = Console.ReadLine();
            }
            dinhMuc = dm;

            // Tính thành tiền ngay sau khi có đủ thông tin
            TinhThanhTien();
        }

        // ================= 6. PHƯƠNG THỨC XUẤT =================
        public override void Xuat()
        {
            Console.WriteLine("--- [KHÁCH HÀNG VIỆT NAM] ---");
            base.Xuat();
            Console.WriteLine(string.Format("  + Loại khách    : {0}", loaiKhachHang));
            Console.WriteLine(string.Format("  + Định mức      : {0:N1} KW", dinhMuc));
        }

        // Xuất định dạng 1 dòng trên bảng tổng hợp
        public override void XuatDong(int stt)
        {
            string loaiDisplay = "VN (" + loaiKhachHang + ")";
            if (loaiDisplay.Length > 20) loaiDisplay = loaiDisplay.Substring(0, 20);
            Console.WriteLine(string.Format("| {0,-4} | {1,-9} | {2,-22} | {3,-10:dd/MM/yyyy} | {4,-20} | {5,10:N1} | {6,10:N0} | {7,10:N1} | {8,15:N0} |",
                stt, maKhachHang, hoTen, ngayHoaDon, loaiDisplay, soLuong, donGia, dinhMuc, thanhTien));
        }
    }
}
