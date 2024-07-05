<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="TH03_WebBanHang.Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .notification {
            display: none;
            position: fixed;
            top: 15%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: #fff;
            padding: 0 50px;
            border-radius: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
            text-align: center;
            justify-content: center;
            align-items: center;          
            flex-direction: column;
        }

        .notification img {
            width: 70%;
        }
    </style>
    <div id="notification" class="notification">
        <img src="Content/icon/Success.gif" alt="">
        <p>Thêm vào giỏ hàng thành công!</p>
    </div>
    <script>
        // JavaScript để hiển thị thông báo sau khi ấn nút
        document.addEventListener("DOMContentLoaded", function () {
            // Sử dụng class của nút thêm vào giỏ hàng để lắng nghe sự kiện click
            const addToCartBtn = document.querySelector('.btn-mua');
            const notification = document.getElementById('notification');

            addToCartBtn.addEventListener('click', function () {
                // Hiển thị thông báo
                notification.style.display = 'flex';

                // Ẩn thông báo sau 2 giây
                setTimeout(function () {
                    notification.style.display = 'none';
                }, 2000);
            });
        });
    </script>

    <section class="py-5">
        <div class="container px-4 px-lg-5 my-5">
            <div class="row gx-4 gx-lg-5 align-items-center">

                <asp:FormView ID="productDetail" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetDetails" RenderOuterTable="false">
                    <ItemTemplate>
                        <div class="col-md-6" id="slSP">
                            <img class="card-img-top mb-5 mb-md-0" src="<%#:Item.DuongDan%>" alt="..." />

                        </div>
                        <div class="col-md-6">
                            <div class="small mb-1"></div>
                            <h1 class="display-5 fw-bolder"><%#:Item.TenSP%></h1>
                            <div class="fs-5 mb-5">
                                <span class="<%--text-decoration-line-through--%>"><%# string.Format("{0:N0}", Item.Gia) %>đ</span>
                                <%--                                <span>$40.00</span>--%>
                            </div>
                            <p class="lead"><%#:Item.MoTa%></p>

                            <style>
                                .product-tomping {
                                    display: inline-block;
                                    margin-right: 10px; /* Điều chỉnh khoảng cách giữa các sản phẩm */
                                }

                                    .product-tomping:hover {
                                        background-color: lightgreen;
                                    }

                                .img-wrapper {
                                    text-align: center; /* Căn giữa ảnh */
                                }

                                .text-wrapper {
                                    text-align: center; /* Căn giữa chữ */
                                }

                                .img-tomping {
                                    text-align: center;
                                }
                            </style>
                            <%--<asp:ListView ID="lsTomping" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetTomping">
                                <ItemTemplate>
                                    <div id="tomPing" class="product-tomping" style="border-radius: 8px; width: 80px; height: 100px; text-align: center; display: inline-table; margin-bottom: 20px;">
                                        <!-- Ảnh -->
                                        <div class="img-wrapper" style="display: inline-flex;">
                                            <img class="img-tomping" src="<%# Eval("DuongDan") %>" alt="..." style="max-width: 100%; border-top-left-radius: 10px; border-top-right-radius: 10px;" />
                                        </div>
                                        <!-- Chữ -->
                                        <div class="text-wrapper" style="width: 100%; height: 20px; text-align: center;">
                                            <p style="font-size: 10px;" class="display-5 fw-bolder"><%# Eval("TenSP") %></p>
                                        </div>
                                        <asp:CheckBox ID="cbTomping" runat="server" Text='' Style="position: relative; bottom: 0;"></asp:CheckBox>

                                    </div>
                                    
                                </ItemTemplate>
                            </asp:ListView>--%>



                            <div class="d-flex">

                                <asp:Button ID="Button1" runat="server" Text="Thêm vào giỏ hàng" OnClick="AddToCart_Click" class="btn btn-outline-dark flex-shrink-0 btn-mua" />

                                <i class="bi-cart-fill me-1"></i>


                            </div>
                        </div>


                    </ItemTemplate>
                </asp:FormView>
            </div>
        </div>

    </section>

    <!-- Product section-->



    <!-- Related items section-->
    <section class="py-5 bg-light">
        <div class="container px-4 px-lg-5 mt-5">
          <%--  <h2 class="fw-bolder mb-4 tenSP-ls-h3">--%><%--Related products--%> <%--<p class="tenSP-ls-p">Các Món Tương Tự</p></h2>--%>
           <%-- <style>
                .tenSP-ls-h3 {
                padding-bottom: 1.5rem;
                text-align: center;
                font-weight: bolder;
                font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                color: #CCBEB1;
                width: 100%;
            }

            .tenSP-ls-p {
                width: max-content;
                padding: 8px;
                margin: auto;
                border-bottom-color:#000 ;
                border:1px solid;
                border-top-style:none;
                border-left-style:none;
                border-right:none;
            }</style>--%>
            
            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">
                <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetPhones">

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
                            <%--<div class="card h-100">--%><a class="btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">
                                <!-- Product image-->

                                <img class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." /><style>
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
<%--                            </div>--%></a>
                        </div>

                        <style>                            .btn-mua:hover {
                                background-color:#FBF4F1;
                                color:#212529;
                            }
                        </style>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </section>

</asp:Content>
