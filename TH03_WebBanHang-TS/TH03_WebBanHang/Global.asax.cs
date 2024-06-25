using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TH03_WebBanHang
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_End(object sender, EventArgs e)
        {
            // Xóa Session["User"] khi phiên kết thúc
            Session.Remove("User");
            Session.Remove("TenTaiKhoan");
            Session.Remove("MatKhau");           
            Session["MaKH"] = "";                       
            Session.Remove("Password");
            Session.Remove("Email");          
            Session.Remove("MaKH");
            Session.Remove("Password");
            Session.Remove("Email");
            Sign.email = null;
            Sign.pass = null;
            Session.Remove("TenTaiKhoan");
            Session.Remove("MatKhau");
            Session.Remove("User");
            Session.Remove("Password");
            Session.Remove("Email");
            Session["MaKH"] = "";
            Session.Remove("MaKH");
        }
    }
}