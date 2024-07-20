<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfileAccount.aspx.cs" Inherits="TH03_WebBanHang.EditProfileAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
    <style>
        *{
            font-family:Roboto;
        }
        #divChangeAvt{
            transition:0.5s all;
        }
        #divChangeAvt #userAvatar{
            border:5px dashed #8549cdff;
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

        ::-webkit-scrollbar {
            width: 5px;
        }

        ::-webkit-scrollbar-thumb {
            background: #5e17a2ff;
        }

        ::-webkit-scrollbar-track {
            background: #202020;
        }
        *{
            margin:0;
            padding:0;
            font-family: Roboto;
        }
        a{
            color:#000;
        }
    </style>
        <style>
        #loader {
            position: fixed;
            top: 0;
            left: 0;
            z-index: 99999;
            width: 100%;
            height: 100%;
            background-color: #FFFF;
            transition: all 0.3s ease-in-out;
            text-align:center;
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
            text-align:center;
        }
        .circle {
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
            text-align:center;
            height: 40px;
            margin: auto;
            position: relative;
            text-align: center;
            width: 40px;
            -webkit-animation: circle_dot 2.0s infinite linear;
                    animation: circle_dot 2.0s infinite linear;
        }

        .circle1, .circle2 {
            height: 60%;
            display: inline-block;
            background-color: #6c38ef;
            border-radius: 100%;
            position: absolute;
            top: 0;
            width: 60%;
            -webkit-animation: circle_bounce 2.0s infinite ease-in-out;
                    animation: circle_bounce 2.0s infinite ease-in-out;
        }

        .circle2 {
            bottom: 0;
            top: auto;
            -webkit-animation-delay: -1.0s;
                    animation-delay: -1.0s;
        }

        @-webkit-keyframes circle_dot { 100% { -webkit-transform: rotate(360deg) }}
        @keyframes circle_dot { 100% { transform: rotate(360deg); -webkit-transform: rotate(360deg) }}

        @-webkit-keyframes circle_bounce {
            0%, 100% { -webkit-transform: scale(0.0) }
            50%      { -webkit-transform: scale(1.0) }
        }

        @keyframes circle_bounce {
            0%, 100% { 
                -webkit-transform: scale(0.0);
                        transform: scale(0.0);
            } 50% { 
                -webkit-transform: scale(1.0);
                        transform: scale(1.0);
            }
        }
    </style>
    <script src="https://code.jquery.com/jquery-latest.js"></script>
<script>
    var loader = function () {
        setTimeout(function () {
            $('#loader').css({ 'opacity': 0, 'visibility': 'hidden' });
        }, 1000);
    };
    $(function () {
        loader();
    });
