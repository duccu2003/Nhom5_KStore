using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class ManagerAccount : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;
            var db = new QL_KPOPStoreEntities();
            if (user.Any(p => Sign.email != null && ((p.Email == Sign.email && Sign.email == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.Email == Sign.email))))
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
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ListView1.DataSource = null;
            ListView1.DataSourceID = null;
            ListView1.DataBind();
            GetDeparments();



        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public IQueryable<KhachHang> GetDeparments()
        {
            string searchText = searchinputA.Text;
            var client = dbcontext.KhachHangs;

            // Sử dụng Contains() thay vì == để tìm kiếm chuỗi tìm kiếm trong các trường
            IQueryable<KhachHang> khachhang = client.Where(p => p.GioiTinh.Contains(searchText) || p.DiaChi.Contains(searchText) || p.DienThoai.Contains(searchText) || p.HoTen.Contains(searchText) || p.Email.Contains(searchText) || p.TK.Email.Contains(searchText) || p.TK.Quyen.Contains(searchText));

            // Nếu không có chuỗi tìm kiếm nào được nhập, trả về toàn bộ danh sách khách hàng
            if (string.IsNullOrEmpty(searchText))
            {
                return client.OrderBy(e => e.MaTK).OrderByDescending(s=>s.MaKH); // Replace 'e.SomeProperty' with the property you want to sort by

            }
            else
            {
                return khachhang.OrderBy(e => e.MaTK).OrderByDescending(s => s.MaKH);// Replace 'e.SomeProperty' with the property you want to sort by

            }
        }
    }
}