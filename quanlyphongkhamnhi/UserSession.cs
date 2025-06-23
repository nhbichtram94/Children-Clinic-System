using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkhamnhi
{
    // UserSession.cs
    public static class UserSession
    {
        // Lưu trữ UserID và các thông tin khác về người dùng
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}
