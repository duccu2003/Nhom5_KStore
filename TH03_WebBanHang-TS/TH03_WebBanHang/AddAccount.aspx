<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="TH03_WebBanHang.AddAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
            <style>
            *,body{
                margin:0;
                padding:0;
                font-family:Roboto;
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

            /* Tùy chỉnh scrollbar cho trình duyệt dựa trên WebKit */
        .div-updateInformation::-webkit-scrollbar {
            width: 8px; /* Chiều rộng của thanh cuộn */
        }

        .div-updateInformation::-webkit-scrollbar-track {
            background: transparent; /* Màu nền của thanh đường dẫn cuộn */
        }

        .div-updateInformation::-webkit-scrollbar-thumb {
            background-color: darkgrey; /* Màu của khối cuộn */
            border-radius: 20px; /* Bán kính góc của khối cuộn */
            border: 3px solid transparent; /* Viền của khối cuộn */
        }

        /* Tùy chỉnh scrollbar cho Firefox */
        .div-updateInformation {
            scrollbar-width: thin; /* Chiều mỏng của thanh cuộn */
            scrollbar-color: darkgrey transparent; /* Màu của khối cuộn và màu nền của thanh cuộn */
            border:1px solid #242426;
    
        }
        table tr th{
            border-bottom:1px solid #242426 !important;
        }
        .input{
              border:1px solid #242426 !important;
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

</style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous">

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
var loader = function() {
    setTimeout(function() {
        $('#loader').css({ 'opacity': 0, 'visibility':'hidden' });
    }, 1000);
};
$(function(){
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

    <form id="form1" runat="server" style="position:relative; ">
                       <a class="dropdown-item" href="ManagerAccount.aspx" style="margin:20px;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center; position:fixed; background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>

            <style>
        .search-container{
            
        }
        .tenSP-ls-h3 {
            padding-bottom: 1.5rem;
            text-align: left;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #9b51e0;
            width: 100%;
        }

        body {
            justify-content: center;
        }

        .tenSP-ls-p {            color: #9b51e0;
            width: max-content;
            padding: 8px;
            margin: auto;
            border-bottom-color: #000;
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
        }

        #div-content {
            text-align: left;
        }
        .search-container-table{
          
         }
        input[type="text"],input[type="email"], input[type="password"]{
            padding-left:10px;
            width:14rem;
        }
    </style>
    <div id="div-content" class="py-5" style="text-align: center; ">
        <div style="display: inline-grid; width: max-content; padding:10px; background:#FFFF;  border-radius:10px; justify-content:center; align-content:center; margin:4rem auto;">
            <asp:TextBox ID="txtEmailSignUp" type="email"  style="text-align: left; height:2.25rem; margin-bottom:0.5rem;" runat="server" placeholder="Email" CssClass="input-field w-more"></asp:TextBox>
            <asp:TextBox ID="txtPasswordSignUp" type="password" style="text-align: left; height:2.25rem" runat="server" TextMode="Password" placeholder="Mặt Khẩu" CssClass="input-field w-more"></asp:TextBox>
            <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Họ Và Tên" CssClass="input-field w-more" style="text-align: left; height:2.25rem"></asp:TextBox>
            <asp:DropDownList ID="ddlGT" runat="server" CssClass="input-field w-more" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" Font-Size="Medium" class="w-more" style="padding:5px 0;">
                <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam"></asp:ListItem>
                <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ"></asp:ListItem>
                <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác"></asp:ListItem>

            </asp:DropDownList>
            <style>
                *,input-field{
                    color:#000;
                }
                input-field{
                   
                }
                #ddlGT {
                    padding: 8px !important;
                    text-align: center !important;
                    margin-bottom: 10px !important;
                    border-radius: 5px !important;
                }

                #btAdd {
                    background-color: #9b51e0;
                }


                .w-more {
                    width: 100%;
                    text-align: left;
                }

                .btn-more {
                    width: 100% !important;
                    padding: 0.5rem 2rem !important;
                    border-radius:5px;
                }


                input[type="text"],
                input[type="password"] {
                    width: 100%;
                    padding: 10px !important;
                    margin-bottom: 10px;
                    border-radius: 4px;
                    border: 1px solid #ccc;
                    box-sizing: border-box;
                }

                input[type="submit"] {
                  
                    padding: 10px;
                    border: none;
                    
                    color: white;
                    
                    cursor: pointer;
                    font-size: 16px;
                }

                    input[type="submit"]:hover {
                        background-color: #9B51E0;
                    }

                #btAdd, .btn-more {
                    background-color: #000 !important;
                }

                    #btAdd:hover, .btn-more:hover {
                        background-color: #a49ccb !important;
                        color: #636161;
                    }
            </style>
             <style>
     .btn-header-u-c *{
         color:#fff !important;
     }
      
 </style>
            <div  style="">
               <%-- <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="input-field" style="padding:  8px 5px; width:12rem">
</asp:DropDownList>

<asp:DropDownList ID="ddlDistrict" runat="server" CssClass="input-field" style="padding: 8px 5px; width:12rem">
</asp:DropDownList>--%>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="input-field" style="padding:  8px 5px; width:100%">
</asp:DropDownList>
<div class=" d-flex" >

    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="input-field" style="padding: 8px 5px; width:7rem;margin-top:0.4rem ;float:left;">
</asp:DropDownList>

<asp:DropDownList ID="ddlW" runat="server" AutoPostBack="True" CssClass="input-field" style="padding: 8px 5px; width:7rem; margin-top:0.4rem; float:right;" >
</asp:DropDownList>
</div>
</div>


            <asp:TextBox ID="txtDiachi" type="text" runat="server" placeholder="Địa Chỉ" CssClass="input-field w-more" Style="margin-top: 5%; text-align: left; height:2.25rem "></asp:TextBox>
            <asp:TextBox ID="TextPhone"  runat="server" placeholder="Số Điện Thoại" style="text-align: left; height:2.25rem" CssClass="input-field w-more"></asp:TextBox>
        
            <asp:Button ID="btAdd" runat="server" Text="THÊM TÀI KHOẢN" OnClick="btAdd_Click" class="btn-more" />

        </div>
    </div>

    </form>
</body>
</html>
