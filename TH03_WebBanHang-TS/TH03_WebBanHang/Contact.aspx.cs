using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TH03_WebBanHang
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string userEmail = email.Text; // Giả sử txtEmail là ID của TextBox nhập email
            SendEmail(userEmail);
        }
        protected void SendEmail(string userEmail)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(Shop.gmailAccount);
            mail.To.Add(Shop.gmailAccount);
            mail.Subject = "Yêu Cầu Hỗ Trợ";
            mail.Body = "Một người dùng đã gửi yêu cầu liên hệ với email sau: " + userEmail + "\nNội dung:\n"+message.Text;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Shop.gmailAccount, Shop.gmailPass);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            try
            {
                SmtpServer.Send(mail);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Email đã được gửi!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            catch (SmtpException ex)
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">SMTP Lỗi: " + ex.Message + "</div>");
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
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Lỗi: " + ex.Message + "</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
            }

            //Response.Write("<script>alert('Email đã được gửi đi!');</script>");


        }

    }
}