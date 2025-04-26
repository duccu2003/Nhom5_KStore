---
# KSTORE - Trang Web Bán Album K-Pop

## 1. Giới thiệu

KSTORE là một nền tảng trực tuyến chuyên về buôn bán album K-pop. Dự án này nhằm mục đích kết nối người yêu thích âm nhạc Hàn Quốc với các sản phẩm độc đáo và hiếm có từ nền văn hóa K-Pop.

## 2. Công nghệ

- Ngôn ngữ Lập Trình: ASP.NET
- Cơ sở Dữ Liệu: SQL Server

## 3. Mục tiêu

- Tạo một nền tảng dễ dàng sử dụng cho người mua và người bán.
- Cung cấp một môi trường uy tín để trao đổi album K-pop.
- Tạo cơ hội cho người bán có thể tiếp cận rộng rãi hơn đối tượng khách hàng tiềm năng.

## 4. Yêu cầu

- Có máy tính với hệ điều hành Windows (do ASP.NET và SQL Server chủ yếu hỗ trợ Windows).
- Có Git và.NET Core SDK (phiên bản 3.1 trở lên) đã được cài đặt.
- Có SQL Server Management Studio (SSMS) hoặc một công cụ quản lý SQL Server khác để quản lý cơ sở dữ liệu.

## 5. Cách cài đặt Dự án

1. Clone kho lưu trữ dự án từ GitHub:

   ```bash
   git clone https://github.com/duccu2003/Nhom5_KStore.git
   ```

2. Navigated vào thư mục dự án:

   ```bash
   cd KSTORE
   ```

3. Cài đặt các gói phụ thuộc bằng npm:

   ```bash
   npm install
   ```

4. Khởi chạy ứng dụng:

   ```bash
   npm start
   ```
*Nếu không thể bằng những cách thức trên thì bạn có thể tải thủ công hoặc liên hệ đến nhóm chúng tôi.*

## 6. Cài đặt

### Sửa lại ConnectionString
1. Chạy hai file SQL sau để thiết lập cơ sở dữ liệu:

   - `QL_KPOPStore.sql`
   - `newLocalVN.sql`
### Nếu đổi rồi mà không nhận hoặc có lỗi thì tiến hành chạy và cài lại
### Nếu sau khi đổi ConnectionString mà vẫn không chạy thì mới áp dụng cách này
#### Cài đặt lại Cơ sở Dữ liệu

Trước tiên, bạn cần khởi tạo cơ sở dữ liệu:
1. Cài đặt SQL Server và SQL Server Management Studio (SSMS) từ trang web chính thức của Microsoft.
2. Chạy hai file SQL sau để thiết lập cơ sở dữ liệu:

   - `QL_KPOPStore.sql`
   - `newLocalVN.sql`

#### Thêm Cơ sở Dữ liệu vào Project

1. Bước 1

   ![Screenshot 2024-06-25 113723](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/52d06e36-eaae-433c-9538-9b1aab1c0eac)

2. Bước 2

   ![Screenshot 2024-06-25 113743](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/ee5f12e0-ae81-407f-ac30-3954e384deb7)

3. Bước 3

   ![Screenshot 2024-06-25 113927](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/3a928cbc-18db-4ae1-aab7-a157fc83fc31)

*Các file này sẽ tạo bảng và cấu trúc cơ sở dữ liệu cần thiết cho dự án KSTORE.*

#### Sửa lại Model sau khi thêm lại cơ sở dữ liệu

1. TK.cs trong Model
   ![Screenshot 2024-06-25 114131](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/2304db05-6435-4e87-aed2-33c2cc45e436)
2. KhachHang.cs trong Model
   ![Screenshot 2024-06-25 114145](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/0f11534f-c06e-4954-b112-01758d27fb8a)
3. SanPham.cs trong Model
   ![Screenshot 2024-06-25 114156](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/5223e26e-3e88-446e-ab99-6faeb8090dba)

## 7. Cách chạy dự án

### Sửa lại những phần sau trước khi chạy

1. Shop.Master.cs
   ![image](https://github.com/user-attachments/assets/59ffc732-e82c-4a8f-a8e7-d35f03c46fa3)

### Và tiến hành chạy dự án

## 8. Sử dụng

Sau khi khởi chạy ứng dụng, bạn có thể truy cập vào `http://localhost:<port>` (thay `<port>` bằng cổng được hiển thị trong console) để bắt đầu sử dụng KSTORE.

---
