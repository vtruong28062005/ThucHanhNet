using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKinhDoanh
{
    public class frmMain : Form
    {
        private MenuStrip menuStrip;

        // Menu Hệ thống
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuCauHinhServer;
        private ToolStripMenuItem mnuTaoCSDL;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuThoat;

        // Menu Nghiệp vụ (Công việc 2)
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuMuaHang;
        private ToolStripMenuItem mnuBanHang;
        private ToolStripSeparator mnuSep2;
        private ToolStripMenuItem mnuDanhMuc;

        // Menu Thống kê & Tìm kiếm (Công việc 3)
        private ToolStripMenuItem mnuThongKe;
        private ToolStripMenuItem mnuThongKeMua;
        private ToolStripMenuItem mnuThongKeBan;
        private ToolStripSeparator mnuSep3;
        private ToolStripMenuItem mnuTimKiemBanHang;

        // Menu Cửa sổ
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileH;
        private ToolStripMenuItem mnuTileV;
        private ToolStripSeparator mnuSep4;
        private ToolStripMenuItem mnuDongTatCa;

        // Menu Trợ giúp
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuGioiThieu;

        // StatusStrip
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblQuickServer;
        private ToolStripStatusLabel lblQuickInit;
        private ToolStripStatusLabel lblTime;
        private Timer timerClock;

        public frmMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuCauHinhServer = new ToolStripMenuItem();
            this.mnuTaoCSDL = new ToolStripMenuItem();
            this.mnuSep1 = new ToolStripSeparator();
            this.mnuThoat = new ToolStripMenuItem();

            this.mnuNghiepVu = new ToolStripMenuItem();
            this.mnuMuaHang = new ToolStripMenuItem();
            this.mnuBanHang = new ToolStripMenuItem();
            this.mnuSep2 = new ToolStripSeparator();
            this.mnuDanhMuc = new ToolStripMenuItem();

            this.mnuThongKe = new ToolStripMenuItem();
            this.mnuThongKeMua = new ToolStripMenuItem();
            this.mnuThongKeBan = new ToolStripMenuItem();
            this.mnuSep3 = new ToolStripSeparator();
            this.mnuTimKiemBanHang = new ToolStripMenuItem();

            this.mnuCuaSo = new ToolStripMenuItem();
            this.mnuCascade = new ToolStripMenuItem();
            this.mnuTileH = new ToolStripMenuItem();
            this.mnuTileV = new ToolStripMenuItem();
            this.mnuSep4 = new ToolStripSeparator();
            this.mnuDongTatCa = new ToolStripMenuItem();

            this.mnuTroGiup = new ToolStripMenuItem();
            this.mnuGioiThieu = new ToolStripMenuItem();

            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblQuickServer = new ToolStripStatusLabel();
            this.lblQuickInit = new ToolStripStatusLabel();
            this.lblTime = new ToolStripStatusLabel();

            this.timerClock = new Timer();

            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = Color.FromArgb(240, 243, 246);
            this.menuStrip.Font = new Font("Segoe UI", 9.5F);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong,
                this.mnuNghiepVu,
                this.mnuThongKe,
                this.mnuCuaSo,
                this.mnuTroGiup
            });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(1008, 29);
            this.menuStrip.TabIndex = 0;

            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuCauHinhServer,
                this.mnuTaoCSDL,
                this.mnuSep1,
                this.mnuThoat
            });
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new Size(85, 25);
            this.mnuHeThong.Text = "📁 Hệ thống";

            // mnuCauHinhServer
            this.mnuCauHinhServer.Name = "mnuCauHinhServer";
            this.mnuCauHinhServer.Size = new Size(270, 26);
            this.mnuCauHinhServer.Text = "⚙ Cấu hình SQL Server...";
            this.mnuCauHinhServer.Click += new EventHandler(this.mnuCauHinhServer_Click);

            // mnuTaoCSDL
            this.mnuTaoCSDL.Name = "mnuTaoCSDL";
            this.mnuTaoCSDL.Size = new Size(270, 26);
            this.mnuTaoCSDL.Text = "⚡ Khởi tạo CSDL & Dữ liệu mẫu";
            this.mnuTaoCSDL.Click += new EventHandler(this.mnuTaoCSDL_Click);

            // mnuSep1
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new Size(267, 6);

            // mnuThoat
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            this.mnuThoat.Size = new Size(270, 26);
            this.mnuThoat.Text = "🚪 Thoát";
            this.mnuThoat.Click += new EventHandler(this.mnuThoat_Click);

            // 
            // mnuNghiepVu
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuMuaHang,
                this.mnuBanHang,
                this.mnuSep2,
                this.mnuDanhMuc
            });
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new Size(93, 25);
            this.mnuNghiepVu.Text = "💼 Nghiệp vụ";

            // mnuMuaHang (Công việc 2)
            this.mnuMuaHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.mnuMuaHang.ForeColor = Color.DarkSlateBlue;
            this.mnuMuaHang.Name = "mnuMuaHang";
            this.mnuMuaHang.ShortcutKeys = Keys.Control | Keys.M;
            this.mnuMuaHang.Size = new Size(330, 26);
            this.mnuMuaHang.Text = "🛒 Quản lý Mua hàng (CV 2)";
            this.mnuMuaHang.Click += new EventHandler(this.mnuMuaHang_Click);

            // mnuBanHang
            this.mnuBanHang.Name = "mnuBanHang";
            this.mnuBanHang.ShortcutKeys = Keys.Control | Keys.B;
            this.mnuBanHang.Size = new Size(330, 26);
            this.mnuBanHang.Text = "🏷️ Quản lý Bán hàng";
            this.mnuBanHang.Click += new EventHandler(this.mnuBanHang_Click);

            // mnuSep2
            this.mnuSep2.Name = "mnuSep2";
            this.mnuSep2.Size = new Size(327, 6);

            // mnuDanhMuc
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.ShortcutKeys = Keys.Control | Keys.D;
            this.mnuDanhMuc.Size = new Size(330, 26);
            this.mnuDanhMuc.Text = "📦 Danh mục (Hàng, NCC, Khách)";
            this.mnuDanhMuc.Click += new EventHandler(this.mnuDanhMuc_Click);

            // 
            // mnuThongKe
            // 
            this.mnuThongKe.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuThongKeMua,
                this.mnuThongKeBan,
                this.mnuSep3,
                this.mnuTimKiemBanHang
            });
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new Size(168, 25);
            this.mnuThongKe.Text = "📊 Thống kê & Tìm kiếm";

            // mnuThongKeMua (Công việc 3a)
            this.mnuThongKeMua.Name = "mnuThongKeMua";
            this.mnuThongKeMua.ShortcutKeys = Keys.Control | Keys.D1;
            this.mnuThongKeMua.Size = new Size(330, 26);
            this.mnuThongKeMua.Text = "📈 Thống kê Hàng Mua (CV 3a)";
            this.mnuThongKeMua.Click += new EventHandler(this.mnuThongKeMua_Click);

            // mnuThongKeBan (Công việc 3b)
            this.mnuThongKeBan.Name = "mnuThongKeBan";
            this.mnuThongKeBan.ShortcutKeys = Keys.Control | Keys.D2;
            this.mnuThongKeBan.Size = new Size(330, 26);
            this.mnuThongKeBan.Text = "📉 Thống kê Hàng Bán (CV 3b)";
            this.mnuThongKeBan.Click += new EventHandler(this.mnuThongKeBan_Click);

            // mnuSep3
            this.mnuSep3.Name = "mnuSep3";
            this.mnuSep3.Size = new Size(327, 6);

            // mnuTimKiemBanHang (Công việc 3c)
            this.mnuTimKiemBanHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.mnuTimKiemBanHang.ForeColor = Color.DarkSlateBlue;
            this.mnuTimKiemBanHang.Name = "mnuTimKiemBanHang";
            this.mnuTimKiemBanHang.ShortcutKeys = Keys.Control | Keys.F;
            this.mnuTimKiemBanHang.Size = new Size(330, 26);
            this.mnuTimKiemBanHang.Text = "🔍 Tìm kiếm Hàng Bán (CV 3c)";
            this.mnuTimKiemBanHang.Click += new EventHandler(this.mnuTimKiemBanHang_Click);

            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuCascade,
                this.mnuTileH,
                this.mnuTileV,
                this.mnuSep4,
                this.mnuDongTatCa
            });
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new Size(72, 25);
            this.mnuCuaSo.Text = "🪟 Cửa sổ";

            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new Size(207, 26);
            this.mnuCascade.Text = "Xếp tầng (Cascade)";
            this.mnuCascade.Click += new EventHandler(this.mnuCascade_Click);

            this.mnuTileH.Name = "mnuTileH";
            this.mnuTileH.Size = new Size(207, 26);
            this.mnuTileH.Text = "Xếp ngang";
            this.mnuTileH.Click += new EventHandler(this.mnuTileH_Click);

            this.mnuTileV.Name = "mnuTileV";
            this.mnuTileV.Size = new Size(207, 26);
            this.mnuTileV.Text = "Xếp dọc";
            this.mnuTileV.Click += new EventHandler(this.mnuTileV_Click);

            this.mnuSep4.Name = "mnuSep4";
            this.mnuSep4.Size = new Size(204, 6);

            this.mnuDongTatCa.Name = "mnuDongTatCa";
            this.mnuDongTatCa.Size = new Size(207, 26);
            this.mnuDongTatCa.Text = "Đóng tất cả";
            this.mnuDongTatCa.Click += new EventHandler(this.mnuDongTatCa_Click);

            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuGioiThieu
            });
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new Size(78, 25);
            this.mnuTroGiup.Text = "❓ Trợ giúp";

            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new Size(224, 26);
            this.mnuGioiThieu.Text = "Giới thiệu chương trình";
            this.mnuGioiThieu.Click += new EventHandler(this.mnuGioiThieu_Click);

            // 
            // statusStrip
            // 
            this.statusStrip.Font = new Font("Segoe UI", 9F);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatus,
                this.lblQuickServer,
                this.lblQuickInit,
                this.lblTime
            });
            this.statusStrip.Location = new Point(0, 655);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1008, 26);
            this.statusStrip.TabIndex = 1;

            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(580, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = string.Format("SQL Server: {0} | CSDL: {1}", DatabaseHelper.ServerName, DatabaseHelper.DatabaseName);
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // lblQuickServer
            this.lblQuickServer.IsLink = true;
            this.lblQuickServer.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblQuickServer.Name = "lblQuickServer";
            this.lblQuickServer.Size = new Size(100, 20);
            this.lblQuickServer.Text = "[ ⚙ Đổi Server ]";
            this.lblQuickServer.Click += new EventHandler(this.mnuCauHinhServer_Click);

            // lblQuickInit
            this.lblQuickInit.IsLink = true;
            this.lblQuickInit.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblQuickInit.Name = "lblQuickInit";
            this.lblQuickInit.Size = new Size(130, 20);
            this.lblQuickInit.Text = "[ ⚡ Tạo CSDL QLKD ]";
            this.lblQuickInit.Click += new EventHandler(this.mnuTaoCSDL_Click);

            // lblTime
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new Size(140, 20);
            this.lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // timerClock
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new EventHandler(this.timerClock_Tick);
            this.timerClock.Start();

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.AppWorkspace;
            this.ClientSize = new Size(1008, 681);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ KINH DOANH CỬA HÀNG (LAB 9 - BÀI 3)";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.frmMain_Load);
            this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CapNhatThanhTrangThai();

            // Mở form Mua hàng (Công việc 2) làm form mặc định
            MoFormMuaHang();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public void CapNhatThanhTrangThai()
        {
            if (lblStatus != null)
            {
                lblStatus.Text = string.Format("SQL Server: {0} | CSDL: {1}", DatabaseHelper.ServerName, DatabaseHelper.DatabaseName);
            }
        }

        private void MoFormCon(Form formCon)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formCon.GetType())
                {
                    f.Activate();
                    formCon.Dispose();
                    return;
                }
            }

            formCon.MdiParent = this;
            formCon.Show();
        }

        #region Mở các Form Nghiệp vụ & Thống kê
        public void MoFormMuaHang()
        {
            MoFormCon(new frmMuaHang());
        }

        public void MoFormBanHang()
        {
            MoFormCon(new frmBanHang());
        }

        public void MoFormThongKeMua()
        {
            MoFormCon(new frmThongKeMua());
        }

        public void MoFormThongKeBan()
        {
            MoFormCon(new frmThongKeBan());
        }

        public void MoFormTimKiemBanHang()
        {
            MoFormCon(new frmTimKiemBanHang());
        }

        public void MoFormDanhMuc()
        {
            MoFormCon(new frmDanhMuc());
        }

        private void mnuMuaHang_Click(object sender, EventArgs e)
        {
            MoFormMuaHang();
        }

        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            MoFormBanHang();
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
            MoFormDanhMuc();
        }

        private void mnuThongKeMua_Click(object sender, EventArgs e)
        {
            MoFormThongKeMua();
        }

        private void mnuThongKeBan_Click(object sender, EventArgs e)
        {
            MoFormThongKeBan();
        }

        private void mnuTimKiemBanHang_Click(object sender, EventArgs e)
        {
            MoFormTimKiemBanHang();
        }
        #endregion

        #region Cửa sổ
        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }
        #endregion

        #region Hệ thống & Cấu hình
        private void mnuCauHinhServer_Click(object sender, EventArgs e)
        {
            using (Form frmCfg = new Form())
            {
                frmCfg.Text = "Cấu hình Kết nối SQL Server";
                frmCfg.Size = new Size(420, 190);
                frmCfg.StartPosition = FormStartPosition.CenterParent;
                frmCfg.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmCfg.MaximizeBox = false;
                frmCfg.MinimizeBox = false;

                Label lbl = new Label() { Text = "Tên Máy chủ / SQL Server Instance:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
                TextBox txt = new TextBox() { Text = DatabaseHelper.ServerName, Location = new Point(20, 48), Width = 360, Font = new Font("Segoe UI", 9.5F) };

                Button btnLuuServer = new Button() { Text = "Lưu cấu hình", DialogResult = DialogResult.OK, Location = new Point(140, 95), Width = 110, Height = 32 };
                Button btnDong = new Button() { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(265, 95), Width = 115, Height = 32 };

                frmCfg.Controls.AddRange(new Control[] { lbl, txt, btnLuuServer, btnDong });
                frmCfg.AcceptButton = btnLuuServer;
                frmCfg.CancelButton = btnDong;

                if (frmCfg.ShowDialog(this) == DialogResult.OK)
                {
                    string sv = txt.Text.Trim();
                    if (!string.IsNullOrEmpty(sv))
                    {
                        DatabaseHelper.LuuCauHinhServer(sv);
                        CapNhatThanhTrangThai();
                        MessageBox.Show("Đã cập nhật tên SQL Server thành công: " + sv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void mnuTaoCSDL_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn khởi tạo lại CSDL 'QLKD' và nạp dữ liệu mẫu 7 bảng không?\n(Dữ liệu cũ nếu có sẽ được làm mới sạch sẽ theo file QLKD.sql)",
                "Xác nhận khởi tạo CSDL QLKD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                string thongBao;
                bool ok = DatabaseHelper.TaoCSDLVaDuLieuMau(out thongBao);
                Cursor.Current = Cursors.Default;

                if (ok)
                {
                    MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới lại các form đang mở
                    foreach (Form f in this.MdiChildren)
                    {
                        f.Close();
                    }
                    MoFormMuaHang();
                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn thoát chương trình Quản lý kinh doanh?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            string thongTin = "LAB 09 - BÀI TẬP VỀ NHÀ SỐ 3\n" +
                              "Đề tài: Quản lý kinh doanh (QLKD)\n\n" +
                              "Các công việc đã hoàn thành:\n" +
                              "✔ Công việc 1: CSDL QLKD với 7 bảng (NCC, HANG, KHACH, HDMUA, CHITIETMUA, HDBAN, CHITIETBAN) cùng khóa chính, khóa ngoại, dữ liệu mẫu thực tế.\n" +
                              "✔ Công việc 2: Form Mua Hàng trực quan với lưới hiển thị và các nút Thêm, Sửa, Lưu, Xóa, Thoát.\n" +
                              "✔ Công việc 3a: Form Thống kê Hàng Mua (Tên hàng, ĐVT, NCC, Ngày mua, SL mua, Đơn giá mua, Thành tiền).\n" +
                              "✔ Công việc 3b: Form Thống kê Hàng Bán (Tên hàng, ĐVT, Khách hàng, Ngày bán, SL bán, Đơn giá bán, Thành tiền).\n" +
                              "✔ Công việc 3c: Form Tìm kiếm Hàng Bán theo Số HĐB chi tiết.\n" +
                              "✔ Công việc 4: Giao diện chính MDI Form kết nối tất cả các chức năng qua Menu, phím tắt nhanh và thanh trạng thái.";

            MessageBox.Show(thongTin, "Giới thiệu chương trình", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
