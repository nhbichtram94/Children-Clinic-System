using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace quanlyphongkhamnhi.Services
{
    public class DatKhamService
    {
        private readonly string _connString;

        public DatKhamService(string connString)
        {
            _connString = connString;
        }

        public int? GetGiamHoIDFromUserID(int userID)
        {
            if (userID <= 0) return null;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string query = "SELECT GiamHoID FROM GIAMHO WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result);
                }
            }
            return null;
        }

        public DataTable LoadKhungGio(DateTime ngayKham)
        {
            // Lấy tên ngày trong tuần theo tiếng Việt, viết hoa chữ đầu
            string ngayTrongTuan = ngayKham.ToString("dddd", new CultureInfo("vi-VN"));
            ngayTrongTuan = char.ToUpper(ngayTrongTuan[0]) + ngayTrongTuan.Substring(1);

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string sql = @"
                    SELECT KhungGioID, Buoi + N': ' 
                        + CONVERT(NVARCHAR(5), BatDau, 108) 
                        + N' - ' 
                        + CONVERT(NVARCHAR(5), KetThuc, 108) AS KhungThoiGian
                    FROM KHUNG_GIO 
                    WHERE NgayTrongTuan = @NgayTrongTuan 
                    ORDER BY Buoi, BatDau";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayTrongTuan", ngayTrongTuan);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable LoadBenhNhanData(int giamHoID)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string sql = "SELECT BenhNhanID, HoTen FROM BENHNHAN WHERE GiamHoID = @GiamHoID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable LoadChuyenKhoaData()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string sql = "SELECT ChuyenKhoaID, TenChuyenKhoa FROM CHUYENKHOA";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int TaoPhieuKham(int benhNhanID, int giamHoID, int chuyenKhoaID, DateTime ngayKham, int khungGioID)
        {
            if (benhNhanID <= 0 || giamHoID <= 0 || chuyenKhoaID <= 0 || khungGioID <= 0 || ngayKham.Date < DateTime.Today)
                return 0;

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("TaoPhieuKham", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BenhNhanID", benhNhanID);
                    cmd.Parameters.AddWithValue("@GiamHoID", giamHoID);
                    cmd.Parameters.AddWithValue("@ChuyenKhoaID", chuyenKhoaID);
                    cmd.Parameters.AddWithValue("@NgayKham", ngayKham);
                    cmd.Parameters.AddWithValue("@KhungGioID", khungGioID);

                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int newID))
                        return newID;
                    else
                        throw new Exception("Không nhận được ID phiếu khám mới từ stored procedure.");
                }
            }
        }

    }
}
