using Microsoft.Ajax.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;

namespace TH03_WebBanHang
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public string fileimgMT;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;
            var db = new QL_KPOPStoreEntities();
            if (user.Any(p => Sign.email != null && ((p.Email == Sign.email && Sign.email == "Admin") || ((p.Quyen == "Admin" || p.Quyen == "Manager") && p.Email == Sign.email))))
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
            //if (user.Any(p => (p.Email == "Admin" && p.TrangThai == true && p.Email == Sign.email && Sign.email == "Admin") || (p.Quyen == "Admin" || p.Quyen == "Manager") && p.TrangThai == true && p.Email == Sign.email))
            //{

            //}
            //// Otherwise, display an error message

            //else
            //{
            //    //Response.Write("<script>alert('Bạn không có quyền truy cập');</script>");
            //    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Bạn không có quyền truy cập!</div>");
            //    Response.Write("<script type=\"text/javascript\">");
            //    Response.Write("setTimeout(function() {");
            //    Response.Write("var elements = document.getElementsByClassName('alert');");
            //    Response.Write("for (var i = 0; i < elements.length; i++) {");
            //    Response.Write("elements[i].style.display = 'none';");
            //    Response.Write("}");
            //    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
            //    Response.Write("</script>");

            //    Response.Redirect("Error/401");

            //}
            if (!IsPostBack)
            {
                MaSPDropDownLists();


                PopulateDropDownLists();
                if (ViewState["checkPreOrderChecked"] != null)
                {
                    checkPreOrder.Checked = (bool)ViewState["checkPreOrderChecked"];
                }
                if (ViewState["checkHavePop"] != null)
                {
                    CheckboxOfPop.Checked = (bool)ViewState["checkHavePop"];
                }


                LoaiDropDownLists();



            }

        }
        private void PopulateDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                // Populate ddlCity
                var queryTP = from tp in context.Nhoms
                              select new { tp.MaNhom, tp.TenNhom };

                ddlMaNhom.DataSource = queryTP.ToList();
                ddlMaNhom.DataTextField = "TenNhom";
                ddlMaNhom.DataValueField = "MaNhom";
                ddlMaNhom.DataBind();
                ddlMaNhom.Items.Insert(0, new ListItem("Khác", "Khac"));


                ViewState["DropDownListsPopulated"] = true;
            }



        }
        private void MaSPDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                // Populate ddlCity
                var MaSPofVer = from masp in context.SanPhams
                                where masp.Ver != null
                                group masp by masp.Ver into g
                                select g.Select(masp => masp).FirstOrDefault();
                ddlMaSPofVer.DataSource = MaSPofVer.ToList();
                ddlMaSPofVer.DataTextField = "Ver";
                ddlMaSPofVer.DataValueField = "Ver";
                ddlMaSPofVer.DataBind();
                ddlMaSPofVer.Items.Insert(0, new ListItem("None", "None"));

            }



        }

        private void LoaiDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                // Populate ddlCity
                var queryLoai = from l in context.Loais
                                select new { l.MaLoai, l.TenLoai };

                ddlMaLoai.DataSource = queryLoai.ToList();
                ddlMaLoai.DataTextField = "TenLoai";
                ddlMaLoai.DataValueField = "MaLoai";
                ddlMaLoai.DataBind();
                //ddlMaNhom.Items.Insert(0, new ListItem("Khác", "Khac"));


                //ViewState["DropDownListsPopulated"] = true;


            }



        }


        protected void ddlMaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlMaNhom.SelectedValue == "Khac")
            {

                txtNewMaNhom.Visible = true;
                txtNewNhomName.Visible = true;
                fileUploadGPLogo.Visible = true;
                fileUploadGPmem.Visible = true;
                lbGpImage.Visible = true;
                lbLG.Visible = true;
                lbnameGp.Visible = true;
                lbNewMaNhom.Visible = true;


            }
            else
            {
                txtNewMaNhom.Visible = false;
                txtNewNhomName.Visible = false;
                fileUploadGPLogo.Visible = false;
                fileUploadGPmem.Visible = false;
                lbGpImage.Visible = false;
                lbLG.Visible = false;
                lbnameGp.Visible = false;
                lbNewMaNhom.Visible = false;

            }

        }

        protected void ddlMaSPofVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaSPofVer.SelectedValue == "None")
            {
                txtMaSP.Text = "";
                lbTenVerSP.Visible = false;
                txtTenVerSP.Visible = false;

            }
            else
            {
                lbTenVerSP.Visible = true;
                txtTenVerSP.Visible = true;
                txtMaSP.Text = ddlMaSPofVer.SelectedItem.Text;
                SanPham sanP = dbcontext.SanPhams.FirstOrDefault(s => s.Ver == txtMaSP.Text || s.MaSP == txtMaSP.Text);
                ddlMaNhom.SelectedValue = sanP.MaNhom;

            }
        }

        //private void CreateProduct(string imagePath, List<string> additionalImagePaths)
        //{
        //    using (var db = new QL_KPOPStoreEntities())
        //    {
        //        string maSP = txtMaSP.Text.Trim();
        //        string tenSP = txtTenSP.Text.Trim();
        //        float gia;
        //        if (!float.TryParse(txtGia.Text, out gia))
        //        {
        //            // Handle invalid price format
        //            Console.WriteLine("Invalid price format.");
        //            return;
        //        }
        //        string moTa = txtMoTa.Text.Trim();
        //        string maLoai = ddlMaLoai.SelectedValue;
        //        string MaNhom;

        //        if (ddlMaNhom.SelectedValue == "Khac")
        //        {
        //            MaNhom = txtNewMaNhom.Text.Trim();
        //        }
        //        else
        //        {
        //            MaNhom = ddlMaNhom.SelectedValue;
        //        }
        //        DateTime NgaySX;
        //        if (!DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX))
        //        {
        //            // Handle invalid date format
        //            Console.WriteLine("Invalid date format.");
        //            return;
        //        }
        //        int SLKho;
        //        if (!int.TryParse(txtGia.Text, out SLKho))
        //        {
        //            // Handle invalid stock quantity format
        //            Console.WriteLine("Invalid stock quantity format.");
        //            return;
        //        }


        //            var product = new SanPham
        //            {
        //                MaSP = maSP,
        //                TenSP = tenSP,
        //                Gia = gia,
        //                MoTa = moTa,
        //                MaLoai = maLoai,
        //                MaNhom = MaNhom,
        //                NgaySX = NgaySX,
        //                NgayNhap = DateTime.Now,
        //                DoanhSo = 0,
        //                SoLuongKho = SLKho,
        //                DuongDan = imagePath
        //            };
        //            var sanPhamData = new SanPhamData
        //            {
        //                MaSP = product.MaSP,
        //                AnhNote = fileimgMT,
        //                DuongDan1= imagePath
        //            };

        //        sanPhamData.DuongDan2 = null;
        //        sanPhamData.DuongDan3 = null;
        //        sanPhamData.DuongDan4 = null;
        //        sanPhamData.DuongDan5 = null;

        //        //for (int i = 0; i < additionalImagePaths.Count; i++)
        //        //{
        //        //    switch (i)
        //        //    {
        //        //        case 0:
        //        //            sanPhamData.DuongDan1 = additionalImagePaths[i];
        //        //            break;
        //        //        case 1:
        //        //            sanPhamData.DuongDan2 = additionalImagePaths[i];
        //        //            break;
        //        //        case 2:
        //        //            sanPhamData.DuongDan3 = additionalImagePaths[i];
        //        //            break;
        //        //        case 3:
        //        //            sanPhamData.DuongDan4 = additionalImagePaths[i];
        //        //            break;
        //        //        case 4:
        //        //            sanPhamData.DuongDan5 = additionalImagePaths[i];
        //        //            break;
        //        //    }
        //        //}


        //        db.SanPhams.Add(product);                
        //        db.SanPhamDatas.Add(sanPhamData);
        //        db.SaveChanges();


        //    }
        //}

        //private void CreateSanPhamData(List<string> additionalImagePaths)
        //{
        //    using (var db = new QL_KPOPStoreEntities())
        //    {

        //            string maSP = txtMaSP.Text;
        //            var sanPhamData = new SanPhamData
        //            {
        //                MaSP = maSP,
        //                AnhNote = fileimgMT,
        //            };

        //            // Đặt tất cả các đường dẫn hình ảnh không sử dụng thành null
        //            sanPhamData.DuongDan1 = null;
        //            sanPhamData.DuongDan2 = null;
        //            sanPhamData.DuongDan3 = null;
        //            sanPhamData.DuongDan4 = null;
        //            sanPhamData.DuongDan5 = null;

        //            // Sử dụng vòng lặp để thêm các đường dẫn hình ảnh vào đối tượng
        //            for (int i = 0; i < additionalImagePaths.Count; i++)
        //            {
        //                switch (i)
        //                {
        //                    case 0:
        //                        sanPhamData.DuongDan1 = additionalImagePaths[i];
        //                        break;
        //                    case 1:
        //                        sanPhamData.DuongDan2 = additionalImagePaths[i];
        //                        break;
        //                    case 2:
        //                        sanPhamData.DuongDan3 = additionalImagePaths[i];
        //                        break;
        //                    case 3:
        //                        sanPhamData.DuongDan4 = additionalImagePaths[i];
        //                        break;
        //                    case 4:
        //                        sanPhamData.DuongDan5 = additionalImagePaths[i];
        //                        break;
        //                }
        //            }

        //            db.SanPhamDatas.Add(sanPhamData);
        //            db.SaveChanges();


        //    }

        //}


        //protected void btnAddProduct_Click(object sender, EventArgs e)
        //{

        //    QL_KPOPStoreEntities sp = new QL_KPOPStoreEntities();
        //    if(ddlMaNhom.SelectedValue == "Khac")
        //    {
        //        string uploadFolderPathIconKPOP = Server.MapPath("~/Content/icon-group-kpop/");
        //        string uploadFolderPathImageKPOP = Server.MapPath("~/Content/image-group-kpop/");
        //        string srcLogo= string.Empty;
        //        string srcGpImg= string.Empty;
        //        if (fileUploadGPLogo.HasFile)
        //        {
        //            string fileName = Path.GetFileName(fileUploadGPLogo.FileName);
        //            string filePath = Path.Combine(uploadFolderPathIconKPOP, fileName);
        //            fileUploadGPLogo.SaveAs(filePath);
        //            srcLogo = filePath;
        //            // Xử lý ảnh đã lưu
        //        }

        //        if (fileUploadGPmem.HasFile)
        //        {
        //            string fileName = Path.GetFileName(fileUploadGPmem.FileName);
        //            string filePath = Path.Combine(uploadFolderPathImageKPOP, fileName);
        //            fileUploadGPmem.SaveAs(filePath);
        //            srcGpImg = filePath;


        //        }
        //        using (var db = new QL_KPOPStoreEntities())
        //        {
        //            string maNhom = txtNewMaNhom.Text;

        //            var newNhom = new Nhom
        //            {
        //                MaNhom = maNhom,
        //                TenNhom = txtNewNhomName.Text,
        //                DuongDan = srcLogo,
        //                AnhNhom = srcGpImg,

        //            };

        //            db.Nhoms.Add(newNhom);
        //            db.SaveChanges();
        //        }


        //    }
        //    else
        //    {
        //        if (sp.SanPhams.Any(p => p.MaSP == txtMaSP.Text))
        //        {

        //        //Response.Write("<script>alert('Sản phẩm đã tồn tại');</script>");
        //        Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Sản phẩm đã tồn tại!</div>");
        //        Response.Write("<script type=\"text/javascript\">");
        //        Response.Write("setTimeout(function() {");
        //        Response.Write("var elements = document.getElementsByClassName('alert');");
        //        Response.Write("for (var i = 0; i < elements.length; i++) {");
        //        Response.Write("elements[i].style.display = 'none';");
        //        Response.Write("}");
        //        Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
        //        Response.Write("</script>");

        //        }
        //        else
        //        {
        //        string uploadFolderPath = Server.MapPath("~/Content/items/");
        //        string loaiFolder = "";
        //        switch (ddlMaLoai.SelectedValue)
        //        {
        //            case "1":
        //                loaiFolder = "alb";
        //                break;
        //            case "2":
        //                loaiFolder = "ssg";
        //                break;
        //            case "3":
        //                loaiFolder = "blr&cd";
        //                break;
        //            case "4":
        //                loaiFolder = "md";
        //                break;
        //        }

        //        string nhomFolder = ddlMaNhom.SelectedItem.Text.ToLower().Replace(" ", "");

        //        string finalFolderPath = Path.Combine(uploadFolderPath, nhomFolder, loaiFolder);

        //        if (Request.Files.Count > 0)
        //        {
        //            string mainImagePath = null;
        //            List<string> additionalImagePaths = new List<string>();

        //            if (!Directory.Exists(finalFolderPath))
        //            {
        //                Directory.CreateDirectory(finalFolderPath);
        //            }

        //            for (int i = 0; i < Request.Files.Count; i++)
        //            {
        //                HttpPostedFile file = Request.Files[i];
        //                if (file != null && file.ContentLength > 0)
        //                {
        //                    string fileName = Path.GetFileName(file.FileName);
        //                    string filePath = Path.Combine(finalFolderPath, fileName);
        //                    file.SaveAs(filePath);

        //                    if (i == 0) // Ảnh chính
        //                    {
        //                        mainImagePath = filePath;
        //                    }
        //                    else // Ảnh phụ
        //                    {
        //                        additionalImagePaths.Add(filePath);
        //                    }
        //                }
        //            }
        //                if (fileImageMoTa.HasFile)
        //                {

        //                    if (!Directory.Exists(finalFolderPath))
        //                    {
        //                        Directory.CreateDirectory(finalFolderPath);
        //                    }

        //                    string fileName = Path.GetFileName(fileImageMoTa.FileName);
        //                    string filePath = Path.Combine(finalFolderPath, fileName);
        //                    fileImageMoTa.SaveAs(filePath);

        //                    fileimgMT = filePath;

        //                }
        //                using (var db = new QL_KPOPStoreEntities())
        //                {
        //                    string maSP = txtMaSP.Text.Trim();
        //                    string tenSP = txtTenSP.Text.Trim();
        //                    float gia;
        //                    if (!float.TryParse(txtGia.Text, out gia))
        //                    {
        //                        // Handle invalid price format
        //                        Console.WriteLine("Invalid price format.");
        //                        return;
        //                    }
        //                    string moTa = txtMoTa.Text.Trim();
        //                    string maLoai = ddlMaLoai.SelectedValue;
        //                    string MaNhom;

        //                    if (ddlMaNhom.SelectedValue == "Khac")
        //                    {
        //                        MaNhom = txtNewMaNhom.Text.Trim();
        //                    }
        //                    else
        //                    {
        //                        MaNhom = ddlMaNhom.SelectedValue;
        //                    }
        //                    DateTime NgaySX;
        //                    if (!DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX))
        //                    {
        //                        // Handle invalid date format
        //                        Console.WriteLine("Invalid date format.");
        //                        return;
        //                    }
        //                    int SLKho;
        //                    if (!int.TryParse(txtGia.Text, out SLKho))
        //                    {
        //                        // Handle invalid stock quantity format
        //                        Console.WriteLine("Invalid stock quantity format.");
        //                        return;
        //                    }


        //                    var product = new SanPham
        //                    {
        //                        MaSP = maSP,
        //                        TenSP = tenSP,
        //                        Gia = gia,
        //                        MoTa = moTa,
        //                        MaLoai = maLoai,
        //                        MaNhom = MaNhom,
        //                        NgaySX = NgaySX,
        //                        NgayNhap = DateTime.Now,
        //                        DoanhSo = 0,
        //                        SoLuongKho = SLKho,
        //                        DuongDan = mainImagePath
        //                    };
        //                    var sanPhamData = new SanPhamData
        //                    {
        //                        MaSP = product.MaSP,
        //                        AnhNote = fileimgMT,
        //                        DuongDan1 = mainImagePath
        //                    };

        //                    sanPhamData.DuongDan2 = null;
        //                    sanPhamData.DuongDan3 = null;
        //                    sanPhamData.DuongDan4 = null;
        //                    sanPhamData.DuongDan5 = null;

        //                    for (int i = 0; i < additionalImagePaths.Count; i++)
        //                    {
        //                        switch (i)
        //                        {
        //                            case 0:
        //                                sanPhamData.DuongDan1 = additionalImagePaths[i];
        //                                break;
        //                            case 1:
        //                                sanPhamData.DuongDan2 = additionalImagePaths[i];
        //                                break;
        //                            case 2:
        //                                sanPhamData.DuongDan3 = additionalImagePaths[i];
        //                                break;
        //                            case 3:
        //                                sanPhamData.DuongDan4 = additionalImagePaths[i];
        //                                break;
        //                            case 4:
        //                                sanPhamData.DuongDan5 = additionalImagePaths[i];
        //                                break;
        //                        }
        //                    }


        //                    db.SanPhams.Add(product);
        //                    db.SanPhamDatas.Add(sanPhamData);
        //                    db.SaveChanges();


        //                }

        //                // Tạo sản phẩm với đường dẫn ảnh chính
        //                //CreateProduct(mainImagePath, additionalImagePaths);

        //                // Tạo SanPhamData với đường dẫn ảnh phụ
        //                //CreateSanPhamData(additionalImagePaths);

        //                //string dataSource = "DUC-LAPTOP\\NGUYENHOANGDUC";
        //                //string initialCatalog = "QL_KPOPStore";
        //                //string sqlTK = "sa";
        //                //string sqlMK = "1";
        //                ////string dataSource = "SQL9001.site4now.net";
        //                ////string initialCatalog = "db_aa6a91_sa";
        //                ////string sqlTK = "db_aa6a91_sa";
        //                ////string sqlMK = "26072003Duc";
        //                //string connectionString = "Data Source=" + dataSource + ";Initial Catalog=" + initialCatalog + ";User ID=" + sqlTK + ";Password=" + sqlMK + ";";

        //                //using (SqlConnection connection = new SqlConnection(connectionString))
        //                //{
        //                //    using (SqlCommand command = new SqlCommand("Product_Add", connection))
        //                //    {
        //                //        command.CommandType = CommandType.StoredProcedure;

        //                //        command.Parameters.AddWithValue("@MaSP", maSP);
        //                //        command.Parameters.AddWithValue("@TenSP", tenSP);
        //                //        command.Parameters.AddWithValue("@Gia", gia);
        //                //        command.Parameters.AddWithValue("@MoTa", moTa);
        //                //        command.Parameters.AddWithValue("@MaLoai", maLoai);
        //                //        command.Parameters.AddWithValue("@MaNhom", MaNhom);
        //                //        if (fileUpload.HasFile)
        //                //        {
        //                //            string uploadFolderPath = Server.MapPath("Content/img/");
        //                //            string fileName = Path.GetFileName(fileUpload.FileName);
        //                //            string fileExtension = Path.GetExtension(fileUpload.FileName);

        //                //            string filePath = Path.Combine(uploadFolderPath, fileName);

        //                //            // Lấy đường dẫn từ "Content" trở đi
        //                //            string relativePath = filePath.Substring(filePath.IndexOf("Content"));

        //                //            command.Parameters.AddWithValue("@DuongDan", relativePath);

        //                //            fileUpload.SaveAs(filePath);

        //                //        }
        //                //        connection.Open();
        //                //        command.ExecuteNonQuery();
        //                //    }
        //                //}
        //            }



        //    }
        //    }





        //}



        protected void checkHavePop_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem CheckBox đã được tích chưa
            if (CheckboxOfPop.Checked)
            {
                // Nếu CheckBox được tích, ẩn TextBox
                lbPopName.Visible = true;
                txtPopName.Visible = true;


            }
            else
            {
                lbPopName.Visible = false;
                txtPopName.Visible = false;
            }
            ViewState["checkHavePop"] = CheckboxOfPop.Checked;
        }
        protected void checkPreOrder_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem CheckBox đã được tích chưa
            if (checkPreOrder.Checked)
            {
                // Nếu CheckBox được tích, ẩn TextBox
                txtSLKho.Visible = false;
                lbSL.Visible = false;
                lbNgayHH.Visible = true;
                txtNgayHH.Visible = true;

            }
            else
            {
                // Nếu CheckBox không được tích, hiển thị TextBox
                txtSLKho.Visible = true;
                lbSL.Visible = true;
                lbNgayHH.Visible = false;
                txtNgayHH.Visible = false;
            }
            ViewState["checkPreOrderChecked"] = checkPreOrder.Checked;
        }




        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities sp = new QL_KPOPStoreEntities();

            if (txtMaSP.Text.IsNullOrWhiteSpace() || txtTenSP.Text.IsNullOrWhiteSpace() || txtGia.Text.IsNullOrWhiteSpace() || txtNgay.Text.IsNullOrWhiteSpace())
            {
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Thông tin sản phẩm chưa được nhập!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");
            }
            if (sp.SanPhams.Any(p => p.MaSP == txtMaSP.Text))
            {

                //Response.Write("<script>alert('Sản phẩm đã tồn tại');</script>");
                Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Sản phẩm đã tồn tại!</div>");
                Response.Write("<script type=\"text/javascript\">");
                Response.Write("setTimeout(function() {");
                Response.Write("var elements = document.getElementsByClassName('alert');");
                Response.Write("for (var i = 0; i < elements.length; i++) {");
                Response.Write("elements[i].style.display = 'none';");
                Response.Write("}");
                Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                Response.Write("</script>");

            }
            else { 

                string Ver = null;
                if (ddlMaSPofVer.SelectedValue == "None")
                {
                    Ver = null;
                }
                else
                {


                    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(s => s.TenSP.Contains(txtTenSP.Text) || s.TenSP == txtTenSP.Text || s.MaSP == txtMaSP.Text || s.MaSP.Contains(txtMaSP.Text));




                    string tenSP = txtTenVerSP.Text;

                    tenSP = Regex.Replace(tenSP, sanPham.TenSP, "");

                    // Loại bỏ tất cả các khoảng trắng
                    tenSP = tenSP.Replace(" ", "");

                    tenSP = tenSP.Trim();
                    Ver = tenSP;
                }



                if (sp.Nhoms.Any(p => p.MaNhom == txtNewMaNhom.Text))
                {

                    //Response.Write("<script>alert('Sản phẩm đã tồn tại');</script>");
                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Nhóm nhạc / Nghệ sĩ đã tồn tại!</div>");
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
                    // Xác định chuỗi kết nối
                    //string dataSource = Shop.SQL_dataSource /*"DUC-LAPTOP\\NGUYENHOANGDUC"*/;
                    //string initialCatalog = Shop.SQL_initialCatalog /*"QL_KPOPStore"*/;
                    //string sqlTK = Shop.SQL_sqlTK /*"sa"*/;
                    //string sqlMK = Shop.SQL_sqlMK  /*"1"*/;
                    //string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={sqlTK};Password={sqlMK};";
                    string nhomFolder;

                    string relativePathGOMem;
                    string relativePathGOLogo;
                    if (ddlMaNhom.SelectedValue == "Khac")
                    {
                        nhomFolder = txtNewNhomName.Text.ToLower().Replace(" ", "");
                        string targetDirectoryGPmem = Server.MapPath("Content/image-group-kpop/");
                        string targetDirectoryGPLogo = Server.MapPath("Content/icon-group-kpop/");
                        string fileNameLogo = Path.GetFileName(fileUploadGPLogo.FileName);
                        string targetPathLogo = Path.Combine(targetDirectoryGPLogo, fileNameLogo);
                        relativePathGOLogo = targetPathLogo.Substring(targetPathLogo.IndexOf("Content"));
                        string fileNameMem = Path.GetFileName(fileUploadGPmem.FileName);
                        string targetPathMem = Path.Combine(targetDirectoryGPmem, fileNameMem);
                        relativePathGOMem = targetPathMem.Substring(targetPathMem.IndexOf("Content"));
                        // Kiểm tra xem có ảnh nào được chọn
                        if (fileUploadGPmem.HasFile || fileUploadGPLogo.HasFile)
                        {
                            // Kiểm tra và lưu ảnh logo
                            if (fileUploadGPmem.HasFile)
                            {


                                fileUploadGPmem.SaveAs(targetPathMem);
                            }
                            else
                            {
                                // Nếu không có ảnh logo, đặt giá trị null
                                relativePathGOLogo = null;
                            }

                            // Kiểm tra và lưu ảnh member
                            if (fileUploadGPLogo.HasFile)
                            {


                                fileUploadGPLogo.SaveAs(targetPathLogo);
                            }
                            else
                            {
                                // Nếu không có ảnh member, đặt giá trị null
                                relativePathGOMem = null;
                            }

                            // Kiểm tra xem thư mục đích có tồn tại, nếu không thì tạo thư mục
                            if (!Directory.Exists(targetDirectoryGPmem))
                            {
                                Directory.CreateDirectory(targetDirectoryGPmem);
                            }
                            using (var context = new QL_KPOPStoreEntities())
                            {
                                var newIdols = new Nhom()
                                {
                                    MaNhom = txtNewMaNhom.Text.Trim(),
                                    TenNhom = txtNewNhomName.Text.Trim(),
                                    AnhNhom = relativePathGOMem,
                                    DuongDan = relativePathGOLogo,
                                };

                                context.Nhoms.Add(newIdols);
                                context.SaveChanges();
                            }

                            // Thêm logic để lưu hoặc xử lý đối tượng newIdols
                        }
                        else
                        {

                        }


                    }
                    else
                    {
                        relativePathGOMem = null;
                        relativePathGOLogo = null;
                        nhomFolder = ddlMaNhom.SelectedItem.Text.ToLower().Replace(" ", "");
                    }
                    string maSP;
                    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(s => s.TenSP.Contains(txtTenSP.Text) || s.TenSP == txtTenSP.Text || s.MaSP == txtMaSP.Text || s.MaSP.Contains(txtMaSP.Text));

                    // Thông tin sản phẩm
                    if (ddlMaSPofVer.SelectedValue == "None")
                    {
                        maSP = txtMaSP.Text;

                    }

                    else
                    {
                        maSP = txtMaSP.Text + Ver;
                        maSP = Regex.Replace(maSP, sanPham.TenSP, "");
                    }


                    maSP = maSP.Replace(" ", "");

                    //maSP.Replace(" ", "");

                    string tenSP = txtTenSP.Text.Trim();
                    float gia = float.Parse(txtGia.Text);
                    string moTa = txtMoTa.Text;
                    string tenLoai = ddlMaLoai.SelectedItem.Text.ToLower().Replace("-", "").Replace("/", "");

                    string MaNhom = ddlMaNhom.SelectedValue == "Khac" ? txtNewMaNhom.Text.Trim() : ddlMaNhom.SelectedValue;

                    bool PreOrder;

                    DateTime NgaySX;

                    DateTime? NgayHH;
                    DateTime tempNgayHH;


                    //DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX); /*DateTime.ParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);*/
                    DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX);


                    if (checkPreOrder.Checked)
                    {
                        PreOrder = true;
                        if (DateTime.TryParseExact(txtNgayHH.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempNgayHH))
                        {
                            NgayHH = tempNgayHH;
                        }
                        else
                        {
                            NgayHH = null;
                        }


                    }
                    else { NgayHH = null; PreOrder = false; }


                    //int SLKho = int.Parse(txtSLKho.Text); // Giả định txtGia.Text chứa số lượng kho
                    int SLKho;
                    if (checkPreOrder.Checked)
                    {

                        SLKho = int.MaxValue;

                    }
                    else
                    {

                        SLKho = int.Parse(txtSLKho.Text);

                    }

                    // Đường dẫn lưu ảnh
                    string uploadFolderPath = Server.MapPath("Content/items/");
                    //string loaiFolder = ddlMaLoai.SelectedValue; // Giả định ddlMaLoai.SelectedValue chứa tên thư mục
                    string loaiFolder = ddlMaLoai.SelectedItem.Text.ToLower().Replace("-", "").Replace("/", "");
                    string finalFolderPath = Path.Combine(uploadFolderPath, nhomFolder, loaiFolder);

                    //// Kiểm tra và lưu ảnh
                    //if (fileUploadGPLogo.HasFile)
                    //{
                    //    string fileName = Path.GetFileName(fileUploadGPLogo.FileName);
                    //    string filePath = Path.Combine(finalFolderPath, fileName);
                    //    fileUploadGPLogo.SaveAs(filePath);

                    //}

                    // Sử dụng SqlConnection và SqlCommand để gọi Stored Procedure
                    using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
                    {
                        string mainImagePath = null;
                        List<string> additionalImagePaths = new List<string>();

                        if (!Directory.Exists(finalFolderPath))
                        {
                            Directory.CreateDirectory(finalFolderPath);
                        }


                        //connection.Open();
                        //using (SqlCommand command = new SqlCommand("Product_Add", connection))
                        //{
                        //    command.CommandType = CommandType.StoredProcedure;

                        //    // Thêm các tham số vào SqlCommand
                        //    command.Parameters.AddWithValue("@MaSP", maSP);
                        //    command.Parameters.AddWithValue("@TenSP", tenSP);
                        //    command.Parameters.AddWithValue("@Gia", gia);
                        //    command.Parameters.AddWithValue("@MoTa", moTa);
                        //    command.Parameters.AddWithValue("@MaLoai", maLoai);
                        //    command.Parameters.AddWithValue("@MaNhom", MaNhom);
                        //    command.Parameters.AddWithValue("@NgaySX", NgaySX);
                        //    command.Parameters.AddWithValue("@SoLuongKho", SLKho);
                        //    command.Parameters.AddWithValue("@DuongDan", mainImagePath);
                        //    command.Parameters.AddWithValue("@NgayNhap", DateTime.Now);
                        //    command.Parameters.AddWithValue("@DoanhSo", 0);

                        //}
                        //string selectedImageName;  
                        //selectedImageName = Request.Form["selectedImages"];

                        string selectedImageName = hiddenSelectedImageName.Value;


                        string checkMaSPQuery = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
                        using (SqlCommand checkCommand = new SqlCommand(checkMaSPQuery, connection))
                        {
                            //checkCommand.Parameters.AddWithValue("@MaSP", maSP);

                            //int count = (int)checkCommand.ExecuteScalar();


                            //if (count == 0)
                            //{
                            // Step 2: Insert MaSP into SanPham table if it does not exist

                            string insertMaSPQuery = "INSERT INTO SanPham (MaSP, TenSP, Gia, MoTa, MaLoai, MaNhom, NgaySX, NgayHH, SoLuongKho, DuongDan, NgayNhap, DoanhSo, Ver, TenVer, NguonHang) VALUES (@MaSP, @TenSP, @Gia, @MoTa, @MaLoai, @MaNhom, @NgaySX,@NgayHH, @SoLuongKho, @DuongDan, @NgayNhap, @DoanhSo, @Ver, @TenVer, @NguonHang)";
                            using (SqlCommand insertCommand = new SqlCommand(insertMaSPQuery, connection))
                            {
                                // Add parameters for the insert command once before the loop
                                insertCommand.Parameters.AddWithValue("@MaSP", maSP.Replace(" ", ""));
                                insertCommand.Parameters.AddWithValue("@TenSP", tenSP);
                                insertCommand.Parameters.AddWithValue("@Gia", gia);
                                insertCommand.Parameters.AddWithValue("@MoTa", moTa);
                                insertCommand.Parameters.AddWithValue("@MaLoai", ddlMaLoai.SelectedValue);
                                insertCommand.Parameters.AddWithValue("@MaNhom", MaNhom);
                                insertCommand.Parameters.AddWithValue("@NgaySX", NgaySX);
                                insertCommand.Parameters.AddWithValue("@NguonHang", txtNguonHang.Text);
                                //insertCommand.Parameters.AddWithValue("@Ver", Ver);
                                insertCommand.Parameters.AddWithValue("@Ver", txtMaSP.Text);

                                if (Ver != null)
                                {
                                    insertCommand.Parameters.AddWithValue("@TenVer", txtTenVerSP.Text);

                                }
                                else
                                {
                                    //insertCommand.Parameters.AddWithValue("@Ver", DBNull.Value);
                                    if (txtTenVerSP.Text.IsNullOrEmpty())
                                    {
                                        insertCommand.Parameters.AddWithValue("@TenVer", DBNull.Value);
                                    }
                                    else
                                    {
                                        insertCommand.Parameters.AddWithValue("@TenVer", txtTenVerSP.Text);
                                    }


                                }



                                if (NgayHH.HasValue)
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayHH", NgayHH.Value);
                                }
                                else
                                {
                                    // Sử dụng DBNull.Value nếu NgayHH không có giá trị
                                    insertCommand.Parameters.AddWithValue("@NgayHH", DBNull.Value);
                                }


                                insertCommand.Parameters.AddWithValue("@SoLuongKho", SLKho);
                                insertCommand.Parameters.AddWithValue("@NgayNhap", DateTime.Now);
                                insertCommand.Parameters.AddWithValue("@DoanhSo", 0);



                                for (int i = 0; i < Request.Files.Count; i++)
                                {
                                    HttpPostedFile file = Request.Files[i];

                                    if (file != null && file.ContentLength > 0)
                                    {
                                        string fileNameMain = Path.GetFileName(hiddenSelectedImageName.Value);

                                        string fileName = Path.GetFileName(file.FileName);
                                        string filePath = Path.Combine(finalFolderPath, fileName);

                                        //if (selectedImageName != null)
                                        //{
                                        string filePathMain = Path.Combine(finalFolderPath, fileNameMain);

                                        //}
                                        //else
                                        //{
                                        //    filePathMain = Path.Combine(finalFolderPath, fileName);
                                        //}

                                        string relativePath = filePath.Substring(filePath.IndexOf("Content"));
                                        string relativePathMain = filePathMain.Substring(filePathMain.IndexOf("Content"));

                                        string absolutePathMain = Server.MapPath(relativePathMain);
                                        file.SaveAs(filePath);
                                        file.SaveAs(absolutePathMain);

                                        if (i == 0) // Main image
                                        {

                                            mainImagePath = relativePathMain;


                                        }
                                        else // Additional images
                                        {
                                            additionalImagePaths.Add(relativePath);
                                        }
                                    }
                                }

                                // Set the main image path as the DuongDan parameter
                                insertCommand.Parameters.AddWithValue("@DuongDan", mainImagePath);

                                // Execute the insert command once after setting all parameters

                                /////POP


                                connection.Open();
                                insertCommand.ExecuteNonQuery();

                                connection.Close();
                            }
                            if (CheckboxOfPop.Checked)
                            {
                                string MaPob = MaPob = txtMaSP.Text.Trim() + txtPopName.Text.Trim();

                                string insertPopSPQuery = "INSERT INTO POB (MaPob, TenPob, MaSP) VALUES (@MaPob, @TenPob, @MaSP)";
                                using (SqlCommand insertPopCommand = new SqlCommand(insertPopSPQuery, connection))
                                {
                                    insertPopCommand.Parameters.AddWithValue("@MaPob", MaPob);
                                    insertPopCommand.Parameters.AddWithValue("@TenPob", txtPopName.Text);
                                    insertPopCommand.Parameters.AddWithValue("@MaSP", maSP.Replace(" ", ""));
                                    connection.Open();
                                    insertPopCommand.ExecuteNonQuery();

                                    connection.Close();

                                }
                                //POP pOP = new POP()
                                //{
                                //    MaPob = maSP.Replace(" ", "").Trim() + txtPopName.Text.Trim(),
                                //    TenPob = txtPopName.Text,
                                //    MaSP = maSP.Replace(" ", ""),
                                //};
                                //dbcontext.POPs.Add(pOP);
                                //dbcontext.SaveChanges();
                            }
                            else
                            {

                            }
                            // Now, call the ProductData_Add stored procedure
                            using (SqlCommand command = new SqlCommand("ProductData_Add", connection))
                            {

                                command.CommandType = CommandType.StoredProcedure;
                                string fileNameMain = Path.GetFileName(hiddenSelectedImageName.Value);


                                //if (selectedImageName != null)
                                //{
                                string filePathMain = Path.Combine(finalFolderPath, fileNameMain);

                                //}
                                //else
                                //{
                                //    string fileName ="";
                                //    for (int i = 0; i < Request.Files.Count; i++)
                                //    {
                                //        HttpPostedFile file = Request.Files[i];
                                //        fileName = Path.GetFileName(file.FileName);

                                //    }
                                //    string fileNameMem = Path.GetFileName(fileUploadGPmem.FileName);
                                //    string fileNameLogo = Path.GetFileName(fileUploadGPLogo.FileName);




                                //    if (fileName != fileNameMem || fileName != fileNameLogo)
                                //    {
                                //        filePathMain = Path.Combine(finalFolderPath, fileName);

                                //    }
                                //    else
                                //    {
                                //        filePathMain = null;
                                //    }

                                //}

                                //string filePathMain = Path.Combine(finalFolderPath, selectedImageName);                                
                                string relativePathMain = filePathMain.Substring(filePathMain.IndexOf("Content"));


                                string absolutePathMain = Server.MapPath(relativePathMain);

                                for (int i = 0; i < Request.Files.Count; i++)
                                {
                                    HttpPostedFile file = Request.Files[i];
                                    if (file != null && file.ContentLength > 0)
                                    {


                                        string fileName = Path.GetFileName(file.FileName);

                                        string fileNameMem = Path.GetFileName(fileUploadGPmem.FileName);
                                        string fileNameLogo = Path.GetFileName(fileUploadGPLogo.FileName);



                                        string filePath;
                                        string relativePath;
                                        if (fileName == fileNameMem || fileName == fileNameLogo)
                                        {
                                            filePath = null;


                                            relativePath = null;
                                        }
                                        else
                                        {
                                            filePath = Path.Combine(finalFolderPath, fileName);


                                            relativePath = filePath.Substring(filePath.IndexOf("Content"));
                                            file.SaveAs(filePath);
                                            file.SaveAs(absolutePathMain);

                                        }

                                        //file.SaveAs(filePath);
                                        //file.SaveAs(absolutePathMain);


                                        string fileNameMT1 = Path.GetFileName(fileImageMoTa.FileName);

                                        if (i == 0) // Main image
                                        {
                                            if (fileNameMem != null && fileNameLogo != null)
                                            {
                                                if (fileName == fileNameMem || fileName == fileNameLogo || fileName == fileNameMT1)
                                                {
                                                    mainImagePath = null;
                                                    relativePath = null;
                                                    additionalImagePaths.Add(relativePath);
                                                }
                                            }
                                            mainImagePath = relativePathMain;


                                        }
                                        else // Additional images
                                        {
                                            if (relativePath != relativePathMain || relativePath != absolutePathMain || !relativePath.Contains(fileNameMem) || !relativePath.Contains(fileNameLogo))
                                            {
                                                additionalImagePaths.Add(relativePath);
                                            }
                                            else
                                            {
                                                relativePath = null;
                                                additionalImagePaths.Add(relativePath);
                                            }

                                        }



                                    }
                                }


                                string fileNameMT = null;
                                string filePathMT = null;
                                string relativePathMT;

                                // Kiểm tra xem fileImageMoTa có chứa tên tệp không
                                if (!string.IsNullOrEmpty(fileImageMoTa?.FileName))
                                {
                                    fileNameMT = Path.GetFileName(fileImageMoTa.FileName);
                                    filePathMT = Path.Combine(finalFolderPath, fileNameMT);

                                    // Lưu tệp ảnh
                                    fileImageMoTa.SaveAs(filePathMT);

                                    // Tạo đường dẫn relative
                                    relativePathMT = filePathMT.Substring(filePathMT.IndexOf("Content"));
                                    fileimgMT = relativePathMT;
                                }
                                else
                                {

                                    fileimgMT = "";


                                }


                                //string fileNameMT = Path.GetFileName(fileImageMoTa.FileName);


                                //string filePathMT = Path.Combine(finalFolderPath, fileNameMT);



                                //fileImageMoTa.SaveAs(filePathMT);
                                //string relativePathMT = filePathMT.Substring(filePathMT.IndexOf("Content"));


                                //if (mainImagePath == relativePathMT)
                                //{
                                //        mainImagePath = null;
                                //}


                                string[] DuongDan = new string[5];
                                string DuongDan2 = null;
                                string DuongDan3 = null;
                                string DuongDan4 = null;
                                string DuongDan5 = null;
                                string MainDP;
                                string fileNameMem1 = Path.GetFileName(fileUploadGPmem.FileName);
                                string fileNameLogo1 = Path.GetFileName(fileUploadGPLogo.FileName);
                                // Add parameters for the ProductData_Add stored procedure

                                command.Parameters.AddWithValue("@MaSP", maSP);
                                command.Parameters.AddWithValue("@AnhNote", fileimgMT); // Assuming fileimgMT is defined elsewhere

                                if (CheckboxOfPop.Checked)
                                {
                                    command.Parameters.AddWithValue("@Pob", true);
                                }
                                else command.Parameters.AddWithValue("@Pob", false);


                                command.Parameters.AddWithValue("@DuongDan1", mainImagePath);

                                command.Parameters.AddWithValue("@IsPreOrder", PreOrder);
                                //command.Parameters.AddWithValue("@Ver", Ver);


                                //if (Ver != null)
                                //{
                                //    command.Parameters.AddWithValue("@Ver", Ver);
                                //}
                                //else
                                //{
                                //    command.Parameters.AddWithValue("@Ver", DBNull.Value);
                                //}





                                for (int i = 0; i < Request.Files.Count; i++)
                                {
                                    HttpPostedFile file = Request.Files[i];
                                    if (file != null && file.ContentLength > 0)
                                    {


                                        string fileName = Path.GetFileName(file.FileName);

                                        string fileNameMem = Path.GetFileName(fileUploadGPmem.FileName);
                                        string fileNameLogo = Path.GetFileName(fileUploadGPLogo.FileName);
                                        string filePath;
                                        string relativePath;
                                        if (fileName == fileNameMem || fileName == fileNameLogo)
                                        {
                                            filePath = null;
                                            relativePath = null;
                                        }
                                        else
                                        {
                                            filePath = Path.Combine(finalFolderPath, fileName);
                                            relativePath = filePath.Substring(filePath.IndexOf("Content"));
                                            file.SaveAs(filePath);
                                        }






                                        if (relativePath == fileimgMT || relativePath == mainImagePath || relativePath == relativePathGOMem || relativePath == relativePathGOLogo)
                                        {
                                            // If the path is the same, assign null to the corresponding DuongDan variable
                                            if (i < DuongDan.Length) // Ensure we don't go out of bounds
                                            {
                                                DuongDan[i] = null;
                                            }
                                        }
                                        else
                                        {
                                            // If the path is different, assign it to the corresponding DuongDan variable
                                            if (i < DuongDan.Length) // Ensure we don't go out of bounds
                                            {
                                                DuongDan[i] = relativePath;
                                            }
                                        }



                                    }
                                }

                                //command.Parameters.AddWithValue("@DuongDan1", DuongDan1 ?? (object)DBNull.Value);

                                //command.Parameters.AddWithValue("@DuongDan2", DuongDan2 ?? (object)DBNull.Value);
                                //command.Parameters.AddWithValue("@DuongDan3", DuongDan3 ?? (object)DBNull.Value);
                                //command.Parameters.AddWithValue("@DuongDan4", DuongDan4 ?? (object)DBNull.Value);
                                //command.Parameters.AddWithValue("@DuongDan5", DuongDan5 ?? (object)DBNull.Value);
                                for (int i = 1; i < DuongDan.Length; i++)
                                {
                                    string paramName = "@DuongDan" + (i + 1).ToString();
                                    command.Parameters.AddWithValue(paramName, DuongDan[i - 1] ?? (object)DBNull.Value);
                                }

                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();
                            }

                            //using (SqlCommand insertCommand = new SqlCommand(insertMaSPQuery, connection))
                            //{
                            //    //if (fileUpload.HasFile)
                            //    //{
                            //    //    string uploadFolderPath = Server.MapPath("Content/img/");
                            //    //    string fileName = Path.GetFileName(fileUpload.FileName);
                            //    //    string fileExtension = Path.GetExtension(fileUpload.FileName);

                            //    //    string filePath = Path.Combine(uploadFolderPath, fileName);

                            //    //    // Lấy đường dẫn từ "Content" trở đi
                            //    //    string relativePath = filePath.Substring(filePath.IndexOf("Content"));

                            //    //    command.Parameters.AddWithValue("@DuongDan", relativePath);

                            //    //    fileUpload.SaveAs(filePath);

                            //    //}
                            //    // Add parameters for the insert command
                            //    for (int i = 0; i < Request.Files.Count; i++)
                            //    {
                            //        HttpPostedFile file = Request.Files[i];
                            //        if (file != null && file.ContentLength > 0)
                            //        {
                            //            string fileName = Path.GetFileName(file.FileName);
                            //            string filePath = Path.Combine(finalFolderPath, fileName);
                            //            string relativePath = filePath.Substring(filePath.IndexOf("Content"));
                            //            file.SaveAs(filePath);

                            //            if (i == 0) // Ảnh chính
                            //            {
                            //                mainImagePath = relativePath;

                            //            }
                            //            else // Ảnh phụ
                            //            {
                            //                additionalImagePaths.Add(relativePath);
                            //            }

                            //            insertCommand.Parameters.AddWithValue("@MaSP", maSP);
                            //            insertCommand.Parameters.AddWithValue("@TenSP", tenSP);
                            //            insertCommand.Parameters.AddWithValue("@Gia", gia);
                            //            insertCommand.Parameters.AddWithValue("@MoTa", moTa);
                            //            insertCommand.Parameters.AddWithValue("@MaLoai", maLoai);
                            //            insertCommand.Parameters.AddWithValue("@MaNhom", MaNhom);
                            //            insertCommand.Parameters.AddWithValue("@NgaySX", NgaySX);
                            //            insertCommand.Parameters.AddWithValue("@SoLuongKho", SLKho);
                            //            insertCommand.Parameters.AddWithValue("@DuongDan", mainImagePath);
                            //            insertCommand.Parameters.AddWithValue("@NgayNhap", DateTime.Now);
                            //            insertCommand.Parameters.AddWithValue("@DoanhSo", 0);


                            //            insertCommand.ExecuteNonQuery();

                            //        }
                            //    using (SqlCommand command = new SqlCommand("ProductData_Add", connection))
                            //    {
                            //        command.CommandType = CommandType.StoredProcedure;
                            //        string fileNameMT = Path.GetFileName(fileImageMoTa.FileName);
                            //        string filePathMT = Path.Combine(finalFolderPath, fileNameMT);
                            //        fileImageMoTa.SaveAs(filePathMT);
                            //        string relativePathMT = filePathMT.Substring(filePathMT.IndexOf("Content"));

                            //        fileimgMT = relativePathMT;

                            //        command.Parameters.AddWithValue("@MaSP", maSP);
                            //        command.Parameters.AddWithValue("@AnhNote", relativePathMT);


                            //        for (int x = 0; x < additionalImagePaths.Count; x++)
                            //        {
                            //            string paramName = "@DuongDan" + (x + 1).ToString();
                            //            command.Parameters.AddWithValue(paramName, additionalImagePaths[x]);
                            //        }

                            //        // If the stored procedure expects a fixed number of image paths, fill in any missing paths with DBNull.Value
                            //        for (int x = additionalImagePaths.Count; x < 5; x++) // Assuming the stored procedure expects up to 5 image paths
                            //        {
                            //            string paramName = "@DuongDan" + (x + 1).ToString();
                            //            command.Parameters.AddWithValue(paramName, DBNull.Value);
                            //        }


                            //        command.ExecuteNonQuery();

                            //    }
                            //}


                            //}

                            //using (SqlCommand command = new SqlCommand("ProductData_Add", connection))
                            //{
                            //    // Handle the main image (fileImageMoTa) separately
                            //    string fileNameMT = Path.GetFileName(fileImageMoTa.FileName);
                            //    string filePathMT = Path.Combine(finalFolderPath, fileNameMT);
                            //    fileImageMoTa.SaveAs(filePathMT);
                            //    string relativePathMT = filePathMT.Substring(filePathMT.IndexOf("Content"));
                            //    fileimgMT = relativePathMT;

                            //    // Initialize variables for additional image paths
                            //    string DuongDan1 = null;
                            //    string DuongDan2 = null;
                            //    string DuongDan3 = null;
                            //    string DuongDan4 = null;
                            //    string DuongDan5 = null;

                            //    // Process additional images
                            //    for (int i = 0; i < Request.Files.Count; i++)
                            //    {
                            //        HttpPostedFile file = Request.Files[i];
                            //        if (file != null && file.ContentLength > 0)
                            //        {
                            //            string fileName = Path.GetFileName(file.FileName);
                            //            string filePath = Path.Combine(finalFolderPath, fileName);
                            //            string relativePath = filePath.Substring(filePath.IndexOf("Content"));
                            //            file.SaveAs(filePath);

                            //            // Assign additional image paths based on their index
                            //            switch (i)
                            //            {
                            //                case 0:
                            //                    DuongDan1 = relativePath;
                            //                    break;
                            //                case 1:
                            //                    DuongDan2 = relativePath;
                            //                    break;
                            //                case 2:
                            //                    DuongDan3 = relativePath;
                            //                    break;
                            //                case 3:
                            //                    DuongDan4 = relativePath;
                            //                    break;
                            //                case 4:
                            //                    DuongDan5 = relativePath;
                            //                    break;
                            //            }
                            //        }
                            //    }

                            //    // Add parameters for the ProductData_Add stored procedure
                            //    command.Parameters.AddWithValue("@MaSP", maSP);
                            //    command.Parameters.AddWithValue("@AnhNote", fileimgMT); // Set @AnhNote to fileimgMT
                            //    command.Parameters.AddWithValue("@DuongDan1", DuongDan1 ?? (object)DBNull.Value);
                            //    command.Parameters.AddWithValue("@DuongDan2", DuongDan2 ?? (object)DBNull.Value);
                            //    command.Parameters.AddWithValue("@DuongDan3", DuongDan3 ?? (object)DBNull.Value);
                            //    command.Parameters.AddWithValue("@DuongDan4", DuongDan4 ?? (object)DBNull.Value);
                            //    command.Parameters.AddWithValue("@DuongDan5", DuongDan5 ?? (object)DBNull.Value);

                            //    connection.Open();
                            //    command.ExecuteNonQuery();
                            //    connection.Close();
                            //}
                            //string DuongDan1 = DuongDan;
                            //    string DuongDan2 = null;
                            //    string DuongDan3 = null;
                            //    string DuongDan4 = null;
                            //    string DuongDan5 = null;

                            //    for (int a = 0; a <= additionalImagePaths.Count; a++)
                            //    {
                            //        switch (a)
                            //        {
                            //            case 0:
                            //                DuongDan1 = mainImagePath;
                            //                break;
                            //            case 1:
                            //                DuongDan2 = additionalImagePaths[a];
                            //                break;
                            //            case 2:
                            //                DuongDan3 = additionalImagePaths[a];
                            //                break;
                            //            case 3:
                            //                DuongDan4 = additionalImagePaths[a];
                            //                break;
                            //            case 4:
                            //                DuongDan5 = additionalImagePaths[a];
                            //                break;
                            //        }
                            //    }
                            //if (fileImageMoTa.HasFile)
                            //{

                            //    if (!Directory.Exists(finalFolderPath))
                            //    {
                            //        Directory.CreateDirectory(finalFolderPath);
                            //    }

                            //    string fileNameMT = Path.GetFileName(fileImageMoTa.FileName);
                            //    string filePathMT = Path.Combine(finalFolderPath, fileNameMT);
                            //    fileImageMoTa.SaveAs(filePathMT);

                            //    fileimgMT = filePathMT;

                            //}
                            //using (SqlCommand command = new SqlCommand("ProductData_Add", connection))
                            //{
                            //    command.CommandType = CommandType.StoredProcedure;

                            //    // Thêm các tham số cần thiết
                            //    command.Parameters.AddWithValue("@MaSP", maSP);
                            //    command.Parameters.AddWithValue("@AnhNote", fileimgMT);

                            //    // Kiểm tra số lượng ảnh phụ và thêm các tham số tương ứng
                            //    for (int x = 0; x < additionalImagePaths.Count; x++)
                            //    {
                            //        string paramName = "@DuongDan" + (x + 1).ToString();
                            //        command.Parameters.AddWithValue(paramName, additionalImagePaths[x]);
                            //    }

                            //    // Nếu số lượng ảnh phụ nhỏ hơn 5, thêm các giá trị null cho các tham số còn thiếu
                            //    for (int x = additionalImagePaths.Count; x < 5; x++)
                            //    {
                            //        string paramName = "@DuongDan" + (x + 1).ToString();
                            //        command.Parameters.AddWithValue(paramName, DBNull.Value);
                            //    }


                            //    // Thực thi Stored Procedure
                            //    command.ExecuteNonQuery();
                            //}

                            //connection.Close();
                        }


                        Response.Write("<div class=\"alert alert-success\" role=\"alert\">Thêm sản phẩm thành công.</div>");
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
            }
        }


    }
}