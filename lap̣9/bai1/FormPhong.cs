using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public class FormPhong : Form
    {
        #region Khai báo điều khiển giao diện (Controls)
        private GroupBox grbThongTin;
        private Label lblMaPhong;
        private TextBox txtMaPhong;
        private Label lblLoaiPhong;
        private ComboBox cboLoaiPhong;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblHangPhong;
        private ComboBox cboHangPhong;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;

        private Label lblDanhSach;
        private DataGridView dgvPhong;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblDoiServer;
        private ToolStripStatusLabel lblTaoCSDL;
        private ToolStripStatusLabel lblMoFormKhachThue;
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

        public FormPhong()
        {
            DocCauHinhServer();
            InitializeComponent();
        }

        #region Khởi tạo Giao diện (Thiết kế giống chuẩn Hình 9.42)
        private void InitializeComponent()
        {
            this.grbThongTin = new GroupBox();
            this.lblMaPhong = new Label();
            this.txtMaPhong = new TextBox();
            this.lblLoaiPhong = new Label();
            this.cboLoaiPhong = new ComboBox();
            this.lblDonGia = new Label();
            this.txtDonGia = new TextBox();
            this.lblHangPhong = new Label();
            this.cboHangPhong = new ComboBox();

            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            this.lblDanhSach = new Label();
            this.dgvPhong = new DataGridView();

            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblDoiServer = new ToolStripStatusLabel();
            this.lblTaoCSDL = new ToolStripStatusLabel();
            this.lblMoFormKhachThue = new ToolStripStatusLabel();

            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormPhong
            // 
            this.Text = "Quản Lý Phòng";
            this.ClientSize = new Size(670, 560);
            this.MinimumSize = new Size(670, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 233, 216); // Màu xám ấm chuẩn như trong ảnh mẫu
            this.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.FormClosing += new FormClosingEventHandler(this.FormPhong_FormClosing);
            this.Load += new EventHandler(this.FormPhong_Load);

            // 
            // grbThongTin ("Nhập thông tin Phòng")
            // 
            this.grbThongTin.Text = "Nhập thông tin Phòng";
            this.grbThongTin.Location = new Point(20, 15);
            this.grbThongTin.Size = new Size(625, 175);
            this.grbThongTin.ForeColor = Color.FromArgb(0, 70, 140);
            this.grbThongTin.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // 
            // lblMaPhong
            // 
            this.lblMaPhong.Text = "Mã Phòng";
            this.lblMaPhong.Location = new Point(25, 30);
            this.lblMaPhong.Size = new Size(75, 20);
            this.lblMaPhong.ForeColor = Color.Black;

            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new Point(110, 27);
            this.txtMaPhong.Size = new Size(160, 22);

            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Text = "Loại Phòng";
            this.lblLoaiPhong.Location = new Point(320, 30);
            this.lblLoaiPhong.Size = new Size(80, 20);
            this.lblLoaiPhong.ForeColor = Color.Black;

            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.Location = new Point(415, 27);
            this.cboLoaiPhong.Size = new Size(180, 22);
            this.cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            // Yêu cầu a: Combobox loại phòng nhận 3 giá trị: phòng đơn, phòng đôi, phòng ba
            this.cboLoaiPhong.Items.AddRange(new object[] { "Phòng đơn", "Phòng đôi", "Phòng ba" });

            // 
            // lblDonGia
            // 
            this.lblDonGia.Text = "Đơn giá";
            this.lblDonGia.Location = new Point(25, 72);
            this.lblDonGia.Size = new Size(75, 20);
            this.lblDonGia.ForeColor = Color.Black;

            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new Point(110, 69);
            this.txtDonGia.Size = new Size(160, 22);

            // 
            // lblHangPhong
            // 
            this.lblHangPhong.Text = "Hạng Phòng";
            this.lblHangPhong.Location = new Point(320, 72);
            this.lblHangPhong.Size = new Size(80, 20);
            this.lblHangPhong.ForeColor = Color.Black;

            // 
            // cboHangPhong
            // 
            this.cboHangPhong.Location = new Point(415, 69);
            this.cboHangPhong.Size = new Size(180, 22);
            this.cboHangPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            // Yêu cầu a: Combobox hạng phòng nhận 3 giá trị: Thường, Sang, VIP
            this.cboHangPhong.Items.AddRange(new object[] { "Thường", "Sang", "VIP" });

            // 
            // btnThem
            // 
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new Point(45, 122);
            this.btnThem.Size = new Size(95, 30);
            this.btnThem.ForeColor = Color.Black;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new EventHandler(this.btnThem_Click);

            // 
            // btnSua
            // 
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new Point(190, 122);
            this.btnSua.Size = new Size(95, 30);
            this.btnSua.ForeColor = Color.Black;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new EventHandler(this.btnSua_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new Point(335, 122);
            this.btnXoa.Size = new Size(95, 30);
            this.btnXoa.ForeColor = Color.Black;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(480, 122);
            this.btnThoat.Size = new Size(95, 30);
            this.btnThoat.ForeColor = Color.Black;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Thêm controls vào GroupBox
            this.grbThongTin.Controls.Add(this.lblMaPhong);
            this.grbThongTin.Controls.Add(this.txtMaPhong);
            this.grbThongTin.Controls.Add(this.lblLoaiPhong);
            this.grbThongTin.Controls.Add(this.cboLoaiPhong);
            this.grbThongTin.Controls.Add(this.lblDonGia);
            this.grbThongTin.Controls.Add(this.txtDonGia);
            this.grbThongTin.Controls.Add(this.lblHangPhong);
            this.grbThongTin.Controls.Add(this.cboHangPhong);
            this.grbThongTin.Controls.Add(this.btnThem);
            this.grbThongTin.Controls.Add(this.btnSua);
            this.grbThongTin.Controls.Add(this.btnXoa);
            this.grbThongTin.Controls.Add(this.btnThoat);

            // 
            // lblDanhSach ("Danh sách  Phòng")
            // 
            this.lblDanhSach.Text = "Danh sách  Phòng";
            this.lblDanhSach.Location = new Point(20, 203);
            this.lblDanhSach.Size = new Size(200, 24);
            this.lblDanhSach.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSach.ForeColor = Color.Black;

            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new Point(20, 232);
            this.dgvPhong.Size = new Size(625, 275);
            this.dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvPhong.BackgroundColor = Color.White;
            this.dgvPhong.BorderStyle = BorderStyle.Fixed3D;
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.MultiSelect = true; // Cho phép chọn nhiều dòng để xóa theo yêu cầu d
            this.dgvPhong.RowHeadersVisible = true;
            this.dgvPhong.RowHeadersWidth = 35;
            this.dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.CellClick += new DataGridViewCellEventHandler(this.dgvPhong_CellClick);

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatus,
                this.lblDoiServer,
                this.lblTaoCSDL,
                this.lblMoFormKhachThue
            });
            this.statusStrip.Location = new Point(0, 538);
            this.statusStrip.Size = new Size(670, 22);

            this.lblStatus.Text = "Server: " + serverName + " | CSDL: " + dbName;
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            this.lblDoiServer.Text = "[ ⚙ Đổi Server ]";
            this.lblDoiServer.IsLink = true;
            this.lblDoiServer.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblDoiServer.Click += new EventHandler(this.lblDoiServer_Click);

            this.lblTaoCSDL.Text = "[ ⚡ Khởi tạo CSDL & Dữ liệu mẫu ]";
            this.lblTaoCSDL.IsLink = true;
            this.lblTaoCSDL.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblTaoCSDL.Click += new EventHandler(this.lblTaoCSDL_Click);

            this.lblMoFormKhachThue.Text = "[ 📋 Mở Form QL Khách Thuê ]";
            this.lblMoFormKhachThue.IsLink = true;
            this.lblMoFormKhachThue.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblMoFormKhachThue.Click += new EventHandler(this.lblMoFormKhachThue_Click);

            // 
            // Thêm controls vào Form chính
            // 
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.statusStrip);

            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
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
                LoadDuLieuLenLuoi();
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
                            ('001200001234', N'Nguyễn Văn An', N'Nam'),
                            ('001201005678', N'Trần Thị Bình', N'Nữ'),
                            ('001202009876', N'Lê Hoàng Long', N'Nam');

                            INSERT INTO ThueP (SoCMT, MaPH, NgayDen, NgayDi, TienSDDV) VALUES
                            ('001200001234', 'P001', '2026-03-01 08:00:00', '2026-03-05 12:00:00', 150000),
                            ('001201005678', 'P002', '2026-03-10 14:00:00', '2026-03-12 10:00:00', 50000),
                            ('001202009876', 'P006', '2026-03-15 09:30:00', NULL, 200000);
                        END";

                    using (SqlCommand cmd = new SqlCommand(sqlTables, appConn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Khởi tạo CSDL 'QL_KhachSan' và dữ liệu mẫu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDuLieuLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo CSDL:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu a: Load Form & Chọn dòng hiển thị lên TextBox, ComboBox
        private void FormPhong_Load(object sender, EventArgs e)
        {
            KhoiTaoCacCotDataGridView();
            LoadDuLieuLenLuoi();

            // Mặc định chọn giá trị đầu tiên cho 2 Combobox
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            if (cboHangPhong.Items.Count > 0) cboHangPhong.SelectedIndex = 0;
        }

        private void KhoiTaoCacCotDataGridView()
        {
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.Columns.Clear();

            // Cột 1: Mã Phòng
            DataGridViewTextBoxColumn colMaPH = new DataGridViewTextBoxColumn();
            colMaPH.DataPropertyName = "MaPH";
            colMaPH.HeaderText = "Mã Phòng";
            colMaPH.Name = "MaPH";
            colMaPH.Width = 110;
            dgvPhong.Columns.Add(colMaPH);

            // Cột 2: Loại Phòng
            DataGridViewTextBoxColumn colLoaiP = new DataGridViewTextBoxColumn();
            colLoaiP.DataPropertyName = "LoaiP";
            colLoaiP.HeaderText = "Loại Phòng";
            colLoaiP.Name = "LoaiP";
            colLoaiP.Width = 120;
            dgvPhong.Columns.Add(colLoaiP);

            // Cột 3: Hạng Phòng
            DataGridViewTextBoxColumn colHangP = new DataGridViewTextBoxColumn();
            colHangP.DataPropertyName = "HangP";
            colHangP.HeaderText = "Hạng Phòng";
            colHangP.Name = "HangP";
            colHangP.Width = 110;
            dgvPhong.Columns.Add(colHangP);

            // Cột 4: Đơn giá (định dạng số thực giống mẫu 200.0000)
            DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn();
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.Name = "DonGia";
            colDonGia.Width = 120;
            colDonGia.DefaultCellStyle.Format = "0.0000";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPhong.Columns.Add(colDonGia);

            // Cột 5: Tình trạng
            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.DataPropertyName = "TinhTrang";
            colTinhTrang.HeaderText = "Tình trạng";
            colTinhTrang.Name = "TinhTrang";
            colTinhTrang.Width = 110;
            dgvPhong.Columns.Add(colTinhTrang);
        }

        private void LoadDuLieuLenLuoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();
                    string query = "SELECT MaPH, LoaiP, HangP, DonGia, TinhTrang FROM Phong ORDER BY MaPH";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPhong.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Nếu chưa có CSDL hoặc sai tên server
                DialogResult dr = MessageBox.Show(
                    string.Format("Không thể kết nối CSDL tại Server: '{0}'.\n\nChi tiết lỗi: {1}\n\nBạn có muốn đổi lại Tên Server (ví dụ: .\\SQLEXPRESS) ngay bây giờ không?", serverName, ex.Message),
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
                MessageBox.Show("Lỗi khi tải danh sách phòng:\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yêu cầu a: Khi kích chọn một dòng trên lưới thì các thông tin của dòng đó được hiển thị lên các Textbox và các Combobox tương ứng.
        /// </summary>
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhong.Rows.Count)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

                if (row.Cells["MaPH"].Value != null)
                {
                    txtMaPhong.Text = row.Cells["MaPH"].Value.ToString().Trim();
                    // Yêu cầu c: Không cho phép sửa mã phòng khi chọn dòng để sửa
                    txtMaPhong.ReadOnly = true;
                    txtMaPhong.BackColor = Color.FromArgb(240, 240, 240);
                }

                if (row.Cells["LoaiP"].Value != null)
                {
                    cboLoaiPhong.Text = row.Cells["LoaiP"].Value.ToString().Trim();
                }

                if (row.Cells["HangP"].Value != null)
                {
                    cboHangPhong.Text = row.Cells["HangP"].Value.ToString().Trim();
                }

                if (row.Cells["DonGia"].Value != null)
                {
                    decimal donGia;
                    if (decimal.TryParse(row.Cells["DonGia"].Value.ToString(), out donGia))
                    {
                        txtDonGia.Text = donGia.ToString("0.0000");
                    }
                    else
                    {
                        txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                    }
                }
            }
        }

        private void XoaTrangFormDeNhapMoi()
        {
            txtMaPhong.Clear();
            txtDonGia.Clear();
            txtMaPhong.ReadOnly = false;
            txtMaPhong.BackColor = Color.White;
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            if (cboHangPhong.Items.Count > 0) cboHangPhong.SelectedIndex = 0;
            txtMaPhong.Focus();
        }
        #endregion

        #region Yêu cầu b: Nút Thêm
        /// <summary>
        /// Yêu cầu b: Phải bổ sung được bản ghi vào bảng “Phong” đồng thời cập nhật thông tin vừa nhập lên lưới;
        /// không cho phép nhập trùng mã phòng, tình trạng phòng mặc định là “Không”.
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPH = txtMaPhong.Text.Trim();
            string loaiP = cboLoaiPhong.Text.Trim();
            string hangP = cboHangPhong.Text.Trim();
            string donGiaStr = txtDonGia.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(maPH))
            {
                MessageBox.Show("Vui lòng nhập Mã Phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

            if (string.IsNullOrEmpty(loaiP))
            {
                MessageBox.Show("Vui lòng chọn Loại Phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiPhong.Focus();
                return;
            }

            if (string.IsNullOrEmpty(hangP))
            {
                MessageBox.Show("Vui lòng chọn Hạng Phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangPhong.Focus();
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(donGiaStr, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số thực lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    // 2. Kiểm tra không cho phép nhập trùng mã phòng
                    string sqlKiemTra = "SELECT COUNT(*) FROM Phong WHERE MaPH = @MaPH";
                    using (SqlCommand cmdKiemTra = new SqlCommand(sqlKiemTra, conn))
                    {
                        cmdKiemTra.Parameters.AddWithValue("@MaPH", maPH);
                        int count = (int)cmdKiemTra.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show(
                                string.Format("Mã phòng '{0}' đã tồn tại trong CSDL! Không được phép nhập trùng mã phòng.", maPH),
                                "Cảnh báo trùng mã",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            txtMaPhong.Focus();
                            return;
                        }
                    }

                    // 3. Bổ sung bản ghi vào bảng Phong, tình trạng phòng mặc định là "Không"
                    string sqlInsert = @"
                        INSERT INTO Phong (MaPH, LoaiP, HangP, DonGia, TinhTrang) 
                        VALUES (@MaPH, @LoaiP, @HangP, @DonGia, N'Không')";

                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaPH", maPH);
                        cmdInsert.Parameters.AddWithValue("@LoaiP", loaiP);
                        cmdInsert.Parameters.AddWithValue("@HangP", hangP);
                        cmdInsert.Parameters.AddWithValue("@DonGia", donGia);

                        cmdInsert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật thông tin vừa nhập lên lưới
                LoadDuLieuLenLuoi();

                // Xóa trắng để tiếp tục nhập
                XoaTrangFormDeNhapMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu c: Nút Sửa
        /// <summary>
        /// Yêu cầu c: Phải sửa được thông tin của bản ghi được chọn vào bảng “Phong” đồng thời cập nhật thông tin vừa sửa lên lưới;
        /// không cho phép sửa mã phòng.
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPH = txtMaPhong.Text.Trim();
            string loaiP = cboLoaiPhong.Text.Trim();
            string hangP = cboHangPhong.Text.Trim();
            string donGiaStr = txtDonGia.Text.Trim();

            if (string.IsNullOrEmpty(maPH))
            {
                MessageBox.Show("Vui lòng chọn một phòng trên danh sách để sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(donGiaStr, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số thực lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    // Cập nhật thông tin bản ghi đã chọn (Không sửa mã phòng, chỉ sửa Loại, Hạng, Đơn giá)
                    string sqlUpdate = @"
                        UPDATE Phong 
                        SET LoaiP = @LoaiP, HangP = @HangP, DonGia = @DonGia 
                        WHERE MaPH = @MaPH";

                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoaiP", loaiP);
                        cmd.Parameters.AddWithValue("@HangP", hangP);
                        cmd.Parameters.AddWithValue("@DonGia", donGia);
                        cmd.Parameters.AddWithValue("@MaPH", maPH);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                string.Format("Cập nhật thông tin phòng '{0}' thành công!", maPH),
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                string.Format("Không tìm thấy phòng '{0}' để sửa!", maPH),
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }

                // Cập nhật lại thông tin lên lưới
                LoadDuLieuLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phòng:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu d: Nút Xóa
        /// <summary>
        /// Yêu cầu d: Phải xóa được tất cả các dòng được chọn đồng thời cập nhật thông tin vừa xóa lên lưới.
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng phòng trên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soDong = dgvPhong.SelectedRows.Count;
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa {0} phòng đang được chọn không?", soDong),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes)
            {
                return;
            }

            int daXoa = 0;
            StringBuilder loiKhoaNgoai = new StringBuilder();

            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvPhong.SelectedRows)
                    {
                        if (row.Cells["MaPH"].Value != null)
                        {
                            string maPH = row.Cells["MaPH"].Value.ToString().Trim();

                            try
                            {
                                string sqlDelete = "DELETE FROM Phong WHERE MaPH = @MaPH";
                                using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPH", maPH);
                                    cmd.ExecuteNonQuery();
                                    daXoa++;
                                }
                            }
                            catch (SqlException sqlEx)
                            {
                                // Lỗi vi phạm ràng buộc khóa ngoại (547: Foreign Key constraint)
                                if (sqlEx.Number == 547)
                                {
                                    loiKhoaNgoai.AppendLine("- Phòng " + maPH + ": Đang có dữ liệu thuê phòng trong bảng ThueP.");
                                }
                                else
                                {
                                    loiKhoaNgoai.AppendLine("- Phòng " + maPH + ": " + sqlEx.Message);
                                }
                            }
                        }
                    }
                }

                // Cập nhật lại thông tin lên lưới
                LoadDuLieuLenLuoi();
                XoaTrangFormDeNhapMoi();

                // Thông báo kết quả
                if (loiKhoaNgoai.Length > 0)
                {
                    string thongBao = string.Format("Đã xóa thành công {0} phòng.\nCác phòng sau không thể xóa do ràng buộc dữ liệu:\n{1}", daXoa, loiKhoaNgoai.ToString());
                    MessageBox.Show(thongBao, "Kết quả xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(string.Format("Đã xóa thành công {0} phòng!", daXoa), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xóa dữ liệu:\n" + ex.Message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu e: Nút Thoát & Hộp thoại xác nhận đóng Form
        /// <summary>
        private bool daXacNhanThoat = false;

        /// <summary>
        /// Yêu cầu e: Nút Thoát: Phải hiển thị được hộp thoại xác nhận có muốn thoát không và xử lý được việc đóng hoặc hủy việc đóng Form.
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
        }

        private void FormPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    e.Cancel = true; // Hủy việc đóng Form nếu chọn No
                    return;
                }
            }
        }

        private void lblMoFormKhachThue_Click(object sender, EventArgs e)
        {
            FormKhachThue frm = new FormKhachThue();
            frm.Show();
        }
        #endregion

        #region Tiện ích Hộp thoại Nhập liệu (InputBox)
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
