using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlyphongkhamnhi.Forms
{
    public partial class QLHoaDon : Form
    {
        private string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";

        public QLHoaDon()
        {
            InitializeComponent();
            LoadHoaDonDataGrid();
        }

        private void LoadHoaDonDataGrid()
        {
            string query = "SELECT HoaDonID, BenhNhanID, NgayTao, TongTien FROM HOADON";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message);
                }
            }
        }

        // Khi người dùng chọn một dòng trong DataGridView
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int hoaDonID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["HoaDonID"].Value);
            }
        }

        // Khi bấm vào nút Xem Chi Tiết
        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hoaDonID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["HoaDonID"].Value);
            LoadChiTietHoaDon(hoaDonID);
        }

        private void LoadChiTietHoaDon(int hoaDonID)
        {
            string query = @"
                SELECT CT.HoaDonID, T.TenThuoc, CT.SoLuong, CT.Cachdung, CT.DonGia, CT.ThanhTien
                FROM CHITIETHOADON CT
                JOIN THUOC T ON CT.ThuocID = T.ThuocID
                WHERE CT.HoaDonID = @HoaDonID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@HoaDonID", hoaDonID);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message);
                }
            }
        }
    }
}
