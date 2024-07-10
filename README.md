![K-Photoroom](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/5320b814-5f86-403e-b702-25815f2275e0)

---
# *English*
# KSTORE - K-Pop Album Trading Website

## Introduction

KSTORE is an online platform specializing in the trading of K-pop albums. This project aims to connect K-pop music enthusiasts with unique and rare products from around the world.

## Technology

- Programming Language: ASP.NET
- Database: SQL Server

## Objectives

- Create an easy-to-use platform for buyers and sellers.
- Provide a reputable environment for trading K-pop albums.
- Create opportunities for sellers to reach a wider audience of potential customers.

## Requirements

- A computer with Windows OS (as ASP.NET and SQL Server primarily support Windows).
- Git and .NET Core SDK (version 3.1 or higher) installed.
- SQL Server Management Studio (SSMS) or another SQL Server management tool to manage the database.

## Setup

### Update ConnectionString
1. Run the following two SQL files to set up the database:

   - `QL_KPOPStore.sql`
   - `newLocalVN.sql`
2. Update the ConnectionString as shown:
   ![Untitled](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/204d22b0-0951-4f69-8187-6defd9bf458f)
   ![222](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/50f61455-3490-4aa2-8bb6-2809b9dfd635)

### If the updated ConnectionString is not recognized or there are errors, reinstall and reconfigure
#### Database Setup

First, initialize the database:
1. Install SQL Server and SQL Server Management Studio (SSMS) from the official Microsoft website.
2. Run the following two SQL files to set up the database:

   - `QL_KPOPStore.sql`
   - `newLocalVN.sql`

#### Add Database to Project

1. Step 1

   ![Screenshot 2024-06-25 113723](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/52d06e36-eaae-433c-9538-9b1aab1c0eac)

2. Step 2

   ![Screenshot 2024-06-25 113743](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/ee5f12e0-ae81-407f-ac30-3954e384deb7)

3. Step 3

   ![Screenshot 2024-06-25 113852](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/e2b6f438-bf5d-4538-80ec-f9791db3152c)

4. Step 4

   ![Screenshot 2024-06-25 113927](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/3a928cbc-18db-4ae1-aab7-a157fc83fc31)

*These files will create the necessary tables and database structure for the KSTORE project.*

#### Update Models after Adding Database

1. TK.cs in Models
   ![Screenshot 2024-06-25 114131](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/2304db05-6435-4e87-aed2-33c2cc45e436)
2. KhachHang.cs in Models
   ![Screenshot 2024-06-25 114145](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/0f11534f-c06e-4954-b112-01758d27fb8a)
3. SanPham.cs in Models
   ![Screenshot 2024-06-25 114156](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/5223e26e-3e88-446e-ab99-6faeb8090dba)

## Running the Project

### Update the following parts before running

1. Shop.Master.cs
   ![Screenshot 2024-06-25 114248](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/9716de8f-43f6-4b38-b98d-eeba7d305bb4)
2. ChatBotController (Controllers/ChatBotController.cs)
   ![22222](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/54cafac8-a728-4abd-ba71-922ca47b34c0)

### And run the Project

## Project Installation

1. Clone the project repository from GitHub:

   ```bash
   git clone https://github.com/duccu2003/Nhom5_KStore.git
   ```

2. Navigate to the project directory:

   ```bash
   cd KSTORE
   ```

3. Install dependencies using npm:

   ```bash
   npm install
   ```

4. Start the application:

   ```bash
   npm start
   ```
*If the above methods do not work, you can manually download or contact our team.*

## Usage

After starting the application, you can access it at `http://localhost:<port>` (replace `<port>` with the port displayed in the console) to start using KSTORE.

## Contact

