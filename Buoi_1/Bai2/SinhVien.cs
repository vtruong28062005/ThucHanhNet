using System;

namespace BaiTapSinhVien
{
    public class SinhVien
    {
        // ================= 1. THUỘC TÍNH (FIELDS & PROPERTIES) =================
        private string hoTen;
        private string queQuan;
        private int namSinh;
        private double diemTongKet;

        // Họ và tên
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        // Quê quán
        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        // Năm sinh
        public int NamSinh
        {
            get { return namSinh; }
            set
            {
                int namHienTai = DateTime.Now.Year;
                if (value >= 1900 && value <= namHienTai)
                {
                    namSinh = value;
                }
                else
                {
                    namSinh = 2000;
                }
            }
        }

        // Điểm tổng kết (thang điểm 0 - 10)
        public double DiemTongKet
        {
            get { return diemTongKet; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemTongKet = value;
                }
                else
                {
                    diemTongKet = 0;
                }
            }
        }

        // ================= 2. CÁC HÀM TẠO (CONSTRUCTORS) =================
        // - Hàm tạo mặc định không tham số
        public SinhVien()
        {
            hoTen = "";
            queQuan = "";
            namSinh = 2000;
            diemTongKet = 0.0;
        }

        // - Hàm tạo có tham số
        public SinhVien(string hoTen, string queQuan, int namSinh, double diemTongKet)
        {
            this.hoTen = hoTen;
            this.queQuan = queQuan;
            this.NamSinh = namSinh;
            this.DiemTongKet = diemTongKet;
        }

        // ================= 3. HÀM HỦY (DESTRUCTOR / FINALIZER) =================
        ~SinhVien()
        {
            // Trong C#, bộ thu gom rác (Garbage Collector) sẽ tự động dọn dẹp bộ nhớ.
            // Destructor được gọi khi đối tượng bị giải phóng khỏi bộ nhớ.
        }

        // ================= 4. PHƯƠNG THỨC NHẬP =================
        public void Nhap()
        {
            // Nhập họ và tên
            Console.Write("  - Nhập họ và tên: ");
            hoTen = Console.ReadLine();
            while (string.IsNullOrEmpty(hoTen) || hoTen.Trim().Length == 0)
            {
                Console.Write("  [!] Họ tên không được để trống, vui lòng nhập lại: ");
                hoTen = Console.ReadLine();
            }
            hoTen = hoTen.Trim();

            // Nhập quê quán
            Console.Write("  - Nhập quê quán: ");
            queQuan = Console.ReadLine();
            while (string.IsNullOrEmpty(queQuan) || queQuan.Trim().Length == 0)
            {
                Console.Write("  [!] Quê quán không được để trống, vui lòng nhập lại: ");
                queQuan = Console.ReadLine();
            }
            queQuan = queQuan.Trim();

            // Nhập năm sinh
            int namHienTai = DateTime.Now.Year;
            Console.Write(string.Format("  - Nhập năm sinh (1900 - {0}): ", namHienTai));
            int ns;
            while (!int.TryParse(Console.ReadLine(), out ns) || ns < 1900 || ns > namHienTai)
            {
                Console.Write(string.Format("  [!] Năm sinh không hợp lệ, vui lòng nhập lại (1900 - {0}): ", namHienTai));
            }
            namSinh = ns;

            // Nhập điểm tổng kết
            Console.Write("  - Nhập điểm tổng kết (0.0 - 10.0): ");
            double diem;
            string inputDiem = Console.ReadLine();
            while (!double.TryParse(inputDiem.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out diem)
                   || diem < 0 || diem > 10)
            {
                Console.Write("  [!] Điểm phải là số thực từ 0 đến 10, vui lòng nhập lại: ");
                inputDiem = Console.ReadLine();
            }
            diemTongKet = diem;
        }

