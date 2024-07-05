using log4net;
using Newtonsoft.Json.Linq;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Input;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;
using VNPAY_CS_ASPX.Models;
using VNPAY_CS_ASPX;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows;
using MoMo;
using Prism.Services.Dialogs;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
<<<<<<< HEAD
using System.Data.Entity.Infrastructure;
using System.Threading;
=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498



namespace TH03_WebBanHang
{
    public partial class Pay : System.Web.UI.Page
    {
        public static string Amount;
        public static string madh;
        public static string emailKHnoSign;
        public static string DiaChiKHnoSign;
        public static string DienThoaiKHnoSign;
        public static string HotenKHnoSign;
        public static string TongForMail;
        public static string MaDHXNGD;
        public static string DiaChiNN;
        public static long TongThanhTien;
        public static string MaDHtoMomo;
        public static int IdClinedtoMomo;
        public static string DiaChitxt;
        private static readonly ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string apiKeyCK = ConfigurationManager.AppSettings["KStore-CK"];
            string apiKeyBM = ConfigurationManager.AppSettings["KStore-BM"];
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
<<<<<<< HEAD
            
            var hadtk = dbcontext.TKs.Any(s => s.Email == EmailKhach && s.TrangThai==true);
            if (hadtk)
            {
                
                var tk = dbcontext.TKs.FirstOrDefault(s => s.Email == EmailKhach);
                var kh = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                if (tk.Email == "Admin")
                {

                    Session["MaKH"] = 0;
                    Response.Redirect("Account");
                }
                else
                {

                    Session["MaKH"] = kh.MaKH;
                }
            }

            var hadkh = dbcontext.KhachHangs.Any(s => s.Email == EmailKhach && s.TrangThai == true);

            if (hadkh) { 
                var kh = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach); 
                Session["MaKH"] = kh.MaKH; 
            }
            

            if (!IsPostBack)
            {
                if (Email == null) EmailKhach = Sign.email;
                else EmailKhach = Email.Value;

                if (hadtk)
                {
                    var kh = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                    var tk = dbcontext.TKs.FirstOrDefault(s => s.Email == EmailKhach);

                    if (tk.Email == "Admin")
                    {

                        Session["MaKH"] = 0;
                        Response.Redirect("Account");
                    }
                    else
                    {   
                        Session["MaKH"] = kh.MaKH;
                    }
                }

                if (hadkh)
                {
                    var kh = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                    Session["MaKH"] = kh.MaKH;
                }


=======
            if (!IsPostBack)
            {
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                // Khôi phục giá trị count từ session nếu có
                if (Session["Count"] != null)
                {
                    int count = (int)Session["Count"];
                    ViewState["Count"] = count;
                }
                //ddlCity.Items.Add(new ListItem("Chọn thành phố", ""));
                //ddlCity.Items.Add(new ListItem("Hà Nội", "Hanoi"));
                //ddlCity.Items.Add(new ListItem("TP. Hồ Chí Minh", "HCM"));
<<<<<<< HEAD
                if (khachhang.Any(p => p.TrangThai == true && p.Email == EmailKhach) || user.Any(p => (p.TrangThai == true && p.Email == EmailKhach)))
=======
                if (khachhang.Any(p => p.Email == EmailKhach)|| user.Any(p => (p.TrangThai == true && p.Email == EmailKhach)))
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                {

                    // Đặt giá trị cho txtEmailSignUp
                    txtEmailSignUp.Text = khachhang.Where(s=>s.Email==EmailKhach).Select(p => p.Email).FirstOrDefault() ?? string.Empty;

                    // Đặt giá trị cho txtName
                    txtName.Text = khachhang.Where(s => s.Email == EmailKhach).Select(p => p.HoTen).FirstOrDefault() ?? string.Empty;


                    // Đặt giá trị cho txtPasswordSignUp
                    // Lưu ý: Mật khẩu không nên được hiển thị trực tiếp
                    // txtPasswordSignUp.Text = khachhang.Select(p => p.MatKhau).FirstOrDefault() ?? string.Empty;
                    TextPhone.Text = khachhang.Where(s => s.Email == EmailKhach).Select(p => p.DienThoai).FirstOrDefault() ?? string.Empty;
                    // Đặt giá trị cho ddlGT
                    //var gioiTinh = khachhang.Where(s => s.Email == EmailKhach).Select(p => p.GioiTinh).FirstOrDefault();
                    //var gioiTinhItem = ddlGT.Items.FindByText(gioiTinh);
                    //if (gioiTinhItem != null)
                    //{
                    //    ddlGT.Text = gioiTinhItem.Text;
                    //}

                    //var diaChiParts = khachhang.Select(p => p.DiaChi).FirstOrDefault().Split(new[] { ", " }, StringSplitOptions.None);
                    //if (diaChiParts.Length >= 3)
                    //{
                    //    // Giả sử diaChiParts[0] là địa chỉ cụ thể, diaChiParts[1] là quận huyện, và diaChiParts[2] là thành phố
                    //    txtDiachi.Text = diaChiParts[0] ?? string.Empty;
                    //    // Tìm quận huyện tương ứng trong DropDownList quận huyện

                    //    var cityItem = ddlCity.Items.FindByText(diaChiParts[2]);
                    //    if (cityItem != null)
                    //    {
                    //        ddlCity.SelectedItem.Text = cityItem.Text;
                    //    } 
                    //    var districtItem = ddlDistrict.Items.FindByText(diaChiParts[1]);
                    //    if (districtItem != null||diaChiParts.Contains(ddlDistrict.Text)||diaChiParts.Contains(ddlCity.Text))
                    //    {

                    //        ddlDistrict.Text = districtItem.Text;

                    //    }

                    //}
                    /* else {*/

                    //}
                    ddlCity.Visible = false;
                    ddlDistrict.Visible = false;
                    ddlW.Visible = false;
                    


                    Response.Write(" <style>\r\n        .input-field-DiaChi{\r\n \r\n   width:28rem !important;\r\n}\r\n    </style>");
                    txtDiachi.Text = khachhang.Where(s => s.Email == EmailKhach).Select(p => p.DiaChi).FirstOrDefault() ?? string.Empty;
                    



                    //ddlDistrict.Text=khachhang.Select(p => p.DiaChi).FirstOrDefault();
                    //txtDiachi.Text = khachhang.Select(p => p.DiaChi).FirstOrDefault();

                }
                else
                {


                     
                    txtEmailSignUp.Text = null;
                    txtName.Text = null;
                    //ddlGT.Text = null;
                    txtDiachi.Text = null;
                    //ddlCity.Text = null;
                    //ddlDistrict.Text = null;
                    Response.Write("  <style>\r\n        .input-field-DiaChi{\r\n             width:13rem !important;\r\n        }\r\n   </style>");
                }
                // Set the flag to indicate that the DropDownLists have not been populated yet
                ViewState["DropDownListsPopulated"] = false;

                PopulateDropDownLists();
                List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;

                // Đặt dữ liệu cho ListView
                ListViewGioHang.DataSource = lstGioHang;
                ListViewGioHang.DataBind();
                Hepler hepler = new Hepler();

                lbTong.Text ="Tổng tiền: "+ hepler.TongThanhTien(lstGioHang).ToString();
                TongForMail = hepler.TongThanhTien(lstGioHang).ToString();
                
                TongThanhTien = hepler.longTongThanhTien(lstGioHang);

            }
            else
            {
                // Retrieve selected values from ViewState on postback
                if (ViewState["SelectedCity"] != null)
                {
                    ddlCity.SelectedValue = ViewState["SelectedCity"].ToString();
                }
                if (ViewState["SelectedDistrict"] != null)
                {
                    ddlDistrict.SelectedValue = ViewState["SelectedDistrict"].ToString();
                }
                if (ViewState["SelectedWard"] != null)
                {
                    ddlW.SelectedValue = ViewState["SelectedWard"].ToString();
                }
            }



            var db = new QL_KPOPStoreEntities();

            if (user.Any(p => (p.TrangThai == true && p.Email == EmailKhach)) && Session["GioHang"] != null)
            {
                //user.SingleOrDefault(p => p.MaTK==makh); 
                

                // user.Any(p =>p.MaTK == makh);


            }
            // Otherwise, display an error message

            else
            {

                //Response.Redirect("Cart.aspx");

            }

            //List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            //Hepler hepler = new Hepler();



            
            //string amount = hepler.TongThanhTien(lstGioHang).ToString();
            //string ma = GenerateRandomString(4);
            //string orderId = ma+countQR.ToString()+ Shop.CH;
            //maDHQR = orderId;
            ////        < add key = "vietQRapiKey" value = "c80d2dd7-13a5-4ab2-9d8d-745da3356fad" />

            ////< add key = "vietQRclientKey" value = "f46c9c31-d300-46d5-80c6-a92fd4079891" />

            ////< add key = "vietQRreturn" value = "http://localhost:52718/Success.asp?GD=QR" />
            //string vietQRlink = $"https://api.vietqr.io/image/970454-9021053350473-BIsgDhE.jpg?accountName=NGUYEN%20HOANG%20DUC&amount={amount}&orderid={orderId}&return_url=http://localhost:52718/Success.asp?GD=QR";
            ////string vietQRlink = $"https://sandbox.vnpayment.vn/token_ui/create-token.html?vnp_app_user_id={SignIn.makh}&vnp_cancel_url=http://localhost:52718/Pay.aspx&vnp_card_type=01&vnp_command=token_create&vnp_create_date={DateTime.Now}&vnp_ip_addr=192:168:1:11&vnp_locale=vi&vnp_return_url=http://localhost:52718/Success.asp?GD=QR&vnp_tmn_code=B9KOCLN0&vnp_txn_desc=Tao moi token&vnp_txn_ref=286&vnp_version=2.0.1&vnp_secure_hash={{value}}\r\n";

            //Bitmap qrCodeImage = GenerateMomoQRCode( vietQRlink);
            //imgMomoQRCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ImageToByte(qrCodeImage));
        }
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();


