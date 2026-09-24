using System;

namespace Bai4
{
    // =========================================================
    // 3. XÂY DỰNG LỚP HÀNH KHÁCH (Hanhkhach) KẾ THỪA LỚP NGUOI
    // =========================================================
    public class Hanhkhach : Nguoi
    {
        // Thuộc tính bổ sung theo đề bài: Vemaybay *ve; int soluong;
        private Vemaybay[] ve;
        private int soluong;

        // Đóng gói thuộc tính (Properties)
        public Vemaybay[] Ve
        {
            get { return ve; }
            set { ve = value; }
        }

        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        // --- HÀM TẠO KHÔNG THAM SỐ ---
        public Hanhkhach() : base()
        {
            soluong = 0;
            ve = null;
        }

        // --- HÀM TẠO CÓ THAM SỐ ---
        public Hanhkhach(string hoten, string gioitinh, int tuoi, int soluong, Vemaybay[] ve)
            : base(hoten, gioitinh, tuoi)
        {
            this.soluong = soluong;
            this.ve = ve;
        }

        // --- HỦY (Destructor) ---
        ~Hanhkhach()
        {
            // Tự động giải phóng
        }

        // --- PHƯƠNG THỨC TÍNH TỔNG TIỀN ---
        // tongtien(): trả về Tổng số tiền phải trả của hành khách
        public double tongtien()
        {
            double tong = 0;
            if (ve != null)
            {
                for (int i = 0; i < soluong; i++)
                {
                    if (ve[i] != null)
                    {
                        tong += ve[i].getgiave();
                    }
                }
            }
            return tong;
        }

        // --- PHƯƠNG THỨC NHẬP ---
        public override void Nhap()
        {
            // Gọi phương thức Nhap() của lớp cha Nguoi
            base.Nhap();

            // Nhập số lượng vé đã mua
            while (true)
            {
                Console.Write("  - Nhập số lượng vé muốn mua: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out soluong) && soluong >= 0)
                {
                    break;
                }
                Console.WriteLine("  [!] Số lượng vé phải là số nguyên >= 0!");
            }

            // Cấp phát mảng vé theo số lượng (tương đương cấp phát động trong C++)
            ve = new Vemaybay[soluong];
            for (int i = 0; i < soluong; i++)
            {
                Console.WriteLine("    * [Vé thứ {0}]:", i + 1);
                ve[i] = new Vemaybay();
                ve[i].Nhap();
            }
        }

        // --- PHƯƠNG THỨC XUẤT ---
        public override void Xuat()
        {
            // Xuất thông tin người từ lớp cha
            base.Xuat();

            Console.WriteLine("  Số lượng vé đã mua: {0}", soluong);
            if (soluong > 0 && ve != null)
            {
                Console.WriteLine("  Danh sách vé đã mua:");
                for (int i = 0; i < soluong; i++)
                {
                    Console.Write("    Vé {0}: ", i + 1);
                    ve[i].Xuat();
                }
            }
            else
            {
                Console.WriteLine("  (Chưa mua vé nào)");
            }
            Console.WriteLine("  => TỔNG TIỀN PHẢI TRẢ: {0:N0} VNĐ", tongtien());
        }
    }
}
