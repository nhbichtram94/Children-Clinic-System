using System;
using System.Windows.Forms;
using quanlyphongkhamnhi.Services;

namespace quanlyphongkhamnhi.Forms
{
    public partial class DienHoSo : Form
    {
        private static readonly string connString = "Data Source=DESKTOP-35FGUEF;Initial Catalog=QLPKN;User ID=sa;Password=Tram@942004";
        private readonly HoSoService _service = new HoSoService(connString);

        public DienHoSo()
        {
            InitializeComponent();
            LoadSDT();
        }

        private void LoadSDT()
        {
            string username = UserSession.Username;

            if (!string.IsNullOrWhiteSpace(username) && username.Length >= 10)
            {
                textBoxGiamHoPhone.Text = username;
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLuuBenhNhan_Click(object sender, EventArgs e)
        {
            string hoTenGiamHo = tbGiamHo.Text.Trim();
            DateTime ngaySinhGiamHo = ngaysinhGH.Value;
            string gioiTinhGiamHo = materialComboBox1.SelectedItem?.ToString();
            string diaChiGiamHo = diachiGH.Text.Trim();
            string soDienThoaiGiamHo = textBoxGiamHoPhone.Text.Trim();
            string hoTenBenhNhan = tbBenhNhan.Text.Trim();
            DateTime ngaySinhBenhNhan = dateTimePickerBenhNhan.Value;
            string gioiTinhBenhNhan = cbGioiTinh.SelectedItem?.ToString();
            string vaiTroGiamHo = materialComboBox3.SelectedItem?.ToString();
            int userID = UserSession.UserID;

            // Validate dữ liệu trước khi gọi insert
            bool isValid = _service.ValidateInput(
                hoTenGiamHo,
                soDienThoaiGiamHo,
                diaChiGiamHo,
                hoTenBenhNhan,
                gioiTinhBenhNhan,
                vaiTroGiamHo,
                ngaySinhBenhNhan,
                out string errorMsg);

            if (!isValid)
            {
                MessageBox.Show(errorMsg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _service.InsertGiamHoBenhNhan(
                    hoTenGiamHo,
                    ngaySinhGiamHo,
                    gioiTinhGiamHo,
                    soDienThoaiGiamHo,
                    diaChiGiamHo,
                    userID,
                    hoTenBenhNhan,
                    ngaySinhBenhNhan,
                    gioiTinhBenhNhan,
                    vaiTroGiamHo);

                MessageBox.Show("Thông tin giám hộ và bệnh nhân đã được thêm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
