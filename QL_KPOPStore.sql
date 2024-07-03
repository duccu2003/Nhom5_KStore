create database QL_KPOPStore
go

--use master
--go
--drop database Shop
--go

use QL_KPOPStore
go
CREATE TABLE TK
(
	MaTK INT IDENTITY(1,1) PRIMARY KEY , 
    MatKhau VARCHAR(50) collate Latin1_General_CI_AS  NULL, 
   
    Email VARCHAR(50) collate Latin1_General_CI_AS NULL,
	Quyen NVARCHAR(50) Null,
)
GO


create table Loai
(
	MaLoai varchar(100) not null,
	TenLoai varchar(50) not null,

	constraint PK_Loai primary key (MaLoai),
)
go
create table Nhom
(
	MaNhom varchar(100) not null,
	TenNhom varchar(50) not null,
	DuongDan nvarchar(Max) not null,
	AnhNhom nvarchar(100) null,
	constraint PK_Size primary key (MaNhom),
)
go

CREATE TABLE POB
(	
	MaPob varchar(50) NOT NULL,
	TenPob nvarchar(50) NOT NULL,
	MaSP varchar(50) NOT NULL,
)
GO

CREATE TABLE SanPhamData
(
    MaSP varchar(50) NOT NULL,
    DuongDan1 nvarchar(Max) NULL,
    DuongDan2 nvarchar(Max) NULL,
    DuongDan3 nvarchar(Max) NULL,
    DuongDan4 nvarchar(Max) NULL,
    DuongDan5 nvarchar(Max) NULL,
	AnhNote nvarchar(Max) NULL,
	--Pop bit NOT NULL DEFAULT 0
	Pob bit

	
);
GO
ALTER TABLE SanPhamData
ADD IsPreOrder bit ; -- 0 là false, 1 là true
GO

CREATE TABLE SanPham
(
    MaSP varchar(50) NOT NULL,
    TenSP nvarchar(50) NOT NULL,
    DuongDan nvarchar(Max) NOT NULL,
    Gia float NOT NULL,
    MoTa nvarchar(255) NOT NULL,
    MaLoai varchar(100) NOT NULL,
    MaNhom varchar(100) NOT NULL,
    NgaySX datetime NULL,
	NgayHH datetime NULL,
    NgayNhap datetime NULL,
    DoanhSo int NULL,
    SoLuongKho int NULL,
	Ver varchar(50) NULL,
	TenVer varchar(50) NULL,
	NguonHang nvarchar(50) NULL,
	--NguonHang nvarchar(50) NULL,
    CONSTRAINT PK_SANPHAM PRIMARY KEY (MaSP),
    CONSTRAINT FK_SanPham_Loai FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai),
    CONSTRAINT FK_SanPham_Size FOREIGN KEY (MaNhom) REFERENCES Nhom(MaNhom)
);
GO
--ALTER TABLE SanPhamData
--ADD CONSTRAINT FK_SanPhamData_SanPham PRIMARY KEY(MaSP)

--ALTER TABLE SanPhamData
--ADD CONSTRAINT FK_SanPhamData_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);
ALTER TABLE SanPhamData
ADD CONSTRAINT FK_SanPhamData_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE;

GO


create table KhachHang
(
	MaTK INT,
	AvatarUser varchar(Max) null,

    MaKH INT IDENTITY(1,1),
    HoTen NVARCHAR(255) NULL,
    DienThoai NVARCHAR(13) NULL,
    GioiTinh NVARCHAR(10) NULL,
    DiaChi NVARCHAR(255) NULL,
    Email VARCHAR(100) collate Latin1_General_CI_AS  NULL,
    MatKhau VARCHAR(50) collate Latin1_General_CI_AS  NULL,
	Diem int null,
    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH),
    CONSTRAINT FK_KhachHang_TK FOREIGN KEY (MaTK) REFERENCES TK(MaTK)
)
go

