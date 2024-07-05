<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TH03_WebBanHang.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="Content/logo/K.png" rel="shortcut icon" type="image/x-icon" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-y12XeLvPH5sAAfwm+4D/J2vPT3j9ky8/Sf1gXIS6Xr4F5ujP+0x2jE+8whv2G4N6" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">    
    <style>
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

         ::-webkit-scrollbar {
     width: 5px;
 }

 ::-webkit-scrollbar-thumb {
     background: #5e17a2ff;
 }

 ::-webkit-scrollbar-track {
     background: #202020;
 }
        .full-width {
    
            font-size:16px !important;
            text-align:center;
        }
        body {
    display: grid;
  
    height: 100vh; /* Chiều cao của body sẽ chiếm toàn bộ viewport */
    margin: 0; /* Loại bỏ margin mặc định */
    font-family: Roboto;
    background:#000000;
    
}
        *{
            font-family:Roboto;
        }
        body {
    font-size: 2vw; /* Hoặc sử dụng % thay vì vw */
}

        .div-ls{
            
        }
        .div-2 input, .div-2 select, .full-width{
            width:218.57px !important;
            height:35px;
        }
        .search-container{
            
        }
        *{
            color:#000;
        }
        label{
            color:#000;
        }
      .form-container {
   
    /*border: 1px solid #9b51e0;*/
    border-radius: 5px;
    height: max-content;
   
    margin: auto;
    /*background-image: url('Content/image-bg/content-bg.png');
    background-size: cover;*/
        /*background:linear-gradient(to bottom, #522A77,#000);*/
        background:#fff;
    position: relative; /* Đảm bảo .form-container có thể chứa .overlay */
   
}
      form {
     background: #242426 !important; 
    }


    

        /* Căn giữa các label và input */
        label, input, select {
       
            
        }

        /* Căn giữa nút thêm sản phẩm */
        .btnAddProduct {
           
        }
        .btnAddProduct {
            background-color:#000;
            width:100%;
    padding: 10px;
    border: none;
    color: #fff;
   
    cursor: pointer;
    font-size: 18px;
    margin:3rem auto auto auto;
   


    
        }
        .btnAddProduct:hover {
            background-color:#242426;
            color:#fff;
        }
        /* Thiết lập định dạng cho tiêu đề */
        .tenSP-ls-h3 {
            font-weight: bold;
            color: #9b51e0;
            text-align: center;
        }

        /* Thiết lập định dạng cho đoạn phụ tiêu đề */
        .tenSP-ls-p {            color: #9b51e0;
            width: max-content;
            padding: 8px;

            margin: auto;
            
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
        }
        div {
        }
        .div-ls{
            display:grid;
           
            font-size:16px !important;
           height:80px !important;
           width:14rem !important;
           
          
        }
        .div-ls input, .div-ls select{
          
            
        }
        
        
    </style>
    <style>
    .form-container {
        display: grid !important;
        flex-direction: row;
        align-items: center;
        
        min-height: 140vh; 
        overflow: hidden; 
    }

    .image-preview-container {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        width: 100%;
        padding: 20px;
        box-sizing: border-box;
    }

    .image-preview {
        margin: 10px;
        max-width: 100px;
        max-height: 100px;
        object-fit: cover; /* Đảm bảo rằng ảnh không bị biến dạng */
    }

    /* Các thuộc tính khác để tùy chỉnh hiển thị dựa trên kích thước màn hình */
    @media only screen and  (max-width: 768px) {
        
    }
    @media only screen and (max-width: 768px) {
    #form1{
        padding:0 !important;
    }
    /* Quy tắc cho màn hình nhỏ hơn hoặc bằng 768px */
   .form-container {
        width: 100% !important;
        margin: auto;
    }
   .div-ls {
        width: 100% !important;
    }
    /* Thêm các quy tắc khác cho các phần tử khi màn hình nhỏ */
}

