using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TH03_WebBanHang.Models;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Web.ModelBinding;
using System.IO;

namespace TH03_WebBanHang
{
    public partial class Account : System.Web.UI.Page
    {
        private QL_KPOPStoreEntities dbcontext = new QL_KPOPStoreEntities();
        public static int makh;
        public string maK;
        public static int MaKhach;
        public static string urlAvt;
        protected void Page_Load(object sender, EventArgs e)
        {


            // Query the database for the user with the given username and password
            var user = from u in dbcontext.TKs
                       select u;
            var khachhang = from u in dbcontext.KhachHangs
                            select u;

            var db = new QL_KPOPStoreEntities();
            if (user.Count() > 1)
            {
                //Session.Clear();




            }
            if (user.Any(p => (p.TrangThai == true && p.Email == Sign.email)))
            {


                var tk = user.FirstOrDefault(p => p.Email == Sign.email); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
                var kh = khachhang.FirstOrDefault(p => p.Email == Sign.email); //lọc trong xem có email nào == lbDeptid đang được hiện (TK)
                if (kh != null)
                {
                    maK = kh.MaKH.ToString(); MaKhach = kh.MaKH;

                    if (kh.AvatarUser != null)
                    {
                        ProfileImage.ImageUrl = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == MaKhach).AvatarUser;
                        urlAvt = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == MaKhach).AvatarUser;
                    }
                    else
                    {
                        ProfileImage.ImageUrl = Shop.defaultAvatar_BlackKS;
                        urlAvt = Shop.defaultAvatar_BlackKS;

                    }
                    lbDiem.Text = "Điểm: " + dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == MaKhach).Diem.ToString();

                }
                else if (kh == null && Sign.email == "Admin")
                {
                    ProfileImage.ImageUrl = Shop.defaultAvatar_BlackKS;
                    urlAvt = Shop.defaultAvatar_BlackKS;
                    MaKhach = 0;
                }
                else
                {
                    MaKhach = 0;
                }

                makh = tk.MaTK; // Cập nhật giá trị của makh từ tk.MaKH
                Session["MaKH"] = MaKhach; // Gán giá trị của makh vào Session["MaKH"]

