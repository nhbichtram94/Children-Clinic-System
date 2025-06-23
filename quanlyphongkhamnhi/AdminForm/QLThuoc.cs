using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class QLThuoc : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";
                                         

        public QLThuoc()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadThuocData();
            button2.Visible = false;
        }

        // Đọc dữ liệu thuốc vào DataGridView
        private void LoadThuocData()
        {
            string query = "SELECT ThuocID, TenThuoc, HamLuong, CachDung, Gia, TonKho FROM THUOC";

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
                    MessageBox.Show("Lỗi khi tải dữ liệu thuốc: " + ex.Message);
                }
            }
        }

        private void LoadThuocDetails(int thuocID)
        {
            string query = "SELECT TenThuoc, HamLuong, CachDung, Gia, TonKho FROM THUOC WHERE ThuocID = @ThuocID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ThuocID", thuocID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Gán giá trị vào các TextBox
                        materialTextBox1.Text = reader["TenThuoc"].ToString();
                        materialTextBox4.Text = reader["HamLuong"].ToString();
                        materialTextBox2.Text = reader["CachDung"].ToString();
                        materialTextBox3.Text = reader["Gia"].ToString();

                        numericUpDown.Value = Convert.ToInt32(reader["TonKho"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết thuốc: " + ex.Message);
                }
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                var thuocIDValue = dataGridView.Rows[e.RowIndex].Cells["ThuocID"].Value;

                if (thuocIDValue != DBNull.Value && thuocIDValue != null)
                {
                    int thuocID = Convert.ToInt32(thuocIDValue);
                    LoadThuocDetails(thuocID);
                    this.Refresh();
                }
            }
        }

        private (string tenThuoc, string hamLuong, string cachDung, decimal gia, int tonKho) GetThuocInput()
        {
            string tenThuoc = materialTextBox1.Text;
            string hamLuong = materialTextBox4.Text;
            string cachDung = materialTextBox2.Text;
            decimal gia = Convert.ToDecimal(materialTextBox3.Text);
            int tonKho = Convert.ToInt32(numericUpDown.Value);

            return (tenThuoc, hamLuong, cachDung, gia, tonKho);
        }

        // Kiểm tra tính hợp lệ của tên thuốc
        private bool IsValidTenThuoc(string tenThuoc)
        {
            tenThuoc = tenThuoc.Trim();

            if (string.IsNullOrWhiteSpace(tenThuoc))
            {
                MessageBox.Show("Tên thuốc không được để trống.");
                return false;
            }

            // Kiểm tra nếu tên thuốc có ký tự đặc biệt
            foreach (char c in tenThuoc)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                {
                    MessageBox.Show("Tên thuốc không được chứa ký tự đặc biệt.");
                    return false;
                }
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của hàm lượng (không chứa ký tự đặc biệt)
        private bool IsValidHamLuong(string hamLuong)
        {
            hamLuong = hamLuong.Trim();

            if (string.IsNullOrWhiteSpace(hamLuong))
            {
                MessageBox.Show("Hàm lượng không được để trống.");
                return false;
            }
            foreach (char c in hamLuong)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                {
                    MessageBox.Show("Hàm lượng không được chứa ký tự đặc biệt.");
                    return false;
                }
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của giá bán
        private bool IsValidGia(string gia)
        {
            if (string.IsNullOrWhiteSpace(gia))
            {
                MessageBox.Show("Giá bán không được để trống.");
                return false;
            }

            decimal result;
            if (!decimal.TryParse(gia, out result))
            {
                MessageBox.Show("Giá bán chỉ được nhập số.");
                return false;
            }

            if (result < 0)
            {
                MessageBox.Show("Giá bán không được là số âm.");
                return false;
            }

            return true;
        }

        // Kiểm tra tính hợp lệ của dữ liệu thuốc
        private bool ValidateThuocData()
        {
            var thuocInput = GetThuocInput();

            if (string.IsNullOrWhiteSpace(thuocInput.tenThuoc))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(thuocInput.hamLuong))
            {
                MessageBox.Show("Vui lòng nhập hàm lượng thuốc!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(thuocInput.cachDung))
            {
                MessageBox.Show("Vui lòng nhập cách dùng thuốc!");
                return false;
            }

            if (!IsValidGia(thuocInput.gia.ToString()))
            {
                return false; 
            }

            if (!IsValidTenThuoc(thuocInput.tenThuoc))
            {
                return false;
            }

            if (!IsValidHamLuong(thuocInput.hamLuong))
            {
                return false;
            }

            if (thuocInput.tonKho < 0)
            {
                MessageBox.Show("Tồn kho không được là số âm!");
                return false;
            }

            return true; 
        }

        // Hàm kiểm tra tên thuốc trùng lặp trong cơ sở dữ liệu
        private bool KiemTraTrung(int thuocID, string tenThuoc)
        {
            string query = "SELECT COUNT(*) FROM THUOC WHERE TenThuoc = @TenThuoc AND ThuocID != @ThuocID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                        cmd.Parameters.AddWithValue("@ThuocID", thuocID);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra trùng tên thuốc: " + ex.Message);
                    return false;
                }
            }
        }

        // Lấy tên thuốc từ cơ sở dữ liệu dựa trên ThuocID
        private string GetThuocName(int thuocID)
        {
            string tenThuoc = string.Empty;
            string query = "SELECT TenThuoc FROM THUOC WHERE ThuocID = @ThuocID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ThuocID", thuocID);
                        tenThuoc = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin tên thuốc: " + ex.Message);
                }
            }
            return tenThuoc;
        }

        private void ClearInputs()
        {
            materialTextBox1.Clear();  // Xóa tên thuốc
            materialTextBox4.Clear();  // Xóa hàm lượng
            materialTextBox2.Clear();  // Xóa cách dùng
            materialTextBox3.Clear();  // Xóa giá bán
            numericUpDown.Value = 0;   // Đặt lại số lượng tồn kho về 0
        }

        //Bắt đầu thêm mới
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputs();
            button2.Visible = true;
            this.Refresh();
        }

        // Thêm một thuốc mới
        private void button2_Click(object sender, EventArgs e)
        {
            var (tenThuoc, hamLuong, cachDung, gia, tonKho) = GetThuocInput();

            if (!ValidateThuocData())
            {
                return; 
            }

            if (!string.IsNullOrWhiteSpace(tenThuoc))
            {
                if (KiemTraTrung(0, tenThuoc))
                {
                    MessageBox.Show("Tên thuốc đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }

            // Câu lệnh SQL để thêm thuốc mới
            string query = "INSERT INTO THUOC (TenThuoc, HamLuong, CachDung, Gia, TonKho) VALUES (@TenThuoc, @HamLuong, @CachDung, @Gia, @TonKho)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                        cmd.Parameters.AddWithValue("@HamLuong", hamLuong);
                        cmd.Parameters.AddWithValue("@CachDung", cachDung);
                        cmd.Parameters.AddWithValue("@Gia", gia);
                        cmd.Parameters.AddWithValue("@TonKho", tonKho);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thuốc đã được thêm thành công!");

                        LoadThuocData();
                        ClearInputs();
                        button2.Visible = false; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm thuốc: " + ex.Message);
                }
            }
        }

        // Sự kiện xóa thuốc
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int thuocID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ThuocID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        string deleteFromDetailQuery = "DELETE FROM CHITIETPHIEUTHANHTOAN WHERE ThuocID = @ThuocID";
                        using (SqlCommand cmd = new SqlCommand(deleteFromDetailQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ThuocID", thuocID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteFromPrescriptionQuery = "DELETE FROM DONTHUOC WHERE ThuocID = @ThuocID";
                        using (SqlCommand cmd = new SqlCommand(deleteFromPrescriptionQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ThuocID", thuocID);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteDrugQuery = "DELETE FROM THUOC WHERE ThuocID = @ThuocID";
                        using (SqlCommand cmd = new SqlCommand(deleteDrugQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ThuocID", thuocID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã xóa thuốc thành công.");

                        LoadThuocData();
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null) transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa thuốc: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc để xóa.");
            }
        }

        //Cập nhật thông tin
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var (tenThuoc, hamLuong, cachDung, gia, tonKho) = GetThuocInput();

            if (!ValidateThuocData())
            {
                return; 
            }

            if (dataGridView.SelectedRows.Count > 0)
            {
                int selectedThuocID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ThuocID"].Value);

                if (tenThuoc != GetThuocName(selectedThuocID))
                {
                    if (KiemTraTrung(selectedThuocID, tenThuoc)) 
                    {
                        MessageBox.Show("Tên thuốc đã tồn tại. Vui lòng nhập tên khác!");
                        return;
                    }
                }

                string query = "UPDATE THUOC SET TenThuoc = @TenThuoc, HamLuong = @HamLuong, CachDung = @CachDung, Gia = @Gia, TonKho = @TonKho " +
                               "WHERE ThuocID = @ThuocID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                            cmd.Parameters.AddWithValue("@HamLuong", hamLuong);
                            cmd.Parameters.AddWithValue("@CachDung", cachDung);
                            cmd.Parameters.AddWithValue("@Gia", gia);
                            cmd.Parameters.AddWithValue("@TonKho", tonKho);
                            cmd.Parameters.AddWithValue("@ThuocID", selectedThuocID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin thuốc đã được cập nhật thành công!");
                            LoadThuocData(); 
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin thuốc: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc cần cập nhật.");
            }
        }

        // Tìm kiếm thuốc
        private void button8_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();

            string query = "SELECT ThuocID, TenThuoc, HamLuong, CachDung, Gia, TonKho " +
                           "FROM THUOC ";

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT ThuocID, TenThuoc, HamLuong, CachDung, Gia, TonKho " +
                        "FROM THUOC";
            }
            else
            {
                query += "WHERE ThuocID LIKE @SearchText OR TenThuoc LIKE @SearchText";
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

                        dataGridView.DataSource = dataTable;

             if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy thuốc nào.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm thuốc: " + ex.Message);
                }
            }
        }
    }
}
