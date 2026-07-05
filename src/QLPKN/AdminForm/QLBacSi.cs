using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class QLBacSi : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connString = ""Data Source = DESKTOP - 35FGUEF;Initial Catalog = QLPKN; User ID = sa; Password=Tram@942004";

        public QLBacSi()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadChuyenKhoaData();
            LoadPhongLamViecData();
            LoadUserData();
            LoadDoctorData();
            button2.Visible = false;
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
                var bacSiIDValue = dataGridView1.Rows[e.RowIndex].Cells["BacSiID"].Value;

                if (bacSiIDValue != DBNull.Value && bacSiIDValue != null)
                {
                    int bacSiID = Convert.ToInt32(bacSiIDValue);
                    LoadDoctorDetails(bacSiID);
                    this.Refresh();
                }
            }
        }

        // Kiểm tra xem UserID đã tồn tại hay chưa (chỉ kiểm tra khi UserID khác NULL)
        private bool IsUserIDDuplicate(int? userID)
        {
            if (userID == null)
            {
                return false; // Không kiểm tra nếu UserID là NULL
            }

            string query = @"
                            SELECT COUNT(*) 
                            FROM (
                                SELECT UserID FROM GIAMHO WHERE UserID = @UserID
                                UNION ALL
                                SELECT UserID FROM NHANVIEN WHERE UserID = @UserID
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

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Trả về true nếu UserID đã tồn tại trong bất kỳ bảng nào
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
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra xem số điện thoại có phải là chuỗi số và có độ dài hợp lý không
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 10 && phoneNumber.Length <= 15;
        }

        //Kiểm tra độ tuổi hợp lệ tối thiểu 24
        private bool IsAgeValid(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            {
                age--;
            }
            return age >= 24;
        }

        //Kiểm tra nhập liệu đầy đủ
        private bool ValidateDoctorData()
        {
            string hoTen = materialTextBox1.Text;
            string email = materialTextBox2.Text;
            string phoneNumber = materialTextBox3.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            int? userID = (int?)materialComboBox4.SelectedValue;

            // Kiểm tra xem các trường có bị bỏ trống không
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
            if (string.IsNullOrWhiteSpace(phoneNumber))
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
            if (!IsValidPhoneNumber(phoneNumber))
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


        private void LoadDoctorDetails(int bacSiID)
        {
            string query = "SELECT HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID FROM BACSI WHERE BacSiID = @BacSiID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@BacSiID", bacSiID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Gán các giá trị từ cơ sở dữ liệu vào các TextBox và ComboBox
                        materialTextBox1.Text = reader["HoTen"].ToString();
                        dateTimePicker.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        materialComboBox1.SelectedItem = reader["GTinh"].ToString();
                        materialComboBox2.SelectedValue = reader["ChuyenKhoaID"];
                        materialTextBox2.Text = reader["Email"].ToString();
                        materialTextBox3.Text = reader["Sodienthoai"].ToString();
                        materialTextBox4.Text = reader["DChi"].ToString();
                        materialComboBox3.SelectedValue = reader["PhongID"];
                        materialComboBox4.SelectedValue = reader["UserID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết bác sĩ: " + ex.Message);
                }
            }
        }

        //Lấy dữ liệu bác sĩ từ input
        private (string hoTen, DateTime ngaySinh, string gioiTinh, int chuyenKhoaID, string email, string phoneNumber, string diaChi, int phongID, int? userID) GetDoctorData()
        {
            string hoTen = materialTextBox1.Text;
            DateTime ngaySinh = dateTimePicker.Value;
            string gioiTinh = materialComboBox1.Text;
            int chuyenKhoaID = (int)materialComboBox2.SelectedValue;
            string email = materialTextBox2.Text;
            string phoneNumber = materialTextBox3.Text;
            string diaChi = materialTextBox4.Text;
            int phongID = (int)materialComboBox3.SelectedValue;
            int? userID = (int?)materialComboBox4.SelectedValue;

            return (hoTen, ngaySinh, gioiTinh, chuyenKhoaID, email, phoneNumber, diaChi, phongID, userID);
        }

        private int? GetUserID(int bacSiID)
        {
            int? userID = null; // Khởi tạo với giá trị null
            string query = "SELECT UserID FROM BACSI WHERE BacSiID = @BacSiID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                        var result = cmd.ExecuteScalar();
                        // Kiểm tra nếu kết quả không phải null, chuyển sang kiểu int?
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

        // Hàm tải dữ liệu bác sĩ từ cơ sở dữ liệu  
        private void LoadDoctorData()
        {
            string query = "SELECT BacSiID, HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID FROM BACSI";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu bác sĩ: " + ex.Message);
                }
            }
        }

        // Phương thức tải dữ liệu từ bảng PHONGLAMVIEC vào materialComboBox3
        private void LoadPhongLamViecData()
        {
            string query = "SELECT PhongID, TenPhong FROM PHONGLAMVIEC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Thiết lập ComboBox để hiển thị tên phòng và lưu PhongID
                    materialComboBox3.DisplayMember = "TenPhong";  // Tên phòng làm việc hiển thị
                    materialComboBox3.ValueMember = "PhongID";     // Giá trị ID phòng làm việc
                    materialComboBox3.DataSource = dataTable;  // Gán dữ liệu vào ComboBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu phòng làm việc: " + ex.Message);
                }
            }
        }

        // Phương thức tải dữ liệu từ bảng NGUOIDUNG vào materialComboBox4
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

                    // Thêm một dòng trống vào dataTable để có lựa chọn trống trong ComboBox
                    DataRow row = dataTable.NewRow();
                    row["UserID"] = DBNull.Value;
                    row["Username"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(row, 0); // Thêm dòng này vào đầu bảng

                    // Gán dữ liệu vào ComboBox
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

        // Phương thức tải dữ liệu từ bảng CHUYENKHOA vào materialComboBox2
        private void LoadChuyenKhoaData()
        {
            string query = "SELECT ChuyenKhoaID, TenChuyenKhoa FROM CHUYENKHOA";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Thiết lập ComboBox để hiển thị tên chuyên khoa và lưu ChuyenKhoaID
                    materialComboBox2.DisplayMember = "TenChuyenKhoa";  // Tên chuyên khoa hiển thị
                    materialComboBox2.ValueMember = "ChuyenKhoaID";     // Giá trị ID chuyên khoa
                    materialComboBox2.DataSource = dataTable;  // Gán dữ liệu vào ComboBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu chuyên khoa: " + ex.Message);
                }
            }
        }

        //Sự kiện xóa
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int bacSiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BacSiID"].Value);

                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        // Xóa hồ sơ bệnh án liên quan đến bác sĩ
                        string deleteHoSoBenhAnQuery = "DELETE FROM HOSOBENHAN WHERE BacSiID = @BacSiID";
                        using (SqlCommand cmd = new SqlCommand(deleteHoSoBenhAnQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                            cmd.ExecuteNonQuery();
                        }

                        int? userID = null;
                        // Lấy UserID của bác sĩ trước khi xóa bác sĩ
                        string getUserIdQuery = "SELECT UserID FROM BACSI WHERE BacSiID = @BacSiID";
                        using (SqlCommand cmd = new SqlCommand(getUserIdQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                            userID = (int?)cmd.ExecuteScalar();
                        }

                        // Xóa bác sĩ khỏi bảng BACSI
                        string deleteDoctorQuery = "DELETE FROM BACSI WHERE BacSiID = @BacSiID";
                        using (SqlCommand cmd = new SqlCommand(deleteDoctorQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa tài khoản người dùng từ bảng NGUOIDUNG nếu UserID tồn tại
                        if (userID.HasValue)
                        {
                            string deleteUserQuery = "DELETE FROM NGUOIDUNG WHERE UserID = @UserID";
                            using (SqlCommand cmd = new SqlCommand(deleteUserQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserID", userID.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Commit transaction nếu mọi thứ suôn sẻ
                        transaction.Commit();
                        MessageBox.Show("Đã xóa bác sĩ và thông tin liên quan thành công.");
                        LoadDoctorData();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa bác sĩ: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bác sĩ để xóa.");
            }
        }

        // Lấy email của bác sĩ từ cơ sở dữ liệu dựa trên BacSiID
        private string GetDoctorEmail(int bacSiID)
        {
            string email = string.Empty;
            string query = "SELECT Email FROM BACSI WHERE BacSiID = @BacSiID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                        email = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin email bác sĩ: " + ex.Message);
                }
            }
            return email;
        }

        // Lấy số điện thoại của bác sĩ từ cơ sở dữ liệu dựa trên BacSiID
        private string GetDoctorPhoneNumber(int bacSiID)
        {
            string phoneNumber = string.Empty;
            string query = "SELECT Sodienthoai FROM BACSI WHERE BacSiID = @BacSiID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                        phoneNumber = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin số điện thoại bác sĩ: " + ex.Message);
                }
            }
            return phoneNumber;
        }


        //Sự kiện sửa thông tin một bác sĩ
        private void buttonSua_Click(object sender, EventArgs e)
        {
            // Gọi hàm lấy dữ liệu bác sĩ
            var (hoTen, ngaySinh, gioiTinh, chuyenKhoaID, email, phoneNumber, diaChi, phongID, userID) = GetDoctorData();

            // Kiểm tra dữ liệu hợp lệ
            if (!ValidateDoctorData())
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }

            // Lấy BacSiID từ DataGridView khi chọn bác sĩ cần sửa
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int bacSiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BacSiID"].Value);
                int? originalUserID = GetUserID(bacSiID);

                // Kiểm tra trùng lặp chỉ khi có thay đổi về email hoặc số điện thoại
                if (email != GetDoctorEmail(bacSiID) || phoneNumber != GetDoctorPhoneNumber(bacSiID))
                {
                    if (KiemTraTrung(bacSiID, phoneNumber, email)) // Truyền BacSiID để bỏ qua bác sĩ hiện tại
                    {
                        MessageBox.Show("Số điện thoại hoặc email đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                // Kiểm tra trùng lặp UserID nếu có thay đổi
                if (userID != originalUserID)
                {
                    if (KiemTraTrungUserID(bacSiID, userID))
                    {
                        MessageBox.Show("UserID đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                // Cập nhật thông tin bác sĩ trong cơ sở dữ liệu
                string query = "UPDATE BACSI SET HoTen = @HoTen, NgaySinh = @NgaySinh, GTinh = @GTinh, " +
                               "ChuyenKhoaID = @ChuyenKhoaID, Email = @Email, Sodienthoai = @Sodienthoai, " +
                               "DChi = @DChi, PhongID = @PhongID, UserID = @UserID WHERE BacSiID = @BacSiID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Gán các giá trị cho tham số SQL
                            cmd.Parameters.AddWithValue("@HoTen", hoTen);
                            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            cmd.Parameters.AddWithValue("@GTinh", gioiTinh);
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Sodienthoai", phoneNumber);
                            cmd.Parameters.AddWithValue("@DChi", diaChi);
                            cmd.Parameters.AddWithValue("@PhongID", phongID);
                            cmd.Parameters.AddWithValue("@UserID", userID); // Đảm bảo UserID không NULL
                            cmd.Parameters.AddWithValue("@BacSiID", bacSiID);

                            // Thực thi câu lệnh SQL
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin bác sĩ đã được cập nhật thành công!");
                            LoadDoctorData(); // Làm mới dữ liệu sau khi cập nhật
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật bác sĩ: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần cập nhật.");
            }
        }

        // Hàm kiểm tra trùng giữa bác sĩ mới và toàn bộ dữ liệu của bác sĩ và nhân viên
        private bool KiemTraTrung(int bacSiID, string phoneNumber, string email)
        {
            // Truy vấn SQL kiểm tra trong bảng BACSI và NHANVIEN
            string query = @"
                        SELECT COUNT(*)
                        FROM (
                            SELECT BacSiID, Sodienthoai, Email FROM BACSI
                            UNION ALL
                            SELECT NULL AS BacSiID, Sodienthoai, Email FROM NHANVIEN
                        ) AS CombinedData
                        WHERE (Sodienthoai = @PhoneNumber OR Email = @Email)
                        AND (BacSiID IS NULL OR BacSiID != @BacSiID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số cho truy vấn
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Trả về true nếu có trùng lặp
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp: " + ex.Message);
                    return false;
                }
            }
        }

        // Kiểm tra trùng UserID cho bác sĩ khi cập nhật
        private bool KiemTraTrungUserID(int? bacSiID, int? userID)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM (
                SELECT UserID FROM GIAMHO WHERE UserID = @UserID
                UNION ALL
                SELECT UserID FROM NHANVIEN WHERE UserID = @UserID
                UNION ALL
                SELECT UserID FROM BACSI WHERE UserID = @UserID AND BacSiID != @BacSiID
            ) AS CombinedUserIDs";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số cho truy vấn
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID.HasValue ? bacSiID.Value : -1); // Kiểm tra bacSiID có giá trị hay không, nếu null dùng giá trị -1

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Trả về true nếu có trùng lặp UserID
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp UserID khi cập nhật: " + ex.Message);
                    return false;
                }
            }
        }


        private void ClearFields()
        {
            // Xóa nội dung các trường nhập liệu
            materialTextBox1.Clear();            // Tên
            materialTextBox2.Clear();            // Email
            materialTextBox3.Clear();            // Số điện thoại
            materialTextBox4.Clear();            // Địa chỉ
            dateTimePicker.Value = DateTime.Now; // Ngày sinh về mặc định là ngày hiện tại
            materialComboBox1.SelectedIndex = -1; // Xóa lựa chọn giới tính
            materialComboBox2.SelectedIndex = -1; // Xóa lựa chọn chuyên khoa
            materialComboBox3.SelectedIndex = -1; // Xóa lựa chọn phòng
            materialComboBox4.SelectedIndex = -1;  // Đặt về dòng trống trong UserID ComboBox
        }

        //Sự kiện thêm bác sĩ
        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.Refresh();
            button2.Visible = true;
        }

        //Lưu dữ liệu vào database - chức năng thêm
        private void button2_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gioiTinh, chuyenKhoaID, email, phoneNumber, diaChi, phongID, userID) = GetDoctorData();

            if (!ValidateDoctorData())
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

            if (!string.IsNullOrWhiteSpace(phoneNumber) || !string.IsNullOrWhiteSpace(email))
            {
                if (KiemTraTrung(0, phoneNumber, email)) 
                {
                    MessageBox.Show("Số điện thoại hoặc email đã tồn tại. Vui lòng kiểm tra lại.");
                    return;
                }
            }

            string query = "INSERT INTO BACSI (HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID) " +
                           "VALUES (@HoTen, @NgaySinh, @GTinh, @ChuyenKhoaID, @Email, @Sodienthoai, @DChi, @PhongID, @UserID)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Sodienthoai", phoneNumber);
                        cmd.Parameters.AddWithValue("@DChi", diaChi);
                        cmd.Parameters.AddWithValue("@PhongID", phongID);
                        cmd.Parameters.AddWithValue("@UserID", userID); 

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bác sĩ đã được thêm thành công!");
                        LoadDoctorData();
                        ClearFields();
                        button2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm bác sĩ: " + ex.Message);
                }
            }
        }

        //Chức năng tìm kiếm
        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            string query = "SELECT BacSiID, HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID " +
                           "FROM BACSI ";

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT BacSiID, HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID " +
                        "FROM BACSI";
            }
            else
            {
                query += "WHERE HoTen LIKE @SearchText OR UserID IN (SELECT UserID FROM NGUOIDUNG WHERE Username LIKE @SearchText)";

                if (int.TryParse(searchText, out int bacSiID))
                {
                    query = "SELECT BacSiID, HoTen, NgaySinh, GTinh, ChuyenKhoaID, Email, Sodienthoai, DChi, PhongID, UserID " +
                            "FROM BACSI WHERE BacSiID = @BacSiID";
                }
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (int.TryParse(searchText, out int bacSiID))
                        {
                            cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
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
                            MessageBox.Show("Không tìm thấy bác sĩ nào.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm bác sĩ: " + ex.Message);
                }
            }
        }
    }
}
