<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="TH03_WebBanHang.Pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
             
            .branchList *{
                color:#fff !important;
            }

            .menu-links {
                display: flex;
                justify-content: center;
            }

            .menu-link {
                text-align: center;
                margin: 0 10px; /* Khoảng cách giữa các liên kết */
                text-decoration: none;
                color: black;
                border:0.5px solid #9b51e0;
                box-shadow:2px 2px 18px #9b51e0;
                padding:10px;
                margin:8% 2%;
                border-radius:10px;
                --bs-btn-active-bg: #9b51e0;
                --bs-btn-disabled-color: #9b51e0;
                background-color:#eeeeee;
            }
            .menu-link:hover {
            background-color:#FBF4F1;
                                            color:#56157c;

            }
            .menu-link img {
                width: 160px; /* Kích thước của hình ảnh */
                height: 160px; /* Kích thước của hình ảnh */
                display: block; /* Để canh chỉnh hình ảnh */
                margin: 0 auto 5px; /* Canh chỉnh hình ảnh theo chiều dọc */
            }

            .menu-link h6 {
                margin: 0; /* Loại bỏ khoảng trắng xung quanh tiêu đề */
            }
            a{text-decoration:none;}
            .tenSP-ls-h3 {
                padding-bottom: 1.5rem;
                text-align: center;
                font-weight: bolder;
                font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                color: #9b51e0;
                width: 100%;
            }

            .tenSP-ls-p {            
                color: #9b51e0;
                width: max-content;
                padding: 8px;
                margin: auto;
                border-bottom-color:#000 ;
                border:1px solid;
                border-top-style:none;
                border-left-style:none;
                border-right:none;
            }
            .menu-link img{padding:1.5rem !important;}
            .btn-header-u-c *{
                color:#fff !important;
            }
        </style>
        <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Thanh Toán</p></h2>

  <%--  <div class="menu-links">
        <a class="menu-link xn" href="#!" id="tm">
            <img src="Content/icon/money.png" alt="Image 1">
            <h6>Thanh Toán Tiền Mặt</h6>
        </a>
        <a class="menu-link" href="PayCard.aspx">
            <img src="Content/icon/operation.png" alt="Image 2">
            <h6>Thanh Toán Số Thẻ</h6>
        </a>
        <a class="menu-link qr" href="PayQR.aspx" id="qr">
            <img src="Content/icon/qr-code.png" alt="Image 3">
            <h6>Thanh Toán Mã QR</h6>
        </a>
    </div>
    <div id="confirmationBox" class="confirmation-box">
    <div class="confirmation-content">--%>

              
        <style>                    
            #ddlGT {
                padding:8px;
                text-align:center;
                margin-bottom:10px;
                border-radius:5px;
            } 
            #fg-li{text-align:right;}
            #sgin-li{text-align:left;}
            #btnSignIn {
                background-color:#9b51e0;
            }
            .ul-sg-fg {
                display: flex;
                list-style: none;
                gap: 20%;
                justify-content: center;
                margin-bottom: 3%;
            }
             .signin-password {
                font-size: 12px;
                color: #000;
                text-decoration: none;
                display: block;
                margin-top: 10px;
            }

            .signin-password:hover {
                text-decoration: underline;
            }
            .forgot-password {
                font-size: 12px;
                color: #666;
                text-decoration: none;
                display: block;
                margin-top: 10px;
            }

                .forgot-password:hover {
                    text-decoration: underline;
                }.input-field{
                     color:#000 !important;
                     margin:0.4rem 0;
                     border-radius:2.5px;
                     padding:5px 8px;
                     width:18rem;
                     height:58px;
                     border:none;
                     min-width:18rem;
                 }
                 .input-field-DiaChi{
                     color:#000 !important;
                     margin:0.4rem 0;
                     border-radius:2.5px;
                     padding:0 8px;
                     border:none;
                    height:58px;
                    width:100% !important;
                    min-width:18rem;

                    
       
                 }
                  .input-field-Phone{
                 color:#000 !important;
                 margin:0.4rem 0 0 0;
                 border-radius:2.5px;
                 padding:0 10px;
                 border:none;
                height:58px;
                 width:16rem;
                 /*text-align:center;*/
             }
                  section{
                      background:linear-gradient(to top, black, #242426, black);
                  }
        </style>
  
   <section class="py-5">
       <div class="d-flex container" style="margin-top:3rem; border-radius:2.5px; background:#000; box-shadow:0 0 20px #636363; /*background:linear-gradient(to left,#9b51e0, black);*/ width:max-content; box-shadow:0 0 5px #636363; /*border:1px solid #636363;*/">        
<div class="d-grid" style="height:max-content; max-height:70vh; overflow:auto; color:#fff;">
            <asp:ListView ID="ListViewGioHang" runat="server">
    <ItemTemplate>
        <div class="d-flex p-5" style="gap:2rem;">    
             

            <a href="Item.aspx?sp=<%# Eval("MaSP") %>"><img title="<%# Eval("TenSP") %>"  src='<%# Eval("DuongDan") %>' alt='<%# Eval("TenSP") %>' style="width:100px;height:100px;" /></a>
            <div class="d-grid"> 
                 <a href="Item.aspx?sp=<%# Eval("MaSP") %>"><h5 style="color:#fff;"><%# Eval("TenSP") %></h5></a>
            <%--<p>Số lượng: <%# Eval("SoLuong") %></p>--%>
            <p style="color:#fff;"><%#:string.IsNullOrEmpty(Eval("TenPob") as string)?"":"Pob: "+ Eval("TenPob") %></p>

            <p style="color:#fff;">Giá:  <%# string.Format("{0:N0}",Eval("Gia")) %>đ</p>
            <p style="color:#fff;">Thành tiền: <%# string.Format("{0:N0}", Eval("ThanhTien")) %>đ</p>
                                   <style>
                                    p{
                                        margin:0;
                                    }
                                    .btn-p-m{
                                        width:1.5rem;
                                        padding:0;
                                        background-color:#fff;
                                        border:none;
                                        border-radius:50%;
                                         margin:0 0.4rem;
                                         height:1.5rem;
                                        
                                    }
                                    .btn-p-m:hover{
  
                                        border:1px solid #000;
                                                                                background-color:#000;

    
}                                    .btn-p-m:active{
  
                                        border:1px solid #000;
                                        background-color:#000;
    
}

                                     .btnXoaSP{
                                         transition:0.5s;
                                     }
                                     .btnXoaSP:hover{
                                        transform:scale(1.1);
                                        box-shadow:0 0 50px #636363;
                                        background-color:orangered !important;
                                        
                                    }
                                </style>
                
                                               <div class="d-flex" style="margin:5px 0;">         
                     <%--<p style="color:#fff;">Số lượng:
<div style="position:relative; margin-left:4rem;" class="d-flex">--%>
<asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btnDelete_Click" CssClass="btn btn-danger btn-p-m btnTG" ImageUrl="~/Content/icon/g-minus.png" />
     <p style="color:#fff; background:linear-gradient(to left, #11B588,#06BCCF); width:3rem; height:25px; border-radius:10px; text-align:center;"><%# Eval("SoLuong") %></p>
<asp:ImageButton ID="btnChange" runat="server" CommandArgument='<%# Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btnChange_Click" CssClass="btn btn-warning btn-p-m btnTG" ImageUrl="~/Content/icon/g-plus.png" />
<style>
    .btnTG{
        transition:0.5s;
    }
    .btnTG:hover{
        transform:scale(1.2);
        box-shadow:0px 0px 50px #636363;
    }
</style>

<%--</div></p>--%>
                    
</div>                                 
            <asp:Button ID="btnXoa" runat="server" Text="X" title="Xóa sản phẩm khỏi đơn hàng" CssClass="btnXoaSP" CommandArgument='<%# Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btnXoa_Click" style=" background:#000; /*background:linear-gradient(to left, #522A77, #2a2e77);*/ color:#fff; border:1px solid #636363; border-radius:20px; width:35px; height:35px; padding:1px; margin:10px 0" />
            </div>
        </div>
    </ItemTemplate>
</asp:ListView>



        </div>
        <div class=" d-grid p-5 text-center justify-content-center align-content-center" style="background:#0000007c; width:max-content; ">
            <div class=" d-flex" style="gap:10px">
                    <asp:TextBox ID="txtEmailSignUp" type="email" runat="server" placeholder="Email" CssClass="input-field"></asp:TextBox>
<asp:TextBox ID="txtName" runat="server" type="text" placeholder="Họ và tên" CssClass="input-field"></asp:TextBox>
<%--<asp:DropDownList ID="ddlGT" runat="server" CssClass="input-field" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" style="width:max-content;padding:5px;" Font-Size="small">
    <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam"></asp:ListItem>
    <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ"></asp:ListItem>
    <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác"></asp:ListItem>

</asp:DropDownList>--%>

<%--<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" style="width:12rem"  CssClass="input-field">
</asp:DropDownList>

<asp:DropDownList ID="ddlDistrict" runat="server" style="width:12rem" CssClass="input-field">
</asp:DropDownList>--%>
            <style>
                .input-field,#ddlCity,*{
                    color:#000;
                }
            </style>
           </div>
