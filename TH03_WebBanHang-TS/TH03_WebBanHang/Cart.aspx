<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TH03_WebBanHang.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                                    <style>
                                    
                                    .btn-p-m{
                                        width:1.8rem;
                                        padding:0;
                                        background-color:#fff;
                                        border:none;
                                        border-radius:50%;
                                         margin:0 0.4rem;
                                         height:1.8rem;
                                         
                                        
                                    }
                                    .btn-p-m:hover{
  
                                        border:1px solid #000;
                                                                                background-color:#000;

    
}                                    .btn-p-m:active{
  
                                        border:1px solid #000;
                                        background-color:#000;
    
}
                                </style>
    <!-- Product section-->
    <section class="py-5" style="margin-top:3rem;">
        <div class="container px-4 px-lg-5 my-5">
            <div class="row gx-4 gx-lg-5 justify-content-center" style="margin-top:5rem; gap:2rem;" >
               <%-- <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetCart">


                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td style="text-align:center;"><%--No data was returned.--%>
                                   <%-- Giỏ hàng rỗng.--%>

                               <%-- </td>
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
                        <tr class="cart-list">
                            <td style="text-align:center;" class="justify-content-center align-content-center"> <a class="a-hadItems" href="item.aspx?sp=<%#:Item.MaSP%>"> <%#:Item.TenSP%></a></td>
                            <td style="text-align:center;" class="justify-content-center align-content-center">
                               <a class="a-hadItems"  href="item.aspx?sp=<%#:Item.MaSP%>">  <img  style="width: 150px; border-radius:20px;" class="card-img-top h-100 fade-out" src="<%#:Item.DuongDan%>" alt="..." /></a></td>
                            <td style="text-align:center;" class=" justify-content-center align-content-center">
                                           <div class="d-flex justify-content-center align-content-center">        
                                <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%#: Item.MaSP %>' OnClick="btnDelete_Click" CssClass="btn btn-danger btn-p-m" ImageUrl="~/Content/icon/g-minus.png" />
                               <p class="justify-content-center align-content-center" style="background:#00000080; border-radius:10px; width:max-content; padding:0 15px; text-align:center; height:2rem;"><%#:Item.SoLuong%></p>
                                
                                <asp:ImageButton ID="btnChange" runat="server" CommandArgument='<%#: Item.MaSP %>' OnClick="btnChange_Click" CssClass="btn btn-warning btn-p-m" ImageUrl="~/Content/icon/g-plus.png" />
                            </div>  
                            </td>
                            <td style="text-align:center;" class="justify-content-center align-content-center"><%# string.Format("{0:N0}", Item.Gia) %></td>
                            <td style="text-align:center;" class="justify-content-center align-content-center"><%# string.Format("{0:N0}", Item.ThanhTien) %></td>
                            <!-- Add buttons for deleting and changing items -->
                           <%-- <td style="text-align:center;" class="justify-content-center align-content-center" style=" width:max-content; text-align:center;">
                                
                                
                            </td>--%>
                       <%-- </tr>
                    </ItemTemplate>

                    <LayoutTemplate>
                        <table class="table table-bordered fade-out" id="groupPlaceholderContainer" runat="server" style="width: 100%">
                            <thead>
                                <tr class="cart-list">

                                    <th style="text-align:center;" class="justify-content-center align-content-center">Tên</th>
                                    <th style="text-align:center;" class="justify-content-center align-content-center">Ảnh</th>
                                    <th style="text-align:center; width:max-content;" class="justify-content-center align-content-center">Số Lượng</th>
                                    <th style="text-align:center;" class="justify-content-center align-content-center">Đơn Giá</th>
                                    <th style="text-align:center;" class="justify-content-center align-content-center">Thành Tiền</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="groupPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                </asp:ListView>--%>
                <style>
                    .divLSSPCart{
                        
                    }
                </style>

                <div class="divLSSPCart" style="width:50%; background:linear-gradient(to right, #522A77, #2a2e77); padding-bottom:1rem;  border-radius:10px;"><div style="overflow-y:auto;max-height:84vh; ">
                 <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.ChiTietDonHang" SelectMethod="GetCart">

                     <EmptyDataTemplate>
                        <h2 style="text-align:center; margin-top:2rem;" class="justify-content-center align-content-center">
                         Giỏ hàng rỗng</h2>
                     </EmptyDataTemplate>
     <ItemTemplate>
         <%--<div class="cart-list d-flex" style="gap:1rem; background:linear-gradient(to right, #522A77, #2a2e77);">
              <div style="text-align:center;" class="justify-content-center align-content-center">
    <a class="a-hadItems"  href="item.aspx?sp=<%#:Item.MaSP%>">  <img  style="width: 150px;  border-radius:20px;" class="card-img-top h-100 fade-out" src="<%#:Item.DuongDan%>" alt="..." /></a></div>
             <div class="d-grid">
             <p style="text-align:left; font-size:24px;" class="justify-content-center align-content-center"> <a class="a-hadItems" href="item.aspx?sp=<%#:Item.MaSP%>"> <%#:Item.TenSP%></a></p>           
             <p style="text-align:left;" class="justify-content-center align-content-center">Giá: <%# string.Format("{0:N0}", Item.Gia) %></p>
             <p style="text-align:left;" class="justify-content-center align-content-center">Thành tiền: <%# string.Format("{0:N0}", Item.ThanhTien) %></p>
             <!-- Add buttons for deleting and changing items -->
            <%-- <td style="text-align:center;" class="justify-content-center align-content-center" style=" width:max-content; text-align:center;">
                 
                 
             </td>--%>

                <%-- <div style="text-align:left;" class="">
               <div class="d-flex ">        
    <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%#: Item.MaSP %>' OnClick="btnDelete_Click" CssClass="btn btn-danger btn-p-m" ImageUrl="~/Content/icon/g-minus.png" />
   <p class="justify-content-center align-content-center" style="background:#00000080; border-radius:10px; width:max-content; padding:0 15px; text-align:center; height:2rem;"><%#:Item.SoLuong%></p>
    
    <asp:ImageButton ID="btnChange" runat="server" CommandArgument='<%#: Item.MaSP %>' OnClick="btnChange_Click" CssClass="btn btn-warning btn-p-m" ImageUrl="~/Content/icon/g-plus.png" />
