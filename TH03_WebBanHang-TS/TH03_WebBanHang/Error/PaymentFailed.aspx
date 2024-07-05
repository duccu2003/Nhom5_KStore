<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentFailed.aspx.cs" Inherits="TH03_WebBanHang.Error.PaymentFailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KStore</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css" rel="stylesheet" />
<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
<style>
._failed{ border-bottom: solid 4px red !important; }
._failed i{  color:red !important;  }

._success {
    box-shadow: 0 15px 25px #00000019;
    padding: 45px;
    width: 100%;
    text-align: center;
    margin: 40px auto;
    border-bottom: solid 4px #28a745;
}

._success i {
    font-size: 55px;
    color: #28a745;
}

._success h2 {
    margin-bottom: 12px;
    font-size: 40px;
    font-weight: 500;
    line-height: 1.2;
    margin-top: 10px;
}

._success a {
    margin-bottom: 0px;
    font-size: 18px;
    color: #495057;
    font-weight: 500;
}
</style>
</head>
<body>
     <div class="row justify-content-center align-content-center mt-5">
            <div class="col-md-5">
                <div class="message-box _success _failed">
                     <i class="fa fa-times-circle" aria-hidden="true"></i>
                    <h2> Đơn hàng của bạn bị từ chối </h2>
<<<<<<< HEAD
             <a href="../Cart">  Thử lại lần nữa </a> 
=======
             <a href="../Pay">  Thử lại lần nữa </a> 
>>>>>>> e3ec5bf4e729124a365c85464cae3c7eb1532498
         
            </div> 
        </div> 
    </div> 
  

</body>
</html>