<div class=" d-flex" style="gap:10px">
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="input-field" style="padding:  8px 5px;width:18rem; color:#000;">
</asp:DropDownList>
    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="input-field" style="padding: 8px 5px; width:18rem;margin-top:0.4rem ;float:left; color:#000;">
</asp:DropDownList>

     

</div>
            <div class=" d-flex" style="gap:10px">
            <asp:DropDownList ID="ddlW" runat="server" AutoPostBack="True" CssClass="input-field" style="padding: 8px 5px;width:18rem; margin-top:0.4rem;color:#000;" >
</asp:DropDownList>      
             <asp:TextBox ID="txtDiachi" type="text" runat="server" style="" placeholder="Địa chỉ" CssClass="input-field-DiaChi"></asp:TextBox>
                </div>
            <div class="d-flex" style="gap:10px">         <asp:TextBox ID="TextPhone"  runat="server" placeholder="Số điện thoại" CssClass="input-field-Phone" style="width:18rem;"></asp:TextBox>
                <div style="height:58px; margin:0.4rem auto; display:flex; align-content:center; align-items:center; padding:2.5px; gap:5px; background:#fff;" class="input-field">
                            
                           <asp:Image ID="imgPaymentMethod" ImageUrl="~/Content/icon/iconCOD.png" style="width:54px; border-radius:4px; height:54px; align-content:center; align-items:center;" runat="server" />

                            <asp:DropDownList ID="ddlPay" runat="server" OnSelectedIndexChanged="ddlPay_SelectedIndexChanged" AutoPostBack="True" style="width:14rem !important; height:100%; min-width:14rem !important; color:#000;" >
                                <asp:ListItem ID="txtTM" Text="Thanh toán khi nhận hàng" Value="TM" style="color:#000;"></asp:ListItem> 
                                <asp:ListItem ID="MOMO" Text="Thanh toán bằng Mono" Value="MOMO" style="color:#000;"></asp:ListItem>
                               <%-- <asp:ListItem ID="bankcode_Default" Text="Thanh toán bằng VNPay" Value="postVNPAYQR" style="color:#000;"></asp:ListItem>--%>
                                <%-- <asp:ListItem ID="bankcode_Vnpayqr" Text="Thanh toán qua ứng dụng hỗ trợ VNPAYQR" Value="appVNPAYQR" style="color:#000;"></asp:ListItem>--%>
                                <%--<asp:ListItem ID="bankcode_Vnbank" Text="Thẻ nội địa (VNPay)" Value="atnVNBank" style="color:#000;"></asp:ListItem>
                                <asp:ListItem ID="bankcode_Intcard" Text="Thẻ quốc tế (VNPay)" Value="intVNPay" style="color:#000;"></asp:ListItem>--%>
                                 <asp:ListItem ID="bankcode_Default" Text="Thanh toán bằng VNPay" Value="VNPAY" style="color:#000;"></asp:ListItem>


                                <%--<asp:ListItem ID="txtPayCard" Text="Chuyển khoản" Value="PAY" style="color:#000;"></asp:ListItem>--%>
                                <%--<asp:ListItem ID="txtQR" Text="Quét mã (QR) 📲" Value="QR" style="color:#000;"></asp:ListItem>--%>
 
                            </asp:DropDownList>
                            
                            </div>

            </div>
             <asp:Label runat="server" ID="lbTong" style="font-size:xx-large; padding-left:1rem; color:#fff; font-weight:bolder; margin:0.5rem 0"></asp:Label>

            

            <div class="d-flex" style="gap:10px;">
        <asp:Button ID="btnCancel" runat="server" title="Hủy giao dịch này" Text="HỦY GIAO DỊCH" OnClick="btnCancel_Click" CssClass="btn-cancel" style="background:#9b51e0; border:none; border-radius:2.5px; padding:5px 0; height:58px; color:#fff; width:18rem;" />
          <asp:Button ID="btnConfirm" runat="server" title="Xác nhận giao dịch này và tiến hành thanh toán" Text="XÁC NHẬN GIAO DỊCH" OnClick="btnConfirm_Click" CssClass="btn-confirm" style="background:#9b51e0; border:none; border-radius:2.5px; padding:5px 0; height:58px; color:#fff; width:18rem;"/>

        </div>
