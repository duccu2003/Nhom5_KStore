using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class AccountOrder : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public int MaKH;
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

            if (user.Any(p => /*p.TrangThai == true &&*/ p.Email == EmailKhach))
            {
                if (!IsPostBack)
                {
                    var str = Request.QueryString["Deptid"].ToString();

                    

                    KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.Email == str || p.Email == EmailKhach);
                    
                }
            }
            

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
            var str = Request.QueryString["Deptid"].ToString();
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;

            KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.Email == str || p.Email == EmailKhach);


            ListView1.DataSource = null;
            ListView1.DataSourceID = null;
            ListView1.DataBind();
            GetDeparments(deparments.Email);





        }
        public IQueryable<ChiTietDonHang> GetDeparments2()
        {
            string searchTextA = searchinputA.Text;
            //IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
            string searchText = Request.QueryString["searchText"];
            //HttpCookie Email = Request.Cookies["Email"];

            string Email = Request.QueryString["Deptid"].ToString();

            

            var departments = dbcontext.ChiTietDonHangs.OrderBy(s => s.MaDH).Where(s=> s.DonHang.KhachHang.Email == Email);
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
        public IQueryable<DonHang> GetDeparments(string Email)
        {
            string searchTextA = searchinputA.Text;
            string searchText = Request.QueryString["searchText"];

            
            HttpCookie cokieEmail = Request.Cookies["Email"];
            string EmailKhach;
            if (cokieEmail == null) EmailKhach = Sign.email;
            else EmailKhach = cokieEmail.Value;

            KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.Email == Email || p.Email == EmailKhach);
            MaKH = deparments.MaKH;

            string kh = MaKH.ToString();
            var donCT = dbcontext.ChiTietDonHangs.Where(s => s.KH == MaKH && (s.DonHang.KhachHang.Email == Email || s.DonHang.KhachHang.Email == EmailKhach));
            var don = dbcontext.DonHangs.OrderBy(s1 => s1.MaDH).Where(s=> s.KH == MaKH && (s.KhachHang.Email == Email || s.KhachHang.Email == EmailKhach));
            int searhtoint;
            int.TryParse(searchTextA, out searhtoint);
            IQueryable<ChiTietDonHang> chiTiets = donCT.Where(p => p.TenSP.Contains(searchTextA) || p.MaCTDH.Contains(searchTextA) || p.KH == searhtoint || p.MaDH.Contains(searchTextA) || p.MaSP.Contains(searchTextA));

            var donofKH = don.Where(s =>  s.KhachHang.Email == Email || s.KhachHang.Email == EmailKhach /*&& s.KH == Account.MaKhach*/);


            if (!string.IsNullOrEmpty(searchTextA))
            {
                DateTime searchDate;
                if (DateTime.TryParse(searchTextA, out searchDate))
                {
                    // Nếu chuyển đổi thành công, tìm kiếm ngày
                    IQueryable<ChiTietDonHang> dateorder = donCT.Where(p => p.Ngay.ToString().Contains(searchTextA));
                    return donofKH.Where(p =>  p.Ngay == searchDate);
                }
                else
                {
                    // Filter by text
                    return donofKH.Where(p =>  p.MaDH.Contains(searchTextA));
                }

            }
            
            else if (!string.IsNullOrEmpty(searchText))
            {
                return don.Where(p =>  p.MaDH == searchText);
            }

            else return don.OrderByDescending(s=>s.Ngay);


        }
    }
}