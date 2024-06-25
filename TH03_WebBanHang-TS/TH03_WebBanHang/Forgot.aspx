<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Forgot.aspx.cs" Inherits="TH03_WebBanHang.Forgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
     <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family:Roboto !important;
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

        body {
            font-family: Arial, sans-serif;
            background-color: #9b51e0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 300px;
            background:#e3e3e3a1;
        }
        input, select{
            
            justify-content:center;
            align-content:center;
            align-items:center;
            border:none;
            border-radius:5px !important;
            background-color:#fff;
        }
        .form-container {
            text-align: center;
            margin-bottom: 20px;

        }

            .form-container h1 {
                font-size: 24px;
                margin-bottom: 10px;
            }

            .form-container span {
                font-size: 14px;
                color: #666;
                display: block;
                margin-bottom: 10px;
            }

            .form-container input[type="text"],
            .form-container input[type="password"] {
                width: 100%;
                padding: 10px;
                margin-bottom: 10px;
                border-radius: 4px;
                border: 1px solid #ccc;
                box-sizing: border-box;
            }

            .form-container input[type="submit"] {
                width: 100%;
                padding: 10px;
                border: none;
                background-color: #fff0;
                color: white;
                border-radius: 4px;
                cursor: pointer;
                font-size: 16px;
            }

                .form-container input[type="submit"]:hover {
                    background-color: #9B51E0;
                }

        #btnForgot,#btnGetOTP {
            background-color: #9b51e0;
        }

            #btnForgot:hover,#btnGetOTP:hover {
                background-color: #a49ccb;
                color: #636161;
            }

        #img-maid1 {
            position: absolute;
            right: 0;
            width: 18.5rem;
            bottom: 0;
        }

        #img-maid1 {
            position: absolute;
            right: 0;
            width: 18.5rem;
            bottom: 0;
        }

        #img-maid2 {
            position: absolute;
            left: 0;
            bottom: 0;
            width: 18.5rem;
        }
    </style>


</head>
<body style="background-color:#2424269b">
    <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: absolute; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />

    <form id="form1" runat="server" style="z-index: 1;">
       <%-- <img src="Content/image-bg/maid1.png" id="img-maid1" />
        <img src="Content/image-bg/maid2.png" id="img-maid2" />--%>

        <div class="container" style="text-align:center;">
            <div class="form-container sign-up">
                <%--                <img src="Content/icon/ag.gif" style="max-width: 100%; border-radius: 2rem; margin-bottom: 1.5rem;" />--%>
                <%--                <h1>Forgot Account</h1>--%>
                <%--                <span>or use your email for registration</span>--%>

                <a href="Default.aspx" style="text-decoration: none; color: #9b51e0;">
<%--                    <h1 style="text-align: center; font-weight: bolder; font-family: 'Edwardian Script ITC'; font-size: 4rem; margin-bottom: 1rem; border-bottom-color: #000; border: 1px solid; border-top-style: none; border-left-style: none; border-right: none;">KStore</h1>--%>
                                  <img style="width:100%;" src="Content/logo/K-Photoroom.png"/>

                </a>

                <asp:TextBox ID="txtEmailSFogot" type="email" runat="server" placeholder="Email" CssClass="input-field" style="width:15.8rem; margin-top:15px; margin-bottom:0.5rem; height:2.1875rem; padding-left:10px;"></asp:TextBox>
                
               <asp:DropDownList ID="ddlOTPChoice" runat="server" CssClass="input-field" OnSelectedIndexChanged="ddlOTPChoice_SelectedIndexChanged" AutoPostBack="True" style="width:15.8rem; padding:5px; color:#000; margin-bottom:0.5rem; height:2.1875rem;" >

 <asp:ListItem ID="otpEmail" Text="Gửi OTP qua địa chỉ Email" Value="otpEmail" style="color:#000;"></asp:ListItem>
 <asp:ListItem ID="otpSmsPhone" Text="Gửi OTP qua tin nhắn SMS" Value="otpSmsPhone" style="color:#000;"></asp:ListItem>
 <asp:ListItem ID="otpCallPhone" Text="Gửi OTP qua cuộc gọi" Value="otpCallPhone" style="color:#000;"></asp:ListItem>

 
</asp:DropDownList>

                
                <div class="d-flex"> <asp:TextBox ID="txtMaKhoiPhuc" type="text" runat="server" placeholder="OTP" CssClass="input-field" style="width:12rem;"></asp:TextBox>
                 <asp:Button ID="btnGetOTP" runat="server" Text="Lấy Mã" CssClass="submit-button" OnClick="btnGetOTP_Click" style="font-size:12px; width:max-content; height:2.1875rem;"/></div>
                 


                <p><asp:Label class="otp-p" runat="server" ID="lbOTP" style="font-size:12px;
color:darkred; height:12px;"></asp:Label></p>
<%--                <asp:TextBox ID="txtPasswordFogot" runat="server" placeholder="Mật Khẩu" CssClass="input-field" style="width:16rem;"></asp:TextBox>--%>
              



                <asp:Button ID="btnForgot" runat="server" Text="Xác Nhận" CssClass="submit-button" OnClick="btnForgot_Click" />
               
                                            

                    
                <style>
                    .forgot-password {
                        font-size: 12px;
                        color: #242426 !important;
                        text-decoration: none;
                        display: block;
                        margin-top:10px;
   
                    }

                        .forgot-password:hover {
                            text-decoration: underline;
                        }

                    #sgup-li {
                        text-align: right;
                    }

                    #sgin-li,.otp-p {
                        text-align: left;
                    }

                    #btnSignIn {
                        background-color: #9b51e0;
                    }

                    .ul-sgin-sgup {
                        display: flex;
                        list-style: none;
                        gap: 20%;
                        justify-content: center;
                        margin-bottom: 3%;
                    }

                    .signin-password {
                        font-size: 12px;
                            color: #242426 !important;

                        text-decoration: none;
                        display: block;
                        margin-top: 10px;
                    }
                   
                    /*.signin-password:hover {
                text-decoration: underline;
            }*/ .sign-up {
                        font-size: 12px;
                            color: #242426 !important;

                        text-decoration: none;
                        display: block;
                        margin-top: 10px;
                    }

                    /*.sign-up:hover {
                text-decoration: underline;
            }*/

                   /* .sign-up:hover, .signin-password:hover{
                        text-decoration:auto !important;
                    }*/
                </style>
            </div>
            <a  class="forgot-password" href="Sign">Đăng nhập</a>
        </div>
    </form>
</body>
    </html>