        private void PopulateDropDownLists()
        {
            using (var context = new VNlocalEntities())
            {
                
                
               
                var queryTP = from tp in context.devvn_tinhthanhpho
                              select new { tp.matp, tp.nameTP };

                ddlCity.DataSource = queryTP.ToList();
                ddlCity.DataTextField = "nameTP";
                ddlCity.DataValueField = "matp";
                ddlCity.DataBind();

                // Check if a city is selected
                string selectedCity = ddlCity.SelectedValue;
                if (!string.IsNullOrEmpty(selectedCity))
                {
                    // Populate ddlDistrict
                    var queryQH = from qh in context.devvn_quanhuyen
                                  where qh.matp == selectedCity
                                  select new { qh.maqh, qh.nameQH };

                    ddlDistrict.DataSource = queryQH.ToList();
                    ddlDistrict.DataTextField = "nameQH";
                    ddlDistrict.DataValueField = "maqh";
                    ddlDistrict.DataBind();

                    // Check if a district is selected
                    string selectedDis = ddlDistrict.SelectedValue;
                    if (!string.IsNullOrEmpty(selectedDis))
                    {
                        // Populate ddlW
                        var queryXH = from xp in context.devvn_xaphuongthitran
                                      where xp.maqh == selectedDis
                                      select new { xp.xaid, xp.nameXP };

                        ddlW.DataSource = queryXH.ToList();
                        ddlW.DataTextField = "nameXP";
                        ddlW.DataValueField = "xaid";
                        ddlW.DataBind();
                    }
                }
                
                else
                {
                    ddlCity.SelectedIndex = 0;
                }

                // Set the flag to indicate that the DropDownLists have been populated
                ViewState["DropDownListsPopulated"] = true;
            }
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {



            using (var context = new VNlocalEntities())
            {

                string selectedCity = ddlCity.SelectedValue;
                if (!string.IsNullOrEmpty(selectedCity))
                {
                    // Filter districts based on the selected city
                    var queryQH = from qh in context.devvn_quanhuyen
                                  where qh.matp == selectedCity
                                  select new { qh.maqh, qh.nameQH };

                    ddlDistrict.DataSource = queryQH.ToList();
                    ddlDistrict.DataTextField = "nameQH";
                    ddlDistrict.DataValueField = "maqh";
                    ddlDistrict.DataBind();

                }

            }

        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new VNlocalEntities();
            using (context)
            {
                string selectedDistrict = ddlDistrict.SelectedValue;
                if (!string.IsNullOrEmpty(selectedDistrict))
                {
                    var queryXH = from xp in context.devvn_xaphuongthitran
                                  where xp.maqh == selectedDistrict
                                  select new { xp.xaid, xp.nameXP };

                    ddlW.DataSource = queryXH.ToList();
                    ddlW.DataTextField = "nameXP";
                    ddlW.DataValueField = "xaid";
                    ddlW.DataBind();
                }
            }
        }
        protected void ddlW_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void DeleteItemFromCart(string itemId, string Pob)
        {
            // Retrieve the cart from the session
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            if (lstGioHang != null)
            {
                // Find the item to update
                ChiTietDonHang itemToUpdate = lstGioHang.FirstOrDefault(item => item.MaSP == itemId && (item.TenPob == Pob || item.TenPob == null));
                if (itemToUpdate != null)
                {
                    // Check if the item's quantity is greater than  1
                    if (itemToUpdate.SoLuong > 1)
                    {
                        // Decrease the quantity by  1
                        itemToUpdate.SoLuong--;

                    }
                    else
                    {
                        // If the quantity is  1, remove the item from the cart
                        lstGioHang.Remove(itemToUpdate);
                    }
                    itemToUpdate.ThanhTien = itemToUpdate.SoLuong * itemToUpdate.Gia;

                    // Update the session with the new cart list
                    Session["GioHang"] = lstGioHang;

                    // Optionally, refresh the ListView to reflect the changes
                    ListViewGioHang.DataBind();
                    // Update the total price label
                    UpdateTotalPrice();
                }
            }
        }

        public string url = HttpContext.Current.Request.Url.ToString();


        private void UpdateTotalPrice()
        {
            // Calculate the total price of items in the cart
            // This is just a placeholder method
            Hepler hepler = new Hepler();
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;

            lbTong.Text = hepler.TongThanhTien(lstGioHang).ToString();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            ImageButton btnDelete = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            string itemId = btnDelete.CommandArgument;
            string[] arg = new string[2];
            arg = btnDelete.CommandArgument.ToString().Split(';');
            string maSP = arg[0];
            string Pob = arg[1];
            // Example: Delete the item from the cart
            // You'll need to replace this with your actual logic
            DeleteItemFromCart(maSP, Pob);
            // Example: Delete the item from the cart
            // You'll need to replace this with your actual logic
            //DeleteItemFromCart(itemId);

            // Optionally, refresh the ListView to reflect the changes
            ListViewGioHang.DataBind();
            // Update the total price label
            UpdateTotalPrice();
            Response.Redirect(url);
        }


        protected void btnChange_Click(object sender, EventArgs e)
        {
            ImageButton btnChange = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            string itemId = btnChange.CommandArgument;
            string[] arg = new string[2];
            arg = btnChange.CommandArgument.ToString().Split(';');
            string maSP = arg[0];
            string Pob = arg[1];


            ItemFromCart(maSP, Pob);


            //ItemFromCart(itemId);
            // Optionally, refresh the ListView to reflect the changes
            ListViewGioHang.DataBind();
            // Update the total price label
            UpdateTotalPrice();
            Response.Redirect(url);

        }
        private void ItemFromCart(string itemId, string Pob)
        {
            // Retrieve the cart from the session
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            if (lstGioHang != null)
            {
                // Find the item to update
                ChiTietDonHang itemToUpdate = lstGioHang.FirstOrDefault(item => item.MaSP == itemId && (item.TenPob == Pob || item.TenPob == null));
                var sanphamC = dbcontext.SanPhams.FirstOrDefault(item => item.MaSP == itemId);
                if (itemToUpdate != null && sanphamC != null)
                {
                    // Calculate the available quantity based on SoLuongKho and the quantity already in the cart
                    sanphamC.SoLuongKho -= itemToUpdate.SoLuong;

                    // Check if the requested quantity is greater than 0 and not exceeding the available quantity
                    if (sanphamC.SoLuongKho>0)
                    {
                        itemToUpdate.SoLuong++;
                    }
                    // If the requested quantity exceeds the available quantity, set it to the maximum available quantity
                    else if (sanphamC.SoLuongKho< 0)
                    {
                        itemToUpdate.SoLuong +=0;
                    }

                    itemToUpdate.ThanhTien = itemToUpdate.SoLuong * itemToUpdate.Gia;

                    // Update the session with the new cart list
                    Session["GioHang"] = lstGioHang;

                    // Optionally, refresh the ListView to reflect the changes
                    ListViewGioHang.DataBind();
                    // Update the total price label
                    UpdateTotalPrice();
                }
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy nút nhấn
            System.Web.UI.WebControls.Button btnXoa = (System.Web.UI.WebControls.Button)sender;

            // Lấy mã sản phẩm từ CommandArgument của nút
            //string maSP = btnXoa.CommandArgument;

            string[] arg = new string[2];
            arg = btnXoa.CommandArgument.ToString().Split(';');
            string maSP = arg[0];
            string Pob = arg[1];

            // Lấy danh sách sản phẩm từ Session
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;

            // Tìm và xóa sản phẩm tương ứng
            var chiTietDon = lstGioHang.FirstOrDefault(item => item.MaSP == maSP && (item.TenPob == Pob || item.TenPob==null));
            if (chiTietDon != null)
            {
                lstGioHang.Remove(chiTietDon);
            }

            // Cập nhật Session và giao diện người dùng
            Session["GioHang"] = lstGioHang;
            ListViewGioHang.DataSource = lstGioHang;
            ListViewGioHang.DataBind();
        }

        // Phương thức giả định để lấy giá trị MaTK từ một nguồn nào đó
        //protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Xóa tất cả các mục hiện có trong DropDownList quận huyện
        //    ddlDistrict.Items.Clear();

        //    // Điền dữ liệu vào DropDownList quận huyện dựa trên thành phố được chọn
        //    if (ddlCity.SelectedValue == "Hanoi")
        //    {
        //        ddlDistrict.Items.Add(new ListItem("Chọn quận huyện", ""));
        //        ddlDistrict.Items.Add(new ListItem("Quận Ba Đình", "BaDinh"));
        //        ddlDistrict.Items.Add(new ListItem("Quận Hoàn Kiếm", "HoanKiem"));
        //        // Thêm các quận huyện khác tại đây
        //    }
        //    else if (ddlCity.SelectedValue == "HCM")
        //    {
        //        ddlDistrict.Items.Add(new ListItem("Chọn quận huyện", ""));
        //        ddlDistrict.Items.Add(new ListItem("Quận 1", "Quan1"));
        //        ddlDistrict.Items.Add(new ListItem("Quận 2", "Quan2"));
        //        // Thêm các quận huyện khác tại đây
        //    }
        //    // Xử lý các thành phố khác tại đây
        //}

        protected void ddlPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string txtTT;

            //if (ddlPay.SelectedValue == "TM")
            //{
            //    txtTT = "TM";
            //}
            //else if (ddlPay.SelectedValue == "PAY")
            //{
            //    txtTT = "PAY";
            //}
            //else if (ddlPay.SelectedValue == "QR")
            //{
            //    txtTT = "QR";
            //}
        }

        public byte[] ImageToByte(System.Drawing.Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Bitmap GenerateMomoQRCode( string vietQRlink)
        {
            string paymentInfo = $"{vietQRlink}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(paymentInfo, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
          
            return qrCodeImage;
        }
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
            else if(Session["MaKH"] == null)
            {
                return 0;
            }
          

            // Trong trường hợp không có giá trị MaTK nào được tìm thấy hoặc không hợp lệ, bạn có thể trả về một giá trị mặc định hoặc thực hiện xử lý khác tùy thuộc vào yêu cầu của ứng dụng của bạn.
            return 0; // Ví dụ: Trả về -1 nếu không có giá trị MaTK được tìm thấy
        }

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





        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        public void Momo(string amountOrder, string redirectMomo)
        {
            IdClinedtoMomo = GetMaTKFromSomeSource();
            string ma = GenerateRandomString(6);
            MaDHXNGD = GenerateRandomString(6);
            MaDHtoMomo = ma;
            string endapiCreate = "https://test-payment.momo.vn/v2/gateway/api/create";
            //request params need to request to MoMo system
            string endpoint = endapiCreate.Equals("") ? "https://test-payment.momo.vn/v2/gateway/api/create" : "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO5RGX20191128";
            string accessKey = "M8brj9K6E22vXoDB";
            string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = "Thanh toán đơn hàng "+ MaDHXNGD + " trị giá "+  string.Format("{0:N0}", amountOrder) + "đ" + ", từ Kstore.";
            string redirectUrl = redirectMomo /*Shop.localhost +  "Momo/redirectMomo.aspx"*/;
            string ipnUrl = Shop.localhost + "Momo/ipnMomo.aspx";
            string requestType = "captureWallet";

            string amount = amountOrder;
            string orderId = MaDHXNGD /*Guid.NewGuid().ToString()*/;
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "accessKey=" + accessKey +
                "&amount=" + amount +
                "&extraData=" + extraData +
                "&ipnUrl=" + ipnUrl +
                "&orderId=" + orderId +
                "&orderInfo=" + orderInfo +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + redirectUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType
                ;

            log.Debug("rawHash = " + rawHash);

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }

            };
            log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            log.Debug("Return from MoMo: " + jmessage.ToString());
            
