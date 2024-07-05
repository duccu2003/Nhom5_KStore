using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.PeerToPeer;
using System.Security.Policy;
using System.Threading;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using TH03_WebBanHang.Models;
using static System.Net.WebRequestMethods;

namespace TH03_WebBanHang
{
    public partial class Item : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities(); 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaSP = Request.QueryString["sp"];
            string sp = HttpContext.Current.Request.QueryString.Get("sp");
            var maSPsameSP = dbcontext.SanPhams.Any(s => s.MaSP == sp || s.MaSP == MaSP);


            string searchText = Request.QueryString["searchText"];
            HttpCookie Email = Request.Cookies["Email"];


            string EmailKhach;
            if(Email==null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            


            if (IsPostBack)
            {
               
                // Kiểm tra xem txtSoLuong có giá trị không
                if (!string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    // Thêm CSS vào trang
                    if (maSPsameSP)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "AddCSS", "<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}.widget-container{display:grid !important;}</style>");

                        //LoadPop();
                        SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == sp || s.MaSP == MaSP);


                        if (sanPham.SoLuongKho <= 0)
                        {
                            txtSoLuong.Text = "HẾT HÀNG";
                            btnChange.Visible = false;
                            btnDelete.Visible = false;
                            txtSoLuong.Enabled = false;
                            Response.Write("<style>#divSL{padding:0 !important;} #SL *{margin:0 !important;} #SL{width:144.25px; color:orangered;} .txtSoLuong{width:100% !important; color:orangered !important;} #notification, #notification *{display:none !important;} </style>");
                            ddlPop.Enabled = false;


                        }
                       else { }


                        var pOP = dbcontext.POBs.Any(p => p.MaSP == sp || p.MaSP == MaSP);
                        var SP = dbcontext.SanPhams.Any(s => s.MaSP == sp || s.MaSP == MaSP);


                        
                        if (SP)
                        {
                            if (pOP)
                            {
                                ddlPop.Visible = true;

                            }
                            else
                            {
                                Response.Write("  <style>\r\n#divPop, .divPop{\r\nbackground:#0000 !important;\r\n}\r\n</style>");

                                ddlPop.Visible = false;
                            }
                        }
                        else
                        {
                            Response.Write("  <style>\r\n#divPop, .divPop{\r\ndisplay:none !important;\r\n}\r\n</style>");
                            ddlPop.Visible = false;
                        }

                       
                            
                        

                        var thichList = dbcontext.ThichSPs.Any(s => s.MaSP == sp && (s.Email == EmailKhach ||s.MaKH == Account.MaKhach));


                        if (thichList)
                        {
                            var thich = dbcontext.ThichSPs.FirstOrDefault(t => t.MaSP == sp && (t.Email == EmailKhach || t.MaKH == Account.MaKhach));

                            if (thich.DaThich == true)
                            {
                                btnToggleLike.ImageUrl = "Content/icon/Like.png";

                            }
                            else
                            {
                                btnToggleLike.ImageUrl = "Content/icon/whiteLike.png";

                            }
                        }
                        else
                        {
                            btnToggleLike.ImageUrl = "Content/icon/whiteLike.png";

                        }

                    }
                    else
                    {
                        
                            Response.Write("  <style>\r\n#divPop, .divPop{\r\ndisplay:none !important;\r\n}\r\n</style>");
                            ddlPop.Visible = false;
                        
                    }
                }
            }
            if (!IsPostBack)
            {
                
                LoadPop();
                BindLoaiListView();
                var khach = dbcontext.KhachHangs.Any(s => s.Email == EmailKhach);

                var danhGia = dbcontext.DanhGias.Where(s => (s.MaSP==sp || s.MaSP==MaSP)).Select(s=>s.RatingValue.Value);
               

                txtComment.Text = string.Empty;
                LoadComments();

                if (maSPsameSP)
                {
                    if (khach)
                    {
                        KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                        var hadRating = dbcontext.DanhGias.Any(s => s.DienThoai == khachHang.DienThoai || s.Email == khachHang.Email);

                        txtDienThoai.Visible = false;
                        txtHoTen.Visible = false;
                        //lbHoTen.Visible = false;
                        //lbSoDT.Visible = false;
                        //lbEmail.Visible = false;
                        txtEmail.Visible = false;
                        imgClientCMT.ImageUrl = khachHang.AvatarUser;

                        lbLike.Visible = true;
                        btnToggleLike.Visible = true;

                        var thichList = dbcontext.ThichSPs.Any(s => s.MaSP == sp && (s.Email == EmailKhach || s.MaKH == Account.MaKhach));
                        if (thichList)
                        {
                            var thich = dbcontext.ThichSPs.FirstOrDefault(t => t.MaSP == sp && (t.Email == EmailKhach || t.MaKH == Account.MaKhach));

                            if (thich.DaThich == true)
                            {
                                btnToggleLike.ImageUrl = "Content/icon/Like.png";

                            }
                            else
                            {
                                btnToggleLike.ImageUrl = "Content/icon/whiteLike.png";

                            }
                        }
                        else
                        {
                            btnToggleLike.ImageUrl = "Content/icon/whiteLike.png";

                        }

                        //if (hadRating)
                        //{
                        //    ratingForm.Visible = false;
                        //    txtComment.Visible = false;
                        //    btnSubmitCommentIMG.Visible = false;


                        //}
                    }
                    else
                    {
                        KhachHang khachHang = new KhachHang();
                        var hasRating = dbcontext.DanhGias.Any(s => s.DienThoai == khachHang.DienThoai || s.Email == khachHang.Email);
                        txtDienThoai.Visible = true;
                        txtHoTen.Visible = true;
                        //lbHoTen.Visible = true;
                        //lbSoDT.Visible = true;
                        //lbEmail.Visible = true;
                        txtEmail.Visible = true;
                        //if (hasRating)
                        //{
                        //    ratingForm.Visible = false;
                        //    txtComment.Visible = false;
                        //    btnSubmitCommentIMG.Visible = false;


                        //}
                    }
                    ratingForm.Visible = true;
                    //toggleRating.Visible = true;
                    txtComment.Visible = true;
                    btnSubmitComment.Visible = true;
                    imgClientCMT.Visible = true;
                    txtSoLuong.Visible = true;
                     txtSoLuong.Text = "1";
                    IMGRatingSP.Visible = true;
                    lbRatingSP.Visible = true;
                    
                    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == sp || s.MaSP == MaSP);

                    if (sanPham.SoLuongKho <= 0)
                    {
                        txtSoLuong.Text = "HẾT HÀNG";
                        btnChange.Visible = false;
                        btnDelete.Visible = false;
                        txtSoLuong.Enabled = false;
                        Response.Write("<style>#divSL{padding:0 !important;}  #SL *{margin:0 !important;}  #SL{width:144.25px; color:orangered;} .txtSoLuong{width:100% !important;  color:orangered !important;} #notification, #notification *{display:none !important;} </style>");
                        ddlPop.Enabled = false;

                    }
                    else
                    {
                       
                        btnChange.Visible = true;
                        btnDelete.Visible = true;
                    }

                    IMGRatingSP.ImageUrl = sanPham.DuongDan;
                    lbRatingSP.Text=sanPham.TenSP;
                    //Response.Write("  <style>\r\n                    .widget-container{\r\n                        display:grid !important;\r\n                    }\r\n                </style>");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AddCSS", "<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}.widget-container{display:grid !important;}</style>");

                    var pOP = dbcontext.POBs.Any(p => p.MaSP == sp || p.MaSP == MaSP);
                    var SP = dbcontext.SanPhams.Any(s => s.MaSP == sp || s.MaSP == MaSP);

                    
                    
                    if (SP)
                    {
                        if (pOP)
                        {
                            ddlPop.Visible = true;

                        }
                        else
                        {
                            Response.Write("  <style>\r\n#divPop, .divPop{\r\nbackground:#0000 !important;\r\n}\r\n</style>");

                            ddlPop.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Write("  <style>\r\n#divPop, .divPop{\r\ndisplay:none !important;\r\n}\r\n</style>");
                        ddlPop.Visible = false;
                    }
                    

                    var hadRate = dbcontext.DanhGias.Any(s => s.MaSP == sp);

                    if (hadRate)
                    {
                        lblMostRatedStar.Visible = true;
                    }
                    else
                    {
                        lblMostRatedStar.Visible = false;

                    }
                    Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");

                    
                    ddlRatingFilter.SelectedValue = "0";
                    DisplayMostRatedStar();

                    var saP = dbcontext.SanPhams.FirstOrDefault(p => (p.MaSP == sp || p.MaSP == MaSP));

                 
                       
                    


                    lsItemRatingAll.Text = "Tất cả (" + danhGia.Count() + ")";

                    for (int i = 1; i <= 5; i++)
                    {
                        var dg = dbcontext.DanhGias.Where(s => (s.MaSP == sp || s.MaSP == MaSP) && s.RatingValue.Value == i);
                        var count = dg.Count();

                        // Thêm giá trị đếm vào các control tương ứng
                        switch (i)
                        {
                            case 1:
                                lsItemRating1.Text += "(" + count + ")";
                                break;
                            case 2:
                                lsItemRating2.Text += "(" + count + ")";
                                break;
                            case 3:
                                lsItemRating3.Text += "(" + count + ")";
                                break;
                            case 4:
                                lsItemRating4.Text += "(" + count + ")";
                                break;
                            case 5:
                                lsItemRating5.Text += "(" + count + ")";
                                break;
                        }

                    }




                    
                    int soLuongCoThe;
                    soLuongCoThe = saP.SoLuongKho.Value - 1;
                    if (int.TryParse(txtSoLuong.Text, out int currentValue))
                    {
                        if (currentValue > soLuongCoThe)
                        {
                            int soluongCon = saP.SoLuongKho.Value;
                            txtSoLuong.Text = soluongCon.ToString();

                        }
                        else if (currentValue == saP.SoLuongKho)
                        {
                            txtSoLuong.Text = saP.SoLuongKho.ToString();
                        }
                        else
                        {
                            txtSoLuong.Text = "1";
                        }


                        //Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");


                    }
                    //Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");



                }

                else
                {

                    Response.Write("  <style>\r\n#divPop, .divPop{\r\ndisplay:none !important;\r\n}\r\n</style>");
                    ddlPop.Visible = false;

                }




                //if (MaSP != null || sp != null)
                //{
                //    Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");

                //}

                if (khach)
                {
                    KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);

                    imgClientCMT.ImageUrl = Account.urlAvt;


                }
                else
                {
                    if (txtDienThoai.Text != string.Empty)
                    {
                        var K = dbcontext.KhachHangs.Any(s => s.DienThoai == txtDienThoai.Text || s.Email == txtEmail.Text);
                        if (K)
                        {
                            KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.DienThoai == txtDienThoai.Text || s.Email == txtEmail.Text);
                            imgClientCMT.ImageUrl = khachHang.AvatarUser;
                        }
                        else imgClientCMT.ImageUrl = Shop.defaultAvatar_BlackKS;

                    }
                    imgClientCMT.ImageUrl = Shop.defaultAvatar_BlackKS;




                }

            }

        }
        private void LoadComments()
        {
            string sp = HttpContext.Current.Request.QueryString.Get("sp");
            if (dbcontext.SanPhams.Any(s => s.MaSP == sp))
            {
                string productId = sp;
                using (SqlConnection conn = new SqlConnection(Shop.SQL_connectionString))
                {
                    conn.Open();
                    string sql = "SELECT AvatarUser, MaSP, TenKH, NoiDung, NgayDG, RatingValue, DienThoai , Email, LuotThich, Anh1, Anh2, Anh3, Anh4, Anh5, Video FROM DanhGia WHERE MaSP = @MaSP";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", productId);

                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        ListViewComments.DataSource = dt;
                        ListViewComments.DataBind();
                    }
                }
            }
        }
        private void BindLoaiListView()
        {
            using (SqlConnection connection = new SqlConnection(Shop.SQL_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT MaLoai, TenLoai FROM Loai", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    LoaiListView.DataSource = dataTable;
                    LoaiListView.DataBind();
                }
            }
        }
        protected void ddlRatingFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRating = int.Parse(ddlRatingFilter.SelectedValue);
            if (selectedRating == 0)
            {
                // Xử lý việc hiển thị tất cả các đánh giá
                LoadComments();
            }
            else
            {
                // Xử lý việc lọc đánh giá dựa trên số sao
                FilterListViewByRating(selectedRating);
            }
        }
        private void FilterListViewByRating(int rating)
        {

            string sp = HttpContext.Current.Request.QueryString.Get("sp");

            // Giả sử bạn đã có một DataTable dtComments để lưu trữ dữ liệu đánh giá
            var dtComments = dbcontext.DanhGias.Where(s => s.RatingValue == rating && s.MaSP == sp).ToList();



            // Gán dữ liệu đã lọc cho ListViewComments
            ListViewComments.DataSource = dtComments;
            ListViewComments.DataBind();
        }
        private void DisplayMostRatedStar()
        {
            string sp = HttpContext.Current.Request.QueryString.Get("sp");

            // Lấy danh sách đánh giá từ bảng DanhGias
            var ratings = dbcontext.DanhGias.Where(s => s.MaSP == sp).Select(d => d.RatingValue).ToList();

            // Kiểm tra xem danh sách đánh giá có rỗng không
            if (!ratings.Any())
            {
                // Nếu không có đánh giá nào, đặt lblMostRatedStar.Text thành null hoặc một thông báo tương ứng
                lblMostRatedStar.Text = null;
                return; // Thoát khỏi hàm để không thực hiện các bước tiếp theo
            }

            //// Tính số lượng đánh giá cho mỗi sao
            //Dictionary<double, double> starRatingsCount = new Dictionary<double, double>();
            //for (double i = 1; i <= 5; i++)
            //{
            //    starRatingsCount[i] = ratings.Count(rating => rating == i);
            //}

            //// Tìm sao có số lượng đánh giá nhiều nhất
            //double mostRatedStar = 0;
            //double maxCount = 0;
            //List<double> maxStars = new List<double>();

            //foreach (var star in starRatingsCount)
            //{
            //    if (star.Value > maxCount)
            //    {
            //        //mostRatedStar = star.Key;
            //        maxCount = star.Value;
            //        maxStars.Clear();
            //        maxStars.Add(star.Key);
            //    }
            //    else if (star.Value == maxCount)
            //    {
            //        //mostRatedStar = Math.Max(mostRatedStar, star.Key);
            //        maxStars.Add(star.Key);
            //    }
            //}
            //// Xử lý khi có nhiều sao có số lượng đánh giá bằng nhau
            //if (maxStars.Count > 1)
            //{
            //    // Lấy sao ở giữa
            //    mostRatedStar = (maxStars[0] + maxStars[maxStars.Count - 1]) / 2;
            //}
            //else
            //{
            //    mostRatedStar = maxStars[0];
            //}



            //lblMostRatedStar.Text = $"{mostRatedStar}★";


            // Tính tổng số lượng sao nhận được và tổng số lượng bài đánh giá
            double totalStars = (double)ratings.Sum();
            double totalReviews = ratings.Count;

            // Tính rating
            double rating = totalStars / totalReviews;

            // Làm tròn rating đến một số thập phân thứ hai
            rating = Math.Round(rating, 1);

            // Đặt giá trị cho lblMostRatedStar.Text
            lblMostRatedStar.Text = $"{rating}⭐";

        }
        private bool IsVideoSizeValid(HttpPostedFile videoFile)
        {
            // Giới hạn dung lượng video là 10MB
            const int maxSize = 10 * 1024 * 1024; // 10MB
            return videoFile.ContentLength <= maxSize;
        }
        private double GetVideoDuration(string videoPath)
        {

            return 0;
        }
        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            string sp = HttpContext.Current.Request.QueryString.Get("sp");

            var sanphamRating = dbcontext.SanPhams.FirstOrDefault(s=>s.MaSP==sp);

            var khach = dbcontext.KhachHangs.Any(s => s.Email == EmailKhach);
            string imagePath = Server.MapPath(Shop.logoForMail_BlackKS);
            string pic1String = null, pic2String = null, pic3String = null, pic4String = null, pic5String = null, videoString=null, avatar=null, userName =null ;
            int valueRate = Convert.ToInt32(ratingValue.Value);

            //string tenKH = ddlMaNhom.SelectedItem.Text.ToLower().Replace(" ", "");

            string tenKH = (khach ? dbcontext.KhachHangs.Where(s => s.Email == EmailKhach).Select(s => s.HoTen).FirstOrDefault() : txtHoTen.Text).Replace(" ", ""); ;
            // Thay thế các dấu tiếng Việt bằng ký tự tương ứng không dấu
            tenKH = tenKH.Replace("á", "a").Replace("à", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a").Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a").Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ậ", "a").Replace("é", "e").Replace("è", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e").Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e").Replace("í", "i").Replace("ì", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i").Replace("ó", "o").Replace("ò", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o").Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o").Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o").Replace("ú", "u").Replace("ù", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u").Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u").Replace("ý", "y").Replace("ỳ", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y");


            string sdtKH = (khach ? dbcontext.KhachHangs.Where(s => s.Email == EmailKhach).Select(s => s.DienThoai).FirstOrDefault() : txtDienThoai.Text).ToLower().Replace(" ", "");
            string emailKH = (khach ? dbcontext.KhachHangs.Where(s => s.Email == EmailKhach).Select(s => s.Email).FirstOrDefault() : txtEmail.Text).ToLower().Replace(" ", "");
            //string dateRating = DateTime.Now.ToString();
            string format = "ddMMyyyy-HH-mm";

            string wwRatingProfile = DateTime.Now.ToString(format) + "-" + emailKH + "-" + sdtKH + '/';


            string path = Server.MapPath("Content/rating-data/");
            string fullPath = System.IO.Path.Combine(path, wwRatingProfile);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);

            }


            string[] imagePaths = new string[fileUploadImages.PostedFiles.Count];
            string video = null;
            if (fileUploadImages.HasFiles)
            {
                for (int i = 0; i < fileUploadImages.PostedFiles.Count; i++)
                {
                    HttpPostedFile file = fileUploadImages.PostedFiles[i];

                    string fileName = System.IO.Path.GetFileName(file.FileName);


                    string pathimgDG = System.IO.Path.Combine(fullPath, fileName);



                    file.SaveAs(pathimgDG);
                    imagePaths[i] = "Content/rating-data/" + wwRatingProfile + fileName;
                    //imagePaths[i] = fullPath + fileName;
                }
                string images = string.Join(",", imagePaths);

            }
            if (fileUploadVideo.HasFile)
            {
                HttpPostedFile videoFile = fileUploadVideo.PostedFile;
                string videoFileName = System.IO.Path.GetFileName(videoFile.FileName);

                string pathimgDGVideo = System.IO.Path.Combine(fullPath, videoFileName);
                videoFile.SaveAs(pathimgDGVideo);

                // Kiểm tra dung lượng video
                if (!IsVideoSizeValid(videoFile))
                {

                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Video quá lớn. Vui lòng chọn video có dung lượng dưới 10MB.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");

                    video = null;
                    return;
                }
                double videoDuration = GetVideoDuration(pathimgDGVideo);

                if (videoDuration > 60) // Kiểm tra thời lượng video vượt quá 1 phút
                {

                    Response.Write("<div class=\"alert alert-danger\" role=\"alert\">Video quá dài. Vui lòng chọn video dưới 1 phút.</div>");
                    Response.Write("<script type=\"text/javascript\">");
                    Response.Write("setTimeout(function() {");
                    Response.Write("var elements = document.getElementsByClassName('alert');");
                    Response.Write("for (var i = 0; i < elements.length; i++) {");
                    Response.Write("elements[i].style.display = 'none';");
                    Response.Write("}");
                    Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                    Response.Write("</script>");

                    video = null;
                    return;
                }

                video = "Content/rating-data/" + wwRatingProfile + videoFileName;
                videoString =video;
            }


            //if (fileUploadVideo.HasFile)
            //{
            //    HttpPostedFile videoFile = fileUploadVideo.PostedFile;
            //    string videoFileName = System.IO.Path.GetFileName(videoFile.FileName);

            //    string pathimgDGVideo = System.IO.Path.Combine(fullPath, videoFileName);
            //    videoFile.SaveAs(pathimgDGVideo);


            //    double videoDuration = GetVideoDuration(pathimgDGVideo);
            //    if (videoDuration > 40)
            //    {

            //        Response.Write("Video quá dài.Xin hãy chọn video dưới 40s.");
            //        return;
            //    }

            //    video = "Content/rating-data/" + wwRatingProfile + videoFileName;


            //}







            if (khach)
            {
                KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                userName = khachHang.HoTen;
                var Rating = dbcontext.DanhGias.Any(s => (s.DienThoai == khachHang.DienThoai || s.Email == khachHang.Email) && s.MaSP == sp);
                if (Rating)
                {


                    using (var db = new QL_KPOPStoreEntities())
                    {
                        // Tìm DanhGia cần cập nhật
                        var danhGia = db.DanhGias.FirstOrDefault(d => (d.DienThoai == khachHang.DienThoai || d.Email == khachHang.Email) && d.MaSP == sp);
                        if (danhGia != null)
                        {
                            // Cập nhật các trường cần thiết
                            danhGia.NoiDung = txtComment.Text; // Ví dụ: cập nhật nội dung bình luận
                            danhGia.RatingValue = Convert.ToInt32(ratingValue.Value); // Ví dụ: cập nhật giá trị đánh giá
                            danhGia.AvatarUser = Account.urlAvt;
                            avatar = danhGia.AvatarUser;

                            // Lưu thay đổi vào cơ sở dữ liệu

                            //danhGia.LuotThich = 0; // Đặt LuotThich bằng 0
                            if (fileUploadImages.HasFiles || fileUploadImages.HasFile)
                            {
                                // Lưu ảnh và video
                                if (imagePaths.Length > 0)
                                {
                                    danhGia.Anh1 = imagePaths[0]; pic1String = danhGia.Anh1;
                                    if (imagePaths.Length > 1) { danhGia.Anh2 = imagePaths[1]; pic2String = danhGia.Anh2; } else danhGia.Anh2 = null;
                                    if (imagePaths.Length > 2) { danhGia.Anh3 = imagePaths[2]; pic3String = danhGia.Anh3; } else danhGia.Anh3 = null;
                                    if (imagePaths.Length > 3) { danhGia.Anh4 = imagePaths[3]; pic4String = danhGia.Anh4; } else danhGia.Anh4 = null;
                                    if (imagePaths.Length > 4) { danhGia.Anh5 = imagePaths[4]; pic5String = danhGia.Anh5;} else danhGia.Anh5 = null;
                                }
                                else
                                {
                                    danhGia.Anh1 = null;
                                    danhGia.Anh2 = null;
                                    danhGia.Anh3 = null;
                                    danhGia.Anh4 = null;
                                    danhGia.Anh5 = null;
                                }
                            }
                            else
                            {
                                danhGia.Anh1 = null;
                                danhGia.Anh2 = null;
                                danhGia.Anh3 = null;
                                danhGia.Anh4 = null;
                                danhGia.Anh5 = null;
                            }
                            if (fileUploadVideo.HasFile)
                            {

                                danhGia.Video = video;



                            }
                            else
                            {
                                danhGia.Video = null;
                            }

                            db.SaveChanges();
                            dbcontext.SaveChanges();
                        }

                        db.SaveChanges();
                        dbcontext.SaveChanges();
                    }
                }
                else
                {


                    int ratingValueAcpt = Convert.ToInt32(ratingValue.Value);
                    string comment = txtComment.Text; // Lấy nội dung từ TextBox
                    string productId;
                    if (dbcontext.SanPhams.Any(s => s.MaSP == sp))
                    {
                        productId = sp; // Giả sử đây là ID của sản phẩm

                        // Tạo một kết nối đến cơ sở dữ liệu
                        using (SqlConnection conn = new SqlConnection(Shop.SQL_connectionString))
                        {
                            conn.Open();

                            // Tạo một câu lệnh SQL để thêm bình luận vào cơ sở dữ liệu
                            string sql = "INSERT INTO DanhGia (AvatarUser, MaSP, TenKH, NoiDung, NgayDG, RatingValue, DienThoai, Email, LuotThich, Anh1, Anh2, Anh3, Anh4, Anh5, Video) VALUES (@AvatarUser, @MaSP, @TenKH, @NoiDung, @NgayDG, @RatingValue, @DienThoai , @Email, @LuotThich, @Anh1, @Anh2, @Anh3, @Anh4, @Anh5, @Video)";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaSP", productId);


                                

                                avatar = Account.urlAvt;
                                cmd.Parameters.AddWithValue("@AvatarUser", avatar);
                                cmd.Parameters.AddWithValue("@TenKH", khachHang.HoTen); // Giả sử tên khách hàng
                                imgClientCMT.ImageUrl = Account.urlAvt;
                                cmd.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai); // Giả sử tên khách hàng
                                cmd.Parameters.AddWithValue("@Email", khachHang.Email);

                                cmd.Parameters.AddWithValue("@LuotThich", 0);

                                //if (imagePaths.Length > 0)
                                //{
                                //    cmd.Parameters.AddWithValue("@Anh1", imagePaths[0]);

                                //    if (imagePaths.Length > 1) cmd.Parameters.AddWithValue("@Anh2", imagePaths[1]); ;
                                //    if (imagePaths.Length > 2) cmd.Parameters.AddWithValue("@Anh3", imagePaths[2]); ;
                                //    if (imagePaths.Length > 3) cmd.Parameters.AddWithValue("@Anh4", imagePaths[3]); ;
                                //    if (imagePaths.Length > 4) cmd.Parameters.AddWithValue("@Anh5", imagePaths[4]); ;
                                //}
                                //if (!string.IsNullOrEmpty(videoPath))
                                //{

                                //    cmd.Parameters.AddWithValue("@Video", videoPath);
                                //}

                                //if (imagePaths.Length > 0)
                                //{
                                //    cmd.Parameters.AddWithValue("@Anh1", imagePaths[0]);

                                //    if (imagePaths.Length > 1) cmd.Parameters.AddWithValue("@Anh2", imagePaths[1]);
                                //    else cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                //    if (imagePaths.Length > 2) cmd.Parameters.AddWithValue("@Anh3", imagePaths[2]);
                                //    else cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                //    if (imagePaths.Length > 3) cmd.Parameters.AddWithValue("@Anh4", imagePaths[3]);
                                //    else cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                //    if (imagePaths.Length > 4) cmd.Parameters.AddWithValue("@Anh5", imagePaths[4]);
                                //    else cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                //}
                                //else
                                //{
                                //    cmd.Parameters.AddWithValue("@Anh1", DBNull.Value);
                                //    cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                //    cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                //    cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                //    cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                //}
                                //if (!string.IsNullOrEmpty(videoPath))
                                //{

                                //    cmd.Parameters.AddWithValue("@Video", videoPath);
                                //}
                                //else
                                //{
                                //    cmd.Parameters.AddWithValue("@Video", DBNull.Value);
                                //}


                                if (fileUploadImages.HasFiles || fileUploadImages.HasFile)
                                {
                                    if (imagePaths.Length > 0)
                                    {
                                        cmd.Parameters.AddWithValue("@Anh1", imagePaths[0]);pic1String = imagePaths[0];
                                        if (imagePaths.Length > 1) { cmd.Parameters.AddWithValue("@Anh2", imagePaths[1]); pic2String = imagePaths[1]; } else cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                        if (imagePaths.Length > 2) { cmd.Parameters.AddWithValue("@Anh3", imagePaths[2]); pic3String = imagePaths[2]; } else cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                        if (imagePaths.Length > 3) { cmd.Parameters.AddWithValue("@Anh4", imagePaths[3]); pic4String = imagePaths[3]; } else cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                        if (imagePaths.Length > 4) { cmd.Parameters.AddWithValue("@Anh5", imagePaths[4]); pic5String = imagePaths[4]; } else cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@Anh1", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                    }
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@Anh1", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                }
                                if (fileUploadVideo.HasFile)
                                {

                                    cmd.Parameters.AddWithValue("@Video", video);




                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@Video", DBNull.Value);
                                }



                                //cmd.Parameters.AddWithValue("@AvatarUser", Shop.defaultAvatar_BlackKS);

                                //cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text); // Giả sử tên khách hàng
                                //imgClientCMT.ImageUrl = Shop.defaultAvatar_BlackKS;
                                //cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text); // Giả sử tên khách hàng

                                cmd.Parameters.AddWithValue("@RatingValue", ratingValueAcpt);

                                valueRate = ratingValueAcpt;

                                cmd.Parameters.AddWithValue("@NoiDung", comment);
                                cmd.Parameters.AddWithValue("@NgayDG", DateTime.Now);

                                // Thực thi câu lệnh
                                cmd.ExecuteNonQuery();
                                LoadComments();

                            }
                        }
                        txtComment.Text = string.Empty; // Đặt giá trị của txtComment thành chuỗi trống

                        // Thông báo thành công
                        Response.Write("<div class=\"alert alert-success\" role=\"alert\">Bài đánh giá của bạn về sản phẩm này đã được thêm thành công!</div>");
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
            else
            {
                if (txtEmail.Text.IsNullOrWhiteSpace() || txtDienThoai.Text.IsNullOrWhiteSpace() || txtHoTen.Text.IsNullOrWhiteSpace())
                {


                }
                else
                {
                    userName=txtHoTen.Text;
                    var hasRating = dbcontext.DanhGias.Any(s => (s.DienThoai == txtDienThoai.Text || s.Email == txtEmail.Text) && s.MaSP == sp);
                    if (hasRating)
                    {
                        using (var db = new QL_KPOPStoreEntities())
                        {
                            // Tìm DanhGia cần cập nhật
                            var danhGia = db.DanhGias.FirstOrDefault(d => (d.DienThoai == txtDienThoai.Text || d.Email == txtEmail.Text) && d.MaSP == sp);
                            if (danhGia != null)
                            {
                                // Cập nhật các trường cần thiết
                                danhGia.NoiDung = txtComment.Text; // Ví dụ: cập nhật nội dung bình luận
                                danhGia.RatingValue = Convert.ToInt32(ratingValue.Value); // Ví dụ: cập nhật giá trị đánh giá
                                avatar = danhGia.AvatarUser;

                                if (fileUploadImages.HasFiles || fileUploadImages.HasFile)
                                {


                                    if (imagePaths.Length > 0)
                                    {
                                        danhGia.Anh1 = imagePaths[0]; pic1String = danhGia.Anh1;
                                        if (imagePaths.Length > 1) { danhGia.Anh2 = imagePaths[1]; pic2String = danhGia.Anh2; } else danhGia.Anh2 = null;
                                        if (imagePaths.Length > 2) { danhGia.Anh3 = imagePaths[2]; pic3String = danhGia.Anh3; } else danhGia.Anh3 = null;
                                        if (imagePaths.Length > 3) { danhGia.Anh4 = imagePaths[3]; pic4String = danhGia.Anh4; } else danhGia.Anh4 = null;
                                        if (imagePaths.Length > 4) { danhGia.Anh5 = imagePaths[4]; pic5String = danhGia.Anh5; } else danhGia.Anh5 = null;
                                    }
                                    else
                                    {
                                        danhGia.Anh1 = null;
                                        danhGia.Anh2 = null;
                                        danhGia.Anh3 = null;
                                        danhGia.Anh4 = null;
                                        danhGia.Anh5 = null;
                                    }
                                }
                                else
                                {
                                    danhGia.Anh1 = null;
                                    danhGia.Anh2 = null;
                                    danhGia.Anh3 = null;
                                    danhGia.Anh4 = null;
                                    danhGia.Anh5 = null;
                                }
                                if (fileUploadVideo.HasFile)
                                {

                                    danhGia.Video = video;

                                }
                                else
                                {
                                    danhGia.Video = null;
                                }




                                // Lưu thay đổi vào cơ sở dữ liệu
                                db.SaveChanges();
                                valueRate = Convert.ToInt32(ratingValue.Value);
                            }
                        }
                    }
                    //Response.Redirect("Account.aspx");
                    else
                    {


                        int ratingValueAcpt = Convert.ToInt32(ratingValue.Value);
                        string comment = txtComment.Text; // Lấy nội dung từ TextBox
                        string productId;
                        if (dbcontext.SanPhams.Any(s => s.MaSP == sp))
                        {
                            productId = sp; // Giả sử đây là ID của sản phẩm

                            // Tạo một kết nối đến cơ sở dữ liệu
                            using (SqlConnection conn = new SqlConnection(Shop.SQL_connectionString))
                            {
                                conn.Open();

                                // Tạo một câu lệnh SQL để thêm bình luận vào cơ sở dữ liệu
                                //string sql = "INSERT INTO DanhGia (AvatarUser, MaSP, TenKH, NoiDung, NgayDG, RatingValue, DienThoai, Email, LuotThich, Anh1, Anh2, Anh3, Anh4, Anh5, Video) VALUES (@AvatarUser, @MaSP, @TenKH, @NoiDung, @NgayDG, @RatingValue, @DienThoai, @Email, @LuotThich, @Anh1, @Anh2, @Anh3, @Anh4, @Anh5, @Video)";
                                string sql = "INSERT INTO DanhGia (AvatarUser, MaSP, TenKH, NoiDung, NgayDG, RatingValue, DienThoai, Email, LuotThich, Anh1, Anh2, Anh3, Anh4, Anh5, Video) VALUES (@AvatarUser, @MaSP, @TenKH, @NoiDung, @NgayDG, @RatingValue, @DienThoai, @Email, @LuotThich, @Anh1, @Anh2, @Anh3, @Anh4, @Anh5, @Video)";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaSP", productId);

                                    cmd.Parameters.AddWithValue("@AvatarUser", Shop.defaultAvatar_BlackKS);

                                    avatar = Shop.defaultAvatar_BlackKS;

                                    cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text); // Giả sử tên khách hàng
                                    imgClientCMT.ImageUrl = Shop.defaultAvatar_BlackKS;
                                    cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text); // Giả sử tên khách hàng
                                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                                    cmd.Parameters.AddWithValue("@RatingValue", ratingValueAcpt);

                                    valueRate = ratingValueAcpt;

                                    cmd.Parameters.AddWithValue("@NoiDung", comment);
                                    cmd.Parameters.AddWithValue("@NgayDG", DateTime.Now);

                                    cmd.Parameters.AddWithValue("@LuotThich", 0);

                                    if (fileUploadImages.HasFiles || fileUploadImages.HasFile)
                                    {
                                        if (imagePaths.Length > 0)
                                        {
                                            cmd.Parameters.AddWithValue("@Anh1", imagePaths[0]); pic1String = imagePaths[0];
                                            if (imagePaths.Length > 1) { cmd.Parameters.AddWithValue("@Anh2", imagePaths[1]); pic2String = imagePaths[1]; } else cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                            if (imagePaths.Length > 2) { cmd.Parameters.AddWithValue("@Anh3", imagePaths[2]); pic3String = imagePaths[2]; } else cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                            if (imagePaths.Length > 3) { cmd.Parameters.AddWithValue("@Anh4", imagePaths[3]); pic4String = imagePaths[3]; } else cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                            if (imagePaths.Length > 4) { cmd.Parameters.AddWithValue("@Anh5", imagePaths[4]); pic5String = imagePaths[4]; } else cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@Anh1", DBNull.Value);
                                            cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                            cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                            cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                            cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@Anh1", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh2", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh3", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh4", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@Anh5", DBNull.Value);
                                    }
                                    if (fileUploadVideo.HasFile)
                                    {

                                        cmd.Parameters.AddWithValue("@Video", video);


                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@Video", DBNull.Value);
                                    }



                                    // Thực thi câu lệnh
                                    cmd.ExecuteNonQuery();
                                    LoadComments();

                                }
                            }
                            txtComment.Text = string.Empty; // Đặt giá trị của txtComment thành chuỗi trống

                            // Thông báo thành công
                            //Response.Write("Bình luận của bạn đã được gửi!");

                            Response.Write("<div class=\"alert alert-success\" role=\"alert\">Bài đánh giá của bạn về sản phẩm này đã được thêm thành công!</div>");
                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("setTimeout(function() {");
                            Response.Write("var elements = document.getElementsByClassName('alert');");
                            Response.Write("for (var i = 0; i < elements.length; i++) {");
                            Response.Write("elements[i].style.display = 'none';");
                            Response.Write("}");
                            Response.Write("}, 3000);"); // 1000 mili giây = 1 giây
                            Response.Write("</script>");

                            valueRate = Convert.ToInt32(ratingValue.Value);

                        }
                    }
                }
            }


            SendEmail(txtEmail.Text, "Bài đánh giá sản phẩm", sanphamRating.TenSP, imagePath,avatar, userName, valueRate , pic1String, pic2String, pic3String, pic4String, pic5String, videoString);
            
            txtComment.Text = string.Empty;
            Response.Redirect(Request.RawUrl);
            //else
            //{
            //    productId = null;
            //}


        }
        public static string Pop;

        private void LoadPop()
        {
            string MaSP = Request.QueryString["sp"];
            string sp = HttpContext.Current.Request.QueryString.Get("sp");
            var pOP = dbcontext.POBs.Any(p => p.MaSP == sp || p.MaSP == MaSP);
            var SP = dbcontext.SanPhams.Any(s => s.MaSP == sp || s.MaSP == MaSP);
            string searchText = Request.QueryString["searchText"];

            if (!SP && !string.IsNullOrEmpty(searchText))
            {
                Response.Write("  <style>\r\n#divPop, .divPop{\r\ndisplay:none !important;\r\n}\r\n</style>");
                ddlPop.Visible = false;
            }
            if (SP)
            {
                if (pOP)
                {
                    ddlPop.Visible = true;

                    using (var context = new QL_KPOPStoreEntities())
                    {
                        // Populate ddlCity
                        //var PopSP = from masp in context.POPs
                        //                where masp.MaSP == MaSP || masp.MaSP==sp
                        //                group masp by masp.MaPob into g
                        //                select g.Select(masp => masp).ToList();

                        var PopSP = context.POBs
                           .Where(p => p.MaSP == MaSP || p.MaSP == sp)
                           .OrderByDescending(p => p.MaPob) // Hoặc bất kỳ điều kiện sắp xếp nào phù hợp
                           .ToList();
                        ddlPop.DataSource = PopSP;
                        ddlPop.DataTextField = "TenPob";
                        ddlPop.DataValueField = "MaPob";
                        ddlPop.DataBind();
                        if (ViewState["SelectedValue"] != null)
                        {
                            ddlPop.SelectedValue = ViewState["SelectedValue"].ToString();
                        }
                        else ddlPop.SelectedIndex = 0;
                    }

                }
                else
                {
                    Response.Write("  <style>\r\n                                        #divPop, .divPop{\r\n                                            background:#0000 !important;\r\n                                        }\r\n                                    </style>");

                    ddlPop.Visible = false;
                }
            }
            else
            {
                Response.Write("  <style>\r\n                                        #divPop, .divPop{\r\n                                            display:none !important;\r\n                                        }\r\n                                    </style>");
                ddlPop.Visible = false;
            }
            
            

        }


        protected void ddlPop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaSP = Request.QueryString["sp"];
            string sp = HttpContext.Current.Request.QueryString.Get("sp");
            var saPaData = dbcontext.SanPhamDatas.FirstOrDefault(p => (p.MaSP == sp || p.MaSP == MaSP));
            //if (saPaData.Pop==true)
            //{


            //    ddlPop.Visible = true;
            //    Pop = ddlPop.SelectedItem.Text;
            //    SanPhamData sanP = dbcontext.SanPhamDatas.FirstOrDefault(s => (s.MaSP == sp || s.MaSP == MaSP));

            //}
            //else
            //{
            //    ddlPop.Visible = false;
            //    Pop = null;
            //}
            ViewState["SelectedValue"] = ddlPop.SelectedValue;


        }

        protected void btnToggleLike_Click(object sender, EventArgs e)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            if (dbcontext.TKs.Any(s => s.Email == EmailKhach))
            {
                if (dbcontext.KhachHangs.Any(s => s.Email == EmailKhach))
                {
                    KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);
                    string MaSP = Request.QueryString["sp"];
                    string sp = HttpContext.Current.Request.QueryString.Get("sp");
                    var saP = dbcontext.SanPhams.FirstOrDefault(p => (p.MaSP == sp || p.MaSP == MaSP));

                    string email = khachHang.Email; string dienThoai = khachHang.DienThoai;

                    string maSPId = saP.MaSP;
                    int khachHangId = Account.makh;
                    var ItsHasThich = dbcontext.ThichSPs.Any(s => s.MaSP == maSPId && (s.Email == khachHang.Email || s.DienThoai == khachHang.DienThoai) && s.MaKH == khachHangId);

                    if (ItsHasThich)
                    {
                        var HasThich = dbcontext.ThichSPs.FirstOrDefault(s => s.MaSP == maSPId && (s.Email == khachHang.Email || s.DienThoai == khachHang.DienThoai) && s.MaKH == khachHangId);

                        if (HasThich != null) // Kiểm tra xem HasThich có tồn tại trong cơ sở dữ liệu hay không
                        {
                            if (HasThich.DaThich == false)
                            {
                                HasThich.DaThich = true;
                            }
                            else
                            {
                                HasThich.DaThich = false;
                            }
                            dbcontext.SaveChanges();
                        }
                        else
                        {

                        }


                    }

                    else
                    {
                        using (SqlConnection conn = new SqlConnection(Shop.SQL_connectionString))
                        {
                            conn.Open();

                            // Kiểm tra xem bản ghi đã tồn tại trong bảng ThichSP hay chưa
                            //string checkSql = "SELECT COUNT(*) FROM ThichSP WHERE MaSP = @MaSP AND MaKH = @MaKH AND Email = @Email AND DienThoai = @DienThoai";

                            string checkSql = "SELECT COUNT(*) FROM ThichSP WHERE MaSP = @MaSP AND MaKH = @MaKH";


                            using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@MaSP", maSPId);
                                checkCmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);

                                int count = (int)checkCmd.ExecuteScalar();
                                if (count == 0) // Nếu bản ghi chưa tồn tại
                                {
                                    // Tạo một câu lệnh SQL để thêm bản ghi vào cơ sở dữ liệu
                                    string sql = "INSERT INTO ThichSP (MaSP, MaKH, Email, DienThoai, DaThich) VALUES (@MaSP, @MaKH, @Email, @DienThoai, @DaThich)";

                                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@MaSP", maSPId);
                                        cmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                                        cmd.Parameters.AddWithValue("@Email", khachHang.Email);
                                        cmd.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                                        cmd.Parameters.AddWithValue("@DaThich", true);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    var HasThich = dbcontext.ThichSPs.FirstOrDefault(s => s.MaSP == maSPId && s.MaKH == khachHang.MaKH);
                                    if (HasThich != null) // Kiểm tra xem HasThich có tồn tại trong cơ sở dữ liệu hay không
                                    {
                                        HasThich.DaThich = !HasThich.DaThich;

                                        // Lưu thay đổi vào cơ sở dữ liệu
                                        dbcontext.SaveChanges();
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }

                    //else { 
                    //    using (SqlConnection conn = new SqlConnection(Shop.SQL_connectionString))
                    //{
                    //    conn.Open();

                    //    // Tạo một câu lệnh SQL để thêm bình luận vào cơ sở dữ liệu
                    //    //string sql = "INSERT INTO DanhGia (AvatarUser, MaSP, TenKH, NoiDung, NgayDG, RatingValue, DienThoai, Email, LuotThich, Anh1, Anh2, Anh3, Anh4, Anh5, Video) VALUES (@AvatarUser, @MaSP, @TenKH, @NoiDung, @NgayDG, @RatingValue, @DienThoai, @Email, @LuotThich, @Anh1, @Anh2, @Anh3, @Anh4, @Anh5, @Video)";
                    //    string sql = "INSERT INTO ThichSP (MaSP, MaKH, Email, DienThoai, DaThich) VALUES (@MaSP, @MaKH, @Email, @DienThoai, @DaThich)";

                    //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    //    {
                    //        cmd.Parameters.AddWithValue("@MaSP", maSPId);
                    //        cmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                    //        cmd.Parameters.AddWithValue("@Email", khachHang.Email);
                    //        cmd.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                    //        cmd.Parameters.AddWithValue("@DaThich", true);
                    //        cmd.ExecuteNonQuery();

                    //    }
                    //}
                    //}

                    //ToggleLike(danhGiaId, khachHangId, email,dienThoai);


                }
                else
                {

                }

            }
            else
            {

            }
            Response.Redirect(Request.RawUrl);
        }        

        public IQueryable<TH03_WebBanHang.Models.SanPham> GetPhones()
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;


            string url = HttpContext.Current.Request.Url.ToString();
            string sppopular = HttpContext.Current.Request.QueryString.Get("sp");
            string gp = HttpContext.Current.Request.QueryString.Get("gp");
            string ls = HttpContext.Current.Request.QueryString.Get("ls");
            string searchText = Request.QueryString["searchText"];
            string myrating = HttpContext.Current.Request.QueryString.Get("myrating");
            string mylike = HttpContext.Current.Request.QueryString.Get("mylike");

            if((mylike !=null || myrating != null) && (gp==null || ls==null || sppopular == null || searchText==null))
            {
                if (mylike != null && myrating == null)
                {
                    var khach = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach && s.Email == mylike);
                    var liked = dbcontext.ThichSPs.FirstOrDefault(s => (s.Email == EmailKhach && s.MaKH == khach.MaKH) || (s.Email == EmailKhach && s.Email==mylike));
                    var hadliked = dbcontext.ThichSPs.Any(s => (s.Email == EmailKhach && s.MaKH == khach.MaKH) || (s.Email == EmailKhach && s.Email == mylike));
                    if (hadliked && ls == null)
                        return dbcontext.SanPhams.Where(s => s.MaSP == liked.MaSP);
                    else if(hadliked && ls != null) return dbcontext.SanPhams.Where(s => s.MaSP == liked.MaSP && s.MaLoai == ls);
                    else return null;
                }
                else if (myrating != null && mylike == null)
                {
                    var khach = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach && s.Email == myrating);
                    var rated = dbcontext.DanhGias.FirstOrDefault(s => (s.Email == EmailKhach && s.Email == khach.Email) || (s.Email == myrating && s.Email == EmailKhach));
                    var hadrated = dbcontext.DanhGias.Any(s => (s.Email == EmailKhach && s.Email == khach.Email) || (s.Email == myrating && s.Email==EmailKhach));
                    if(hadrated && ls==null)
                        return dbcontext.SanPhams.Where(s => s.MaSP == rated.MaSP);
                    else if (hadrated && ls !=null) return dbcontext.SanPhams.Where(s => s.MaSP == rated.MaSP && s.MaLoai == ls);
                    else return null;
                }
                else return null;
            }
            else
            {
                if ((dbcontext.SanPhams.Any(p =>p.MaNhom == gp) || gp != null)&&ls==null)
                {
                    return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                }
                //if (dbcontext.SanPhams.Any(p => p.MaLoai == ls)||ls!=null)
                //{
                //    return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls);
                //}
                if (dbcontext.SanPhams.Any(p => p.SoLuongKho > 0 && p.MaNhom == gp || p.MaLoai == ls))
                {
                    if (dbcontext.SanPhams.Any(p => p.SoLuongKho > 0 && p.MaNhom == gp && p.MaLoai == ls))
                    {
                        return dbcontext.SanPhams.Where(p => p.MaNhom == gp && p.MaLoai == ls).OrderByDescending(s => s.NgayNhap);
                    }
                    else if (gp != null && ls == "0")
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                    else if (gp != null && ls != null)
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp && p.MaLoai == ls).OrderByDescending(s => s.NgayNhap);
                    else if (dbcontext.SanPhams.Any(p => p.SoLuongKho > 0 && p.MaNhom == gp))
                    {

                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                    }
                    else if (dbcontext.SanPhams.Any(p => p.SoLuongKho > 0 && p.MaLoai == ls) && (gp == null || gp == ""))
                    {
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls).OrderByDescending(s => s.NgayNhap);
                    }
                    else if (ls == "0" && (gp != null || gp != ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                    else if (ls == "0" && (gp == null || gp == ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0).OrderByDescending(s => s.NgayNhap);
                    else if (ls == "0")
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0).OrderByDescending(s => s.NgayNhap);
                    else if (gp == null)
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0).OrderByDescending(s => s.NgayNhap);
                    else if (gp != null)
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                    else if (ls != null && (gp != null || gp != ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls && p.MaNhom == gp).OrderByDescending(s => s.NgayNhap);
                    else if (ls != null && (gp == null || gp == ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls).OrderByDescending(s => s.NgayNhap);
                    else
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0).OrderByDescending(s => s.NgayNhap);
                }
                else
                {
                    if (sppopular == "popular")
                    {
                        var chitietList = dbcontext.ChiTietDonHangs.Where(p => p.MaDH != null).ToList();
                        var maSPList = chitietList.Select(p => p.MaSP).ToList();
                        if (ls != null)
                        {
                            var sanpham = dbcontext.SanPhams
                                               .Where(p => maSPList.Contains(p.MaSP) && p.MaLoai == ls)
                                               .OrderByDescending(p => p.DoanhSo)
                                               .Take(8);
                            return sanpham;
                        }
                        else
                        {
                            var sanpham = dbcontext.SanPhams
                                               .Where(p => maSPList.Contains(p.MaSP))
                                               .OrderByDescending(p => p.DoanhSo)
                                               .Take(8);
                            return sanpham;
                        }
                    }
                    else if (sppopular == "new")
                    {
                        if (ls != null)
                        {
                            var sanpham = dbcontext.SanPhams
                                               .Where(p => p.MaLoai == ls)
                                               .OrderByDescending(p => p.NgayNhap)
                                               .Take(8);
                            return sanpham;
                        }
                        else
                        {
                            var sanpham = dbcontext.SanPhams
                                                   .OrderByDescending(p => p.NgayNhap)
                                                   .Take(8);
                            return sanpham;
                        }
                    }
                    else if (gp != null && ls != null)
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp && p.MaLoai == ls ).OrderByDescending(s => s.NgayNhap);
                    else if (dbcontext.SanPhams.Any(p => p.SoLuongKho > 0 && p.MaLoai == ls ))
                    {
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls ).OrderByDescending(s => s.NgayNhap);
                    }
                    else if (gp != null && ls == "0")
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaNhom == gp ).OrderByDescending(s => s.NgayNhap);
                    else if (ls == "0")
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 ).OrderByDescending(s => s.NgayNhap);
                    else if (ls != null && (gp != null || gp != ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls && p.MaNhom == gp ).OrderByDescending(s => s.NgayNhap);
                    else if (ls != null && (gp == null || gp == ""))
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && p.MaLoai == ls ).OrderByDescending(s => s.NgayNhap);
                    else if (!string.IsNullOrEmpty(searchText))
                    {
                        var hasloai = dbcontext.Loais.Any(s => s.TenLoai.Contains(searchText) || s.MaLoai.Contains(searchText));
                        var hasnhom = dbcontext.Nhoms.Any(s => s.TenNhom.Contains(searchText) || s.MaNhom.Contains(searchText));
                        if (hasloai)
                        {
                            Loai loai = dbcontext.Loais.FirstOrDefault(s => s.TenLoai.Contains(searchText) || s.MaLoai.Contains(searchText));
                            return dbcontext.SanPhams.Where(p => p.MaLoai == loai.MaLoai).GroupBy(p => p.TenSP).Select(group => group.OrderBy(p => p.Gia).FirstOrDefault());

                        }
                        else if (hasnhom)
                        {
                            Nhom nhom = dbcontext.Nhoms.FirstOrDefault(s => s.TenNhom.Contains(searchText) || s.MaNhom.Contains(searchText));


                            return dbcontext.SanPhams.Where(p => p.MaNhom == nhom.MaNhom).GroupBy(p => p.TenSP).Select(group => group.OrderBy(p => p.Gia).FirstOrDefault());

                        }
                        else
                        {
                            return dbcontext.SanPhams.Where(p => p.TenSP.Contains(searchText)).GroupBy(p => p.TenSP).Select(group => group.OrderBy(p => p.Gia).FirstOrDefault());

                        }
                    }
                    else if (string.IsNullOrEmpty(searchText))
                    {
                        return dbcontext.SanPhams.OrderByDescending(s => s.NgayNhap);
                    }
                    else
                    {
                        return dbcontext.SanPhams.Where(p => p.SoLuongKho > 0 && (gp == "" || gp == null) ).GroupBy(p => p.TenSP).Select(group => group.OrderBy(p => p.Gia).OrderByDescending(s => s.NgayNhap).FirstOrDefault());

                    }

                }
            }
        }

        public IQueryable<TH03_WebBanHang.Models.SanPham> GetVer([QueryString("sp")] String sp)
        {

            SanPham sanpham = dbcontext.SanPhams.FirstOrDefault(s => s.Ver == sp || s.Ver.Contains(sp) || sp.Contains(s.Ver) || s.MaSP == sp || s.MaSP.Contains(sp) || sp.Contains(s.MaSP));
            int SLsame = dbcontext.SanPhams.Where(s=>s.Ver==sanpham.Ver).Count();
            
            IQueryable<SanPham> sanPham = dbcontext.SanPhams.Where(p => p.Ver == sp || p.Ver.Contains(sp) || sp.Contains(p.Ver)|| p.MaSP == sp || p.MaSP.Contains(sp) || sp.Contains(p.MaSP));
            //if (sanpham.SoLuongKho <= 0 || sanpham.SoLuongKho == 0 || sanpham.SoLuongKho < 0)
            //{
            //    Response.Write("<style>\r\n                                            #aTenVer{\r\n                                                pointer-events:none;\r\n                                            }\r\n                                            #pTenVer{\r\n                color:#fff;                                background:#636363;\r\n                                            }\r\n                                        </style>");
            //}
            //else
            //{
            //    Response.Write("<style>\r\n                                            #aTenVer{\r\n                                                pointer-events:auto;\r\n                                            }\r\n                                            #pTenVer{\r\n               color:#000;                                 background:#fff;\r\n                                            }\r\n                                        </style>");
            //}


            return sanPham.Where(s=>(s.TenVer!=null||s.TenVer.Length==0||s.TenVer.Length<1)&&s.Ver==sanpham.Ver && SLsame>1);
        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TH03_WebBanHang.Models.SanPham> GetDetails([QueryString("sp")] String sp)
        {
            string ver = HttpContext.Current.Request.QueryString.Get("ver");
            var hasVer = dbcontext.SanPhams.Any(s => s.Ver != null && s.MaSP == sp);
            IQueryable<SanPham> sanPhams = dbcontext.SanPhams.Where(p => p.MaSP == sp);

            //if (hasVer)
            //{
            //    if (ver != null) sanPhams = dbcontext.SanPhams.Where(p => p.MaSP == sp && p.Ver == ver);

            //    else sanPhams = dbcontext.SanPhams.Where(p => p.MaSP == sp);

            //}
            //else
            //{
            //    sanPhams = dbcontext.SanPhams.Where(p => p.MaSP == sp);

            //}

            
            return sanPhams;
        }
        protected string IfNotNullOrEmpty(object value, string htmlIfNotNull)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return htmlIfNotNull;
            }
            return string.Empty;
        }
