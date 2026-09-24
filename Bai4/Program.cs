using System;
using System.Text;

namespace Bai4
{
    class Program
    {
        // Hàm hiển thị bảng tóm tắt danh sách hành khách
        static void HienThiBangTomTat(Hanhkhach[] ds, string tieuDe)
        {
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("        " + tieuDe.ToUpper());
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("+-----+----------------------+-----------+------+--------+--------------------+");
            Console.WriteLine("| STT | Họ và tên            | Giới tính | Tuổi | Số vé  | Tổng tiền (VNĐ)    |");
            Console.WriteLine("+-----+----------------------+-----------+------+--------+--------------------+");

            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("| {0,-3} | {1,-20} | {2,-9} | {3,-4} | {4,-6} | {5,18:N0} |",
                    i + 1,
                    ds[i].HoTen,
                    ds[i].GioiTinh,
                    ds[i].Tuoi,
                    ds[i].SoLuong,
                    ds[i].tongtien());
            }
            Console.WriteLine("+-----+----------------------+-----------+------+--------+--------------------+");
        }

        // Hàm sắp xếp danh sách hành khách giảm dần theo tổng tiền (Đổi chỗ trực tiếp)
        static void SapXepGiamDanTheoTongTien(Hanhkhach[] ds)
        {
            int n = ds.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (ds[i].tongtien() < ds[j].tongtien())
                    {
                        Hanhkhach temp = ds[i];
                        ds[i] = ds[j];
                        ds[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // Thiết lập font hiển thị tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("===============================================================================");
            Console.WriteLine("              CHƯƠNG TRÌNH QUẢN LÝ HÀNH KHÁCH VÀ VÉ MÁY BAY                    ");
            Console.WriteLine("===============================================================================\n");

            // 1. Nhập số lượng hành khách n
            int n = 0;
            while (true)
            {
                Console.Write("Nhập số lượng hành khách n: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("[!] Số lượng hành khách phải là số nguyên dương (> 0). Vui lòng nhập lại!");
            }

            // Khởi tạo danh sách n hành khách
            Hanhkhach[] dsHanhKhach = new Hanhkhach[n];

            // 2. Nhập thông tin từng hành khách
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n" + new string('-', 50));
                Console.WriteLine(">>> NHẬP THÔNG TIN HÀNH KHÁCH THỨ {0} <<<", i + 1);
                Console.WriteLine(new string('-', 50));

                dsHanhKhach[i] = new Hanhkhach();
                dsHanhKhach[i].Nhap();
            }

            // 3. Hiển thị thông tin chi tiết từng hành khách ban đầu
            Console.WriteLine("\n\n===============================================================================");
            Console.WriteLine("           DANH SÁCH CHI TIẾT HÀNH KHÁCH VÀ SỐ TIỀN PHẢI TRẢ                  ");
            Console.WriteLine("===============================================================================");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n[Hành khách {0}]:", i + 1);
                dsHanhKhach[i].Xuat();
            }

            // Hiển thị dạng bảng tóm tắt
            HienThiBangTomTat(dsHanhKhach, "Bảng danh sách hành khách ban đầu");

            // 4. Sắp xếp danh sách hành khách theo chiều giảm dần của Tổng tiền
            SapXepGiamDanTheoTongTien(dsHanhKhach);

            // 5. Hiển thị lại danh sách sau khi sắp xếp
            Console.WriteLine("\n\n===============================================================================");
            Console.WriteLine("   DANH SÁCH HÀNH KHÁCH SAU KHI SẮP XẾP GIẢM DẦN THEO TỔNG TIỀN PHẢI TRẢ       ");
            Console.WriteLine("===============================================================================");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n[Hạng {0}]:", i + 1);
                dsHanhKhach[i].Xuat();
            }

            HienThiBangTomTat(dsHanhKhach, "Bảng sau khi sắp xếp giảm dần theo tổng tiền");

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("\nHoàn thành chương trình. Nhấn phím bất kỳ để thoát...");
                Console.ReadKey();
            }
        }
    }
}
