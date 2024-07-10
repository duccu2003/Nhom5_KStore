using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH03_WebBanHang.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web.UI;
using System.Data.Entity;
using System.Globalization;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using TH03_WebBanHang.Controllers;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Net.Http;


namespace TH03_WebBanHang.Controllers
{

    //public class QLkop : DbContext
    //{
    //    public QLkop() : base("name=QL_KPOPStoreBOT")
    //    {
    //    }

    //    public DbSet<ChatBot> ChatBot { get; set; }

    //    // Định nghĩa DbSet cho các bảng khác theo nhu cầu
    //}
    //public class ChatBot
    //{   [Key]
    //    public string BotChat { get; set; }
        
    //    public string ClientChat { get; set; }
    //    // Các thuộc tính khác...
    //}

    public class ChatBotController : Controller
    {
        private QL_KPOPStoreEntities db = new QL_KPOPStoreEntities();
        
        // GET: ChatBot
        public ActionResult Index()
        {
            return View();
        }
        static string RemoveAccents(string text)
        {
            if (text == null || string.IsNullOrWhiteSpace(text))
            {
                return ""; // Trả về chuỗi rỗng nếu text là null hoặc whitespace
            }

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public ActionResult ChatBot(string chat)
        {
            HttpCookie Email = Request.Cookies["Email"];
            string EmailKhach;
            if (Email == null) EmailKhach = Sign.email;
            else EmailKhach = Email.Value;
            chat = Request.QueryString["chat"];


            // Kiểm tra xem có dữ liệu trong db.SanPhams hay không
            string imgSP = null;
            string linkTo = null;
            var group = db.Nhoms.Any(s => (chat.Contains(s.TenNhom) || s.TenNhom.Contains(chat)));
            var mess = db.SanPhams.Any(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);



            string noAccentString = RemoveAccents(chat);
            string lowerCaseNoAccentString = noAccentString.ToLower();
            string text = lowerCaseNoAccentString.Trim();
            string pattern = @"[\p{P}\s]";

            // Thay thế tất cả các dấu câu bằng chuỗi rỗng
            string textChat = Regex.Replace(text, pattern, "");

            // Kiểm tra xem message có giá trị hay không trước khi chuyển đổi sang JSON
            if ((mess ||  group) &&(textChat.Contains("conko") || textChat.Contains("conkhong") || textChat.Contains("cokhong")) || (textChat.Contains("sanpham") || textChat.Contains("sp") && textChat.Contains("mon") || textChat.Contains("mathang") || textChat.Contains("hang")) || (chat.Contains("sanpham") || chat.Contains("sp") && chat.Contains("mon") || chat.Contains("mathang") || chat.Contains("hang")) ||
                    (textChat == "wiki" || textChat.Contains("wiki") || textChat == "timhieu" || textChat.Contains("timhieu") || textChat.Contains("thongtin") || textChat.Contains("profile") || textChat.Contains("timkiemve") || textChat.Contains("thongtin") || textChat.Contains("profile")))
            {
                var message = db.SanPhams.FirstOrDefault(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);
                var gp = db.Nhoms.FirstOrDefault(s => (s.MaNhom == chat || s.MaNhom.Contains(chat) || chat.Contains(s.MaNhom) || chat.Contains(s.TenNhom) || s.TenNhom.Contains(chat)));

                if (group && mess)
                {

                    linkTo = "item?gp=" + gp + "&sp=" + message.MaSP;
                    imgSP = message.DuongDan;
                    return new JsonResult
                    {
                        Data = new { message = "Sản phẩm " + message.TenSP + " của nhóm " + gp.TenNhom + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                // Sử dụng JsonResult với JsonRequestBehavior.AllowGet để cho phép trả về dữ liệu từ yêu cầu GET
                else if (group && !mess && (textChat.Contains("sanpham") || textChat.Contains("sp") && textChat.Contains("mon") || textChat.Contains("mathang") || textChat.Contains("hang")) || (chat.Contains("sanpham") || chat.Contains("sp") && chat.Contains("mon") || chat.Contains("mathang") || chat.Contains("hang")) ||
                    (textChat == "wiki" || textChat.Contains("wiki") || textChat == "timhieu" || textChat.Contains("timhieu") || textChat.Contains("thongtin") || textChat.Contains("profile") || textChat.Contains("timkiemve") || textChat.Contains("thongtin") || textChat.Contains("profile")))
                       
                {
                    if (textChat == "wiki"
                        //|| "wiki".Contains(chat)
                        || textChat.Contains("wiki")                        
                        //|| "wiki".Contains(textChat)
                        //|| "wiki" == textChat
                        //|| "wiki" == chat

                        || textChat == "timhieu"
                        //|| "timhieu".Contains(chat)
                        || textChat.Contains("timhieu")
                        //|| "timhieu".Contains(textChat)
                        //|| "timhieu" == textChat
                        //|| "timhieu" == chat

                        //|| "thongtin" == textChat
                        //|| "thongtin".Contains(chat)
                        || textChat.Contains("thongtin")
                        //|| "thongtin".Contains(textChat)
                        //|| "thongtin" == textChat
                        //|| "thongtin" == chat


                        //|| "profile" == chat
                        //|| "profile".Contains(chat)
                        || textChat.Contains("profile")
                        //|| "profile".Contains(textChat)
                        //|| "profile" == textChat
                        //|| "profile" == chat

                        //|| "timkiemve".Contains(textChat)
                        //|| "timkiemve".Contains(chat)
                        || textChat.Contains("timkiemve")
                        //|| "timkiemve".Contains(textChat)
                        //|| "timkiemve" == textChat
                        //|| "timkiemve" == chat

                        //|| "thongtin" == chat
                        //|| "thongtin".Contains(chat)
                        || textChat.Contains("thongtin")
                        //|| "thongtin".Contains(textChat)
                        //|| "thongtin" == textChat
                        //|| "thongtin" == chat

                        //|| "profile".Contains(chat)
                        //|| "profile".Contains(chat)
                        || textChat.Contains("profile")
                        //|| "profile".Contains(textChat)
                        //|| "profile" == textChat
                        //|| "profile" == chat

                        )
                    {
                        if (gp != null)
                        {
                            imgSP = gp.AnhNhom;
                            linkTo = "https://vi.wikipedia.org/w/index.php?search=" + gp.TenNhom;
                            return new JsonResult
                            {
                                Data = new { message = "Dưới đây là thông tin của " + gp.TenNhom + " trên trang wikipedia.", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        else
                        {
                            imgSP = null;
                            linkTo = null;
                            return new JsonResult
                            {
                                Data = new { message = "Không tìm thấy nhóm/nghệ sĩ " + gp.TenNhom + " đang có trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                    }
                    else
                    {
                        if (gp != null)
                        {
                            imgSP = gp.AnhNhom;
                            linkTo = "item?gp=" + gp.MaNhom;
                            return new JsonResult
                            {
                                Data = new { message = "Dưới đây là những sản phẩm của " + gp.TenNhom + " đang có trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        else
                        {
                            imgSP = null;
                            linkTo = null;
                            return new JsonResult
                            {
                                Data = new { message = "Không tìm thấy nhóm/nghệ sĩ " + gp.TenNhom + " đang có trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        
                    }
                    
                }
                else if(!group && mess)
                {   linkTo = "item?sp=" + message.MaSP;
                    imgSP = message.DuongDan;
                    return new JsonResult
                    {
                        Data = new { message = "Sản phẩm " + message.TenSP + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                
                else
                {
                    linkTo = null;
                    imgSP = null;
                    return new JsonResult
                    {
                        Data = new { message = "Sản phẩm không có trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }


            }
            else if(textChat.Contains("sanpham") || textChat.Contains("sp") && textChat.Contains("mon") || textChat.Contains("mathang") || textChat.Contains("hang") || chat.Contains("sanpham") || chat.Contains("sp") && chat.Contains("mon") || chat.Contains("mathang") || chat.Contains("hang"))
            {
                if((textChat.Contains("moi") || textChat.Contains("new")|| (chat.Contains("moi") || chat.Contains("new")))){
                    var message = db.SanPhams.OrderBy(s=>s.NgayNhap).FirstOrDefault(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);

                    if (message != null)
                    {
                        linkTo = "item?sp=" + message.MaSP;
                        imgSP = message.DuongDan;
                        return new JsonResult
                        {
                            Data = new { message = "Sản phẩm " + message.TenSP + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        linkTo = null;
                        imgSP = null;
                        return new JsonResult
                        {
                            Data = new { message = "Chưa có sản phẩm mới trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }
                if ((textChat.Contains("hot") || textChat.Contains("noibat") || textChat.Contains("noi") || chat.Contains("hot") || chat.Contains("noibat") || chat.Contains("noi"))){
                    var message = db.SanPhams.OrderBy(s => s.DoanhSo.Value).FirstOrDefault(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);
                    if (message != null)
                    {
                        linkTo = "item?sp=" + message.MaSP;
                        imgSP = message.DuongDan;
                        return new JsonResult
                        {
                            Data = new { message = "Sản phẩm " + message.TenSP + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        linkTo = null;
                        imgSP = null;
                        return new JsonResult
                        {
                            Data = new { message = "Chưa có sản phẩm nào nổi bật.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    
                }
                if ((textChat.Contains("danhgiacao") || textChat.Contains("danhgia")  || chat.Contains("danhgiacao") || chat.Contains("danhgia")))
                {
                    var message = db.SanPhams.OrderBy(s => s.DanhGias.Count).FirstOrDefault(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);

                    if (message != null)
                    {
                        linkTo = "item?sp=" + message.MaSP;
                        imgSP = message.DuongDan;
                        return new JsonResult
                        {
                            Data = new { message = "Sản phẩm " + message.TenSP + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        linkTo = null;
                        imgSP = null;
                        return new JsonResult
                        {
                            Data = new { message = "Chưa có sản phẩm nào được đánh giá cao.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }
                if ((textChat.Contains("yeuthich") || textChat.Contains("thich") || (textChat.Contains("yeuthik") || textChat.Contains("thik") || chat.Contains("yeuthich") || chat.Contains("yeuthik") || chat.Contains("thich") || chat.Contains("thik")))){
                    var message = db.SanPhams.OrderBy(s => s.ThichSPs.Count).FirstOrDefault(s => (s.MaSP == chat || s.MaSP.Contains(chat) || chat.Contains(s.MaSP) || chat.Contains(s.TenSP) || s.TenSP.Contains(chat)) && s.SoLuongKho > 0);

                    if (message != null)
                    {
                        linkTo = "item?sp=" + message.MaSP;
                        imgSP = message.DuongDan;
                        return new JsonResult
                        {
                            Data = new { message = "Sản phẩm " + message.TenSP + " vẫn đang còn hàng.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        linkTo = null;
                        imgSP = null;
                        return new JsonResult
                        {
                            Data = new { message = "Chưa có sản phẩm nào được yêu thích.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }
                linkTo = null;
                imgSP = null;
                return new JsonResult
                {
                    Data = new { message = "Sản phẩm không có trong cửa hàng.", imgsrc = imgSP, alink = linkTo },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };


            }
            else
            {

                        //string file = @"Default.aspx";
                        //string Type = "application/aspx";

                        //return File(file, Type, Path.GetFileName(file));
                        //return Redirect("default");
                if (!string.IsNullOrEmpty(chat))
                {
                    
                    ////return new JsonResult
                    ////{
                    ////    Data = new { message = "Chào bạn" },
                    ////    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    ////};
                    //return new JsonResult
                    //{
                    //    Data = new { message = "Chào bạn tôi là KS Bot tôi có thể giúp gì cho bạn", imgsrc = imgSP, alink = linkTo },
                    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //};

                    //using (var dbbot = new QLkop())
                    //        {

                    //            string noAccentString = RemoveAccents(chat);
                    //            string lowerCaseNoAccentString = noAccentString.ToLower();
                    //            string textChat = lowerCaseNoAccentString.Trim();

                    //                // Kiểm tra xem có bất kỳ bản ghi nào thỏa mãn điều kiện nào đó hay không
                    //            var hasMatch = dbbot.ChatBot.Any(s => chat== s.ClientChat || chat.ToLower().Trim() == s.ClientChat || textChat == s.ClientChat || s.ClientChat==chat || s.ClientChat==chat.ToLower().Trim() || s.ClientChat == textChat|| s.ClientChat.Contains(chat.ToLower().Trim()) || chat.ToLower().Trim().Contains(s.ClientChat) 
                    //                || s.ClientChat.Contains(chat) || chat.Contains(s.ClientChat) || s.ClientChat.Contains(textChat) 
                    //                || textChat.Contains(s.ClientChat));

                    //            if (hasMatch)
                    //            {
                    //                    // Lấy bản ghi đầu tiên thỏa mãn điều kiện
                    //                var client = dbbot.ChatBot.FirstOrDefault(s => chat == s.ClientChat || chat.ToLower().Trim() == s.ClientChat || textChat == s.ClientChat || s.ClientChat == chat || s.ClientChat == chat.ToLower().Trim() || s.ClientChat == textChat || s.ClientChat.Contains(chat.ToLower().Trim()) || chat.ToLower().Trim().Contains(s.ClientChat)
                    //                || s.ClientChat.Contains(chat) || chat.Contains(s.ClientChat) || s.ClientChat.Contains(textChat)
                    //                || textChat.Contains(s.ClientChat));

                    //                if (client != null)
                    //                {
                    //                    return new JsonResult
                    //                    {
                    //                        Data = new { message = client.BotChat, imgsrc = imgSP, alink = linkTo }, // Cập nhật thông tin cần thiết
                    //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //                    };
                    //                }
                    //                else
                    //                {
                    //                                // Xử lý trường hợp không tìm thấy bản ghi cụ thể
                    //                    return new JsonResult
                    //                    {
                    //                        Data = new { message = "Không tìm thấy thông tin.", imgsrc = imgSP, alink = linkTo },
                    //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //                    };
                    //                }
                    //            }
                    //            else
                    //            {
                    //                var client = dbbot.ChatBot.FirstOrDefault();
                    //                // Xử lý trường hợp không tìm thấy bản ghi nào thỏa mãn
                    //                return new JsonResult
                    //                {
                    //                    Data = new { message = client.BotChat, imgsrc = imgSP, alink = linkTo },
                    //                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //                };
                    //            }

                    //    }

                    var hadDon = db.DonHangs.Any(s => s.MaDH == textChat || s.MaDH == chat 
                    || s.MaDH.ToLower().Trim()==textChat||s.MaDH.ToLower().Trim().Contains(textChat)
                    || s.MaDH.Contains(textChat) || s.MaDH.ToLower().Trim() == chat || s.MaDH.ToLower().Trim().Contains(chat)
                    || s.MaDH.Contains(chat)|| textChat.Contains(s.MaDH) || textChat.Contains(s.MaDH.ToLower().Trim()));
                    if (textChat == "010?1" || "010?1"== textChat || "010?1" == chat
                    || "010?1".ToLower().Trim() == textChat || "010?1".ToLower().Trim().Contains(textChat)
                    || "010?1".Contains(textChat) || "010?1".ToLower().Trim() == chat || "010?1".ToLower().Trim().Contains(chat)
                    || "010?1".Contains(chat) || textChat.Contains("010?1") || textChat.Contains("010?1".ToLower().Trim()))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Bí mật không được bật mí. 🤐", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else if (textChat == "kslagi" || textChat == "kstorelagi"
                        || textChat == "kslagi" || "kslagi" == textChat || "kslagi" == chat
                    || "kslagi".ToLower().Trim() == textChat || "kslagi".ToLower().Trim().Contains(textChat)
                    || "kslagi".Contains(textChat) || "kslagi".ToLower().Trim() == chat || "kslagi".ToLower().Trim().Contains(chat)
                    || "kslagi".Contains(chat) || textChat.Contains("kslagi") || textChat.Contains("kslagi".ToLower().Trim())
                    || textChat == "kstorelagi" || "kstorelagi" == textChat || "kstorelagi" == chat
                    || "kstorelagi".ToLower().Trim() == textChat || "kstorelagi".ToLower().Trim().Contains(textChat)
                    || "kstorelagi".Contains(textChat) || "kstorelagi".ToLower().Trim() == chat || "kstorelagi".ToLower().Trim().Contains(chat)
                    || "kstorelagi".Contains(chat) || textChat.Contains("kstorelagi") || textChat.Contains("kstorelagi".ToLower().Trim()))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "KStore là cửa hàng KPOP chuyên cung cấp những album nội dung liên quan đến Kpop mang đam mê đu idol đến với mọi người.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    
                    else if (hadDon)
                    {
                        var Don = db.DonHangs.FirstOrDefault(s => s.KhachHang.Email == EmailKhach && s.KhachHang.TrangThai==true && (s.MaDH == textChat || s.MaDH == chat
                        || s.MaDH.ToLower().Trim() == textChat || s.MaDH.ToLower().Trim().Contains(textChat)
                        || s.MaDH.Contains(textChat) || s.MaDH.ToLower().Trim() == chat || s.MaDH.ToLower().Trim().Contains(chat)
                        || s.MaDH.Contains(chat) || textChat.Contains(s.MaDH) || textChat.Contains(s.MaDH.ToLower().Trim())));
                        if (Don != null)
                        {
                            linkTo = "DetailOrder?MaDH=" + Don.MaDH;
                            return new JsonResult
                            {
                                Data = new { message = "Bạn có thể xem đơn hàng trong phần tài khoản hoặc link dười đây.", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        else
                        {
                            linkTo = null;
                            return new JsonResult
                            {
                                Data = new { message = "Xin lỗi tôi không hiểu rõ ý muộn của bạn, bạn có thể nói lại lần nữa không? 🥺", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                        }
                        
                        
                    }
                    //else if (textChat == "xoachat" || textChat == "xoahet"
                    //    || textChat == "xoadoanchat" || "xoahetdonchat" == textChat || textChat == "clearchat"
                    //    || textChat == "clearhetchat" || textChat == "xoabaichat"
                    //    || textChat.Contains("xoachat") || textChat.Contains("xoahet")
                    //    || textChat.Contains("xoadoanchat") || textChat.Contains("xoahetdonchat") || textChat.Contains("clearchat")
                    //    || textChat.Contains("clearhetchat") || textChat.Contains("xoabaichat")
                    //    || chat == "xoachat" || chat == "xoahet"
                    //    || chat == "xoadoanchat" || chat == "xoahetdonchat"  || chat == "clearchat"
                    //    || chat == "clearhetchat" || chat == "xoabaichat"
                    //    || chat.Contains("xoachat") || chat.Contains("xoahet")
                    //    || chat.Contains("xoadoanchat") || chat.Contains("xoahetdonchat") || chat.Contains("clearchat")
                    //    || chat.Contains("clearhetchat") || chat.Contains("xoabaichat")
                    //)
                    //{
                    //    //return new JsonResult
                    //    //{
                    //    //    Data = new { message = "clearthechattrue", imgsrc = imgSP, alink = linkTo },
                    //    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //    //};
                    //    return JavaScript("while (chatMessages.firstChild) {\r\n                    chatMessages.removeChild(chatMessages.firstChild);\r\n                }\r\n\r\n                // Xóa dữ liệu trong localStorage\r\n                localStorage.removeItem('chatMessages');\r\n\r\n                // Reset scroll position\r\n                chatMessages.scrollTop = 0;");
                    //}

                    else if (textChat == "donhangcuatoidau" || textChat == "donhang"
                    || textChat == "doncuatoi" 
                    || textChat == "donhangcuatoidau" || "donhangcuatoidau" == textChat || "donhangcuatoidau" == chat
                    || "donhangcuatoidau".ToLower().Trim() == textChat || "donhangcuatoidau".ToLower().Trim().Contains(textChat)
                    || "donhangcuatoidau".Contains(textChat) || "donhangcuatoidau".ToLower().Trim() == chat || "donhangcuatoidau".ToLower().Trim().Contains(chat)
                    || "donhangcuatoidau".Contains(chat) || textChat.Contains("donhangcuatoidau") || textChat.Contains("donhangcuatoidau".ToLower().Trim())
                    || textChat == "donhang" || "donhang" == textChat || "donhang" == chat
                    || "donhang".ToLower().Trim() == textChat || "donhang".ToLower().Trim().Contains(textChat)
                    || "donhang".Contains(textChat) || "donhang".ToLower().Trim() == chat || "donhang".ToLower().Trim().Contains(chat)
                    || "donhang".Contains(chat) || textChat.Contains("donhang") || textChat.Contains("donhang".ToLower().Trim())
                    || textChat == "doncuatoi" || "doncuatoi" == textChat || "doncuatoi" == chat
                    || "doncuatoi".ToLower().Trim() == textChat || "doncuatoi".ToLower().Trim().Contains(textChat)
                    || "doncuatoi".Contains(textChat) || "doncuatoi".ToLower().Trim() == chat || "doncuatoi".ToLower().Trim().Contains(chat)
                    || "doncuatoi".Contains(chat) || textChat.Contains("doncuatoi") || textChat.Contains("doncuatoi".ToLower().Trim()))
                    {
                        linkTo = "Account";
                        return new JsonResult
                        {
                            Data = new { message = "Bạn có thể xem đơn hàng trong phần tài khoản hoặc link dười đây.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else if (textChat == "hinhthucthanhtoan" || textChat == "thanhtoan"
                        || textChat == "hinhthuctoan" || textChat == "thantoan"
                        || textChat == "hinhthucthanhtoan" || "hinhthucthanhtoan" == textChat || "hinhthucthanhtoan" == chat
                        || "hinhthucthanhtoan".ToLower().Trim() == textChat || "hinhthucthanhtoan".ToLower().Trim().Contains(textChat)
                        || "hinhthucthanhtoan".Contains(textChat) || "hinhthucthanhtoan".ToLower().Trim() == chat || "hinhthucthanhtoan".ToLower().Trim().Contains(chat)
                        || "hinhthucthanhtoan".Contains(chat) || textChat.Contains("hinhthucthanhtoan") || textChat.Contains("hinhthucthanhtoan".ToLower().Trim())
                        || textChat == "thanhtoan" || "thanhtoan" == textChat || "thanhtoan" == chat
                        || "thanhtoan".ToLower().Trim() == textChat || "thanhtoan".ToLower().Trim().Contains(textChat)
                        || "thanhtoan".Contains(textChat) || "thanhtoan".ToLower().Trim() == chat || "thanhtoan".ToLower().Trim().Contains(chat)
                        || "thanhtoan".Contains(chat) || textChat.Contains("thanhtoan") || textChat.Contains("thanhtoan".ToLower().Trim())
                        || textChat == "hinhthuctoan" || "hinhthuctoan" == textChat || "hinhthuctoan" == chat
                        || "hinhthuctoan".ToLower().Trim() == textChat || "hinhthuctoan".ToLower().Trim().Contains(textChat)
                        || "hinhthuctoan".Contains(textChat) || "hinhthuctoan".ToLower().Trim() == chat || "hinhthuctoan".ToLower().Trim().Contains(chat)
                        || "hinhthuctoan".Contains(chat) || textChat.Contains("hinhthuctoan") || textChat.Contains("hinhthuctoan".ToLower().Trim())
                        || textChat == "thantoan" || "thantoan" == textChat || "thantoan" == chat
                        || "thantoan".ToLower().Trim() == textChat || "thantoan".ToLower().Trim().Contains(textChat)
                        || "thantoan".Contains(textChat) || "thantoan".ToLower().Trim() == chat || "thantoan".ToLower().Trim().Contains(chat)
                        || "thantoan".Contains(chat) || textChat.Contains("thantoan") || textChat.Contains("thantoan".ToLower().Trim()))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Chúng tôi hiện tại đang nhận 2 hinh thức thanh toán là chuyển khoản và cod.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else if (textChat == "coloi" || textChat == "covande"
                        || textChat == "vande" || textChat == "covade"
                        || textChat == "cokoi"|| textChat.Contains("coloi") || textChat.Contains("covande")
                        || textChat.Contains("vande") || textChat.Contains("covade")
                        || textChat.Contains("cokoi")
                        || chat == "coloi" || chat == "covande"
                        || chat == "vande" || chat == "covade"
                        || chat == "cokoi" || chat.Contains("coloi") || chat.Contains("covande")
                        || chat.Contains("vande") || chat.Contains("covade")
                        || chat.Contains("cokoi"))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Bạn đang gặp vấn đề gì hôm nay?", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    //else if (textChat == "maygio" || textChat == "baygio"
                    //    || textChat == "thoigian" || textChat == "gio"
                    //    || textChat == "dongho" 
                    //    || textChat.Contains("maygio") || textChat.Contains("baygio")
                    //    || textChat.Contains("thoigian") || textChat.Contains("gio")
                    //    || textChat.Contains("dongho")
                    //    || chat == "maygio" || chat == "baygio"
                    //    || chat == "thoigian" || chat == "gio"
                    //    || chat == "dongho"
                    //    || chat.Contains("maygio") || chat.Contains("baygio")
                    //    || chat.Contains("thoigian") || chat.Contains("gio")
                    //    || chat.Contains("dongho"))
                    //{
                    //    return new JsonResult
                    //    {
                    //        Data = new { message = "Bây giờ là " + DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " phút " + DateTime.Now.Second + " giây.", imgsrc = imgSP, alink = linkTo },
                    //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //    };
                    //}
                    //else if (textChat == "homnayla" || textChat == "nayla"
                    //    || textChat == "homnay" || textChat == "ngay"
                    //    || textChat == "langay" || textChat == "homnaylangay"
                    //    || textChat.Contains("homnayla") || textChat.Contains("nayla")
                    //    || textChat.Contains("homnay") || textChat.Contains("ngay")
                    //    || textChat.Contains("langay") || textChat.Contains("homnaylangay")
                    //    || chat == "homnayla" || chat == "nayla"
                    //    || chat == "homnay" || chat == "ngay"
                    //    || chat == "langay" || chat == "homnaylangay"
                    //    || chat.Contains("homnayla") || chat.Contains("nayla")
                    //    || chat.Contains("homnay") || chat.Contains("ngay")
                    //    || chat.Contains("langay") || chat.Contains("homnaylangay"))
                    //{
                    //    return new JsonResult
                    //    {
                    //        Data = new { message = "Hôm nay là ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + ".", imgsrc = imgSP, alink = linkTo },
                    //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //    };
                    //}
                    else if (textChat == "cuahangmocuamaygio" || textChat == "giomocua"
                        || textChat == "mocua" || textChat == "cuahangmo"
                        || textChat == "mocya"
                        || textChat.Contains("cuahangmocuamaygio") || textChat.Contains("giomocua")
                        || textChat.Contains("mocua") || textChat.Contains("cuahangmo")
                        || textChat.Contains("mocya")
                        || chat == "cuahangmocuamaygio" || chat == "giomocua"
                        || chat == "mocua" || chat == "cuahangmo"
                        || chat == "mocya"
                        || chat.Contains("cuahangmocuamaygio") || chat.Contains("giomocua")
                        || chat.Contains("mocua") || chat.Contains("cuahangmo")
                        || chat.Contains("mocya"))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Cửa hàng mở cửa từ 8 giờ đến 18 giờ từ Thứ 2 đến Thứ 6 hàng tuần.", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else if (textChat == "xinchao" || textChat=="xunchao"
                        || textChat == "xenchao" || textChat == "xichao"
                        || textChat == "xincheo" || textChat == "xincha"
                        || textChat == "xinacho" || textChat == "xinchaof"
                        || textChat == "xinfchai"
                        || textChat.Contains("xinchao") || textChat.Contains("xunchao")
                        || textChat.Contains("xenchao") || textChat.Contains("xichao")
                        || textChat.Contains("xincheo") || textChat.Contains("xincha")
                        || textChat.Contains("xinacho") || textChat.Contains("xinchaof")
                        || textChat.Contains("xinfchai")
                        || chat == "xinchao" || chat == "xunchao"
                        || chat == "xenchao" || chat == "xichao"
                        || chat == "xincheo" || chat == "xincha"
                        || chat == "xinacho" || chat == "xinchaof"
                        || chat == "xinfchai"
                        || chat.Contains("xinchao") || chat.Contains("xunchao")
                        || chat.Contains("xenchao") || chat.Contains("xichao")
                        || chat.Contains("xincheo") || chat.Contains("xincha")
                        || chat.Contains("xinacho") || chat.Contains("xinchaof")
                        || chat.Contains("xinfchai")
                        || textChat == "xchao" || textChat == "chao"
                        || textChat == "xcheo" || textChat == "cheo"
                        || textChat == "choo" 
                        || textChat.Contains("xchao") || textChat.Contains("chao")
                        || textChat.Contains("xcheo") || textChat.Contains("cheo")
                        || textChat.Contains("choo")
                        || chat == "xchao" || chat == "chao"
                        || chat == "xcheo" || chat == "cheo"
                        || chat == "choo" 
                        || chat.Contains("xchao") || chat.Contains("chao")
                        || chat.Contains("xcheo") || chat.Contains("cheo")
                        || chat.Contains("choo")                                               
                        || textChat == "hello" || textChat == "helo"                       
                        || textChat.Contains("hello") || textChat.Contains("helo")                        
                        || chat == "hello" || chat == "helo"
                        || chat.Contains("hello") || chat.Contains("helo"))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Xin chào bạn tôi là KS Bot, tôi có thể giúp gì cho bạn?", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }

                    else if (textChat == "bantengi" || textChat == "banteengif"
                        || textChat == "bantengif" || textChat == "tenban"
                        || textChat == "tenbanlagi" || textChat == "banlagi" 
                        || textChat == "tenbanla" || textChat == "banlagif" 
                        || textChat == "tenbanlagif" || textChat == "banla" 
                        || textChat =="banlaai" || textChat == "caulaai" 
                        || textChat == "caula" || textChat == "caulagif" 
                        || textChat == "caulagi" || textChat == "thongtincuacau" 
                        || textChat =="ưhoareu" || textChat == "yourname"
                        || textChat == "ưhoau" || textChat == "whoareu"
                        || textChat == "whoau" || textChat == "ưhaturname"
                        || textChat == "whaturname" || textChat == "ưhatyourname"
                        || textChat == "whatyourname" || textChat == "ưhatuname"
                        || textChat == "whatuname" || textChat == "uname"
                        || textChat == "urname" 
                        || textChat == "meylaai" || textChat == "meyla" 
                        || textChat == "laai" || textChat == "mlaai" 
                        || textChat == "mla" || textChat == "mylaai"
                        || textChat == "maylaai" || textChat == "mayla" 
                        || textChat.Contains("bantengi") || textChat.Contains("banteengif")
                        || textChat.Contains("bantengif") || textChat.Contains("tenban")
                        || textChat.Contains("tenbanlagi") || textChat.Contains("banlagi")
                        || textChat.Contains("tenbanla") || textChat.Contains("banlagif")
                        || textChat.Contains("tenbanlagif") || textChat.Contains("banla")
                        || textChat.Contains("banlaai") || textChat.Contains("caulaai")
                        || textChat.Contains("caula") || textChat.Contains("caulagif")
                        || textChat.Contains("caulagi") || textChat.Contains("thongtincuacau")
                        || textChat.Contains("ưhoareu") || textChat.Contains("yourname")
                        || textChat.Contains("ưhoau") || textChat.Contains("whoareu")
                        || textChat.Contains("whoau") || textChat.Contains("ưhaturname")
                        || textChat.Contains("whaturname") || textChat.Contains("ưhatyourname")
                        || textChat.Contains("whatyourname") || textChat.Contains("ưhatuname")
                        || textChat.Contains("whatuname") || textChat.Contains("uname")
                        || textChat.Contains("urname")
                        || textChat.Contains("meylaai") || textChat.Contains("meyla") 
                        || textChat.Contains("laai") || textChat.Contains("mlaai") 
                        || textChat.Contains("mla") || textChat.Contains("mylaai")
                        || textChat.Contains("maylaai") || textChat.Contains("mayla")
                        || chat == "bantengi" || chat == "banteengif"
                        || chat == "bantengif" || chat == "tenban"
                        || chat == "tenbanlagi" || chat == "banlagi"
                        || chat == "tenbanla" || chat == "banlagif"
                        || chat == "tenbanlagif" || chat == "banla"
                        || chat == "banlaai" || chat == "caulaai"
                        || chat == "caula" || chat == "caulagif"
                        || chat == "caulagi" || chat == "thongtincuacau"
                        || chat == "ưhoareu" || chat == "yourname"
                        || chat == "ưhoau" || chat == "whoareu"
                        || chat == "whoau" || chat == "ưhaturname"
                        || chat == "whaturname" || chat == "ưhatyourname"
                        || chat == "whatyourname" || chat == "ưhatuname"
                        || chat == "whatuname" || chat == "uname"
                        || chat == "urname"
                        || chat.Contains("bantengi") || chat.Contains("banteengif")
                        || chat.Contains("bantengif") || chat.Contains("tenban")
                        || chat.Contains("tenbanlagi") || chat.Contains("banlagi")
                        || chat.Contains("tenbanla") || chat.Contains("banlagif")
                        || chat.Contains("tenbanlagif") || chat.Contains("banla")
                        || chat.Contains("banlaai") || chat.Contains("caulaai")
                        || chat.Contains("caula") || chat.Contains("caulagif")
                        || chat.Contains("caulagi") || chat.Contains("thongtincuacau")
                        || chat.Contains("ưhoareu") || chat.Contains("yourname")
                        || chat.Contains("ưhoau") || chat.Contains("whoareu")
                        || chat.Contains("whoau") || chat.Contains("ưhaturname")
                        || chat.Contains("whaturname") || chat.Contains("ưhatyourname")
                        || chat.Contains("whatyourname") || chat.Contains("ưhatuname")
                        || chat.Contains("whatuname") || chat.Contains("uname")
                        || chat.Contains("urname")
                        || chat == "meylaai" || chat == "meyla"
                        || chat == "laai" || chat == "mlaai"
                        || chat == "mla" || chat == "mylaai"
                        || chat == "maylaai" || chat == "mayla"
                        || chat.Contains("meylaai") || chat.Contains("meyla")
                        || chat.Contains("laai") || chat.Contains("mlaai")
                        || chat.Contains("mla") || chat.Contains("mylaai")
                        || chat.Contains("maylaai") || chat.Contains("mayla"))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Tên tôi là KS Bot, tôi là một ChatBot thân thiện lun sẵn sàng giải đáp và hỗ trợ những thắc mắc và mong muốn của bạn. 🥰", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }

                    else if(textChat == "iloveyoiu" || textChat == "iloveyoyu"
                        || textChat == "iloveu" || textChat == "iloveyou"
                        || textChat == "ilikeu" || textChat == "ilove"
                        || textChat == "ilikeyoy" || textChat == "ilikeyou"
                        || textChat == "toiyeucau" || textChat == "taoyeumay"
                        || textChat == "toyeucau" || textChat == "toithichcau"
                        || textChat.Contains("iloveyoiu") || textChat.Contains("iloveyoyu")
                        || textChat.Contains("iloveu") || textChat.Contains("iloveyou")
                        || textChat.Contains("ilikeu") || textChat.Contains("ilove")
                        || textChat.Contains("ilikeyoy") || textChat.Contains("ilikeyou")
                        || textChat.Contains("toiyeucau") || textChat.Contains("taoyeumay")
                        || textChat.Contains("toyeucau") || textChat.Contains("toithichcau")
                        || chat == "iloveyoiu" || chat == "iloveyoyu"
                        || chat == "iloveu" || chat == "iloveyou"
                        || chat == "ilikeu" || chat == "ilove"
                        || chat == "ilikeyoy" || chat == "ilikeyou"
                        || chat == "toiyeucau" || chat == "taoyeumay"
                        || chat == "toyeucau" || chat == "toithichcau"
                        || chat.Contains("iloveyoiu") || chat.Contains("iloveyoyu")
                        || chat.Contains("iloveu") || chat.Contains("iloveyou")
                        || chat.Contains("ilikeu") || chat.Contains("ilove")
                        || chat.Contains("ilikeyoy") || chat.Contains("ilikeyou")
                        || chat.Contains("toiyeucau") || chat.Contains("taoyeumay")
                        || chat.Contains("toyeucau") || chat.Contains("toithichcau"))
                    {
                        return new JsonResult
                        {
                            Data = new { message = "Tôi cũng yêu bạn rất nhiều. 🥰❤️‍🔥", imgsrc = imgSP, alink = linkTo },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {

                        var searchParams = new
                        {
                            model = "gpt-3.5-turbo",
                            messages = new[] {
                                //new { role = "system", content = chat },
                                new { role = "user", content = chat }
                            },
                            //messages = new[] { chat },
                            //role = "user",
                            max_tokens = 1500,
                            temperature = 0.7
                        };

                        // Converting the object to a JSON string
                        string json = JsonConvert.SerializeObject(searchParams);

                        // Setup the body of the request
                        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                        //var url = "https://api.openai.com/v1/completions";
                        var url = "https://api.openai.com/v1/chat/completions";

                        var request = new HttpRequestMessage(HttpMethod.Post, url);

                        // Add the JSON content to the request
                        request.Content = data;

                        var client = new HttpClient();
                        
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API Key của ChatGPT năm ở đây");


                        try
                        {
                            // Send the HTTP request and get the response
                            HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();
                            response.EnsureSuccessStatusCode();
                            string result = null;
                            string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            var responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseBody);

                            if (responseObject != null && responseObject.Choices != null && responseObject.Choices.Length > 0)
                            {
                                result = responseObject.Choices[0].Message.ToString();
                                Console.WriteLine("Result: " + result);
                                return new JsonResult
                                {
                                    Data = new { message = result, imgsrc = imgSP, alink = linkTo },
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };
                            }
                            else
                            {
                                Console.WriteLine("No valid response from the API.");
                                result = "No valid response from the API.";
                                //return new JsonResult
                                //{
                                //    Data = new { message = result, imgsrc = imgSP, alink = linkTo },
                                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                //};
                                return new JsonResult
                                {
                                    Data = new { message = "Xin lỗi tôi không hiểu rõ ý muộn của bạn, bạn có thể nói lại lần nữa không? 🥺", imgsrc = imgSP, alink = linkTo },
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);

                            //return new JsonResult
                            //{
                            //    Data = new { message = "\nException Caught! Message :"+ e.Message + " " , imgsrc = imgSP, alink = linkTo },
                            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            //};
                            return new JsonResult
                            {
                                Data = new { message = "Xin lỗi tôi không hiểu rõ ý muộn của bạn, bạn có thể nói lại lần nữa không? 🥺", imgsrc = imgSP, alink = linkTo },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                        }

                        //string result = responseObject.Choices[0].Message.ToString();
                        //return new JsonResult
                        //{
                        //    Data = new { message = result, imgsrc = imgSP, alink = linkTo },
                        //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        //};

                        //return new JsonResult
                        //{
                        //    Data = new { message = "Xin lỗi tôi không hiểu rõ ý muộn của bạn, bạn có thể nói lại lần nữa không? 🥺", imgsrc = imgSP, alink = linkTo },
                        //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        //};


                    }
                   
                    
                }



                else
                {
                    string isnull = null;
                    //return Redirect("default");
                    return new JsonResult
                    {
                        Data = new { message = isnull, imgsrc = imgSP, alink = linkTo },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }

        }
        public class ResponseObject
        {
            public Choice[] Choices { get; set; }
        }

        public class Choice
        {
            public Message Message { get; set; }
        }

        public class Message
        {
            public string Role { get; set; }
            public string Content { get; set; }

            public override string ToString()
            {
                return Content;
            }
        }

    }

}