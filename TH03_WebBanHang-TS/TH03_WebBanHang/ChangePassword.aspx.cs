using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("OTP");
            if (!IsPostBack)
            {
                string str = Request.QueryString["Deptid"].ToString();
                TK deparments = dbcontext.TKs.SingleOrDefault(p => p.Email == str);
                var hadKhach = dbcontext.KhachHangs.Any(p => p.Email == str);

                var Khach = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == str);

                if (deparments != null)
                {
                    lbEmail.Text = str;
                    if(hadKhach)
                        imgUser.ImageUrl = Khach.AvatarUser;
                    else
                    {
                        imgUser.ImageUrl = "Content\\account-img\\KS.png";
                    }
                }
                else
                {
                    Response.Redirect("Forgot.aspx");
                }

            }
        }
        protected void btChange_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["Deptid"].ToString();

            // Tìm đối tượng TK và KhachHang dựa trên email
            TK tkUser = dbcontext.TKs.SingleOrDefault(p => p.Email == email);
            KhachHang khUser = dbcontext.KhachHangs.SingleOrDefault(p => p.Email == email);
            if (txtPasswordSignUp.Text != txtPasswordConfirm.Text)
            {
                // Nếu không khớp, hiển thị thông báo lỗi
                //Response.Write("<script>alert('Mật khẩu không khớp');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Mật khẩu không khớp!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
                return; // Dừng việc thực hiện phương thức
            }

            // Kiểm tra xem hai trường mật khẩu có được điền đầy đủ hay không
            if (string.IsNullOrWhiteSpace(txtPasswordSignUp.Text) || string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                // Nếu không được điền đầy đủ, hiển thị thông báo lỗi
                //Response.Write("<script>alert('Vui lòng nhập mật khẩu mới');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập mật khẩu mới!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
                return; // Dừng việc thực hiện phương thức
            }
            if (tkUser != null || khUser != null)
            {
                try
                {

                    if (tkUser != null)
                    {
                        tkUser.MatKhau = txtPasswordConfirm.Text;
                    }


                    if (khUser != null)
                    {
                        khUser.MatKhau = txtPasswordConfirm.Text;
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    dbcontext.SaveChanges();


                    //Response.Write("<script>alert('Thay đổi mật khẩu thành công');</script>");
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thay đổi mật khẩu thành công.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");

                    //Thread.Sleep(1500);
                    Response.Redirect("Account.aspx");
                }
                catch (Exception ex)
                {

                    //Response.Write("<script>alert('Lỗi khi thay đổi mật khẩu: " + ex.Message + "');</script>");
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Lỗi khi thay đổi mật khẩu: " + ex.Message + "</div>");
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
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản không tồn tại!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
                Response.Redirect("Forgot.aspx");
            }
        }

    }
}