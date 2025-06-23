using System;
using NUnit.Framework;
using quanlyphongkhamnhi.Services;

namespace quanlyphongkhamnhi.Tests
{
    [TestFixture]
    public class HoSoServiceTests
    {
        private HoSoService _service;

        [SetUp]
        public void Setup()
        {
            string fakeConnString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";
            _service = new HoSoService(fakeConnString);
        }

        private static DateTime GetBirthDateByAge(int age)
        {
            DateTime now = DateTime.Now;
            return now.AddYears(-age);
        }

        // 1. Các trường hợp hợp lệ (Thêm thành công)
        [TestCase("Nguyễn Văn A", "0123456789", "Hà Nội", "Trần Thị B", "Nam", "Cha", 10, TestName = "TC_HOSO_01_THANHCONG_Tuoi10")]
        [TestCase("Nguyễn Văn A", "0987654321", "Hà Nội", "Lê Thị C", "Nữ", "Mẹ", 15, TestName = "TC_HOSO_02_THANHCONG_Tuoi15")]
        [TestCase("Phạm Văn D", "0123456789", "Hồ Chí Minh", "Trần Văn E", "Nam", "Ông", 0, TestName = "TC_HOSO_03_THANHCONG_Tuoi0")]
        public void TC_HOSO_01_03_THANHCONG_ThemThanhCong(string hoTenGH, string sdtGH, string diaChiGH, string hoTenBN, string gtBN, string vaiTroGH, int tuoiBN)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(tuoiBN);

            bool isValid = _service.ValidateInput(
                hoTenGH,
                sdtGH,
                diaChiGH,
                hoTenBN,
                gtBN,
                vaiTroGH,
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.True);
            Assert.That(errorMsg, Is.Null.Or.Empty);
        }

        // 4. Trường hợp tuổi vượt quá 15 (Fail)
        [Test]
        public void TC_HOSO_04_Tuoi16_BaoLoi()
        {
            DateTime ngaySinhBN = GetBirthDateByAge(16);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                "Hà Nội",
                "Trần Thị B",
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo("Tuổi vượt quá 15"));
        }

        // 5-6. SĐT giám hộ không hợp lệ (rỗng hoặc <10 ký tự)
        [TestCase("", TestName = "TC_HOSO_05_SDT_Rong")]
        [TestCase("012345678", TestName = "TC_HOSO_06_SDT_Ngan")] // 9 ký tự
        public void TC_HOSO_05_06_SDT_GiamHo_KhongHopLe(string sdtGH)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                sdtGH,
                "Hà Nội",
                "Trần Thị B",
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo("SĐT không hợp lệ"));
        }

        // 7. Tên giám hộ rỗng hoặc chỉ khoảng trắng
        [TestCase("", "Tên giám hộ không được để trống", TestName = "TC_HOSO_07_TenGH_Rong")]
        [TestCase(" ", "Tên giám hộ không được để trống", TestName = "TC_HOSO_07_TenGH_KhoangTrang")]
        public void TC_HOSO_07_TenGiamHo_RongHoacKhoangTrang(string hoTenGH, string expectedError)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                hoTenGH,
                "0123456789",
                "Hà Nội",
                "Trần Thị B",
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo(expectedError));
        }

        // 8. Địa chỉ giám hộ rỗng hoặc chỉ khoảng trắng
        [TestCase("", "Địa chỉ không được để trống", TestName = "TC_HOSO_08_DiaChi_Rong")]
        [TestCase(" ", "Địa chỉ không được để trống", TestName = "TC_HOSO_08_DiaChi_KhoangTrang")]
        public void TC_HOSO_08_DiaChiGiamHo_RongHoacKhoangTrang(string diaChiGH, string expectedError)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                diaChiGH,
                "Trần Thị B",
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo(expectedError));
        }

        // 9. Tên bệnh nhân rỗng hoặc chỉ khoảng trắng
        [TestCase("", "Tên bệnh nhân không được để trống", TestName = "TC_HOSO_09_TenBN_Rong")]
        [TestCase(" ", "Tên bệnh nhân không được để trống", TestName = "TC_HOSO_09_TenBN_KhoangTrang")]
        public void TC_HOSO_09_TenBenhNhan_RongHoacKhoangTrang(string hoTenBN, string expectedError)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                "Hà Nội",
                hoTenBN,
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo(expectedError));
        }

        // 10. Giới tính bệnh nhân rỗng, null hoặc không hợp lệ
        [TestCase("", "Giới tính không hợp lệ", TestName = "TC_HOSO_10_GTBN_Rong")]
        [TestCase(null, "Giới tính không hợp lệ", TestName = "TC_HOSO_10_GTBN_Null")]
        [TestCase("Khác", "Giới tính không hợp lệ", TestName = "TC_HOSO_10_GTBN_KhongHopLe")]
        public void TC_HOSO_10_GioiTinhBenhNhan_KhongHopLe(string gtBN, string expectedError)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                "Hà Nội",
                "Trần Thị B",
                gtBN,
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo(expectedError));
        }

        // 11. Vai trò giám hộ rỗng hoặc null
        [TestCase("", "Vai trò không được để trống", TestName = "TC_HOSO_11_VTGH_Rong")]
        [TestCase(null, "Vai trò không được để trống", TestName = "TC_HOSO_11_VTGH_Null")]
        public void TC_HOSO_11_VaiTroGiamHo_RongHoacNull(string vaiTroGH, string expectedError)
        {
            DateTime ngaySinhBN = GetBirthDateByAge(10);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                "Hà Nội",
                "Trần Thị B",
                "Nam",
                vaiTroGH,
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo(expectedError));
        }

        // 12. Ngày sinh bệnh nhân ở tương lai (bổ sung)
        [Test]
        public void TC_HOSO_12_NgaySinhBenhNhan_TuongLai_BaoLoi()
        {
            DateTime ngaySinhBN = DateTime.Now.AddDays(1);

            bool isValid = _service.ValidateInput(
                "Nguyễn Văn A",
                "0123456789",
                "Hà Nội",
                "Trần Thị B",
                "Nam",
                "Cha",
                ngaySinhBN,
                out string errorMsg);

            Assert.That(isValid, Is.False);
            Assert.That(errorMsg, Is.EqualTo("Tuổi bệnh nhân không hợp lệ"));
        }
    }
}
