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
            if (user.Any(p => p.TrangThai == true && p.Email == Sign.email))
            {
                if (!IsPostBack)
                {
                    var str = Request.QueryString["Deptid"].ToString();

                    int clientStr;
                    int.TryParse(str, out clientStr);

                    KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.MaKH == Account.makh);
                    ChiTietDonHang chitet = dbcontext.ChiTietDonHangs.FirstOrDefault(p => p.KH == clientStr);
                }
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

            //KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.MaKH == Account.makh);
            //MaKH = Account.makh - 1;

            //string kh = MaKH.ToString();
            //var don = dbcontext.ChiTietDonHangs.Where(s => s.KH == MaKH);
            //int searhtoint;
            //int.TryParse(searchTextA, out searhtoint);


            //if (!string.IsNullOrEmpty(searchTextA))
            //{
            //    DateTime searchDate;
            //    if (DateTime.TryParse(searchTextA, out searchDate))
            //    {
            //        // Nếu chuyển đổi thành công, tìm kiếm ngày
            //        IQueryable<ChiTietDonHang> dateorder = don.Where(p => p.Ngay.ToString().Contains(searchTextA));
            //        return dateorder;
            //    }
            //    else return chiTiets;

            //}
            //else if (!string.IsNullOrEmpty(searchText))
            //{
            //    return don.Where(p => p.MaCTDH == searchText || p.MaDH == searchText);
            //}

            //else return don;

            //IQueryable<ChiTietDonHang> chiTiets = don.Where(p => p.TenSP.Contains(searchTextA) || p.MaCTDH.Contains(searchTextA) || p.KH == searhtoint || p.MaDH.Contains(searchTextA) || p.MaSP.Contains(searchTextA));

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

            int maK;
            int.TryParse(searchTextA, out maK);

            //if (!string.IsNullOrEmpty(searchTextA))
            //{
            //    DateTime searchDate;
            //    if (DateTime.TryParse(searchTextA, out searchDate))
            //    {
            //        // Assuming you want to filter by date
            //        return don.Where(p => p.Ngay == searchDate);
            //    }
            //    else
            //    {
            //        // Filter by text
            //        return don.Where(p => p.MaDH.Contains(searchTextA) || p.KH == maK);
            //    }
            //}
            //else if (!string.IsNullOrEmpty(searchText))
            //{
            //    return don.Where(p => p.MaDH == searchText);
            //}

            //return don;
            //string searchTextA = searchinputA.Text;
            ////IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
            //string searchText = Request.QueryString["searchText"];

            KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.MaKH == Account.makh);
            MaKH = Account.MaKhach;

            string kh = MaKH.ToString();
            var donCT = dbcontext.ChiTietDonHangs.Where(s => s.KH == MaKH);
            var don = dbcontext.DonHangs.OrderBy(s1 => s1.MaDH);
            int searhtoint;
            int.TryParse(searchTextA, out searhtoint);
            IQueryable<ChiTietDonHang> chiTiets = donCT.Where(p => p.TenSP.Contains(searchTextA) || p.MaCTDH.Contains(searchTextA) || p.KH == searhtoint || p.MaDH.Contains(searchTextA) || p.MaSP.Contains(searchTextA));

            var donofKH = don.Where(s => s.KH == Account.MaKhach);


            if (!string.IsNullOrEmpty(searchTextA))
            {
                DateTime searchDate;
                if (DateTime.TryParse(searchTextA, out searchDate))
                {
                    // Nếu chuyển đổi thành công, tìm kiếm ngày
                    IQueryable<ChiTietDonHang> dateorder = donCT.Where(p => p.Ngay.ToString().Contains(searchTextA));
                    return donofKH.Where(p => p.Ngay == searchDate);
                }
                else
                {
                    // Filter by text
                    return donofKH.Where(p => p.MaDH.Contains(searchTextA));
                }

            }
            //else if (!string.IsNullOrEmpty(searchText))
            //{
            //    return don.Where(p => p.MaCTDH == searchText || p.MaDH == searchText);
            //}
            else if (!string.IsNullOrEmpty(searchText))
            {
                return don.Where(p => p.MaDH == searchText);
            }

            else return don.Where(s => s.KH == Account.MaKhach).OrderByDescending(s=>s.Ngay);


        }
        //public IQueryable<ChiTietDonHang> GetDeparments()
        //{
        //    string searchTextA = searchinputA.Text;
        //    //IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
        //    string searchText = Request.QueryString["searchText"];

        //    KhachHang deparments = dbcontext.KhachHangs.SingleOrDefault(p => p.MaKH == Account.makh);
        //    MaKH = Account.makh - 1;

        //    string kh = MaKH.ToString();
        //    var don = dbcontext.ChiTietDonHangs.Where(s => s.KH == MaKH);
        //    int searhtoint;
        //    int.TryParse(searchTextA, out searhtoint);
        //    IQueryable<ChiTietDonHang> chiTiets = don.Where(p => p.TenSP.Contains(searchTextA) || p.MaCTDH.Contains(searchTextA) || p.KH== searhtoint || p.MaDH.Contains(searchTextA) || p.MaSP.Contains(searchTextA));


        //    if (!string.IsNullOrEmpty(searchTextA))
        //    {
        //        DateTime searchDate;
        //        if (DateTime.TryParse(searchTextA, out searchDate))
        //        {
        //            // Nếu chuyển đổi thành công, tìm kiếm ngày
        //            IQueryable<ChiTietDonHang> dateorder = don.Where(p => p.Ngay.ToString().Contains(searchTextA));
        //            return dateorder;
        //        }
        //        else return chiTiets;

        //    }
        //    else if (!string.IsNullOrEmpty(searchText))
        //    {
        //        return don.Where(p => p.MaCTDH == searchText || p.MaDH == searchText);
        //    }

        //    else return don;




        //}

    }
}