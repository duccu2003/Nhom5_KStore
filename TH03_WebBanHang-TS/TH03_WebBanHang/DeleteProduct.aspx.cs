using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class DeleteProduct : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                string str = Request.QueryString["Deptid"].ToString();
                SanPham deparments = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == str);
                lbDeptid.Text = deparments.Ver;
                lbName.Text = deparments.TenSP;
                imgSP.ImageUrl = deparments.DuongDan;
                lbMaSPV.Text = str;
            }
        }



        protected void btDel_Click(object sender, EventArgs e)
        {
            string deptId = lbMaSPV.Text;
            string deptName = lbName.Text;
            SanPham deparment = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == deptId);
            SanPham namesp = dbcontext.SanPhams.SingleOrDefault(p => p.TenSP == deptName && p.MaSP == deptId);

            if (namesp.TenSP == lbName.Text && lbMaSPV.Text == deparment.MaSP)
            {
                // Xóa các bản ghi liên quan trong SanPhamData bằng truy vấn SQL
                dbcontext.Database.ExecuteSqlCommand("DELETE FROM SanPhamData WHERE MaSP = {0}", deptId);

                string checkMaSPQuery = "SELECT FROM SanPham WHERE MaSP = " + deptId;

                using (var dbcontext = new QL_KPOPStoreEntities())
                {
                    dbcontext.Database.ExecuteSqlCommand(@"
                        ALTER TABLE ChiTietDonHang
                        ALTER COLUMN MaSP varchar(50) NULL;
                        IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK__ChiTietDon__MaSP__44FF419A')
                        BEGIN
                            ALTER TABLE ChiTietDonHang
                            DROP CONSTRAINT FK__ChiTietDon__MaSP__44FF419A;
                        END
                    ");

                    dbcontext.Database.ExecuteSqlCommand(@"
                        ALTER TABLE ChiTietDonHang
                        ADD CONSTRAINT FK__ChiTietDon__MaSP__44FF419A
                        FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
                        ON DELETE SET NULL;
                    ");
                }


                // Xóa bản ghi trong bảng SanPham
                //dbcontext.Database.ExecuteSqlCommand("DELETE FROM SanPham WHERE MaSP = @p0", deptId);

                // Commit transaction
                dbcontext.SaveChanges();





                // Xóa các bản ghi liên quan trong SanPhams
                if (deparment?.SPs != null)
                {
                    foreach (var employeeMSP in deparment.SPs.ToList())
                    {
                        dbcontext.SanPhams.Remove(employeeMSP);
                    }
                }

                if (namesp?.TSPs != null)
                {
                    foreach (var employeeTSP in namesp.TSPs.ToList())
                    {
                        dbcontext.SanPhams.Remove(employeeTSP);
                    }
                }

                // Xóa sản phẩm
                dbcontext.SanPhams.Remove(deparment);
                dbcontext.SanPhams.Remove(namesp);

                // Lưu thay đổi
                dbcontext.SaveChanges();
            }
            Response.Write("<div class=\"alert alert-success\" role=\"alert\">Xóa sản phẩm thành công.</div>");
            Response.Write("<script type=\"text/javascript\">");
            Response.Write("setTimeout(function() {");
            Response.Write("var elements = document.getElementsByClassName('alert');");
            Response.Write("for (var i = 0; i < elements.length; i++) {");
            Response.Write("elements[i].style.display = 'none';");
            Response.Write("}");
            Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
            Response.Write("</script>");
            Response.Redirect("ManagerProduct.aspx");
        }







        //protected void btDel_Click(object sender, EventArgs e)
        //{
        //    string deptId = lbMaSPV.Text;
        //    string deptName = lbName.Text;
        //    SanPham deparment = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == deptId);
        //    SanPham namesp = dbcontext.SanPhams.SingleOrDefault(p => p.TenSP == deptName && p.MaSP == deptId);

        //    if ( namesp.TenSP == lbName.Text && lbMaSPV.Text==deparment.MaSP)
        //    {
        //        // Xóa các bản ghi liên quan trong SanPhamData bằng truy vấn SQL
        //        dbcontext.Database.ExecuteSqlCommand("DELETE FROM SanPhamData WHERE MaSP = {0}", deptId);

        //            string checkMaSPQuery = "SELECT FROM SanPham WHERE MaSP = " + deptId;

        //            using (var db  = new QL_KPOPStoreEntities())
        //            {

        //            }




        //                // Xóa các bản ghi liên quan trong SanPhams
        //        if (deparment?.SPs != null)
        //        {
        //            foreach (var employeeMSP in deparment.SPs.ToList())
        //            {
        //                dbcontext.SanPhams.Remove(employeeMSP);
        //            }
        //        }

        //        if (namesp?.TSPs != null)
        //        {
        //            foreach (var employeeTSP in namesp.TSPs.ToList())
        //            {
        //                dbcontext.SanPhams.Remove(employeeTSP);
        //            }
        //        }

        //        // Xóa sản phẩm
        //        dbcontext.SanPhams.Remove(deparment);
        //        dbcontext.SanPhams.Remove(namesp);

        //        // Lưu thay đổi
        //        dbcontext.SaveChanges();
        //    }

        //    Response.Redirect("ManagerProduct.aspx");
        //}

        //protected void btDel_Click(object sender, EventArgs e)
        //{
        //    string deptId = lbDeptid.Text;
        //    string deptName = lbName.Text;
        //    SanPham deparment = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == deptId);
        //    SanPham namesp = dbcontext.SanPhams.SingleOrDefault(p => p.TenSP == deptName && p.MaSP == deptId);
        //    SanPhamData spData = dbcontext.SanPhamDatas.SingleOrDefault(s => s.MaSP == deptId);

        //    using (var connection = new SqlConnection(Shop.SQL_connectionString))
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand("DELETE FROM SanPhamData WHERE MaSP = @ID", connection))
        //        {
        //            command.Parameters.AddWithValue("@ID", deptId);
        //            command.ExecuteNonQuery();


        //        }
        //        connection.Close();

        //    }

        //    if (deparment.MaSP == lbDeptid.Text && namesp.TenSP == lbName.Text)
        //    {


        //        dbcontext.Database.ExecuteSqlCommand("DELETE FROM SanPhamData WHERE MaSP = {0}", deparment.MaSP);
        //        dbcontext.SaveChanges();
        //        // Check if spData.SPsData is not null before iterating over it
        //        if (spData?.SPsData != null)
        //        {
        //            foreach (var employeeSPData in spData.SPsData.ToList())
        //            {
        //                dbcontext.SanPhamDatas.Remove(employeeSPData);
        //            }
        //        }

        //        // Check if deparment.SPs is not null before iterating over it
        //        if (deparment?.SPs != null)
        //        {
        //            foreach (var employeeMSP in deparment.SPs.ToList())
        //            {
        //                dbcontext.SanPhams.Remove(employeeMSP);
        //            }
        //        }

        //        // Check if namesp.TSPs is not null before iterating over it
        //        if (namesp?.TSPs != null)
        //        {
        //            foreach (var employeeTSP in namesp.TSPs.ToList())
        //            {
        //                dbcontext.SanPhams.Remove(employeeTSP);
        //            }
        //        }


        //        dbcontext.SanPhams.Remove(deparment);
        //        dbcontext.SanPhams.Remove(namesp);

        //        dbcontext.SaveChanges();
        //    }

        //    //Nó bị phải xóa SPData mới xóa được SP

        //    Response.Redirect("ManagerProduct.aspx");
        //}

        //protected void btDel_Click(object sender, EventArgs e)
        //{
        //    //TK deparment = dbcontext.TKs.SingleOrDefault(p => p.Email == lbDeptid.Text);
        //    //try
        //    //{
        //    //    if (deparment.KhachHang.Count > 0)
        //    //    {
        //    //        ICollection<TK> employees = deparment.TKs;
        //    //        for (int i = 0; i < employees.Count; i++)
        //    //        {
        //    //            dbcontext.Employees.Remove(employees.ElementAt(i));
        //    //            dbcontext.SaveChanges();
        //    //        }
        //    //    }
        //    //    dbcontext.TKs.Remove(deparment);
        //    //    dbcontext.SaveChanges();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    throw;
        //    //}
        //    //Response.Redirect("Phong.aspx");
        //    string deptId = lbDeptid.Text;
        //    string deptName = lbName.Text;
        //    SanPham deparment = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == deptId);
        //    SanPham namesp = dbcontext.SanPhams.SingleOrDefault(p => p.TenSP == deptName && p.MaSP == deptId); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
        //    try
        //    {
        //        if (deparment.MaSP == lbDeptid.Text && namesp.TenSP == lbName.Text)
        //        {
        //            ICollection<SanPham> eMSP = deparment.SPs;
        //            foreach (var employeeMSP in eMSP.ToList())
        //            {

        //                dbcontext.SanPhams.Remove(employeeMSP);
        //                dbcontext.SaveChanges();

        //            }
        //            ICollection<SanPham> eTSP = namesp.TSPs;
        //            foreach (var employeeTSP in eTSP.ToList())
        //            {

        //                dbcontext.SanPhams.Remove(employeeTSP);
        //                dbcontext.SaveChanges();

        //            }
        //            dbcontext.SanPhams.Remove(deparment);
        //            dbcontext.SanPhams.Remove(namesp);

        //            dbcontext.SaveChanges();

        //        }



        //        dbcontext.SaveChanges();



        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    Response.Redirect("ManagerProduct.aspx");
        //}


    }
}