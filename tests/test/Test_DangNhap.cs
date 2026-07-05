//using NUnit.Framework;
//using quanlyphongkhamnhi.Utils;

//namespace test
//{
//    [TestFixture]
//    public class RegistrationValidatorTests
//    {
//        private RegistrationValidator validator;

//        [SetUp]
//        public void Setup()
//        {
//            validator = new RegistrationValidator();
//        }

//        [Test]
//        public void TC_LOGIN_01_THANHCONG()
//        {
//            Assert.That(validator.Validate("0912345678", "Abcd1234!"), Is.Null);
//        }

//        [Test]
//        public void TC_LOGIN_04_RONG()
//        {
//            Assert.That(validator.Validate("", ""), Is.EqualTo("Vui lòng nhập đầy đủ số điện thoại và mật khẩu."));
//            Assert.That(validator.Validate(null, "Abcd1234!"), Is.EqualTo("Vui lòng nhập đầy đủ số điện thoại và mật khẩu."));
//            Assert.That(validator.Validate("0912345678", null), Is.EqualTo("Vui lòng nhập đầy đủ số điện thoại và mật khẩu."));
//        }

//        [TestCase("091234567", "Abcd1234!", "Tên đăng ký phải bắt đầu bằng số 0 và gồm 10 chữ số.")]
//        [TestCase("09123456789", "Abcd1234!", "Tên đăng ký phải bắt đầu bằng số 0 và gồm 10 chữ số.")]
//        [TestCase("abcdefghij", "Abcd1234!", "Tên đăng ký phải bắt đầu bằng số 0 và gồm 10 chữ số.")]
//        public void TC_LOGIN_06_USR_LENGTH_OR_FORMAT(string username, string password, string expectedError)
//        {
//            Assert.That(validator.Validate(username, password), Is.EqualTo(expectedError));
//        }

//        [TestCase("0912345678", "abcd1234!", "Mật khẩu phải chứa ít nhất một chữ hoa.")]
//        [TestCase("0912345678", "ABCD1234!", "Mật khẩu phải chứa ít nhất một chữ thường.")]
//        [TestCase("0912345678", "Abcdabcd!", "Mật khẩu phải chứa ít nhất một số.")]
//        [TestCase("0912345678", "Abcd1234", "Mật khẩu phải chứa ít nhất một ký tự đặc biệt.")]
//        public void TC_LOGIN_08_PWD_FORMAT(string username, string password, string expectedError)
//        {
//            Assert.That(validator.Validate(username, password), Is.EqualTo(expectedError));
//        }

//        [TestCase("0912345678", "abcd 1234!", "Mật khẩu không được chứa khoảng trắng.")]
//        [TestCase("0912345678", " Abcd1234!", "Mật khẩu không được chứa khoảng trắng.")] // khoảng trắng đầu chuỗi vẫn hợp lệ nếu không check
//        [TestCase("0912345678", "Abcd1234! ", "Mật khẩu không được chứa khoảng trắng.")]
//        public void TC_LOGIN_09_PWD_SPACE(string username, string password, string expectedError)
//        {
//            Assert.That(validator.Validate(username, password), Is.EqualTo(expectedError));
//        }

//        [TestCase("0912345678", "Abc1!", "Mật khẩu phải có ít nhất 8 ký tự.")]
//        [TestCase("0912345678", "Abcd1234!Abcd1234!Abcd", "Mật khẩu không được vượt quá 20 ký tự.")]
//        public void TC_LOGIN_05_PWD_LENGTH(string username, string password, string expectedError)
//        {
//            Assert.That(validator.Validate(username, password), Is.EqualTo(expectedError));
//        }

//        [TestCase("0912345678", "12345678", "Mật khẩu quá yếu, vui lòng chọn mật khẩu khác.")]
//        [TestCase("0912345678", "password", "Mật khẩu quá yếu, vui lòng chọn mật khẩu khác.")]
//        [TestCase("0912345678", "admin123", "Mật khẩu quá yếu, vui lòng chọn mật khẩu khác.")]
//        public void TC_LOGIN_11_BANNED_PASSWORDS(string username, string password, string expectedError)
//        {
//            Assert.That(validator.Validate(username, password), Is.EqualTo(expectedError));
//        }
//    }
//}