        // ================= 5. PHƯƠNG THỨC SỬA THÔNG TIN =================
        public void SuaThongTin()
        {
            Console.WriteLine("\n  --- CẬP NHẬT THÔNG TIN HỌC SINH ---");
            Console.WriteLine("  (Nhấn Enter để giữ nguyên thông tin cũ)");

            // Sửa Họ tên
            Console.Write(string.Format("  - Họ tên hiện tại [{0}] -> Đổi thành: ", hoTen));
            string tenMoi = Console.ReadLine();
            if (!string.IsNullOrEmpty(tenMoi) && tenMoi.Trim().Length > 0)
            {
                hoTen = tenMoi.Trim();
            }

            // Sửa Quê quán
            Console.Write(string.Format("  - Quê quán hiện tại [{0}] -> Đổi thành: ", queQuan));
            string queMoi = Console.ReadLine();
            if (!string.IsNullOrEmpty(queMoi) && queMoi.Trim().Length > 0)
            {
                queQuan = queMoi.Trim();
            }

            // Sửa Năm sinh
            int namHienTai = DateTime.Now.Year;
            Console.Write(string.Format("  - Năm sinh hiện tại [{0}] -> Đổi thành: ", namSinh));
            string nsMoi = Console.ReadLine();
            if (!string.IsNullOrEmpty(nsMoi) && nsMoi.Trim().Length > 0)
            {
                int ns;
                while (!int.TryParse(nsMoi, out ns) || ns < 1900 || ns > namHienTai)
                {
                    Console.Write(string.Format("  [!] Năm sinh không hợp lệ (1900 - {0}), nhập lại: ", namHienTai));
                    nsMoi = Console.ReadLine();
                }
                namSinh = ns;
            }

            // Sửa Điểm tổng kết
            Console.Write(string.Format("  - Điểm tổng kết hiện tại [{0:0.00}] -> Đổi thành: ", diemTongKet));
            string diemMoiStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(diemMoiStr) && diemMoiStr.Trim().Length > 0)
            {
                double diemMoi;
                while (!double.TryParse(diemMoiStr.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out diemMoi)
                       || diemMoi < 0 || diemMoi > 10)
                {
                    Console.Write("  [!] Điểm phải từ 0 đến 10, nhập lại: ");
                    diemMoiStr = Console.ReadLine();
                }
                diemTongKet = diemMoi;
            }

            Console.WriteLine("  => Cập nhật thông tin thành công!");
        }

        // ================= 6. PHƯƠNG THỨC XUẤT =================
        public void Xuat()
        {
            Console.WriteLine(string.Format("  + Họ và tên     : {0}", hoTen));
            Console.WriteLine(string.Format("  + Quê quán      : {0}", queQuan));
            Console.WriteLine(string.Format("  + Năm sinh      : {0} ({1} tuổi)", namSinh, TinhTuoi()));
            Console.WriteLine(string.Format("  + Điểm tổng kết : {0:0.00}", diemTongKet));
            Console.WriteLine(string.Format("  + Xếp loại      : {0}", XepLoai()));
        }

        // Xuất thông tin dạng dòng trên bảng
        public void XuatDong(int stt)
        {
            Console.WriteLine(string.Format("| {0,-4} | {1,-22} | {2,-15} | {3,-8} | {4,-13:0.00} | {5,-10} |",
                stt, hoTen, queQuan, namSinh, diemTongKet, XepLoai()));
        }

        // Phương thức phụ trợ tính tuổi
        public int TinhTuoi()
        {
            return DateTime.Now.Year - namSinh;
        }

        // Phương thức phụ trợ xếp loại học lực
        public string XepLoai()
        {
            if (diemTongKet >= 9.0) return "Xuất sắc";
            if (diemTongKet >= 8.0) return "Giỏi";
            if (diemTongKet >= 6.5) return "Khá";
            if (diemTongKet >= 5.0) return "Trung bình";
            return "Yếu";
        }
    }
}
