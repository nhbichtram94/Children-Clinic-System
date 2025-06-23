using System;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.ServicesPK
{
    public interface IPhieuKhamService
    {
        int? GetGiamHoIDFromUserID(int userID);
        string GetPhieuKhamTextByID(int phieuKhamID);
    }

    public class PhieuKhamService : IPhieuKhamService
    {
        private readonly string _connString;

        public PhieuKhamService(string connString)
        {
            _connString = connString;
        }

        public int? GetGiamHoIDFromUserID(int userID)
        {
            int? giamHoID = null;
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                string query = "SELECT GiamHoID FROM GIAMHO WHERE UserID = @UserID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        giamHoID = Convert.ToInt32(result);
                }
            }
            return giamHoID;
        }

        public string GetPhieuKhamTextByID(int phieuKhamID)
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                string query = "EXEC HienThiPhieuKham @PhieuKhamID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhieuKhamID", phieuKhamID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var result = reader["PhieuKhamText"]?.ToString();
                            if (string.IsNullOrWhiteSpace(result))
                                return null;  // Trả về null nếu chuỗi rỗng hoặc toàn khoảng trắng
                            return result;
                        }
                    }
                }
            }
            return null;
        }

    }
}
