<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerAccount.aspx.cs" Inherits="TH03_WebBanHang.ManagerAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"/>

    <style>
      ::-webkit-scrollbar {
     width: 5px;
 }

 ::-webkit-scrollbar-thumb {
     background: #5e17a2ff;
 }

 ::-webkit-scrollbar-track {
     background: #202020;
 }
     body {
         margin: 0;
         padding: 0;
         color: #000;                      
     }
     *{
         color:#000;font-family:Roboto;transition:0.5s;
     }
    /* Thay đổi kích thước cho NextPreviousPagerField và ImageButton */
     .pagerImage {
         width: 25px!important;
         height: 25px!important;
     }

     .btn-p-m {
         width: 25px!important;
         height: 25px!important;
     }

     /* Điều chỉnh căn chỉnh nội dung */
     .form-container {
         display: flex;
         flex-direction: column;
         align-items: flex-start; /* Căn chỉnh sang trái */
         z-index:1;
         width:100%;
         margin:auto;

     }

     .search-container-table {
     }


    .form-container::after {
         
     }

    .btn-p-m {
         /* Các định dạng khác không thay đổi */
     }

    .btn-color {
         color: #000; /* Thay đổi màu sắc thành đen */
         text-decoration: none; /* Bỏ gạch chân */
     }

    .btn-color:hover {
        /* color: #242426;*/
     }

     table {
         overflow: hidden;
         width:1260px !important;

     }

    /* table th, table td {
         border: 1px solid #242426;
     }*/
     table th, table td {
        /*border-bottom:1px solid #242426;*/
       /* border:1px solid #242426;*/
       box-shadow:0 1px 2px #242426;
     }
      .btn-default:hover{
     color:#FFF !important;
     background:#000 !important;
 }
     table th:first-child, table td:first-child {
        
     }

     table th:last-child, table td:last-child {
         
     }
     a{
         text-decoration:none;

     }
     td{
         padding:10px;text-align:center;
     }
     .d-flex {
         display: flex;
         justify-content: center;
        /* align-items: center;*/
         gap: 5px; /* Tạo khoảng cách giữa các thành phần */
     }

     /* Đảm bảo rằng các nút và textbox đều có kích thước phù hợp */
     .btn-p-m, #txtSoLuongKho {
         width: auto; /* Cho phép tự động điều chỉnh chiều rộng */
         height: auto; /* Cho phép tự động điều chỉnh chiều cao */
          border:1px solid #242426;
          border-radius:5px;
     }

     /* Nếu bạn muốn tăng kích thước của textbox, bạn có thể điều chỉnh trực tiếp */
     #txtSoLuongKho {
         width: 60px; 
         height: 30px !important; 
        
     }
     .btn-w{
         width:100px !important;
         height:30px !important;
         background:#fff;
         border:1px solid #242426;
         border-radius:5px;
         align-content:center;
         align-items:center;
         font-size:14px;
         font-weight:normal;
         
     }
     /* Các định dạng khác không thay đổi */
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
*{
    font-family:Roboto;
}
    </style>
   

</head>
<body style="overflow-x:hidden;">    
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
    <style>
        .avt-user{
            width:100px; 
            border-radius:50%; 
            border:5px solid; 
            height:100px; 
            object-fit:cover; 
            overflow:hidden;
         
        }
    </style>
    <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />

    <form id="form1" runat="server" class="form-container container justify-content-center align-items-center" style="padding:20px 0;">
        <div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
     <a title="Thoát" class="dropdown-item" href="Account.aspx" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
     
</div>

        <div class="form-container container">
   
    <div style="width:80%; padding:20px; background: #FFFF;  margin:auto;           border-radius: 10px;">
   <div class="container" style="text-align:left; padding-left:2px; margin-bottom:1rem;">
       

                      <div title="Tìm kiếm" class="justify-content-center align-content-center search-container container mt-2" style="border: 1px solid #242426; width:15rem;  font-size:18px; height:40px;">
    
                    
                            <asp:TextBox ID="searchinputA" placeholder="Tìm kiếm" type="search" Text="" runat="server"  Style="border: 1px solid #0000 !important; touch-action: none; border-bottom-left-radius:5px; border-top-left-radius: 5px;" class="search-textbox searchinput"></asp:TextBox>
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
             <asp:ImageButton runat="server" ID="btnSearch" CssClass="searchbutton justify-content-center align-content-center" OnClick="SearchButton_Click" ImageUrl="Content/icon/search.png"/>
                
                   <style>
                     #searchinputA:focus {
     border: none; /* Loại bỏ viền */
     outline: none; /* Loại bỏ viền nổi khi nhấp vào */
     
 }
                    #searchbutton {
    position: absolute;
    top: 0;
    right: 0;
    width: auto;
    height: 100%;
    background-color: #FFFFFF;
    border: none;
    border-radius: 0 5px 5px 0;
    cursor: pointer;
}
                    .search-container {
    position: relative;
    width: 8rem;
    display: inline-flex;
    border-radius: 5px;
    border: 1px solid #242426;
    background: #FFFF;
}

