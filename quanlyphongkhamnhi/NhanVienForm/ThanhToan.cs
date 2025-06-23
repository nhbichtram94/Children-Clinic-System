using MaterialSkin.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace quanlyphongkhamnhi.Forms
{
    public partial class ThanhToan : Form
    {
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123"  ;
        private PrintDocument printDocument = new PrintDocument();

        public ThanhToan()
        {
            InitializeComponent();
            LoadHoSoBenhAn();
            LoadPhuongThucThanhToan();
            LoadHoaDon();
            materialComboBox2.SelectedIndexChanged += materialComboBox2_SelectedIndexChanged;
            materialComboBox1.SelectedIndexChanged += materialComboBox1_SelectedIndexChanged;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        //Sự kiện in hóa đơn
        private void materialButton3_Click(object sender, EventArgs e)
        {
            // Thực hiện lệnh in
            printDialog1.Document = printDocument;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print(); // Gửi lệnh in
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Lấy nội dung của RichTextBox cần in
            string textToPrint = richTextBox1.Text;

            // Thiết lập font chữ và màu sắc
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            // Vẽ văn bản trên đối tượng Graphics của PrintPageEventArgs
            e.Graphics.DrawString(textToPrint, printFont, printBrush, e.MarginBounds.Left, e.MarginBounds.Top);

            // Xác nhận không có thêm trang in
            e.HasMorePages = false;
        }

        private void LoadHoaDon()
        {
            // Truy vấn tất cả hóa đơn trong hệ thống
            string query = @"
        SELECT HoaDonID, 
               BN.HoTen + ' - ' + DH.TenDichVu AS HoaDonInfo
        FROM HOADON HD
        JOIN BENHNHAN BN ON HD.BenhNhanID = BN.BenhNhanID
        JOIN DICHVUKHAM DH ON HD.DichVuID = DH.DichVuID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Kiểm tra xem có dữ liệu hóa đơn hay không
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn nào trong hệ thống.");
                        return; // Nếu không có hóa đơn, không cần tiếp tục
                    }

                    // Thêm một dòng trống để ComboBox có giá trị rỗng
                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["HoaDonID"] = DBNull.Value;
                    emptyRow["HoaDonInfo"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    // Cấu hình ComboBox để hiển thị thông tin và giá trị hóa đơn
                    materialComboBox2.DisplayMember = "HoaDonInfo";
                    materialComboBox2.ValueMember = "HoaDonID";
                    materialComboBox2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message);
                }
            }
        }

        private void LoadHoSoBenhAn()
        {
            string query = @"
                SELECT HoSoID, 
                       BN.HoTen + ' - GH: ' + ISNULL(GH.HoTen, 'Chưa có giám hộ') AS BenhNhan
                FROM HOSOBENHAN HBA
                JOIN BENHNHAN BN ON HBA.BenhNhanID = BN.BenhNhanID
                LEFT JOIN GIAMHO_BENHNHAN GHB ON BN.BenhNhanID = GHB.BenhNhanID
                LEFT JOIN GIAMHO GH ON GHB.GiamHoID = GH.GiamHoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Thêm một dòng trống để ComboBox có giá trị rỗng
                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["HoSoID"] = DBNull.Value;
                    emptyRow["BenhNhan"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    materialComboBox1.DisplayMember = "BenhNhan";
                    materialComboBox1.ValueMember = "HoSoID";
                    materialComboBox1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu hồ sơ bệnh án: " + ex.Message);
                }
            }
        }

        private void LoadPhuongThucThanhToan()
        {
            string query = "SELECT PhuongThucID, TenPhuongThuc FROM PHUONGTHUCTHANHTOAN";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    materialComboBox3.DisplayMember = "TenPhuongThuc";
                    materialComboBox3.ValueMember = "PhuongThucID";
                    materialComboBox3.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải phương thức thanh toán: " + ex.Message);
                }
            }
        }


        //Xuất hóa đơn
        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ComboBox
                int hoSoID = (int)materialComboBox1.SelectedValue;
                int phuongThucID = (int)materialComboBox3.SelectedValue;

                if (hoSoID <= 0 || phuongThucID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ bệnh án và phương thức thanh toán.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("TaoHoaDon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@HoSoID", hoSoID);
                    cmd.Parameters.AddWithValue("@PhuongThucID", phuongThucID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadHoaDon();
                    MessageBox.Show("Hóa đơn đã được tạo thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message);
            }
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox2.SelectedIndex <= 0)
            {
                richTextBox1.Clear();
                return;
            }

            int hoaDonID = (int)materialComboBox2.SelectedValue;

            LoadHoaDonDetails(hoaDonID);
        }

        private void LoadHoaDonDetails(int hoaDonID)
        {
            string query = "EXEC XuatHoaDon @HoaDonID = @HoaDonID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string hoaDonText = reader["HoaDonText"].ToString();
                        richTextBox1.Clear();
                        richTextBox1.Font = new Font("Courier New", 10);

                        string[] lines = hoaDonText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        foreach (string line in lines)
                        {
                            richTextBox1.AppendText(line.Replace("|", "\t") + Environment.NewLine);
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
                }
            }
        }
        private void TimKiemHoaDon(int? hoaDonID, int? hoSoID)
        {
            string query = "EXEC TimKiemHoaDon @HoaDonID = @HoaDonID, @HoSoID = @HoSoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID.HasValue ? (object)hoaDonID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@HoSoID", hoSoID.HasValue ? (object)hoSoID.Value : DBNull.Value);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            int hoaDonIDFromDb = Convert.ToInt32(reader["HoaDonID"]);
                            LoadHoaDonDetails(hoaDonIDFromDb);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn hoặc hồ sơ bệnh án.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            int? hoaDonID = string.IsNullOrEmpty(materialTextBox1.Text) ? (int?)null : Convert.ToInt32(materialTextBox1.Text);
            int? hoSoID = string.IsNullOrEmpty(materialTextBox1.Text) ? (int?)null : Convert.ToInt32(materialTextBox1.Text);

            TimKiemHoaDon(hoaDonID, hoSoID);
        }


        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedItem != null)
            {
                // Lấy HoSoID từ giá trị được chọn
                int hoSoID = Convert.ToInt32(materialComboBox1.SelectedValue);
                HienThiHoSoBenhAn(hoSoID);
            }
        }

        private void HienThiHoSoBenhAn(int hoSoID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("XemThongTinHoSo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HoSoID", hoSoID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy nội dung văn bản từ Stored Procedure
                        string hoSoText = reader["HoSoText"].ToString();

                        // Xóa nội dung cũ và thiết lập font monospace
                        richTextBox1.Clear();
                        richTextBox1.Font = new Font("Courier New", 10);

                        // Chia dòng dựa trên ký tự xuống dòng
                        string[] lines = hoSoText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        foreach (string line in lines)
                        {
                            // Thêm từng dòng vào RichTextBox
                            richTextBox1.AppendText(line + Environment.NewLine);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin hồ sơ.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị thông tin hồ sơ bệnh án: " + ex.Message);
                }
            }
        }
    }
}
