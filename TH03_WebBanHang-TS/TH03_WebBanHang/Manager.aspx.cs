using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity.Migrations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TH03_WebBanHang
{
    public partial class Manager : System.Web.UI.Page
    {
        public int Year { get; set; }
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;
            var db = new QL_KPOPStoreEntities();
            //if (user.Any(p => (p.Email == "Admin" && p.TrangThai == true && p.Email == Sign.email && Sign.email == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.TrangThai == true && p.Email == Sign.email)))
            //{

            //}
            // Otherwise, display an error message

            if (!VerifyToken())
            {
                // Redirect to the login page
                Response.Redirect("Sign.aspx");
            }
            else
            {
                HttpCookie Email = Request.Cookies["Email"];
                string EmailKhach;
                if (Email == null) EmailKhach = Sign.email;
                else EmailKhach = Email.Value;
                if ( user.Any(p => EmailKhach != null && ((p.Email == EmailKhach && EmailKhach == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.Email == EmailKhach))))
                {

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

            if (!IsPostBack)
            {
                Year = DateTime.Now.Year; // Sử dụng năm hiện tại làm mặc định
                BindData(); BindDataBieuDoTron();
                //DateTime tim = DateTime.Now;
                //int hh = p.GetHour(tim);
                //int mm = p.GetMinute(tim);
                //lbTime.Text = DateTime.Now.ToString("hh:mm");
                //lbTime.Text = DateTime.Now.ToString("HH:mm:ss");


            }
        }
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Shop.SQL_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Year", Year);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        //private void RegisterScript(string chartName, DataTable dt)
        //{
        //    string jsonLabels = Newtonsoft.Json.JsonConvert.SerializeObject(dt.AsEnumerable().Select(r => r[0].ToString()));
        //    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dt.AsEnumerable().Select(r => r[1]));

        //    string script = $@"
        //    <script>
        //    document.addEventListener('DOMContentLoaded', (event) => {{
        //        var labels = {jsonLabels};
        //        var data = {jsonData};
        //        var backgroundColors = labels.map(() => {{
        //            var letters = '0123456789ABCDEF';
        //            var color = '#';
        //            for (var i = 0; i < 6; i++) {{
        //                color += letters[Math.floor(Math.random() * 16)];
        //            }}
        //            return color;
        //        }});

        //        var ctx = document.getElementById('myPieChart{chartName}').getContext('2d');
        //        new Chart(ctx, {{
        //            type: 'pie',
        //            data: {{
        //                labels: labels,
        //                datasets: [{{
        //                    data: data,
        //                    backgroundColor: backgroundColors,
        //                }}],
        //            }},
        //            options: {{
        //                responsive: true,
        //                legend: {{
        //                    position: 'top',
        //                }},
        //                animation: {{
        //                    animateScale: true,
        //                    animateRotate: true
        //                }}
        //            }}
        //        }});
        //    }});
        //    </script>";

        //    ClientScript.RegisterStartupScript(this.GetType(), $"PieChartScript{chartName}", script);
        //}
        private void RegisterScript(string chartName, DataTable dt)
        {
            string jsonLabels = Newtonsoft.Json.JsonConvert.SerializeObject(dt.AsEnumerable().Select(r => r[0].ToString()));
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dt.AsEnumerable().Select(r => r[1]));

            string script = $@"
    <script>
    document.addEventListener('DOMContentLoaded', (event) => {{
        var labels = {jsonLabels};
        var data = {jsonData};
        var backgroundColors = labels.map(() => {{
            var letters = '0123456789ABCDEF';
            var color = '#';
            for (var i = 0; i < 6; i++) {{
                color += letters[Math.floor(Math.random() * 16)];
            }}
            return color;
        }});

        function formatCurrency(value) {{
            return value.toLocaleString('vi-VN', {{ style: 'currency', currency: 'VND' }});
        }}

        var ctx = document.getElementById('myPieChart{chartName}').getContext('2d');
        new Chart(ctx, {{
            type: 'pie',
            data: {{
                labels: labels,
                datasets: [{{
                    data: data,
                    backgroundColor: backgroundColors,
                }}],
            }},
            options: {{
                responsive: true,
                legend: {{
                    position: 'top',
                }},
                tooltips: {{
                    callbacks: {{
                        label: function(tooltipItem, data) {{
                            var label = data.labels[tooltipItem.index] || '';
                            var value = data.datasets[0].data[tooltipItem.index];
                            return label + ': ' + formatCurrency(value);
                        }}
                    }}
                }},
                animation: {{
                    animateScale: true,
                    animateRotate: true
                }}
            }}
        }});
    }});
    </script>";

            ClientScript.RegisterStartupScript(this.GetType(), $"PieChartScript{chartName}", script);
        }

        protected void BindDataBieuDoTron()
        {
            DataTable dtLoai = GetData("SELECT Loai.TenLoai, SUM(ChiTietDonHang.ThanhTien) AS Revenue FROM ChiTietDonHang INNER JOIN SanPham ON ChiTietDonHang.MaSP = SanPham.MaSP INNER JOIN Loai ON SanPham.MaLoai = Loai.MaLoai WHERE YEAR(ChiTietDonHang.Ngay) = @Year GROUP BY Loai.TenLoai");

            DataTable dtNhom = GetData("SELECT Nhom.TenNhom, SUM(ChiTietDonHang.ThanhTien) AS Revenue FROM ChiTietDonHang INNER JOIN SanPham ON ChiTietDonHang.MaSP = SanPham.MaSP INNER JOIN Nhom ON SanPham.MaNhom = Nhom.MaNhom WHERE YEAR(ChiTietDonHang.Ngay) = @Year GROUP BY Nhom.TenNhom");

            DataTable dtAlbum = GetData("SELECT SanPham.TenSP, SUM(ChiTietDonHang.ThanhTien) AS Revenue FROM ChiTietDonHang INNER JOIN SanPham ON ChiTietDonHang.MaSP = SanPham.MaSP INNER JOIN Loai ON SanPham.MaLoai = Loai.MaLoai WHERE Loai.TenLoai LIKE '%album%' AND YEAR(ChiTietDonHang.Ngay) = @Year GROUP BY SanPham.TenSP ORDER BY Revenue DESC");

            DataTable dtChiNhanh = GetData("SELECT ChiNhanh.TenCN, SUM(ChiTietDonHang.ThanhTien) AS Revenue FROM ChiTietDonHang INNER JOIN DonHang ON ChiTietDonHang.MaDH = DonHang.MaDH INNER JOIN ChiNhanh ON DonHang.MaCN = ChiNhanh.MaCN WHERE YEAR(ChiTietDonHang.Ngay) = @Year GROUP BY ChiNhanh.TenCN");

            RegisterScript("Loai", dtLoai);
            RegisterScript("Nhom", dtNhom);
            RegisterScript("Album", dtAlbum);
            RegisterScript("ChiNhanh", dtChiNhanh);
        }

        protected void BindData()
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            DataTable dt = new DataTable();
            //string dataSource = "DUC-LAPTOP\\NGUYENHOANGDUC";
            //string initialCatalog = "QL_KPOPStore";
            //string sqlTK = "sa";
            //string sqlMK = "1";
            //string dataSource = Shop.SQL_dataSource /*"DUC-LAPTOP\\NGUYENHOANGDUC"*/;
            //string initialCatalog = Shop.SQL_initialCatalog /*"QL_KPOPStore"*/;
            //string sqlTK = Shop.SQL_sqlTK /*"sa"*/;
            //string sqlMK = Shop.SQL_sqlMK  /*"1"*/;
            //string connectionString = "Data Source=" + dataSource + ";Initial Catalog=" + initialCatalog + ";User ID=" + sqlTK + ";Password=" + sqlMK + ";";

            using (SqlConnection con = new SqlConnection(Shop.SQL_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT MONTH(ChiTietDonHang.Ngay) AS Month, SUM(ChiTietDonHang.ThanhTien) AS Revenue FROM ChiTietDonHang INNER JOIN SanPham ON ChiTietDonHang.MaSP = SanPham.MaSP WHERE YEAR(Ngay) = @Year GROUP BY MONTH(Ngay)", con);
                cmd.Parameters.AddWithValue("@Year", Year);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            //GridViewMonthlyRevenue.DataSource = dt;
            //GridViewMonthlyRevenue.DataBind();
            var paidOrderCount = dbcontext.ChiTietDonHangs
                    .Where(s => s.GiaoDich == true)
                    .Select(s => s.MaDH)
                    .Distinct()
                    .Count();

            // Count unpaid orders
            var unpaidOrderCount = dbcontext.ChiTietDonHangs
                .Where(s => s.GiaoDich == false)
                .Select(s => s.MaDH)
                .Distinct()
                .Count();
            var isSignin = dbcontext.TKs.Any(s => s.Email == EmailKhach);
            var accountPer = dbcontext.TKs.Any(s => s.Email == EmailKhach && (s.Quyen == "Admin" || s.Quyen == "Manager"));
            if (!isSignin && EmailKhach == null)
            {
                Response.Redirect("Error/401");
            }
            else
            {
                if (accountPer)
                {
                    var account = dbcontext.TKs.FirstOrDefault(s => s.Email == EmailKhach && (s.Quyen == "Admin" || s.Quyen == "Manager"));
                    lbAccountCheck.Text = account.Email;
                }
                else
                {
                    Response.Redirect("Error/401");
                }
            }

            // Update the labels with the counts
            lbSDDTT.Text = paidOrderCount.ToString();
            lbSDCTT.Text = unpaidOrderCount.ToString();

            var doanhso = dbcontext.DoanhThus.Any();
            if (doanhso)
            {
                lbVNPay.Text = "0";
                lbMomo.Text = "0";
                lbCod.Text = "0";
                lbVNPayBill.Text = "0";
                lbMomoBill.Text = "0";
                lbCodBill.Text = "0";
                dauphantram.InnerText = "+";
                phantram.InnerText = "0";
                lbTotalAll.Text = dbcontext.DoanhThus.Sum(s => s.DoanhThuNgay).ToString();
                //LabelTotalRevenue.Text = CalculateTotalRevenue(dt).ToString("N0") + "đ"; // Format as currency
                
                var hadMomo = dbcontext.ChiTietDonHangs.Any(s => s.DonHang.PhuongThuc == "Momo");

                var hadVNPAY = dbcontext.ChiTietDonHangs.Any(s => s.DonHang.PhuongThuc == "VNPay");
                var hadCod = dbcontext.ChiTietDonHangs.Any(s => s.DonHang.PhuongThuc == "COD");

                if (hadVNPAY)
                {
                    lbVNPay.Text = dbcontext.ChiTietDonHangs.Where(s => s.DonHang.PhuongThuc == "VNPay").Sum(s => s.ThanhTien).ToString();

                    lbVNPayBill.Text = dbcontext.DonHangs.Where(s=>s.PhuongThuc == "VNPay").Count().ToString();
                }
                if (hadMomo)
                {
                    lbMomo.Text = dbcontext.ChiTietDonHangs.Where(s => s.DonHang.PhuongThuc == "Momo").Sum(s => s.ThanhTien).ToString();
                    lbMomoBill.Text = dbcontext.DonHangs.Where(s => s.PhuongThuc == "Momo").Count().ToString();
                }
                if (hadCod)
                {
                    lbCod.Text = dbcontext.ChiTietDonHangs.Where(s => s.DonHang.PhuongThuc == "COD").Sum(s => s.ThanhTien).ToString();
                    lbCodBill.Text = dbcontext.DonHangs.Where(s => s.PhuongThuc == "COD").Count().ToString();
                }
                int month = DateTime.Now.Month;
                decimal doanhThuThangTruoc = 0;
                var haddoanhThuThangTruoc = dbcontext.DoanhThus.Any(s => s.Thang == month - 1);
                if (haddoanhThuThangTruoc)
                {
                    doanhThuThangTruoc = (decimal)dbcontext.DoanhThus.Where(s => s.Thang == month - 1).Sum(s => s.DoanhThuNgay);
                }
                decimal doanhThuThangNay = (decimal)dbcontext.DoanhThus.Where(s => s.Thang == month).Sum(s => s.DoanhThuNgay);
                decimal tichDoanhThu = 0;

                if (doanhThuThangTruoc == 0)
                {
                    tichDoanhThu = 100;

                }
                else tichDoanhThu = (doanhThuThangNay - doanhThuThangTruoc) / doanhThuThangTruoc * 100;

                if (doanhThuThangNay > doanhThuThangTruoc)
                {
                    dauphantram.InnerText = "+";
                    string sophantram = tichDoanhThu.ToString("F2");
                    phantram.InnerText = sophantram;
                    Response.Write("<style>.textphantram{color:limegreen;}</style>");

                }
                else
                {
                    dauphantram.InnerText = "-";
                    string sophantram = tichDoanhThu.ToString("F2");
                    phantram.InnerText = sophantram;
                    Response.Write("<style>.textphantram{color:#ff3232;}</style>");

                }
                
            }

            else
            {
                lbTotalAll.Text =  "0";
                lbCod.Text = "0";
                lbVNPay.Text = "0";
                lbMomo.Text = "0";
                lbVNPayBill.Text = "0";
                lbMomoBill.Text = "0";
                lbCodBill.Text = "0";

            }


        }

        protected decimal CalculateTotalRevenue(DataTable dt)
        {
            decimal totalRevenue = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalRevenue += Convert.ToDecimal(row["Revenue"]);
            }
            return totalRevenue;
        }
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public double GetTotalRevenue()
        {
            var total = dbcontext.ChiTietDonHangs.Where(s => s.GiaoDich == true).Sum(s => s.ThanhTien);
            double totalRevenue = total;
            return totalRevenue;
        }

        //private int startRowIndex, maximumRows;

        protected void SearchButtonGetDeparments_Click(object sender, EventArgs e)
        {
            //ListView1.DataSource = null;
            //ListView1.DataSourceID = null;
            //ListView1.DataBind();
            GetDeparmentsRevenue();



        }
        public IQueryable<ChiTietDonHang> GetDeparmentsRevenue()
        {
            IQueryable<ChiTietDonHang> order = dbcontext.ChiTietDonHangs;

            return order.OrderBy(e => e.Ngay);
        }
        //public  IQueryable<DoanhThu>  GetRevernue()
        //{
        //    // Lấy dữ liệu doanh thu từ tháng hiện tại cho năm hiện tại
        //    var doanhThu = dbcontext.DoanhThus
        //      /*.Where(d => d.Nam == DateTime.Now.Year && d.Ngay <= DateTime.Now.Day)*/.AsQueryable();

        //    return doanhThu;
        //}

        public IQueryable<DoanhThu> GetRevernueRevenue()
        {
            // Lấy dữ liệu doanh thu từ tháng hiện tại cho năm hiện tại
            var doanhThu = dbcontext.DoanhThus
                .Where(d => d.Nam == DateTime.Now.Year) // Ensure the year filter is applied correctly
                .OrderBy(d => d.Ngay)
                .ThenBy(d => d.Thang);

            return doanhThu.Take(15);
        }










        protected void ListView1Branch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public IQueryable<ChiNhanh> GetDeparmentsBranch()
        {
            IQueryable<ChiNhanh> branch = dbcontext.ChiNhanhs;

            return branch;
        }

        protected void btnCPass_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;

            var user = from u in dbcontext.TKs
                       select u;
            var tk = user.SingleOrDefault(p => p.Email == EmailKhach);

            Response.Redirect("ChangePassword.aspx?Deptid=" + tk.Email);
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            var user = from u in dbcontext.TKs
                       select u;

            using (var dbContext = new QL_KPOPStoreEntities())
            {
                var disabledTKs = dbContext.TKs.FirstOrDefault(p => p.TrangThai == true && p.Email == EmailKhach);
                var disabledKhs = dbContext.KhachHangs.FirstOrDefault(p => p.TrangThai == true && p.Email == EmailKhach);
                var Tks = dbContext.TKs.Any(p => p.TrangThai == true && p.Email == EmailKhach);
                var Khs = dbContext.KhachHangs.Any(p => p.TrangThai == true && p.Email == EmailKhach);


                if (Tks)
                {

                    disabledTKs.TrangThai = false;
                    dbContext.TKs.AddOrUpdate(disabledTKs);
                    if (Khs)
                    {
                        disabledKhs.TrangThai = false;
                        dbContext.KhachHangs.AddOrUpdate(disabledKhs);
                    }
                    dbContext.SaveChanges();
                }

                dbContext.SaveChanges();
                dbcontext.SaveChanges();


                Response.Cookies["AuthToken"].Value = null;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Key"].Value = null;
                Response.Cookies["Key"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Email"].Value = null;
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("Sign.aspx");

            }


        }
        private bool VerifyToken()
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            HttpCookie Key = Request.Cookies["Key"];
            HttpCookie cookie = Request.Cookies["AuthToken"];
            if (cookie == null || EmailKhach == null) return false;
            string token = cookie.Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key.Value);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }

        //protected void btnSignOut_Click(object sender, EventArgs e)
        //{
        //    var user = from u in dbcontext.TKs
        //               select u;

        //    using (var dbContext = new QL_KPOPStoreEntities())
        //    {
        //        var disabledTKs = dbContext.TKs.FirstOrDefault(p => p.TrangThai == true && p.Email == Sign.email);

        //        var disabledKhs = dbContext.KhachHangs.FirstOrDefault(p => p.TrangThai == true && p.Email == Sign.email);
        //        disabledTKs.TrangThai = false;

        //        var Khs = dbContext.KhachHangs.Any(p => p.TrangThai == true && p.Email == Sign.email);
        //        var Tks = dbContext.TKs.Any(p => p.TrangThai == true && p.Email == Sign.email);



        //        if (Tks)
        //        {

        //            disabledTKs.TrangThai = false;
        //            if(Khs)
        //                disabledKhs.TrangThai = false;
        //        }

        //        else
        //        {

        //        }
        //        //var disabledKHs = dbContext.KhachHangs.Where(p => p.TrangThai == true).ToList();
        //        //foreach (var kh in disabledKHs)
        //        //{
        //        //    kh.TrangThai = false;
        //        //}


        //        // Lưu thay đổi vào cơ sở dữ liệu
        //        dbContext.SaveChanges();
        //        dbcontext.SaveChanges();
        //    }
        //    if (Request.Cookies["UserAccount"] != null)
        //    {

        //        Response.Cookies.Clear();
        //    }
        //    if (Request.Cookies["UserAccount"] != null)
        //    {
        //        HttpCookie cookie = new HttpCookie("UserAccount");
        //        cookie.Expires = DateTime.Now.AddMonths(-1); // Đặt thời hạn về một ngày trong quá khứ
        //        Response.Cookies.Add(cookie);
        //    }
        //    //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
        //    Session.Remove("Password");
        //    Session.Remove("Email");
        //    Sign.email = null;
        //    Sign.pass = null;
        //    Session.Remove("TenTaiKhoan");
        //    Session.Remove("MatKhau");
        //    Session.Remove("User");
        //    Session.Remove("Password");
        //    Session.Remove("Email");
        //    //Session["MaKH"] = "";
        //    Session.Remove("MaKH");
        //    //Session.Clear();
        //    Response.Redirect("Sign.aspx");

        //}


    }
}