using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public class FormKhachThue : Form
    {
        #region Khai báo điều khiển giao diện (Controls)
        // Menu Điều hướng
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuChucNang;
        private ToolStripMenuItem menuFormPhong;
        private ToolStripMenuItem menuFormKhachThue;
        private ToolStripSeparator menuSeparator1;
        private ToolStripMenuItem menuThoatItem;
        private ToolStripMenuItem menuHeThong;
        private ToolStripMenuItem menuDoiServerItem;
        private ToolStripMenuItem menuTaoCSDLItem;

        // 1. GroupBox "Xem thông tin Phòng"
        private GroupBox grbXemPhong;
        private Label lblTinhTrangPhong;
        private ComboBox cboTinhTrangPhong;
        private Button btnXemTheoTinhTrang;
        private Label lblLoaiPhong;
        private ComboBox cboLoaiPhong;
        private Button btnXemTheoLoaiPhong;

        // 2. "Chi tiết Phòng"
        private Label lblChiTietPhong;
        private DataGridView dgvPhong;

        // 3. GroupBox "Thông tin Khách thuê"
        private GroupBox grbKhachThue;
        private Label lblSoCMT;
        private TextBox txtSoCMT;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private Label lblMaPhong;
        private ComboBox cboMaPhong;

        // 4 nút chức năng (Thứ tự đúng như Hình 9.43: Nhập, Xóa, Sửa, Thoát)
        private Button btnNhap;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThoat;

        // 4. "Chi tiết Khách hàng"
        private Label lblChiTietKhachHang;
        private DataGridView dgvKhachHang;

        // Thanh trạng thái dưới đáy
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblDoiServer;
        private ToolStripStatusLabel lblTaoCSDL;
        private ToolStripStatusLabel lblMoFormPhong;
        #endregion

        #region Cấu hình Kết nối CSDL
        private static string serverConfigFile = "server.txt";
        private string serverName = ".";
        private string dbName = "QL_KhachSan";

        private string MasterConnectionString
        {
            get { return string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;", serverName); }
        }

        private string AppConnectionString
        {
            get { return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", serverName, dbName); }
        }
        #endregion

        public FormKhachThue()
        {
            DocCauHinhServer();
            InitializeComponent();
        }

        #region Khởi tạo Giao diện (Thiết kế chuẩn Hình 9.43)
        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.menuChucNang = new ToolStripMenuItem();
            this.menuFormPhong = new ToolStripMenuItem();
            this.menuFormKhachThue = new ToolStripMenuItem();
            this.menuSeparator1 = new ToolStripSeparator();
            this.menuThoatItem = new ToolStripMenuItem();
            this.menuHeThong = new ToolStripMenuItem();
            this.menuDoiServerItem = new ToolStripMenuItem();
            this.menuTaoCSDLItem = new ToolStripMenuItem();

            this.grbXemPhong = new GroupBox();
            this.lblTinhTrangPhong = new Label();
            this.cboTinhTrangPhong = new ComboBox();
            this.btnXemTheoTinhTrang = new Button();
            this.lblLoaiPhong = new Label();
            this.cboLoaiPhong = new ComboBox();
            this.btnXemTheoLoaiPhong = new Button();

            this.lblChiTietPhong = new Label();
            this.dgvPhong = new DataGridView();

            this.grbKhachThue = new GroupBox();
            this.lblSoCMT = new Label();
            this.txtSoCMT = new TextBox();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblGioiTinh = new Label();
            this.cboGioiTinh = new ComboBox();
            this.lblMaPhong = new Label();
            this.cboMaPhong = new ComboBox();

            this.btnNhap = new Button();
            this.btnXoa = new Button();
            this.btnSua = new Button();
            this.btnThoat = new Button();

            this.lblChiTietKhachHang = new Label();
            this.dgvKhachHang = new DataGridView();

            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblDoiServer = new ToolStripStatusLabel();
            this.lblTaoCSDL = new ToolStripStatusLabel();
            this.lblMoFormPhong = new ToolStripStatusLabel();

            this.menuStrip.SuspendLayout();
            this.grbXemPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.grbKhachThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // MenuStrip
            // 
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.menuChucNang, this.menuHeThong });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Size = new Size(710, 24);

            this.menuChucNang.Text = "Chức năng";
            this.menuChucNang.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuFormPhong,
                this.menuFormKhachThue,
                this.menuSeparator1,
                this.menuThoatItem
            });

            this.menuFormPhong.Text = "Công việc 2: Quản Lý Phòng";
            this.menuFormPhong.Click += new EventHandler(this.menuFormPhong_Click);

            this.menuFormKhachThue.Text = "Công việc 3: QL Khách Thuê Phòng (Đang mở)";
            this.menuFormKhachThue.Enabled = false;

            this.menuThoatItem.Text = "Thoát";
            this.menuThoatItem.Click += new EventHandler(this.btnThoat_Click);

            this.menuHeThong.Text = "Hệ thống / CSDL";
            this.menuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuDoiServerItem,
                this.menuTaoCSDLItem
            });
            this.menuDoiServerItem.Text = "⚙ Đổi Tên SQL Server...";
            this.menuDoiServerItem.Click += new EventHandler(this.lblDoiServer_Click);
            this.menuTaoCSDLItem.Text = "⚡ Tự động tạo CSDL & Dữ liệu mẫu (Công việc 1)";
            this.menuTaoCSDLItem.Click += new EventHandler(this.lblTaoCSDL_Click);

            // 
            // FormKhachThue
            // 
            this.Text = "QL Khách Thuê Phòng";
            this.ClientSize = new Size(710, 680);
            this.MinimumSize = new Size(710, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 233, 216);
            this.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.FormClosing += new FormClosingEventHandler(this.FormKhachThue_FormClosing);
            this.Load += new EventHandler(this.FormKhachThue_Load);

            // 
            // 1. GroupBox grbXemPhong ("Xem thông tin Phòng")
            // 
            this.grbXemPhong.Text = "Xem thông tin Phòng";
            this.grbXemPhong.Location = new Point(15, 30);
            this.grbXemPhong.Size = new Size(680, 88);
            this.grbXemPhong.ForeColor = Color.FromArgb(0, 70, 140);

            // Label Tình trạng Phòng
            this.lblTinhTrangPhong.Text = "Tình trạng Phòng";
            this.lblTinhTrangPhong.Location = new Point(20, 24);
            this.lblTinhTrangPhong.Size = new Size(110, 20);
            this.lblTinhTrangPhong.ForeColor = Color.Black;

            // ComboBox cboTinhTrangPhong (Yêu cầu a: Có, Không)
            this.cboTinhTrangPhong.Location = new Point(135, 21);
            this.cboTinhTrangPhong.Size = new Size(130, 22);
            this.cboTinhTrangPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTinhTrangPhong.Items.AddRange(new object[] { "Có", "Không" });

            // Button btnXemTheoTinhTrang (Yêu cầu b)
            this.btnXemTheoTinhTrang.Text = "Xem theo tình trạng";
            this.btnXemTheoTinhTrang.Location = new Point(285, 19);
            this.btnXemTheoTinhTrang.Size = new Size(140, 26);
            this.btnXemTheoTinhTrang.ForeColor = Color.Black;
            this.btnXemTheoTinhTrang.UseVisualStyleBackColor = true;
            this.btnXemTheoTinhTrang.Click += new EventHandler(this.btnXemTheoTinhTrang_Click);

            // Label Loại Phòng
            this.lblLoaiPhong.Text = "Loại Phòng";
            this.lblLoaiPhong.Location = new Point(20, 55);
            this.lblLoaiPhong.Size = new Size(110, 20);
            this.lblLoaiPhong.ForeColor = Color.Black;

            // ComboBox cboLoaiPhong (Yêu cầu a: Phòng đơn, Phòng đôi, Phòng ba)
            this.cboLoaiPhong.Location = new Point(135, 52);
            this.cboLoaiPhong.Size = new Size(130, 22);
            this.cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.Items.AddRange(new object[] { "Phòng đơn", "Phòng đôi", "Phòng ba" });

            // Button btnXemTheoLoaiPhong (Yêu cầu c)
            this.btnXemTheoLoaiPhong.Text = "Xem theo loại Phòng";
            this.btnXemTheoLoaiPhong.Location = new Point(285, 50);
            this.btnXemTheoLoaiPhong.Size = new Size(140, 26);
            this.btnXemTheoLoaiPhong.ForeColor = Color.Black;
            this.btnXemTheoLoaiPhong.UseVisualStyleBackColor = true;
            this.btnXemTheoLoaiPhong.Click += new EventHandler(this.btnXemTheoLoaiPhong_Click);

            this.grbXemPhong.Controls.Add(this.lblTinhTrangPhong);
            this.grbXemPhong.Controls.Add(this.cboTinhTrangPhong);
            this.grbXemPhong.Controls.Add(this.btnXemTheoTinhTrang);
            this.grbXemPhong.Controls.Add(this.lblLoaiPhong);
            this.grbXemPhong.Controls.Add(this.cboLoaiPhong);
            this.grbXemPhong.Controls.Add(this.btnXemTheoLoaiPhong);

            // 
            // 2. Chi tiết Phòng
            // 
            this.lblChiTietPhong.Text = "Chi tiết Phòng";
            this.lblChiTietPhong.Location = new Point(15, 122);
            this.lblChiTietPhong.Size = new Size(150, 18);
            this.lblChiTietPhong.ForeColor = Color.FromArgb(0, 70, 140);
            this.lblChiTietPhong.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.dgvPhong.Location = new Point(15, 142);
            this.dgvPhong.Size = new Size(680, 115);
            this.dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvPhong.BackgroundColor = Color.White;
            this.dgvPhong.BorderStyle = BorderStyle.Fixed3D;
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.RowHeadersVisible = true;
            this.dgvPhong.RowHeadersWidth = 35;
            this.dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // 3. GroupBox grbKhachThue ("Thông tin Khách thuê")
            // 
            this.grbKhachThue.Text = "Thông tin Khách thuê";
            this.grbKhachThue.Location = new Point(15, 265);
            this.grbKhachThue.Size = new Size(680, 145);
            this.grbKhachThue.ForeColor = Color.FromArgb(0, 70, 140);

            // Số CMT
            this.lblSoCMT.Text = "Số CMT";
            this.lblSoCMT.Location = new Point(20, 26);
            this.lblSoCMT.Size = new Size(70, 20);
            this.lblSoCMT.ForeColor = Color.Black;

            this.txtSoCMT.Location = new Point(95, 23);
            this.txtSoCMT.Size = new Size(190, 22);

            // Giới tính (Yêu cầu a: Nam, Nữ)
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.Location = new Point(340, 26);
            this.lblGioiTinh.Size = new Size(70, 20);
            this.lblGioiTinh.ForeColor = Color.Black;

            this.cboGioiTinh.Location = new Point(420, 23);
            this.cboGioiTinh.Size = new Size(130, 22);
            this.cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });

            // Họ tên
            this.lblHoTen.Text = "Họ tên";
            this.lblHoTen.Location = new Point(20, 60);
            this.lblHoTen.Size = new Size(70, 20);
            this.lblHoTen.ForeColor = Color.Black;

            this.txtHoTen.Location = new Point(95, 57);
            this.txtHoTen.Size = new Size(190, 22);

            // Mã Phòng (Yêu cầu d: Đưa các mã phòng có Tình trạng là "Không")
            this.lblMaPhong.Text = "Mã Phòng";
            this.lblMaPhong.Location = new Point(340, 60);
            this.lblMaPhong.Size = new Size(70, 20);
            this.lblMaPhong.ForeColor = Color.Black;

            this.cboMaPhong.Location = new Point(420, 57);
            this.cboMaPhong.Size = new Size(130, 22);
            this.cboMaPhong.DropDownStyle = ComboBoxStyle.DropDownList;

            // 4 nút chức năng: Nhập, Xóa, Sửa, Thoát (Thứ tự đúng Hình 9.43)
            this.btnNhap.Text = "Nhập";
            this.btnNhap.Location = new Point(50, 98);
            this.btnNhap.Size = new Size(95, 30);
            this.btnNhap.ForeColor = Color.Black;
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new EventHandler(this.btnNhap_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new Point(190, 98);
            this.btnXoa.Size = new Size(95, 30);
            this.btnXoa.ForeColor = Color.Black;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new Point(330, 98);
            this.btnSua.Size = new Size(95, 30);
            this.btnSua.ForeColor = Color.Black;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new EventHandler(this.btnSua_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(470, 98);
            this.btnThoat.Size = new Size(95, 30);
            this.btnThoat.ForeColor = Color.Black;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            this.grbKhachThue.Controls.Add(this.lblSoCMT);
            this.grbKhachThue.Controls.Add(this.txtSoCMT);
            this.grbKhachThue.Controls.Add(this.lblGioiTinh);
            this.grbKhachThue.Controls.Add(this.cboGioiTinh);
            this.grbKhachThue.Controls.Add(this.lblHoTen);
            this.grbKhachThue.Controls.Add(this.txtHoTen);
            this.grbKhachThue.Controls.Add(this.lblMaPhong);
            this.grbKhachThue.Controls.Add(this.cboMaPhong);
            this.grbKhachThue.Controls.Add(this.btnNhap);
            this.grbKhachThue.Controls.Add(this.btnXoa);
            this.grbKhachThue.Controls.Add(this.btnSua);
            this.grbKhachThue.Controls.Add(this.btnThoat);

            // 
            // 4. Chi tiết Khách hàng
            // 
            this.lblChiTietKhachHang.Text = "Chi tiết Khách hàng";
            this.lblChiTietKhachHang.Location = new Point(15, 420);
            this.lblChiTietKhachHang.Size = new Size(180, 18);
            this.lblChiTietKhachHang.ForeColor = Color.FromArgb(0, 70, 140);
            this.lblChiTietKhachHang.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.dgvKhachHang.Location = new Point(15, 440);
            this.dgvKhachHang.Size = new Size(680, 185);
            this.dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvKhachHang.BackgroundColor = Color.White;
            this.dgvKhachHang.BorderStyle = BorderStyle.Fixed3D;
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.MultiSelect = true; // Cho phép chọn nhiều dòng để xóa theo yêu cầu f
            this.dgvKhachHang.RowHeadersVisible = true;
            this.dgvKhachHang.RowHeadersWidth = 35;
            this.dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.CellClick += new DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // 
            // StatusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatus,
                this.lblDoiServer,
                this.lblTaoCSDL,
                this.lblMoFormPhong
            });
            this.statusStrip.Location = new Point(0, 658);
            this.statusStrip.Size = new Size(710, 22);

            this.lblStatus.Text = "Server: " + serverName + " | CSDL: " + dbName;
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            this.lblDoiServer.Text = "[ ⚙ Đổi Server ]";
            this.lblDoiServer.IsLink = true;
            this.lblDoiServer.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblDoiServer.Click += new EventHandler(this.lblDoiServer_Click);

            this.lblTaoCSDL.Text = "[ ⚡ Tạo CSDL ]";
            this.lblTaoCSDL.IsLink = true;
            this.lblTaoCSDL.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblTaoCSDL.Click += new EventHandler(this.lblTaoCSDL_Click);

            this.lblMoFormPhong.Text = "[ 🚪 Mở Form QL Phòng ]";
            this.lblMoFormPhong.IsLink = true;
            this.lblMoFormPhong.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblMoFormPhong.Click += new EventHandler(this.menuFormPhong_Click);

            // 
            // Thêm controls vào Form chính
            // 
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.lblChiTietKhachHang);
            this.Controls.Add(this.grbKhachThue);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.lblChiTietPhong);
            this.Controls.Add(this.grbXemPhong);
            this.Controls.Add(this.menuStrip);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grbXemPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.grbKhachThue.ResumeLayout(false);
            this.grbKhachThue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Xử lý Cấu hình Server & CSDL
        private void DocCauHinhServer()
        {
            try
            {
                if (File.Exists(serverConfigFile))
                {
                    string content = File.ReadAllText(serverConfigFile).Trim();
                    if (!string.IsNullOrEmpty(content))
                    {
                        serverName = content;
                    }
                }
            }
            catch { }
        }

        private void LuuCauHinhServer(string moi)
        {
            try
            {
                serverName = moi;
                File.WriteAllText(serverConfigFile, serverName);
                if (lblStatus != null)
                {
                    lblStatus.Text = "Server: " + serverName + " | CSDL: " + dbName;
                }
            }
            catch { }
        }

        private void lblDoiServer_Click(object sender, EventArgs e)
        {
            string prompt = "Nhập tên SQL Server của bạn (ví dụ: . hoặc .\\SQLEXPRESS hoặc localhost):";
            string giaTri = HienThiHopThoaiNhapLieu("Cấu hình Tên SQL Server", prompt, serverName);
            if (!string.IsNullOrEmpty(giaTri))
            {
                LuuCauHinhServer(giaTri.Trim());
                TaiDuLieuBanDau();
            }
        }

        private void lblTaoCSDL_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn tự động tạo cơ sở dữ liệu 'QL_KhachSan', tạo 3 bảng (Phong, KH, ThueP) và nạp dữ liệu mẫu không?",
                "Xác nhận khởi tạo CSDL",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                TaoCSDLVaDuLieuMau();
            }
        }

        private void TaoCSDLVaDuLieuMau()
        {
            try
            {
                using (SqlConnection masterConn = new SqlConnection(MasterConnectionString))
                {
                    masterConn.Open();
                    string sqlCreateDb = @"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_KhachSan')
                        BEGIN
                            CREATE DATABASE QL_KhachSan;
                        END";
                    using (SqlCommand cmd = new SqlCommand(sqlCreateDb, masterConn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection appConn = new SqlConnection(AppConnectionString))
                {
                    appConn.Open();
                    string sqlTables = @"
                        IF OBJECT_ID(N'dbo.ThueP', N'U') IS NULL AND OBJECT_ID(N'dbo.Phong', N'U') IS NULL
                        BEGIN
                            CREATE TABLE Phong (
                                MaPH VARCHAR(10) NOT NULL PRIMARY KEY,
                                LoaiP NVARCHAR(50) NOT NULL,
                                HangP NVARCHAR(50) NOT NULL,
                                DonGia DECIMAL(18, 0) NOT NULL,
                                TinhTrang NVARCHAR(20) NOT NULL,
                                CONSTRAINT CHK_Phong_LoaiP CHECK (LoaiP IN (N'Phòng đơn', N'Phòng đôi', N'Phòng ba')),
                                CONSTRAINT CHK_Phong_HangP CHECK (HangP IN (N'Thường', N'VIP', N'Sang')),
                                CONSTRAINT CHK_Phong_TinhTrang CHECK (TinhTrang IN (N'Có', N'Không')),
                                CONSTRAINT CHK_Phong_DonGia CHECK (DonGia >= 0)
                            );

                            CREATE TABLE KH (
                                SoCMT VARCHAR(20) NOT NULL PRIMARY KEY,
                                Hoten NVARCHAR(100) NOT NULL,
                                Gioitinh NVARCHAR(10) NOT NULL,
                                CONSTRAINT CHK_KH_Gioitinh CHECK (Gioitinh IN (N'Nam', N'Nữ'))
                            );

                            CREATE TABLE ThueP (
                                SoCMT VARCHAR(20) NOT NULL,
                                MaPH VARCHAR(10) NOT NULL,
                                NgayDen DATETIME NOT NULL,
                                NgayDi DATETIME NULL,
                                TienSDDV DECIMAL(18, 0) NULL DEFAULT 0,
                                CONSTRAINT PK_ThueP PRIMARY KEY (SoCMT, MaPH, NgayDen),
                                CONSTRAINT FK_ThueP_KH FOREIGN KEY (SoCMT) REFERENCES KH(SoCMT) ON UPDATE CASCADE ON DELETE CASCADE,
                                CONSTRAINT FK_ThueP_Phong FOREIGN KEY (MaPH) REFERENCES Phong(MaPH) ON UPDATE CASCADE ON DELETE CASCADE
                            );

                            INSERT INTO Phong (MaPH, LoaiP, HangP, DonGia, TinhTrang) VALUES
                            ('P001', N'Phòng đơn', N'Thường', 200000, N'Có'),
                            ('P002', N'Phòng đơn', N'Thường', 200000, N'Có'),
                            ('P003', N'Phòng đơn', N'Thường', 200000, N'Không'),
                            ('P004', N'Phòng đơn', N'Sang',   300000, N'Không'),
                            ('P005', N'Phòng đơn', N'Sang',   300000, N'Không'),
                            ('P006', N'Phòng đơn', N'VIP',    400000, N'Có'),
                            ('P007', N'Phòng đôi', N'Thường', 300000, N'Có');

                            INSERT INTO KH (SoCMT, Hoten, Gioitinh) VALUES
                            ('162626524', N'Đinh Gia Trường', N'Nam'),
                            ('162707094', N'Bùi Thị Thảo', N'Nữ'),
                            ('162707095', N'Đinh Gia Minh', N'Nam'),
                            ('162709945', N'Nguyễn Thị Thu ...', N'Nữ');

                            INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV) VALUES
                            ('162626524', 'P007', '2013-10-21 08:00:00', NULL, 0),
                            ('162707094', 'P001', '2013-10-21 09:15:00', NULL, 0),
                            ('162707095', 'P002', '2013-10-21 10:30:00', NULL, 0),
                            ('162709945', 'P006', '2013-10-21 11:00:00', NULL, 0);
                        END";

                    using (SqlCommand cmd = new SqlCommand(sqlTables, appConn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Khởi tạo CSDL 'QL_KhachSan' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDuLieuBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo CSDL:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu a: Load Form & Chọn dòng hiển thị lên TextBox, ComboBox
        private void FormKhachThue_Load(object sender, EventArgs e)
        {
            KhoiTaoCacCotLuoiPhong();
            KhoiTaoCacCotLuoiKhachHang();

            // Mặc định chọn các combobox
            if (cboTinhTrangPhong.Items.Count > 0) cboTinhTrangPhong.SelectedIndex = 0; // "Có"
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0; // "Phòng đơn"
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0; // "Nam"

            TaiDuLieuBanDau();
        }

        private void KhoiTaoCacCotLuoiPhong()
        {
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.Columns.Clear();

            DataGridViewTextBoxColumn colMaPH = new DataGridViewTextBoxColumn();
            colMaPH.DataPropertyName = "MaPH";
            colMaPH.HeaderText = "Mã Phòng";
            colMaPH.Name = "MaPH";
            colMaPH.Width = 100;
            dgvPhong.Columns.Add(colMaPH);

            DataGridViewTextBoxColumn colLoaiP = new DataGridViewTextBoxColumn();
            colLoaiP.DataPropertyName = "LoaiP";
            colLoaiP.HeaderText = "Loại Phòng";
            colLoaiP.Name = "LoaiP";
            colLoaiP.Width = 120;
            dgvPhong.Columns.Add(colLoaiP);

            DataGridViewTextBoxColumn colHangP = new DataGridViewTextBoxColumn();
            colHangP.DataPropertyName = "HangP";
            colHangP.HeaderText = "Hạng Phòng";
            colHangP.Name = "HangP";
            colHangP.Width = 110;
            dgvPhong.Columns.Add(colHangP);

            DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn();
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.Name = "DonGia";
            colDonGia.Width = 120;
            colDonGia.DefaultCellStyle.Format = "0.0000";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPhong.Columns.Add(colDonGia);

            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.DataPropertyName = "TinhTrang";
            colTinhTrang.HeaderText = "Tình trạng";
            colTinhTrang.Name = "TinhTrang";
            colTinhTrang.Width = 100;
            dgvPhong.Columns.Add(colTinhTrang);
        }

        private void KhoiTaoCacCotLuoiKhachHang()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();

            // Cột 1: Số CMT
            DataGridViewTextBoxColumn colCMT = new DataGridViewTextBoxColumn();
            colCMT.DataPropertyName = "SoCMT";
            colCMT.HeaderText = "Số CMT";
            colCMT.Name = "SoCMT";
            colCMT.Width = 120;
            dgvKhachHang.Columns.Add(colCMT);

            // Cột 2: Họ tên
            DataGridViewTextBoxColumn colHoTen = new DataGridViewTextBoxColumn();
            colHoTen.DataPropertyName = "Hoten";
            colHoTen.HeaderText = "Họ tên";
            colHoTen.Name = "Hoten";
            colHoTen.Width = 160;
            dgvKhachHang.Columns.Add(colHoTen);

            // Cột 3: Giới tính
            DataGridViewTextBoxColumn colGioiTinh = new DataGridViewTextBoxColumn();
            colGioiTinh.DataPropertyName = "Gioitinh";
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.Name = "Gioitinh";
            colGioiTinh.Width = 90;
            dgvKhachHang.Columns.Add(colGioiTinh);

            // Cột 4: Mã Phòng
            DataGridViewTextBoxColumn colMaPH = new DataGridViewTextBoxColumn();
            colMaPH.DataPropertyName = "MaPH";
            colMaPH.HeaderText = "Mã Phòng";
            colMaPH.Name = "MaPH";
            colMaPH.Width = 110;
            dgvKhachHang.Columns.Add(colMaPH);

            // Cột 5: Ngày đến (định dạng dd/MM/yyyy)
            DataGridViewTextBoxColumn colNgayDen = new DataGridViewTextBoxColumn();
            colNgayDen.DataPropertyName = "NgayDen";
            colNgayDen.HeaderText = "Ngày đến";
            colNgayDen.Name = "NgayDen";
            colNgayDen.Width = 120;
            colNgayDen.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvKhachHang.Columns.Add(colNgayDen);
        }

        private void TaiDuLieuBanDau()
        {
            LoadDanhSachPhongTrongVaoCombo();
            LoadDanhSachKhachChuaThanhToan();
            // Mặc định load các phòng đang "Có" lên lưới chi tiết phòng như ảnh mẫu
            TaiDanhSachPhongTheoTinhTrang("Có");
        }

        /// <summary>
        /// Yêu cầu d: Đưa toàn bộ các Mã Phòng có Tình trạng là “Không” vào Combobox Mã Phòng
        /// </summary>
        private void LoadDanhSachPhongTrongVaoCombo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaPH FROM Phong WHERE TinhTrang = N'Không' ORDER BY MaPH";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cboMaPhong.Items.Clear();
                            while (reader.Read())
                            {
                                cboMaPhong.Items.Add(reader["MaPH"].ToString());
                            }
                        }
                    }
                }

                if (cboMaPhong.Items.Count > 0)
                {
                    cboMaPhong.SelectedIndex = 0;
                }
            }
            catch { }
        }

        /// <summary>
        /// Yêu cầu a: Khi Load Form: Thông tin của những khách thuê phòng chưa thanh toán được hiển thị lên lưới Chi tiết khách hàng
        /// </summary>
        private void LoadDanhSachKhachChuaThanhToan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    // Chưa thanh toán = NgayDi IS NULL
                    string sql = @"
                        SELECT t.SoCMT, k.Hoten, k.Gioitinh, t.MaPH, t.NgayDen
                        FROM ThueP t
                        JOIN KH k ON t.SoCMT = k.SoCMT
                        WHERE t.NgayDi IS NULL
                        ORDER BY t.NgayDen DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKhachHang.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                DialogResult dr = MessageBox.Show(
                    string.Format("Không thể kết nối CSDL tại Server: '{0}'.\n\nChi tiết: {1}\n\nBạn có muốn đổi Tên Server (ví dụ: .\\SQLEXPRESS) không?", serverName, ex.Message),
                    "Lỗi kết nối CSDL",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (dr == DialogResult.Yes)
                {
                    lblDoiServer_Click(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yêu cầu a: Khi kích chọn một dòng trên lưới Chi tiết khách hàng thì hiển thị thông tin khách hàng đó lên các Textbox và Combobox tương ứng
        /// </summary>
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                if (row.Cells["SoCMT"].Value != null)
                {
                    txtSoCMT.Text = row.Cells["SoCMT"].Value.ToString().Trim();
                    txtSoCMT.ReadOnly = true; // Khóa số CMT khi chọn sửa
                    txtSoCMT.BackColor = Color.FromArgb(240, 240, 240);
                }

                if (row.Cells["Hoten"].Value != null)
                {
                    txtHoTen.Text = row.Cells["Hoten"].Value.ToString().Trim();
                }

                if (row.Cells["Gioitinh"].Value != null)
                {
                    cboGioiTinh.Text = row.Cells["Gioitinh"].Value.ToString().Trim();
                }

                if (row.Cells["MaPH"].Value != null)
                {
                    string maPH = row.Cells["MaPH"].Value.ToString().Trim();
                    // Nếu mã phòng này hiện không nằm trong danh sách phòng trống, thêm tạm vào để hiển thị
                    if (!cboMaPhong.Items.Contains(maPH))
                    {
                        cboMaPhong.Items.Add(maPH);
                    }
                    cboMaPhong.Text = maPH;
                }
            }
        }
        #endregion

        #region Yêu cầu b: Nút "Xem theo tình trạng"
        /// <summary>
        /// Yêu cầu b: Khi người dùng chọn trong Combo Tình trạng phòng rồi nhấn vào nút Xem theo tình trạng,
        /// thông tin về các phòng sẽ được hiển thị lên lưới Chi tiết phòng.
        /// </summary>
        private void btnXemTheoTinhTrang_Click(object sender, EventArgs e)
        {
            string tinhTrang = cboTinhTrangPhong.Text.Trim();
            if (string.IsNullOrEmpty(tinhTrang))
            {
                MessageBox.Show("Vui lòng chọn Tình trạng phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiDanhSachPhongTheoTinhTrang(tinhTrang);
        }

        private void TaiDanhSachPhongTheoTinhTrang(string tinhTrang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaPH, LoaiP, HangP, DonGia, TinhTrang FROM Phong WHERE TinhTrang = @TinhTrang ORDER BY MaPH";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvPhong.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem phòng theo tình trạng:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu c: Nút "Xem theo loại phòng"
        /// <summary>
        /// Yêu cầu c: Khi người dùng chọn trong Combo Loại phòng rồi nhấn vào nút Xem theo loại phòng,
        /// thông tin về các phòng sẽ được hiển thị lên lưới Chi tiết phòng.
        /// </summary>
        private void btnXemTheoLoaiPhong_Click(object sender, EventArgs e)
        {
            string loaiPhong = cboLoaiPhong.Text.Trim();
            if (string.IsNullOrEmpty(loaiPhong))
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaPH, LoaiP, HangP, DonGia, TinhTrang FROM Phong WHERE LoaiP = @LoaiP ORDER BY MaPH";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoaiP", loaiPhong);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvPhong.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem phòng theo loại phòng:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu d: Nút "Nhập"
        /// <summary>
        /// Yêu cầu d: Nút Nhập phải bổ sung được các thông tin về khách hàng vào bảng “KH” trong CSDL nếu khách hàng đó chưa có trong bảng “KH”;
        /// thông tin về thuê phòng vào bảng “ThueP” và hiển thị lên lưới.
        /// Yêu cầu: ngày đến lấy theo ngày hiện tại; ngày đi và tiền sử dụng dịch vụ để trống;
        /// đồng thời cập nhật Tình trạng của phòng đó trong bảng “Phong” thành “Có”.
        /// </summary>
        private void btnNhap_Click(object sender, EventArgs e)
        {
            string soCMT = txtSoCMT.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            string maPH = cboMaPhong.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(soCMT))
            {
                MessageBox.Show("Vui lòng nhập Số CMT của khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCMT.Focus();
                return;
            }

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên của khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }

            if (string.IsNullOrEmpty(maPH))
            {
                MessageBox.Show("Vui lòng chọn Mã Phòng thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaPhong.Focus();
                return;
            }

            DateTime ngayDen = DateTime.Now;

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    // Bắt đầu Transaction để đảm bảo tính toàn vẹn giữa KH, ThueP và Phong
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Bổ sung thông tin khách hàng vào KH nếu chưa có
                            string sqlKH = @"
                                IF NOT EXISTS (SELECT 1 FROM KH WHERE SoCMT = @SoCMT)
                                BEGIN
                                    INSERT INTO KH (SoCMT, Hoten, Gioitinh) VALUES (@SoCMT, @Hoten, @Gioitinh);
                                END
                                ELSE
                                BEGIN
                                    UPDATE KH SET Hoten = @Hoten, Gioitinh = @Gioitinh WHERE SoCMT = @SoCMT;
                                END";

                            using (SqlCommand cmdKH = new SqlCommand(sqlKH, conn, trans))
                            {
                                cmdKH.Parameters.AddWithValue("@SoCMT", soCMT);
                                cmdKH.Parameters.AddWithValue("@Hoten", hoTen);
                                cmdKH.Parameters.AddWithValue("@Gioitinh", gioiTinh);
                                cmdKH.ExecuteNonQuery();
                            }

                            // 2. Thêm thông tin vào bảng ThueP:
                            // Ngày đến lấy ngày hiện tại, ngày đi và tiền dịch vụ để trống (NULL / 0)
                            string sqlThueP = @"
                                INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV)
                                VALUES (@SoCMT, @MaPH, @NgayDen, NULL, 0)";

                            using (SqlCommand cmdThueP = new SqlCommand(sqlThueP, conn, trans))
                            {
                                cmdThueP.Parameters.AddWithValue("@SoCMT", soCMT);
                                cmdThueP.Parameters.AddWithValue("@MaPH", maPH);
                                cmdThueP.Parameters.AddWithValue("@NgayDen", ngayDen);
                                cmdThueP.ExecuteNonQuery();
                            }

                            // 3. Cập nhật Tình trạng của phòng đó trong bảng Phong thành "Có"
                            string sqlPhong = "UPDATE Phong SET TinhTrang = N'Có' WHERE MaPH = @MaPH";
                            using (SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans))
                            {
                                cmdPhong.Parameters.AddWithValue("@MaPH", maPH);
                                cmdPhong.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    string.Format("Đăng ký thuê phòng '{0}' cho khách hàng '{1}' thành công!", maPH, hoTen),
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Cập nhật lại giao diện
                LoadDanhSachKhachChuaThanhToan();
                LoadDanhSachPhongTrongVaoCombo();

                // Cập nhật lại lưới phòng nếu đang hiển thị
                if (!string.IsNullOrEmpty(cboTinhTrangPhong.Text))
                {
                    TaiDanhSachPhongTheoTinhTrang(cboTinhTrangPhong.Text);
                }

                // Xóa trắng form để nhập tiếp
                XoaTrangFormKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập khách thuê phòng:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaTrangFormKhach()
        {
            txtSoCMT.Clear();
            txtHoTen.Clear();
            txtSoCMT.ReadOnly = false;
            txtSoCMT.BackColor = Color.White;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboMaPhong.Items.Count > 0) cboMaPhong.SelectedIndex = 0;
            txtSoCMT.Focus();
        }
        #endregion

        #region Yêu cầu e: Nút "Sửa"
        /// <summary>
        /// Yêu cầu e: Nút Sửa: Phải sửa được các thông tin về họ tên, giới tính của bản ghi được chọn
        /// trên lưới chi tiết khách hàng vào bảng “KH” và hiện thông tin vừa sửa lên lưới.
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            string soCMT = txtSoCMT.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();

            if (string.IsNullOrEmpty(soCMT))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng trên danh sách để sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    // Sửa họ tên và giới tính trong bảng KH
                    string sqlUpdate = "UPDATE KH SET Hoten = @Hoten, Gioitinh = @Gioitinh WHERE SoCMT = @SoCMT";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@Hoten", hoTen);
                        cmd.Parameters.AddWithValue("@Gioitinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@SoCMT", soCMT);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show(
                                string.Format("Cập nhật thông tin khách hàng '{0}' thành công!", hoTen),
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng với Số CMT này để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Cập nhật lại thông tin lên lưới Chi tiết khách hàng
                LoadDanhSachKhachChuaThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin khách hàng:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu f: Nút "Xóa"
        /// <summary>
        /// Yêu cầu f: Nút Xóa: Phải xóa được thông tin thuê phòng trong bảng “ThueP” của các dòng được chọn trên lưới;
        /// cập nhật Tình trạng của các phòng đó trong bảng “Phong” thành “Không”;
        /// đồng thời cập nhật thông tin sau khi xóa lên lưới.
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng khách thuê phòng trên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soDong = dgvKhachHang.SelectedRows.Count;
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa {0} lượt thuê phòng đang chọn không?\n(Tình trạng các phòng này sẽ được trả về 'Không')", soDong),
                "Xác nhận xóa thuê phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes)
            {
                return;
            }

            int daXoa = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvKhachHang.SelectedRows)
                    {
                        if (row.Cells["SoCMT"].Value != null && row.Cells["MaPH"].Value != null)
                        {
                            string soCMT = row.Cells["SoCMT"].Value.ToString().Trim();
                            string maPH = row.Cells["MaPH"].Value.ToString().Trim();

                            using (SqlTransaction trans = conn.BeginTransaction())
                            {
                                try
                                {
                                    // 1. Xóa thông tin thuê phòng trong bảng ThueP
                                    string sqlDelete = "DELETE FROM ThueP WHERE SoCMT = @SoCMT AND MaPH = @MaPH AND NgayDi IS NULL";
                                    using (SqlCommand cmdDel = new SqlCommand(sqlDelete, conn, trans))
                                    {
                                        cmdDel.Parameters.AddWithValue("@SoCMT", soCMT);
                                        cmdDel.Parameters.AddWithValue("@MaPH", maPH);
                                        cmdDel.ExecuteNonQuery();
                                    }

                                    // 2. Cập nhật Tình trạng phòng đó trong bảng Phong thành "Không"
                                    string sqlPhong = "UPDATE Phong SET TinhTrang = N'Không' WHERE MaPH = @MaPH";
                                    using (SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans))
                                    {
                                        cmdPhong.Parameters.AddWithValue("@MaPH", maPH);
                                        cmdPhong.ExecuteNonQuery();
                                    }

                                    trans.Commit();
                                    daXoa++;
                                }
                                catch
                                {
                                    trans.Rollback();
                                }
                            }
                        }
                    }
                }

                // Cập nhật lại thông tin lên lưới Chi tiết khách hàng
                LoadDanhSachKhachChuaThanhToan();

                // Cập nhật lại danh sách phòng trống vào cboMaPhong
                LoadDanhSachPhongTrongVaoCombo();

                // Cập nhật lại lưới phòng
                if (!string.IsNullOrEmpty(cboTinhTrangPhong.Text))
                {
                    TaiDanhSachPhongTheoTinhTrang(cboTinhTrangPhong.Text);
                }

                XoaTrangFormKhach();

                MessageBox.Show(
                    string.Format("Đã xóa thành công {0} lượt thuê phòng và cập nhật lại trạng thái phòng thành 'Không'!", daXoa),
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thuê phòng:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu g: Nút Thoát & Xử lý đóng/hủy đóng Form
        private bool daXacNhanThoat = false;

        /// <summary>
        /// Yêu cầu g) Nút Thoát: Phải hiển thị được hộp thoại xác nhận có muốn thoát không và xử lý được việc đóng hoặc hủy việc đóng Form.
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                daXacNhanThoat = true;
                this.Close();
            }
            // Nếu chọn No: hủy việc đóng Form (không làm gì cả, giữ nguyên Form)
        }

        private void FormKhachThue_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu người dùng bấm nút [X] của cửa sổ (chưa qua xác nhận ở nút Thoát)
            if (!daXacNhanThoat)
            {
                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.No)
                {
                    e.Cancel = true; // Hủy việc đóng Form
                    return;
                }
            }
        }

        private void menuFormPhong_Click(object sender, EventArgs e)
        {
            FormPhong frm = new FormPhong();
            frm.Show();
        }
        #endregion

        #region Tiện ích Hộp thoại Nhập liệu
        private string HienThiHopThoaiNhapLieu(string title, string promptText, string defaultValue)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = defaultValue;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Hủy";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(15, 15, 370, 40);
            textBox.SetBounds(15, 60, 370, 22);
            buttonOk.SetBounds(215, 95, 80, 28);
            buttonCancel.SetBounds(305, 95, 80, 28);

            form.ClientSize = new Size(405, 135);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog(this);
            return dialogResult == DialogResult.OK ? textBox.Text : null;
        }
        #endregion
    }
}
