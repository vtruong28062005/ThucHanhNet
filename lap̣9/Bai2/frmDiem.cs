using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public class frmDiem : Form
    {
        #region Khai báo Controls Giao diện theo Hình 9.46
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblMaMH;
        private TextBox txtMaMH;
        private Label lblTenSV;
        private TextBox txtTenSV;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblDiem;
        private TextBox txtDiem;
        private Label lblMaKhoa;
        private ComboBox cboMaKhoa;

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnTimKiem;
        private Button btnIn;

        private ListView lvwDiem;
        private ColumnHeader colMaSV;
        private ColumnHeader colMaMH;
        private ColumnHeader colTenSV;
        private ColumnHeader colNgaySinh;
        private ColumnHeader colDiem;
        private ColumnHeader colMaKhoa;
        #endregion

        public frmDiem()
        {
            InitializeComponent();
        }

        #region Khởi tạo Giao diện theo chuẩn Hình 9.46
        private void InitializeComponent()
        {
            this.lblMaSV = new Label();
            this.txtMaSV = new TextBox();
            this.lblMaMH = new Label();
            this.txtMaMH = new TextBox();
            this.lblTenSV = new Label();
            this.txtTenSV = new TextBox();
            this.lblNgaySinh = new Label();
            this.dtpNgaySinh = new DateTimePicker();
            this.lblDiem = new Label();
            this.txtDiem = new TextBox();
            this.lblMaKhoa = new Label();
            this.cboMaKhoa = new ComboBox();

            this.btnThem = new Button();
            this.btnXoa = new Button();
            this.btnSua = new Button();
            this.btnTimKiem = new Button();
            this.btnIn = new Button();

            this.lvwDiem = new ListView();
            this.colMaSV = new ColumnHeader();
            this.colMaMH = new ColumnHeader();
            this.colTenSV = new ColumnHeader();
            this.colNgaySinh = new ColumnHeader();
            this.colDiem = new ColumnHeader();
            this.colMaKhoa = new ColumnHeader();

            this.SuspendLayout();

            // 
            // lblMaSV & txtMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Font = new Font("Segoe UI", 9F);
            this.lblMaSV.Location = new Point(45, 25);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new Size(51, 20);
            this.lblMaSV.Text = "Mã SV";

            this.txtMaSV.Font = new Font("Segoe UI", 9F);
            this.txtMaSV.Location = new Point(140, 22);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new Size(240, 27);
            this.txtMaSV.Leave += new EventHandler(this.txtMaSV_Leave);

            // 
            // lblMaMH & txtMaMH
            // 
            this.lblMaMH.AutoSize = true;
            this.lblMaMH.Font = new Font("Segoe UI", 9F);
            this.lblMaMH.Location = new Point(45, 62);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new Size(58, 20);
            this.lblMaMH.Text = "Mã MH";

            this.txtMaMH.Font = new Font("Segoe UI", 9F);
            this.txtMaMH.Location = new Point(140, 59);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new Size(240, 27);

            // 
            // lblTenSV & txtTenSV
            // 
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Font = new Font("Segoe UI", 9F);
            this.lblTenSV.Location = new Point(45, 99);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new Size(53, 20);
            this.lblTenSV.Text = "Tên SV";

            this.txtTenSV.Font = new Font("Segoe UI", 9F);
            this.txtTenSV.Location = new Point(140, 96);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new Size(240, 27);

            // 
            // lblNgaySinh & dtpNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new Font("Segoe UI", 9F);
            this.lblNgaySinh.Location = new Point(45, 137);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new Size(74, 20);
            this.lblNgaySinh.Text = "Ngày sinh";

            this.dtpNgaySinh.CustomFormat = "M/d/yyyy";
            this.dtpNgaySinh.Font = new Font("Segoe UI", 9F);
            this.dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new Point(140, 133);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new Size(240, 27);

            // 
            // lblDiem & txtDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new Font("Segoe UI", 9F);
            this.lblDiem.Location = new Point(45, 175);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new Size(45, 20);
            this.lblDiem.Text = "Điểm";

            this.txtDiem.Font = new Font("Segoe UI", 9F);
            this.txtDiem.Location = new Point(140, 171);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new Size(240, 27);

            // 
            // lblMaKhoa & cboMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Font = new Font("Segoe UI", 9F);
            this.lblMaKhoa.Location = new Point(45, 212);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new Size(67, 20);
            this.lblMaKhoa.Text = "Mã Khoa";

            this.cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMaKhoa.Font = new Font("Segoe UI", 9F);
            this.cboMaKhoa.FormattingEnabled = true;
            this.cboMaKhoa.Location = new Point(140, 208);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new Size(240, 28);

            // 
            // btnThem
            // 
            this.btnThem.Font = new Font("Segoe UI", 9F);
            this.btnThem.Location = new Point(445, 20);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(135, 30);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new EventHandler(this.btnThem_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Font = new Font("Segoe UI", 9F);
            this.btnXoa.Location = new Point(445, 57);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(135, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa điểm";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            // 
            // btnSua
            // 
            this.btnSua.Font = new Font("Segoe UI", 9F);
            this.btnSua.Location = new Point(445, 94);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(135, 30);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa điểm";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new EventHandler(this.btnSua_Click);

            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new Font("Segoe UI", 9F);
            this.btnTimKiem.Location = new Point(445, 131);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new Size(135, 30);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new EventHandler(this.btnTimKiem_Click);

            // 
            // btnIn
            // 
            this.btnIn.Font = new Font("Segoe UI", 9F);
            this.btnIn.Location = new Point(445, 168);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new Size(135, 30);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new EventHandler(this.btnIn_Click);

            // 
            // lvwDiem
            // 
            this.lvwDiem.Columns.AddRange(new ColumnHeader[] {
                this.colMaSV,
                this.colMaMH,
                this.colTenSV,
                this.colNgaySinh,
                this.colDiem,
                this.colMaKhoa
            });
            this.lvwDiem.FullRowSelect = true;
            this.lvwDiem.GridLines = true;
            this.lvwDiem.Font = new Font("Segoe UI", 9F);
            this.lvwDiem.HideSelection = false;
            this.lvwDiem.Location = new Point(25, 255);
            this.lvwDiem.Name = "lvwDiem";
            this.lvwDiem.Size = new Size(575, 215);
            this.lvwDiem.TabIndex = 11;
            this.lvwDiem.UseCompatibleStateImageBehavior = false;
            this.lvwDiem.View = View.Details;
            this.lvwDiem.SelectedIndexChanged += new EventHandler(this.lvwDiem_SelectedIndexChanged);
            this.lvwDiem.Click += new EventHandler(this.lvwDiem_Click);

            // 
            // Columns Header
            // 
            this.colMaSV.Text = "Mã SV";
            this.colMaSV.Width = 75;

            this.colMaMH.Text = "Mã MH";
            this.colMaMH.Width = 75;

            this.colTenSV.Text = "Tên SV";
            this.colTenSV.Width = 145;

            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 100;

            this.colDiem.Text = "Điểm";
            this.colDiem.Width = 65;

            this.colMaKhoa.Text = "Mã Khoa";
            this.colMaKhoa.Width = 90;

            // 
            // frmDiem
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 235, 215); // Màu nền chuẩn theo Hình 9.46
            this.ClientSize = new Size(625, 485);
            this.Controls.Add(this.lvwDiem);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboMaKhoa);
            this.Controls.Add(this.lblMaKhoa);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtTenSV);
            this.Controls.Add(this.lblTenSV);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.lblMaMH);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblMaSV);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDiem";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frDiem";
            this.Load += new EventHandler(this.frmDiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Yêu cầu 1: Hiển thị toàn bộ danh sách điểm và nạp lên Controls khi click ListView
        private void frmDiem_Load(object sender, EventArgs e)
        {
            LoadMaKhoaVaoComboBox();
            LoadDanhSachDiem();
        }

        private void LoadMaKhoaVaoComboBox()
        {
            try
            {
                string sql = "SELECT Makhoa, Tenkhoa FROM tblKhoa ORDER BY Makhoa ASC";
                DataTable dt = DatabaseHelper.ExecuteDataTable(sql);
                cboMaKhoa.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cboMaKhoa.Items.Add(row["Makhoa"].ToString());
                }
                if (cboMaKhoa.Items.Count > 0 && cboMaKhoa.SelectedIndex == -1)
                {
                    cboMaKhoa.SelectedIndex = 0;
                }
            }
            catch { }
        }

        public void LoadDanhSachDiem(string keyword = null)
        {
            lvwDiem.Items.Clear();
            try
            {
                string sql = "SELECT d.MaSV, d.Mamon, sv.Hoten, sv.Ngaysinh, d.Diem, sv.Makhoa " +
                             "FROM tblDiem d " +
                             "INNER JOIN tblSinhVien sv ON d.MaSV = sv.MaSV ";

                SqlParameter[] p = null;
                if (!string.IsNullOrEmpty(keyword))
                {
                    sql += "WHERE d.MaSV LIKE @keyword OR sv.Hoten LIKE @keyword ";
                    p = new SqlParameter[] {
                        new SqlParameter("@keyword", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" }
                    };
                }

                sql += "ORDER BY d.MaSV ASC, d.Mamon ASC";

                DataTable dt = DatabaseHelper.ExecuteDataTable(sql, p);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaSV"].ToString());
                    item.SubItems.Add(row["Mamon"].ToString());
                    item.SubItems.Add(row["Hoten"].ToString());

                    string strNgaySinh = "";
                    if (row["Ngaysinh"] != DBNull.Value)
                    {
                        DateTime ns = Convert.ToDateTime(row["Ngaysinh"]);
                        strNgaySinh = ns.ToString("M/d/yyyy");
                    }
                    item.SubItems.Add(strNgaySinh);

                    string strDiem = "";
                    if (row["Diem"] != DBNull.Value)
                    {
                        strDiem = Convert.ToDouble(row["Diem"]).ToString();
                    }
                    item.SubItems.Add(strDiem);

                    item.SubItems.Add(row["Makhoa"] != DBNull.Value ? row["Makhoa"].ToString() : "");

                    lvwDiem.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nạp danh sách điểm từ CSDL:\n" + ex.Message + "\n\n(Vui lòng kiểm tra kết nối SQL Server)", "Thông báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvwDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiChiTietPhanTuChon();
        }

        private void lvwDiem_Click(object sender, EventArgs e)
        {
            HienThiChiTietPhanTuChon();
        }

        private void HienThiChiTietPhanTuChon()
        {
            if (lvwDiem.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwDiem.SelectedItems[0];
                txtMaSV.Text = item.SubItems[0].Text;
                txtMaMH.Text = item.SubItems[1].Text;
                txtTenSV.Text = item.SubItems[2].Text;

                DateTime ns;
                if (DateTime.TryParse(item.SubItems[3].Text, out ns))
                {
                    dtpNgaySinh.Value = ns;
                }

                txtDiem.Text = item.SubItems[4].Text;

                string maKhoa = item.SubItems[5].Text;
                cboMaKhoa.SelectedItem = maKhoa;
                if (cboMaKhoa.SelectedIndex == -1) cboMaKhoa.Text = maKhoa;
            }
        }

        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            // Tự động điền Họ tên, Ngày sinh, Mã khoa nếu Mã SV đã tồn tại trong CSDL
            string maSV = txtMaSV.Text.Trim();
            if (!string.IsNullOrEmpty(maSV))
            {
                try
                {
                    string sql = "SELECT Hoten, Ngaysinh, Makhoa FROM tblSinhVien WHERE MaSV = @MaSV";
                    SqlParameter[] p = new SqlParameter[] {
                        new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV }
                    };
                    DataTable dt = DatabaseHelper.ExecuteDataTable(sql, p);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        txtTenSV.Text = r["Hoten"].ToString();
                        if (r["Ngaysinh"] != DBNull.Value)
                        {
                            dtpNgaySinh.Value = Convert.ToDateTime(r["Ngaysinh"]);
                        }
                        if (r["Makhoa"] != DBNull.Value)
                        {
                            cboMaKhoa.SelectedItem = r["Makhoa"].ToString();
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Yêu cầu 2: Chức năng "Thêm" (Có kiểm tra tính hợp lệ chặt chẽ)
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string tenSV = txtTenSV.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string strDiem = txtDiem.Text.Trim();
            string maKhoa = cboMaKhoa.SelectedItem != null ? cboMaKhoa.SelectedItem.ToString() : cboMaKhoa.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            if (string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMH.Focus();
                return;
            }

            if (string.IsNullOrEmpty(strDiem))
            {
                MessageBox.Show("Điểm số không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            // 2. Kiểm tra điểm hợp lệ từ 0 đến 10
            double diem;
            // Cho phép cả dấu chấm và dấu phẩy thập phân
            string diemFormat = strDiem.Replace(',', '.');
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;
            if (!double.TryParse(diemFormat, System.Globalization.NumberStyles.Any, culture, out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập điểm là số thực trong khoảng từ 0 đến 10.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                txtDiem.SelectAll();
                return;
            }

            try
            {
                // 3. Kiểm tra mã môn học có tồn tại trong tblMonHoc không
                string sqlCheckMH = "SELECT COUNT(*) FROM tblMonHoc WHERE Mamon = @Mamon";
                SqlParameter[] pCheckMH = new SqlParameter[] {
                    new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMH }
                };
                int countMH = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCheckMH, pCheckMH));
                if (countMH == 0)
                {
                    MessageBox.Show(string.Format("Mã môn học '{0}' không tồn tại trong bảng môn học (tblMonHoc)!\nVui lòng kiểm tra lại mã môn hoặc thêm môn học trước.", maMH), "Không tồn tại môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMH.Focus();
                    return;
                }

                // 4. Kiểm tra sinh viên đã tồn tại trong tblSinhVien chưa
                string sqlCheckSV = "SELECT COUNT(*) FROM tblSinhVien WHERE MaSV = @MaSV";
                SqlParameter[] pCheckSV = new SqlParameter[] {
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV }
                };
                int countSV = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCheckSV, pCheckSV));

                if (countSV == 0)
                {
                    // Nếu sinh viên chưa có, yêu cầu nhập Tên SV và Mã Khoa để thêm sinh viên
                    if (string.IsNullOrEmpty(tenSV))
                    {
                        MessageBox.Show("Mã SV mới chưa có trong hệ thống, vui lòng nhập Tên SV để tạo mới sinh viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenSV.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(maKhoa))
                    {
                        MessageBox.Show("Vui lòng chọn Mã khoa cho sinh viên mới!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboMaKhoa.Focus();
                        return;
                    }

                    // Tự động thêm vào tblSinhVien
                    string sqlInsertSV = "INSERT INTO tblSinhVien (MaSV, Hoten, Ngaysinh, Makhoa) VALUES (@MaSV, @Hoten, @Ngaysinh, @Makhoa)";
                    SqlParameter[] pInsertSV = new SqlParameter[] {
                        new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV },
                        new SqlParameter("@Hoten", SqlDbType.NVarChar, 100) { Value = tenSV },
                        new SqlParameter("@Ngaysinh", SqlDbType.DateTime) { Value = ngaySinh },
                        new SqlParameter("@Makhoa", SqlDbType.VarChar, 10) { Value = maKhoa }
                    };
                    DatabaseHelper.ExecuteNonQuery(sqlInsertSV, pInsertSV);
                }

                // 5. Kiểm tra trùng điểm: Sinh viên này đã có điểm môn này chưa
                string sqlCheckDiem = "SELECT COUNT(*) FROM tblDiem WHERE MaSV = @MaSV AND Mamon = @Mamon";
                SqlParameter[] pCheckDiem = new SqlParameter[] {
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV },
                    new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMH }
                };
                int countDiem = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCheckDiem, pCheckDiem));
                if (countDiem > 0)
                {
                    MessageBox.Show(string.Format("Sinh viên '{0}' đã có điểm cho môn học '{1}'!\nNếu muốn thay đổi điểm, vui lòng dùng chức năng 'Sửa điểm'.", maSV, maMH), "Trùng dữ liệu điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 6. Thực hiện thêm điểm vào tblDiem
                string sqlInsertDiem = "INSERT INTO tblDiem (MaSV, Mamon, Diem) VALUES (@MaSV, @Mamon, @Diem)";
                SqlParameter[] pInsertDiem = new SqlParameter[] {
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV },
                    new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMH },
                    new SqlParameter("@Diem", SqlDbType.Float) { Value = diem }
                };
                DatabaseHelper.ExecuteNonQuery(sqlInsertDiem, pInsertDiem);

                MessageBox.Show("Thêm thông tin điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại ListView
                LoadDanhSachDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm điểm vào CSDL:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu 3: Chức năng "XÓA" (Xóa tất cả các phần tử được chọn trên ListView)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwDiem.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phần tử trên ListView để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int count = lvwDiem.SelectedItems.Count;
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa {0} phần tử điểm được chọn khỏi cơ sở dữ liệu không?", count),
                "Xác nhận xóa điểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                int xoaThanhCong = 0;
                try
                {
                    foreach (ListViewItem item in lvwDiem.SelectedItems)
                    {
                        string maSV = item.SubItems[0].Text;
                        string maMH = item.SubItems[1].Text;

                        string sqlDelete = "DELETE FROM tblDiem WHERE MaSV = @MaSV AND Mamon = @Mamon";
                        SqlParameter[] p = new SqlParameter[] {
                            new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV },
                            new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMH }
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlDelete, p);
                        xoaThanhCong++;
                    }

                    MessageBox.Show(string.Format("Đã xóa thành công {0} bản ghi điểm!", xoaThanhCong), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại ListView sau khi xóa
                    LoadDanhSachDiem();

                    // Xóa trắng ô nhập liệu
                    XoaTrangControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Yêu cầu 4: Chức năng "SỬA" (Sửa điểm và thông tin liên quan)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwDiem.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng điểm trên ListView để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();
            string tenSV = txtTenSV.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string strDiem = txtDiem.Text.Trim();
            string maKhoa = cboMaKhoa.SelectedItem != null ? cboMaKhoa.SelectedItem.ToString() : cboMaKhoa.Text.Trim();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Mã SV và Mã MH không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double diem;
            string diemFormat = strDiem.Replace(',', '.');
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;
            if (!double.TryParse(diemFormat, System.Globalization.NumberStyles.Any, culture, out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập điểm là số thực từ 0 đến 10.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }

            try
            {
                // Cập nhật điểm trong tblDiem
                string sqlUpdateDiem = "UPDATE tblDiem SET Diem = @Diem WHERE MaSV = @MaSV AND Mamon = @Mamon";
                SqlParameter[] pDiem = new SqlParameter[] {
                    new SqlParameter("@Diem", SqlDbType.Float) { Value = diem },
                    new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV },
                    new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMH }
                };
                int rowDiem = DatabaseHelper.ExecuteNonQuery(sqlUpdateDiem, pDiem);

                // Đồng thời cập nhật thông tin sinh viên nếu có thay đổi
                if (!string.IsNullOrEmpty(tenSV) && !string.IsNullOrEmpty(maKhoa))
                {
                    string sqlUpdateSV = "UPDATE tblSinhVien SET Hoten = @Hoten, Ngaysinh = @Ngaysinh, Makhoa = @Makhoa WHERE MaSV = @MaSV";
                    SqlParameter[] pSV = new SqlParameter[] {
                        new SqlParameter("@Hoten", SqlDbType.NVarChar, 100) { Value = tenSV },
                        new SqlParameter("@Ngaysinh", SqlDbType.DateTime) { Value = ngaySinh },
                        new SqlParameter("@Makhoa", SqlDbType.VarChar, 10) { Value = maKhoa },
                        new SqlParameter("@MaSV", SqlDbType.VarChar, 10) { Value = maSV }
                    };
                    DatabaseHelper.ExecuteNonQuery(sqlUpdateSV, pSV);
                }

                MessageBox.Show("Cập nhật thông tin điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại ListView
                LoadDanhSachDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu 5: Chức năng "TÌM KIẾM" (Theo MaSV, TenSV)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = txtTenSV.Text.Trim();
            }

            // Nếu cả 2 ô trên giao diện đều trống, hiện hộp thoại nhập từ khóa
            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = ShowInputDialog("Tìm kiếm sinh viên", "Nhập Mã SV hoặc Tên SV cần tìm kiếm\n(Để trống và nhấn OK để hiển thị toàn bộ):", "");
            }

            if (tuKhoa == null)
            {
                // Người dùng bấm Hủy
                return;
            }

            tuKhoa = tuKhoa.Trim();
            LoadDanhSachDiem(tuKhoa);

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show(string.Format("Tìm thấy {0} kết quả phù hợp với từ khóa '{1}'.", lvwDiem.Items.Count, tuKhoa), "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Chức năng nút "In"
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (lvwDiem.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu điểm để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.Width = 800;
            ppd.Height = 600;
            ppd.StartPosition = FormStartPosition.CenterParent;
            ppd.ShowDialog();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTieuDe = new Font("Arial", 16, FontStyle.Bold);
            Font fontCot = new Font("Arial", 10, FontStyle.Bold);
            Font fontDong = new Font("Arial", 10, FontStyle.Regular);

            float y = 50;
            g.DrawString("BẢNG ĐIỂM CHI TIẾT SINH VIÊN", fontTieuDe, Brushes.Black, 220, y);
            y += 40;
            g.DrawString("Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontDong, Brushes.Gray, 50, y);
            y += 30;

            // Kẻ bảng
            int xMaSV = 50;
            int xMaMH = 140;
            int xTenSV = 230;
            int xNgaySinh = 420;
            int xDiem = 530;
            int xMaKhoa = 620;

            g.DrawLine(Pens.Black, 50, y, 750, y);
            y += 5;
            g.DrawString("Mã SV", fontCot, Brushes.Black, xMaSV, y);
            g.DrawString("Mã MH", fontCot, Brushes.Black, xMaMH, y);
            g.DrawString("Tên SV", fontCot, Brushes.Black, xTenSV, y);
            g.DrawString("Ngày sinh", fontCot, Brushes.Black, xNgaySinh, y);
            g.DrawString("Điểm", fontCot, Brushes.Black, xDiem, y);
            g.DrawString("Mã Khoa", fontCot, Brushes.Black, xMaKhoa, y);
            y += 25;
            g.DrawLine(Pens.Black, 50, y, 750, y);
            y += 8;

            foreach (ListViewItem item in lvwDiem.Items)
            {
                g.DrawString(item.SubItems[0].Text, fontDong, Brushes.Black, xMaSV, y);
                g.DrawString(item.SubItems[1].Text, fontDong, Brushes.Black, xMaMH, y);
                g.DrawString(item.SubItems[2].Text, fontDong, Brushes.Black, xTenSV, y);
                g.DrawString(item.SubItems[3].Text, fontDong, Brushes.Black, xNgaySinh, y);
                g.DrawString(item.SubItems[4].Text, fontDong, Brushes.Black, xDiem, y);
                g.DrawString(item.SubItems[5].Text, fontDong, Brushes.Black, xMaKhoa, y);
                y += 24;
            }

            g.DrawLine(Pens.Black, 50, y, 750, y);
            y += 30;
            g.DrawString("Tổng cộng: " + lvwDiem.Items.Count.ToString() + " dòng điểm.", fontCot, Brushes.Black, 50, y);
        }

        private void XoaTrangControls()
        {
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtTenSV.Clear();
            txtDiem.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboMaKhoa.SelectedIndex = -1;
        }

        private static string ShowInputDialog(string title, string promptText, string defaultValue)
        {
            Form form = new Form();
            Label lbl = new Label();
            TextBox txt = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = title;
            lbl.Text = promptText;
            txt.Text = defaultValue;

            btnOk.Text = "OK";
            btnCancel.Text = "Hủy";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            lbl.SetBounds(15, 15, 370, 40);
            txt.SetBounds(15, 60, 370, 25);
            btnOk.SetBounds(215, 95, 80, 30);
            btnCancel.SetBounds(305, 95, 80, 30);

            form.ClientSize = new Size(405, 140);
            form.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult res = form.ShowDialog();
            return (res == DialogResult.OK) ? txt.Text : null;
        }
        #endregion
    }
}