</div>  
</div>
         </div></div>--%>
                 <div class="cart-list d-flex" style="gap:2rem; padding:2rem;border-bottom:1px solid #ffffff80;">    
             <script>

                 $(document).ready(function () {
                     $('[data-toggle="popoverItemsLS"]').popover({
                         trigger: 'hover',
                         placement: 'left',
                         html: true,
                         content: function () {
                             return $(this).data('content');
                         }

                     });
                 });

             </script>

            <a href="Item.aspx?sp=<%# Eval("MaSP") %>"><img title="<%# Eval("TenSP") %>"  src='<%# Eval("DuongDan") %>' alt='<%# Eval("TenSP") %>' style="width:150px;height:150px; border-radius:10px;" /></a>
            <div class="d-grid" style=""> 
                 <a href="Item.aspx?sp=<%# Eval("MaSP") %>"><h5 style="color:#fff;"><%# Eval("TenSP") %></h5></a>
            <%--<p>Số lượng: <%# Eval("SoLuong") %></p>--%>

                <%--  <p style="color:#fff;">Pop: <%# Eval("TenPob") %></p>  --%>
             <p style="color:#fff;"><%#:string.IsNullOrEmpty(Eval("TenPob") as string)?"":"Pob: "+ Eval("TenPob") %></p>

                
            <p style="color:#fff;">Giá:  <%# string.Format("{0:N0}",Eval("Gia")) %>đ</p>
            <p style="color:#fff;">Thành tiền: <%# string.Format("{0:N0}", Eval("ThanhTien")) %>đ</p>
                                                <style>
                                    p{
                                        margin:0;
                                    }
                                    .btn-p-m{
                                        width:1.5rem;
                                        padding:0;
                                        background-color:#fff;
                                        border:none;
                                        border-radius:50%;
                                         margin:0 0.4rem;
                                         height:1.5rem;
                                        
                                    }
                                    .btn-p-m:hover{
  
                                        border:1px solid #000;
                                                                                background-color:#000;

    
}                                    .btn-p-m:active{
  
                                        border:1px solid #000;
                                        background-color:#000;
    
}

                                     .btnXoaSP{
                                         transition:0.5s;
                                     }
                                     .btnXoaSP:hover{
                                        transform:scale(1.1);
                                        box-shadow:0 0 50px #636363;
                                    }
                                </style>
                
                                               <div class="d-flex" style="margin:5px 0;">         
                     <%--<p style="color:#fff;">Số lượng:
