using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using quanlyphongkhamnhi.Utils;


namespace quanlyphongkhamnhi.Forms
{
    public partial class Login : Form
    {
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123"  ;

        public Login()
        {
            InitializeComponent();
            materialLabel1.Visible = false;
        }

        public void LoadForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pictureBox3.Left += 20;
            if (pictureBox3.Left == 360)
            {
                timer1.Stop();
                panel2.BackColor = Color.FromArgb(100, 255, 255, 255);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox3.Left -= 20;
            if (pictureBox3.Left == 0)
            {
                timer3.Stop();
                panel1.BackColor = Color.FromArgb(100, 255, 255, 255);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 255, 255, 255);
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 255, 255, 255);
            timer3.Start();
        }

        //Mục đăng nhập
        private void materialButton1_Click(object sender, EventArgs e)
        {
            string username = materialTextBox1.Text;
            string password = materialTextBox2.Text;
            string query = "SELECT UserID, RoleID FROM NGUOIDUNG WHERE Username = @username AND Matkhau = @password";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Lưu thông tin vào UserSession
                            UserSession.UserID = Convert.ToInt32(reader["UserID"]);
                            UserSession.Username = username;
                            int roleId = Convert.ToInt32(reader["RoleID"]);

                            // Lưu Role vào UserSession
                            switch (roleId)
                            {
                                case 1: // Admin
                                    UserSession.Role = "Admin";
                                    break;
                                case 2: // Bac Si
                                    UserSession.Role = "Bác sĩ";
                                    break;
                                case 3: // Nhan Vien
                                    UserSession.Role = "Nhân viên";
                                    break;
                                case 4: // Giám hộ
                                    UserSession.Role = "Người giám hộ";
                                    break;
                                default:
                                    MessageBox.Show("Role không hợp lệ.");
                                    break;
                            }

                            foreach (Form f in Application.OpenForms)
                            {
                                if (f is Form1)  
                                {
                                    f.Hide(); // Ẩn form HomePage
                                    break; // Chỉ cần ẩn 1 lần
                                }
                            }

                            // Mở form tương ứng và ẩn form Login
                            Form newForm = null;
                            switch (roleId)
                            {
                                case 1:
                                    newForm = new Admin();
                                    break;
                                case 2:
                                    newForm = new BacSi();
                                    break;
                                case 3:
                                    newForm = new NhanVien();
                                    break;
                                case 4:
                                    newForm = new UserHome();
                                    break;
                            }

                            if (newForm != null)
                            {
                                this.Hide(); // Ẩn form đăng nhập
                                newForm.Show(); // Mở form tương ứng
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialLabel1.Visible = true;
            string username = materialTextBox6.Text;
            string password = materialTextBox3.Text;

            var validator = new RegistrationValidator();
            string validationError = validator.Validate(username, password);

            if (validationError != null)
            {
                materialLabel1.ForeColor = Color.Red;
                materialLabel1.Text = validationError;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Kiểm tra username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM NGUOIDUNG WHERE Username = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            materialLabel1.ForeColor = Color.Red;
                            materialLabel1.Text = "Số điện thoại đã tồn tại!";
                            return;
                        }
                    }

                    // Thêm tài khoản mới với RoleID = 4 (Người giám hộ)
                    string insertQuery = "INSERT INTO NGUOIDUNG (Username, Matkhau, RoleID) VALUES (@username, @password, 4)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            materialLabel1.ForeColor = Color.Green;
                            materialLabel1.Text = "Đăng ký thành công!";
                        }
                        else
                        {
                            materialLabel1.ForeColor = Color.Red;
                            materialLabel1.Text = "Đăng ký thất bại, vui lòng thử lại.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                materialLabel1.ForeColor = Color.Red;
                materialLabel1.Text = "Lỗi kết nối cơ sở dữ liệu: " + ex.Message;
            }
        }

    }
}

