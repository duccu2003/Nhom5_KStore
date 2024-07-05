using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    
    public partial class Sign : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static string email = null;
        public static string pass = null;

        public static int makh;

        public static string hashE;
        public static string hashP;

        string txtGT;
        protected void Page_Load(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities db = QL_KPOPStoreEntities();
            var user = from u in db.TKs
                       where u.Email == email && u.MatKhau == pass
                       select u;
            var client = from c in db.KhachHangs
                         where c.Email == email
                         select c;
            



            

            if (VerifyToken())
            {
                HttpCookie Email = Request.Cookies["Email"];
                email = Email.Value;
                Response.Redirect("Account.aspx");
            }


            if (!IsPostBack)
            {
                ViewState["DropDownListsPopulated"] = false;
                PopulateDropDownLists();
            }
            else
            {
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
        }

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

                string selectedCity = ddlCity.SelectedValue;
                if (!string.IsNullOrEmpty(selectedCity))
                {
                    var queryQH = from qh in context.devvn_quanhuyen
                                  where qh.matp == selectedCity
                                  select new { qh.maqh, qh.nameQH };

                    ddlDistrict.DataSource = queryQH.ToList();
                    ddlDistrict.DataTextField = "nameQH";
                    ddlDistrict.DataValueField = "maqh";
                    ddlDistrict.DataBind();

                    string selectedDis = ddlDistrict.SelectedValue;
                    if (!string.IsNullOrEmpty(selectedDis))
                    {
                        var queryXH = from xp in context.devvn_xaphuongthitran
                                      where xp.maqh == selectedDis
                                      select new { xp.xaid, xp.nameXP };

                        ddlW.DataSource = queryXH.ToList();
                        ddlW.DataTextField = "nameXP";
                        ddlW.DataValueField = "xaid";
                        ddlW.DataBind();
                    }
                }

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
            using (var context = new VNlocalEntities())
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
        protected void ddlGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGT.SelectedValue == "Nam")
            {
                txtGT = "Nam";
            }
            else if (ddlGT.SelectedValue == "Nữ")
            {
                txtGT = "Nữ";
            }
            else if (ddlGT.SelectedValue == "Khác")
            {
                txtGT = "Khác";
            }
        }
        
        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            QL_KPOPStoreEntities tk = new QL_KPOPStoreEntities();
            if (string.IsNullOrEmpty(txtEmailSignUp.Text) ||
                string.IsNullOrEmpty(txtPasswordSignUp.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtDiachi.Text))
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng điền đầy đủ thông tin.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");

                return;
            }
            else if (txtPasswordSignUpAgain.Text != txtPasswordSignUp.Text)
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Mật khẩu không trùng khớp, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");

            }
            else if (TextPhone.Text.Length != 10)
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập đúng số điện thoại</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");

            }
            else if (!TextPhone.Text.IsNullOrEmpty() && tk.KhachHangs.Any(p => p.DienThoai == TextPhone.Text && (p.MatKhau != null || p.MatKhau !="")))
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã tồn tại, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");

            }
            else if (tk.KhachHangs.Any(p => p.Email == txtEmailSignUp.Text && p.MatKhau != null))
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Email này đã tồn tại, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");

            }
            else if (txtDiachi.Text.Length <= 4)
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập địa chỉ cụ thể</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);");
                Response.Write("</script>");
            }
            else
            {
                using (var db = new QL_KPOPStoreEntities())
                {
                    if (ddlGT.SelectedValue == "Nam")
                    {
                        txtGT = "Nam";
                    }
                    else if (ddlGT.SelectedValue == "Nữ")
                    {
                        txtGT = "Nữ";
                    }
                    else if (ddlGT.SelectedValue == "Khác")
                    {
                        txtGT = "Khác";
                    }
                    var hadUser = dbcontext.TKs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text && p.MatKhau == null);

                    if (hadUser != null)
                    {
                        var existingAccount = db.KhachHangs.FirstOrDefault(p => p.MaKH != 0 && p.MatKhau == null && (p.Email == txtEmailSignUp.Text || p.DienThoai == TextPhone.Text));
                        var existingAccountTK = db.TKs.FirstOrDefault(p => p.Email == txtEmailSignUp.Text && p.MatKhau == null);
                        if (existingAccount != null)
                        {
                            if (string.IsNullOrWhiteSpace(existingAccount.Email))
                            {
                                existingAccount.Email = txtEmailSignUp.Text;
                                existingAccountTK.Email = txtEmailSignUp.Text;
                            }
                            if (string.IsNullOrWhiteSpace(existingAccount.MatKhau))
                            {
                                existingAccount.MatKhau = txtPasswordSignUp.Text;
                                existingAccountTK.MatKhau = txtPasswordSignUp.Text;
                            }
                            existingAccount.HoTen = txtName.Text;
                            existingAccount.DienThoai = TextPhone.Text;
                            existingAccount.GioiTinh = txtGT;
                            existingAccount.DiaChi = txtDiachi.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;

                            existingAccount.TrangThai = false;
                            existingAccountTK.TrangThai = false;
                            
                            db.SaveChanges();
                            
                            Response.Write("<script>\r\n            document.getElementById(\"container\").classList.remove(\"active\");\r\n        </script>");
                            Response.Write("<div class=\"alert alert-success\" role=\"alert\">Đăng ký tài khoản thành công, giờ bạn có thể đăng nhập</div>");
                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("setTimeout(function() {");
                            Response.Write("var elements = document.getElementsByClassName('alert');");
                            Response.Write("for (var i = 0; i < elements.length; i++) {");
                            Response.Write("elements[i].style.display = 'none';");
                            Response.Write("}");
                            Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                            Response.Write("</script>");

                            txtDiachi.Text = string.Empty;
                            txtPasswordSignUp.Text = string.Empty;
                            txtEmailSignUp.Text = string.Empty;
                            TextPhone.Text = string.Empty;
                            txtName.Text = string.Empty;
                            ddlCity.SelectedIndex=0;
                            ddlDistrict.SelectedIndex=0;
                            ddlGT.SelectedIndex=0;
                            ddlW.SelectedIndex=0;
                            txtPasswordSignUpAgain.Text = string.Empty;
                        }
                    }

                   

                    if (tk.TKs.Any(p => p.Email == txtEmailSignUp.Text))
                    {

                        Response.Write("<script>alert('Tài khoản đã tồn tại, vui lòng nhập lại');</script>");
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản đã tồn tại, vui lòng nhập lại.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);");
                        Response.Write("</script>");
                    }
                    else if (!TextPhone.Text.IsNullOrEmpty() && tk.KhachHangs.Any(p => p.DienThoai == TextPhone.Text && (p.MatKhau!=null||p.MatKhau!="")))
                    {
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã tồn tại, vui lòng nhập lại.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);");
                        Response.Write("</script>");
                    }
                    if (string.IsNullOrWhiteSpace(txtEmailSignUp.Text) || string.IsNullOrWhiteSpace(txtPasswordSignUp.Text))
                    {
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản, mật khẩu không được để trống.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);");
                        Response.Write("</script>");
                    }

                    var existingUser = db.TKs.FirstOrDefault(u => u.Email == txtEmailSignUp.Text);
                    var existingUserKH = db.KhachHangs.FirstOrDefault(u => u.Email == txtEmailSignUp.Text);

                    var existingHoTen = db.KhachHangs.FirstOrDefault(t => t.HoTen == txtName.Text);
                    var existingDiaChi = db.KhachHangs.FirstOrDefault(d => d.DiaChi == txtDiachi.Text);

                    var existingPhone = db.KhachHangs.FirstOrDefault(s => s.DienThoai == TextPhone.Text);
                    if (existingPhone != null)
                    {
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã được sử dụng cho tài khoản khác.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);");
                        Response.Write("</script>");

                    }



                    var existingGioiTinh = db.KhachHangs.FirstOrDefault(d => d.GioiTinh == txtGT);

                    if (existingUser != null)
                    {
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Email đã được sử dụng, vui lòng nhập lại.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);");
                        Response.Write("</script>");
                    }
                    
                    var newUser = new TK
                    {
                        Email = txtEmailSignUp.Text,
                        MatKhau = txtPasswordSignUp.Text,
                        TrangThai = true,



                    };
                    var newClient = new KhachHang
                    {
                        HoTen = txtName.Text,
                        DienThoai = TextPhone.Text,
                        GioiTinh = txtGT,
                        DiaChi = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text,
                        Email = txtEmailSignUp.Text,
                        MatKhau = txtPasswordSignUp.Text,
                        TrangThai = true,
                        Diem = 0,
                        AvatarUser = Shop.defaultAvatar_BlackKS,

                    };

                    db.TKs.Add(newUser);
                    db.KhachHangs.Add(newClient);
                    db.SaveChanges();

                    
                    Response.Write("<script>\r\n            document.getElementById(\"container\").classList.remove(\"active\");\r\n        </script>");
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Đăng ký tài khoản thành công, giờ bạn có thể đăng nhập.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); 
                    Response.Write("</script>");

                    txtDiachi.Text = string.Empty;
                    txtPasswordSignUp.Text = string.Empty;
                    txtEmailSignUp.Text = string.Empty;
                    TextPhone.Text = string.Empty;
                    txtName.Text = string.Empty;
                    ddlCity.SelectedIndex = 0;
                    ddlDistrict.SelectedIndex = 0;
                    ddlGT.SelectedIndex = 0;
                    ddlW.SelectedIndex = 0;
                    txtPasswordSignUpAgain.Text = string.Empty;
                }
            }

        }
       

        public static string HashPassword(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            
            QL_KPOPStoreEntities db = QL_KPOPStoreEntities();

            string hashedPassword = HashPassword(txtPasswordSignIn.Text);
            string hashedEmail = HashPassword(txtEmailSignIn.Text);
            
            TK tK = dbcontext.TKs.FirstOrDefault(s => s.Email == txtEmailSignIn.Text && s.MatKhau == txtPasswordSignIn.Text);
            string SQLhashedPassword;
            string SQLhashedEmail;
            if (tK != null)
            {

                Session["Password"] = txtPasswordSignIn.Text;
                Session["Email"] = txtEmailSignIn.Text;
                HttpCookie cookieEmail = new HttpCookie("Email", Session["Email"].ToString());
                Response.Cookies.Add(cookieEmail);
                
                SQLhashedPassword = HashPassword(tK.MatKhau);
                SQLhashedEmail = HashPassword(tK.Email);
                

                HttpCookie Email = Request.Cookies["Email"];
                email = Email.Value;
                

                string token = GenerateToken(email, pass);

                HttpCookie cookie = new HttpCookie("AuthToken", token);
                Response.Cookies.Add(cookie);



                var user = from u in db.TKs
                           where u.Email == email && u.MatKhau == pass
                           select u;
                var client = from c in db.KhachHangs
                             where c.Email == email
                             select c;

                var disabledTKs = user.Where(p => p.TrangThai == false && p.Email == email).ToList();
                var disabledKHs = client.Where(p => p.TrangThai == false && p.Email == email).ToList();

                foreach (var tk in disabledTKs)
                {
                    tk.TrangThai = true;


                }
                foreach (var kh in disabledKHs)
                {
                    kh.TrangThai = true;
                    Session["MaKH"] = kh.MaKH; 
                }
                

                db.SaveChanges();

                Response.Redirect("Account.aspx");

            }
            else
            {
                SQLhashedPassword = null;
                SQLhashedEmail = null;
                //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
                Session.Remove("Password");
                Session.Remove("Email");
                email = null;
                pass = null;
            }

            if (SQLhashedPassword != hashedPassword || SQLhashedEmail != hashedEmail)
            {

                
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản hoặc mật khẩu không chính xác.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); 
                Response.Write("</script>");
                
            }
        }

        private QL_KPOPStoreEntities QL_KPOPStoreEntities()
        {
            return new QL_KPOPStoreEntities();
        }
       
        private string GenerateToken(string email, string pass)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32]; //Độ dài 32 byte tương đương với 256 bit
                rng.GetBytes(randomBytes);

                //Chuyển byte array thành chuỗi Base64
                string secretKey = Convert.ToBase64String(randomBytes);

                //Sử dụng secretKey để tạo token
                var key = Encoding.ASCII.GetBytes(secretKey);
                HttpCookie cookieKey = new HttpCookie("Key", secretKey);
                Response.Cookies.Add(cookieKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                


                return tokenHandler.WriteToken(token);
            }
        }
        private bool VerifyToken()
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            HttpCookie cookie = Request.Cookies["AuthToken"];
            HttpCookie Key = Request.Cookies["Key"];
            
            if (cookie == null || EmailKhach == null) return false;
            string token = cookie.Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key.Value);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }


    }
}