<<<<<<< HEAD

=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
        public IQueryable<TH03_WebBanHang.Models.SanPhamData> GetImages([QueryString("sp")] String sp)
        {
            // Giả sử bạn muốn lấy tất cả các ảnh liên quan đến sản phẩm có MaSP tương ứng
            SanPham sanpham = dbcontext.SanPhams.FirstOrDefault(s => s.MaSP == sp);
            string ver = HttpContext.Current.Request.QueryString.Get("ver");
            var hasVer = dbcontext.SanPhams.Any(s => s.Ver != null && s.MaSP == sp);
            IQueryable<SanPhamData> sanPhamDatas = dbcontext.SanPhamDatas.Where(p => p.MaSP == sp); ;

            
            // Thực hiện các kiểm tra điều kiện nếu cần
            // Ví dụ: Kiểm tra xem sản phẩm có số lượng kho > 0 và thuộc loại hoặc nhóm nhất định
            // Lưu ý: Bạn cần đảm bảo rằng bạn có thể truy cập thông tin cần thiết từ SanPhamData
            // để thực hiện các kiểm tra này.

            // Trả về dữ liệu từ SanPhamData

            return sanPhamDatas;


        }
        public IQueryable<TH03_WebBanHang.Models.Nhom> GetGroups()
        {
            string gp = HttpContext.Current.Request.QueryString.Get("gp");

            IQueryable<Nhom> maGrp = dbcontext.Nhoms.Where(p => p.MaNhom == gp);

            //if (SanPhams.Any(p => p.SoLuongKho>0&& p.MaLoai == "1" || p.MaLoai == "3"))
            //{
            //    Response.Write(" <style>\r\n                                #size{\r\n                                    display:flex;\r\n                                }\r\n                            </style>");
            //}
            //else Response.Write("<style>\r\n                                #size{\r\n                                    display:none;\r\n                                }\r\n                            </style>");
            //if (SanPhams.Any(p => p.SoLuongKho>0&& p.MaNhom == "1")) { Response.Write(" <style>                                .sizeM {\r\n         background:#9b51e0 !important;\r\n         border-color:#9b51e0 !important;\r\n     }\r\n        .sizeL {\r\n         background:#fff0 !important;\r\n         border-color:#000 !important;\r\n     }\r\n </style>"); }
            //else if (SanPhams.Any(p => p.SoLuongKho>0&& p.MaNhom == "2")) { Response.Write(" <style>                                .sizeL {\r\n         background:#9b51e0 !important;\r\n         border-color:#9b51e0 !important;\r\n     }\r\n        .sizeM {\r\n         background:#fff0 !important;\r\n         border-color:#000 !important;\r\n     }\r\n </style>"); }


            return maGrp;
        }
        /// <summary>
        /// Lấy giở hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<ChiTietDonHang> LayGioHang()
        {
            List<ChiTietDonHang> lstGioHang = Session["GioHang"] as List<ChiTietDonHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<ChiTietDonHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;


        }    
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            // Trở lại trang hiện tại
            string url = HttpContext.Current.Request.Url.ToString();
            //productDetail.DataItem.
            // Lấy giở hàng

            List<ChiTietDonHang> lstGioHang = LayGioHang();
            // 
            string idsp = HttpContext.Current.Request.QueryString.Get("sp");
            var saP = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp && p.SoLuongKho > 0);

            var HavepOP = dbcontext.POBs.Any(p => p.MaSP == idsp);

            

            var sanPhamCon1 = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp && p.SoLuongKho == 1);
            var saPA = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
            int soLuongCoThe;
            soLuongCoThe = saPA.SoLuongKho.Value;
            ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp);
            if (HavepOP)
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp && sp.TenPob == ddlPop.SelectedItem.Text);

            }
            else
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp);

            }
            if (int.TryParse(txtSoLuong.Text, out int currentValue))
            {
                if (currentValue > soLuongCoThe)
                {
                    int soluongCon = saPA.SoLuongKho.Value;
                    txtSoLuong.Text = soluongCon.ToString();
                }
                else
                {
                    if (currentValue == 1)
                    {
                        if (chiTietDon == null && saP != null)
                        {
                            SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
                            chiTietDon = new ChiTietDonHang();
                            chiTietDon.MaSP = idsp;
                            if (chiTietDon.SoLuong <= soLuongCoThe)
                            {
                                chiTietDon.SoLuong = 1;
                            }

                            chiTietDon.TenSP = sanPham.TenSP;
                            chiTietDon.DuongDan = sanPham.DuongDan;
                            chiTietDon.Gia = (double)sanPham.Gia;
                            chiTietDon.ThanhTien = (double)sanPham.Gia * currentValue;

                            var pOP = dbcontext.POBs.Any(p => p.MaSP == idsp);
                            if (pOP)
                            {
                                chiTietDon.TenPob = ddlPop.SelectedItem.Text;
                            }
                            else
                            {
                                chiTietDon.TenPob = null;
                            }

                            lstGioHang.Add(chiTietDon);
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;
                            Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                            Thread.Sleep(1500);

                            Response.Redirect(Request.RawUrl);
                        }
                        else if (saP != null && sanPhamCon1 == null)
                        {
                            if (HavepOP)
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe && chiTietDon.TenPob == ddlPop.SelectedItem.Text)
                                {
                                    chiTietDon.SoLuong++;
                                }
                            }
                            else
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe)
                                {
                                    chiTietDon.SoLuong++;
                                }
                            }
                            

                            chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;
                            Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                            Thread.Sleep(1500);

                            Response.Redirect(Request.RawUrl);
                        }
                    }
                    else
                    {
                        if (chiTietDon == null && saP != null)
                        {
                            SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
                            chiTietDon = new ChiTietDonHang();
                            chiTietDon.MaSP = idsp;
                            if (chiTietDon.SoLuong == soLuongCoThe || chiTietDon.SoLuong <= soLuongCoThe)
                            {
                                chiTietDon.SoLuong = currentValue;
                            }
                            var pOP = dbcontext.POBs.Any(p => p.MaSP == idsp);
                           



                            chiTietDon.TenSP = sanPham.TenSP;
                            chiTietDon.DuongDan = sanPham.DuongDan;
                            chiTietDon.Gia = (double)sanPham.Gia;
                            chiTietDon.ThanhTien = (double)sanPham.Gia * currentValue;

                            if (pOP)
                            {
                                chiTietDon.TenPob = ddlPop.SelectedItem.Text;
                            }
                            else
                            {
                                chiTietDon.TenPob = null;
                            }


                            lstGioHang.Add(chiTietDon);
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                            Thread.Sleep(1500);

                            Response.Redirect(Request.RawUrl);
                        }
                        else if (saP != null && sanPhamCon1 == null)
                        {
                            if (HavepOP)
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe && chiTietDon.TenPob == ddlPop.SelectedItem.Text)
                                {
                                    chiTietDon.SoLuong++;
                                }
                            }
                            else
                            {
                                if (chiTietDon.SoLuong == soLuongCoThe || chiTietDon.SoLuong <= soLuongCoThe)
                                {
                                    chiTietDon.SoLuong += currentValue;
                                }
                            }

                            

                            chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                            Thread.Sleep(1500);

                            Response.Redirect(Request.RawUrl);
                        }
                    }
                }


            }


        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            // Trở lại trang hiện tại
            string url = HttpContext.Current.Request.Url.ToString();
            Button btnCart = (Button)sender;
            string itemMaSP = btnCart.CommandArgument;
            //productDetail.DataItem.
            // Lấy giở hàng
            var pOP = dbcontext.POBs.Any(p => p.MaSP == itemMaSP);
            var saP = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP && p.SoLuongKho > 0);
            var popSP = dbcontext.POBs.FirstOrDefault(s => s.MaSP == itemMaSP);





            List<ChiTietDonHang> lstGioHang = LayGioHang();
            // 
            //string idsp = HttpContext.Current.Request.QueryString.Get("sp");
            //ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);
            ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);

            if (pOP)
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP && sp.TenPob == popSP.TenPob);

            }
            else
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);

            }


            var sanPhamCon1 = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP && p.SoLuongKho == 1);

            if (chiTietDon == null && saP != null)
            {
                SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP);
                chiTietDon = new ChiTietDonHang();
                chiTietDon.MaSP = itemMaSP;
                chiTietDon.SoLuong = 1;
                chiTietDon.TenSP = sanPham.TenSP;
                chiTietDon.DuongDan = sanPham.DuongDan;
                chiTietDon.Gia = (double)sanPham.Gia;
                chiTietDon.ThanhTien = (double)sanPham.Gia;
                if (pOP)
                {
                    chiTietDon.TenPob = popSP.TenPob;
                }
                else
                {
                    chiTietDon.TenPob = null;
                }


                lstGioHang.Add(chiTietDon);
                Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                Session["GioHang"] = lstGioHang;
                Thread.Sleep(1500);

                Response.Redirect(Request.RawUrl);
            }
            else if (saP != null && sanPhamCon1 == null)
            {
                if (pOP)
                {
                    if (chiTietDon.TenPob == popSP.TenPob)
                    {
                        chiTietDon.SoLuong++;
                    }
                    else
                    {
                        chiTietDon.SoLuong++;
                    }
                }
                else
                {
                    chiTietDon.SoLuong++;
                }
                //chiTietDon.SoLuong++;
                Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

                chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
                Session["GioHang"] = lstGioHang;
                Thread.Sleep(1500);

                Response.Redirect(Request.RawUrl);
            }

        }


        //protected void btnCart_Click(object sender, ImageClickEventArgs e)
        //{
        //    // Trở lại trang hiện tại
        //    string url = HttpContext.Current.Request.Url.ToString();
        //    ImageButton btnCart = (ImageButton)sender;
        //    string itemMaSP = btnCart.CommandArgument;
        //    //productDetail.DataItem.
        //    // Lấy giở hàng
        //    var pOP = dbcontext.POBs.Any(p => p.MaSP == itemMaSP);
        //    var saP = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP && p.SoLuongKho > 0);
        //    var popSP = dbcontext.POBs.FirstOrDefault(s => s.MaSP == itemMaSP);

            



        //    List<ChiTietDonHang> lstGioHang = LayGioHang();
        //    // 
        //    //string idsp = HttpContext.Current.Request.QueryString.Get("sp");
        //    //ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);
        //    ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);

        //    if (pOP)
        //    {
        //        chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP && sp.TenPob == popSP.TenPob);

        //    }
        //    else
        //    {
        //        chiTietDon = lstGioHang.Find(sp => sp.MaSP == itemMaSP);

        //    }


        //    var sanPhamCon1 = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP && p.SoLuongKho == 1);

        //    if (chiTietDon == null && saP != null)
        //    {
        //        SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == itemMaSP);
        //        chiTietDon = new ChiTietDonHang();
        //        chiTietDon.MaSP = itemMaSP;
        //        chiTietDon.SoLuong = 1;
        //        chiTietDon.TenSP = sanPham.TenSP;
        //        chiTietDon.DuongDan = sanPham.DuongDan;
        //        chiTietDon.Gia = (double)sanPham.Gia;
        //        chiTietDon.ThanhTien = (double)sanPham.Gia;
        //        if (pOP)
        //        {
        //            chiTietDon.TenPob = popSP.TenPob;
        //        }
        //        else
        //        {
        //            chiTietDon.TenPob = null;
        //        }

                
        //        lstGioHang.Add(chiTietDon);
        //        Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

        //        Session["GioHang"] = lstGioHang;
        //        Thread.Sleep(1500);

        //        Response.Redirect(Request.RawUrl);
        //    }
        //    else if (saP != null && sanPhamCon1 == null)
        //    {
        //        if (pOP)
        //        {
        //            if(chiTietDon.TenPob == popSP.TenPob)
        //            {
        //                chiTietDon.SoLuong++;
        //            }
        //            else
        //            {
        //                chiTietDon.SoLuong++;
        //            }
        //        }
        //        else
        //        {
        //            chiTietDon.SoLuong++;
        //        }
        //        //chiTietDon.SoLuong++;
        //        Response.Write(" <script>\r\n        // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click\r\n        const notification = document.getElementById('notification');\r\n\r\n       \r\n            // Hiển thị thông báo\r\n            notification.style.display = 'flex';\r\n\r\n            // Ẩn thông báo sau 2 giây\r\n            setTimeout(function () {\r\n                notification.style.display = 'none';\r\n            }, 2000);\r\n        \r\n    </script>");

        //        chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
        //        Session["GioHang"] = lstGioHang;
        //        Thread.Sleep(1500);

        //        Response.Redirect(Request.RawUrl);
        //    }

        //}


        protected void BuyNow_Click(object sender, EventArgs e)
        {
            // Trở lại trang hiện tại
            string url = HttpContext.Current.Request.Url.ToString();
            //productDetail.DataItem.
            // Lấy giở hàng
            List<ChiTietDonHang> lstGioHang = LayGioHang();
            // 
            string idsp = HttpContext.Current.Request.QueryString.Get("sp");
            var saP = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp && p.SoLuongKho > 0);
            var HavepOP = dbcontext.POBs.Any(p => p.MaSP == idsp);

            ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp); ;
            if (HavepOP)
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp && sp.TenPob == ddlPop.SelectedItem.Text);

            }
            else
            {
                chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp);

            }


            //ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp);
            //ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp && sp.TenPob == ddlPop.SelectedItem.Text);


            var sanPhamCon1 = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp && p.SoLuongKho == 1);
            var saPA = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);

            int soLuongCoThe;
            soLuongCoThe = saPA.SoLuongKho.Value;
            if (int.TryParse(txtSoLuong.Text, out int currentValue))
            {
                if (currentValue > soLuongCoThe)
                {
                    int soluongCon = saPA.SoLuongKho.Value;
                    txtSoLuong.Text = soluongCon.ToString();
                }
                else
                {
                    if (currentValue == 1)
                    {
                        if (chiTietDon == null && saP != null)
                        {
                            SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
                            chiTietDon = new ChiTietDonHang();
                            chiTietDon.MaSP = idsp;
                            if (chiTietDon.SoLuong <= soLuongCoThe)
                            {
                                chiTietDon.SoLuong = 1;
                            }




                            chiTietDon.TenSP = sanPham.TenSP;
                            chiTietDon.DuongDan = sanPham.DuongDan;
                            chiTietDon.Gia = (double)sanPham.Gia;
                            chiTietDon.ThanhTien = (double)sanPham.Gia * currentValue;
                            var pOP = dbcontext.POBs.Any(p => p.MaSP == idsp);
                            if (pOP)
                            {
                                chiTietDon.TenPob = ddlPop.SelectedItem.Text;
                            }
                            else
                            {
                                chiTietDon.TenPob = null;
                            }


                            lstGioHang.Add(chiTietDon);
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Thread.Sleep(1500);
                            if (lstGioHang.Any(p => p.MaSP == idsp))
                            {
                                Response.Redirect("Pay.aspx");
                            }

                        }
                        else if (chiTietDon != null && saP != null && sanPhamCon1 == null)
                        {
                            if (HavepOP)
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe && chiTietDon.TenPob==ddlPop.SelectedItem.Text)
                                {
                                    chiTietDon.SoLuong++;
                                }
                            }
                            else
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe)
                                {
                                    chiTietDon.SoLuong++;
                                }
                            }
                            

                            chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Thread.Sleep(1500);

                            Response.Redirect("Pay.aspx");

                        }
                    }
                    else
                    {
                        if (chiTietDon == null && saP != null)
                        {
                            SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
                            chiTietDon = new ChiTietDonHang();
                            chiTietDon.MaSP = idsp;
                            if (chiTietDon.SoLuong <= soLuongCoThe)
                            {
                                chiTietDon.SoLuong = currentValue;
                            }

                            chiTietDon.TenSP = sanPham.TenSP;
                            chiTietDon.DuongDan = sanPham.DuongDan;
                            chiTietDon.Gia = (double)sanPham.Gia;
                            chiTietDon.ThanhTien = (double)sanPham.Gia * currentValue;

                            var pOP = dbcontext.POBs.Any(p => p.MaSP == idsp);
                            if (pOP)
                            {
                                chiTietDon.TenPob = ddlPop.SelectedItem.Text;
                            }
                            else
                            {
                                chiTietDon.TenPob = null;
                            }

                            lstGioHang.Add(chiTietDon);
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Thread.Sleep(1500);
                            if (lstGioHang.Any(p => p.MaSP == idsp))
                            {
                                Response.Redirect("Pay.aspx");
                            }

                        }
                        else if (chiTietDon != null && saP != null && sanPhamCon1 == null)
                        {
                            if (HavepOP)
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe && chiTietDon.TenPob==ddlPop.SelectedItem.Text)
                                {
                                    chiTietDon.SoLuong += currentValue;
                                }
                            }
                            else
                            {
                                if (chiTietDon.SoLuong <= soLuongCoThe)
                                {
                                    chiTietDon.SoLuong += currentValue;
                                }
                            }

                            

                            chiTietDon.ThanhTien = chiTietDon.Gia * chiTietDon.SoLuong;
                            Session["GioHang"] = lstGioHang;
                            soLuongCoThe -= chiTietDon.SoLuong;

                            Thread.Sleep(1500);

                            Response.Redirect("Pay.aspx");

                        }
                    }
                }

            }


        }
        protected void productDetail_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {


            if (int.TryParse(txtSoLuong.Text, out int currentValue))
            {
                if (currentValue == 0|| currentValue < 0||currentValue <= 0)
                {
                    int newValue = 1;
                    txtSoLuong.Text = newValue.ToString();
                    
                }
                else
                {
                    if (currentValue > 1) { 
                    int newValue = currentValue - 1;
                    txtSoLuong.Text = newValue.ToString();
                    }
                    else
                    {
                        int newValue = 1;
                        txtSoLuong.Text = newValue.ToString();
                    }

                }


            }
            else
            {

                int newValue = 1;
                txtSoLuong.Text = newValue.ToString();
            }
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string idsp = HttpContext.Current.Request.QueryString.Get("sp");

            var saPA = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
            int soLuongCoThe;
            soLuongCoThe = saPA.SoLuongKho.Value;
            if (int.TryParse(txtSoLuong.Text, out int currentValue))
            {
                if (currentValue > soLuongCoThe)
                {
                    int newValue = soLuongCoThe;
                    txtSoLuong.Text = newValue.ToString();
                    Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");

                }
                else if (currentValue == saPA.SoLuongKho)
                {
                    txtSoLuong.Text = saPA.SoLuongKho.ToString();
                }
                else
                {
                    int newValue = currentValue + 1;
                    txtSoLuong.Text = newValue.ToString();
                    Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");

                }


            }
            else
            {
                // Xử lý trường hợp không thể chuyển đổi giá trị
                Response.Write("<style>#divDetailProduct{background:linear-gradient(to right, #522A77,#2a2e77) !important;}</style>");

            }
        }

        //protected void btnEditRating_Click(object sender, EventArgs e)
        //{
        //    ratingForm.Visible = true;
        //    txtComment.Visible = true;
        //    btnSubmitCommentIMG.Visible = true;
        //}

        //        private void DisplayMostRatedStar()
        //{
        //    string sp = HttpContext.Current.Request.QueryString.Get("sp");

        //    // Lấy danh sách đánh giá từ bảng DanhGias
        //    var ratings = dbcontext.DanhGias.Where(s => s.MaSP == sp).Select(d => d.RatingValue).ToList();

        //    // Tính số lượng đánh giá cho mỗi sao
        //    Dictionary<int, int> starRatingsCount = new Dictionary<int, int>();
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        starRatingsCount[i] = ratings.Count(rating => rating == i);
        //    }

        //    // Tìm sao có số lượng đánh giá nhiều nhất
        //    // Nếu có nhiều hơn một sao có số lượng đánh giá nhiều nhất, chọn sao lớn nhất
        //    int mostRatedStar = starRatingsCount.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).First().Key;

        //    // Hiển thị kết quả lên web
        //    // Giả sử bạn có một Label ID là "lblMostRatedStar" để hiển thị sao có số lượng đánh giá nhiều nhất
        //    lblMostRatedStar.Text = $"{mostRatedStar}";
        //}

        //public void ToggleLike(string maSP, int maKH, string email = null, string dienThoai = null, bool daThich = true)
        //{
        //    var thich = dbcontext.ThichSPs.Any(t => t.MaSP == maSP && t.MaKH == maKH);
        //    if(thich)
        //    { 
        //        using (var db = new QL_KPOPStoreEntities())
        //        {
        //           KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(s => s.Email == EmailKhach);

        //            var thichNot = dbcontext.ThichSPs.Any(s=>s.MaSP==maSP&&s.MaKH==maKH&&s.Email== khachHang.Email&& s.DienThoai==khachHang.DienThoai);
        //            if (thichNot)
        //            {
        //                var thichAdd = dbcontext.ThichSPs.FirstOrDefault(s => s.MaSP == maSP && s.MaKH == maKH && s.Email == khachHang.Email && s.DienThoai == khachHang.DienThoai);

        //                 if (thichAdd == null)
        //                {
        //                    // Người dùng chưa thích bình luận này, thêm mới
        //                    db.ThichSPs.Add(new ThichSP { MaSP = maSP, MaKH = maKH, DaThich = true });
        //                }
        //                else
        //                {
        //                        // Người dùng đã thích bình luận này, thay đổi trạng thái
        //                        thichAdd.DaThich = !thichAdd.DaThich;
        //                }
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                    var thichSP = new ThichSP
        //                    {
        //                        MaSP = maSP,
        //                        MaKH = maKH,
        //                        Email = email,
        //                        DienThoai = dienThoai,
        //                        DaThich = daThich
        //                    };
        //                    db.ThichSPs.Add(thichSP);
        //                    db.SaveChanges();
        //            }

        //        }
        //    }
        //    else
        //    {
        //        var thichSP = new ThichSP
        //        {
        //            MaSP = maSP,
        //            MaKH = maKH,
        //            Email = email,
        //            DienThoai = dienThoai,
        //            DaThich = daThich
        //        };
        //        dbcontext.ThichSPs.Add(thichSP);
        //        dbcontext.SaveChanges();
        //    }
        //}



        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        //public IQueryable<TH03_WebBanHang.Models.SanPham> GetTomping([QueryString("sp")] String sp)
        //{

        //        IQueryable<SanPham> Tomping = dbcontext.SanPhams.Where(p => p.MaLoai == "6");

        //    IQueryable<SanPham> TraSua = dbcontext.SanPhams.Where(p => p.MaLoai == "1");
        //    if (TraSua.Any(p => p.MaSP == sp))
        //    {
        //       masp = sp;
        //        return Tomping;
        //    }
        //    return null;


        //}
        //protected void cbTomping_CheckedChanged(object sender, EventArgs e)
        //{
        //    // Get the price of the selected topping
        //    CheckBox cb = (CheckBox)sender;
        //    SanPham topping = dbcontext.SanPhams.SingleOrDefault(p => p.MaLoai == "6");
        //    double toppingPrice = topping.Gia;

        //    // Get the price of the main product
        //    SanPham sanPhams = dbcontext.SanPhams.SingleOrDefault(p => p.MaSP == masp);
        //    double mainProductPrice = sanPhams.Gia;

        //    // Update the price of the main product
        //    if (cb.Checked)
        //    {
        //        // Add the price of the topping to the price of the main product
        //        mainProductPrice += toppingPrice;
        //    }
        //    else
        //    {
        //        // Subtract the price of the topping from the price of the main product
        //        mainProductPrice -= toppingPrice;
        //    }



        //        lbPrice.Text = string.Format("{0:N0}", mainProductPrice.ToString()) + "đ";


        //}

        //int tomPing = 0;
        //protected void AddTomping_Click(object sender, EventArgs e)
        //{
        //    string idsp = HttpContext.Current.Request.QueryString.Get("sp");
        //    List<ChiTietDonHang> lstGioHang = LayGioHang();

        //    ChiTietDonHang chiTietDon = lstGioHang.Find(sp => sp.MaSP == idsp);
        //    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
        //    tomPing  += 5000; 
        //}

        //protected void SizeM_Click(object sender, EventArgs e)
        //{
        //    string url = HttpContext.Current.Request.Url.ToString();

        //    //Response.Write("<style>.sizeL{background-color:#fff;}.sizeM{background-color:red;}</style>");
        //    string idsp = HttpContext.Current.Request.QueryString.Get("sp");
        //    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
        //    //SanPham sanPhamSize =dbcontext.SanPhams.FirstOrDefault(p=>p.MaSP != idsp&&p.TenSP==sanPham.TenSP&&p.Gia<=sanPham.Gia);
        //    //if (sanPhamSize != null)
        //    //{            SanPham sanPhamSL = dbcontext.SanPhams.Where(p => p.Gia <= sanPhamSize.Gia && p.TenSP == sanPhamSize.TenSP).FirstOrDefault();

        //    //    //Response.Write(" <style>                                .sizeM {\r\n         background:#9b51e0 !important;\r\n         border-color:#9b51e0 !important;\r\n     }\r\n        .sizeL {\r\n         background:#fff0 !important;\r\n         border-color:#000 !important;\r\n     }\r\n </style>");
        //    //    Response.Redirect("item.aspx?sp=" + sanPhamSL.MaSP);
        //    //}
        //    //else Response.Redirect(Request.RawUrl);
        //    SanPham sanPhamSL = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP != idsp && p.TenSP == sanPham.TenSP && p.MaNhom == "1");
        //    if (sanPhamSL != null || sanPham.MaNhom != "1")
        //    {
        //        Response.Redirect("item.aspx?sp=" + sanPhamSL.MaSP);
        //    }
        //    else Response.Redirect(Request.RawUrl);

        //}
        //protected void SizeL_Click(object sender, EventArgs e)
        //{
        //    string url = HttpContext.Current.Request.Url.ToString();

        //    //Response.Write("<style>.sizeL{background-color:red;}.sizeM{background-color:#fff;}</style>");
        //    string idsp = HttpContext.Current.Request.QueryString.Get("sp");
        //    SanPham sanPham = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP == idsp);
        //    //SanPham sanPhamSize = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP != idsp && p.TenSP == sanPham.TenSP && (p.Gia >= sanPham.Gia));
        //    //if (sanPhamSize != null)
        //    //{
        //    //SanPham sanPhamSL= dbcontext.SanPhams.Where(p => p.Gia>= sanPhamSize.Gia && p.TenSP == sanPhamSize.TenSP).FirstOrDefault();

        //    //    Response.Redirect("item.aspx?sp=" + sanPhamSL.MaSP);
        //    //}
        //    //else Response.Redirect(Request.RawUrl);
        //    SanPham sanPhamSL = dbcontext.SanPhams.FirstOrDefault(p => p.MaSP != idsp && p.TenSP == sanPham.TenSP && p.MaNhom == "2");
        //    if (sanPhamSL != null || sanPham.MaNhom != "2")
        //    {
        //        if (sanPhamSL != null)
        //        {
        //            Response.Redirect("item.aspx?sp=" + sanPhamSL.MaSP);
        //        }
        //        else if (sanPhamSL == null)
        //        {
        //            Response.Redirect(Request.RawUrl); Response.Write("<script>alert('Sản phẩm không tồn tại');</script>");
        //        }
        //        else
        //        {
        //            Response.Redirect(Request.RawUrl); Response.Write("<script>alert('Sản phẩm không tồn tại');</script>");
        //        }

        //    }
        //    else
        //    {
        //        Response.Redirect(Request.RawUrl); Response.Write("<script>alert('Sản phẩm không tồn tại');</script>");
        //    }
        //}

        public void SendEmail(string to, string subject, string body, string imagePath, string avatar, string userName, int valueRate, string anh1, string anh2, string anh3, string anh4, string anh5, string videoM)
        {
            try
            {

                // Tạo một đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential(Shop.gmailAccount, Shop.gmailPass),
                    EnableSsl = true
                };

                // Tạo một đối tượng MailMessage
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Shop.gmailAccount);
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.Subject = subject;

                // Thêm hình ảnh vào email
                System.Net.Mail.LinkedResource inline = new System.Net.Mail.LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
                inline.ContentId = Guid.NewGuid().ToString(); // Đặt ContentId để tham chiếu đến hình ảnh trong HTML

                // Tạo nội dung HTML tùy chỉnh