</div>


        
</div></section>
    
   <%-- <div id="confirmationBox-QR" class="confirmation-box-QR">
        <div class="confirmation-content-QR">
        <%-- <img src="Content/icon/qr-thanh-toan.jpg" alt="Image QR" style=" width: 300px;">--%><asp:Image ID="imgMomoQRCode" runat="server" style=" width: 300px;"/>
       <%-- <asp:Button ID="Button2" runat="server" Text="Hủy" OnClick="btnCancel_Click" CssClass="btn-cancel"/>
    </div></div>--%>
    <style>
    .confirmation-box {
    display: none;
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: white;
    padding: 20px;
    border: 1px solid #ccc;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    text-align:center;
}

.confirmation-content {
    text-align: center;
}

.btn-confirm, .btn-cancel {
    margin: 5px 0;
}.confirmation-box-QR {
    display: none;
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: white;
    padding: 20px;
    border: 1px solid #ccc;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.confirmation-content-QR {
    text-align: center;
    display:grid;
}
</style>
    <script>document.addEventListener('DOMContentLoaded', function () {
            var menuLinks = document.querySelectorAll('.xn');
            var confirmationBox = document.getElementById('confirmationBox');
            var tm = document.getElementById('tm');

            menuLinks.forEach(function (tm) {
                tm.addEventListener('click', function (event) {
                    event.preventDefault();

                    confirmationBox.style.display = 'block';
                });
            });


            var qrc = document.querySelectorAll('.qr');
            var confirmationBoxQR = document.getElementById('confirmationBox-QR');
            var qr = document.getElementById('qr');

            qrc.forEach(function (qr) {
                qr.addEventListener('click', function (event) {


                    confirmationBoxQR.style.display = 'block';
                });
            });

        });
    </script>
</asp:Content>

