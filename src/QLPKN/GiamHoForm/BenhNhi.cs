using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkhamnhi.Forms
{
    public partial class BenhNhi : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public BenhNhi()
        {
            InitializeComponent();
            LoadInfo();
            BenhNhi_Load();
            LoadVaiTroGiamHo();
            materialComboBox2.SelectedIndexChanged += materialComboBox2_SelectedIndexChanged;
            materialButton2.Visible = false;
            materialTextBox4.Enabled = false;
            materialTextBox5.Enabled = false;
            materialTextBox7.Enabled = false;
            materialTextBox6.Enabled = false;
            materialComboBox1.Enabled = false;
            materialComboBox4.Enabled = false;
        }

        private void LoadVaiTroGiamHo()
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

                    materialComboBox4.DisplayMember = "TenQuanHe"; 
                    materialComboBox4.ValueMember = "LoaiQuanHeID";    
                    materialComboBox4.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu phòng làm việc: " + ex.Message);
                }
            }
        }

        private void LoadInfo()
        {
            try
            {
                // Truy xuất UserID từ UserSession
                int userID = UserSession.UserID; // Lấy UserID từ lớp UserSession

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Lấy danh sách bệnh nhi dựa trên userID
                    string query = @"
                        SELECT BN.BenhNhanID, BN.HoTen 
                        FROM BENHNHAN BN
                        INNER JOIN GIAMHO_BENHNHAN GHB ON BN.BenhNhanID = GHB.BenhNhanID
                        INNER JOIN GIAMHO GH ON GHB.GiamHoID = GH.GiamHoID
                        WHERE GH.UserID = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    materialComboBox2.DisplayMember = "HoTen";
                    materialComboBox2.ValueMember = "BenhNhanID";
                    materialComboBox2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox2.SelectedValue is int selectedBenhNhanID)
            {
                LoadBenhNhiDetails(selectedBenhNhanID);
            }
        }

        private void LoadBenhNhiDetails(int benhNhanID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Lấy thông tin chi tiết của bệnh nhi
                    string query = @"
                SELECT BN.HoTen, BN.NgSinh, BN.GioiTinh, LQH.TenQuanHe AS VaiTro
                FROM BENHNHAN BN
                INNER JOIN GIAMHO_BENHNHAN GHB ON BN.BenhNhanID = GHB.BenhNhanID
                INNER JOIN LOAIQUANHE LQH ON GHB.LoaiQuanHeID = LQH.LoaiQuanHeID
                WHERE BN.BenhNhanID = @BenhNhanID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["HoTen"].ToString();
                        dtpNgaySinh.Value = DateTime.Parse(reader["NgSinh"].ToString());
                        string gioiTinh = reader["GioiTinh"].ToString().Trim();
                        materialComboBox3.SelectedItem = gioiTinh == "Nam" ? "Nam" : "Nữ";
                        string vaiTro = reader["VaiTro"].ToString();
                        materialComboBox4.SelectedItem = vaiTro;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết bệnh nhi: " + ex.Message);
            }
        }

        private void BenhNhi_Load()
        {
            LoadGiamHoInformation(UserSession.UserID);
        }

        private void LoadGiamHoInformation(int userID)
        {
            string query = @"
        SELECT 
            gh.HoTen AS HoTenGiamHo, 
            gh.NgaySinh AS NgaySinhGiamHo, 
            gh.GTinh AS GioiTinhGiamHo, 
            gh.Sodienthoai AS SoDienThoaiGiamHo, 
            gh.DChi AS DiaChiGiamHo,
            nd.Username AS TenDangNhap, 
            nd.Matkhau AS MatKhau
        FROM GIAMHO gh
        JOIN NGUOIDUNG nd ON gh.UserID = nd.UserID
        WHERE gh.UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Debug: In giá trị để kiểm tra
                                MessageBox.Show("Số điện thoại giám hộ: " + reader["SoDienThoaiGiamHo"].ToString());

                                // Gán giá trị cho các control trong form
                                materialTextBox3.Text = reader["HoTenGiamHo"].ToString(); // Họ tên giám hộ
                                dateTimePicker1.Value = Convert.ToDateTime(reader["NgaySinhGiamHo"]); // Ngày sinh giám hộ

                                // Gán giá trị giới tính giám hộ vào materialComboBox1
                                string gioiTinh = reader["GioiTinhGiamHo"].ToString();
                                materialComboBox1.SelectedItem = gioiTinh == "Nam" ? "Nam" : "Nữ"; // Chọn Nam hoặc Nữ

                                materialTextBox4.Text = reader["SoDienThoaiGiamHo"].ToString(); // Số điện thoại giám hộ
                                materialTextBox5.Text = reader["DiaChiGiamHo"].ToString(); // Địa chỉ giám hộ
                                materialTextBox6.Text = reader["TenDangNhap"].ToString(); // Tên đăng nhập
                                materialTextBox7.Text = reader["MatKhau"].ToString(); // Mật khẩu
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin giám hộ cho người dùng này.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Hiển thị nút "Lưu thay đổi" và cho phép chỉnh sửa thông tin
            materialButton2.Visible = true;
            materialTextBox4.Enabled = true;  // Cho phép chỉnh sửa số điện thoại
            materialTextBox5.Enabled = true;  // Cho phép chỉnh sửa địa chỉ
            materialTextBox7.Enabled = true;  // Cho phép chỉnh sửa mật khẩu
            materialTextBox6.Enabled = true;  // Cho phép chỉnh sửa tên tài khoản
        }


        private bool ValidateInputs(string phoneNumber, string address, string password)
        {
            // Kiểm tra số điện thoại (chỉ chứa các số và độ dài 10-11 ký tự)
            string phonePattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10-11 chữ số.");
                return false;
            }

            // Kiểm tra địa chỉ (chỉ chứa chữ cái, số, dấu cách và các ký tự thông thường)
            string addressPattern = @"^[\p{L}\p{N}\s,.-]+$";
            if (!Regex.IsMatch(address, addressPattern))
            {
                MessageBox.Show("Địa chỉ không hợp lệ. Vui lòng chỉ nhập các ký tự chữ, số và ký tự hợp lệ (, . -).");
                return false;
            }

            // Kiểm tra mật khẩu (ít nhất 8 ký tự, không chứa ký tự đặc biệt)
            string passwordPattern = @"^[a-zA-Z0-9]{8,}$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("Mật khẩu không hợp lệ. Mật khẩu phải có ít nhất 8 ký tự và không chứa ký tự đặc biệt.");
                return false;
            }

            return true;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            string soDienThoaiMoi = materialTextBox4.Text.Trim();
            string diaChiMoi = materialTextBox5.Text.Trim();
            string matKhauMoi = materialTextBox7.Text.Trim();
            string tenTaiKhoanMoi = materialTextBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(soDienThoaiMoi) || string.IsNullOrWhiteSpace(diaChiMoi) || string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (!ValidateInputs(soDienThoaiMoi, diaChiMoi, matKhauMoi))
            {
                return; 
            }

            tenTaiKhoanMoi = soDienThoaiMoi;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                UPDATE GIAMHO
                SET 
                    Sodienthoai = @SoDienThoaiMoi, 
                    DChi = @DiaChiMoi
                WHERE UserID = @UserID;

                UPDATE NGUOIDUNG
                SET 
                    Username = @TenTaiKhoanMoi, 
                    Matkhau = @MatKhauMoi
                WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDienThoaiMoi", soDienThoaiMoi);
                        cmd.Parameters.AddWithValue("@DiaChiMoi", diaChiMoi);
                        cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                        cmd.Parameters.AddWithValue("@TenTaiKhoanMoi", tenTaiKhoanMoi);
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            materialButton2.Visible = false;
                            materialTextBox4.Enabled = false;
                            materialTextBox5.Enabled = false;
                            materialTextBox7.Enabled = false;
                            materialTextBox6.Enabled = false;

                            MessageBox.Show("Thông tin đã được cập nhật thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật thông tin.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        //Bệnh nhi mới
        private void materialButton3_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            materialComboBox3.Enabled = true;
            materialComboBox4.Enabled = true;
            materialButton4.Visible = true;
        }

        //Lưu bệnh nhi mới
        private void materialButton4_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = materialComboBox3.SelectedItem?.ToString();
            string vaitro = materialComboBox4.SelectedItem?.ToString();
            int loaiQuanHeID = (int)materialComboBox4.SelectedValue; 

            // Kiểm tra dữ liệu nhập vào
            string validationMessage = ValidateInput();

            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            // Gọi thủ tục SQL để thêm bệnh nhi
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("AddBenhNhi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào thủ tục
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgSinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@LoaiQuanHeID", loaiQuanHeID);  
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int benhNhanID = reader.GetInt32(0);
                            LoadInfo();
                            txtHoTen.Clear();
                            dtpNgaySinh.Value = DateTime.Now;
                            materialComboBox3.SelectedIndex = -1;
                            materialComboBox4.SelectedIndex = -1;  
                            materialButton4.Visible = false;
                            MessageBox.Show("Bệnh nhi đã được thêm thành công. Mã bệnh nhi: " + benhNhanID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh nhi: " + ex.Message);
            }
        }

        // Hàm kiểm tra dữ liệu nhập vào
        private string ValidateInput()
        {
            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = materialComboBox1.SelectedItem?.ToString();
            string vaiTro = materialComboBox4.SelectedValue.ToString();

            // Kiểm tra đầy đủ thông tin
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(gioiTinh) || string.IsNullOrWhiteSpace(vaiTro))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // Kiểm tra nếu bệnh nhi trên 15 tuổi
            if (DateTime.Now.Year - ngaySinh.Year > 15)
            {
                return "Bệnh nhi không được quá 15 tuổi.";
            }

            // Kiểm tra tên không chứa ký tự số hoặc ký tự đặc biệt, chỉ cho phép chữ cái và dấu cách
            string vietNamePattern = @"^[\p{L}]+([\s][\p{L}]+)*$"; 
            if (!Regex.IsMatch(hoTen, vietNamePattern))
            {
                return "Họ tên không hợp lệ, không được chứa số hoặc ký tự đặc biệt.";
            }

            if (gioiTinh == "Nam" && vaiTro == "2")
            {
                return "Giám hộ là nam, không thể chọn vai trò 'Mẹ'.";
            }

            if (gioiTinh == "Nữ" && vaiTro == "1")
            {
                return "Giám hộ là nữ, không thể chọn vai trò 'Cha'.";
            }

            return string.Empty;  
        }
    }
}
