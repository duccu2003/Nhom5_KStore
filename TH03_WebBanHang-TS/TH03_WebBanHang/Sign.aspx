<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign.aspx.cs" Inherits="TH03_WebBanHang.Sign" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>KStore</title>
        <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <script src="~/Scripts/jquery-1.10.2.js"></script>
<script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, Helvetica, sans-serif;
        }
        
        body {
            background-color: #c9d6ff;
            background: #000;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            height: 100vh;
            overflow: hidden;
        }
        
        .container {
            background-color: #fff;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.35);
            position: relative;
            overflow: hidden;
            width: 100%;
            
            height: 100%;
        }
        
        .container h1 {
            font-size: 24px;
            margin-bottom: 10px;
            
            
        }
        
        .container p {
            font-size: 14px;
            line-height: 20px;
            letter-spacing: 0.3px;
            
            width:300px; 
            margin:20px auto;
            display:block;
            height:max-content;
        }
        
        .container span {
            font-size: 12px;
        }
        
        .container a {
            color: #9b51e0;
            font-size: 13px;
            text-decoration: none;
            margin: 15px 0 10px;
        }
        .submit-button{
            font-size: 13px !important;
        }
        .container .button {
            background-color: #512da8;
            color: #fff;
            font-size: 12px;
            padding: 10px 45px;
            border: 1px solid transparent;
            border-radius: 8px;
            font-weight: 600;
            letter-spacing: 0.5px;
            text-transform: uppercase;
            margin-top: 10px;
            cursor: pointer;
        }
        
        .container .button.hidden {
            background-color: transparent;
            border-color: #fff;
        }
        
        .container form {
            background-color: #fff;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            padding: 0 40px;
            height: 100%;
        }
        
        .container input {
            background-color:#fff;
            border: none;
            
            padding: 10px;
            font-size: 13px;
            border-radius: 8px;
            width: 100%;
            outline: none;
        }
        
        .form-container {
            position: absolute;
            top: 0;
            height: 100%;
            transition: all 0.6s ease-in-out;
            
        }
        
        .sign-in {
            left: 0;
            width: 50%;
            z-index: 2;
            text-align:center;
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
            display:grid;
        }
        
        .container.active .sign-in {
            transform: translateX(30%);
        }
        
        .sign-up {
            left: 20%;
            width: 80%;
            opacity: 0;
            z-index: 1;
           display:grid;
            text-align:center;
            justify-content:center;
            align-content:center;
            align-items:center;
            justify-items:center;
           
        }
        
        .container.active .sign-up {
            transform: translateX(20%);
            opacity: 1;
            z-index: 5;
            animation: move 0.6s;
        }
        
        @keyframes move {
            0%,
            49.99% {
                opacity: 0;
                z-index: 1;
            }
            50%,
            100% {
                opacity: 1;
                z-index: 5;
            }
        }
        
        .social-icons {
            margin: 20px 0;
        }
        
        .social-icons a {
            border: 1px solid #ccc;
            border-radius: 20%;
            display: inline-flex;
            justify-content: center;
            align-items: center;
            margin: 0 3px;
            width: 40px;
            height: 40px;
        }
        
        .toggle-container {
            position: absolute;
            top: 0;
            left: 50%;
            width: 50%;
            height: 100%;
            overflow: hidden;
            transition: all 0.6s ease-in-out;
            border-radius: 150px 0 0 100px;
            z-index: 1000;
        }
        
        .container.active .toggle-container {
            transform: translateX(-100%);
            border-radius: 0px 150px 100px 0px;
        }
        
        .toggle {
            background-color: #512da8;
            height: 100%;
            background: linear-gradient(to left, #e5711e, #512da8);
            color: #fff;
            position: relative;
            left: -100%;
            height: 100%;
            width: 200%;
            transform: translateX(0);
            transition: all 0.6s ease-in-out;
        }
        
        .container.active .toggle {
            transform: translateX(50%);
        }
        
        .toggle-panel {
            position: absolute;
            width: 50%;
            height: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            padding: 0 30px;
            text-align: center;
            top: 0;
            transform: translateX(0);
            transition: all 0.6s ease-in-out;
        }
        
        .container.active .toggle-left {
            transform: translateX(0);
        }
        
        .container.active .toggle-right {
            transform: translateX(200%);
        }
        
        .toggle-left {
            transform: translateX(-200%);
        }
        
        .toggle-right {
            right: 0;
            transform: translateX(0);
        }
        input, select{
            width:14rem !important;
            justify-content:center;
            align-content:center;
            align-items:center;
            margin:5px auto;
            border-radius:10px !important;
            background-color:#fff;
        }
        
        .checkbox {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            margin-top: 0.5rem;
        }
        
        .ul-sg-fg {
            
            list-style: none;
            
           
            margin-bottom: 3%;
        }
        
        .signin-password, .forgot-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
            
        }
        
        .signin-password:hover, .forgot-password:hover {
            text-decoration: underline;
        }


         .form-container {  
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
        
             padding: 10px;
        
             border-radius: 4px;
             border: 1px solid #ccc;
             box-sizing: border-box;
         }

         .form-container input[type="submit"] {
         
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
         #btnSignUp {
            background-color:#9b51e0;
     
         }
         #btnSignUp:hover {
             background-color:#a49ccb;
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

         .form-container {
            margin-bottom: 20px;
         }

        .text-center {
            text-align: center;
        }

        .form-container h1 {
            font-size: 24px;
            margin-bottom: 10px;
            color: #353535e1 !important;
        }

        .form-container span {
            font-size: 14px;
            color: #666;
            display: block;
            margin-bottom: 10px;
        }

        .form-container input[type="text"],
        .form-container input[type="password"] {
    
            padding: 10px;
            border-radius: 4px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .form-container input[type="submit"] {
    
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

        .forgot-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
        
        }

        .forgot-password:hover {
            text-decoration: underline;
        }

        .signup-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
       
        }

        .signup-password:hover {
            text-decoration: underline;
        }

    

   
    
        #btnSignIn {
            background-color:#9b51e0;
        
        }
        #btnSignIn:hover {
            background-color:#a49ccb;
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
        #container{
            background-image:url("Content/image-bg/bg-for-slide-gp.png");
            background-size:cover;
            background-repeat:no-repeat;
            object-fit:cover;
       
        
        }
        #form1{
            background:#2424269b;
        }
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
          -webkit-appearance: none;
          margin: 0;
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
        .container-check {
             display: block;
             position: relative;
     
             margin: 5px auto;
             cursor: pointer;
             font-size: 12px;
             -webkit-user-select: none;
             -moz-user-select: none;
             -ms-user-select: none;
             user-select: none;
             padding-left:18px;
             justify-items:center;
             justify-content:center;
             align-content:center;
             align-items:center;
        }

        .container-check input {
             position: absolute;
             opacity: 0;
             cursor: pointer;
             height: 0;
             width: 0;

        }

        .checkmark {
             position: absolute;
             top: 0;
             left: 0;
             height: 15px;
             width: 15px;
             background-color: #eee;
             border-radius:10px;
        }

        .container-check:hover input ~ .checkmark {
             background-color: #ccc;
        }

        .container-check input:checked ~ .checkmark {
             background-color: #2196F3;
        }

        .checkmark:after {
             content: "";
             position: absolute;
             display: none;
        }

        .container-check input:checked ~ .checkmark:after {
             display: block;
        }

        .container-check .checkmark:after {
             left: 4.5px;
             top: 2.5px;
             width: 2.5px;
             height: 5px;
             border: solid white;
             border-width: 0 3px 3px 0;
             -webkit-transform: rotate(45deg);
             -ms-transform: rotate(45deg);
             transform: rotate(45deg);
        }
        .content-form{
             display:grid;
             width:max-content;
             background:#e3e3e3a1;
             padding:20px 15px 10px 15px;
             border-radius:10px;

        }
        #ddlGT {
             padding:8px 8px 8px 5px;
             text-align:left; 
             border-radius:5px;
        } 
        #btnSignIn {
            background-color:#9b51e0;
        }
        .signin-password {
            font-size: 12px;
            color: #666;
            text-decoration: none;
            display: block;
   
        }

        .signin-password:hover {
            text-decoration: underline;
        }
        .forgot-password {
            font-size: 12px;
            color: #242426 !important;
            text-decoration: none;
            display: block;
   
        }

        .forgot-password:hover {
            text-decoration: underline;
        }


        .btn-a-click:hover{
            background:linear-gradient(to top, #c9d6ff88, #ffffff6d);
        }

    </style>
    
</head>

<body>
    
    <div class="container active" id="container">
        <form id="form1" runat="server">
            <div class="form-container sign-in">
                <div class="content-form">
                    <h1>ĐĂNG NHẬP</h1>
                      <%--<div class="social-icons">
                        <a href="#" class="icon"><i class="fa-brands fa-google"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-facebook"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-github"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-linkedin"></i></a>
                      </div>
                      <span>or use your email password</span>--%>
                    <asp:TextBox ID="txtEmailSignIn" runat="server" placeholder="Email" CssClass=""></asp:TextBox>
                    <asp:TextBox ID="txtPasswordSignIn" type="password" runat="server" TextMode="Password" placeholder="Mật khẩu" CssClass=""></asp:TextBox>

                    <asp:Button ID="btnSignIn" runat="server" Text="ĐĂNG NHẬP" CssClass="submit-button" OnClick="btnSignIn_Click" />
                
                       
                    <label class="container-check">Ghi nhớ đăng nhập
                        <asp:CheckBox ID="chkRemember" runat="server" />
                        <span class="checkmark"></span>
                    </label>
       
                    <a  class="forgot-password" href="Forgot">Quên mật khẩu</a>
                </div>               
            </div>
            <div class="form-container sign-up">
                <div class="content-form">
                    <h1>ĐĂNG KÝ</h1>
                    <%--<div class="social-icons">
                        <a href="#" class="icon"><i class="fa-brands fa-google"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-facebook"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-github"></i></a>
                        <a href="#" class="icon"><i class="fa-brands fa-linkedin"></i></a>
                    </div>
                    <span>or use your email for registeration</span>   --%>         
           
                   <%-- <img src="Content/icon/ag.gif" style="max-width: 100%; border-radius: 2rem; margin-bottom: 1.5rem;" />
                    <h1>Đăng Ký</h1>--%>
                    <%--                <span>or use your email for registration</span>--%>
                              
                    <div class="d-flex">
                        <asp:TextBox ID="txtName" type="text" runat="server" placeholder="Họ và tên" CssClass=""></asp:TextBox>
                        <asp:TextBox ID="TextPhone" type ="number"   runat="server" placeholder="Số điện thoại" CssClass="" style=""></asp:TextBox>
                    </div>
                    <div class="d-flex">
                        <asp:DropDownList ID="ddlGT" runat="server" CssClass="" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" Width="100%" Font-Size="small">
                            <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam"></asp:ListItem>
                            <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ"></asp:ListItem>
                            <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtEmailSignUp" type="email" runat="server" placeholder="Email" CssClass="" style=" padding-left:10px;"></asp:TextBox>
                    </div>

                    <div class="d-flex">
                        <asp:TextBox ID="txtPasswordSignUp" type="password" runat="server" TextMode="Password" placeholder="Mật khẩu" CssClass=""></asp:TextBox>
                        <asp:TextBox ID="txtPasswordSignUpAgain" type="password" runat="server" TextMode="Password" placeholder="Nhập lại mật khẩu" CssClass=""></asp:TextBox>
                    </div>
                 
                
                    <div class="d-flex">         
                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="" style="padding:  8px 5px;">
                        </asp:DropDownList> 
                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="" style="padding: 8px 5px;">
                        </asp:DropDownList>
                    </div> 
                     
   
                    <div class="d-flex">
                        <asp:DropDownList ID="ddlW" runat="server" AutoPostBack="True" CssClass="" style="padding: 8px 5px;" >
                        </asp:DropDownList>
                        <asp:TextBox ID="txtDiachi" type="text" runat="server" placeholder="Địa chỉ" CssClass=" " Style ="" ></asp:TextBox>
                    </div>
                
                    <asp:Button ID="btnSignUp" runat="server" Text="ĐĂNG KÝ" CssClass="submit-button btn-sign-up" OnClick="btnSignUp_Click" />
                
                    <a class="forgot-password" href="Forgot">Quên mật khẩu</a>
                </div>
            </div>
            <div class="toggle-container">
                <div class="toggle">
                    <div class="toggle-panel toggle-left">
                        <a href="Default.aspx" style="text-decoration:none; color:#9b51e0;">
                            <img style="width:80%;" src="Content/logo/K-Photoroom.png"/>
                        </a>
                        <h1>Chào mừng bạn đến với KStore!</h1>
                        <p>Đăng nhập thông tin cá nhân của bạn để sử dụng tất cả các tính năng của trang web</p>
                        <a href="#" class="hidden button btn-a-click" id="login">Đăng nhập ngay!</a>
                    </div>
                    <div class="toggle-panel toggle-right">
                        <a href="Default.aspx" style="text-decoration:none; color:#9b51e0;">
                            <img style="width:80%;" src="Content/logo/K-Photoroom.png"/>
                        </a>
                        <h1>KStore xin chào quý khách!</h1>
                        <p>
                            Đăng ký với thông tin cá nhân của bạn để sử dụng tất cả các tính năng của trang web
                        </p>
                        <a href="#" class="hidden button btn-a-click" id="register">Đăng ký ngay!</a>
                    </div>
                </div>
            </div>   
        </form>           
    </div>
    <script>
        var singIn = false;
        var signupSC = document.getElementsByClassName('btn-sign-up');
        const registerBtn = document.getElementById("register");
        const container = document.getElementById("container");
        const loginBtn = document.getElementById("login");

        registerBtn.addEventListener("click", () => {
            container.classList.add("active");
            localStorage.setItem("tabActive", "signUp"); //Lưu trạng thái
            singIn = true;
        });

        loginBtn.addEventListener("click", () => {
            container.classList.remove("active");
            localStorage.setItem("tabActive", "");
            singIn = false;

        });
        signupSC.addEventListener("click", () => {
            container.classList.remove("active");
            localStorage.setItem("tabActive", "");

        });

        document.addEventListener("DOMContentLoaded", function () {
            //Kiểm tra trạng thái lưu trữ
            if (localStorage.getItem("tabActive") === "signUp") {
                container.classList.add("active");
                singIn = true;
            } else if (localStorage.getItem("tabActive") === "") {
                //Không áp dụng trạng thái nếu không có trạng thái được lưu trữ
            }
        });

    </script>
</body>

</html>