@media only screen and (min-width: 769px) and (max-width: 1024px) {
    /* Quy tắc cho màn hình từ 769px đến 1024px */
   .form-container {
        width: 80%;
    }
    /* Thêm các quy tắc khác cho các phần tử khi màn hình nằm trong khoảng này */
}

</style>
    <style>
    .btn-header-u-c *{
        color:#000 !important;
    }
    footer{
        z-index:9999;
        background:#000;
    }
    #form1{
        background:#242426;
    }
    #moveTop *{
        color:#000 !important;
    }
</style>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

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
    var loader = function () {
        setTimeout(function () {
            $('#loader').css({ 'opacity': 0, 'visibility': 'hidden' });
        }, 1000);
    };
    $(function () {
        loader();
    });
</script>
</head>
<body style="overflow-x:hidden;">
    <div id="loader">
    <div class="circle">
        <div class="circle1"></div>
        <div class="circle2"></div>
    </div>
</div>
     <img loading="lazy" style="filter: brightness(50%); height: 100%; width: 100%; position: fixed; z-index: 0;" src="Content/image-bg/bg-for-slide-gp.png" />
    <form id="form1" runat="server" style="padding:20px;">
<<<<<<< HEAD
        <div style="margin:0px 20px 20px 20px; position:fixed; display:grid; row-gap:30px; z-index:99;">
     <a title="Thoát" class="dropdown-item" href="ManagerProduct" style="padding:5px; color:#000;  z-index:99; font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center;  background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>
     
</div>
=======
          <a class="dropdown-item" href="ManagerProduct" style="font-size:25px; text-align:center; border-radius:50%; border:1px solid #242426; width:35px; height:35px; align-items:center; align-content:center; justify-content:center; justify-items:center; position:fixed; background:#FFF;"><i class="fa-solid fa-caret-left" style="margin-right: 5px; width: 35px;"></i></a>

>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498

         <div class="form-container fade-out" style="width:60%; display: flex; border-radius:5px; overflow:auto; padding-top:5px;">
            <h1 style="margin:1rem auto 2rem auto; ">FORM THÊM SẢN PHẨM</h1>

        <div style="text-align: left; display:block; margin:auto;">



                        

                
        
          <div style="display:flex !important; gap:34px;">
<div class="div-ls" style="display:flex; gap:0.5rem;  width:10rem;"> 
 <asp:Label ID="lbPreOrder" runat="server" for="txtSL" Text="Hàng đặt trước:" style="color:#000;"></asp:Label>


<asp:CheckBox ID="checkPreOrder" type="checkbox"  CssClass="checkmark" runat="server" style=""  AutoPostBack="True" OnCheckedChanged="checkPreOrder_CheckedChanged"/>
</div>
  <div class="div-ls"  style="display:flex; gap:0.5rem;  width:10rem;">      
 <asp:Label ID="lbCheckPop" runat="server" for="txtSL" Text="Kèm Pob:" style="color:#000;"></asp:Label>

     
 <asp:CheckBox ID="CheckboxOfPop" type="checkbox"  CssClass="checkmark" runat="server" style=""  AutoPostBack="True" OnCheckedChanged="checkHavePop_CheckedChanged"/>
</div>

 
<div class="div-ls"  style="display:flex; gap:0.5rem;  width:max-content;"> 
                     <asp:Label ID="Label1" runat="server" for="txtSL" Text="Ver:" style="color:#000;"></asp:Label>


                    <asp:DropDownList ID="ddlMaSPofVer" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlMaSPofVer_SelectedIndexChanged" CssClass="full-width div-ls" style="width:190.57px !important; height:35px !important; text-align:center;">
                  
    </asp:DropDownList>  
    
                       


 </div>
