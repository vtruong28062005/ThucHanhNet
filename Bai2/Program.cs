using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapSinhVien
{
    class Program
    {
        // Danh sách học sinh dùng chung trong chương trình
        static List<SinhVien> dsHocSinh = new List<SinhVien>();

        static void Main(string[] args)
        {
            // Thiết lập bảng mã UTF-8 để hiển thị và nhập tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int luaChon;
            do
            {
                HienThiMenu();
                Console.Write("  => Nhập lựa chọn của bạn (0 - 7): ");
                while (!int.TryParse(Console.ReadLine(), out luaChon) || luaChon < 0 || luaChon > 7)
                {
                    Console.Write("  [!] Lựa chọn không hợp lệ, vui lòng nhập lại (0 - 7): ");
                }

                Console.WriteLine();
                switch (luaChon)
                {
                    case 1:
                        // a) Tạo danh sách học sinh
                        TaoDanhSachHocSinh();
                        break;
                    case 2:
                        // Xuất toàn bộ danh sách học sinh
                        XuatDanhSach(dsHocSinh, "TOÀN BỘ DANH SÁCH HỌC SINH");
                        break;
                    case 3:
                        // b) Sửa thông tin của một học sinh
                        SuaThongTinHocSinh();
                        break;
                    case 4:
                        // c) Xóa thông tin về một học sinh ra khỏi danh sách
                        XoaHocSinh();
                        break;
                    case 5:
                        // d) Đưa ra những học sinh có quê quán ở "Nam Định"
                        TimHocSinhNamDinh();
                        break;
                    case 6:
                        // e) Đưa ra những học sinh có điểm tổng kết lớn nhất
                        TimHocSinhDiemCaoNhat();
                        break;
                    case 7:
                        // Nạp dữ liệu mẫu nhanh
                        NapDuLieuMau();
                        break;
                    case 0:
                        Console.WriteLine("  Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.Write("Nhấn phím Enter để tiếp tục về Menu chính...");
                    Console.ReadLine();
                }
            } while (luaChon != 0);
        }

        // ================= GIAO DIỆN MENU CHÍNH =================
        static void HienThiMenu()
        {
            try
            {
                if (!Console.IsOutputRedirected && !Console.IsInputRedirected)
                {
                    Console.Clear();
                }
            }
            catch { }

            Console.WriteLine("============================================================");
            Console.WriteLine("        CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN / HỌC SINH (C#)      ");
            Console.WriteLine("============================================================");
            Console.WriteLine("  [1] a) Tạo danh sách học sinh                             ");
            Console.WriteLine("  [2]    Xuất toàn bộ danh sách học sinh                    ");
            Console.WriteLine("  [3] b) Sửa thông tin của một học sinh                     ");
            Console.WriteLine("  [4] c) Xóa thông tin về một học sinh ra khỏi danh sách    ");
            Console.WriteLine("  [5] d) Đưa ra những học sinh có quê quán ở \"Nam Định\"     ");
            Console.WriteLine("  [6] e) Đưa ra những học sinh có điểm tổng kết lớn nhất    ");
            Console.WriteLine("  [7]    Nạp danh sách dữ liệu học sinh mẫu                 ");
            Console.WriteLine("  [0]    Thoát chương trình                                 ");
            Console.WriteLine("============================================================");
            Console.WriteLine(string.Format("  (Hiện có {0} học sinh trong hệ thống)\n", dsHocSinh.Count));
        }

        // ================= a) TẠO DANH SÁCH HỌC SINH =================
        static void TaoDanhSachHocSinh()
        {
            Console.WriteLine("========== a) TẠO DANH SÁCH HỌC SINH ==========");
            Console.Write("Nhập số lượng học sinh cần thêm: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("[!] Vui lòng nhập số nguyên dương: ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Format("\n--- Nhập thông tin học sinh thứ {0} ---", dsHocSinh.Count + 1));
                SinhVien sv = new SinhVien();
                sv.Nhap();
                dsHocSinh.Add(sv);
            }

            Console.WriteLine(string.Format("\n=> Đã thêm thành công {0} học sinh vào danh sách!", n));
        }

        // ================= b) SỬA THÔNG TIN CỦA MỘT HỌC SINH =================
        static void SuaThongTinHocSinh()
        {
            Console.WriteLine("========== b) SỬA THÔNG TIN CỦA MỘT HỌC SINH ==========");
            if (KiemTraDanhSachRong()) return;

            XuatDanhSach(dsHocSinh, "DANH SÁCH HIỆN CÓ");
            Console.Write("\nNhập số thứ tự (STT) của học sinh cần sửa (1 - {0}): ", dsHocSinh.Count);
            int stt;
            while (!int.TryParse(Console.ReadLine(), out stt) || stt < 1 || stt > dsHocSinh.Count)
            {
                Console.Write(string.Format("[!] STT không hợp lệ, vui lòng nhập lại (1 - {0}): ", dsHocSinh.Count));
            }

            SinhVien sv = dsHocSinh[stt - 1];
            Console.WriteLine(string.Format("\nThông tin học sinh được chọn (STT {0}):", stt));
            sv.Xuat();

            sv.SuaThongTin();

            Console.WriteLine("\n=> Thông tin sau khi cập nhật:");
            sv.Xuat();
        }

        // ================= c) XÓA THÔNG TIN MỘT HỌC SINH KHỎI DANH SÁCH =================
        static void XoaHocSinh()
        {
            Console.WriteLine("========== c) XÓA THÔNG TIN VỀ MỘT HỌC SINH ==========");
            if (KiemTraDanhSachRong()) return;

            XuatDanhSach(dsHocSinh, "DANH SÁCH HIỆN CÓ");
            Console.Write("\nNhập số thứ tự (STT) của học sinh muốn xóa (1 - {0}): ", dsHocSinh.Count);
            int stt;
            while (!int.TryParse(Console.ReadLine(), out stt) || stt < 1 || stt > dsHocSinh.Count)
            {
                Console.Write(string.Format("[!] STT không hợp lệ, vui lòng nhập lại (1 - {0}): ", dsHocSinh.Count));
            }

            SinhVien svCanXoa = dsHocSinh[stt - 1];
            Console.WriteLine(string.Format("\nBạn chuẩn bị xóa học sinh: \"{0}\" (Quê quán: {1})", svCanXoa.HoTen, svCanXoa.QueQuan));
            Console.Write("Bạn có chắc chắn muốn xóa không? (c/k): ");
            string xacNhan = Console.ReadLine();

            if (xacNhan != null && (xacNhan.Trim().ToLower() == "c" || xacNhan.Trim().ToLower() == "y"))
            {
                dsHocSinh.RemoveAt(stt - 1);
                Console.WriteLine("=> Đã xóa học sinh ra khỏi danh sách thành công!");
            }
            else
            {
                Console.WriteLine("=> Đã hủy thao tác xóa.");
            }
        }

        // ================= d) ĐƯA RA NHỮNG HỌC SINH CÓ QUÊ QUÁN Ở "NAM ĐỊNH" =================
        static void TimHocSinhNamDinh()
        {
            Console.WriteLine("========== d) DANH SÁCH HỌC SINH CÓ QUÊ QUÁN Ở \"NAM ĐỊNH\" ==========");
            if (KiemTraDanhSachRong()) return;

            List<SinhVien> dsNamDinh = new List<SinhVien>();
            for (int i = 0; i < dsHocSinh.Count; i++)
            {
                string que = dsHocSinh[i].QueQuan.Trim();
                // Kiểm tra quê quán chứa "Nam Định" hoặc "Nam Dinh" (không phân biệt hoa/thường)
                if (que.IndexOf("Nam Định", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    que.IndexOf("Nam Dinh", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dsNamDinh.Add(dsHocSinh[i]);
                }
            }

            if (dsNamDinh.Count > 0)
            {
                XuatDanhSach(dsNamDinh, string.Format("KẾT QUẢ: TÌM THẤY {0} HỌC SINH QUÊ NAM ĐỊNH", dsNamDinh.Count));
            }
            else
            // {
                Console.WriteLine("=> Không có học sinh nào trong danh sách có quê quán ở \"Nam Định\".");
            }
        }

        // ================= e) ĐƯA RA NHỮNG HỌC SINH CÓ ĐIỂM TỔNG KẾT LỚN NHẤT =================
        static void TimHocSinhDiemCaoNhat()
        {
            Console.WriteLine("========== e) NHỮNG HỌC SINH CÓ ĐIỂM TỔNG KẾT LỚN NHẤT ==========");
            if (KiemTraDanhSachRong()) return;

            // 1. Tìm điểm tổng kết lớn nhất
            double maxDiem = dsHocSinh[0].DiemTongKet;
            for (int i = 1; i < dsHocSinh.Count; i++)
            {
                if (dsHocSinh[i].DiemTongKet > maxDiem)
                {
                    maxDiem = dsHocSinh[i].DiemTongKet;
                }
            }

            // 2. Lấy tất cả học sinh đạt điểm lớn nhất này (có thể có nhiều thủ khoa)
            List<SinhVien> dsThuKhoa = new List<SinhVien>();
            for (int i = 0; i < dsHocSinh.Count; i++)
            {
                if (Math.Abs(dsHocSinh[i].DiemTongKet - maxDiem) < 0.0001)
                {
                    dsThuKhoa.Add(dsHocSinh[i]);
                }
            }

            Console.WriteLine(string.Format("=> Điểm tổng kết lớn nhất đạt được: {0:0.00}", maxDiem));
            XuatDanhSach(dsThuKhoa, string.Format("DANH SÁCH THỦ KHOA (ĐIỂM CAO NHẤT: {0:0.00})", maxDiem));
        }

        // ================= NẠP DỮ LIỆU MẪU =================
        static void NapDuLieuMau()
        {
            Console.WriteLine("========== NẠP DỮ LIỆU HỌC SINH MẪU ==========");
            dsHocSinh.Clear();
            dsHocSinh.Add(new SinhVien("Trần Văn Bảo", "Nam Định", 2004, 9.5));
            dsHocSinh.Add(new SinhVien("Nguyễn Thị Mai", "Hà Nội", 2004, 8.8));
            dsHocSinh.Add(new SinhVien("Lê Hoàng Nam", "Nam Định", 2003, 9.5)); // Cùng đạt 9.5 để test câu e
            dsHocSinh.Add(new SinhVien("Phạm Quỳnh Chi", "Đà Nẵng", 2005, 7.5));
            dsHocSinh.Add(new SinhVien("Vũ Minh Tuấn", "Nam Định", 2004, 8.0));
            dsHocSinh.Add(new SinhVien("Đỗ Thu Hà", "Hải Phòng", 2003, 6.4));

            Console.WriteLine("=> Đã nạp thành công 6 học sinh mẫu (có 3 bạn quê Nam Định và 2 thủ khoa 9.5 điểm)!");
            XuatDanhSach(dsHocSinh, "DANH SÁCH VỪA NẠP");
        }

        // ================= CÁC HÀM XUẤT BẢNG VÀ PHỤ TRỢ =================
        static void XuatDanhSach(List<SinhVien> ds, string tieuDe)
        {
            if (ds == null || ds.Count == 0)
            {
                Console.WriteLine("  [Danh sách hiện tại đang trống!]");
                return;
            }

            Console.WriteLine("\n=========================================================================================");
            Console.WriteLine(string.Format("                         {0}                         ", tieuDe));
            InDuongKeBang();
            Console.WriteLine(string.Format("| {0,-4} | {1,-22} | {2,-15} | {3,-8} | {4,-13} | {5,-10} |",
                "STT", "Họ và Tên", "Quê Quán", "Năm Sinh", "Điểm TK", "Xếp Loại"));
            InDuongKeBang();

            for (int i = 0; i < ds.Count; i++)
            {
                ds[i].XuatDong(i + 1);
            }
            InDuongKeBang();
            Console.WriteLine(string.Format("  Tổng cộng: {0} học sinh", ds.Count));
        }

        static void InDuongKeBang()
        {
            Console.WriteLine("+------+------------------------+-----------------+----------+---------------+------------+");
        }

        static bool KiemTraDanhSachRong()
        {
            if (dsHocSinh.Count == 0)
            {
                Console.WriteLine("  [!] Danh sách hiện đang trống! Vui lòng chọn [1] để tạo danh sách hoặc [7] để nạp dữ liệu mẫu trước.");
                return true;
            }
            return false;
        }
    }
}
