<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="TH03_WebBanHang.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gmilk Tea</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        /* Global CSS reset */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: Arial, sans-serif;
            background-color: #CCBEB1;
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
            z-index:1;
        }

        .form-container {
            margin-bottom: 20px;
        }

        .text-center {
            text-align: center;
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
            background-color: #4CAF50;
            color: white;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

            .form-container input[type="submit"]:hover {
                background-color: #45a049;
            }

        .forgot-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
            margin-top: 10px;
        }

            .forgot-password:hover {
                text-decoration: underline;
            }

        .signup-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
            margin-top: 10px;
        }

            .signup-password:hover {
                text-decoration: underline;
            }

        .ul-sg-fg {
            display: flex;
            list-style: none;
            gap: 20%;
            justify-content: center;
            margin-bottom: 3%;
        }

        li {
            width: 40%;
        }
        #fg-li{text-align:right;}
        #sgup-li{text-align:left;}
        #btnSignIn {
            background-color:#CCBEB1;
        }
        #btnSignIn:hover {
            background-color:#cbb39c;
            color:#636161;
        }
         #img-maid1 {
            position: absolute;
            right: 0;
            width:18.5rem;
                        bottom: 0;


        }

        #img-maid2 {
            position: absolute;
            left: 0;
            bottom: 0;
            width:18.5rem;

        }
    </style>
</head>
<body>

    <form id="form1" runat="server">       
    <img src="Content/image-bg/maid1.png" id="img-maid1"/>

        <div class="container">
            <div class="form-container sign-in">
                                <%--<img src="Content/icon/ag.gif" style="max-width:100%; border-radius:2rem; margin-bottom:1.5rem;"/>--%>
<%--                <img src="Content/logo/logo.png" id="img-logo-header"/><style>#img-logo-header{max-width:100%;}</style>--%>
              <a href="Default.aspx" style="text-decoration:none; color:#CCBEB1;"> <h1 style="text-align:center; font-weight:bolder; font-family:'Edwardian Script ITC'; font-size:4rem; margin-bottom:1rem;border-bottom-color:#000 ;
                border:1px solid;
                border-top-style:none;
                border-left-style:none;
                border-right:none;"> Gmilk Tea</h1></a>
<%--                <h1 class="text-center">Đăng Nhập</h1>--%>
                <%--                <span class="text-center">or use your email and password</span>--%>
                <asp:TextBox ID="txtEmailSignIn" runat="server" placeholder="Email" CssClass="input-field"></asp:TextBox>
                <asp:TextBox ID="txtPasswordSignIn" runat="server" TextMode="Password" placeholder="Mật Khẩu" CssClass="input-field"></asp:TextBox>


                <asp:Button ID="btnSignIn" runat="server" Text="Đăng Nhập" CssClass="submit-button" OnClick="btnSignIn_Click" />
                 <div class="checkbox">
                <label><asp:CheckBox ID="chkRemember" runat="server" Text="Ghi nhớ đăng nhập" style="font-size: 12px;
            color: #666;
            text-decoration: none;
            margin-top:0.5rem;"/></label>
            </div>
                <ul class="ul-sg-fg">
                    <li id="sgup-li">
                        <asp:LinkButton ID="LinkSignUp" runat="server" Text="Đăng Ký" CssClass="signup-password" href="/SignUp"></asp:LinkButton>
                    </li>
                    <li id="fg-li">
                        <asp:LinkButton ID="lnkForgetPassword" runat="server" Text="Quên Mật Khẩu?" CssClass="forgot-password" href="/Forgot"></asp:LinkButton></li>

                </ul>
            </div>
        </div>
         <img src="Content/image-bg/maid2.png" id="img-maid2"/>
    </form>
</body>
</html>
