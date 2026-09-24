using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public class frmMonHoc : Form
    {
        #region Khai báo Controls Giao diện
        private Label lblMaMon;
        private TextBox txtMaMon;
        private Label lblTenMon;
        private TextBox txtTenMon;
        private Label lblMaKhoa;
        private ComboBox cboMaKhoa;
        private Label lblSoHocPhan;
        private TextBox txtSoHocPhan;
        private Label lblGiaoVien;
        private TextBox txtGiaoVien;

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;

        private ListView lvwMonHoc;
        private ColumnHeader colMaMon;
        private ColumnHeader colTenMon;
        private ColumnHeader colMaKhoa;
        private ColumnHeader colSoHocPhan;
        private ColumnHeader colGiaoVien;

        private bool dangThemMoi = false;
        private bool dangSua = false;
        #endregion

        public frmMonHoc()
        {
            InitializeComponent();
        }

        #region Khởi tạo Giao diện theo Hình 9.45
        private void InitializeComponent()
        {
            this.lblMaMon = new Label();
            this.txtMaMon = new TextBox();
            this.lblTenMon = new Label();
            this.txtTenMon = new TextBox();
            this.lblMaKhoa = new Label();
            this.cboMaKhoa = new ComboBox();
            this.lblSoHocPhan = new Label();
            this.txtSoHocPhan = new TextBox();
            this.lblGiaoVien = new Label();
            this.txtGiaoVien = new TextBox();

            this.btnThem = new Button();
            this.btnXoa = new Button();
            this.btnSua = new Button();

            this.lvwMonHoc = new ListView();
            this.colMaMon = new ColumnHeader();
            this.colTenMon = new ColumnHeader();
            this.colMaKhoa = new ColumnHeader();
            this.colSoHocPhan = new ColumnHeader();
            this.colGiaoVien = new ColumnHeader();

            this.SuspendLayout();

            // 
            // lblMaMon & txtMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblMaMon.Location = new Point(40, 35);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new Size(95, 20);
            this.lblMaMon.Text = "Mã môn học";

            this.txtMaMon.Font = new Font("Segoe UI", 9F);
            this.txtMaMon.Location = new Point(160, 32);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new Size(240, 27);

            // 
            // lblTenMon & txtTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblTenMon.Location = new Point(40, 75);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new Size(97, 20);
            this.lblTenMon.Text = "Tên môn học";

            this.txtTenMon.Font = new Font("Segoe UI", 9F);
            this.txtTenMon.Location = new Point(160, 72);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new Size(240, 27);

            // 
            // lblMaKhoa & cboMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblMaKhoa.Location = new Point(40, 118);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new Size(67, 20);
            this.lblMaKhoa.Text = "Mã khoa";

            this.cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMaKhoa.Font = new Font("Segoe UI", 9F);
            this.cboMaKhoa.FormattingEnabled = true;
            this.cboMaKhoa.Location = new Point(160, 115);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new Size(240, 28);

            // 
            // lblSoHocPhan & txtSoHocPhan
            // 
            this.lblSoHocPhan.AutoSize = true;
            this.lblSoHocPhan.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblSoHocPhan.Location = new Point(40, 160);
            this.lblSoHocPhan.Name = "lblSoHocPhan";
            this.lblSoHocPhan.Size = new Size(91, 20);
            this.lblSoHocPhan.Text = "Số học phần";

            this.txtSoHocPhan.Font = new Font("Segoe UI", 9F);
            this.txtSoHocPhan.Location = new Point(160, 157);
            this.txtSoHocPhan.Name = "txtSoHocPhan";
            this.txtSoHocPhan.Size = new Size(240, 27);

            // 
            // lblGiaoVien & txtGiaoVien
            // 
            this.lblGiaoVien.AutoSize = true;
            this.lblGiaoVien.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblGiaoVien.Location = new Point(40, 202);
            this.lblGiaoVien.Name = "lblGiaoVien";
            this.lblGiaoVien.Size = new Size(71, 20);
            this.lblGiaoVien.Text = "Giáo viên";

            this.txtGiaoVien.Font = new Font("Segoe UI", 9F);
            this.txtGiaoVien.Location = new Point(160, 199);
            this.txtGiaoVien.Name = "txtGiaoVien";
            this.txtGiaoVien.Size = new Size(240, 27);

            // 
            // btnThem
            // 
            this.btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.btnThem.Location = new Point(445, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(125, 32);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new EventHandler(this.btnThem_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.btnXoa.Location = new Point(445, 112);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(125, 32);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            // 
            // btnSua
            // 
            this.btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.btnSua.Location = new Point(445, 195);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(125, 32);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new EventHandler(this.btnSua_Click);

            // 
            // lvwMonHoc
            // 
            this.lvwMonHoc.Columns.AddRange(new ColumnHeader[] {
                this.colMaMon,
                this.colTenMon,
                this.colMaKhoa,
                this.colSoHocPhan,
                this.colGiaoVien
            });
            this.lvwMonHoc.FullRowSelect = true;
            this.lvwMonHoc.GridLines = true;
            this.lvwMonHoc.Font = new Font("Segoe UI", 9F);
            this.lvwMonHoc.HideSelection = false;
            this.lvwMonHoc.Location = new Point(25, 245);
            this.lvwMonHoc.MultiSelect = false;
            this.lvwMonHoc.Name = "lvwMonHoc";
            this.lvwMonHoc.Size = new Size(575, 215);
            this.lvwMonHoc.TabIndex = 8;
            this.lvwMonHoc.UseCompatibleStateImageBehavior = false;
            this.lvwMonHoc.View = View.Details;
            this.lvwMonHoc.SelectedIndexChanged += new EventHandler(this.lvwMonHoc_SelectedIndexChanged);
            this.lvwMonHoc.Click += new EventHandler(this.lvwMonHoc_Click);

            // 
            // Column Headers
            // 
            this.colMaMon.Text = "Mã môn";
            this.colMaMon.Width = 85;

            this.colTenMon.Text = "Tên môn";
            this.colTenMon.Width = 175;

            this.colMaKhoa.Text = "Mã khoa";
            this.colMaKhoa.Width = 85;

            this.colSoHocPhan.Text = "Số học phần";
            this.colSoHocPhan.Width = 90;

            this.colGiaoVien.Text = "Giáo viên";
            this.colGiaoVien.Width = 135;

            // 
            // frmMonHoc
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 235, 215); // Màu nền chuẩn theo ảnh Hình 9.45
            this.ClientSize = new Size(625, 480);
            this.Controls.Add(this.lvwMonHoc);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaoVien);
            this.Controls.Add(this.lblGiaoVien);
            this.Controls.Add(this.txtSoHocPhan);
            this.Controls.Add(this.lblSoHocPhan);
            this.Controls.Add(this.cboMaKhoa);
            this.Controls.Add(this.lblMaKhoa);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.txtMaMon);
            this.Controls.Add(this.lblMaMon);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMonHoc";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Frmonhoc";
            this.Load += new EventHandler(this.frmMonHoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Yêu cầu a: Khi khởi thi form hiển thị dữ liệu lên ListView, vô hiệu hóa controls
        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            ThietLapTrangThaiBanDau();
            LoadDanhSachMonHoc();
        }

        private void ThietLapTrangThaiBanDau()
        {
            dangThemMoi = false;
            dangSua = false;

            // Nút Thêm ở trạng thái bình thường
            btnThem.Text = "Thêm";
            btnThem.Enabled = true;

            // Nút Xóa, Sửa mờ đi (vô hiệu hóa) theo yêu cầu a
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            // Các TextBox và ComboBox mờ đi (vô hiệu hóa) theo yêu cầu a
            txtMaMon.Enabled = false;
            txtTenMon.Enabled = false;
            cboMaKhoa.Enabled = false;
            txtSoHocPhan.Enabled = false;
            txtGiaoVien.Enabled = false;

            // Xóa trắng ô nhập liệu
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSoHocPhan.Clear();
            txtGiaoVien.Clear();
            cboMaKhoa.SelectedIndex = -1;
        }

        public void LoadDanhSachMonHoc()
        {
            lvwMonHoc.Items.Clear();
            try
            {
                string sql = "SELECT Mamon, Tenmon, Makhoa, Sohocphan, Giaovien FROM tblMonHoc ORDER BY Mamon ASC";
                DataTable dt = DatabaseHelper.ExecuteDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Mamon"].ToString());
                    item.SubItems.Add(row["Tenmon"].ToString());
                    item.SubItems.Add(row["Makhoa"].ToString());
                    item.SubItems.Add(row["Sohocphan"].ToString());
                    item.SubItems.Add(row["Giaovien"] != DBNull.Value ? row["Giaovien"].ToString() : "");

                    lvwMonHoc.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách môn học từ CSDL:\n" + ex.Message + "\n\n(Vui lòng kiểm tra kết nối SQL Server tại menu Hệ thống -> Cấu hình SQL Server)", "Thông báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        #endregion

        #region Yêu cầu b: Chức năng "Thêm" đổi thành "Lưu" & lưu vào CSDL
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                // Khi click "Thêm", nút đổi thành "Lưu"
                btnThem.Text = "Lưu";
                dangThemMoi = true;
                dangSua = false;

                // Các TextBox và ComboBox sáng lên để nhập dữ liệu
                txtMaMon.Enabled = true;
                txtTenMon.Enabled = true;
                cboMaKhoa.Enabled = true;
                txtSoHocPhan.Enabled = true;
                txtGiaoVien.Enabled = true;

                // Nút Xóa, Sửa bị mờ đi khi đang thêm mới
                btnXoa.Enabled = false;
                btnSua.Enabled = false;

                // Xóa trắng dữ liệu cũ
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtSoHocPhan.Clear();
                txtGiaoVien.Clear();

                // Toàn bộ mã khoa trong bảng tblKhoa được load lên combobox mã khoa
                LoadMaKhoaVaoComboBox();

                txtMaMon.Focus();
            }
            else if (btnThem.Text == "Lưu")
            {
                // Khi click vào nút "Lưu" -> Kiểm tra dữ liệu & lưu vào CSDL
                string maMon = txtMaMon.Text.Trim();
                string tenMon = txtTenMon.Text.Trim();
                string maKhoa = cboMaKhoa.SelectedItem != null ? cboMaKhoa.SelectedItem.ToString() : cboMaKhoa.Text.Trim();
                string strSoHP = txtSoHocPhan.Text.Trim();
                string giaoVien = txtGiaoVien.Text.Trim();

                // 1. Kiểm tra rỗng
                if (string.IsNullOrEmpty(maMon))
                {
                    MessageBox.Show("Mã môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMon.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tenMon))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMon.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(maKhoa))
                {
                    MessageBox.Show("Vui lòng chọn Mã khoa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaKhoa.Focus();
                    return;
                }

                int soHocPhan;
                if (!int.TryParse(strSoHP, out soHocPhan) || soHocPhan <= 0)
                {
                    MessageBox.Show("Số học phần phải là số nguyên dương lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHocPhan.Focus();
                    return;
                }

                try
                {
                    // 2. Kiểm tra trùng mã môn học theo yêu cầu đề bài
                    string sqlKiemTra = "SELECT COUNT(*) FROM tblMonHoc WHERE Mamon = @Mamon";
                    SqlParameter[] pCheck = new SqlParameter[] {
                        new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMon }
                    };
                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKiemTra, pCheck));

                    if (count > 0)
                    {
                        MessageBox.Show(string.Format("Mã môn học '{0}' đã tồn tại trong cơ sở dữ liệu! Vui lòng chọn mã môn khác.", maMon), "Trùng mã môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaMon.Focus();
                        txtMaMon.SelectAll();
                        return;
                    }

                    // 3. Thực hiện lưu vào CSDL tblMonHoc
                    string sqlInsert = "INSERT INTO tblMonHoc (Mamon, Tenmon, Makhoa, Sohocphan, Giaovien) VALUES (@Mamon, @Tenmon, @Makhoa, @Sohocphan, @Giaovien)";
                    SqlParameter[] pInsert = new SqlParameter[] {
                        new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMon },
                        new SqlParameter("@Tenmon", SqlDbType.NVarChar, 100) { Value = tenMon },
                        new SqlParameter("@Makhoa", SqlDbType.VarChar, 10) { Value = maKhoa },
                        new SqlParameter("@Sohocphan", SqlDbType.Int) { Value = soHocPhan },
                        new SqlParameter("@Giaovien", SqlDbType.NVarChar, 100) { Value = (object)giaoVien ?? DBNull.Value }
                    };

                    DatabaseHelper.ExecuteNonQuery(sqlInsert, pInsert);

                    MessageBox.Show("Thêm mới môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Cập nhật lại ListView
                    LoadDanhSachMonHoc();

                    // 5. Trở về trạng thái ban đầu: nút thành "Thêm", controls mờ đi
                    ThietLapTrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm môn học vào CSDL:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Yêu cầu c: Nút Xóa sáng khi click ListView & xóa khỏi CSDL
        private void lvwMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongTinTuDongChon();
        }

        private void lvwMonHoc_Click(object sender, EventArgs e)
        {
            CapNhatThongTinTuDongChon();
        }

        private void CapNhatThongTinTuDongChon()
        {
            if (lvwMonHoc.SelectedItems.Count > 0)
            {
                // Nếu đang bấm Thêm/Lưu thì không đè dữ liệu
                if (dangThemMoi) return;

                ListViewItem item = lvwMonHoc.SelectedItems[0];
                txtMaMon.Text = item.SubItems[0].Text;
                txtTenMon.Text = item.SubItems[1].Text;

                LoadMaKhoaVaoComboBox();
                cboMaKhoa.SelectedItem = item.SubItems[2].Text;
                if (cboMaKhoa.SelectedIndex == -1) cboMaKhoa.Text = item.SubItems[2].Text;

                txtSoHocPhan.Text = item.SubItems[3].Text;
                txtGiaoVien.Text = item.SubItems.Count > 4 ? item.SubItems[4].Text : "";

                // Yêu cầu c & d: Nút Xóa và Sửa sẽ sáng khi người dùng click vào ListView
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Các ô nhập vẫn để chế độ xem/sửa tùy trạng thái
                txtMaMon.Enabled = false; // Mã môn là khóa chính không sửa
                txtTenMon.Enabled = dangSua;
                cboMaKhoa.Enabled = dangSua;
                txtSoHocPhan.Enabled = dangSua;
                txtGiaoVien.Enabled = dangSua;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwMonHoc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa trên ListView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maMon = lvwMonHoc.SelectedItems[0].SubItems[0].Text;
            string tenMon = lvwMonHoc.SelectedItems[0].SubItems[1].Text;

            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có chắc chắn muốn xóa môn học [{0} - {1}] khỏi CSDL không?\n\n(Lưu ý: Điểm liên quan của môn học này cũng sẽ được xóa)", maMon, tenMon),
                "Xác nhận xóa môn học",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sqlDelete = "DELETE FROM tblMonHoc WHERE Mamon = @Mamon";
                    SqlParameter[] pDelete = new SqlParameter[] {
                        new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMon }
                    };

                    DatabaseHelper.ExecuteNonQuery(sqlDelete, pDelete);

                    MessageBox.Show("Đã xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại ListView
                    LoadDanhSachMonHoc();

                    // Trở về trạng thái ban đầu: nút Xóa, Sửa mờ đi
                    ThietLapTrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa môn học:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Yêu cầu d: Nút Sửa sáng khi click ListView & lưu cập nhật CSDL
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwMonHoc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một môn học trên ListView để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!dangSua)
            {
                // Bật chế độ sửa
                dangSua = true;
                btnSua.Text = "Cập nhật";

                // Cho phép sửa các trường trừ Mã môn (khóa chính)
                txtMaMon.Enabled = false;
                txtTenMon.Enabled = true;
                cboMaKhoa.Enabled = true;
                txtSoHocPhan.Enabled = true;
                txtGiaoVien.Enabled = true;

                LoadMaKhoaVaoComboBox();
                txtTenMon.Focus();
                txtTenMon.SelectAll();
            }
            else
            {
                // Thực hiện lưu dữ liệu đã sửa vào CSDL
                string maMon = txtMaMon.Text.Trim();
                string tenMon = txtTenMon.Text.Trim();
                string maKhoa = cboMaKhoa.SelectedItem != null ? cboMaKhoa.SelectedItem.ToString() : cboMaKhoa.Text.Trim();
                string strSoHP = txtSoHocPhan.Text.Trim();
                string giaoVien = txtGiaoVien.Text.Trim();

                if (string.IsNullOrEmpty(tenMon))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMon.Focus();
                    return;
                }

                int soHocPhan;
                if (!int.TryParse(strSoHP, out soHocPhan) || soHocPhan <= 0)
                {
                    MessageBox.Show("Số học phần phải là số nguyên dương lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHocPhan.Focus();
                    return;
                }

                try
                {
                    string sqlUpdate = "UPDATE tblMonHoc SET Tenmon = @Tenmon, Makhoa = @Makhoa, Sohocphan = @Sohocphan, Giaovien = @Giaovien WHERE Mamon = @Mamon";
                    SqlParameter[] pUpdate = new SqlParameter[] {
                        new SqlParameter("@Tenmon", SqlDbType.NVarChar, 100) { Value = tenMon },
                        new SqlParameter("@Makhoa", SqlDbType.VarChar, 10) { Value = maKhoa },
                        new SqlParameter("@Sohocphan", SqlDbType.Int) { Value = soHocPhan },
                        new SqlParameter("@Giaovien", SqlDbType.NVarChar, 100) { Value = (object)giaoVien ?? DBNull.Value },
                        new SqlParameter("@Mamon", SqlDbType.VarChar, 10) { Value = maMon }
                    };

                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, pUpdate);

                    MessageBox.Show("Cập nhật thông tin môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnSua.Text = "Sửa";
                    dangSua = false;

                    // Cập nhật lại ListView
                    LoadDanhSachMonHoc();

                    // Vô hiệu hóa lại controls
                    ThietLapTrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật môn học:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
