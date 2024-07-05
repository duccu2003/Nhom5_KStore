using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TH03_WebBanHang
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            

            routes.MapRoute(
                name: "ChatBot",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ChatBot", action = "ChatBot", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );


        }
    }
}
