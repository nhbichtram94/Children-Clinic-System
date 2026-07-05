using System.Data;





namespace quanlyphongkhamnhi.Forms
{
    public partial class QLUser : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public QLUser()
        {
            InitializeComponent();
            ConfigureDataGridView();
            ConfigureRoleDataGridView();
            LoadRoleData();
            LoadUserData();
            LoadRoleDataGrid();
            button2.Visible = false;
            button4.Visible = false;
        }

        //Đọc dữ liệu vào combobox
        private void LoadRoleData()
        {
            string query = "SELECT RoleID, RoleName FROM VAITRO";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow row = dataTable.NewRow();
                    row["RoleID"] = DBNull.Value;
                    row["RoleName"] = ""; 
                    dataTable.Rows.InsertAt(row, 0); 

                    materialComboBox1.DisplayMember = "RoleName";
                    materialComboBox1.ValueMember = "RoleID";
                    materialComboBox1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vai trò: " + ex.Message);
                }
            }
        }

        private void LoadUserData()
        {
            string query = "SELECT UserID, Username, Matkhau, RoleID FROM NGUOIDUNG";

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
                    MessageBox.Show("Lỗi khi tải dữ liệu người dùng: " + ex.Message);
                }
            }
        }

        private void LoadRoleDataGrid()
        {
            string query = "SELECT RoleID, RoleName FROM VAITRO";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vai trò: " + ex.Message);
                }
            }
        }

        private void LoadUserDetails(int userID)
        {
            string query = "SELECT Username, Matkhau, RoleID FROM NGUOIDUNG WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@UserID", userID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialTextBox1.Text = reader["Username"].ToString();
                        materialTextBox5.Text = reader["Matkhau"].ToString();
                        materialComboBox1.SelectedValue = reader["RoleID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết người dùng: " + ex.Message);
                }
            }
        }

        private void LoadRoleDetails(int roleID)
        {
            string query = "SELECT RoleName FROM VAITRO WHERE RoleID = @RoleID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialTextBox2.Text = reader["RoleName"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết vai trò: " + ex.Message);
                }
            }
        }

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
                var userIDValue = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value;

                if (userIDValue != DBNull.Value && userIDValue != null)
                {
                    int userID = Convert.ToInt32(userIDValue);
                    LoadUserDetails(userID);  
                    this.Refresh();
                }
            }
        }

        private void ConfigureRoleDataGridView()
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
        }

        // Lấy dữ liệu khi chọn một dòng trong DataGridView
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                var roleIDValue = dataGridView2.Rows[e.RowIndex].Cells["RoleID"].Value;

                if (roleIDValue != DBNull.Value && roleIDValue != null)
                {
                    int roleID = Convert.ToInt32(roleIDValue);
                    LoadRoleDetails(roleID);  
                    this.Refresh();
                }
            }
        }


        private (string username, string password, int? roleID) GetUserInput()
        {
            string username = materialTextBox1.Text;
            string password = materialTextBox5.Text;
            int? roleID = materialComboBox1.SelectedValue as int?;

            return (username, password, roleID);
        }

        private string GetRoleInput()
        {
            string roleName = materialTextBox2.Text;
            return roleName;
        }

        // Kiểm tra hợp lệ tên tài khoản
        private bool IsValidUsername(string username)
        {
            // Kiểm tra nếu tên tài khoản không được trống và không chứa khoảng trắng
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên tài khoản không được để trống.");
                return false;
            }

            // Kiểm tra nếu tên tài khoản không chứa ký tự đặc biệt (Chỉ cho phép chữ cái và số)
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(username))
            {
                MessageBox.Show("Tên tài khoản chỉ được chứa chữ cái và số.");
                return false;
            }

            return true;
        }

        // Kiểm tra hợp lệ mật khẩu (ít nhất 8 ký tự)
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.");
                return false;
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của tên vai trò
        private bool IsValidRoleName(string roleName)
        {
            roleName = roleName.Trim();

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Tên vai trò không được để trống.");
                return false;
            }

            foreach (char c in roleName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Tên vai trò chỉ được chứa chữ cái và dấu cách.");
                    return false;
                }
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của dữ liệu người dùng
        private bool ValidateUserData()
        {
            string username = materialTextBox1.Text;
            string password = materialTextBox5.Text;
            int? roleID = (int?)materialComboBox1.SelectedValue;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return false;
            }
            if (roleID == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò người dùng!");
                return false;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự!");
                return false;
            }

            if (!IsValidUsername(username))
            {
                MessageBox.Show("Tên tài khoản chỉ được chứa chữ cái và số, không chứa ký tự đặc biệt.");
                return false;
            }

            return true; 
        }

        // Hàm kiểm tra trùng giữa người dùng mới và toàn bộ dữ liệu
        private bool KiemTraTrung(int userID, string username)
        {
            string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE Username = @Username AND UserID != @UserID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@UserID", userID);

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

        // Hàm kiểm tra trùng tên vai trò
        private bool KiemTraTrungVaiTro(int roleID, string roleName)
        {
            string query = "SELECT COUNT(*) FROM VAITRO WHERE RoleName = @RoleName AND RoleID != @RoleID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", roleName);
                        cmd.Parameters.AddWithValue("@RoleID", roleID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng vai trò: " + ex.Message);
                    return false;
                }
            }
        }

        // Lấy username của nhân viên từ cơ sở dữ liệu dựa trên NhanVienID
        private string GetEmpUsername(int nhanVienID)
        {
            string username = string.Empty;
            string query = "SELECT Username FROM NGUOIDUNG WHERE UserID = (SELECT UserID FROM NHANVIEN WHERE NhanVienID = @NhanVienID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                        username = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin username nhân viên: " + ex.Message);
                }
            }
            return username;
        }

        // Lấy tên vai trò từ cơ sở dữ liệu dựa trên RoleID
        private string GetRoleName(int roleID)
        {
            string roleName = string.Empty;
            string query = "SELECT RoleName FROM VAITRO WHERE RoleID = @RoleID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", roleID);
                        roleName = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin tên vai trò: " + ex.Message);
                }
            }
            return roleName;
        }

        private void ClearInputs()
        {
            materialTextBox1.Clear();
            materialTextBox5.Clear();
            materialComboBox1.SelectedIndex = -1;
        }

        //Bắt đầu clear để thêm một người dùng mới vào hệ thống
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Refresh();
            button2.Visible = true;
        }

        //Sự kiện xóa tài khoản người dùng
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        string updateDoctorQuery = "UPDATE BACSI SET UserID = NULL WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(updateDoctorQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.ExecuteNonQuery();
                        }

                        string updateGuardianQuery = "UPDATE GIAMHO SET UserID = NULL WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(updateGuardianQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.ExecuteNonQuery();
                        }

                        string updateEmployeeQuery = "UPDATE NHANVIEN SET UserID = NULL WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(updateEmployeeQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteUserQuery = "DELETE FROM NGUOIDUNG WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(deleteUserQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa người dùng thành công.");
                        ClearInputs();
                        LoadUserData(); 
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa.");
            }
        }

        //Sự kiện cập nhật tài khoản người dùng
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var (username, password, roleID) = GetUserInput();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || roleID == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin người dùng.");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedUserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                if (username != GetEmpUsername(selectedUserID))
                {
                    if (KiemTraTrung(selectedUserID, username)) 
                    {
                        MessageBox.Show("Tên người dùng đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE NGUOIDUNG SET Username = @Username, Matkhau = @Matkhau, RoleID = @RoleID " +
                               "WHERE UserID = @UserID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Matkhau", password);
                            cmd.Parameters.AddWithValue("@RoleID", roleID); 
                            cmd.Parameters.AddWithValue("@UserID", selectedUserID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin người dùng đã được cập nhật thành công!");
                            LoadUserData(); 
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin người dùng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật.");
            }
        }


        // Sự kiện lưu thông tin người dùng mới vào hệ thống
        private void button2_Click(object sender, EventArgs e)
        {
            var (username, password, roleID) = GetUserInput();

            if (!ValidateUserData())
            {
                return; 
            }

            if (!string.IsNullOrWhiteSpace(username))
            {

                if (KiemTraTrung(0, username)) 
                {
                    MessageBox.Show("Tài khoản này đã tồn tại. Vui lòng chọn tài khoản khác.");
                    return;
                }
            }

            string query = "INSERT INTO NGUOIDUNG (Username, Matkhau, RoleID) VALUES (@Username, @Matkhau, @RoleID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Matkhau", password);
                        cmd.Parameters.AddWithValue("@RoleID", roleID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Người dùng đã được thêm thành công!");

                        LoadUserData();
                        ClearInputs();
                        button2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
                }
            }
        }

        //Tìm một tài khoản
        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            string query = "SELECT UserID, Username, Matkhau, RoleID " +
                           "FROM NGUOIDUNG ";

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT UserID, Username, Matkhau, RoleID " +
                        "FROM NGUOIDUNG";
            }
            else
            {
                query += "WHERE Username LIKE @SearchText OR RoleID LIKE @SearchText";
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy người dùng nào.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm người dùng: " + ex.Message);
                }
            }
        }

        //Dọn sạch input
        private void button5_Click(object sender, EventArgs e)
        {
            materialTextBox2.Clear();
            this.Refresh();
            button4.Visible = true;
        }

        //Lưu vai trò mới
        private void button4_Click(object sender, EventArgs e)
        {
            string roleName = materialTextBox2.Text.Trim();   

            if (!IsValidRoleName(roleName))
            {
                return; 
            }

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                if (KiemTraTrungVaiTro(0, roleName))
                {
                    MessageBox.Show("Vai trò này đã tồn tại. Vui lòng chọn vai trò khác.");
                    return;
                }
            }

            // Câu lệnh SQL để thêm vai trò mới
            string query = "INSERT INTO VAITRO (RoleName) VALUES (@RoleName)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", roleName);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vai trò đã được thêm thành công!");

                        LoadRoleDataGrid();
                        LoadRoleData();
                        materialTextBox2.Clear();
                        button4.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm vai trò: " + ex.Message);
                }
            }
        }

        // Sự kiện xóa vai trò
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["RoleID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        string updateUserQuery = "UPDATE NGUOIDUNG SET RoleID = NULL WHERE RoleID = @RoleID";
                        using (SqlCommand cmd = new SqlCommand(updateUserQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@RoleID", roleID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteRoleQuery = "DELETE FROM VAITRO WHERE RoleID = @RoleID";
                        using (SqlCommand cmd = new SqlCommand(deleteRoleQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@RoleID", roleID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa vai trò thành công.");

                        LoadRoleDataGrid();
                        LoadRoleData();
                        LoadUserData();
                        materialTextBox2.Clear();
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa vai trò: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò để xóa.");
            }
        }

        //Cập nhật vai trò
        private void button6_Click(object sender, EventArgs e)
        {
            var roleName = GetRoleInput();

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tên vai trò.");
                return;
            }

            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedRoleID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["RoleID"].Value);

                if (roleName != GetRoleName(selectedRoleID))
                {
                    if (KiemTraTrungVaiTro(selectedRoleID, roleName)) 
                    {
                        MessageBox.Show("Tên vai trò đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE VAITRO SET RoleName = @RoleName WHERE RoleID = @RoleID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@RoleName", roleName);
                            cmd.Parameters.AddWithValue("@RoleID", selectedRoleID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin vai trò đã được cập nhật thành công!");
                            LoadRoleDataGrid();
                            LoadRoleData();
                            materialTextBox2.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin vai trò: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cần cập nhật.");
            }
        }

        //Tìm kiếm vai trò
        private void button8_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();

            string query = "SELECT RoleID, RoleName FROM VAITRO";

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT RoleID, RoleName FROM VAITRO";
            }
            else
            {
                query += " WHERE RoleName LIKE @SearchText OR RoleID LIKE @SearchText";
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        dataGridView2.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy vai trò nào.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm vai trò: " + ex.Message);
                }
            }
        }
    }
}
