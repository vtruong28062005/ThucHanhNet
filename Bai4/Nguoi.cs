using System;

namespace Bai4
{
    // ==========================================
    // 2. XÂY DỰNG LỚP NGƯỜI (Nguoi)
    // ==========================================
    public class Nguoi
    {
        // Thuộc tính theo đề bài
        protected string hoten;    // Họ và tên
        protected string gioitinh; // Giới tính
        protected int tuoi;        // Tuổi

        // Đóng gói thuộc tính (Properties)
        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }

        // --- HÀM TẠO KHÔNG THAM SỐ ---
        public Nguoi()
        {
            hoten = "";
            gioitinh = "";
            tuoi = 0;
        }

        // --- HÀM TẠO CÓ THAM SỐ ---
        public Nguoi(string hoten, string gioitinh, int tuoi)
        {
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.tuoi = tuoi;
        }

        // --- HỦY (Destructor) ---
        ~Nguoi()
        {
            // Tự động giải phóng
        }

        // --- PHƯƠNG THỨC NHẬP ---
        public virtual void Nhap()
        {
            Console.Write("  - Nhập họ và tên: ");
            hoten = Console.ReadLine();

            Console.Write("  - Nhập giới tính: ");
            gioitinh = Console.ReadLine();

            while (true)
            {
                Console.Write("  - Nhập tuổi: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out tuoi) && tuoi > 0)
                {
                    break;
                }
                Console.WriteLine("  [!] Tuổi phải là số nguyên dương hợp lệ!");
            }
        }

        // --- PHƯƠNG THỨC XUẤT ---
        public virtual void Xuat()
        {
            Console.WriteLine("  Họ tên: {0,-20} | Giới tính: {1,-8} | Tuổi: {2,-4}", 
                hoten, gioitinh, tuoi);
        }
    }
}
