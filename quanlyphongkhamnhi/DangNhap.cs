using System.Linq;
using System.Text.RegularExpressions;

namespace quanlyphongkhamnhi.Utils
{
    public class RegistrationValidator
    {
        public string Validate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return "Vui lòng nhập đầy đủ số điện thoại và mật khẩu.";

            if (!Regex.IsMatch(username, @"^\d{10}$"))
                return "Tên đăng ký phải là số điện thoại gồm 10 chữ số.";

            if (password.Length < 8)
                return "Mật khẩu phải có ít nhất 8 ký tự.";
            if (password.Length > 20)
                return "Mật khẩu không được vượt quá 20 ký tự.";

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return "Mật khẩu phải chứa ít nhất một chữ hoa.";
            if (!Regex.IsMatch(password, @"[a-z]"))
                return "Mật khẩu phải chứa ít nhất một chữ thường.";
            if (!Regex.IsMatch(password, @"[0-9]"))
                return "Mật khẩu phải chứa ít nhất một số.";
            if (!Regex.IsMatch(password, @"[\W_]"))
                return "Mật khẩu phải chứa ít nhất một ký tự đặc biệt.";

            string[] bannedPasswords = { "12345678", "password", "qwerty", "matkhau123", "admin123" };
            if (bannedPasswords.Contains(password.ToLower()))
                return "Mật khẩu quá yếu, vui lòng chọn mật khẩu khác.";

            return null; // hợp lệ
        }
    }
}
