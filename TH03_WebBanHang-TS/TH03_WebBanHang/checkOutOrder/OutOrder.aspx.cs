using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang.checkOutOrder
{
    public partial class OutOrder : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

        public IQueryable<TH03_WebBanHang.Models.ChiTietDonHang> GetListItemsInOrder()
        {
            string maDH = HttpContext.Current.Request.QueryString.Get("MaDH");

            //var chitietDon = dbcontext.ChiTietDonHangs.FirstOrDefault(s=>s.MaDH== MaDHXNGD);
            IQueryable<ChiTietDonHang> lsItems = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == checkOut.mdh|| s.MaDH== maDH);

            return lsItems;

        }
        public void SendEmail(string to, string subject, string body, string imagePath)
        {
            string maDHang = HttpContext.Current.Request.QueryString.Get("MaDH");
            ChiTietDonHang maDH = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == checkOut.mdh || p.MaDH== maDHang);

            ChiTietDonHang maCT = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == maDH.MaDH);
            try
            {
                // Tạo một đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential(Shop.gmailAccount, Shop.gmailPass),
                    EnableSsl = true
                };

                // Tạo một đối tượng MailMessage
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Shop.gmailAccount);
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.Subject = subject;

                // Thêm hình ảnh vào email
                LinkedResource inline = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
                inline.ContentId = Guid.NewGuid().ToString(); // Đặt ContentId để tham chiếu đến hình ảnh trong HTML
                string styleColor;
                if (maDH.GiaoDich == true)
                {
                    styleColor = "<p>Giao dịch: <span style=\"color: green;\">Đã Thanh Toán</span></p>";
                }
                else styleColor = "<p>Giao dịch: <span style=\"color: red;\">Đợi Thanh Toán</span></p>";
                // Tạo nội dung HTML tùy chỉnh
                string htmlBody = $"<html><body><img style=\"max-width: 100%; border-radius:20px;\" src='cid:{inline.ContentId}' alt='KStore' /><h1>Thông báo đơn hàng!</h1><p>Xin chào bạn đây là thông báo về đơn hàng với giá trị là {Pay.TongForMail}<p>Đơn hàng có mã <strong>{body}</strong> đã được chúng tôi xác nhận.{styleColor}<p>Vào lúc: {maDH.Ngay}</p></p><p>Cảm ơn vì bạn đã mua hàng.</p></body></html>";

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                avHtml.LinkedResources.Add(inline);
                mailMessage.AlternateViews.Add(avHtml);

                // Gửi email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Đã gửi email.");
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Chúng tôi đã gửi thông tin đến mail của bạn, vui lòng kiểm tra.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Lỗi khi gửi email: " + ex.Message + ".</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            string maDH = HttpContext.Current.Request.QueryString.Get("MaDH");

            var don = dbcontext.ChiTietDonHangs.FirstOrDefault(s => s.MaDH == maDH);
            var khachhang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == don.DonHang.KhachHang.Email);
            var list = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == maDH).ToList();

            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            Hepler hepler = new Hepler();

            displayOrderCode.InnerText = don.MaDH;
            displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
            txtPTGD.InnerText = don.DonHang.PhuongThuc;



            //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
            //Response.Redirect("../Pay");
            //displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
            //displayTmnCode.InnerText = TerminalID;
            displayTxnRef.InnerText = don.MaDH;
            //displayVnpayTranNo.InnerText = vnpayTranId.ToString();
            displayAmount.InnerText = string.Format("{0:N0}", list.Sum(s => s.ThanhTien)) + "đ";
            //displayBankCode.InnerText = bankCode;
            displayOrderCode.InnerText = don.MaDH;
            displayDateCreate.InnerText = don.Ngay.ToString();
            displayBranhLocate.InnerText = don.DonHang.ChiNhanh.TenCN;
            displayClientLocate.InnerText = don.DonHang.DiaChiNN;
            displayClientName.InnerText = don.DonHang.HoTenNN;
            displayClientPhone.InnerText = don.DonHang.DienThoaiNN;
            txtEmailNN.InnerText = don.DonHang.KhachHang.Email;
            if (don.GiaoDich == true)
            {
                txtGiaoDich.Style.Add(HtmlTextWriterStyle.Color, "green");
                txtGiaoDich.InnerText = "Đã thanh toán thành công";
            }
            else
            {
                txtGiaoDich.Style.Add(HtmlTextWriterStyle.Color, "orangered");

                txtGiaoDich.InnerText = "Đang đợi thanh toán";
            }

            if (don != null)
            {
                lstGioHang.Clear();
                Session["GioHang"] = lstGioHang;

                Session["MailMD"] = don.MaDH;
                string email = Sign.email;

                var db = new QL_KPOPStoreEntities();
                var user = db.TKs.FirstOrDefault(u => u.Email == checkOut.mail || u.Email == email || u.Email==Pay.emailKHnoSign);
                string imagePath = Server.MapPath("../" + Shop.logoForMail_BlackKS);




                //System.Threading.Thread.Sleep(5000);

                //if (user != null) SendEmail(user.Email, "KStore", don.MaDH, imagePath);
                //else SendEmail(khachhang.Email, "KStore", don.MaDH, imagePath);

                //SendEmail(khachhang.Email, "KStore", don.MaDH, imagePath);

                try
                {
                    SendEmail(user.Email, "KStore", don.MaDH, imagePath);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Lỗi khi gửi email: " + ex.Message + ".</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");
                }


            }

        }
    }
}