If you have any questions or feedback, feel free to contact us through any of the following channels:
- **Email**: `vippro11011@gmail.com`
- **Facebook**: [Đức Nguyễn](https://www.facebook.com/ducnguyenhoang2003)
- **Zalo**: [0389800308](zalo://talk/?number=0389800308)
- **Phone Number**: +84389800308 (0389800308)
- **Github**: [duccu2003](https://github.com/duccu2003), [Kumetiqn](https://github.com/Kumetiqn), [trnhatanh1211@gmail.com](https://github.com/trnhatanh1211@gmail.com)

*Our team is always ready to support and listen to your feedback!*

---
# *Vietnamese*
# KSTORE - Trang Web Buôn Bán Album K-Pop

## Giới thiệu

KSTORE là một nền tảng trực tuyến chuyên về buôn bán album K-pop. Dự án này nhằm mục đích kết nối người yêu thích âm nhạc Hàn Quốc với các sản phẩm độc đáo và hiếm có từ khắp nơi trên thế giới.

## Công nghệ

- Ngôn ngữ Lập Trình: ASP.NET
- Cơ sở Dữ Liệu: SQL Server

## Mục tiêu

- Tạo một nền tảng dễ dàng sử dụng cho người mua và người bán.
- Cung cấp một môi trường uy tín để trao đổi album K-pop.
- Tạo cơ hội cho người bán có thể tiếp cận rộng rãi hơn đối tượng khách hàng tiềm năng.

## Yêu cầu

- Có máy tính với hệ điều hành Windows (do ASP.NET và SQL Server chủ yếu hỗ trợ Windows).
- Có Git và.NET Core SDK (phiên bản 3.1 trở lên) đã được cài đặt.
- Có SQL Server Management Studio (SSMS) hoặc một công cụ quản lý SQL Server khác để quản lý cơ sở dữ liệu.

## Cài đặt

### Sửa lại ConnectionString
1. Chạy hai file SQL sau để thiết lập cơ sở dữ liệu:

   - `QL_KPOPStore.sql`
   - `newLocalVN.sql`
2. Sửa ConnectionString được khoanh
   ![Untitled](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/204d22b0-0951-4f69-8187-6defd9bf458f)
   ![222](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/50f61455-3490-4aa2-8bb6-2809b9dfd635)

### Nếu đổi rồi mà không nhận hoặc có lỗi thì tiến hành chạy và cài lại
#### Cài đặt Cơ sở Dữ liệu

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

   ![Screenshot 2024-06-25 113852](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/e2b6f438-bf5d-4538-80ec-f9791db3152c)

4. Bước 4

   ![Screenshot 2024-06-25 113927](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/3a928cbc-18db-4ae1-aab7-a157fc83fc31)

*Các file này sẽ tạo bảng và cấu trúc cơ sở dữ liệu cần thiết cho dự án KSTORE.*

#### Sửa lại Model sau khi thêm lại cơ sở dữ liệu

1. TK.cs trong Model
   ![Screenshot 2024-06-25 114131](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/2304db05-6435-4e87-aed2-33c2cc45e436)
2. KhachHang.cs trong Model
   ![Screenshot 2024-06-25 114145](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/0f11534f-c06e-4954-b112-01758d27fb8a)
3. SanPham.cs trong Model
   ![Screenshot 2024-06-25 114156](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/5223e26e-3e88-446e-ab99-6faeb8090dba)

## Cách chạy dự án

### Sửa lại những phần sau trước khi chạy

1. Shop.Master.cs
   ![Screenshot 2024-06-25 114248](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/9716de8f-43f6-4b38-b98d-eeba7d305bb4)
2. ChatBotController (Controllers/ChatBotController.cs)
   ![22222](https://github.com/duccu2003/Nhom5_KStore/assets/130604232/54cafac8-a728-4abd-ba71-922ca47b34c0)

### Và tiến hành chạy dự án

## Cách cài đặt Dự án

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

## Sử dụng

Sau khi khởi chạy ứng dụng, bạn có thể truy cập vào `http://localhost:<port>` (thay `<port>` bằng cổng được hiển thị trong console) để bắt đầu sử dụng KSTORE.

## Liên Hệ

Nếu bạn có bất kỳ câu hỏi hoặc góp ý, đừng ngần ngại liên hệ với chúng tôi qua một trong các kênh sau:
- **Email**: `vippro11011@gmail.com`
- **Facebook**: [Đức Nguyễn](https://www.facebook.com/ducnguyenhoang2003)
- **Zalo**: [0389800308](zalo://talk/?number=0389800308)
- **Số Điện Thoại**: +84389800308 (0389800308)
- **Github**: [duccu2003](https://github.com/duccu2003), [Kumetiqn](https://github.com/Kumetiqn), [trnhatanh1211@gmail.com](https://github.com/trnhatanh1211@gmail.com)

*Nhóm chúng tôi luôn sẵn lòng hỗ trợ và lắng nghe ý kiến từ các bạn!*

---
