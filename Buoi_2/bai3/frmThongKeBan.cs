using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmThongKeBan : Form
    {
        #region Điều khiển Giao diện (Controls)
        private Label lblTieuDe;

        private GroupBox grpBoLoc;
        private CheckBox chkLocNgay;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;

        private Label lblKhach;
        private ComboBox cboKhach;
        private Label lblHang;
        private ComboBox cboHang;

        private Button btnThongKe;
        private Button btnXemTatCa;
        private Button btnThoat;

        private GroupBox grpKetQua;
        private DataGridView dgvThongKe;
        private Panel pnlTongHop;
        private Label lblTongSoDong;
        private Label lblTongSoLuong;
        private Label lblTongThanhTien;
        #endregion

        public frmThongKeBan()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.grpBoLoc = new GroupBox();
            this.chkLocNgay = new CheckBox();
            this.lblTuNgay = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.lblDenNgay = new Label();
            this.dtpDenNgay = new DateTimePicker();
            this.lblKhach = new Label();
            this.cboKhach = new ComboBox();
            this.lblHang = new Label();
            this.cboHang = new ComboBox();
            this.btnThongKe = new Button();
            this.btnXemTatCa = new Button();
            this.btnThoat = new Button();

            this.grpKetQua = new GroupBox();
            this.dgvThongKe = new DataGridView();
            this.pnlTongHop = new Panel();
            this.lblTongSoDong = new Label();
            this.lblTongSoLuong = new Label();
            this.lblTongThanhTien = new Label();

            this.grpBoLoc.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.pnlTongHop.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.Firebrick;
            this.lblTieuDe.Location = new Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(980, 48);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THỐNG KÊ CHI TIẾT HÀNG BÁN (QLKD)";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpBoLoc.Controls.Add(this.chkLocNgay);
            this.grpBoLoc.Controls.Add(this.lblTuNgay);
            this.grpBoLoc.Controls.Add(this.dtpTuNgay);
            this.grpBoLoc.Controls.Add(this.lblDenNgay);
            this.grpBoLoc.Controls.Add(this.dtpDenNgay);
            this.grpBoLoc.Controls.Add(this.lblKhach);
            this.grpBoLoc.Controls.Add(this.cboKhach);
            this.grpBoLoc.Controls.Add(this.lblHang);
            this.grpBoLoc.Controls.Add(this.cboHang);
            this.grpBoLoc.Controls.Add(this.btnThongKe);
            this.grpBoLoc.Controls.Add(this.btnXemTatCa);
            this.grpBoLoc.Controls.Add(this.btnThoat);
            this.grpBoLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpBoLoc.ForeColor = Color.DarkRed;
            this.grpBoLoc.Location = new Point(15, 50);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new Size(950, 105);
            this.grpBoLoc.TabIndex = 1;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Tiêu chí thống kê & bộ lọc";

            // chkLocNgay
            this.chkLocNgay.AutoSize = true;
            this.chkLocNgay.Font = new Font("Segoe UI", 9F);
            this.chkLocNgay.ForeColor = Color.Black;
            this.chkLocNgay.Location = new Point(20, 30);
            this.chkLocNgay.Name = "chkLocNgay";
            this.chkLocNgay.Size = new Size(125, 24);
            this.chkLocNgay.TabIndex = 0;
            this.chkLocNgay.Text = "Lọc theo ngày";
            this.chkLocNgay.UseVisualStyleBackColor = true;
            this.chkLocNgay.CheckedChanged += new EventHandler(this.chkLocNgay_CheckedChanged);

            // lblTuNgay & dtpTuNgay
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new Font("Segoe UI", 9F);
            this.lblTuNgay.ForeColor = Color.Black;
            this.lblTuNgay.Location = new Point(150, 31);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new Size(65, 20);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Enabled = false;
            this.dtpTuNgay.Font = new Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new Point(220, 27);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new Size(130, 27);
            this.dtpTuNgay.TabIndex = 2;

            // lblDenNgay & dtpDenNgay
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new Font("Segoe UI", 9F);
            this.lblDenNgay.ForeColor = Color.Black;
            this.lblDenNgay.Location = new Point(365, 31);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new Size(75, 20);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Enabled = false;
            this.dtpDenNgay.Font = new Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new Point(445, 27);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new Size(130, 27);
            this.dtpDenNgay.TabIndex = 4;

            // lblKhach & cboKhach
            this.lblKhach.AutoSize = true;
            this.lblKhach.Font = new Font("Segoe UI", 9F);
            this.lblKhach.ForeColor = Color.Black;
            this.lblKhach.Location = new Point(20, 68);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new Size(89, 20);
            this.lblKhach.TabIndex = 5;
            this.lblKhach.Text = "Khách hàng:";

            this.cboKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKhach.Font = new Font("Segoe UI", 9F);
            this.cboKhach.FormattingEnabled = true;
            this.cboKhach.Location = new Point(130, 65);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new Size(250, 28);
            this.cboKhach.TabIndex = 6;

            // lblHang & cboHang
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new Font("Segoe UI", 9F);
            this.lblHang.ForeColor = Color.Black;
            this.lblHang.Location = new Point(400, 68);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new Size(74, 20);
            this.lblHang.Text = "Mặt hàng:";

            this.cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboHang.Font = new Font("Segoe UI", 9F);
            this.cboHang.FormattingEnabled = true;
            this.cboHang.Location = new Point(480, 65);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new Size(220, 28);
            this.cboHang.TabIndex = 7;

            // btnThongKe
            this.btnThongKe.BackColor = Color.Brown;
            this.btnThongKe.FlatStyle = FlatStyle.Flat;
            this.btnThongKe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThongKe.ForeColor = Color.White;
            this.btnThongKe.Location = new Point(720, 22);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new Size(105, 33);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "📊 Lọc";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new EventHandler(this.btnThongKe_Click);

            // btnXemTatCa
            this.btnXemTatCa.BackColor = Color.DarkSlateGray;
            this.btnXemTatCa.FlatStyle = FlatStyle.Flat;
            this.btnXemTatCa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnXemTatCa.ForeColor = Color.White;
            this.btnXemTatCa.Location = new Point(835, 22);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new Size(105, 33);
            this.btnXemTatCa.TabIndex = 9;
            this.btnXemTatCa.Text = "🔄 Tất cả";
            this.btnXemTatCa.UseVisualStyleBackColor = false;
            this.btnXemTatCa.Click += new EventHandler(this.btnXemTatCa_Click);

            // btnThoat
            this.btnThoat.BackColor = Color.FromArgb(70, 70, 70);
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Location = new Point(720, 62);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new Size(220, 33);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "🚪 Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // 
            // grpKetQua
            // 
            this.grpKetQua.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.grpKetQua.Controls.Add(this.dgvThongKe);
            this.grpKetQua.Controls.Add(this.pnlTongHop);
            this.grpKetQua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpKetQua.Location = new Point(15, 160);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new Size(950, 430);
            this.grpKetQua.TabIndex = 2;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Bảng dữ liệu Thống kê Hàng Bán (Công việc 3b)";

            // dgvThongKe
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = Color.White;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Dock = DockStyle.Fill;
            this.dgvThongKe.Location = new Point(3, 25);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 35;
            this.dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new Size(944, 362);
            this.dgvThongKe.TabIndex = 0;

            // pnlTongHop
            this.pnlTongHop.BackColor = Color.FromArgb(253, 245, 245);
            this.pnlTongHop.Controls.Add(this.lblTongSoDong);
            this.pnlTongHop.Controls.Add(this.lblTongSoLuong);
            this.pnlTongHop.Controls.Add(this.lblTongThanhTien);
            this.pnlTongHop.Dock = DockStyle.Bottom;
            this.pnlTongHop.Location = new Point(3, 387);
            this.pnlTongHop.Name = "pnlTongHop";
            this.pnlTongHop.Size = new Size(944, 40);
            this.pnlTongHop.TabIndex = 1;

            // lblTongSoDong
            this.lblTongSoDong.AutoSize = true;
            this.lblTongSoDong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblTongSoDong.ForeColor = Color.Black;
            this.lblTongSoDong.Location = new Point(15, 10);
            this.lblTongSoDong.Name = "lblTongSoDong";
            this.lblTongSoDong.Size = new Size(130, 21);
            this.lblTongSoDong.TabIndex = 0;
            this.lblTongSoDong.Text = "Số lượt bán: 0";

            // lblTongSoLuong
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblTongSoLuong.ForeColor = Color.DarkSlateGray;
            this.lblTongSoLuong.Location = new Point(250, 10);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new Size(170, 21);
            this.lblTongSoLuong.TabIndex = 1;
            this.lblTongSoLuong.Text = "Tổng số lượng bán: 0";

            // lblTongThanhTien
            this.lblTongThanhTien.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblTongThanhTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTongThanhTien.ForeColor = Color.DarkRed;
            this.lblTongThanhTien.Location = new Point(480, 8);
            this.lblTongThanhTien.Name = "lblTongThanhTien";
            this.lblTongThanhTien.Size = new Size(450, 25);
            this.lblTongThanhTien.TabIndex = 2;
            this.lblTongThanhTien.Text = "Tổng doanh thu bán hàng: 0 VNĐ";
            this.lblTongThanhTien.TextAlign = ContentAlignment.MiddleRight;

            // 
            // frmThongKeBan
            // 
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(980, 605);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(900, 550);
            this.Name = "frmThongKeBan";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Công việc 3b: Thống kê Hàng Bán";
            this.Load += new EventHandler(this.frmThongKeBan_Load);

            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.pnlTongHop.ResumeLayout(false);
            this.pnlTongHop.PerformLayout();
            this.ResumeLayout(false);
        }

        private void frmThongKeBan_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-3);
            dtpDenNgay.Value = DateTime.Now;

            LoadCombos();
            ThucHienThongKe();
        }

        private void chkLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpTuNgay.Enabled = chkLocNgay.Checked;
            dtpDenNgay.Enabled = chkLocNgay.Checked;
        }

        private void LoadCombos()
        {
            try
            {
                // Combo Khách hàng
                DataTable dtKhach = DatabaseHelper.ExecuteDataTable("SELECT Makh, Tenkh FROM KHACH ORDER BY Tenkh");
                DataRow rKhach = dtKhach.NewRow();
                rKhach["Makh"] = "";
                rKhach["Tenkh"] = "-- Tất cả Khách hàng --";
                dtKhach.Rows.InsertAt(rKhach, 0);
                cboKhach.DataSource = dtKhach;
                cboKhach.DisplayMember = "Tenkh";
                cboKhach.ValueMember = "Makh";
                cboKhach.SelectedIndex = 0;

                // Combo Hàng
                DataTable dtHang = DatabaseHelper.ExecuteDataTable("SELECT Mahang, Tenhang FROM HANG ORDER BY Tenhang");
                DataRow rHang = dtHang.NewRow();
                rHang["Mahang"] = "";
                rHang["Tenhang"] = "-- Tất cả Mặt hàng --";
                dtHang.Rows.InsertAt(rHang, 0);
                cboHang.DataSource = dtHang;
                cboHang.DisplayMember = "Tenhang";
                cboHang.ValueMember = "Mahang";
                cboHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThucHienThongKe();
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            chkLocNgay.Checked = false;
            cboKhach.SelectedIndex = 0;
            cboHang.SelectedIndex = 0;
            ThucHienThongKe();
        }

        private void ThucHienThongKe()
        {
            try
            {
                string sql = "SELECT " +
                             "ROW_NUMBER() OVER (ORDER BY HD.Ngayban DESC) AS [STT], " +
                             "H.Tenhang AS [Tên hàng], " +
                             "H.DVT AS [Đơn vị tính], " +
                             "K.Tenkh AS [Khách hàng], " +
                             "HD.Ngayban AS [Ngày bán], " +
                             "CT.Soluongban AS [Số lượng bán], " +
                             "CT.Dongiaban AS [Đơn giá bán], " +
                             "(CT.Soluongban * CT.Dongiaban) AS [Thành tiền], " +
                             "HD.SoHDB AS [Số HĐB] " +
                             "FROM CHITIETBAN CT " +
                             "INNER JOIN HDBAN HD ON CT.SoHDB = HD.SoHDB " +
                             "INNER JOIN HANG H ON CT.Mahang = H.Mahang " +
                             "INNER JOIN KHACH K ON HD.Makh = K.Makh " +
                             "WHERE 1=1 ";

                System.Collections.Generic.List<SqlParameter> prms = new System.Collections.Generic.List<SqlParameter>();

                if (chkLocNgay.Checked)
                {
                    DateTime tu = dtpTuNgay.Value.Date;
                    DateTime den = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                    sql += " AND HD.Ngayban BETWEEN @tu AND @den ";
                    prms.Add(new SqlParameter("@tu", tu));
                    prms.Add(new SqlParameter("@den", den));
                }

                if (cboKhach.SelectedValue != null && !string.IsNullOrEmpty(cboKhach.SelectedValue.ToString()))
                {
                    sql += " AND HD.Makh = @makh ";
                    prms.Add(new SqlParameter("@makh", cboKhach.SelectedValue.ToString()));
                }

                if (cboHang.SelectedValue != null && !string.IsNullOrEmpty(cboHang.SelectedValue.ToString()))
                {
                    sql += " AND CT.Mahang = @mahang ";
                    prms.Add(new SqlParameter("@mahang", cboHang.SelectedValue.ToString()));
                }

                sql += " ORDER BY HD.Ngayban DESC";

                DataTable dt = DatabaseHelper.ExecuteDataTable(sql, prms.ToArray());
                dgvThongKe.DataSource = dt;

                // Định dạng hiển thị
                if (dgvThongKe.Columns["STT"] != null)
                {
                    dgvThongKe.Columns["STT"].FillWeight = 40;
                    dgvThongKe.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvThongKe.Columns["Ngày bán"] != null)
                {
                    dgvThongKe.Columns["Ngày bán"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvThongKe.Columns["Số lượng bán"] != null)
                {
                    dgvThongKe.Columns["Số lượng bán"].DefaultCellStyle.Format = "#,##0";
                    dgvThongKe.Columns["Số lượng bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvThongKe.Columns["Đơn giá bán"] != null)
                {
                    dgvThongKe.Columns["Đơn giá bán"].DefaultCellStyle.Format = "#,##0";
                    dgvThongKe.Columns["Đơn giá bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvThongKe.Columns["Thành tiền"] != null)
                {
                    dgvThongKe.Columns["Thành tiền"].DefaultCellStyle.Format = "#,##0";
                    dgvThongKe.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tính tổng hợp
                int tongSL = 0;
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Số lượng bán"] != DBNull.Value)
                    {
                        tongSL += Convert.ToInt32(row["Số lượng bán"]);
                    }
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["Thành tiền"]);
                    }
                }

                lblTongSoDong.Text = string.Format("Số lượt bán: {0}", dt.Rows.Count);
                lblTongSoLuong.Text = string.Format("Tổng số lượng bán: {0:#,##0}", tongSL);
                lblTongThanhTien.Text = string.Format("Tổng doanh thu bán hàng: {0:#,##0} VNĐ", tongTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
