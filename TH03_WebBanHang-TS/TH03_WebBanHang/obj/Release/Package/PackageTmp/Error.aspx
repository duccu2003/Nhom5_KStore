<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TH03_WebBanHang.Error" %>

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
            width: max-content;
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
                         <img src="Content/image-bg/maid2.png" id="img-maid2"/>

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
               <%-- <asp:TextBox ID="txtEmailError" runat="server" placeholder="Email" CssClass="input-field"></asp:TextBox>
                <asp:TextBox ID="txtPasswordError" runat="server" TextMode="Password" placeholder="Mật Khẩu" CssClass="input-field"></asp:TextBox>--%>
               <h1 style="color:#CCBEB1;text-align:center; font-weight:bolder; font-size:10rem; margin-bottom:1rem ; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;"> 404</h1>
               <%-- <asp:Button ID="btnError" runat="server" Text="Đăng Nhập" CssClass="submit-button" OnClick="btnError_Click" />
                <ul class="ul-sg-fg">
                    <li id="sgup-li">
                        <asp:LinkButton ID="LinkSignUp" runat="server" Text="Đăng Ký" CssClass="signup-password" href="/SignUp"></asp:LinkButton>
                    </li>
                    <li id="fg-li">
                        <asp:LinkButton ID="lnkForgetPassword" runat="server" Text="Quên Mật Khẩu?" CssClass="forgot-password" href="/Forgot"></asp:LinkButton></li>

                </ul>--%>
            </div>
        </div>
<%--         <img src="Content/image-bg/maid2.png" id="img-maid2"/>--%>
    </form>
</body>
</html>
