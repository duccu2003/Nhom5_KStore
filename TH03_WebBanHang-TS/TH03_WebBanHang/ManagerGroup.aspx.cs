using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class ManagerGroup : System.Web.UI.Page
    {
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
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public string url = HttpContext.Current.Request.Url.ToString();
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ListView1.DataSource = null;
            ListView1.DataSourceID = null;
            ListView1.DataBind();
            GetDeparments();



        }
        public IQueryable<Nhom> GetDeparments()
        {
            string searchText = searchinputA.Text;

            //IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
            var departments = dbcontext.Nhoms.OrderBy(s => s.MaNhom);

            IQueryable<Nhom> nhom = departments.OrderBy(s => s.MaNhom);
            IQueryable<Nhom> nhomSearch = nhom.Where(p => p.MaNhom.Contains(searchText) || p.TenNhom.Contains(searchText));

            if (string.IsNullOrEmpty(searchText))
            {
                return nhom.OrderByDescending(s=>s.SanPhams.Count());
            }
            else
            {
                return nhomSearch;
            }
        }

    }
}