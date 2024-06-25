<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TH03_WebBanHang._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Header-->
    <header class="bg-dark py-0 px-0"><!-- Nút mũi tên trái -->
<button  id="btnPrevious" onclick="previousImage()" class="btn-arrow bg-dark"style=" left:0; position:absolute; height:100%; width:max-content; padding:0 2rem;"><img class="img-banner"src="Content/icon/back.png"/></button>

<!-- Nút mũi tên phải -->
<button id="btnNext" onclick="nextImage()" class="btn-arrow bg-dark" style=" right:0; position:absolute; height:100%; width:max-content; padding:0 2rem;"><img class="img-banner"src="Content/icon/next.png"/></button>

        <div class="container px-0 px-lg-0 my-0 position-relative">
            <img id="bg-df" src="Content\image-bg\bg-image-1.jpg" class="img-fluid" alt="Background Image" style="max-width: 100%; height: auto; background-size:cover;"/>
            <script type="text/javascript">
                var images = ["Content\\image-bg\\bg-image-1.jpg", "Content\\image-bg\\bg-image-2.jpg", "Content\\image-bg\\bg-image-3.jpg", "Content\\image-bg\\bg-image-4.jpg", "Content\\image-bg\\bg-image-5.jpg", "Content\\image-bg\\bg-image-6.jpg", "Content\\image-bg\\bg-image-7.jpg"]; // Danh sách các đường dẫn ảnh
                var currentImageIndex = 0;

                function nextImage(event) {
                    event.preventDefault(); // Ngăn chặn hành vi mặc định của liên kết hoặc nút
                    currentImageIndex = (currentImageIndex + 1) % images.length;
                    changeBackgroundImage();
                }

                function previousImage(event) {
                    event.preventDefault(); // Ngăn chặn hành vi mặc định của liên kết hoặc nút
                    currentImageIndex = (currentImageIndex - 1 + images.length) % images.length;
                    changeBackgroundImage();
                }

                function changeBackgroundImage() {
                    var bgImage = document.getElementById("bg-df");
                    bgImage.src = images[currentImageIndex];
                }

                // Gắn sự kiện click cho các nút
                document.getElementById("btnNext").addEventListener("click", nextImage);
                document.getElementById("btnPrevious").addEventListener("click", previousImage);
            </script>
            <style>                .btn-arrow {   border: none; /* Loại bỏ viền */
    background: none; 
    padding: 0;
    margin: 0; 
    cursor: pointer; 
    outline: none;
    -webkit-appearance: none; 
    -moz-appearance: none;
    appearance: none; 
                }
                .img-banner{
                    width:48px;
                    padding:10px;
                    border-radius:50%;
                }
                .img-banner:hover{
                    background-color:#FAF4F4;
                }
                .btn-arrow:focus .img-banner:hover{
                    background-color:#FAF4F4;

                }
            </style>
            <div class="position-absolute top-50 start-50 translate-middle text-center text-white" style="width: max-content;">
                <h2 class="display-4 fw-bolder">Gmilk Tea<br />
                    Tiệm Trà Sữa Hầu Gái</h2>
                <p class="lead fw-normal text-white-50 mb-0"><strong>Trà Sữa Được Làm Ra Từ Những Cô Hầu Gái Xinh Đẹp</strong></p>
            </div>

        </div>
        <style>
            .btn-mua:hover {
                background-color: #FBF4F1;
                color: #212529;
            }
            /**/ .bg-dark {
                position: relative;
            }

                .bg-dark .container {
                    position: relative;
                    overflow: hidden;
                }

                .bg-dark img {
                    filter: brightness(50%);
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
                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                color: #CCBEB1;
                width: 100%;
            }

            .tenSP-ls-p {
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


    <!-- Section-->
    <section class="py-5">
        <div class="container px-4 px-lg-5 mt-5">
            <h3 class="tenSP-ls-h3">
                <p class="tenSP-ls-p">Trà Sữa</p>
            </h3>
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">
                <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetTraSua">
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No data was returned.</td>
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
                        <div class="col mb-5">
                            <%--<div class="card h-100">  --%>                      <a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">

                                <!-- Product image-->
                                <img class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content;" />
                                <style>
                                    .img-with-hover {
                                        transition: transform 0.3s;
                                        border-radius: 1.8rem;
                                    }

                                    .btn-mua:hover .img-with-hover {
                                        transform: scale(1.05);
                                    }

                                    .btn-outline-dark {
                                        --bs-btn-active-bg: #CCBEB1;
                                        --bs-btn-disabled-color: #CCBEB1;
                                    }
                                </style>
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
                                    <%--                                    <div class="text-center"><a class="btn btn-outline-dark mt-auto btn-mua" href="item.aspx?sp=<%#:Item.MaSP%>">Mua</a></div>--%>
                                </div>
                            </a><%--</div>     --%>
                        </div>
                    </ItemTemplate>
                </asp:ListView>


            </div>
            <h3 class="tenSP-ls-h3">
                <p class="tenSP-ls-p">Hồng Trà</p>
            </h3>
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">

                <asp:ListView ID="ListView2" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetTea">

                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No data was returned.</td>
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
                        <div class="col mb-5">
                            <%--<div class="card h-100">  --%>                      <a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">

                                <!-- Product image-->
                                <img class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content;" />

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
                                    <%--                                    <div class="text-center"><a class="btn btn-outline-dark mt-auto btn-mua" href="item.aspx?sp=<%#:Item.MaSP%>">Mua</a></div>--%>
                                </div>
                                <%--                            </div>--%></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <h3 class="tenSP-ls-h3">
                <p class="tenSP-ls-p">Cà Phê</p>
            </h3>
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">

                <asp:ListView ID="ListView4" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetCoffee">

                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No data was returned.</td>
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
                        <div class="col mb-5">
                            <%--<div class="card h-100">  --%>                      <a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">

                                <!-- Product image-->
                                <img class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content;" />

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
                                    <%--                                    <div class="text-center"><a class="btn btn-outline-dark mt-auto btn-mua" href="item.aspx?sp=<%#:Item.MaSP%>">Mua</a></div>--%>
                                </div>
                                <%--                            </div>--%></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <h3 class="tenSP-ls-h3">
                <p class="tenSP-ls-p">Kem Tươi</p>
            </h3>
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">

                <asp:ListView ID="ListView3" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetIceCream">

                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No data was returned.</td>
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
                        <div class="col mb-5">
                            <%--<div class="card h-100">  --%>                      <a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">

                                <!-- Product image-->
                                <img class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content;" />

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
                                    <%--                                    <div class="text-center"><a class="btn btn-outline-dark mt-auto btn-mua" href="item.aspx?sp=<%#:Item.MaSP%>">Mua</a></div>--%>
                                </div>
                                <%--                            </div>--%></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </section>
</asp:Content>
