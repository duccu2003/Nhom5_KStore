using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class UpdatePob : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities db = new QL_KPOPStoreEntities();
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

        public List<POB> GetProductsByCategory(string categoryId)
        {
            // Logic để lấy danh sách sản phẩm dựa trên categoryId
            // Đây chỉ là giả định, bạn cần thay thế bằng logic thực tế của mình
            return new List<POB>(); // Trả về danh sách sản phẩm giả định
        }

        protected void ddlMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selectedCategoryId = ddlMaSP.SelectedItem.Text;
            var products = GetProductsByCategory(selectedCategoryId);
            //listView.DataSource = products;
            //listView.DataBind();
            listView.Items.Clear();
            listView.DataBind();
            GetDeparments();

        }
        private void MaSPDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                // Populate ddlCity
                var HavePop = db.SanPhamDatas.Any(s => s.Pob == true);

                var MaSPtruePop = from masp in context.SanPhams
                                  where masp.TenVer == null
                                  group masp by masp.MaSP into g
                                  select g.Select(masp => masp).FirstOrDefault();
                ddlMaSP.DataSource = MaSPtruePop.ToList();
                ddlMaSP.DataTextField = "MaSP";
                ddlMaSP.DataValueField = "MaSP";
                ddlMaSP.DataBind();

                //else
                //{
                //    var MaSP = from masp in context.SanPhams
                //               where masp.SanPhamDatas.Any(s => s.Pop == true)
                //               group masp by masp.Ver into g
                //               select g.Select(masp => masp).ToList();
                //    ddlMaSP.DataSource = MaSP;
                //    ddlMaSP.DataTextField = "Ver";
                //    ddlMaSP.DataValueField = "Ver";
                //    ddlMaSP.DataBind();
                //}



            }

        }
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

            if (!IsPostBack)
            {
                MaSPDropDownLists();

            }
        }

        protected void btnAddPop_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();


            SanPhamData sanpData = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == ddlMaSP.SelectedItem.Text && s.Pob != true);

            var sp = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == ddlMaSP.SelectedItem.Text);
            var notHadPop = dbcontext.SanPhamDatas.Any(s => s.MaSP == ddlMaSP.SelectedItem.Text && s.Pob != true);


            using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
            {
                string MaPob = ddlMaSP.SelectedItem.Text.Trim() + txtTenPob.Text.Trim();

                string insertPopSPQuery = "INSERT INTO POB (MaPob, TenPob, MaSP) VALUES (@MaPob, @TenPob, @MaSP)";
                using (SqlCommand insertPopCommand = new SqlCommand(insertPopSPQuery, connection))
                {
                    insertPopCommand.Parameters.AddWithValue("@MaPob", MaPob);
                    insertPopCommand.Parameters.AddWithValue("@TenPob", txtTenPob.Text);
                    insertPopCommand.Parameters.AddWithValue("@MaSP", ddlMaSP.SelectedItem.Text.Replace(" ", ""));
                    connection.Open();
                    insertPopCommand.ExecuteNonQuery();

                    connection.Close();
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm "+ txtTenPob.Text +" vào sản phẩm "+ddlMaSP.SelectedItem.Text+" thành công.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");
                }
            }
            if (notHadPop)
            {
                if (sanpData.Pob != true)
                {
                    //sanpData.Pop = true;
                    //dbcontext.SaveChanges();
                    string sql = "UPDATE SanPhamData SET Pob = @PobValue WHERE MaSP = @MaSP";
                    dbcontext.Database.ExecuteSqlCommand(sql, new SqlParameter("@PobValue", true), new SqlParameter("@MaSP", sp.MaSP));
                    Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm " + txtTenPob.Text + " vào sản phẩm " + sp.MaSP + " thành công.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");
                }
                else
                {

                }

            }

            else { }
            dbcontext.SaveChanges();

            //Response.Redirect("item.aspx?sp=" + sp.MaSP);
            Response.Redirect(Request.RawUrl);
        }

        public IQueryable<POB> GetDeparments()
        {
            string SP = ddlMaSP.SelectedItem.Text;
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();

            var sp = dbcontext.SanPhams.FirstOrDefault(s => s.Ver == SP);

            IQueryable<POB> product = dbcontext.POBs.Where(s => s.MaSP == sp.Ver);


            return product;

        }
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            GetDeparments();
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
            System.Web.UI.WebControls.Button btnXoa = (System.Web.UI.WebControls.Button)sender;

            // Lấy mã sản phẩm từ CommandArgument của nút
            string maSP = btnXoa.CommandArgument;

            string[] arg = new string[3];
            arg = btnXoa.CommandArgument.ToString().Split(';');
            string MaPob = arg[0];
            string maSanP = arg[1];
            string TenPob = arg[2];

            POB pOB = dbcontext.POBs.FirstOrDefault(s => s.TenPob == TenPob && s.MaSP == maSanP && s.MaPob == MaPob);
            if (pOB != null)
            {
                string sql = "DELETE FROM POB WHERE MaSP = @MaSP AND TenPob = @TenPob AND MaPob = @MaPob";

                // Khai báo các tham số
                SqlParameter maSpParam = new SqlParameter("@MaSP", maSanP);
                SqlParameter TenPobParam = new SqlParameter("@TenPob", TenPob);
                SqlParameter MaPobParam = new SqlParameter("@MaPob", MaPob);

                // Thực thi câu lệnh SQL với các tham số đã khai báo
                dbcontext.Database.ExecuteSqlCommand(sql, maSpParam, TenPobParam, MaPobParam);

                // Kiểm tra xem có SanPhamData nào có MaSP khớp với MaSP của POP vừa xóa hay không
                bool sanPhamDataExists = dbcontext.SanPhamDatas.Any(s => s.MaSP == maSanP);
                if (!sanPhamDataExists)
                {
                    // Tìm SanPhamData đầu tiên có MaSP khớp và đặt Pop thành false
                    var sanpham = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == maSanP);
                    if (sanpham != null)
                    {
                        sanpham.Pob = false;
                        // Lưu thay đổi vào database
                        dbcontext.SaveChanges();
                    }
                }

                // Đảm bảo rằng tất cả các thay đổi đều được lưu trước khi redirect
                dbcontext.SaveChanges();
                Response.Redirect(Request.RawUrl);
                //Response.Redirect("Item.aspx?sp=" + maSanP);
                Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa Pob " + TenPob + " của sản phẩm "+ maSanP + " thành công.</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }

            listView.Items.Clear();
            listView.DataBind();
            GetDeparments();

        }


    }
}