</div>
                                <div class="d-flex fade-out div-2" style="display:flex !important; gap:34px;">

    <style>
                    #MainContent_checkPreOrder{
                       
                        
                    }
                </style>
                 <script>
                     function formatDate(input) {
                         // Lấy giá trị nhập vào từ textbox
                         var value = input.value;

                         // Loại bỏ tất cả các ký tự không phải là số
                         var numericValue = value.replace(/\D/g, '');

                         // Kiểm tra xem có đủ số không
                         if (numericValue.length >= 8) {
                             // Lấy ngày, tháng, năm từ chuỗi số
                             var day = numericValue.slice(0, 2);
                             var month = numericValue.slice(2, 4);
                             var year = numericValue.slice(4);

                             // Kiểm tra và sửa đổi giá trị ngày, tháng, năm nếu cần
                             if (parseInt(day) > 31) {
                                 day = '31';
                             }
                             if (parseInt(month) > 12) {
                                 month = '12';
                             }
                             if (parseInt(year) < 1000) {
                                 year = '1000';
                             }



                             // Định dạng ngày tháng năm theo dạng dd/MM/yyyy
                             var formattedDate = day + '/' + month + '/' + year;

                             // Gán lại giá trị đã định dạng vào textbox
                             input.value = formattedDate;
                         }
                     }
                 </script>
                    
 
              
                    <style>
                        .div-add-Lb{
                            color:#000;
                        }
                        .div-add-input{
                            color:#000;
                            width:8rem;
                        }
                    </style>

                
           <div class="d-grid" style="">
               <div class="div-ls fade-out">
               
                <label for="txtMaSP">Mã Sản Phẩm:</label>
                <asp:TextBox ID="txtMaSP"  type="text" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
               <div class="div-ls"> <label for="ddlMaLoai">Loại:</label>
                <asp:DropDownList ID="ddlMaLoai" runat="server" CssClass="full-width" style=" text-align:center; width:225px !important; height:35px !important;">
                    <%--<asp:ListItem Text="Album" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Seasion Greeting" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Bluray / CD" Value="3"></asp:ListItem>
                    <asp:ListItem Text="MD" Value="4"></asp:ListItem>
                    <asp:ListItem Text="FM" Value="5"></asp:ListItem>--%>

                </asp:DropDownList></div>
                    <div class="div-ls"><label for="ddlMaLoai">Nhóm nhạc / Nghệ sĩ:</label>
    <asp:DropDownList ID="ddlMaNhom" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlMaNhom_SelectedIndexChanged" CssClass="full-width" style=" text-align:center; width:225px !important; height:35px !important;">
<%--        <asp:ListItem Text="Khác" Value="addNew"></asp:ListItem>--%>
<%--        <asp:ListItem Text="L" Value="2"></asp:ListItem>--%>
       
       
    </asp:DropDownList></div> 
                    
            
               
               <div class="div-ls fade-out"> 
    <label for="txtNgay">Ngày Sản Xuất:</label>
    <asp:TextBox ID="txtNgay" runat="server" onkeyup="formatDate(this)"  placeholder="dd/MM/yyyy" CssClass="full-width" style=" " ></asp:TextBox>
</div>
              
               

           </div>
                                                    
                                    <div class="d-grid">   
                                        <div class="div-ls fade-out"> 
                <label for="txtTenSP">Tên Sản Phẩm:</label>
                <asp:TextBox ID="txtTenSP"  type="text" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
                <div class="div-ls"><label for="txtGia">Giá:</label>
                <asp:TextBox ID="txtGia" runat="server"  TextMode="Number" CssClass="full-width"></asp:TextBox>
            </div>
                
                

                        <div class="div-ls fade-out">
    <asp:Label ID="lbNguonHang" runat="server" for="txtNguonHang" Text="Nguồn hàng:" style="color:#000;"></asp:Label>
    <asp:TextBox ID="txtNguonHang" runat="server" placeholder="" CssClass="full-width"></asp:TextBox>
