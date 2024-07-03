using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.checkOutOrder;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class DetailOrder : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

        public IQueryable<TH03_WebBanHang.Models.ChiTietDonHang> GetListItemsInOrder()
        {
            string maDH = HttpContext.Current.Request.QueryString.Get("MaDH");

            //var chitietDon = dbcontext.ChiTietDonHangs.FirstOrDefault(s=>s.MaDH== MaDHXNGD);
            IQueryable<ChiTietDonHang> lsItems = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == checkOut.mdh || s.MaDH == maDH);

            return lsItems;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string maDH = HttpContext.Current.Request.QueryString.Get("MaDH");

            var don = dbcontext.ChiTietDonHangs.FirstOrDefault(s => s.MaDH == maDH);
            var khachhang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == don.DonHang.KhachHang.Email);
            var list = dbcontext.ChiTietDonHangs.Where(s => s.MaDH == maDH).ToList();

            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            var user = from u in dbcontext.TKs
                       select u;
            if (user.Any(p => (p.Email == "Admin" && p.TrangThai == true && p.Email == EmailKhach && EmailKhach == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.TrangThai == true && p.Email == EmailKhach)))
            {
                btnDel.Visible = true;
                if(don.GiaoDich !=true)
                    btDone.Visible = true;
                else btDone.Visible = false;

            }
            else
            {
                btnDel.Visible = false;
                btDone.Visible = false;
                btnDel.Enabled = false;
                btDone.Enabled = false;
            }




            

            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            Hepler hepler = new Hepler();

            displayOrderCode.InnerText = don.MaDH;
            displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";




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


            txtPTGD.InnerText = don.DonHang.PhuongThuc;


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



        }


        protected void btDel_Click(object sender, EventArgs e)
        {

            string don = HttpContext.Current.Request.QueryString.Get("MaDH");


            DonHang chitet = dbcontext.DonHangs.FirstOrDefault(p => p.MaDH == don);
            ChiTietDonHang chitietDon = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == don);

            if (chitet != null)
            {
                try
                {
                    // Retrieve and delete all related ChiTietDonHang records
                    var relatedChiTietDonHangs = dbcontext.ChiTietDonHangs.Where(p => p.MaDH == don).ToList();
                    foreach (var chiTietDonHang in relatedChiTietDonHangs)
                    {
                        dbcontext.ChiTietDonHangs.Remove(chiTietDonHang);
                    }

                    // Delete the DonHang record
                    dbcontext.DonHangs.Remove(chitet);

                    // Save changes to the database
                    dbcontext.SaveChanges();


                    //if (chitet.MaDH == lbDeptid.Text && chitietDon.MaDH == lbDeptid.Text)
                    //{

                    //    ICollection<ChiTietDonHang> eTCTD = chitietDon.CTD;
                    //    foreach (var employeeTCTD in eTCTD.ToList())
                    //    {

                    //        dbcontext.ChiTietDonHangs.Remove(employeeTCTD);


                    //    }
                    //    ICollection<DonHang> eMDH = chitet.DHs;
                    //    foreach (var employeeMDH in eMDH.ToList())
                    //    {

                    //        dbcontext.DonHangs.Remove(employeeMDH);


                    //    }
                    //    dbcontext.ChiTietDonHangs.Remove(chitietDon);
                    //    dbcontext.DonHangs.Remove(chitet);

                    //    dbcontext.SaveChanges();

                    //}



                    //dbcontext.SaveChanges();

                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa đơn hàng thành công.</div>");
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
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Lỗi khi xóa đơn hàng: " + ex.Message + "</div>");
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
            Response.Redirect("ManagerOrder.aspx");
        }
        protected void btDone_Click(object sender, EventArgs e)
        {
            var str = Request.QueryString["MaDH"].ToString();
            ChiTietDonHang chitet = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == str);
            List<ChiTietDonHang> chiTietDonHangs = dbcontext.ChiTietDonHangs.Where(p => p.MaDH == str).ToList();

            KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.MaKH == chitet.KH);

            var db = new QL_KPOPStoreEntities();
            string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);
            DoanhThu doanhThu = new DoanhThu();
            foreach (var item in chiTietDonHangs)
            {

                if (item.GiaoDich == false)
                {
                    item.GiaoDich = true;
                    // Gửi email cho mỗi đơn hàng cần xác nhận

                    if (dbcontext.DoanhThus.Any(s => s.Nam == DateTime.Now.Year && s.Thang == DateTime.Now.Month && s.Ngay == DateTime.Now.Day))
                    {
                        doanhThu = dbcontext.DoanhThus.FirstOrDefault(s => s.Nam == DateTime.Now.Year && s.Thang == DateTime.Now.Month && s.Ngay == DateTime.Now.Day);
                        doanhThu.DoanhThuNgay += item.ThanhTien;

                    }
                    else
                    {
                        doanhThu = new DoanhThu
                        {

                            Ngay = DateTime.Now.Day,
                            Nam = DateTime.Now.Year,
                            Thang = DateTime.Now.Month,
                            DoanhThuNgay = item.ThanhTien,
                        };
                        dbcontext.DoanhThus.Add(doanhThu);

                    }
                }
            }

            dbcontext.SaveChanges();
            db.SaveChanges();
            SendEmail(deparments.Email, "KStore", str, imagePath);


            Response.Redirect(Request.RawUrl);
            Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xác nhận giao dịch thành công.</div>");
            Response.Write("<script type=\"text/javascript\">");
            Response.Write("setTimeout(function() {");
            Response.Write("var elements = document.getElementsByClassName('alert');");
            Response.Write("for (var i = 0; i < elements.length; i++) {");
            Response.Write("elements[i].style.display = 'none';");
            Response.Write("}");
            Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
            Response.Write("</script>");

        }
        public void SendEmail(string to, string subject, string body, string imagePath)
        {
            var str = Request.QueryString["MaDH"].ToString();

            ChiTietDonHang maDH = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.MaDH == str);

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
                string htmlBody = $"<html><body><img style=\"max-width: 100%; border-radius:20px;\" src='cid:{inline.ContentId}' alt='KStore' /><h1>Thông báo đơn hàng!</h1><p>Xin chào bạn đây là thông báo về đơn hàng với mã là <strong>{maDH.MaDH}</strong> đã được chúng tôi xác nhận.{styleColor}<p>Vào lúc: {maDH.Ngay}</p></p><p>Cảm ơn vì bạn đã mua hàng.</p></body></html>";

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                avHtml.LinkedResources.Add(inline);
                mailMessage.AlternateViews.Add(avHtml);

                // Gửi email
                smtpClient.Send(mailMessage);
                //Console.WriteLine("Đã gửi email.");
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xác nhận giao dịch thành công, chúng tôi đã gửi email đến bạn vui lòng kiểm tra.</div>");
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
                //Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">\"Lỗi khi gửi email:" + ex.Message + "</div>");
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