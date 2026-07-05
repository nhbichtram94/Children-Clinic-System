using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkhamnhi.Forms
{
    public partial class Admin : Form
    {
        bool sidebarExpand;
        bool HomeCollapsed;
        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);
        public Admin()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Load += UserHome_Load;
        }
        private void UserHome_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu UserSession có thông tin username
            if (!string.IsNullOrEmpty(UserSession.Username))
            {
                label2.Text = $"Xin chào, {UserSession.Username}!";
            }
        }

        private void button6_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.QLBacSi());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.QLThuoc());
        }

        private void LoadForm(Form form)
        {
            mainpanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Thêm form vào mainPanel
            mainpanel.Controls.Add(form);
            form.Show();
        }
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            int initialSidebarWidth = 200; // Kích thước sidebar ban đầu
            int initialMainPanelWidth = 1007; // Kích thước ban đầu của mainPanel

            // Cập nhật chiều rộng của sidebar
            if (sidebarExpand)
            {
                // Thu sidebar lại
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebar.Width = sidebar.MinimumSize.Width; 
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                // Mở rộng sidebar
                sidebar.Width += 10;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebar.Width = sidebar.MaximumSize.Width; 
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }

            // Cập nhật kích thước của mainPanel
            if (sidebarExpand) // Nếu sidebar đang mở
            {
                // Giảm chiều rộng của mainPanel khi sidebar mở
                mainpanel.Width = initialMainPanelWidth - (initialSidebarWidth - sidebar.Width);
            }
            else // Nếu sidebar đang đóng
            {
                // Tăng chiều rộng của mainPanel khi sidebar đóng
                mainpanel.Width = initialMainPanelWidth + (initialSidebarWidth - sidebar.Width);
            }

            // Đặt vị trí của mainPanel để nó luôn nằm bên cạnh sidebar
            mainpanel.Location = new Point(sidebar.Width, mainpanel.Location.Y);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        private void HomeTimer_Tick(object sender, EventArgs e)
        {
            if (HomeCollapsed)
            {
                // Thu gọn homeContainer
                homeContainer.Height -= 10;
                if (homeContainer.Height <= homeContainer.MinimumSize.Height)
                {
                    HomeCollapsed = false;
                    HomeTimer.Stop();
                }
            }
            else
            {
                // Mở rộng homeContainer
                homeContainer.Height += 10;
                if (homeContainer.Height >= homeContainer.MaximumSize.Height)
                {
                    HomeCollapsed = true;
                    HomeTimer.Stop();
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            HomeTimer.Start();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                // Phóng to cửa sổ
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                // Khôi phục kích thước ban đầu
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y); 
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Tính toán vị trí mới của form
                Point newLocation = new Point(this.Left + e.X - dragStartPoint.X, this.Top + e.Y - dragStartPoint.Y);
                this.Location = newLocation;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false; // Kết thúc quá trình kéo
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          //  LoadForm(new Forms.BackupRestore());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.DichVu());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.QLUser());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Danh sách thông tin bệnh nhi
            LoadForm(new Forms.QLBenhNhi());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1)
                {
                    f.Show(); 
                    break;
                }
            }
        }

        //Quản lý danh sách nhân viên
        private void button10_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.QLNhanVien());
        }

        //Phòng khoa
        private void button9_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.PhongKhoa());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.QLHoaDon());
        }
    }
}
