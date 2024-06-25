<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TH03_WebBanHang.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Product section-->
    <section class="py-5">
        <div class="container px-4 px-lg-5 my-5">
            <div class="row gx-4 gx-lg-5 align-items-center">
                <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetCart">


                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td style="text-align:center;"><%--No data was returned.--%>Giỏ hàng rỗng.</td>
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
                        <tr class="cart-list">
                            <td><%#:Item.TenSP%></td>
                            <td>
                                <img style="width: 150px;" class="card-img-top h-100" src="<%#:Item.DuongDan%>" alt="..." /></td>
                            <td><%#:Item.SoLuong%></td>
                            <td><%# string.Format("{0:N0}", Item.Gia) %></td>
                            <td><%# string.Format("{0:N0}", Item.ThanhTien) %></td>
                            <!-- Add buttons for deleting and changing items -->
                            <td>
                                <asp:Button ID="btnDelete" runat="server" Text="-" CommandArgument='<%#:Item.MaSP%>' OnClick="btnDelete_Click" CssClass="btn btn-danger" />
                                <asp:Button ID="btnChange" runat="server" Text="+" CommandArgument='<%#:Item.MaSP%>' OnClick="btnChange_Click" CssClass="btn btn-warning" />
                            </td>
                        </tr>
                    </ItemTemplate>

                    <LayoutTemplate>
                        <table class="table table-bordered" id="groupPlaceholderContainer" runat="server" style="width: 100%">
                            <thead>
                                <tr class="cart-list">

                                    <th>Tên</th>
                                    <th>Ảnh</th>
                                    <th>Số lượng</th>
                                    <th>Đơn giá</th>
                                    <th>Thành tiền</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="groupPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                </asp:ListView>
                <div>

                    <b>Tổng tiền:</b>
                    <asp:Label ID="lbTongThanhToan" runat="server" Text="0"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnDathang" runat="server" Text="Đặt hàng" OnClick="btnDathang_Click" />
                   <%-- <style>                        #btnDathang {
                            padding:10px;
                            border: 1px solid #ccc;
                            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
                            b
                        }
                        #btnDathang {
            background-color:#CCBEB1;
        }
        #btnDathang:hover {
            background-color:#cbb39c;
            color:#636161;
        }
                    </style>--%>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
