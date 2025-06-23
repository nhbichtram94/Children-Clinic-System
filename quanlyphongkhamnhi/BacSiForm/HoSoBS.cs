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
using quanlyphongkhamnhi.HosoBacSiServices;
namespace quanlyphongkhamnhi.Forms
{
    public partial class HoSoBS : Form
    {
        private string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";
        private BacSiService bacSiService;
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
            int bacsiID = UserSession.UserID; // lấy ID bác sĩ hiện tại

            string email = txtEmail.Text.Trim();
            string sdt = txtPhone.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string matkhau = txtMatKhau.Text;

            bool result = bacSiService.CapNhatBacSi(bacsiID, email, sdt, diachi, matkhau);

            if (result)
            {
                MessageBox.Show("Cập nhật hồ sơ bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Khóa các textbox sau khi lưu
                txtPhone.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Cập nhật hồ sơ bác sĩ thất bại. Vui lòng kiểm tra lại thông tin nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }

