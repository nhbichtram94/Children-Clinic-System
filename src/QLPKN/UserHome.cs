using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class UserHome : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        bool sidebarExpand;
        bool HomeCollapsed;
        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public UserHome()
        {
            InitializeComponent();
            button6.Click += Button6_Click_TrangChu;
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Load += UserHome_Load;
            label3.Visible = false;
            button10.Visible = false;
        }

        //Đọc vai trò và thông tin cá nhân
        private void UserHome_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu UserSession có thông tin username
            if (!string.IsNullOrEmpty(UserSession.Username))
            {
                // Hiển thị câu chào "Xin chào, username!" lên label2
                label2.Text = $"Xin chào, {UserSession.Username}!";
            }
            CheckUserProfile();
        }

        private void CheckUserProfile()
        {
            string query = @"
                        SELECT COUNT(*) 
                        FROM GIAMHO gh
                        JOIN NGUOIDUNG nd ON gh.UserID = nd.UserID
                        WHERE nd.Username = @username";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho câu truy vấn
                        cmd.Parameters.AddWithValue("@username", UserSession.Username);

                        // Thực thi câu truy vấn và lấy kết quả
                        int userCount = (int)cmd.ExecuteScalar();

                        // Nếu không tìm thấy UserID trong bảng GIAMHO (userCount = 0), hiển thị thông báo
                        if (userCount == 0)
                        {
                            label3.Visible = true;
                            button10.Visible = true;
                            label3.Text = "Bạn chưa có thông tin cá nhân. Vui lòng cập nhật thông tin!";
                        }
                        else
                        {
                            label3.Visible = false;
                            button10.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
        private void Button6_Click_TrangChu(object? sender, EventArgs e)
        {
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

            LoadForm(new Forms.TrangchuGH());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

            LoadForm(new Forms.HoSoBenhAn());
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

            mainpanel.Location = new Point(sidebar.Width, mainpanel.Location.Y);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

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

        private int? GetGiamHoID(int userID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT GiamHoID FROM GIAMHO WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    var result = cmd.ExecuteScalar();
                    return result as int?;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra thông tin giám hộ: " + ex.Message);
                    return null;
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

        private void button4_Click(object sender, EventArgs e)
        {
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

            LoadForm(new Forms.PhieuKham());
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
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

            LoadForm(new Forms.BenhNhi());
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //Hồ sơ cá nhân
            LoadForm(new Forms.DienHoSo());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int? giamHoID = GetGiamHoID(UserSession.UserID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không có thông tin giám hộ. Không thể thực hiện thao tác này.");
                return;
            }

            LoadForm(new Forms.DatKham());
        }
    }
}
