using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class AddGroup : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public string url = HttpContext.Current.Request.Url.ToString();
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
        }
        protected void btnAddIDOL_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities gp = new QL_KPOPStoreEntities();







                string nhomFolder;

                string relativePathGOMem;
                string relativePathGOLogo;

                if (gp.Nhoms.Any(p => p.MaNhom == txtMaiDol.Text))
                {

                    //Response.Write("<script>alert('Sản phẩm đã tồn tại');</script>");
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Nhóm nhạc/Nghệ sĩ đã tồn tại!</div>");
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
                    using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
                {
                    nhomFolder = txtNameiDol.Text.ToLower().Replace(" ", "");
                    string targetDirectoryGPmem = Server.MapPath("Content/image-group-kpop/");
                    string targetDirectoryGPLogo = Server.MapPath("Content/icon-group-kpop/");
                    string fileNameLogo = Path.GetFileName(fileUploadimgLogoiDol.FileName);
                    string targetPathLogo = Path.Combine(targetDirectoryGPLogo, fileNameLogo);
                    relativePathGOLogo = targetPathLogo.Substring(targetPathLogo.IndexOf("Content"));
                    string fileNameMem = Path.GetFileName(fileUploadimgMemberiDol.FileName);
                    string targetPathMem = Path.Combine(targetDirectoryGPmem, fileNameMem);
                    relativePathGOMem = targetPathMem.Substring(targetPathMem.IndexOf("Content"));
                    // Kiểm tra xem có ảnh nào được chọn
                    if (fileUploadimgMemberiDol.HasFile || fileUploadimgLogoiDol.HasFile)
                    {
                        // Kiểm tra và lưu ảnh logo
                        if (fileUploadimgMemberiDol.HasFile)
                        {


                            fileUploadimgMemberiDol.SaveAs(targetPathMem);
                        }
                        else
                        {
                            // Nếu không có ảnh logo, đặt giá trị null
                            relativePathGOLogo = null;
                        }

                        // Kiểm tra và lưu ảnh member
                        if (fileUploadimgLogoiDol.HasFile)
                        {


                            fileUploadimgLogoiDol.SaveAs(targetPathLogo);
                        }
                        else
                        {
                            // Nếu không có ảnh member, đặt giá trị null
                            relativePathGOMem = null;
                        }

                        // Kiểm tra xem thư mục đích có tồn tại, nếu không thì tạo thư mục
                        if (!Directory.Exists(targetDirectoryGPmem))
                        {
                            Directory.CreateDirectory(targetDirectoryGPmem);
                        }
                        using (var context = new QL_KPOPStoreEntities())
                        {
                            var newIdols = new Nhom()
                            {
                                MaNhom = txtMaiDol.Text.Trim(),
                                TenNhom = txtNameiDol.Text.Trim(),
                                AnhNhom = relativePathGOMem,
                                DuongDan = relativePathGOLogo,
                            };

                            context.Nhoms.Add(newIdols);
                            context.SaveChanges();
                        }
                        Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm Nhóm nhạc/Nghệ sĩ thành công.</div>");
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
                        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Chưa đủ thông tin được yêu cầu thêm Nhóm nhạc/Nghệ sĩ không thành công.</div>");
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
}