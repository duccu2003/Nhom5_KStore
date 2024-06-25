<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="TH03_WebBanHang.Pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"><style>
                                                                                 .menu-links {
    display: flex;
    justify-content: center;
}

.menu-link {
    text-align: center;
    margin: 0 10px; /* Khoảng cách giữa các liên kết */
    text-decoration: none;
    color: black;
    border:0.5px solid #CCBEB1;
    box-shadow:2px 2px 18px #CCBEB1;
    padding:10px;
    margin:8% 2%;
    border-radius:10px;
    --bs-btn-active-bg: #CCBEB1;
    --bs-btn-disabled-color: #CCBEB1;
    background-color:#eeeeee;
}
.menu-link:hover {
background-color:#FBF4F1;
                                color:#212529;

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
            }
            .menu-link img{padding:1.5rem !important;}
</style>
        <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Thanh Toán</p></h2>

    <div class="menu-links">
        <a class="menu-link xn" href="#!" id="tm">
            <img src="Content/icon/money.png" alt="Image 1">
            <h6>Thanh Toán Tiền Mặt</h6>
        </a>
        <a class="menu-link" href="PayCard.aspx">
            <img src="Content/icon/operation.png" alt="Image 2">
            <h6>Thanh Toán Số Thẻ</h6>
        </a>
        <a class="menu-link qr" href="#!" id="qr">
            <img src="Content/icon/qr-code.png" alt="Image 3">
            <h6>Thanh Toán Mã QR</h6>
        </a>
    </div>
    <div id="confirmationBox" class="confirmation-box">
    <div class="confirmation-content">
        <asp:Button ID="btnConfirm" runat="server" Text="Xác Nhận" OnClick="btnConfirm_Click" CssClass="btn-confirm" />
        <asp:Button ID="btnCancel" runat="server" Text="Hủy" OnClick="btnCancel_Click" CssClass="btn-cancel" />
    </div>
        
</div>
    <div id="confirmationBox-QR" class="confirmation-box-QR">
        <div class="confirmation-content-QR">
         <img src="Content/icon/qr-thanh-toan.jpg" alt="Image QR" style=" width: 300px;">
        <asp:Button ID="Button2" runat="server" Text="Hủy" OnClick="btnCancel_Click" CssClass="btn-cancel"/>
    </div></div>
    <style>.confirmation-box {
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
    margin: 5px;
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

