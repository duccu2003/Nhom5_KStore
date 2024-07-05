<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TH03_WebBanHang.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .container {
            background-color: #000;
            border-radius: 8px;


        }
        /*.btnControl{
            display:none;
        }*/
        .profile-picture {
            width: 180px;
            height: 180px;
            border-radius: 50%;
            overflow: hidden;
            margin: 0 auto 20px;
        }

            .profile-picture .profile-image {
                width: 100%;
                height: 100%;
                object-fit: cover;
            }

            .profile-info {
                text-align: match-parent;
                        
            }

            .profile-info h5 {
                
                font-size: 18px;
                 color:white;
              
                 text-align:left;
            }

            .profile-info p {
                margin: 5px 0 0;
                padding: 0;
                font-size: 16px;
                 color:white;
            }

        #container-pr {
            padding: 0 0 5% 0;
            display: flex;
            flex-wrap: wrap;
                        
            
        }

        .centered-text {
            max-width: max-content; /* Thiết lập giá trị tối đa cho chiều rộng của các phần tử */
            text-align: left; /* Đảm bảo văn bản được căn trái bên trong phần tử */
            background-color: #0000000d;
            border-radius: 10px;
            padding: 5px 10px;
            margin-bottom: 1.5rem;
            color:white;
        }


        #item-pr {
            justify-content: center;
            text-align: center;
        }
        .search-container{
            border-radius: 10px;
        }
        .tenSP-ls-h3 {
            padding-bottom: 1.5rem;
            text-align: center;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #9b51e0;
            width: 100%;
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
        .pr-info{
          
            width:max-content; 
            height:max-content; 

            
        }
       .h5-pr{
           width:8rem;
       }
    </style>

    
    <div class="container-fluid py-5 div-same-prf" style="margin-top:10rem;">
        <div id="container-pr" class="justify-content-center align-items-center fade-out" style="background:linear-gradient(to bottom, #522A77,#0000); width:fit-content; margin:auto; border-radius:10px;">

<%--            <img loading="lazy" class="fade-out" src="Content/image-bg/KS.png" style="margin-top:8rem; position:absolute; z-index:0; height:auto; width:46rem; backdrop-filter:blur(20px);  filter: brightness(50%); border-radius:50px;border:1px solid #666;"/>--%>
           
            <div class="fade-out" id="item-pr" style="z-index:1;">
                <div  class="pr-info" style=" border-top-right-radius:0;border-bottom-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;  padding-left:10px; padding:1.18rem;"> <div class="profile-picture" style="position: relative; ">
                    
                    <!-- FileUploadProfilePic -->
                    <asp:FileUpload ID="FileUploadProfilePic" runat="server" Style="position: absolute; width: 5rem; margin: 0 3rem; height: 11rem; opacity: 0; z-index: 4;" />
                    <!-- ImageButton -->
                    <asp:ImageButton ID="ProfileImage" runat="server" CssClass="profile-image justify-content-center align-content-center" OnClick="btnUpload_Click" AlternateText="Profile Picture" Style="position: relative; z-index: 0; object-fit:cover; text-align:center;" />
                </div></div>
               
                <asp:Label ID="lbDiem" runat="server" style="font-weight:bolder; font-size:large;"></asp:Label>
               

                             
            </div>

            <style>
                /* Khi di chuột vào ảnh */
                /*.profile-picture:hover {
                    filter: brightness(50%);*/ /* Độ sáng tăng lên */
                    /*transition: filter 0.3s ease;*/ /* Hiệu ứng mượt */
                /*}*/

                #camerai {
                    display: none;
                }
                /* Hiển thị biểu tượng máy ảnh khi di chuột vào */
                .profile-picture:hover #camerai {
                    display: block;
                }
                .long-text{
                    width:20rem;
                    overflow-x:auto hidden;
                }
                .table{
                    background:#0000;
                    border:none;
                }
                .table *{
                    border:none;
                }
            </style>
                            <style>
                    @media only screen and  (min-width: 768px) {
                        .icon-container {
                            display: grid;
                            right:-10%; 
                            top:-1rem;
                            position:fixed;
                        }
                        .icon-link:hover {
    
                            transform:translate(10px,-10px);
                            box-shadow:0px 10px 50px #636363;
                        }
                        .p-icon-link{
                            left:3rem;
                            bottom:-15px;
                        }
                        
                    
                    }
                    @media only screen and  (max-width: 768px) {
                        .icon-container {
                            display: flex;
                            
                            z-index:1000;
                            position:fixed;
                            bottom:2%;
                            background:#522A77;
                            padding:0 10px;
                            border-radius:20px;

                            
                           
                        }
                          .p-icon-link{
                              left:0;
                              bottom:-5rem;
                              
                          }
                        .icon-link:hover {
    
                            transform:translate(0,-10px);
                            box-shadow:0px 10px 50px #636363;
                        }
                        .btn-sign-out{
                            margin-top:2rem;
                        }
                        .div-same-prf{
                           
                            
                        }

                    }
                    
                    .icon-container {
   
    justify-content: center; /* Center the icons horizontally */
    align-items: center; /* Center the icons vertically */
    gap: 1rem; /* Add some space between the icons */
    margin-top:1rem;
    
}

