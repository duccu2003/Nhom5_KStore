<%@ Page Title="Gmilk Tea" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="TH03_WebBanHang.AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%>
        <p class="tenSP-ls-p">Thêm Tài Khoản</p>
    </h2>
    <style>
        .tenSP-ls-h3 {
            padding-bottom: 1.5rem;
            text-align: center;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #CCBEB1;
            width: 100%;
        }

        body {
            text-align: center;
            justify-content: center;
        }

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

        #div-content {
            text-align: center;
        }
    </style>
    <div id="div-content">
        <div style="display: inline-grid; width: max-content; text-align: center;">
            <asp:TextBox ID="txtEmailSignUp" runat="server" placeholder="Email" CssClass="input-field w-more"></asp:TextBox>
            <asp:TextBox ID="txtPasswordSignUp" runat="server" TextMode="Password" placeholder="Mặt Khẩu" CssClass="input-field w-more"></asp:TextBox>
            <asp:TextBox ID="txtName" runat="server" placeholder="Họ Và Tên" CssClass="input-field w-more"></asp:TextBox>
            <asp:DropDownList ID="ddlGT" runat="server" CssClass="input-field w-more" OnSelectedIndexChanged="ddlGT_SelectedIndexChanged" AutoPostBack="True" Font-Size="Medium" class="w-more">
                <asp:ListItem ID="txtGTNam" Text="Nam" Value="Nam"></asp:ListItem>
                <asp:ListItem ID="txtGTNu" Text="Nữ" Value="Nữ"></asp:ListItem>
                <asp:ListItem ID="txtGTKhac" Text="Khác" Value="Khác"></asp:ListItem>

            </asp:DropDownList>
            <style>
                #ddlGT {
                    padding: 8px !important;
                    text-align: center !important;
                    margin-bottom: 10px !important;
                    border-radius: 5px !important;
                }

                #btAdd {
                    background-color: #CCBEB1;
                }


                .w-more {
                    width: 100%;
                    text-align: center;
                }

                .btn-more {
                    width: max-content !important;
                    padding: 0.5rem 2rem !important;
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
                    width: 100%;
                    padding: 10px;
                    border: none;
                    background-color: #4CAF50;
                    color: white;
                    border-radius: 4px;
                    cursor: pointer;
                    font-size: 16px;
                }

                    input[type="submit"]:hover {
                        background-color: #45a049;
                    }

                #btAdd, .btn-more {
                    background-color: #CCBEB1 !important;
                }

                    #btAdd:hover, .btn-more:hover {
                        background-color: #cbb39c !important;
                        color: #636161;
                    }
            </style>
            <asp:TextBox ID="txtDiachi" runat="server" placeholder="Địa Chỉ" CssClass="input-field w-more" Style="margin-top: 5%;"></asp:TextBox>
            <asp:TextBox ID="TextPhone" runat="server" placeholder="Số Điện Thoại" CssClass="input-field w-more"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btAdd" runat="server" Text="Thêm" OnClick="btAdd_Click" class="btn-more" />

</asp:Content>