create table DonHang
(
	MaTK INT,
    MaDH VARCHAR(10) NOT NULL,
    KH INT,
	HoTenNN NVARCHAR(255) NULL,
	DiaChiNN NVARCHAR(255) NULL,
	DienThoaiNN NVARCHAR(13) NULL,
	PhuongThuc NVARCHAR(50) NULL,
    Ngay DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT PK_GioHang PRIMARY KEY (MaDH),
    CONSTRAINT FK_DonHang_TK FOREIGN KEY (MaTK) REFERENCES TK(MaTK),
	    FOREIGN KEY (KH) REFERENCES KhachHang(MaKH)

)
go
CREATE TABLE DanhGia
(
	AvatarUser varchar(max) null,
    MaDG int IDENTITY(1,1) NOT NULL, -- ID duy nhất cho mỗi bình luận
    MaSP varchar(50) NOT NULL, -- Mã sản phẩm
    TenKH nvarchar(50) NULL, -- Tên khách hàng
	DienThoai NVARCHAR(13) NULL,
    NoiDung nvarchar(Max) NULL, -- Nội dung bình luận
    NgayDG datetime NULL, -- Ngày bình luận
	RatingValue INT CHECK (RatingValue >= 1 AND RatingValue <= 5),
	Anh1 nvarchar(Max) NULL,
	Anh2 nvarchar(Max) NULL,
	Anh3 nvarchar(Max) NULL,
	Anh4 nvarchar(Max) NULL,
	Anh5 nvarchar(Max) NULL,
	Video nvarchar(Max) NULL,
	Email VARCHAR(100) NULL,
	LuotThich INT DEFAULT 0,
    CONSTRAINT PK_DanhGia PRIMARY KEY (MaDG),
    CONSTRAINT FK_DanhGia_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO
ALTER TABLE DanhGia
DROP CONSTRAINT FK_DanhGia_SanPham; -- Xóa constraint hiện tại

ALTER TABLE DanhGia
ADD CONSTRAINT FK_DanhGia_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE;
GO

CREATE TABLE ThichSP
(
    MaSP varchar(50) NOT NULL,
    MaKH INT NOT NULL,
	Email VARCHAR(100) NULL,
	DienThoai NVARCHAR(13) NULL,
    DaThich BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_Thich PRIMARY KEY (MaSP, MaKH),
    CONSTRAINT FK_Thich_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE,
    CONSTRAINT FK_Thich_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE
);


--CREATE TABLE DanhGiaData
--(
--    MaDG int NOT NULL,
--	Thich int null,
--	MaKH INT,
	
--    CONSTRAINT PK_DanhGiaData PRIMARY KEY (MaDG),
--    CONSTRAINT FK_DanhGiaData_DanhGia FOREIGN KEY (MaDG) REFERENCES DanhGia(MaDG) ON DELETE CASCADE,
--    CONSTRAINT FK_MAKH_DanhGiaData_DanhGia FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE

--);
--GO

create table ChiTietDonHang
(
	KH INT,
	MaCTDH varchar(10) not null,
	MaDH varchar(10) not null,
	MaSP varchar(50) not null,
	SoLuong integer not null,
	TenSP nvarchar(50) not null,
	DuongDan nvarchar(Max) not null,
	Gia float not null,
	TenPob nvarchar(50) NULL,
	ThanhTien float not null,
	Ngay datetime not null default CURRENT_TIMESTAMP,
	constraint PK_ChiTietDonHang primary key (MaCTDH),
	 FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
go

CREATE TABLE ChiNhanh
(
    MaCN varchar(10) PRIMARY KEY,
    TenCN nvarchar(50) NOT NULL,
    DiaChiCN nvarchar(255) NOT NULL
)
go

CREATE TABLE TinTuc
(
    MaBV INT IDENTITY(1,1),
    HinhAnhBV nvarchar(Max) NULL,
    DuongDanBV varchar(Max) NULL,
    TieuDe nvarchar(Max) NULL,
    NoiDungBV nvarchar(Max) Null,
	NgayDangBV DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
    
);
GO

CREATE TABLE VideoThongTin
(
    MaV INT IDENTITY(1,1),  
    DuongDanV nvarchar(Max) NULL,
	NgayDangBV DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
    
);
GO
CREATE TABLE Banner
(
    MaBanner INT IDENTITY(0,1),
	TieuDe nvarchar(Max) NULL,
    DuongDan nvarchar(Max) NULL,
	NgayDangBV DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
    
);
GO
CREATE TABLE DoanhThu
(	Ma INT IDENTITY(1,1),  
	--MaDH varchar(10) null,
	Ngay INT NOT NULL,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    DoanhThuNgay FLOAT NOT NULL DEFAULT 0.0,
	 PRIMARY KEY (Ma)
    
);
go

-- foreign key

alter table SanPham 
add constraint FK_SP_Loai foreign key (MaLoai) references Loai(MaLoai)
go
alter table SanPham 
add constraint FK_SP_Size foreign key (MaNhom) references Nhom(MaNhom)
go
--alter table ChiTietDonHang
--add constraint FK_GH_SP foreign key (MaSP) references SanPham(MaSP)
--go
alter table ChiTietDonHang
add constraint FK_GH_SP foreign key (MaSP) references SanPham(MaSP) ON DELETE NO ACTION;
go
alter table ChiTietDonHang
add constraint FK_CTDH_DH foreign key (MaDH) references DonHang(MaDH)
go

--alter table DonHang
--add constraint FK_GH_KH foreign key (MaKH) references KhachHang(MaKH)
--go
ALTER TABLE DonHang
ADD MaCN varchar(10) NOT NULL
go
ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_ChiNhanh FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
go
ALTER TABLE KhachHang
ADD TrangThai bit;
go
ALTER TABLE TK
ADD TrangThai bit;
go
ALTER TABLE ChiTietDonHang
ADD GiaoDich bit;
go
insert into Loai
values
('1','Album'),
('2','Merch'),
('3','Fankit'),
('4','Light Stick'),
('5','Seasons Greetings'),
('6','DVD/Blu-ray/LP')
go

INSERT INTO Nhom VALUES
('AESPA', 'AESPA', 'Content/icon-group-kpop/aespa.png','Content/image-group-kpop/aespa.png'),
('BP', 'BLACKPINK', 'Content/icon-group-kpop/blackpink.png','Content/image-group-kpop/blackpink.png'),
('BTS', 'BTS', 'Content/icon-group-kpop/bts.png','Content/image-group-kpop/bts.png'),
('ITZY', 'ITZY', 'Content/icon-group-kpop/itzy.png','Content/image-group-kpop/itzy.png'),
('IU', 'IU', 'Content/icon-group-kpop/iu.png','Content/image-group-kpop/iu.png'),
('IVE', 'IVE', 'Content/icon-group-kpop/ive.png','Content/image-group-kpop/ive.png'),
('KP1', 'KEP1ER', 'Content/icon-group-kpop/kep1er.png','Content/image-group-kpop/kep1er.png'),
('LSER', 'LE SSERAFIM', 'Content/icon-group-kpop/le sserafim.png','Content/image-group-kpop/le sserafim.png'),
('NJ', 'NEWJEANS', 'Content/icon-group-kpop/newjeans.png','Content/image-group-kpop/newjeans.png'),
('NMX', 'NMIXX', 'Content/icon-group-kpop/nmixx.png','Content/image-group-kpop/nmixx.png'),
('ILLIT', 'ILLIT', 'Content/icon-group-kpop/illit.png','Content/image-group-kpop/illit.png'),
('SOMI', 'JEON SOMI', 'Content/icon-group-kpop/somi.png','Content/image-group-kpop/somi.png'),
('TPST', 'TEMPEST', 'Content/icon-group-kpop/tempest.png','Content/image-group-kpop/tempest.png'),
('TWC', 'TWICE', 'Content/icon-group-kpop/twice.png','Content/image-group-kpop/twice.png')

go

set dateformat dmy
insert into SanPham
values

('ASPALBBTTBouquetVer',N'Aespa Album Bouquet Ver','Content/items/aespa/album/BouquetVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004',null,'13/04/2004',0,50,'ASPALBBTT','Bouquet Ver','Ktown4u'),
('ASPALBBTTKarinaVer',N'Aespa Album Karina Ver','Content/items/aespa/album/KARINAVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004',null,'13/04/2004',0,50,'ASPALBBTT','Karina Ver','Ktown4u'),
('ASPALBBTTWinterVer',N'Aespa Album Winter Ver','Content/items/aespa/album/WINTERVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004',null,'13/04/2004',0,50,'ASPALBBTT','Winter Ver','Ktown4u'),
('ASPALBBTTNingningVer',N'Aespa Album Ningning Ver','Content/items/aespa/album/NINGNINGVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004',null,'13/04/2004',0,50,'ASPALBBTT','Ningning Ver','Ktown4u'),
('ASPALBBTTGiselleVer',N'Aespa Album Giselle Ver','Content/items/aespa/album/GISELLEVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004',null,'13/04/2004',0,50,'ASPALBBTT','Giselle Ver','Ktown4u'),
('IUALBLP',N'IU Album Love Poem','Content/items/iu/album/albLovePoem.png',200000,N'Album Love Poem','1','IU','13/04/2004',null,'13/04/2004',0,50,'IUALBLP',null,'Ktown4u'),
('IU29Doc',N'IU Documentary Pieces','Content/items/iu/dvdbluraylp/29th.png',1600000,N'Winter of 29th Year Old','6','IU','13/04/2004',null,'13/04/2004',0,50,'IU29Doc',null,'Ktown4u'),
('BTSALBprf',N'BTS Album Proof','Content/items/bts/album/proof.png',1200000,N'Album Proof','1','BTS','13/04/2004',null,'13/04/2004',0,50,'BTSALBprf',null,'Ktown4u'),
('ILITReal1',N'ILLIT Album Super Real','Content/items/illit/album/spReal.png',420000,N'Album Super Real','1','ILLIT','13/04/2004',null,'13/04/2004',0,50,'ILITReal1',null,'Ktown4u')

go

insert into SanPhamData
values
('ASPALBBTTBouquetVer','Content/items/aespa/album/BouquetVer_750x.png','','','','','',0,0),
('ASPALBBTTKarinaVer','Content/items/aespa/album/KARINAVer_750x.png','','','','','',0,0),
('ASPALBBTTWinterVer','Content/items/aespa/album/WINTERVer_750x.png','','','','','',0,0),
('ASPALBBTTNingningVer','Content/items/aespa/album/NINGNINGVer_750x.png','','','','','',0,0),
('ASPALBBTTGiselleVer','Content/items/aespa/album/GISELLEVer_750x.png','','','','','',0,0),
('IUALBLP','Content/items/iu/album/albLovePoem.png','Content/items/iu/album/albLovePoem1.png','','','','Content/items/iu/album/AnhALBLovePoem.png',0,0),
('IU29Doc','Content/items/iu/dvdbluraylp/29th.png','Content/items/iu/dvdbluraylp/29th1.png','Content/items/iu/dvdbluraylp/29th2.png','Content/items/iu/dvdbluraylp/29th3.png','','',0,0),
('BTSALBprf','Content/items/bts/album/proof.png','Content/items/bts/album/proof1.png','','','','Content/items/bts/album/AnhALBProofNote.jpg',0,0),
('ILITReal1','Content/items/illit/album/spReal.png','Content/items/illit/album/spReal1.png','','','','',0,0)

go
INSERT INTO ChiNhanh (MaCN, TenCN, DiaChiCN) 
VALUES 
    ('CN1', N'Hà Nội', N'Số 4B Phố Hàng Bài, P. Tràng Tiền, Q. Hoàn Kiếm, Hà Nội'),
    ('CN2', N'Hồ Chí Minh', N'Số 172 Đường Số 1 Q.Bình Tân');  

go
INSERT INTO TK(Email, MatKhau,TrangThai,Quyen) 
VALUES 
    ('Admin', 'Admin', 0,'Admin');
   

go

INSERT INTO TinTuc (HinhAnhBV, DuongDanBV, TieuDe, NoiDungBV)
VALUES ('https://images2.thanhnien.vn/528068263637045248/2024/4/8/boadongthaigiainghe3-1712617508236587635258.jpg', 'https://thanhnien.vn/dong-thai-cua-nu-hoang-kpop-boa-sau-khi-up-mo-giai-nghe-som-185240409061553758.htm', N'Động thái của "nữ hoàng Kpop" BoA sau khi úp mở giải nghệ sớm', N'Trên trang cá nhân, BoA trấn an người hâm mộ sau khi chia sẻ những trạng thái úp mở sắp rời khỏi showbiz.'),
		('https://media-cdn-v2.laodong.vn/storage/newsportal/2024/3/4/1311231/Hanni-Chaumet-8.jpg?w=800&h=420&crop=auto&scale=both', 'https://laodong.vn/thoi-trang/hanni-newjeans-gay-an-tuong-voi-bo-anh-hoa-bao-cung-trang-suc-xa-xi-1311231.ldo', N'Hanni (NewJeans) gây ấn tượng với bộ ảnh hoạ báo cùng trang sức xa xỉ', N'Hanni chưng diện bộ sưu tập Joséphine của thương hiệu trang sức xa xỉ Chaumet, thể hiện thần thái tự tin, quyến rũ và trưởng thành.'),
		('https://kenh14cdn.com/203336854389633024/2024/6/5/mv5bnzqznzvizdctzguwzi00zme5ltk4zjgtzja1zjg5ymriogq4xkeyxkfqcgdeqxvyndy5mjmyntgv1-0917-17175554430311730617564.jpg', 'https://kenh14.vn/nhom-nhac-5-lan-7-luot-bi-dem-ra-lam-bia-do-dan-moi-khi-cong-ty-vuong-scandal-20240605094445235.chn', N'Nhóm nhạc 5 lần 7 lượt bị đem ra làm "bia đỡ đạn" mỗi khi công ty vướng scandal', N'Không biết vô tình hay cố ý mà mỗi lần nhóm nhạc này được thông báo comeback là lúc công ty đang xảy ra biến động.'),
		('https://kenh14cdn.com/203336854389633024/2024/4/8/chrome-capture-2024-2-29-17125713432341764253845.gif', 'https://kenh14.vn/hybe-lai-ap-dung-cong-thuc-thao-tung-nhac-so-cua-newjeans-cho-nhom-nhac-dan-em-20240408171856713.chn', N'HYBE lại áp dụng công thức "thao túng" nhạc số của NewJeans cho nhóm nhạc đàn em?', N'Tranh cãi về thành tích nhạc số của tân binh HYBE hiện đang nổ ra trên các trang cộng đồng.');
go

INSERT INTO VideoThongTin (DuongDanV)
VALUES	('https://www.youtube.com/embed/if0we38Hbyk?si=WNpzGXpbqMuT6kOH'),
		('https://www.youtube.com/embed/nXzD9vXtscs?si=TDrhRrmd7wm6gbrT'),
		('https://www.youtube.com/embed/VFm6ztzZ188?si=3V4l6e2bZX284Y9D');

go
INSERT INTO Banner(TieuDe,DuongDan)
VALUES	('KStore','Content\image-banner\banner1.1.png'),
		('Aespa Better Things','Content\image-banner\banner2.png'),
		('ILLIT New Album Coming','Content\image-banner\banner3.png'),
		('2024 Christmas Sale','Content\image-banner\banner4.png');

go
CREATE PROCEDURE Product_Add 
    @MaSP varchar(50), 
    @TenSP nvarchar(50), 
    @DuongDan nvarchar(Max), 
    @Gia float, 
    @MoTa nvarchar(255), 
    @MaLoai varchar(100),
    @MaNhom varchar(100),
    @NgaySX datetime,
	@NgayHH datetime,-- Thêm tham số này
    @NgayNhap datetime, -- Thêm tham số này
    @DoanhSo int, -- Thêm tham số này
    @SoLuongKho int,
	@Ver varchar(50),
	@TenVer varchar(50),
	@NguonHang nvarchar(50)
AS
BEGIN
    INSERT INTO [dbo].[SanPham]
               ([MaSP]
               ,[TenSP]
               ,[DuongDan]
               ,[Gia]
               ,[MoTa]
               ,[MaLoai]
               ,[MaNhom]
               ,[NgaySX]
			   ,[NgayHH]-- Thêm cột này vào INSERT
               ,[NgayNhap] -- Thêm cột này vào INSERT
               ,[DoanhSo] -- Thêm cột này vào INSERT
               ,[SoLuongKho]
			   ,[Ver]
			   ,[TenVer]
			   ,[NguonHang]) -- Thêm cột này vào INSERT
    VALUES 
     ( @MaSP,
      @TenSP,
      @DuongDan,
      @Gia,
      @MoTa,
      @MaLoai,
      @MaNhom,
      @NgaySX,
	  @NgayHH,-- Thêm giá trị này vào VALUES
      @NgayNhap, -- Thêm giá trị này vào VALUES
      @DoanhSo, -- Thêm giá trị này vào VALUES
      @SoLuongKho,
	  @Ver,
	  @TenVer,
	  @NguonHang) -- Thêm giá trị này vào VALUES
END
GO


CREATE PROCEDURE ProductData_Add 
    @MaSP varchar(50), 
    @DuongDan1 nvarchar(Max), 
    @DuongDan2 nvarchar(Max), 
    @DuongDan3 nvarchar(Max), 
    @DuongDan4 nvarchar(Max), 
    @DuongDan5 nvarchar(Max),
    @AnhNote nvarchar(Max),
	@Pob bit = 0,
	
	@IsPreOrder bit = 0
AS
BEGIN
    INSERT INTO [dbo].[SanPhamData]
           ([MaSP]
           ,[DuongDan1]
           ,[DuongDan2]
           ,[DuongDan3]
           ,[DuongDan4]
           ,[DuongDan5]
           ,[AnhNote]
		   ,[Pob]
		   ,[IsPreOrder])
    VALUES 
    ( @MaSP,
      @DuongDan1,
      @DuongDan2,
      @DuongDan3,
      @DuongDan4,
      @DuongDan5,
      @AnhNote,
	  @Pob,
	  @IsPreOrder)
END;
GO


 CREATE PROCEDURE splogin 
    @MaTK VARCHAR(100),
    @matkhau VARCHAR(100)
AS
BEGIN
    SELECT MaTK, matkhau 
    FROM TK 
    WHERE MaTK = @MaTK AND MatKhau = @matkhau
END
GO
 CREATE PROCEDURE GetOrderRevenueByBranch
    @MaCN VARCHAR(10) -- Declare the variable here
AS
BEGIN
    SELECT 
        CN.TenCN AS TenChiNhanh,
        DH.MaDH,
        DH.Ngay,
        SUM(CTDH.ThanhTien) AS TongDoanhThu
    FROM 
        DonHang DH
    INNER JOIN 
        ChiNhanh CN ON DH.MaCN = CN.MaCN
    INNER JOIN 
        ChiTietDonHang CTDH ON DH.MaDH = CTDH.MaDH
    WHERE 
        CN.MaCN = @MaCN
    GROUP BY 
        CN.TenCN, DH.MaDH, DH.Ngay

END
GO
CREATE PROCEDURE DeleteSanPhamData
    @ID INT
AS
BEGIN
    DELETE FROM SanPhamData WHERE MaSP = @ID
END
GO

--CREATE TRIGGER SyncTrangThai_KhachHang_TK
--ON TK
--AFTER UPDATE
--AS
--BEGIN
--    IF UPDATE(TrangThai)
--    BEGIN
--        DECLARE @NewTrangThai bit;
--        SELECT @NewTrangThai = TrangThai FROM inserted;

--        -- Update TrangThai column in TK table to match KhachHang table
--        UPDATE KhachHang
--        SET TrangThai = @NewTrangThai;
--    END
--END;
DECLARE @Year INT; 
SELECT 
    MONTH(ChiTietDonHang.Ngay) AS Month,
    SUM(ChiTietDonHang.ThanhTien) AS MonthlyRevenue
FROM
    ChiTietDonHang
INNER JOIN 
    SanPham ON ChiTietDonHang.MaSP = SanPham.MaSP
WHERE 
    YEAR(Ngay) = @Year
GROUP BY 
    MONTH(Ngay)
ORDER BY 
    MONTH(Ngay)

go

--CREATE PROCEDURE CapNhatDoanhThu
--AS
--BEGIN
--    -- Tính tổng doanh thu của tháng hiện tại
--    DECLARE @TongDoanhThu FLOAT;
--    SELECT @TongDoanhThu = SUM(ThanhTien)
--    FROM ChiTietDonHang
--    WHERE GiaoDich = 1 AND MONTH(Ngay) = MONTH(GETDATE())
--    GROUP BY MONTH(Ngay);

--    -- Cập nhật tổng doanh thu của tháng hiện tại
--    UPDATE DoanhThu
--    SET TongDoanhThu = TongDoanhThu + @TongDoanhThu
--    WHERE Thang = MONTH(GETDATE()) AND Nam = YEAR(GETDATE());

--    -- Tính tổng doanh thu của năm hiện tại
--    SELECT @TongDoanhThu = SUM(TongDoanhThu)
--    FROM DoanhThu
--    WHERE Nam = YEAR(GETDATE());

--    -- Cập nhật tổng doanh thu của năm hiện tại
--    UPDATE DoanhThu
--    SET TongDoanhThu = TongDoanhThu + @TongDoanhThu
--    WHERE Nam = YEAR(GETDATE());
--END;

--go
--CREATE TRIGGER trg_ChiTietDonHang_Insert
--ON ChiTietDonHang
--AFTER INSERT
--AS
--BEGIN
--    EXEC CapNhatDoanhThu;
--END;

