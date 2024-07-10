<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePob.aspx.cs" Inherits="TH03_WebBanHang.UpdatePob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
            <style>
            *{
                margin:0;
                padding:0;
                font-family:Roboto;transition:0.5s;
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
    /* box-shadow:0 1px 2px #242426;*/
}
.btn-primary{
    border-radius:5px;
    padding:10px;
}
.btn-primary:hover{
    color:#FFF;
    background:orangered !important;
}
.btnAddPop:hover{
    color:#FFF !important;
    background:black !important;
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
input{
    
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

    <form id="form1" runat="server" style="position:relative; padding:20px;">
        <div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
     <a title="Thoát" class="dropdown-item" href="ManagerProduct.aspx" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
     
</div>
                    <div class=" d-flex" style="display:grid !important; height:max-content; margin: auto; width:max-content; background:#FFFF; padding:15px; border-radius:10px; box-shadow:0 0 5px #636363;">
        <style>
            table tr th, td{
                justify-content:center;
                align-content:center;
                align-items:center;
                justify-items:center;
                text-align:center;
                padding:10px;
            }
            table {
                height:100px;
                overflow:auto;
                
            }
        </style>
        
        <table>
            <tr>
                <td><asp:Label ID="lbMaSP" runat="server" Text="Mã sản phẩm: "></asp:Label></td>
                 <td>   <asp:DropDownList ID="ddlMaSP" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlMaSP_SelectedIndexChanged" CssClass="full-width div-ls popInput" style="width:10rem; height:30px; text-align:center;">
       <%--        <asp:ListItem Text="Khác" Value="addNew"></asp:ListItem>--%>
       <%--        <asp:ListItem Text="L" Value="2"></asp:ListItem>--%>
       
       
  </asp:DropDownList>
                </td>
                

                
            </tr>
            <tr>
<td>
                    <asp:Label ID="lbTenPob" runat="server" Text="Tên Pob: "></asp:Label> </td>
                   <td> <asp:TextBox ID="txtTenPob" CssClass="popInput" runat="server" style=" padding-left:5px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"> <asp:Button ID="btnAddPop" runat="server" Text="THÊM POB VÀO SẢN PHẨM" OnClick="btnAddPop_Click" CssClass="btnAddPop" style="color:#000; padding:10px; width:100%;"/>
</td>
            </tr>
        </table>
        <style>
            table tr td{
               padding:10px;
               justify-content:center;
               justify-items:center;
               align-content:center;
               align-items:center;
               text-align:left;
            }
            .popInput{
                color:#000;
                width:9.5rem;
                height:27px;
               
            }
            .popInput *{
                color:#000;
            }
        </style>
           <table>
           <%-- <tr>
                <th colspan="3" style="text-align:center;">Pob</th>
            </tr>--%>
           <%-- <tr>
                             <th colspan="2"><%#ddlMaSP.SelectedItem.Text.ToString() %></th>
            </tr>--%>
                <asp:ListView ID="listView" runat="server" ItemType="TH03_WebBanHang.Models.POB"
		SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" class="text-center ListView1">
                    <EmptyDataTemplate>
                        <tr>
                            <th>Sản phẩm này chưa được kèm Pob</th>
                        </tr>
                    </EmptyDataTemplate>

                    <ItemTemplate>
                         
                      <%--  <tr>
                       <%-- <td rowspan="2">
                            <img  src="<%#Item.MaSP %>" style="width:80px"/>
                        </td>--%>
                      <%--  <th><%#Item.MaSP %></th>
                                  </tr>--%>
                        <tr>
                            <th><a href="Item.aspx?sp=<%#Item.MaSP %>"><%#Item.MaSP %></a></th>
                                                    <th><%#Item.TenPob %></th>
                                                        <td style="height:100%;">

	                             <asp:Button ID="btnDel" class="btnUpdate btn btn-default btn-color btn-w" runat="server" style="border:none; /*background-color:#0000;*/ /*background:linear-gradient(to right, #7c92ea,#4cff00);*/   /*font-size:14px;*/ /*width:max-content;*/ width: 6rem; background-color:#0000;" CommandArgument='<%# Eval("MaPob")+ ";" +Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btDel_Click" Text="Xóa" CssClass="btn btn-primary" />
<%--	                            <a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaSP%>">Chỉnh sửa</a>--%>
	                            <%--<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaSP%>">Xóa</a>--%>
                            </td>

                        </tr>
                        
                    </ItemTemplate>
                </asp:ListView>
            
        </table>
             
       
            
       

    </div>
    </form>
</body>
</html>
