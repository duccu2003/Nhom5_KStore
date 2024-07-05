<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TH03_WebBanHang.ChangePassword" %>

  <%--  <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%>
   <%-- <p class="tenSP-ls-p">Đổi Mật Khẩu</p>
</h2>--%>
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
            width: 250px;
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



    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />

<style>
    .tenSP-ls-h3 {
        padding-bottom: 1.5rem;
        text-align: center;
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
        text-align: center;
       
        width:100%;
       
    }
    .search-container-table,.search-container{
        
    }
    .container *{
        margin:auto;
    }
    input, select{
        height:2.1875rem;
    }
   
</style>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

</head>
<body style="background-color:#2424269b">
    <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: absolute; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />


     <form id="form1" runat="server" class="container" style="z-index: 1; display: inline-grid;  text-align: center; ">
 
        <asp:Image ID="imgUser" runat="server" style="height:100px; width:100px; object-fit:cover; border:4px dashed #24b51a; border-radius:59%; margin:auto auto 2rem auto;"/>
        <asp:Label ID="lbEmail" runat="server" placeholder="Email" CssClass="input-field" style="margin-bottom:0.5rem;"></asp:Label>
        <asp:TextBox ID="txtPasswordSignUp" type="password" runat="server" TextMode="Password" placeholder="Nhập mật khẩu mới" CssClass="input-field w-more fade-out"></asp:TextBox>
         <asp:TextBox ID="txtPasswordConfirm" type="password" runat="server" TextMode="Password" placeholder="Xác nhận mật khẩu" CssClass="input-field w-more fade-out"></asp:TextBox>

       
        <style>
            #ddlGT {
                padding: 8px !important;
                text-align: center !important;
                margin-bottom: 10px !important;
                border-radius: 5px !important;
            }

            #btChange {
                background-color: #9b51e0;
            }


            .w-more {
                width: 100%;
                text-align: left;
                
            }

            .btn-more {
                width: 12rem !important;
                padding: 0.5rem 2.5rem !important;
                background-color:#6361617c;
                margin-top:1rem;

            }


            input[type="text"],
            input[type="password"] {
                width: 12rem;
                padding:5px 10px !important;
                margin-bottom: 10px;
                border-radius: 4px;
                border: 1px solid #ccc;
                box-sizing: border-box;
                margin-top:0.6rem;
                color:#000;

            }

            input[type="submit"] {
             
                padding: 10px;
                border: none;
                
                color: white;
                border-radius: 4px;
                cursor: pointer;
                font-size: 16px;
            }

                input[type="submit"]:hover {
                    background-color: #9B51E0;
                }

            #btChange, .btn-more {
                background-color: #9b51e0 !important;
            }

                #btChange:hover, .btn-more:hover {
                    background-color: #a49ccb !important;
                    color: #636161;
                }
        </style>
        <asp:Button ID="btChange" runat="server" Text="XÁC NHẬN" OnClick="btChange_Click" class="btn-more fade-in"  />
         <a class="dropdown-item" href="Account" style="margin:1rem auto 0 auto; border-radius:50%; border:1px dashed #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;"><i class="fa-solid fa-arrow-left" style="margin-right: 5px; width: 35px;"></i></a>

         </form>


    </body>