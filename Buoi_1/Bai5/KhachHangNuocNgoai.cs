using System;

namespace QuanLyHoaDonTienDien
{
    // Lớp Khách Hàng Nước Ngoài thừa kế Khách Hàng
    public class KhachHangNuocNgoai : KhachHang
    {
        // Thuộc tính riêng của Khách hàng nước ngoài
        private string quocTich;

        // ================= 1. HÀM TẠO (CONSTRUCTORS) =================
        // Hàm tạo mặc định
        public KhachHangNuocNgoai() : base()
        {
            this.quocTich = "";
        }

        // Hàm tạo có tham số
        public KhachHangNuocNgoai(string maKhachHang, string hoTen, DateTime ngayHoaDon,
                                 double soLuong, double donGia, string quocTich)
            : base(maKhachHang, hoTen, ngayHoaDon, soLuong, donGia)
        {
            this.quocTich = quocTich;
            TinhThanhTien();
        }

        // ================= 2. HÀM HỦY (DESTRUCTOR) =================
        ~KhachHangNuocNgoai()
        {
            // Giải phóng tài nguyên
        }

        // ================= 3. GETTER / SETTER =================
        public string QuocTich
        {
            get { return quocTich; }
            set { quocTich = value; }
        }

        // ================= 4. TÍNH THÀNH TIỀN =================
        // Công thức tính tiền điện cho Khách hàng nước ngoài:
        // Thành tiền = Số lượng * Đơn giá
        public override double TinhThanhTien()
        {
            thanhTien = soLuong * donGia;
            return thanhTien;
        }

        // ================= 5. PHƯƠNG THỨC NHẬP =================
        public override void Nhap()
        {
            base.Nhap();

            // Nhập Quốc tịch
            Console.Write("  - Nhập quốc tịch: ");
            quocTich = Console.ReadLine();
            while (string.IsNullOrEmpty(quocTich) || quocTich.Trim().Length == 0)
            {
                Console.Write("  [!] Quốc tịch không được để trống, nhập lại: ");
                quocTich = Console.ReadLine();
            }
            quocTich = quocTich.Trim();

            // Tính thành tiền sau khi nhập
            TinhThanhTien();
        }

        // ================= 6. PHƯƠNG THỨC XUẤT =================
        public override void Xuat()
        {
            Console.WriteLine("--- [KHÁCH HÀNG NƯỚC NGOÀI] ---");
            base.Xuat();
            Console.WriteLine(string.Format("  + Quốc tịch     : {0}", quocTich));
        }

        // Xuất định dạng 1 dòng trên bảng tổng hợp
        public override void XuatDong(int stt)
        {
            string nnDisplay = "NN (" + quocTich + ")";
            if (nnDisplay.Length > 20) nnDisplay = nnDisplay.Substring(0, 20);
            Console.WriteLine(string.Format("| {0,-4} | {1,-9} | {2,-22} | {3,-10:dd/MM/yyyy} | {4,-20} | {5,10:N1} | {6,10:N0} | {7,10} | {8,15:N0} |",
                stt, maKhachHang, hoTen, ngayHoaDon, nnDisplay, soLuong, donGia, "-", thanhTien));
        }
    }
}
