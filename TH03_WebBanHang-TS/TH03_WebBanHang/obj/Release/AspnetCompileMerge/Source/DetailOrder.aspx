<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="DetailOrder.aspx.cs" Inherits="TH03_WebBanHang.DetailOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>
<h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Chi Tiết Đơn</p></h2>
            <style>
                .tenSP-ls-h3 {
                padding-bottom: 1.5rem;
                text-align: center;
                font-weight: bolder;
                font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                color: #CCBEB1;
                width: 100%;
            }
                body{
				text-align:center;
				justify-content:center;
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

            #btDel {
            background-color:#CCBEB1;
        }

            
            .w-more{
                width:100%;
                text-align:center;
            }
            
            .btn-del{
                width:max-content !important;
                padding:0.5rem 2rem !important;
                                            border: 1px solid #ccc;

            }
            

                #btDel,.btn-del {
            background-color:#CCBEB1 !important;
        }
        #btDel:hover,.btn-del:hover {
            background-color:#cbb39c !important;
            color:#636161;
        }
        .container {
    display: flex;
    justify-content: center;
    align-items: center;
    max-width:max-content;
    text-align:left;
}

.image-container {
    flex: 1;
}

.content-container {
    flex: 2;
}

.tenSP-ls-h3 {
    padding-bottom: 1.5rem;
    text-align: center;
    font-weight: bolder;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    color: #CCBEB1;
}

body {
    text-align: center;
    justify-content: center;
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

.w-more {
    width: 100%;
    text-align: center;
}

.btn-del {
    width: max-content !important;
    padding: 0.5rem 2rem !important;
    border: 1px solid #ccc;
}

#btDel,
.btn-del {
    background-color: #CCBEB1 !important;
}

#btDel:hover,
.btn-del:hover {
    background-color: #cbb39c !important;
    color: #636161;
}.tenSP-ls-h6 {
            text-align: center;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #CCBEB1;
            width: 100%;
        }

            </style>	
 <div class="container">
        <div></div>
       <div class="image-container">
    <asp:Image ID="lbImg" runat="server" style="padding: 20px; height: max-content; width:20rem;"/>
</div>
        <div class="content-container">
        <div></div>
                        <h6 class="fw-bolder tenSP-ls-h6"><%--Related products--%> <p class="tenSP-ls-p">Thông Tin Đơn Hàng</p></h6>

             <span>Mã Khách Hàng: <b>
			<asp:Label ID="lbDeptid" runat="server" Text=""></asp:Label></b></span>
		
        <div></div>
        <span>Ma Đơn: <asp:Label ID="lbMD" runat="server"
			Text="1"></asp:Label></span>
        <div></div>
		<span>Sản Phẩm: <asp:Label ID="lbSP" runat="server"
			Text="1"></asp:Label></span>
        <div></div>
		<span>Số Lượng: <asp:Label ID="lbSL" runat="server"
			Text="1"></asp:Label></span>
        <div></div>
		<span>Giá: <asp:Label ID="lbGia" runat="server"
			Text="1"></asp:Label></span>
        <div></div>
		<span>Thành Tiền: <asp:Label ID="lbThanhTien" runat="server"
			Text="1"></asp:Label></span>
                <div></div>
       
            <h6 class="fw-bolder tenSP-ls-h6"><%--Related products--%> <p class="tenSP-ls-p">Thông Tin Giao Hàng</p></h6>

		<span>Số Điện Thoại: <asp:Label ID="lbPhone" runat="server"
			Text="1"></asp:Label></span><div></div>
		<span>Họ Tên: <asp:Label ID="lbName" runat="server"
			Text="1"></asp:Label></span><div></div>
		<span>Địa Chỉ: <asp:Label ID="lbLocate" runat="server"
			Text="1"></asp:Label></span>
        <div></div>
		<span>Email: <asp:Label ID="lbEmail" runat="server"
			Text="1"></asp:Label></span>
	</div>
     </div>
        </div>
</asp:Content>
