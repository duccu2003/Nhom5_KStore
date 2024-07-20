<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TH03_WebBanHang.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <%--   <h2><%: Title %>.</h2>--%>
    <%--<h2><img src="Content/logo/logo.png" id="img-logo"/><style>#img-logo{width:180px;}</style></h2>--%>
   
   
                     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

<%--     <h1 class="fw-bolder mb-4 tenSP-ls-h3"><p class="tenSP-ls-p">Thành Viên Thành Lập KStore</p></h1>--%>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <style>
        body{
            overflow-x:hidden;
        }

        .tenSP-ls-h3 {
            text-align: center;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #9b51e0;
          
        }

        .tenSP-ls-p {            color: #9b51e0;
            width: max-content;
            padding-bottom:1.5rem;
            margin: auto;
            padding-top:1rem;
            border-bottom-color: #000;
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
            
        }
        *{
           
        }
        .col-sm-6, .col-sm-3{
            padding:0 10px;
            
            text-align:left;
            align-content:start;
            align-items:start;
            display:block; 
            overflow-x:hidden;
            overflow-y:auto;
            
        }
    </style>
   

    <section class="" style="color:#fff; overflow-x:hidden; margin-top:10rem; background:linear-gradient(to bottom, #000, #242426);">
        <div class="container px-5 px-lg-5" style="/*background:#0000007f;*/ border-radius:10px;">
            <div class="divAboutContent " style="">
                <div id="divLogo" class="col-sm-6 fade-in">
                <img style="width:80%; margin-top:2rem; border-radius:10px; transform:rotate(-6deg)"  src="Content/logo/K-Photoroom.png"/>
            </div>
                 <div class="col-sm-6" style=""> 
                     <h3 style="margin-top:4rem;"><strong>GIỚI THIỆU</strong></h3>
