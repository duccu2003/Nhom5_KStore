<%@ Page Title="KStore" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="TH03_WebBanHang.Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.css" />
    <style>
        .btn-send-rating{
            color:#FFFF !important;
            transition:0.5s all;
        }
        .btn-send-rating:hover{
            box-shadow:0 0 20px #636363;
            transform:scale(1.05);
        }
        .btn-item {
            background-color: #fff !important;
        }
        .btn-at-sp-hover:hover{
            color:#FFFF !important;
            background:#000 !important;
             box-shadow:0 0 50px #636363;
        }
        .btn-at-sp-hover{
            transition:0.5s;
        
        }
        .alert{
            top:0;
            position:absolute !important;
            width:100%;
            z-index:9999 !important;
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


        .branchList *{
            color:#fff !important;
        }
        .notification {
            display: none;
            position: fixed;
            top: 15%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: #212529;
            padding: 0 10px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
            text-align: center;
            justify-content: center;
            align-items: center;
            gap: 1rem;
            width: max-content;
            z-index: 9999;
            /*flex-direction: column;*/
        }
        .notificationRating {
            display: none;
            position: fixed;
            top: 15%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: #1bad3c;
            padding: 0 10px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
            text-align: center;
            justify-content: center;
            align-items: center;
            gap: 1rem;
            width: max-content;
            z-index: 9999;
            /*flex-direction: column;*/
        }
        .notification .imgNotification {
            width: 100px;
            height: auto;
        }
        .notification .lbNotification,.notificationRating .lbNotification{
            font-family: Roboto;
            padding-top: 1rem;
            font-size: 20px;
        }
        .comment-item{
            border-radius:10px;
            color:#000;
        }
        .btn-comment{
            border-radius:10px;
            color:#fff;
        }
        .btn-comment:hover{
            background: #464baa;
        }
        .star {
            font-size: 28px;
            color: #ccc; /* Màu sáng khi chưa chọn */
            cursor: pointer;
            transition:0.2s;
        }
                    

        .star.selected i{
            color: #ffc107; 
        }

        .zoom-hover {
        }

        .zoom-hover:hover {
        }
                               
        .lb-add-pr-cmt {
            width:max-content;
            color:#fff !important;
        
        }

         .widget-container {
        
             display:none;
             justify-content: center;
             gap: 20px;
             position:fixed;
             /*right:12%;*/
             top:27.5%;
             width:max-content;
             z-index:1000;
     
         }

         .widget-item {
             width: 40px;
             height: 40px;
             border-radius: 50%;
             background: linear-gradient(to right, #522A77, #2a2e77) ;
             display: flex;
             justify-content: center;
             align-items: center;
             text-decoration: none;
             color: #333;
   
            /* transition: background-color 0.3s ease;*/
            transition:0.5s;
         }

         .widget-item:hover {
             /*background-color: #522A77;*/
             transform: translate(0,-10px);
             box-shadow:0 10px 50px #636363;
         }

         .widget-link {
             display: flex;
             justify-content: center;
             align-items: center;
             width: 100%;
             height: 100%;
             text-decoration: none;
             color: inherit;
   
         }

         .widget-link i {
             font-size: 20px;
         }
         .custom-file-upload {
             display: none;
         }
         .custom-file-label {
            padding: .375rem .75rem;
            font-size: 0.8rem;
            line-height: 1.5;
            color: #495057;
            background-color: #ffffff00;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            cursor: pointer;
            height:max-content;
         }
         .custom-file-label{
            width:8rem;
         }
         .btn-comment,.custom-file-label{
             transition:0.5s;
             background: #fff;
             color:#000;   
         }
         .custom-file-label i{
             color:#000;
         }
         .btn-comment:hover,.custom-file-label:hover{
             box-shadow:0 10px 50px #636363;
         }
         .custom-file-label:hover{
              color:#fff;
              background:#522A77;
         }
         .custom-file-label:hover i{
              color:#fff;
         }
           
        #divNoteUploadRating{
            max-width:670px;
            font-size:10px;
        }
        #btnViewMore{
            transition:0.5s;
        }
                          
         .aVer, #verImg, #aTenVer,.aVer #verImg,.aVer #aTenVer{                                  
             transition:0.5s;
         }
        .aVer:hover #verImg{
            /*transform:translate(0, 20px) scale(1.1);*/
            box-shadow:0px 10px 50px  #636363;
            /*transform:scale(1.1);*/

        }
         .aVer:hover {
        
            background:#ffffff80 !important;
            border:1px solid #ffffff80 !important;
        
         }
          .aVer:hover #pTenVer{
             color:#000 !important;
         }

         .product-image {
             max-width: 100px;
             height: auto;
             cursor: pointer;
             border-radius: 10px;
         }
                
    
        .btn-p-m{
            width:31px;
            padding:0;
            background-color:#fff;
            border:none;
        
             margin:0 0.4rem;
             height:31px;
             transition:0.5s;
        
        }
        .btn-p-m:hover{
  
           background:#fff !important;
           transform:scale(1.1);
           box-shadow: 0 0 20px #636363;
    
         }                                    
        .btn-p-m:active{
  
        
            background:#fff !important;
    
        }
        .btn-mua:hover {
            background-color: #FBF4F1;
            color: #212529;
        }
        .btn-mua-ngay:hover {
             background-color: #FBF4F1;
             color: #212529;
        }
        .btn-gio:hover {
             background-color: #FBF4F1;
             color: #212529;
        }
        .btn-gio-card:hover {
            background-color: #FBF4F1;
            color: #212529;
        }
                       
        #ratingDiv{
            display:none;
            background: linear-gradient(to right, #522A77, #2a2e77) ;
            border-radius: 10px;
            z-index: 1001; 
            color:#000 !important;
        }
                   
              
        #ratingDiv th, #ratingDiv tr,  #ratingDiv td {
            border: none !important;
        }
        .star.hover i{
        color: #ffc107;
        }
        .star:hover{
    
        }
        .star.selected:hover i{
            color:#ffc107;
        }


        @media only screen and  (max-width: 768px) {
            .btn-at-sp{
                width:137.5px;
                font-size:small;
            }
            #btnViewMore{
                font-size:small;
            }
            .btn-p-m {
                width:27px;
            }
            #divSL{
                position:absolute;
                bottom:19.438rem;
                left:8.525rem;
                height:43px;
            }
            #divButtonMuaGioDG{
                margin-top:6.75rem;
            }
        }
                        
                           
*{
scroll-behavior: smooth;
}
.div-DG::-webkit-scrollbar-thumb {
border-radius: 30px;
}
.div-DG::-webkit-scrollbar-track {
border-radius: 10px;                             
background:#00000040;
}
.div-DG::-webkit-scrollbar {
}
                      
