using System;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    static class Program
    {
        /// <summary>
        /// Điểm bắt đầu chính của ứng dụng Quản lý kinh doanh (Lab 9 - Bài 3).
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null && args.Length > 0)
            {
                string arg = args[0].ToLower();
                if (arg == "/mua")
                {
                    Application.Run(new frmMuaHang());
                    return;
                }
                if (arg == "/ban")
                {
                    Application.Run(new frmBanHang());
                    return;
                }
                if (arg == "/thongkemua")
                {
                    Application.Run(new frmThongKeMua());
                    return;
                }
                if (arg == "/thongkeban")
                {
                    Application.Run(new frmThongKeBan());
                    return;
                }
                if (arg == "/timkiem")
                {
                    Application.Run(new frmTimKiemBanHang());
                    return;
                }
                if (arg == "/danhmuc")
                {
                    Application.Run(new frmDanhMuc());
                    return;
                }
            }

            // Mặc định khởi chạy giao diện chính frmMain (Công việc 4)
            Application.Run(new frmMain());
        }
    }
}
