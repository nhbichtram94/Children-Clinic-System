//using System;
//using System.Collections;
//using NUnit.Framework;
//using quanlyphongkhamnhi.HosoBacSiServices;

//namespace UnitTests
//{
//    [TestFixture]
//    public class BacSiServiceTests
//    {
//        private BacSiService service;

//        [SetUp]
//        public void Setup()
//        {
//            string fakeConnString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";

//        }

//        [Test]
//        public void TC_HOSOBACSI_01_THANHCONG()
//        {
//            string error;
//            bool result = service.CapNhatBacSi(1, "abc@gmail.com", "0123456789", "123 Đường ABC", "Pass@123", out error);
//            Assert.That(result, Is.True);
//            Assert.That(error, Is.EqualTo(string.Empty));
//        }

//        private static IEnumerable EmailTestCases
//        {
//            get
//            {
//                yield return new TestCaseData("abc@", false);
//                yield return new TestCaseData("abc.com", false);
//                yield return new TestCaseData("", false);
//                yield return new TestCaseData("abc@@gmail.com", false);
//                yield return new TestCaseData("abc@.com", false);
//                yield return new TestCaseData(" abc@gmail.com", false);
//                yield return new TestCaseData("abc @gmail.com", false);
//                yield return new TestCaseData("abc@gmail.com", true);
//            }
//        }

//        [Test, TestCaseSource(nameof(EmailTestCases))]
//        public void TC_HOSOBACSI_02_EMAIL_KHONG_HOP_LE(string email, bool expected)
//        {
//            string error;
//            bool result = service.CapNhatBacSi(1, email, "0123456789", "123 ABC", "123456", out error);
//            Assert.That(result, Is.EqualTo(expected));
//        }

//        private static IEnumerable PhoneTestCases
//        {
//            get
//            {
//                yield return new TestCaseData("01234", false);
//                yield return new TestCaseData("012345678901", false);
//                yield return new TestCaseData("01234abcde", false);
//                yield return new TestCaseData("", false);
//                yield return new TestCaseData(" 0123456789", false);
//                yield return new TestCaseData("0123 456789", false);
//                yield return new TestCaseData("0123456789", true);
//                yield return new TestCaseData("0987654321", true);
//            }
//        }

//        [Test, TestCaseSource(nameof(PhoneTestCases))]
//        public void TC_HOSOBACSI_03_SDT_KHONG_HOP_LE(string phone, bool expected)
//        {
//            string error;
//            bool result = service.CapNhatBacSi(1, "test@gmail.com", phone, "123 ABC", "123456", out error);
//            Assert.That(result, Is.EqualTo(expected));
//        }

//        [Test]
//        public void TC_HOSOBACSI_04_DIACHI_GIA_TRI_BIEN()
//        {
//            string email = "abc@gmail.com";
//            string phone = "0123456789";
//            string matkhau = "123456";
//            string error;

//            string diachi254 = new string('a', 254);
//            string diachi255 = new string('a', 255);
//            string diachi256 = new string('a', 256);

//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi254, matkhau, out error), Is.True);
//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi255, matkhau, out error), Is.True);
//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi256, matkhau, out error), Is.False);
//        }

//        [TestCase("", false)]
//        [TestCase("    ", false)]
//        [TestCase("123 ABC", true)]
//        public void TC_HOSOBACSI_05_DIACHI_RONG(string diachi, bool expected)
//        {
//            string error;
//            bool result = service.CapNhatBacSi(1, "abc@gmail.com", "0123456789", diachi, "123456", out error);
//            Assert.That(result, Is.EqualTo(expected));
//        }

//        [Test]
//        public void TC_HOSOBACSI_06_MATKHAU_GIA_TRI_BIEN()
//        {
//            string email = "abc@gmail.com";
//            string phone = "0123456789";
//            string diachi = "123 ABC";
//            string error;

//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi, "12345", out error), Is.False);
//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi, "123456", out error), Is.True);
//            Assert.That(service.CapNhatBacSi(1, email, phone, diachi, "1234567", out error), Is.True);
//        }

//        [Test]
//        public void TC_HOSOBACSI_07_MATKHAU_RONG()
//        {
//            string error;
//            bool result = service.CapNhatBacSi(1, "abc@gmail.com", "0123456789", "123 ABC", "", out error);
//            Assert.That(result, Is.False);
//            Assert.That(error, Does.Contain("Mật khẩu"));
//        }
//    }
//}
