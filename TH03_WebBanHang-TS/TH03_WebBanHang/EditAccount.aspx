<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="TH03_WebBanHang.EditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="div-content container py-5 fade-in" style=" margin-top:12rem; gap:1rem; height:max-content; gap:4rem;">
        <asp:FormView ID="editImg" runat="server" ItemType="TH03_WebBanHang.Models.KhachHang" SelectMethod="GetProfile" RenderOuterTable="false" OnPageIndexChanging="editImg_PageIndexChanging">
            <ItemTemplate><div class="d-grid" id="divChangeAvt">
                <img id="userAvatar" loading="lazy" 
     style="border-radius: 50%; height: 300px; width: 300px; overflow: hidden; object-fit: cover;" 
     class="fade-in card-img-top mb-5 mb-md-0 zoom-hover justify-content-center align-content-center img-avt" 
     src="<%#: Item.AvatarUser %>" 
     alt="..." />
                 <label for="<%= fileUploadImages.ClientID %>" id="btnChangeIMG" style="display:none; color:#fff; width:max-content;  margin-top:-2rem;" class="custom-file-label"><i class="fa-solid fa-camera"></i> Thay đổi ảnh đại diện!</label>
                </div>
                </ItemTemplate>  
        </asp:FormView>
        <style>
            *{
                font-family:Roboto;
            }
            #divChangeAvt{
                transition:0.5s all;
            }
            #divChangeAvt #userAvatar{
                border:5px dashed #FFFF;
                transition:0.5s all;
            }
            #divChangeAvt:hover #userAvatar{
                border:5px solid #31772a;
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

            #divChangeAvt:hover #btnChangeIMG{

                display:block !important;
            }
            .custom-file-upload {
                display: none;
            }
             .custom-file-label {
                 padding: .375rem .75rem;
                 font-size: 1rem;
                 line-height: 1.5;
                 color: #495057;
                 background-color: #ffffff00;
                 border: 1px solid #ced4da;
                 border-radius: .25rem;
                 cursor: pointer;
                 height:max-content;
                 width:max-content;
                 margin:0 auto;
             }
            .custom-file-label{
                transition:0.5s;
            }
            .custom-file-label:hover{
    
                box-shadow:0 10px 50px #636363;
            }
            .custom-file-label:hover{
     
                 background:#522A77;
             }
            .div-content{
                margin:auto;
                width:max-content;
                background: linear-gradient(to bottom, #522A77, #0000) ;
                /*background:url('Content/image-bg/bg1.png') no-repeat;
                background-size:cover;
                object-fit:cover;*/
                padding:2rem;
                border-radius:10px;
            }
            .same-css-edit{
                margin-bottom:0.5rem;
                font-size:16px;
                 padding:5px 0;
                 border:none;
                 border-radius:10px;
                
            }
            .input-txt{
                color:#000;
               width:max-content; height:35px;
               margin-top:5px;
               padding:5px;
               
            }
            
            .input-field{
                color:#000;
            }
            .diachi-style{

                 color:#000;
                width:18rem;
                margin-top:5px;
                padding:5px;
                flex-wrap:wrap;
                height:max-content;

            }
        </style>
      <script type="text/javascript">
    window.onload = function() {
        var fileUploadImages = document.getElementById('<%= fileUploadImages.ClientID %>');
        var userAvatar = document.getElementById('userAvatar');

        fileUploadImages.addEventListener('change', function() {
            var file = this.files[0];
            if (file) {
                var reader = new FileReader();
                reader.onload = function(e) {
                    userAvatar.src = e.target.result;
                };
                reader.readAsDataURL(file);
            }
        });
    };
      </script>

         <div class="div-small-content textlabel"style="display:grid;"><asp:FileUpload ID="fileUploadImages" runat="server" AllowMultiple="true" CssClass="custom-file-upload" ClientIDMode="Static" />
             <div class="div-tt" >
              <div class="d-grid div-pr-child">
              <asp:Label ID="lbHoTen" runat="server" Text="Họ tên: " CssClass="same-css-edit"></asp:Label>
            <asp:TextBox ID="txtHoTen" type="text" runat="server" CssClass="same-css-edit input-txt"></asp:TextBox></div>
              <div class="d-grid div-pr-child"> <asp:Label ID="lbSoDienThoai" runat="server" Text="Số điện thoại: " CssClass="same-css-edit"></asp:Label>

            <asp:TextBox ID="txtSoDienThoai"  runat="server" CssClass="same-css-edit input-txt"></asp:TextBox></div>
              
</div>
              <div class="div-tt">
                  <div class="d-grid div-pr-child">
            <asp:Label ID="lbDiaChi" runat="server" Text="Địa chỉ: " CssClass="same-css-edit"></asp:Label> 
             <asp:TextBox ID="txtDiaChi" type="text" TextMode="MultiLine" runat="server" CssClass="same-css-edit  diachi-style"></asp:TextBox></div>
             <%--<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="input-field" style="padding:  8px 5px; width:100%">
</asp:DropDownList>
<div class=" d-flex" >

    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="input-field" style="padding: 8px 5px; width:7rem;margin-top:0.4rem ;float:left;">
</asp:DropDownList>

<asp:DropDownList ID="ddlW" runat="server" AutoPostBack="True" CssClass="input-field" style="padding: 8px 5px; width:7rem; margin-top:0.4rem; float:right;" >
</asp:DropDownList>
</div>--%>
                  <div class="d-grid div-pr-child">
              <asp:Label ID="lbGioiTinh" runat="server" Text="Giới tính: " CssClass="same-css-edit"></asp:Label> 

             <asp:DropDownList ID="ddlGT" runat="server" style="text-align:center;" CssClass="input-field same-css-edit input-gt" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" Width="100%" Font-Size="small">
                <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam" style="color:#000;"></asp:ListItem>
                <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ" style="color:#000;"></asp:ListItem>
                <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác" style="color:#000;"></asp:ListItem>
            </asp:DropDownList>

                      
                  </div>
                  </div>
             <div class="d-flex" style="margin:auto; margin-left:1.18rem; gap:0.8rem; padding-top:4rem;">

             <a id="btnBack" href="Account.aspx" class="profile-image btn-upload justify-content-center align-content-center" style="position: relative; text-align:center; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:40px; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" ><i class="fa-solid fa-arrow-left"></i></a>

                 <asp:Button ID="btnCPass" runat="server" Text="Đổi mật khẩu" OnClick="btnCPass_Click" CssClass="profile-image btn-upload"  Style="position: relative; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />


            <asp:Button ID="ProfileImage" Text="Cập nhật" runat="server" CssClass="profile-image btn-upload" OnClick="btnUpload_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />
             <%--<asp:Button ID="btnCancel" Text="Hủy thay đổi" runat="server" CssClass="profile-image btn-upload" OnClick="btnCancel_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:max-content; height:max-content; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />
<asp:Button ID="btnBack" Text="Quay về" runat="server" CssClass="profile-image btn-upload" OnClick="btnBack_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:max-content; height:max-content; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />--%>
            
                  <asp:Button ID="btDel" Text="Xóa tài khoản" runat="server" CssClass="profile-image btn-upload" OnClick="btDel_Click" Style="position: relative; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />

                 
                 <a id="btnCancel" href="#" class="profile-image btn-upload justify-content-center align-content-center" style="position: relative; text-align:center; z-index: 0; color:#fff; background: linear-gradient(to right, #522A77, #2a2e77) ; border:1px solid #000; width:40px; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;"  onclick="location.reload();" ><i class="fa-solid fa-rotate-right"></i></a>


<script>
    document.getElementById('btnCancel').href = window.location.href;
</script>

             </div>
        </div>
        <style>
            /*#btPer{display:none;}*/

        </style>
        <style>
            .btn-upload{
                transition:0.5s;

            }
            .btn-upload:hover{
                box-shadow:0px 10px 50px #636363;
                transform:scale(1.1);
            }

            @media only screen and  (min-width: 768px) {
                .div-small-content{
                    margin-top:2.5rem !important;
                    margin-bottom:2.5rem !important;
                }
            .div-tt{
    display:flex;
   gap:2rem;
   
}
            .div-pr-child{
                width:280px;
            }
            .div-content{
                padding:10px 50px;
                display:flex;
                
            }
            .img-avt{
                height: 300px; width: 300px;
            }
            .input-gt{
     color:#000;
    width:max-content !important; height:35px;
    margin-bottom:1.75rem;
    padding:5px;
    
}
            }
             @media only screen and  (max-width: 768px) {
                 .custom-file-label{
                      position:absolute;
                     left:10rem;
                     top:12rem;
                 }
                    .div-small-content{
                         
                    }
                 .div-tt{
                     display:grid;
                 }
                .div-content{
                    
                   
                }
                 .img-avt{
                     
                     height: 100px; width: 100px;
                     overflow:hidden;
                     object-fit:cover;
                 }
                 .input-gt{
     color:#000;
    width:max-content !important; height:35px;
    margin-top:5px;
    padding:5px;
}
              }
             .btn-a-m{
                 color:#000;
                 padding:10px;
             }
        </style>
    </section>
      

       
     
</asp:Content>