</script>
</head>
<body>
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
             <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />

    <form id="form1" runat="server" style="position:relative; padding-top:5rem;">
            <section class="div-content container py-5 fade-in" style="gap:1rem; height:max-content; gap:4rem;">
        <asp:FormView ID="editImg" runat="server" ItemType="TH03_WebBanHang.Models.KhachHang" SelectMethod="GetProfile" RenderOuterTable="false" OnPageIndexChanging="editImg_PageIndexChanging">
            <ItemTemplate><div class="d-grid" id="divChangeAvt" style="row-gap:1rem;">
                <img id="userAvatar" loading="lazy" 
     style="border-radius: 50%; margin-top:2rem; height: 300px; width: 300px; overflow: hidden; object-fit: cover;" 
     class="fade-in card-img-top mb-5 mb-md-0 zoom-hover justify-content-center align-content-center img-avt" 
     src="<%#: Item.AvatarUser %>" 
     alt="..." />
                 <label for="<%= fileUploadImages.ClientID %>" id="btnChangeIMG"  onclick="ChangeAVT();" style="display:none; color:#fff; width:max-content;  margin-top:1rem;" class="custom-file-label"><i class="fa-solid fa-camera"></i> Thay đổi ảnh đại diện!</label>
                </div>
                </ItemTemplate>  
        </asp:FormView>
        <style>
           
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
     color: #fff;
      background:#000;
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
  
     background:#000;
 }
            .div-content{
                margin:auto;
                width:max-content;
                background: #FFF ;
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
               border:1px solid #242425;
               
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
            .div-pr-child{
               margin:0.5rem !important;
            }
        </style>
      <script type="text/javascript">
          function ChangeAVT() {
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
              <div class="d-grid div-pr-child" style="display:grid !important;">
              <asp:Label ID="lbHoTen" runat="server" Text="Họ tên: " CssClass="same-css-edit"></asp:Label>
            <asp:TextBox ID="txtHoTen" type="text" runat="server" CssClass="same-css-edit input-txt"></asp:TextBox></div>
              <div class="d-grid div-pr-child" style="display:grid !important;"> 
                  <asp:Label ID="lbSoDienThoai" runat="server" Text="Số điện thoại: " CssClass="same-css-edit"></asp:Label>

            <asp:TextBox ID="txtSoDienThoai"  runat="server" CssClass="same-css-edit input-txt"></asp:TextBox></div>
                          <div class="d-grid div-pr-child" style="display:grid !important;">
  <asp:Label ID="lbGioiTinh" runat="server" Text="Giới tính: " CssClass="same-css-edit"></asp:Label> 

 <asp:DropDownList ID="ddlGT" runat="server" style="text-align:center;" CssClass="input-field same-css-edit input-gt" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" Width="100%" Font-Size="small">
    <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam" style="color:#000;"></asp:ListItem>
    <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ" style="color:#000;"></asp:ListItem>
    <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác" style="color:#000;"></asp:ListItem>
</asp:DropDownList>

         
      </div>
              
</div>
        
                  <div class="d-grid div-pr-child" style="display:grid !important;">
            <asp:Label ID="lbDiaChi" runat="server" Text="Địa chỉ: " CssClass="same-css-edit"></asp:Label> 
             <asp:TextBox ID="txtDiaChi" type="text" TextMode="MultiLine" runat="server" style="width:520px !important; border:1px solid #242426 !important;" CssClass="same-css-edit  diachi-style"></asp:TextBox>

                      

                  </div>
             <%--<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="input-field" style="padding:  8px 5px; width:100%">
</asp:DropDownList>
<div class=" d-flex" >

    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="input-field" style="padding: 8px 5px; width:7rem;margin-top:0.4rem ;float:left;">
</asp:DropDownList>

<asp:DropDownList ID="ddlW" runat="server" AutoPostBack="True" CssClass="input-field" style="padding: 8px 5px; width:7rem; margin-top:0.4rem; float:right;" >
</asp:DropDownList>
</div>--%>
                  
                 

                                   <div  class="d-grid div-pr-child" style="display:grid !important; margin-top:1rem;">
                                            <p>Quyền: <asp:Label ID="lbQuyenName" runat="server" Text=""></asp:Label></p>
                                </div>
             <div class="d-flex" style="margin:auto; margin-left:1.18rem; gap:0.8rem; padding-top:4rem;">

             <a id="btnBack" href="ManagerAccount.aspx" class="profile-image btn-upload justify-content-center align-content-center" style="position: relative; text-align:center; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:40px; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" ><i class="fa-solid fa-arrow-left"></i></a>
            <a id="btPer" class="profile-image btn-upload" style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;"  href="#!">Quyền</a>

                 <asp:Button ID="btnCPass" runat="server" Text="Đổi mật khẩu" OnClick="btnCPass_Click" CssClass="profile-image btn-upload"  Style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />


            <asp:Button ID="ProfileImage" Text="Cập nhật" runat="server" CssClass="profile-image btn-upload" OnClick="btnUpload_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />
             <%--<asp:Button ID="btnCancel" Text="Hủy thay đổi" runat="server" CssClass="profile-image btn-upload" OnClick="btnCancel_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:max-content; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />
<asp:Button ID="btnBack" Text="Quay về" runat="server" CssClass="profile-image btn-upload" OnClick="btnBack_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:max-content; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />--%>
            
                  <asp:Button ID="btDel" Text="Xóa tài khoản" runat="server" CssClass="profile-image btn-upload" OnClick="btDel_Click" Style="position: relative; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:max-content; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;" />

                 
                 <a id="btnCancel" href="#" class="profile-image btn-upload justify-content-center align-content-center" style="position: relative; text-align:center; z-index: 0; color:#fff; background: #000 ; border:1px solid #000; width:40px; height:40px; border-radius:20px; margin: 1rem auto auto auto; padding: 8px 10px;"  onclick="location.reload();" ><i class="fa-solid fa-rotate-right"></i></a>


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
                display:flex !important;
               gap:10px !important;
   
            }
            .div-pr-child{
                width:max-content;
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
    
    padding:5px;
    border:1px solid #242426 !important; 
    
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
        <div id="permissionTableContainer">
    <div id="permissionTable">
        <asp:Button ID="Admin" runat="server" Text="Admin" CssClass="btn-a-m" OnClick="btAdmin_Click"/>
        <asp:Button ID="Manager" runat="server" Text="Manager" CssClass="btn-a-m" OnClick="btManager_Click"/>
        <asp:Button ID="None" runat="server" Text="None" CssClass="btn-a-m" OnClick="btNone_Click"/>

        <a id="cancel" class="btn btn-default btn-color" style="margin:auto !important; text-align:center; margin-top:1rem !important;" href="#">Hủy</a>
   </div>
</div>

        <script type="text/javascript">
            document.addEventListener("DOMContentLoaded", function (event) {
                var getPer = document.getElementById("btPer");
                var cancel = document.getElementById("cancel");
                var permissionTable = document.getElementById("permissionTableContainer");
                getPer.addEventListener('click', () => {
                    if (permissionTable.style.display == "flex") permissionTable.style.display = "none";
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
    border-radius:5px;
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
           
            #cancel{
                display:grid;
            }
        </style>
    </form>
</body>
</html>
