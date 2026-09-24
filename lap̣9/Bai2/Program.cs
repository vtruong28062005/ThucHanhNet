using System;
using System.Windows.Forms;

namespace QuanLyDiem
{
    static class Program
    {
        /// <summary>
        /// Điểm bắt đầu chính của ứng dụng Quản lý điểm.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mặc định khởi chạy Form chính frmMain (Công việc 2)
            if (args != null && args.Length > 0)
            {
                if (args[0].ToLower() == "/monhoc")
                {
                    Application.Run(new frmMonHoc());
                    return;
                }
                if (args[0].ToLower() == "/diem")
                {
                    Application.Run(new frmDiem());
                    return;
                }
            }

            Application.Run(new frmMain());
        }
    }
}
