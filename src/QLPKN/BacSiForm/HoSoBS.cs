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
using System.Xml.Linq;

namespace quanlyphongkhamnhi.Forms
{
    public partial class HoSoBS : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public HoSoBS()
        {
            InitializeComponent();
            LoadBacSiData();
        }


        private void LoadBacSiData()
        {
            try
            {
                int bacsiID = UserSession.UserID;

                string query = @"
                            SELECT BS.HoTen, BS.NgaySinh, BS.GTinh, 
                            CK.TenChuyenKhoa, PLV.TenPhong, 
                            BS.Email, BS.Sodienthoai, BS.DChi, ND.Username, ND.Matkhau,
                            BS.ChuyenKhoaID, BS.PhongID
                            FROM BACSI BS
                            LEFT JOIN CHUYENKHOA CK ON BS.ChuyenKhoaID = CK.ChuyenKhoaID
                            LEFT JOIN PHONGLAMVIEC PLV ON BS.PhongID = PLV.PhongID
                            LEFT JOIN NGUOIDUNG ND ON BS.UserID = ND.UserID
                            WHERE BS.UserID = @bacsiID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BacSiID", bacsiID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["HoTen"].ToString();
                                dateTimePicker.Value = Convert.ToDateTime(reader["NgaySinh"]);
                                txtGioiTinh.Text = reader["GTinh"].ToString() == "1" ? "Nam" : "Nữ";
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhone.Text = reader["Sodienthoai"].ToString();
                                txtDiaChi.Text = reader["DChi"].ToString();

                                txtChuyenKhoa.Text = reader["TenChuyenKhoa"].ToString();
                                txtPhong.Text = reader["TenPhong"].ToString();

                                txtUser.Text = reader["Username"].ToString();
                                txtMatKhau.Text = reader["Matkhau"].ToString();

                                txtName.ReadOnly = true;
                                dateTimePicker.Enabled = false;
                                txtGioiTinh.ReadOnly = true;
                                txtEmail.ReadOnly = true;
                                txtPhone.ReadOnly = true;
                                txtDiaChi.ReadOnly = true;
                                txtChuyenKhoa.ReadOnly = true;
                                txtPhong.ReadOnly = true;
                                txtUser.ReadOnly = true;
                                txtMatKhau.ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin bác sĩ!");
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bác sĩ: " + ex.Message);
            }
        }
        private void HoSoBS_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtMatKhau.ReadOnly = false;

            txtPhone.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                int bacsiID = UserSession.UserID;

                string updateBacSiQuery = @"
                    UPDATE BACSI
                    SET Email = @Email, 
                    Sodienthoai = @Sodienthoai, 
                    DChi = @DChi
                    WHERE UserID = @bacsiID";

                string updateTaiKhoanQuery = @"
                    UPDATE NGUOIDUNG
                    SET Matkhau = @Matkhau
                    WHERE UserID = @bacsiID";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmdBacSi = new SqlCommand(updateBacSiQuery, conn, transaction))
                            {
                                cmdBacSi.Parameters.AddWithValue("@Email", txtEmail.Text);
                                cmdBacSi.Parameters.AddWithValue("@Sodienthoai", txtPhone.Text);
                                cmdBacSi.Parameters.AddWithValue("@DChi", txtDiaChi.Text);
                                cmdBacSi.Parameters.AddWithValue("@BacSiID", bacsiID);

                                cmdBacSi.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdTaiKhoan = new SqlCommand(updateTaiKhoanQuery, conn, transaction))
                            {
                                cmdTaiKhoan.Parameters.AddWithValue("@Matkhau", txtMatKhau.Text);
                                cmdTaiKhoan.Parameters.AddWithValue("@BacSiID", bacsiID);

                                cmdTaiKhoan.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            txtPhone.ReadOnly = true;
                            txtEmail.ReadOnly = true;
                            txtDiaChi.ReadOnly = true;
                            txtMatKhau.ReadOnly = true;
                            MessageBox.Show("Cập nhật thông tin thành công!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
