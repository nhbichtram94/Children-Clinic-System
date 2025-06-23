using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkhamnhi.Forms
{
    public partial class HoSoNhanVien : Form
    {
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123"  ;

        public HoSoNhanVien()
        {
            InitializeComponent();
            LoadHoSoNV();
            ReadOnly();
        }

        private void ReadOnly()
        {
            materialTextBox1.Enabled = false;
            materialTextBox2.Enabled= false;
            materialTextBox3.Enabled = false;
            materialTextBox4.Enabled = false;
            materialTextBox5.Enabled = false;
            materialTextBox6.Enabled = false;
            materialTextBox7.Enabled= false;
            materialTextBox8.Enabled = false;
            textBox1.Enabled = false;
            materialButton2.Visible = false;
        }

        private void LoadHoSoNV()
        {
            int userID = UserSession.UserID;

            string query = "SELECT NV.HoTen, NV.NgaySinh, NV.GTinh, NV.ChucVu, NV.DChi, NV.Sodienthoai, NV.Email, ND.Username AS TenTaiKhoan, ND.MatKhau " +
                           "FROM NHANVIEN NV LEFT JOIN NGUOIDUNG ND ON NV.UserID = ND.UserID " +
                           "WHERE NV.UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                materialTextBox1.Text = reader["HoTen"]?.ToString() ?? "";
                                materialTextBox2.Text = reader["NgaySinh"]?.ToString() ?? "";
                                materialTextBox3.Text = reader["GTinh"]?.ToString() ?? "";
                                materialTextBox4.Text = reader["ChucVu"]?.ToString() ?? "";
                                materialTextBox5.Text = reader["DChi"]?.ToString() ?? "";
                                materialTextBox6.Text = reader["Sodienthoai"]?.ToString() ?? "";
                                materialTextBox7.Text = reader["Email"]?.ToString() ?? "";
                                materialTextBox8.Text = reader["TenTaiKhoan"]?.ToString() ?? "";
                                textBox1.Text = reader["MatKhau"]?.ToString() ?? "";
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }
        }

        //Thay đổi thông tin cá nhân
        private void materialButton1_Click(object sender, EventArgs e)
        {
            materialTextBox5.Enabled = true;
            materialTextBox6.Enabled = true;
            materialTextBox7.Enabled = true;
            textBox1.Enabled = true;
            materialButton2.Visible = true;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (!ValidateChanges())
            {
                return;
            }

            string newDChi = materialTextBox5.Text;
            string newSodienthoai = materialTextBox6.Text;
            string newEmail = materialTextBox7.Text;
            string newMatKhau = textBox1.Text; 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"
            UPDATE NHANVIEN
            SET DChi = @DChi, Sodienthoai = @Sodienthoai, Email = @Email
            WHERE UserID = @UserID;
            UPDATE NGUOIDUNG
            SET MatKhau = @MatKhau
            WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DChi", newDChi);
                    cmd.Parameters.AddWithValue("@Sodienthoai", newSodienthoai);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@MatKhau", newMatKhau);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ReadOnly();
                        LoadHoSoNV();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private bool ValidateChanges()
        {
            string newSodienthoai = materialTextBox6.Text;
            string newEmail = materialTextBox7.Text;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Kiểm tra số điện thoại và email trong cả NHANVIEN và BACSI
                string query = @"
            SELECT COUNT(*) FROM NHANVIEN WHERE Sodienthoai = @Sodienthoai OR Email = @Email AND UserID != @UserID
            UNION
            SELECT COUNT(*) FROM BACSI WHERE Sodienthoai = @Sodienthoai OR Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Sodienthoai", newSodienthoai);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Số điện thoại hoặc email đã tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
