using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyHoaDonTienDien
{
    class Program
    {
        // Danh sách lưu trữ các hóa đơn khách hàng (bao gồm cả KH Việt Nam và KH Nước ngoài)
        static List<KhachHang> dsKhachHang = new List<KhachHang>();

        static void Main(string[] args)
        {
            // Thiết lập bảng mã hiển thị UTF-8 tiếng Việt cho Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int luaChon = -1;
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
                        // b. Nhập danh sách các hóa đơn khách hàng
                        NhapDanhSachHoaDon();
                        break;
                    case 2:
                        // b. Xuất toàn bộ danh sách hóa đơn khách hàng
                        XuatDanhSach(dsKhachHang, "TOÀN BỘ DANH SÁCH HÓA ĐƠN KHÁCH HÀNG");
                        break;
                    case 3:
                        // Xuất danh sách theo từng loại khách hàng (Việt Nam & Nước ngoài)
                        XuatDanhSachTheoLoai();
                        break;
                    case 4:
                        // c. Tính tổng số lượng điện tiêu thụ cho từng loại khách hàng
                        TinhTongSoLuongDienTungLoai();
                        break;
                    case 5:
                        // d. Tính trung bình thành tiền của khách hàng người nước ngoài
                        TinhTrungBinhThanhTienKhachNuocNgoai();
                        break;
                    case 6:
                        // e. Xuất ra các hóa đơn trong tháng 09 năm 2020 (của 2 loại khách hàng)
                        XuatHoaDonThang9Nam2020();
                        break;
                    case 7:
                        // Nạp dữ liệu mẫu để kiểm thử nhanh
                        NapDuLieuMau();
                        break;
                    case 0:
                        Console.WriteLine("============================================================");
                        Console.WriteLine("  Cảm ơn bạn đã sử dụng chương trình! Tạm biệt.");
                        Console.WriteLine("============================================================");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------");
                    Console.Write("Nhấn phím Enter để tiếp tục về Menu chính...");
                    Console.ReadLine();
                    try { Console.Clear(); } catch { }
                }

            } while (luaChon != 0);
        }

        // ================= HIỂN THỊ MENU =================
        static void HienThiMenu()
        {
            Console.WriteLine("=================================================================================");
            Console.WriteLine("             CHƯƠNG TRÌNH QUẢN LÝ HÓA ĐƠN TIỀN ĐIỆN KHÁCH HÀNG (C#)              ");
            Console.WriteLine("=================================================================================");
            Console.WriteLine("  [1] b) Nhập thêm hóa đơn khách hàng (Việt Nam / Nước ngoài)                   ");
            Console.WriteLine("  [2] b) Xuất toàn bộ danh sách các hóa đơn khách hàng                          ");
            Console.WriteLine("  [3]    Xuất danh sách phân loại (Riêng KH Việt Nam và KH Nước ngoài)          ");
            Console.WriteLine("  [4] c) Tính tổng số lượng điện tiêu thụ cho từng loại khách hàng              ");
            Console.WriteLine("  [5] d) Tính trung bình thành tiền của khách hàng người nước ngoài             ");
            Console.WriteLine("  [6] e) Xuất các hóa đơn trong tháng 09 năm 2020 (của cả 2 loại khách hàng)    ");
            Console.WriteLine("  [7]    Nạp dữ liệu hóa đơn mẫu (Mock Data kiểm thử nhanh)                     ");
            Console.WriteLine("  [0]    Thoát chương trình                                                     ");
            Console.WriteLine("=================================================================================");
            Console.WriteLine(string.Format("  (Hiện có: {0} hóa đơn trong hệ thống)", dsKhachHang.Count));
            Console.WriteLine();
        }

        // ================= b) NHẬP DANH SÁCH HÓA ĐƠN KHÁCH HÀNG =================
        static void NhapDanhSachHoaDon()
        {
            Console.WriteLine("=================== b) NHẬP DANH SÁCH HÓA ĐƠN KHÁCH HÀNG ===================");
            Console.WriteLine("  Chọn loại khách hàng cần nhập:");
            Console.WriteLine("    [1] Khách hàng Việt Nam");
            Console.WriteLine("    [2] Khách hàng Nước ngoài");
            Console.Write("  => Nhập lựa chọn (1 hoặc 2): ");
            int loai;
            while (!int.TryParse(Console.ReadLine(), out loai) || (loai != 1 && loai != 2))
            {
                Console.Write("  [!] Lựa chọn không hợp lệ, vui lòng nhập lại (1 hoặc 2): ");
            }

            Console.Write("  - Nhập số lượng hóa đơn muốn thêm: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("  [!] Số lượng phải là số nguyên dương (> 0), nhập lại: ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("--- Nhập thông tin hóa đơn thứ {0}/{1} ({2}) ---", 
                    i + 1, n, loai == 1 ? "Khách hàng Việt Nam" : "Khách hàng Nước ngoài"));

                KhachHang kh;
                if (loai == 1)
                {
                    kh = new KhachHangVietNam();
                }
                else
                {
                    kh = new KhachHangNuocNgoai();
                }

                kh.Nhap();
                dsKhachHang.Add(kh);
                Console.WriteLine("  => Thêm hóa đơn thành công!");
            }
        }

        // ================= b) XUẤT DANH SÁCH DẠNG BẢNG =================
        static void XuatDanhSach(List<KhachHang> danhSach, string tieuDe)
        {
            Console.WriteLine("===============================================================================================================================");
            // Căn giữa tiêu đề bảng
            int padding = Math.Max(0, (127 - tieuDe.Length) / 2);
            Console.WriteLine(new string(' ', padding) + tieuDe);
            Console.WriteLine("===============================================================================================================================");

            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("                                          [ Danh sách hiện tại đang trống! ]");
                Console.WriteLine("===============================================================================================================================");
                return;
            }

            Console.WriteLine("+------+-----------+------------------------+------------+----------------------+------------+------------+------------+-----------------+");
            Console.WriteLine("| STT  | Mã KH     | Họ và Tên              | Ngày HĐ    | Loại KH / Quốc tịch  | Số KW      | Đơn giá    | Định mức   | Thành tiền(VNĐ) |");
            Console.WriteLine("+------+-----------+------------------------+------------+----------------------+------------+------------+------------+-----------------+");

            double tongKW = 0;
            double tongTien = 0;

            for (int i = 0; i < danhSach.Count; i++)
            {
                danhSach[i].XuatDong(i + 1);
                tongKW += danhSach[i].SoLuong;
                tongTien += danhSach[i].ThanhTien;
            }

            Console.WriteLine("+------+-----------+------------------------+------------+----------------------+------------+------------+------------+-----------------+");
            Console.WriteLine(string.Format("| TỔNG CỘNG: {0,-4} hóa đơn                              | Tổng điện tiêu thụ: {1,10:N1} KW | Tổng tiền: {2,20:N0} VNĐ |", 
                danhSach.Count, tongKW, tongTien));
            Console.WriteLine("+----------------------------------------------------+-----------------------------------+-------------------------------+");
        }

        // ================= XUẤT DANH SÁCH PHÂN LOẠI =================
        static void XuatDanhSachTheoLoai()
        {
            if (KiemTraDanhSachRong()) return;

            List<KhachHang> dsVN = new List<KhachHang>();
            List<KhachHang> dsNN = new List<KhachHang>();

            for (int i = 0; i < dsKhachHang.Count; i++)
            {
                if (dsKhachHang[i] is KhachHangVietNam)
                {
                    dsVN.Add(dsKhachHang[i]);
                }
                else if (dsKhachHang[i] is KhachHangNuocNgoai)
                {
                    dsNN.Add(dsKhachHang[i]);
                }
            }

            XuatDanhSach(dsVN, "DANH SÁCH HÓA ĐƠN KHÁCH HÀNG VIỆT NAM");
            Console.WriteLine();
            XuatDanhSach(dsNN, "DANH SÁCH HÓA ĐƠN KHÁCH HÀNG NƯỚC NGOÀI");
        }

        // ================= c) TÍNH TỔNG SỐ LƯỢNG ĐIỆN TIÊU THỤ CHO TỪNG LOẠI =================
        static void TinhTongSoLuongDienTungLoai()
        {
            Console.WriteLine("============== c) TÍNH TỔNG SỐ LƯỢNG ĐIỆN TIÊU THỤ CHO TỪNG LOẠI KHÁCH HÀNG ==============");
            if (KiemTraDanhSachRong()) return;

            double tongKWDienVN = 0;
            double tongKWDienNN = 0;
            int soLuongHoaDonVN = 0;
            int soLuongHoaDonNN = 0;

            for (int i = 0; i < dsKhachHang.Count; i++)
            {
                if (dsKhachHang[i] is KhachHangVietNam)
                {
                    tongKWDienVN += dsKhachHang[i].SoLuong;
                    soLuongHoaDonVN++;
                }
                else if (dsKhachHang[i] is KhachHangNuocNgoai)
                {
                    tongKWDienNN += dsKhachHang[i].SoLuong;
                    soLuongHoaDonNN++;
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("  1. Khách hàng Việt Nam : {0,3} hóa đơn  -->  Tổng điện tiêu thụ: {1,12:N1} KW", 
                soLuongHoaDonVN, tongKWDienVN));
            Console.WriteLine(string.Format("  2. Khách hàng Nước ngoài: {0,2} hóa đơn  -->  Tổng điện tiêu thụ: {1,12:N1} KW", 
                soLuongHoaDonNN, tongKWDienNN));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("  => TỔNG CỘNG TOÀN BỘ   : {0,3} hóa đơn  -->  Tổng điện tiêu thụ: {1,12:N1} KW", 
                dsKhachHang.Count, tongKWDienVN + tongKWDienNN));
        }

        // ================= d) TÍNH TRUNG BÌNH THÀNH TIỀN CỦA KHÁCH HÀNG NƯỚC NGOÀI =================
        static void TinhTrungBinhThanhTienKhachNuocNgoai()
        {
            Console.WriteLine("=========== d) TÍNH TRUNG BÌNH THÀNH TIỀN CỦA KHÁCH HÀNG NGƯỜI NƯỚC NGOÀI ===========");
            if (KiemTraDanhSachRong()) return;

            double tongTienNN = 0;
            int soHoaDonNN = 0;

            for (int i = 0; i < dsKhachHang.Count; i++)
            {
                if (dsKhachHang[i] is KhachHangNuocNgoai)
                {
                    tongTienNN += dsKhachHang[i].ThanhTien;
                    soHoaDonNN++;
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            if (soHoaDonNN == 0)
            {
                Console.WriteLine("  [!] Không có hóa đơn nào của khách hàng người nước ngoài trong danh sách.");
            }
            else
            {
                double trungBinh = tongTienNN / soHoaDonNN;
                Console.WriteLine(string.Format("  + Số lượng hóa đơn khách hàng nước ngoài : {0}", soHoaDonNN));
                Console.WriteLine(string.Format("  + Tổng thành tiền khách hàng nước ngoài   : {0:N0} VNĐ", tongTienNN));
                Console.WriteLine(string.Format("  => TRUNG BÌNH THÀNH TIỀN / 1 HÓA ĐƠN KHNN : {0:N2} VNĐ", trungBinh));
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        // ================= e) XUẤT CÁC HÓA ĐƠN TRONG THÁNG 09 NĂM 2020 =================
        static void XuatHoaDonThang9Nam2020()
        {
            Console.WriteLine("============== e) XUẤT CÁC HÓA ĐƠN TRONG THÁNG 09 NĂM 2020 (CẢ 2 LOẠI KH) ==============");
            if (KiemTraDanhSachRong()) return;

            List<KhachHang> dsThang9Nam2020 = new List<KhachHang>();

            for (int i = 0; i < dsKhachHang.Count; i++)
            {
                if (dsKhachHang[i].NgayHoaDon.Month == 9 && dsKhachHang[i].NgayHoaDon.Year == 2020)
                {
                    dsThang9Nam2020.Add(dsKhachHang[i]);
                }
            }

            if (dsThang9Nam2020.Count > 0)
            {
                XuatDanhSach(dsThang9Nam2020, string.Format("KẾT QUẢ: TÌM THẤY {0} HÓA ĐƠN TRONG THÁNG 09/2020", dsThang9Nam2020.Count));
            }
            else
            {
                Console.WriteLine("  => Không có hóa đơn nào được lập trong tháng 09 năm 2020.");
            }
        }

        // ================= NẠP DỮ LIỆU MẪU (MOCK DATA) =================
        static void NapDuLieuMau()
        {
            Console.WriteLine("====================== NẠP DỮ LIỆU MẪU ĐỂ KIỂM THỬ NHANH ======================");
            
            // Xóa dữ liệu cũ nếu có
            dsKhachHang.Clear();

            // Khách hàng Việt Nam:
            // 1. Nguyễn Văn An - Tháng 09/2020, Số lượng 80 KW <= Định mức 100 KW (Không vượt)
            dsKhachHang.Add(new KhachHangVietNam("KHVN001", "Nguyễn Văn An", new DateTime(2020, 9, 5), 80, 2500, "Sinh hoạt", 100));

            // 2. Trần Thị Bích - Tháng 09/2020, Số lượng 160 KW > Định mức 100 KW (Vượt định mức 60 KW)
            dsKhachHang.Add(new KhachHangVietNam("KHVN002", "Trần Thị Bích", new DateTime(2020, 9, 18), 160, 2500, "Kinh doanh", 100));

            // 3. Lê Hoàng Nam - Tháng 10/2020 (Tháng khác để test lọc tháng 9)
            dsKhachHang.Add(new KhachHangVietNam("KHVN003", "Lê Hoàng Nam", new DateTime(2020, 10, 12), 220, 3000, "Sản xuất", 150));

            // Khách hàng Nước ngoài:
            // 4. John Smith - Mỹ - Tháng 09/2020
            dsKhachHang.Add(new KhachHangNuocNgoai("KHNN001", "John Smith", new DateTime(2020, 9, 10), 120, 3500, "Mỹ"));

            // 5. Tanaka Hiroshi - Nhật Bản - Tháng 09/2020
            dsKhachHang.Add(new KhachHangNuocNgoai("KHNN002", "Tanaka Hiroshi", new DateTime(2020, 9, 25), 180, 3500, "Nhật Bản"));

            // 6. David Miller - Anh - Tháng 08/2020 (Tháng khác)
            dsKhachHang.Add(new KhachHangNuocNgoai("KHNN003", "David Miller", new DateTime(2020, 8, 15), 90, 3500, "Anh"));

            Console.WriteLine(string.Format("  => Đã nạp thành công {0} hóa đơn mẫu (3 KH Việt Nam + 3 KH Nước ngoài)!", dsKhachHang.Count));
            Console.WriteLine("     - Trong đó có 4 hóa đơn tháng 09/2020 (2 KH Việt Nam + 2 KH Nước ngoài).");
            Console.WriteLine("     - Có trường hợp KH Việt Nam tiêu thụ trong định mức và vượt định mức.");
            Console.WriteLine("     - Bạn có thể chọn ngay chức năng [2], [4], [5], [6] để xem kết quả tính toán.");
        }

        // Phương thức kiểm tra danh sách rỗng
        static bool KiemTraDanhSachRong()
        {
            if (dsKhachHang.Count == 0)
            {
                Console.WriteLine("  [!] Danh sách hóa đơn hiện đang trống!");
                Console.WriteLine("  [*] Gợi ý: Hãy chọn [1] để nhập hóa đơn hoặc chọn [7] để nạp dữ liệu mẫu nhanh.");
                return true;
            }
            return false;
        }
    }
}
