using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    class Program
    {
        // Chuỗi kết nối mặc định đến SQL Server (dùng Windows Authentication)
        // Bạn có thể sửa tên server nếu máy bạn dùng .\SQLEXPRESS hoặc tên khác
        private static string serverName = ".";
        private static string dbName = "QL_KhachSan";

        private static string MasterConnectionString
        {
            get { return string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;", serverName); }
        }

        private static string AppConnectionString
        {
            get { return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", serverName, dbName); }
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Nếu truyền tham số /console thì chạy menu console (Công việc 1)
            if (args != null && args.Length > 0 && args[0].ToLower() == "/console")
            {
                ChayGiaoDienConsole();
                return;
            }

            if (args != null && args.Length > 0 && args[0].ToLower() == "/phong")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormPhong());
                return;
            }

            // Mặc định khởi chạy giao diện Windows Forms Form QL Khách Thuê Phòng (Công việc 3)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormKhachThue());
        }

        static void ChayGiaoDienConsole()
        {
            // Thiết lập hiển thị tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int luaChon = -1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===============================================================================");
                Console.WriteLine("        BÀI TẬP THỰC HÀNH .NET - LAB 9 - BÀI 1: CSDL QUẢN LÝ KHÁCH SẠN         ");
                Console.WriteLine("===============================================================================");
                Console.ResetColor();
                Console.WriteLine("  Server hiện tại: " + serverName + " | Database: " + dbName);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("  [1] TỰ ĐỘNG THỰC HIỆN CÔNG VIỆC 1 (Tạo CSDL, 3 Bảng, Khóa, Dữ liệu mẫu)");
                Console.WriteLine("  [2] Xem danh sách bảng PHÒNG (Phong)");
                Console.WriteLine("  [3] Xem danh sách KHÁCH HÀNG (KH)");
                Console.WriteLine("  [4] Xem danh sách THUÊ PHÒNG (ThueP)");
                Console.WriteLine("  [5] Báo cáo chi tiết thuê phòng & Tổng tiền thanh toán (JOIN 3 bảng)");
                Console.WriteLine("  [6] Thêm một phòng mới vào CSDL");
                Console.WriteLine("  [7] Thêm một khách hàng mới vào CSDL");
                Console.WriteLine("  [8] Đăng ký thuê phòng mới");
                Console.WriteLine("  [9] Cấu hình lại Tên SQL Server (hiện tại: " + serverName + ")");
                Console.WriteLine("  [0] Thoát chương trình");
                Console.WriteLine("===============================================================================");
                Console.Write("  Vui lòng nhập lựa chọn của bạn [0-9]: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out luaChon))
                {
                    luaChon = -1;
                }

                Console.WriteLine();
                switch (luaChon)
                {
                    case 1:
                        ThucHienCongViec1();
                        break;
                    case 2:
                        HienThiDanhSachPhong();
                        break;
                    case 3:
                        HienThiDanhSachKH();
                        break;
                    case 4:
                        HienThiDanhSachThueP();
                        break;
                    case 5:
                        HienThiBaoCaoChiTiet();
                        break;
                    case 6:
                        ThemPhongMoi();
                        break;
                    case 7:
                        ThemKhachHangMoi();
                        break;
                    case 8:
                        DangKyThuePhong();
                        break;
                    case 9:
                        DoiServerName();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình! Tạm biệt.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 0 đến 9.");
                        Console.ResetColor();
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                }

            } while (luaChon != 0);
        }

        #region 1. CÔNG VIỆC 1: TẠO CSDL, BẢNG, KHÓA CHÍNH, KHÓA NGOẠI VÀ CHÈN DỮ LIỆU
        /// <summary>
        /// Tự động thực hiện toàn bộ Công việc 1 theo đề bài:
        /// a) Tạo cấu trúc các bảng và chỉ ra khóa chính
        /// b) Nhập vào mỗi bảng ít nhất 3 bản ghi phù hợp thực tế
        /// c) Tạo mối quan hệ (khóa ngoại) giữa các bảng dữ liệu
        /// </summary>
        static void ThucHienCongViec1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>> ĐANG TIẾN HÀNH THỰC HIỆN CÔNG VIỆC 1 TRÊN SQL SERVER...");
            Console.ResetColor();

            try
            {
                // Bước 1: Kết nối master để tạo Database QL_KhachSan nếu chưa có
                using (SqlConnection masterConn = new SqlConnection(MasterConnectionString))
                {
                    masterConn.Open();
                    Console.WriteLine("[+] Kết nối đến SQL Server thành công!");

                    string sqlCreateDb = @"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_KhachSan')
                        BEGIN
                            CREATE DATABASE QL_KhachSan;
                        END";
                    using (SqlCommand cmd = new SqlCommand(sqlCreateDb, masterConn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("[+] Kiểm tra & Khởi tạo CSDL 'QL_KhachSan' thành công!");
                    }
                }

                // Bước 2: Kết nối vào CSDL QL_KhachSan để tạo bảng & dữ liệu
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    // a & c) Tạo cấu trúc các bảng và mối quan hệ
                    string sqlDropAndCreateTables = @"
                        -- Xóa bảng cũ nếu đã tồn tại theo thứ tự quan hệ
                        IF OBJECT_ID(N'dbo.ThueP', N'U') IS NOT NULL DROP TABLE dbo.ThueP;
                        IF OBJECT_ID(N'dbo.KH', N'U') IS NOT NULL DROP TABLE dbo.KH;
                        IF OBJECT_ID(N'dbo.Phong', N'U') IS NOT NULL DROP TABLE dbo.Phong;

                        -- 1. Bảng Phong (Khóa chính: MaPH)
                        CREATE TABLE Phong (
                            MaPH VARCHAR(10) NOT NULL,
                            LoaiP NVARCHAR(50) NOT NULL,
                            HangP NVARCHAR(50) NOT NULL,
                            DonGia DECIMAL(18, 0) NOT NULL,
                            TinhTrang NVARCHAR(20) NOT NULL,
                            CONSTRAINT PK_Phong PRIMARY KEY (MaPH),
                            CONSTRAINT CHK_Phong_LoaiP CHECK (LoaiP IN (N'Phòng đơn', N'Phòng đôi', N'Phòng ba')),
                            CONSTRAINT CHK_Phong_HangP CHECK (HangP IN (N'Thường', N'VIP', N'Sang')),
                            CONSTRAINT CHK_Phong_TinhTrang CHECK (TinhTrang IN (N'Có', N'Không')),
                            CONSTRAINT CHK_Phong_DonGia CHECK (DonGia >= 0)
                        );

                        -- 2. Bảng KH (Khóa chính: SoCMT)
                        CREATE TABLE KH (
                            SoCMT VARCHAR(20) NOT NULL,
                            Hoten NVARCHAR(100) NOT NULL,
                            Gioitinh NVARCHAR(10) NOT NULL,
                            CONSTRAINT PK_KH PRIMARY KEY (SoCMT),
                            CONSTRAINT CHK_KH_Gioitinh CHECK (Gioitinh IN (N'Nam', N'Nữ'))
                        );

                        -- 3. Bảng ThueP (Khóa chính: SoCMT, MaPH, NgayDen; Khóa ngoại tham chiếu KH và Phong)
                        CREATE TABLE ThueP (
                            SoCMT VARCHAR(20) NOT NULL,
                            MaPH VARCHAR(10) NOT NULL,
                            NgayDen DATETIME NOT NULL,
                            NgayDi DATETIME NULL,
                            TienSDDV DECIMAL(18, 0) DEFAULT 0,
                            CONSTRAINT PK_ThueP PRIMARY KEY (SoCMT, MaPH, NgayDen),
                            CONSTRAINT FK_ThueP_KH FOREIGN KEY (SoCMT) REFERENCES KH(SoCMT)
                                ON UPDATE CASCADE ON DELETE CASCADE,
                            CONSTRAINT FK_ThueP_Phong FOREIGN KEY (MaPH) REFERENCES Phong(MaPH)
                                ON UPDATE CASCADE ON DELETE CASCADE,
                            CONSTRAINT CHK_ThueP_NgayDi CHECK (NgayDi IS NULL OR NgayDi >= NgayDen),
                            CONSTRAINT CHK_ThueP_TienSDDV CHECK (TienSDDV >= 0)
                        );
                    ";

                    using (SqlCommand cmd = new SqlCommand(sqlDropAndCreateTables, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("[+] Câu a & c: Tạo cấu trúc 3 bảng (Phong, KH, ThueP), Khóa chính và Khóa ngoại thành công!");
                    }

                    // b) Nhập vào mỗi bảng ít nhất 3 bản ghi mẫu phù hợp thực tế
                    string sqlInsertSampleData = @"
                        -- Thêm dữ liệu bảng Phong (4 phòng)
                        INSERT INTO Phong (MaPH, LoaiP, HangP, DonGia, TinhTrang) VALUES
                        ('P101', N'Phòng đơn', N'Thường', 350000, N'Có'),
                        ('P102', N'Phòng đôi', N'VIP',    600000, N'Có'),
                        ('P201', N'Phòng ba',  N'Sang',   1200000, N'Không'),
                        ('P202', N'Phòng đơn', N'Thường', 350000, N'Không');

                        -- Thêm dữ liệu bảng KH (4 khách hàng)
                        INSERT INTO KH (SoCMT, Hoten, Gioitinh) VALUES
                        ('001201003456', N'Nguyễn Văn An', N'Nam'),
                        ('038202007891', N'Trần Thị Bích', N'Nữ'),
                        ('024200001234', N'Lê Hoàng Long', N'Nam'),
                        ('079203009876', N'Phạm Thu Hà',   N'Nữ');

                        -- Thêm dữ liệu bảng ThueP (4 giao dịch thuê phòng)
                        INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV) VALUES
                        ('001201003456', 'P101', '2026-09-20 14:00:00', '2026-09-23 12:00:00', 150000),
                        ('038202007891', 'P102', '2026-09-22 09:30:00', '2026-09-25 11:00:00', 300000),
                        ('024200001234', 'P201', '2026-09-18 15:00:00', '2026-09-21 10:00:00', 500000),
                        ('079203009876', 'P101', '2026-09-24 13:00:00', NULL,                  0);
                    ";

                    using (SqlCommand cmd = new SqlCommand(sqlInsertSampleData, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("[+] Câu b: Nhập thành công 4 bản ghi mẫu phù hợp thực tế vào mỗi bảng!");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n===> HOÀN THÀNH TOÀN BỘ CÔNG VIỆC 1 THÀNH CÔNG RỰC RỠ! <===");
                Console.ResetColor();
            }
            catch (SqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[LỖI SQL]: " + ex.Message);
                Console.WriteLine("Gợi ý khắc phục: Kiểm tra SQL Server đã bật chưa hoặc chọn mục [9] để đổi Tên Server (ví dụ: .\\SQLEXPRESS hoặc localhost).");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[LỖI]: " + ex.Message);
                Console.ResetColor();
            }
        }
        #endregion

        #region 2. HIỂN THỊ DANH SÁCH CÁC BẢNG
        static void HienThiDanhSachPhong()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== DANH SÁCH CÁC PHÒNG (BẢNG Phong) ====================");
            Console.ResetColor();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string query = "SELECT MaPH, LoaiP, HangP, DonGia, TinhTrang FROM Phong ORDER BY MaPH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-10} | {1,-14} | {2,-10} | {3,15} | {4,-12}", 
                            "Mã Phòng", "Loại Phòng", "Hạng Phòng", "Đơn Giá (VNĐ)", "Tình Trạng");
                        Console.WriteLine(new string('-', 72));

                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            string maPH = reader["MaPH"].ToString();
                            string loaiP = reader["LoaiP"].ToString();
                            string hangP = reader["HangP"].ToString();
                            decimal donGia = Convert.ToDecimal(reader["DonGia"]);
                            string tinhTrang = reader["TinhTrang"].ToString();

                            Console.WriteLine("{0,-10} | {1,-14} | {2,-10} | {3,15:N0} | {4,-12}",
                                maPH, loaiP, hangP, donGia, tinhTrang);
                        }

                        Console.WriteLine(new string('-', 72));
                        Console.WriteLine("Tổng số phòng: {0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        static void HienThiDanhSachKH()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== DANH SÁCH KHÁCH HÀNG (BẢNG KH) ====================");
            Console.ResetColor();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string query = "SELECT SoCMT, Hoten, Gioitinh FROM KH ORDER BY SoCMT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-16} | {1,-25} | {2,-10}", "Số CMT/CCCD", "Họ Và Tên", "Giới Tính");
                        Console.WriteLine(new string('-', 58));

                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            string soCMT = reader["SoCMT"].ToString();
                            string hoten = reader["Hoten"].ToString();
                            string gioitinh = reader["Gioitinh"].ToString();

                            Console.WriteLine("{0,-16} | {1,-25} | {2,-10}", soCMT, hoten, gioitinh);
                        }

                        Console.WriteLine(new string('-', 58));
                        Console.WriteLine("Tổng số khách hàng: {0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        static void HienThiDanhSachThueP()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== DANH SÁCH THUÊ PHÒNG (BẢNG ThueP) ====================");
            Console.ResetColor();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string query = "SELECT SoCMT, MaPH, NgayDen, NgayDi, TienSDDV FROM ThueP ORDER BY NgayDen DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-15} | {1,-8} | {2,-18} | {3,-18} | {4,14}", 
                            "Số CMT", "Mã PH", "Ngày Đến", "Ngày Đi", "Tiền SDDV (VNĐ)");
                        Console.WriteLine(new string('-', 83));

                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            string soCMT = reader["SoCMT"].ToString();
                            string maPH = reader["MaPH"].ToString();
                            DateTime ngayDen = Convert.ToDateTime(reader["NgayDen"]);
                            string ngayDiStr = reader["NgayDi"] == DBNull.Value ? "Chưa trả phòng" : Convert.ToDateTime(reader["NgayDi"]).ToString("dd/MM/yyyy HH:mm");
                            decimal tienSDDV = Convert.ToDecimal(reader["TienSDDV"]);

                            Console.WriteLine("{0,-15} | {1,-8} | {2,-18} | {3,-18} | {4,14:N0}",
                                soCMT, maPH, ngayDen.ToString("dd/MM/yyyy HH:mm"), ngayDiStr, tienSDDV);
                        }

                        Console.WriteLine(new string('-', 83));
                        Console.WriteLine("Tổng số lượt thuê phòng: {0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        static void HienThiBaoCaoChiTiet()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== BÁO CÁO CHI TIẾT THUÊ PHÒNG & TỔNG TIỀN ====================");
            Console.ResetColor();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            t.SoCMT,
                            k.Hoten,
                            k.Gioitinh,
                            p.MaPH,
                            p.LoaiP,
                            p.HangP,
                            p.DonGia,
                            t.NgayDen,
                            t.NgayDi,
                            CASE 
                                WHEN DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())) <= 0 THEN 1 
                                ELSE DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())) 
                            END AS SoNgayO,
                            t.TienSDDV,
                            (
                                CASE 
                                    WHEN DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())) <= 0 THEN 1 
                                    ELSE DATEDIFF(DAY, t.NgayDen, ISNULL(t.NgayDi, GETDATE())) 
                                END * p.DonGia + t.TienSDDV
                            ) AS TongTien
                        FROM ThueP t
                        JOIN KH k ON t.SoCMT = k.SoCMT
                        JOIN Phong p ON t.MaPH = p.MaPH
                        ORDER BY t.NgayDen DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-14} | {1,-20} | {2,-6} | {3,-11} | {4,-6} | {5,7} | {6,12} | {7,14}",
                            "Số CMT", "Họ Tên Khách", "Phòng", "Loại", "Hạng", "Số Ngày", "Tiền SDDV", "TỔNG TIỀN");
                        Console.WriteLine(new string('-', 106));

                        decimal tongDoanhThu = 0;
                        while (reader.Read())
                        {
                            string soCMT = reader["SoCMT"].ToString();
                            string hoten = reader["Hoten"].ToString();
                            string maPH = reader["MaPH"].ToString();
                            string loaiP = reader["LoaiP"].ToString();
                            string hangP = reader["HangP"].ToString();
                            int soNgayO = Convert.ToInt32(reader["SoNgayO"]);
                            decimal tienSDDV = Convert.ToDecimal(reader["TienSDDV"]);
                            decimal tongTien = Convert.ToDecimal(reader["TongTien"]);
                            tongDoanhThu += tongTien;

                            Console.WriteLine("{0,-14} | {1,-20} | {2,-6} | {3,-11} | {4,-6} | {5,7} | {6,12:N0} | {7,14:N0}",
                                soCMT, hoten, maPH, loaiP, hangP, soNgayO, tienSDDV, tongTien);
                        }

                        Console.WriteLine(new string('-', 106));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("===> TỔNG DOANH THU KHÁCH SẠN: {0:N0} VNĐ", tongDoanhThu);
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }
        #endregion

        #region 3. CÁC THAO TÁC THÊM MỚI DỮ LIỆU
        static void ThemPhongMoi()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== THÊM PHÒNG MỚI ====================");
            Console.ResetColor();

            try
            {
                Console.Write("Nhập mã phòng (ví dụ P301): ");
                string maPH = Console.ReadLine().Trim();

                Console.WriteLine("Chọn loại phòng: 1. Phòng đơn | 2. Phòng đôi | 3. Phòng ba");
                Console.Write("Lựa chọn (1/2/3): ");
                string loaiOpt = Console.ReadLine().Trim();
                string loaiP = loaiOpt == "2" ? "Phòng đôi" : (loaiOpt == "3" ? "Phòng ba" : "Phòng đơn");

                Console.WriteLine("Chọn hạng phòng: 1. Thường | 2. VIP | 3. Sang");
                Console.Write("Lựa chọn (1/2/3): ");
                string hangOpt = Console.ReadLine().Trim();
                string hangP = hangOpt == "2" ? "VIP" : (hangOpt == "3" ? "Sang" : "Thường");

                Console.Write("Nhập đơn giá (VNĐ): ");
                decimal donGia = decimal.Parse(Console.ReadLine().Trim());

                Console.Write("Tình trạng phòng (Có/Không, mặc định Không): ");
                string tinhTrang = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(tinhTrang)) tinhTrang = "Không";

                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string insertSql = "INSERT INTO Phong (MaPH, LoaiP, HangP, DonGia, TinhTrang) VALUES (@ma, @loai, @hang, @gia, @tt)";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maPH);
                        cmd.Parameters.AddWithValue("@loai", loaiP);
                        cmd.Parameters.AddWithValue("@hang", hangP);
                        cmd.Parameters.AddWithValue("@gia", donGia);
                        cmd.Parameters.AddWithValue("@tt", tinhTrang);

                        cmd.ExecuteNonQuery();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thêm phòng " + maPH + " thành công!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        static void ThemKhachHangMoi()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== THÊM KHÁCH HÀNG MỚI ====================");
            Console.ResetColor();

            try
            {
                Console.Write("Nhập số CMT/CCCD: ");
                string soCMT = Console.ReadLine().Trim();

                Console.Write("Nhập họ và tên: ");
                string hoTen = Console.ReadLine().Trim();

                Console.Write("Nhập giới tính (Nam/Nữ): ");
                string gioiTinh = Console.ReadLine().Trim();
                if (gioiTinh != "Nam" && gioiTinh != "Nữ") gioiTinh = "Nam";

                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string insertSql = "INSERT INTO KH (SoCMT, Hoten, Gioitinh) VALUES (@cmt, @ten, @gt)";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cmt", soCMT);
                        cmd.Parameters.AddWithValue("@ten", hoTen);
                        cmd.Parameters.AddWithValue("@gt", gioiTinh);

                        cmd.ExecuteNonQuery();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thêm khách hàng '" + hoTen + "' thành công!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }

        static void DangKyThuePhong()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== ĐĂNG KÝ THUÊ PHÒNG ====================");
            Console.ResetColor();

            try
            {
                Console.Write("Nhập số CMT/CCCD của khách đã có trong hệ thống: ");
                string soCMT = Console.ReadLine().Trim();

                Console.Write("Nhập mã phòng muốn thuê: ");
                string maPH = Console.ReadLine().Trim();

                DateTime ngayDen = DateTime.Now;
                Console.WriteLine("Thời gian đến: " + ngayDen.ToString("dd/MM/yyyy HH:mm:ss"));

                Console.Write("Nhập tiền sử dụng dịch vụ ban đầu (VNĐ, mặc định 0): ");
                string tienStr = Console.ReadLine().Trim();
                decimal tienSDDV = 0;
                if (!string.IsNullOrEmpty(tienStr)) decimal.TryParse(tienStr, out tienSDDV);

                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string insertSql = @"
                        INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV) 
                        VALUES (@cmt, @maph, @ngayden, NULL, @tiendv);
                        UPDATE Phong SET TinhTrang = N'Có' WHERE MaPH = @maph;";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cmt", soCMT);
                        cmd.Parameters.AddWithValue("@maph", maPH);
                        cmd.Parameters.AddWithValue("@ngayden", ngayDen);
                        cmd.Parameters.AddWithValue("@tiendv", tienSDDV);

                        cmd.ExecuteNonQuery();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Đăng ký thuê phòng " + maPH + " cho khách " + soCMT + " thành công!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                BaoLoi(ex);
            }
        }
        #endregion

        #region 4. CẤU HÌNH & TIỆN ÍCH
        static void DoiServerName()
        {
            Console.WriteLine("Tên SQL Server hiện tại: " + serverName);
            Console.WriteLine("Gợi ý các tên server phổ biến:");
            Console.WriteLine("  - . (dấu chấm biểu thị máy local)");
            Console.WriteLine("  - .\\SQLEXPRESS (bản SQL Server Express)");
            Console.WriteLine("  - localhost");
            Console.WriteLine("  - (localdb)\\MSSQLLocalDB");
            Console.Write("Nhập tên server mới của bạn: ");
            string moi = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(moi))
            {
                serverName = moi;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Đã cập nhật Tên Server thành: " + serverName);
                Console.ResetColor();
            }
        }

        static void BaoLoi(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ĐÃ XẢY RA LỖI]: " + ex.Message);
            Console.WriteLine("Nếu là lỗi kết nối CSDL, hãy chạy lựa chọn [1] để khởi tạo CSDL hoặc kiểm tra SQL Server Service.");
            Console.ResetColor();
        }
        #endregion
    }
}