@media only screen and (max-width: 768px) {
#idRating{
width:468px;
}
#lbNoiDung,#anhNote{
width:100%;
}
#DGshow{

}
#listImageDetailt{
position:absolute;
bottom:1.75rem;
max-width:428.5px;
overflow:hidden;
flex-wrap:wrap;
gap:0.585rem !important;
padding:0;
margin:0;
}
#DGshow{
    max-height:100vh;  
    min-height:0;  
    padding:30px 15px  0px 15px;
    min-height:0vh;
}
                            #divVer{
                                margin:16rem 0 18rem 0 !important;
                            }
                           
                           /* .toggleRating{
                                left:4.65rem; top:24.35rem;
                            }*/
                            #navLSMenu{
    padding:0px 10px; 
}
                            .div-DG{
                                padding-right:10px;
                            }
                           
    .DG {
    max-height:80vh !important;   
    width:100%;
    
}
    .showRating{
        bottom:5.5rem; left:-15rem; border-top-right-radius:20px; border-top-left-radius:20px;font-size:20px;
    }
    .cmtProfile-Non-Login{
        display:flex;
    }
    #divDetailProduct{
     padding-right:0;
     padding-bottom:3rem;
}
     .div-bottom-product-content{
     display:flex;
    
    
     
 }
      .widget-container{
           right:2.25rem; 
      }
       #ratingDiv2{
     display:grid;
 }
       .comment-item{
    width:20rem;
}
       .div-Ver{
           
          /*width:50%;*/
       }
         #divSLandBtnShowRadting{
      margin-top:-10rem;
      margin-left:3rem;
      
  }

         .divSLandbtnDGShow{
    display:flex;
   margin-left:1rem;
   
    
}
         #divBtnShowDG{
             margin-top:-1rem;
             justify-content:center;
             align-content:center;
             margin-left:1rem;
         }
               .image-container, .video-container {
    width: 60px;
    
}

     #divUserComentShow{
     width:100%;
     
    
 }

}

                         @media only screen and  (max-height: 538px){

                             
                             
                             .widget-container{
                                 top:7.5rem;
                                right:1.5rem; 
                            }
                             
                             #divSL, #listImageDetailt, .showRating, .divSLandbtnDGShow{
                                 display:none !important;
                             }

                             
                         }
                                                @media only screen and  (min-width: 768px) {
                                                   

                                                     .btn-at-sp{
                                                         width:145.5px;
                                                     }

                                                    #divNoteContentText{
                                                        padding-left:11.5rem !important;
                                                    }
                                                    #idRating{
                                                        width:1223px;
                                                        
                                                    }
                                                    #lbNoiDung,
                                                    #anhNote{
                                                        width:585px;
                                                    }
                                                    #divButtonMuaGioDG{
                                                        margin-bottom:-8rem !important;
                                                        margin-top:8rem !important;
                                                        
                                                    }
                                                    #DGshow{
                                                        max-height:84vh;  min-height:0vh;  padding:30px 15px  5px 15px;
                                                    }
                                                    #divVer{
                                                        margin-top:8rem !important;
                                                    }
                                                    #divSL{
                                                        position:absolute;
                                                        top:27rem;
                                                        /*right:37.845rem;*/
                                                        right:27.30234rem;
                                                    }
                                                    /*.toggleRating{
                                                        left:31.5rem; top:12.55rem;
                                                    }*/
                                                    #navLSMenu{
                                                        padding:5px 10px; 
                                                    }
                                                    .DG{
                                                         width:100%;
                                                    }
   
    .showRating{
        top:10rem; left:-10rem;   border-top-left-radius:20px; border-top-right-radius:20px;height:max-content;font-size:24px;
    }
    .cmtProfile-Non-Login{
        display:flex;
    }
    #divDetailProduct{
         /*padding-bottom:12rem;*//* padding-right:1rem;*/
    }
    .div-bottom-product-content{
        display:flex;
    }
     .widget-container{
         right:1.5rem; 
     }
     #ratingDiv2{
         display:flex;
         gap:1rem;
     }
     .comment-item{
         width:40rem;
     }
     #divSLandBtnShowRadting{
        margin-top:0.5rem;
     }
     .divSLandbtnDGShow{
         display:grid;
         margin-left:0.35rem;
     }
      #divBtnShowDG{
     margin-top:2.5rem;
 }
      .image-container, .video-container {
    width: 80px; 
    
}
      #divUserComentShow{
          width:max-content;
      }
      .product-detail-Img{
          width:596px;
          height:596px;
      }


}
    select option {
        color: black;
    }

      #moveTop:hover{
           transform: translate(0,-10px);
 box-shadow:0 10px 50px #636363;
      }
 
      #lsItemRatingAll,#lsItemRating1,#lsItemRating2,#lsItemRating3,#lsItemRating4,#lsItemRating5{
           font-family:Verdana, Geneva, Tahoma, sans-serif;
           font-weight:bolder; color:#ffc107;
      }


          .img-with-hover {
              transition: transform 0.5s;
          border-radius: 1.8rem;
                                                                                                                                                       }

          .btn-mua:hover .img-with-hover {
              transform: scale(1.05);
                                                                                                                                                       }

          .btn-outline-dark {
              --bs-btn-active-bg: #9b51e0;
          --bs-btn-disabled-color: #9b51e0;
                                                                                                                                                       }
     
    .image-container, .video-container {
        height: max-content; /* Kích thước cố định cho container */
        overflow: hidden; /* Ẩn phần của hình ảnh và video không vừa với container */
                transition:0.5s;
                border-radius:10px;

    }
    .rating-image, .rating-video {
        width: 100%;
        height: 100%;
        object-fit: cover; /* Hoặc sử dụng 'contain' nếu muốn hình ảnh và video luôn hiển thị toàn bộ nội dung */
        border-radius:10px;
        transition:0.5s;

    }

    .image-container:hover, .video-container:hover {
         transform:scale(1.1);
         /*transform:translate(0,-10px);*/
        box-shadow:0 10px 50px #636363;
    }

    @media only screen and  (max-width: 600px) {
        .image-container, .video-container {
            width: 60px; /* Giảm kích thước cho các thiết bị nhỏ hơn */
        }
    }

     #idRating,#divDetailProduct{
         transition:0.5s;

     }

     .btn-bold{
         font-weight:bold;
     }


     #showFormButton,#btnHideDG{
         transition:0.5s;
         font-size:16px;

     }
      #showFormButton:hover,#btnHideDG:hover{
           transform:scale(1.1);
           box-shadow:0 0 50px #636363;
           color:#fff;
       }

    section {
        background:#000 !important;
        
    }

    .nav-item-inItem {
        width: max-content;
    }

    .img-close-ViewMore {
        width: 24px;
    }

    #additionalContent {
        border: 1px solid #ccc;
        padding: 20px;
        background: linear-gradient(to right, #522A77, #2a2e77);
        width: 60%; /* Adjust the width as needed */
        height: 600px;
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        margin: auto;
        border-radius: 10px;
        z-index: 1000;
    }

    .product-image-AnhNote {
        width: 100%;
        height: 100%;
        padding-bottom: 1rem;
    }

    #overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5); /* Black background with 50% opacity */
        z-index: 9999; /* Ensure it's above other content */
    }
    #divNoiDung{
        display:none;
    }

    #btnViewMore{display:none; }
    #btnViewMore:hover,#toggleRating:hover{
        color:#000;
        box-shadow:0 0 50px #636363;
       
    }

