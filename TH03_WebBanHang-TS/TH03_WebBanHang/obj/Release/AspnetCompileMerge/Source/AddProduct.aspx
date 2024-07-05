<%@ Page Title="Gmilk Tea"Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TH03_WebBanHang.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
</head>--%>
<body>
    <div>
               

            </div>
    <form id="form1">            <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p" style="font-size:30px;">Thêm Sản Phẩm</p></h2>

         <div class="form-container" style="display: flex;">
            <div style="flex: 1; text-align: left; padding-left:1rem;">
    <label for="fileUpload" style="display:grid; width:max-content; grid-gap:10px;">Chọn Ảnh:<asp:FileUpload ID="fileUpload" runat="server" onchange="previewImage(event)" style=" /*border:1px solid #000;*/ outline:none;"/>
</label>
                <div style="display:flex; justify-content: center; align-items: center; ">    <img id="imagePreview" src="#" alt="Preview Image" style="display: none; max-width: 240px; margin-top: 10px; text-align: center;" />
</div>
</div>

            <div style="flex: 2; margin-top: 0.5rem; width:300px; text-align:left; display:inline; padding-left:1rem;">
                <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p" style="font-size:24px;">Thông Tin</p></h2>
            <div class="div-ls">
                <label for="txtMaSP">Mã Sản Phẩm:</label>
                <asp:TextBox ID="txtMaSP" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="div-ls"> 
                <label for="txtTenSP">Tên Sản Phẩm:</label>
                <asp:TextBox ID="txtTenSP" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="div-ls">
                <label for="txtGia">Giá:</label>
                <asp:TextBox ID="txtGia" runat="server" TextMode="Number" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="div-ls">
                <label for="txtMoTa">Mô Tả:</label>
                <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" CssClass="full-width"></asp:TextBox>
            </div>
            <div>
                <label for="ddlMaLoai">Loại:</label>
                <asp:DropDownList ID="ddlMaLoai" runat="server" CssClass="full-width div-ls" style="width:6rem; text-align:center;">
                    <asp:ListItem Text="Trà Sữa" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Cà Phê" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Hồng Trà" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Kem" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Bánh" Value="5"></asp:ListItem>

                </asp:DropDownList>
            </div>
            <div class="div-ls">
                <asp:Button ID="btnAddProduct" runat="server" Text="Thêm Sản Phẩm" OnClick="btnAddProduct_Click" CssClass="btnAddProduct"/>
                
            </div>
            
                </div>
</div>    </form>
    <style>
        
        .full-width {
    width: 100%;
    font-size:16px;
    text-align:center;
}
        body {
    display: grid;
    justify-content: center;
    align-items: center;
    height: 100vh; /* Chiều cao của body sẽ chiếm toàn bộ viewport */
    margin: 0; /* Loại bỏ margin mặc định */
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.form-container {
    padding: 20px; /* Padding để tạo khoảng cách xung quanh form */
    border: 1px solid #ccc; /* Viền cho form */
    border-radius: 5px; /* Bo tròn góc cho form */
    height: 52vh;
    max-width: 800px;
    margin: auto; /* Để căn giữa theo chiều ngang */
}

        /* Căn giữa các label và input */
        label, input, select {
            display: block;
            margin-bottom: 10px;
        }

        /* Căn giữa nút thêm sản phẩm */
        .btnAddProduct {
            margin-top: 10px;
        }
        .btnAddProduct {
            background-color:#CCBEB1;
            max-width: 100%;
    padding: 10px;
    border: none;
    color: white;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
    
        }
        .btnAddProduct:hover {
            background-color:#cbb39c;
            color:#636161;
        }
        /* Thiết lập định dạng cho tiêu đề */
        .tenSP-ls-h3 {
            font-weight: bold;
            color: #CCBEB1;
            text-align: center;
        }

        /* Thiết lập định dạng cho đoạn phụ tiêu đề */
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
        div {
            margin-bottom: 10px; /* Khoảng cách giữa các hàng */
        }
        .div-ls{
            display:inline-grid;
            width:fit-content;
            font-size:16px !important;
            margin:0 0.5rem;
        }
        
    </style>
     <script>
         function previewImage(event) {
             var reader = new FileReader();
             reader.onload = function () {
                 var imagePreview = document.getElementById('imagePreview');
                 imagePreview.src = reader.result;
                 imagePreview.style.display = 'block';
             };
             reader.readAsDataURL(event.target.files[0]);
         }
     </script>
</body>
<%--</html>--%>
    </asp:Content>