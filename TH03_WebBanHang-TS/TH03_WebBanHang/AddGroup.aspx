<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="TH03_WebBanHang.AddGroup" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">    
    <style>
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
        .full-width {
    
            font-size:16px !important;
            text-align:center;
        }
        body {
    display: grid;
  
    height: 100vh; /* Chiều cao của body sẽ chiếm toàn bộ viewport */
    margin: 0; /* Loại bỏ margin mặc định */
    font-family: Roboto;
    background:#000000;
    
}
        *{
            font-family:Roboto;
        }
        body {
    font-size: 2vw; /* Hoặc sử dụng % thay vì vw */
}

        .div-ls{
            
        }
        .div-2 input, .div-2 select, .full-width{
            width:218.57px !important;
            height:35px;
        }
        .search-container{
            
        }
        *{
            color:#000;
        }
        label{
            color:#000;
        }
      .form-container {
   
    /*border: 1px solid #9b51e0;*/
    border-radius: 5px;
    height: max-content;
   
    margin: auto;
    /*background-image: url('Content/image-bg/content-bg.png');
    background-size: cover;*/
        /*background:linear-gradient(to bottom, #522A77,#000);*/
        background:#fff;
    position: relative; /* Đảm bảo .form-container có thể chứa .overlay */
   
}
      form {
     background: #242426 !important; 
    }


    

        /* Căn giữa các label và input */
        label, input, select {
       
            
        }

        /* Căn giữa nút thêm sản phẩm */
        .btnAddProduct {
           
        }
        .btnAddProduct {
            background-color:#000;
            width:100%;
    padding: 10px;
    border: none;
    color: #fff;
   
    cursor: pointer;
    font-size: 18px;
    margin:3rem auto auto auto;
   


    
        }
        .btnAddProduct:hover {
            background-color:#242426;
            color:#fff;
        }
        /* Thiết lập định dạng cho tiêu đề */
        .tenSP-ls-h3 {
            font-weight: bold;
            color: #9b51e0;
            text-align: center;
        }

        /* Thiết lập định dạng cho đoạn phụ tiêu đề */
        .tenSP-ls-p {            color: #9b51e0;
            width: max-content;
            padding: 8px;

            margin: auto;
            
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
        }
        div {
        }
        .div-ls{
            display:grid;
           
            font-size:16px !important;
           height:80px !important;
           width:14rem !important;
           
          
        }
        .div-ls input, .div-ls select{
          
            
        }
        
        
    </style>
    <style>
    .form-container {
        display: grid !important;
        flex-direction: row;
        align-items: center;
        
        
        overflow: hidden; 
    }

    .image-preview{
        height:150px;
        text-align:center;
        justify-content:center;
        align-content:center;
        margin:1rem auto;
        
    }
    #imgMember{
        width:100%;
    }
    #imgLogo{
        width:150px;
    }

    /* Các thuộc tính khác để tùy chỉnh hiển thị dựa trên kích thước màn hình */
    @media only screen and  (max-width: 768px) {
        
    }
    @media only screen and (max-width: 768px) {
    #form1{
        padding:0 !important;
    }
    /* Quy tắc cho màn hình nhỏ hơn hoặc bằng 768px */
   .form-container {
        width: 100% !important;
        margin: auto;
    }
   .div-ls {
        width: 100% !important;
    }
    /* Thêm các quy tắc khác cho các phần tử khi màn hình nhỏ */
}

@media only screen and (min-width: 769px) and (max-width: 1024px) {
    /* Quy tắc cho màn hình từ 769px đến 1024px */
   .form-container {
        width: 80%;
    }
    /* Thêm các quy tắc khác cho các phần tử khi màn hình nằm trong khoảng này */
}

</style>
    <style>
    .btn-header-u-c *{
        color:#000 !important;
    }
    footer{
        z-index:9999;
        background:#000;
    }
    #form1{
        background:#242426;
    }
    #moveTop *{
        color:#000 !important;
    }
</style>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script>
    function previewimgLogoiDol(event) {
        var reader = new FileReader();
        reader.onload = function () {
            var output = document.getElementById('imgLogo');
            output.src = reader.result;
        };
        reader.readAsDataURL(event.target.files[0]);
    }
    function previewimgMemberiDol(event) {
        var reader = new FileReader();
        reader.onload = function () {
            var output = document.getElementById('imgMember');
            output.src = reader.result;
        };
        reader.readAsDataURL(event.target.files[0]);
    }
</script>
</head>
<body style="overflow-x:hidden;">
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
     <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />
    <form id="form1" runat="server" style="padding:20px;">
        <div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
            <a title="Thoát" class="dropdown-item" href="ManagerGroup" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
     
            </div>

         <div class="form-container fade-out" style="padding:10px 20px; width:max-content; display: grid; border-radius:5px; overflow:auto;">
            <h1 style="margin:1rem auto 2rem auto; ">Thêm Nhóm/Nghệ sĩ</h1>
            <table>
                <tr>
                    <td>
                        <div class="" style="display:grid; width:100%; text-align:left; margin:auto; justify-content:center; align-content:center;">
                            <asp:FileUpload ID="fileUploadimgLogoiDol" CssClass="div-add-input"  runat="server" onchange="previewimgLogoiDol(event)" style="outline:none;"/>
                            <img id="imgLogo" style="" src="#" alt="Ảnh Logo" class="imgLogoiDol image-preview"/>

                        </div>

                    </td>
                    <td>
                        <div class="" style="display:grid; width:100%; text-align:left; margin:auto; justify-content:center; align-content:center;">
                        
                            <asp:FileUpload  ID="fileUploadimgMemberiDol" CssClass="div-add-input"  runat="server" onchange="previewimgMemberiDol(event)" style="outline:none;"/>
                            <img id="imgMember" style="" src="#" alt="Ảnh Thành Viên" class="imgMemberiDol image-preview"/>
                        </div>

                    </td>
                </tr>
                <tr>
                    <th><div class="" style="display:grid; width:100%; text-align:left; margin:auto; justify-content:center; align-content:center;"><label style="font-size:18px;">Mã nhóm/thần tượng:</label><asp:TextBox ID="txtMaiDol" runat="server" CssClass="full-width"></asp:TextBox></div></th>
                    <th><div class="" style="display:grid; width:100%; text-align:left; margin:auto; justify-content:center; align-content:center;"><label style="font-size:18px;">Tên nhóm/thần tượng:</label><asp:TextBox ID="txtNameiDol" runat="server" CssClass="full-width"></asp:TextBox></div></th>
                </tr>
                <tr>
                    <td colspan="2">
                     <asp:Button ID="btnAddIDOL" runat="server" Text="THÊM NHÓM NHẠC/NGHỆ SĨ" OnClick="btnAddIDOL_Click" CssClass="btnAddProduct"/>
                    </td>
                 </tr>
            </table>
        </div>
    </form>
</body>
</html>


