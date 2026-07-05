using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class QLNhanVien : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public QLNhanVien()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadUserData();
            LoadEmployeeData();
            button2.Visible = false;
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        // Lấy dữ liệu khi chọn một dòng trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var nhanVienIDValue = dataGridView1.Rows[e.RowIndex].Cells["NhanVienID"].Value;

                if (nhanVienIDValue != DBNull.Value && nhanVienIDValue != null)
                {
                    int nhanVienID = Convert.ToInt32(nhanVienIDValue);
                    LoadEmployeeDetails(nhanVienID);  
                    this.Refresh();
                }
            }
        }

        //Load dữ liệu người dùng vào combobox
        private void LoadUserData()
        {
            string query = "SELECT UserID, Username FROM NGUOIDUNG";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow row = dataTable.NewRow();
                    row["UserID"] = DBNull.Value;
                    row["Username"] = ""; 
                    dataTable.Rows.InsertAt(row, 0); 

                    materialComboBox4.DisplayMember = "Username";
                    materialComboBox4.ValueMember = "UserID";
                    materialComboBox4.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu người dùng: " + ex.Message);
                }
            }
        }

        private void LoadEmployeeDetails(int nhanVienID)
        {
            string query = "SELECT HoTen, NgaySinh, GTinh, ChucVu, DChi, Sodienthoai, Email, UserID FROM NHANVIEN WHERE NhanVienID = @NhanVienID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@NhanVienID", nhanVienID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialTextBox1.Text = reader["HoTen"].ToString(); 
                        dateTimePicker.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        materialComboBox1.SelectedItem = reader["GTinh"].ToString();  
                        materialTextBox2.Text = reader["Email"].ToString();  
                        materialTextBox3.Text = reader["Sodienthoai"].ToString();  
                        materialTextBox4.Text = reader["DChi"].ToString();  
                        materialTextBox5.Text = reader["ChucVu"].ToString();  
                        materialComboBox4.SelectedValue = reader["UserID"];  
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết nhân viên: " + ex.Message);
                }
            }
        }

        // Hàm tải dữ liệu nhân viên từ cơ sở dữ liệu
        private void LoadEmployeeData()
        {
            string query = "SELECT NhanVienID, HoTen, NgaySinh, GTinh, ChucVu, DChi, Sodienthoai, Email, UserID FROM NHANVIEN";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
                }
            }
        }

        private (string hoTen, DateTime ngaySinh, string gTinh, string chucVu, string diaChi, string soDienThoai, string email, int? userID) GetEmployeeInput()
        {
            string hoTen = materialTextBox1.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            string gTinh = materialComboBox1.SelectedItem?.ToString();
            string chucVu = materialTextBox5.Text;
            string diaChi = materialTextBox4.Text;
            string soDienThoai = materialTextBox3.Text;
            string email = materialTextBox2.Text;
            int? userID = materialComboBox4.SelectedValue as int?;

            return (hoTen, ngaySinh, gTinh, chucVu, diaChi, soDienThoai, email, userID);
        }

        private void ClearInputs()
        {
            materialTextBox1.Clear();
            materialTextBox2.Clear();
            materialTextBox3.Clear();
            materialTextBox4.Clear();
            materialTextBox5.Clear();
            dateTimePicker.Value = DateTime.Now;
            materialComboBox1.SelectedIndex = -1;
            materialComboBox4.SelectedIndex = -1;
        }

        //Kiểm tra tính hợp lệ của UserID trong hệ thống
        private bool IsUserIDDuplicate(int? userID)
        {
            if (userID == null)
            {
                return false; 
            }

            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng UserID: " + ex.Message);
                    return false;
                }
            }
        }

        //Kiểm tra hợp lệ Email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra hợp lệ số điện thoại
        private bool IsValidPhoneNumber(string soDienThoai)
        {
            return soDienThoai.All(char.IsDigit) && soDienThoai.Length >= 10 && soDienThoai.Length <= 15;
        }

        //Kiểm tra độ tuổi hợp lệ tối thiểu 24
        private bool IsAgeValid(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            {
                age--;
            }
            return age >= 22;
        }

        private bool ValidateEmpData()
        {
            string hoTen = materialTextBox1.Text;
            string email = materialTextBox2.Text;
            string soDienThoai = materialTextBox3.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            int? userID = (int?)materialComboBox4.SelectedValue;

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập tên bác sĩ!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return false;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng kiểm tra lại.");
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng kiểm tra lại.");
                return false;
            }

            // Kiểm tra độ tuổi
            if (!IsAgeValid(ngaySinh))
            {
                MessageBox.Show("Bác sĩ phải ít nhất 24 tuổi!");
                return false;
            }

            return true; // Nếu tất cả kiểm tra đều qua, trả về true
        }

        // Hàm kiểm tra trùng giữa nhân viên mới và toàn bộ dữ liệu của nhân viên và bác sĩ
        private bool KiemTraTrung(int nhanVienID, string phoneNumber, string email)
        {
            string query = @"
                    SELECT COUNT(*)
                    FROM (
                        SELECT NhanVienID, Sodienthoai, Email FROM NHANVIEN
                        UNION ALL
                        SELECT NULL AS NhanVienID, Sodienthoai, Email FROM BACSI
                    ) AS CombinedData
                    WHERE (Sodienthoai = @PhoneNumber OR Email = @Email)
                    AND (NhanVienID IS NULL OR NhanVienID != @NhanVienID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp: " + ex.Message);
                    return false;
                }
            }
        }

        // Kiểm tra trùng UserID cho nhân viên khi cập nhật
        private bool KiemTraTrungUserID(int userID, int? nhanVienID)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM (
                SELECT UserID FROM GIAMHO WHERE UserID = @UserID
                UNION ALL
                SELECT UserID FROM NHANVIEN WHERE UserID = @UserID AND NhanVienID != @NhanVienID
                UNION ALL
                SELECT UserID FROM BACSI WHERE UserID = @UserID
            ) AS CombinedUserIDs";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID.HasValue ? nhanVienID.Value : -1);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp UserID khi cập nhật: " + ex.Message);
                    return false;
                }
            }
        }

        // Lấy email của nhân viên từ cơ sở dữ liệu dựa trên NhanVienID
        private string GetEmpEmail(int bacSiID)
        {
            string email = string.Empty;
            string query = "SELECT Email FROM NHANVIEN WHERE NhanVienID = @NhanVienID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NhanVienID", bacSiID);
                        email = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin email nhân viên: " + ex.Message);
                }
            }
            return email;
        }

        // Lấy số điện thoại của nhân viên từ cơ sở dữ liệu
        private string GetEmpPhoneNumber(int bacSiID)
        {
            string soDienThoai = string.Empty;
            string query = "SELECT Sodienthoai FROM NHANVIEN WHERE NhanVienID = @NhanVienID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NhanVienID", bacSiID);
                        soDienThoai = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin số điện thoại nhân viên: " + ex.Message);
                }
            }
            return soDienThoai;
        }

        private int? GetUserID(int nhanVienID)
        {
            int? userID = null; 
            string query = "SELECT UserID FROM NHANVIEN WHERE NhanVienID = @NhanVienID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                        var result = cmd.ExecuteScalar();
                        userID = result != null ? (int?)Convert.ToInt32(result) : null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin UserID: " + ex.Message);
                }
            }
            return userID;
        }


        //Bắt đầu tạo mới dữ liệu - Thêm một nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Refresh();
            button2.Visible = true;
        }

        //Xóa một nhân viên
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int nhanVienID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["NhanVienID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        int? userID = null;
                        string getUserIdQuery = "SELECT UserID FROM NHANVIEN WHERE NhanVienID = @NhanVienID";
                        using (SqlCommand cmd = new SqlCommand(getUserIdQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                            userID = (int?)cmd.ExecuteScalar();
                        }

                        string deleteEmployeeQuery = "DELETE FROM NHANVIEN WHERE NhanVienID = @NhanVienID";
                        using (SqlCommand cmd = new SqlCommand(deleteEmployeeQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                            cmd.ExecuteNonQuery();
                        }

                        if (userID.HasValue)
                        {
                            string deleteUserQuery = "DELETE FROM NGUOIDUNG WHERE UserID = @UserID";
                            using (SqlCommand cmd = new SqlCommand(deleteUserQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserID", userID.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa nhân viên thành công.");
                        LoadEmployeeData(); 
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
            }
        }

        //Cập nhật thông tin nhân viên
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gTinh, chucVu, diaChi, soDienThoai, email, userID) = GetEmployeeInput();

            if (!ValidateEmpData()) return;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int nhanVienID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["NhanVienID"].Value);
                int? originalUserID = GetUserID(nhanVienID);

                if (email != GetEmpEmail(nhanVienID) || soDienThoai != GetEmpPhoneNumber(nhanVienID))
                {
                    if (KiemTraTrung(nhanVienID, soDienThoai, email)) 
                    {
                        MessageBox.Show("Số điện thoại hoặc email đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                if (userID != originalUserID)
                {
                    if (KiemTraTrungUserID(nhanVienID, userID))
                    {
                        MessageBox.Show("UserID đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE NHANVIEN SET HoTen = @HoTen, NgaySinh = @NgaySinh, GTinh = @GTinh, " +
                               "ChucVu = @ChucVu, Email = @Email, Sodienthoai = @Sodienthoai, DChi = @DChi, " +
                               "UserID = @UserID WHERE NhanVienID = @NhanVienID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", hoTen);
                            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            cmd.Parameters.AddWithValue("@GTinh", gTinh);
                            cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Sodienthoai", soDienThoai);
                            cmd.Parameters.AddWithValue("@DChi", diaChi);
                            cmd.Parameters.AddWithValue("@UserID", userID); 
                            cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!");

                            ClearInputs();
                            LoadEmployeeData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật.");
            }
        }

        //Xác nhận dữ liệu và lưu vào SQL
        private void button2_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gTinh, chucVu, diaChi, soDienThoai, email, userID) = GetEmployeeInput();

            if (!ValidateEmpData())
            {
                return;
            }

            if (userID == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản người dùng!");
                return;
            }

            if (IsUserIDDuplicate(userID))
            {
                MessageBox.Show("UserID này đã được sử dụng. Vui lòng chọn một UserID khác.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(soDienThoai) || !string.IsNullOrWhiteSpace(email))
            {
                if (KiemTraTrung(0, soDienThoai, email)) 
                {
                    MessageBox.Show("Số điện thoại hoặc email đã tồn tại. Vui lòng kiểm tra lại.");
                    return;
                }
            }

            string query = "INSERT INTO NHANVIEN (HoTen, NgaySinh, GTinh, ChucVu, Email, Sodienthoai, DChi, UserID) " +
                           "VALUES (@HoTen, @NgaySinh, @GTinh, @ChucVu, @Email, @Sodienthoai, @DChi, @UserID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GTinh", gTinh);
                        cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Sodienthoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@DChi", diaChi);
                        cmd.Parameters.AddWithValue("@UserID", userID); 

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Nhân viên đã được thêm thành công!");
                        LoadEmployeeData(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

        //Chức năng tìm kiếm dựa trên tên, id nhân viên tương đương
        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            string query = "SELECT NhanVienID, HoTen, NgaySinh, GTinh, ChucVu, Sodienthoai, Email, DChi, UserID " +
                           "FROM NHANVIEN ";

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT NhanVienID, HoTen, NgaySinh, GTinh, ChucVu, Sodienthoai, Email, DChi, UserID " +
                        "FROM NHANVIEN";
            }
            else
            {
                query += "WHERE HoTen LIKE @SearchText OR Email LIKE @SearchText OR Sodienthoai LIKE @SearchText";

                if (int.TryParse(searchText, out int nhanVienID))
                {
                    query = "SELECT NhanVienID, HoTen, NgaySinh, GTinh, ChucVu, Sodienthoai, Email, DChi, UserID " +
                            "FROM NHANVIEN WHERE NhanVienID = @NhanVienID";
                }
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (int.TryParse(searchText, out int nhanVienID))
                        {
                            cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        }

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy nhân viên nào.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
                }
            }
        }
    }
}
