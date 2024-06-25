<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="ManagerProduct.aspx.cs" Inherits="TH03_WebBanHang.ManagerProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Danh Sách Sản Phẩm</p></h2>
            <style>
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
			body{
				text-align:center;
				justify-content:center;
								

			}
			.btn-color:hover{
				color:#CCBEB1;
			}
			.td-longer{
				width:12rem;
				
			}
			
			.btn-w{
				width:6rem;
			}#linksContainer {
            display: none;
        }
			 td,tr,th{
				 border:0.8px solid #b8b8b84f;
				 text-align:center;
			 }
			 .ListView1{
				 display:flex;
				text-align:center;
				justify-content:center;}
            </style>
	
	<asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.SanPham"
		SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" class="text-center ListView1">
		<EmptyDataTemplate>
			<table>
				<tr>
					<td>No data was returned.</td>
				</tr>
			</table>
		</EmptyDataTemplate>
		<EmptyItemTemplate>
			<td />
		</EmptyItemTemplate>
		<GroupTemplate>
			<tr id="itemPlaceholderContainer" runat="server">
				<td id="itemPlaceholder" runat="server"></td>
			</tr>
		</GroupTemplate>
		
		<ItemTemplate>
			<td><%#:Item.MaSP%></td>
			<td><img  src="<%#:Item.DuongDan%>" alt="..." style="padding: 20px; height: max-content; width:10rem;" /></td>
			<td class="td-longer"><%#:Item.TenSP%></td>
			<td class="td-longer"><%#:Item.MoTa%></td>
			<td><%# string.Format("{0:N0}", Item.Gia) %>đ</td>
			<td><%#:Item.MaLoai%></td>
			
			<td>
				
				<a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaSP%>">Chỉnh sửa</a>
				<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaSP%>">Xóa</a>
			</td>
		</ItemTemplate>
		<LayoutTemplate>
			<table class="table" id="groupPlaceholderContainer" runat="server" style="width: 100%;">
				<thead>
					<tr>
						<th>Mã Sản Phẩm</th>
						<th>Hình Minh Họa</th>
						<th>Tên Sản Phẩm</th>
						<th>Mô Tả</th>
						<th>Giá</th>
						<th>Mã Loại</th>
						
						<th></th>
					</tr>
				</thead>
				<tbody>
					<tr id="groupPlaceholder"></tr>
				</tbody>
			</table>
		</LayoutTemplate>
	</asp:ListView>
	 
        <a class="btn btn-default btn-color" href="AddProduct.aspx">Thêm Sản Phẩm</a>
        
       
</asp:Content>
