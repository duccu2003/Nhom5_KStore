<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TH03_WebBanHang.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <%-- <h2><%: Title %>.</h2>
   <h3>KStore</h3>
   <address>
       Hùng Vương, Số 736<br />
       Đường Nguyễn Trãi, Quận 5<br />
       <abbr title="Phone">Số Điện Thoại:</abbr>
       0389800308
   </address>

   <address>
       <strong>Hỗ Trợ:</strong>   <a href="mailto:Support@example.com">KStore@example.com</a><br />
       <strong>Tiếp Thị:</strong> <a href="mailto:Marketing@example.com">KStore@example.com</a>
   </address>--%>

   
    <meta name="robots" content="noindex, follow">
    <link href="Content/css/animate.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

    <link href="Content/css/animsition.min.css" rel="stylesheet" />

        

    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/css/daterangepicker.css" rel="stylesheet" />
    <link href="Content/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/css/hamburgers.min.css" rel="stylesheet" />
    <link href="Content/css/icon-font.min.css" rel="stylesheet" />
    <link href="Content/css/main.css" rel="stylesheet" />
    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
    <link href="Content/css/util.css" rel="stylesheet" />
 

    <style>
        .btn-send{
            font-weight:bold;
            background-color:#9b51e0;
            border-radius:5px;
            width:100%;
        }
        .btn-send:hover{
            box-shadow:0 0 20px #636363;
        }

        .tenSP-ls-h3 {
            padding-bottom: 1.5rem;
            text-align: center;
            font-weight: bolder;
            font-family: Roboto;
            color: #9b51e0;
            width: 100%;
        }



        .tenSP-ls-p {            color: #9b51e0;
            width: max-content;
            padding: 8px;
   
            border-bottom-color: #000;
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
        }
        *, .nav-link{
             font-family: Roboto;
        }
        #items *{
           font-family: var(--bs-body-font-family) !important;
        }
        .footer-title{
            font-family: Baloo !important;
        }
        section{
         /*  background:#000 !important;*/
          background: linear-gradient(to bottom, #000, #242426);
        }
        .div-content{
            background: linear-gradient(to bottom, #000, #242426);
           
        }
        #hr{
         
        }
        ul *, ol *{
           color:#fff !important;
           background:#000 !important;
           font-family: Roboto !important;
           
        }
        .content2 p{
              padding:2rem;
              
              color:#fff;
              
         }
         .content2  {
             margin-bottom:2rem;  padding:5rem;
         }
         .content2 * {
             font-family:Roboto !important;
              
         }
    </style>
    <section class=" div-content" id="items" style="">
    <div  class="container-contact100 py-5 fade-out div-content" style="margin-top:8rem;">
        <div class="wrap-contact100 fade-out" style="border-radius:10px;  ">
            <div class="contact100-form validate-form">
                <span class="contact100-form-title">Gửi Phản Hồi Cho Chúng Tôi

</span>
                <label class="label-input100" for="first-name">Họ tên của bạn *</label>
                <div class="wrap-input100 rs1-wrap-input100 validate-input" data-validate="Type first name">
                    <asp:TextBox ID="firstName" runat="server" type="text" CssClass="input100" placeholder="Họ"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <div class="wrap-input100 rs2-wrap-input100 validate-input" data-validate="Type last name">
                    <asp:TextBox ID="lastName" runat="server" type="text" CssClass="input100" placeholder="Tên"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="email">Email của bạn *</label>
                <div class="wrap-input100 validate-input" data-validate="Hãy nhập email hợp lệ: ex@abc.xyz">
                    <asp:TextBox ID="email" runat="server" type="email" CssClass="input100" placeholder="example@email.com"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="phone">Số điện thoại</label>
                <div class="wrap-input100">
                    <asp:TextBox ID="phone"  runat="server" CssClass="input100" placeholder="+84 038 9800308"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <label class="label-input100" for="message">Lời nhắn *</label>
                <div class="wrap-input100 validate-input" data-validate="Message is required">
                    <asp:TextBox ID="message" runat="server" type="text" CssClass="input100" TextMode="MultiLine" placeholder="Nhập lời nhắn bạn muốn gửi cho chúng tôi"></asp:TextBox>
                    <span class="focus-input100"></span>
                </div>
                <div class="container-contact100-form-btn">
                    <asp:Button ID="btnSend" runat="server" Text="Gửi phản hồi đến chúng tôi" CssClass="contact100-form-btn btn-send" OnClick="btnSend_Click" style="" />
                </div>
            </div>
            <div class="contact100-more flex-col-c-m fade-out" style="background-image: url('Content/image-branch/4.png');">
                <div class="flex-w size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <img src="Content/icon/w-location.png"/>
<%--                        <span class="lnr lnr-map-marker"></span>--%>
                    </div>
                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">
Địa Chỉ
</span><style>           .txt1 img {
               width:18px;
               margin-top:0.2rem;
               
           }
       </style>
                        <span class="txt2"  style="color:#fff;">
736, Đường Nguyễn Trãi, Quận 5, Hồ Chí Minh.
</span>
                    </div>
                </div>
                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">
                                                <img src="Content/icon/w-phone-call.png"/>

<%--                        <span class="lnr lnr-phone-handset"></span>--%>
                    </div>
                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">
Liên Hệ
</span>
                        <span class="txt3" style="color:#fff;"><a href="tel:+840389800308">+84 038 9800308</a>

</span>
                    </div>
                </div>
                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">
                                                <img src="Content/icon/w-mail.png"/>

<%--                        <span class="lnr lnr-envelope"></span>--%>
                    </div>
                    <div class="flex-col size2">
                        <span class="txt1 p-b-20">
Hỗ Trợ
</span>
                        <span class="txt3"  style="color:#fff;"><a href="mailto:KStore@gmail.com">KStore@gmail.com</a>
<%--<a href="https://colorlib.com/cdn-cgi/l/email-protection" class="__cf_email__" data-cfemail="73101c1d0712100733160b121e031f165d101c1e">[email&#160;protected]</a>--%>
</span>
                    </div>
                </div>
                                <div class="dis-flex size1 p-b-47">
                    <div class="txt1 p-r-25">
                        <style>                            .icon-mxh {
                                width:36px !important;
                              
                            } a:hover, a:active {
                                 color: #9b51e0 !important;
                             }
                        </style>
                                                <img class="icon-mxh fade-in" src="Content/icon/facebook.png"/>
                        <img class="icon-mxh fade-in" style="  margin-left:1rem;" src="Content/icon/instagram.png"/>
<%--                        <span class="lnr lnr-phone-handset"></span>--%>
                    </div>
                    <%--<div class="flex-col size2">
                        <span class="txt1 p-b-20">
Liên Hệ
</span>
                        <span class="txt3" style="color:#9b51e0;">
+84 038 9800308
</span>
                    </div>--%>
                </div>

            </div>
        </div>
    </div>

    </section>
    <section style="background: linear-gradient(to top, #000, #242426) !important; margin:auto; text-align:center;">
        <div class="container px-5 px-lg-5  content2 fade-in" style=" display:block;">
            <h3  class="fade-in" style=""><strong>LƯU Ý VỀ VIỆC GỬI PHẢN HỒI ĐẾN KSTORE</strong></h3>
            <p>Nội dung phản hồi của bạn sẽ được chúng tôi lưu trữ lại nhầm nâng cao chất lượng dịch vụ trong tương lai, nếu bạn đồng ý với điều kiện đó vui lòng gửi phản hồi cho chúng tôi, sau khi chúng tôi đọc và kiểm tra thư chúng tôi sẽ gửi lại phản hồi đến địa chỉ Email mà bạn đã gửi phản hồi trước đó. </p>
            <p>Kstore chân thành cảm ơn những ý kiến, đóng góp, phản hồi của bạn và sẽ cố gắng cải thiện hơn trong tương lai.</p>
<%--    <div class="col-sm-6 d-grid fade-in">
    <h3  class="fade-in" style=""><strong>KẾT NỐI VỚI KSTORE</strong></h3>

    <ul>
         <li  class="fade-in"><p><strong>Địa Chỉ:</strong> [Địa chỉ cửa hàng cụ thể]</p></li>
        <li  class="fade-in"><p>
        <strong>Website:</strong>
        <a href="#">https://www.kstore.com.vn</a>
    </p></li>
        <li  class="fade-in"><p>
        <strong>Fanpage:</strong>
        <a href="#">https://www.facebook.com/kstore</a>
    </p></li>
        <li><p>
        <strong>Instagram:</strong>
        <a href="#">https://www.instagram.com/kstore</a>
    </p></li>
    <li  class="fade-in"><p><strong>Hotline:</strong> 0389800308</p></li>
    </ul>

   
</div>
<div class="col-sm-6 d-grid fade-right">
    <h3  class="fade-in" style=""><strong>ĐỊA CHỈ CỦA KSTORE</strong></h3>

    <ul>
         <li  class="fade-in"><p><strong>Địa Chỉ Chi Nhánh 1:</strong> [Địa chỉ cửa hàng cụ thể]</p></li>
        <li  class="fade-in"><p>
        <strong>Thời gian làm việc:</strong>
        <a href="#">https://www.kstore.com.vn</a>
    </p></li>
        
         <li  class="fade-in"><p><strong>Địa Chỉ Chi Nhánh 2:</strong> [Địa chỉ cửa hàng cụ thể]</p></li>
        <li  class="fade-in"><p>
        <strong>Thời gian làm việc:</strong>
    </ul>

   
</div>--%>

</div>

    </section>
   <style>
       footer a{
           text-decoration:none;
           color:#fff;
       }
   </style>
</asp:Content>
