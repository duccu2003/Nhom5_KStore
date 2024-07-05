using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlTypes;
using System.Web.ModelBinding;
using System.Web.Services;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.Web.WebPages;
<<<<<<< HEAD
using Newtonsoft.Json;
=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498

namespace TH03_WebBanHang
{
    public partial class Shop : System.Web.UI.MasterPage
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static string CH;
        public static string SQL_dataSource = "DUC-LAPTOP\\NGUYENHOANGDUC";
        public static string SQL_initialCatalog = "QL_KPOPStore";
        public static string SQL_sqlTK = "sa";
        public static string SQL_sqlMK = "1";
        public static string SQL_connectionString = $"Data Source={SQL_dataSource};Initial Catalog={SQL_initialCatalog};User ID={SQL_sqlTK};Password={SQL_sqlMK};";

        public static string gmailAccount = "2105ct0098@dhv.edu.vn";
        public static string gmailPass = "beduc102";


        public static string defaultAvatar_BlackKS = "Content\\account-img\\KS.png";
        public static string logoForMail_BlackKS = "Content\\image-bg\\KS.png";

        public static string localhost = "http://localhost:52718/";
<<<<<<< HEAD
        
=======

>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498


        protected void Page_Load(object sender, EventArgs e)
        {
            CH = ddlBranches.SelectedValue.ToString();

            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;

            var db = new QL_KPOPStoreEntities();
            HttpCookie Email = Request.Cookies["Email"];
            
            if (Email != null)
            {
<<<<<<< HEAD
                var isKhachLog = dbcontext.KhachHangs.Any(s => s.Email == Email.Value && s.TrangThai==true);
=======
                var isKhachLog = dbcontext.KhachHangs.Any(s => s.Email == Email.Value);
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                if (isKhachLog)
                {
                    imgHeaderAVTofUser.Visible = true;
                    var KhachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == Email.Value);
                    imgHeaderAVTofUser.ImageUrl = KhachHang.AvatarUser;
                    Response.Write("<style>#iconAccount{display:none;}</style>");
                }
                else
                {
                    imgHeaderAVTofUser.Visible=false;
                }
            }

            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            Hepler hepler = new Hepler();
            lbCart.Text = hepler.TongSoLuong(lstGioHang).ToString(); 
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(searchinput.Text))
                {   
                    
                    searchinput.Focus();
                    //Response.Write("<script type=\"text/javascript\">\r\n    function setFocusToSearchInput() {\r\n        // Đặt focus vào TextBox sau mỗi postback\r\n        document.getElementsByClassName('searchinput').focus();\r\n    }\r\n\r\n    // Gọi hàm setFocusToSearchInput sau mỗi postback\r\n    window.onload = setFocusToSearchInput;\r\n</script>");
<<<<<<< HEAD
                   //BindData();
=======
                    BindData();
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                    
                }
                LoadChiNhanh();
                
<<<<<<< HEAD
               //BindData();
