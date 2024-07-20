<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TH03_WebBanHang._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
            body {
                background-image: url('Content/image-bg/KStore-bg.png');
                background-size: cover;
                background-color: #000;
            }


            .notification {
                display: none;
                position: fixed;
                top: 15%;
                left: 50%;
                transform: translate(-50%, -50%);
                background-color: #212529;
                padding: 0 10px;
                border-radius: 10px;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
                text-align: center;
                justify-content: center;
                align-items: center;
                gap:1rem;
                width:max-content;
                z-index:9999;
                /*flex-direction: column;*/        
            }

            .notification img {
                width: 30%;
                height:auto;
            }
            .notification p {
                font-family:Baloo;
                padding-top:1rem;
                font-size:20px;
            }
            
    </style>
    <div id="notification" class="notification">
        <img <%--loading="lazy"--%> src="Content/icon/p-Success.gif" alt="">
        <p>Thêm thành công!</p>
    </div>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click
            const addToCartBtn = document.querySelector('.btn-gio');
            const notification = document.getElementById('notification');

            // Sử dụng addEventListener với class thay vì ID
            addToCartBtn.addEventListener('click', showNotification);

            function showNotification() {
                // Hiển thị thông báo
                notification.style.display = 'flex';

                // Ẩn thông báo sau 2 giây
                setTimeout(function () {
                    notification.style.display = 'none';
                }, 2000);
            }
        });
    </script>
    <!-- Header-->
    <header class="py-0 px-0" style="margin-top:9.25rem;">
        <style>
            @media only screen and  (min-width: 768px) {
                .divBanner1{
                     height:400px;
                }
                .divACheader{
                    display:flex;
                }
                .single-row-item {
                  
                    width: 100px; /* Adjust the width as needed */
                    height:100px;
                   
                }
                #scrollRight{
                     right:0.5rem;
                }
                #scrollLeft{
                    left:0.5rem;
                }
                .aGP{
                   
                }
                .divGP{
                    gap: 11.8px; 
                }
                .divHeader{
                    margin:auto;
                    max-width:1531px;
                    
                    
                }.divBannerLS23{
                    display:grid;
                }
                 /*.divBanner1{
                     max-width: 80%;
                 }*/
                 .rotateulMap{
                         left:10px; transform: rotate(-32.5deg);position:relative;
                    }
            }
            @media only screen and (max-width: 450px) {
                  .divACheader p{
                          display:none;
    
                    }
                  .divACheader h6{
                       align-content:center;
                       align-items:center;
                       justify-content:center;
                       justify-items:center;
                       padding-top:10px;
    
                  }

            }
           
            @media only screen and  (max-width: 768px) {
                 .divACheader{
                     display:flex;
                    flex-wrap:wrap;
                 }
                 .divACheader img{
                    width:44px !important;
                    height:44px !important;
                }
                 
                 .col-sm-3{
                     width:50%;
                 }
               
                #scrollRight{
                     right:0.5rem;
                }
                #scrollLeft{
                    left:0.5rem;
                }
                 .aGP{
                    
                    
                    
                 }
                .divGP{
                   gap:0;
                    
                }
                 .single-row-item {
                     width: 90px; height: 90px;
                    
                   
   
                 }
                .divHeader{
                    margin:auto;
                    
                    
                }
                
                .divBanner2{
                    display:none;
                }
                .divBannerLS23{
                    display:none;
                }
                 .divBanner1{
                     max-width: 100%;
                 }
                  #carouselExampleIndicators{
                         /*height:450px !important;*/
                        /* overflow:hidden;*/
                     }
                     .rotateulMap{
                         left:-80px; transform: rotate(-57.5deg);
                         margin-right:1rem;
                         bottom:-150px;
                         width:80%;
                         display:block;
                         font-size:x-small;
                         position:relative;

                    }
            }
        </style>
        <div class="divHeader" style="display: flex; background: #000; ">
            <div class="px-0 px-lg-0 my-0 position-relative  divBanner1" style="border: 4px solid #000; width:100%; border-right: none;">
                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                    <a id="scrollPreviousBanner1" class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 10px 30px 5px; border-bottom-right-radius:10rem;  border-top-right-radius:10rem;">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a id="scrollNextBanner1" class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 5px 30px 10px; border-bottom-left-radius:10rem;  border-top-left-radius:10rem;">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                    <style>
                        #carouselExampleControls:hover #scrollPreviousBanner1,#carouselExampleControls:hover #scrollNextBanner1{
                            display:block;
                        }
                        #scrollPreviousBanner1, #scrollNextBanner1{
                            display:none;
                        }
                    </style>

                    <ol class="carousel-indicators">
                        <%--<li data-target="#carouselExampleControls" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleControls" data-slide-to="1"></li>
                        <li data-target="#carouselExampleControls" data-slide-to="2"></li>
                        <li data-target="#carouselExampleControls" data-slide-to="3"></li>--%>
                        <asp:ListView ID="ListView5" runat="server" ItemType="TH03_WebBanHang.Models.Banner" SelectMethod="GetBanner">
                            <ItemTemplate>
                                <li data-target="#carouselExampleControls" data-slide-to="<%#:Item.MaBanner%>" class='<%# Eval("MaBanner").ToString() == "0"? "active" : "" %>'></li>
                            </ItemTemplate>
                        </asp:ListView>


                    </ol>
                    <div class="carousel-inner">
                        <%--<div class="carousel-item active">
                            <img loading="lazy" src="Content\image-banner\banner1.1.png" class="d-block w-100" alt="Background Image 1">
                        </div>
                        <div class="carousel-item">
                            <img loading="lazy" src="Content\image-banner\banner2.png" class="d-block w-100" alt="Background Image 2">
                        </div>
                        <div class="carousel-item">
                            <img loading="lazy" src="Content\image-banner\banner3.png" class="d-block w-100" alt="Background Image 3">
                        </div>
                        <div class="carousel-item">
                            <img loading="lazy" src="Content\image-banner\banner4.png" class="d-block w-100" alt="Background Image 4">
                        </div>--%>
                         <asp:ListView ID="ListView6" runat="server" ItemType="TH03_WebBanHang.Models.Banner" SelectMethod="GetBanner">
                             <ItemTemplate>
                                 
                                 <div title="<%#:Item.TieuDe %>" class='carousel-item <%# Eval("MaBanner").ToString() == "0"? "active" : "" %>'>
                                    <img loading="lazy" src="<%#:Item.DuongDan %>" class="d-block w-100" alt="Background Image 2">
                                </div>

                             </ItemTemplate>
                         </asp:ListView>
                    
                    </div>
                   
                </div>


            </div>

            </div>
        <script>

            var myCarousel = new bootstrap.Carousel(document.getElementById('carouselExampleControls'), {
                interval: 3000, // Thời gian chuyển ảnh (5 giây)
                wrap: true // Tự động quay vòng ảnh

            });
            //var myCarousel = new bootstrap.Carousel(document.getElementById('carouselExampleIndicators'), {
            //    interval: 3000, // Thời gian chuyển ảnh (5 giây)
            //    wrap: true // Tự động quay vòng ảnh

            //});

            var myCarousel = new bootstrap.Carousel(document.getElementById('carouselExampleIndicators'), {
                interval: 2000, // Thời gian chuyển ảnh (5 giây)
                wrap: true // Tự động quay vòng ảnh

            });
            var myCarousel = new bootstrap.Carousel(document.getElementById('carouselExampleControlsBranch'), {
                interval: 3000, // Thời gian chuyển ảnh (5 giây)
                wrap: true // Tự động quay vòng ảnh

            });
            var myCarousel = new bootstrap.Carousel(document.getElementById('carouselExampleControlsRoom'), {
                interval: 3000, // Thời gian chuyển ảnh (5 giây)
                wrap: true // Tự động quay vòng ảnh

            });
        </script>

       

        <style>
            .carousel-item {
                transition-duration: 0.1s !important; /* Tốc độ chuyển cảnh là 0.5 giây */
            }

            .container .btn-mua:hover {
                background-color: #FBF4F1;
                color: #212529;
            }

            .container .btn-mua:active {
                background-color: #9b51e0 !important;
                color: #212529 !important;
            }
            /**/ .bg-dark {
                position: relative;
            }

                .bg-dark .container {
                    position: relative;
                    overflow: hidden;
                }

                .bg-dark img {
                    filter: brightness(35%);
                }

            .position-absolute {
                position: absolute;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
                z-index: 1;
            }

            .tenSP-ls-h3 {
                padding-bottom: 1.5rem;
                text-align: center;
                font-weight: bolder;
                font-family: Roboto;
                color: #9b51e0;
                width: 100%;
                font-size: 3rem
            }

            .tenSP-ls-p {
                color: #9b51e0;
                width: max-content;
                padding: 8px;
                margin: auto;
                border-bottom-color: #000;
                border: 1px solid;
                border-top-style: none;
                border-left-style: none;
                border-right: none;
            }
        </style>

    </header>
    <style>
        .itemMap{
            background-image:linear-gradient(to right, #522A77, #804cdeff, #1c60bc);
           height:460px;
           background-size: 200% auto; animation: backgroundMapping 5s ease infinite;
           border-radius:10px;
        }
        .ul-l-type p {
            border: 2px solid #21222937;
            width: 7rem;
        }

            .ul-l-type p:hover {
                border-top-color: none;
                border-left-color: none;
                border-right-color: none;
                border-bottom-color: #1c60bc;
            }

        .ul-l-type li p {
            color: #fff;
            padding: 5px;
            font-size: large;
        }



        .ul-l-type a:hover {
            color: #808080;
            text-decoration: none;
        }



        .ul-l-type a {
            text-decoration: none;
            display: flex;
        }




        .carousel-item-boder img {
            /* border-top-right-radius: 10px;
         border-top-right-radius: 10px;*/
        }

        .carousel-item img {
            width: 100% !important;
            height: auto;
        }

        .carousel {
            position: relative
        }

            .carousel.pointer-event {
                -ms-touch-action: pan-y;
                touch-action: pan-y
            }

        .carousel-inner {
            position: relative;
            width: 100%;
            overflow: hidden
        }

            .carousel-inner::after {
                display: block;
                clear: both;
                content: ""
            }

        .carousel-item {
            position: relative;
            display: none;
            float: left;
            width: 100%;
            margin-right: -100%;
            -webkit-backface-visibility: hidden;
            backface-visibility: hidden;
            transition: -webkit-transform .6s ease-in-out;
            transition: transform .6s ease-in-out;
            transition: transform .6s ease-in-out,-webkit-transform .6s ease-in-out
        }

        @media (prefers-reduced-motion:reduce) {
            .carousel-item {
                transition: none
            }
        }

        .carousel-item-next, .carousel-item-prev, .carousel-item.active {
            display: block
        }

            .active.carousel-item-right, .carousel-item-next:not(.carousel-item-left) {
                -webkit-transform: translateX(100%);
                transform: translateX(100%)
            }

            .active.carousel-item-left, .carousel-item-prev:not(.carousel-item-right) {
                -webkit-transform: translateX(-100%);
                transform: translateX(-100%)
            }

        .carousel-fade .carousel-item {
            opacity: 0;
            transition-property: opacity;
            -webkit-transform: none;
            transform: none
        }

            .carousel-fade .carousel-item-next.carousel-item-left, .carousel-fade .carousel-item-prev.carousel-item-right, .carousel-fade .carousel-item.active {
                z-index: 1;
                opacity: 1
            }

        .carousel-fade .active.carousel-item-left, .carousel-fade .active.carousel-item-right {
            z-index: 0;
            opacity: 0;
            transition: opacity 0s .6s
        }

        @media (prefers-reduced-motion:reduce) {
            .carousel-fade .active.carousel-item-left, .carousel-fade .active.carousel-item-right {
                transition: none
            }
        }

        .carousel-control-next, .carousel-control-prev {
            position: absolute;
            top: 0;
            bottom: 0;
            z-index: 1;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            -ms-flex-pack: center;
            justify-content: center;
            width: 15%;
            color: #fff;
            text-align: center;
            opacity: .5;
            transition: opacity .15s ease
        }

        @media (prefers-reduced-motion:reduce) {
            .carousel-control-next, .carousel-control-prev {
                transition: none
            }
        }

        .carousel-control-next:focus, .carousel-control-next:hover, .carousel-control-prev:focus, .carousel-control-prev:hover {
            color: #fff;
            text-decoration: none;
            outline: 0;
            opacity: .9
        }

        .carousel-control-prev {
            left: 0
        }

        .carousel-control-next {
            right: 0
        }

        .carousel-control-next-icon, .carousel-control-prev-icon {
            display: inline-block;
            width: 20px;
            height: 20px;
            background: no-repeat 50%/100% 100%
        }

        .carousel-control-prev-icon {
            background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' fill='%23fff' width='8' height='8' viewBox='0 0 8 8'%3e%3cpath d='M5.25 0l-4 4 4 4 1.5-1.5L4.25 4l2.5-2.5L5.25 0z'/%3e%3c/svg%3e")
        }

        .carousel-control-next-icon {
            background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' fill='%23fff' width='8' height='8' viewBox='0 0 8 8'%3e%3cpath d='M2.75 0l-1.5 1.5L3.75 4l-2.5 2.5L2.75 8l4-4-4-4z'/%3e%3c/svg%3e")
        }

        .carousel-indicators {
            position: absolute;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 15;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-pack: center;
            justify-content: center;
            padding-left: 0;
            margin-right: 15%;
            margin-left: 15%;
            list-style: none
        }

            .carousel-indicators li {
                box-sizing: content-box;
                -ms-flex: 0 1 auto;
                flex: 0 1 auto;
                width: 30px;
                height: 3px;
                margin-right: 3px;
                margin-left: 3px;
                text-indent: -999px;
                cursor: pointer;
                background-color: #fff;
                background-clip: padding-box;
                border-top: 10px solid transparent;
                border-bottom: 10px solid transparent;
                opacity: .5;
                transition: opacity .6s ease
            }

        @media (prefers-reduced-motion:reduce) {
            .carousel-indicators li {
                transition: none
            }
        }

        .carousel-indicators .active {
            opacity: 1
        }

        .carousel-caption {
            position: absolute;
            right: 15%;
            bottom: 20px;
            left: 15%;
            z-index: 10;
            padding-top: 20px;
            padding-bottom: 20px;
            color: #fff;
            text-align: center
        }

        .sr-only {
            position: absolute;
            width: 1px;
            height: 1px;
            padding: 0;
            margin: -1px;
            overflow: hidden;
            clip: rect(0,0,0,0);
            white-space: nowrap;
            border: 0
        }

        .sr-only-focusable:active, .sr-only-focusable:focus {
            position: static;
            width: auto;
            height: auto;
            overflow: visible;
            clip: auto;
            white-space: normal
        }

        .img-dm {
            max-width: 60px !important;
            border-radius: 10px;
            padding-bottom: 0.5rem;
        }
    </style>
   

    <!-- Section-->

    <style>
        body{
            background:#000;
            overflow-x:hidden;
        }
        .single-row {
            display: flex;
            flex-wrap: nowrap; /* Prevents items from wrapping to the next line */
            overflow-x: auto; /* Enables horizontal scrolling if items overflow the container */
        }
        
        .single-row-item {
            flex: 0 0 auto; /* Prevents the items from growing or shrinking */
           
           
        }
        /* For WebKit browsers (Chrome, Safari, etc.) */
        /* For WebKit browsers (Chrome, Safari, etc.) */
        .single-row::-webkit-scrollbar {
            width: 4px; /* Adjust the width as needed */
            color: #fff0;
            
        }
        
        .single-row::-webkit-scrollbar-thumb {
            background: linear-gradient(to right, #9b51e0, #212529);
            /* Adjust the color as needed */
            border-radius: 20px !important;
            color: #fff0;
           
        }

        .single-row::-webkit-scrollbar-track {
            background-color: #f1f1f100; /* Adjust the color as needed */
            cursor: pointer; /* Make the track clickable */
            color: #fff0;
        }

        /* For Firefox */
        .single-row {
            scrollbar-width:thin;
            scrollbar-color: #9b51e03a #f1f1f100; /* Adjust the colors as needed */
            
        }
        .single-row:hover {
            
            scrollbar-color: #9b51e09e #f1f1f100; /* Adjust the colors as needed */
    
        }
        #content-group-idols {
           /* background-image: url('Content/image-bg/KStore-bg.png');*/
           background-size: cover;
           object-fit:cover;
            background-color: #000;
           /* border-bottom:1px solid #636363 !important;*/
            

        }

        .content-itens {
            position: relative; /* Đảm bảo rằng pseudo-element sẽ được đặt đúng vị trí */
            overflow: hidden; /* Đảm bảo rằng nội dung không vượt quá kích thước của #content-itens */
        }

            .content-itens::before {
                content: ""; /* Yêu cầu cho pseudo-element */
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                background-image: url('Content/image-bg/bg1.png');
                background-size: cover;
                background-repeat: no-repeat;
                filter: brightness(50%); /* Áp dụng hiệu ứng tối hơn cho hình nền */
                z-index: -1; /* Đặt pseudo-element dưới cùng để không che khuất nội dung */
            }
            .popupShowFixGetSubMainTitleEjoy,.popupShowFixGetSubMainEjoy,.popupShowFixGetSubMainEjoy{
                z-index:0;
                background:#0000;
                color:#0000;

            }

            @keyframes backgroundGroupSelectColor {
                0% {background-position: left;}
                50% {background-position: right;}
                100% {background-position: left;}
            }

    </style>
    <%--<script>
        function changeBackgroundImage() {
            var contentGroupIdols = document.getElementById('content-group-idols');
            contentGroupIdols.style.backgroundImage = "url('Content/image-bg/bg-for-slide-gp.png')";
        } window.onload = changeBackgroundImage;
    </script>--%>

    <script>

        $(document).ready(function () {
            $('[data-toggle="popoverGP"]').popover({
                trigger: 'hover',
                placement: 'bottom',
                html: true,
                content: function () {
                    return $(this).data('content');
                }

            });
        });

    </script>
    <style>
        .divAC{
            border-left:1px solid #242424;
            padding:10px 5px;
            gap:10px;
           border-right:1px solid #242424;

        }
        .divAC div{
            
        }
    </style>
    <section loading="lazy"  style="max-width:1531px; margin:auto; background:#000 !important;" class="py-5">
         <div loading="lazy" class="container-fuild px-4 px-lg-5 fade-in divACheader" style="">
             <div class="col-sm-3 d-flex divAC">
                 <img src="data:image/png;base64,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">
                <div class="d-grid">
                 <h6>Giao hàng nhanh chóng</h6>
                 <p>Giao đến bạn với tốc độ như quả tên lửa!</p>
                </div>
             </div>
             <div class="col-sm-3 d-flex divAC">
                <img src="data:image/png;base64,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">
                 <div class="d-grid">
                 <h6>Thanh toán an toàn</h6>
                 <p>100% thanh toán an toàn với nhiều hình thức!</p>
                </div>
            </div>
             <div class="col-sm-3 d-flex divAC">
                 <img src="data:image/png;base64,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">
             <div class="d-grid">
                 <h6>Hỗ trợ 24/7</h6>
                 <p>Hỗ trợ tận tâm, lun giải đáp các câu hỏi và thắc mắc của bạn!</p>
                </div>
             </div>
             <div class="col-sm-3 d-flex divAC">
                 <img src="data:image/png;base64,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">
                 <div class="d-grid">
                     <h6>Dịch vụ quà tặng</h6>
                     <p>Hỗ trợ các sản phẩm, dịch vụ quà tặng!</p>
                    </div>
                 </div>
             
             </div>
      
    </section>

    <section loading="lazy" id="content-group-idols" style="max-width:1531px; margin:auto; background:linear-gradient(to bottom, #000, #242426);   /*background-image:url('Content/image-bg/bg-for-slide-gp.png');*/ " class="py-5">
        <div loading="lazy" class="container px-4 px-lg-5 mt-0 fade-in" style="background: linear-gradient(to bottom, #1111117f, #242426); border-radius: 10px 10px 30px 30px !important;  padding:2.5rem 0 1rem 0;">
           <h3 id="NS" class=" text-left lnr-text-size" style="position:absolute; top:-20px;">
                 <p class="">Danh mục nhóm, nghệ sĩ</p>
             </h3>
            <div loading="lazy" id="divlistidols" class="gx-4 gx-lg-5 single-row <%--fade-out--%> smooth-scroll divGP filtering" style="/*background-color: #EADEFF; */ scroll-behavior: smooth; overflow-y:hidden; /*box-shadow:0px 0px 50px #522A77;*/  
background-image: linear-gradient(to right , #a27ac7, /*#EADEFF*/ #fff, #C4A1FE, #a678d1);  background-size: 200% auto;     animation: backgroundGroupSelectColor 5s ease infinite;
 border-radius: 10px; border: 3px solid #9b51e0; padding-top: 6px; padding-bottom:-2px;">
                <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.Nhom" SelectMethod="GetGroup">
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>

                        <td />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <div id="slideGroup" class="slideGroup col mb-0 single-row-item ">
                            <style>
                                .groupIdols,.groupIdols img{
                                    transition:0.5s;
                                }
                                .groupIdols:hover img{
                                    box-shadow:0px 10px 50px #636363;
                                    transform:scale(1.2);
                                }
                            </style>

                            <a class="btn mt-auto card h-100 groupIdols aGP" style="background: #fff0; border: none;" href="item.aspx?gp=<%#:Item.MaNhom%>">
                                <!-- Product image-->
                                <img data-toggle="popoverGP" data-placement="bottom" data-content="<%#:Item.TenNhom%>"  loading="lazy" class=" img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="background-color: #fff; object-fit: cover; border-radius: 15px;" />
                                <!-- Removed inline styles for .img-with-hover and .btn-outline-dark for clarity -->
                            </a>
                            
                        </div>
                    </ItemTemplate>

                </asp:ListView>


            </div>
            <style>
                #content-group-idols:hover #scrollLeft, #content-group-idols:hover #scrollRight{
                    background:#C4A1FE;
                }
                #scrollLeft, #scrollRight{
                    background:#000;
                    box-shadow:0px 0px 2px #fff;
                }
            </style>
            <a  id="scrollLeft" class="carousel-control-prev justify-content-center align-content-center" style="margin:auto; height:max-content; padding:10px 10px; position:absolute; width:max-content; border-bottom-left-radius:20px; border-top-left-radius:20px;">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>

            </a>
            <a id="scrollRight" class="carousel-control-next justify-content-center align-content-center"  style="margin:auto; height:max-content; padding:10px 10px; position:absolute; width:max-content; border-bottom-right-radius:20px; border-top-right-radius:20px;">    
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>

            </a>
           <%-- <script>
                // Chọn phần tử cần trượt
                var content = document.querySelector('.single-row-item');

                // Tự động trượt sang phải
                setInterval(function () {
                    scrollRight();
                }, 2000); 

            </script>--%>



            <style>
                .smooth-scroll {
                    scroll-behavior: smooth;
                }
            </style>

           <%-- <script>
                // Get the container and the buttons
                var container = document.querySelector('.gx-4.gx-lg-5.single-row.fade-out');
                var scrollLeftButton = document.getElementById('scrollLeft');
                var scrollRightButton = document.getElementById('scrollRight');

                // Calculate the width of the items in the container
                var itemWidth = container.querySelector('.col.mb-0.single-row-item').offsetWidth;

                // Function to scroll left
                function scrollLeft() {
                    container.scrollLeft -= itemWidth;
                }

                // Function to scroll right
                function scrollRight() {
                    container.scrollLeft += itemWidth;
                }

                // Attach event listeners to the buttons
                scrollLeftButton.addEventListener('click', scrollLeft);
                scrollRightButton.addEventListener('click', scrollRight);
            </script>--%>
            <script>
                // Get the container and the buttons
                var container = document.getElementById('divlistidols');
                var scrollLeftButton = document.getElementById('scrollLeft');
                var scrollRightButton = document.getElementById('scrollRight');

                // Calculate the width of the items in the container
                var itemWidth = container.querySelector('.slideGroup').offsetWidth;
                var autoScrollGP = true;
                // Function to scroll left
                function scrollLeft() {
                    /*container.scrollLeft -= itemWidth + 13.5;*/
                    /*container.scrollLeft -= itemWidth * 4;*/
                    container.scrollLeft -= itemWidth * itemWidth;
                }

                // Function to scroll right
                function scrollRight() {
                    // Check if we're at the end and if so, scroll back to the start
                    if (container.scrollLeft + container.offsetWidth >= container.scrollWidth) {
                        container.scrollLeft = 0;
                    } else {
                        /*container.scrollLeft += itemWidth +13.5;*/
                        /*container.scrollLeft += itemWidth * 4;*/
                        container.scrollLeft += itemWidth * itemWidth;
                    }
                }

                // Attach event listeners to the buttons
                scrollLeftButton.addEventListener('click', scrollLeft);
                scrollRightButton.addEventListener('click', scrollRight);

                //// Set up the automatic scrolling
                //setInterval(function () {
                //    scrollRight();
                //}, 4000);

                var autoScrollIntervalGP = setInterval(function () {
                    if (autoScrollGP) {
                        scrollRight();
                    }
                }, 3000);

                // Stop automatic scrolling when mouse enters the container
                container.addEventListener('mouseenter', function () {
                    autoScrollGP = false;
                });

                // Resume automatic scrolling when mouse leaves the container
                container.addEventListener('mouseleave', function () {
                    autoScrollGP = true;
                });

            </script>

        </div>
    </section>

   

  

    <section class="py-5 d-flex content-itens">
        <div id="divProducts" class="container px-4 px-lg-5 mt-0 fade-in" style="background: linear-gradient(to bottom, #1111117f, #242426); padding:40px 10px 0px 10px; border-radius: 10px; /*box-shadow:0px 0px 20px #636363;*/">

            <h3 id="SP" class=" text-left lnr-text-size" style="position:absolute; top:-20px;">
                <p class="">Danh mục sản phẩm</p>
            </h3>
            <style>
                .flex-container {
                    display: flex;
                    flex-wrap: nowrap; /* Đảm bảo tất cả các mục nằm trên cùng một hàng */
                    overflow-x: auto; /* Cho phép cuộn ngang nếu cần */
                    scroll-behavior: smooth;
 
    
                }
                .flex-container:hover::-webkit-scrollbar-thumb{
                    background:linear-gradient(to left, #522A77,#0000);
                }
                .flex-container::-webkit-scrollbar {
}

                .flex-container::-webkit-scrollbar-track {
                  background:#00000000;
                  border-radius: 10px;
                }
                .flex-container:hover::-webkit-scrollbar-track {
  
                  background:#0000007f;
                }

                .flex-container::-webkit-scrollbar-thumb {
                  border-radius: 10px; /* Bán kính góc của thanh cuộn con trỏ */
                  background:linear-gradient(to left, #522a7700,#0000);
                }

                .flex-container.col {
                    flex: 0 0 auto; /* Không cho phép các mục tự dãn */
                    margin-right: 1rem; /* Tạo khoảng cách giữa các mục */
                }

            </style>
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left flex-container">
                <asp:ListView ID="ListView2" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetSanPham">
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <div class="col mb-5 fade-in divSPLS">
                            <a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">
                                <!-- Product image-->
                                <img title="<%#:Item.TenSP%>"  loading="lazy" class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content;" />

                                <!-- Product details-->
                                <div class="card-body p-4">
                                    <div class="text-center">
                                        <!-- Product name-->
                                        <h5 class="fw-bolder"><%#:Item.TenSP%></h5>
                                    </div>
                                </div>
                                <!-- Product actions-->
                                <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                                    <!-- Product price-->
                                    <p class="text-center"><%# string.Format("{0:N0}", Item.Gia) %>đ</p>
                                                                        <div class="text-center d-flex justify-content-center" style="gap:1rem;">
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
                                        <script>
                                            $(document).ready(function () {
                                                $('.btn-mua').click(function () {
                                                    var url = $(this).data('href');
                                                    window.location.href = url;
                                                });
                                            });
                                        </script>
                            
                            <%-- <button class="btn btn-outline-dark mt-auto btn-mua" style="background:#fff; color:#000;" type="button" data-href="item.aspx?sp=<%#:Item.MaSP%>">Mua</button>
                             <asp:ImageButton ID="btnCart" CommandArgument='<%#:Item.MaSP%>' runat="server" Style="width: 57.5px; height:37.5px; background:#fff;" OnClick="btnCart_Click" class="btn btn-outline-dark flex-shrink-0 btn-gio  btn-gio-card" ImageUrl="~/Content/icon/sz-add-cart.png" />--%>
                             <asp:Button ID="btnCart" CommandArgument='<%#:Item.MaSP%>' runat="server" Style="font-size:small; width: 145.5px; height:37.5px; background:#fff;" OnClick="btnCart_Click" class="btn btn-outline-dark flex-shrink-0 btn-gio btn-gio-card btn-bold btn-at-sp-hover" Text="THÊM VÀO GIỎ" title="Thêm sản phẩm này vào giỏ hàng"/>

            
                                       </div>

                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                           <style>

                                .btn-bold{
                                     font-weight:bold;
                                 }

                               .btn-at-sp-hover:hover{
                                    color:#FFFF !important;
                                    background:#000 !important;
                                     box-shadow:0 0 50px #636363;
                                }
                                .btn-at-sp-hover{
                                    transition:0.5s;
    
                                }



                               #scrollLeftSP:hover, #scrollRightSP:hover {
                                   background:#636363;
                               }
                           </style>
                <style>
                    #divProducts:hover #scrollLeftSP, #divProducts:hover #scrollRightSP{
                        display:block;
                    }
                    #scrollLeftSP, #scrollRightSP{
                        display:none;
                    }
                </style>
                          <a  id="scrollLeftSP" class="carousel-control-prev justify-content-center align-content-center" style="margin:auto; height:max-content; padding:30px 10px 30px 5px; position:absolute; background:#6363637c; width:max-content; border-bottom-right-radius:50px; border-top-right-radius:50px;">
                             <span class="carousel-control-prev-icon fade-left" aria-hidden="true"></span>
                             <span class="visually-hidden">Previous</span>

                         </a>
                         <a id="scrollRightSP" class="carousel-control-next justify-content-center align-content-center"  style="margin:auto; height:max-content; padding:30px 5px 30px 10px; position:absolute; background:#6363637c; width:max-content; border-bottom-left-radius:50px; border-top-left-radius:50px;">    
     
                             <span class="carousel-control-next-icon fade-right" aria-hidden="true"></span>
                             <span class="visually-hidden">Next</span>

                         </a>       
                
                 <script>
                     // Get the container and the buttons
                     var containerSP = document.querySelector('.flex-container');
                     var scrollLeftButtonSP = document.getElementById('scrollLeftSP');
                     var scrollRightButtonSP = document.getElementById('scrollRightSP');

                     // Calculate the width of the items in the container
                     var itemWidthSP = containerSP.querySelector('.divSPLS').offsetWidth;

                     // Variable to control automatic scrolling
                     var autoScroll = true;

                     // Function to scroll left
                     function scrollLeftSP() {
                         containerSP.scrollLeft -= itemWidthSP * 2;
                     }

                     // Function to scroll right
                     function scrollRightSP() {
                         // Check if we're at the end and if so, scroll back to the start
                         if (containerSP.scrollLeft + containerSP.offsetWidth >= containerSP.scrollWidth) {
                             containerSP.scrollLeft = 0;
                         } else {
                             containerSP.scrollLeft += itemWidthSP *2 /*+ 1*/ ;
                         }
                     }

                     // Attach event listeners to the buttons
                     scrollLeftButtonSP.addEventListener('click', scrollLeftSP);
                     scrollRightButtonSP.addEventListener('click', scrollRightSP);

                     // Set up the automatic scrolling
                     var autoScrollInterval = setInterval(function () {
                         if (autoScroll) {
                             scrollRightSP();
                         }
                     }, 3000);

                     // Stop automatic scrolling when mouse enters the container
                     containerSP.addEventListener('mouseenter', function () {
                         autoScroll = false;
                     });

                     // Resume automatic scrolling when mouse leaves the container
                     containerSP.addEventListener('mouseleave', function () {
                         autoScroll = true;
                     });
                 </script>



            </div>
            <style>
               .tenSP-ls-h6 {
                   font-size: 1.5rem;
                   font-family: Roboto;             
                            
               }                      

            </style>
            <a href="Item.aspx">
                <h6 id="more" class="tenSP-ls-h6">

                    

                    <p class="tenSP-ls-p" style="border-bottom-color: #0000;color:#fff;">
                        Xem thêm
                    </p>
                </h6>
            </a>
        </div>
        <style>
            .embed-responsive {
                border-radius: 10px; /* Điều chỉnh độ tròn của iframe */
                overflow: hidden; /* Đảm bảo rằng iframe được làm tròn */
            }

            .embed-responsive-16by9::before {
                padding-top: 56.25%
            }

            .embed-responsive {
                position: relative;
                display: block;
                width: 100%;
                padding: 0;
                overflow: hidden
            }

                .embed-responsive::before {
                    display: block;
                    content: ""
                }

                .embed-responsive .embed-responsive-item, .embed-responsive embed, .embed-responsive iframe, .embed-responsive object, .embed-responsive video {
                    position: absolute;
                    top: 0;
                    bottom: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                    border: 0
                }

                .embed-responsive-item, .embed-responsive embed, .embed-responsive iframe, .embed-responsive object, .embed-responsive video {
                    position: absolute;
                    top: 0;
                    bottom: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                    border: 0
                }
        </style>

        <%-- <!-- CSS của Bootstrap -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">--%>

        <!-- JavaScript của Bootstrap và jQuery (Bootstrap đòi hỏi jQuery) -->



    </section>

   <section class="py-5 sc-spChoice" style="max-width:1531px; margin:auto; background:#242426;">
            <style>
                /*section{
                    background-color:#eaeaf5 !important;
                }*/

                .sc-spChoice .container {
                        --bs-gutter-x: 0;
                }
                #scrollNextBodyImgHomme2, #scrollPreviousBodyImgHomme2 {
                    display: none;
                }

                #carouselExampleControlsSPChoice:hover #scrollNextBodyImgHomme2,
                #carouselExampleControlsSPChoice:hover #scrollPreviousBodyImgHomme2 {
                    display: block;
                }

              /*  .divSPChoice * {
                    padding: 0 !important;
                    margin: 0 !important;
                    width: max-content;
                    height: max-content;
                    object-fit: cover;
                    border:none !important;
                     border-radius:10px !important;
                }*/
              
               .divSPChoice *{
                   justify-content:center;
                    align-content:center;
                    align-items:center;
                    justify-items:center;
               }
               .divSPChoice h3{
                   padding-top:10px;
                 
               }
                .divSPChoice {
                    padding: 0 !important;
                    margin: 0 !important;
                    background-color: #000;
                   border-radius:10px !important;
                   
                   justify-content:center;
                   align-content:center;
                   align-items:center;
                   justify-items:center;
                    
                   margin:auto;
                  
                }
                 #carouselExampleControlsSPChoice .col-sm-6{
                     flex: 0 auto;
                 }
               /* .spChoice-ing{
                   height:250px !important;
                }*/
               /* .divSPChoice table tr th{
                   width:350px;
                 
                }*/
                
                .carousel-caption {
                    color: white;
                    text-align: left;
                    background: linear-gradient(to right, #9b51e0, #fff);
                    width: max-content;
                    margin-left: -10rem;
                    font-family: 'Baloo', sans-serif;
                    -webkit-background-clip: text;
                    -webkit-text-fill-color: transparent;
                }

                
                @keyframes backgroundDMSPLQ {
                    0% {background-position: left;}
                    50% {background-position: right;}
                    100% {background-position: left;}
                }

                #spHot, #spLike, #spNew, #spRating{
   
                     background-size: 200% auto;
                     animation: backgroundDMSPLQ 5s ease infinite;
                }





                #spHot{
                    background-color:orangered; 
                    background-image:linear-gradient(to left, #d5c03e, #e81717, #d5c03e);
                }
                #spLike{
                    background-color:hotpink; 
                    background-image:linear-gradient(to left, #d338d7, #804cdeff, #d338d7);
                }
                #spNew{
                    background-color:orange;
                    background-image:linear-gradient(to left, orange, #d53e3e, orange);

                }
                 #spNew{
                   

                 }
                #spRating{
                    background-color:black;
                    background-image:linear-gradient(to left, #804cdeff, #e23939, #804cdeff);

                }
                #spRating *{
                   /* color:yellow !important;*/
              
                }
                 #spRating *, #spHot *, #spLike *, #spNew *{
               
                       text-shadow:0 0 20px #fff;
                 }
                
                @media only screen and (min-width: 768px) {
                 .div-text-spChoice{
                     width:400px;
                     
                 }
                    .carousel-caption h3 {
                        font-size: 4.5rem;
                        margin-bottom: 1rem;
    
                    }

                    .carousel-caption p {
                        font-size: 3.25rem;
                    }
                     .divSPChoice img{
                         width:64px !important;
                     }
                       .divSPChoice {
                          display:flex;height:220px;
                      }
                       #carouselExampleControlsSPChoice{
                           padding:2.5rem 15px 0 15px;
                       }
                       .div-dmsplq{
                           height:250px;
                       }
                
                }
                @media only screen and (max-width: 768px) {
                    #carouselExampleControlsSPChoice{
                        padding:2.5rem 15px 0 15px;
                    }

                      .divSPChoice {
                        display:grid;height:140px;
                        width:50%;
                    }
                     .divSPChoice h3 {
                            font-size: 14px;
                            margin-bottom: 0;
    
                        }

                        .divSPChoice p {
                            font-size: 12px;
                        }
                         .divSPChoice img{
                         width:44px !important;
                     }

                    }
            </style>
            <div id="carouselExampleControlsSPChoice" class="carousel slide  px-4 px-lg-5  mt-0 container" data-bs-ride="carousel" style="background: linear-gradient(to bottom, #1111117f, #242426); border-radius:10px;">
                <h3 id="SPLQ" class=" text-left lnr-text-size" style="position:absolute; top:-20px;">
                     <p class="">Danh mục sản phẩm liên quan</p>
                 </h3>
                <a id="scrollPreviousBodyImgHomme2" class="carousel-control-prev" href="#carouselExampleControlsSPChoice" role="button" data-bs-slide="prev" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 10px 30px 5px; border-bottom-right-radius:10rem; border-top-right-radius:10rem;">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a id="scrollNextBodyImgHomme2" class="carousel-control-next" href="#carouselExampleControlsSPChoice" role="button" data-bs-slide="next" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 5px 30px 10px; border-bottom-left-radius:10rem; border-top-left-radius:10rem;">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                <ol class="carousel-indicators">
                    <li data-bs-target="#carouselExampleControlsSPChoice" data-bs-slide-to="0" class="active"></li>
                    <li data-bs-target="#carouselExampleControlsSPChoice" data-bs-slide-to="1"></li>
                </ol>
                <div class="carousel-inner d-flex div-dmsplq" style="">
                    <div class="carousel-item active">
                        <div class="d-flex" style="gap:10px;">
                            <a href="Item.aspx?sp=toprate" id="spRating" class="col-sm-6 divSPChoice">
                                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAACXBIWXMAAAsTAAALEwEAmpwYAAAIhElEQVR4nO1bDXMTxxn2/yhpp3+g/6MJnTBNnLSdTqbFdzIQ45hpWiAmhK+Yxl8QiBNjMKkN00LaJCYFk9IZAimDAw6U2AnIlu5OgsYytuUP2ZJ272Ofzp4sI0sn3Z50xi7lnXlmNLq73fd59t3bvXd3q6qe2lNztLsE6++lcXMkDTpKgdAiwotQKKAuQtMziOQgmoNIHrQSiAiWk70/64OS41vWV+53MA0zmMZwkKLaE/kRAnDkk1dyyOc77eSsE8ms004oJUqp8rMiKA4icB7BNNg9gheFBBhJYzCXvFurlyKdT1ARQClR8sUQiYYcEe6ICpBwI5/rSLGwdCIcFkApQZyEyK2/lAjBNNJCAowS3HQiX6zVnVogl7AWm0fs6gjip65hru0CUo1nQBp6QDefsMF/8//4NX7P2Jcj0MbnHQVxi8D8LpErwgjBLbEIIHjOjbxbH4yMJTDZdwupXWegB46VheSus5g8dwtaLFEgRqlocBIhRGCOEvysStTCBM+GCW6oBNRLyEXVOGZOXIa+qats4gWo7cLskYuIjk547pIqAQkTDIQJflpViT1IYl2Uor9Yq2tTqQzx2k7ogZXD7AeX7LqcokGlOH8/iR9UrZSFUnjGKbzGrodAGk6uKPFckIYP8f1AuCAaRpNYt2LkcwVYavmkhemeK9ADH6wK4r1XbR+yIqyoAKEUnlEpLmbJqwkdc4f+Dj3w/qoi0XoOyhzNitBftggKwfrFlx4p9rZfIj+nY77p41Unn8X8wY+hJPSCUctpdFh8KX6lEDz3qHUJNoQJrGLDXX7YZ1q+Y00h0dqHcNJ0FMFpeOR8QwTP2wKECW6Xeij3hTfdcxl64L01iXjvFcfJW1E+BLez4U/cFOMPjA2EVp2kG8aujbhO4HKiIJ0VYMhNLW0qCdLAJyZHfIF5rB+YS9owOy/4Vi55rRPa5IJQFITJ4seRSlGtUrBSoT9z/B/QA+/6g7oOIEmwZEli/+dX+TPdl1y7AuerELyw9CLkImg6hiMURr4A98MPodcehh7wB+bxfuSb2dXvW/nc16g66TwqUBiajqFILnk30wPtfzMC7fAL7BulQAB2J+xb+RyznedzkzjlT5HTUsuPdbnNMgJt8AXbOgDDLBAApmVf862e2nZosTlbgIpmiHqg+S0j0AK/YJ2+hGLGr/lZ18RnA5ULYMjvjBhyM/wCG31QVAB+zc+6Um92Z3OD5U2REfjjDw35HfgFc2cnwFhRAfg1Y0enb/VxaOOZbmDPYglM/qKPimaIaU3Tbw35IHzBtsNg32nFyWc1+Fa17/Wr3tiXw4UTIz7ki2SIDbnpPUNughB2dIBdHwILRsAiMbBoDGxixgYWUqVb3iES+DPZ5+2yeJm87OtDdl2ifsVPX7K7gcN8wD1DbEoH/mnKByACpn6Px2VM+Y+QTxzz7X9etqaxJAAVyBAb8n7FlPdDBNCNxyYACBXyiSP9RscyAbJRENUFMsSGvC9uyvsgAvbF4GPjzy4PCvnEQbe1FgigUphRkQyxIe+hprwHQgjsgXXmoj2hWTGzLLDPrsCs3Svmk7wHxub9jwQgIArBgGYIZogN+U1qyrvhBVbTMWBi2n/y8VlYzd2efOEwpN1EiGzEwHqNZlJi2S9A2vA2THmXd9QfALs55Bt39u+7MMv0xZAaJ13JawQbIhRW/idwemcbTLmxbFhnL3gb/gqYM7uMSnww5MaQe+vruM2/k/MFWGjthiXvrAjsXrh8/ndDFddvyTs+dxeAguQmQpaSIKf6YMnbKwL7uvyuwAa/qbh+S9r+rnsX0DHklAkavzIIS/59+ahrBNLpsgVAmsDauqsiH0zp9VdcBYhSVEcWU2K5AkTGZ2DJvysbrOej8slno6DnbEU+QPqD2FdgdDElplEYy16EjQdhSdvKAtRoxQJAjZRdvyk1fFdVjo0msY4vM3EBpj79HJbU4B17W9zJmWYGLsbLKscHU2p4o6qStUCFd4NYHJb8Giyp3hPYF/8qzohSsE/Pw3r1dRv8N/+vmPGyvNZvSvUmNm75UcUChCmQ6DgBS6rzBMzPO5O5dQfW9t2Fz2zfbV9ztMS85/qtmrq/VEr+YlaA+8oDMPlVMGmLMDAVX05i/CHYoaPuzx46at+7zCYmPdVtSVsYajb/xBNpjeIXmo5vIxSm08LI3PE/gUmbxNF2GJicBGZnwT7pA9tUJ/4sv/eTPvtZm3xru6e6Z0/2On4CaxluhSkxleJlt5UhLZ6AWd8AJgXWNLiP6lSi5MoQT4kpuSkxhWBYZGU4NvA1mCSvacSu3XBs/XxeSnZd0MvqsD097ukFkzauSUz3nnYOfWcBHqXEvOwPUFImFtrbwKTfrCkstDQjnDTE9wfkbpoMETwvukPELjyRRurtvWDSK2sCqaZ9tk8iob/Y+qaSnxILZzZGDojsEcqIQLDQ3gwm/XpVsdByEMpccfLLBKCZlFhZmyZHk1inUvQv24ObNDDT0w0m/XJVMN37IcIp0ynpuTIbJkN5+wSz/S12/TqsrRuBmpcfC8z6GowNDDjuZuf+rdh+wVCRnaIc6vQ8Zk6dBKSXgJrqlYH0EhJdR6HGZ4uS5+DbeleEfITiYqkd4pnN0lEkuo4AMnf6BX8gvYiFQ02IhpQC4o7DHUV/xSIoDhsnvRxQ0GITiPd9BNpYB9RsKAt011ZMnfsrtPEJ1zNLjv5RUJXg5rJNkUKtTbAhRGBVcl5gmRjjkxi/ehkzp7qQbH0LdOcmmPW/Aqv9uQ3+m//Hr/F7+L3aw6kC0pWcF+CjnLAAIwS3/Twxkn+aSwTFjtCUfWKE4IawAME0yBN3ZoggIR4BaQw9aafGgmkvEUBRzc/ZPSnnBjmXoNfZXzAjwvBIGsb/7MlRAhok+Moz+af21Kr+b+y/2TvMC1uOsJ8AAAAASUVORK5CYII=">
                                <div class="d-grid div-text-spChoice">
                                <h3>Sản phẩm được đánh giá cao</h3>
                                <p>Những sản phẩm được đánh giá cao</p></div>
                            </a>
                            <a href="Item.aspx?sp=popular" id="spLike" class="col-sm-6 divSPChoice">
                                <img src="data:image/png;base64,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">
                                <div class="d-grid div-text-spChoice"> 
                                <h3>Sản phẩm được yêu thích</h3>
                                <p>Những sản phẩm được yêu thích!</p></div>
                            </a>
                           
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="d-flex"  style="gap:10px;">
                            <a href="Item.aspx?sp=hot" id="spHot" class="col-sm-6 divSPChoice">
