using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmDanhMuc : Form
    {
        private TabControl tabControl;
        private TabPage tabHang;
        private TabPage tabNCC;
        private TabPage tabKhach;

        // Tab Hang
        private TextBox txtMahang, txtTenhang, txtDVT;
        private Button btnThemHang, btnSuaHang, btnLuuHang, btnXoaHang;
        private DataGridView dgvHang;
        private bool isThemHang = false;

        // Tab NCC
        private TextBox txtMancc, txtTenncc, txtDiachiNCC;
        private Button btnThemNCC, btnSuaNCC, btnLuuNCC, btnXoaNCC;
        private DataGridView dgvNCC;
        private bool isThemNCC = false;

        // Tab Khach
        private TextBox txtMakh, txtTenkh, txtDiachikh;
        private Button btnThemKhach, btnSuaKhach, btnLuuKhach, btnXoaKhach;
        private DataGridView dgvKhach;
        private bool isThemKhach = false;

        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabHang = new TabPage();
            this.tabNCC = new TabPage();
            this.tabKhach = new TabPage();

            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 9.5F);
            this.tabControl.Controls.Add(this.tabHang);
            this.tabControl.Controls.Add(this.tabNCC);
            this.tabControl.Controls.Add(this.tabKhach);

            BuildTabHang();
            BuildTabNCC();
            BuildTabKhach();

            this.ClientSize = new Size(880, 560);
            this.Controls.Add(this.tabControl);
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Danh mục (Hàng hóa, Nhà cung cấp, Khách hàng)";
            this.Load += new EventHandler(this.frmDanhMuc_Load);
        }

        private void BuildTabHang()
        {
            this.tabHang.Text = "  📦 Mặt hàng (HANG)  ";
            Panel pnlTop = new Panel() { Dock = DockStyle.Top, Height = 140, Padding = new Padding(10) };

            Label l1 = new Label() { Text = "Mã hàng:", Location = new Point(20, 20), AutoSize = true };
            txtMahang = new TextBox() { Location = new Point(100, 17), Width = 150 };

            Label l2 = new Label() { Text = "Tên hàng:", Location = new Point(280, 20), AutoSize = true };
            txtTenhang = new TextBox() { Location = new Point(360, 17), Width = 300 };

            Label l3 = new Label() { Text = "ĐVT:", Location = new Point(680, 20), AutoSize = true };
            txtDVT = new TextBox() { Location = new Point(730, 17), Width = 110 };

            btnThemHang = new Button() { Text = "➕ Thêm", Location = new Point(100, 65), Width = 100, Height = 32, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSuaHang = new Button() { Text = "✏️ Sửa", Location = new Point(215, 65), Width = 100, Height = 32, BackColor = Color.Goldenrod, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLuuHang = new Button() { Text = "💾 Lưu", Location = new Point(330, 65), Width = 100, Height = 32, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnXoaHang = new Button() { Text = "❌ Xóa", Location = new Point(445, 65), Width = 100, Height = 32, BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnThemHang.Click += new EventHandler(btnThemHang_Click);
            btnSuaHang.Click += new EventHandler(btnSuaHang_Click);
            btnLuuHang.Click += new EventHandler(btnLuuHang_Click);
            btnXoaHang.Click += new EventHandler(btnXoaHang_Click);

            pnlTop.Controls.AddRange(new Control[] { l1, txtMahang, l2, txtTenhang, l3, txtDVT, btnThemHang, btnSuaHang, btnLuuHang, btnXoaHang });

            dgvHang = new DataGridView() { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White };
            dgvHang.CellClick += new DataGridViewCellEventHandler(dgvHang_CellClick);

            this.tabHang.Controls.Add(dgvHang);
            this.tabHang.Controls.Add(pnlTop);
        }

        private void BuildTabNCC()
        {
            this.tabNCC.Text = "  🏭 Nhà cung cấp (NCC)  ";
            Panel pnlTop = new Panel() { Dock = DockStyle.Top, Height = 140, Padding = new Padding(10) };

            Label l1 = new Label() { Text = "Mã NCC:", Location = new Point(20, 20), AutoSize = true };
            txtMancc = new TextBox() { Location = new Point(100, 17), Width = 150 };

            Label l2 = new Label() { Text = "Tên NCC:", Location = new Point(280, 20), AutoSize = true };
            txtTenncc = new TextBox() { Location = new Point(360, 17), Width = 480 };

            Label l3 = new Label() { Text = "Địa chỉ:", Location = new Point(20, 60), AutoSize = true };
            txtDiachiNCC = new TextBox() { Location = new Point(100, 57), Width = 740 };

            btnThemNCC = new Button() { Text = "➕ Thêm", Location = new Point(100, 95), Width = 100, Height = 32, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSuaNCC = new Button() { Text = "✏️ Sửa", Location = new Point(215, 95), Width = 100, Height = 32, BackColor = Color.Goldenrod, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLuuNCC = new Button() { Text = "💾 Lưu", Location = new Point(330, 95), Width = 100, Height = 32, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnXoaNCC = new Button() { Text = "❌ Xóa", Location = new Point(445, 95), Width = 100, Height = 32, BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnThemNCC.Click += new EventHandler(btnThemNCC_Click);
            btnSuaNCC.Click += new EventHandler(btnSuaNCC_Click);
            btnLuuNCC.Click += new EventHandler(btnLuuNCC_Click);
            btnXoaNCC.Click += new EventHandler(btnXoaNCC_Click);

            pnlTop.Controls.AddRange(new Control[] { l1, txtMancc, l2, txtTenncc, l3, txtDiachiNCC, btnThemNCC, btnSuaNCC, btnLuuNCC, btnXoaNCC });

            dgvNCC = new DataGridView() { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White };
            dgvNCC.CellClick += new DataGridViewCellEventHandler(dgvNCC_CellClick);

            this.tabNCC.Controls.Add(dgvNCC);
            this.tabNCC.Controls.Add(pnlTop);
        }

        private void BuildTabKhach()
        {
            this.tabKhach.Text = "  👥 Khách hàng (KHACH)  ";
            Panel pnlTop = new Panel() { Dock = DockStyle.Top, Height = 140, Padding = new Padding(10) };

            Label l1 = new Label() { Text = "Mã KH:", Location = new Point(20, 20), AutoSize = true };
            txtMakh = new TextBox() { Location = new Point(100, 17), Width = 150 };

            Label l2 = new Label() { Text = "Tên KH:", Location = new Point(280, 20), AutoSize = true };
            txtTenkh = new TextBox() { Location = new Point(360, 17), Width = 480 };

            Label l3 = new Label() { Text = "Địa chỉ:", Location = new Point(20, 60), AutoSize = true };
            txtDiachikh = new TextBox() { Location = new Point(100, 57), Width = 740 };

            btnThemKhach = new Button() { Text = "➕ Thêm", Location = new Point(100, 95), Width = 100, Height = 32, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSuaKhach = new Button() { Text = "✏️ Sửa", Location = new Point(215, 95), Width = 100, Height = 32, BackColor = Color.Goldenrod, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLuuKhach = new Button() { Text = "💾 Lưu", Location = new Point(330, 95), Width = 100, Height = 32, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnXoaKhach = new Button() { Text = "❌ Xóa", Location = new Point(445, 95), Width = 100, Height = 32, BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnThemKhach.Click += new EventHandler(btnThemKhach_Click);
            btnSuaKhach.Click += new EventHandler(btnSuaKhach_Click);
            btnLuuKhach.Click += new EventHandler(btnLuuKhach_Click);
            btnXoaKhach.Click += new EventHandler(btnXoaKhach_Click);

            pnlTop.Controls.AddRange(new Control[] { l1, txtMakh, l2, txtTenkh, l3, txtDiachikh, btnThemKhach, btnSuaKhach, btnLuuKhach, btnXoaKhach });

            dgvKhach = new DataGridView() { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White };
            dgvKhach.CellClick += new DataGridViewCellEventHandler(dgvKhach_CellClick);

            this.tabKhach.Controls.Add(dgvKhach);
            this.tabKhach.Controls.Add(pnlTop);
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadHang();
            LoadNCC();
            LoadKhach();
        }

        #region Xử lý Tab HANG
        private void LoadHang()
        {
            try
            {
                dgvHang.DataSource = DatabaseHelper.ExecuteDataTable("SELECT Mahang AS [Mã hàng], Tenhang AS [Tên mặt hàng], DVT AS [Đơn vị tính] FROM HANG ORDER BY Mahang");
            }
            catch { }
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHang.Rows.Count)
            {
                DataGridViewRow r = dgvHang.Rows[e.RowIndex];
                txtMahang.Text = r.Cells["Mã hàng"].Value.ToString();
                txtTenhang.Text = r.Cells["Tên mặt hàng"].Value.ToString();
                txtDVT.Text = r.Cells["Đơn vị tính"].Value.ToString();
                txtMahang.Enabled = false;
                btnLuuHang.Enabled = false;
            }
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            isThemHang = true;
            txtMahang.Enabled = true;
            txtMahang.Clear();
            txtTenhang.Clear();
            txtDVT.Text = "Chiếc";
            txtMahang.Focus();
            btnLuuHang.Enabled = true;
        }

        private void btnSuaHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMahang.Text)) return;
            isThemHang = false;
            txtMahang.Enabled = false;
            btnLuuHang.Enabled = true;
            txtTenhang.Focus();
        }

        private void btnLuuHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMahang.Text) || string.IsNullOrEmpty(txtTenhang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã hàng và Tên hàng!");
                return;
            }

            try
            {
                if (isThemHang)
                {
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO HANG (Mahang, Tenhang, DVT) VALUES (@ma, @ten, @dvt)", new SqlParameter[] {
                        new SqlParameter("@ma", txtMahang.Text.Trim()),
                        new SqlParameter("@ten", txtTenhang.Text.Trim()),
                        new SqlParameter("@dvt", txtDVT.Text.Trim())
                    });
                }
                else
                {
                    DatabaseHelper.ExecuteNonQuery("UPDATE HANG SET Tenhang = @ten, DVT = @dvt WHERE Mahang = @ma", new SqlParameter[] {
                        new SqlParameter("@ten", txtTenhang.Text.Trim()),
                        new SqlParameter("@dvt", txtDVT.Text.Trim()),
                        new SqlParameter("@ma", txtMahang.Text.Trim())
                    });
                }
                LoadHang();
                btnLuuHang.Enabled = false;
                txtMahang.Enabled = false;
                MessageBox.Show("Lưu thông tin mặt hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMahang.Text)) return;
            if (MessageBox.Show("Bạn có muốn xóa mặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM HANG WHERE Mahang = @ma", new SqlParameter[] {
                        new SqlParameter("@ma", txtMahang.Text.Trim())
                    });
                    LoadHang();
                    txtMahang.Clear(); txtTenhang.Clear(); txtDVT.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa mặt hàng đã có phát sinh mua/bán! Chi tiết: " + ex.Message);
                }
            }
        }
        #endregion

        #region Xử lý Tab NCC
        private void LoadNCC()
        {
            try
            {
                dgvNCC.DataSource = DatabaseHelper.ExecuteDataTable("SELECT Mancc AS [Mã NCC], Tenncc AS [Tên nhà cung cấp], DiachiNCC AS [Địa chỉ] FROM NCC ORDER BY Mancc");
            }
            catch { }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNCC.Rows.Count)
            {
                DataGridViewRow r = dgvNCC.Rows[e.RowIndex];
                txtMancc.Text = r.Cells["Mã NCC"].Value.ToString();
                txtTenncc.Text = r.Cells["Tên nhà cung cấp"].Value.ToString();
                txtDiachiNCC.Text = r.Cells["Địa chỉ"].Value != null ? r.Cells["Địa chỉ"].Value.ToString() : "";
                txtMancc.Enabled = false;
                btnLuuNCC.Enabled = false;
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            isThemNCC = true;
            txtMancc.Enabled = true;
            txtMancc.Clear();
            txtTenncc.Clear();
            txtDiachiNCC.Clear();
            txtMancc.Focus();
            btnLuuNCC.Enabled = true;
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMancc.Text)) return;
            isThemNCC = false;
            txtMancc.Enabled = false;
            btnLuuNCC.Enabled = true;
            txtTenncc.Focus();
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMancc.Text) || string.IsNullOrEmpty(txtTenncc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã NCC và Tên NCC!");
                return;
            }

            try
            {
                if (isThemNCC)
                {
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO NCC (Mancc, Tenncc, DiachiNCC) VALUES (@ma, @ten, @dc)", new SqlParameter[] {
                        new SqlParameter("@ma", txtMancc.Text.Trim()),
                        new SqlParameter("@ten", txtTenncc.Text.Trim()),
                        new SqlParameter("@dc", txtDiachiNCC.Text.Trim())
                    });
                }
                else
                {
                    DatabaseHelper.ExecuteNonQuery("UPDATE NCC SET Tenncc = @ten, DiachiNCC = @dc WHERE Mancc = @ma", new SqlParameter[] {
                        new SqlParameter("@ten", txtTenncc.Text.Trim()),
                        new SqlParameter("@dc", txtDiachiNCC.Text.Trim()),
                        new SqlParameter("@ma", txtMancc.Text.Trim())
                    });
                }
                LoadNCC();
                btnLuuNCC.Enabled = false;
                txtMancc.Enabled = false;
                MessageBox.Show("Lưu thông tin nhà cung cấp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMancc.Text)) return;
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM NCC WHERE Mancc = @ma", new SqlParameter[] {
                        new SqlParameter("@ma", txtMancc.Text.Trim())
                    });
                    LoadNCC();
                    txtMancc.Clear(); txtTenncc.Clear(); txtDiachiNCC.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa NCC đã có phát sinh hóa đơn mua! Chi tiết: " + ex.Message);
                }
            }
        }
        #endregion

        #region Xử lý Tab KHACH
        private void LoadKhach()
        {
            try
            {
                dgvKhach.DataSource = DatabaseHelper.ExecuteDataTable("SELECT Makh AS [Mã KH], Tenkh AS [Tên khách hàng], Diachikh AS [Địa chỉ] FROM KHACH ORDER BY Makh");
            }
            catch { }
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhach.Rows.Count)
            {
                DataGridViewRow r = dgvKhach.Rows[e.RowIndex];
                txtMakh.Text = r.Cells["Mã KH"].Value.ToString();
                txtTenkh.Text = r.Cells["Tên khách hàng"].Value.ToString();
                txtDiachikh.Text = r.Cells["Địa chỉ"].Value != null ? r.Cells["Địa chỉ"].Value.ToString() : "";
                txtMakh.Enabled = false;
                btnLuuKhach.Enabled = false;
            }
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            isThemKhach = true;
            txtMakh.Enabled = true;
            txtMakh.Clear();
            txtTenkh.Clear();
            txtDiachikh.Clear();
            txtMakh.Focus();
            btnLuuKhach.Enabled = true;
        }

        private void btnSuaKhach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMakh.Text)) return;
            isThemKhach = false;
            txtMakh.Enabled = false;
            btnLuuKhach.Enabled = true;
            txtTenkh.Focus();
        }

        private void btnLuuKhach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMakh.Text) || string.IsNullOrEmpty(txtTenkh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã KH và Tên KH!");
                return;
            }

            try
            {
                if (isThemKhach)
                {
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO KHACH (Makh, Tenkh, Diachikh) VALUES (@ma, @ten, @dc)", new SqlParameter[] {
                        new SqlParameter("@ma", txtMakh.Text.Trim()),
                        new SqlParameter("@ten", txtTenkh.Text.Trim()),
                        new SqlParameter("@dc", txtDiachikh.Text.Trim())
                    });
                }
                else
                {
                    DatabaseHelper.ExecuteNonQuery("UPDATE KHACH SET Tenkh = @ten, Diachikh = @dc WHERE Makh = @ma", new SqlParameter[] {
                        new SqlParameter("@ten", txtTenkh.Text.Trim()),
                        new SqlParameter("@dc", txtDiachikh.Text.Trim()),
                        new SqlParameter("@ma", txtMakh.Text.Trim())
                    });
                }
                LoadKhach();
                btnLuuKhach.Enabled = false;
                txtMakh.Enabled = false;
                MessageBox.Show("Lưu thông tin khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaKhach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMakh.Text)) return;
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM KHACH WHERE Makh = @ma", new SqlParameter[] {
                        new SqlParameter("@ma", txtMakh.Text.Trim())
                    });
                    LoadKhach();
                    txtMakh.Clear(); txtTenkh.Clear(); txtDiachikh.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa khách hàng đã có phát sinh hóa đơn bán! Chi tiết: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
