using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace quanlyphongkhamnhi.HosoBacSiServices
{
    public class BacSiService
    {
        private readonly string _connString;

        public BacSiService(string connString)
        {
            _connString = connString;
        }

        public bool CapNhatBacSi(int bacsiID, string email, string sdt, string diachi, string matkhau)
        {
            // Validate dữ liệu đầu vào, không được để trống và hợp lệ
            if (!ValidateEmail(email)) return false;
            if (!ValidatePhone(sdt)) return false;
            if (!ValidateAddress(diachi)) return false;
            if (!ValidatePassword(matkhau)) return false;

            try
            {
                using SqlConnection conn = new SqlConnection(_connString);
                conn.Open();

                using SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Cập nhật bảng BACSI
                    const string updateBacSiSql = @"
                        UPDATE BACSI 
                        SET Email = @Email, Sodienthoai = @Sdt, DChi = @DiaChi 
                        WHERE UserID = @ID";

                    using (SqlCommand cmd = new SqlCommand(updateBacSiSql, conn, tran))
                    {
                        cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = email.Trim();
                        cmd.Parameters.Add("@Sdt", System.Data.SqlDbType.NVarChar, 10).Value = sdt.Trim();
                        cmd.Parameters.Add("@DiaChi", System.Data.SqlDbType.NVarChar, 255).Value = diachi.Trim();
                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = bacsiID;
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật bảng NGUOIDUNG
                    const string updateNguoiDungSql = @"
                        UPDATE NGUOIDUNG 
                        SET Matkhau = @MatKhau 
                        WHERE UserID = @ID";

                    using (SqlCommand cmd = new SqlCommand(updateNguoiDungSql, conn, tran))
                    {
                        cmd.Parameters.Add("@MatKhau", System.Data.SqlDbType.NVarChar, 255).Value = matkhau.Trim();
                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = bacsiID;
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            // Email chuẩn, dạng abc@domain.com
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim();

            // Đúng 10 chữ số, không chứa ký tự khác
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        private bool ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            address = address.Trim();

            if (address.Length > 255)
                return false;

            // Cho phép chữ, số, dấu cách, dấu phẩy, dấu chấm, dấu gạch ngang
            string pattern = @"^[a-zA-Z0-9\s,.\-]+$";
            return Regex.IsMatch(address, pattern);
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            password = password.Trim();

            if (password.Length < 6)
                return false;

            // Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt
            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecial = Regex.IsMatch(password, @"[\W_]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
