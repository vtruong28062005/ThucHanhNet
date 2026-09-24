using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public static class DatabaseHelper
    {
        private static string serverConfigFile = "server.txt";
        public static string ServerName = @".\SQLEXPRESS";
        public static string DatabaseName = "QL_Diem";

        static DatabaseHelper()
        {
            DocCauHinhServer();
        }

        public static string MasterConnectionString
        {
            get
            {
                return string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;Connect Timeout=5;", ServerName);
            }
        }

        public static string AppConnectionString
        {
            get
            {
                return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;Connect Timeout=5;", ServerName, DatabaseName);
            }
        }

        public static void DocCauHinhServer()
        {
            try
            {
                if (File.Exists(serverConfigFile))
                {
                    string content = File.ReadAllText(serverConfigFile).Trim();
                    if (!string.IsNullOrEmpty(content))
                    {
                        ServerName = content;
                    }
                }
            }
            catch { }

            // Tự động kiểm tra nếu ServerName hiện tại không kết nối được thì thử các instance phổ biến
            TuDongPhatHienServer();
        }

        private static void TuDongPhatHienServer()
        {
            string[] danhSachThu = new string[] { ServerName, @".\SQLEXPRESS", ".", @"localhost\SQLEXPRESS", "localhost", @"(localdb)\MSSQLLocalDB" };
            foreach (string sv in danhSachThu)
            {
                if (string.IsNullOrEmpty(sv)) continue;
                string testConnStr = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;Connect Timeout=2;", sv);
                try
                {
                    using (SqlConnection conn = new SqlConnection(testConnStr))
                    {
                        conn.Open();
                        ServerName = sv;
                        try { File.WriteAllText(serverConfigFile, sv); } catch { }
                        return;
                    }
                }
                catch { }
            }
        }

        public static void LuuCauHinhServer(string newServer)
        {
            try
            {
                ServerName = newServer.Trim();
                File.WriteAllText(serverConfigFile, ServerName);
            }
            catch { }
        }

        public static bool KiemTraKetNoi(out string loi)
        {
            loi = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }

        public static bool TaoCSDLVaDuLieuMau(out string thongBao)
        {
            thongBao = string.Empty;
            string sqlFile = "QuanLyDiem.sql";
            if (!File.Exists(sqlFile))
            {
                thongBao = "Không tìm thấy file QuanLyDiem.sql trong thư mục ứng dụng!";
                return false;
            }

            try
            {
                string script = File.ReadAllText(sqlFile);
                // Tách script theo lệnh GO
                string[] commands = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection masterConn = new SqlConnection(MasterConnectionString))
                {
                    masterConn.Open();
                    foreach (string cmdText in commands)
                    {
                        string trimmed = cmdText.Trim();
                        if (!string.IsNullOrEmpty(trimmed))
                        {
                            using (SqlCommand cmd = new SqlCommand(trimmed, masterConn))
                            {
                                cmd.CommandTimeout = 60;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                thongBao = "Khởi tạo CSDL 'QL_Diem' và nạp dữ liệu mẫu thành công!";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi khởi tạo CSDL: " + ex.Message;
                return false;
            }
        }

        public static DataTable ExecuteDataTable(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(AppConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(AppConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(AppConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
