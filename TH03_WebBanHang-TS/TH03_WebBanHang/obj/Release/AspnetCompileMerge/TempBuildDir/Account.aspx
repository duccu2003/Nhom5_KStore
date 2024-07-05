<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TH03_WebBanHang.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <style>
        body {
            background-color: #f0f0f0;
        }
        .container {
            background-color: #fff;
            border-radius: 8px;
        }
        .profile-picture {
            width: 180px;
            height: 180px;
            border-radius: 50%;
            overflow: hidden;
            margin: 0 auto 20px;
            

        }
        .profile-picture img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
        .profile-info {
                        text-align: match-parent;
        }
        .profile-info h5 {
            margin: 0;
            padding: 0;
            font-size: 18px;
            color: #333;
        }
        .profile-info p {
            margin: 5px 0 0;
            padding: 0;
            font-size: 16px;
            color: #666;
        }
        #container-pr {
            padding: 0 0 5% 0 ;
                        text-align: center;            


        }
        .centered-text {
    margin: 0 auto; /* Đảm bảo các phần tử được căn giữa theo chiều ngang */
    max-width: max-content; /* Thiết lập giá trị tối đa cho chiều rộng của các phần tử */
    text-align: left; /* Đảm bảo văn bản được căn trái bên trong phần tử */
    background-color:#fff;
    border-radius:10px;
    padding:5px 10px;
    margin-bottom:1.5rem;
}

        
        #item-pr{
            justify-content:center;
            text-align:center;
        }
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
            
    </style>
 
    <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Thông Tin Tài Khoản</p></h2>
   <div id="container-pr">
       <div id="item-pr"><div class="profile-picture">
        <asp:Image ID="ProfileImage" runat="server" CssClass="profile-image" ImageUrl="~/Content/icon/icon-pr.gif" AlternateText="Profile Picture" />
    </div>
    <asp:ListView ID="ListViewAccounts" runat="server">
        <ItemTemplate>
            <div class="profile-info centered-text"> <!-- Thêm lớp CSS centered-text -->
                 <h5>Họ Và Tên: <%# Eval("HoTen") %></h5>
                                <h5>Email: <asp:Label ID="EmailAddress" runat="server" Text='<%# Eval("Email") %>'></asp:Label></h5>
                <h5>Giới Tính: <%# Eval("GioiTinh") %></h5>
                <h5>Địa Chỉ: <%# Eval("DiaChi") %></h5>
                <h5>Số Điện Thoại: <%# Eval("DienThoai") %></h5>
            </div><a class="menu-link" href="AccountOrder.aspx?Deptid=<%# Eval("MaKH") %>">
            <h6>Đơn Hàng</h6>
        </a>
        </ItemTemplate>
    </asp:ListView>
   <%-- <asp:ListView ID="ListViewClient" runat="server">
        <ItemTemplate>
            <div class="profile-info centered-text"> <!-- Thêm lớp CSS centered-text -->
                <h5>Họ Và Tên: <%# Eval("HoTen") %></h5>
                <h5>Giới Tính: <%# Eval("GioiTinh") %></h5>
                <h5>Địa Chỉ: <%# Eval("DiaChi") %></h5>
                <h5>Số Điện Thoại: <%# Eval("DienThoai") %></h5>
            </div>
        </ItemTemplate>
    </asp:ListView>--%>
        <asp:Button ID="btnSignOut" runat="server" Text="Đăng Xuất" OnClick="btnSignOut_Click"/></div>
    
</div>

    <%--<asp:ListView ID="ListViewAccounts" runat="server">
        <ItemTemplate>
            <img src="Content/icon/user.png" style="width: 2%;" />
            <h5>Tài Khoản: <%# Eval("TenTaiKhoan") %></h5>
            <h5>Email: <%# Eval("Email") %></h5>
            
        </ItemTemplate>
    </asp:ListView>
         <ItemTemplate>
           
            <h5>Họ Và Tên: <%# Eval("HoTen") %></h5>
<h5>Giới Tính: <%# Eval("GioiTinh") %></h5>
<h5>Địa Chỉ: <%# Eval("DiaChi") %></h5>
<h5>Số Điện Thoại: <%# Eval("DienThoai") %></h5>
        </ItemTemplate>
   
<div id="f-kh" style="display:none;"><ItemTemplate>
            <h5>Họ Và Tên:</h5>
<asp:TextBox type="text" ID="txtHoTen" runat="server" value='<%# Eval("HoTen") %>' placeholder="Họ Và Tên" CssClass="input-field"/>
<h5>Giới Tính:</h5>
<asp:TextBox type="text" ID="txtGioiTinh" runat="server" value='<%# Eval("GioiTinh") %>' placeholder="Giới Tính" CssClass="input-field"/>
<h5>Địa Chỉ:</h5>
<asp:TextBox type="text" ID="txtDiaChi" runat="server" value='<%# Eval("DiaChi") %>' placeholder="Địa Chỉ" CssClass="input-field"/>
<h5>Số Điện Thoại:</h5>
<asp:TextBox type="text" ID="TextPhone" runat="server" value='<%# Eval("DienThoai") %>' placeholder="Số Điện Thoại" CssClass="input-field"/>



        </ItemTemplate></div> 
       <a id="a-change" href="#">Change</a>
    <script>var change = document.getElementById("a-change");            var formkh = document.getElementById("f-kh");
        var save = document.getElementById("btnSave");
        change.addEventListener('click', function () {
            if (formkh.style.display = "none") formkh.style.display = "block";
            else formkh.style.display = "none";
        });
        save.addEventListener('click', function () {
            formkh.style.display = "none";
        });
    </script>

    <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" />
        <asp:Button ID="btnSignOut" runat="server" Text="SignOut" OnClick="btnSignOut_Click" />--%>
       

</asp:Content>
