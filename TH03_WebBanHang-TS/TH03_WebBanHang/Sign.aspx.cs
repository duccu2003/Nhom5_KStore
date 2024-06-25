using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class Sign : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static string email;
        public static string pass;

        public static int makh;



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
            



            Session["User"] = txtEmailSignUp.Text;
            
            if (user.Any(p => p.TrangThai == true && p.Email == Sign.email))
            {
                Response.Redirect("Account.aspx");

            }


            if (!IsPostBack)
            {

                // Set the flag to indicate that the DropDownLists have not been populated yet
                ViewState["DropDownListsPopulated"] = false;

                PopulateDropDownLists();
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

            Session["Password"] = txtPasswordSignIn.Text;
            Session["Email"] = txtEmailSignIn.Text;
            email = Session["Email"].ToString();
            pass = Session["Password"].ToString();
            string hashedPassword = HashPassword(pass);
            string hashedEmail = HashPassword(email);
            TK tK = dbcontext.TKs.FirstOrDefault(s => s.Email == email && s.MatKhau == pass);
            string SQLhashedPassword;
            string SQLhashedEmail;
            if (tK != null)
            {
                SQLhashedPassword = HashPassword(tK.MatKhau);
                SQLhashedEmail = HashPassword(tK.Email);
            }
            else
            {
                SQLhashedPassword = null;
                SQLhashedEmail = null;
                //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
                Session.Remove("Password");
                Session.Remove("Email");
            }

            if (/*db.TKs.Any(p => p.Email != email || p.MatKhau != pass) */ SQLhashedPassword != hashedPassword || SQLhashedEmail != hashedEmail)
            {

                //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
                SQLhashedPassword = null;
                SQLhashedEmail = null;
                Session.Remove("Password");
                Session.Remove("Email");

            }
            else
            {


                // If a user was found, redirect to the home page
                if (user.Any(p => p.Email == email) && SQLhashedEmail == hashedEmail && SQLhashedPassword == hashedPassword)
                {

                    var disabledTKs = user.Where(p => p.TrangThai == false && p.Email == email).ToList();
                    var disabledKHs = client.Where(p => p.TrangThai == false && p.Email == email).ToList();

                    foreach (var tk in disabledTKs)
                    {
                        tk.TrangThai = true;
                        Session["MaKH"] = tk.MaTK - 1;

                    }
                    foreach (var kh in disabledKHs)
                    {
                        kh.TrangThai = true;
                    }
                    db.SaveChanges(); Response.Redirect("Account.aspx");
                }
                // Otherwise, display an error message
                //else if (txtEmailSignIn.Text == "admin" && txtPasswordSignIn.Text == "123456")
                //{
                //    Response.Redirect("Manager");

                //}
                else
                {

                    ModelState.AddModelError("Password", "The password is incorrect.");
                }
            }


        }

        private void PopulateDropDownLists()
        {
            using (var context = new VNlocalEntities())
            {
                // Populate ddlCity
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

        //}
        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            QL_KPOPStoreEntities tk = new QL_KPOPStoreEntities();
            if (string.IsNullOrEmpty(txtEmailSignUp.Text) ||
                string.IsNullOrEmpty(txtPasswordSignUp.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtDiachi.Text))
            {
                // Thông báo cho người dùng nhập đầy đủ thông tin
                //Response.Write("<script>alert('Vui lòng điền đầy đủ thông tin');</script>");

                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng điền đầy đủ thông tin.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

                return;
            }
            else if (txtPasswordSignUpAgain.Text != txtPasswordSignUp.Text)
            {

                //Response.Write("<script>alert('Mật khẩu không trùng khớp, vui lòng nhập lại');</script>");

                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Mật khẩu không trùng khớp, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else if (TextPhone.Text.Length != 10)
            {

                //Response.Write("<script>alert('Vui lòng nhập đúng số điện thoại');</script>");

                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập đúng số điện thoại</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else if (!TextPhone.Text.IsNullOrEmpty() && tk.KhachHangs.Any(p => p.DienThoai == TextPhone.Text && (p.MatKhau != null || p.MatKhau !="")))
            {

                //Response.Write("<script>alert('Số điện thoại đã tồn tại');</script>");

                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã tồn tại, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else if (tk.KhachHangs.Any(p => p.Email == txtEmailSignUp.Text && p.MatKhau != null))
            {

                //Response.Write("<script>alert('Email đã tồn tại');</script>");

                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Email này đã tồn tại, vui lòng nhập lại.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else if (txtDiachi.Text.Length <= 4)
            {

                //Response.Write("<script>alert('Vui lòng nhập địa chỉ cụ thể');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập địa chỉ cụ thể</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
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
                            // If the account exists, only add missing or not yet entered parts
                            //if (string.IsNullOrWhiteSpace(existingAccount.HoTen))
                            //{
                            //    existingAccount.HoTen = txtName.Text;

                            //}
                            //if (string.IsNullOrWhiteSpace(existingAccount.DienThoai))
                            //{
                            //    existingAccount.DienThoai = TextPhone.Text;
                            //}
                            //if (string.IsNullOrWhiteSpace(existingAccount.GioiTinh))
                            //{
                            //    existingAccount.GioiTinh = txtGT;
                            //}

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
                            //db.TKs.Add(existingAccountTK);
                            //db.KhachHangs.Add(existingAccount);
                            db.SaveChanges();
                            //Response.Redirect("Account.aspx");
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

                    // input

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
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                        Response.Write("</script>");
                    }
                    else if (!TextPhone.Text.IsNullOrEmpty() && tk.KhachHangs.Any(p => p.DienThoai == TextPhone.Text && (p.MatKhau!=null||p.MatKhau!="")))
                    {

                        //Response.Write("<script>alert('Số điện thoại đã tồn tại');</script>");
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã tồn tại, vui lòng nhập lại.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
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
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                        Response.Write("</script>");
                    }

                    // Check if email already exists
                    var existingUser = db.TKs.FirstOrDefault(u => u.Email == txtEmailSignUp.Text);
                    var existingUserKH = db.KhachHangs.FirstOrDefault(u => u.Email == txtEmailSignUp.Text);

                    var existingHoTen = db.KhachHangs.FirstOrDefault(t => t.HoTen == txtName.Text);
                    var existingDiaChi = db.KhachHangs.FirstOrDefault(d => d.DiaChi == txtDiachi.Text);

                    var existingPhone = db.KhachHangs.FirstOrDefault(s => s.DienThoai == TextPhone.Text);
                    if (existingPhone != null)
                    {
                        //Response.Write("<script>alert('Số điện thoại đã được sử dụng cho tài khoản khác.');</script>");
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã được sử dụng cho tài khoản khác.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                        Response.Write("</script>");

                    }



                    var existingGioiTinh = db.KhachHangs.FirstOrDefault(d => d.GioiTinh == txtGT);

                    if (existingUser != null)
                    {
                        //throw new Exception("Email already exists.");
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Email đã được sử dụng, vui lòng nhập lại.</div>");
                        Response.Write("<script type=\"text/javascript\">");
                        Response.Write("setTimeout(function() {");
                        Response.Write("var elements = document.getElementsByClassName('alert');");
                        Response.Write("for (var i = 0; i < elements.length; i++) {");
                        Response.Write("elements[i].style.display = 'none';");
                        Response.Write("}");
                        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                        Response.Write("</script>");
                    }
                    // Add new user to database
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

                    // Redirect to login page
                    //Response.Redirect("Account.aspx");
                    Response.Write("<script>\r\n            document.getElementById(\"container\").classList.remove(\"active\");\r\n        </script>");
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Đăng ký tài khoản thành công, giờ bạn có thể đăng nhập.</div>");
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
            // Connect to the database
            QL_KPOPStoreEntities db = QL_KPOPStoreEntities();

           
            string hashedPassword = HashPassword(pass);
            string hashedEmail = HashPassword(email);
            TK tK = dbcontext.TKs.FirstOrDefault(s => s.Email == txtEmailSignIn.Text && s.MatKhau == txtPasswordSignIn.Text);
            string SQLhashedPassword;
            string SQLhashedEmail;
            if (tK != null)
            {
                Session["Password"] = txtPasswordSignIn.Text;
                Session["Email"] = txtEmailSignIn.Text;
                email = Session["Email"].ToString();
                pass = Session["Password"].ToString();
                SQLhashedPassword = HashPassword(tK.MatKhau);
                SQLhashedEmail = HashPassword(tK.Email);
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

            if (/*db.TKs.Any(p => p.Email != email || p.MatKhau != pass) */ SQLhashedPassword != hashedPassword || SQLhashedEmail != hashedEmail)
            {

                //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản hoặc mật khẩu không chính xác.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
                SQLhashedPassword = null;
                SQLhashedEmail = null;
                Session.Remove("Password");
                Session.Remove("Email");

            }
            else
            {
                var user = from u in db.TKs
                           where u.Email == email && u.MatKhau == pass
                           select u;
                var client = from c in db.KhachHangs
                             where c.Email == email
                             select c;

                // If a user was found, redirect to the home page
                if (user.Any(p => p.Email == email) && SQLhashedEmail == hashedEmail && SQLhashedPassword == hashedPassword)
                {

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
                    //if (chkRemember.Checked)
                    //{
                    //    HttpCookie cookie = new HttpCookie("UserAccount");
                    //    cookie["Username"] = txtEmailSignIn.Text;
                    //    cookie["Password"]= txtPasswordSignIn.Text;
                    //    cookie.Expires = DateTime.Now.AddMonths(1);
                    //    Response.Cookies.Add(cookie);
                    //}

                    db.SaveChanges(); Response.Redirect("Account.aspx");
                }
                // Otherwise, display an error message
                //else if (txtEmailSignIn.Text == "admin" && txtPasswordSignIn.Text == "123456")
                //{
                //    Response.Redirect("Manager");

                //}
                else
                {

                    ModelState.AddModelError("Password", "The password is incorrect.");
                }
            }
        }

        private QL_KPOPStoreEntities QL_KPOPStoreEntities()
        {
            return new QL_KPOPStoreEntities();
        }
    }
}