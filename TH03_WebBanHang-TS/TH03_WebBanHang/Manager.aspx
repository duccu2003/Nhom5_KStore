<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="TH03_WebBanHang.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" integrity="sha512-SnH5WK+bZxgPHs44uWIX+LLJAJ9/2PkPKZ5QiAj6Ta86w+fsb2TkcmfRyVX3pBnMFcV7oQPJkl9QevSCWr3W6A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <script type="text/javascript">
    //$(function () {
    //    $('.count').each(function () {
    //        $(this).prop('Counter', 0).animate({
    //            Counter: $(this).text()
    //        }, {
    //            duration: 3000,
    //            easing: 'swing',
    //            step: function (now) {
    //                $(this).text(Math.ceil(now));
    //            }
    //        });
    //    });
    //});
    $(function () {
        $('.count').each(function () {
            var originalText = parseFloat($(this).text().replace(/,/g, '')); // Chuyển đổi text sang số và loại bỏ dấu phẩy nếu có
            $(this).prop('Counter', 0).animate({
                Counter: originalText
            }, {
                duration: 3000,
                easing: 'swing',
                step: function (now) {
                    var formattedNow = Math.round(now).toLocaleString('en-US'); // Chuyển đổi số về chuỗi với định dạng số
                    $(this).text(formattedNow + "đ"); // Thêm "đ" vào kết thúc chuỗi
                }
            });
        });
    });
    $(function () {
        $('.countNum').each(function () {
            $(this).prop('Counter', 0).animate({
                Counter: $(this).text()
            }, {
                duration: 3000,
                easing: 'swing',
                step: function (now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
    });

</script>
    <style>
        *{
            transition:0.5s;
        }
        .textphantram{
            font-weight:bold;
            
            font-size:20px;
        }
        .row3-items {
            row-gap:10px;
            
            text-shadow:0 0  1px #000;
    
        }
        .row3-items .imgdiv{
            border-radius:50%;
            padding:10px;
            width:100px;
            height:100px;
            border:2px solid green;
           
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
            margin:auto;
            transition:0.5s all;
        }
        .row3-items:hover .imgdiv{
            transform:scale(1.1);
            border:none;
            padding:0px;
             
        }
        .row3-items .imgdiv img{
    
            width:100% !important;
            max-height:100% !important;
            height:auto;
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
            
        }
        @media only screen and  (max-width: 768px) 
        {
            *{
                padding:0;
                margin:0;
            }
            
            #listMenu,#listMenuContent{
                display:none !important;
                width:0 !important;
                position:relative;
            }
            .col-sm-10, .col-lg-4, .col-sm-4  , .col-lg-6, .col-sm-6, .col-md-3, .col-sm-3{
                flex: auto !important;
                width:100% !important;
            }
            .card{
                width:600px !important;
                margin:25px auto !important;
            }
            /*.col-sm-10, .col-lg-4, .col-sm-4  , .col-lg-6, .col-sm-6, .col-md-3, .col-sm-3{
                width:100%;
                margin:24px auto;
                justify-content:center;
                align-content:center;
                align-items:center;
                justify-items:center;
            }*/

            /*.row, .card{
                width:600px !important;
                margin:auto;
                justify-content:center;
                align-content:center;
                align-items:center;
                justify-items:center;
            }*/
            .col-sm-2{
                
            }
        }
        .table > :not(caption) > * > *, .datatable-table > :not(caption) > * > * {
            
            border-bottom-width: 2px !important;
           
        }


        ::-webkit-scrollbar {
            width: 5px;
        }

        ::-webkit-scrollbar-thumb {
            background: #5e17a2ff;
        }

        ::-webkit-scrollbar-track {
            background: #202020;
        }
        *{
            font-family:Roboto;
        }
    </style>
    <style>
        .nav-link:hover, .dropdown-item:hover{
            background:#000 !important;
            color:#fff !important;
            transform:scale(1.1);
            
        }
        .nav-link:hover *,.dropdown-item:hover *{
            color:#fff !important;
        }

        #loader {
            position: fixed;
            top: 0;
            left: 0;
            z-index: 99999;
            width: 100%;
            height: 100%;
            background-color: #FFFF;
            transition: all 0.3s ease-in-out;
            text-align: center;
            justify-content: center;
            align-content: center;
            align-items: center;
            justify-items: center;
            text-align: center;
        }

        .circle {
            justify-content: center;
            align-content: center;
            align-items: center;
            justify-items: center;
            text-align: center;
            height: 40px;
            margin: auto;
            position: relative;
            text-align: center;
            width: 40px;
            -webkit-animation: circle_dot 2.0s infinite linear;
            animation: circle_dot 2.0s infinite linear;
        }

        .circle1, .circle2 {
            height: 60%;
            display: inline-block;
            background-color: #6c38ef;
            border-radius: 100%;
            position: absolute;
            top: 0;
            width: 60%;
            -webkit-animation: circle_bounce 2.0s infinite ease-in-out;
            animation: circle_bounce 2.0s infinite ease-in-out;
        }

        .circle2 {
            bottom: 0;
            top: auto;
            -webkit-animation-delay: -1.0s;
            animation-delay: -1.0s;
        }

        @-webkit-keyframes circle_dot {
            100% {
                -webkit-transform: rotate(360deg)
            }
        }

        @keyframes circle_dot {
            100% {
                transform: rotate(360deg);
                -webkit-transform: rotate(360deg)
            }
        }

        @-webkit-keyframes circle_bounce {
            0%, 100% {
                -webkit-transform: scale(0.0)
            }

            50% {
                -webkit-transform: scale(1.0)
            }
        }

        @keyframes circle_bounce {
            0%, 100% {
                -webkit-transform: scale(0.0);
                transform: scale(0.0);
            }

            50% {
                -webkit-transform: scale(1.0);
                transform: scale(1.0);
            }
        }
    </style>
    <script src="https://code.jquery.com/jquery-latest.js"></script>
<script>
    var loader = function () {
        setTimeout(function () {
            $('#loader').css({ 'opacity': 0, 'visibility': 'hidden' });
        }, 1000);
    };
    $(function () {
        loader();
    });
</script>
</head>
<body style="background-color:#2424269b; overflow-x:hidden;">
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
    <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />
    <form id="form1" runat="server" class="d-flex"> 
        <section id="listMenu" class="col-sm-2" style="">
            <div id="listMenuContent" style="text-align:center; position: fixed; left:30px; top:5%; border-radius: 6px !important; height: max-content; width:15rem; background:#FFFF !important; padding:10px 5px;">
                <div style="width:100%; border-bottom:1px dashed #000; text-align:center">
                <h4>KS Manager Panel</h4>

                <p>Tài khoản: <asp:Label ID="lbAccountCheck" runat="server" CssClass="LabelTotalRevenue" Text="" Style="font-weight: bold;"></asp:Label></p>
                    <h6 id="time" style="color:#000; height:40px;"></h6>
                    <a class="dropdown-item" href="Default" style="margin:1rem auto; border-radius:50%; border:1px dashed #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;"><i class="fa-solid fa-arrow-left" style="margin-right: 5px; width: 35px;"></i></a>
                </div>
                <ul id="adminul" class="navbar-nav adminul" style="color: #000; height:100%;">

                <li class="nav-item"><a class="nav-link active dropdown-item" href="#Revenue"><i class="fa-solid fa-chart-column" style="margin-right: 5px; width: 35px;"></i>Quản lý doanh thu</a></li>
                <li class="nav-item"><a class="nav-link dropdown-item" href="ManagerOrder"><i class="fa-solid fa-boxes-stacked" style="margin-right: 5px; width: 35px;"></i>Quản lý đơn hàng</a></li>
              
                <li class="nav-item"><a class="nav-link dropdown-item" aria-current="page" href="ManagerAccount" style=""><i class="fas fa-user" style="margin-right: 5px; width: 35px;"></i>Quản lý tài khoản</a>
                    
                </li>
                <li class="nav-item"><a class="nav-link dropdown-item" href="ManagerProduct"><i class="fas fa-box" style="margin-right: 5px; width: 35px;"></i>Quản lý sản phẩm</a>
                    
                </li>
                <li class="nav-item"><a class="nav-link dropdown-item" href="ManagerGroup"><i class="fa-brands fa-artstation" style="margin-right: 5px; width: 35px;"></i>Quản lý nghệ sĩ</a>

                </li>

                           <li class="nav-item ">
                <a class="dropdown-item" href="UpdateInformation" style="color: #fff;"><i class="fa-solid fa-pager" style="margin-right: 5px; width: 35px;"></i>Quản lý nội dung</a>
                </li>

               <%-- <li class="nav-item"><a class="nav-link dropdown-item" href="ManagerBranch.aspx"><i class="fas fa-map-marker-alt" style="margin-right: 5px; width: 35px;"></i>Chi nhánh</a>
                    
                </li>--%>

                <li class="nav-item"><a class="nav-link dropdown-item" href="#"><i class="fa-solid fa-globe" style="margin-right: 5px; width: 35px;"></i>Quản lý liên kết</a>

                </li>
                <%--<li class="nav-item" style="border-bottom: 1px solid #fff; padding-top: 10px; text-align: center; padding-left: 1rem">
                    <h5>Thêm nội dung</h5>
                </li>
                <li class="nav-item">
                    <a class="dropdown-item" href="AddAccount.aspx" style="color: #fff;"><i class="fas fa-plus" style="margin-right: 5px; width: 35px;"></i>Thêm tài khoản</a>
                </li>

                <li class="nav-item ">
                    <a class="dropdown-item" href="AddProduct.aspx" style="color: #fff;"><i class="fas fa-plus" style="margin-right: 5px; width: 35px;"></i>Thêm sản phẩm</a>
                </li>
                <li class="nav-item">
                    <a class="dropdown-item" href="AddProduct.aspx" style="color: #fff;"><i class="fas fa-plus" style="margin-right: 5px; width: 35px;"></i>Thêm nghệ sĩ</a>
                </li>
                <li class="nav-item ">
                    <a class="dropdown-item" href="AddInformational.aspx" style="color: #fff;"><i class="fas fa-plus" style="margin-right: 5px; width: 35px;"></i>Thêm thông tin</a>
                </li>--%>
               <%-- <li class="nav-item" style="border-bottom: 1px solid #fff; padding-top: 10px; text-align: center; padding-left: 1rem">
                    <h5>Yêu cầu</h5>
                </li>--%>
                <%--    <li>
    <a class="dropdown-item" href="#" style="color: #fff;">Hỗ trợ, liên hệ</a>
</li>--%>

               <%-- <li class="nav-item ">
                    <a class="dropdown-item" href="#" style="color: #fff;"><i class="fa-solid fa-right-left" style="margin-right: 5px; width: 35px;"></i>Hoàn tiền, trả hàng</a>
                </li>--%>
                <%--  <li>
    <a class="dropdown-item" href="#" style="color: #fff;">Yêu cầu từ đối tác</a>
</li>--%>
                <li class="nav-item ">
                    <a class="dropdown-item" href="#" style="color: #fff;"><i class="fa-brands fa-servicestack" style="margin-right: 5px; width: 35px;"></i>Quản lý dịch vụ</a>
                </li>
                <li class="nav-item ">
                <a class="dropdown-item" href="#" style="color: #fff;"><i class="fa-solid fa-face-meh" style="margin-right: 5px; width: 35px;"></i>Quản lý khiếu nại</a>
            </li>

                        

                    <%--<li class="nav-item ">
    <a class="dropdown-item" href="Default" style="color: #fff;"><i class="fa-solid fa-house" style="margin-right: 5px; width: 35px;"></i>Quay về trang chính</a>
</li>--%>

            </ul>
                      <div style="margin-top:10px;">

                         <asp:Button ID="btnCPass" runat="server" Text="Đổi mật khẩu" OnClick="btnCPass_Click" CssClass="dropdown-item"  style="border:none; background:#FFFFFF; padding:5px 0;"/>
    <%--<a class="dropdown-item" href="#" style="color: #fff;"><i class="fa-solid fa-face-meh" style="margin-right: 5px; width: 35px;"></i>Quản lý khiếu nại</a>--%>

          

       <asp:Button ID="btnSignOut" runat="server" Text="Đăng xuất" OnClick="btnSignOut_Click" CssClass="dropdown-item"  style="border:none; background:#FFFFFF; padding:5px 0;" />
</div>
               <%-- <asp:Label ID="lbTime" runat="server"></asp:Label>--%>
                <script>
                    var timeDisplay = document.getElementById("time");


                    function refreshTime() {
                        var dateString = new Date().toLocaleString("vi", { timeZone: "Asia/Ho_Chi_Minh" });
                        var formattedString = dateString.replace(", ", " - ");
                        timeDisplay.innerHTML = formattedString;
                    }

                    setInterval(refreshTime, 1000);
                </script>
            </div>
        </section>
        
        <section id="Revenue" class="content-Manager col-sm-10" style="height:max-content; position:absolute; right:0;">
        <style>
            #footer, #header{
                display:none !important;
            }
            .ListView1Account{
			 display:flex;
			text-align:center;
			justify-content:center;
                }
        </style>

   
        <style>
            .table *{
               /* border:none !important;*/
            }
            .adminul li {
                    width: 100%;
                    text-align: left;
                    
                    border-bottom:1px solid #242426;
                    border-radius:0;
                   background:#FFFF !important; 
                    padding:5px;
                  
                  
                }
           
             .adminul nav-item {
                 font-size:16px;
       
       
             }
            .adminul *{
                transition:linear 0.5s, opacity 0.5s linear;
                color:#000 !important;
            }
            .adminul li a{
                font-size:16px;
                padding:5px 15px;
            }
             .adminul li:hover .dropdown-item, #adminul .nav-item:hover .nav-link{
         
                transition: 0.25s ease-in;
                
                
             }
             
             .smallul li a{
                 padding:5px 15px;

             }
             /* CSS cho phần tử <li> cha */
            .nav-item:hover > ul {
                display: block;
    
            }

            /* CSS cho phần tử <ul> con */
            .adminul.smallul {
                display: none; /* Ban đầu, các phần tử <ul> con sẽ không hiển thị */
            }

            /* CSS cho phần tử <li> con khi hover lên */
            .nav-item:hover > ul > li {
                display: block; /* Hiển thị các phần tử <li> con khi hover lên */
            }

        </style>
         
       
                <style>
                    .card-header{
                        font-size:12px;
                    }

                    .tenSP-ls-h3 {
                        padding-bottom: 1.5rem;
                        text-align: center;
                        font-weight: bolder;
                        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                        color: #9b51e0;
                        width: 100%;
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

                    body {
                        text-align: center;
                        justify-content: center;
                    }

                    .btn-color:hover {
                        color: #9b51e0;
                    }

                    .td-longer {
                        width: 12rem;
                    }

                    .btn-w {
                        width: 6rem;
                    }

                    #linksContainer {
                        display: none;
                    }

                    td, tr, th {
                        /*border: 2px solid #fff !important;*/
                        text-align: center;
                    }

                    .ListView1 {
                        display: flex;
                        text-align: center;
                        justify-content: center;
                    }

                    .pagerImage {
                        width: 24px; /* Độ rộng mong muốn */
                        height: 24px; /* Độ cao mong muốn */
                    }

                    .btn-num-page:hover {
                        color: #9B51E0;
                    }

                    .pagerGap {
                        margin: 0 5px; /* Thêm khoảng cách giữa các phần tử */
                    }

                    .numericPagerField a {
                        margin-right: 10px;
                        padding-bottom: 2rem;
                    }

                        /* To ensure the last button doesn't have an extra margin on the right */
                        .numericPagerField a:last-child {
                            margin-right: 0;
                        }

                    .currentPage {
                        font-weight: bold;
                        color: #9B51E0;
                    }

                    .table-card h3 *{
                        padding:0;
                    }

                    .table-card * {
                        /*border: none !important;*/
                        text-align: left !important;
                        padding: 10px;
                        color:#000;
                    }

                    .table-card {
                       /* border: none !important;*/
                    }

                    a {
                        text-decoration: none;
                        color: #fff;
                    }

                    .card {
                        text-align: center;
                    }

                    .row {
                        display: flex;
                        flex-wrap: nowrap;
                        justify-content: space-between;
                    }

                    .card-body {
                        padding: 0;
                    }

                    canvas {
                        margin: auto;
                    }
                    .div-TotalText{
                       
                       
                        background:#FFFFFF;
                        width: 100%; height: max-content;
                        border: 1px solid #636363; border-radius: var(--bs-card-border-radius);
                    }
                    a{
                        text-decoration:none !important;
                    }
                </style> 
                <asp:ListView ID="ListView2" runat="server" ItemType="TH03_WebBanHang.Models.DoanhThu" SelectMethod="GetRevernueRevenue">
                    <LayoutTemplate>
                        <div id="data-container" style="display: none;">
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <span class="data-item" data-ngay="<%#: Item.Ngay %>" data-thang="<%#: Item.Thang %>" data-doanhthungay="<%#: Item.DoanhThuNgay %>"></span>
                    </ItemTemplate>
                </asp:ListView>
                <section  style="max-width: 100%; margin: 2.5rem auto 2rem auto;">
                     <div class="container-fuild px-5 px-lg-5" style="margin:24px auto;">
                         <div class="row" style="margin:24px auto;  width:100%;">
                            <div class="col-lg-6 col-sm-6" style="text-align: center; padding:0; padding-right:10px;">
                                <div class="card d-flex text-left justify-content-center align-content-center text-white bg-primary" style="gap:10px; text-shadow:0 0 1px #000; height:265px; border:3px solid white;  padding:10px; border-radius: var(--bs-card-border-radius); background:#FFFFFF;">
                                   
                                        <h1>Doanh thu</h1>
                                        <h1><asp:Label ID="lbTotalAll" runat="server" CssClass="LabelTotalRevenue extra-bold count" Text="" Style="font-weight: bold;"></asp:Label></h1>
                                       
                                        <p style="border-radius: var(--bs-card-border-radius); background:#000; width:max-content; padding:0 10px; margin:0 auto;"><strong id="dauphantram" class="textphantram" runat="server"></strong><strong id="phantram" class="textphantram countNum" runat="server"></strong><strong class="textphantram">% </strong><strong class="textphantram" style="color:#FFF;">so với tháng trước</strong></p>
                                </div>
                            </div>
                            <div class="col-lg-6 col-sm-6 d-grid" style="text-align: center; row-gap:24px; padding:0; padding-left:10px; ">
                                <div class="card d-flex text-left justify-content-center align-content-center text-white bg-success" style="text-shadow:0 0 1px #000; border:3px solid white;  height:120px; padding:10px; border-radius: var(--bs-card-border-radius); background:#FFFFFF;">
        
                                            <h5>Đã thanh toán</h5>
                                        
                                             <h5><asp:Label ID="lbSDDTT" runat="server" CssClass="LabelTotalRevenue  extra-bold countNum" Text="" Style="font-weight: bold;"></asp:Label></h5>
                                        
                                </div>
                                <div class="card d-flex text-left justify-content-center align-content-center text-white bg-warning bg-dark" style="text-shadow:0 0 1px #000; border:3px solid white; height:120px; padding:10px; border-radius: var(--bs-card-border-radius); background:#FFFFFF;">
        
                                             <h5>Chưa thanh toán</h5>
        
                                            <h5><asp:Label ID="lbSDCTT" runat="server" CssClass="LabelTotalRevenue  extra-bold countNum" Text="" Style="font-weight: bold;"></asp:Label></h5>
        
                                </div>
                            </div>
                        </div>
                     
              
                   
                     
                            <div class="row" style="margin:24px auto;  width:100%;">
                                 <div class="col-lg-4 col-sm-4" style="text-align: center; padding:0 10px 0 0;">
                                   <div class="card d-grid text-left justify-content-center align-content-center text-dark row3-items" style="border:3px solid white; width:100%; padding:10px; background:#D7FFC2; border-radius: var(--bs-card-border-radius);">
                                               <div class="imgdiv">
                                               <img style="" src="Content/icon/cod.png"/>   </div>        
                                              <p>Phương thức COD: <asp:Label ID="lbCod" runat="server" CssClass="LabelTotalRevenue  extra-bold count" Text="" Style="font-weight: bold;"></asp:Label></p>
                                               <p>Số đơn: <asp:Label ID="lbCodBill" runat="server"></asp:Label></p>
                                   </div>
                                </div>
                                 <div class="col-lg-4 col-sm-4" style="text-align: center; padding:0 10px;">
                                       <div class="card d-grid text-left justify-content-center align-content-center text-dark row3-items" style="border:3px solid white; width:100%; padding:10px; background:#FFD6E7;  border-radius: var(--bs-card-border-radius);">
                                                <div class="imgdiv"><img style="" src="Content/icon/momo1.png"/>  
                                                        </div>
                                                
                                                  <p>Phương thức Momo: <asp:Label ID="lbMomo" runat="server" CssClass="LabelTotalRevenue  extra-bold count" Text="" Style="font-weight: bold;"></asp:Label></p>
                                                    <p>Số đơn: <asp:Label ID="lbMomoBill" runat="server"></asp:Label></p>
                                       </div>
                               </div>
                                 <div class="col-lg-4 col-sm-4 " style="text-align: center; padding:0 0 0 10px;">
                                     <div class="card d-grid text-left justify-content-center align-content-center text-dark row3-items" style="border:3px solid white; width:100%; padding:10px; background:#DBEEFF; border-radius: var(--bs-card-border-radius);">
                                                <div class="imgdiv"><img style="" src="Content/icon/VNPay.png"/> 
                                      </div>
                                                 <p>Phương thức VNPay: <asp:Label ID="lbVNPay" runat="server" CssClass="LabelTotalRevenue  extra-bold count" Text="" Style="font-weight: bold;"></asp:Label></p>
                                                <p>Số đơn: <asp:Label ID="lbVNPayBill" runat="server"></asp:Label></p>
                                                
                                     </div>
                                 </div>
                                
                            </div>

                       

                  
               
                       
                            
                               
                                    <div class="row" style="">
                                    <div class="col-lg-6 col-sm-6" style="text-align: center; padding:0 10px;">
                                       
                                        <div style="background:#fff; width:100%; height:max-content; justify-content:center; align-content:center; align-items:center; justify-items:center; border-radius: 6px; padding-left:10px; padding-top:10px;">
                                          <main>
                                            <asp:ListView ID="ListView1Branch" runat="server" ItemType="TH03_WebBanHang.Models.ChiNhanh"
	                                        SelectMethod="GetDeparmentsBranch" OnSelectedIndexChanged="ListView1Branch_SelectedIndexChanged" class="text-center ListView1Branch">
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
		                                        <td class="justify-content-center align-content-center"><%#:Item.MaCN%></td>
		                                        <td class="justify-content-center align-content-center"><%#:Item.TenCN%></td>
		                                        <td class="justify-content-center align-content-center" style="width:200px;"><%#:Item.DiaChiCN%></td>
		                                        <td class="justify-content-center align-content-center" style="text-align:center;"><%#:Item.DonHangs.Count%></td>
		
		                                       <%-- <td class="justify-content-center align-content-center">
			                                        <a class="btn btn-default btn-color btn-w" href="BrandOrder.aspx?Deptid=<%#:Item.MaCN%>">Chi Tiết</a>
			                                        <%--<a class="btn btn-default btn-color btn-w" href="DeleteBranch.aspx?Deptid=<%#:Item.MaCN%>">Xóa</a>--%>
		                                       <%-- </td>--%>
	                                        </ItemTemplate>
	                                        <LayoutTemplate>
		                                        <div class="d-flex justify-content-center align-content-center "><table class="table" id="groupPlaceholderContainer" runat="server" style="">
			                                        <thead>
				                                        <tr>
					                                        <th scope="col" class="justify-content-center align-content-center">Mã</th>
					                                        <th scope="col" class="justify-content-center align-content-center">Khu vực</th>
					                                        <th scope="col" class="justify-content-center align-content-center">Địa chỉ</th>
					                                        <th scope="col" class="justify-content-center align-content-center">Lượng đơn</th>
					
					                                       <%-- <th></th>--%>
				                                        </tr>
			                                        </thead>
			                                        <tbody>
				                                        <tr id="groupPlaceholder"></tr>
			                                        </tbody>
		                                        </table></div>
		
	                                        </LayoutTemplate>
                                        </asp:ListView>
                                            </main>
                                        </div>
                                    
                                     

                                    </div>
                                    <div id="layoutSidenav_content" class="col-lg-6 col-sm-6" style="">

                                        <main>
                                        <div class="card mb-4">
                                            <div class="card-header">
                                                <i class="fas fa-chart-area me-1"></i>TỔNG DOANH THU THEO NGÀY
                                            </div>
                                            <div class="card-body">
                                                <canvas id="myAreaChart" style="width: 100%; height: 250px;"></canvas>
                                            </div>
                                            <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                        </div>
                                          </main>


                                    </div>
                                

                                    </div>
                   
                       <%-- <div id="layoutSidenav_content2" class="container-fuild px-5 px-lg-5" style="margin:24px auto;">--%>
                            <main>

                              
                                    <link href="Content/css/stylesChart.css" rel="stylesheet" />
                                    <script src="https://use.fontawesome.com/releases/v6.3.0/js/all.js" crossorigin="anonymous"></script>


                                    <script src="Scripts/js/script.js"></script>
                                    <script src="Scripts/js/scriptsChart.js"></script>
                                    <script src="Scripts/js/datatables-simple-demo.js"></script>
                                    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>

                                    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-3">
                                            <div class="card mb-4">
                                                <div class="card-header">
                                                    <i class="fas fa-chart-pie me-1"></i>DOANH SỐ THEO LOẠI SẢN PHẨM
                                                </div>
                                                <div class="card-body">
                                                    <canvas id="myPieChartLoai" style="width: 150px; height: 150px;"></canvas>
                                                </div>
                                                <div class="card-footer small  text-dark text-dark">Updated yesterday at 11:59 PM</div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <div class="card mb-4">
                                                <div class="card-header">
                                                    <i class="fas fa-chart-pie me-1"></i>DOANH SỐ THEO NHÓM/NGHỆ SĨ
                                                </div>
                                                <div class="card-body">
                                                    <canvas id="myPieChartNhom" style="width: 150px; height: 150px;"></canvas>
                                                </div>
                                                <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-sm-6">
                                            <div class="card mb-4">
                                                <div class="card-header">
                                                    <i class="fas fa-chart-area me-1"></i>TỔNG DOANH THU THEO THÁNG
                                                </div>
                                                <div class="card-body">
                                                    <canvas id="myMonthlyAreaChart" style="width: 100%; height: 250px;"></canvas>
                                                </div>
                                                <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                            </div>
                                        </div>

                                    </div>
                               
                            </main>
                      <%--  </div>--%>
                
                   
                        <div class="row">
                            
                            <div class="col-md-3 col-sm-3">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-pie me-1"></i>DOANH SỐ THEO CHI NHÁNH
                                    </div>
                                    <div class="card-body">
                                        <canvas id="myPieChartChiNhanh" style="width: 150px; height: 150px;"></canvas>
                                    </div>
                                    <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-sm-6">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area me-1"></i>TỔNG DOANH THU THEO NĂM
                                    </div>
                                    <div class="card-body">
                                        <canvas id="myYearlyAreaChart" style="width: 100%; height: 250px;"></canvas>
                                    </div>
                                    <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-md-3 col-sm-3">
                                <div class="card mb-4" style="width:1180px; height:auto;">
                                    <div class="card-header">
                                        <i class="fas fa-chart-pie me-1"></i>DOANH SỐ THEO ALBUM
                                    </div>
                                    <div class="card-body">
                                        <canvas id="myPieChartAlbum" style=""></canvas>
                                    </div>
                                    <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                        </div>
               
                    
                        
                         <div class="row">
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="#Revenue">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ DOANH THU
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAYAAADimHc4AAAACXBIWXMAAAsTAAALEwEAmpwYAAAJfklEQVR4nO2bf2yU9R3Hb8TgtrhEl23OgaIFqhaRQoEWECqt0BYKvf64lv66/jh713IgzBj8SXpuyzycixGcBGamcRq3TgsWKIzf1IJuiZmIy3TLEnWj4j9k2fAHyfC1HOtne6z90u+3z7e9Up5X8krKc+/n/Xy+d+W5554Dn8/Dw8PDw8PDw8PDw8PDYzi54S6uHreKaeNWsuTaVdSPi3L/+ChPjIvyq3FRusZHeWd8lH+OX8XH46O8PGEl3x3WAUcr10b53nVRTlwXBUMPJ3v2UcH1Lbx4/UrQ9NPrWzgnf/b+FlggpYWulBbo9XRKMztTmtma0kzrDS2EUiIsSYkyNTXMt1KaKUhp4fPz2WbOTVjDlTZmuKSZHGHV5Gbo9R8pzXynv1xi++RmTv0vG+GF4Z92FJLdymWpYU7cGIFef/7lFF9JjdAhmdQIp24JcXUy5h2V3BSm5OYInDfMuZvCzOjzePQLj0dYlLxpRxOtjJkSITiliQ+nhEFMC3M08VufiKRFSEtr4hPH448le+xRwZQwC6c28YepTdCftzaxYtJqLp96J2/KtluaODGhjq8me/aLmowwE9NDtKffCU6nhXg/PcQOx7YPpoXY7Hj8k/QG0pI9/0VL2kqumB4iNj3EpzNCIE5v5OMZIeKJx+c28o3pjfQ4HxczQrQkew0XJ62MyWggmNHAqZmN4PDzmQ20ZYS5zhnPaCDUJ0dGI53ynuBhwOx6cmY1cHx2A/Sxe1YjM/vdqZUxsxrY68i+m97At02Oe8mTWc/krDq2Z9WD08w63susp2Kg3+asAF/LbKAms46mrBDfvOSfUF2yA1wxr47Y3CCfzasDcW4dZxLbE0+sdpmHAa2MmRckeFuQU/OD4PDz+UHa5tV+8TzvYZH5NeRk13A8uxacLqjl9QW1zPGe7CFiQSWTb6+mbWEN9PGDhTUEvauWISK7jitzq4nnVPNZbjWIOVWcya0mlj1En1QDAcbmVrMhp4oe53FV5lRzMjFnYj/faKC1lTGLKwkuruSjxVUgLqrk3KJKnlsSGNqvCBdVEXceV9dFVTziu9jJryA3r5Lj+ZXgNG8Fr+VXkzUsM6ygp+/xtVxBz5APt2QFiDZ7CypILVhBm7O/1w8Kyof3PG+6xqF6TvqlsAJEG31Lq7iqsJx4YQWfObsLyzmztGLozvM212j7ObkgReUguunJzuYyf4Dw8nI+cnYuD3BuefnQn+dtrtHWc9Iv/gCziwMc9Qc4WxyAAYzpdJaUc0dxgLf62f9QUYB0X5LRWKdSu4MUc01JKadLy0DL0gu/AP4KUkvKaOu7X0kp75eVJc7zIwPt9faj1UHKyogEykBbxQtQVcVVZWXEA6Wc7ZP/V2KfuhH2zZPRmvtodZCKUmIVpdCr1umlL/n5XF5eyt8cPVSU8O/yUrbUFPf/z0KSjXPWochrU1lMrKoEEiZ+ttRzsKaYab4RjMyacCjy2lQXE6sphoSJnwfbEy7k69V+DtT6KfJdBMiaEw5FXps6P+GgHy5oEWeDfo4G/cz2JYFAgLFBPxuCRfQMOKsfav2crPVf+L6NM68zg2lem+pirqkv4nR9EWh4OpH3DTN1y4lrztdX5X0bZ05nBtO8ESE/sxuW0924jLONy2EAm3zDTMMyejTm+pKJ/VSdzpzODKZ5qzQtI9a0DHqNJeH4iLbyqsz3j4HoZgarRJYSixTCeZcO/wsQkWMX6i1eJ6/K3HMURDczWKVlKbGWpdDrsL8ALf8/Nrbyqsy6oyC6mUGbaAGx6BLQdWXB8L8HRA3m66tOp3P7/d0g6uRds7qA2OoC0DKf02vzhv8qaLXufP2o0+nc/lA3iDp516zJI7Y2Hy7kmjzOrsmj+658ZvmSwNoB5ruQOp3O7a2vgqiTHxLuzgPRNwK423Aenbwq83AXiG5mcMU9i0H0jQDuMZxHJ6/K/KgLRDczuGLdIhB9I4B1hvPo5FWZR46A6GaGpNEaYOy9d7Dh3lx67rsDBjSXk/flEk/sp+p05nVm0MmrMhsOg+hmhqTxYC7xB3PB1Ady1PdtnDnNGQbMqzKPHQbRzQxJY30OPetzYBAq79s4c5ozDJhXZR4/BKKbGZJG60IQbeVVGdWnVjedTxwC0c26ksbDt4NoK6/KPNANoq3OJw+C6GZdSeOHt4NoK6/KrH8VRFudmw+A6GZdSePH2TBYdTp1PjS56dx6AETTzhFBfAEMVp1OnQ9Nbjqf3g+iaeeI4NH5MFh1Op3b40dA1MnrZJ7ZB6Jp54jgsdtAtJVXZX5yGERbnc/tA9HNupLG4/NAtJVXZVTX7G46n98Lopt1JY0n5oJoK6/KbDwIoq3OF/eC6GZdWrSmMXbTHDZsyqJn0xwYyI1ZnNyYRTyxn6rTmfdpoJNXZZ46CKKtzrbfguhmXVo8mUX8Z1lgamI/Vacz59NAJ6/KbDkAoq3Ol/aA6GZdWjyVSc/mTBiEH6o6nTmfBjp5VUZ1yeimc9seEN2sS4uts0G0lVdl1inu27jpfHYfiLY6O3aDaNppzNOzQLSVV2UeUnzZ7abzl3tBtNW5qxNE005jfjETRFt5VeZhxW0DN52qKxY3nbs7QTTtNObZDBisOp0+ja/63HSqrljcdO7dBaJppzHPzYDBqtPpc/DTwyDq5HUy7XtAtNV5YBeIpp3GvDAdBqtOp8/BpoMg6uR1Mq/sBtFW56GdIJp2GvNiOoi28qrMFsU1u5tO1Rumm86uHSCadhrz62kg2sqrMs/sB9FW555OEG11Ht0BommnMb+5FURbeVXmecVNLjed+3aBaKvz9Q4QTTuNeXkqiLbyqkyb4orFTafqfO2m8/evgGjaacz2qSDayqsy23eDaKtTdb520/nGKyCadhrTcQuItvKqTGcniLY6j3WAaKvzze0gmnYas3MKiM7tP+gCUSevk9m/C0Rbnb/rANFW51vbQTTtNKYzDUSda3ZVXifTpThduOlUnS7cdP5xG4imncbsuRlEnZtcqrxO5rUOEG11qk4XbjrfaQfRtNOYfTeB6Ny+czeIOnmdzBuK31Y3nW9vA9FW55/bQTTtNObAjSDqfBhR5XUyJ7aBaKvzT+0g2ur868sgmnYacygVRJ3zoCqvk3m3HURbnX9pB9FW53svgWjaaczhSZw8MhmMncTfvU4LdE8k3j0JjJ2o/s8Ul3KnMW+nMfbYROLHUjh5bCIM6H9z8cR+XqeHh4eHh4eHh4eHh4eHbyTxH2OtmXrGK1CsAAAAAElFTkSuQmCC"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerOrder.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ ĐƠN HÀNG
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="UpdateInformation.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ NỘI DUNG
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>


                         </div>

                         <div class="row">
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerAccount.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ TÀI KHOẢN
                                         </div>
                                         <div class="card-body">
                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerProduct.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ SẢN PHẨM
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerGroup.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ NHÓM/NGHỆ SĨ
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>

                         </div>


                         <div class="row">
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerConnect.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ LIÊN KẾT
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerService.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ DỊCH VỤ
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAYAAADimHc4AAAACXBIWXMAAAsTAAALEwEAmpwYAAARZElEQVR4nO2cCVjU5b7H55Snbqc659S9eU/aiiACCsgi2wguoCi7OLiwKIsLgmslpeVk1wVNS9yS9KTXMnNSREBA2UQB2wwzW849aafy1D3PTY9hi5SHz31e5D+8jDPMoGzSfJ/n8zzM+35/y8vM/Gfm/c9/VCqrrLLKKqusssoqq6yyyiqrep60cMu8GjbNq6Fufg3Mq+bivBoyu7qvX42eqGbSwmow5PEagru6tx4nbTW9F1exZnEV2U9VM1CMLTrG2sVVYMiiYzwj5p+pxnNRFdsWV7FCW8Efu3oNN60WV/PwkmN8rj0GgiVH+UF7jJeXHOOfylgLjvK/2qNsW3KUemn8Y20Ff+qI/mxnc/v96cy5P523+qTzvUD8fX866Y5ablPdzNJW0GvZUU4tOwrtQHV79/fADPo+kMbJB9LBBLXCo7pZlXkEh1WV0F4sL+U/2/OR/+AsTj6UBq3x4Czev2mfCRsruOuFci68UAHtwN91Om5tr94emcWcR2eB4JFZ1D+SysIH0+gjeCSVDDGmzD86kzTVzaqsMmLWl4Mxssr5dn0ZO9aXkZlVzq6sci6a9JYxqm2V+Y3NLNQ2qWT0S2Vlv1Rm287AUZntl8rb/VJBIDyG0U1xyvxxZVzksJnJHJHTJpWFNjPwE7VU3VWbyhj1UhkY4dVtVdwte7cWc+/mUnKN+bdU4GFpTfvpDLKdQa3dTDBCru1s7rOdwSVlzD6NPtfkSKOPMm87kzoRYzeTPKM5Z/C+qKnqLtJquWVrKZu2llC3rRSuoYQy4TEWq9Nx27YS3jMaV8rFrSWtf1izm4HLgBnUDZgBrfCZfNtUrhYx0zljJmdd/1ScVd1BOw4z6b9LwCSHCWg1/hBRrcVvLzHxYU3DrY7T+NBxOjTxk8N0tjhOJ8NhOnsdp9Mgzekx1Ycxr8jhMI03G3NOI1vUUOYcpvOBysQDq1O16zArdh0GY7x2iAbxKG8tfuchepuKb8qx0FicUwqjB04DgVMKPzqm4NpifhrrlXkZU30Y84ocskfUELX0nmSCVF2tPcWs0B0CY+wpNn8H7DtEb1PxTRi9A5xTWOaSAgLnZDYp4xoNt7oks16Z05PMVyLGVB9izjmZc0bi1smPdJcUNkt1/0vV1copYtL+YjBJEcPMxI9rLX5fsfFDkGsSGwcnQyNJLFD++a5JvKEfTwbXJL5wSSJWzJlbS4CWXoOTiXNN5ssWOZLZrdwJopaUe6OqqyVeYPML2VhQRF1BEVxDIRWm3tPrdNxWUMgJY3H5hVzML2KlqbruiSx2T4Im9ogxt0TWS2O4J1I0KJV72romESNiDXKta6qrU8bcklik6k4qPkhQcSEYUlTIrsJCfi97S0r496KD5BnzHyrA3VwtzyQ8PBOhiQaPRNZLtxG3DV8k3acS5JHIVs+pfOqZyPdNfOKRyMseiQTKXvGM8Uxkg2FOUUu57T4VN1V3UkkeE8oKwCj5nC/NZ2dZAZllBewuy+c7k948yz6IeU/hoPdUMEKh/M/3jKe/11QqTXj1eE3hiNdU7OQ7wWsqRSa8+arupAodd1XmceFoPtwweXxtyVaEOpH7fBI44zsFFHym8IV6cvNhxycBf58pXJA9rZLAed+pDNXXmMw9Pgl82aJGAmdEbVV3UnUeA47nQbtxwPhmXPBsbldPYY5fAm/5JfC9OgFkfKcQq3jV8fRXJ3BBmfOL57JfPFnqOLyC4rhTIP5Wx7NBnUC9Pk88573jsJXyxBvWEbWbekh31HSDDbyKCnq9c4BT7x6AG+WdXKqM1RiRQF//eE4GxIMx/OP5KiCAXoo/II5K/Vwc54bH4WKq/4ApuAqPPl8c5fq5AHo15jZVN45a0Zuqq3ViLw+fzOXzk7nQyH5+OJnLltr9XNCPSdTu55vaXLbW5lIvjX98uuDaEzLikT8slpPD46AVliv+EXEEKePDYrnc2j9fkX88g4fFUS/FjVTmRO5Wa8fyvqY7PBNO7qP36f2s/iiHLR8dwEmMfbSftR/tB0NO7796SvJULh6nc9h6ej/LavcbPyU5cjJzRsaCYEQs9SMmszBw4rUba5J/q+TPsrT/kbFslOKyTflE7RGTyRC96P2Tu+lW9l9ymPSXHDDk032Wn5QPmszboyZDExlm/ZP4VO+fxBBL6wTG4q3EBU3mE3N+0YtUR7+V3a2EllvO7mXj2b3Und0HZ/dx8ew+0x+yjCl4EpeCJ4FgdCz3t8UfoOEuS+sIrxIncpjzj9Xwp7b4b1qNncilsRNBEN7KoceYvy13QHAsv1fixk7gO3P+EA192+K/aRUaw1thE6AJs4eg0Al8qvjDJ+JlcR0NPvo6MXxsQZ0npb5qVD1VETHMjogBQXgM9REaMlp7JkTE8LLer2m5rdyawjVskuK2mPRNpE9jD6KXJn9EDLNUPVXBwdwepaE2SgOmiBzf/DZ0XAyB0tzlCE3L8wXGFBWDW6SGeiluhDIncpupfaJbvA3tSGk09I2Opnb8eDBBiw9i0dEcUeaiozmnaeVOiIrCLTqav0v+MqnuHdHRfNNK3RMTLXhd6hHSaLhNM470mHHUxIzjUkw0yGiiiVO848ZhFzOO8/r5cdTHRLNBo8FHo+GuJnw049jUNKfk+XZCJP2UPDFRzDas01hb9DCeWT3+kW9KcVH0nhDFmYnjQOJLjYZ7Fc+EaIZOjOK8gcckE8bx7aRI1Eq8yDUxinMtPFGc0Wi62WZcVyg2isLYKLiGSIrlM2BxYdjGRlJu1CsxOZIy+ZEvckyO4pAJb4Hq16z4cDziI6GJhrhI1ku3iY9go+FpyNgIRsZHkh0XwcfxEVxqJJKP4iLZEhfV/IIrJGLjItlkkDNL1FJux0Z1sxMynamEcJ6eEgGNhPOGGJsSwTr92NXx4mTpcGSpRMyUcA7JuRLCebGxRjh79GMRnXxKMjWEe5JCiU8KI8MUiWHECV9H95IUxsakcGhigXJ+OjGM3dI4SWF8KXrWSu+OTEl4EsNJSAzjqxY5wnld+XKZqCXl7ryT8snhaJJDuZgSBmYJ5Z8pIYzvyH5Swlim1EsOa/5aivhHJYeyzrCn5DDOiZjW8jV5WsaF8qL8zb6UUDZL63xO1RmaEYbftFB+mR4KbeDnlDC8O6qnlBBGK7WmhfBjytiW7/GnhbLeWF+m8hldQ0jLbWxRY3ooPynzM8I66YtZqWMpTg2BRqI5nzaX6rS5VBmhWszrvSEUdlRPGg23zgzhlFTrp9QQts4cy5OpY8lJDaFBmtNjco1GvI05xpIjcs4MYdvMEC4rczPH8oGp77y2u9LGUJc2FgSPF8AT1aZ5PP+qTzBrbMfuDqYG4yz3ZpQxnJFvm1xjKzFGctaJ2qrO0uwxoPBUlXlkf0f3NicY59nBnJJrShTMDua+2WO4pIylBV67ZSDGlPn0YOqaYgqM5UwfwwdpYzr56+nzgkHh6WPmkf1zg8kwxvxgZs0JunoV5Y1KHArmjCJobjDPzR3NpnmjWTRvdPN79HmjeUvux8j6npR61m8pixwil8gpcosanXbYkbVgNCg8e8w8st8MDQtGsXtuQMdemrpgFLOVmvNHUT9/FBlPBNJHIP4WY/r54G64pfz4KFCw5CpH2W8hHz4WRO+O6n92MLc/Nopac308FsQJbXfcWMsIAoXMSvPI/oVBZBojI4idGUH8rPcGUj3dnd921BoWjaBvRiC1cm8tCOSEeEaouqOeCgSFNUfMI/tbzTuCoKcC+VHyW/z1keuReHQ/GUj6U4HUPBnIJUHj3yOZ1S0f+YoWjwSFdRXmkf3mcj89ktDFI2lo8jcsCmR056zqJtKSEaCwodw8st+i/MPZoPifGc4XS0aQcT08M5IFz4xgjDaAf1P1JD07HBRMXIbaAtlvSf5Vvtz97DD+IcfdCNrhfK0NYKKqp+i5YaCwtdQ8sr8NNebKce3E3I74f6xUc89zAYxfOozNS4dxfOkw3l86jPxnh5Fsya5rm7U8ABS2l5hH9lta4/kg7lzmz8rlAWTeANnLA/haqb3MnyvP+d/4p1adhltX+OOzzB/tsgBqRF55jTLL/Dm5yred302t9AeFV0vMI/tVnSxtAH9c6c9bUg87ridPph8PrRxKykp/3lzpzwV5TeZY4c/prGBub7dFrRoKCrsPm0f2q7pAq/3x0feg5itLYrTu/C7TjzGZatatUvOJvAZDMtVcWTWU45lDWbpaTfAKfzwzh/J4pprLep8/j7Xbgp5Xg4KZa3obkf2qLtAqX+5W6q/247IxDyp+s1qN8/NDeeJ5NSXCJ/d9DX58vlpN9vNqxovXAGM5V6tJ1ddV8167LegFP1DIKTaP7Fd1gdb4oVbqr/XlC2U8S819a/2YvNaXHWt9+Vru05C1vlxa60veWj/S16jpb0ndrCH8Xo5vtwWt8wWFvCLzyH5VJ2uzmnvW+fCuUv9FH46/6MPyF314b50v/5J7M+BfIk54s7wJyL6ObRFx3JfqGn3mXZfW+4BCYaF5ZH+bF+FDxnXjzctZPnwj1zfDuSxvXlnnw8Q17vzHjf6fsrwJVnJneZu/uMNibfIGhcMHzSP7b6TWpnZmozc/bPKiaKM38zd6Xr18qr0k8m3y4m9SvTZdgNKqXvIChfIC88j+G6n10g2y2YuGzV6cfMmL1Zu9CdzeAVsUa725Y/MQlm32ol6q+38b2vOzQPYQUKjMN4/sv45ame3BFg/itnq13w//meg1ZIsnZ+X1Znvy3ctDWn7L7oa1zRMUqvPNI/t3OnOnqocp252HtnqwX15nE9XZ7gxo94KveIDC23nNWDL+Z3c+3+bOcFUPkDaAXq94MPcVd+parNGDC2Jcq+qg88U73EHhxIFmLBkXbHenYYc72Tfzs+EVN4Zud+PDa9blxs4/u3bwV9VfdQOFD3KbsWRcZudgzrw2GH/VTSSdN/e+6kb2TjcaDNbzwU5XfDuliV2DQUG+0t2S8dcGU9DititXXhvMykLbdtys6gCJw8kuV1J3DeaC3P+uwdS96sa8io7Ydjal1124stsVBJ++2XyluzIm0F/9rmseE3GN8c4k7XbhO9n/uisfvjGoe36/fpcb7q+78I7cbxN7dC5d8KMcOhc+07mAoGoe/FUHn+27eltB3BbjVfObx/Y48z/6HO48pHOmRI7ROfPzHheevZ6P/R0hnTt/0DmzQefMFblPsY43Xdr6a77tqDcHsXSvM1wHWsMdyL3OpO515lIL3yDe1w3q2l+j1Q0kdq8z3xj0/9NeZ5Zsf7iLzzHrvLlj3yCqcwZBG6gy1fjeQdjkDKTSwF+/bxCLOvXYKnoZyICcQZRf0/9AinKcmq8X63KJOyF3INrcgfz1gBNXDgyEa3DiipgXvgozjxrxInfAiXkHnPjRIM/bOU44dPR68tz5Xe5Alh8YSL3BGr7KdezYi0u6lQoGYZPnRGW+EyjkOfFTgSMZ4lxsR9TMcyIs35GzLWo68ku+I1m59i1/ZPxXIa2KWw46MLfAkcsHHUGipsge+/aqk29H34OO7DSoQYEDxw7ad6NfRO8qFTriWOTAu8UOIPFj8QAybuRj/nvu/LbIgblFA7gk5y4awHkx3mFbCDejKgLodXgAGYftqT88ACSqih2bf8nQUh1ywP+wPaflXIcG0HDInp2Fttar3U2qxJbBpf05VWoPCiX9qSux5wlLPkWX2GFT2p9dJfY0yDlK7ak9PKDjLh7sUdI5cltFf5aX2/FLRX+Q+EdFf9Yc6c+Yw/b0EYeYEhv+cMQOh4r+xJfbsb/cjp8NYr4rt2duZ7/N7RGqtGNIpR0fVtrB9XDEljeq7Lvpd/9vFlUE0OuoLalHbfnbMVuwkNLKfp20Y/lrESpuOf4oQdU2vFBjQ01NP76utqG+xoZL1TacrbYhr6YfT9X0a/sLtlVWWWWVVVZZZZVVVllllVWqnq//B/4+aIk06m2CAAAAAElFTkSuQmCC"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>



                             <div class="col-lg-4 col-sm-4 ">
                                 <div class="card mb-4">
                                     <a href="ManagerComplain.aspx">
                                         <div class="card-header">
                                             <%--<i class="fas fa-chart-area me-1"></i>--%>QUẢN LÝ KHIẾU NẠI
                                         </div>
                                         <div class="card-body">

                                             <img src="data:image/png;base64,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"/>
                                         </div>
                                         <div class="card-footer small  text-dark">Updated yesterday at 11:59 PM</div>

                                     </a>
                                 </div>
                             </div>
                         </div>


                     </div>
                 </section>

                <script>
                    document.addEventListener('DOMContentLoaded', function () {
                        //var dataItems = document.querySelectorAll('.data-item');

                        //// Initialize arrays for 15 days, 12 months, and 5 years
                        //var currentMonth = new Date().getMonth() + 1;
                        //var labelsDaily = Array.from({ length: 15 }, (v, i) => `${i + 1}/${currentMonth}`);
                        //var dataDaily = Array(15).fill(0);
                        ////var labelsDaily = Array.from({ length: 15 }, (v, i) => (i + 1).toString());
                        ////var dataDaily = Array(15).fill(0);

                        ////var currentYear = new Date().getFullYear();
                        ////var labelsMonthly = Array.from({ length: 12 }, (v, i) => `${i + 1}/${currentYear}`);
                        ////var dataMonthly = Array(12).fill(0);
                        //var labelsMonthly = Array.from({ length: 12 }, (v, i) => (i + 1).toString());
                        //var dataMonthly = Array(12).fill(0);

                        //var currentYear = new Date().getFullYear();
                        //var labelsYearly = Array.from({ length: 5 }, (v, i) => (currentYear - i).toString()).reverse();
                        //var dataYearly = Array(5).fill(0);

                        //// Update arrays with actual data
                        //dataItems.forEach(function (item) {
                        //    var ngay = parseInt(item.getAttribute('data-ngay'));
                        //    var thang = parseInt(item.getAttribute('data-thang'));
                        //    var doanhThuNgay = parseFloat(item.getAttribute('data-doanhthungay'));

                        //    // Update daily data
                        //    if (ngay >= 1 && ngay <= 15) {
                        //        dataDaily[ngay - 1] += doanhThuNgay; // Adjust this logic if you need to sum or average data
                        //    }

                        //    // Update monthly data
                        //    if (thang >= 1 && thang <= 12) {
                        //        dataMonthly[thang - 1] += doanhThuNgay; // Adjust this logic if you need to sum or average data
                        //    }

                        //    // Update yearly data
                        //    var yearIndex = labelsYearly.indexOf(currentYear.toString());
                        //    if (yearIndex !== -1) {
                        //        dataYearly[yearIndex] += doanhThuNgay; // Adjust this logic if you need to sum or average data
                        //    }
                        //});
                        var dataItems = document.querySelectorAll('.data-item');

                        // Initialize arrays for 15 days, 12 months, and 5 years
                        var currentDate = new Date();
                        var currentMonth = currentDate.getMonth() + 1;
                        var currentDay = currentDate.getDate();

                        // Generate dynamic labels for the last 15 days
                        var labelsDaily = [];
                        for (var i = 0; i < 15; i++) {
                            var date = new Date();
                            date.setDate(currentDay - 14 + i);
                            labelsDaily.push(`${date.getDate()}/${date.getMonth() + 1}`);
                        }
                        var dataDaily = Array(15).fill(0);

                        var labelsMonthly = Array.from({ length: 12 }, (v, i) => (i + 1).toString());
                        var dataMonthly = Array(12).fill(0);

                        var currentYear = new Date().getFullYear();
                        var labelsYearly = Array.from({ length: 5 }, (v, i) => (currentYear - i).toString()).reverse();
                        var dataYearly = Array(5).fill(0);

                        // Update arrays with actual data
                        dataItems.forEach(function (item) {
                            var ngay = parseInt(item.getAttribute('data-ngay'));
                            var thang = parseInt(item.getAttribute('data-thang'));
                            var doanhThuNgay = parseFloat(item.getAttribute('data-doanhthungay'));

                            // Update daily data
                            var itemDate = new Date(currentYear, thang - 1, ngay);
                            for (var i = 0; i < 15; i++) {
                                var date = new Date();
                                date.setDate(currentDay - 14 + i);
                                if (itemDate.getDate() === date.getDate() && itemDate.getMonth() === date.getMonth()) {
                                    dataDaily[i] += doanhThuNgay;
                                    break;
                                }
                            }

                            // Update monthly data
                            if (thang >= 1 && thang <= 12) {
                                dataMonthly[thang - 1] += doanhThuNgay;
                            }

                            // Update yearly data
                            var yearIndex = labelsYearly.indexOf(currentYear.toString());
                            if (yearIndex !== -1) {
                                dataYearly[yearIndex] += doanhThuNgay;
                            }
                        });

                        if (typeof Chart !== 'undefined') {
                            // Format numbers as currency VND
                            function formatCurrency(value) {
                                return value.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
                            }

                            // Common options for all charts
                            var commonOptions = {
                                tooltips: {
                                    callbacks: {
                                        label: function (tooltipItem, data) {
                                            return formatCurrency(tooltipItem.yLabel);
                                        }
                                    }
                                },
                                scales: {
                                    xAxes: [{
                                        gridLines: {
                                            display: false
                                        }
                                    }],
                                    yAxes: [{
                                        ticks: {
                                            beginAtZero: true,
                                            callback: function (value) {
                                                return value.toLocaleString('vi-VN');
                                            }
                                        },
                                        gridLines: {
                                            color: "rgba(0, 0, 0, .125)",
                                        }
                                    }]
                                },
                                legend: {
                                    display: false
                                }
                            };

                            // Daily revenue chart
                            var ctxDaily = document.getElementById('myAreaChart').getContext('2d');
                            var myDailyChart = new Chart(ctxDaily, {
                                type: 'line',
                                data: {
                                    labels: labelsDaily,
                                    datasets: [{
                                        label: "TỔNG DOANH THU NGÀY",
                                        data: dataDaily,
                                        backgroundColor: "rgba(131, 2, 216, 0.2)",
                                        borderColor: "rgba(147, 2, 216, 1)",
                                        borderWidth: 1
                                    }]
                                },
                                options: commonOptions
                            });

                            // Monthly revenue chart
                            var ctxMonthly = document.getElementById('myMonthlyAreaChart').getContext('2d');
                            var myMonthlyChart = new Chart(ctxMonthly, {
                                type: 'line',
                                data: {
                                    labels: labelsMonthly,
                                    datasets: [{
                                        label: 'Doanh thu theo tháng',
                                        data: dataMonthly,
                                        backgroundColor: 'rgba(54, 162, 235, 0.2)',
                                        borderColor: 'rgba(54, 162, 235, 1)',
                                        borderWidth: 1
                                    }]
                                },
                                options: commonOptions
                            });

                            // Yearly revenue chart
                            var ctxYearly = document.getElementById('myYearlyAreaChart').getContext('2d');
                            var myYearlyChart = new Chart(ctxYearly, {
                                type: 'line',
                                data: {
                                    labels: labelsYearly,
                                    datasets: [{
                                        label: 'Doanh thu theo năm',
                                        data: dataYearly,
                                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                                        borderColor: 'rgba(255, 99, 132, 1)',
                                        borderWidth: 1
                                    }]
                                },
                                options: commonOptions
                            });
                        }
                    });
                </script>



                <script>
                         document.addEventListener('DOMContentLoaded', (event) => {
                             // Hàm để tạo màu ngẫu nhiên cho biểu đồ
                             function getRandomColor() {
                                 var letters = '0123456789ABCDEF';
                                 var color = '#';
                                 for (var i = 0; i < 6; i++) {
                                     color += letters[Math.floor(Math.random() * 16)];
                                 }
                                 return color;
                             }

                             // Dữ liệu giả lập, thay thế bằng dữ liệu thực từ server
                             var labels = [];
                             var data = [];
                             var backgroundColors = labels.map(() => getRandomColor());

                             var ctx = document.getElementById("myPieChart").getContext('2d');
                             var myPieChart = new Chart(ctx, {
                                 type: 'pie',
                                 data: {
                                     labels: labels,
                                     datasets: [{
                                         data: data,
                                         backgroundColor: backgroundColors,
                                     }],
                                 },
                                 options: {
                                     responsive: true,
                                     maintainAspectRatio: false, // Disable maintaining aspect ratio
                                     legend: {
                                         position: 'top',
                                     },
                                     animation: {
                                         animateScale: true,
                                         animateRotate: true
                                     }
                                 }
                             });
                         });
                </script>
         

       
       
    </section>
    
    </form>
</body>
</html>
