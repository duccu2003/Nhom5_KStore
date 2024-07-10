<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="NewInformationPage.aspx.cs" Inherits="TH03_WebBanHang.NewInformationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .text-container {
            max-height: 100px;
            text-overflow: ellipsis; /* Thêm dấu chấm (...) khi văn bản bị cắt bớt */
            color:#000 !important;
        }
        .image-container {
            height: 100px; /* Kích thước cố định */
            width: 156px; /* Kích thước cố định */
            object-fit:cover;
        }
       .embed-responsive {
    border-radius: 10px; /* Điều chỉnh độ tròn của iframe */
    overflow: hidden; /* Đảm bảo rằng iframe được làm tròn */
}

.embed-responsive-16by9::before {
    padding-top: 56.25%
}

.embed-responsive {
    position: relative;
    display: block;
    width: 100%;
    padding: 0;
    overflow: hidden
}

    .embed-responsive::before {
        display: block;
        content: ""
    }

    .embed-responsive .embed-responsive-item, .embed-responsive embed, .embed-responsive iframe, .embed-responsive object, .embed-responsive video {
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        width: 100%;
        height: 100%;
        border: 0
    }

    .embed-responsive-item, .embed-responsive embed, .embed-responsive iframe, .embed-responsive object, .embed-responsive video {
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        width: 100%;
        height: 100%;
        border: 0
    }
    .titletext{
        text-align:center;
        justify-content:center;
        justify-items:center;
    }
    </style>
    <section id="ssNews" class="pt-5 mt-5  pb-5" style="margin-top:8rem !important; background:linear-gradient(to bottom, #000, #242426);" loading="lazy">
       
        <div class="container px-5 px-lg-5 my-2" style=""> 
            <h3 id="INFO" class=" text-left lnr-text-size titletext" style="background:linear-gradient(to right, #7400a7, #1f00a7, #004ba7); padding:4px 10px; border-radius:10px;">
                     <p class="">NEWS</p>
                 </h3>
            <div class="row gx-4 gx-lg-5 align-items-center d-grid" style="padding:20px 0; border-radius:6px; background:#FFF; row-gap:20px;">
                 
               <iframe id="iframeBV" style="width:100%; height:600px; object-fit:contain;" src="#"></iframe>
              
             <ul id="div-tin" style="width:100%; gap:10px; border-top:2px solid #000; padding:1rem 20px; overflow-x:scroll;" class="d-flex">
            <asp:ListView ID="ListView3" runat="server" ItemType="TH03_WebBanHang.Models.TinTuc" SelectMethod="GetNews">
          <ItemTemplate>
               <li title="Tin tức" class="fade-in" style="height:100px; border-top:1px solid #b200ff; border-left:2px solid #000; border-right:2px solid #000;">
                  <a onclick="showBVinIframe('<%#:Item.DuongDanBV%>')" title="<%#:Item.TieuDe%>" href="#" class="alinkLinkBV" style="cursor:pointer; display:flex; margin-bottom:15px; gap:10px; height:100%; width:400px; object-fit:cover; overflow:auto;">
                      <div class="image-container">
                          <img loading="lazy" style="width:100%; height:100%;" class="" src="<%#:Item.HinhAnhBV%>" />
                      </div>
                      <p style="width:100%; height:100%; overflow:hidden; display:block; flex-wrap:wrap;"><span class="text-container"><%#:Item.TieuDe%><br />
                        <small class="text-container"><%#:Item.NoiDungBV%></small></span></p>
                  </a>
              </li>

          </ItemTemplate>


        </asp:ListView>
    

            </ul>
            </div>
        </div>
    </section>

     <section id="ssVideos" class="pt-5 mb-5 pb-5" style="background:linear-gradient(to top, #000, #242426);" loading="lazy">
         
     <div id="divVideo" class="container px-5 px-lg-5 my-2" style="">
            <h3 id="INFOVideo" class=" text-left lnr-text-size titletext" style="background:linear-gradient(to right, #7400a7, #1f00a7, #004ba7); padding:4px 10px; border-radius:10px; ">
             <p class="">VIDEOS</p>
         </h3>
         <div class="row gx-4 gx-lg-5 align-items-center d-flex" style="padding:20px 0; height:max-content; display:flex; border-radius:6px; background:#FFF;">
          <iframe id="iframeVideo" name="" allowfullscreen class="" style="object-fit:contain; width:75%; height:514px" src="#"></iframe>
           
          <div id="div-video" class="d-grid fade-in" style="height:514px; overflow-y:auto; padding-top:1rem; width:25%;">
                 <asp:ListView ID="ListView4" runat="server" ItemType="TH03_WebBanHang.Models.VideoThongTin" SelectMethod="GetVid">
                 <ItemTemplate>
                 <a  name="<%#:Item.MaV%>" style="cursor:pointer;" onclick="showVideoinIframe('<%#:Item.DuongDanV%>','<%#:Item.MaV%>' , this)" 
                   title="Video thông tin gần đây" class="alinkLinkVideo">
                    <div class="embed-responsive embed-responsive-16by9 fade-in video-if">
                        <iframe loading="lazy" style="cursor:none; z-index:1; pointer-events: none;" 
                               class="embed-responsive-item" src="<%#: Item.DuongDanV %>"></iframe>
                    </div>
                </a>

                </ItemTemplate>

                     </asp:ListView>
 

         </div>
         </div>
     </div>
 </section>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

   <script>

       $(document).ready(function () {
           // Tìm kiếm danh sách bài viết
           var $listView = $('#div-tin');

           // Kiểm tra xem danh sách có ít nhất một mục không
           if ($listView.length > 0) {
               // Chọn mục đầu tiên
               $listView.first().find('.alinkLinkBV').click();
           }

           var $listViewVideo = $('#div-video');

           // Kiểm tra xem danh sách có ít nhất một mục không
           if ($listViewVideo.length > 0) {
               // Chọn mục đầu tiên
               $listViewVideo.first().find('.alinkLinkVideo').click();
           }

       });


       function showBVinIframe(alink) {
           document.getElementById('iframeBV').src = alink;
           
       }
       function showVideoinIframe(alink, name, anchorTag) {
           document.getElementById('iframeVideo').src = alink;
           document.getElementById('iframeVideo').tagName = name;
           

           anchorTag.style.pointerEvents = 'auto'; // Khởi động lại khả năng tương tác sau khi thay đổi src

       }

   </script>
</asp:Content>