<<<<<<< HEAD
                string htmlBody = $"<html><body style=\"padding: 10px; background:#000; color:#FFFF; height:max-content; \"><img style=\"max-width: 100%;  border-radius:20px; \" src='cid:{inline.ContentId}' alt='KStore' /><h1>Bài đánh giá sản phẩm</h1>" +
=======
                string htmlBody = $"<html><body><img style=\"max-width: 100%;  border-radius:20px; \" src='cid:{inline.ContentId}' alt='KStore' /><h1>Bài đánh giá sản phẩm</h1>" +
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                    //$"<div style='display:flex; gap:15px;'>" +
                    //$"<img style='object-fit:cover; background:#000; width:50px; height:50px; border-radius:50%; border:2px solid #9b51e0' src='{avatar}'/>" +
                    //$"<p style=\"\"><strong  style=\"color:#000; font-size:16px; \">{userName}</strong></p>    \r\n         " +
                    //$"<p>    <strong style=\"color:#000;\">(</strong><strong style=\"width:16px; font-family:Verdana, Geneva, Tahoma, sans-serif; font-weight:bolder; color:#ffc107;\">{valueRate.ToString()}</strong><span  ClientIDMode=\"Static\" style=\"width:16px; font-family:Baloo; color:#ffc107;\"><i class=\"fa-solid fa-star\" style=\"color: #ffc107;\"></i></span><strong style=\"color:#000;\">)</strong></p></div>" +
                   
                    //$"<div class=\"d-flex\" style=\"width:100%; flex-wrap:wrap; gap:10px; padding:5px 0px 10px 10px; margin-top:5px; overflow-wrap: break-word; \">\r\n    <%# IfNotNullOrEmpty({anh1}), \"<div class='image-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"image\\\" data-fancybox-index=0 href='\" + {anh1} + \"'><img src='\" + {anh1}+ \"' class='rating-image fade-out' /></a></div>\") %>\r\n    <%# IfNotNullOrEmpty({anh2}), \"<div class='image-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"image\\\" data-fancybox-index=1 href='\" + {anh2} + \"'><img src='\" + {anh2} + \"' class='rating-image fade-out' /></a></div>\") %>\r\n    <%# IfNotNullOrEmpty({anh3}), \"<div class='image-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"image\\\" data-fancybox-index=2 href='\" + {anh3} + \"'><img src='\" + {anh3} + \"' class='rating-image fade-out' /></a></div>\") %>\r\n    <%# IfNotNullOrEmpty({anh4}), \"<div class='image-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"image\\\" data-fancybox-index=3 href='\" + {anh4} + \"'><img src='\" + {anh4} + \"' class='rating-image fade-out' /></a></div>\") %>\r\n    <%# IfNotNullOrEmpty({anh5}), \"<div class='image-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"image\\\" data-fancybox-index=4 href='\" + {anh5} + \"'><img src='\" + {anh5} + \"' class='rating-image fade-out' /></a></div>\") %>\r\n\r\n    <%# IfNotNullOrEmpty({videoM}), \"<div class='video-container'><a data-fancybox=\\\"gallery\\\" data-type=\\\"video\\\" data-fancybox-index=5 href='\" + {videoM} + \"'><video src='\" + {videoM} + \"' class='rating-video fade-out' /></a></div>\") %>\r\n\r\n    <style>\r\n        .image-container, .video-container {{\r\n            height: max-content; /* Kích thước cố định cho container */\r\n            overflow: hidden; /* Ẩn phần của hình ảnh và video không vừa với container */\r\n                    transition:0.5s;\r\n                    border-radius:10px;\r\n\r\n        }}\r\n        .rating-image, .rating-video {{\r\n            width: 100%;\r\n            height: 100%;\r\n            object-fit: cover; /* Hoặc sử dụng 'contain' nếu muốn hình ảnh và video luôn hiển thị toàn bộ nội dung */\r\n            border-radius:10px;\r\n            transition:0.5s;\r\n\r\n        }}\r\n\r\n        .image-container:hover, .video-container:hover {{\r\n             transform:scale(1.1);\r\n             /*transform:translate(0,-10px);*/\r\n            box-shadow:0 10px 50px #636363;\r\n        }}\r\n\r\n        @media only screen and  (max-width: 600px) {{\r\n            .image-container, .video-container {{\r\n                width: 60px; /* Giảm kích thước cho các thiết bị nhỏ hơn */\r\n            }}\r\n        }}\r\n    </style>" +
                    $"<p>Bài đánh giá về sản phẩm: <strong>{body}</strong> của bạn đã được chúng tôi ghi nhận." +
                    $"<p>Nội dung đánh giá: {txtComment.Text}</p>" +
                    $"Chân thành cảm ơn bạn chúng tôi!</p></body></html>";

                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                avHtml.LinkedResources.Add(inline);
                mailMessage.AlternateViews.Add(avHtml);

                // Gửi email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Đã gửi email.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
            }
        }


    }



}