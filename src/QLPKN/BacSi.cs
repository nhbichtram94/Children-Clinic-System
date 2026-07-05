using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class BacSi : Form
    {
        bool sidebarExpand;
        bool HomeCollapsed;
        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public BacSi()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Load += BacSiHome_Load;
        }

        //Đọc vai trò và thông tin cá nhân
        private void BacSiHome_Load(object sender, EventArgs e)
        {
            try
            {
                int bacsiID = UserSession.UserID; // Lấy ID bác sĩ từ UserSession
                string query = "SELECT HoTen FROM BACSI WHERE UserID = @bacsiID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacsiID);
                        string tenBacSi = cmd.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(tenBacSi))
                        {
                            MessageBox.Show("Không tìm thấy thông tin bác sĩ!");
                            return;
                        }

                        // Hiển thị tên bác sĩ lên Label2
                        label2.Text = $"Xin chào, bác sĩ {tenBacSi}!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bác sĩ: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.KhamBenh());
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
            int initialSidebarWidth = 200; 
            int initialMainPanelWidth = 1007; 

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

            if (sidebarExpand) // Nếu sidebar đang mở
            {
                mainpanel.Width = initialMainPanelWidth - (initialSidebarWidth - sidebar.Width);
            }
            else // Nếu sidebar đang đóng
            {
                mainpanel.Width = initialMainPanelWidth + (initialSidebarWidth - sidebar.Width);
            }

            mainpanel.Location = new Point(sidebar.Width, mainpanel.Location.Y);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.TrangchuGH());
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
                dragStartPoint = new Point(e.X, e.Y); // Lưu tọa độ khi bắt đầu kéo
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


        //Sự kiện đăng xuất
        private void button5_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại (nếu là form con của HomePage)
            this.Close();

            // Kiểm tra và hiển thị lại form HomePage
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1)
                {
                    f.Show(); // Hiển thị lại HomePage (Form1)
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new Forms.HoSoBS());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Forms.KeDonThuoc());
        }
    }
}
