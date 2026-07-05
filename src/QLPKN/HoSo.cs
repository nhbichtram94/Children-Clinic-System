using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace quanlyphongkhamnhi.Services
{
    public class HoSoService
    {
        private readonly string _connectionString;

        public HoSoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Validate dữ liệu nhập hợp lệ theo yêu cầu
        /// </summary>
        public bool ValidateInput(
            string hoTenGiamHo,
            string soDienThoaiGiamHo,
            string diaChiGiamHo,
            string hoTenBenhNhan,
            string gioiTinhBenhNhan,
            string vaiTroGiamHo,
            DateTime ngaySinhBenhNhan,
            out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;

            // 1. Tên giám hộ không được để trống
            if (string.IsNullOrWhiteSpace(hoTenGiamHo))
            {
                thongBaoLoi = "Tên giám hộ không được để trống";
                return false;
            }

            // 1.1 Kiểm tra tên giám hộ viết hoa chữ cái đầu mỗi từ
            if (!IsTitleCase(hoTenGiamHo))
            {
                thongBaoLoi = "Tên giám hộ phải viết hoa chữ cái đầu mỗi từ";
                return false;
            }

            // 2. SĐT giám hộ phải >= 10 ký tự và không rỗng
            if (string.IsNullOrWhiteSpace(soDienThoaiGiamHo) || soDienThoaiGiamHo.Length < 10)
            {
                thongBaoLoi = "SĐT không hợp lệ";
                return false;
            }

            // 3. Địa chỉ giám hộ không được để trống
            if (string.IsNullOrWhiteSpace(diaChiGiamHo))
            {
                thongBaoLoi = "Địa chỉ không được để trống";
                return false;
            }

            // 4. Tên bệnh nhân không được để trống
            if (string.IsNullOrWhiteSpace(hoTenBenhNhan))
            {
                thongBaoLoi = "Tên bệnh nhân không được để trống";
                return false;
            }

            // 4.1 Kiểm tra tên bệnh nhân viết hoa chữ cái đầu mỗi từ
            if (!IsTitleCase(hoTenBenhNhan))
            {
                thongBaoLoi = "Tên bệnh nhân phải viết hoa chữ cái đầu mỗi từ";
                return false;
            }

            // 5. Giới tính bệnh nhân không được để trống
            if (string.IsNullOrWhiteSpace(gioiTinhBenhNhan))
            {
                thongBaoLoi = "Giới tính không hợp lệ";
                return false;
            }

            // 6. Vai trò giám hộ không được để trống
            if (string.IsNullOrWhiteSpace(vaiTroGiamHo))
            {
                thongBaoLoi = "Vai trò không được để trống";
                return false;
            }

            // 6.1 Kiểm tra vai trò giám hộ viết hoa chữ cái đầu mỗi từ
            if (!IsTitleCase(vaiTroGiamHo))
            {
                thongBaoLoi = "Vai trò giám hộ phải viết hoa chữ cái đầu mỗi từ";
                return false;
            }

            // 7. Tính tuổi bệnh nhân chính xác
            int tuoiBenhNhan = DateTime.Now.Year - ngaySinhBenhNhan.Year;
            if (ngaySinhBenhNhan > DateTime.Now.AddYears(-tuoiBenhNhan))
            {
                tuoiBenhNhan--;
            }

            // Tuổi phải nằm trong khoảng 0 <= tuổi <= 15
            if (tuoiBenhNhan < 0)
            {
                thongBaoLoi = "Tuổi bệnh nhân không hợp lệ";
                return false;
            }
            if (tuoiBenhNhan > 15)
            {
                thongBaoLoi = "Tuổi vượt quá 15";
                return false;
            }

            // Nếu tất cả ràng buộc đều đúng
            return true;
        }

        /// <summary>
        /// Hàm kiểm tra chuỗi có viết hoa chữ cái đầu mỗi từ hay không
        /// Ví dụ: "Nguyễn Văn A" => true; "nguyễn văn a" => false
        /// </summary>
        private bool IsTitleCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(text.ToLower());

            // So sánh sau khi chuẩn hóa chữ hoa chữ thường
            return titleCase == text;
        }

        /// <summary>
        /// Ghi dữ liệu giám hộ và bệnh nhân vào DB qua thủ tục Insert_GiamHo_BenhNhan
        /// </summary>
        public void InsertGiamHoBenhNhan(
            string hoTenGiamHo, DateTime ngaySinhGiamHo, string gioiTinhGiamHo,
            string soDienThoaiGiamHo, string diaChiGiamHo, int userID,
            string hoTenBenhNhan, DateTime ngaySinhBenhNhan,
            string gioiTinhBenhNhan, string vaiTroGiamHo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert_GiamHo_BenhNhan", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@HoTenGiamHo", hoTenGiamHo);
                    cmd.Parameters.AddWithValue("@NgaySinhGiamHo", ngaySinhGiamHo);
                    cmd.Parameters.AddWithValue("@GTGiamHo", gioiTinhGiamHo);
                    cmd.Parameters.AddWithValue("@SoDienThoaiGiamHo", soDienThoaiGiamHo);
                    cmd.Parameters.AddWithValue("@DiaChiGiamHo", diaChiGiamHo);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@HoTenBenhNhan", hoTenBenhNhan);
                    cmd.Parameters.AddWithValue("@NgaySinhBenhNhan", ngaySinhBenhNhan);
                    cmd.Parameters.AddWithValue("@GTBenhNhan", gioiTinhBenhNhan);
                    cmd.Parameters.AddWithValue("@VaiTroGiámHo", vaiTroGiamHo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Ném lỗi lên phía gọi để xử lý UI
                throw;
            }
        }
    }
}
