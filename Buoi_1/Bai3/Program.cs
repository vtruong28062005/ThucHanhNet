using System;
using System.Text;

namespace Bai3
{
    // ==========================================
    // XÂY DỰNG LỚP VẬN ĐỘNG VIÊN (VanDongVien)
    // ==========================================
    public class VanDongVien
    {
        // 1. Thuộc tính (fields)
        private string hoten;
        private int tuoi;
        private string monthidau;
        private double cannang;
        private double chieucao;

        // Các thuộc tính đóng gói (Properties)
        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }

        public string MonThiDau
        {
            get { return monthidau; }
            set { monthidau = value; }
        }

        public double CanNang
        {
            get { return cannang; }
            set { cannang = value; }
        }

        public double ChieuCao
        {
            get { return chieucao; }
            set { chieucao = value; }
        }

        // 2. Phương thức thiết lập không tham số (Default Constructor)
        public VanDongVien()
        {
            hoten = "";
            tuoi = 0;
            monthidau = "";
            cannang = 0.0;
            chieucao = 0.0;
        }

        // 3. Phương thức thiết lập 5 tham số (Parameterized Constructor)
        public VanDongVien(string hoten, int tuoi, string monthidau, double cannang, double chieucao)
        {
            this.hoten = hoten;
            this.tuoi = tuoi;
            this.monthidau = monthidau;
            this.cannang = cannang;
            this.chieucao = chieucao;
        }

        // 4. Phương thức hủy bỏ (Destructor / Finalizer)
        ~VanDongVien()
        {
            // Tự động được bộ thu gom rác (Garbage Collector) giải phóng khi đối tượng không còn dùng
        }

        // 5. Phương thức nhập thông tin vận động viên
        public void Nhap()
        {
            Console.Write("  - Nhập họ và tên: ");
            hoten = Console.ReadLine();

            Console.Write("  - Nhập tuổi: ");
            while (!int.TryParse(Console.ReadLine(), out tuoi) || tuoi <= 0)
            {
                Console.Write("    Tuổi không hợp lệ! Vui lòng nhập lại: ");
            }

            Console.Write("  - Nhập môn thi đấu: ");
            monthidau = Console.ReadLine();

            Console.Write("  - Nhập cân nặng (kg): ");
            while (!double.TryParse(Console.ReadLine(), out cannang) || cannang <= 0)
            {
                Console.Write("    Cân nặng không hợp lệ! Vui lòng nhập lại: ");
            }

            Console.Write("  - Nhập chiều cao (m): ");
            while (!double.TryParse(Console.ReadLine(), out chieucao) || chieucao <= 0)
            {
                Console.Write("    Chiều cao không hợp lệ! Vui lòng nhập lại: ");
            }
        }

        // 6. Phương thức xuất thông tin chi tiết
        public void Xuat()
        {
            Console.WriteLine("Họ tên: {0,-20} | Tuổi: {1,-3} | Môn: {2,-15} | Cân nặng: {3,5} kg | Chiều cao: {4,4} m", 
                hoten, tuoi, monthidau, cannang, chieucao);
        }

        // Phương thức xuất dạng dòng kẻ bảng cho danh sách
        public void XuatHang(int stt)
        {
            Console.WriteLine("| {0,-4} | {1,-22} | {2,-5} | {3,-18} | {4,-14} | {5,-13} |", 
                stt, hoten, tuoi, monthidau, cannang, chieucao);
        }
    }

    // ==========================================
    // CHƯƠNG TRÌNH CHÍNH (Program)
    // ==========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt có dấu trong Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       CHƯƠNG TRÌNH QUẢN LÝ VẬN ĐỘNG VIÊN                      ");
            Console.WriteLine("===============================================================================\n");

            // -------------------------------------------------------------
            // Yêu cầu 1: Khai báo p là đối tượng lớp VanDongVien
            // (sử dụng hàm thiết lập 5 tham số), hiển thị thông tin của p
            // -------------------------------------------------------------
            Console.WriteLine("--- 1. KHỞI TẠO ĐỐI TƯỢNG p (HÀM THIẾT LẬP 5 THAM SỐ) ---");
            VanDongVien p = new VanDongVien("Nguyễn Văn An", 23, "Bơi lội", 70.5, 1.80);
            Console.WriteLine("Thông tin của vận động viên p:");
            p.Xuat();
            Console.WriteLine();

            // -------------------------------------------------------------
            // Yêu cầu 2: Nhập vào một mảng gồm n vận động viên
            // -------------------------------------------------------------
            Console.WriteLine("--- 2. NHẬP MẢNG GỒM n VẬN ĐỘNG VIÊN ---");
            int n;
            Console.Write("Nhập số lượng vận động viên n = ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Số lượng n phải là số nguyên dương (> 0). Vui lòng nhập lại: ");
            }

            // Khai báo mảng gồm n phần tử
            VanDongVien[] ds = new VanDongVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n[Vận động viên thứ {0}]:", i + 1);
                ds[i] = new VanDongVien(); // Sử dụng hàm thiết lập không tham số
                ds[i].Nhap();
            }

            // -------------------------------------------------------------
            // Yêu cầu 3: Hiển thị danh sách đã nhập ra màn hình
            // -------------------------------------------------------------
            Console.WriteLine("\n--- 3. DANH SÁCH VẬN ĐỘNG VIÊN ĐÃ NHẬP ---");
            InTieuDeBang();
            for (int i = 0; i < n; i++)
            {
                ds[i].XuatHang(i + 1);
            }
            InDuongKeBang();

            Console.WriteLine("\nHoàn thành! Nhấn phím Enter để kết thúc...");
            Console.ReadLine();
        }

        static void InTieuDeBang()
        {
            InDuongKeBang();
            Console.WriteLine("| {0,-4} | {1,-22} | {2,-5} | {3,-18} | {4,-14} | {5,-13} |", 
                "STT", "Họ và tên", "Tuổi", "Môn thi đấu", "Cân nặng (kg)", "Chiều cao (m)");
            InDuongKeBang();
        }

        static void InDuongKeBang()
        {
            Console.WriteLine("+------+------------------------+-------+--------------------+----------------+---------------+");
        }
    }
}
