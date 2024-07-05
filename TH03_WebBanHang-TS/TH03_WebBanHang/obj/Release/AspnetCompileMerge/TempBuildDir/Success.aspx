<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="TH03_WebBanHang.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div-bd"></div>
     <div class="success-message">
        <h2>Thanh Toán Thành Công!</h2>
        <p>Đơn hàng <asp:Label ID="lbMaDH" runat="server" Text=""></asp:Label> của bạn đã được xác nhận thành công!</p>
    </div>
    <script type="text/javascript">
    setTimeout(function () {
        window.location.href = 'Default.aspx'; 
    }, 5000); 
    </script>
    <style>
        .success-message {
    background-color: #4CAF50; 
    color: white; 
    padding: 20px;
    border-radius: 10px; 
    position: fixed; 
    top: 50%; 
    left: 50%; 
    transform: translate(-50%, -50%);
    text-align:center;
}
        #div-bd{
            height:70vh;
        }
    </style>
</asp:Content>