</div>
   
                                     

                                      
                <div class="div-ls fade-out"> 
    <asp:Label ID="lbNgayHH" runat="server" for="txtNgayHH" style="color:#000;" Visible="false">Ngày Hết Hạn:</asp:Label>
    <asp:TextBox ID="txtNgayHH" runat="server" onkeyup="formatDate(this)"   placeholder="dd/MM/yyyy"  CssClass="full-width"  Visible="false" style=""></asp:TextBox>
</div>   

                </div>

                                    <div>
                                        <div class="div-ls fade-out">
                                                <asp:Label ID="lbSL" runat="server" for="txtSL" Text="Số Lượng:" style="color:#000;"></asp:Label>
                                                <asp:TextBox ID="txtSLKho" runat="server" placeholder="" type="number" TextMode="Number" CssClass="full-width"></asp:TextBox>
                                            </div>
                                        <div class="div-ls fade-out"> 
                                             <asp:Label ID="lbTenVerSP" Visible="false"  runat="server" style="color:#000;" Text="Tên Ver:" for="txtTenVerSP"></asp:Label>
    
                                             <asp:TextBox ID="txtTenVerSP" type="text"  Visible="false"   runat="server" CssClass="full-width"></asp:TextBox>
                                         </div>
                                          <div class="div-ls fade-out"> 
                                            <asp:Label ID="lbPopName" Visible="false"  for="txtPopName"  runat="server" Text="Pop:" style="color:#000;"></asp:Label>
                                            <asp:TextBox ID="txtPopName"  Visible="false"  type="text" runat="server" CssClass="full-width"></asp:TextBox>
                                        </div> 
                                                                                
                                    </div>
               
                </div>
                

            <div class="div-ls fade-out" style="">
                <label for="txtMoTa">Mô Tả:</label>
                <asp:TextBox ID="txtMoTa" runat="server" type="text" TextMode="MultiLine" CssClass="full-width" style="width:720.5px !important; height:6rem; text-align:left; padding:10px;"></asp:TextBox>

            </div>
           <div class="div-ls fade-out" style="margin-top:5rem;">

            <asp:FileUpload ID="fileImageMoTa" runat="server"  AllowMultiple="true"  onchange="previewImage(event)" style=" z-index:99; /*border:1px solid #000;*/ outline:none; color:#000;"/>
               </div>

                <div style="display:flex !important; gap:34px;">
                        <div class="d-flex fade-in">
                        <div class="div-ls">
    <asp:Label ID="lbNewMaNhom" CssClass="div-add-Lb" runat="server" for="txtNewMaNhom" Text="Mã nhóm:" style=""></asp:Label>
    <asp:TextBox ID="txtNewMaNhom" type="text"   runat="server"  CssClass="full-width" style="text-align:center; "></asp:TextBox>
</div>
                         <div class="div-ls  fade-in">
      <asp:Label ID="lbLG"  runat="server" for="fileUploadGPLogo" CssClass="div-add-Lb" style="display:grid; width:max-content; grid-gap:10px;" Text="Logo nhóm:"></asp:Label>
          <asp:FileUpload ID="fileUploadGPLogo" CssClass="div-add-input"  runat="server" onchange="previewImage(event)" style=" /*border:1px solid #000;*/ outline:none;"/>

</div>
            
                    </div>
                    <div class="d-flex fade-in">
                 <div class="div-ls">
    <asp:Label ID="lbnameGp" runat="server" CssClass="div-add-Lb" for="txtNewNhomName" Text="Tên nhóm / Nghệ sĩ:" style=""></asp:Label>
    <asp:TextBox ID="txtNewNhomName" type="text"  runat="server"  CssClass="full-width" style="text-align:center;" ></asp:TextBox>
</div>
                                            <div class="div-ls fade-in">
      <asp:Label ID="lbGpImage" runat="server" for="fileUploadGPmem" CssClass="div-add-Lb" style=" display:grid;  width:max-content; grid-gap:10px;" Text="Ảnh nhóm:"></asp:Label>
          <asp:FileUpload ID="fileUploadGPmem" runat="server" onchange="previewImage(event)" style=" /*border:1px solid #000;*/ outline:none;" CssClass="div-add-input"/>