           System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
            
        }
        private void textPartnerCode_TextChanged(object sender, EventArgs e)
        {

        }
        public void CreateTheOrder(string MaDH, string kh, int makh)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
<<<<<<< HEAD

=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
            if (string.IsNullOrEmpty(txtEmailSignUp.Text) ||
    string.IsNullOrEmpty(txtName.Text) ||
    string.IsNullOrEmpty(txtDiachi.Text) ||
    string.IsNullOrEmpty(TextPhone.Text) ||
    string.IsNullOrEmpty(ddlCity.Text) ||
    string.IsNullOrEmpty(ddlDistrict.Text) ||
    string.IsNullOrEmpty(ddlW.Text))
            {
                // Hiển thị thông báo lỗi
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Vui lòng điền đầy đủ thông tin');", true);
                return;
            }
            Amount = TH03_WebBanHang.Pay.TongThanhTien.ToString();
            
            emailKHnoSign = txtEmailSignUp.Text;
            DiaChiKHnoSign = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;
            DiaChiNN = DiaChiKHnoSign;
            DienThoaiKHnoSign = TextPhone.Text;
            HotenKHnoSign = txtName.Text;
            // Chuyển đổi giá trị MaTK thành chuỗi
            
            string ma = MaDH;
            ChiNhanh chiNhanh = new ChiNhanh();
            string phuongthucGD = "COD";


            // Lưu giá trị count vào session
            string url = HttpContext.Current.Request.Url.ToString();
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
<<<<<<< HEAD

            try
            {

                if (lstGioHang != null && lstGioHang.Any())
                {
                    var user = from u in dbcontext.KhachHangs
                               select u;

                    var tk = from u in dbcontext.TKs select u;

                    var hadUser = tk.Any(p => p.Email == txtEmailSignUp.Text && (p.MatKhau != null || p.MatKhau != ""));
                    var hadClient = user.Any(p => p.Email == txtEmailSignUp.Text && (p.MatKhau != null || p.MatKhau != ""));
                    var hadClientNonPass = user.Any(s => s.Email == txtEmailSignUp.Text && (s.MatKhau == null || s.MatKhau == ""));


                    if (EmailKhach == null /*&& (!hadUser || !hadClient)*/)
                    {
                        using (var db = new QL_KPOPStoreEntities())
                        {
                            DiaChiNN = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;

                            // Kiểm tra giá trị trước khi thêm vào cơ sở dữ liệu
                            if ((!hadUser && !hadClient && !hadClientNonPass)/*&& !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(TextPhone.Text) && !string.IsNullOrEmpty(txtDiachi.Text) && !string.IsNullOrEmpty(txtEmailSignUp.Text)*/)
                            {
                                var newUser = new TK
                                {
                                    Email = txtEmailSignUp.Text,
                                    MatKhau = null,
                                    TrangThai = false,

                                };

                                var newClient = new KhachHang
                                {
                                    AvatarUser = Shop.defaultAvatar_BlackKS,
                                    HoTen = txtName.Text,
                                    DienThoai = TextPhone.Text,
                                    DiaChi = DiaChiNN,

                                    Email = txtEmailSignUp.Text,
                                    GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
                                    MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
                                    TrangThai = false,
                                    Diem = 0,

                                };

                                //db.TKs.Add(newUser);

                                //db.KhachHangs.Add(newClient);
                                //db.SaveChanges();

                                //try
                                //{
                                db.TKs.Add(newUser);

                                db.KhachHangs.Add(newClient);
                                db.SaveChanges();
                                //db.TKs.Add(newUser);

                                //db.KhachHangs.Add(newClient);
                                //db.SaveChanges();
                                // Tạo một đơn hàng mới
                                string makhno;
                                makhno = newClient.MaKH.ToString();
                                DonHang donHang = new DonHang
                                {
                                    MaDH = ma,
                                    PhuongThuc = phuongthucGD,
                                    HoTenNN = txtName.Text,
                                    DiaChiNN = DiaChiNN,
                                    DienThoaiNN = TextPhone.Text,

                                    KH = newClient.MaKH,
                                    Ngay = DateTime.Now,
                                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
                                };
                                //    donHang.MaDH = ma;
                                ////donHang.MaKH = makh;

                                //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                                //    donHang.KH = kh;

                                //    // Tiếp tục xử lý khác ở đây...

                                //donHang.Ngay = DateTime.Now;
                                //donHang.MaCN = Shop.CH;
                                //donHang.ChiTietDonHangs = lstGioHang;
                                //donHang.MaKH = Account.makh;

                                dbcontext.DonHangs.Add(donHang);

                                string maDonHang = donHang.MaDH;
                                MaDHXNGD = donHang.MaDH;
                                int count = 1;
                                foreach (var item in lstGioHang)
                                {
                                    string mact = maDonHang + count.ToString();

                                    ChiTietDonHang chiTietDon = new ChiTietDonHang
                                    {
                                        KH = donHang.KH,
                                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                        MaCTDH = mact,
                                        MaSP = item.MaSP,
                                        TenSP = item.TenSP,
                                        DuongDan = item.DuongDan,
                                        SoLuong = item.SoLuong,
                                        Gia = item.Gia,
                                        ThanhTien = item.ThanhTien,
                                        TenPob = item.TenPob,
                                    };

                                    //chiTietDon.KH = donHang.KH;
                                    //chiTietDon.MaDH = donHang.MaDH;
                                    //chiTietDon.MaCTDH = mact;
                                    //chiTietDon.MaSP = item.MaSP;
                                    //chiTietDon.TenSP = item.TenSP;
                                    //chiTietDon.DuongDan = item.DuongDan;
                                    //chiTietDon.SoLuong = item.SoLuong;
                                    //chiTietDon.Gia = item.Gia;
                                    //chiTietDon.ThanhTien = item.ThanhTien;
                                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                    double diem = chiTietDon.ThanhTien / 200000;

                                    if (khachmua != null)
                                    {

                                        khachmua.Diem = khachmua.Diem + (int)diem;
                                    }
                                    else
                                    {
                                        var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                        khachHad.Diem = khachHad.Diem + (int)diem;
                                    }
                                    chiTietDon.Ngay = donHang.Ngay;
                                    chiTietDon.GiaoDich = false;
                                    count++;
                                    madh = donHang.MaDH;
                                    dbcontext.ChiTietDonHangs.Add(chiTietDon);

                                }
                                // Thêm thông báo thành công hoặc xử lý kết quả khác
                                //}
                                //catch (Exception ex)
                                //{
                                //    // Xử lý lỗi, ví dụ: hiển thị thông báo lỗi
                                //    Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                                //}
                            }
                            else
                            {
                                var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);

                                DonHang donHang = new DonHang
                                {
                                    MaDH = ma,
                                    PhuongThuc = phuongthucGD,
                                    HoTenNN = txtName.Text,
                                    DiaChiNN = DiaChiNN,
                                    DienThoaiNN = TextPhone.Text,

                                    KH = khachmua.MaKH,
                                    Ngay = DateTime.Now,
                                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
                                };
                                dbcontext.DonHangs.Add(donHang);

                                string maDonHang = donHang.MaDH;
                                MaDHXNGD = donHang.MaDH;
                                int count = 1;
                                foreach (var item in lstGioHang)
                                {
                                    string mact = maDonHang + count.ToString();

                                    ChiTietDonHang chiTietDon = new ChiTietDonHang
                                    {
                                        KH = donHang.KH,
                                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                        MaCTDH = mact,
                                        MaSP = item.MaSP,
                                        TenSP = item.TenSP,
                                        DuongDan = item.DuongDan,
                                        SoLuong = item.SoLuong,
                                        Gia = item.Gia,
                                        ThanhTien = item.ThanhTien,
                                        TenPob = item.TenPob,
                                    };
                                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                                    double diem = chiTietDon.ThanhTien / 200000;
                                    if (khachmua != null)
                                    {

                                        khachmua.Diem = khachmua.Diem + (int)diem;
                                    }
                                    else
                                    {
                                        var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                        khachHad.Diem = khachHad.Diem + (int)diem;
                                    }


                                    chiTietDon.Ngay = donHang.Ngay;
                                    chiTietDon.GiaoDich = false;

                                    count++;
                                    madh = donHang.MaDH;
                                    dbcontext.ChiTietDonHangs.Add(chiTietDon);

                                }
                            }
                        }

                    }
                    else if (hadUser && hadClient && !hadClientNonPass)
                    {
                        DiaChiNN = txtDiachi.Text;
                        DiaChitxt = txtDiachi.Text;
                        var khach = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);

                        if (EmailKhach != null && user.Any(p => p.Email == EmailKhach))
                        {
                            // Tạo một đơn hàng mới
=======
            if (lstGioHang != null && lstGioHang.Any())
            {
                var user = from u in dbcontext.KhachHangs
                           select u;

                var tk = from u in dbcontext.TKs select u;

                var hadUser = tk.Any(p => p.Email == txtEmailSignUp.Text && (p.MatKhau != null || p.MatKhau != ""));
                var hadClient = user.Any(p => p.Email == txtEmailSignUp.Text && (p.MatKhau != null || p.MatKhau != ""));
                var hadClientNonPass = user.Any(s => s.Email == txtEmailSignUp.Text && (s.MatKhau == null || s.MatKhau == ""));


                if (EmailKhach == null /*&& (!hadUser || !hadClient)*/)
                {
                    using (var db = new QL_KPOPStoreEntities())
                    {
                        DiaChiNN = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;

                        // Kiểm tra giá trị trước khi thêm vào cơ sở dữ liệu
                        if ((!hadUser && !hadClient && !hadClientNonPass)/*&& !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(TextPhone.Text) && !string.IsNullOrEmpty(txtDiachi.Text) && !string.IsNullOrEmpty(txtEmailSignUp.Text)*/)
                        {
                            var newUser = new TK
                            {
                                Email = txtEmailSignUp.Text,
                                MatKhau = null,
                                TrangThai = false,

                            };

                            var newClient = new KhachHang
                            {
                                AvatarUser = Shop.defaultAvatar_BlackKS,
                                HoTen = txtName.Text,
                                DienThoai = TextPhone.Text,
                                DiaChi = DiaChiNN,

                                Email = txtEmailSignUp.Text,
                                GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
                                MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
                                TrangThai = false,
                                Diem = 0,

                            };

                            //db.TKs.Add(newUser);

                            //db.KhachHangs.Add(newClient);
                            //db.SaveChanges();

                            //try
                            //{
                            db.TKs.Add(newUser);

                            db.KhachHangs.Add(newClient);
                            db.SaveChanges();
                            //db.TKs.Add(newUser);

                            //db.KhachHangs.Add(newClient);
                            //db.SaveChanges();
                            // Tạo một đơn hàng mới
                            string makhno;
                            makhno = newClient.MaKH.ToString();
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                            DonHang donHang = new DonHang
                            {
                                MaDH = ma,
                                PhuongThuc = phuongthucGD,
                                HoTenNN = txtName.Text,
                                DiaChiNN = DiaChiNN,
                                DienThoaiNN = TextPhone.Text,

<<<<<<< HEAD
                                KH = makh,
=======
                                KH = newClient.MaKH,
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                                Ngay = DateTime.Now,
                                MaCN = Shop.CH // Shop.CH là mã chi nhánh
                            };
                            //    donHang.MaDH = ma;
                            ////donHang.MaKH = makh;

                            //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                            //    donHang.KH = kh;

                            //    // Tiếp tục xử lý khác ở đây...

                            //donHang.Ngay = DateTime.Now;
                            //donHang.MaCN = Shop.CH;
                            //donHang.ChiTietDonHangs = lstGioHang;
                            //donHang.MaKH = Account.makh;

                            dbcontext.DonHangs.Add(donHang);

                            string maDonHang = donHang.MaDH;
                            MaDHXNGD = donHang.MaDH;
                            int count = 1;
                            foreach (var item in lstGioHang)
                            {
                                string mact = maDonHang + count.ToString();

                                ChiTietDonHang chiTietDon = new ChiTietDonHang
                                {
                                    KH = donHang.KH,
                                    MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                    MaCTDH = mact,
                                    MaSP = item.MaSP,
                                    TenSP = item.TenSP,
                                    DuongDan = item.DuongDan,
                                    SoLuong = item.SoLuong,
                                    Gia = item.Gia,
                                    ThanhTien = item.ThanhTien,
                                    TenPob = item.TenPob,
                                };

                                //chiTietDon.KH = donHang.KH;
                                //chiTietDon.MaDH = donHang.MaDH;
                                //chiTietDon.MaCTDH = mact;
                                //chiTietDon.MaSP = item.MaSP;
                                //chiTietDon.TenSP = item.TenSP;
                                //chiTietDon.DuongDan = item.DuongDan;
                                //chiTietDon.SoLuong = item.SoLuong;
                                //chiTietDon.Gia = item.Gia;
                                //chiTietDon.ThanhTien = item.ThanhTien;
                                var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
<<<<<<< HEAD
                                sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                                var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
=======
                                sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                double diem = chiTietDon.ThanhTien / 200000;

                                if (khachmua != null)
                                {

                                    khachmua.Diem = khachmua.Diem + (int)diem;
                                }
                                else
                                {
                                    var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                    khachHad.Diem = khachHad.Diem + (int)diem;
                                }
                                chiTietDon.Ngay = donHang.Ngay;
                                chiTietDon.GiaoDich = false;
                                count++;
                                madh = donHang.MaDH;
                                dbcontext.ChiTietDonHangs.Add(chiTietDon);

                            }
                            // Thêm thông báo thành công hoặc xử lý kết quả khác
                            //}
                            //catch (Exception ex)
                            //{
                            //    // Xử lý lỗi, ví dụ: hiển thị thông báo lỗi
                            //    Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                            //}
                        }
                        else
                        {
                            var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text && p.DienThoai == TextPhone.Text);

                            DonHang donHang = new DonHang
                            {
                                MaDH = ma,
                                PhuongThuc = phuongthucGD,
                                HoTenNN = txtName.Text,
                                DiaChiNN = DiaChiNN,
                                DienThoaiNN = TextPhone.Text,

                                KH = khachmua.MaKH,
                                Ngay = DateTime.Now,
                                MaCN = Shop.CH // Shop.CH là mã chi nhánh
                            };
                            dbcontext.DonHangs.Add(donHang);

                            string maDonHang = donHang.MaDH;
                            MaDHXNGD = donHang.MaDH;
                            int count = 1;
                            foreach (var item in lstGioHang)
                            {
                                string mact = maDonHang + count.ToString();

                                ChiTietDonHang chiTietDon = new ChiTietDonHang
                                {
                                    KH = donHang.KH,
                                    MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                    MaCTDH = mact,
                                    MaSP = item.MaSP,
                                    TenSP = item.TenSP,
                                    DuongDan = item.DuongDan,
                                    SoLuong = item.SoLuong,
                                    Gia = item.Gia,
                                    ThanhTien = item.ThanhTien,
                                    TenPob = item.TenPob,
                                };
                                var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                                double diem = chiTietDon.ThanhTien / 200000;
                                if (khachmua != null)
                                {

                                    khachmua.Diem = khachmua.Diem + (int)diem;
                                }
                                else
                                {
                                    var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                    khachHad.Diem = khachHad.Diem + (int)diem;
                                }


                                chiTietDon.Ngay = donHang.Ngay;
                                chiTietDon.GiaoDich = false;

                                count++;
                                madh = donHang.MaDH;
                                dbcontext.ChiTietDonHangs.Add(chiTietDon);

                            }
                        }
<<<<<<< HEAD
                        else
=======
                    }

                }
                else if (hadUser && hadClient && !hadClientNonPass)
                {
                    DiaChiNN = txtDiachi.Text;
                    DiaChitxt = txtDiachi.Text;
                    var khach = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);

                    if (EmailKhach != null && user.Any(p => p.Email == EmailKhach))
                    {
                        // Tạo một đơn hàng mới
                        DonHang donHang = new DonHang
                        {
                            MaDH = ma,
                            PhuongThuc = phuongthucGD,
                            HoTenNN = txtName.Text,
                            DiaChiNN = DiaChiNN,
                            DienThoaiNN = TextPhone.Text,

                            KH = makh,
                            Ngay = DateTime.Now,
                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
                        };
                        //    donHang.MaDH = ma;
                        ////donHang.MaKH = makh;

                        //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                        //    donHang.KH = kh;

                        //    // Tiếp tục xử lý khác ở đây...

                        //donHang.Ngay = DateTime.Now;
                        //donHang.MaCN = Shop.CH;
                        //donHang.ChiTietDonHangs = lstGioHang;
                        //donHang.MaKH = Account.makh;

                        dbcontext.DonHangs.Add(donHang);

                        string maDonHang = donHang.MaDH;
                        MaDHXNGD = donHang.MaDH;
                        int count = 1;
                        foreach (var item in lstGioHang)
                        {
                            string mact = maDonHang + count.ToString();

                            ChiTietDonHang chiTietDon = new ChiTietDonHang
                            {
                                KH = donHang.KH,
                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                MaCTDH = mact,
                                MaSP = item.MaSP,
                                TenSP = item.TenSP,
                                DuongDan = item.DuongDan,
                                SoLuong = item.SoLuong,
                                Gia = item.Gia,
                                ThanhTien = item.ThanhTien,
                                TenPob = item.TenPob,
                            };

                            //chiTietDon.KH = donHang.KH;
                            //chiTietDon.MaDH = donHang.MaDH;
                            //chiTietDon.MaCTDH = mact;
                            //chiTietDon.MaSP = item.MaSP;
                            //chiTietDon.TenSP = item.TenSP;
                            //chiTietDon.DuongDan = item.DuongDan;
                            //chiTietDon.SoLuong = item.SoLuong;
                            //chiTietDon.Gia = item.Gia;
                            //chiTietDon.ThanhTien = item.ThanhTien;
                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                            var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                            double diem = chiTietDon.ThanhTien / 200000;
                            if (khachmua != null)
                            {

                                khachmua.Diem = khachmua.Diem + (int)diem;
                            }
                            else
                            {
                                var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                khachHad.Diem = khachHad.Diem + (int)diem;
                            }


                            chiTietDon.Ngay = donHang.Ngay;
                            chiTietDon.GiaoDich = false;

                            count++;
                            madh = donHang.MaDH;
                            dbcontext.ChiTietDonHangs.Add(chiTietDon);

                        }
                    }
                    else
                    {
                        var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                        string khHadMaKH = khHad.MaKH.ToString();
                        // Tạo một đơn hàng mới
                        DonHang donHang = new DonHang
                        {
                            MaDH = ma,
                            PhuongThuc = phuongthucGD,
                            HoTenNN = txtName.Text,
                            DiaChiNN = DiaChiNN,
                            DienThoaiNN = TextPhone.Text,

                            KH = khHad.MaKH,
                            Ngay = DateTime.Now,
                            MaCN = Shop.CH // Shop.CH là mã chi nhánh
                        };
                        //    donHang.MaDH = ma;
                        ////donHang.MaKH = makh;

                        //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                        //    donHang.KH = kh;

                        //    // Tiếp tục xử lý khác ở đây...

                        //donHang.Ngay = DateTime.Now;
                        //donHang.MaCN = Shop.CH;
                        //donHang.ChiTietDonHangs = lstGioHang;
                        //donHang.MaKH = Account.makh;

                        dbcontext.DonHangs.Add(donHang);

                        string maDonHang = donHang.MaDH;
                        MaDHXNGD = donHang.MaDH;
                        int count = 1;
                        foreach (var item in lstGioHang)
                        {
                            string mact = maDonHang + count.ToString();

                            ChiTietDonHang chiTietDon = new ChiTietDonHang
                            {
                                KH = donHang.KH,
                                MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                MaCTDH = mact,
                                MaSP = item.MaSP,
                                TenSP = item.TenSP,
                                DuongDan = item.DuongDan,
                                SoLuong = item.SoLuong,
                                Gia = item.Gia,
                                ThanhTien = item.ThanhTien,
                                TenPob = item.TenPob,
                            };

                            //chiTietDon.KH = donHang.KH;
                            //chiTietDon.MaDH = donHang.MaDH;
                            //chiTietDon.MaCTDH = mact;
                            //chiTietDon.MaSP = item.MaSP;
                            //chiTietDon.TenSP = item.TenSP;
                            //chiTietDon.DuongDan = item.DuongDan;
                            //chiTietDon.SoLuong = item.SoLuong;
                            //chiTietDon.Gia = item.Gia;
                            //chiTietDon.ThanhTien = item.ThanhTien;
                            var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                            sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                            var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                            double diem = chiTietDon.ThanhTien / 200000;

                            if (khHad.Diem != null)
                                khHad.Diem = khHad.Diem + (int)diem;
                            else
                            {
                                khHad.Diem = 0;
                                khHad.Diem = khHad.Diem + (int)diem;

                            }



                            chiTietDon.Ngay = donHang.Ngay;
                            chiTietDon.GiaoDich = false;

                            count++;
                            madh = donHang.MaDH;
                            dbcontext.ChiTietDonHangs.Add(chiTietDon);

                        }
                    }
                }
                else
                {
                    using (var db = new QL_KPOPStoreEntities())
                    {

                        if (hadClientNonPass)
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                        {
                            var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                            string khHadMaKH = khHad.MaKH.ToString();
                            // Tạo một đơn hàng mới
                            DonHang donHang = new DonHang
                            {
                                MaDH = ma,
                                PhuongThuc = phuongthucGD,
                                HoTenNN = txtName.Text,
                                DiaChiNN = DiaChiNN,
                                DienThoaiNN = TextPhone.Text,

                                KH = khHad.MaKH,
                                Ngay = DateTime.Now,
                                MaCN = Shop.CH // Shop.CH là mã chi nhánh
                            };
                            //    donHang.MaDH = ma;
                            ////donHang.MaKH = makh;

                            //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                            //    donHang.KH = kh;

                            //    // Tiếp tục xử lý khác ở đây...

                            //donHang.Ngay = DateTime.Now;
                            //donHang.MaCN = Shop.CH;
                            //donHang.ChiTietDonHangs = lstGioHang;
                            //donHang.MaKH = Account.makh;

                            dbcontext.DonHangs.Add(donHang);

                            string maDonHang = donHang.MaDH;
                            MaDHXNGD = donHang.MaDH;
                            int count = 1;
                            foreach (var item in lstGioHang)
                            {
                                string mact = maDonHang + count.ToString();

                                ChiTietDonHang chiTietDon = new ChiTietDonHang
                                {
                                    KH = donHang.KH,
                                    MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                    MaCTDH = mact,
                                    MaSP = item.MaSP,
                                    TenSP = item.TenSP,
                                    DuongDan = item.DuongDan,
                                    SoLuong = item.SoLuong,
                                    Gia = item.Gia,
                                    ThanhTien = item.ThanhTien,
                                    TenPob = item.TenPob,
                                };

<<<<<<< HEAD
                                //chiTietDon.KH = donHang.KH;
                                //chiTietDon.MaDH = donHang.MaDH;
                                //chiTietDon.MaCTDH = mact;
                                //chiTietDon.MaSP = item.MaSP;
                                //chiTietDon.TenSP = item.TenSP;
                                //chiTietDon.DuongDan = item.DuongDan;
                                //chiTietDon.SoLuong = item.SoLuong;
                                //chiTietDon.Gia = item.Gia;
                                //chiTietDon.ThanhTien = item.ThanhTien;
=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                                var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                                var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                double diem = chiTietDon.ThanhTien / 200000;

                                if (khHad.Diem != null)
                                    khHad.Diem = khHad.Diem + (int)diem;
                                else
                                {
                                    khHad.Diem = 0;
                                    khHad.Diem = khHad.Diem + (int)diem;

                                }



                                chiTietDon.Ngay = donHang.Ngay;
                                chiTietDon.GiaoDich = false;

                                count++;
                                madh = donHang.MaDH;
                                dbcontext.ChiTietDonHangs.Add(chiTietDon);

                            }
                        }
<<<<<<< HEAD
                    }
                    else
                    {
                        using (var db = new QL_KPOPStoreEntities())
                        {

                            if (hadClientNonPass)
                            {
                                var khHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                string khHadMaKH = khHad.MaKH.ToString();
                                // Tạo một đơn hàng mới
                                DonHang donHang = new DonHang
                                {
                                    MaDH = ma,
                                    PhuongThuc = phuongthucGD,
                                    HoTenNN = txtName.Text,
                                    DiaChiNN = DiaChiNN,
                                    DienThoaiNN = TextPhone.Text,

                                    KH = khHad.MaKH,
                                    Ngay = DateTime.Now,
                                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
                                };
                                //    donHang.MaDH = ma;
                                ////donHang.MaKH = makh;

                                //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                                //    donHang.KH = kh;

                                //    // Tiếp tục xử lý khác ở đây...

                                //donHang.Ngay = DateTime.Now;
                                //donHang.MaCN = Shop.CH;
                                //donHang.ChiTietDonHangs = lstGioHang;
                                //donHang.MaKH = Account.makh;

                                dbcontext.DonHangs.Add(donHang);

                                string maDonHang = donHang.MaDH;
                                MaDHXNGD = donHang.MaDH;
                                int count = 1;
                                foreach (var item in lstGioHang)
                                {
                                    string mact = maDonHang + count.ToString();

                                    ChiTietDonHang chiTietDon = new ChiTietDonHang
                                    {
                                        KH = donHang.KH,
                                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                        MaCTDH = mact,
                                        MaSP = item.MaSP,
                                        TenSP = item.TenSP,
                                        DuongDan = item.DuongDan,
                                        SoLuong = item.SoLuong,
                                        Gia = item.Gia,
                                        ThanhTien = item.ThanhTien,
                                        TenPob = item.TenPob,
                                    };

                                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong;
                                    var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                    double diem = chiTietDon.ThanhTien / 200000;

                                    if (khHad.Diem != null)
                                        khHad.Diem = khHad.Diem + (int)diem;
                                    else
                                    {
                                        khHad.Diem = 0;
                                        khHad.Diem = khHad.Diem + (int)diem;

                                    }



                                    chiTietDon.Ngay = donHang.Ngay;
                                    chiTietDon.GiaoDich = false;

                                    count++;
                                    madh = donHang.MaDH;
                                    dbcontext.ChiTietDonHangs.Add(chiTietDon);

                                }
                            }

                            else
                            {

                                var newUser = new TK
                                {
                                    Email = txtEmailSignUp.Text,
                                    MatKhau = null,
                                    TrangThai = false,

                                };

                                var newClient = new KhachHang
                                {
                                    AvatarUser = Shop.defaultAvatar_BlackKS,
                                    HoTen = txtName.Text,
                                    DienThoai = TextPhone.Text,
                                    DiaChi = DiaChiNN,

                                    Email = txtEmailSignUp.Text,
                                    GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
                                    MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
                                    TrangThai = false,
                                    Diem = 0,

                                };

                                //db.TKs.Add(newUser);

                                //db.KhachHangs.Add(newClient);
                                //db.SaveChanges();

                                //try
                                //{
                                db.TKs.Add(newUser);

                                db.KhachHangs.Add(newClient);
                                db.SaveChanges();
                                //db.TKs.Add(newUser);

                                //db.KhachHangs.Add(newClient);
                                //db.SaveChanges();
                                // Tạo một đơn hàng mới
                                string makhno;
                                makhno = newClient.MaKH.ToString();
                                DonHang donHang = new DonHang
                                {
                                    MaDH = ma,
                                    PhuongThuc = phuongthucGD,
                                    HoTenNN = txtName.Text,
                                    DiaChiNN = DiaChiNN,
                                    DienThoaiNN = TextPhone.Text,

                                    KH = newClient.MaKH,
                                    Ngay = DateTime.Now,
                                    MaCN = Shop.CH // Shop.CH là mã chi nhánh
                                };
                                //    donHang.MaDH = ma;
                                ////donHang.MaKH = makh;

                                //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                                //    donHang.KH = kh;

                                //    // Tiếp tục xử lý khác ở đây...

                                //donHang.Ngay = DateTime.Now;
                                //donHang.MaCN = Shop.CH;
                                //donHang.ChiTietDonHangs = lstGioHang;
                                //donHang.MaKH = Account.makh;

                                dbcontext.DonHangs.Add(donHang);

                                string maDonHang = donHang.MaDH;
                                MaDHXNGD = donHang.MaDH;
                                int count = 1;
                                foreach (var item in lstGioHang)
                                {
                                    string mact = maDonHang + count.ToString();

                                    ChiTietDonHang chiTietDon = new ChiTietDonHang
                                    {
                                        KH = donHang.KH,
                                        MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                        MaCTDH = mact,
                                        MaSP = item.MaSP,
                                        TenSP = item.TenSP,
                                        DuongDan = item.DuongDan,
                                        SoLuong = item.SoLuong,
                                        Gia = item.Gia,
                                        ThanhTien = item.ThanhTien,
                                        TenPob = item.TenPob,
                                    };

                                    //chiTietDon.KH = donHang.KH;
                                    //chiTietDon.MaDH = donHang.MaDH;
                                    //chiTietDon.MaCTDH = mact;
                                    //chiTietDon.MaSP = item.MaSP;
                                    //chiTietDon.TenSP = item.TenSP;
                                    //chiTietDon.DuongDan = item.DuongDan;
                                    //chiTietDon.SoLuong = item.SoLuong;
                                    //chiTietDon.Gia = item.Gia;
                                    //chiTietDon.ThanhTien = item.ThanhTien;
                                    var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                    sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                    double diem = chiTietDon.ThanhTien / 200000;

                                    if (khachmua != null)
                                    {

                                        khachmua.Diem = khachmua.Diem + (int)diem;
                                    }
                                    else
                                    {
                                        var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                        khachHad.Diem = khachHad.Diem + (int)diem;
                                    }
                                    chiTietDon.Ngay = donHang.Ngay;
                                    chiTietDon.GiaoDich = false;
                                    count++;
                                    madh = donHang.MaDH;
                                    dbcontext.ChiTietDonHangs.Add(chiTietDon);

                                }
                            }
                        }

                    }



                }

                dbcontext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Lỗi " + ex.InnerException.Message + ".</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");
                Thread.Sleep(3500);


                Response.Redirect("Error/PaymentFailed");
            }

