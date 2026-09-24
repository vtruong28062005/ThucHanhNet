using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmMuaHang : Form
    {
        #region Điều khiển Giao diện (Controls)
        private Label lblTieuDe;

        private GroupBox grpHoaDon;
        private Label lblSoHD;
        private TextBox txtSoHD;
        private Label lblNgayMua;
        private DateTimePicker dtpNgayMua;
        private Label lblNCC;
        private ComboBox cboNCC;
        private Label lblDiaChiNCC;
        private TextBox txtDiaChiNCC;

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
        private DataGridView dgvMuaHang;
        private Label lblTongTien;
        #endregion

        private bool isThem = false;
        private DataTable dtNCC;
        private DataTable dtHang;

        public frmMuaHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.grpHoaDon = new GroupBox();
            this.lblSoHD = new Label();
            this.txtSoHD = new TextBox();
            this.lblNgayMua = new Label();
            this.dtpNgayMua = new DateTimePicker();
            this.lblNCC = new Label();
            this.cboNCC = new ComboBox();
            this.lblDiaChiNCC = new Label();
            this.txtDiaChiNCC = new TextBox();

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
            this.dgvMuaHang = new DataGridView();
            this.lblTongTien = new Label();

            this.grpHoaDon.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            this.pnlChucNang.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuaHang)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.DarkSlateBlue;
            this.lblTieuDe.Location = new Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(960, 48);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ NGHIỆP VỤ MUA HÀNG (QLKD)";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpHoaDon.Controls.Add(this.lblSoHD);
            this.grpHoaDon.Controls.Add(this.txtSoHD);
            this.grpHoaDon.Controls.Add(this.lblNgayMua);
            this.grpHoaDon.Controls.Add(this.dtpNgayMua);
            this.grpHoaDon.Controls.Add(this.lblNCC);
            this.grpHoaDon.Controls.Add(this.cboNCC);
            this.grpHoaDon.Controls.Add(this.lblDiaChiNCC);
            this.grpHoaDon.Controls.Add(this.txtDiaChiNCC);
            this.grpHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpHoaDon.ForeColor = Color.Navy;
            this.grpHoaDon.Location = new Point(15, 50);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new Size(930, 95);
            this.grpHoaDon.TabIndex = 1;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "1. Thông tin Hóa đơn mua hàng (HDMUA)";

            // lblSoHD & txtSoHD
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Font = new Font("Segoe UI", 9F);
            this.lblSoHD.ForeColor = Color.Black;
            this.lblSoHD.Location = new Point(20, 30);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new Size(74, 20);
            this.lblSoHD.Text = "Số HĐ mua:";

            this.txtSoHD.Font = new Font("Segoe UI", 9F);
            this.txtSoHD.Location = new Point(110, 27);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new Size(130, 27);
            this.txtSoHD.TabIndex = 0;

            // lblNgayMua & dtpNgayMua
            this.lblNgayMua.AutoSize = true;
            this.lblNgayMua.Font = new Font("Segoe UI", 9F);
            this.lblNgayMua.ForeColor = Color.Black;
            this.lblNgayMua.Location = new Point(20, 62);
            this.lblNgayMua.Name = "lblNgayMua";
            this.lblNgayMua.Size = new Size(81, 20);
            this.lblNgayMua.Text = "Ngày mua:";

            this.dtpNgayMua.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayMua.Font = new Font("Segoe UI", 9F);
            this.dtpNgayMua.Format = DateTimePickerFormat.Custom;
            this.dtpNgayMua.Location = new Point(110, 59);
            this.dtpNgayMua.Name = "dtpNgayMua";
            this.dtpNgayMua.Size = new Size(180, 27);
            this.dtpNgayMua.TabIndex = 1;

            // lblNCC & cboNCC
            this.lblNCC.AutoSize = true;
            this.lblNCC.Font = new Font("Segoe UI", 9F);
            this.lblNCC.ForeColor = Color.Black;
            this.lblNCC.Location = new Point(320, 30);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new Size(103, 20);
            this.lblNCC.Text = "Nhà cung cấp:";

            this.cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboNCC.Font = new Font("Segoe UI", 9F);
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new Point(430, 27);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new Size(480, 28);
            this.cboNCC.TabIndex = 2;
            this.cboNCC.SelectedIndexChanged += new EventHandler(this.cboNCC_SelectedIndexChanged);

            // lblDiaChiNCC & txtDiaChiNCC
            this.lblDiaChiNCC.AutoSize = true;
            this.lblDiaChiNCC.Font = new Font("Segoe UI", 9F);
            this.lblDiaChiNCC.ForeColor = Color.Black;
            this.lblDiaChiNCC.Location = new Point(320, 62);
            this.lblDiaChiNCC.Name = "lblDiaChiNCC";
            this.lblDiaChiNCC.Size = new Size(89, 20);
            this.lblDiaChiNCC.Text = "Địa chỉ NCC:";

            this.txtDiaChiNCC.BackColor = Color.WhiteSmoke;
            this.txtDiaChiNCC.Font = new Font("Segoe UI", 9F);
            this.txtDiaChiNCC.Location = new Point(430, 59);
            this.txtDiaChiNCC.Name = "txtDiaChiNCC";
            this.txtDiaChiNCC.ReadOnly = true;
            this.txtDiaChiNCC.Size = new Size(480, 27);
            this.txtDiaChiNCC.TabIndex = 3;

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
            this.grpChiTiet.ForeColor = Color.DarkOliveGreen;
            this.grpChiTiet.Location = new Point(15, 150);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new Size(930, 100);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "2. Chi tiết mặt hàng mua (CHITIETMUA)";

            // lblHang & cboHang
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new Font("Segoe UI", 9F);
            this.lblHang.ForeColor = Color.Black;
            this.lblHang.Location = new Point(20, 28);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new Size(74, 20);
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
            this.lblDonGia.Size = new Size(100, 20);
            this.lblDonGia.Text = "Đơn giá mua:";

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
            this.grpDanhSach.Controls.Add(this.dgvMuaHang);
            this.grpDanhSach.Controls.Add(this.lblTongTien);
            this.grpDanhSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpDanhSach.Location = new Point(15, 305);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new Size(930, 310);
            this.grpDanhSach.TabIndex = 4;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách chi tiết hóa đơn mua hàng";

            // dgvMuaHang
            this.dgvMuaHang.AllowUserToAddRows = false;
            this.dgvMuaHang.AllowUserToDeleteRows = false;
            this.dgvMuaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMuaHang.BackgroundColor = Color.White;
            this.dgvMuaHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuaHang.Dock = DockStyle.Fill;
            this.dgvMuaHang.Location = new Point(3, 25);
            this.dgvMuaHang.MultiSelect = false;
            this.dgvMuaHang.Name = "dgvMuaHang";
            this.dgvMuaHang.ReadOnly = true;
            this.dgvMuaHang.RowHeadersWidth = 35;
            this.dgvMuaHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuaHang.Size = new Size(924, 252);
            this.dgvMuaHang.TabIndex = 0;
            this.dgvMuaHang.CellClick += new DataGridViewCellEventHandler(this.dgvMuaHang_CellClick);

            // lblTongTien
            this.lblTongTien.Dock = DockStyle.Bottom;
            this.lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.DarkRed;
            this.lblTongTien.Location = new Point(3, 277);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new Size(924, 30);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền hàng mua: 0 VNĐ";
            this.lblTongTien.TextAlign = ContentAlignment.MiddleRight;

            // 
            // frmMuaHang
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
            this.Name = "frmMuaHang";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Công việc 2: Quản lý Mua hàng (QLKD)";
            this.Load += new EventHandler(this.frmMuaHang_Load);

            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.pnlChucNang.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuaHang)).EndInit();
            this.ResumeLayout(false);
        }

        private void frmMuaHang_Load(object sender, EventArgs e)
        {
            string err;
            if (!DatabaseHelper.KiemTraKetNoi(out err))
            {
                DialogResult dr = MessageBox.Show(
                    "Chưa kết nối được CSDL QLKD: " + err + "\n\nBạn có muốn tự động khởi tạo CSDL QLKD và dữ liệu mẫu không?",
                    "Thông báo CSDL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string tb;
                    if (DatabaseHelper.TaoCSDLVaDuLieuMau(out tb))
                    {
                        MessageBox.Show(tb, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(tb, "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            LoadDanhMucNCC();
            LoadDanhMucHang();
            LoadDanhSachMuaHang();
            ThietLapTrangThai(false);
        }

        private void LoadDanhMucNCC()
        {
            try
            {
                dtNCC = DatabaseHelper.ExecuteDataTable("SELECT Mancc, Tenncc, DiachiNCC FROM NCC ORDER BY Tenncc");
                cboNCC.DataSource = dtNCC;
                cboNCC.DisplayMember = "Tenncc";
                cboNCC.ValueMember = "Mancc";
                if (cboNCC.Items.Count > 0)
                {
                    cboNCC.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadDanhSachMuaHang()
        {
            try
            {
                string sql = "SELECT HD.SoHD AS [Số HĐ], " +
                             "HD.Ngaymua AS [Ngày mua], " +
                             "NCC.Tenncc AS [Nhà cung cấp], " +
                             "H.Mahang AS [Mã hàng], " +
                             "H.Tenhang AS [Tên mặt hàng], " +
                             "H.DVT AS [ĐVT], " +
                             "CT.Soluongmua AS [Số lượng], " +
                             "CT.Dongiamua AS [Đơn giá], " +
                             "(CT.Soluongmua * CT.Dongiamua) AS [Thành tiền], " +
                             "NCC.Mancc " +
                             "FROM CHITIETMUA CT " +
                             "INNER JOIN HDMUA HD ON CT.SoHD = HD.SoHD " +
                             "INNER JOIN HANG H ON CT.Mahang = H.Mahang " +
                             "INNER JOIN NCC NCC ON HD.Mancc = NCC.Mancc " +
                             "ORDER BY HD.Ngaymua DESC, HD.SoHD DESC";

                DataTable dt = DatabaseHelper.ExecuteDataTable(sql);
                dgvMuaHang.DataSource = dt;

                if (dgvMuaHang.Columns["Mancc"] != null)
                {
                    dgvMuaHang.Columns["Mancc"].Visible = false;
                }

                if (dgvMuaHang.Columns["Ngày mua"] != null)
                {
                    dgvMuaHang.Columns["Ngày mua"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvMuaHang.Columns["Số lượng"] != null)
                {
                    dgvMuaHang.Columns["Số lượng"].DefaultCellStyle.Format = "#,##0";
                    dgvMuaHang.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvMuaHang.Columns["Đơn giá"] != null)
                {
                    dgvMuaHang.Columns["Đơn giá"].DefaultCellStyle.Format = "#,##0";
                    dgvMuaHang.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvMuaHang.Columns["Thành tiền"] != null)
                {
                    dgvMuaHang.Columns["Thành tiền"].DefaultCellStyle.Format = "#,##0";
                    dgvMuaHang.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tính tổng tiền
                decimal tong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        tong += Convert.ToDecimal(row["Thành tiền"]);
                    }
                }
                lblTongTien.Text = string.Format("Tổng tiền hàng mua: {0:#,##0} VNĐ", tong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách mua hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThietLapTrangThai(bool dangSuaHoacThem)
        {
            txtSoHD.Enabled = dangSuaHoacThem && isThem;
            dtpNgayMua.Enabled = dangSuaHoacThem;
            cboNCC.Enabled = dangSuaHoacThem;

            cboHang.Enabled = dangSuaHoacThem && isThem;
            txtSoLuong.Enabled = dangSuaHoacThem;
            txtDonGia.Enabled = dangSuaHoacThem;

            btnThem.Enabled = !dangSuaHoacThem;
            btnSua.Enabled = !dangSuaHoacThem && (dgvMuaHang.Rows.Count > 0);
            btnXoa.Enabled = !dangSuaHoacThem && (dgvMuaHang.Rows.Count > 0);
            btnLuu.Enabled = dangSuaHoacThem;
            btnHuy.Enabled = dangSuaHoacThem;
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNCC.SelectedValue != null && dtNCC != null)
            {
                string mancc = cboNCC.SelectedValue.ToString();
                DataRow[] rows = dtNCC.Select("Mancc = '" + mancc.Replace("'", "''") + "'");
                if (rows.Length > 0)
                {
                    txtDiaChiNCC.Text = rows[0]["DiachiNCC"].ToString();
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

        private void dgvMuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMuaHang.Rows.Count)
            {
                DataGridViewRow r = dgvMuaHang.Rows[e.RowIndex];
                txtSoHD.Text = r.Cells["Số HĐ"].Value != null ? r.Cells["Số HĐ"].Value.ToString() : "";
                if (r.Cells["Ngày mua"].Value != null && r.Cells["Ngày mua"].Value != DBNull.Value)
                {
                    dtpNgayMua.Value = Convert.ToDateTime(r.Cells["Ngày mua"].Value);
                }
                if (r.Cells["Mancc"].Value != null)
                {
                    cboNCC.SelectedValue = r.Cells["Mancc"].Value.ToString();
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

            // Gợi ý số hóa đơn mua tiếp theo
            object maxObj = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM HDMUA");
            int nextIndex = maxObj != null ? Convert.ToInt32(maxObj) + 1 : 1;
            txtSoHD.Text = string.Format("HDM{0:00}", nextIndex);
            dtpNgayMua.Value = DateTime.Now;

            txtSoLuong.Text = "1";
            txtDonGia.Text = "0";
            txtThanhTien.Text = "0";

            txtSoHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHD.Text.Trim()))
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
            string sohd = txtSoHD.Text.Trim();
            if (string.IsNullOrEmpty(sohd))
            {
                MessageBox.Show("Số hóa đơn mua không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }

            if (cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNCC.Focus();
                return;
            }
            string mancc = cboNCC.SelectedValue.ToString();

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
                MessageBox.Show("Số lượng mua phải là số nguyên dương (> 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            decimal dongia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out dongia) || dongia < 0)
            {
                MessageBox.Show("Đơn giá mua phải là số không âm (>= 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            DateTime ngaymua = dtpNgayMua.Value;

            try
            {
                if (isThem)
                {
                    // 1. Kiểm tra hóa đơn mua HDMUA đã tồn tại chưa
                    string sqlKiemTraHD = "SELECT COUNT(*) FROM HDMUA WHERE SoHD = @sohd";
                    int countHD = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKiemTraHD, new SqlParameter[] {
                        new SqlParameter("@sohd", sohd)
                    }));

                    if (countHD == 0)
                    {
                        // Chưa có thì tạo mới hóa đơn mua
                        string sqlInsertHD = "INSERT INTO HDMUA (SoHD, Ngaymua, Mancc) VALUES (@sohd, @ngay, @mancc)";
                        DatabaseHelper.ExecuteNonQuery(sqlInsertHD, new SqlParameter[] {
                            new SqlParameter("@sohd", sohd),
                            new SqlParameter("@ngay", ngaymua),
                            new SqlParameter("@mancc", mancc)
                        });
                    }

                    // 2. Kiểm tra xem mặt hàng đã có trong chi tiết hóa đơn này chưa
                    string sqlKiemTraCT = "SELECT COUNT(*) FROM CHITIETMUA WHERE SoHD = @sohd AND Mahang = @mahang";
                    int countCT = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKiemTraCT, new SqlParameter[] {
                        new SqlParameter("@sohd", sohd),
                        new SqlParameter("@mahang", mahang)
                    }));

                    if (countCT > 0)
                    {
                        MessageBox.Show(string.Format("Hóa đơn {0} đã có mặt hàng {1}. Bạn có thể bấm Sửa để cập nhật số lượng hoặc đơn giá!", sohd, mahang), "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Thêm chi tiết hóa đơn mua
                    string sqlInsertCT = "INSERT INTO CHITIETMUA (SoHD, Mahang, Soluongmua, Dongiamua) VALUES (@sohd, @mahang, @sl, @dg)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsertCT, new SqlParameter[] {
                        new SqlParameter("@sohd", sohd),
                        new SqlParameter("@mahang", mahang),
                        new SqlParameter("@sl", soluong),
                        new SqlParameter("@dg", dongia)
                    });

                    MessageBox.Show("Thêm mới chi tiết hóa đơn mua thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Sửa: Cập nhật HDMUA và CHITIETMUA
                    string sqlUpdateHD = "UPDATE HDMUA SET Ngaymua = @ngay, Mancc = @mancc WHERE SoHD = @sohd";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdateHD, new SqlParameter[] {
                        new SqlParameter("@ngay", ngaymua),
                        new SqlParameter("@mancc", mancc),
                        new SqlParameter("@sohd", sohd)
                    });

                    string sqlUpdateCT = "UPDATE CHITIETMUA SET Soluongmua = @sl, Dongiamua = @dg WHERE SoHD = @sohd AND Mahang = @mahang";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdateCT, new SqlParameter[] {
                        new SqlParameter("@sl", soluong),
                        new SqlParameter("@dg", dongia),
                        new SqlParameter("@sohd", sohd),
                        new SqlParameter("@mahang", mahang)
                    });

                    MessageBox.Show("Cập nhật thông tin mua hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachMuaHang();
                ThietLapTrangThai(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sohd = txtSoHD.Text.Trim();
            if (string.IsNullOrEmpty(sohd) || cboHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi chi tiết mua hàng cần xóa trên lưới!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mahang = cboHang.SelectedValue.ToString();

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa mặt hàng [{0}] khỏi hóa đơn mua [{1}] không?", mahang, sohd),
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sqlDeleteCT = "DELETE FROM CHITIETMUA WHERE SoHD = @sohd AND Mahang = @mahang";
                    DatabaseHelper.ExecuteNonQuery(sqlDeleteCT, new SqlParameter[] {
                        new SqlParameter("@sohd", sohd),
                        new SqlParameter("@mahang", mahang)
                    });

                    // Kiểm tra nếu hóa đơn này không còn chi tiết nào nữa thì xóa luôn hóa đơn
                    string sqlCheckRemaining = "SELECT COUNT(*) FROM CHITIETMUA WHERE SoHD = @sohd";
                    int rem = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCheckRemaining, new SqlParameter[] {
                        new SqlParameter("@sohd", sohd)
                    }));

                    if (rem == 0)
                    {
                        DatabaseHelper.ExecuteNonQuery("DELETE FROM HDMUA WHERE SoHD = @sohd", new SqlParameter[] {
                            new SqlParameter("@sohd", sohd)
                        });
                    }

                    MessageBox.Show("Đã xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachMuaHang();
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
            if (dgvMuaHang.CurrentRow != null)
            {
                dgvMuaHang_CellClick(dgvMuaHang, new DataGridViewCellEventArgs(0, dgvMuaHang.CurrentRow.Index));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đóng form Quản lý Mua hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