=======
                BindData();
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
             
                
            }
            else
            {
                if (!string.IsNullOrEmpty(searchinput.Text))
                {
                    searchinput.Focus();
                    //Response.Write("<script type=\"text/javascript\">\r\n    function setFocusToSearchInput() {\r\n        // Đặt focus vào TextBox sau mỗi postback\r\n        document.getElementsByClassName('searchinput').focus();\r\n    }\r\n\r\n    // Gọi hàm setFocusToSearchInput sau mỗi postback\r\n    window.onload = setFocusToSearchInput;\r\n</script>");

<<<<<<< HEAD
                   //BindData();
                }
               //BindData();
=======
                    BindData();
                }
                BindData();
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                
            }
            
            string searchText = Request.Form["searchinput"];



        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

            string searchText = searchinput.Text;

            // Chuyển đổi searchText thành chuỗi để có thể sử dụng Contains()
            var DonHang = dbcontext.ChiTietDonHangs.Any(p => p.MaCTDH.Contains(searchText));
            var Don = dbcontext.DonHangs.Any(p => p.MaDH.Contains(searchText));
            var SanPham = dbcontext.SanPhams.Any(p => p.TenSP.Contains(searchText) || searchText.Contains(p.TenSP) || p.MoTa.Contains(searchText) || searchText.Contains(p.MoTa)  || p.Nhom.TenNhom.Contains(searchText) || searchText.Contains(p.Nhom.TenNhom) || p.Loai.TenLoai.Contains(searchText)  || searchText.Contains(p.Loai.TenLoai));
            var ChiNhanh = dbcontext.ChiNhanhs.Any(p => p.TenCN.Contains(searchText) || p.MaCN.Contains(searchText) || p.DiaChiCN.Contains(searchText));
            // Đối với các trường DateTime, chuyển đổi thành chuỗi và sử dụng Contains()
            // Giả sử bạn muốn tìm kiếm ngày trong một trường DateTime, ví dụ: p.Ngay
            // var Ngay = dbcontext.SanPhams.Any(p => p.Ngay.ToString("yyyy-MM-dd").Contains(searchText));

            //if (DonHang) Response.Redirect("ManagerOrder.aspx?searchText=" + searchText);
            //else if (Don) Response.Redirect("ManagerOrder.aspx?searchText=" + searchText);
            if (SanPham) Response.Redirect("item.aspx?searchText=" + searchText);
            //else if (ChiNhanh) Response.Redirect("About.aspx?searchText=" + searchText);
            else Response.Redirect("item.aspx?searchText=" + searchText);



        }
        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the selected value in a session
            Session["SelectedBranch"] = ddlBranches.SelectedValue;
            string MaSP = Request.QueryString["sp"];
            string sp = HttpContext.Current.Request.QueryString.Get("sp");
            

                

                if (MaSP != null || sp != null)
                {
                    Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");
                }
            
        }

        private void LoadChiNhanh()
        {
            string query = "SELECT MaCN, TenCN FROM ChiNhanh";
            string efConnectionString = ConfigurationManager.ConnectionStrings["QL_KPOPStoreEntities"].ConnectionString;
            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder(efConnectionString);
            string actualConnectionString = efBuilder.ProviderConnectionString;
            using (SqlConnection connection = new SqlConnection(actualConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ddlBranches.Items.RemoveAt(0);
                    while (reader.Read())
                    {
                        string maCN = reader["MaCN"].ToString();
                        string tenCN = reader["TenCN"].ToString();

                        ListItem listItem = new ListItem(tenCN, maCN);
                        ddlBranches.Items.Add(listItem);
                    }

                    // Check if there's a selected value stored in the session
                    if (Session["SelectedBranch"] != null)
                    {
                        // Set the selected value from the session
                        ddlBranches.SelectedValue = Session["SelectedBranch"].ToString();
                    }
                    else
                    {
                        // If no value is stored in the session, select the first item
                        ddlBranches.SelectedIndex = 0;
                    }

                    connection.Close();
                }
            }
        }




<<<<<<< HEAD
        

        
=======
        [System.Web.Services.WebMethod]
        protected void BindData()
        {
            if (!string.IsNullOrEmpty(searchinput.Text))
            {
                lvItemsSearch.Visible = true;
                Response.Write(" <style>\r\n                        #div-items-Search{\r\n                            display:block;\r\n                        }\r\n                    </style>");
                string searchText = searchinput.Text;

                int value;
                int.TryParse(searchText, out value);
                DateTime date;
                DateTime.TryParse(searchText, out date);

                var items = dbcontext.SanPhams
                  .Where(p =>
                        p.SoLuongKho > 0 
                        && (p.TenSP == searchText || p.TenSP.Contains(searchText) || searchText.Contains(p.TenSP) 
                        || p.MoTa == searchText || p.MoTa.Contains(searchText) || searchText.Contains(p.MoTa) 
                        //|| p.Loai.TenLoai == searchText || p.Loai.TenLoai.Contains(searchText) || searchText.Contains(p.Loai.TenLoai) 
                        //|| p.Nhom.TenNhom == searchText || p.Nhom.TenNhom.Contains(searchText) || searchText.Contains(p.Nhom.TenNhom) 
                        //|| p.Gia == value || p.DoanhSo == value || p.NgaySX == date || p.NgayHH == date
                        )).ToList();

                if (items.Count > 0)
                {
                    PlaceHolderGioiThieu.Visible = true; // Ẩn dòng "Sản phẩm gợi ý."
                    lvItemsSearch.DataSource = items;
                    lvItemsSearch.DataBind();
                }
                else
                {
                    PlaceHolderGioiThieu.Visible = false; // Hiển thị dòng "Sản phẩm gợi ý."
                    lvItemsSearch.DataSource = null; // Đặt DataSource null để không hiển thị sản phẩm
                    lvItemsSearch.DataBind(); // Gọi DataBind để cập nhật UI
                }
            }
            else
            {
                Response.Write(" <style>\r\n                        #div-items-Search{\r\n                            display:none;\r\n                        }\r\n                    </style>");

                PlaceHolderGioiThieu.Visible = false; // Hiển thị dòng "Sản phẩm gợi ý."
                lvItemsSearch.DataSource = null; // Đặt DataSource null để không hiển thị sản phẩm
                lvItemsSearch.DataBind(); // Gọi DataBind để cập nhật UI
                lvItemsSearch.Visible= false;
            }

        }

        protected void searchinput_TextChanged(object sender, EventArgs e)
        {
            // Gọi phương thức để cập nhật dữ liệu khi người dùng nhập vào TextBox
            BindData();
        }
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
        
    }
}