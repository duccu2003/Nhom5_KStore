<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailOrder.aspx.cs" Inherits="TH03_WebBanHang.DetailOrder" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>BILL</title>
        <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
        <link href="Styles/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"/>
         <link rel="preconnect" href="https://fonts.googleapis.com"/>
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
        <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
            <link rel="preconnect" href="https://fonts.googleapis.com"/>
            <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
            <link href="https://fonts.googleapis.com/css2?family=Basic&display=swap" rel="stylesheet"/>
     <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"/>


            <style>
               

        #loader {
    position: fixed;
    top: 0;
    left: 0;
    z-index: 99999;
    width: 100%;
    height: 100%;
    background-color: #FFFF;
    transition: all 0.3s ease-in-out;
    text-align:center;
    justify-content:center;
align-content:center;
align-items:center;
justify-items:center;
text-align:center;
}
.circle {
    justify-content:center;
    align-content:center;
    align-items:center;
    justify-items:center;
    text-align:center;
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

@-webkit-keyframes circle_dot { 100% { -webkit-transform: rotate(360deg) }}
@keyframes circle_dot { 100% { transform: rotate(360deg); -webkit-transform: rotate(360deg) }}

@-webkit-keyframes circle_bounce {
    0%, 100% { -webkit-transform: scale(0.0) }
    50%      { -webkit-transform: scale(1.0) }
}

@keyframes circle_bounce {
    0%, 100% { 
        -webkit-transform: scale(0.0);
                transform: scale(0.0);
    } 50% { 
        -webkit-transform: scale(1.0);
                transform: scale(1.0);
    }
}
    </style>
        <script src="https://code.jquery.com/jquery-latest.js"></script>
<script>
var loader = function() {
    setTimeout(function() {
        $('#loader').css({ 'opacity': 0, 'visibility':'hidden' });
    }, 1000);
};
$(function(){
    loader();
});
</script>
    </head>
    <body style="overflow-x:hidden;">
        <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
                     <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />

        <form id="form1" runat="server" class="container" style="position:relative; padding-top:20px;">
            <div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
                 <a title="Thoát" class="dropdown-item" href="Account.aspx" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
                 <a title="In hóa đơn này" href="javascript:void(0);" onclick="printDiv('TheBill')" style="padding:5px; color:#000; cursor:pointer; z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-print" style="margin-right: 5px; width: 35px;"></i></a>
                 <a  title="Tải hóa đơn này" href="javascript:void(0);" onclick="CreatePDFfromHTML()" style="padding:5px; color:#000; cursor:pointer; z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-download" style="margin-right: 5px; width: 35px;"></i></a>
            </div>
            <style> 
                *{
                    padding:0;
                    margin:0;
                    font-family:Roboto;
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
                   background:#F7F7F7;
               }
            </style>
            <div id="TheBill" style="width:max-content; height:max-content; margin: auto; border-radius:5px; padding: 5px;  box-shadow:0 0 20px #636363; background:#FFFF;  box-shadow: 0 15px 25px #00000019; border:1px solid #000;">
            <table id="tableHoaDon" style="">
                <tr style="max-height:125px;">
                    <th style="text-align:center; height:125px;">
                        <img style="width:auto; height:115px;" src="Content/logo/K-Photoroom.png"/>

                    </th>
                    <th style="text-align:center; row-gap:10px; height:125px;">
                        <h1 class="text-muted">HÓA ĐƠN ĐIỆN TỬ</h1>
<%--                        <div style="display:flex; width:max-content; margin:auto;">Mã hóa đơn: <div runat="server" id="displayOrderCode"></div></div>--%>
                        <div runat="server" id="displayDateCreate"></div>
                    </th>
                    <th style="text-align:center;  height:125px;">
                        <div style="gap:10px; display:flex; text-align:center; justify-content:center; align-content:center; margin:auto; width:100%;">
                            <img src="~/Content/logo/K.png" style="width:85px; height:85px;" id="imgQRCodeLink" runat="server"  alt="QRBill" />
                            <ul style="width:50%; text-align:left; row-gap:0; gap:0; list-style:none; align-content:center; align-items:center; justify-content:center; justify-items:center;">
                                <li><h5>Nhà cung cấp KSTORE trực thuộc tại Công ty KS Town</h5></li>
                                <li><div style="display:flex;">
                                    <h5 runat="server" id="displayBranhLocate"></h5>
                                </div></li>
                                <li><h5>Số liên lạc: 0389800308</h5></li>
                                <li><h6>Quét mã QR truy cập hóa đơn online</h6></li>
                            </ul>

                        </div>
                    </th>
                </tr>
                <tr style="">
                   <td rowspan="12" style="border:2px double #636363 !important; height:500px; overflow:auto;  margin:0;padding: 0 10px; overflow:auto; font-size:12px; text-align:left;">
                        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetListItemsInOrder">
                            <ItemTemplate>
                                <a title="<%#:Item.TenSP %>" class="align-top" href="../Item.aspx?sp=<%#:Item.MaSP %>" style="border-bottom:1px dashed #636363; text-decoration:none; color:#000; display:flex">
                                    <table class="a-itemsInOrder">
                                        <tr>
                                            <td id="tdIMG"  rowspan="2"><img style=" object-fit:cover;" width="60" src="../<%#:Item.DuongDan %>"/></td>
                                            <th rowspan="2"><p>x<%#:Item.SoLuong %></p></th>
                                            <th><p><%#:Item.TenSP %></p></th>
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

                   <%-- <th><p>Thông báo: </p></th>
                     <th><div runat="server" id="displayMsg"></div></th>--%>
                    <th style="border:2px double #636363 !important;"><p>Mã đơn hàng: </p></th>
                    <th style="border:2px double #636363 !important;"><div runat="server" id="displayOrderCode"></div></th>
                </tr>

                <%--<tr>
                    <th><p>Mã Website (Terminal ID): </p></th>
                    <th><div runat="server" id="displayTmnCode"></div></th>
                </tr>--%>
                <tr>
                    <th style="border:2px double #636363 !important;"><p>Mã giao dịch thanh toán: </p></th>
                     <th style="border:2px double #636363 !important;"><div runat="server" id="displayTxnRef"></div></th>
                </tr>
               <%-- <tr>
                    <th><p>Mã giao dịch tại Momo: </p></th>
                     <th><div runat="server" id="displayVnpayTranNo"></div></th>
                </tr>--%>
                 <tr>
                     <th style="border:2px double #636363 !important;"><p>Số tiền thanh toán (VND): </p></th>
                      <th style="border:2px double #636363 !important;"><div runat="server" id="displayAmount"></div></th>
                 </tr>
                <%--<tr>
                    <th><p>Ngân hàng thanh toán: </p></th>
                     <th><div runat="server" id="displayBankCode"></div></th>
                </tr>--%>
                
                <%--<tr>
                    <th><p>Ngày tạo đơn: </p></th>
                     <th><div runat="server" id="displayDateCreate"></div></th>
                </tr>--%>
                <tr>
                    <th style="border:2px double #636363 !important;"><p>Họ tên người nhận: </p></th>
                     <th style="border:2px double #636363 !important;"><div runat="server" id="displayClientName"></div></th>
                </tr>
                 <tr>
                     <th style="border:2px double #636363 !important;"><p>Email người nhận: </p></th>
                      <th style="border:2px double #636363 !important;"><div runat="server" id="txtEmailNN"></div></th>
                 </tr>
                 <tr>
                     <th style="border:2px double #636363 !important;"><p>Số điện thoại người nhận: </p></th>
                      <th style="border:2px double #636363 !important;"><div runat="server" id="displayClientPhone"></div></th>
                 </tr>
                 <tr>
                     <th style="border:2px double #636363 !important;"><p>Địa chỉ người nhận: </p></th>
                      <th style="border:2px double #636363 !important;"><div runat="server" id="displayClientLocate"></div></th>
                 </tr>
               <%-- <tr>
                    <th><p>Chi nhánh tạo đơn: </p></th>
                     <th><div runat="server" id="displayBranhLocate"></div></th>
                </tr>--%>
                <tr>
                    <th style="border:2px double #636363 !important;"><p>Phương thức giao dịch: </p></th>
                     <th style="border:2px double #636363 !important;"><div runat="server" id="txtPTGD"></div></th>
                </tr>
                <tr>
                    <th style="border:2px double #636363 !important;"><p>Giao dịch: </p></th>
                     <th style="border:2px double #636363 !important;"><div runat="server" id="txtGiaoDich"></div></th>
                </tr>
                
            </table>
            <div style="border:2px double #636363;">
                 <div style="text-align:center; display:flex; padding:20px 10px; width:100%;" class="d-flex">
                     <div class="col-sm-4 d-grid" style="width:32.5%;">
                         <h3>NGƯỜI NHẬN HÀNG</h3>
                         <p>(Ký, đóng dấu)</p>
                         <div style="border:2px solid #636363; width:80%; height:150px; margin:10px auto;">

                        </div>
                     </div>
                     <div class="col-sm-4 d-grid" style="width:32.5%;">
                        <h3>CƠ QUAN THUẾ</h3>
                        <p>(Ký, đóng dấu)</p>
                         <div style="border:2px solid #636363; width:80%; height:150px;  margin:10px auto;">

                        </div>
                    </div>
                     <div class="col-sm-4 d-grid" style="width:32.5%;">
                        <h3>NGƯỜI BÁN HÀNG</h3>
                        <p>(Ký, đóng dấu)</p>
                         <div style="border:2px solid #636363; width:80%; height:150px;  margin:10px auto;">

                         </div>
                    </div>
                 </div>
                 <div style="text-align:center; display:grid; padding:20px 10px; width:100%;">
                     <p>(Cần khiểm tra, đối chiếu khi lập, giao nhận hóa đơn)</p>
                     <p>Được cho phép kiểm tra hàng trước.</p>
                     <p>Đối với những đơn hàng COD yêu cầu đưa tiền rồi mới được nhận hàng.</p>
                 </div>

            </div>
            </div>

            <style>
                .btn-done{
                    width:200px;
                }
            </style>
            <div style="margin:1rem auto; text-align:center;">
<%--            <a style="text-decoration:none; padding:10px; border-radius:5px; background:#fff; border:1px solid #636363; color:#000; font-weight:bold;" href="../Default.aspx">Tiếp tục mua sắm <i class="fa-solid fa-arrow-right"></i></a>--%>
        
             <asp:Button ID="btnDel" runat="server" Text="Xóa đơn" OnClick="btDel_Click" CssClass="btn-done" style="text-decoration:none; padding:10px; border-radius:5px; background:#fff; border:1px solid #636363; color:#000; font-weight:bold;"/>
             <asp:Button ID="btDone" runat="server" Text="Xác nhận" OnClick="btDone_Click" CssClass="btn-done" style="text-decoration:none; padding:10px; border-radius:5px; background:#fff; border:1px solid #636363; color:#000; font-weight:bold;"/>
 
          <%--<div class="header clearfix">
                
                
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
            <div id="editor"></div>

        </form>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
        <script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
        <script>
            function printDiv(divId) {

                //if (document.getElementById('tdIMG').style.display != "none") document.getElementById('tdIMG').style.display = "none";

                var printContents = document.getElementById(divId).innerHTML;
                var originalContents = document.body.innerHTML;

                document.body.innerHTML = printContents;

                window.print();

                document.body.innerHTML = originalContents;
            }

        </script>
        <script>
            function CreatePDFfromHTML() {

                //if (document.getElementById('tdIMG').style.display != "none") document.getElementById('tdIMG').style.display = "none";

                var HTML_Width = $("#TheBill").width();
                var HTML_Height = $("#TheBill").height();
                var top_left_margin = 15;
                var PDF_Width = HTML_Width + (top_left_margin * 2);
                var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
                var canvas_image_width = HTML_Width;
                var canvas_image_height = HTML_Height;

                var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

                html2canvas($("#TheBill")[0]).then(function (canvas) {
                    var imgData = canvas.toDataURL("image/jpeg", 1.0);
                    var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
                    pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
                    for (var i = 1; i <= totalPDFPages; i++) {
                        pdf.addPage(PDF_Width, PDF_Height);
                        pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
                    }
                    pdf.save("KSTORE_Hoa_Don_Cua_Don_Hang_" + document.getElementById('displayOrderCode').textContent +".pdf");
                    
                });
            }
        </script>
    </body>
    
</html>

