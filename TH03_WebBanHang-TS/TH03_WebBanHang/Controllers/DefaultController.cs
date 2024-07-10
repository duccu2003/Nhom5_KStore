using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNPAY_CS_ASPX;

namespace TH03_WebBanHang.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
           
            return Redirect("Default.aspx");
        }
    }
}