<p>
            Chào mừng bạn đến với KStore – điểm đến tuyệt vời dành cho tất cả những ai yêu thích Kpop! Chúng tôi tự hào là cửa hàng chuyên bán các sản phẩm Kpop hàng đầu, mang đến cho bạn một thế giới âm nhạc và văn hóa Hàn Quốc ngay tại Việt Nam.
        </p>
                 </div>
                
            </div>
           

        </div>
    </section>
    <style>
       
        
       
        
        h1 {
            color: #e91e63;
            text-align: center;
            margin-bottom: 20px;
        }
        
        h2 {
            color: #333;
            margin-top: 20px;
        }
        
        ul {
            list-style: none;
            padding: 0;
        }
        
        ul li {
           /* background: url("https://i.imgur.com/kjM2p4Z.png") no-repeat left center;*/
            background-size: 20px 20px;
           /* padding-left: 30px;*/
            margin-bottom: 10px;
        }
        
        .contact-info {
            margin-top: 20px;
        }
        
        .contact-info p {
            margin: 5px 0;
        }
        
        .highlight {
            color: #e91e63;
        }
        ol{
            padding-left:16px;
        }
        
      
    </style>
    <style>
        .divAboutSP img{
            object-fit:cover;
            border-radius:10px;
           
        }
       
        .ul-ab-div-lydo *{
            
        }
        @media only screen and (min-width:768px){
            .divAboutContent{
                display:flex;
            }
             .ul-ab-div-lydo img{
                 height:50px;
                 width:50px;
             }
             .divAboutSP img{
                
                height:300px;
                width:180px !important;
            }
              .col-sm-3,.col-sm-6{
                
                 height:400px;
             }
              #KNKSTORE{
                  clip-path: polygon(0% 0%, 100% 0%, 100% 75%, 75% 75%, 75% 100%, 50% 75%, 0% 75%);
              }
              #LDNCKSTORE{
                  clip-path: polygon(0% 0%, 100% 0%, 100% 75%, 50% 75%, 25% 100%, 25% 75%, 0% 75%);
              }
              .rotateulMap{
                   left:10px; transform: rotate(-32.5deg);position:relative;
              }
        }
         @media only screen and (max-width:768px){
             #carouselExampleIndicators{
                 height:450px !important;
                 overflow:hidden;
             }
             .rotateulMap{
                 left:-120px; transform: rotate(-60.75deg);
                 margin-right:1rem;
                 bottom:-150px;
                 width:80%;
                 display:block;
                 font-size:x-small;
                 position:relative;

            }

             .divAboutContent{
                 
             }
             .col-sm-3,.col-sm-6{
                 width:100%;overflow:hidden;
                 height:max-content;
                 margin:2.5rem auto !important;
                
             }
             .div-footer-content2{
                 text-align:center !important;
                 
             }
             ol {
                 margin-left:0 !important;
                 padding-left:0 !important;
             }
               .col-sm-3 p,.col-sm-6 p,.divAboutContent ul *,.divAboutContent ol *{
                
                text-align:left !important;
             }
              .divAboutSP img{
                 
                 width:120px !important;
                 height:180px;
             }
              .divAboutContent *{
                  text-align:center;
                  margin:auto;overflow:hidden;
                  
              }
              body{
                  overflow:hidden;
                  margin:auto;
              }
         }
         @keyframes imgCAP {
          0% {
            transform:rotate(-10deg);
         

            opacity: 0;
          }
          60% {
             transform:rotate(10deg);
          

            opacity: 1;
          }
          100% {
            transform: scale(1);
             transform:rotate(-6deg);

          }
        }
         #divLogo img{
             animation-duration: 2s;
             animation-name: imgCAP;
         }
    </style>
    <section class="" style="color:#fff; background:#242426;">
        <div class="container px-5 px-lg-5 divAboutContent" style="/*background:#0000007f;*/ border-radius:10px; gap:10px; justify-content:center; align-content:center; align-items:center; justify-items:center;">
                <div class="col-sm-6 fade-in" style="">
                    
                    <h3 style=""><strong>SẢN PHẨM ĐẶC SẮC</strong></h3>
                        <ul>
                            <li>
                                <strong>Album Kpop:</strong> Chúng tôi cung cấp đầy đủ các album từ những nhóm nhạc và nghệ sĩ hàng đầu như BTS, BLACKPINK, EXO, TWICE, và nhiều hơn nữa. Các phiên bản giới hạn, album đặc biệt và đĩa than hiếm có đều có mặt tại KStore.
                            </li>
                            <li>
                                <strong>Merchandise (Đồ lưu niệm):</strong> Áo phông, mũ, túi xách, poster, và hàng loạt phụ kiện thời trang khác mang đậm phong cách Kpop. Photocard, sticker, và nhiều vật phẩm sưu tầm độc đáo dành riêng cho fan.
                            </li>
                            <li>
                                <strong>Lightsticks:</strong> Các mẫu lightstick chính hãng từ các nhóm nhạc yêu thích của bạn, giúp bạn tỏa sáng trong mỗi concert và sự kiện.
                            </li>
                        </ul>
                </div>
               
                   <div class="col-sm-6 divAboutSP d-flex" style="gap:15px;">
                    <img style="width:180px" class="fade-in" src="Content/image-data/alb.jpg"/>
                     <img style="width:180px" class="fade-out" src="Content/image-data/md.jpg"/>
                     <img style="width:180px" class="fade-right" src="Content/image-data/ls.jpg"/>
              </div>
            </div>
    </section>
   <section class="" style="color:#fff; background:#242426;">
   
  <h1 class="fade-in" style="color:#FFF; position:absolute; padding-top:20px; margin:auto; width:100%; text-align:center; z-index:999;">ĐỊA CHỈ CỬA HÀNG</h1>
<div id="carouselExampleIndicators" class="fade-in carousel slide container px-5 px-lg-5 divAboutContent" style="background-image: linear-gradient(to right, #562386,#735292, #232592); background-size: 200% auto; animation: backgroundMapping 5s ease infinite; border-radius:10px; /*background:#0000007f;*/   justify-content:center; align-content:center; align-items:center; justify-items:center;">
          
  
          <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            
          </div>
          <div class="carousel-inner">
            <div class="carousel-item active">
               <ul class="rotateulMap" style="">
                   <li><h3>Chi nhánh Hà Nội</h3></li>
                   <li><p>Địa chỉ: Số 4B Phố Hàng Bài, P. Tràng Tiền, Q. Hoàn Kiếm, Hà Nội</p></li>

               </ul>
            <iframe class="col-sm-4 " style="height:400px; width:100%;  padding:20px 10px; justify-content:center; justify-items:center; clip-path: polygon(50% 0%, 100% 0, 100% 100%, 0 100%);" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.206404441712!2d105.85310919999999!3d21.024425699999995!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135abeca85765eb%3A0x182717ff5916baf7!2zNEIgUC4gSMOgbmcgQsOgaSwgVHLDoG5nIFRp4buBbiwgSG_DoG4gS2nhur9tLCBIw6AgTuG7mWksIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1720275140863!5m2!1svi!2s" width="600" height="450" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    
            </div>
            <div class="carousel-item">
                 <ul class="rotateulMap" style="">
                       <li><h3>Chi nhánh Hồ Chí Minh</h3></li>
                       <li><p>Địa chỉ: Số 172 Đường Số 1 Q.Bình Tân</p></li>

                   </ul>
                <iframe class="col-sm-4 " style="height:400px; width:100%;  padding:20px 10px; justify-content:center; justify-items:center; clip-path: polygon(50% 0%, 100% 0, 100% 100%, 0 100%);" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.8166319136185!2d106.61648179999997!3d10.748611300000002!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752dcd68c5a1a3%3A0xef240e1eb6bb8965!2zMTcyIMSQLiBT4buRIDEsIELDrG5oIFRy4buLIMSQw7RuZyBCLCBCw6xuaCBUw6JuLCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1720275296910!5m2!1svi!2s" width="600" height="450" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    
            </div>
            
          </div>
          <button style="background:#000; border-radius:20px; border-bottom-left-radius:0; border-top-left-radius:0; padding:10px; height:max-content; width:max-content; justify-content:center; align-content:center; margin:auto;" class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button style="background:#000; border-radius:20px;  border-bottom-right-radius:0; border-top-right-radius:0; padding:10px; height:max-content; width:max-content; justify-content:center; align-content:center; margin:auto;" class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>

   

