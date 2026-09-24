using System;

namespace BaiTapPhanSo
{
    public class Phanso
    {
        // 1. Thuộc tính
        private int tuso;
        private int mauso;

        // Getter & Setter
        public int TuSo
        {
            get { return tuso; }
            set { tuso = value; }
        }

        public int MauSo
        {
            get { return mauso; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mẫu số phải khác 0.");
                mauso = value;
            }
        }

        // 2. Hàm khởi tạo không tham số (Default Constructor)
        public Phanso()
        {
            tuso = 0;
            mauso = 1;
        }

        // Hàm khởi tạo có tham số
        public Phanso(int tu, int mau)
        {
            tuso = tu;
            mauso = (mau == 0) ? 1 : mau;
            RutGon();
        }

        // 3. Hàm hủy (Destructor)
        ~Phanso()
        {
            // Trong C#, bộ thu gom rác tự động quản lý tài nguyên.
        }

        // 4. Phương thức Nhập
        public void Nhap()
        {
            Console.Write("  Nhập tử số: ");
            while (!int.TryParse(Console.ReadLine(), out tuso))
            {
                Console.Write("  [!] Vui lòng nhập số nguyên hợp lệ: ");
            }

            do
            {
                Console.Write("  Nhập mẫu số (khác 0): ");
                while (!int.TryParse(Console.ReadLine(), out mauso))
                {
                    Console.Write("  [!] Vui lòng nhập số nguyên hợp lệ: ");
                }

                if (mauso == 0)
                {
                    Console.WriteLine("  [!] Mẫu số không được bằng 0! Vui lòng nhập lại.");
                }
            } while (mauso == 0);

            RutGon();
        }

        // 5. Phương thức Xuất
        public void Xuat()
        {
            if (mauso == 1)
                Console.Write(tuso);
            else if (tuso == 0)
                Console.Write(0);
            else
                Console.Write(tuso + "/" + mauso);
        }

        // Tìm ước chung lớn nhất (UCLN)
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Rút gọn phân số và chuẩn hóa dấu âm về tử số
        public void RutGon()
        {
            if (mauso < 0)
            {
                tuso = -tuso;
                mauso = -mauso;
            }

            int ucln = UCLN(tuso, mauso);
            if (ucln != 0)
            {
                tuso /= ucln;
                mauso /= ucln;
            }
        }

        // 6. Các phương thức tính toán
        public Phanso Cong(Phanso ps2)
        {
            int tu = this.tuso * ps2.mauso + ps2.tuso * this.mauso;
            int mau = this.mauso * ps2.mauso;
            return new Phanso(tu, mau);
        }

        public Phanso Tru(Phanso ps2)
        {
            int tu = this.tuso * ps2.mauso - ps2.tuso * this.mauso;
            int mau = this.mauso * ps2.mauso;
            return new Phanso(tu, mau);
        }

        public Phanso Nhan(Phanso ps2)
        {
            int tu = this.tuso * ps2.tuso;
            int mau = this.mauso * ps2.mauso;
            return new Phanso(tu, mau);
        }

        public Phanso Chia(Phanso ps2)
        {
            if (ps2.tuso == 0)
            {
                Console.WriteLine("\n[Lỗi] Không thể chia vì tử số của phân số thứ hai bằng 0!");
                return null;
            }
            int tu = this.tuso * ps2.mauso;
            int mau = this.mauso * ps2.tuso;
            return new Phanso(tu, mau);
        }
    }
}
