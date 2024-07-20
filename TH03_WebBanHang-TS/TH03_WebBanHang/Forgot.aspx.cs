using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static System.Net.WebRequestMethods;

namespace TH03_WebBanHang
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {

            //using (var db = new QL_KPOPStoreEntities())
            //{

            //    // input
            //    if (string.IsNullOrWhiteSpace(txtNameSignUp.Text) || string.IsNullOrWhiteSpace(txtEmailSignUp.Text) || string.IsNullOrWhiteSpace(txtPasswordSignUp.Text))
            //    {
            //        throw new Exception("All fields are required.");
            //    }

            //    // Check if email already exists
            //    var existingUser = db.TKs.FirstOrDefault(u => u.TenTaiKhoan == txtNameSignUp.Text);


            //    var existingPhone = db.KhachHangs.FirstOrDefault(s => s.DienThoai == TextPhone.Text);
            //    if (existingPhone != null)
            //    {
            //        throw new Exception("Phone already exists.");
            //    }



            //    if (existingUser != null)
            //    {
            //        throw new Exception("Email already exists.");
            //    }
            //    // Add new user to database
            //    var newUser = new TK
            //    {
            //        TenTaiKhoan = txtNameSignUp.Text,
            //        Email = txtEmailSignUp.Text,
            //        MatKhau = txtPasswordSignUp.Text,
            //        TrangThai = true,

            //    };


            //    db.SaveChanges();

            //    // Redirect to login page
            //    Response.Redirect("Default.aspx");
            //}


            string email = txtEmailSFogot.Text.Trim();

            using (var db = new QL_KPOPStoreEntities())
            {
                var user = db.TKs.FirstOrDefault(u => u.Email == email);

                if (user != null)
                {




                    if (txtMaKhoiPhuc.Text == Session["OTP"].ToString())
                    {
                        Response.Redirect("ChangePassword.aspx?Deptid=" + user.Email);

                    }
                    else if (txtMaKhoiPhuc.Text != Session["OTP"].ToString() || Session["OTP"].ToString() != txtMaKhoiPhuc.Text)
                    {
                        //Response.Write("<script>alert('Mã OTP không chính xác vui lòng thử lại!');</script>");
                        //lbOTP.Text = "Mã OTP không chính xác vui lòng thử lại!";
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Mã OTP không chính xác vui lòng thử lại!</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                        Response.Write("</script>");
                    }
                    else if (txtMaKhoiPhuc.Text == ""|| Session["OTP"]==null) lbOTP.Text = "Mã OTP không chính xác vui lòng thử lại!";

                    else
                    {

                        //lbOTP.Text = "Mã OTP không chính xác vui lòng thử lại!";
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Mã OTP không chính xác vui lòng thử lại!</div>");
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
                else
                {

                    //Response.Write("<script>alert('Tài khoản không tồn tại');</script>");
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản không tồn tại.</div>");
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

        public string GenerateOTP(int length)
        {
            var random = new Random();
            var otp = new string(Enumerable.Repeat("0123456789", length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return otp;
        }
        public void SendEmail(string to, string subject, string body, string imagePath)
        {
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

                // Tạo nội dung HTML tùy chỉnh
                string htmlBody = $"<html><body style=\"padding: 10px;  border-radius:10px; background:#000; color:#FFFF; height:max-content; \"><img style=\"max-width: 100%;  border-radius:20px; \" src='cid:{inline.ContentId}' alt='KStore' /><h1>Verify OTP</h1><p>Đây là mã OTP của bạn: <strong>{body}</strong>. Vui lòng không cung cấp mã này với bất kỳ ai!</p></body></html>";

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                avHtml.LinkedResources.Add(inline);
                mailMessage.AlternateViews.Add(avHtml);

                // Gửi email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Đã gửi email.");
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Mã OTP đã được gửi thành công, vui lòng kiểm tra!</div>");
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
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Đã xãy ra lỗi khi gửi mã OTP mã lỗi là: '" + ex.Message + "'.</div>");
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
        static string GetValuePhone(string phoneNumber)
        {
            // Kiểm tra xem số điện thoại có phải là chuỗi không
            if (phoneNumber != null && phoneNumber.Length > 0)
            {
                // Nếu số điện thoại bắt đầu bằng '0', giữ nguyên
                if (phoneNumber.StartsWith("0"))
                {
                    return phoneNumber.Substring(1);
                }
                else
                {
                    // Ngược lại, thêm '8' vào đầu và cắt bỏ ký tự đầu tiên
                    return  phoneNumber/*.Substring(1)*/;
                }
            }
            else
            {
                return null;
            }
        }
        public async void CallPhone(string phone, string otp)
        {
            try
            {
                //const string accountSid = "ACef60998169f862022892bc5328af9718";
                //const string authToken = "3a4940e569429a35b738d64aea7d785f";
                //const string fromPhoneNumber = "+16067751092"; // Ví dụ: +12345678901
                //const string toPhoneNumber = "recipient_phone_number"; // Ví dụ: +09876543210
                //const string callUrl = $"http://demo.twilio.com/docs/voice.xml";

                //TwilioClient.Init(accountSid, authToken);

                //var call = CallResource.Create(
                //    url: callUrl,
                //    to: new Twilio.Types.PhoneNumber(toPhoneNumber),
                //    from: new Twilio.Types.PhoneNumber(fromPhoneNumber)
                //);


                //var client = new HttpClient();
                //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.stringee.com/v1/call2/callout");
                //request.Headers.Add("Cookie", "SRVNAME=SF");
                //var content = new StringContent("{\r\n    \"from\": {\r\n        \"type\": \"external\",\r\n        \"number\": \"842871026036\",\r\n        \"alias\": \"STRINGEE_NUMBER\"\r\n    },\r\n    \"to\": [{\r\n        \"type\": \"external\",\r\n        \"number\": \"'" + phone + "'\",\r\n        \"alias\": \"TO_NUMBER\"\r\n    }],\r\n    \"answer_url\": \"https://example.com/answerurl\",\r\n    \"actions\": [{\r\n        \"action\": \"talk\",\r\n        \"text\": \"Xin chào đây là cuộc gọi từ KStore, bạn vừa yêu cầu mã OTP vui lòng không cấp mã này với bất kỳ ai, mã của bạn là '" + otp + "'\"\r\n    }]\r\n}", null, "application/json");
                //request.Content = content;
                //var response = await client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                string soDienThoai = phone.Substring(0, phone.Length - 1);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.stringee.com/v1/call2/callout");
                //request.Headers.Add("Authorization", "Bearer eyJjdHkiOiJzdHJpbmdlZS1hcGk7dj0xIiwidHlwIjoiSldUIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiJTSy4wLlNMU1hSRlpYNzY3bVNSQ29vZTlUamMwaWtRM3E4Rmo3LTE3MjEzMjQ4ODkiLCJpc3MiOiJTSy4wLlNMU1hSRlpYNzY3bVNSQ29vZTlUamMwaWtRM3E4Rmo3IiwiZXhwIjoxNzIzOTE2ODg5LCJyZXN0X2FwaSI6dHJ1ZX0.9RqxklzusVCJaCPp5skT_LdSMuqTq4AuAmwvoidIjEs");
                request.Headers.Add("Authorization", Shop.tokenStringee30day);

                request.Headers.Add("Cookie", "SRVNAME=SD");
                var content = new StringContent("{\r\n    \"from\": {\r\n        \"type\": \"external\",\r\n        \"number\": \"842871020574\",\r\n        \"alias\": \"STRINGEE_NUMBER\"\r\n    },\r\n    \"to\": [{\r\n        \"type\": \"external\",\r\n        \"number\": \"84"+ GetValuePhone(phone).ToString() + "\",\r\n        \"alias\": \"TO_NUMBER\"\r\n    }],\r\n    \"answer_url\": \"https://developer.stringee.com/scco_helper/simple_project_answer_url?record=false&appToPhone=auto&recordFormat=mp3\",\r\n    \"actions\": [{\r\n        \"action\": \"talk\",\r\n        \"text\": \"Xin chào đây là cuộc gọi từ KStore, bạn vừa yêu cầu mã OTP vui lòng không cấp mã này với bất kỳ ai, mã của bạn là " + string.Join(" ", otp.Select(c => c.ToString())) + ", xin nhắc lại mã OTP của bạn là " + string.Join(" ", otp.Select(c => c.ToString())) + "\"\r\n    }]\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                


                Console.WriteLine("Đã gọi cuộc gọi OTP.");
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Mã OTP đã được gửi thành công, vui lòng kiểm tra!</div>");
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
                Console.WriteLine("Lỗi khi thực hiện cuộc gọi: " + ex.Message);
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Đã xãy ra lỗi khi gửi mã OTP mã lỗi là: '" + ex.Message + "'.</div>");
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
        protected void ddlOTPChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            string otp = GenerateOTP(6);
            Session["OTP"] = otp;
            string email = txtEmailSFogot.Text.Trim();
            var db = new QL_KPOPStoreEntities();
            var user = db.TKs.FirstOrDefault(u => u.Email == email);
            string imagePath = Server.MapPath(Shop.logoForMail_BlackKS); // Đường dẫn đến hình ảnh trên server

            if (user != null)
            { 
                if(ddlOTPChoice.SelectedValue== "otpEmail")
                    SendEmail(user.Email, "OTP KStore", otp, imagePath);
                if (ddlOTPChoice.SelectedValue == "otpCallPhone")
                {
                    var khachHang = db.KhachHangs.FirstOrDefault(u => u.Email==email);
                    CallPhone(khachHang.DienThoai,otp);



                }
                if (ddlOTPChoice.SelectedValue == "otpSmsPhone")
                {
                    var khachHang = db.KhachHangs.FirstOrDefault(u => u.Email == email);
                    //string sdt = khachHang.DienThoai;
                    string sdt = khachHang.DienThoai.ToString();

                    //SmsPhone(khachHang.DienThoai, otp);
                    const string accountSid = "ACef60998169f862022892bc5328af9718";
                    const string authToken = "3a4940e569429a35b738d64aea7d785f";
                    const string fromPhoneNumber = "+16067751092"; // Ví dụ: +12345678901
                    string toPhoneNumber = "+84"+ sdt; // Ví dụ: +09876543210
                    string messageBody = "Đây là mã OTP của bạn: " + otp;

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: messageBody,
                        from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                        to: new Twilio.Types.PhoneNumber(toPhoneNumber)
                    );

                    Console.WriteLine($"Message sent successfully - SID: {message.Sid}");
                }

            }
            else
            {
                //Response.Write("<script>alert('Tài khoản không tồn tại');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản không tồn tại.</div>");
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