</style> 



    <div id="notification" class="notification">
        <img class="imgNotification"  loading="lazy"  src="Content/icon/p-Success.gif" alt="">
        <p class="lbNotification">Thêm thành công!</p>
    </div>
    
    
    

    <!-- Product section-->
    <section class="pt-5 mt-5" style="margin-top:8rem !important;" loading="lazy">
        <div class="container px-5 px-lg-5 my-2" style="">
            <div id="divDetailProduct" class="row gx-4 gx-lg-5 align-items-center" style=" border-radius:10px;">
                        
                            <div class="widget-container">

                                <asp:Label ID="lbLike"  Visible="false" runat="server" CssClass="widget-item">
                                                               
                                <asp:ImageButton ID="btnToggleLike" title="Thích" Visible="false" style="color:#000; border:none; padding:6px; width:2.5rem; height:2.5rem; border-radius:50%;" runat="server" OnClick="btnToggleLike_Click" />

</asp:Label>
                 <div class="widget-item">
                     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

                                    <a onclick="toggleChatWindow()" href="#" <%--href="https://www.messenger.com/t/100005745948829"--%> class="widget-link" style="z-index:99999;"  title="Nhắn tin với KStore" >
                                        <i class="fas fa-comment-alt"></i>
                                    </a>
                                </div>
                <div class="widget-item">
                    <a href="#" class="widget-link"  title="Copy đường dẫn" >
                        <i class="fas fa-link"></i>
                    </a>
                </div>
                <div class="widget-item">
                    <a href="#" class="widget-link"  title="Chia sẻ trang" >
                        <i class="fa-solid fa-share"></i>
                    </a>
                </div>
               
            </div>
                <asp:FormView ID="productDetail" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetDetails" RenderOuterTable="false" OnPageIndexChanging="productDetail_PageIndexChanging">
                    <ItemTemplate>
                        <div class="col-md-6 py-3" id="slSP">
                           
                            <img   title="<%#:Item.TenSP%>" loading="lazy" style="border-radius:20px;" class="card-img-top mb-5 mb-md-0 zoom-hover product-detail-Img" src="<%#:Item.DuongDan%>" alt="..." />
                            
                        </div>
                        <div class="col-md-6">
                            <div class="small mb-1"></div>
                            <h1 class="display-5 fw-bolder" style="font-size:40px; margin-top:-2rem;"><%#:Item.TenSP%></h1>
<%--                             <p class="lead fade-out"><a id="btnViewMore" href="#" onclick="toggleAdditionalContent(); return false;"><%#:Item.MoTa%></a></p>--%>

                            <div class="fs-5 mb-5 <%--fade-out--%>">
                                <span title="Giá sản phẩm <%#string.Format("{0:N0}", Item.Gia)%>đ" style="font-size:24px; font-weight:bold; color:#F7C1D8;" loading="lazy" class="<%--text-decoration-line-through--%>"><%# string.Format("{0:N0}", Item.Gia) %>đ</span><p style="font-size:12px;"><i>&#x2a;Giá niêm yết không thay đổi</i></p>
                                <%--<asp:Label ID="lbPrice" runat="server" Text='<%# string.Format("{0:N0}", Item.Gia) %>đ' />--%>

                                <%--                                <span>$40.00</span>--%>

                            </div>
                            <div class="d-grid" id="divButtonMuaGioDG" style="gap: 1rem;">
                                





                                <div class="d-flex" style="gap: 1rem;">
                                <asp:Button ID="BuyNow" runat="server" title="Mua sản phẩm ngay"  Style="height:45px;"  Text="MUA NGAY" OnClick="BuyNow_Click" class="btn btn-outline-dark flex-shrink-0 btn-mua-ngay btn-item btn-at-sp-hover btn-at-sp btn-bold" />

                                <asp:Button ID="Button1" runat="server" title="Thêm sản phẩm này vào giỏ hàng"  Style="height:45px;" OnClick="AddToCart_Click" class="btn btn-outline-dark flex-shrink-0 btn-item btn-gio btn-at-sp-hover btn-at-sp btn-bold" Text="THÊM VÀO GIỎ"/>

                               
                                <a title="Xem đánh giá của sản phẩm"  id="toggleRating" herf="#" class="btn btn-outline-dark flex-shrink-0 btn-item toggleRating btn-at-sp-hover btn-at-sp btn-bold" style="height:45px; cursor:pointer; justify-content:center; align-content:center; align-items:center; justify-items:center; text-align:center;" >XEM ĐÁNH GIÁ</a>

                                </div>
                                <a title="Xem nội dung bên trong của sản phẩm" id="btnViewMore" class="btn btn-outline-dark flex-shrink-0 btn-item btn-at-sp-hover btn-bold" style="height:45px; cursor:pointer; justify-content:center; align-content:center; align-items:center; justify-items:center; text-align:center;" href="#" onclick="toggleAdditionalContent(); return false;">XEM NỘI DUNG BÊN TRONG SẢN PHẨM <%--<%#:Item.MoTa%>--%></a>            

                                <i class="bi-cart-fill me-1"></i>





                                            </div>
                            
                                                                                    <div loading="lazy" id="divVer" class="div-Ver d-flex" style="gap:0.5rem; height:160px !important;   flex-wrap:wrap;  height:max-content; border-top:1px  dashed #fff; padding-top:2rem;">
 <asp:ListView ID="lvVer" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetVer">
    <ItemTemplate>
         <%# IfNotNullOrEmpty(Item.Ver,"<style> @media only screen and  (max-width: 768px) {\r\n        \r\n            \r\n              #divSL{\r\n     \r\n                  bottom:16.4rem !important;\r\n                  left:8.525rem !important;\r\n                   height:43px !important;\r\n\r\n              }\r\n         \r\n     }</style>")%>
        <a loading="lazy" class="aVer" href="item.aspx?sp=<%#:Item.MaSP%>" id="aTenVer" style="text-align:center; border:1px solid #fff0; border-radius:5px;  color:#000;    background:#fff0; width:100px; height:max-content; padding:0 0 -1rem 0; margin-bottom:0.1rem;">   
            <img  title="<%#:Item.TenSP%>"  loading="lazy" id="verImg" src="<%#:Item.DuongDan%>" style="width:70px; height:70px; border-radius:10px; margin:1rem auto auto auto; justify-content:center; align-content:center; justify-items:center; align-items:center;" alt="Versions"/>
            <p id="pTenVer" loading="lazy" style="/*border:1px solid #fff;*/  /*color:#000;    background:#fff;*/ flex-wrap:wrap;   border-radius:10px; padding:2.5px 0  -1rem 0;"><%#:Item.TenVer %></p></a>
    </ItemTemplate>