</section>
                
             
    <section class="" style="color:#fff; background:linear-gradient(to bottom, #242426, #000);">
    
    <div class="container px-5 px-lg-5 divAboutContent" style="/*background:#0000007f;*/ border-radius:10px; gap:60px; justify-content:center; align-content:center; align-items:center; justify-items:center;">
           
           <div id="LDNCKSTORE" class="col-sm-6 d-grid fade-left fate-in" style="margin:4rem  auto;
 background: linear-gradient(to right, #562386, #232592); padding:20px 10px; justify-content:center; justify-items:center;">
        
                <h3 class="" style=""><strong>LÝ DO NÊN CHỌN KSTORE</strong></h3>
          
                        <ol class="ul-ab-div-lydo" style="">
                            <li class="">
                                <span class="highlight">Chất Lượng Chính Hãng:</span> Cam kết tất cả các sản phẩm đều là hàng chính hãng, được nhập khẩu trực tiếp từ Hàn Quốc.
                            </li>
                            <li class=""> 
                                <span class="highlight">Giá Cả Cạnh Tranh:</span> Giá thành hợp lý, nhiều chương trình khuyến mãi hấp dẫn dành cho khách hàng thân thiết.
                            </li>
                            <li class="">
                                <span class="highlight">Dịch Vụ Khách Hàng Tận Tâm:</span> Đội ngũ nhân viên nhiệt tình, am hiểu về Kpop, luôn sẵn sàng tư vấn và hỗ trợ bạn.
                            </li>
                            <li class="">
                                <span class="highlight">Mua Sắm Tiện Lợi:</span> Hệ thống cửa hàng online và offline thuận tiện, giao hàng nhanh chóng trên toàn quốc.
                            </li>
                        </ol>
            </div>
             
        
       
        <div id="KNKSTORE" class="col-sm-6 d-grid fade-right fate-in" style="margin:4rem  auto;
background: linear-gradient(to left, #562386, #232592); padding:20px 10px; justify-content:center; justify-items:center;">
            <h3  class="" style=""><strong>KẾT NỐI VỚI KSTORE</strong></h3>

            <ul>
                 <li  class=""><p><strong>Địa Chỉ:</strong> KSTown 736, Nguyễn Trãi, Quận 5, TP.HCM</p></li>
                <li  class=""><p>
                <strong>Website:</strong>
                <a href="#">https://www.kstore.com.vn</a>
            </p></li>
                <li  class=""><p>
                <strong>Fanpage:</strong>
                <a href="#">https://www.facebook.com/kstore</a>
            </p></li>
                <li><p>
                <strong>Instagram:</strong>
                <a href="#">https://www.instagram.com/kstore</a>
            </p></li>
            <li  class=""><p><strong>Hotline:</strong> 0389800308</p></li>
            </ul>

           
        </div>
       
    </div>
      
</section>
              
    
    <section class="" style="color:#fff; background:linear-gradient(to bottom, #242426, #000);">
<div class="container-fuild  divAboutContent" style="/*background:#0000007f;*/ border-radius:10px; gap:10px; justify-content:center; align-content:center; align-items:center; justify-items:center;">
<%--       <img class="fade-out" style="width:100%;" src="Content/image-data/member-nhom5.png"/>--%>
           <img class="fade-out" style="width:100%;" src="Content/image-data/member-nhom5.png"/>

           </div>

    </section>
    <style>
      

     .element {
  transform: translateY(100%);
  transition: transform 0.5s ease; /* Áp dụng hiệu ứng cho transform */
}

.element.show {
  transform: translateY(0); /* Dịch chuyển lên trên khi hiển thị */
}
.single_advisor_profile {
    position: relative;
    margin-bottom: 50px;
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    z-index: 1;
    border-radius: 15px;
    -webkit-box-shadow: 0 0.25rem 1rem 0 rgba(47, 91, 234, 0.125);
    box-shadow: 0 0.25rem 1rem 0 rgba(47, 91, 234, 0.125);
}
.single_advisor_profile .advisor_thumb {
    position: relative;
    z-index: 1;
    border-radius: 15px 15px 0 0;
    margin: 0 auto;
    padding: 30px 30px 0 30px;
    background-color: #9b51e0;
    overflow: hidden;
}
.single_advisor_profile .advisor_thumb::after {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    position: absolute;
    width: 150%;
    height: 80px;
    bottom: -45px;
    left: -25%;
    content: "";
    background-color: #ffffff;
    -webkit-transform: rotate(-15deg);
    transform: rotate(-15deg);
}
@media only screen and (max-width: 575px) {
    .single_advisor_profile .advisor_thumb::after {
        height: 160px;
        bottom: -90px;
    }
}
.single_advisor_profile .advisor_thumb .social-info {
    position: absolute;
    z-index: 1;
    width: 100%;
    bottom: 0;
    right: 30px;
    text-align: right;
}
.single_advisor_profile .advisor_thumb .social-info a {
    font-size: 14px;
    color: #020710;
    padding: 0 5px;
}
.single_advisor_profile .advisor_thumb .social-info a:hover,
.single_advisor_profile .advisor_thumb .social-info a:focus {
    color: #3f43fd;
}
.single_advisor_profile .advisor_thumb .social-info a:last-child {
    padding-right: 0;
}
.single_advisor_profile .single_advisor_details_info {
    position: relative;
    z-index: 1;
    padding: 30px;
    text-align: right;
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    border-radius: 0 0 15px 15px;
    background-color: #ffffff;
}
.single_advisor_profile .single_advisor_details_info::after {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    position: absolute;
    z-index: 1;
    width: 50px;
    height: 3px;
    background-color: #725535;
    content: "";
    top: 12px;
    right: 30px;
}
.single_advisor_profile .single_advisor_details_info h6 {
    margin-bottom: 0.25rem;
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
}
@media only screen and (min-width: 768px) and (max-width: 991px) {
    .single_advisor_profile .single_advisor_details_info h6 {
        font-size: 14px;
    }
}
.single_advisor_profile .single_advisor_details_info p {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    margin-bottom: 0;
    font-size: 14px;
}
@media only screen and (min-width: 768px) and (max-width: 991px) {
    .single_advisor_profile .single_advisor_details_info p {
        font-size: 12px;
    }
}
.single_advisor_profile:hover .advisor_thumb::after,
.single_advisor_profile:focus .advisor_thumb::after {
    background-color: #725535;
}
.single_advisor_profile:hover .advisor_thumb .social-info a,
.single_advisor_profile:focus .advisor_thumb .social-info a {
    color: #ffffff;
}
.single_advisor_profile:hover .advisor_thumb .social-info a:hover,
.single_advisor_profile:hover .advisor_thumb .social-info a:focus,
.single_advisor_profile:focus .advisor_thumb .social-info a:hover,
.single_advisor_profile:focus .advisor_thumb .social-info a:focus {
    color: #ffffff;
}
.single_advisor_profile:hover .single_advisor_details_info,
.single_advisor_profile:focus .single_advisor_details_info {
    background-color: #725535;
}
.single_advisor_profile:hover .single_advisor_details_info::after,
.single_advisor_profile:focus .single_advisor_details_info::after {
    background-color: #ffffff;
}
.single_advisor_profile:hover .single_advisor_details_info h6,
.single_advisor_profile:focus .single_advisor_details_info h6 {
    color: #ffffff;
}
.single_advisor_profile:hover .single_advisor_details_info p,
.single_advisor_profile:focus .single_advisor_details_info p {
    color: #ffffff;
}
.advisor_thumb {
  
   height:20rem;
}
.advisor_thumb img{
  border-start-end-radius:20px;
   max-width:100%;
   
}
.designation{
    font-size:xx-large;
    font-weight:bolder;
}
    </style>
</asp:Content>
