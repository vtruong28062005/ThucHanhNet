using System;

namespace Bai4
{
    // ==========================================
    // 1. XÂY DỰNG LỚP VÉ MÁY BAY (Vemaybay)
    // ==========================================
    public class Vemaybay
    {
        // Thuộc tính theo đề bài
        private string tenchuyen; // Tên chuyến bay
        private string ngaybay;   // Ngày bay
        private double giave;     // Giá vé

        // Đóng gói thuộc tính (Properties)
        public string TenChuyen
        {
            get { return tenchuyen; }
            set { tenchuyen = value; }
        }

        public string NgayBay
        {
            get { return ngaybay; }
            set { ngaybay = value; }
        }

        public double GiaVe
        {
            get { return giave; }
            set { giave = value; }
        }

        // --- HÀM TẠO (Constructor) KHÔNG THAM SỐ ---
        public Vemaybay()
        {
            tenchuyen = "";
            ngaybay = "";
            giave = 0.0;
        }

        // --- HÀM TẠO (Constructor) ĐẦY ĐỦ THAM SỐ ---
        public Vemaybay(string tenchuyen, string ngaybay, double giave)
        {
            this.tenchuyen = tenchuyen;
            this.ngaybay = ngaybay;
            this.giave = giave;
        }

        // --- HỦY (Destructor) ---
        ~Vemaybay()
        {
            // Trong C#, bộ dọn rác GC tự động giải phóng bộ nhớ
        }

        // --- PHƯƠNG THỨC NHẬP ---
        public void Nhap()
        {
            Console.Write("       + Nhập tên chuyến bay: ");
            tenchuyen = Console.ReadLine();

            Console.Write("       + Nhập ngày bay (vd: 25/12/2026): ");
            ngaybay = Console.ReadLine();

            while (true)
            {
                Console.Write("       + Nhập giá vé (VNĐ): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out giave) && giave >= 0)
                {
                    break;
                }
                Console.WriteLine("       [!] Giá vé không hợp lệ, vui lòng nhập số thực >= 0!");
            }
        }

        // --- PHƯƠNG THỨC XUẤT ---
        public void Xuat()
        {
            Console.WriteLine("       - Chuyến bay: {0,-15} | Ngày bay: {1,-12} | Giá vé: {2,12:N0} VNĐ", 
                tenchuyen, ngaybay, giave);
        }

        // --- HÀM TRẢ VỀ GIÁ VÉ ---
        public double getgiave()
        {
            return giave;
        }
    }
}
