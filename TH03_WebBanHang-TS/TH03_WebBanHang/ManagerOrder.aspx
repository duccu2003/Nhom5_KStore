<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerOrder.aspx.cs" Inherits="TH03_WebBanHang.ManagerOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous">
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
            color #000;                      
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
         .btn-default:hover{
     color:#FFF !important;
     background:#000 !important;
 }
       /* table th, table td {
            border: 1px solid #242426;
        }*/
        table th, table td {
           /*border-bottom:1px solid #242426;*/
           /*border:1px solid #242426;*/
            box-shadow:0 1px 2px #242426;
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
</head>
<body style="overflow-x:hidden;">    
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
    <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />

    <form id="form1" runat="server" class="form-container container justify-content-center align-items-center" style="padding:20px 0;">
<<<<<<< HEAD
<div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
     <a title="Thoát" class="dropdown-item" href="Account.aspx" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
     
</div>
=======
                          <a class="dropdown-item" href="Account.aspx" style="margin-left:20px;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center; position:fixed; background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>

>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
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

               <%--<div title="Tìm kiếm" class="justify-content-center align-content-center search-container container mt-2" style="border: 1px solid #242426; width:14rem;  font-size:18px; height:40px;">
    
                    
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
   
   
    </div>
        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.DonHang" SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" class="text-center ListView1">
        <EmptyDataTemplate>
             <table  style="text-align:center;margin:auto; border:none">
             <tr style="border:none">
                 <td style="border:none"><%--No data was returned.--%> <h4>Chưa có đơn hàng.</h4></td>
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
                       <%--						<td><%#:TH03_WebBanHang.Pay.kh%></td>--%>
           <td class="justify-content-center align-content-center"><%#:Item.MaDH%></td>
           <td class="justify-content-center align-content-center"><%#:Item.HoTenNN%></td>
<%--                       <td class="justify-content-center align-content-center"><%#:Item.DiaChiNN%></td>--%>

           <td class="justify-content-center align-content-center"><%#:Item.ChiNhanh.TenCN%></td>

           <td class="justify-content-center align-content-center" style="width:8rem"><%#:Item.Ngay%></td>
           <td class="justify-content-center align-content-center"><%#:Item.ChiTietDonHangs.Sum(s=>s.SoLuong)%></td>
          <%-- <td>
<asp:Repeater ID="Repeater1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetDeparments2">
                   <HeaderTemplate>
                       <table class="order-item-table">
                           <thead>
                               <tr>
                                   <th class="son-table">Tên Sản Phẩm</th>
                                   <th class="son-table" style=" text-align:center;">Số Lượng</th>
                                   <th class="son-table" style=" text-align:center;">Giá</th>
                                   <th class="son-table" style=" text-align:center;">Thành Tiền</th>
                               </tr>
                           </thead>
                           <tbody >
                   </HeaderTemplate>
                   <ItemTemplate>
                       <tr>
                           <td class="son-table" style="text-align:left;"><%#:Item.TenSP %></td>
                           <td class="son-table"><%#:Item.SoLuong%></td>
                           <td class="son-table" style="text-align:center;"><%# string.Format("{0:N0}", Item.Gia) %>đ</td>
                           <td class="son-table" style="text-align:center;"><%# string.Format("{0:N0}", Item.ThanhTien) %>đ</td>
                           <td class="son-table"><a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?MaDH=<%#:Item.MaDH%>&SP=<%#:Item.MaSP%>">Chi tiết</a></td>

                       </tr>
                   </ItemTemplate>
                   <FooterTemplate>
                               </tbody>
                           </table>
                   </FooterTemplate>
               </asp:Repeater>                </td>--%>
           <td class="justify-content-center align-content-center">
               <%# string.Format("{0:N0}", Item.ChiTietDonHangs.Sum(p=>p.ThanhTien)) %>đ
           </td>
           
            <td class="justify-content-center align-content-center">
                    <%# Item.PhuongThuc=="COD"?"<p style=' background:linear-gradient(to right, #14452F , #009e59); padding:5px 10px; color:#FFF; border-radius:20px; width:max-content; margin:auto; text-align:center;'>"+ Item.PhuongThuc+"</p>": Item.PhuongThuc=="Momo"?"<p style='background:linear-gradient(to right, #D82D8B , #ff0000); padding:5px 10px; color:#FFF; border-radius:20px; width:max-content; margin:auto; text-align:center;'>"+ Item.PhuongThuc + "</p>":"<p style=' background:linear-gradient(to right, #6c38ef , #008abaff); padding:5px 10px; color:#FFF; border-radius:20px; width:max-content; margin:auto; text-align:center;'>"+ Item.PhuongThuc + "</p>"%>


            </td>
                       <td class="justify-content-center align-content-center d-grid" style="display:grid !important; height:100% !important; text-align:center; justify-content:center; justify-items:center; align-content:center; align-items:center;">

                   <%#  Item.ChiTietDonHangs.Any(s => s.GiaoDich == true)? "<p style='border-radius:5px; color:#fff; background:forestgreen; padding:5px 10px;'>Đã thanh toán</p>":"<p style='border-radius:5px; color:#fff; background:orangered; padding:5px 10px;'>Đợi thanh toán</p>" %>
                    <a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?MaDH=<%#:Item.MaDH%>">Chi tiết</a>
<%--               <a class="btn btn-default btn-color btn-w" href="DeleteOrder.aspx?MaDH=<%#:Item.MaDH%>">Xóa</a>--%>

			<%--<a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaDH%>">Chỉnh sửa</a>
			<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaDH%>">Xóa</a>--%>
		</td>
        </ItemTemplate>
        <LayoutTemplate>
            <div class="d-flex justify-content-center align-content-center">
                <table class="table" id="groupPlaceholderContainer" runat="server">
                    <thead>
                        <tr>
                           <th scope="col" class="justify-content-center align-content-center">Mã Đơn</th>
<th scope="col" class="justify-content-center align-content-center">Khách Hàng</th>
<%--<th scope="col" class="justify-content-center align-content-center">Địa chỉ</th>--%>
<th scope="col" class="justify-content-center align-content-center">Chi Nhánh</th>
<th scope="col" class="justify-content-center align-content-center">Thời Gian</th>
<th scope="col" class="justify-content-center align-content-center">Số Lượng</th>
<th scope="col" class="justify-content-center align-content-center">Tổng Tiền</th>
                            <th scope="col" class="justify-content-center align-content-center">Phương Thức</th>

                      <th scope="col" class="justify-content-center align-content-center" style="width:max-content;"></th>
                      

                        </tr>
                    </thead>
                    <tbody>
                        <tr id="groupPlaceholder"></tr>
                        <tr>
                            <td colspan="8" style="text-align:center; width:100%;" class="justify-content-center align-content-center">
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
</body>
</html>
