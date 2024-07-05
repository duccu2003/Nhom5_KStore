<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutOrder.aspx.cs" Inherits="TH03_WebBanHang.checkOutOrder.OutOrder" %>

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
     <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

    </head>
    <body>
        <div class="container">
            <style>
                *{
                    margin:0;
                    padding:0;
                    font-family: Roboto;
                }
                .alert{
                     top:0;
                     position:absolute;
                     width:100%;
                     z-index:9999;
                     padding:10px 0;
                     text-align:center;
                     color:#000;
                 }
                 .alert-success{
                     background:#d4edda;
                     color: #155724;
                     background-color: #d4edda;
                     border-color: #c3e6cb;

                 }
                 .alert-danger{
                         background:#f8d7da;
                          color: #721c24;
                           border-color: #f5c6cb;
                 }
                #tableHoaDon, tr, td, th{
                   
                    border:1px solid #636363;
                    justify-content:center;
                    align-content:center !important;
                    align-items:center !important;
                    justify-items:center;
                    text-align:left;
                   
                    
                }
                table,tr,td, th{
                   border:none !important;
               }
                th{
                   max-width:400px; 
                   flex-wrap:wrap;
                   border-bottom:1px dashed #636363 !important;

                }
                th{
                    padding:10px;
                    
                    
                }
                p{
                    padding:0 5px;
                }
            </style>
            <style>
               .align-top {
                    vertical-align: top;
                }
               body{
                   background:#fff;
               }
               .a-itemsInOrder *{
                   border:none;
               }
               section{
                   background:#FFF;
               }
            </style>
            <div style="width:max-content; height:max-content; margin:5rem auto; border-radius:5px; padding: 5px;  box-shadow:0 0 20px #636363; background:#FFFF;  box-shadow: 0 15px 25px #00000019;">
            <table id="tableHoaDon" style="">
                <tr>
                    <th colspan="3" style="text-align:center;">
                        <h3 class="text-muted">KẾT QUẢ THANH TOÁN</h3>
                    </th>
                </tr>
                <tr style="">
                   <td rowspan="12" style="height:500px; overflow:auto;  margin:0;padding: 0 10px; overflow:auto; font-size:12px; text-align:left;">
                        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetListItemsInOrder">
                            <ItemTemplate>
                                <a title="<%#:Item.TenSP %>" class="align-top" href="../Item.aspx?sp=<%#:Item.MaSP %>" style="border-bottom:1px dashed #636363; text-decoration:none; color:#000; display:flex">
                                    <table class="a-itemsInOrder">
                                        <tr>
                                            <td  rowspan="2"><img style=" object-fit:cover;" width="60" src="../<%#:Item.DuongDan %>"/></td>
                                            <th rowspan="2"><p>x<%#:Item.SoLuong %></p></th>
                                            <th><p><%#:Item.TenSP %></p></th>
<%--                                            <th><p>Pob: <%#:Item.TenPob %></p></th>--%>
                                           <th><p><%#: string.IsNullOrEmpty(Item.TenPob)?"": "Pob: " + Item.TenPob%></p></th>

                                        </tr>
                                        <tr>
                                            <th><p>Giá: <%# string.Format("{0:N0}", Eval("Gia")) %>đ</p></th>
                                            <th><p>Thanh tiền: <%# string.Format("{0:N0}", Eval("ThanhTien")) %>đ</p></th>
                                        </tr>
                                    </table>
                                    <%--<p>x<%#:Item.SoLuong %> - <%#:Item.TenSP %></p>
                                    <p>Pob: <%#:Item.TenPob %></p>
                                    <p>Giá: <%# string.Format("{0:N0}", Eval("ThanhTien")) %>đ</p>--%>
                                </a>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>

                    <th><p>Thông báo: </p></th>
                     <th><div runat="server" id="displayMsg"></div></th>
                </tr>
                <%--<tr>
                    <th><p>Mã Website (Terminal ID): </p></th>
                    <th><div runat="server" id="displayTmnCode"></div></th>
                </tr>--%>
                <tr>
                    <th><p>Mã giao dịch thanh toán: </p></th>
                     <th><div runat="server" id="displayTxnRef"></div></th>
                </tr>
               <%-- <tr>
                    <th><p>Mã giao dịch tại Momo: </p></th>
                     <th><div runat="server" id="displayVnpayTranNo"></div></th>
                </tr>--%>
                 <tr>
                     <th><p>Số tiền thanh toán (VND): </p></th>
                      <th><div runat="server" id="displayAmount"></div></th>
                 </tr>
                <%--<tr>
                    <th><p>Ngân hàng thanh toán: </p></th>
                     <th><div runat="server" id="displayBankCode"></div></th>
                </tr>--%>
                <tr>
                    <th><p>Đơn hàng có mã: </p></th>
                     <th><div runat="server" id="displayOrderCode"></div></th>
                </tr>
                <tr>
                    <th><p>Ngày tạo đơn: </p></th>
                     <th><div runat="server" id="displayDateCreate"></div></th>
                </tr>
                <tr>
                    <th><p>Họ tên người nhận: </p></th>
                     <th><div runat="server" id="displayClientName"></div></th>
                </tr>
                 <tr>
                     <th><p>Email người nhận: </p></th>
                      <th><div runat="server" id="txtEmailNN"></div></th>
                 </tr>
                 <tr>
                     <th><p>Số điện thoại người nhận: </p></th>
                      <th><div runat="server" id="displayClientPhone"></div></th>
                 </tr>
                 <tr>
                     <th><p>Địa chỉ người nhận: </p></th>
                      <th><div runat="server" id="displayClientLocate"></div></th>
                 </tr>
                <tr>
                    <th><p>Chi nhánh tạo đơn: </p></th>
                     <th><div runat="server" id="displayBranhLocate"></div></th>
                </tr>
                <tr>
                    <th><p>Phương thức giao dịch: </p></th>
                     <th><div runat="server" id="txtPTGD"></div></th>
                </tr>
                <tr>
                    <th><p>Giao dịch: </p></th>
                     <th><div runat="server" id="txtGiaoDich"></div></th>
                </tr>
            </table>

            </div>
            <div style="margin:auto; text-align:center;">
            <a style="text-decoration:none; padding:10px; border-radius:5px; background:#fff; border:1px solid #636363; color:#000; font-weight:bold;" href="../Default.aspx">Tiếp tục mua sắm <i class="fa-solid fa-arrow-right"></i></a>
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
        </div>
    </body>
</html>
