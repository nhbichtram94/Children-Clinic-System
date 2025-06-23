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
    public partial class KeDonThuoc : Form
    {
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123"  ;

        public KeDonThuoc()
        {
            InitializeComponent();
            LoadBacSiData();
            LoadThuocData();
            SetupListViewColumns();

        }

        private void LoadBacSiData()
        {
            try
            {
                int bacsiID = UserSession.UserID;
                string query = "SELECT HoTen FROM BACSI WHERE UserID = @bacsiID ";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacsiID);
                        string tenBacSi = cmd.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(tenBacSi))
                        {
                            MessageBox.Show("Không tìm thấy thông tin bác sĩ!");
                            return;
                        }

                        txtName.Text = tenBacSi;
                        txtName.Tag = bacsiID; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bác sĩ: " + ex.Message);
            }
        }

        private void LoadHoSoData()
        {
            string query = @"
                SELECT HS.HoSoID
                FROM HOSOBENHAN HS
                LEFT JOIN CHITIET_HOSOBENHAN DT ON HS.HoSoID = DT.HoSoID
                WHERE DT.HoSoID IS NULL";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["HoSoID"] = DBNull.Value;
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    cboHoSo.DisplayMember = "HoSoID";
                    cboHoSo.ValueMember = "HoSoID";
                    cboHoSo.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu hồ sơ: " + ex.Message);
                }
            }
        }
        private void LoadThuocData()
        {
            string query = @"
                SELECT ThuocID, TenThuoc, Gia, CachDung, TonKho
                FROM THUOC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["ThuocID"] = DBNull.Value;
                    emptyRow["TenThuoc"] = ""; 
                    emptyRow["Gia"] = DBNull.Value; 
                    emptyRow["CachDung"] = "";
                    emptyRow["TonKho"] = DBNull.Value;
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    // Gán dữ liệu vào ComboBox
                    cboThuoc.DisplayMember = "TenThuoc";
                    cboThuoc.ValueMember = "ThuocID";
                    cboThuoc.DataSource = dataTable;
                    cboThuoc.Tag = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thuốc: " + ex.Message);
                }
            }
        }

        // Tạo một lớp để lưu thông tin thuốc trong ComboBox
        private void cboThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedItem != null)
            {
                DataTable dataTable = cboThuoc.Tag as DataTable;
                if (dataTable != null && cboThuoc.SelectedIndex > 0)
                {
                    DataRowView selectedRow = cboThuoc.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        txtCachDung.Text = selectedRow["CachDung"].ToString();
                        int tonKho = selectedRow["TonKho"] != DBNull.Value ? Convert.ToInt32(selectedRow["TonKho"]) : 0;
                        txtTonKho.Text = tonKho.ToString();
                    }
                }
                else
                {
                    txtCachDung.Text = string.Empty;
                    txtTonKho.Text = string.Empty;
                }

            }
        }


        private void txtThemThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy các thông tin từ form
                int hoSoID = Convert.ToInt32(cboHoSo.SelectedValue);
                int thuocID = Convert.ToInt32(cboThuoc.SelectedValue);
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                string cachDung = txtCachDung.Text;

                string insertQuery = @"
            INSERT INTO CHITIET_HOSOBENHAN (HoSoID, ThuocID, SoLuong, CachDung)
            VALUES (@HoSoID, @ThuocID, @SoLuong, @CachDung)";

                string updateQuery = @"
            UPDATE THUOC
            SET TonKho = TonKho - @SoLuong
            WHERE ThuocID = @ThuocID AND TonKho >= @SoLuong"; // Kiểm tra đủ số lượng

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@HoSoID", hoSoID);
                                cmdInsert.Parameters.AddWithValue("@ThuocID", thuocID);
                                cmdInsert.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdInsert.Parameters.AddWithValue("@CachDung", cachDung);

                                int rowsAffectedInsert = cmdInsert.ExecuteNonQuery();
                                if (rowsAffectedInsert == 0)
                                {
                                    MessageBox.Show("Có lỗi khi lưu chi tiết thuốc!");
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdUpdate.Parameters.AddWithValue("@ThuocID", thuocID);

                                int rowsAffectedUpdate = cmdUpdate.ExecuteNonQuery();
                                if (rowsAffectedUpdate == 0)
                                {
                                    MessageBox.Show("Số lượng thuốc không đủ trong kho!");
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Chi tiết đơn thuốc đã được lưu thành công ");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xử lý đơn thuốc: " + ex.Message);
                        }
                    }
                }

                cboThuoc.SelectedIndex = 0; 
                txtSoLuong.Clear();  
                LoadThuocData();
                LoadThuocHoSoData(hoSoID);  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn thuốc: " + ex.Message);
            }
        }

        private void txtTaoDonKhac_Click(object sender, EventArgs e)
        {
            LoadHoSoData();
        }

        private void cboHoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoSo.SelectedValue != null && cboHoSo.SelectedValue != DBNull.Value)
            {
                int hoSoID = Convert.ToInt32(cboHoSo.SelectedValue);

                LoadThuocHoSoData(hoSoID);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KeDonThuoc_Load(object sender, EventArgs e)
        {
            LoadHoSoData();
        }
        private void LoadThuocHoSoData(int hoSoID)
        {
            string query = @"
        SELECT T.TenThuoc, CT.SoLuong
        FROM CHITIET_HOSOBENHAN CT
        JOIN THUOC T ON CT.ThuocID = T.ThuocID
        WHERE CT.HoSoID = @HoSoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoSoID", hoSoID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    lstView1.Items.Clear();

                    while (reader.Read())
                    {
                        string tenThuoc = reader["TenThuoc"].ToString();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);

                        ListViewItem item = new ListViewItem(tenThuoc);
                        item.SubItems.Add(soLuong.ToString());

                        lstView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thuốc: " + ex.Message);
                }
            }
        }


        private void SetupListViewColumns()
        {
            lstView1.Columns.Add("Tên Thuốc", 150);
            lstView1.Columns.Add("Số Lượng", 100);

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong = 0;

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong < 0)
            {
                txtSoLuong.Text = "";
            }
        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
