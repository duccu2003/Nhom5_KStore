using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class UpdateInformation : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

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
        protected void btnAddInformationBV_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
            {
                string insertBVQuery = "INSERT INTO TinTuc (HinhAnhBV, DuongDanBV, TieuDe, NoiDungBV) VALUES (@HinhAnhBV, @DuongDanBV, @TieuDe, @NoiDungBV)";

                using (SqlCommand insertPopCommand = new SqlCommand(insertBVQuery, connection))
                {
                    insertPopCommand.Parameters.AddWithValue("@HinhAnhBV", txtHinhBV.Text);
                    insertPopCommand.Parameters.AddWithValue("@DuongDanBV", txtLinkBV.Text);
                    insertPopCommand.Parameters.AddWithValue("@TieuDe", txtTieuDeBV.Text);
                    insertPopCommand.Parameters.AddWithValue("@NoiDungBV", txtNoiDungBV.Text);

                    connection.Open();
                    insertPopCommand.ExecuteNonQuery();

                    connection.Close();

                }
                Response.Redirect(Request.RawUrl);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm nội dung thành công.</div>");
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
        public IQueryable<TinTuc> GetDeparments()
        {
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();



            IQueryable<TinTuc> product = dbcontext.TinTucs;


            return product;

        }

        public IQueryable<Banner> GetDeparmentsBanner()
        {
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();



            IQueryable<Banner> product = dbcontext.Banners;


            return product;

        }

        public IQueryable<VideoThongTin> GetDeparmentsVideoThongTin()
        {
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();



            IQueryable<VideoThongTin> product = dbcontext.VideoThongTins;


            return product;

        }
        protected void btnAddInformationVideo_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
            {
                string insertBVQuery = "INSERT INTO VideoThongTin (DuongDanV) VALUES (@DuongDanV)";

                using (SqlCommand insertPopCommand = new SqlCommand(insertBVQuery, connection))
                {

                    insertPopCommand.Parameters.AddWithValue("@DuongDanV", txtLinkVideo.Text);


                    connection.Open();
                    insertPopCommand.ExecuteNonQuery();

                    connection.Close();

                }
                Response.Redirect(Request.RawUrl);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm nội dung thành công.</div>");
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

        protected void ListView1TinTuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ListView1Banner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ListView1VideoThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnAddBanner_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
            {
<<<<<<< HEAD
                string temTieuDe = txtBannerTitle.Text;
                string insertBVQuery = "INSERT INTO Banner (DuongDan, TieuDe) VALUES (@DuongDan, @TieuDe)";
=======
                string insertBVQuery = "INSERT INTO Banner (DuongDan) VALUES (@DuongDan)";
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                string fileNameBanner = null;
                string filePathBanner = null;
                string fileimgBanner =null;
                string relativePathBanner;
                string uploadFolderPath = Server.MapPath("Content/image-banner");
                string finalFolderPath = Path.Combine(uploadFolderPath);

                if (!string.IsNullOrEmpty(fileUploadBanner?.FileName))
                {
                    fileNameBanner = Path.GetFileName(fileUploadBanner.FileName);
                    filePathBanner = Path.Combine(finalFolderPath, fileNameBanner);

                    // Lưu tệp ảnh
                    fileUploadBanner.SaveAs(filePathBanner);

                    // Tạo đường dẫn relative
                    relativePathBanner = filePathBanner.Substring(filePathBanner.IndexOf("Content"));
                    fileimgBanner = relativePathBanner;
                    using (SqlCommand insertPopCommand = new SqlCommand(insertBVQuery, connection))
                    {


                        insertPopCommand.Parameters.AddWithValue("@DuongDan", fileimgBanner);
<<<<<<< HEAD
                        insertPopCommand.Parameters.AddWithValue("@TieuDe", temTieuDe);
=======

>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498

                        connection.Open();
                        insertPopCommand.ExecuteNonQuery();

                        connection.Close();

                    }
                    Response.Redirect(Request.RawUrl);
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm nội dung thành công.</div>");
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
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Thêm nội dung không thành công.</div>");
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


        protected void btnDelBanner_Click(object sender, EventArgs e)
        {

            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
            System.Web.UI.WebControls.Button btnXoa = (System.Web.UI.WebControls.Button)sender;

            // Lấy mã sản phẩm từ CommandArgument của nút
            int maBanner = int.Parse(btnXoa.CommandArgument);



            Banner banner = dbcontext.Banners.FirstOrDefault(s => s.MaBanner == maBanner);
            if (banner != null)
            {
                string sql = "DELETE FROM Banner WHERE MaBanner = @MaBanner";

                SqlParameter MaBanner = new SqlParameter("@MaBanner", maBanner);

                dbcontext.Database.ExecuteSqlCommand(sql, MaBanner);


                dbcontext.SaveChanges();

                Response.Redirect(Request.RawUrl);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa nội dung thành công.</div>");
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

        protected void btDelTinTuc_Click(object sender, EventArgs e)
        {

            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
            System.Web.UI.WebControls.Button btnXoa = (System.Web.UI.WebControls.Button)sender;

            // Lấy mã sản phẩm từ CommandArgument của nút
            int maBV = int.Parse(btnXoa.CommandArgument);



            TinTuc tintuc = dbcontext.TinTucs.FirstOrDefault(s => s.MaBV == maBV);
            if (tintuc != null)
            {
                string sql = "DELETE FROM TinTuc WHERE MaBV = @MaBV";

                SqlParameter maBaiV = new SqlParameter("@MaBV", maBV);

                dbcontext.Database.ExecuteSqlCommand(sql, maBaiV);


                dbcontext.SaveChanges();

                Response.Redirect(Request.RawUrl);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa nội dung thành công.</div>");
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

        protected void btDelVideoThongTin_Click(object sender, EventArgs e)
        {

            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
            System.Web.UI.WebControls.Button btnXoa = (System.Web.UI.WebControls.Button)sender;

            // Lấy mã sản phẩm từ CommandArgument của nút
            int maV = int.Parse(btnXoa.CommandArgument);



            VideoThongTin video = dbcontext.VideoThongTins.FirstOrDefault(s => s.MaV == maV);
            if (video != null)
            {
                string sql = "DELETE FROM VideoThongTin WHERE MaV = @MaV";

                SqlParameter maVParam = new SqlParameter("@MaV", maV);

                dbcontext.Database.ExecuteSqlCommand(sql, maVParam);


                dbcontext.SaveChanges();

                Response.Redirect(Request.RawUrl);

                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa nội dung thành công.</div>");
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