=======

                        else
                        {

                            var newUser = new TK
                            {
                                Email = txtEmailSignUp.Text,
                                MatKhau = null,
                                TrangThai = false,

                            };

                            var newClient = new KhachHang
                            {
                                AvatarUser = Shop.defaultAvatar_BlackKS,
                                HoTen = txtName.Text,
                                DienThoai = TextPhone.Text,
                                DiaChi = DiaChiNN,

                                Email = txtEmailSignUp.Text,
                                GioiTinh = null, // Kiểm tra và đặt giá trị hợp lệ
                                MatKhau = null, // Kiểm tra và đặt giá trị hợp lệ
                                TrangThai = false,
                                Diem = 0,

                            };

                            //db.TKs.Add(newUser);

                            //db.KhachHangs.Add(newClient);
                            //db.SaveChanges();

                            //try
                            //{
                            db.TKs.Add(newUser);

                            db.KhachHangs.Add(newClient);
                            db.SaveChanges();
                            //db.TKs.Add(newUser);

                            //db.KhachHangs.Add(newClient);
                            //db.SaveChanges();
                            // Tạo một đơn hàng mới
                            string makhno;
                            makhno = newClient.MaKH.ToString();
                            DonHang donHang = new DonHang
                            {
                                MaDH = ma,
                                PhuongThuc = phuongthucGD,
                                HoTenNN = txtName.Text,
                                DiaChiNN = DiaChiNN,
                                DienThoaiNN = TextPhone.Text,

                                KH = newClient.MaKH,
                                Ngay = DateTime.Now,
                                MaCN = Shop.CH // Shop.CH là mã chi nhánh
                            };
                            //    donHang.MaDH = ma;
                            ////donHang.MaKH = makh;

                            //    // Gán giá trị MaTK cho trường KH của đối tượng DonHang
                            //    donHang.KH = kh;

                            //    // Tiếp tục xử lý khác ở đây...

                            //donHang.Ngay = DateTime.Now;
                            //donHang.MaCN = Shop.CH;
                            //donHang.ChiTietDonHangs = lstGioHang;
                            //donHang.MaKH = Account.makh;

                            dbcontext.DonHangs.Add(donHang);

                            string maDonHang = donHang.MaDH;
                            MaDHXNGD = donHang.MaDH;
                            int count = 1;
                            foreach (var item in lstGioHang)
                            {
                                string mact = maDonHang + count.ToString();

                                ChiTietDonHang chiTietDon = new ChiTietDonHang
                                {
                                    KH = donHang.KH,
                                    MaDH = donHang.MaDH, // Sử dụng mã đơn hàng mới tạo
                                    MaCTDH = mact,
                                    MaSP = item.MaSP,
                                    TenSP = item.TenSP,
                                    DuongDan = item.DuongDan,
                                    SoLuong = item.SoLuong,
                                    Gia = item.Gia,
                                    ThanhTien = item.ThanhTien,
                                    TenPob = item.TenPob,
                                };

                                //chiTietDon.KH = donHang.KH;
                                //chiTietDon.MaDH = donHang.MaDH;
                                //chiTietDon.MaCTDH = mact;
                                //chiTietDon.MaSP = item.MaSP;
                                //chiTietDon.TenSP = item.TenSP;
                                //chiTietDon.DuongDan = item.DuongDan;
                                //chiTietDon.SoLuong = item.SoLuong;
                                //chiTietDon.Gia = item.Gia;
                                //chiTietDon.ThanhTien = item.ThanhTien;
                                var sanpham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == chiTietDon.MaSP);
                                sanpham.SoLuongKho -= chiTietDon.SoLuong; sanpham.DoanhSo += chiTietDon.SoLuong; var khachmua = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == makh);
                                double diem = chiTietDon.ThanhTien / 200000;

                                if (khachmua != null)
                                {

                                    khachmua.Diem = khachmua.Diem + (int)diem;
                                }
                                else
                                {
                                    var khachHad = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text);
                                    khachHad.Diem = khachHad.Diem + (int)diem;
                                }
                                chiTietDon.Ngay = donHang.Ngay;
                                chiTietDon.GiaoDich = false;
                                count++;
                                madh = donHang.MaDH;
                                dbcontext.ChiTietDonHangs.Add(chiTietDon);

                            }
                        }
                    }

                }


            }

            dbcontext.SaveChanges();
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //MaDHXNGD = null;

            if (string.IsNullOrEmpty(txtEmailSignUp.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtDiachi.Text) ||
                string.IsNullOrEmpty(TextPhone.Text) ||
                string.IsNullOrEmpty(ddlCity.Text) ||
                string.IsNullOrEmpty(ddlDistrict.Text) ||
                string.IsNullOrEmpty(ddlW.Text)){
                // Hiển thị thông báo lỗi
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Vui lòng điền đầy đủ thông tin');", true);
                return;
            }
             Amount = TH03_WebBanHang.Pay.TongThanhTien.ToString();
            int makh = GetMaTKFromSomeSource(); // Giả định rằng bạn đã có phương thức này để lấy giá trị MaTK
            emailKHnoSign = txtEmailSignUp.Text;
            DiaChiKHnoSign = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;
            DiaChiNN = DiaChiKHnoSign;
            DienThoaiKHnoSign =TextPhone.Text;
            HotenKHnoSign=txtName.Text;
            // Chuyển đổi giá trị MaTK thành chuỗi

            string kh = makh.ToString();
            ChiNhanh chiNhanh = new ChiNhanh();
          


            // Lưu giá trị count vào session
            string url = HttpContext.Current.Request.Url.ToString();
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            //DonHang donHang = new DonHang();
            switch (ddlPay.SelectedValue)
            {
                case "TM":
                    string ma = GenerateRandomString(6);
                    CreateTheOrder(ma, kh, makh);
                    var donhang = dbcontext.DonHangs.Any(s=>s.MaDH==ma);
                    var don = dbcontext.DonHangs.FirstOrDefault(s => s.MaDH == ma);
                    if (donhang) {
                   
                   
                        lstGioHang.Clear();
                        Session["GioHang"] = lstGioHang;
                        //Response.Redirect("OrderNotification.aspx?GD=TM");
                        Response.Redirect("checkOutOrder/OutOrder?MaDH=" + don.MaDH);

                        //var hadDon = dbcontext.DonHangs.Any(s => s.MaDH == MaDHXNGD);
                        //var donhang = dbcontext.DonHangs.FirstOrDefault(s => s.MaDH == MaDHXNGD);
                        //if (hadDon)
                        //    Response.Redirect("checkOutOrder/checkOut?MaDH=" + donhang.MaDH + "&Amount=" + TongThanhTien + "GD=TMCOD");
                        //else
                        //{
                        //    //Response.Redirect("OrderNotification.aspx?GD=TM");
                        //    Response.Redirect("Error/PaymentFailed");
                        //}

                    }
                    else
                    {
                        Response.Redirect("Error/PaymentFailed");
                    }
                    break;              
                case "MOMO":                
                    if (Session["Email"] != null)
                    {
                        DiaChiNN = txtDiachi.Text;
                    }
                    string MomoToOrder = Shop.localhost + "Momo/Momo_return";
                    Momo(Amount, MomoToOrder);
                    break;
                case "VNPAY":






                    if (Session["Email"] != null)
                    {
                        DiaChiNN = txtDiachi.Text;
                    }



                    //Get Config Info
                    string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
                    string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
                    string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma định danh merchant kết nối (Terminal Id)
                    string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Secret Key

                    //Get payment input
                    OrderInfo order = new OrderInfo();
                    order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
                    order.Amount = TH03_WebBanHang.Pay.TongThanhTien; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
                    order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
                    order.CreatedDate = DateTime.Now;
                    //Save order to db

                    //Build URL for VNPAY
                    VnPayLibrary vnpay = new VnPayLibrary();

                    vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
                    vnpay.AddRequestData("vnp_Command", "pay");
                    vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                    vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
                    if (/*bankcode_Vnpayqr.Checked == true || */ddlPay.SelectedValue == "appVNPAYQR")
                    {
                        vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
                    }
                    if (/*bankcode_Vnbank.Checked == true*/ ddlPay.SelectedValue == "atnVNBank")
                    {
                        vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                    }
                    if (/*bankcode_Intcard.Checked == true*/ ddlPay.SelectedValue == "intVNPay")
                    {
                        vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                    }
                    //if (ddlPaymentVNPaySelect.SelectedValue == "VNPAYQR")
                    //{
                    //    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                    //}
                    vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
                    vnpay.AddRequestData("vnp_CurrCode", "VND");
                    vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
                    vnpay.AddRequestData("vnp_Locale", "vn");
                    //if (locale_Vn.Checked == true)
                    //{
                    //    vnpay.AddRequestData("vnp_Locale", "vn");
                    //}
                    //else if (locale_En.Checked == true)
                    //{
                    //    vnpay.AddRequestData("vnp_Locale", "en");
                    //}
                    vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + TH03_WebBanHang.Pay.MaDHXNGD);
                    vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

                    vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
                    vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

                    //Add Params of 2.1.0 Version
                    //Billing

                    string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                    log.InfoFormat("VNPAY URL: {0}", paymentUrl);
                    Response.Redirect(paymentUrl);
                    break;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart");
        }
    }
}