                FileUploadProfilePic.Attributes["onchange"] = "btnUpload_Click(this)";
                if (tk.Email == "Admin" || tk.Quyen == "Admin" || tk.Quyen == "Manager")
                {
                    btnControl.Visible = true;
                    if (tk.Email == "Admin")
                    { btnAccOrder.Visible = false; Response.Redirect("Manager"); }
                    if (tk.Email != "Admin" && (tk.Quyen == "Admin" || tk.Quyen == "Manager"))
                    { btnAccOrder.Visible = true; }

                }
                else if (tk.Quyen == null || tk.Quyen == "None") { btnControl.Visible = false; }
                else btnControl.Visible = false;


            }
            // Otherwise, display an error message

            else
            {

                Response.Redirect("Sign.aspx");

            }
            //if (Session["TenTaiKhoan"] != null)
            //{
            //    // Lấy tên tài khoản từ session
            //    string tenTaiKhoan = Session["TenTaiKhoan"].ToString();
            //    string khachHang = Session["MaKH"].ToString();
            //    int maKH;
            //    // Query the database for the user with the given username
            //    var users = dbcontext.TKs.FirstOrDefault(u => u.TenTaiKhoan == tenTaiKhoan);
            //    if (int.TryParse(khachHang, out maKH))
            //    {
            //        var khs = dbcontext.KhachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
            //        if (khs != null)
            //        {
            //            // Sử dụng thông tin của khách hàng tại đây
            //            ListViewClient.DataSource = new List<KhachHang> { khs };
            //            ListViewClient.DataBind();
            //        }
            //        else
            //        {
            //            // Không tìm thấy khách hàng có mã tương ứng
            //        }
            //    }
            //    // Kiểm tra xem tài khoản có tồn tại hay không
            //    if (users != null)
            //    {
            //        // Tài khoản tồn tại, thêm nó vào ListView
            //        ListViewAccounts.DataSource = new List<TK> { users };
            //        ListViewAccounts.DataBind();
            //    }
            //    else
            //    {
            //        // Tài khoản không tồn tại, có thể hiển thị thông báo lỗi hoặc thực hiện hành động phù hợp
            //        Response.Redirect("Sign.aspx");
            //    }
            //}
            //else
            //{
            //    // Nếu session không chứa thông tin tên tài khoản, chuyển hướng người dùng đến trang đăng nhập
            //    //Response.Redirect("Sign.aspx");
            //}

            var activeAccounts = dbcontext.KhachHangs.Where(p => p.TrangThai == true && p.Email == Sign.email).ToList();
            ListViewAccounts.DataSource = activeAccounts;

            ListViewAccounts.DataBind();
            //var activeClient = dbcontext.KhachHangs.Where(p => p.TrangThai == true).ToList();

            //ListViewClient.DataSource = activeClient;
            //ListViewClient.DataBind();

            //// Lấy giá trị từ các TextBox
            //string hoTen = txtHoTen.Text;
            //string gioiTinh = txtGioiTinh.Text;
            //string diaChi = txtDiaChi.Text;
            //string soDienThoai = TextPhone.Text;

            //// Thêm logic lưu dữ liệu vào cơ sở dữ liệu ở đây

            //// Sau khi lưu, cập nhật lại giá trị của các TextBox thành các giá trị đã nhập
            //txtHoTen.Attributes["value"] = hoTen;
            //txtGioiTinh.Attributes["value"] = gioiTinh;
            //txtDiaChi.Attributes["value"] = diaChi;
            //TextPhone.Attributes["value"] = soDienThoai;
            //        if (IsPostBack)
            //{
            //    string name = txtHoTen.Text;
            //            string gt = txtGioiTinh.Text;
            //    string dc = txtDiaChi.Text;
            //            string phone = TextPhone.Text;

            //            // Validate the input here

            //            using (var dbcontext = new QL_KPOPStoreEntities())
            //            {
            //                // Assuming you have a DbContext named dbContext and a model named User
            //                var kh = new KhachHang
            //                {
            //                    HoTen = name,
            //                    GioiTinh = gt,
            //                    DiaChi = dc,

            //                };

            //                dbcontext.KhachHangs.Add(kh);
            //            }
            //}

        }
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Lấy giá trị từ QueryString
        //        string kh = Request.QueryString["kh"];

        //        if (!string.IsNullOrEmpty(kh))
        //        {
        //            KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == kh);

        //            if (khachHang != null)
        //            {
        //                // Lấy giá trị từ các TextBox
        //                string hoTen = txtHoTen.Text;
        //                string gioiTinh = txtGioiTinh.Text;
        //                string diaChi = txtDiaChi.Text;
        //                string soDienThoai = TextPhone.Text;

        //                // Thực hiện cập nhật dữ liệu vào đối tượng khachHang
        //                khachHang.HoTen = hoTen;
        //                khachHang.GioiTinh = gioiTinh;
        //                khachHang.DiaChi = diaChi;

        //                // Kiểm tra xem số điện thoại có hợp lệ không trước khi gán
        //                int soDienThoaiValue;
        //                if (int.TryParse(soDienThoai, out soDienThoaiValue))
        //                {
        //                    khachHang.DienThoai = soDienThoaiValue;
        //                }
        //                else
        //                {
        //                    // Xử lý trường hợp số điện thoại không hợp lệ
        //                    // Ví dụ: Hiển thị thông báo lỗi cho người dùng
        //                    throw new Exception("Số điện thoại không hợp lệ.");
        //                }

        //                // Lưu thay đổi vào cơ sở dữ liệu
        //                dbcontext.SaveChanges();

        //                // Sau khi lưu, cập nhật lại giá trị của các TextBox
        //                txtHoTen.Text = khachHang.HoTen;
        //                txtGioiTinh.Text = khachHang.GioiTinh;
        //                txtDiaChi.Text = khachHang.DiaChi;
        //                TextPhone.Text = khachHang.DienThoai.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý ngoại lệ
        //        // Ví dụ: Ghi log, hiển thị thông báo lỗi cho người dùng, v.v.
        //        // Ở đây, chúng ta có thể ghi log để ghi lại lỗi
        //        // và hiển thị một thông báo lỗi cho người dùng
        //        // Hoặc thực hiện các hành động phù hợp với ứng dụng của bạn.
        //        // Ví dụ: lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Your existing code to save changes
                dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or display the error message
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadProfilePic.HasFile)
            {
                string uploadFolderPath = Server.MapPath("Content/account-img/");
                string fileName = Path.GetFileName(FileUploadProfilePic.FileName);
                string fileExtension = Path.GetExtension(FileUploadProfilePic.FileName);

                string filePath = Path.Combine(uploadFolderPath, fileName);

                // Lấy đường dẫn từ "Content" trở đi
                string relativePath = filePath.Substring(filePath.IndexOf("Content"));

                var tk = dbcontext.TKs.Where(p => p.Email == Sign.email).FirstOrDefault();
                var khachhang = dbcontext.KhachHangs.Where(s => s.Email == Sign.email).FirstOrDefault();
                if (tk != null)
                {
                    // Cập nhật thuộc tính AvatarUser và lưu thay đổi vào cơ sở dữ liệu
                    khachhang.AvatarUser = relativePath;
                    dbcontext.SaveChanges();

                    FileUploadProfilePic.SaveAs(filePath);
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy đối tượng tk
                    System.Diagnostics.Debug.WriteLine("User not found.");
                }
            }
            else
            {
                // In ra thông báo khi không có tệp nào được tải lên
                System.Diagnostics.Debug.WriteLine("No file uploaded.");
            }
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    // Lấy giá trị từ QueryString
        //    string kh = Request.QueryString["kh"];

        //    if (!string.IsNullOrEmpty(kh))
        //    {
        //        KhachHang khachHang = dbcontext.KhachHangs.FirstOrDefault(p => p.MaKH == kh);

        //        if (khachHang != null)
        //        {
        //            // Lấy giá trị từ các TextBox
        //            string hoTen = txtHoTen.Text;
        //            string gioiTinh = txtGioiTinh.Text;
        //            string diaChi = txtDiaChi.Text;
        //            string soDienThoai = TextPhone.Text;

        //            // Thực hiện cập nhật dữ liệu vào đối tượng khachHang
        //            khachHang.HoTen = hoTen;
        //            khachHang.GioiTinh = gioiTinh;
        //            khachHang.DiaChi = diaChi;
        //            int soDienThoaiValue;
        //            if (int.TryParse(soDienThoai, out soDienThoaiValue))
        //            {
        //                // Gán giá trị số điện thoại vào thuộc tính
        //                khachHang.DienThoai = soDienThoaiValue;
        //            }
        //            // Lưu thay đổi vào cơ sở dữ liệu
        //            dbcontext.SaveChanges();

        //            // Sau khi lưu, cập nhật lại giá trị của các TextBox
        //            txtHoTen.Text = khachHang.HoTen;
        //            txtGioiTinh.Text = khachHang.GioiTinh;
        //            txtDiaChi.Text = khachHang.DiaChi;
        //            TextPhone.Text = khachHang.DienThoai.ToString();
        //        }
        //    }
        //}

        protected void btnCPass_Click(object sender, EventArgs e)
        {
            var user = from u in dbcontext.TKs
                       select u;
            var tk = user.SingleOrDefault(p => p.Email == Sign.email);

            Response.Redirect("ChangePassword.aspx?Deptid=" + tk.Email);
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            var user = from u in dbcontext.TKs
                       select u;

            using (var dbContext = new QL_KPOPStoreEntities())
            {
                var disabledTKs = dbContext.TKs.FirstOrDefault(p => p.TrangThai == true && p.Email == Sign.email);

                var disabledKhs = dbContext.KhachHangs.FirstOrDefault(p => p.TrangThai == true && p.Email == Sign.email);
                var Tks = dbContext.TKs.Any(p => p.TrangThai == true && p.Email == Sign.email);


                var Khs = dbContext.KhachHangs.Any(p => p.TrangThai == true && p.Email == Sign.email);

                if (Tks)
                {
                    
                    disabledTKs.TrangThai = false;
                    
                    disabledKhs.TrangThai = false;
                } 
                else
                {

                }
                //var disabledKHs = dbContext.KhachHangs.Where(p => p.TrangThai == true).ToList();
                //foreach (var kh in disabledKHs)
                //{
                //    kh.TrangThai = false;
                //}


                // Lưu thay đổi vào cơ sở dữ liệu
                dbContext.SaveChanges();
                dbcontext.SaveChanges();
            }
            if (Request.Cookies["UserAccount"] != null)
            {

                Response.Cookies.Clear();
            }
            if (Request.Cookies["UserAccount"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserAccount");
                cookie.Expires = DateTime.Now.AddMonths(-1); // Đặt thời hạn về một ngày trong quá khứ
                Response.Cookies.Add(cookie);
            }
            //Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác');</script>");
            Session.Remove("Password");
            Session.Remove("Email");
            Sign.email = null;
            Sign.pass = null;
            Session.Remove("TenTaiKhoan");
            Session.Remove("MatKhau");
            Session.Remove("User");
            Session.Remove("Password");
            Session.Remove("Email");
            //Session["MaKH"] = "";
            Session.Remove("MaKH");
            //Session.Clear();
            Response.Redirect("Sign.aspx");

        }


        protected void btnControl_Click(object sender, EventArgs e)
        {

            Response.Redirect("Manager.aspx");
        }
        protected void btnAccOrder_Click(object sender, EventArgs e)
        {


            Response.Redirect("AccountOrder.aspx?Deptid=" + maK);
        }
    }
}