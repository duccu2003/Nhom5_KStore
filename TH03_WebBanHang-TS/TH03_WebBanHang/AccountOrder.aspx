<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="AccountOrder.aspx.cs" Inherits="TH03_WebBanHang.AccountOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%>
        <p class="tenSP-ls-p">Đơn Hàng</p>
    </h2>
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
            color: #fff;                      
        }
        *{
            color: #fff;font-family:Roboto;
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
           border:1px solid #60536D;
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
            background:#FFF;
            border:1px solid #242426;
            border-radius:5px;
            align-content:center;
            align-items:center;
            font-size:14px;
            font-weight:normal;
            
        }
    </style>

                                <form id="form1" class="form-container container justify-content-center align-items-center" style="padding:20px 0;">

        <div class="form-container container" style="margin-top:10rem !important;">
   
    <div style="width:80%; padding:20px; background: linear-gradient(to right, #7a29c4, #3b0d677b);  margin:auto;           border-radius: 10px;">
   <div class="container" style="text-align:left; padding-left:2px; margin-bottom:1rem;">
       
               <div title="Tìm kiếm" class="justify-content-center align-content-center search-container container mt-2" style="border: 1px solid #7a29c4 !important; width:15rem;  font-size:18px; height:40px;">
    
                    
                            <asp:TextBox ID="searchinputA" placeholder="Tìm kiếm" type="search" Text="" runat="server"  Style="border: 1px solid #0000 !important; touch-action: none; border-bottom-left-radius:5px; border-top-left-radius: 5px;" class="search-textbox searchinput"></asp:TextBox>
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
             <asp:ImageButton runat="server" ID="btnSearch" CssClass="searchbutton justify-content-center align-content-center" OnClick="SearchButton_Click" ImageUrl="Content/icon/search.png"/>
                
                   <style>
                     #searchinputA:focus {
    border: 1px solid #0000 !important;
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
    background: #000;
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
    background: #000;
    
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
                    .table{
                        background:#0000;
                    }
                </style>
    


    
        </div>
   
   
    </div>
        <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.DonHang" SelectMethod="GetDeparments" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" class="text-center ListView1">
        <EmptyDataTemplate>
             <table style="text-align:center; border:none; margin:auto; font-weight:bold;">
                 <tr style=" border:none;">
                     <td style=" border:none;"><h3>Bạn chưa có đơn hàng.</h3></td>
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
         <%--  <td><%#:Item.KH%></td>--%>

        <%--   <td><%#:Item.MaCN%></td>--%>
             <td class="justify-content-center align-content-center"><%#:Item.HoTenNN%></td>
             <td class="justify-content-center align-content-center td-longer"><%#:Item.DiaChiNN%></td>
           <td class="td-longer justify-content-center align-content-center"><%#:Item.Ngay%></td>
                       <td class="justify-content-center align-content-center"><%#:Item.ChiTietDonHangs.Sum(s=>s.SoLuong)%></td>

         <%--  <td>--%>
<%--<asp:Repeater ID="Repeater1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetDeparments2">
                   <HeaderTemplate>
                       <table class="order-item-table" style="width:100%;">
                           <thead>
                               <tr>
                                   <th class="son-table" style="width:16rem">Tên Sản Phẩm</th>
                                   <th class="son-table">Số Lượng</th>
                                   <th class="son-table">Giá</th>
                                   <th  style="width:16rem;" class="son-table">Thành Tiền</th>
                               </tr>
                           </thead>
                           <tbody >
                   </HeaderTemplate>
                   <ItemTemplate>
                       <tr>
                           <td class="son-table" style="text-align:left;"><%#:Item.TenSP %></td>
                           <td class="son-table"><%#:Item.SoLuong%></td>
                           <td class="son-table" style="text-align:center;"><%# string.Format("{0:N0}", Item.Gia) %>đ</td>
                           <td class="son-table" style="text-align:center; "><%# string.Format("{0:N0}", Item.ThanhTien) %>đ</td>
                           <td class="son-table"><a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?MaDH=<%#:Item.MaDH%>&SP=<%#:Item.MaSP%>">Chi tiết</a></td>
                                      <%-- <td>
								<a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?Order=<%#:Item.MaDH%>&SP=<%#:Item.MaSP%>">Chi tiết</a>

                <%--<a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaDH%>">Chỉnh sửa</a>--%>
<%--                <a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaDH%>">Xóa</a>--%>
     <%--       </td>--%>
                       <%--</tr>
                   </ItemTemplate>
                   <FooterTemplate>
                               </tbody>
                           </table>
                   </FooterTemplate>
               </asp:Repeater>       --%>   <%--   </td>--%>
           <td class="justify-content-center align-content-center">
               <%# string.Format("{0:N0}", Item.ChiTietDonHangs.Sum(p=>p.ThanhTien)) %>đ
           </td>
                 <td class="justify-content-center align-content-center d-grid" style="display:grid !important; height:100% !important; row-gap:1rem;">
                       <a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?MaDH=<%#:Item.MaDH%>">Chi tiết</a>

<%--       <a class="btn btn-default btn-color btn-w" href="DeleteOrder.aspx?MaDH=<%#:Item.MaDH%>">Xóa</a>--%>

	<%--<a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaDH%>">Chỉnh sửa</a>
	<a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaDH%>">Xóa</a>--%>
</td>
            <%--						<td><%#:TH03_WebBanHang.Pay.kh%></td>--%>
          <%--  <td><%#:Item.MaCTDH%></td>


            <td class="td-longer"><%#:Item.Ngay%></td>
            <td class="td-longer" style="text-align:left;"> <a class="a-hadItems"  href="item.aspx?sp=<%#:Item.MaSP%>"> <%#:Item.TenSP%></a></td>
            <td style="width:max-content;"><%#:Item.SoLuong%></td>
            <td><%# string.Format("{0:N0}", Item.Gia) %>đ</td>
            <td><%# string.Format("{0:N0}", Item.ThanhTien) %>đ</td>
--%>


           <%-- <td>
								<a class="btn btn-default btn-color btn-w" href="DetailOrder.aspx?Order=<%#:Item.MaDH%>&SP=<%#:Item.MaSP%>">Chi tiết</a>

                <%--<a class="btn btn-default btn-color btn-w" href="EditProduct.aspx?Deptid=<%#:Item.MaDH%>">Chỉnh sửa</a>--%>
<%--                <a class="btn btn-default btn-color btn-w" href="DeleteProduct.aspx?Deptid=<%#:Item.MaDH%>">Xóa</a>--%>
          <%--  </td>--%>
        </ItemTemplate>
        <LayoutTemplate>
            <div class="d-flex justify-content-center align-content-center">
                <table class="table" id="groupPlaceholderContainer" runat="server">
                    <thead>
                        <tr>
                                                   <th class="justify-content-center align-content-center">Mã Đơn</th>
                         <th class="justify-content-center align-content-center">Khách hàng</th>
 <th class="justify-content-center align-content-center">Địa chỉ</th>
 <th class="justify-content-center align-content-center">Thời Gian</th>

<%-- <th class="justify-content-center align-content-center">Chi Tiết</th>--%>
<th class="justify-content-center align-content-center">Số Sản Phẩm</th>

 <th class="justify-content-center align-content-center">Tổng Tiền</th>
                      <%--  <th>Mã Đơn</th>

                        <th>Thời Gian</th>
                        <th>Chi Tiết</th>--%>
                        <%--<th>Số Lượng</th>
                        <th>Giá</th>
                        <th>Thành Tiền</th>--%>


                        <%--						<th>Mã Khách Hàng</th>--%>

                      <%--  <th></th>--%>
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

</asp:Content>
