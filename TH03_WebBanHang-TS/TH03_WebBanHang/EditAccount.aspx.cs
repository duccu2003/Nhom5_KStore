using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TH03_WebBanHang.Models;
using static QRCoder.PayloadGenerator;

namespace TH03_WebBanHang
{
    public partial class EditAccount : System.Web.UI.Page
    {
        public string txtGT;
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaKH = HttpContext.Current.Request.QueryString.Get("MaKH");
            string email = HttpContext.Current.Request.QueryString.Get("Email");

            int.TryParse(MaKH, out int id);
            KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.MaKH == id || s.Email == email);

            
            if (!IsPostBack)
            {
                txtHoTen.Text = khachHang.HoTen;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSoDienThoai.Text = khachHang.DienThoai;
                ddlGT.Text = khachHang.GioiTinh;
                


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

        public IQueryable<TH03_WebBanHang.Models.KhachHang> GetProfile([QueryString("MaKH")] String MaKH)
        {
            int MaK;
            int.TryParse(MaKH, out MaK);

            IQueryable<KhachHang> khachHangs = dbcontext.KhachHangs.Where(p => p.MaKH == MaK);






            return khachHangs;
        }
        protected void editImg_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            string email = HttpContext.Current.Request.QueryString.Get("Email");
            string MaKH = HttpContext.Current.Request.QueryString.Get("MaKH");
            int MaK;
            int.TryParse(MaKH, out MaK);
            if (fileUploadImages.HasFile)
            {
                string uploadFolderPath = Server.MapPath("Content/account-img/");
                string fileName = Path.GetFileName(fileUploadImages.FileName);
                string fileExtension = Path.GetExtension(fileUploadImages.FileName);

                string filePath = Path.Combine(uploadFolderPath, fileName);

                // Lấy đường dẫn từ "Content" trở đi
                string relativePath = filePath.Substring(filePath.IndexOf("Content"));

                var tk = dbcontext.TKs.FirstOrDefault(p => p.Email == EmailKhach);
                KhachHang khachhang = dbcontext.KhachHangs.FirstOrDefault(p => (p.Email == EmailKhach || p.Email == email) && p.MaKH == MaK);
                if (tk != null)
                {
                    // Cập nhật thuộc tính AvatarUser và lưu thay đổi vào cơ sở dữ liệu
                    khachhang.AvatarUser = relativePath;
                    khachhang.DiaChi = txtDiaChi.Text;
                    khachhang.HoTen = txtHoTen.Text;
                    khachhang.DienThoai = txtSoDienThoai.Text;
                    khachhang.GioiTinh = ddlGT.SelectedItem.Text;
                    dbcontext.SaveChanges();

                    fileUploadImages.SaveAs(filePath);
                    Response.Redirect("Account.aspx");

                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thay đổi thông tin thành công.</div>");
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
                    // Xử lý trường hợp không tìm thấy đối tượng tk
                    System.Diagnostics.Debug.WriteLine("User not found.");
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Không tìm thấy đối tượng!</div>");
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
                var tk = dbcontext.TKs.FirstOrDefault(p => p.Email == EmailKhach);
                KhachHang khachhang = dbcontext.KhachHangs.FirstOrDefault(p => (p.Email == EmailKhach || p.Email == email) && p.MaKH == MaK);

                if (tk != null)
                {

                    khachhang.DiaChi = txtDiaChi.Text;
                    khachhang.HoTen = txtHoTen.Text;
                    khachhang.DienThoai = txtSoDienThoai.Text;
                    khachhang.GioiTinh = ddlGT.SelectedItem.Text;
                    dbcontext.SaveChanges();
                    Response.Redirect("Account.aspx");

                }
            }
        }
        //private void PopulateDropDownLists()
        //{
        //    string MaKH = HttpContext.Current.Request.QueryString.Get("MaKH");
        //    string email = HttpContext.Current.Request.QueryString.Get("Email");
        //    int.TryParse(MaKH, out int id);

        //    KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.MaKH == id || s.Email == email);

        //    using (var context = new VNlocalEntities())
        //    {
        //        // Populate ddlCity
        //        var queryTP = from tp in context.devvn_tinhthanhpho
        //                      select new { tp.matp, tp.nameTP };

        //        ddlCity.DataSource = queryTP.ToList();
        //        ddlCity.DataTextField = "nameTP";
        //        ddlCity.DataValueField = "matp";
        //        ddlCity.DataBind();

        //        // Check if a city is selected
        //        string selectedCity = ddlCity.SelectedValue;
        //        if (!string.IsNullOrEmpty(selectedCity))
        //        {
        //            // Populate ddlDistrict
        //            var queryQH = from qh in context.devvn_quanhuyen
        //                          where qh.matp == selectedCity
        //                          select new { qh.maqh, qh.nameQH };

        //            ddlDistrict.DataSource = queryQH.ToList();
        //            ddlDistrict.DataTextField = "nameQH";
        //            ddlDistrict.DataValueField = "maqh";
        //            ddlDistrict.DataBind();
        //            ListItem listItemQuan = ddlDistrict.Items.FindByValue(khachHang.DiaChi);
        //            if (listItemQuan != null)
        //            {
        //                // Chọn mục phù hợp
        //                ddlDistrict.SelectedValue = listItemQuan.Value;
        //            }
        //            else
        //            {
        //                // Nếu không tìm thấy mục phù hợp, bạn có thể chọn một mục mặc định hoặc không chọn gì cả
        //                // Ví dụ: Chọn mục đầu tiên nếu không tìm thấy mục phù hợp
        //                if (ddlDistrict.Items.Count > 0)
        //                {
        //                    ddlDistrict.SelectedIndex = 0;
        //                }
        //            }
        //            // Check if a district is selected
        //            string selectedDis = ddlDistrict.SelectedValue;
        //            if (!string.IsNullOrEmpty(selectedDis))
        //            {
        //                // Populate ddlW
        //                var queryXH = from xp in context.devvn_xaphuongthitran
        //                              where xp.maqh == selectedDis
        //                              select new { xp.xaid, xp.nameXP };

        //                ddlW.DataSource = queryXH.ToList();
        //                ddlW.DataTextField = "nameXP";
        //                ddlW.DataValueField = "xaid";
        //                ddlW.DataBind();
        //                ListItem listItemXa = ddlW.Items.FindByValue(khachHang.DiaChi);
        //                if (listItemXa != null)
        //                {
        //                    // Chọn mục phù hợp
        //                    ddlW.SelectedValue = listItemXa.Value;
        //                }
        //                else
        //                {
        //                    // Nếu không tìm thấy mục phù hợp, bạn có thể chọn một mục mặc định hoặc không chọn gì cả
        //                    // Ví dụ: Chọn mục đầu tiên nếu không tìm thấy mục phù hợp
        //                    if (ddlW.Items.Count > 0)
        //                    {
        //                        ddlW.SelectedIndex = 0;
        //                    }
        //                }
        //            }
        //        }

        //        // Set the flag to indicate that the DropDownLists have been populated
        //        ViewState["DropDownListsPopulated"] = true;
        //    }
        //}
        //protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        //{



        //    using (var context = new VNlocalEntities())
        //    {

        //        string selectedCity = ddlCity.SelectedValue;
        //        if (!string.IsNullOrEmpty(selectedCity))
        //        {
        //            // Filter districts based on the selected city
        //            var queryQH = from qh in context.devvn_quanhuyen
        //                          where qh.matp == selectedCity
        //                          select new { qh.maqh, qh.nameQH };

        //            ddlDistrict.DataSource = queryQH.ToList();
        //            ddlDistrict.DataTextField = "nameQH";
        //            ddlDistrict.DataValueField = "maqh";
        //            ddlDistrict.DataBind();


        //        }

        //    }

        //}

        //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    using (var context = new VNlocalEntities())
        //    {
        //        string selectedDistrict = ddlDistrict.SelectedValue;
        //        if (!string.IsNullOrEmpty(selectedDistrict))
        //        {
        //            var queryXH = from xp in context.devvn_xaphuongthitran
        //                          where xp.maqh == selectedDistrict
        //                          select new { xp.xaid, xp.nameXP };

        //            ddlW.DataSource = queryXH.ToList();
        //            ddlW.DataTextField = "nameXP";
        //            ddlW.DataValueField = "xaid";
        //            ddlW.DataBind();
        //        }
        //    }
        //}
        //protected void ddlW_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //}


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString();
            Response.Redirect(url);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString();
            Response.Redirect("Account.aspx");
        }
        protected void btnCPass_Click(object sender, EventArgs e)
        {
            string maKH = HttpContext.Current.Request.QueryString.Get("MaKH");
            string emailKH = HttpContext.Current.Request.QueryString.Get("Email");

            var user = from u in dbcontext.TKs
                       select u;
            var tk = user.SingleOrDefault(p => p.Email == emailKH);

            Response.Redirect("ChangePassword.aspx?Deptid=" + tk.Email);
        }
        protected void btDel_Click(object sender, EventArgs e)
        {
            //TK deparment = dbcontext.TKs.SingleOrDefault(p => p.Email == lbDeptid.Text);
            //try
            //{
            //    if (deparment.KhachHang.Count > 0)
            //    {
            //        ICollection<TK> employees = deparment.TKs;
            //        for (int i = 0; i < employees.Count; i++)
            //        {
            //            dbcontext.Employees.Remove(employees.ElementAt(i));
            //            dbcontext.SaveChanges();
            //        }
            //    }
            //    dbcontext.TKs.Remove(deparment);
            //    dbcontext.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //Response.Redirect("Phong.aspx");
            var maKH = Request.QueryString["MaKH"].ToString();
            var emailKH = Request.QueryString["Email"].ToString();
            TK deparment = dbcontext.TKs.SingleOrDefault(p => p.Email == emailKH); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
            KhachHang client = dbcontext.KhachHangs.SingleOrDefault(p => p.Email == emailKH); //lọc trong xem có email nào == lbDeptid đang được hiện (KH)


            if (client != null && deparment != null)
            {

                var donHangs = dbcontext.DonHangs.Where(d => d.KH == client.MaKH).ToList();
                var chiTietDonKH = dbcontext.ChiTietDonHangs.Where(d => d.KH == client.MaKH).ToList();

                foreach (var donHang in donHangs)
                {
                    dbcontext.DonHangs.Remove(donHang);
                }
                foreach (var chitietDon in chiTietDonKH)
                {
                    dbcontext.ChiTietDonHangs.Remove(chitietDon);

                }
                dbcontext.SaveChanges();


                ICollection<TK> eTK = deparment.TKs.ToList();
                foreach (var employeeTK in eTK)
                {
                    dbcontext.TKs.Remove(employeeTK);
                }
                ICollection<KhachHang> eKH = client.KhachHangs.ToList();
                foreach (var employeeKH in eKH)
                {
                    dbcontext.KhachHangs.Remove(employeeKH);
                }


                dbcontext.TKs.Remove(deparment);
                dbcontext.KhachHangs.Remove(client);

                dbcontext.SaveChanges();
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa tài khoản thành công.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }




            Response.Redirect("Account");
        }



        

    }
}