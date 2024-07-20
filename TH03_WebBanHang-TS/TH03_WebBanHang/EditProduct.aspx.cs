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
using System.Data.Entity.Migrations;
using System.Web.WebPages;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace TH03_WebBanHang
{
    public partial class EditProduct : System.Web.UI.Page
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
            //if (user.Any(p => (p.Email == "Admin" && p.TrangThai == true && p.Email == EmailKhach && EmailKhach == "Admin") || (p.Quyen == "Admin" || p.Quyen == "Manager") && p.TrangThai == true && p.Email == EmailKhach))
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
                string str = Request.QueryString["Deptid"].ToString();
                var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
                var SPdata = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == str);
                txtGia.Text = SP.Gia.ToString();
                txtMaSP.Text = SP.MaSP.ToString();
                txtMoTa.Text = SP.MoTa.ToString();
                txtNgay.Text = SP.NgayNhap.ToString();
                txtNgayHH.Text = SP.NgayHH.ToString();
                txtNguonHang.Text = SP.NguonHang.ToString();
                txtSLKho.Text = SP.SoLuongKho.ToString();
                txtTenSP.Text = SP.TenSP.ToString();
                if(SP.TenVer!=null)
                    txtTenVerSP.Text = SP.TenVer.ToString();
                txtPopName.Visible = false;
                lbPopName.Visible = false;
                if(SP.SanPhamData.AnhNote!=null || SP.SanPhamData.AnhNote != "")
                {
                }
                if(SP.SanPhamData.DuongDan1 != null || SP.SanPhamData.DuongDan1 != "")
                {
                    
                }
                if (SP.SanPhamData.Pob == true)
                {
                    CheckboxOfPop.Checked = true;
                }
                if (SP.SanPhamData.IsPreOrder == true)
                {
                    checkPreOrder.Checked = true;
                }

                if(ddlMaLoai.SelectedValue!= "Khac")
                {
                    txtNewMaNhom.Visible = false;
                    txtNewNhomName.Visible = false;
                    lbNewMaNhom.Visible=false;
                    lbnameGp.Visible = false;
                    fileUploadGPmem.Visible = false;
                    lbGpImage.Visible = false;
                    fileUploadGPLogo.Visible = false;
                    lbLG.Visible = false;
                }

                ViewState["DropDownListsPopulated"] = true;
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
                string str = Request.QueryString["Deptid"].ToString();
                var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP==str);
                // Populate ddlCity
                var queryTP = from tp in context.Nhoms
                              select new { tp.MaNhom, tp.TenNhom };

                ddlMaNhom.DataSource = queryTP.ToList();
                ddlMaNhom.DataTextField = "TenNhom";
                ddlMaNhom.DataValueField = "MaNhom";
                ddlMaNhom.DataBind();
                ddlMaNhom.Items.Insert(0, new ListItem("Khác", "Khac"));
                ddlMaNhom.SelectedValue = SP.MaNhom;


                ViewState["DropDownListsPopulated"] = true;
            }



        }
        private void MaSPDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                string str = Request.QueryString["Deptid"].ToString();
                var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
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
                ddlMaSPofVer.SelectedValue = SP.MaSP;

            }



        }

        private void LoaiDropDownLists()
        {
            using (var context = new QL_KPOPStoreEntities())
            {
                string str = Request.QueryString["Deptid"].ToString();
                var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
                // Populate ddlCity
                var queryLoai = from l in context.Loais
                                select new { l.MaLoai, l.TenLoai };

                ddlMaLoai.DataSource = queryLoai.ToList();
                ddlMaLoai.DataTextField = "TenLoai";
                ddlMaLoai.DataValueField = "MaLoai";
                ddlMaLoai.DataBind();
                ddlMaLoai.SelectedValue = SP.MaLoai;
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


        //protected void btnUpdateProduct_Click(object sender, EventArgs e)
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
            string str = Request.QueryString["Deptid"].ToString();
            var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
            var SPdata = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == str);
            if (SPdata.Pob==true)
                CheckboxOfPop.Checked = true;
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
            string str = Request.QueryString["Deptid"].ToString();
            var SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
            var SPdata = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == str);
            if (SPdata.Pob==true)
                checkPreOrder.Checked = true;
            ViewState["checkPreOrderChecked"] = checkPreOrder.Checked;
        }




        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            QL_KPOPStoreEntities sp = new QL_KPOPStoreEntities();
            string str = Request.QueryString["Deptid"].ToString();
            SanPham SP = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == str);
            SanPhamData SPdata = dbcontext.SanPhamDatas.FirstOrDefault(s => s.MaSP == str);


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
                    DateTime? NgatSanXuat;
                    DateTime? NgayHH;
                    DateTime tempNgayHH;


                    //DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX); /*DateTime.ParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);*/
                   
                    


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


                    string uploadFolderPath = Server.MapPath("Content/items/");

                    string loaiFolder = ddlMaLoai.SelectedItem.Text.ToLower().Replace("-", "").Replace("/", "");
                    string finalFolderPath = Path.Combine(uploadFolderPath, nhomFolder, loaiFolder);


                    string mainImagePath = null;
                    List<string> additionalImagePaths = new List<string>();

                    if (!Directory.Exists(finalFolderPath))
                    {
                        Directory.CreateDirectory(finalFolderPath);
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
                  

                    SPdata.AnhNote = fileimgMT;

                    string selectedImageName = hiddenSelectedImageName.Value;

                    string[] DuongDan = null;
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
                    SP.TenSP = tenSP;
                    SP.Gia = gia;
                    SP.MoTa = moTa;
                    SP.MaLoai = ddlMaLoai.SelectedValue;
                    SP.MaNhom = MaNhom;
                    SP.MaSP = maSP.Replace(" ", "");
                    SP.Ver = txtMaSP.Text;

                    if (NgayHH.HasValue)
                    {
                        SP.NgayHH = NgayHH.Value;
                    }

                    if (DateTime.TryParseExact(txtNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgaySX))
                    {

                        NgatSanXuat = NgaySX;
                    SP.NgaySX = NgatSanXuat;
                    }
                    
                    SP.NguonHang = txtNguonHang.Text;
                    SP.SoLuongKho = SLKho;

                    if (Ver != null)
                    {
                        SP.TenVer = txtTenVerSP.Text;

                    }
                    else
                    {
                        //insertCommand.Parameters.AddWithValue("@Ver", DBNull.Value);
                        if (!(txtTenVerSP.Text.IsNullOrEmpty()))
                        {
                          SP.TenVer = txtTenVerSP.Text;
                        }
                    }

                    if (DuongDan != null && DuongDan[0] != null)
                    {
                        SP.DuongDan = DuongDan[0];
                        SPdata.DuongDan1 = DuongDan[0];
                        if (DuongDan[1] != null)
                        {
                            SPdata.DuongDan2 = DuongDan[1];
                            if (DuongDan[2] != null)
                            {
                                SPdata.DuongDan3 = DuongDan[2];
                                if (DuongDan[3] != null)
                                {
                                    SPdata.DuongDan4 = DuongDan[3];
                                    if (DuongDan[4] != null)
                                    {
                                        SPdata.DuongDan5 = DuongDan[4];

                                    }

                                }
                            }
                        }
                    }
                    dbcontext.SanPhams.AddOrUpdate(SP);
                    dbcontext.SanPhamDatas.AddOrUpdate(SPdata);
                    dbcontext.SaveChanges();
                    //context.SanPhams.AddOrUpdate(SP);
                    //context.SanPhamDatas.AddOrUpdate(SPdata);
                    //context.SaveChanges();



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