</div>
                    </div>
                </div>


   <div class="div-ls">
            <label for="fileUpload" style="display:grid; width:max-content; grid-gap:10px;">Chọn Ảnh:</label>
            <input type="file"  id="fileUpload" name="fileUpload" multiple onchange="previewImages(event)" style="outline:none;"/>

   </div>

<style>
      #fileUpload {
          
          width:600px;
            color: white; /* Màu chữ màu trắng */
            
            padding: 10px; /* Lề nội bộ */
          
            cursor: pointer; /* Con trỏ chuột thành dấu chuột */
           
        }
</style>
                    <asp:HiddenField ID="hiddenSelectedImageName" runat="server" />
            <div class="d-flex" style="display:flex !important; gap:20px;">
<div id="mainImagePreview" style="width:600px; background-color:#242426; border:1px solid #242426; height:600px;display:flex; justify-content: center; align-items: center; position: relative;"></div>
<div id="imagePreviews" style="display:grid; background-color:#242426; width:120px; border:1px solid #242426; padding:0; margin:0;"></div>
</div>
<script>
    function previewImages(event) {
        var files = event.target.files;
        var imagePreviews = document.getElementById('imagePreviews');
        imagePreviews.innerHTML = ''; // Clear previous previews

        var mainImagePreview = document.getElementById('mainImagePreview');
        mainImagePreview.innerHTML = ''; // Clear main image preview

        var imageCount = 0; // Counter to track the number of images loaded

        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var reader = new FileReader();

            // Save the filename and extension before reading the file


            reader.onload = function (e) {
                var img = document.createElement('img');
                img.src = e.target.result;
                img.style.maxWidth = '100px';
                img.style.margin = '10px';
                img.style.display = 'block';
                img.style.objectFit = 'cover';
                img.style.maxHeight = '100px';
                img.style.backgroundColor = 'gray';
                img.onclick = function () {
                    // Clear main image preview
                    mainImagePreview.innerHTML = '';

                    // Create main image with checkbox
                    var mainImg = document.createElement('img');
                    mainImg.src = this.src;
                    mainImg.style.maxWidth = '600px';
                    mainImg.style.margin = '10px';
                    mainImg.style.display = 'block';
                    mainImg.style.objectFit = 'cover';
                    mainImg.style.maxHeight = '600px';
                    mainImg.style.backgroundColor = 'gray';
                    var filenameWithExtension = file.name;
                    // Use the saved filename and extension
                    var filenameWithExtensionString = filenameWithExtension;

                    // Set the combined string to the hidden input
                    document.getElementById('<%= hiddenSelectedImageName.ClientID %>').value = filenameWithExtensionString;

                    var container = document.createElement('div');
                    container.appendChild(mainImg);
                    mainImagePreview.appendChild(container);

                    // Move the clicked image to the beginning of imagePreviews
                    imagePreviews.insertBefore(this, imagePreviews.firstChild);
                };
                imagePreviews.appendChild(img);

                // Check if it's the first image loaded
                imageCount++;
                if (imageCount === 1) {
                    // Display the first image as the main image
                    img.onclick();
                }
            };

            reader.readAsDataURL(file);
        }
    }

</script>


               
                


</div>
    
        <div class="fade-in" style="">
    <asp:Button ID="btnAddProduct" runat="server" Text="THÊM SẢN PHẨM" OnClick="btnAddProduct_Click" CssClass="btnAddProduct"/>
    
</div>
</div>  

  
     <script>
         function previewImage(event) {
             var reader = new FileReader();
             reader.onload = function () {
                 var imagePreview = document.getElementById('imagePreview');
                 imagePreview.src = reader.result;
                 imagePreview.style.display = 'block';
             };
             reader.readAsDataURL(event.target.files[0]);
         }
     </script>

    </form>
</body>
</html>

