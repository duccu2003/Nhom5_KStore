using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Web.ModelBinding;
using System.IO;
using System.Data.Entity.Migrations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace TH03_WebBanHang
{
    public partial class Account : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static int makh;
        public string maK;
        public static int MaKhach;
        public static string urlAvt;
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
            
            if (!VerifyToken())
            {
                
                Response.Redirect("Sign.aspx");
            }
            else
            {


                if (user.Any(p => (p.Email == EmailKhach)))
                {


                    var tk = user.FirstOrDefault(p => p.Email == EmailKhach); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
                    var kh = khachhang.FirstOrDefault(p => p.Email == EmailKhach); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
                    if (kh != null)
                    {
                        maK = kh.MaKH.ToString(); MaKhach = kh.MaKH;

                        if (kh.AvatarUser != null)
                        {
                            ProfileImage.ImageUrl = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == EmailKhach).AvatarUser;
                            urlAvt = dbcontext.KhachHangs.FirstOrDefault(p => p.Email == EmailKhach).AvatarUser;
                        }
                        else
                        {
                            ProfileImage.ImageUrl = Shop.defaultAvatar_BlackKS;
                            urlAvt = Shop.defaultAvatar_BlackKS;

                        }
                        lbDiem.Text = "Điểm: " + dbcontext.KhachHangs.FirstOrDefault(p => p.Email == EmailKhach).Diem.ToString();

                    }
                    else if (kh == null && EmailKhach == "Admin")
                    {
                        ProfileImage.ImageUrl = Shop.defaultAvatar_BlackKS;
                        urlAvt = Shop.defaultAvatar_BlackKS;

                    }
                    else
                    {

                    }
                    if (tk.Email == "Admin")
                    {
                        makh = 0;
                        Session["MaKH"] = makh;
                    }
                    else
                    {
                        makh = kh.MaKH;
                        Session["MaKH"] = kh.MaKH;
                    }







                    //LinkButton linkButton = (LinkButton)sender;




                    FileUploadProfilePic.Attributes["onchange"] = "btnUpload_Click(this)";
                    if (tk.Email == "Admin" || tk.Quyen == "Admin" || tk.Quyen == "Manager")
                    {
                        //btnControl.Visible = true;
                        Response.Write("<style>.btnControl{\r\n            display:block !important;\r\n        }</style>");
                        if (tk.Email == "Admin")
                        {
                            //btnAccOrder.Visible = false; 
                            Response.Write("<style>.btnAccOrder{\r\n            display:none !important;\r\n        }</style>");
                            Response.Redirect("Manager"); }
                        if (tk.Email != "Admin" && (tk.Quyen == "Admin" || tk.Quyen == "Manager"))
                        { 
                            /*btnAccOrder.Visible = true;*/
                            Response.Write("<style>.btnAccOrder{\r\n            display:block !important;\r\n        }</style>");
                        }

                    }
                    else if (tk.Quyen == null || tk.Quyen == "None") {
                        /*btnControl.Visible = false;*/
                        Response.Write("<style>.btnControl{\r\n            display:none !important;\r\n        }</style>");
                    }
                    else {
                        /*btnControl.Visible = false*/
                        Response.Write("<style>.btnControl{\r\n            display:none !important;\r\n        }</style>");
                    };

                    var activeAccounts = dbcontext.KhachHangs.Where(p => p.TrangThai == true && p.Email == EmailKhach).ToList();
                    ListViewAccounts.DataSource = activeAccounts;

                    ListViewAccounts.DataBind();
                }
                    
            
            
                else
                {

                    Response.Redirect("Sign.aspx");

                }
            }
            

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Your existing code to save changes
                dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or display the error message
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;

            if (FileUploadProfilePic.HasFile)
            {
                string uploadFolderPath = Server.MapPath("Content/account-img/");
                string fileName = Path.GetFileName(FileUploadProfilePic.FileName);
                string fileExtension = Path.GetExtension(FileUploadProfilePic.FileName);

                string filePath = Path.Combine(uploadFolderPath, fileName);

                // Lấy đường dẫn từ "Content" trở đi
                string relativePath = filePath.Substring(filePath.IndexOf("Content"));

                var tk = dbcontext.TKs.Where(p => p.Email == EmailKhach).FirstOrDefault();
                var khachhang = dbcontext.KhachHangs.Where(s => s.Email == EmailKhach).FirstOrDefault();
                if (tk != null)
                {
                    // Cập nhật thuộc tính AvatarUser và lưu thay đổi vào cơ sở dữ liệu
                    khachhang.AvatarUser = relativePath;
                    dbcontext.SaveChanges();

                    FileUploadProfilePic.SaveAs(filePath);
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy đối tượng tk
                    System.Diagnostics.Debug.WriteLine("User not found.");
                }
            }
            else
            {
                // In ra thông báo khi không có tệp nào được tải lên
                System.Diagnostics.Debug.WriteLine("No file uploaded.");
            }
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
                var disabledTKs = dbContext.TKs.FirstOrDefault(p => p.Email == EmailKhach);

                var disabledKhs = dbContext.KhachHangs.FirstOrDefault(p => p.Email == EmailKhach);
                var Tks = dbContext.TKs.Any(p => p.Email == EmailKhach);


                var Khs = dbContext.KhachHangs.Any(p => p.Email == EmailKhach);
                //if (Tks)
                //{
                //    disabledTKs.TrangThai = false;
                //    if(Khs) disabledKhs.TrangThai = false;
                //}
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


        protected void btnControl_Click(object sender, EventArgs e)
        {

            Response.Redirect("Manager.aspx");
        }
        //protected void btnAccOrder_Click(object sender, EventArgs e)
        //{
        //    HttpCookie Email = Request.Cookies["Email"];
        //    string EmailKhach;
        //    if (Email == null) EmailKhach = Sign.email;
        //    else EmailKhach = Email.Value;

        //    Response.Redirect("AccountOrder.aspx?Deptid=" + EmailKhach);
        //}
        private bool VerifyToken()
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if(Email==null) EmailKhach = Sign.email;
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
       
    }
}