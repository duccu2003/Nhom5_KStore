<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="GetPermission.aspx.cs" Inherits="TH03_WebBanHang.GetPermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>
<h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Cấp Quyền Cho Tài Khoản</p></h2>
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

            #btPer {
            background-color:#CCBEB1;
        }

            
            .w-more{
                width:100%;
                text-align:center;
            }
            
            .btn-per{
                width:max-content !important;
                padding:0.5rem 2rem !important;
                                            border: 1px solid #ccc;

            }
            

                #btPer,.btn-per {
            background-color:#CCBEB1 !important;
        }
        #btPer:hover,.btn-per:hover {
            background-color:#cbb39c !important;
            color:#636161;
        }
        .btn-a-m{
            width:5rem !important;
            color:#000;
            background-color:aliceblue;
        }
            </style>			<span>Email: <b>
			<asp:Label ID="lbDeptid" runat="server" Text=""></asp:Label></b></span>
		<div></div>
		<span>Mật Khẩu: <asp:Label ID="lbName" runat="server"
			Text="1"></asp:Label></span>
        		<div></div>

        <span>Quyền: <asp:Label ID="lbQuyen" runat="server"
			Text="2"></asp:Label></span>
	</div>
   <br />
       <br />

		<div></div>
<a id="btPer" class="btn-per" href="#!">Quyền</a>
    <div id="permissionTableContainer">
    <div id="permissionTable">
        <asp:Button ID="Admin" runat="server" Text="Admin" CssClass="btn-a-m" OnClick="btAdmin_Click"/>
        <asp:Button ID="Manager" runat="server" Text="Manager" CssClass="btn-a-m" OnClick="btManager_Click"/>
        <asp:Button ID="None" runat="server" Text="None" CssClass="btn-a-m" OnClick="btNone_Click"/>

        <a id="cancel" class="btn btn-default btn-color" href="#">Hủy</a>
   </div>
</div>

        <script type="text/javascript">
            document.addEventListener("DOMContentLoaded", function (event) {
                var getPer = document.getElementById("btPer");
                var cancel = document.getElementById("cancel");
                var permissionTable = document.getElementById("permissionTableContainer");
                getPer.addEventListener('click', ()=>{
                    if (permissionTable.style.display == "flex")  permissionTable.style.display = "none"; 
                    else permissionTable.style.display = "flex";
                }); 
                cancel.addEventListener('click', function (event) {
                    event.preventDefault(); // Ngăn chặn hành động mặc định của thẻ a

                    permissionTable.style.display = "none"; // Ẩn permissionTable
                });
            }); 
                
        
    
        </script>
        <style>           #permissionTable {
    background-color: white;
    padding: 20px;
    width: max-content;
    margin: auto; /* căn giữa */
}
           #permissionTableContainer {
    display: none;
    justify-content: center; /* căn giữa theo chiều ngang */
    align-items: center; /* căn giữa theo chiều dọc */
    position: fixed; /* vị trí cố định */
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.5); /* một lớp mờ đen */
}
            a{text-decoration:none;
              color:#000;
            }
            #cancel{
                display:grid;
            }
        </style>


</asp:Content>

