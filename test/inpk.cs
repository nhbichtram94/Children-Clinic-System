//using NUnit.Framework;
//using quanlyphongkhamnhi.ServicesPK;

//namespace QuanLyPhongKham.Tests
//{
//    [TestFixture]
//    public class InPhieuKhamServiceTests
//    {
//        private IPhieuKhamService _service;
//        private string _connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";

//        [SetUp]
//        public void Setup() => _service = new PhieuKhamService(_connString);

       
//        [TestCase(1, true, TestName = "TC_GH_01_UserIDHopLe_TonTai")]
//        [TestCase(2, true, TestName = "TC_GH_02_UserIDHopLe_TonTaiKhac")]
//        [TestCase(9999, false, TestName = "TC_GH_03_UserIDKhongTonTai")]
//        [TestCase(0, false, TestName = "TC_GH_04_UserIDBang0_KhongTonTai")]
//        [TestCase(-1, false, TestName = "TC_GH_05_UserIDAm_KhongTonTai")]
//        [TestCase(int.MaxValue, false, TestName = "TC_GH_06_UserIDMax_KhongTonTai")]
//        public void Test_GetGiamHoIDFromUserID(int userId, bool shouldExist)
//        {
//            var giamHoID = _service.GetGiamHoIDFromUserID(userId);

//            if (shouldExist)
//                Assert.That(giamHoID, Is.Not.Null.And.GreaterThan(0));
//            else
//                Assert.That(giamHoID, Is.Null);
//        }

//        // ======= TEST LẤY NỘI DUNG PHIẾU KHÁM THEO PhieuKhamID =======
//        [TestCase(1, true, false, false, TestName = "TC_INPK_01_PhieuKhamHopLe_NoidungBinhThuong")]
//        [TestCase(2, true, true, false, TestName = "TC_INPK_02_PhieuKhamNoiDungDai")]
//        [TestCase(3, true, false, true, TestName = "TC_INPK_03_PhieuKhamNoiDungRong")]
//        [TestCase(4, true, false, false, TestName = "TC_INPK_04_PhieuKhamNoiDungUnicode")]
//        [TestCase(0, false, false, false, TestName = "TC_INPK_05_PhieuKhamIDBang0_KhongTonTai")]
//        [TestCase(-1, false, false, false, TestName = "TC_INPK_06_PhieuKhamIDAm_KhongTonTai")]
//        [TestCase(9999, false, false, false, TestName = "TC_INPK_07_PhieuKhamIDKhongTonTai")]
//        [TestCase(int.MaxValue, false, false, false, TestName = "TC_INPK_08_PhieuKhamIDMax_KhongTonTai")]
//        public void Test_GetPhieuKhamTextByID(int phieuKhamID, bool shouldExist, bool shouldBeLong, bool shouldBeEmpty)
//        {
//            var text = _service.GetPhieuKhamTextByID(phieuKhamID);

//            if (!shouldExist)
//            {
//                Assert.That(text, Is.Null, "Trường hợp không tồn tại phải trả về null");
//                return;
//            }

//            Assert.That(text, Is.Not.Null, "Trường hợp tồn tại không được null");

//            if (shouldBeEmpty)
//            {
//                Assert.That(text, Is.Not.Null.And.Not.Empty, "Nội dung rỗng nhưng vẫn có template mặc định");
//                Assert.That(text.Contains("PHÒNG KHÁM NHI HUIT"), Is.True, "Nội dung phải chứa phần header chuẩn");
//                Assert.That(text.Contains("Cảm ơn quý khách đã sử dụng dịch vụ!"), Is.True, "Nội dung phải chứa footer chuẩn");
//            }
//            else if (shouldBeLong)
//            {
//                Assert.That(text.Length, Is.GreaterThan(100), "Nội dung phải dài hơn 1000 ký tự");
//            }
//            else
//            {
//                Assert.That(text.Length, Is.InRange(1, 1000), "Nội dung phải nằm trong khoảng 1-1000 ký tự");
//            }
//        }
//    }
//}
