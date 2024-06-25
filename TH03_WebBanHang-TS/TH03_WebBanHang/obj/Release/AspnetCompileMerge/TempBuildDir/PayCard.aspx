<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="PayCard.aspx.cs" Inherits="TH03_WebBanHang.PayCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="fw-bolder mb-4 tenSP-ls-h3"><%--Related products--%> <p class="tenSP-ls-p">Thanh Toán Bằng Thẻ Tín Dụng</p></h2>
   
                             
                             <style>
        .tenSP-ls-h3 {
            padding-bottom: 1.5rem;
            text-align: center;
            font-weight: bolder;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #CCBEB1;
            width: 100%;
        }

        .tenSP-ls-p {
            width: max-content;
            padding: 8px;
            margin: auto;
            border-bottom-color: #000;
            border: 1px solid;
            border-top-style: none;
            border-left-style: none;
            border-right: none;
        }
      
   
        /* Tạo ra một phần CSS mới chỉ cho trang PayCard.aspx, không bị ảnh hưởng bởi các CSS trong Shop.master */
        .paycard-container {
            max-width: 40%;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #fff;
            display:flex;
            flex-wrap:wrap;
            text-align:left;
        }

        .paycard-form-group {
            margin:10px;
            display:inline-grid;
             

        }

        .paycard-label {
            display: block;
            margin-bottom: 5px;
        }

        .paycard-input-field {
            padding: 5px 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .paycard-btn {
            display: block;
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            background-color: #CCBEB1;
            color: #000;
            cursor: pointer;
        }

        .paycard-btn:hover {
            background-color: #9c9085;
        }
    </style>
                    
    <div class="paycard-container">
        
        <div class="paycard-form-group" style="width:max-content; text-align:center; ">
            <label for="amount" class="paycard-label" style="width:max-content; text-align:center;">Số Tiền Thanh Toán:</label>
<asp:TextBox runat="server" ID="amount" CssClass="paycard-input-field" style="width:12rem; text-align:right;" Placeholder="0đ" Required="true" ValidationGroup="paymentValidation" Pattern="\d{1,12}" Title="Please enter a valid amount" ReadOnly="true" maxlength="12"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="amount" ValidationGroup="paymentValidation" ErrorMessage="Please enter a valid amount"></asp:RequiredFieldValidator>
        </div>
        <div class="paycard-form-group" style="width:max-content; text-align:center;">
    <label for="cardUser" class="paycard-label" style="width:max-content; text-align:center;">Tên Chủ Thẻ:</label>
    <asp:TextBox runat="server" ID="cardUser" CssClass="paycard-input-field" style="width:max-content;" Placeholder="NGUYEN HOANG DUC" Required="true" ValidationGroup="paymentValidation" Title="Please enter your name" oninput="convertToUppercase(this)" maxlength="30"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="cardUser" ValidationGroup="paymentValidation" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>
</div>

<script>
    function convertToUppercase(input) {
        input.value = input.value.toUpperCase(); // Chuyển đổi tất cả ký tự thành chữ hoa
    }
</script>

        <div class="paycard-form-group" style="width:min-content; text-align:center; ">
            <label for="cardNumber" class="paycard-label"style="width:max-content; text-align:center;">Số Thẻ Tin Dụng:</label>
<asp:TextBox runat="server" ID="cardNumber" CssClass="paycard-input-field" style="width:12rem; text-align:center;" Placeholder="0000-0000-0000-0000" Required="true" ValidationGroup="paymentValidation" Title="Please enter a 16-digit card number" oninput="formatAndValidateCardNumber(this)" maxlength="19"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="cardNumber" ValidationGroup="paymentValidation" ErrorMessage="Please enter a 16-digit card number"></asp:RequiredFieldValidator>
        </div>
        
        <div class="paycard-form-group" style="width:10rem;" >
            <label for="cardExpiry" class="paycard-label" style="width:max-content; text-align:center;">Ngày Hết Hạn:</label>
<asp:TextBox runat="server" ID="cardExpiry" CssClass="paycard-input-field" style="width:6rem; text-align:center;" Placeholder="MM/YYYY" Required="true" ValidationGroup="paymentValidation" Pattern="^(0[1-9]|1[0-2])\/([0-9]{4}|[0-9]{2})$" Title="Please enter a valid MM/YYYY format" oninput="formatAndValidateExpiryDate(this)" maxlength="7"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="cardExpiry" ValidationGroup="paymentValidation" ErrorMessage="Please enter a valid MM/YYYY format"></asp:RequiredFieldValidator>
        </div>
        <div class="paycard-form-group" style="width:8rem; text-align:center;">
            <label for="cardCVC" class="paycard-label" style="width:max-content; text-align:center;">Mã CVC:</label>
<asp:TextBox runat="server" ID="cardCVC" CssClass="paycard-input-field" style="width:3rem;" Placeholder="000" Required="true" ValidationGroup="paymentValidation" Pattern="\d{3}" Title="Please enter a 3-digit CVC number" oninput="validateCVC(this)" maxlength="3"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="cardCVC" ValidationGroup="paymentValidation" ErrorMessage="Please enter a 3-digit CVC number"></asp:RequiredFieldValidator>
        </div>
        


        <asp:Button runat="server" ID="btnPay" Text="Thanh Toán" CssClass="paycard-btn" ValidationGroup="paymentValidation" OnClick="btnPay_Click"></asp:Button>
    </div>
    <script>
        function formatAndValidateCardNumber(input) {
            let cardNumber = input.value.replace(/\D/g, ''); // Remove non-numeric characters
            if (cardNumber.length > 16) {
                cardNumber = cardNumber.slice(0, 16);
            }
            cardNumber = cardNumber.replace(/(\d{4})(?=\d)/g, '$1-');
            input.value = cardNumber;
        }

        function formatAndValidateExpiryDate(input) {
            let expiryDate = input.value.replace(/\D/g, ''); // Remove non-numeric characters
            if (expiryDate.length > 6) {
                expiryDate = expiryDate.slice(0, 6);
            }
            if (expiryDate.length > 4) {
                expiryDate = expiryDate.slice(0, 2) + '/' + expiryDate.slice(2, 6);
            }
            input.value = expiryDate;
        }

        function validateCVC(input) {
            let cvc = input.value.replace(/\D/g, ''); // Remove non-numeric characters
            if (cvc.length > 3) {
                cvc = cvc.slice(0, 3);
            }
            input.value = cvc;
        }
    </script>
                            
</asp:Content>
