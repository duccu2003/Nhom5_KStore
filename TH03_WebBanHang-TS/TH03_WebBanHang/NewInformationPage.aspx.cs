using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class NewInformationPage : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        public IQueryable<TH03_WebBanHang.Models.TinTuc> GetNews()
        {
            var allNews = dbcontext.TinTucs.OrderBy(s => s.MaBV).OrderByDescending(v => v.NgayDangBV);
            var distinct = allNews.GroupBy(v => v.MaBV)
                                .Select(g => g.FirstOrDefault())
                                .ToList();
            return distinct.AsQueryable();




        }
        public IQueryable<VideoThongTin> GetVid()
        {


            var distinctVideosForListView = dbcontext.VideoThongTins
                                                .OrderByDescending(v => v.NgayDangBV)
                                                .GroupBy(v => v.MaV)
                                                .Select(g => g.FirstOrDefault()).OrderByDescending(v => v.NgayDangBV).ToList();

            return distinctVideosForListView.AsQueryable();
        }
    }
}