<img src="data:image/png;base64,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">                                
                                
                                <div class="d-grid div-text-spChoice">
                                <h3>Sản phẩm hot nhất</h3><p>Những sản phẩm hot nhất!</p></div>
                            </a>
                            <a href="Item.aspx?sp=new" id="spNew" class="col-sm-6 divSPChoice">
                                <img src="data:image/png;base64,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">

                                <div class="d-grid div-text-spChoice">
                        <h3>Sản phẩm mới nhất</h3><p>Những sản phẩm mới nhất!</p></div>
                    </a>
                            
                        </div>
                    </div>
                </div>
            </div>
        </section>

    <section class="py-5">
        <div id="carouselExampleControlsRoom" data-bs-ride="carousel" class="carousel slide container px-4 px-lg-5 mt-0 fade-left" style="background: linear-gradient(to bottom, #1111117f, #242426); border-radius: 10px; 
/*box-shadow:0 0 20px #9b51e0; */ padding:0 2rem">
            <h3 id="MAP" class=" text-left lnr-text-size" style="position:absolute; top:-20px;">
                  <p class="">Danh mục địa chỉ cửa hàng</p>
              </h3>
            <style>
                #scrollNextBodyImgHomme1,#scrollPreviousBodyImgHomme1{
                    display:none;
                }
                #carouselExampleControlsRoom:hover #scrollNextBodyImgHomme1,#carouselExampleControlsRoom:hover #scrollPreviousBodyImgHomme1{
                    display:block;
                }
            </style>

                <a id="scrollPreviousBodyImgHomme1" class="carousel-control-prev" href="#carouselExampleControlsRoom" role="button" data-slide="prev" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 10px 30px 5px; border-bottom-right-radius:10rem;  border-top-right-radius:10rem;">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a id="scrollNextBodyImgHomme1" class="carousel-control-next" href="#carouselExampleControlsRoom" role="button" data-slide="next" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 5px 30px 10px; border-bottom-left-radius:10rem;  border-top-left-radius:10rem;">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleControlsRoom" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleControlsRoom" data-slide-to="1"></li>
                    <%--        <li data-target="#carouselExampleControlsRoom" data-slide-to="2"></li>--%>
                    <%-- <li data-target="#carouselExampleControlsBranch" data-slide-to="3"></li>
        <li data-target="#carouselExampleControlsBranch" data-slide-to="4"></li>--%>
                    <%--<li data-target="#carouselExampleControlsBranch" data-slide-to="5"></li>
        <li data-target="#carouselExampleControlsBranch" data-slide-to="6"></li>--%>
                </ol>
                <div class="carousel-inner  fade-in" style="padding:20px 0 0 0;  /*box-shadow:0 0 20px #636363;*/">
                    <div class="carousel-item active border-cs-item">
                        <style>
                            .border-cs-item img{
                                border-radius:10px;
                            }
                            .carousel-caption {
                                color: white;
                                text-align: left;
                                background: linear-gradient(to right,#9b51e0, #fff);
                                width: max-content;
                                margin-left: -10rem;
                                font-family: 'Baloo', sans-serif;
                                -webkit-background-clip: text;
                                text-fill-color: transparent;
                                -webkit-text-fill-color: transparent;
                            }

                                .carousel-caption h3 {
                                    font-size: 4.5rem;
                                    margin-bottom: 1rem;
                                }

                                .carousel-caption p {
                                    font-size: 3.25rem;
                                }
                        </style>
                        <div class="itemMap">
                        <%--<img loading="lazy" src="Content\image-branch\1.png" class="d-block w-100" alt="Background Image 1">--%>
                           <ul class="rotateulMap" style="">
                               <li><h3>Chi nhánh Hà Nội</h3></li>
                               <li><p>Địa chỉ: Số 4B Phố Hàng Bài, P. Tràng Tiền, Q. Hoàn Kiếm, Hà Nội</p></li>

                           </ul>
                        <iframe class="col-sm-4 " style="height:400px; width:100%;  padding:0 10px; justify-content:center; justify-items:center; clip-path: polygon(50% 0%, 100% 0, 100% 100%, 0 100%);" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.206404441712!2d105.85310919999999!3d21.024425699999995!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135abeca85765eb%3A0x182717ff5916baf7!2zNEIgUC4gSMOgbmcgQsOgaSwgVHLDoG5nIFRp4buBbiwgSG_DoG4gS2nhur9tLCBIw6AgTuG7mWksIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1720275140863!5m2!1svi!2s" width="600" height="450" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                        </div>
                    </div>
                    <div class="carousel-item border-cs-item">
                        <div class="itemMap">
                         <ul class="rotateulMap" style="">
                           <li><h3>Chi nhánh Hồ Chí Minh</h3></li>
                           <li><p>Địa chỉ: Số 172 Đường Số 1 Q.Bình Tân</p></li>

                       </ul>
                    <iframe class="col-sm-4 " style="height:400px; width:100%;  padding:0 10px; justify-content:center; justify-items:center; clip-path: polygon(50% 0%, 100% 0, 100% 100%, 0 100%);" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.8166319136185!2d106.61648179999997!3d10.748611300000002!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752dcd68c5a1a3%3A0xef240e1eb6bb8965!2zMTcyIMSQLiBT4buRIDEsIELDrG5oIFRy4buLIMSQw7RuZyBCLCBCw6xuaCBUw6JuLCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1720275296910!5m2!1svi!2s" width="600" height="450" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </div>
                    </div>

                    <!-- Thêm các ảnh khác vào đây -->
                </div>
            </div>
        
    </section>
    <%--<section class="py-5">
        <div class="container px-4 px-lg-5 mt-0">
             <style>
                 #scrollNextBodyImgHomme2,#scrollPreviousBodyImgHomme2{
                     display:none;
                 }
                 #carouselExampleControlsBranch:hover #scrollNextBodyImgHomme2,#carouselExampleControlsBranch:hover #scrollPreviousBodyImgHomme2{
                     display:block;
                 }
             </style>
            <div id="carouselExampleControlsBranch" class="carousel slide" data-bs-ride="carousel">
                <a id="scrollPreviousBodyImgHomme2" class="carousel-control-prev" href="#carouselExampleControlsBranch" role="button" data-slide="prev" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 10px 30px 5px; border-bottom-right-radius:10rem;  border-top-right-radius:10rem;">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a id="scrollNextBodyImgHomme2" class="carousel-control-next" href="#carouselExampleControlsBranch" role="button" data-slide="next" style="margin:auto; background:#636363; width:max-content; height:max-content; padding:30px 5px 30px 10px; border-bottom-left-radius:10rem;  border-top-left-radius:10rem;">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleControlsBranch" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleControlsBranch" data-slide-to="1"></li>

                </ol>
                <div class="carousel-inner" style="border-radius:10px; box-shadow:0 0 20px #636363;">
                    <div class="carousel-item active d-flex" style="padding:10px; gap:1rem">
                        <style>
                            .carousel-caption {
                                color: white;
                                text-align: left;
                                background: linear-gradient(to right,#9b51e0, #fff);
                                width: max-content;
                                margin-left: -10rem;
                                font-family: 'Baloo', sans-serif;
                                -webkit-background-clip: text;
                                text-fill-color: transparent;
                                -webkit-text-fill-color: transparent;
                            }

                                .carousel-caption h3 {
                                    font-size: 4.5rem;
                                    margin-bottom: 1rem;
                                }

                                .carousel-caption p {
                                    font-size: 3.25rem;
                                }
                        </style>
                        <div style="width:50%;">
                        <div class="carousel-caption d-none d-md-block">
                            <h3>Hồ Chí Minh</h3>
                        </div>
                        <img loading="lazy" src="Content\image-branch\3.png" class="d-block" style="width:100%" alt="Background Image 1">
                        </div>
                        <div>
                            <style>                                
                                table *{
                                    border:none;
                                    width:max-content !important;
                                    padding:10px;
                                }

                            </style>
                            <table class="" style="">
                                <tr>
                                    <th>Chi nhánh:</th>
                                    <th>Hồ chí minh</th>
                                </tr>
                                <tr>
                                    <th>Địa chỉ:</th>
                                    <th>736 Nguyễn Trãi, Quận 5, TP.HCM</th>
                                </tr>
                                <tr>
                                    <th>Hoạt động từ:</th>
                                    <th>8 giờ sáng đến 6 giờ chiều</th>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="carousel-caption d-none d-md-block">
                            <h3>Hà Nội</h3>
                        </div>
                        <img loading="lazy" src="Content\image-branch\4.png" class="d-block w-100" alt="Background Image 2">
                    </div>
                 
                </div>
            </div>
        </div>
    </section>--%>

    <section id="scInformation" class="py-5 d-flex content-itens" style="background: linear-gradient(to bottom, #242426, #000);">
        <div class="container px-4 px-lg-5 mt-0 fade-in divInfo" style="padding:2.5rem 0 1rem 0; background: linear-gradient(to bottom, #1111117f, #24242600); border-radius: 10px; /*box-shadow:0 0 20px #9b51e0; */">
            <h3 id="INFO" class=" text-left lnr-text-size" style="position:absolute; top:-20px;">
                <p class="">Danh mục thông tin và nội dung</p>
            </h3>
            <%--<h3 id="TS" class="tenSP-ls-h3">
     <p class="tenSP-ls-p">Thịnh hành</p>
 </h3>--%>
            <!-- Video lớn ở trên -->

         

            <div class="divInfo-content" style="">
                 <asp:FormView ID="InformationVideo" runat="server" ItemType="TH03_WebBanHang.Models.VideoThongTin" SelectMethod="GetVideoInformation" RenderOuterTable="false" OnPageIndexChanging="InformationVideo_PageIndexChanging">
              <ItemTemplate>
                  <div title="Video thông tin mới đây" class="embed-responsive embed-responsive-16by9 mb-3 fade-in video-if">
                        <iframe loading="lazy" class="embed-responsive-item" src="<%#: Item.DuongDanV %>" allowfullscreen></iframe>
                    </div>
              </ItemTemplate>

          </asp:FormView> 
                <div class="row">
                 <asp:ListView ID="ListView4" runat="server" ItemType="TH03_WebBanHang.Models.VideoThongTin" SelectMethod="GetVid">
     <ItemTemplate>
                     <div title="Video thông tin gần đây" class="col-6">
                         <div  class="embed-responsive embed-responsive-16by9 mb-3 fade-in video-if">
                             <iframe loading="lazy" class="embed-responsive-item" src="<%#: Item.DuongDanV %>" allowfullscreen></iframe>
                         </div>
                     </div>
         </ItemTemplate></asp:ListView></div>

            </div>
            <div class="fade-in divInfo-content" style="">
                <style>
                    .video-if {
                        background-color: darkgray;
                        transition:0.5s;
                        border-radius:10px !important;
                    }
                    .video-if:hover {
                        box-shadow: 0 0px 20px #636363;
                    }
                    #div-list-end li {
                        border: 4px solid #522A77;
                        padding: 5px;
                        border-radius: 10px;
                        width: 8rem;
                        text-align: center;
                        margin: 0 0.5rem;
                    }

                        #div-list-end li a {
                            color: #9b51e0;
                        }

                        #div-list-end li:hover a {
                            color: #542480;
                        }
                    /* #div-tin li a img{
                                            width:100%;
                                            height:100%;
                                        }*/

                    #div-tin li {
                        margin-bottom: 2.5rem;
                        height: 100px;
                    }

                    .text-container {
                        max-height: 100px;
                        overflow: hidden; /* Ẩn phần văn bản vượt quá kích thước */
                        text-overflow: ellipsis; /* Thêm dấu chấm (...) khi văn bản bị cắt bớt */
                    }

                    #div-tin a {
                        display: flex;
                        align-items: flex-start; /* Đảm bảo rằng vị trí x của chữ và hình ảnh bằng nhau */
                        color: #fff;
                        font-size: large;
                    }

                        #div-tin a p {
                            width: 100%;
                            padding-left: 1rem;
                            position: relative;
                            top: 0;
                        }

                    .image-container {
                        height: 100px; /* Kích thước cố định */
                        width: 256px; /* Kích thước cố định */
                        overflow: hidden; /* Ẩn phần nằm ngoài khung */
                    }

                        .image-container img {
                            width: 100%; /* Chiều rộng của ảnh fill toàn bộ phần tử chứa */
                            height: 100%; /* Chiều cao của ảnh fill toàn bộ phần tử chứa */
                            object-fit: cover; /* Hiển thị ảnh sao cho vừa khung */
                        }
                </style>
                <script>
                                               window.addEventListener('DOMContentLoaded', (event) => {
                           const images = document.querySelectorAll('.image-container img');
                           if (images.length > 0) {
                               const firstImage = images[0];
                               const firstImageWidth = firstImage.width;
                               const firstImageHeight = firstImage.height;

                               images.forEach(img => {
                                   img.style.width = `${firstImageWidth}px`;
                                   img.style.height = `${firstImageHeight}px`;
                               });
                           }
                       });
                </script>
                <style>
                    #div-tin li{
                        transition:0.5s;
                        border-top:1px solid #636363;
                        
                    }
                     #div-tin li:hover{
                         
                         
                         border:none;
                         border-top:1px solid #9b51e0;
                         /*background:linear-gradient(to top, #0000, #522A77)*/
                         box-shadow:0 0 20px #636363;
                     }
                     #div-list-end li{
                          transition:0.5s;
                          padding-top:0.5rem;
                     }
                     #div-list-end li:hover {
                         
                         background:linear-gradient(to right, #0000, #522A77);
                         transform:translate(0, -10px);
                         box-shadow: 0 10px 50px #636363;
                     }
                </style>
                <ul id="div-tin" style="">
                     <asp:ListView ID="ListView3" runat="server" ItemType="TH03_WebBanHang.Models.TinTuc" SelectMethod="GetNews">
                         <ItemTemplate>
                              <li title="Tin tức" class="fade-in" style="">
                                 <a title="<%#:Item.TieuDe%>" href="<%#:Item.DuongDanBV%>" style="height:100%; object-fit:cover; overflow:auto;">
                                     <div class="image-container">
                                         <img loading="lazy" class="" src="<%#:Item.HinhAnhBV%>" />
                                     </div>
                                     <p><span class="text-container"><%#:Item.TieuDe%><br />
                                         <small><%#:Item.NoiDungBV%></small></span></p>
                                 </a>
                             </li>

                         </ItemTemplate>


                     </asp:ListView>


                </ul>
              
            </div>

        </div>

    </section>
    <style>
        #divscLast{
             background-image: url('Content/image-bg/lastK.gif') !important;
             
             position:relative;
             border-top:1px solid #000;
        }
        @media only screen and (min-width: 768px) {
              #divscLast{
                  background-size:contain;
                    background-repeat:no-repeat;
                  height:480px;
                 
             }
               .aP{
                   /*border-radius: 0 0 20px 20px;*/
               }
               .divInfo{
                   display:flex;
               }
               .divInfo-content{
                   width:50%;
               }
                

        }
        @media only screen and (max-width: 768px) {
            .divInfo{
                
            }

            .divInfo-content ul{
                padding-left:0;
            }

            #scInformation{
                 display:grid !important;
             }
            .video-container{
                display:grid;
            }
              #divscLast{
                  background-size:cover;
                    background-repeat:no-repeat;
                  height:280px;
         
             }
              #hr{
                  margin:0;
              }
               /*.aP{
                   border-radius: 0 0 20px 20px;
               }*/

        }
        section{
            border-right:1px solid #000 !important;
             border-left:1px solid #000 !important;
             max-width:1531px;
             margin:auto;
        }
    </style>

   <section style="height:max-content; width:100%; /*border-top:1px solid #636363;*/">
        
