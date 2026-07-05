//using NUnit.Framework;
//using QuanLyPhongKham.Services;
//using System.Data;

//namespace QuanLyPhongKham.Tests
//{
//    [TestFixture]
//    public class HoSoBenhAnServiceTests
//    {
//        private HoSoBenhAnService _service;
//        private string _conn = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";

//        [SetUp]
//        public void Init() => _service = new HoSoBenhAnService(_conn);

//        // === TEST GET DANH SÁCH HỒ SƠ ===
//        [TestCase(1, true, TestName = "TC_HSBA_01_UserID_HopLe_LayDuocDanhSach")]
//        [TestCase(2, true, TestName = "TC_HSBA_02_UserID_CoNhieuHoSo_LayDuocDanhSach")]
//        [TestCase(999, false, TestName = "TC_HSBA_03_UserID_KhongTonTai_KhongCoDuLieu")]
//        [TestCase(-1, false, TestName = "TC_HSBA_04_UserID_Am_KhongCoDuLieu")]
//        public void TC_GetDanhSachHoSoTheoUser(int userId, bool expectData)
//        {
//            var dt = _service.GetHoSoBenhAnByUser(userId);

//            Assert.That(dt, Is.Not.Null, "DataTable trả về không được null");
//            Assert.That(dt.Rows.Count > 0, Is.EqualTo(expectData), "Số dòng trả về không khớp kỳ vọng");
//        }

//        // === TEST GET CHI TIẾT HỒ SƠ ===
//        [TestCase(1, true, false, false, TestName = "TC_HSBA_05_HoSoID_HopLe_NoiDungBinhThuong")]
//        [TestCase(2, true, true, false, TestName = "TC_HSBA_06_HoSoID_CoNoiDungDai_LayThanhCong")]
//        [TestCase(4, true, false, false, TestName = "TC_HSBA_07_HoSoID_CoUnicode_LayThanhCong")]
//        [TestCase(999, false, false, false, TestName = "TC_HSBA_08_HoSoID_KhongTonTai_TraVeNull")]
//        [TestCase(-5, false, false, false, TestName = "TC_HSBA_09_HoSoID_Am_TraVeNull")]
//        public void TC_GetChiTietHoSoText(int hoSoId, bool shouldExist, bool shouldBeLong, bool shouldBeEmpty)
//        {
//            var text = _service.GetHoSoTextById(hoSoId);

//            if (!shouldExist)
//            {
//                Assert.That(text, Is.Null, "Trường hợp không tồn tại: phải trả về null");
//                return;
//            }

//            Assert.That(text, Is.Not.Null, "Trường hợp tồn tại: không được null");

//            if (shouldBeEmpty)
//                Assert.That(text, Is.Empty, "Nội dung phải rỗng");

//            if (shouldBeLong)
//                Assert.That(text.Length, Is.GreaterThan(100), "Nội dung phải dài");

//            if (!shouldBeLong && !shouldBeEmpty)
//                Assert.That(text.Length, Is.InRange(1, 2000), "Nội dung phải nằm trong giới hạn hợp lý");
//        }
//    }
//}
