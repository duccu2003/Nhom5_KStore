using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class AddAccount : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        string txtGT;
        protected void Page_Load(object sender, EventArgs e)
        {

            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;
            var db = new QL_KPOPStoreEntities();
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            if (user.Any(p => EmailKhach != null && ((p.Email == EmailKhach && EmailKhach == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.Email == EmailKhach))))
            {

            }
            // Otherwise, display an error message

            else
            {
                //Response.Write("<script>alert('Bạn không có quyền truy cập');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Bạn không có quyền truy cập!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

                Response.Redirect("Error/401");

            }


            if (!IsPostBack)
            {
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

        //    }

        //}
        protected void btAdd_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities tk = new QL_KPOPStoreEntities();
            if (string.IsNullOrEmpty(txtEmailSignUp.Text) ||
               string.IsNullOrEmpty(txtPasswordSignUp.Text) ||
               string.IsNullOrEmpty(txtName.Text) ||
               string.IsNullOrEmpty(txtDiachi.Text))
            {
                // Thông báo cho người dùng nhập đầy đủ thông tin
                //Response.Write("<script>alert('Vui lòng điền đầy đủ thông tin');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng điền đầy đủ thông tin!</div>");
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
            if (tk.TKs.Any(p => p.Email == txtEmailSignUp.Text))
            {

                //Response.Write("<script>alert('Tài khoản đã tồn tại');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Tài khoản đã tồn tại!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else if (tk.KhachHangs.Any(p => p.DienThoai == TextPhone.Text))
            {

                //Response.Write("<script>alert('Số điện thoại đã tồn tại');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Số điện thoại đã tồn tại!</div>");
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
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập đúng số điện thoại!</div>");
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
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Vui lòng nhập địa chỉ cụ thể!</div>");
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
                TK deparment = new TK();
                KhachHang client = new KhachHang();
                QL_KPOPStoreEntities db = new QL_KPOPStoreEntities();
                deparment.Email = txtEmailSignUp.Text;
                deparment.MatKhau = txtPasswordSignUp.Text;
                deparment.TrangThai = false;
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
                var existingGioiTinh = db.KhachHangs.FirstOrDefault(d => d.GioiTinh == txtGT);
                client.AvatarUser = Shop.defaultAvatar_BlackKS;
                client.HoTen = txtName.Text;
                client.DienThoai = TextPhone.Text;
                client.GioiTinh = txtGT;
                client.DiaChi = txtDiachi.Text + ", " + ddlW.SelectedItem.Text + ", " + ddlDistrict.SelectedItem.Text + ", " + ddlCity.SelectedItem.Text;

                client.Email = txtEmailSignUp.Text;
                client.MatKhau = txtPasswordSignUp.Text;
                client.TrangThai = false;
                client.Diem = 0;



                dbcontext.TKs.Add(deparment);
                dbcontext.KhachHangs.Add(client);

                dbcontext.SaveChanges();
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm tài khoản thành công.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

                Response.Redirect("ManagerAccount");
            }

        }


    }
}