using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class QLBenhNhi : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public QLBenhNhi()
        {
            InitializeComponent();
            ConfigureDataGridViewGiamHo();
            ConfigureDataGridViewBenhNhan();
            LoadBenhNhanData();
            LoadGiamHoData();
            LoadLoaiQuanHeData();
            LoadGiamHoBenhNhanData();
            LoadUserData();
            button6.Visible = false;
            button7.Visible = false;
        }

        private void LoadBenhNhanData()
        {
            string query = "SELECT BenhNhanID, HoTen, NgSinh, GioiTinh FROM BENHNHAN";

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
                    MessageBox.Show("Lỗi khi tải dữ liệu bệnh nhân: " + ex.Message);
                }
            }
        }

        private void LoadGiamHoData()
        {
            string query = "SELECT GiamHoID, HoTen, NgaySinh, GTinh, Sodienthoai, DChi, UserID FROM GIAMHO";

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
                    MessageBox.Show("Lỗi khi tải dữ liệu giám hộ: " + ex.Message);
                }
            }
        }

        private void LoadBenhNhanDetails(int benhNhanID)
        {
            string query = "SELECT HoTen, NgSinh, GioiTinh FROM BENHNHAN WHERE BenhNhanID = @BenhNhanID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@BenhNhanID", benhNhanID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Gán giá trị vào các TextBox và ComboBox
                        materialTextBox1.Text = reader["HoTen"].ToString(); // Họ tên
                        dateTimePicker2.Value = Convert.ToDateTime(reader["NgSinh"]); // Ngày sinh
                        materialComboBox1.SelectedItem = reader["GioiTinh"].ToString(); 
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết bệnh nhân: " + ex.Message);
                }
            }
        }

        private void LoadGiamHoDetails(int giamHoID)
        {
            string query = "SELECT HoTen, NgaySinh, GTinh, Sodienthoai, DChi, UserID FROM GIAMHO WHERE GiamHoID = @GiamHoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@GiamHoID", giamHoID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Gán giá trị vào các điều khiển trên form
                        materialTextBox2.Text = reader["HoTen"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        materialComboBox4.SelectedItem = reader["GTinh"].ToString();
                        materialTextBox3.Text = reader["Sodienthoai"].ToString();
                        materialTextBox4.Text = reader["DChi"].ToString();
                        materialComboBox5.SelectedValue = reader["UserID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết giám hộ: " + ex.Message);
                }
            }
        }

        private void LoadLoaiQuanHeData()
        {
            string query = "SELECT LoaiQuanHeID, TenQuanHe FROM LOAIQUANHE";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow row = dataTable.NewRow();
                    row["LoaiQuanHeID"] = DBNull.Value;
                    row["TenQuanHe"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(row, 0); // Thêm dòng này vào đầu bảng

                    // Gán dữ liệu vào ComboBox
                    materialComboBox3.DisplayMember = "TenQuanHe";
                    materialComboBox3.ValueMember = "LoaiQuanHeID";
                    materialComboBox3.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu loại quan hệ: " + ex.Message);
                }
            }
        }

        private void LoadGiamHoBenhNhanData()
        {
            string query = "SELECT GiamHoID, HoTen FROM GIAMHO";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Thêm dòng trống vào đầu DataTable
                    DataRow row = dataTable.NewRow();
                    row["GiamHoID"] = DBNull.Value;
                    row["HoTen"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(row, 0);

                    // Gán dữ liệu vào ComboBox
                    materialComboBox2.DisplayMember = "HoTen";
                    materialComboBox2.ValueMember = "GiamHoID";
                    materialComboBox2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu giám hộ: " + ex.Message);
                }
            }
        }

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
                    row["Username"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(row, 0);

                    // Gán dữ liệu vào ComboBox
                    materialComboBox5.DisplayMember = "Username";
                    materialComboBox5.ValueMember = "UserID";
                    materialComboBox5.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu người dùng: " + ex.Message);
                }
            }
        }

        private void LoadGiamHoBenhNhanDetails(int benhNhanID)
        {
            // Truy vấn để lấy Giám Hộ và Vai trò của bệnh nhân
            string query = @"
                    SELECT 
                        g.GiamHoID,        -- Trả về GiamHoID
                        g.HoTen, 
                        l.LoaiQuanHeID,    -- Trả về LoaiQuanHeID
                        l.TenQuanHe 
                    FROM GIAMHO_BENHNHAN gbn
                    INNER JOIN GIAMHO g ON gbn.GiamHoID = g.GiamHoID
                    INNER JOIN LOAIQUANHE l ON gbn.LoaiQuanHeID = l.LoaiQuanHeID
                    WHERE gbn.BenhNhanID = @BenhNhanID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@BenhNhanID", benhNhanID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialComboBox2.SelectedValue = reader["GiamHoID"];  // GiamHoID
                        materialComboBox3.SelectedValue = reader["LoaiQuanHeID"];    // LoaiQuanHeID
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin giám hộ: " + ex.Message);
                }
            }
        }

        // Cấu hình DataGridView cho Bệnh Nhân
        private void ConfigureDataGridViewBenhNhan()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridViewBenhNhan_CellClick);
        }

        // Sự kiện khi chọn dòng trong DataGridView Bệnh Nhân
        private void dataGridViewBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var benhNhanIDValue = dataGridView1.Rows[e.RowIndex].Cells["BenhNhanID"].Value;

                if (benhNhanIDValue != DBNull.Value && benhNhanIDValue != null)
                {
                    int benhNhanID = Convert.ToInt32(benhNhanIDValue);
                    LoadBenhNhanDetails(benhNhanID);
                    LoadGiamHoBenhNhanDetails(benhNhanID);
                    this.Refresh();
                }
            }
        }


        // Cấu hình DataGridView cho Giám Hộ
        private void ConfigureDataGridViewGiamHo()
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridViewGiamHo_CellClick);
        }

        // Sự kiện khi chọn dòng trong DataGridView Giám Hộ
        private void dataGridViewGiamHo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                var giamHoIDValue = dataGridView2.Rows[e.RowIndex].Cells["GiamHoID"].Value;

                if (giamHoIDValue != DBNull.Value && giamHoIDValue != null)
                {
                    int giamHoID = Convert.ToInt32(giamHoIDValue);
                    LoadGiamHoDetails(giamHoID);  
                    this.Refresh();
                }
            }
        }

        private (string hoTen, DateTime ngaySinh, string gioiTinh) GetBenhNhanInput()
        {
            string hoTen = materialTextBox1.Text; // Họ tên Bệnh Nhân
            DateTime ngaySinh = dateTimePicker2.Value; // Ngày sinh Bệnh Nhân
            string gioiTinh = materialComboBox1.Text; // Giới tính Bệnh Nhân

            return (hoTen, ngaySinh, gioiTinh);
        }

        private (string hoTen, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int? userID) GetGiamHoInput()
        {
            string hoTen = materialTextBox2.Text; // Họ tên Giám Hộ
            DateTime ngaySinh = dateTimePicker1.Value; // Ngày sinh Giám Hộ
            string gioiTinh = materialComboBox4.Text; // Giới tính Giám Hộ
            string soDienThoai = materialTextBox3.Text; // Số điện thoại Giám Hộ
            string diaChi = materialTextBox4.Text; // Địa chỉ Giám Hộ
            int? userID = (int?)materialComboBox5.SelectedValue;

            return (hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi, userID);
        }

        // Kiểm tra xem UserID đã tồn tại trong GIAMHO, NHANVIEN và BACSI hay chưa
        private bool IsUserIDDuplicate(int? userID)
        {
            if (userID == null)
            {
                return false;
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

        private bool IsValidPhoneNumber(string soDienThoai)
        {
            return soDienThoai.All(char.IsDigit) && soDienThoai.Length >= 10 && soDienThoai.Length <= 15;
        }

        //Kiểm tra độ tuổi hợp lệ tối thiểu 24
        private bool IsAgeValid(DateTime ngaySinh)
        {
            int age = DateTime.Now.Year - ngaySinh.Year;
            if (DateTime.Now.DayOfYear < ngaySinh.DayOfYear)
            {
                age--;
            }
            return age >= 18;
        }

        // Kiểm tra nhập liệu đầy đủ và tính hợp lệ của dữ liệu người giám hộ
        private bool ValidateGiamHoData()
        {
            var (hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi, userID) = GetGiamHoInput();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập tên người giám hộ!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                return false;
            }
            
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng kiểm tra lại.");
                return false;
            }

            if (!IsAgeValid(ngaySinh))
            {
                MessageBox.Show("Người giám hộ phải ít nhất 18 tuổi!");
                return false;
            }

            return true; 
        }

        private bool IsGiamHo_BenhNhan(int giamHoID, int loaiQuanHeID)
        {
            string query = @"
                    SELECT COUNT(*) 
                    FROM GIAMHO_BENHNHAN gbn
                    INNER JOIN GIAMHO g ON gbn.GiamHoID = g.GiamHoID
                    WHERE gbn.GiamHoID = @GiamHoID 
                    AND gbn.LoaiQuanHeID = @LoaiQuanHeID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);
                        cmd.Parameters.AddWithValue("@LoaiQuanHeID", loaiQuanHeID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng giám hộ và quan hệ: " + ex.Message);
                    return false;
                }
            }
        }

        // Hàm kiểm tra trùng số điện thoại cho giám hộ
        private bool KiemTraTrungSDT(int giamHoID, string soDienThoai)
        {
            string query = @"
                            SELECT COUNT(*)
                            FROM GIAMHO
                            WHERE Sodienthoai = @soDienThoai
                            AND GiamHoID != @GiamHoID"; 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@GiamHoID", giamHoID); 
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp số điện thoại: " + ex.Message);
                    return false;
                }
            }
        }

        // Kiểm tra trùng UserID cho giám hộ khi cập nhật
        private bool KiemTraTrungUserID(int userID, int? giamHoID)
        {
            string query = @"
                    SELECT COUNT(*) 
                    FROM (
                        SELECT UserID FROM GIAMHO WHERE UserID = @UserID AND GiamHoID != @GiamHoID
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
                        cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);

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

        private string GetEmpPhoneNumber(int giamHoID)
        {
            string soDienThoai = string.Empty;
            string query = "SELECT Sodienthoai FROM GIAMHO WHERE GiamHoID = @GiamHoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);
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

        private int GetBenhNhanGiamHoID(int benhNhanID)
        {
            string query = "SELECT GiamHoID FROM GIAMHO_BENHNHAN WHERE BenhNhanID = @BenhNhanID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);

                        return cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy GiamHoID: " + ex.Message);
                    return -1;
                }
            }
        }

        private int? GetUserID(int giamHoID)
        {
            int? userID = null; 
            string query = "SELECT UserID FROM GIAMHO WHERE GiamHoID = @GiamHoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);
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

        private int GetBenhNhanLoaiQuanHeID(int benhNhanID)
        {
            string query = "SELECT LoaiQuanHeID FROM GIAMHO_BENHNHAN WHERE BenhNhanID = @BenhNhanID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);

                        return cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy LoaiQuanHeID: " + ex.Message);
                    return -1;
                }
            }
        }

        private void ClearInputsGH()
        {
            dateTimePicker1.Value = DateTime.Now;
            materialTextBox2.Clear();
            materialTextBox3.Clear();
            materialTextBox4.Clear();
            materialComboBox5.SelectedIndex = -1;
            materialComboBox4.SelectedIndex = -1;
        }

        private void ClearInputsBN()
        {
            dateTimePicker2.Value = DateTime.Now;
            materialTextBox1.Clear();
            materialComboBox1.SelectedIndex = -1;
            materialComboBox2.SelectedIndex = -1;
            materialComboBox3.SelectedIndex = -1;
        }

        //Bắt đầu thêm giám hộ
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputsGH();
            this.Refresh();
            button6.Visible = true;
        }

        //Bắt đầu thêm bệnh nhân
        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputsBN();
            this.Refresh();
            button7.Visible = true;
        }

        //Thêm mới giám hộ
        private void button6_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi, userID) = GetGiamHoInput();

            if (!ValidateGiamHoData())
            {
                return; 
            }

            if (userID == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản người dùng!");
                return;
            }

            // Kiểm tra trùng UserID nếu có
            if (IsUserIDDuplicate(userID))
            {
                MessageBox.Show("UserID này đã được sử dụng!");
                return;
            }

            // Kiểm tra trùng lặp về email hoặc số điện thoại (chỉ kiểm tra nếu có giá trị)
            if (!string.IsNullOrWhiteSpace(soDienThoai))
            {
                if (KiemTraTrungSDT(0,soDienThoai))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng kiểm tra lại.");
                    return;
                }
            }

            string query = "INSERT INTO GIAMHO (HoTen, NgaySinh, GTinh, Sodienthoai, DChi, UserID) " +
                           "VALUES (@HoTen, @NgaySinh, @GTinh, @Sodienthoai, @DChi, @UserID)";

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
                        cmd.Parameters.AddWithValue("@Sodienthoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@DChi", diaChi);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Người giám hộ đã được thêm thành công!");

                        // Tải lại dữ liệu giám hộ để cập nhật DataGridView
                        LoadGiamHoData();
                        ClearInputsGH();
                        LoadGiamHoBenhNhanData();
                        button6.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm người giám hộ: " + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gioiTinh) = GetBenhNhanInput();
            int giamHoID = Convert.ToInt32(materialComboBox2.SelectedValue);
            int loaiQuanHeID = Convert.ToInt32(materialComboBox3.SelectedValue);

            if (IsGiamHo_BenhNhan(giamHoID, loaiQuanHeID))
            {
                MessageBox.Show("Bệnh nhân này đã có giám hộ với loại quan hệ này.");
                return;
            }

            string query = "INSERT INTO BENHNHAN (HoTen, NgSinh, GioiTinh) " +
                           "VALUES (@HoTen, @NgSinh, @GioiTinh); " +
                           "SELECT SCOPE_IDENTITY();"; 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgSinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);

                        int benhNhanID = Convert.ToInt32(cmd.ExecuteScalar()); 

                        string insertGiamHoBenhNhanQuery = "INSERT INTO GIAMHO_BENHNHAN (GiamHoID, BenhNhanID, LoaiQuanHeID) " +
                                                           "VALUES (@GiamHoID, @BenhNhanID, @LoaiQuanHeID)";

                        using (SqlCommand cmdGiamHo = new SqlCommand(insertGiamHoBenhNhanQuery, conn))
                        {
                            cmdGiamHo.Parameters.AddWithValue("@GiamHoID", giamHoID);
                            cmdGiamHo.Parameters.AddWithValue("@BenhNhanID", benhNhanID);
                            cmdGiamHo.Parameters.AddWithValue("@LoaiQuanHeID", loaiQuanHeID);

                            cmdGiamHo.ExecuteNonQuery();
                        }

                        MessageBox.Show("Bệnh nhân và thông tin giám hộ đã được thêm thành công!");

                        LoadBenhNhanData();
                        ClearInputsBN();
                        button7.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm bệnh nhân: " + ex.Message);
                }
            }
        }

        // Cập nhật giám hộ
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gioiTinh, soDienThoai, diaChi, userID) = GetGiamHoInput();

            if (!ValidateGiamHoData()) return;

            if (dataGridView2.SelectedRows.Count > 0)
            {
                int giamHoID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["GiamHoID"].Value);

                string originalPhoneNumber = GetEmpPhoneNumber(giamHoID);
                int? originalUserID = GetUserID(giamHoID);

                if (soDienThoai != originalPhoneNumber)
                {
                    if (KiemTraTrungSDT(giamHoID, soDienThoai))
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                if (userID != originalUserID)
                {
                    if (KiemTraTrungUserID(giamHoID, userID))
                    {
                        MessageBox.Show("UserID đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE GIAMHO SET HoTen = @HoTen, NgaySinh = @NgaySinh, " +
                               "GTinh = @GioiTinh, Sodienthoai = @Sodienthoai, DChi = @DChi, " +
                               "UserID = @UserID WHERE GiamHoID = @GiamHoID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", hoTen);
                            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            cmd.Parameters.AddWithValue("@Sodienthoai", soDienThoai);
                            cmd.Parameters.AddWithValue("@DChi", diaChi);
                            cmd.Parameters.AddWithValue("@UserID", userID); 
                            cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin giám hộ đã được cập nhật thành công!");

                            LoadGiamHoData();
                            ClearInputsGH();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin giám hộ: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giám hộ cần cập nhật.");
            }
        }

        //Cập nhật bệnh nhi
        private void button4_Click(object sender, EventArgs e)
        {
            var (hoTen, ngaySinh, gioiTinh) = GetBenhNhanInput();
            int giamHoID = Convert.ToInt32(materialComboBox2.SelectedValue);  
            int loaiQuanHeID = Convert.ToInt32(materialComboBox3.SelectedValue);  

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int benhNhanID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BenhNhanID"].Value);

                if (giamHoID != GetBenhNhanGiamHoID(benhNhanID) || loaiQuanHeID != GetBenhNhanLoaiQuanHeID(benhNhanID))
                {
                    if (IsGiamHo_BenhNhan(giamHoID, loaiQuanHeID))
                    {
                        MessageBox.Show("Bệnh nhân này đã có giám hộ với loại quan hệ này.");
                        return;
                    }
                }

                string updateBenhNhanQuery = "UPDATE BENHNHAN SET HoTen = @HoTen, NgSinh = @NgSinh, GioiTinh = @GioiTinh WHERE BenhNhanID = @BenhNhanID";

                string updateGiamHoBenhNhanQuery = "UPDATE GIAMHO_BENHNHAN SET GiamHoID = @GiamHoID, LoaiQuanHeID = @LoaiQuanHeID WHERE BenhNhanID = @BenhNhanID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(updateBenhNhanQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", hoTen);
                            cmd.Parameters.AddWithValue("@NgSinh", ngaySinh);
                            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd2 = new SqlCommand(updateGiamHoBenhNhanQuery, conn))
                        {
                            cmd2.Parameters.AddWithValue("@GiamHoID", giamHoID);
                            cmd2.Parameters.AddWithValue("@LoaiQuanHeID", loaiQuanHeID);
                            cmd2.Parameters.AddWithValue("@BenhNhanID", benhNhanID);
                            cmd2.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thông tin bệnh nhân và quan hệ giám hộ đã được cập nhật thành công!");
                        LoadBenhNhanData(); 
                        ClearInputsBN(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin bệnh nhân: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật.");
            }
        }

        //Tìm chung cho hai bên
        private void button3_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text;
            int searchId;
            bool isIdSearch = int.TryParse(searchQuery, out searchId);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string queryBenhNhi = "SELECT BenhNhiID, HoTen, NgaySinh, GioiTinh FROM BENH_NHI WHERE " +
                                          "(BenhNhiID = @searchId OR HoTen COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @searchText)";
                    SqlDataAdapter dataAdapterBenhNhi = new SqlDataAdapter(queryBenhNhi, conn);
                    dataAdapterBenhNhi.SelectCommand.Parameters.AddWithValue("@searchId", isIdSearch ? (object)searchId : DBNull.Value);
                    dataAdapterBenhNhi.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchQuery + "%");

                    DataTable dataTableBenhNhi = new DataTable();
                    dataAdapterBenhNhi.Fill(dataTableBenhNhi);

                    if (dataTableBenhNhi.Rows.Count == 0)
                    {
                        string queryAllBenhNhi = "SELECT BenhNhiID, HoTen, NgaySinh, GioiTinh FROM BENH_NHI";
                        SqlDataAdapter allDataAdapterBenhNhi = new SqlDataAdapter(queryAllBenhNhi, conn);
                        dataTableBenhNhi.Clear();
                        allDataAdapterBenhNhi.Fill(dataTableBenhNhi);
                    }
                    dataGridView1.DataSource = dataTableBenhNhi;

                    string queryGiamHo = "SELECT GiamHoID, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi FROM GIAMHO WHERE " +
                                         "(GiamHoID = @searchId OR HoTen COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @searchText)";
                    SqlDataAdapter dataAdapterGiamHo = new SqlDataAdapter(queryGiamHo, conn);
                    dataAdapterGiamHo.SelectCommand.Parameters.AddWithValue("@searchId", isIdSearch ? (object)searchId : DBNull.Value);
                    dataAdapterGiamHo.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchQuery + "%");

                    DataTable dataTableGiamHo = new DataTable();
                    dataAdapterGiamHo.Fill(dataTableGiamHo);

                    if (dataTableGiamHo.Rows.Count == 0)
                    {
                        string queryAllGiamHo = "SELECT GiamHoID, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi FROM GIAMHO";
                        SqlDataAdapter allDataAdapterGiamHo = new SqlDataAdapter(queryAllGiamHo, conn);
                        dataTableGiamHo.Clear();
                        allDataAdapterGiamHo.Fill(dataTableGiamHo);
                    }
                    dataGridView2.DataSource = dataTableGiamHo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }
    }
}
