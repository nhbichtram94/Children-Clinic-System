using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class PhongKhoa : Form
    {
        private string connString = "Server=GOCUNNPC;Database=QLPKND;User Id=sa;Password=123;";

        public PhongKhoa()
        {
            InitializeComponent();
            ConfigureDataGridView();
            ConfigureDataGridView1();
            LoadSpecialtyData();
            LoadRoomData();
            button2.Visible = false;
            button3.Visible = false;
        }

        private void LoadSpecialtyData()
        {
            string query = "SELECT ChuyenKhoaID, TenChuyenKhoa, MoTa FROM CHUYENKHOA";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu chuyên khoa: " + ex.Message);
                }
            }
        }

        private void LoadRoomData()
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

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu phòng làm việc: " + ex.Message);
                }
            }
        }

        private void LoadSpecializationDetails(int chuyenKhoaID)
        {
            string query = "SELECT TenChuyenKhoa, MoTa FROM CHUYENKHOA WHERE ChuyenKhoaID = @ChuyenKhoaID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialTextBox1.Text = reader["TenChuyenKhoa"].ToString();
                        materialTextBox2.Text = reader["MoTa"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết chuyên khoa: " + ex.Message);
                }
            }
        }

        // Hàm tải thông tin chi tiết phòng làm việc
        private void LoadWorkingRoomDetails(int phongID)
        {
            string query = "SELECT TenPhong FROM PHONGLAMVIEC WHERE PhongID = @PhongID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@PhongID", phongID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        materialTextBox3.Text = reader["TenPhong"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết phòng làm việc: " + ex.Message);
                }
            }
        }


        // Cấu hình CHUYÊN KHOA DataGridView
        private void ConfigureDataGridView()
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
        }

        // Lấy dữ liệu CHUYÊN KHOA khi chọn một dòng trong DataGridView
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                var chuyenKhoaIDValue = dataGridView.Rows[e.RowIndex].Cells["ChuyenKhoaID"].Value;

                if (chuyenKhoaIDValue != DBNull.Value && chuyenKhoaIDValue != null)
                {
                    int chuyenKhoaID = Convert.ToInt32(chuyenKhoaIDValue);
                    LoadSpecializationDetails(chuyenKhoaID);
                    this.Refresh();
                }
            }
        }

        // Cấu hình DataGridView cho phòng làm việc
        private void ConfigureDataGridView1()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        // Lấy dữ liệu khi chọn một dòng trong DataGridView (Phòng Làm Việc)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var phongIDValue = dataGridView1.Rows[e.RowIndex].Cells["PhongID"].Value;

                if (phongIDValue != DBNull.Value && phongIDValue != null)
                {
                    int phongID = Convert.ToInt32(phongIDValue);
                    LoadWorkingRoomDetails(phongID);
                    this.Refresh();
                }
            }
        }

        private (string tenChuyenKhoa, string moTa) GetChuyenKhoaInput()
        {
            string tenChuyenKhoa = materialTextBox1.Text;
            string moTa = materialTextBox2.Text;

            return (tenChuyenKhoa, moTa);
        }

        // Kiểm tra tính hợp lệ tên phòng làm việc
        private bool IsValidPhongName(string tenPhong)
        {
            tenPhong = tenPhong.Trim();

            if (string.IsNullOrWhiteSpace(tenPhong))
            {
                MessageBox.Show("Tên phòng không được để trống.");
                return false;
            }

            foreach (char c in tenPhong)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Tên phòng chỉ được chứa chữ cái và dấu cách.");
                    return false;
                }
            }

            return true;
        }

        // Kiểm tra tính hợp lệ tên chuyên khoa
        private bool IsValidChuyenKhoaName(string tenChuyenKhoa)
        {
            tenChuyenKhoa = tenChuyenKhoa.Trim();

            if (string.IsNullOrWhiteSpace(tenChuyenKhoa))
            {
                MessageBox.Show("Tên chuyên khoa không được để trống.");
                return false;
            }

            foreach (char c in tenChuyenKhoa)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    MessageBox.Show("Tên chuyên khoa chỉ được chứa chữ cái và dấu cách.");
                    return false;
                }
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của dữ liệu chuyên khoa
        private bool ValidateChuyenKhoaData()
        {
            var (tenChuyenKhoa, moTa) = GetChuyenKhoaInput();

            if (string.IsNullOrWhiteSpace(tenChuyenKhoa))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên khoa!");
                return false;
            }

            if (!IsValidChuyenKhoaName(tenChuyenKhoa))
            {
                MessageBox.Show("Tên chuyên khoa không được chứa ký tự đặc biệt.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(moTa))
            {
                MessageBox.Show("Vui lòng nhập mô tả cho chuyên khoa!");
                return false;
            }

            return true; 
        }


        // Hàm kiểm tra trùng tên chuyên khoa trong cơ sở dữ liệu
        private bool KiemTraTrungChuyenKhoa(int chuyenKhoaID, string tenChuyenKhoa)
        {
            string query = "SELECT COUNT(*) FROM CHUYENKHOA WHERE TenChuyenKhoa = @TenChuyenKhoa AND ChuyenKhoaID != @ChuyenKhoaID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenChuyenKhoa", tenChuyenKhoa);
                        cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp chuyên khoa: " + ex.Message);
                    return false;
                }
            }
        }

        // Hàm kiểm tra trùng tên phòng làm việc trong cơ sở dữ liệu
        private bool KiemTraTrungPhong(int phongID, string tenPhong)
        {
            string query = "SELECT COUNT(*) FROM PHONGLAMVIEC WHERE TenPhong = @TenPhong AND PhongID != @PhongID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                        cmd.Parameters.AddWithValue("@PhongID", phongID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng lặp phòng làm việc: " + ex.Message);
                    return false;
                }
            }
        }

        // Hàm lấy tên và mô tả chuyên khoa từ cơ sở dữ liệu dựa trên ChuyênKhoaID
        private (string TenChuyenKhoa, string MoTa) GetChuyenKhoa(int chuyenKhoaID)
        {
            string tenChuyenKhoa = string.Empty;
            string moTa = string.Empty;
            string query = "SELECT TenChuyenKhoa, MoTa FROM CHUYENKHOA WHERE ChuyenKhoaID = @ChuyenKhoaID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            tenChuyenKhoa = reader["TenChuyenKhoa"].ToString();
                            moTa = reader["MoTa"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin chuyên khoa: " + ex.Message);
                }
            }
            return (tenChuyenKhoa, moTa);
        }

        // Hàm lấy tên phòng làm việc từ cơ sở dữ liệu dựa trên PhongID
        private string GetPhongLamViec(int phongID)
        {
            string tenPhong = string.Empty;
            string query = "SELECT TenPhong FROM PHONGLAMVIEC WHERE PhongID = @PhongID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PhongID", phongID);

                        tenPhong = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin phòng làm việc: " + ex.Message);
                }
            }
            return tenPhong;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            materialTextBox1.Clear();
            materialTextBox2.Clear();
            this.Refresh();
            button2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            materialTextBox3.Clear();
            this.Refresh();
            button3.Visible = true;
        }

        // Sự kiện lưu thông tin chuyên khoa mới vào hệ thống
        private void button2_Click(object sender, EventArgs e)
        {
            var (tenChuyenKhoa, moTa) = GetChuyenKhoaInput();

            if (!ValidateChuyenKhoaData())
            {
                return; 
            }

            if (!string.IsNullOrWhiteSpace(tenChuyenKhoa))
            {
                if (KiemTraTrungChuyenKhoa(0, tenChuyenKhoa)) 
                {
                    MessageBox.Show("Chuyên khoa này đã tồn tại. Vui lòng chọn tên chuyên khoa khác.");
                    return;
                }
            }

            // Câu lệnh SQL để thêm chuyên khoa mới
            string query = "INSERT INTO CHUYENKHOA (TenChuyenKhoa, MoTa) VALUES (@TenChuyenKhoa, @MoTa)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenChuyenKhoa", tenChuyenKhoa);
                        cmd.Parameters.AddWithValue("@MoTa", moTa);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Chuyên khoa đã được thêm thành công!");

                        LoadSpecialtyData();
                        materialTextBox1.Clear();
                        materialTextBox2.Clear(); 
                        button2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chuyên khoa: " + ex.Message);
                }
            }
        }


        // Sự kiện lưu thông tin phòng làm việc mới vào hệ thống
        private void button3_Click(object sender, EventArgs e)
        {
            var tenPhong = materialTextBox3.Text;

            if (!IsValidPhongName(tenPhong))
            {
                return; 
            }

            if (!string.IsNullOrWhiteSpace(tenPhong))
            {
                if (KiemTraTrungPhong(0, tenPhong)) 
                {
                    MessageBox.Show("Phòng làm việc này đã tồn tại. Vui lòng chọn tên phòng khác.");
                    return;
                }
            }

            string query = "INSERT INTO PHONGLAMVIEC (TenPhong) VALUES (@TenPhong)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenPhong", tenPhong);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Phòng làm việc đã được thêm thành công!");

                        LoadRoomData();
                        materialTextBox3.Clear(); 
                        button3.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phòng làm việc: " + ex.Message);
                }
            }
        }


        // Sự kiện xóa chuyên khoa
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0) 
            {
                int chuyenKhoaID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ChuyenKhoaID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        string updateDoctorQuery = "UPDATE BACSI SET ChuyenKhoaID = NULL WHERE ChuyenKhoaID = @ChuyenKhoaID";
                        using (SqlCommand cmd = new SqlCommand(updateDoctorQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.ExecuteNonQuery();
                        }

                        string updatePatientFileQuery = "UPDATE HOSOBENHAN SET ChuyenKhoaID = NULL WHERE ChuyenKhoaID = @ChuyenKhoaID";
                        using (SqlCommand cmd = new SqlCommand(updatePatientFileQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.ExecuteNonQuery();
                        }

                        string updateMedicalTicketQuery = "UPDATE PHIEUKHAM SET ChuyenKhoaID = NULL WHERE ChuyenKhoaID = @ChuyenKhoaID";
                        using (SqlCommand cmd = new SqlCommand(updateMedicalTicketQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteScheduleQuery = "DELETE FROM LICHKHAM WHERE ChuyenKhoaID = @ChuyenKhoaID";
                        using (SqlCommand cmd = new SqlCommand(deleteScheduleQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteChuyenKhoaQuery = "DELETE FROM CHUYENKHOA WHERE ChuyenKhoaID = @ChuyenKhoaID";
                        using (SqlCommand cmd = new SqlCommand(deleteChuyenKhoaQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa chuyên khoa thành công.");
                        LoadSpecialtyData();
                        materialTextBox1.Clear();
                        materialTextBox2.Clear();
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa chuyên khoa: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa để xóa.");
            }
        }

        // Sự kiện xóa phòng làm việc
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int phongID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PhongID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        string updateDoctorQuery = "UPDATE BACSI SET PhongID = NULL WHERE PhongID = @PhongID";
                        using (SqlCommand cmd = new SqlCommand(updateDoctorQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongID", phongID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteRoomQuery = "DELETE FROM PHONGLAMVIEC WHERE PhongID = @PhongID";
                        using (SqlCommand cmd = new SqlCommand(deleteRoomQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongID", phongID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa phòng làm việc thành công.");
                        LoadRoomData(); 
                        materialTextBox3.Clear();
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa phòng làm việc: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng làm việc để xóa.");
            }
        }


        //Sự kiện cập nhật chuyên khoa
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var (tenChuyenKhoa, moTa) = GetChuyenKhoaInput();

            if (!ValidateChuyenKhoaData()) return;

            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedChuyenKhoaID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ChuyenKhoaID"].Value);

                var (currentTenChuyenKhoa, currentMoTa) = GetChuyenKhoa(selectedChuyenKhoaID);

                if (tenChuyenKhoa != currentTenChuyenKhoa)
                {
                    if (KiemTraTrungChuyenKhoa(selectedChuyenKhoaID, tenChuyenKhoa)) 
                    {
                        MessageBox.Show("Tên chuyên khoa đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE CHUYENKHOA SET TenChuyenKhoa = @TenChuyenKhoa, MoTa = @MoTa " +
                               "WHERE ChuyenKhoaID = @ChuyenKhoaID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@TenChuyenKhoa", tenChuyenKhoa);
                            cmd.Parameters.AddWithValue("@MoTa", moTa);
                            cmd.Parameters.AddWithValue("@ChuyenKhoaID", selectedChuyenKhoaID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin chuyên khoa đã được cập nhật thành công!");
                            LoadSpecialtyData();
                            materialTextBox1.Clear();
                            materialTextBox2.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin chuyên khoa: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa cần cập nhật.");
            }
        }

        // Sự kiện cập nhật phòng làm việc
        private void button5_Click(object sender, EventArgs e)
        {
            var tenPhong = materialTextBox3.Text;

            if (!IsValidPhongName(tenPhong))
            {
                return; 
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedPhongID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PhongID"].Value);

                var currentTenPhong = GetPhongLamViec(selectedPhongID);

                if (tenPhong != currentTenPhong)
                {
                    if (KiemTraTrungPhong(selectedPhongID, tenPhong))
                    {
                        MessageBox.Show("Tên phòng làm việc này đã tồn tại. Vui lòng kiểm tra lại.");
                        return;
                    }
                }

                string query = "UPDATE PHONGLAMVIEC SET TenPhong = @TenPhong WHERE PhongID = @PhongID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                            cmd.Parameters.AddWithValue("@PhongID", selectedPhongID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin phòng làm việc đã được cập nhật thành công!");
                            LoadRoomData();
                            materialTextBox3.Clear(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin phòng làm việc: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng làm việc cần cập nhật.");
            }
        }


        //Hoạt động tìm kiếm chung cho chuyên khoa và phòng làm việc
        private void button8_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox2.Text;
            int searchId;
            bool isIdSearch = int.TryParse(searchQuery, out searchId);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Tìm kiếm cho chuyên khoa, không phân biệt hoa thường
                    string querySpecialty = "SELECT ChuyenKhoaID, TenChuyenKhoa, MoTa FROM CHUYENKHOA WHERE " +
                                            "(ChuyenKhoaID = @searchId OR TenChuyenKhoa COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @searchText)";
                    SqlDataAdapter dataAdapterSpecialty = new SqlDataAdapter(querySpecialty, conn);
                    dataAdapterSpecialty.SelectCommand.Parameters.AddWithValue("@searchId", isIdSearch ? (object)searchId : DBNull.Value);
                    dataAdapterSpecialty.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchQuery + "%");

                    DataTable dataTableSpecialty = new DataTable();
                    dataAdapterSpecialty.Fill(dataTableSpecialty);

                    // Nếu không tìm thấy kết quả thì lấy toàn bộ dữ liệu
                    if (dataTableSpecialty.Rows.Count == 0)
                    {
                        string queryAllSpecialty = "SELECT ChuyenKhoaID, TenChuyenKhoa, MoTa FROM CHUYENKHOA";
                        SqlDataAdapter allDataAdapterSpecialty = new SqlDataAdapter(queryAllSpecialty, conn);
                        dataTableSpecialty.Clear();
                        allDataAdapterSpecialty.Fill(dataTableSpecialty);
                    }
                    dataGridView.DataSource = dataTableSpecialty;

                    // Tìm kiếm cho phòng làm việc, không phân biệt hoa thường
                    string queryRoom = "SELECT PhongID, TenPhong FROM PHONGLAMVIEC WHERE " +
                                       "(PhongID = @searchId OR TenPhong COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @searchText)";
                    SqlDataAdapter dataAdapterRoom = new SqlDataAdapter(queryRoom, conn);
                    dataAdapterRoom.SelectCommand.Parameters.AddWithValue("@searchId", isIdSearch ? (object)searchId : DBNull.Value);
                    dataAdapterRoom.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchQuery + "%");

                    DataTable dataTableRoom = new DataTable();
                    dataAdapterRoom.Fill(dataTableRoom);

                    // Nếu không tìm thấy kết quả thì lấy toàn bộ dữ liệu
                    if (dataTableRoom.Rows.Count == 0)
                    {
                        string queryAllRoom = "SELECT PhongID, TenPhong FROM PHONGLAMVIEC";
                        SqlDataAdapter allDataAdapterRoom = new SqlDataAdapter(queryAllRoom, conn);
                        dataTableRoom.Clear();
                        allDataAdapterRoom.Fill(dataTableRoom);
                    }
                    dataGridView1.DataSource = dataTableRoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }
    }
}
