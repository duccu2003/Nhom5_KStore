using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using log4net;
using TH03_WebBanHang;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;
using static QRCoder.PayloadGenerator;

namespace VNPAY_CS_ASPX
{
    public partial class vnpay_return : System.Web.UI.Page
    {


        public static string mail;
        public string MaDH;
        public static string payOrder;
        public static string maKH;
        public static string MaDHXNGD;
        public static string displayMsg;
        public static string displayTxnRef;
        public static string displayAmount;
        public static string displayOrderCode;
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

        private static readonly ILog log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            log.InfoFormat("Begin VNPAY Return, URL={0}", Request.RawUrl);
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();
                 
                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                String TerminalID = Request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount"))/100;
                String bankCode = Request.QueryString["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {


                        //GetListItemsInOrder(MaDHXNGD);
                        // CreateTheOrder();
                        // //Thanh toan thanh cong
                        // displayOrderCode.InnerText = MaDHXNGD;

                        //// Session["MailMD"] = MaDHXNGD;
                        //// string email = Sign.email;

                        //// var userCheck = dbcontext.TKs.FirstOrDefault(u => u.Email == email);
                        //// string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);


                        ////if (userCheck != null) SendEmail(userCheck.Email, "KStore", MaDHXNGD, imagePath);
                        ////else SendEmail(Pay.emailKHnoSign, "KStore", MaDHXNGD, imagePath);




                        int makh = GetMaTKFromSomeSource();
                        string ma = GenerateRandomString(6);

                        // displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId, vnpayTranId);
                        //Task.Run(() =>
                        //{

                        //    System.Threading.Thread.Sleep(3000);
                        //    Response.Redirect("../OrderNotification.aspx?GD=VNPay");

                        //});
                        long amount = Pay.TongThanhTien;
                        string key = "260703";
                        string queryString = "makh=" + makh + "&MaDH=" + ma + "&Amount=" + amount + "&PTGD=VNPay";
                        string encryptedQueryString = EncryptQueryString(queryString, key);

                        Response.Redirect("../checkOutOrder/checkOut?data=" + HttpUtility.UrlEncode(encryptedQueryString));

                        //Response.Redirect("../checkOutOrder/checkOut?makh=" + makh + "&MaDH=" + ma + "&Amount=" + amount + "");




                        //Response.Redirect("../checkOutOrder/checkOut?makh="+makh+"&MaDH="+ma+"");

                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        Response.Redirect("../Pay");
                        displayMsg = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}", orderId, vnpayTranId, vnp_ResponseCode);
                    }
                    //displayTmnCode = TerminalID;
                    displayTxnRef =  orderId.ToString();
                    //displayVnpayTranNo =  vnpayTranId.ToString();
                    displayAmount = string.Format("{0:N0}", vnp_Amount) + "đ";
                    //displayBankCode =  bankCode;
                    displayOrderCode = MaDHXNGD;

                }
                else
                {
                    log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                    displayMsg = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }


            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            Hepler hepler = new Hepler();


            if (!IsPostBack)
            {

                // Khôi phục giá trị count từ session nếu có
                if (Session["Count"] != null)
                {
                    int count = (int)Session["Count"];
                    ViewState["Count"] = count;
                }


            }
            //var user = from u in dbcontext.TKs
            //           select u;
            //var khachhang = from u in dbcontext.KhachHangs
            //                select u;

            var db = new QL_KPOPStoreEntities();

            //if (TH03_WebBanHang.Sign.email!=null && Session["GioHang"] != null)
            //{
            //    //user.SingleOrDefault(p => p.MaTK==makh); 



            //    // user.Any(p =>p.MaTK == makh);


            //}
            //// Otherwise, display an error message

            //else
            //{



            //}

        }

        //public IQueryable<TH03_WebBanHang.Models.ChiTietDonHang> GetListItemsInOrder()
        //{
        //    //var chitietDon = dbcontext.ChiTietDonHangs.FirstOrDefault(s=>s.MaDH== MaDHXNGD);
        //    IQueryable<ChiTietDonHang> lsItems = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == MaDHXNGD);

        //    return lsItems;

        //}
        public double DoanhThuNgay { get; private set; }

        // Phương thức giả định để lấy giá trị MaTK từ một nguồn nào đó
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


        //public void CreateTheOrder()
        //{

        //    mail = Pay.emailKHnoSign;
        //    MaDH = null;
        //    double ThanhTien = 0;



        //        int makh = GetMaTKFromSomeSource(); // Giả định rằng bạn đã có phương thức này để lấy giá trị MaTK

        //        // Chuyển đổi giá trị MaTK thành chuỗi
        //        string kh = makh.ToString();

        //        ChiNhanh chiNhanh = new ChiNhanh();
        //        // Tăng giá trị count


        //        // Lưu giá trị count vào session
        //        string url = HttpContext.Current.Request.Url.ToString();
        //        List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
        //        //DonHang donHang = new DonHang();

        //        string ma = GenerateRandomString(6);
        //        if (lstGioHang != null && lstGioHang.Any())
        //        {
        //            var user = from u in dbcontext.KhachHangs
        //                       select u;

        //            var tk = from u in dbcontext.TKs select u;

        //            var hadUser = tk.Any(p => p.Email == Pay.emailKHnoSign && (p.MatKhau != null || p.MatKhau != ""));
        //            var hadClient = user.Any(p => p.Email == Pay.emailKHnoSign && (p.MatKhau != null || p.MatKhau != ""));
        //            var hadClientNonPass = user.Any(s => s.Email == Pay.emailKHnoSign && (s.MatKhau == null || s.MatKhau == ""));


        //            if (Sign.email == null)
        //            {
        //                using (var db = new QL_KPOPStoreEntities())
        //                {
        //                    // Kiểm tra giá trị trước khi thêm vào cơ sở dữ liệu
        //                    if ((!hadUser && !hadClient && !hadClientNonPass) /*&& !string.IsNullOrEmpty(Pay.emailKHnoSign) && !string.IsNullOrEmpty(Pay.DienThoaiKHnoSign) && !string.IsNullOrEmpty(Pay.DiaChiKHnoSign) && !string.IsNullOrEmpty(Pay.emailKHnoSign)*/)
        //                    {
        //                        var newUser = new TK
        //                        {
        //                            Email = Pay.emailKHnoSign,
        //                            MatKhau = null,
        //                            TrangThai = false,



        //                        };
        //                        var newClient = new KhachHang
        //                        {
        //                            AvatarUser = Shop.defaultAvatar_BlackKS,
        //                            HoTen = Pay.HotenKHnoSign,
        //                            DienThoai = Pay.DienThoaiKHnoSign,
        //                            DiaChi = Pay.DiaChiNN,
        //                            Email = Pay.emailKHnoSign,
        //                            GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
        //                            MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
        //                            TrangThai = false,
        //                            Diem = 0,
        //                        };
        //                        //db.TKs.Add(newUser);

        //                        //db.KhachHangs.Add(newClient);
        //                        //db.SaveChanges();
        //                        db.TKs.Add(newUser);

        //                        db.KhachHangs.Add(newClient);
        //                        db.SaveChanges();

        //                        //db.TKs.Add(newUser);

        //                        //db.KhachHangs.Add(newClient);
        //                        //db.SaveChanges();
        //                        // Tạo một đơn hàng mới
        //                        string makhno;
        //                        makhno = newClient.MaKH.ToString();
        //                        DonHang donHang = new DonHang
        //                        {
        //                            MaDH = ma,
        //                            HoTenNN = Pay.HotenKHnoSign,
        //                            DiaChiNN = Pay.DiaChiNN,
        //                            DienThoaiNN = Pay.DienThoaiKHnoSign,


        //                            KH = newClient.MaKH,
        //                            Ngay = DateTime.Now,
        //                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                        };
        //                        mail = newClient.Email;
        //                        //    donHang.MaDH = ma;
        //                        ////donHang.MaKH = makh;

        //                    //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                    //    donHang.KH = kh;

        //                    //    // Tiếp tục xử lý khác ở đây...

        //                    //donHang.Ngay = DateTime.Now;
        //                    //donHang.MaCN = Shop.CH;
        //                    //donHang.ChiTietDonHangs = lstGioHang;
        //                    //donHang.MaKH = Account.makh;

        //                        dbcontext.DonHangs.Add(donHang);

        //                        string maDonHang = donHang.MaDH;
        //                        MaDHXNGD = donHang.MaDH;
        //                        int count = 1;
        //                        foreach (var item in lstGioHang)
        //                        {
        //                            string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                            ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                            {
        //                                KH = donHang.KH,
        //                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                                MaCTDH = mact,
        //                                MaSP = item.MaSP,
        //                                TenSP = item.TenSP,
        //                                DuongDan = item.DuongDan,
        //                                SoLuong = item.SoLuong,
        //                                Gia = item.Gia,
        //                                ThanhTien = item.ThanhTien,
        //                                TenPob = item.TenPob,



        //                            };

        //                            //chiTietDon.KH = donHang.KH;
        //                            //chiTietDon.MaDH = donHang.MaDH;
        //                            //chiTietDon.MaCTDH = mact;
        //                            //chiTietDon.MaSP = item.MaSP;
        //                            //chiTietDon.TenSP = item.TenSP;
        //                            //chiTietDon.DuongDan = item.DuongDan;
        //                            //chiTietDon.SoLuong = item.SoLuong;
        //                            //chiTietDon.Gia = item.Gia;
        //                            //chiTietDon.ThanhTien = item.ThanhTien;
        //                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh); double diem = chiTietDon.ThanhTien / 200000;
        //                            if (khachmua != null)
        //                            {

        //                                khachmua.Diem = khachmua.Diem + (int)diem;
        //                            }
        //                            else
        //                            {
        //                                var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                                khachHad.Diem = khachHad.Diem + (int)diem;
        //                            }
        //                            chiTietDon.Ngay = donHang.Ngay;
        //                            chiTietDon.GiaoDich = true;
        //                            ThanhTien = chiTietDon.ThanhTien;
        //                            MaDH = chiTietDon.MaDH;
        //                            count++;
        //                            payOrder = donHang.MaDH;
        //                            maKH = donHang.KH.ToString();


        //                            dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                        }
        //                        // Thêm thông báo thành công hoặc xử lý kết quả khác

        //                    }
        //                    else
        //                    {
        //                        var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);

        //                        DonHang donHang = new DonHang
        //                        {
        //                            MaDH = ma,
        //                            HoTenNN = Pay.HotenKHnoSign,
        //                            DiaChiNN = Pay.DiaChiNN,
        //                            DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                            KH = khachmua.MaKH,
        //                            Ngay = DateTime.Now,
        //                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                        };


        //                        dbcontext.DonHangs.Add(donHang);

        //                        string maDonHang = donHang.MaDH;
        //                        MaDHXNGD = donHang.MaDH;
        //                        mail = Pay.emailKHnoSign;
        //                        int count = 1;
        //                        foreach (var item in lstGioHang)
        //                        {
        //                            string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                            ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                            {
        //                                KH = donHang.KH,
        //                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                                MaCTDH = mact,
        //                                MaSP = item.MaSP,
        //                                TenSP = item.TenSP,
        //                                DuongDan = item.DuongDan,
        //                                SoLuong = item.SoLuong,
        //                                Gia = item.Gia,
        //                                ThanhTien = item.ThanhTien,
        //                                TenPob = item.TenPob,

        //                            };

        //                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
        //                            double diem = chiTietDon.ThanhTien / 200000;
        //                            if (khachmua != null)
        //                            {

        //                                khachmua.Diem = khachmua.Diem + (int)diem;
        //                            }
        //                            else
        //                            {
        //                                var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                                khachHad.Diem = khachHad.Diem + (int)diem;
        //                            }
        //                            chiTietDon.Ngay = donHang.Ngay;
        //                            chiTietDon.GiaoDich = true;
        //                            ThanhTien = chiTietDon.ThanhTien;
        //                            MaDH = chiTietDon.MaDH;
        //                            count++;
        //                            payOrder = donHang.MaDH;
        //                            maKH = donHang.KH.ToString();


        //                            dbcontext.ChiTietDonHangs.Add(chiTietDon);




        //                        }

        //                    }
        //                }

        //            }
        //            else if (hadUser && hadClient && !hadClientNonPass)
        //            {
        //                if (Sign.email != null && user.Any(p => p.Email == Sign.email))
        //                {
        //                    // Tạo một đơn hàng mới
        //                    DonHang donHang = new DonHang
        //                    {
        //                        MaDH = ma,
        //                        HoTenNN = Pay.HotenKHnoSign,
        //                        DiaChiNN = Pay.DiaChiNN,
        //                        DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                        KH = makh,
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
        //                    MaDHXNGD = donHang.MaDH;
        //                    mail = Pay.emailKHnoSign;
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
        //                        payOrder = donHang.MaDH;
        //                        maKH = donHang.KH.ToString();


        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);




        //                    }
        //                }
        //                else
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
        //                    MaDHXNGD = donHang.MaDH;
        //                    mail = Pay.emailKHnoSign;
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
        //                        payOrder = donHang.MaDH;
        //                        maKH = donHang.KH.ToString();
        //                        dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                    }
        //                }
        //            }
        //            else
        //            {
        //                using (var db = new QL_KPOPStoreEntities())
        //                {
        //                    if (hadClientNonPass)
        //                    {
        //                        var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                        string khHadMaKH = khHad.MaKH.ToString();
        //                        // Tạo một đơn hàng mới
        //                        DonHang donHang = new DonHang
        //                        {
        //                            MaDH = ma,
        //                            HoTenNN = Pay.HotenKHnoSign,
        //                            DiaChiNN = Pay.DiaChiNN,
        //                            DienThoaiNN = Pay.DienThoaiKHnoSign,
        //                            KH = khHad.MaKH,
        //                            Ngay = DateTime.Now,
        //                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                        };
        //                        //    donHang.MaDH = ma;
        //                        ////donHang.MaKH = makh;

        //                        //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                        //    donHang.KH = kh;

        //                        //    // Tiếp tục xử lý khác ở đây...

        //                        //donHang.Ngay = DateTime.Now;
        //                        //donHang.MaCN = Shop.CH;
        //                        //donHang.ChiTietDonHangs = lstGioHang;
        //                        //donHang.MaKH = Account.makh;

        //                        dbcontext.DonHangs.Add(donHang);

        //                        string maDonHang = donHang.MaDH;
        //                        MaDHXNGD = donHang.MaDH;
        //                        mail = Pay.emailKHnoSign;
        //                        int count = 1;
        //                        foreach (var item in lstGioHang)
        //                        {
        //                            string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                            ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                            {
        //                                KH = donHang.KH,
        //                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                                MaCTDH = mact,
        //                                MaSP = item.MaSP,
        //                                TenSP = item.TenSP,
        //                                DuongDan = item.DuongDan,
        //                                SoLuong = item.SoLuong,
        //                                Gia = item.Gia,
        //                                ThanhTien = item.ThanhTien,
        //                                TenPob = item.TenPob,
        //                            };

        //                            //chiTietDon.KH = donHang.KH;
        //                            //chiTietDon.MaDH = donHang.MaDH;
        //                            //chiTietDon.MaCTDH = mact;
        //                            //chiTietDon.MaSP = item.MaSP;
        //                            //chiTietDon.TenSP = item.TenSP;
        //                            //chiTietDon.DuongDan = item.DuongDan;
        //                            //chiTietDon.SoLuong = item.SoLuong;
        //                            //chiTietDon.Gia = item.Gia;
        //                            //chiTietDon.ThanhTien = item.ThanhTien;
        //                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
        //                            var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
        //                            double diem = chiTietDon.ThanhTien / 200000;


        //                            if (khHad.Diem != null)
        //                                khHad.Diem = khHad.Diem + (int)diem;
        //                            else
        //                            {
        //                                khHad.Diem = 0;
        //                                khHad.Diem = khHad.Diem + (int)diem;

        //                            }




        //                            chiTietDon.Ngay = donHang.Ngay;
        //                            chiTietDon.GiaoDich = true;
        //                            ThanhTien = chiTietDon.ThanhTien;
        //                            MaDH = chiTietDon.MaDH;
        //                            count++;
        //                            payOrder = donHang.MaDH;
        //                            maKH = donHang.KH.ToString();
        //                            dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                        }
        //                    }

        //                    else
        //                    {
        //                        var newUser = new TK
        //                        {
        //                            Email = Pay.emailKHnoSign,
        //                            MatKhau = null,
        //                            TrangThai = false,



        //                        };
        //                        var newClient = new KhachHang
        //                        {
        //                            AvatarUser = Shop.defaultAvatar_BlackKS,
        //                            HoTen = Pay.HotenKHnoSign,
        //                            DienThoai = Pay.DienThoaiKHnoSign,
        //                            DiaChi = Pay.DiaChiNN,
        //                            Email = Pay.emailKHnoSign,
        //                            GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
        //                            MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
        //                            TrangThai = false,
        //                            Diem = 0,
        //                        };
        //                        //db.TKs.Add(newUser);

        //                        //db.KhachHangs.Add(newClient);
        //                        //db.SaveChanges();
        //                        db.TKs.Add(newUser);

        //                        db.KhachHangs.Add(newClient);
        //                        db.SaveChanges();

        //                        //db.TKs.Add(newUser);

        //                        //db.KhachHangs.Add(newClient);
        //                        //db.SaveChanges();
        //                        // Tạo một đơn hàng mới
        //                        string makhno;
        //                        makhno = newClient.MaKH.ToString();
        //                        DonHang donHang = new DonHang
        //                        {
        //                            MaDH = ma,
        //                            HoTenNN = Pay.HotenKHnoSign,
        //                            DiaChiNN = Pay.DiaChiNN,
        //                            DienThoaiNN = Pay.DienThoaiKHnoSign,


        //                            KH = newClient.MaKH,
        //                            Ngay = DateTime.Now,
        //                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
        //                        };
        //                        //    donHang.MaDH = ma;
        //                        ////donHang.MaKH = makh;

        //                        //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
        //                        //    donHang.KH = kh;

        //                        //    // Tiếp tục xử lý khác ở đây...

        //                        //donHang.Ngay = DateTime.Now;
        //                        //donHang.MaCN = Shop.CH;
        //                        //donHang.ChiTietDonHangs = lstGioHang;
        //                        //donHang.MaKH = Account.makh;

        //                        dbcontext.DonHangs.Add(donHang);

        //                        string maDonHang = donHang.MaDH;
        //                        MaDHXNGD = donHang.MaDH;
        //                        mail = newClient.Email;
        //                        int count = 1;
        //                        foreach (var item in lstGioHang)
        //                        {
        //                            string mact = maDonHang + count.ToString() + donHang.MaCN;

        //                            ChiTietDonHang chiTietDon = new ChiTietDonHang
        //                            {
        //                                KH = donHang.KH,
        //                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
        //                                MaCTDH = mact,
        //                                MaSP = item.MaSP,
        //                                TenSP = item.TenSP,
        //                                DuongDan = item.DuongDan,
        //                                SoLuong = item.SoLuong,
        //                                Gia = item.Gia,
        //                                ThanhTien = item.ThanhTien,
        //                                TenPob = item.TenPob,



        //                            };

        //                            //chiTietDon.KH = donHang.KH;
        //                            //chiTietDon.MaDH = donHang.MaDH;
        //                            //chiTietDon.MaCTDH = mact;
        //                            //chiTietDon.MaSP = item.MaSP;
        //                            //chiTietDon.TenSP = item.TenSP;
        //                            //chiTietDon.DuongDan = item.DuongDan;
        //                            //chiTietDon.SoLuong = item.SoLuong;
        //                            //chiTietDon.Gia = item.Gia;
        //                            //chiTietDon.ThanhTien = item.ThanhTien;
        //                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
        //                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh); double diem = chiTietDon.ThanhTien / 200000;
        //                            if (khachmua != null)
        //                            {

        //                                khachmua.Diem = khachmua.Diem + (int)diem;
        //                            }
        //                            else
        //                            {
        //                                var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == Pay.emailKHnoSign);
        //                                khachHad.Diem = khachHad.Diem + (int)diem;
        //                            }
        //                            chiTietDon.Ngay = donHang.Ngay;
        //                            chiTietDon.GiaoDich = true;
        //                            ThanhTien = chiTietDon.ThanhTien;
        //                            MaDH = chiTietDon.MaDH;
        //                            count++;
        //                            payOrder = donHang.MaDH;
        //                            maKH = donHang.KH.ToString();


        //                            dbcontext.ChiTietDonHangs.Add(chiTietDon);

        //                        }
        //                    }
        //                }




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
        //        //lstGioHang.Clear();
        //        //Session["GioHang"] = lstGioHang;
        //        //Response.Redirect("Success.aspx?GD=Card");

        //        if (MaDHXNGD != null)
        //        {
        //            lstGioHang.Clear();
        //            Session["GioHang"] = lstGioHang;
        //            //Response.Redirect("OrderNotification.aspx?GD=VNPay");
        //            ChiTietDonHang maDH = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == MaDHXNGD);

        //            Session["MailMD"] = MaDHXNGD;
        //            string email = Sign.email;
        //            var userHad = dbcontext.TKs.FirstOrDefault(u => u.Email == email);

        //            var userCheck = dbcontext.TKs.Any(u => u.Email == email);
        //            string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);


        //            if (userCheck) SendEmail(mail, "KStore", Session["MailMD"].ToString(), imagePath);
        //            else SendEmail(mail, "KStore", Session["MailMD"].ToString(), imagePath);


        //        }
        //        else
        //        {
        //            Response.Redirect("http://localhost:52718/Error/PaymentFailed");
        //        }




        //    }
        //}

        private string GenerateRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }


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
    }
}