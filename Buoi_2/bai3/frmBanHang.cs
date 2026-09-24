using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmBanHang : Form
    {
        #region Điều khiển Giao diện (Controls)
        private Label lblTieuDe;

        private GroupBox grpHoaDon;
        private Label lblSoHDB;
        private TextBox txtSoHDB;
        private Label lblNgayBan;
        private DateTimePicker dtpNgayBan;
        private Label lblKhach;
        private ComboBox cboKhach;
        private Label lblDiaChiKH;
        private TextBox txtDiaChiKH;

        private GroupBox grpChiTiet;
        private Label lblHang;
        private ComboBox cboHang;
        private Label lblDVT;
        private TextBox txtDVT;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblThanhTien;
        private TextBox txtThanhTien;

        private Panel pnlChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnHuy;
        private Button btnThoat;

        private GroupBox grpDanhSach;
        private DataGridView dgvBanHang;
        private Label lblTongTien;
        #endregion

        private bool isThem = false;
        private DataTable dtKhach;
        private DataTable dtHang;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.grpHoaDon = new GroupBox();
            this.lblSoHDB = new Label();
            this.txtSoHDB = new TextBox();
            this.lblNgayBan = new Label();
            this.dtpNgayBan = new DateTimePicker();
            this.lblKhach = new Label();
            this.cboKhach = new ComboBox();
            this.lblDiaChiKH = new Label();
            this.txtDiaChiKH = new TextBox();

            this.grpChiTiet = new GroupBox();
            this.lblHang = new Label();
            this.cboHang = new ComboBox();
            this.lblDVT = new Label();
            this.txtDVT = new TextBox();
            this.lblSoLuong = new Label();
            this.txtSoLuong = new TextBox();
            this.lblDonGia = new Label();
            this.txtDonGia = new TextBox();
            this.lblThanhTien = new Label();
            this.txtThanhTien = new TextBox();

            this.pnlChucNang = new Panel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnLuu = new Button();
            this.btnXoa = new Button();
            this.btnHuy = new Button();
            this.btnThoat = new Button();

            this.grpDanhSach = new GroupBox();
            this.dgvBanHang = new DataGridView();
            this.lblTongTien = new Label();

            this.grpHoaDon.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            this.pnlChucNang.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanHang)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.Firebrick;
            this.lblTieuDe.Location = new Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(960, 48);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ NGHIỆP VỤ BÁN HÀNG (HDBAN - CHITIETBAN)";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpHoaDon.Controls.Add(this.lblSoHDB);
            this.grpHoaDon.Controls.Add(this.txtSoHDB);
            this.grpHoaDon.Controls.Add(this.lblNgayBan);
            this.grpHoaDon.Controls.Add(this.dtpNgayBan);
            this.grpHoaDon.Controls.Add(this.lblKhach);
            this.grpHoaDon.Controls.Add(this.cboKhach);
            this.grpHoaDon.Controls.Add(this.lblDiaChiKH);
            this.grpHoaDon.Controls.Add(this.txtDiaChiKH);
            this.grpHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpHoaDon.ForeColor = Color.DarkRed;
            this.grpHoaDon.Location = new Point(15, 50);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new Size(930, 95);
            this.grpHoaDon.TabIndex = 1;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "1. Thông tin Hóa đơn bán (HDBAN)";

            // lblSoHDB & txtSoHDB
            this.lblSoHDB.AutoSize = true;
            this.lblSoHDB.Font = new Font("Segoe UI", 9F);
            this.lblSoHDB.ForeColor = Color.Black;
            this.lblSoHDB.Location = new Point(20, 30);
            this.lblSoHDB.Name = "lblSoHDB";
            this.lblSoHDB.Size = new Size(82, 20);
            this.lblSoHDB.TabIndex = 0;
            this.lblSoHDB.Text = "Số HĐ bán:";

            this.txtSoHDB.Font = new Font("Segoe UI", 9F);
            this.txtSoHDB.Location = new Point(110, 27);
            this.txtSoHDB.Name = "txtSoHDB";
            this.txtSoHDB.Size = new Size(130, 27);
            this.txtSoHDB.TabIndex = 0;

            // lblNgayBan & dtpNgayBan
            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.Font = new Font("Segoe UI", 9F);
            this.lblNgayBan.ForeColor = Color.Black;
            this.lblNgayBan.Location = new Point(20, 62);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new Size(76, 20);
            this.lblNgayBan.TabIndex = 1;
            this.lblNgayBan.Text = "Ngày bán:";

            this.dtpNgayBan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayBan.Font = new Font("Segoe UI", 9F);
            this.dtpNgayBan.Format = DateTimePickerFormat.Custom;
            this.dtpNgayBan.Location = new Point(110, 59);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new Size(180, 27);
            this.dtpNgayBan.TabIndex = 1;

            // lblKhach & cboKhach
            this.lblKhach.AutoSize = true;
            this.lblKhach.Font = new Font("Segoe UI", 9F);
            this.lblKhach.ForeColor = Color.Black;
            this.lblKhach.Location = new Point(320, 30);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new Size(89, 20);
            this.lblKhach.TabIndex = 2;
            this.lblKhach.Text = "Khách hàng:";

            this.cboKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKhach.Font = new Font("Segoe UI", 9F);
            this.cboKhach.FormattingEnabled = true;
            this.cboKhach.Location = new Point(430, 27);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new Size(480, 28);
            this.cboKhach.TabIndex = 2;
            this.cboKhach.SelectedIndexChanged += new EventHandler(this.cboKhach_SelectedIndexChanged);

            // lblDiaChiKH & txtDiaChiKH
            this.lblDiaChiKH.AutoSize = true;
            this.lblDiaChiKH.Font = new Font("Segoe UI", 9F);
            this.lblDiaChiKH.ForeColor = Color.Black;
            this.lblDiaChiKH.Location = new Point(320, 62);
            this.lblDiaChiKH.Name = "lblDiaChiKH";
            this.lblDiaChiKH.Size = new Size(82, 20);
            this.lblDiaChiKH.TabIndex = 3;
            this.lblDiaChiKH.Text = "Địa chỉ KH:";

            this.txtDiaChiKH.BackColor = Color.WhiteSmoke;
            this.txtDiaChiKH.Font = new Font("Segoe UI", 9F);
            this.txtDiaChiKH.Location = new Point(430, 59);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.ReadOnly = true;
            this.txtDiaChiKH.Size = new Size(480, 27);
            this.txtDiaChiKH.TabIndex = 3;

            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpChiTiet.Controls.Add(this.lblHang);
            this.grpChiTiet.Controls.Add(this.cboHang);
            this.grpChiTiet.Controls.Add(this.lblDVT);
            this.grpChiTiet.Controls.Add(this.txtDVT);
            this.grpChiTiet.Controls.Add(this.lblSoLuong);
            this.grpChiTiet.Controls.Add(this.txtSoLuong);
            this.grpChiTiet.Controls.Add(this.lblDonGia);
            this.grpChiTiet.Controls.Add(this.txtDonGia);
            this.grpChiTiet.Controls.Add(this.lblThanhTien);
            this.grpChiTiet.Controls.Add(this.txtThanhTien);
            this.grpChiTiet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpChiTiet.ForeColor = Color.DarkGoldenrod;
            this.grpChiTiet.Location = new Point(15, 150);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new Size(930, 100);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "2. Chi tiết mặt hàng bán (CHITIETBAN)";

            // lblHang & cboHang
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new Font("Segoe UI", 9F);
            this.lblHang.ForeColor = Color.Black;
            this.lblHang.Location = new Point(20, 28);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new Size(74, 20);
            this.lblHang.TabIndex = 0;
            this.lblHang.Text = "Mặt hàng:";

            this.cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboHang.Font = new Font("Segoe UI", 9F);
            this.cboHang.FormattingEnabled = true;
            this.cboHang.Location = new Point(110, 25);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new Size(330, 28);
            this.cboHang.TabIndex = 0;
            this.cboHang.SelectedIndexChanged += new EventHandler(this.cboHang_SelectedIndexChanged);

            // lblDVT & txtDVT
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new Font("Segoe UI", 9F);
            this.lblDVT.ForeColor = Color.Black;
            this.lblDVT.Location = new Point(460, 28);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new Size(84, 20);
            this.lblDVT.Text = "Đơn vị tính:";

            this.txtDVT.BackColor = Color.WhiteSmoke;
            this.txtDVT.Font = new Font("Segoe UI", 9F);
            this.txtDVT.Location = new Point(550, 25);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new Size(110, 27);
            this.txtDVT.TabIndex = 1;

            // lblSoLuong & txtSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new Font("Segoe UI", 9F);
            this.lblSoLuong.ForeColor = Color.Black;
            this.lblSoLuong.Location = new Point(20, 63);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new Size(72, 20);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng:";

            this.txtSoLuong.Font = new Font("Segoe UI", 9F);
            this.txtSoLuong.Location = new Point(110, 60);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new Size(110, 27);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.TextChanged += new EventHandler(this.TinhThanhTien);

            // lblDonGia & txtDonGia
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new Font("Segoe UI", 9F);
            this.lblDonGia.ForeColor = Color.Black;
            this.lblDonGia.Location = new Point(240, 63);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new Size(97, 20);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "Đơn giá bán:";

            this.txtDonGia.Font = new Font("Segoe UI", 9F);
            this.txtDonGia.Location = new Point(345, 60);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new Size(160, 27);
            this.txtDonGia.TabIndex = 3;
            this.txtDonGia.TextChanged += new EventHandler(this.TinhThanhTien);

            // lblThanhTien & txtThanhTien
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new Font("Segoe UI", 9F);
            this.lblThanhTien.ForeColor = Color.Black;
            this.lblThanhTien.Location = new Point(530, 63);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new Size(81, 20);
            this.lblThanhTien.TabIndex = 4;
            this.lblThanhTien.Text = "Thành tiền:";

            this.txtThanhTien.BackColor = Color.LightYellow;
            this.txtThanhTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.txtThanhTien.ForeColor = Color.DarkRed;
            this.txtThanhTien.Location = new Point(620, 60);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new Size(190, 27);
            this.txtThanhTien.TabIndex = 4;

            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.pnlChucNang.Controls.Add(this.btnThem);
            this.pnlChucNang.Controls.Add(this.btnSua);
            this.pnlChucNang.Controls.Add(this.btnLuu);
            this.pnlChucNang.Controls.Add(this.btnXoa);
            this.pnlChucNang.Controls.Add(this.btnHuy);
            this.pnlChucNang.Controls.Add(this.btnThoat);
            this.pnlChucNang.Location = new Point(15, 255);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new Size(930, 45);
            this.pnlChucNang.TabIndex = 3;

            // btnThem
            this.btnThem.BackColor = Color.SteelBlue;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(10, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(120, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.BackColor = Color.Goldenrod;
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnSua.ForeColor = Color.White;
            this.btnSua.Location = new Point(145, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(120, 35);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new EventHandler(this.btnSua_Click);

            // btnLuu
            this.btnLuu.BackColor = Color.ForestGreen;
            this.btnLuu.Enabled = false;
            this.btnLuu.FlatStyle = FlatStyle.Flat;
            this.btnLuu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnLuu.ForeColor = Color.White;
            this.btnLuu.Location = new Point(280, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new Size(120, 35);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new EventHandler(this.btnLuu_Click);

            // btnXoa
            this.btnXoa.BackColor = Color.IndianRed;
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Location = new Point(415, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(120, 35);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "❌ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            // btnHuy
            this.btnHuy.BackColor = Color.Gray;
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.Location = new Point(550, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(120, 35);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "🔄 Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // btnThoat
            this.btnThoat.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnThoat.BackColor = Color.FromArgb(70, 70, 70);
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Location = new Point(800, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new Size(120, 35);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "🚪 Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.dgvBanHang);
            this.grpDanhSach.Controls.Add(this.lblTongTien);
            this.grpDanhSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpDanhSach.Location = new Point(15, 305);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new Size(930, 310);
            this.grpDanhSach.TabIndex = 4;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách chi tiết hóa đơn bán hàng";

            // dgvBanHang
            this.dgvBanHang.AllowUserToAddRows = false;
            this.dgvBanHang.AllowUserToDeleteRows = false;
            this.dgvBanHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanHang.BackgroundColor = Color.White;
            this.dgvBanHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanHang.Dock = DockStyle.Fill;
            this.dgvBanHang.Location = new Point(3, 25);
            this.dgvBanHang.MultiSelect = false;
            this.dgvBanHang.Name = "dgvBanHang";
            this.dgvBanHang.ReadOnly = true;
            this.dgvBanHang.RowHeadersWidth = 35;
            this.dgvBanHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanHang.Size = new Size(924, 252);
            this.dgvBanHang.TabIndex = 0;
            this.dgvBanHang.CellClick += new DataGridViewCellEventHandler(this.dgvBanHang_CellClick);

            // lblTongTien
            this.lblTongTien.Dock = DockStyle.Bottom;
            this.lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.DarkRed;
            this.lblTongTien.Location = new Point(3, 277);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new Size(924, 30);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền hàng bán: 0 VNĐ";
            this.lblTongTien.TextAlign = ContentAlignment.MiddleRight;

            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(960, 625);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlChucNang);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(900, 600);
            this.Name = "frmBanHang";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Bán hàng (QLKD)";
            this.Load += new EventHandler(this.frmBanHang_Load);

            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.pnlChucNang.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanHang)).EndInit();
            this.ResumeLayout(false);
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadDanhMucKhach();
            LoadDanhMucHang();
            LoadDanhSachBanHang();
            ThietLapTrangThai(false);
        }

        private void LoadDanhMucKhach()
        {
            try
            {
                dtKhach = DatabaseHelper.ExecuteDataTable("SELECT Makh, Tenkh, Diachikh FROM KHACH ORDER BY Tenkh");
                cboKhach.DataSource = dtKhach;
                cboKhach.DisplayMember = "Tenkh";
                cboKhach.ValueMember = "Makh";
                if (cboKhach.Items.Count > 0)
                {
                    cboKhach.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhMucHang()
        {
            try
            {
                dtHang = DatabaseHelper.ExecuteDataTable("SELECT Mahang, Tenhang, DVT FROM HANG ORDER BY Tenhang");
                cboHang.DataSource = dtHang;
                cboHang.DisplayMember = "Tenhang";
                cboHang.ValueMember = "Mahang";
                if (cboHang.Items.Count > 0)
                {
                    cboHang.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Hàng hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachBanHang()
        {
            try
            {
                string sql = "SELECT HD.SoHDB AS [Số HĐB], " +
                             "HD.Ngayban AS [Ngày bán], " +
                             "K.Tenkh AS [Khách hàng], " +
                             "H.Mahang AS [Mã hàng], " +
                             "H.Tenhang AS [Tên mặt hàng], " +
                             "H.DVT AS [ĐVT], " +
                             "CT.Soluongban AS [Số lượng], " +
                             "CT.Dongiaban AS [Đơn giá], " +
                             "(CT.Soluongban * CT.Dongiaban) AS [Thành tiền], " +
                             "K.Makh " +
                             "FROM CHITIETBAN CT " +
                             "INNER JOIN HDBAN HD ON CT.SoHDB = HD.SoHDB " +
                             "INNER JOIN HANG H ON CT.Mahang = H.Mahang " +
                             "INNER JOIN KHACH K ON HD.Makh = K.Makh " +
                             "ORDER BY HD.Ngayban DESC, HD.SoHDB DESC";

                DataTable dt = DatabaseHelper.ExecuteDataTable(sql);
                dgvBanHang.DataSource = dt;

                if (dgvBanHang.Columns["Makh"] != null)
                {
                    dgvBanHang.Columns["Makh"].Visible = false;
                }

                if (dgvBanHang.Columns["Ngày bán"] != null)
                {
                    dgvBanHang.Columns["Ngày bán"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvBanHang.Columns["Số lượng"] != null)
                {
                    dgvBanHang.Columns["Số lượng"].DefaultCellStyle.Format = "#,##0";
                    dgvBanHang.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvBanHang.Columns["Đơn giá"] != null)
                {
                    dgvBanHang.Columns["Đơn giá"].DefaultCellStyle.Format = "#,##0";
                    dgvBanHang.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvBanHang.Columns["Thành tiền"] != null)
                {
                    dgvBanHang.Columns["Thành tiền"].DefaultCellStyle.Format = "#,##0";
                    dgvBanHang.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                decimal tong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        tong += Convert.ToDecimal(row["Thành tiền"]);
                    }
                }
                lblTongTien.Text = string.Format("Tổng tiền hàng bán: {0:#,##0} VNĐ", tong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách bán hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThietLapTrangThai(bool dangSuaHoacThem)
        {
            txtSoHDB.Enabled = dangSuaHoacThem && isThem;
            dtpNgayBan.Enabled = dangSuaHoacThem;
            cboKhach.Enabled = dangSuaHoacThem;

            cboHang.Enabled = dangSuaHoacThem && isThem;
            txtSoLuong.Enabled = dangSuaHoacThem;
            txtDonGia.Enabled = dangSuaHoacThem;

            btnThem.Enabled = !dangSuaHoacThem;
            btnSua.Enabled = !dangSuaHoacThem && (dgvBanHang.Rows.Count > 0);
            btnXoa.Enabled = !dangSuaHoacThem && (dgvBanHang.Rows.Count > 0);
            btnLuu.Enabled = dangSuaHoacThem;
            btnHuy.Enabled = dangSuaHoacThem;
        }

        private void cboKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhach.SelectedValue != null && dtKhach != null)
            {
                string makh = cboKhach.SelectedValue.ToString();
                DataRow[] rows = dtKhach.Select("Makh = '" + makh.Replace("'", "''") + "'");
                if (rows.Length > 0)
                {
                    txtDiaChiKH.Text = rows[0]["Diachikh"].ToString();
                }
            }
        }

        private void cboHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHang.SelectedValue != null && dtHang != null)
            {
                string mahang = cboHang.SelectedValue.ToString();
                DataRow[] rows = dtHang.Select("Mahang = '" + mahang.Replace("'", "''") + "'");
                if (rows.Length > 0)
                {
                    txtDVT.Text = rows[0]["DVT"].ToString();
                }
            }
        }

        private void TinhThanhTien(object sender, EventArgs e)
        {
            int sl;
            decimal dg;
            if (int.TryParse(txtSoLuong.Text.Trim(), out sl) && decimal.TryParse(txtDonGia.Text.Trim(), out dg))
            {
                decimal tt = sl * dg;
                txtThanhTien.Text = string.Format("{0:#,##0}", tt);
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void dgvBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBanHang.Rows.Count)
            {
                DataGridViewRow r = dgvBanHang.Rows[e.RowIndex];
                txtSoHDB.Text = r.Cells["Số HĐB"].Value != null ? r.Cells["Số HĐB"].Value.ToString() : "";
                if (r.Cells["Ngày bán"].Value != null && r.Cells["Ngày bán"].Value != DBNull.Value)
                {
                    dtpNgayBan.Value = Convert.ToDateTime(r.Cells["Ngày bán"].Value);
                }
                if (r.Cells["Makh"].Value != null)
                {
                    cboKhach.SelectedValue = r.Cells["Makh"].Value.ToString();
                }
                if (r.Cells["Mã hàng"].Value != null)
                {
                    cboHang.SelectedValue = r.Cells["Mã hàng"].Value.ToString();
                }
                txtDVT.Text = r.Cells["ĐVT"].Value != null ? r.Cells["ĐVT"].Value.ToString() : "";
                txtSoLuong.Text = r.Cells["Số lượng"].Value != null ? r.Cells["Số lượng"].Value.ToString() : "";
                txtDonGia.Text = r.Cells["Đơn giá"].Value != null ? Convert.ToDecimal(r.Cells["Đơn giá"].Value).ToString("0.##") : "";
                txtThanhTien.Text = r.Cells["Thành tiền"].Value != null ? Convert.ToDecimal(r.Cells["Thành tiền"].Value).ToString("#,##0") : "";

                ThietLapTrangThai(false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            ThietLapTrangThai(true);

            object maxObj = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM HDBAN");
            int nextIndex = maxObj != null ? Convert.ToInt32(maxObj) + 1 : 1;
            txtSoHDB.Text = string.Format("HDB{0:00}", nextIndex);
            dtpNgayBan.Value = DateTime.Now;

            txtSoLuong.Text = "1";
            txtDonGia.Text = "0";
            txtThanhTien.Text = "0";

            txtSoHDB.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHDB.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần sửa trên lưới!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isThem = false;
            ThietLapTrangThai(true);
            txtSoLuong.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sohdb = txtSoHDB.Text.Trim();
            if (string.IsNullOrEmpty(sohdb))
            {
                MessageBox.Show("Số hóa đơn bán không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHDB.Focus();
                return;
            }

            if (cboKhach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhach.Focus();
                return;
            }
            string makh = cboKhach.SelectedValue.ToString();

            if (cboHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHang.Focus();
                return;
            }
            string mahang = cboHang.SelectedValue.ToString();

            int soluong;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soluong) || soluong <= 0)
            {
                MessageBox.Show("Số lượng bán phải là số nguyên dương (> 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            decimal dongia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out dongia) || dongia < 0)
            {
                MessageBox.Show("Đơn giá bán phải là số không âm (>= 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            DateTime ngayban = dtpNgayBan.Value;

            try
            {
                if (isThem)
                {
                    string sqlKiemTraHD = "SELECT COUNT(*) FROM HDBAN WHERE SoHDB = @sohdb";
                    int countHD = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKiemTraHD, new SqlParameter[] {
                        new SqlParameter("@sohdb", sohdb)
                    }));

                    if (countHD == 0)
                    {
                        string sqlInsertHD = "INSERT INTO HDBAN (SoHDB, Ngayban, Makh) VALUES (@sohdb, @ngay, @makh)";
                        DatabaseHelper.ExecuteNonQuery(sqlInsertHD, new SqlParameter[] {
                            new SqlParameter("@sohdb", sohdb),
                            new SqlParameter("@ngay", ngayban),
                            new SqlParameter("@makh", makh)
                        });
                    }

                    string sqlKiemTraCT = "SELECT COUNT(*) FROM CHITIETBAN WHERE SoHDB = @sohdb AND Mahang = @mahang";
                    int countCT = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKiemTraCT, new SqlParameter[] {
                        new SqlParameter("@sohdb", sohdb),
                        new SqlParameter("@mahang", mahang)
                    }));

                    if (countCT > 0)
                    {
                        MessageBox.Show(string.Format("Hóa đơn {0} đã có mặt hàng {1}. Bạn có thể bấm Sửa để cập nhật số lượng hoặc đơn giá!", sohdb, mahang), "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sqlInsertCT = "INSERT INTO CHITIETBAN (SoHDB, Mahang, Soluongban, Dongiaban) VALUES (@sohdb, @mahang, @sl, @dg)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsertCT, new SqlParameter[] {
                        new SqlParameter("@sohdb", sohdb),
                        new SqlParameter("@mahang", mahang),
                        new SqlParameter("@sl", soluong),
                        new SqlParameter("@dg", dongia)
                    });

                    MessageBox.Show("Thêm mới chi tiết hóa đơn bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sqlUpdateHD = "UPDATE HDBAN SET Ngayban = @ngay, Makh = @makh WHERE SoHDB = @sohdb";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdateHD, new SqlParameter[] {
                        new SqlParameter("@ngay", ngayban),
                        new SqlParameter("@makh", makh),
                        new SqlParameter("@sohdb", sohdb)
                    });

                    string sqlUpdateCT = "UPDATE CHITIETBAN SET Soluongban = @sl, Dongiaban = @dg WHERE SoHDB = @sohdb AND Mahang = @mahang";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdateCT, new SqlParameter[] {
                        new SqlParameter("@sl", soluong),
                        new SqlParameter("@dg", dongia),
                        new SqlParameter("@sohdb", sohdb),
                        new SqlParameter("@mahang", mahang)
                    });

                    MessageBox.Show("Cập nhật thông tin bán hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachBanHang();
                ThietLapTrangThai(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sohdb = txtSoHDB.Text.Trim();
            if (string.IsNullOrEmpty(sohdb) || cboHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi chi tiết bán hàng cần xóa trên lưới!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mahang = cboHang.SelectedValue.ToString();

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa mặt hàng [{0}] khỏi hóa đơn bán [{1}] không?", mahang, sohdb),
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sqlDeleteCT = "DELETE FROM CHITIETBAN WHERE SoHDB = @sohdb AND Mahang = @mahang";
                    DatabaseHelper.ExecuteNonQuery(sqlDeleteCT, new SqlParameter[] {
                        new SqlParameter("@sohdb", sohdb),
                        new SqlParameter("@mahang", mahang)
                    });

                    string sqlCheckRemaining = "SELECT COUNT(*) FROM CHITIETBAN WHERE SoHDB = @sohdb";
                    int rem = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCheckRemaining, new SqlParameter[] {
                        new SqlParameter("@sohdb", sohdb)
                    }));

                    if (rem == 0)
                    {
                        DatabaseHelper.ExecuteNonQuery("DELETE FROM HDBAN WHERE SoHDB = @sohdb", new SqlParameter[] {
                            new SqlParameter("@sohdb", sohdb)
                        });
                    }

                    MessageBox.Show("Đã xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachBanHang();
                    ThietLapTrangThai(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThietLapTrangThai(false);
            if (dgvBanHang.CurrentRow != null)
            {
                dgvBanHang_CellClick(dgvBanHang, new DataGridViewCellEventArgs(0, dgvBanHang.CurrentRow.Index));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đóng form Quản lý Bán hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