</asp:ListView>
                                                                                        <div class="d-grid" style="">
   <p style="font-size:20px; font-weight:bolder;">Lưu ý</p>
  <p  style="font-size:14px; ">Về thời gian vận chuyển:</p>
  <ul style="font-size:14px; list-style-type:disc; ">
      <li >
          <p>Từ 3-5 ngày đối với những sản phẩm có sẵn trên website của KStore.</p>
      </li>
      <li>
          <p>Đối với những sản phẩm đặt trước hoặc không có sẵn, thời gian vận chuyển sẽ tính từ ngày sản phẩm có hàng tại kho (tùy thuộc vào ngày gửi đi của nhà bán hàng).</p>
      </li>
  </ul></div>
    </div>

                            
                            
                            </div>
                                            </ItemTemplate>
                </asp:FormView>
                            
                            
                            <div class="div-bottom-product-content <%--d-flex--%> py-1" style="margin:0.5rem; gap:20px; margin-bottom:2rem; flex-wrap:wrap;">
                                               
                                                                               
                                <div id="divSL" class="d-flex" style="gap:16px; height:42px; text-align:center; justify-content:center;justify-items:center; align-content:center; align-items:center;">
                                         <div id="SL" style="background:#fff; height:100%; text-align:center; justify-content:center;justify-items:center; align-content:center; align-items:center; border-radius:5px;">
                                            <asp:ImageButton ID="btnDelete" Visible="false" runat="server" CommandArgument='<%# Eval("MaSP") %>' OnClick="btnDelete_Click" CssClass="btn btn-danger btn-p-m" ImageUrl="~/Content/icon/sl-minus.png" />
                                            <asp:TextBox runat="server" Visible="false"   ID="txtSoLuong" CssClass="txtSoLuong" Text="1" AutoPostBack="true" ShowButtonShapes="false" style="width:3rem; height:31px; color:#000; text-align:center; border-radius:5px; border:none; font-weight:bold;"></asp:TextBox>
                                            <asp:ImageButton ID="btnChange" Visible="false" runat="server" CommandArgument='<%# Eval("MaSP") %>' OnClick="btnChange_Click" CssClass="btn btn-warning btn-p-m" ImageUrl="~/Content/icon/sl-plus.png" />

                                        </div>
                                  
                                    <div id="divPop" style="height:100%;width:144px; background:#fff; text-align:center; justify-content:center;justify-items:center; align-content:center; align-items:center; border-radius:5px;">
                                        <asp:DropDownList ID="ddlPop" runat="server" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlPop_SelectedIndexChanged" CssClass="full-width div-ls divPop dropPop" style="width:136px; height:27px; text-align:center; color:#000;height:100%; background:#fff; border:none; font-weight:bold;">

                                        </asp:DropDownList> 
                                      
                                    </div>

                                 </div>
                            <div class=" d-flex" id="divSLandBtnShowRadting" style="width:8rem; position:absolute; left:51%; top:76%;">
							
                                <div class="divSLandbtnDGShow">
                        


                                    <div class="d-flex" id="divBtnShowDG" style=" text-align:center; gap:1rem; ">
                                                                   
  
   <asp:Label ID="lblMostRatedStar" Visible="false" runat="server" CssClass="showRating justify-content-center align-content-center" style="width:100px;  font-weight:bolder; background:#6d3e99;  color:#FFD43B; position:absolute;border-bottom-right-radius:5px; border-bottom-left-radius:5px;   box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);  padding: 10px;letter-spacing: 3px;   "></asp:Label></div>
                                
                                </div>
							    
                            </div>
                                
                                <asp:ListView ID="lvImages" runat="server" ItemType="TH03_WebBanHang.Models.SanPhamData" SelectMethod="GetImages">
    <ItemTemplate>
        <div class="d-grid" style="width:100%;">
        <div id="listImageDetailt" class="div-bottom-product-content" style=" gap:20px; flex-wrap:wrap;">
        <%# IfNotNullOrEmpty(Item.DuongDan1, "<img src='" + Item.DuongDan1 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>
        <%# IfNotNullOrEmpty(Item.DuongDan2, "<img src='" + Item.DuongDan2 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>
        <%# IfNotNullOrEmpty(Item.DuongDan3, "<img src='" + Item.DuongDan3 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>
        <%# IfNotNullOrEmpty(Item.DuongDan4, "<img src='" + Item.DuongDan4 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>
        <%# IfNotNullOrEmpty(Item.DuongDan5, "<img src='" + Item.DuongDan5 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>
        <%--<%# IfNotNullOrEmpty(Item.DuongDan6, "<img src='" + Item.DuongDan6 + "' class='product-image' onclick='changeMainImage(this.src)' />") %>--%>

                <div style="text-align:center; justify-content:center;">
          

            
                   



        </div>
           
 </div>
            

                             <div class="" id="divNoiDung" style=" margin-top:-6.2rem; padding-right:16px;">
                                <div id="divNoteContentText" style="justify-content:center; text-align:center; justify-items:center; font-size:14px">
                                 <p>Nguồn hàng: <%# Item.SanPham.NguonHang %></p>
                                 <p>Nội dung: <%# Item.SanPham.MoTa %></p>
                                </div>
                                 <div  style="justify-content:right; text-align:right; justify-items:right; display:grid;">
                                     <p id="lbNoiDung" style=" text-align:center; justify-content:right;float:right; justify-items:right;">Nội dung bên trong sản phẩm</p>
                                     
<%# IfNotNullOrEmpty(Item.AnhNote, "<style>@media only screen and  (min-width: 768px) {\r\n    #divSL{\r\n        \r\n        top:25.35rem !important;\r\n        \r\n    }} @media only screen and  (max-width: 768px) { #divSL{\r\n     \r\n     bottom:19.438rem !important;\r\n     height:43px !important;\r\n     \r\n\r\n }}  #btnViewMore{display:block;}</style> <img title=\"Ảnh minh họa\" loading='lazy' id='anhNote'  src=\'"+Item.AnhNote+"' style=' height:auto; border-radius:10px;' class='fade-in' onclick='changeMainImage(this.src)' />") %>



</div>
 </div></div></div>
    </ItemTemplate>

</asp:ListView> </div>

                           
                

              
               
                
            </div>

                            <div id="idRating" class="flex-column flex-md-row fade-out" style="background: linear-gradient(to right, #522A77, #2a2e77); border-radius:10px;  height:max-content; display:none;  margin:auto;  margin:1rem auto; gap:1rem;">
                                        <asp:HiddenField ID="ratingValue" runat="server" />
                    

                   

                                    <div id="DGshow" class="d-grid col-12 col-md-6 fade-out DG" style="background-color:#e1e1e1d4;border-top-left-radius:10px; border-top-right-radius:10px;  /* height:max-content;*/ /*max-height:100%;*/    /*border-bottom-left-radius: 20px; border-bottom-right-radius:20px; */">
                <asp:DropDownList ID="ddlRatingFilter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRatingFilter_SelectedIndexChanged" style="width: max-content; color:#000;   border:none; position:absolute; right:25px; margin-top:5px; background:#0000; text-align:left; padding-left:1rem;">
                  
    <asp:ListItem ID="lsItemRatingAll" Value="0"></asp:ListItem>
    <asp:ListItem ID="lsItemRating1" Text="1★" Value="1"></asp:ListItem>
    <asp:ListItem ID="lsItemRating2" Text="2★" Value="2"></asp:ListItem>
    <asp:ListItem ID="lsItemRating3" Text="3★" Value="3"></asp:ListItem>
    <asp:ListItem ID="lsItemRating4" Text="4★" Value="4"></asp:ListItem>
    <asp:ListItem ID="lsItemRating5" Text="5★" Value="5"></asp:ListItem>
