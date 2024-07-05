<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInformation.aspx.cs" Inherits="TH03_WebBanHang.UpdateInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
        <style>
            *{
                margin:0;
                padding:0;font-family:Roboto;transition:0.5s;
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
.btn-primary{
    border-radius:5px;
}
.btn-primary:hover{
    color:#FFF;
    background:orangered !important;
}
.btnUpBV:hover{
    color:#FFF;
    background:black !important;
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

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous">

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

    <form id="form1" runat="server" style="position:relative !important;">
<<<<<<< HEAD
        <div style="margin:20px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
             <a title="Thoát" class="dropdown-item" href="Account.aspx" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
             
        </div>
=======
               <a class="dropdown-item" href="Account.aspx" style="margin:20px;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center; position:fixed; background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>

>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
        <div class="container px-5 px-lg-5" style="text-align:center !important;  display:flex !important; padding:20px !important; margin:auto !important; gap:10px !important; width:max-content; ">
            <div class="col-sm-2 div-updateInformation" style="width:620px; display:grid; padding: 10px; background:#FFFF; height:max-content; overflow:auto;">
                 <table class="table" style="width:100%; margin:auto;">
                     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
                     <script>
                         function previewImageBanner(event) {
                             var reader = new FileReader();
                             reader.onload = function () {
                                 var output = document.getElementById('preview');
                                 output.src = reader.result;
                             };
                             reader.readAsDataURL(event.target.files[0]);
                         }
                     </script>

                     <tr><th scope="col" style="text-align:center;">
                         Thêm banner
                         </th></tr>
                     <tr>
                         <th scope="col">
<<<<<<< HEAD
                             <asp:TextBox ID="txtBannerTitle" runat="server" placeholder="Tiêu đề Banner mới" style="width:100%; font-size:20px;"></asp:TextBox>
                         </th>
                     </tr>
                     <tr>
                         <th scope="col">
=======
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
                             <asp:FileUpload ID="fileUploadBanner" CssClass="div-add-input"  runat="server" onchange="previewImageBanner(event)" style=" /*border:1px solid #000;*/ outline:none;"/>
                                <img id="preview" src="" alt="Banner" style="width:100%;"/>
                         </th>
                         
                     </tr>

                     <tr>
                         <td>
                               <asp:Button ID="btnAddBanner" runat="server" Text="THÊM BANNER" CssClass="input btnUpBV" OnClick="btnAddBanner_Click" />

                         </td>
                     </tr>
                 </table>
            </div>
            <div class="col-sm-10 div-updateInformation" style="display:grid; width:586px; padding:0 10px; background:#FFFF; height:540px; overflow:auto;">

                                <table class="table" style="width:100%; text-align:center; overflow:auto;">
            <tr>
                <th scope="col" colspan="2" style="text-align:center;">Banner</th>
            </tr>
           <%-- <tr>
                             <th colspan="2"><%#ddlMaSP.SelectedItem.Text.ToString() %></th>
            </tr>--%>
                <asp:ListView ID="listView2" runat="server" ItemType="TH03_WebBanHang.Models.Banner"
		SelectMethod="GetDeparmentsBanner" OnSelectedIndexChanged="ListView1Banner_SelectedIndexChanged" class="text-center ListView1">
                    <ItemTemplate>
                         
                      <%--  <tr>
                       <%-- <td rowspan="2">
                            <img  src="<%#Item.MaSP %>" style="width:80px"/>
                        </td>--%>
                      <%--  <th><%#Item.MaSP %></th>
                                  </tr>--%>
                        <tr>
                            <th colspan="2" scope="col" style="background:#000; color:#FFFF;">
                                <p><%#:Item.TieuDe %></p>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2" scope="col">
                                <img style="width:100%;" src="<%#Item.DuongDan %>"/>
                            </th>
                                       
                                                       

                        </tr>
                      <%--  <tr>
                            
                            <th colspan="2"><%#Item.NoiDungBV %></th>
                        </tr>--%>
                        <tr>
                                <th scope="col">
                                    <p><%#:Item.NgayDangBV %></p>
                                </th>
                              <td>

	                             <asp:Button ID="btnDelBanner" class="btnUpdate btn btn-default btn-color btn-w" runat="server" style="border:none; /*background-color:#0000;*/ /*background:linear-gradient(to right, #7c92ea,#4cff00);*/   /*font-size:14px;*/ /*width:max-content;*/ width: 6rem; background-color:#0000;" CommandArgument='<%# Eval("MaBanner")%>' OnClick="btnDelBanner_Click" Text="Xóa" CssClass="btn btn-primary" />
<%--	                            <a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaSP%>">Chỉnh sửa</a>--%>
	                            <%--<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaSP%>">Xóa</a>--%>
                            </td>
                        </tr>
                        
                    </ItemTemplate>
                </asp:ListView>
            
        </table>


            </div>
        </div>
        <div class="container px-5 px-lg-5" style="text-align:center !important; height:540px;  display:flex !important; padding:20px !important; margin:auto !important; gap:10px !important; width:max-content; ">
           <div  class="div-updateInformation col-sm-4" style="height:100%; display:grid; padding:0 10px; background:#FFFF">
           <table class="table">
               <tr><th scope="col" colspan="2" style="text-align:center;">
                   Thêm tin tức
                   </th></tr>
               <tr>
                   <th scope="col">
                               <asp:Label ID="lbHinhBV" runat="server" Text="Link hình ảnh:"></asp:Label>

                   </th>
                   <td>
                        <asp:TextBox ID="txtHinhBV" TextMode="MultiLine" runat="server" CssClass="input"></asp:TextBox>

                   </td>
               </tr>
               <tr>
                   <th scope="col"><asp:Label ID="lbLinkBV" runat="server" Text="Link bài viết:"></asp:Label></th>
                   <td><asp:TextBox ID="txtLinkBV" TextMode="MultiLine" runat="server" CssClass="input"></asp:TextBox></td>
               </tr>
                 <tr>
                   <th scope="col"><asp:Label ID="lbTieuDeBV" runat="server" Text="Tiêu đề bài viết:"></asp:Label></th>

                  <td><asp:TextBox ID="txtTieuDeBV" TextMode="MultiLine" runat="server" CssClass="input"></asp:TextBox></td>
              </tr>
               <tr>
                   <th scope="col"><asp:Label ID="lbNoiDungBV" runat="server" Text="Tóm tắt nội dung bài viết:"></asp:Label></th>
                   <td>
                        <asp:TextBox ID="txtNoiDungBV" TextMode="MultiLine" runat="server" CssClass="input"></asp:TextBox>

                   </td>
               </tr>
               <tr>
                   <td colspan="2">
                               <asp:Button ID="btnThemBV" runat="server" Text="THÊM BÀI VIẾT" CssClass="input btnUpBV" OnClick="btnAddInformationBV_Click" />

                   </td>
               </tr>
           </table>
            <table class="table">
                <tr><th scope="col" colspan="2" style="text-align:center;">
                    Thêm video
                    </th></tr>
                <tr>
                    <th scope="col">
                        <asp:Label ID="Label1" runat="server" Text="Link Video:"></asp:Label>

                    </th>
                    <td>
                         <asp:TextBox ID="txtLinkVideo" TextMode="MultiLine" runat="server" CssClass="input"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                                <asp:Button ID="btnThemVideo" runat="server" Text="THÊM VIDEO" CssClass="input btnUpBV" OnClick="btnAddInformationVideo_Click" />

                    </td>
                </tr>
            </table>
        </div>
        <style>
            .div-updateInformation{
                border-radius:10px;
            }
           
            .table{
                width:max-content;
                justify-content:center;
                align-content:center;
                justify-items:center;
                align-items:center;
                text-align:left;
                /*margin:auto;*/
                background:#0000;
                
            }
            .table *{
                padding:5px;
                border:none;
                 justify-content:center;
                 align-content:center;
                 justify-items:center;
                 align-items:center;
                

            }
            .table tr{
                /*border-bottom:1px dashed #636363;*/
                 box-shadow:0 1px 2px #242426;
            }
             .table tr th{
                 width:12rem
             }
            .input{
                color:#000;
                background:#fff;
                border-radius:10px;
                height:40px;
                margin:auto !important;
                
               
            }
            .btnUpBV{
                width:100%;
            }
        </style>
        <div  class="div-updateInformation col-sm-4" style="height:100%; display:grid; padding:0 10px; background:#FFFF;  overflow:auto;">
                <table class="table" style="width:400px; text-align:center; overflow:auto;">
            <tr>
                <th scope="col" colspan="3" style="text-align:center;">Tin tức</th>
            </tr>
           <%-- <tr>
                             <th colspan="2"><%#ddlMaSP.SelectedItem.Text.ToString() %></th>
            </tr>--%>
                <asp:ListView ID="listView" runat="server" ItemType="TH03_WebBanHang.Models.TinTuc"
		SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1TinTuc_SelectedIndexChanged" class="text-center ListView1">
                    <ItemTemplate>
                         
                      <%--  <tr>
                       <%-- <td rowspan="2">
                            <img  src="<%#Item.MaSP %>" style="width:80px"/>
                        </td>--%>
                      <%--  <th><%#Item.MaSP %></th>
                                  </tr>--%>
                        <tr>
                            <th scope="col">
                                <img style="width:100px;" src="<%#Item.HinhAnhBV %>"/>
                                </th>
                                                    <th style="text-align:left;"><%#Item.TieuDe %></th>
                                                       

                        </tr>
                      <%--  <tr>
                            
                            <th colspan="2"><%#Item.NoiDungBV %></th>
                        </tr>--%>
                        <tr>
                            <th scope="col"><%#Item.NgayDangBV %></th>
                                                                                    <td>

	                             <asp:Button ID="btnDelTinTuc" class="btnUpdate btn btn-default btn-color btn-w" runat="server" style="border:none; /*background-color:#0000;*/ /*background:linear-gradient(to right, #7c92ea,#4cff00);*/   /*font-size:14px;*/ /*width:max-content;*/ width: 6rem; background-color:#0000;" CommandArgument='<%# Eval("MaBV")%>' OnClick="btDelTinTuc_Click" Text="Xóa" CssClass="btn btn-primary" />
<%--	                            <a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaSP%>">Chỉnh sửa</a>--%>
	                            <%--<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaSP%>">Xóa</a>--%>
                            </td>
                        </tr>
                        
                    </ItemTemplate>
                </asp:ListView>
            
        </table>
    </div>
            <div class="div-updateInformation col-sm-4" style="height:100%; display:grid; padding:0 10px; background:#FFFF;  overflow:auto;">
                <table class="table" style="width:400px; text-align:center; overflow:auto;">
            <tr>
                <th scope="col" colspan="3" style="text-align:center;">Video</th>
            </tr>
           <%-- <tr>
                             <th colspan="2"><%#ddlMaSP.SelectedItem.Text.ToString() %></th>
            </tr>--%>
                <asp:ListView ID="listView1" runat="server" ItemType="TH03_WebBanHang.Models.VideoThongTin"
		SelectMethod="GetDeparmentsVideoThongTin" OnSelectedIndexChanged="ListView1VideoThongTin_SelectedIndexChanged" class="text-center ListView1">
                    <ItemTemplate>
                    
                        <tr>
                            <th scope="col" colspan="2">
                                <div title="Video thông tin gần đây" class="col-6">
                                    <div  class="embed-responsive embed-responsive-16by9 mb-3 fade-in video-if">
                                        <iframe loading="lazy" class="embed-responsive-item" src="<%#: Item.DuongDanV %>" allowfullscreen></iframe>
                                    </div>
                                </div>
                        </tr>
                      <%--  <tr>
                            
                            <th colspan="2"><%#Item.NoiDungBV %></th>
                        </tr>--%>
                        <tr>
                            <th scope="col"><%#Item.NgayDangBV %></th>
                                                                                    <td>

	                             <asp:Button ID="btnDelVideoThongTin" class="btnUpdate btn btn-default btn-color btn-w" runat="server" style="border:none; /*background-color:#0000;*/ /*background:linear-gradient(to right, #7c92ea,#4cff00);*/   /*font-size:14px;*/ /*width:max-content;*/ width: 6rem; background-color:#0000;" CommandArgument='<%# Eval("MaV")%>' OnClick="btDelVideoThongTin_Click" Text="Xóa" CssClass="btn btn-primary" />
<%--	                            <a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaSP%>">Chỉnh sửa</a>--%>
	                            <%--<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaSP%>">Xóa</a>--%>
                            </td>
                        </tr>
                        
                    </ItemTemplate>
                </asp:ListView>
            
        </table>
    </div>
    </div>
    </form>

</body>
</html>
