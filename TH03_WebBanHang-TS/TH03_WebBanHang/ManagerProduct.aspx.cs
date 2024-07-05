using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class ManagerProduct : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

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
            if (user.Any(p => EmailKhach != null && ((p.Email == EmailKhach && EmailKhach == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.Email == EmailKhach))))
            {

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
        public string url = HttpContext.Current.Request.Url.ToString();
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btnUpdate = (Button)sender;
            // Get the CommandArgument, which should be the ID of the item to update
            string itemId = btnUpdate.CommandArgument;
            // Find the input field associated with the button
            var txtSoLuongKho = (HtmlInputText)btnUpdate.NamingContainer.FindControl("txtSoLuongKho");
            if (txtSoLuongKho.Value == null || txtSoLuongKho.Value.IsNullOrEmpty())
            {
                txtSoLuongKho.Value = "0";
            }


            // Parse the new SoLuongKho value from the input field
            int newSoLuongKho = int.Parse(txtSoLuongKho.Value);

            // Retrieve the item from the database
            var sp = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemId);
            if (sp != null)
            {
                // Update the SoLuongKho value
                sp.SoLuongKho = newSoLuongKho;
                // Optionally, update other fields if necessary
                sp.NgayNhap = DateTime.Now;

                // Save changes to the database
                dbcontext.SaveChanges();
                // Refresh the ListView to reflect the changes
                ListView1.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            ImageButton btnDelete = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            string itemId = btnDelete.CommandArgument;
            var sp = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemId);
            sp.SoLuongKho--;

            dbcontext.SaveChanges();
            ListView1.DataBind();

            Response.Redirect(url);
        }


        protected void btnChange_Click(object sender, EventArgs e)
        {
            ImageButton btnChange = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            string itemId = btnChange.CommandArgument;
            var sp = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemId);
            sp.SoLuongKho++;
            sp.NgayNhap = DateTime.Now;
            dbcontext.SaveChanges();
            // Optionally, refresh the ListView to reflect the changes
            ListView1.DataBind();
            // Update the total price label

            Response.Redirect(url);

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
        public IQueryable<SanPham> GetDeparments()
        {
            string searchText = searchinputA.Text;

            //IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.MaLoai != "6");
            var departments = dbcontext.SanPhams.OrderBy(s => s.MaLoai);

            IQueryable<SanPham> product = departments.OrderBy(s => s.MaLoai);
            IQueryable<SanPham> sanPhamsSearch = product.Where(p => p.MoTa.Contains(searchText) || p.MaSP.Contains(searchText) || p.Loai.TenLoai.Contains(searchText) || p.Nhom.TenNhom.Contains(searchText) || p.TenSP.Contains(searchText));

            if (string.IsNullOrEmpty(searchText))
            {
                return product.OrderByDescending(s => s.NgayNhap);
            }
            else
            {
                return sanPhamsSearch;
            }
        }


    }
}