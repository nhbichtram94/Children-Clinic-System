//using NUnit.Framework;
//using System;
//using quanlyphongkhamnhi.Services;

//[TestFixture]
//public class DatKhamService_EquivalencePartitioningTests
//{
//    private DatKhamService _service;

//    [SetUp]
//    public void Setup()
//    {
//        string connString = "Data Source=LAPTOP-U184SQRH\\HHA;Initial Catalog=QLPKND;User ID=sa;Password=123";
//        _service = new DatKhamService(connString);
//    }

//    [Test]
//    public void TC_DK_01_THANHCONG_AllValidInputs()
//    {
//        int benhNhanID = 6;
//        int giamHoID = 8;
//        int chuyenKhoaID = 1;
//        DateTime ngayKham = DateTime.Today.AddDays(1);
//        int khungGioID = 1;

//        int result = _service.TaoPhieuKham(benhNhanID, giamHoID, chuyenKhoaID, ngayKham, khungGioID);
//        Assert.That(result, Is.GreaterThan(0));
//    }

//    [TestCase(0, TestName = "TC_DK_02_LOI_BenhNhanID_0")]
//    [TestCase(-1, TestName = "TC_DK_03_LOI_BenhNhanID_Am")]
//    public void TC_DK_BenhNhanID_Invalid(int benhNhanID)
//    {
//        int giamHoID = 8;
//        int chuyenKhoaID = 1;
//        DateTime ngayKham = DateTime.Today.AddDays(1);
//        int khungGioID = 1;
//        int result = _service.TaoPhieuKham(benhNhanID, giamHoID, chuyenKhoaID, ngayKham, khungGioID);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [TestCase(0, TestName = "TC_DK_04_LOI_GiamHoID_0")]
//    [TestCase(-8, TestName = "TC_DK_05_LOI_GiamHoID_Am")]
//    public void TC_DK_GiamHoID_Invalid(int giamHoID)
//    {
//        int benhNhanID = 6;
//        int chuyenKhoaID = 1;
//        DateTime ngayKham = DateTime.Today.AddDays(1);
//        int khungGioID = 1;
//        int result = _service.TaoPhieuKham(benhNhanID, giamHoID, chuyenKhoaID, ngayKham, khungGioID);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [TestCase(0, TestName = "TC_DK_06_LOI_ChuyenKhoaID_0")]
//    [TestCase(-2, TestName = "TC_DK_07_LOI_ChuyenKhoaID_Am")]
//    public void TC_DK_ChuyenKhoaID_Invalid(int chuyenKhoaID)
//    {
//        int benhNhanID = 6;
//        int giamHoID = 8;
//        DateTime ngayKham = DateTime.Today.AddDays(1);
//        int khungGioID = 1;
//        int result = _service.TaoPhieuKham(benhNhanID, giamHoID, chuyenKhoaID, ngayKham, khungGioID);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [TestCase("2023-01-01", TestName = "TC_DK_08_LOI_NgayKham_QuaKhu")]
//    [TestCase("1999-12-12", TestName = "TC_DK_09_LOI_NgayKham_RatQuaKhu")]
//    public void TC_DK_NgayKham_Invalid(string ngayKhamStr)
//    {
//        DateTime ngayKham = DateTime.Parse(ngayKhamStr);
//        int result = _service.TaoPhieuKham(6, 8, 1, ngayKham, 1);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [TestCase(0, TestName = "TC_DK_10_LOI_KhungGioID_0")]
//    [TestCase(-1, TestName = "TC_DK_11_LOI_KhungGioID_Am")]
//    public void TC_DK_KhungGioID_Invalid(int khungGioID)
//    {
//        int result = _service.TaoPhieuKham(6, 8, 1, DateTime.Today.AddDays(1), khungGioID);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [Test]
//    public void TC_DK_12_LOI_MultipleInvalid()
//    {
//        int result = _service.TaoPhieuKham(-1, -1, 0, DateTime.Today.AddDays(-5), -3);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [Test]
//    public void TC_DK_13_THANHCONG_NgayXa()
//    {
//        DateTime ngayKham = DateTime.Today.AddDays(14);
//        int result = _service.TaoPhieuKham(6, 8, 1, ngayKham, 1);
//        Assert.That(result, Is.GreaterThan(0));
//    }

//    [Test]
//    public void TC_DK_14_NgayKham_HomNay()
//    {
//        DateTime ngayKham = DateTime.Today;
//        int result = _service.TaoPhieuKham(6, 8, 1, ngayKham, 1);

//        // Vì hôm nay được phép đặt, ta kiểm tra là ID > 0
//        Assert.That(result, Is.GreaterThan(0));
//    }
//    [Test]
//    public void TC_DK_16_NgayKham_HomQua()
//    {
//        DateTime ngayKham = DateTime.Today.AddDays(-1);

//        int result = _service.TaoPhieuKham(6, 8, 1, ngayKham, 1);

        
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [Test]
//    public void TC_DK_15_THANHCONG_ChuyenKhoaID_Lon()
//    {
//        int result = _service.TaoPhieuKham(6, 8, 5, DateTime.Today.AddDays(2), 1);
//        Assert.That(result, Is.GreaterThan(0));
//    }

   


//    [Test]
//    public void TC_DK_17_TrungLich()
//    {
//        int result1 = _service.TaoPhieuKham(6, 8, 1, DateTime.Today.AddDays(3), 1);
//        int result2 = _service.TaoPhieuKham(6, 8, 1, DateTime.Today.AddDays(3), 1);
//        Assert.That(result2, Is.GreaterThan(0));
//    }

//    [Test]
//    public void TC_DK_18_LOI_ID_Rong()
//    {
//        int result = _service.TaoPhieuKham(int.MinValue, int.MinValue, int.MinValue, DateTime.Today.AddDays(1), int.MinValue);
//        Assert.That(result, Is.EqualTo(0));
//    }

//    [Test]
//    public void TC_DK_19_XacNhan_KetQuaHopLe()
//    {
//        int result = _service.TaoPhieuKham(6, 8, 1, DateTime.Today.AddDays(5), 1);
//        Assert.Multiple(() =>
//        {
//            Assert.That(result, Is.GreaterThan(0));
//            Assert.That(result, Is.TypeOf<int>());
//        });
//    }

//    [Test]
//    public void TC_DK_20_LOI_NgayKham_NULL()
//    {
//        DateTime? ngay = null;

//        var ex = Assert.Throws<ArgumentNullException>(() =>
//        {
//            _service.TaoPhieuKham(6, 8, 1, ngay, 1); // KHÔNG gọi .Value nữa
//        });

//        Assert.That(ex.ParamName, Is.EqualTo("ngayKham"));
//    }

//}