#MainContent_searchinputA {
    background: #000000;
}

.search-container-table {
    position: relative;
    width: max-content;
    display: inline-flex;
    border-radius: 10px;
    border: 1px solid #242426;
    background: #FFFF;
    max-width: 14.8rem !important;
    
}
/* Style for the search input */
#searchinputA {
    width: 12rem !important;
    padding: 0 5px;
    background: #FFFF;
    
}
                    .searchbutton {
                        background-repeat: no-repeat;
                        background-size: contain; 
                        width: 18px !important; 
                        height: 18px !important; 
                        border: none; 
                        cursor: pointer; 
                        margin-top: 0.6rem;
                        margin-left: 3%;
                        
                    }
                    #div-search-Items{
            
                    }
                   
                </style>
    


    
        </div>



              <%-- <div title="Tìm kiếm" class="justify-content-center align-content-center search-container container mt-2" style="border: 1px solid #242426; width:14rem;  font-size:18px; height:40px;">
    
                    
                            <asp:TextBox ID="searchinputA" placeholder="Tìm kiếm" type="search" Text="" runat="server"  Style="border: 1px solid #fff0 !important; touch-action: none; border-bottom-left-radius:5px; border-top-left-radius: 5px;" class="search-textbox searchinput"></asp:TextBox>
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
            
                            

                            
                            <asp:Button runat="server" ID="btnSearch" CssClass="searchbutton justify-content-center align-content-center" OnClick="SearchButton_Click" Text="" />
                <style>
                     #searchinputA:focus {
     border: none; /* Loại bỏ viền */
     outline: none; /* Loại bỏ viền nổi khi nhấp vào */
     
 }
                    #searchbutton {
    position: absolute;
    top: 0;
    right: 0;
    width: auto;
    height: 100%;
    background-color: #000000;
    border: none;
    border-radius: 0 5px 5px 0;
    cursor: pointer;
}
                    .search-container {
    position: relative;
    width: 8rem;
    display: inline-flex;
    border-radius: 5px;
    border: 1px solid #242426;
    background: #FFF;
}

#MainContent_searchinputA {
    background: #000000;
}

.search-container-table {
    position: relative;
    width: max-content;
    display: inline-flex;
    border-radius: 10px;
    border: 1px solid #242426;
    background: #000;
    max-width: 14.8rem !important;
    
}
/* Style for the search input */
#searchinputA {
    width: 12rem !important;
    padding: 0 5px;
    background: #FFF;
    
}
                    .searchbutton {
                        background-image: url('Content/icon/search.png');
                        background-repeat: no-repeat;
                        background-size: contain; 
                        width: 18px !important; 
                        height: 18px !important; 
                        border: none; 
                        cursor: pointer; 
                        margin-top: 0.6rem;
                        margin-left: 3%;
                        
                    }
                    #div-search-Items{
            
                    }
                </style>
    


    
        </div>--%>
   
   		      <a class="btn btn-default btn-color mx-2" style="padding:5px;background:#FFF; border:1px solid #242426;  color:#000; width:8rem;  height:40px !important;padding:10px; border-radius:5px; justify-content:left"    href="AddAccount.aspx">Thêm tài khoản</a> 

    </div>
        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.KhachHang" SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" class="text-center ListView1">
        <EmptyDataTemplate>
            <table  style="text-align:center;margin:auto; border:none">
	            <tr style="border:none">
		            <td style="border:none"><%--No data was returned.--%> <h4>Chưa có khách hàng.</h4></td>
	            </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td class="td-longer justify-content-center align-content-center">
                <img title="<%#:Item.HoTen %>"" class="avt-user" style='<%# Item.TrangThai == true ? "border-color: #50C878;" : "border-color: #808080;" %>' src="<%#:Item.AvatarUser%>"/>
                <div style="text-align:center; justify-content:center; margin:auto; width:100%;">
                    <p style='<%#:Item.TrangThai==true?"color:#50C878; border-radius:10px; position:relative; top:-0.85rem; margin:auto; padding:0 2px; text-align:center; background:#FFF;  font-weight:bold; width:max-content;": "color:#808080; border-radius:10px; position:relative; top:-0.85rem; margin:auto; padding:0 2px; text-align:center; background:#FFF;  font-weight:bold; width:max-content;" %>'><%#:Item.TrangThai==true?"Online" : "Offline" %></p>
                </div>
            </td>
			<td class="td-longer justify-content-center align-content-center"><%#:Item.HoTen%></td>
			<td class="justify-content-center align-content-center"><%#:Item.DienThoai%></td>
			<%--<td class="justify-content-center align-content-center"><%#:Item.GioiTinh%></td>--%>
			<td class="td-longer justify-content-center align-content-center"><%#:Item.DiaChi%></td>
			<td class="justify-content-center align-content-center"><%#:Item.Email%></td>
			<%--<td class="justify-content-center align-content-center"><%#:Item.MatKhau%></td>--%>
						<td class="justify-content-center align-content-center"><%#:Item.Diem%></td>

            <td class="justify-content-center align-content-center d-grid" style="display:grid !important; align-content:center; align-items:center; height:100% !important;">
