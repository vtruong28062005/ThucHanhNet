using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public class frmMain : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuCauHinhServer;
        private ToolStripMenuItem mnuTaoCSDL;
        private ToolStripSeparator mnuSeparator1;
        private ToolStripMenuItem mnuThoat;

        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuQuanLyDiem;
        private ToolStripMenuItem mnuQuanLyMonHoc;

        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuGioiThieu;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblQuickServer;
        private ToolStripStatusLabel lblQuickInit;

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
            this.mnuSeparator1 = new ToolStripSeparator();
            this.mnuThoat = new ToolStripMenuItem();

            this.mnuQuanLy = new ToolStripMenuItem();
            this.mnuQuanLyDiem = new ToolStripMenuItem();
            this.mnuQuanLyMonHoc = new ToolStripMenuItem();

            this.mnuHelp = new ToolStripMenuItem();
            this.mnuGioiThieu = new ToolStripMenuItem();

            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblQuickServer = new ToolStripStatusLabel();
            this.lblQuickInit = new ToolStripStatusLabel();

            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = Color.FromArgb(240, 240, 240);
            this.menuStrip.Font = new Font("Segoe UI", 9.5F);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong,
                this.mnuQuanLy,
                this.mnuHelp
            });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(880, 28);
            this.menuStrip.TabIndex = 0;

            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuCauHinhServer,
                this.mnuTaoCSDL,
                this.mnuSeparator1,
                this.mnuThoat
            });
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new Size(83, 24);
            this.mnuHeThong.Text = "Hệ thống";

            // 
            // mnuCauHinhServer
            // 
            this.mnuCauHinhServer.Name = "mnuCauHinhServer";
            this.mnuCauHinhServer.Size = new Size(260, 26);
            this.mnuCauHinhServer.Text = "Cấu hình SQL Server...";
            this.mnuCauHinhServer.Click += new EventHandler(this.mnuCauHinhServer_Click);

            // 
            // mnuTaoCSDL
            // 
            this.mnuTaoCSDL.Name = "mnuTaoCSDL";
            this.mnuTaoCSDL.Size = new Size(260, 26);
            this.mnuTaoCSDL.Text = "Khởi tạo CSDL & Dữ liệu mẫu";
            this.mnuTaoCSDL.Click += new EventHandler(this.mnuTaoCSDL_Click);

            // 
            // mnuSeparator1
            // 
            this.mnuSeparator1.Name = "mnuSeparator1";
            this.mnuSeparator1.Size = new Size(257, 6);

            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            this.mnuThoat.Size = new Size(260, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new EventHandler(this.mnuThoat_Click);

            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuQuanLyDiem,
                this.mnuQuanLyMonHoc
            });
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new Size(73, 24);
            this.mnuQuanLy.Text = "Quản lý";

            // 
            // mnuQuanLyDiem
            // 
            this.mnuQuanLyDiem.Name = "mnuQuanLyDiem";
            this.mnuQuanLyDiem.ShortcutKeys = Keys.Control | Keys.D;
            this.mnuQuanLyDiem.Size = new Size(244, 26);
            this.mnuQuanLyDiem.Text = "Quản lý điểm";
            this.mnuQuanLyDiem.Click += new EventHandler(this.mnuQuanLyDiem_Click);

            // 
            // mnuQuanLyMonHoc
            // 
            this.mnuQuanLyMonHoc.Name = "mnuQuanLyMonHoc";
            this.mnuQuanLyMonHoc.ShortcutKeys = Keys.Control | Keys.M;
            this.mnuQuanLyMonHoc.Size = new Size(244, 26);
            this.mnuQuanLyMonHoc.Text = "Quản lý môn học";
            this.mnuQuanLyMonHoc.Click += new EventHandler(this.mnuQuanLyMonHoc_Click);

            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuGioiThieu
            });
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new Size(53, 24);
            this.mnuHelp.Text = "Help";

            // 
            // mnuGioiThieu
            // 
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
                this.lblQuickInit
            });
            this.statusStrip.Location = new Point(0, 560);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(880, 26);
            this.statusStrip.TabIndex = 1;

            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(580, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = string.Format("SQL Server: {0} | CSDL: {1}", DatabaseHelper.ServerName, DatabaseHelper.DatabaseName);
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblQuickServer
            // 
            this.lblQuickServer.IsLink = true;
            this.lblQuickServer.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblQuickServer.Name = "lblQuickServer";
            this.lblQuickServer.Size = new Size(100, 20);
            this.lblQuickServer.Text = "[ ⚙ Đổi Server ]";
            this.lblQuickServer.Click += new EventHandler(this.mnuCauHinhServer_Click);

            // 
            // lblQuickInit
            // 
            this.lblQuickInit.IsLink = true;
            this.lblQuickInit.LinkBehavior = LinkBehavior.HoverUnderline;
            this.lblQuickInit.Name = "lblQuickInit";
            this.lblQuickInit.Size = new Size(130, 20);
            this.lblQuickInit.Text = "[ ⚡ Tạo CSDL Mẫu ]";
            this.lblQuickInit.Click += new EventHandler(this.mnuTaoCSDL_Click);

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.AppWorkspace;
            this.ClientSize = new Size(880, 586);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form1";
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
        }

        public void CapNhatThanhTrangThai()
        {
            if (lblStatus != null)
            {
                lblStatus.Text = string.Format("SQL Server: {0} | CSDL: {1}", DatabaseHelper.ServerName, DatabaseHelper.DatabaseName);
            }
        }

        #region Công việc 2: Mở Form frmDiem & frmMonHoc
        private void mnuQuanLyDiem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmDiem)
                {
                    form.Activate();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            frmDiem f = new frmDiem();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuQuanLyMonHoc_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmMonHoc)
                {
                    form.Activate();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            frmMonHoc f = new frmMonHoc();
            f.MdiParent = this;
            f.Show();
        }
        #endregion

        #region Tiện ích Hệ thống & Cấu hình CSDL
        private void mnuCauHinhServer_Click(object sender, EventArgs e)
        {
            string serverHienTai = DatabaseHelper.ServerName;
            string input = ShowInputDialog("Cấu hình SQL Server", "Nhập tên SQL Server (ví dụ: . hoặc .\\SQLEXPRESS hoặc localhost):", serverHienTai);
            if (!string.IsNullOrEmpty(input))
            {
                DatabaseHelper.LuuCauHinhServer(input.Trim());
                CapNhatThanhTrangThai();
                MessageBox.Show(string.Format("Đã cập nhật tên SQL Server: '{0}'", DatabaseHelper.ServerName), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuTaoCSDL_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                string.Format("Bạn có muốn thực thi script tạo CSDL 'QL_Diem' và nạp dữ liệu mẫu lên SQL Server '{0}' không?", DatabaseHelper.ServerName),
                "Xác nhận khởi tạo CSDL",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                string thongBao;
                bool ok = DatabaseHelper.TaoCSDLVaDuLieuMau(out thongBao);
                if (ok)
                {
                    MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới các form con nếu đang mở
                    foreach (Form form in this.MdiChildren)
                    {
                        if (form is frmMonHoc) ((frmMonHoc)form).LoadDanhSachMonHoc();
                        if (form is frmDiem) ((frmDiem)form).LoadDanhSachDiem();
                    }
                }
                else
                {
                    MessageBox.Show(thongBao + "\n\n(Gợi ý: Kiểm tra dịch vụ SQL Server đã khởi động chưa và tên Server đúng chưa)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chương trình Quản lý điểm sinh viên - Lab 9 Bài 2\n" +
                "- Công việc 1: Cơ sở dữ liệu SQL Server (QL_Diem)\n" +
                "- Công việc 2: Form frmMain (Menu điều hướng MDI)\n" +
                "- Công việc 3: Form frmMonHoc (Quản lý môn học)\n" +
                "- Công việc 4: Form frmDiem (Quản lý điểm sinh viên)",
                "Giới thiệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
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

            lbl.SetBounds(15, 15, 370, 35);
            txt.SetBounds(15, 55, 370, 25);
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
