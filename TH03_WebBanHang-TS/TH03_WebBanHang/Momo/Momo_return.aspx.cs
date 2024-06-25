using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang.Momo
{
    public partial class Momo_return : System.Web.UI.Page
    {
        public static string mail;
        public string MaDH;
        public static string mdh;
        public static string maKH;
        public static string MaDHXNGD;
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        //public void CreateTheOrder()
        //{

        //    mail = Pay.emailKHnoSign;

        //    double ThanhTien = 0;



        //    int makh = Pay.IdClinedtoMomo; // Giả định rằng bạn đã có phương thức này để lấy giá trị MaTK

        //    // Chuyển đổi giá trị MaTK thành chuỗi
        //    string kh = makh.ToString();

        //    ChiNhanh chiNhanh = new ChiNhanh();
        //    // Tăng giá trị count


        //    // Lưu giá trị count vào session
        //    string url = HttpContext.Current.Request.Url.ToString();
        //    List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
        //    //DonHang donHang = new DonHang();

        //    string ma = Pay.MaDHXNGD;


        //    if (lstGioHang != null && lstGioHang.Any())
        //    {
        //        var user = from u in dbcontext.KhachHangs
        //                   select u;

        //        var tk = from u in dbcontext.TKs select u;

        //        var hadUser = tk.Any(p => p.Email == Pay.emailKHnoSign && (p.MatKhau != null || p.MatKhau != ""));
        //        var hadClient = user.Any(p => p.Email == Pay.emailKHnoSign && (p.MatKhau != null || p.MatKhau != ""));
        //        var hadClientNonPass = user.Any(s => s.Email == Pay.emailKHnoSign && (s.MatKhau == null || s.MatKhau == ""));


        //        if (Sign.email == null)
        //        {
        //            using (var db = new QL_KPOPStoreEntities())
        //            {
        //                // Kiểm tra giá trị trước khi thêm vào cơ sở dữ liệu
        //                if ((!hadUser && !hadClient && !hadClientNonPass) /*&& !string.IsNullOrEmpty(Pay.emailKHnoSign) && !string.IsNullOrEmpty(Pay.DienThoaiKHnoSign) && !string.IsNullOrEmpty(Pay.DiaChiKHnoSign) && !string.IsNullOrEmpty(Pay.emailKHnoSign)*/)
        //                {
        //                    var newUser = new TK
        //                    {
        //                        Email = Pay.emailKHnoSign,
        //                        MatKhau = null,
        //                        TrangThai = false,



        //                    };
        //                    var newClient = new KhachHang
        //                    {
        //                        AvatarUser = Shop.defaultAvatar_BlackKS,
        //                        HoTen = Pay.HotenKHnoSign,
        //                        DienThoai = Pay.DienThoaiKHnoSign,
        //                        DiaChi = Pay.DiaChiNN,
        //                        Email = Pay.emailKHnoSign,
        //                        GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
        //                        MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
        //                        TrangThai = false,
        //                        Diem = 0,
        //                    };
        //                    //db.TKs.Add(newUser);

        //                    //db.KhachHangs.Add(newClient);
        //                    //db.SaveChanges();
        //                    db.TKs.Add(newUser);

        //                    db.KhachHangs.Add(newClient);
        //                    db.SaveChanges();

        //                    //db.TKs.Add(newUser);

        //                    //db.KhachHangs.Add(newClient);
        //                    //db.SaveChanges();
        //                    // Tạo một đơn hàng mới
        //                    string makhno;
        //                    makhno = newClient.MaKH.ToString();
        //                    DonHang donHang = new DonHang
        //                    {
        //                        MaDH = ma,
        //                        HoTenNN = Pay.HotenKHnoSign,
        //                        DiaChiNN = Pay.DiaChiNN,
        //                        DienThoaiNN = Pay.DienThoaiKHnoSign,


        //                        KH = newClient.MaKH,
        //                        Ngay = DateTime.Now,
        //                        MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                    };
        //                    //    donHang.MaDH = ma;
        //                    ////donHang.MaKH = makh;

        //                    //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                    //    donHang.KH = kh;

        //                    //    // Tiếp tục xử lý khác ở đây...

        //                    //donHang.Ngay = DateTime.Now;
        //                    //donHang.MaCN = Shop.CH;
        //                    //donHang.ChiTietDonHangs = lstGioHang;
        //                    //donHang.MaKH = Account.makh;

        //                    dbcontext.DonHangs.Add(donHang);

        //                    string maDonHang = donHang.MaDH;
        //                    //MaDHXNGD = donHang.MaDH;
        //                    int count = 1;
        //                    foreach (var item in lstGioHang)
        //                    {
        //                        string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                        ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                        {
        //                            KH = donHang.KH,
        //                            MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                            MaCTDH = mact,
        //                            MaSP = item.MaSP,
        //                            TenSP = item.TenSP,
        //                            DuongDan = item.DuongDan,
        //                            SoLuong = item.SoLuong,
        //                            Gia = item.Gia,
        //                            ThanhTien = item.ThanhTien,
        //                            TenPob = item.TenPob,



        //                        };

        //                        //chiTietDon.KH = donHang.KH;
        //                        //chiTietDon.MaDH = donHang.MaDH;
        //                        //chiTietDon.MaCTDH = mact;
        //                        //chiTietDon.MaSP = item.MaSP;
        //                        //chiTietDon.TenSP = item.TenSP;
        //                        //chiTietDon.DuongDan = item.DuongDan;
        //                        //chiTietDon.SoLuong = item.SoLuong;
        //                        //chiTietDon.Gia = item.Gia;
        //                        //chiTietDon.ThanhTien = item.ThanhTien;
        //                        var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                        sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh); double diem = chiTietDon.ThanhTien / 200000;
        //                        if (khachmua != null)
        //                        {

        //                            khachmua.Diem = khachmua.Diem + (int)diem;
        //                        }
        //                        else
        //                        {
        //                            var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                            khachHad.Diem = khachHad.Diem + (int)diem;
        //                        }
        //                        chiTietDon.Ngay = donHang.Ngay;
        //                        chiTietDon.GiaoDich = true;
        //                        ThanhTien = chiTietDon.ThanhTien;
        //                        MaDH = chiTietDon.MaDH;
        //                        count++;
        //                        mdh = donHang.MaDH;
        //                        //maKH = donHang.KH.ToString();


        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                    }
        //                    // Thêm thông báo thành công hoặc xử lý kết quả khác

        //                }
        //                else
        //                {
        //                    var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);

        //                    DonHang donHang = new DonHang
        //                    {
        //                        MaDH = ma,
        //                        HoTenNN = Pay.HotenKHnoSign,
        //                        DiaChiNN = Pay.DiaChiNN,
        //                        DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                        KH = khachmua.MaKH,
        //                        Ngay = DateTime.Now,
        //                        MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                    };


        //                    dbcontext.DonHangs.Add(donHang);

        //                    string maDonHang = donHang.MaDH;
        //                    //MaDHXNGD = donHang.MaDH;
        //                    int count = 1;
        //                    foreach (var item in lstGioHang)
        //                    {
        //                        string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                        ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                        {
        //                            KH = donHang.KH,
        //                            MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                            MaCTDH = mact,
        //                            MaSP = item.MaSP,
        //                            TenSP = item.TenSP,
        //                            DuongDan = item.DuongDan,
        //                            SoLuong = item.SoLuong,
        //                            Gia = item.Gia,
        //                            ThanhTien = item.ThanhTien,
        //                            TenPob = item.TenPob,

        //                        };

        //                        var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                        sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
        //                        double diem = chiTietDon.ThanhTien / 200000;
        //                        if (khachmua != null)
        //                        {

        //                            khachmua.Diem = khachmua.Diem + (int)diem;
        //                        }
        //                        else
        //                        {
        //                            var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                            khachHad.Diem = khachHad.Diem + (int)diem;
        //                        }
        //                        chiTietDon.Ngay = donHang.Ngay;
        //                        chiTietDon.GiaoDich = true;
        //                        ThanhTien = chiTietDon.ThanhTien;
        //                        MaDH = chiTietDon.MaDH;
        //                        count++;
        //                        mdh = donHang.MaDH;
        //                        //maKH = donHang.KH.ToString();


        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);




        //                    }

        //                }
        //            }

        //        }
        //        else if (hadUser && hadClient && !hadClientNonPass)
        //        {
        //            if (Sign.email != null && user.Any(p => p.Email == Sign.email))
        //            {
        //                // Tạo một đơn hàng mới
        //                DonHang donHang = new DonHang
        //                {
        //                    MaDH = ma,
        //                    HoTenNN = Pay.HotenKHnoSign,
        //                    DiaChiNN = Pay.DiaChiNN,
        //                    DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                    KH = makh,
        //                    Ngay = DateTime.Now,
        //                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                };
        //                //    donHang.MaDH = ma;
        //                ////donHang.MaKH = makh;

        //                //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                //    donHang.KH = kh;

        //                //    // Tiếp tục xử lý khác ở đây...

        //                //donHang.Ngay = DateTime.Now;
        //                //donHang.MaCN = Shop.CH;
        //                //donHang.ChiTietDonHangs = lstGioHang;
        //                //donHang.MaKH = Account.makh;

        //                dbcontext.DonHangs.Add(donHang);

        //                string maDonHang = donHang.MaDH;
        //                //MaDHXNGD = donHang.MaDH;
        //                int count = 1;
        //                foreach (var item in lstGioHang)
        //                {
        //                    string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                    ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                    {
        //                        KH = donHang.KH,
        //                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                        MaCTDH = mact,
        //                        MaSP = item.MaSP,
        //                        TenSP = item.TenSP,
        //                        DuongDan = item.DuongDan,
        //                        SoLuong = item.SoLuong,
        //                        Gia = item.Gia,
        //                        ThanhTien = item.ThanhTien,
        //                        TenPob = item.TenPob,
        //                    };

        //                    //chiTietDon.KH = donHang.KH;
        //                    //chiTietDon.MaDH = donHang.MaDH;
        //                    //chiTietDon.MaCTDH = mact;
        //                    //chiTietDon.MaSP = item.MaSP;
        //                    //chiTietDon.TenSP = item.TenSP;
        //                    //chiTietDon.DuongDan = item.DuongDan;
        //                    //chiTietDon.SoLuong = item.SoLuong;
        //                    //chiTietDon.Gia = item.Gia;
        //                    //chiTietDon.ThanhTien = item.ThanhTien;

        //                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh); double diem = chiTietDon.ThanhTien / 200000;
        //                    if (khachmua != null)
        //                    {

        //                        khachmua.Diem = khachmua.Diem + (int)diem;
        //                    }
        //                    else
        //                    {
        //                        var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                        khachHad.Diem = khachHad.Diem + (int)diem;
        //                    }
        //                    chiTietDon.Ngay = donHang.Ngay;
        //                    chiTietDon.GiaoDich = true;
        //                    ThanhTien = chiTietDon.ThanhTien;
        //                    MaDH = chiTietDon.MaDH;
        //                    count++;
        //                    mdh = donHang.MaDH;
        //                    //maKH = donHang.KH.ToString();


        //                    dbcontext.ChiTietDonHangs.Add(chiTietDon);




        //                }
        //            }
        //            else
        //            {
        //                var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                string khHadMaKH = khHad.MaKH.ToString();
        //                // Tạo một đơn hàng mới
        //                DonHang donHang = new DonHang
        //                {
        //                    MaDH = ma,
        //                    HoTenNN = Pay.HotenKHnoSign,
        //                    DiaChiNN = Pay.DiaChiNN,
        //                    DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                    KH = khHad.MaKH,
        //                    Ngay = DateTime.Now,
        //                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                };
        //                //    donHang.MaDH = ma;
        //                ////donHang.MaKH = makh;

        //                //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                //    donHang.KH = kh;

        //                //    // Tiếp tục xử lý khác ở đây...

        //                //donHang.Ngay = DateTime.Now;
        //                //donHang.MaCN = Shop.CH;
        //                //donHang.ChiTietDonHangs = lstGioHang;
        //                //donHang.MaKH = Account.makh;

        //                dbcontext.DonHangs.Add(donHang);

        //                string maDonHang = donHang.MaDH;
        //                //MaDHXNGD = donHang.MaDH;
        //                int count = 1;
        //                foreach (var item in lstGioHang)
        //                {
        //                    string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                    ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                    {
        //                        KH = donHang.KH,
        //                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                        MaCTDH = mact,
        //                        MaSP = item.MaSP,
        //                        TenSP = item.TenSP,
        //                        DuongDan = item.DuongDan,
        //                        SoLuong = item.SoLuong,
        //                        Gia = item.Gia,
        //                        ThanhTien = item.ThanhTien,
        //                        TenPob = item.TenPob,
        //                    };

        //                    //chiTietDon.KH = donHang.KH;
        //                    //chiTietDon.MaDH = donHang.MaDH;
        //                    //chiTietDon.MaCTDH = mact;
        //                    //chiTietDon.MaSP = item.MaSP;
        //                    //chiTietDon.TenSP = item.TenSP;
        //                    //chiTietDon.DuongDan = item.DuongDan;
        //                    //chiTietDon.SoLuong = item.SoLuong;
        //                    //chiTietDon.Gia = item.Gia;
        //                    //chiTietDon.ThanhTien = item.ThanhTien;
        //                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
        //                    var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
        //                    double diem = chiTietDon.ThanhTien / 200000;


        //                    if (khHad.Diem != null)
        //                        khHad.Diem = khHad.Diem + (int)diem;
        //                    else
        //                    {
        //                        khHad.Diem = 0;
        //                        khHad.Diem = khHad.Diem + (int)diem;

        //                    }




        //                    chiTietDon.Ngay = donHang.Ngay;
        //                    chiTietDon.GiaoDich = true;
        //                    ThanhTien = chiTietDon.ThanhTien;
        //                    MaDH = chiTietDon.MaDH;
        //                    count++;
        //                    mdh = donHang.MaDH;
        //                    //maKH = donHang.KH.ToString();
        //                    dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                }
        //            }
        //        }
        //        else
        //        {
        //            using (var db = new QL_KPOPStoreEntities())
        //            {
        //                if (hadClientNonPass)
        //                {
        //                    var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                    string khHadMaKH = khHad.MaKH.ToString();
        //                    // Tạo một đơn hàng mới
        //                    DonHang donHang = new DonHang
        //                    {
        //                        MaDH = ma,
        //                        HoTenNN = Pay.HotenKHnoSign,
        //                        DiaChiNN = Pay.DiaChiNN,
        //                        DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                        KH = khHad.MaKH,
        //                        Ngay = DateTime.Now,
        //                        MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                    };
        //                    //    donHang.MaDH = ma;
        //                    ////donHang.MaKH = makh;

        //                    //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                    //    donHang.KH = kh;

        //                    //    // Tiếp tục xử lý khác ở đây...

        //                    //donHang.Ngay = DateTime.Now;
        //                    //donHang.MaCN = Shop.CH;
        //                    //donHang.ChiTietDonHangs = lstGioHang;
        //                    //donHang.MaKH = Account.makh;

        //                    dbcontext.DonHangs.Add(donHang);

        //                    string maDonHang = donHang.MaDH;
        //                    //MaDHXNGD = donHang.MaDH;
        //                    int count = 1;
        //                    foreach (var item in lstGioHang)
        //                    {
        //                        string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                        ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                        {
        //                            KH = donHang.KH,
        //                            MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                            MaCTDH = mact,
        //                            MaSP = item.MaSP,
        //                            TenSP = item.TenSP,
        //                            DuongDan = item.DuongDan,
        //                            SoLuong = item.SoLuong,
        //                            Gia = item.Gia,
        //                            ThanhTien = item.ThanhTien,
        //                            TenPob = item.TenPob,
        //                        };

        //                        //chiTietDon.KH = donHang.KH;
        //                        //chiTietDon.MaDH = donHang.MaDH;
        //                        //chiTietDon.MaCTDH = mact;
        //                        //chiTietDon.MaSP = item.MaSP;
        //                        //chiTietDon.TenSP = item.TenSP;
        //                        //chiTietDon.DuongDan = item.DuongDan;
        //                        //chiTietDon.SoLuong = item.SoLuong;
        //                        //chiTietDon.Gia = item.Gia;
        //                        //chiTietDon.ThanhTien = item.ThanhTien;
        //                        var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                        sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
        //                        var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
        //                        double diem = chiTietDon.ThanhTien / 200000;


        //                        if (khHad.Diem != null)
        //                            khHad.Diem = khHad.Diem + (int)diem;
        //                        else
        //                        {
        //                            khHad.Diem = 0;
        //                            khHad.Diem = khHad.Diem + (int)diem;

        //                        }




        //                        chiTietDon.Ngay = donHang.Ngay;
        //                        chiTietDon.GiaoDich = true;
        //                        ThanhTien = chiTietDon.ThanhTien;
        //                        MaDH = chiTietDon.MaDH;
        //                        count++;
        //                        mdh = donHang.MaDH;
        //                        //maKH = donHang.KH.ToString();
        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                    }
        //                }

        //                else
        //                {
        //                    var newUser = new TK
        //                    {
        //                        Email = Pay.emailKHnoSign,
        //                        MatKhau = null,
        //                        TrangThai = false,



        //                    };
        //                    var newClient = new KhachHang
        //                    {
        //                        AvatarUser = Shop.defaultAvatar_BlackKS,
        //                        HoTen = Pay.HotenKHnoSign,
        //                        DienThoai = Pay.DienThoaiKHnoSign,
        //                        DiaChi = Pay.DiaChiNN,
        //                        Email = Pay.emailKHnoSign,
        //                        GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
        //                        MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
        //                        TrangThai = false,
        //                        Diem = 0,
        //                    };
        //                    //db.TKs.Add(newUser);

        //                    //db.KhachHangs.Add(newClient);
        //                    //db.SaveChanges();
        //                    db.TKs.Add(newUser);

        //                    db.KhachHangs.Add(newClient);
        //                    db.SaveChanges();

        //                    //db.TKs.Add(newUser);

        //                    //db.KhachHangs.Add(newClient);
        //                    //db.SaveChanges();
        //                    // Tạo một đơn hàng mới
        //                    string makhno;
        //                    makhno = newClient.MaKH.ToString();
        //                    DonHang donHang = new DonHang
        //                    {
        //                        MaDH = ma,
        //                        HoTenNN = Pay.HotenKHnoSign,
        //                        DiaChiNN = Pay.DiaChiNN,
        //                        DienThoaiNN = Pay.DienThoaiKHnoSign,


        //                        KH = newClient.MaKH,
        //                        Ngay = DateTime.Now,
        //                        MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                    };
        //                    //    donHang.MaDH = ma;
        //                    ////donHang.MaKH = makh;

        //                    //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                    //    donHang.KH = kh;

        //                    //    // Tiếp tục xử lý khác ở đây...

        //                    //donHang.Ngay = DateTime.Now;
        //                    //donHang.MaCN = Shop.CH;
        //                    //donHang.ChiTietDonHangs = lstGioHang;
        //                    //donHang.MaKH = Account.makh;

        //                    dbcontext.DonHangs.Add(donHang);

        //                    string maDonHang = donHang.MaDH;
        //                    int count = 1;
        //                    foreach (var item in lstGioHang)
        //                    {
        //                        string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                        ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                        {
        //                            KH = donHang.KH,
        //                            MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                            MaCTDH = mact,
        //                            MaSP = item.MaSP,
        //                            TenSP = item.TenSP,
        //                            DuongDan = item.DuongDan,
        //                            SoLuong = item.SoLuong,
        //                            Gia = item.Gia,
        //                            ThanhTien = item.ThanhTien,
        //                            TenPob = item.TenPob,



        //                        };

        //                        //chiTietDon.KH = donHang.KH;
        //                        //chiTietDon.MaDH = donHang.MaDH;
        //                        //chiTietDon.MaCTDH = mact;
        //                        //chiTietDon.MaSP = item.MaSP;
        //                        //chiTietDon.TenSP = item.TenSP;
        //                        //chiTietDon.DuongDan = item.DuongDan;
        //                        //chiTietDon.SoLuong = item.SoLuong;
        //                        //chiTietDon.Gia = item.Gia;
        //                        //chiTietDon.ThanhTien = item.ThanhTien;
        //                        var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                        sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh); double diem = chiTietDon.ThanhTien / 200000;
        //                        if (khachmua != null)
        //                        {

        //                            khachmua.Diem = khachmua.Diem + (int)diem;
        //                        }
        //                        else
        //                        {
        //                            var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                            khachHad.Diem = khachHad.Diem + (int)diem;
        //                        }
        //                        chiTietDon.Ngay = donHang.Ngay;
        //                        chiTietDon.GiaoDich = true;
        //                        ThanhTien = chiTietDon.ThanhTien;
        //                        MaDH = chiTietDon.MaDH;
        //                        mdh = donHang.MaDH;
        //                        count++;



        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                    }
        //                }
        //            }

        //        }




        //        dbcontext.SaveChanges();
        //        DoanhThu doanhThu;
        //        if (dbcontext.DoanhThus.Any(s => s.Nam == DateTime.Now.Year && s.Thang == DateTime.Now.Month && s.Ngay == DateTime.Now.Day))
        //        {
        //            doanhThu = dbcontext.DoanhThus.FirstOrDefault(s => s.Nam == DateTime.Now.Year && s.Thang == DateTime.Now.Month && s.Ngay == DateTime.Now.Day);
        //            doanhThu.DoanhThuNgay += ThanhTien;

        //        }
        //        else
        //        {
        //            doanhThu = new DoanhThu
        //            {


        //                Ngay = DateTime.Now.Day,
        //                Nam = DateTime.Now.Year,
        //                Thang = DateTime.Now.Month,
        //                DoanhThuNgay = ThanhTien,
        //            };
        //            dbcontext.DoanhThus.Add(doanhThu);

        //        }

        //        dbcontext.SaveChanges();

        //        //displayOrderCode.InnerText = mdh;



        //    }

        //}
        private int GetMaTKFromSomeSource()
        {
            // Ví dụ: Giả sử bạn lấy giá trị MaTK từ phiên đăng nhập của người dùng
            if (Session["MaKH"] != null)
            {
                int maKH;
                if (int.TryParse(Session["MaKH"].ToString(), out maKH))
                {
                    return maKH;
                }
            }


            return 0;
        }
        //private string GenerateRandomString(int length)
        //{
        //    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    var random = new Random();
        //    var result = new string(
        //        Enumerable.Repeat(chars, length)
        //                  .Select(s => s[random.Next(s.Length)])
        //                  .ToArray());
        //    return result;
        //}
        //public IQueryable<TH03_WebBanHang.Models.ChiTietDonHang> GetListItemsInOrder()
        //{
        //    //var chitietDon = dbcontext.ChiTietDonHangs.FirstOrDefault(s=>s.MaDH== MaDHXNGD);
        //    IQueryable<ChiTietDonHang> lsItems = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == Pay.MaDHXNGD);

        //    return lsItems;

        //}
        //public void SendEmail(string to, string subject, string body, string imagePath)
        //{
        //    ChiTietDonHang maDH = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == body);

        //    ChiTietDonHang maCT = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == maDH.MaDH);
        //    try
        //    {
        //        // Tạo một đối tượng SmtpClient
        //        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
        //        {
        //            Credentials = new System.Net.NetworkCredential(Shop.gmailAccount, Shop.gmailPass),
        //            EnableSsl = true
        //        };

        //        // Tạo một đối tượng MailMessage
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(Shop.gmailAccount);
        //        mailMessage.To.Add(new MailAddress(to));
        //        mailMessage.Subject = subject;

        //        // Thêm hình ảnh vào email
        //        LinkedResource inline = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
        //        inline.ContentId = Guid.NewGuid().ToString(); // Đặt ContentId để tham chiếu đến hình ảnh trong HTML
        //        string styleColor;
        //        if (maDH.GiaoDich == true)
        //        {
        //            styleColor = "<p>Giao dịch: <span style=\"color: green;\">Đã Thanh Toán</span></p>";
        //        }
        //        else styleColor = "<p>Giao dịch: <span style=\"color: red;\">Đợi Thanh Toán</span></p>";
        //        // Tạo nội dung HTML tùy chỉnh
        //        string htmlBody = $"<html><body><img style=\"max-width: 100%; border-radius:20px;\" src='cid:{inline.ContentId}' alt='KStore' /><h1>Thông báo đơn hàng!</h1><p>Xin chào bạn đây là thông báo về đơn hàng với giá trị là {Pay.TongForMail}<p>Đơn hàng có mã <strong>{body}</strong> đã được chúng tôi xác nhận.{styleColor}<p>Vào lúc: {maDH.Ngay}</p></p><p>Cảm ơn vì bạn đã mua hàng.</p></body></html>";

        //        AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
        //        avHtml.LinkedResources.Add(inline);
        //        mailMessage.AlternateViews.Add(avHtml);

        //        // Gửi email
        //        smtpClient.Send(mailMessage);
        //        Console.WriteLine("Đã gửi email.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
        //    }
        //}

        public string EncryptQueryString(string queryString, string key)
        {
            using (var aesAlg = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                Array.Resize(ref keyBytes, 16); // Đảm bảo key có độ dài 16 byte
                aesAlg.Key = keyBytes;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, 16); // Lưu IV trước

                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(queryString);
                    }

                    return HttpUtility.UrlEncode(Convert.ToBase64String(msEncrypt.ToArray()));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int makh = GetMaTKFromSomeSource();
            //string ma = GenerateRandomString(6);
            string ma = Pay.MaDHXNGD;
            long amount = Pay.TongThanhTien;
            //Response.Redirect("../checkOutOrder/checkOut");
            string resultCodeString = HttpContext.Current.Request.QueryString["resultCode"];
            int resultCode;
            if (int.TryParse(resultCodeString, out resultCode))
            {

                string key = "260703";
                // resultCode is successfully parsed and can be used as an integer
                if (resultCode == 0 || resultCodeString == "0")
                {
                    string queryString = "makh=" + makh + "&MaDH=" + ma + "&Amount=" + amount + "&PTGD=Momo";
                    string encryptedQueryString = EncryptQueryString(queryString, key);
                    Response.Redirect("../checkOutOrder/checkOut?data=" + HttpUtility.UrlEncode(encryptedQueryString));
                }    
                    //Response.Redirect("../checkOutOrder/checkOut?makh=" + makh + "&MaDH=" + ma + "&Amount=" + amount + "");

                else if (resultCode == 1006 || resultCodeString == "1006")
                {
                    Response.Redirect("../Pay");
                }
                else
                {
                    Response.Redirect(Shop.localhost + "Error/PaymentFailed");
                }
            }
            else
            {
                Response.Redirect(Shop.localhost + "Error/PaymentFailed");
                // Handle the case where resultCode is not a valid integer
            }

            //Response.Redirect(Shop.localhost +  "Error/PaymentFailed");
            //GetListItemsInOrder(MaDHXNGD);
            //CreateTheOrder();
            //Thanh toan thanh cong


            // Session["MailMD"] = MaDHXNGD;
            // string email = Sign.email;

            // var userCheck = dbcontext.TKs.FirstOrDefault(u => u.Email == email);
            // string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);


            //if (userCheck != null) SendEmail(userCheck.Email, "KStore", MaDHXNGD, imagePath);
            //else SendEmail(Pay.emailKHnoSign, "KStore", MaDHXNGD, imagePath);
            //var don = dbcontext.ChiTietDonHangs.FirstOrDefault(s => s.MaDH == mdh || s.MaDH == MaDHXNGD);
            //List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            //Hepler hepler = new Hepler();



            //if (don != null)
            //{
            //    lstGioHang.Clear();
            //    Session["GioHang"] = lstGioHang;

            //    Session["MailMD"] = don.MaDH;
            //    string email = Sign.email;

            //    var db = new QL_KPOPStoreEntities();
            //    var user = db.TKs.FirstOrDefault(u => u.Email == email);
            //    string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);




            //        //System.Threading.Thread.Sleep(5000);

            //        if (user != null) SendEmail(user.Email, "KStore", don.MaDH, imagePath);
            //        else SendEmail(Pay.emailKHnoSign, "KStore", don.MaDH, imagePath);






            //    displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";




            //    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
            //    //Response.Redirect("../Pay");
            //    //displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
            //    //displayTmnCode.InnerText = TerminalID;
            //    displayTxnRef.InnerText = don.MaDH;
            //    //displayVnpayTranNo.InnerText = vnpayTranId.ToString();
            //    displayAmount.InnerText = string.Format("{0:N0}", don.ThanhTien) + "đ";
            //    //displayBankCode.InnerText = bankCode;
            //    displayOrderCode.InnerText = don.MaDH;
            //}

            //displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý";
        }
    }
    }