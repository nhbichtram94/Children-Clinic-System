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
using quanlyphongkhamnhi.Services;
namespace quanlyphongkhamnhi.Forms
{
    public partial class DatKham : Form
    {

        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";
        private DatKhamService _service;

        public DatKham()
        {
            InitializeComponent();
            LoadBenhNhanData();
            LoadChuyenKhoaData();
            LoadKhungGio();
            dateTimePicker.ValueChanged += new EventHandler(DateTimePicker_ValueChanged);
            _service = new DatKhamService(connString); 
        }

        private void LoadKhungGio()
        {
            DateTime ngayKham = dateTimePicker.Value;
            string ngayTrongTuan = ngayKham.ToString("dddd", new System.Globalization.CultureInfo("vi-VN"));
            ngayTrongTuan = char.ToUpper(ngayTrongTuan[0]) + ngayTrongTuan.Substring(1);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn lấy khung giờ
                    SqlCommand cmd = new SqlCommand(
                        "SELECT KhungGioID, Buoi + N': ' + CONVERT(NVARCHAR(5), BatDau, 108) + N' - ' + CONVERT(NVARCHAR(5), KetThuc, 108) AS KhungThoiGian " +
                        "FROM KHUNG_GIO " +
                        "WHERE NgayTrongTuan = @NgayTrongTuan " +
                        "ORDER BY Buoi, BatDau", conn);

                    cmd.Parameters.AddWithValue("@NgayTrongTuan", ngayTrongTuan);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow emptyRow = dt.NewRow();
                    emptyRow["KhungThoiGian"] = "";
                    emptyRow["KhungGioID"] = DBNull.Value;
                    dt.Rows.InsertAt(emptyRow, 0);

                    materialComboBox3.DisplayMember = "KhungThoiGian";
                    materialComboBox3.ValueMember = "KhungGioID";
                    materialComboBox3.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu khung giờ: " + ex.Message);
                }
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadKhungGio();
        }

        public int? GetGiamHoIDFromUserID(int userID)
        {
            int? giamHoID = null;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT GiamHoID FROM GIAMHO WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            giamHoID = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }

            return giamHoID;
        }

        private void LoadBenhNhanData()
        {
            int userID = UserSession.UserID;
            int? giamHoID = GetGiamHoIDFromUserID(userID);

            if (!giamHoID.HasValue)
            {
                MessageBox.Show("Không tìm thấy thông tin Giám Hộ cho UserID này!");
                return;
            }

            string query = @"
                    SELECT BN.BenhNhanID, BN.HoTen
                    FROM BENHNHAN BN
                    JOIN GIAMHO_BENHNHAN GB ON BN.BenhNhanID = GB.BenhNhanID
                    WHERE GB.GiamHoID = @GiamHoID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@GiamHoID", giamHoID.Value);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["BenhNhanID"] = DBNull.Value;
                    emptyRow["HoTen"] = ""; // Hiển thị trống
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    // Gán dữ liệu vào ComboBox
                    materialComboBox1.DisplayMember = "HoTen";
                    materialComboBox1.ValueMember = "BenhNhanID";
                    materialComboBox1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu bệnh nhân: " + ex.Message);
                }
            }
        }

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

                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["ChuyenKhoaID"] = DBNull.Value;
                    emptyRow["TenChuyenKhoa"] = "";
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    materialComboBox2.DisplayMember = "TenChuyenKhoa";
                    materialComboBox2.ValueMember = "ChuyenKhoaID";
                    materialComboBox2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu chuyên khoa: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedValue == DBNull.Value || materialComboBox2.SelectedValue == DBNull.Value || materialComboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
                return;
            }

            int benhNhanID = (int)materialComboBox1.SelectedValue;
            int chuyenKhoaID = (int)materialComboBox2.SelectedValue;
            DateTime ngayKham = dateTimePicker.Value;
            int khungGioID = (int)materialComboBox3.SelectedValue;

            int giamHoID = GetGiamHoIDFromUserID(UserSession.UserID).GetValueOrDefault();

            try
            {
                int phieuKhamID = _service.TaoPhieuKham(benhNhanID, giamHoID, chuyenKhoaID, ngayKham, khungGioID);


                if (phieuKhamID > 0)
                {
                    MessageBox.Show("Tạo phiếu khám thành công. Mã phiếu: " + phieuKhamID);
                }
                else
                {
                    MessageBox.Show("Tạo phiếu khám thất bại. Ngày khám không hợp lệ hoặc dữ liệu chưa đầy đủ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo phiếu khám: " + ex.Message);
            }
        }
        }

       
    }