<div style="position:relative; margin-left:4rem;" class="d-flex">--%>
<asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btnDelete_Click" CssClass="btn btn-danger btn-p-m btnTG" ImageUrl="~/Content/icon/g-minus.png" />
     <p style="color:#fff; background:linear-gradient(to left, #11B588,#06BCCF); width:3rem; height:25px; border-radius:10px; text-align:center;"><%# Eval("SoLuong") %></p>
<asp:ImageButton ID="btnChange" runat="server" CommandArgument='<%# Eval("MaSP")+ ";" +Eval("TenPob") %>' OnClick="btnChange_Click" CssClass="btn btn-warning btn-p-m btnTG" ImageUrl="~/Content/icon/g-plus.png" />


<%--</div></p>--%>
                    
</div>   
                <style>
    .btnTG{
        transition:0.5s;
    }
    .btnTG:hover{
        transform:scale(1.2);
        box-shadow:0px 0px 50px #636363;
    }
</style>                              
            </div>
        </div>
     </ItemTemplate>

   
 </asp:ListView></div></div>

                <div style="display:grid; position:relative;   background:#fff; text-align:center; gap:5px;  padding: 10px; width:max-content; height:max-content; border-radius:10px;  " class="justify-content-center fade-out">
                <div style="padding:5px 1rem;  font-size:x-large" class="justify-content-center ">
                    <style>                        #tongtien {
                            border-top:none;
                            border-left:none;
                            border-right:none;
                            border-bottom:1px solid #000;
                           
                        }
                    </style>
                    <div id="tongtien" style=""> <b style=" color:#000;">Tổng tiền:</b>                   <asp:Label ID="lbTongThanhToan" runat="server" Text="0" Style="color:#000;"></asp:Label>

                    </div>
                </div>
                    <style>
                        .btnDathang{
                            transition:0.5s;
                        }
                         .btnDathang:hover{
                             transform:scaleX(1.05) /*translate(0,10px)*/ ;
                             box-shadow:0 0 50px #636363;
                             border-top-right-radius:0px;
                             border-top-left-radius:0px;
                         }
                    </style>
                <div>
                    <asp:Button ID="btnDathang" CssClass="justify-content-center  btnDathang" runat="server" Text="TIẾN HÀNH ĐẶT HÀNG" OnClick="btnDathang_Click" style="width:100%; background:linear-gradient(to left, #522A77, #2a2e77); border-radius:10px;  padding:5px 1rem; outline-color:#fff0; border:1px solid #303030a0;"/>
                   <%-- <style>                        #btnDathang {
                            padding:10px;
                            border: 1px solid #ccc;
                            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
                            b
                        }
                        #btnDathang {
            background-color:#9b51e0;
        }
        #btnDathang:hover {
            background-color:#a49ccb;
            color:#636161;
        }
                    </style>--%>

                </div>
            </div></div>
        </div>
    </section>

</asp:Content>
