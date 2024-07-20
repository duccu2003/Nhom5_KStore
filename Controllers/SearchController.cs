using Microsoft.Graph.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang.Controllers
{
    public class SearchController : Controller
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string searchinput)
        {
            StringBuilder htmlContent = new StringBuilder();
            string searchText = searchinput;
            var items = dbcontext.SanPhams
                  .Where(p =>
                        p.SoLuongKho > 0
                        && (p.TenSP == searchText || p.TenSP.Contains(searchText) || searchText.Contains(p.TenSP)
                        || p.MoTa == searchText || p.MoTa.Contains(searchText) || searchText.Contains(p.MoTa)
                        //|| p.Loai.TenLoai == searchText || p.Loai.TenLoai.Contains(searchText) || searchText.Contains(p.Loai.TenLoai) 
                        //|| p.Nhom.TenNhom == searchText || p.Nhom.TenNhom.Contains(searchText) || searchText.Contains(p.Nhom.TenNhom) 
                        //|| p.Gia == value || p.DoanhSo == value || p.NgaySX == date || p.NgayHH == date
                        )).ToList();
            //return Content("Đây là kết quả tìm kiếm");
            searchinput = Request.QueryString["searchinput"];
            bool showPlaceHolder = true;
            bool showList = true;
            if (!string.IsNullOrEmpty(searchinput))
            {

                //Session["lvItemsSearch"] = false;
                
                //lvItemsSearch.Visible = true;
                Response.Write(" <style>\r\n                        #div-items-Search{\r\n                            display:block;\r\n                        }\r\n                    </style>");
                

                int value;
                int.TryParse(searchText, out value);
                DateTime date;
                DateTime.TryParse(searchText, out date);

                

                System.Diagnostics.Debug.WriteLine($"Number of items found: {items.Count}");
                if (items.Count > 0)
                {
                    showPlaceHolder = true;
                    //PlaceHolderGioiThieu.Visible = true; // Ẩn dòng "Sản phẩm gợi ý."
                    //lvItemsSearch.DataSource = items;
                    //lvItemsSearch.DataBind();
                    showList = true;
                    foreach (var product in items)
                    {
                        htmlContent.AppendLine("<style>\\r\\n                        #div-items-Search{\\r\\n                            display:block;\\r\\n                        }\\r\\n                    </style>");

                        htmlContent.AppendLine("<a style='display:flex; margin:7.5px auto; gap:15px;' href=\"item.aspx?sp=" + product.MaSP + "\">");
                        htmlContent.AppendLine("<img style=\"height:80px; border-radius:5px; \" src=\"" + product.DuongDan + "\" alt=\"" + product.TenSP + "\" />");
                        htmlContent.AppendLine("<div style='display:grid;'>" + product.TenSP);
                        htmlContent.AppendLine("<p>" + string.Format("{0:N0}", product.Gia) + "đ</p></div>");
                        htmlContent.AppendLine("</a>");
                    }
                }
                else
                {
                    showPlaceHolder = false;
                    //PlaceHolderGioiThieu.Visible = false; // Hiển thị dòng "Sản phẩm gợi ý."
                    //lvItemsSearch.DataSource = null; // Đặt DataSource null để không hiển thị sản phẩm
                    //lvItemsSearch.DataBind(); // Gọi DataBind để cập nhật UI
                    showList = true;
                    htmlContent.AppendLine("<p>Không tìm thấy nội dung liên quan.</p>");
                }

                var cookieValueshowPlaceHolder = JsonConvert.SerializeObject(showPlaceHolder); // Sử dụng Newtonsoft.Json để serialize object thành JSON nếu cần
                var cookieListItems = JsonConvert.SerializeObject(showList);
                // Tạo cookie
                var cookiePlaceHolder = new HttpCookie("showPlaceHolder", cookieValueshowPlaceHolder)
                {
                    Expires = DateTime.Now.AddSeconds(20), // Cookie sẽ hết hạn sau 7 ngày
                    Path = "/", // Cookie có thể truy cập từ mọi đường dẫn trên website
                    Secure = true, // Cookie chỉ được gửi qua HTTPS
                    HttpOnly = true // Cookie không thể truy cập qua JavaScript
                };
                var cookieList = new HttpCookie("showList", cookieListItems)
                {
                    Expires = DateTime.Now.AddSeconds(20), // Cookie sẽ hết hạn sau 7 ngày
                    Path = "/", // Cookie có thể truy cập từ mọi đường dẫn trên website
                    Secure = true, // Cookie chỉ được gửi qua HTTPS
                    HttpOnly = true // Cookie không thể truy cập qua JavaScript
                };
                Response.Cookies.Add(cookiePlaceHolder);
                Response.Cookies.Add(cookieList);
                //return Json(items, JsonRequestBehavior.AllowGet);

               

                return Content(htmlContent.ToString());

            }
            else
            {
                showPlaceHolder = false;
                showList = false;
                //PlaceHolderGioiThieu.Visible = false; // Hiển thị dòng "Sản phẩm gợi ý."
                //lvItemsSearch.DataSource = null; // Đặt DataSource null để không hiển thị sản phẩm
                //lvItemsSearch.DataBind(); // Gọi DataBind để cập nhật UI
                //lvItemsSearch.Visible = false;

                // Xóa cookie showPlaceHolder
                Response.Cookies.Remove("showPlaceHolder");

                // Xóa cookie showList
                Response.Cookies.Remove("showList");

                //return PartialView("_SearchResults", items);



                //foreach (var product in items)
                //{
                //    htmlContent.AppendLine("<a style='display:flex; margin:7.5px auto; gap:15px;' href=\"item.aspx?sp=" + product.MaSP + "\">");
                //    htmlContent.AppendLine("<img style=\"height:80px; border-radius:5px; \" src=\"" + product.DuongDan + "\" alt=\"" + product.TenSP + "\" />");
                //    htmlContent.AppendLine("<div style='display:grid;'>" + product.TenSP + " - " + string.Format("{0:N0}", product.Gia) + "đ</div>");
                //    htmlContent.AppendLine("</a>");
                //}
                
                htmlContent.AppendLine("<style>\\r\\n                        #div-items-Search{\\r\\n                            display:none;\\r\\n                        }\\r\\n                    </style>");

                //return Content(htmlContent.ToString());
                return Content(htmlContent.ToString());
            }

        }
        
    }
}