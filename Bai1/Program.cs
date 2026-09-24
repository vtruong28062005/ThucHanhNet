using System;
using System.Text;

namespace BaiTapPhanSo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font hiển thị tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("       CHƯƠNG TRÌNH XỬ LÝ PHÂN SỐ TRONG C#        ");
            Console.WriteLine("==================================================");

            // Khởi tạo 2 phân số obj1 và obj2 bằng hàm khởi tạo không tham số
            Phanso obj1 = new Phanso();
            Phanso obj2 = new Phanso();

            Console.WriteLine("\n--- NHẬP PHÂN SỐ THỨ NHẤT (obj1) ---");
            obj1.Nhap();

            Console.WriteLine("\n--- NHẬP PHÂN SỐ THỨ HAI (obj2) ---");
            obj2.Nhap();

            Console.WriteLine("\n==================== KẾT QUẢ ====================");
            Console.Write("Phân số obj1: ");
            obj1.Xuat();
            Console.WriteLine();

            Console.Write("Phân số obj2: ");
            obj2.Xuat();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            // 1. Tính Tổng
            Phanso tong = obj1.Cong(obj2);
            Console.Write("Tổng  (obj1 + obj2) = ");
            tong.Xuat();
            Console.WriteLine();

            // 2. Tính Hiệu
            Phanso hieu = obj1.Tru(obj2);
            Console.Write("Hiệu  (obj1 - obj2) = ");
            hieu.Xuat();
            Console.WriteLine();

            // 3. Tính Tích
            Phanso tich = obj1.Nhan(obj2);
            Console.Write("Tích  (obj1 * obj2) = ");
            tich.Xuat();
            Console.WriteLine();

            // 4. Tính Thương
            Phanso thuong = obj1.Chia(obj2);
            if (thuong != null)
            {
                Console.Write("Thương (obj1 / obj2) = ");
                thuong.Xuat();
                Console.WriteLine();
            }

            Console.WriteLine("==================================================");
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Hoàn thành! Nhấn phím bất kỳ để thoát...");
                Console.ReadKey();
            }
        }
    }
}
