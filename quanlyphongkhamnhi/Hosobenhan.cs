using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace QuanLyPhongKham.Services
{
    public class HoSoBenhAnService
    {
        private readonly string _connString;

        public HoSoBenhAnService(string connString)
        {
            _connString = connString;
        }

        // Hàm kiểm tra tên bệnh nhân hợp lệ
        private bool IsValidTenBenhNhan(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten))
                return false;

            // Regex chỉ cho phép chữ cái (unicode), số và khoảng trắng
            // Không cho phép ký tự đặc biệt
            var regex = new Regex(@"^[\p{L}\p{Nd} ]+$");

            return regex.IsMatch(ten);
        }

        // Lấy danh sách hồ sơ bệnh án theo UserID (GiamHo.UserID), chỉ trả về hồ sơ có tên BN hợp lệ
        public DataTable GetHoSoBenhAnByUser(int userId)
        {
            var dt = new DataTable();

            using (var conn = new SqlConnection(_connString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT 
                        HBA.HoSoID, 
                        BN.HoTen AS TenBenhNhan, 
                        HBA.ChuanDoan, 
                        FORMAT(HBA.NgayKham, 'dd/MM/yyyy HH:mm') AS NgayKham
                    FROM 
                        HOSOBENHAN HBA
                        JOIN BENHNHAN BN ON HBA.BenhNhanID = BN.BenhNhanID
                        JOIN GIAMHO_BENHNHAN GHB ON GHB.BenhNhanID = BN.BenhNhanID
                        JOIN GIAMHO GH ON GHB.GiamHoID = GH.GiamHoID
                    WHERE 
                        GH.UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", userId);

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Lọc bảng chỉ giữ những dòng có tên hợp lệ
            DataTable filtered = dt.Clone(); // clone cấu trúc cột

            foreach (DataRow row in dt.Rows)
            {
                string tenBN = row["TenBenhNhan"].ToString();
                if (IsValidTenBenhNhan(tenBN))
                {
                    filtered.ImportRow(row);
                }
            }

            return filtered;
        }

        // Lấy nội dung chi tiết hồ sơ (HoSoText) theo HoSoID (Stored Procedure)
        public string GetHoSoTextById(int hoSoId)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "XemThongTinHoSo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoSoID", hoSoId);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["HoSoText"] == DBNull.Value)
                            return null;

                        return reader["HoSoText"].ToString();
                    }
                }
            }

            return null;
        }
    }
}
