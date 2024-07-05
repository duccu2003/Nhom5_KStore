<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="TH03_WebBanHang.DeleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>
<h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Xóa Tài Khoản</p></h2>
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
            </style>			<span>Email: <b>
			<asp:Label ID="lbDeptid" runat="server" Text=""></asp:Label></b></span>
		<div></div>
		<span>Mật Khẩu: <asp:Label ID="lbName" runat="server"
			Text="1"></asp:Label></span>
	</div>
		<asp:Button ID="btDel" runat="server" Text="Xóa" OnClick="btDel_Click" CssClass="btn-del" />

</asp:Content>
