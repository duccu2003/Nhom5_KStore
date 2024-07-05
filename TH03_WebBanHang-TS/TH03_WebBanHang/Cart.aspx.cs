using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Help;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class Cart : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public string url = HttpContext.Current.Request.Url.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lbTongThanhToan.Text = "0";
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            Hepler hepler = new Hepler();
            lbTongThanhToan.Text = hepler.TongThanhTien(lstGioHang).ToString();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TH03_WebBanHang.Models.ChiTietDonHang> GetCart()
        {
            Item item = new Item();
            // Lấy giở hàng
            IQueryable<ChiTietDonHang> lstGioHang2 = item.LayGioHang().AsQueryable();

            return lstGioHang2;

        }
        private void ItemFromCart(string itemId, string Pob)
        {
            // Retrieve the cart from the session
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            //if (lstGioHang != null)
            //{
            //    // Find the item to update
            //    ChiTietDonHang itemToUpdate = lstGioHang.FirstOrDefault(item => item.MaSP == itemId);
            //    if (itemToUpdate != null)
            //    {
            //        // Check if the item's quantity is greater than  1


            //        // Decrease the quantity by  1
            //        itemToUpdate.SoLuong++;



            //        itemToUpdate.ThanhTien = itemToUpdate.SoLuong * itemToUpdate.Gia;

            //        // Update the session with the new cart list
            //        Session["GioHang"] = lstGioHang;

            //        // Optionally, refresh the ListView to reflect the changes
            //        ListView1.DataBind();
            //        // Update the total price label
            //        UpdateTotalPrice();
            //    }
            //}

            if (lstGioHang != null)
            {
                // Find the item to update
                ChiTietDonHang itemToUpdate = lstGioHang.FirstOrDefault(item => item.MaSP == itemId && (item.TenPob== Pob || item.TenPob == null));
                var sanphamC = dbcontext.SanPhams.FirstOrDefault(item => item.MaSP == itemId);

                if (itemToUpdate != null && sanphamC != null)
                {
                    // Calculate the available quantity based on SoLuongKho and the quantity already in the cart
                    sanphamC.SoLuongKho -= itemToUpdate.SoLuong;

                    // Check if the requested quantity is greater than 0 and not exceeding the available quantity
                    if (sanphamC.SoLuongKho > 0)
                    {
                        itemToUpdate.SoLuong++;
                    }
                    // If the requested quantity exceeds the available quantity, set it to the maximum available quantity
                    else if (sanphamC.SoLuongKho < 0)
                    {
                        itemToUpdate.SoLuong += 0;
                    }

                    itemToUpdate.ThanhTien = itemToUpdate.SoLuong * itemToUpdate.Gia;

                    // Update the session with the new cart list
                    Session["GioHang"] = lstGioHang;

                    // Optionally, refresh the ListView to reflect the changes
                    ListView1.DataBind();
                    // Update the total price label
                    UpdateTotalPrice();
                }
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            ImageButton btnDelete = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            //string itemId = btnDelete.CommandArgument;
            string[] arg = new string[2];
            arg = btnDelete.CommandArgument.ToString().Split(';');
            string maSP = arg[0];
            string Pob = arg[1];
            // Example: Delete the item from the cart
            // You'll need to replace this with your actual logic
            DeleteItemFromCart(maSP, Pob);

            // Optionally, refresh the ListView to reflect the changes
            ListView1.DataBind();
            // Update the total price label
            UpdateTotalPrice();
            Response.Redirect(url);
        }
        

        protected void btnChange_Click(object sender, EventArgs e)
        {
            ImageButton btnChange = (ImageButton)sender;
            // Get the CommandArgument, which should be the ID of the item to delete
            //string itemId = btnChange.CommandArgument;
            string[] arg = new string[2];
            arg = btnChange.CommandArgument.ToString().Split(';');
            string maSP = arg[0];
            string Pob = arg[1];


            ItemFromCart(maSP, Pob);
            // Optionally, refresh the ListView to reflect the changes
            ListView1.DataBind();
            // Update the total price label
            UpdateTotalPrice();
            Response.Redirect(url);

        }

        private void DeleteItemFromCart(string itemId, string Pob)
        {
            // Retrieve the cart from the session
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            if (lstGioHang != null)
            {
                // Find the item to update
                ChiTietDonHang itemToUpdate = lstGioHang.FirstOrDefault(item => item.MaSP == itemId && (item.TenPob == Pob || item.TenPob == null));
                if (itemToUpdate != null)
                {
                    // Check if the item's quantity is greater than  1
                    if (itemToUpdate.SoLuong > 1)
                    {
                        // Decrease the quantity by  1
                        itemToUpdate.SoLuong--;

                    }
                    else
                    {
                        // If the quantity is  1, remove the item from the cart
                        lstGioHang.Remove(itemToUpdate);
                    }
                    itemToUpdate.ThanhTien = itemToUpdate.SoLuong * itemToUpdate.Gia;

                    // Update the session with the new cart list
                    Session["GioHang"] = lstGioHang;

                    // Optionally, refresh the ListView to reflect the changes
                    ListView1.DataBind();
                    // Update the total price label
                    UpdateTotalPrice();
                }
            }
        }



        private void UpdateTotalPrice()
        {
            // Calculate the total price of items in the cart
            // This is just a placeholder method
            Hepler hepler = new Hepler();
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;

            lbTongThanhToan.Text = hepler.TongThanhTien(lstGioHang).ToString();

        }

        protected void btnDathang_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            // Query the database for the user with the given username and password
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from kh in dbcontext.KhachHangs select kh;
            if (user.Any(p => (p.TrangThai == true && p.Email == EmailKhach)) && Session["GioHang"] != null)
            {
                Response.Redirect("Pay.aspx");

            }
            // Otherwise, display an error message

            else
            {
                //Response.Redirect("Sign.aspx");
                Response.Redirect("Pay.aspx");

            }
        }
    }
}