.icon-link {
    color: #000; /* Set the color of the icons */
    text-decoration: none; /* Remove the underline from the links */
    background: linear-gradient(to right, #522A77, #2a2e77) !important;
    padding:15px;
    border-radius:50%;
    transition:0.5s;

}



.icon-link  {
    display:flex;
    width:45px;
    height:45px;
    
}
.p-icon-link {
    display:none;  
    position:absolute;   
    background: linear-gradient(to right, #522A77, #2a2e77) !important;   
     transition:0.5s;

}
.icon-link:hover .p-icon-link {
    display:block;
    box-shadow:0px 10px 50px #636363;
    padding:10px;
    width:max-content;
     border-radius:20px;
}
.icon-link:hover {
    
    
}
.icon-link i {
    margin:auto;
    text-align:center;
    justify-content:center;
    align-content:center;
    align-items:center;
    justify-items:center;
    position:center;

}
.icon-link p {

}
</style>
 <style>
     #menulink,
     .btn-sign-out {
         display: inline-block;
         width: 8rem;
         height: 3rem;
         text-align: center;
         line-height: 3rem;
         vertical-align: middle;
         background-color: #9b51e0;
         outline: none;
         border: 1px solid transparent; /* Không có đường viền */
         border-radius: 10px;
         z-index:2;
         transition: background-color 0.8s ease, color 0.8s ease; /* Hiệu ứng chuyển động mượt */
     }

         #menulink h6 {
             margin: 0;
             padding: 1rem 0;
             width: 6rem;
             height: 3rem;
             border-radius: 10px;
                             transition: background-color 0.8s ease, color 0.8s ease; /* Hiệu ứng chuyển động mượt */

         }

         .btn-sign-out,
         #menulink h6 {
             font-weight: bold;
         }

             .btn-sign-out:hover,
             #menulink:hover h6 {
                 color: #fff;
                 background-color: #8b8ba9;
             }

             
 </style>
            <asp:ListView ID="ListViewAccounts" runat="server">
                <ItemTemplate>
                          <div class="icon-container">
    <a title="Chỉnh sửa thông tin" href="EditAccount.aspx?MaKH=<%# Eval("MaKH") %>&Email=<%# Eval("Email") %>" class="icon-link">
        <p class="p-icon-link">Chỉnh sửa thông tin</p><i class="fas fa-edit"></i>
    </a>
    <a title="Sản phẩm đã thích" href="item?mylike=<%# Eval("Email") %>" class="icon-link">
        <p class="p-icon-link">Sản phẩm đã yêu thích</p><i class="fas fa-heart"></i>
    </a>
    <a title="Sản phẩm đã đánh giá" href="item?myrating=<%# Eval("Email") %>" class="icon-link">
        <p class="p-icon-link">Sản phẩm đã đánh giá</p><i class="fas fa-star"></i>
    </a>
    <a title="Đơn hàng" href="AccountOrder.aspx?Deptid=<%# Eval("Email") %>" class="icon-link">
        <p class="p-icon-link">Đơn hàng của tôi</p>
        <i class="fa-solid fa-boxes-packing"></i>
    </a>

    <asp:LinkButton ID="btnSignOut" runat="server" title="Đăng xuất" OnClick="btnSignOut_Click" CssClass="icon-link"><p class="p-icon-link">Đăng xuất tài khoản</p><i class="fa-solid fa-right-from-bracket"></i></asp:LinkButton>
    
<%--    <asp:LinkButton ID="btnControl"  runat="server" title="Quản trị" OnClick="btnControl_Click" CssClass="icon-link" Visible="false"><i class="fa-solid fa-user-tie"></i></asp:LinkButton>--%>

    <button id="btnControl" runat="server"
     onserverclick="btnControl_Click"
    class="icon-link btnControl" style="border:none;">
        <p class="p-icon-link">Quản lý KStore</p>
        <i class="fa-solid fa-user-tie"></i>
    </button>
    </div>
                    <div class="pr-info fade-out" style="z-index:1; border-top-right-radius:20px;border-bottom-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;             width:max-content; height:max-content; 
  padding:0 10px; margin-top:1rem;"><div class="profile-info centered-text">
    
      <table class="table">
  <tr>
    <th>Họ tên:</th>
    <td><%# Eval("HoTen") %></td>
  </tr>
  <tr>
    <th>Email:</th>
    <td><asp:Label ID="EmailAddress" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
  </tr>
  <tr>
    <th>Giới tính:</th>
    <td><%# Eval("GioiTinh") %></td>
  </tr>
  <tr>
    <th>Địa chỉ:</th>
    <td><%# Eval("DiaChi") %></td>
  </tr>
  <tr>
    <th>Số điện thoại:</th>
    <td><%# Eval("DienThoai") %></td>
  </tr>
</table>

    </div>

 </div>
                    

                  
     
                </ItemTemplate>
            </asp:ListView>
        </div>
        
        <%--<div class="justify-content-center align-items-center d-flex fade-in" style="gap: 3rem; z-index:1;">--%>
           
<%--        <asp:Button ID="btnAccOrder" runat="server" Text="Đơn hàng" OnClick="btnAccOrder_Click" CssClass="btn-sign-out" Visible="true"/>--%>

           
<%--             <asp:Button ID="btnControl" runat="server" Text="Quản trị" OnClick="btnControl_Click" CssClass="btn-sign-out" Visible="false"/>--%>

            <%--<asp:Button ID="btnSignOut" runat="server" Text="Đăng xuất" OnClick="btnSignOut_Click" CssClass="btn-sign-out" />--%>
        <%--</div>--%>

       

    </div>
                    
                                  
              
</asp:Content>
