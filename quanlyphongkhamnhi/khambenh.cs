using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkhamnhi.KhamBenhServices
{
    // Interface để trừu tượng truy cập DB
    public interface IDataAccess
    {
        SqlDataReader ExecuteReader(string query, Dictionary<string, object> parameters);
        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);
        DataTable ExecuteDataTable(string query, Dictionary<string, object> parameters = null);
    }

    // Class thực thi IDataAccess sử dụng SqlClient
    public class SqlDataAccess : IDataAccess
    {
        private readonly string _connString;
        public SqlDataAccess(string connString)
        {
            _connString = connString;
        }

        public SqlDataReader ExecuteReader(string query, Dictionary<string, object> parameters)
        {
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using SqlConnection conn = new SqlConnection(_connString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataTable ExecuteDataTable(string query, Dictionary<string, object> parameters = null)
        {
            using SqlConnection conn = new SqlConnection(_connString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }

    // Lớp chứa các logic nghiệp vụ khám bệnh
    public class KhamBenh
    {
        private readonly IDataAccess _dataAccess;

        public KhamBenh(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // Validate input trước khi thêm hồ sơ
        public bool ValidateInput(int benhNhanID, int chuyenKhoaID)
        {
            return benhNhanID != 0 && chuyenKhoaID != 0;
        }

        // Lấy thông tin bác sĩ theo UserID
        public (string tenBacSi, int bacSiID)? GetBacSiByUserID(int userID)
        {
            string query = "SELECT HoTen, BacSiID FROM BACSI WHERE UserID = @userID";
            var parameters = new Dictionary<string, object> { { "@userID", userID } };

            using var reader = _dataAccess.ExecuteReader(query, parameters);
            if (reader.Read())
            {
                string tenBacSi = reader["HoTen"].ToString();
                int bacSiID = Convert.ToInt32(reader["BacSiID"]);
                if (string.IsNullOrEmpty(tenBacSi))
                    return null;
                return (tenBacSi, bacSiID);
            }
            return null;
        }

        // Lấy danh sách phiếu khám chưa có hồ sơ bệnh án
        public DataTable LoadPhieuKhamData()
        {
            string query = @"
                SELECT PK.PhieuKhamID, BN.HoTen AS BNHoTen, PK.BenhNhanID, CK.TenChuyenKhoa, CK.ChuyenKhoaID, GH.HoTen AS GHHoTen
                FROM PHIEUKHAM PK
                LEFT JOIN BENHNHAN BN ON PK.BenhNhanID = BN.BenhNhanID
                LEFT JOIN GIAMHO GH ON PK.GiamHoID = GH.GiamHoID
                LEFT JOIN HOSOBENHAN HS ON PK.PhieuKhamID = HS.PhieuKhamID
                LEFT JOIN CHUYENKHOA CK ON PK.ChuyenKhoaID = CK.ChuyenKhoaID
                WHERE HS.PhieuKhamID IS NULL";

            var dt = _dataAccess.ExecuteDataTable(query);

            // Thêm hàng trống cho combobox UI (nếu cần)
            var emptyRow = dt.NewRow();
            emptyRow["PhieuKhamID"] = DBNull.Value;
            emptyRow["BenhNhanID"] = DBNull.Value;
            emptyRow["BNHoTen"] = "";
            emptyRow["GHHoTen"] = "";
            emptyRow["TenChuyenKhoa"] = "";
            dt.Rows.InsertAt(emptyRow, 0);

            dt.Columns.Add("DisplayText", typeof(string), "BNHoTen + ' - GH: ' + ISNULL(GHHoTen, 'Chưa có giám hộ')");
            return dt;
        }

        // Thêm hồ sơ bệnh án mới
        public bool InsertHoSoBenhAn(int benhNhanID, int bacSiID, int chuyenKhoaID, string chanDoan, string dieuTri, DateTime ngayKham, int phieuKhamID)
        {
            if (!ValidateInput(benhNhanID, chuyenKhoaID))
                return false;

            string query = @"
                INSERT INTO HOSOBENHAN (BenhNhanID, BacSiID, ChuyenKhoaID, ChuanDoan, DieuTri, NgayKham, PhieuKhamID)
                VALUES (@BenhNhanID, @BacSiID, @ChuyenKhoaID, @ChuanDoan, @DieuTri, @NgayKham, @PhieuKhamID)";

            var parameters = new Dictionary<string, object>()
            {
                {"@BenhNhanID", benhNhanID},
                {"@BacSiID", bacSiID},
                {"@ChuyenKhoaID", chuyenKhoaID},
                {"@ChuanDoan", chanDoan},
                {"@DieuTri", dieuTri},
                {"@NgayKham", ngayKham},
                {"@PhieuKhamID", phieuKhamID}
            };

            int rowsAffected = _dataAccess.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