<%--            <img style="width:100%;" src="Content\image-bg\K.png"/>--%>
            <div id="divscLast" class=" bg-dark <%--fade-in--%> d-flex">
                <a id="aFacebook" title="Truy cập Facebook của chúng tôi" class="aP" href="#">
                    <i class="fa-brands fa-facebook fa-2xl"></i>
                    <p>Facebook</p>
                </a>
                <a id="aYoutube" title="Truy cập Youtube của chúng tôi" class="aP" href="#">
                    <i class="fa-brands fa-youtube fa-2xl"></i>
                    <p>Youtube</p>
                </a>
                <a id="aTiktok" title="Truy cập Tiktok của chúng tôi" class="aP" href="#">
                    <i class="fa-brands fa-tiktok fa-2xl"></i>
                    <p>Tiktok</p>
                </a>
                <a id="aInstagram" title="Truy cập Instagram của chúng tôi" class="aP" href="#">
                    <i class="fa-brands fa-instagram fa-2xl"></i>
                    <p>Instagram</p>
                </a>
                <style>
                  
                    #aFacebook:hover{
                        background: linear-gradient(to bottom, #000 , #4641c3ff, #4641c3ff , #000) ;
                    }
                    #aInstagram:hover{
                        background: linear-gradient(to bottom, #000 , #e26e13ff, #e26e13ff, #000);
                    }
                    #aTiktok:hover{
                        background: linear-gradient(to bottom, #000 , #431c4dff, #431c4dff, #000) ;
                    }
                    #aYoutube:hover{
                        background: linear-gradient(to bottom, #000 , #b53535ff, #b53535ff, #000);
                    }
                    .aP{
                        width:25%;
                        height:100%;
                        text-align:center;
                        justify-content:center;
                        align-content:center;
                        align-items:center;
                        justify-items:center;
                        background:#0000008a;
                        border-left:1px solid #000;
                        border-right:1px solid #000;
                        transition:0.5s;
                        
                      
                    }
                    .aP i{
                        margin:2rem auto;
  
                    }
                    .aP:hover{
                        /*background: linear-gradient(to top, #000 , #27006cff) ;*/
                    }
                    .aP p{
                      
                       color:#fff0;
                       
                       margin:auto;
                      
                      
                    }
                    .aP:hover p{
                         color:#fff;
                    }
                </style>
            </div>
        </section>
   
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</asp:Content>
