<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Momo_return.aspx.cs" Inherits="TH03_WebBanHang.Momo.Momo_return" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>BILL</title>
        <link href="Styles/bootstrap.min.css" rel="stylesheet" />
         <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
            <link rel="preconnect" href="https://fonts.googleapis.com">
            <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
            <link href="https://fonts.googleapis.com/css2?family=Basic&display=swap" rel="stylesheet">
    </head>
    <body>
        <%--<div class="container">
            <style>
                *{
                    margin:0;
                    padding:0;
                    font-family: Roboto;
                }
               
                #tableHoaDon, tr, td, th{
                   
                    border:1px solid #636363;
                    justify-content:center;
                    align-content:center !important;
                    align-items:center !important;
                    justify-items:center;
                    text-align:left;
                   
                    
                }
               
                th{
                   max-width:400px; 
                   flex-wrap:wrap;
                }
                th{
                    padding:10px;
                }
                p{
                    padding:0 10px;
                }
            </style>
            <style>
               .align-top {
                    vertical-align: top;
                }
               body{
                   background:#242426;
               }
            </style>

            <table id="tableHoaDon" style="margin:5rem auto; box-shadow:0 0 20px #636363; background:#e4e4e4;">
                <tr>
                    <th colspan="3" style="text-align:center;">
                        <h3 class="text-muted">Kết quả thanh toán</h3>
                    </th>
                </tr>
                <tr>
                   <td rowspan="7" style="margin:0; overflow:auto;">
                        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetListItemsInOrder">
                            <ItemTemplate>
                                <a class="align-top" href="../Item.aspx?sp=<%#:Item.MaSP %>">
                                    <p>x<%#:Item.SoLuong %> <%#:Item.TenSP %></p>
                                    <p>Giá <%# string.Format("{0:N0}", Eval("ThanhTien")) %>đ</p>
                                </a>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>

                    <th><p>Thông báo: </p></th>
                     <th><div runat="server" id="displayMsg"></div></th>
                </tr>
                <tr>
                    <th><p>Mã Website (Terminal ID): </p></th>
                    <th><div runat="server" id="displayTmnCode"></div></th>
                </tr>
                <tr>
                    <th><p>Mã giao dịch thanh toán: </p></th>
                     <th><div runat="server" id="displayTxnRef"></div></th>
                </tr>
                <tr>
                    <th><p>Mã giao dịch tại Momo: </p></th>
                     <th><div runat="server" id="displayVnpayTranNo"></div></th>
                </tr>
                 <tr>
                     <th><p>Số tiền thanh toán (VND): </p></th>
                      <th><div runat="server" id="displayAmount"></div></th>
                 </tr>
                <tr>
                    <th><p>Ngân hàng thanh toán: </p></th>
                     <th><div runat="server" id="displayBankCode"></div></th>
                </tr>
                <tr>
                    <th><p>Đơn hàng có mã: </p></th>
                     <th><div runat="server" id="displayOrderCode"></div></th>
                </tr>
            </table>
            <div style="margin:auto; text-align:center;">
            <a style="text-decoration:none; padding:10px; border-radius:10px; background:#ccc; border:1px solid #636363; color:#242426;" href="../Default.aspx">Tiếp tục mua sắm</a>
           </div> <%--<div class="header clearfix">
                
                
            </div>--%>
            <%--<div class="table-responsive">
                 <div runat="server" id="displayMsg"></div>
            </div> --%>
           <%-- <div class="table-responsive">
                 <div runat="server" id="displayTmnCode"></div>
            </div>--%>
             <%--<div class="table-responsive">
                 <div runat="server" id="displayTxnRef"></div>
            </div> --%>
             <%--<div class="table-responsive">
                 <div runat="server" id="displayVnpayTranNo"></div>
            </div> --%>
            <%--<div class="table-responsive">
                 <div runat="server" id="displayAmount"></div>
            </div--%>
            <%--<div class="table-responsive">
                 <div runat="server" id="displayBankCode"></div>
            </div> --%>
          <%--  <div class="table-responsive">
                 <div runat="server" id="displayOrderCode"></div>
            </div> --%>
        <%--</div>--%>
        <h1>Đợi xác nhận đơn...</h1>
    </body>
</html>
