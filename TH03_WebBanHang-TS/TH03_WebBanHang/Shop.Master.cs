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
using Newtonsoft.Json;

namespace TH03_WebBanHang
{
    public partial class Shop : System.Web.UI.MasterPage
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static string CH;

        //thông tin connectionstring nằm ở đây
        public static string SQL_dataSource = "Sever_Name_Của_SQL_Sever_Nằm_Ở_Đây";
        public static string SQL_initialCatalog = "QL_KPOPStore";
        public static string SQL_sqlTK = "Tài_Khoản_SQL_Sever";
        public static string SQL_sqlMK = "Mật_Khẩu_SQL_Sever";
        public static string SQL_connectionString = $"Data Source={SQL_dataSource};Initial Catalog={SQL_initialCatalog};User ID={SQL_sqlTK};Password={SQL_sqlMK};";

        //tài khoản gmail để gửi mail cho khách nằm ở đây
        public static string gmailAccount = "Gmail_Nằm_Ở_Đây";
        public static string gmailPass = "Mật_Khẩu_Gmail_Ở_Đây";

        //api openai nằm ở đây
        public static string apiChatGPT = "API_Của_ChatGPT_Nằm_Ở_Đây";
        public static string modelChatGPT = "gpt-3.5-turbo";

        //Token để thực hiện cuộc gọi otp nằm ở đây
        public static string tokenStringee30day = "Bearer eyJjdHkiOiJzdHJpbmdlZS1hcGk7dj0xIiwidHlwIjoiSldUIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiJTSy4wLlNMU1hSRlpYNzY3bVNSQ29vZTlUamMwaWtRM3E4Rmo3LTE3MjEzMjQ4ODkiLCJpc3MiOiJTSy4wLlNMU1hSRlpYNzY3bVNSQ29vZTlUamMwaWtRM3E4Rmo3IiwiZXhwIjoxNzIzOTE2ODg5LCJyZXN0X2FwaSI6dHJ1ZX0.9RqxklzusVCJaCPp5skT_LdSMuqTq4AuAmwvoidIjEs";


        public static string defaultAvatar_BlackKS = "Content\\account-img\\KS.png";
        public static string logoForMail_BlackKS = "Content\\image-bg\\KS.png";

        public static string localhost = "http://localhost:52718/";
        


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
                var isKhachLog = dbcontext.KhachHangs.Any(s => s.Email ==Sign.email && s.Email == Email.Value && s.TrangThai==true);
                if (isKhachLog)
                {
                    imgHeaderAVTofUser.Visible = true;
                    var KhachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == Sign.email && s.Email == Email.Value && s.TrangThai == true);
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
                   //BindData();
                    
                }
                LoadChiNhanh();
                
               //BindData();
             
                
            }
            else
            {
                if (!string.IsNullOrEmpty(searchinput.Text))
                {
                    searchinput.Focus();
                    //Response.Write("<script type=\"text/javascript\">\r\n    function setFocusToSearchInput() {\r\n        // Đặt focus vào TextBox sau mỗi postback\r\n        document.getElementsByClassName('searchinput').focus();\r\n    }\r\n\r\n    // Gọi hàm setFocusToSearchInput sau mỗi postback\r\n    window.onload = setFocusToSearchInput;\r\n</script>");

                   //BindData();
                }
               //BindData();
                
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




        

        
        
    }
}