</asp:DropDownList>
                                     

                                        <div style="overflow:auto;" class="div-DG">
                                        <asp:ListView ID="ListViewComments" runat="server">
                                            <EmptyItemTemplate>
                                               <p style="color:#000;">Sản phẩm này vẫn chưa có bài đánh giá.</p>

                                            </EmptyItemTemplate>
                                            <EmptyDataTemplate>
                                                <p style="color:#000;">Sản phẩm này vẫn chưa có bài đánh giá.</p>
                                            </EmptyDataTemplate>
    <LayoutTemplate>
        <div runat="server" id="itemPlaceholder"></div>
    </LayoutTemplate>
    <ItemTemplate>

        <div class="grid" id="divUserComentShow" style="background:#fff; flex-wrap:wrap; border-radius:10px; height:max-content;  margin:0.5rem 0;">
            <div class="divClientCMT" style="background:#fff; flex-wrap:wrap; box-shadow:0px 0px 1px #636363;  border-radius:10px; padding:15px 25px 0px 15px;">
        <div class="d-flex" style="gap:10px;">
           
            <img title="<%# Eval("TenKH") %>" id="avatarCMT" src="<%# Eval("AvatarUser") %>"  style="object-fit:cover; background:#000; width:45px; height:45px; border-radius:50%; border:2px solid #9b51e0" class=""/>
               <div class="d-grid justify-content-center align-content-center" style="height:max-content; display:block;"> 
                     
               <div class="d-flex" style="flex-wrap:wrap; gap:5px; padding: 0;  margin-bottom:-1rem;">                  
              <p style=""><strong  style="color:#000; font-size:16px; "><%# Eval("TenKH") %></strong></p>    
         <p>    <strong style="color:#000;">(</strong><strong style="width:16px; font-family:Verdana, Geneva, Tahoma, sans-serif; font-weight:bolder; color:#ffc107;"><%# Eval("RatingValue").ToString() %></strong><span  ClientIDMode="Static" style="width:16px; font-family:Baloo; color:#ffc107;"><i class="fa-solid fa-star" style="color: #ffc107;"></i></span><strong style="color:#000;">)</strong></p>
    </div><p  style="color:#000; flex-wrap:wrap; overflow:hidden; overflow-wrap: break-word; width:100%; max-width:1080px !important; height:max-content; font-size:16px; display:block"><%# Eval("NoiDung") %></p> 
                 
               </div>
                         
</div>
      

                <div class="d-flex" style="width:100%; flex-wrap:wrap; gap:10px; padding:5px 0px 10px 10px; margin-top:5px; overflow-wrap: break-word; ">
    <%# IfNotNullOrEmpty(Eval("Anh1"), "<div class='image-container'><a data-fancybox=\"gallery\" data-type=\"image\" data-fancybox-index=0 href='" + Eval("Anh1") + "'><img src='" + Eval("Anh1") + "' class='rating-image fade-out' /></a></div>") %>
    <%# IfNotNullOrEmpty(Eval("Anh2"), "<div class='image-container'><a data-fancybox=\"gallery\" data-type=\"image\" data-fancybox-index=1 href='" + Eval("Anh2") + "'><img src='" + Eval("Anh2") + "' class='rating-image fade-out' /></a></div>") %>
    <%# IfNotNullOrEmpty(Eval("Anh3"), "<div class='image-container'><a data-fancybox=\"gallery\" data-type=\"image\" data-fancybox-index=2 href='" + Eval("Anh3") + "'><img src='" + Eval("Anh3") + "' class='rating-image fade-out' /></a></div>") %>
    <%# IfNotNullOrEmpty(Eval("Anh4"), "<div class='image-container'><a data-fancybox=\"gallery\" data-type=\"image\" data-fancybox-index=3 href='" + Eval("Anh4") + "'><img src='" + Eval("Anh4") + "' class='rating-image fade-out' /></a></div>") %>
    <%# IfNotNullOrEmpty(Eval("Anh5"), "<div class='image-container'><a data-fancybox=\"gallery\" data-type=\"image\" data-fancybox-index=4 href='" + Eval("Anh5") + "'><img src='" + Eval("Anh5") + "' class='rating-image fade-out' /></a></div>") %>

    <%# IfNotNullOrEmpty(Eval("Video"), "<div class='video-container'><a data-fancybox=\"gallery\" data-type=\"video\" data-fancybox-index=5 href='" + Eval("Video") + "'><video src='" + Eval("Video") + "' class='rating-video fade-out' /></a></div>") %>

    
</div>



  <div class="d-flex" style=" text-align:left;">
                        <p><small style="font-size:12px; color:#000;"><%# Eval("NgayDG") %></small></p>
<%--            <asp:Button ID="btnToggleLike" runat="server" OnClick="btnToggleLike_Click" CommandArgument='<%# Eval("MaDG") %>' />--%>


        </div></div>



        </div>
    </ItemTemplate>
</asp:ListView>


                                        </div>

                                    </div>
                    <div class="d-flex" style="margin:5px auto; gap:1rem">
<%--                    <a id="showAllRatingButton" href="#" style="margin:5px auto; background:#2a2e77; text-align:center; width:150px; padding:10px 15px; border-radius:10px;">Xem tất cả</a>--%>

                        
                       
                                                            <a href="#"  onclick="hideLSRating()" id="btnHideDG" class="btnHideDG btn-bold" style="margin:5px auto; background:#7a41b0;  text-align:center; padding:10px 15px;width:150px; border-radius:10px; transition:0.5s" >ẨN ĐÁNH GIÁ</a>

                    <a id="showFormButton" class="btn-bold"  href="#" style="margin:5px auto; background: #7a41b0; text-align:center; padding:10px 15px;width:150px; border-radius:10px;">VIẾT ĐÁNH GIÁ</a>
</div>
                  
                
                
                </div>
        </div>

    </section>
        
      <!-- Group section-->
   
   
  
    <asp:FormView ID="groupsDetail" runat="server" ItemType="TH03_WebBanHang.Models.Nhom" SelectMethod="GetGroups" RenderOuterTable="false"> 
           <ItemTemplate>
               
                <div class="container px-4 px-lg-5" style="margin-bottom:1rem;"  loading="lazy">
                    <div  loading="lazy" class="align-items-center fade-in" style="background:linear-gradient(to right, #522A77,#2a2e77);border-radius:10px; /* border-top-right-radius:20px;border-top-left-radius:20px;*/ padding:5px;">
                        <img  title="<%#:Item.TenNhom%>" loading="lazy" style="width:100%; background:#808080; /*border-top-right-radius:20px;border-top-left-radius:20px;*/ border-radius:10px; " src="<%#:Item.AnhNhom%>" class="fade-in zoom-hover"/>
                        <a class="fade-in"  loading="lazy" href="https://vi.wikipedia.org/w/index.php?search=<%#:Item.TenNhom%>">                    <h1 loading="lazy" class="fade-in" style="padding:2px 15px; background:linear-gradient(to right, #522A77,#2a2e77);"><%#:Item.TenNhom%></h1></div>
</a>
                    
               </div>
           </ItemTemplate>
       </asp:FormView>
    
    <!-- Related items section-->
    <section class=" <%--bg-light--%> <%--fade-out--%> " style="">
        <div class="container px-4 px-lg-5">
            <%--  <h2 class="fw-bolder mb-4 tenSP-ls-h3">--%><%--Related products--%> <%--<p class="tenSP-ls-p">Các Món Tương Tự</p></h2>--%>
            <%-- <style>
                .tenSP-ls-h3 {
                padding-bottom: 1.5rem;
                text-align: center;
                font-weight: bolder;
                font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                color: #9b51e0;
                width: 100%;
            }

            .tenSP-ls-p {            color: #9b51e0;
                width: max-content;
                padding: 8px;
                margin: auto;
                border-bottom-color:#000 ;
                border:1px solid;
                border-top-style:none;
                border-left-style:none;
                border-right:none;
            }</style>--%>
        <nav id="navLSMenu" class="navbar  navbar-expand-lg  navbar-dark mb-5 align-items-center <%--fade-out--%> " style="background:linear-gradient(to right, #522A77, #2a2e77); border-radius:10px; /*border-bottom-right-radius:20px;border-bottom-left-radius:20px;*/ ">
 
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav" style="gap:1rem;">
        
      <li class="nav-item-inItem nav-item active">
     <a class="nav-link ds-loai-sp" href="#" data-ls="0">Tất cả</a>
    </li>
      <asp:ListView ID="LoaiListView" runat="server">
    <ItemTemplate>
        
        <li class="nav-item-inItem nav-item">
    <a class="nav-link ds-loai-sp" href="#" data-ls="<%# Eval("MaLoai") %>"><%# Eval("TenLoai") %></a>
</li>
    </ItemTemplate>
</asp:ListView>

</ul>
  </div>
</nav>
             
            
            
            
            

           

                     <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-left">
                         <asp:ListView ID="ListView1" runat="server" ItemType="TH03_WebBanHang.Models.SanPham" SelectMethod="GetPhones">

                             <EmptyDataTemplate>
                                
                                 <div style=" width:100%; height:70vh; font-family: 'Baloo 2', sans-serif; text-align:center; justify-content:center; align-content:flex-start; justify-items:center; align-items:center;">
                                 <h3>Chưa có sản phẩm ở hạng mục này.</h3>
                         </div>
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

                             <div class="col mb-5">
                            <%--<div class="card h-100">--%><a class="fade-in btn btn-outline-dark mt-auto btn-mua card h-100" href="item.aspx?sp=<%#:Item.MaSP%>">
                                     <!-- Product image-->

                                     <img  title="<%#:Item.TenSP%>" loading="lazy" style="padding: 20px; height: max-content;" class="card-img-top img-with-hover" src="<%#:Item.DuongDan%>" alt="..." />
                               
                                     <!-- Product details-->
                                     <div class="card-body p-4">
                                         <div class="text-center">
                                             <!-- Product name-->
                                             <h5 class="fw-bolder" style=""><%#:Item.TenSP%></h5>

                                         </div>
                                     </div>
                                     <!-- Product actions-->
                                     <div class="card-footer p-4 pt-0 border-top-0 bg-transparent" style="position:relative;">
                                         <!-- Product price-->
                                         <p class="text-center"><%# string.Format("{0:N0}", Item.Gia) %>đ</p>
                                         <div class="text-center d-flex justify-content-center" style="gap:1rem;">
                                            
                                                  
                                               
                                                <asp:Button ID="btnCart" CommandArgument='<%#:Item.MaSP%>' runat="server" Style="font-size:small; width: 145.5px; height:37.5px; background:#fff;" OnClick="btnCart_Click" class="btn btn-outline-dark flex-shrink-0 btn-gio btn-gio-card btn-bold btn-at-sp-hover" Text="THÊM VÀO GIỎ" title="Thêm sản phẩm này vào giỏ hàng"/>


                                                                        
            </div>
                                </div>
        </a>
                        </div>

                       
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </section>
    <div id="overlay" style="display: none; position: fixed; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.5); z-index: 1000;"></div>
    <div id="ratingDiv" class=" col-12 col-md-6 fade-out"  style="width:100%;  padding:15px 15px;   position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    margin: auto;
    width: max-content;
    height: max-content; ">    
                        <button id="closeRatingDiv"  style="position: absolute; top: 10px; right: 10px; background: none; border: none; font-size: 20px; color: #fff; pointer-events:auto; cursor:pointer;"><i class="fa-solid fa-xmark"></i></button>

                                          <h4 style="margin:10px auto 15px auto;"><strong>Viết đánh giá</strong></h4>
                       <asp:Image ID="IMGRatingSP" Visible="false" runat="server" Height="180" Style="margin:auto; border-radius:10px; margin-bottom:5px"/>
                        <asp:Label ID="lbRatingSP" Visible="false"  runat="server" Style="margin:auto;"></asp:Label>
                        <asp:FormView ID="ratingForm" runat="server" DefaultMode="Insert" Visible="false">
                                              <InsertItemTemplate>
                                           <div style="margin:10px  auto;" class="justify-content-center align-content-center text-center">      
         <span class="star" id="star1" ClientIDMode="Static" onclick="selectStar(1)" onmouseover="hoverStar(1)" onmouseout="removeHover()"><i class="fa-solid fa-star"></i></span>
         <span class="star" id="star2" ClientIDMode="Static" onclick="selectStar(2)" onmouseover="hoverStar(2)" onmouseout="removeHover()"><i class="fa-solid fa-star"></i></span>
         <span class="star" id="star3" ClientIDMode="Static" onclick="selectStar(3)" onmouseover="hoverStar(3)" onmouseout="removeHover()"><i class="fa-solid fa-star"></i></span>
         <span class="star" id="star4" ClientIDMode="Static" onclick="selectStar(4)" onmouseover="hoverStar(4)" onmouseout="removeHover()"><i class="fa-solid fa-star"></i></span>
         <span class="star" id="star5" ClientIDMode="Static" onclick="selectStar(5)" onmouseover="hoverStar(5)" onmouseout="removeHover()"><i class="fa-solid fa-star"></i></span>
                                           </div>
                                                  <p id="pRatingSelect" style="text-align:center; font-size:14px;"></p>
                                              </InsertItemTemplate>
     </asp:FormView>


                        <div class="d-flex" style="gap:10px; margin-top:1rem;">
                                                <asp:Image ID="imgClientCMT" runat="server" Visible="false" style=" display:none; object-fit:cover; background:#000; width:50px; height:50px; border-radius:50%; border:3px solid #9b51e0"/>


<asp:TextBox ID="txtComment" placeholder="Mời bạn chia sẻ thêm cảm nhận..." spellcheck="false" type="text" runat="server" TextMode="MultiLine" Rows="4" Columns="50"  Visible="false" CssClass="fa-comment comment-item" style=" width:100%; padding:10px; "></asp:TextBox>
                        

                                      
                        </div>

                        
                        <div class="d-flex comment-item" style=" margin-top:0.5rem; gap:0.5rem; justify-content:center; align-content:center; text-align:center; ">
    <asp:FileUpload ID="fileUploadImages" runat="server" AllowMultiple="true" CssClass="custom-file-upload" ClientIDMode="Static" onchange="previewImages(this)" />
    <label for="<%= fileUploadImages.ClientID %>" class="custom-file-label"><i class="fa-solid fa-camera"></i> Thêm ảnh</label>

    <asp:FileUpload ID="fileUploadVideo" runat="server" CssClass="custom-file-upload" ClientIDMode="Static"  onchange="previewVideo(this)" />
    <label for="<%= fileUploadVideo.ClientID %>" class="custom-file-label" style=""><i class="fa-solid fa-video"></i> Thêm video</label>
</div>          
                                 

                        <div class="d-flex" style="margin:10px auto;" >
                                <div class="image-preview"id="imagePreviewContainer"></div>
    <div class="video-preview" id="videoPreviewContainer"></div>
                            </div>
                       
                       
                                 
            <p id="divNoteUploadRating">Lưu ý: Web chỉ hỗ trợ upload tối đa 5 hình ảnh và 1 video, kích thước mỗi file dưới 10MB và tổng kích thước các file phải dưới 60MB, không chấp nhận hình ảnh định dạng .webp và video dài quá 1 phút.</p>


                        <div id="ratingDiv2">
   
   <div class="cmtProfile-Non-Login"  style="margin:1rem auto; gap:1rem; justify-content:center; align-content:center; text-align:center;">
                            
                            <div class="d-grid">
                            <asp:TextBox ID="txtHoTen" placeholder="Họ Tên (bắt buộc)" type="text" runat="server" Visible="false" style="color:#000;border-radius:10px; border:1px solid #000; width:12rem; padding:5px;"></asp:TextBox></div>
                                                       <div class="d-grid"> 

                            <asp:TextBox ID="txtDienThoai" placeholder="Số điện thoại (bắt buộc)"  runat="server"  Visible="false" style="color:#000; border-radius:10px;  border:1px solid #000;  width:12rem; padding:5px;"></asp:TextBox></div>
                                                   <div class="d-grid"> 

<asp:TextBox ID="txtEmail" placeholder="Địa chỉ Email (bắt buộc)" type="email" runat="server"  Visible="false" style="color:#000; border-radius:10px;  border:1px solid #000;  width:12rem; padding:5px;"></asp:TextBox></div>
                        
   
   </div>                     
</div>
                        <asp:Button  ID="btnSubmitComment" runat="server" Text="GỬI BÀI ĐÁNH GIÁ"  OnClick="btnSubmitComment_Click"  Visible="false"  CssClass="btn-comment justify-content-center align-content-center btn-bold btn-send-rating" style="padding:8px; border-radius:10px; background:#464baa; border:none; margin:auto; width:100%;"/>
                    </div>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>          
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.js"></script>
<script>
      window.onload = function () {
          selectStar(5);

      };

    function selectStar(starNumber) {
        // Loại bỏ class 'selected' từ tất cả các ngôi sao
        var stars = document.getElementsByClassName('star');
        for (var i = 0; i < stars.length; i++) {
            stars[i].classList.remove('selected');
        }

        // Thêm class 'selected' vào tất cả các ngôi sao trước đó
        for (var i = 1; i <= starNumber; i++) {
            document.getElementById('star' + i).classList.add('selected');
        }


        // Lưu giá trị đánh giá được chọn vào một hidden field để lấy từ code-behind
        document.getElementById('<%= ratingValue.ClientID %>').value = starNumber;
        switch (starNumber) {
            case 1:
                document.getElementById('pRatingSelect').innerHTML = 'Sản phẩm rất tệ 😠'; break;
            case 2:
                document.getElementById('pRatingSelect').innerHTML = 'Sản phẩm tệ 😞'; break;
            case 3:
                document.getElementById('pRatingSelect').innerHTML = 'Sản phẩm bình thường 😐'; break;
            case 4:
                document.getElementById('pRatingSelect').innerHTML = 'Sản phẩm tuyệt vời 🥰'; break;
            case 5:
                document.getElementById('pRatingSelect').innerHTML = 'Sản phẩm rất tuyệt vời 😍'; break;

        }

    }

        document.addEventListener("DOMContentLoaded", function () {

            const addToCartBtn = document.querySelector('.btn-gio');
            const notification = document.getElementById('notification');

            addToCartBtn.addEventListener('click', function () {
                showNotification()
            });

            function showNotification() {
                notification.style.display = 'flex';

                setTimeout(function () {
                    notification.style.display = 'none';
                }, 2000);
            }
        });
    
        function changeMainImage(src) {
            document.querySelector('.card-img-top').src = src;

        }

         document.addEventListener('DOMContentLoaded', function () {
             // Lấy tất cả các widget-link
             const widgetLinks = document.querySelectorAll('.widget-link');

             // Xử lý sự kiện click cho mỗi widget-link
             widgetLinks.forEach(link => {
                 link.addEventListener('click', function (event) {
                     event.preventDefault(); // Ngăn chặn hành vi mặc định của link

                     // Kiểm tra biểu tượng được nhấp vào
                     if (this.querySelector('i').classList.contains('fa-link')) {
                         // Sao chép đường dẫn hiện tại
                         navigator.clipboard.writeText(window.location.href)
                             .then(() => {
                                 alert('Đường dẫn đã được sao chép!');
                             })
                             .catch(err => {
                                 console.error('Không thể sao chép đường dẫn: ', err);
                             });
                     } else if (this.querySelector('i').classList.contains('fa-share')) {
                         // Xử lý chia sẻ trang hiện tại đến mạng xã hội
                         const currentUrl = encodeURIComponent(window.location.href);
                         const facebookUrl = `https://www.facebook.com/sharer/share_channel.php?u=${currentUrl}`;
                         //const messengerUrl = `https://www.facebook.com/dialog/send?app_id=YOUR_APP_ID&link=${currentUrl}&redirect_uri=YOUR_REDIRECT_URI`;
                         //const facebookUrl = `https://www.facebook.com/sharer/sharer.php?u=${currentUrl}`;

                         //const zaloUrl = `https://zalo.me/share?url=${currentUrl}`;

                         // Mở cửa sổ mới để chia sẻ
                         window.open(facebookUrl, '_blank');
                         //window.open(messengerUrl, '_blank');
                         //window.open(zaloUrl, '_blank');
                     }
                 });
             });
         });
     
         $(document).ready(function () {
             Fancybox.bind({
                animationSpeed: 300
             });
         });
                                
         function previewImages(fileInput) {
             var divNoteUploadRating = document.getElementById('divNoteUploadRating');

             const previewContainer = document.getElementById('imagePreviewContainer');
             previewContainer.innerHTML = ''; // Clear previous images
             if (fileInput.files) {
                 for (let i = 0; i < fileInput.files.length; i++) {
                     const file = fileInput.files[i];
                     const img = document.createElement('img');
                     img.src = URL.createObjectURL(file);
                     img.style.width = '50px';
                     img.style.height = '50px';
                     img.style.borderRadius = '10px';
                     img.style.objectFit = 'cover';
                     img.style.marginRight = '10px';
                     previewContainer.appendChild(img);
                     divNoteUploadRating.style.display = 'none';
                 }
             }
         }

         function previewVideo(fileInput) {
             var divNoteUploadRating = document.getElementById('divNoteUploadRating');

             const previewContainer = document.getElementById('videoPreviewContainer');
             previewContainer.innerHTML = ''; // Clear previous videos
             if (fileInput.files) {
                 for (let i = 0; i < fileInput.files.length; i++) {
                     const file = fileInput.files[i];
                     const video = document.createElement('video');
                     video.src = URL.createObjectURL(file);
                     video.style.width = '50px';
                     video.style.height = '50px';
                     video.style.objectFit = 'cover';
                     video.style.borderRadius = '10px';
                     video.style.marginRight = '10px';
                     video.controls = true; // Add controls to the video
                     previewContainer.appendChild(video);
                     divNoteUploadRating.style.display = 'none';
                 }
             }
         }
     </script>
<script type="text/javascript">
         function toggleAdditionalContent() {
             var additionalContent = document.getElementById('divNoiDung');

             if (additionalContent.style.display === "grid") {
                 additionalContent.style.display = "none";
                 document.getElementById('btnViewMore').innerHTML = 'XEM NỘI DUNG BÊN TRONG SẢN PHẨM';


             } else {
                 additionalContent.style.display = "grid";
                 document.getElementById('btnViewMore').innerHTML = 'ẨN BỚT NỘI DUNG BÊN TRONG SẢN PHẨM';

             }
         }

         function closeAdditionalContent() {
             document.getElementById('additionalContent').style.display = "none";

         }

    </script>
<script>
        document.querySelector('.toggleRating').addEventListener('click', function (event) {
            event.preventDefault(); // Ngăn chặn hành vi mặc định của thẻ <a>
            var ratingElement = document.getElementById('idRating');
            var divDetailProduct = document.getElementById('divDetailProduct');
            if (ratingElement.style.display === 'none') {
                ratingElement.style.display = 'grid';
                document.getElementById('toggleRating').innerHTML = "ẨN ĐÁNH GIÁ";
                divDetailProduct.style.paddingBottom = '0';
                localStorage.setItem('ratingElementDisplay', 'grid'); // Lưu trạng thái hiển thị
            } else {
                ratingElement.style.display = 'none';
                divDetailProduct.style.paddingBottom = '0';
                document.getElementById('toggleRating').innerHTML = "XEM ĐÁNH GIÁ";
                localStorage.setItem('ratingElementDisplay', 'none'); // Lưu trạng thái ẩn
            }
        });

        document.addEventListener('DOMContentLoaded', function () {
            var ratingElement = document.getElementById('idRating');
            var displayStatus = localStorage.getItem('ratingElementDisplay');
            if (displayStatus) {
                ratingElement.style.display = displayStatus;
            }
            if (ratingElement.style.display != 'none') document.getElementById('toggleRating').innerHTML = "ẨN ĐÁNH GIÁ";
        });

</script>
<script>
        document.getElementById('showFormButton').addEventListener('click', function () {
            document.getElementById('overlay').style.display = 'block';
            document.getElementById('ratingDiv').style.display = 'grid';
        });

        // Khi người dùng nhấn vào overlay hoặc form, ẩn chúng
        document.getElementById('overlay').addEventListener('click', function () {
            document.getElementById('overlay').style.display = 'none';
            document.getElementById('ratingDiv').style.display = 'none';
        });

        document.getElementById('closeRatingDiv').addEventListener('click', function (event) {
            event.preventDefault();
            document.getElementById('overlay').style.display = 'none';
            document.getElementById('ratingDiv').style.display = 'none';
        });
    </script>
<script>
        function hideLSRating() {

            var ratingElement = document.getElementById('idRating');
            var divDetailProduct = document.getElementById('divDetailProduct');

            ratingElement.style.display = 'none';
            divDetailProduct.style.paddingBottom = '0';

            localStorage.setItem('ratingElementDisplay', 'none');
        };

    </script>
<script type="text/javascript">
        document.getElementById('<%= txtSoLuong.ClientID %>').addEventListener('input', function (e) {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    </script>
<script type="text/javascript">
        $(document).ready(function () {
            $('#<%= txtSoLuong.ClientID %>').on('input', function () {
                // Kiểm tra xem giá trị nhập vào có phải là số không
                var value = parseInt($(this).val(), 10);
                if (isNaN(value) || value < 1) {
                    // Nếu không phải số hoặc nhỏ hơn 1, đặt giá trị là 1
                    $(this).val('1');
                }
            });
        });
    </script>
<script>
        const btnCart = document.getElementById('btnCart');
        const btnCartclass = document.querySelector('.btn-gio-card');
        btnCartclass.addEventListener('click', showNotification);
        btnCart.addEventListener('click', showNotification());
    </script>
<script>
        $(document).ready(function () {
            $('.btn-mua').click(function () {
                var url = $(this).data('href');
                window.location.href = url;
            });
        });
    </script>
<script>
        // Lắng nghe sự kiện click trên các liên kết
        document.querySelectorAll('.ds-loai-sp').forEach(function (link) {
            link.addEventListener('click', function (event) {
                event.preventDefault(); // Ngăn chặn hành vi mặc định của liên kết

                // Lấy giá trị data-ls từ liên kết được click
                var lsValue = this.getAttribute('data-ls');

                // Thêm &ls=value vào URL hiện tại
                var newURL = addLsToCurrentURL(lsValue);

                // Điều hướng đến URL mới
                window.location.href = newURL;
            });
        });

        // Hàm để thêm &ls=value vào URL hiện tại
        function addLsToCurrentURL(lsValue) {
            var currentURL = window.location.href;

            if (currentURL.indexOf('?') === -1) {
                // Nếu URL không có query string, thêm ?ls=value mới
                currentURL += '?ls=' + lsValue;
            } else {
                // Nếu URL có query string
                var queryString = currentURL.split('?')[1]; // Lấy phần query string
                var queryParts = queryString.split('&'); // Chia query string thành các phần

                // Lọc các phần không chứa 'ls='
                queryParts = queryParts.filter(function (part) {
                    return part.indexOf('ls=') !== 0;
                });

                // Nối lại các phần với dấu '&'
                queryString = queryParts.join('&');

                // Thêm &ls=value mới vào cuối query string
                queryString += '&ls=' + lsValue;

                // Cập nhật URL với query string mới
                currentURL = currentURL.split('?')[0] + '?' + queryString;
            }


            return currentURL;
        }
    </script>
<script>
         function hoverStar(starNumber) {
             // Loại bỏ class 'hover' từ tất cả các ngôi sao
             var stars = document.getElementsByClassName('star');
             for (var i = 0; i < stars.length; i++) {
                 stars[i].classList.remove('hover');
             }
             // Thêm class 'hover' vào tất cả các ngôi sao trước đó
             for (var i = 1; i <= starNumber; i++) {
                 document.getElementById('star' + i).classList.add('hover');
             }
         }
         function removeHover() {
             // Loại bỏ class 'hover' từ tất cả các ngôi sao

             var stars = document.getElementsByClassName('star');
             for (var i = 0; i < stars.length; i++) {
                 stars[i].classList.remove('hover');
             }
         }
     </script>
</asp:Content>