<%--				<a style="margin:auto;" class="btn btn-default btn-color btn-w justify-content-center align-content-center" href="GetPermission.aspx?Deptid=<%#:Item.Email%>">Quyền</a>--%>
								<a style="margin:auto;" class="btn btn-default btn-color btn-w justify-content-center align-content-center" href="EditProfileAccount.aspx?MaKH=<%#:Item.MaKH%>&Email=<%#:Item.Email%>">Chỉnh sửa</a>

<%--				<a class="btn btn-default btn-color btn-w" href="ManagerOrder.aspx?Deptid=<%#:Item.Email %>">Đơn</a>--%>
<%--				<a style="margin:auto;" class="btn btn-default btn-color btn-w justify-content-center align-content-center" href="DeleteAccount.aspx?Deptid=<%#:Item.Email%>">Xóa</a>--%>
			</td>
        </ItemTemplate>
        <LayoutTemplate>
            <div class="d-flex justify-content-center align-content-center">
                <table class="table" id="groupPlaceholderContainer" runat="server">
                    <thead>
                        <tr>
                           <th scope="col" class="justify-content-center align-content-center">Ảnh</th>
<th scope="col" class="justify-content-center align-content-center">Họ Tên</th>
<th scope="col" class="justify-content-center align-content-center">Điện Thoại</th>
<%--<th scope="col" class="justify-content-center align-content-center">Giới Tính</th>--%>
<th scope="col" class="justify-content-center align-content-center">Địa Chỉ</th>
<th scope="col" class="justify-content-center align-content-center">Email</th>
<%--<th class="justify-content-center align-content-center">Mật Khẩu</th>--%>
									<th scope="col" class="justify-content-center align-content-center">Điểm</th>

<th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="groupPlaceholder"></tr>
                        <tr>
                            <td colspan="9" style="text-align:center; width:100%;" class="justify-content-center align-content-center">
                                <div class="d-flex justify-content-center align-content-center">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="5">
                                    <Fields>                                        
                                        <asp:NextPreviousPagerField ButtonType="Image" Visible="false" PreviousPageImageUrl='~/Content/icon/previous-page.png' ShowFirstPageButton="false" ShowLastPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="pagerImage pagerGap"/>

                                       <asp:NextPreviousPagerField  ButtonType="Link" ShowFirstPageButton="false" PreviousPageText="Trước" ShowLastPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="pagerImage pagerGap pageTable"/>
                                        <asp:NumericPagerField  ButtonType="Link" CurrentPageLabelCssClass="currentPage numericPagerField pageTable"/>
                                      <asp:NextPreviousPagerField  ButtonType="Link" ShowNextPageButton="true" NextPageText="Sau" ShowLastPageButton="false" ShowPreviousPageButton="false"  ButtonCssClass="pagerImage pagerGap pageTable"/>
                                        <asp:NextPreviousPagerField ButtonType="Image" Visible="false" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" NextPageImageUrl='~/Content/icon/next-page.png' ButtonCssClass="pagerImage pagerGap"/>

                                    
                                    </Fields>

                                </asp:DataPager>

                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div><style>         
                      .currentPage{
                          text-align:center;
                      }
                      .pageTable {
                          margin:0 20px;
                      }
                      .pagerGap{
                          
                      }
                  </style>
        </LayoutTemplate>
    </asp:ListView>
</div>
           
</div>

    </form>
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
</body>
</html>