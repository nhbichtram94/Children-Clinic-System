using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.Forms
{
    public partial class KhamBenh : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";
        public KhamBenh()
        {
            InitializeComponent();
            LoadBacSiData();
            LoadPhieuKhamData();
        }
        private void LoadBacSiData()
        {
            try
            {
                int userID = UserSession.UserID; 
                string query = "SELECT HoTen, BacSiID FROM BACSI WHERE UserID = @userID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tenBacSi = reader["HoTen"].ToString();
                                int bacsiID = Convert.ToInt32(reader["BacSiID"]);

                                if (string.IsNullOrEmpty(tenBacSi))
                                {
                                    MessageBox.Show("Không tìm thấy thông tin bác sĩ!");
                                    return;
                                }

                                materialTextBox3.Text = tenBacSi;
                                materialTextBox3.Tag = bacsiID; 
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin bác sĩ!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bác sĩ: " + ex.Message);
            }
        }

        private void KhamBenh_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int phieuKhamID = (int)cboPhieuKham.SelectedValue;
                int bacSiID = (int)materialTextBox3.Tag; 
                int benhNhanID = (int)txtHoTenBenhNhan.Tag; 
                string chanDoan = materialTextBox1.Text.Trim(); 
                string dieuTri = materialTextBox2.Text.Trim(); 
                int chuyenKhoaID = (int)txtTenKhoa.Tag; 
                DateTime ngayKham = dateTimePicker.Value; 

                if (benhNhanID == 0 || chuyenKhoaID == 0)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin Bệnh Nhân và Chuyên Khoa!");
                    return;
                }

                string query = @"
                INSERT INTO HOSOBENHAN (BenhNhanID, BacSiID, ChuyenKhoaID, ChuanDoan, DieuTri, NgayKham,PhieuKhamID)
                VALUES (@BenhNhanID, @BacSiID,@ChuyenKhoaID, @ChuanDoan, @DieuTri, @NgayKham,@PhieuKhamID)";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacSiID);
                        cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);
                        cmd.Parameters.AddWithValue("@ChuanDoan", chanDoan);
                        cmd.Parameters.AddWithValue("@DieuTri", dieuTri);
                        cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                        cmd.Parameters.AddWithValue("@NgayKham", ngayKham);
                        cmd.Parameters.AddWithValue("@PhieuKhamID", phieuKhamID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lập hồ sơ thành công!");
                    }
                    materialTextBox1.Text = ""; 
                    materialTextBox2.Text = ""; 
                    cboPhieuKham.SelectedIndex = 0; 
                    LoadPhieuKhamData();
                    txtTenKhoa.Text = ""; 
                    dateTimePicker.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lập hồ sơ: " + ex.Message);
            }
        }
        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void LoadPhieuKhamData()
        {
            string query = @"
            SELECT PK.PhieuKhamID, BN.HoTen AS BNHoTen, PK.BenhNhanID, CK.TenChuyenKhoa, CK.ChuyenKhoaID, GH.HoTen AS GHHoTen
            FROM PHIEUKHAM PK
            LEFT JOIN BENHNHAN BN ON PK.BenhNhanID = BN.BenhNhanID
            LEFT JOIN GIAMHO GH ON PK.GiamHoID = GH.GiamHoID
            LEFT JOIN HOSOBENHAN HS ON PK.PhieuKhamID = HS.PhieuKhamID
            LEFT JOIN CHUYENKHOA CK ON PK.ChuyenKhoaID = CK.ChuyenKhoaID
            WHERE HS.PhieuKhamID IS NULL";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["PhieuKhamID"] = DBNull.Value;
                    emptyRow["BenhNhanID"] = DBNull.Value;
                    emptyRow["BNHoTen"] = "";
                    emptyRow["GHHoTen"] = "";
                    emptyRow["TenChuyenKhoa"] = "";
                    dataTable.Rows.InsertAt(emptyRow, 0);
                    dataTable.Columns.Add("DisplayText", typeof(string), "BNHoTen + ' - GH: ' + ISNULL(GHHoTen, 'Chưa có giám hộ')");

                    cboPhieuKham.DisplayMember = "PhieuKhamID";
                    cboPhieuKham.ValueMember = "PhieuKhamID";
                    cboPhieuKham.DataSource = dataTable;
                    cboPhieuKham.Tag = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu phiếu khám: " + ex.Message);
                }
            }
        }

        private void cboPhieuKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = cboPhieuKham.Tag as DataTable;
            if (dataTable != null && cboPhieuKham.SelectedIndex > 0)
            {
                DataRowView selectedRow = cboPhieuKham.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    txtHoTenBenhNhan.Text = selectedRow["DisplayText"].ToString(); 
                    txtHoTenBenhNhan.Tag = selectedRow["BenhNhanID"]; 
                    txtTenKhoa.Tag = selectedRow["ChuyenKhoaID"]; 
                    txtTenKhoa.Text = selectedRow["TenChuyenKhoa"].ToString(); 
                }
            }
            else
            {
                txtHoTenBenhNhan.Text = string.Empty;
                txtTenKhoa.Text = string.Empty;
            }
        }
    }
}
