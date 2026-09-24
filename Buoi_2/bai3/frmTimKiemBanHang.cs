using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmTimKiemBanHang : Form
    {
        #region Điều khiển Giao diện (Controls)
        private Label lblTieuDe;

        private GroupBox grpTimKiem;
        private Label lblChonSoHDB;
        private ComboBox cboSoHDB;
        private Button btnTimKiem;
        private Button btnXemTatCa;
        private Button btnThoat;

        private GroupBox grpThongTinChung;
        private Label lblSoHDB;
        private TextBox txtSoHDB;
        private Label lblNgayBan;
        private TextBox txtNgayBan;
        private Label lblTenKH;
        private TextBox txtTenKH;
        private Label lblDiaChiKH;
        private TextBox txtDiaChiKH;

        private GroupBox grpChiTiet;
        private DataGridView dgvChiTiet;
        private Panel pnlTongTien;
        private Label lblTongMatHang;
        private Label lblTongTienHD;
        #endregion

        public frmTimKiemBanHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.grpTimKiem = new GroupBox();
            this.lblChonSoHDB = new Label();
            this.cboSoHDB = new ComboBox();
            this.btnTimKiem = new Button();
            this.btnXemTatCa = new Button();
            this.btnThoat = new Button();

            this.grpThongTinChung = new GroupBox();
            this.lblSoHDB = new Label();
            this.txtSoHDB = new TextBox();
            this.lblNgayBan = new Label();
            this.txtNgayBan = new TextBox();
            this.lblTenKH = new Label();
            this.txtTenKH = new TextBox();
            this.lblDiaChiKH = new Label();
            this.txtDiaChiKH = new TextBox();

            this.grpChiTiet = new GroupBox();
            this.dgvChiTiet = new DataGridView();
            this.pnlTongTien = new Panel();
            this.lblTongMatHang = new Label();
            this.lblTongTienHD = new Label();

            this.grpTimKiem.SuspendLayout();
            this.grpThongTinChung.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlTongTien.SuspendLayout();
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
            this.lblTieuDe.Text = "TÌM KIẾM HÀNG BÁN THEO SỐ HÓA ĐƠN BÁN (QLKD)";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.lblChonSoHDB);
            this.grpTimKiem.Controls.Add(this.cboSoHDB);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnXemTatCa);
            this.grpTimKiem.Controls.Add(this.btnThoat);
            this.grpTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpTimKiem.ForeColor = Color.Navy;
            this.grpTimKiem.Location = new Point(15, 50);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new Size(930, 75);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Nhập / chọn Số Hóa Đơn Bán Hàng cần tra cứu";

            // lblChonSoHDB
            this.lblChonSoHDB.AutoSize = true;
            this.lblChonSoHDB.Font = new Font("Segoe UI", 9.5F);
            this.lblChonSoHDB.ForeColor = Color.Black;
            this.lblChonSoHDB.Location = new Point(20, 31);
            this.lblChonSoHDB.Name = "lblChonSoHDB";
            this.lblChonSoHDB.Size = new Size(157, 21);
            this.lblChonSoHDB.TabIndex = 0;
            this.lblChonSoHDB.Text = "Số HĐ bán (SoHDB):";

            // cboSoHDB
            this.cboSoHDB.Font = new Font("Segoe UI", 9.5F);
            this.cboSoHDB.FormattingEnabled = true;
            this.cboSoHDB.Location = new Point(185, 28);
            this.cboSoHDB.Name = "cboSoHDB";
            this.cboSoHDB.Size = new Size(260, 29);
            this.cboSoHDB.TabIndex = 1;
            this.cboSoHDB.KeyDown += new KeyEventHandler(this.cboSoHDB_KeyDown);

            // btnTimKiem
            this.btnTimKiem.BackColor = Color.SteelBlue;
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnTimKiem.ForeColor = Color.White;
            this.btnTimKiem.Location = new Point(470, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new Size(130, 34);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new EventHandler(this.btnTimKiem_Click);

            // btnXemTatCa
            this.btnXemTatCa.BackColor = Color.SeaGreen;
            this.btnXemTatCa.FlatStyle = FlatStyle.Flat;
            this.btnXemTatCa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnXemTatCa.ForeColor = Color.White;
            this.btnXemTatCa.Location = new Point(615, 25);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new Size(150, 34);
            this.btnXemTatCa.TabIndex = 3;
            this.btnXemTatCa.Text = "📋 Xem tất cả HĐ";
            this.btnXemTatCa.UseVisualStyleBackColor = false;
            this.btnXemTatCa.Click += new EventHandler(this.btnXemTatCa_Click);

            // btnThoat
            this.btnThoat.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnThoat.BackColor = Color.FromArgb(70, 70, 70);
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Location = new Point(810, 25);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new Size(105, 34);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "🚪 Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // 
            // grpThongTinChung
            // 
            this.grpThongTinChung.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpThongTinChung.Controls.Add(this.lblSoHDB);
            this.grpThongTinChung.Controls.Add(this.txtSoHDB);
            this.grpThongTinChung.Controls.Add(this.lblNgayBan);
            this.grpThongTinChung.Controls.Add(this.txtNgayBan);
            this.grpThongTinChung.Controls.Add(this.lblTenKH);
            this.grpThongTinChung.Controls.Add(this.txtTenKH);
            this.grpThongTinChung.Controls.Add(this.lblDiaChiKH);
            this.grpThongTinChung.Controls.Add(this.txtDiaChiKH);
            this.grpThongTinChung.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpThongTinChung.ForeColor = Color.DarkSlateGray;
            this.grpThongTinChung.Location = new Point(15, 130);
            this.grpThongTinChung.Name = "grpThongTinChung";
            this.grpThongTinChung.Size = new Size(930, 95);
            this.grpThongTinChung.TabIndex = 2;
            this.grpThongTinChung.TabStop = false;
            this.grpThongTinChung.Text = "Thông tin hóa đơn tìm thấy";

            // lblSoHDB & txtSoHDB
            this.lblSoHDB.AutoSize = true;
            this.lblSoHDB.Font = new Font("Segoe UI", 9F);
            this.lblSoHDB.ForeColor = Color.Black;
            this.lblSoHDB.Location = new Point(20, 30);
            this.lblSoHDB.Name = "lblSoHDB";
            this.lblSoHDB.Size = new Size(82, 20);
            this.lblSoHDB.TabIndex = 0;
            this.lblSoHDB.Text = "Số HĐ bán:";

            this.txtSoHDB.BackColor = Color.WhiteSmoke;
            this.txtSoHDB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.txtSoHDB.ForeColor = Color.DarkBlue;
            this.txtSoHDB.Location = new Point(110, 27);
            this.txtSoHDB.Name = "txtSoHDB";
            this.txtSoHDB.ReadOnly = true;
            this.txtSoHDB.Size = new Size(130, 27);
            this.txtSoHDB.TabIndex = 1;

            // lblNgayBan & txtNgayBan
            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.Font = new Font("Segoe UI", 9F);
            this.lblNgayBan.ForeColor = Color.Black;
            this.lblNgayBan.Location = new Point(20, 62);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new Size(76, 20);
            this.lblNgayBan.TabIndex = 2;
            this.lblNgayBan.Text = "Ngày bán:";

            this.txtNgayBan.BackColor = Color.WhiteSmoke;
            this.txtNgayBan.Font = new Font("Segoe UI", 9F);
            this.txtNgayBan.Location = new Point(110, 59);
            this.txtNgayBan.Name = "txtNgayBan";
            this.txtNgayBan.ReadOnly = true;
            this.txtNgayBan.Size = new Size(160, 27);
            this.txtNgayBan.TabIndex = 3;

            // lblTenKH & txtTenKH
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new Font("Segoe UI", 9F);
            this.lblTenKH.ForeColor = Color.Black;
            this.lblTenKH.Location = new Point(290, 30);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new Size(114, 20);
            this.lblTenKH.TabIndex = 4;
            this.lblTenKH.Text = "Tên khách hàng:";

            this.txtTenKH.BackColor = Color.WhiteSmoke;
            this.txtTenKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.txtTenKH.Location = new Point(410, 27);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new Size(505, 27);
            this.txtTenKH.TabIndex = 5;

            // lblDiaChiKH & txtDiaChiKH
            this.lblDiaChiKH.AutoSize = true;
            this.lblDiaChiKH.Font = new Font("Segoe UI", 9F);
            this.lblDiaChiKH.ForeColor = Color.Black;
            this.lblDiaChiKH.Location = new Point(290, 62);
            this.lblDiaChiKH.Name = "lblDiaChiKH";
            this.lblDiaChiKH.Size = new Size(82, 20);
            this.lblDiaChiKH.TabIndex = 6;
            this.lblDiaChiKH.Text = "Địa chỉ KH:";

            this.txtDiaChiKH.BackColor = Color.WhiteSmoke;
            this.txtDiaChiKH.Font = new Font("Segoe UI", 9F);
            this.txtDiaChiKH.Location = new Point(410, 59);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.ReadOnly = true;
            this.txtDiaChiKH.Size = new Size(505, 27);
            this.txtDiaChiKH.TabIndex = 7;

            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Controls.Add(this.pnlTongTien);
            this.grpChiTiet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpChiTiet.ForeColor = Color.Navy;
            this.grpChiTiet.Location = new Point(15, 230);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new Size(930, 360);
            this.grpChiTiet.TabIndex = 3;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Danh sách các mặt hàng đã bán theo hóa đơn (CHITIETBAN)";

            // dgvChiTiet
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = DockStyle.Fill;
            this.dgvChiTiet.Location = new Point(3, 25);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 35;
            this.dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new Size(924, 292);
            this.dgvChiTiet.TabIndex = 0;

            // pnlTongTien
            this.pnlTongTien.BackColor = Color.FromArgb(235, 245, 235);
            this.pnlTongTien.Controls.Add(this.lblTongMatHang);
            this.pnlTongTien.Controls.Add(this.lblTongTienHD);
            this.pnlTongTien.Dock = DockStyle.Bottom;
            this.pnlTongTien.Location = new Point(3, 317);
            this.pnlTongTien.Name = "pnlTongTien";
            this.pnlTongTien.Size = new Size(924, 40);
            this.pnlTongTien.TabIndex = 1;

            // lblTongMatHang
            this.lblTongMatHang.AutoSize = true;
            this.lblTongMatHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblTongMatHang.ForeColor = Color.DarkSlateGray;
            this.lblTongMatHang.Location = new Point(15, 10);
            this.lblTongMatHang.Name = "lblTongMatHang";
            this.lblTongMatHang.Size = new Size(180, 21);
            this.lblTongMatHang.TabIndex = 0;
            this.lblTongMatHang.Text = "Số mặt hàng: 0 sản phẩm";

            // lblTongTienHD
            this.lblTongTienHD.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblTongTienHD.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTongTienHD.ForeColor = Color.DarkRed;
            this.lblTongTienHD.Location = new Point(420, 7);
            this.lblTongTienHD.Name = "lblTongTienHD";
            this.lblTongTienHD.Size = new Size(490, 25);
            this.lblTongTienHD.TabIndex = 1;
            this.lblTongTienHD.Text = "TỔNG TIỀN HÓA ĐƠN: 0 VNĐ";
            this.lblTongTienHD.TextAlign = ContentAlignment.MiddleRight;

            // 
            // frmTimKiemBanHang
            // 
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(960, 605);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpThongTinChung);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(900, 550);
            this.Name = "frmTimKiemBanHang";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Công việc 3c: Tìm kiếm thông tin hàng bán theo Số HĐB";
            this.Load += new EventHandler(this.frmTimKiemBanHang_Load);

            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpThongTinChung.ResumeLayout(false);
            this.grpThongTinChung.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlTongTien.ResumeLayout(false);
            this.pnlTongTien.PerformLayout();
            this.ResumeLayout(false);
        }

        private void frmTimKiemBanHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSoHDB();
            if (cboSoHDB.Items.Count > 0)
            {
                cboSoHDB.SelectedIndex = 0;
                ThucHienTimKiem(cboSoHDB.Text.Trim());
            }
        }

        private void LoadDanhSachSoHDB()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteDataTable("SELECT SoHDB FROM HDBAN ORDER BY SoHDB");
                cboSoHDB.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cboSoHDB.Items.Add(row["SoHDB"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách Số HĐB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSoHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string soHDB = cboSoHDB.Text.Trim();
            if (string.IsNullOrEmpty(soHDB))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Số hóa đơn bán cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDB.Focus();
                return;
            }

            ThucHienTimKiem(soHDB);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                txtSoHDB.Text = "(Tất cả)";
                txtNgayBan.Text = "Toàn thời gian";
                txtTenKH.Text = "Tất cả khách hàng";
                txtDiaChiKH.Text = "--";

                string sql = "SELECT " +
                             "ROW_NUMBER() OVER (ORDER BY HD.SoHDB, CT.Mahang) AS [STT], " +
                             "HD.SoHDB AS [Số HĐB], " +
                             "CT.Mahang AS [Mã hàng], " +
                             "H.Tenhang AS [Tên mặt hàng], " +
                             "H.DVT AS [ĐVT], " +
                             "CT.Soluongban AS [Số lượng], " +
                             "CT.Dongiaban AS [Đơn giá], " +
                             "(CT.Soluongban * CT.Dongiaban) AS [Thành tiền] " +
                             "FROM CHITIETBAN CT " +
                             "INNER JOIN HDBAN HD ON CT.SoHDB = HD.SoHDB " +
                             "INNER JOIN HANG H ON CT.Mahang = H.Mahang " +
                             "ORDER BY HD.SoHDB, CT.Mahang";

                DataTable dt = DatabaseHelper.ExecuteDataTable(sql);
                dgvChiTiet.DataSource = dt;
                DinhDangLuoi();

                int tongSL = 0;
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Số lượng"] != DBNull.Value)
                    {
                        tongSL += Convert.ToInt32(row["Số lượng"]);
                    }
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["Thành tiền"]);
                    }
                }

                lblTongMatHang = (Label)pnlTongTien.Controls[0];
                lblTongMatHang.Text = string.Format("Tổng số dòng chi tiết: {0} | Tổng SL bán: {1:#,##0}", dt.Rows.Count, tongSL);
                lblTongTienHD.Text = string.Format("TỔNG TIỀN TẤT CẢ HÓA ĐƠN: {0:#,##0} VNĐ", tongTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị tất cả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThucHienTimKiem(string soHDB)
        {
            try
            {
                // 1. Tìm thông tin chung của Hóa đơn bán
                string sqlHD = "SELECT HD.SoHDB, HD.Ngayban, K.Tenkh, K.Diachikh " +
                               "FROM HDBAN HD " +
                               "INNER JOIN KHACH K ON HD.Makh = K.Makh " +
                               "WHERE HD.SoHDB = @sohdb";

                DataTable dtHD = DatabaseHelper.ExecuteDataTable(sqlHD, new SqlParameter[] {
                    new SqlParameter("@sohdb", soHDB)
                });

                if (dtHD.Rows.Count == 0)
                {
                    MessageBox.Show(string.Format("Không tìm thấy thông tin cho Số hóa đơn bán: [{0}]!", soHDB), "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoHDB.Clear();
                    txtNgayBan.Clear();
                    txtTenKH.Clear();
                    txtDiaChiKH.Clear();
                    dgvChiTiet.DataSource = null;
                    lblTongMatHang.Text = "Số mặt hàng: 0 sản phẩm";
                    lblTongTienHD.Text = "TỔNG TIỀN HÓA ĐƠN: 0 VNĐ";
                    return;
                }

                DataRow rowHD = dtHD.Rows[0];
                txtSoHDB.Text = rowHD["SoHDB"].ToString();
                txtNgayBan.Text = Convert.ToDateTime(rowHD["Ngayban"]).ToString("dd/MM/yyyy HH:mm");
                txtTenKH.Text = rowHD["Tenkh"].ToString();
                txtDiaChiKH.Text = rowHD["Diachikh"].ToString();

                // 2. Tìm chi tiết các mặt hàng bán trong hóa đơn
                string sqlCT = "SELECT " +
                               "ROW_NUMBER() OVER (ORDER BY CT.Mahang) AS [STT], " +
                               "CT.Mahang AS [Mã hàng], " +
                               "H.Tenhang AS [Tên mặt hàng], " +
                               "H.DVT AS [ĐVT], " +
                               "CT.Soluongban AS [Số lượng], " +
                               "CT.Dongiaban AS [Đơn giá], " +
                               "(CT.Soluongban * CT.Dongiaban) AS [Thành tiền] " +
                               "FROM CHITIETBAN CT " +
                               "INNER JOIN HANG H ON CT.Mahang = H.Mahang " +
                               "WHERE CT.SoHDB = @sohdb " +
                               "ORDER BY CT.Mahang";

                DataTable dtCT = DatabaseHelper.ExecuteDataTable(sqlCT, new SqlParameter[] {
                    new SqlParameter("@sohdb", soHDB)
                });

                dgvChiTiet.DataSource = dtCT;
                DinhDangLuoi();

                // 3. Tính tổng tiền và số mặt hàng
                int tongSL = 0;
                decimal tongTien = 0;
                foreach (DataRow row in dtCT.Rows)
                {
                    if (row["Số lượng"] != DBNull.Value)
                    {
                        tongSL += Convert.ToInt32(row["Số lượng"]);
                    }
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["Thành tiền"]);
                    }
                }

                lblTongMatHang.Text = string.Format("Số loại mặt hàng: {0} | Tổng SL sản phẩm: {1:#,##0}", dtCT.Rows.Count, tongSL);
                lblTongTienHD.Text = string.Format("TỔNG TIỀN HÓA ĐƠN: {0:#,##0} VNĐ", tongTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvChiTiet.Columns["STT"] != null)
            {
                dgvChiTiet.Columns["STT"].FillWeight = 40;
                dgvChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChiTiet.Columns["Mã hàng"] != null)
            {
                dgvChiTiet.Columns["Mã hàng"].FillWeight = 60;
                dgvChiTiet.Columns["Mã hàng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChiTiet.Columns["Số lượng"] != null)
            {
                dgvChiTiet.Columns["Số lượng"].DefaultCellStyle.Format = "#,##0";
                dgvChiTiet.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChiTiet.Columns["Đơn giá"] != null)
            {
                dgvChiTiet.Columns["Đơn giá"].DefaultCellStyle.Format = "#,##0";
                dgvChiTiet.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChiTiet.Columns["Thành tiền"] != null)
            {
                dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "#,##0";
                dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
