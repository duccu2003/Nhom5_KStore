using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class ManagerOrder : System.Web.UI.Page
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
        public IQueryable<ChiTietDonHang> GetDeparments2()
        {
            string searchTextA = searchinputA.Text;
            //IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
            string searchText = Request.QueryString["searchText"];

            var departments = dbcontext.ChiTietDonHangs.OrderBy(s => s.MaDH);
            int maK;
            int.TryParse(searchTextA, out maK);
            IQueryable<ChiTietDonHang> chiTiets = departments.Where(p => p.TenSP.Contains(searchTextA) || p.MaCTDH.Contains(searchTextA) || p.KH == maK || p.MaDH.Contains(searchTextA) || p.MaSP.Contains(searchTextA));

            if (!string.IsNullOrEmpty(searchTextA))
            {
                DateTime searchDate;
                if (DateTime.TryParse(searchTextA, out searchDate))
                {
                    // Nếu chuyển đổi thành công, tìm kiếm ngày
                    IQueryable<ChiTietDonHang> dateorder = departments.Where(p => p.Ngay.ToString().Contains(searchTextA));
                    return dateorder;
                }
                else return chiTiets;

            }
            else if (!string.IsNullOrEmpty(searchText))
            {
                return departments.Where(p => p.MaCTDH == searchText || p.MaDH == searchText);
            }

            else return departments;




        }
        public IQueryable<DonHang> GetDeparments()
        {
            string searchTextA = searchinputA.Text;
            string searchText = Request.QueryString["searchText"];

            var don = dbcontext.DonHangs.OrderBy(s1 => s1.MaDH);
            int maK;
            int.TryParse(searchTextA, out maK);

            if (!string.IsNullOrEmpty(searchTextA))
            {
                DateTime searchDate;
                if (DateTime.TryParse(searchTextA, out searchDate))
                {
                    // Assuming you want to filter by date
                    return don.Where(p => p.Ngay == searchDate);
                }
                else
                {
                    // Filter by text
                    return don.Where(p => p.MaDH.Contains(searchTextA) || p.KH == maK);
                }
            }
            else if (!string.IsNullOrEmpty(searchText))
            {
                return don.Where(p => p.MaDH == searchText);
            }

            return don.OrderByDescending(s=>s.Ngay);
        }
    }
}