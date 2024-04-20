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
    MatKhau NVARCHAR(50) NULL, 
   
    Email NVARCHAR(50) NULL,
	Quyen NVARCHAR(50) Null,
)
GO


create table Loai
(
	MaLoai varchar(10) not null,
	TenLoai varchar(50) not null,

	constraint PK_Loai primary key (MaLoai),
)
go
create table Nhom
(
	MaNhom varchar(10) not null,
	TenNhom varchar(50) not null,
	DuongDan varchar(100) not null,
	AnhNhom varchar(100) null,
	constraint PK_Size primary key (MaNhom),
)
go
CREATE TABLE SanPhamData
(
    MaSP varchar(10) NOT NULL,
    DuongDan1 varchar(100) NULL,
    DuongDan2 varchar(100) NULL,
    DuongDan3 varchar(100) NULL,
    DuongDan4 varchar(100) NULL,
    DuongDan5 varchar(100) NULL,
	AnhNote varchar(100) NULL
);
GO

CREATE TABLE SanPham
(
    MaSP varchar(10) NOT NULL,
    TenSP nvarchar(50) NOT NULL,
    DuongDan varchar(100) NOT NULL,
    Gia float NOT NULL,
    MoTa nvarchar(255) NOT NULL,
    MaLoai varchar(10) NOT NULL,
    MaNhom varchar(10) NOT NULL,
    NgaySX datetime NULL,
    NgayNhap datetime NULL,
    DoanhSo int NULL,
    SoLuongKho int NULL,
    CONSTRAINT PK_SANPHAM PRIMARY KEY (MaSP),
    CONSTRAINT FK_SanPham_Loai FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai),
    CONSTRAINT FK_SanPham_Size FOREIGN KEY (MaNhom) REFERENCES Nhom(MaNhom)
);
GO

ALTER TABLE SanPhamData
ADD CONSTRAINT FK_SanPhamData_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);
GO


create table KhachHang
(
	MaTK INT,
	AvatarUser varchar(100) null,

    MaKH INT IDENTITY(1,1),
    HoTen NVARCHAR(255) NULL,
    DienThoai NVARCHAR(13) NULL,
    GioiTinh NVARCHAR(10) NULL,
    DiaChi NVARCHAR(255) NULL,
    Email VARCHAR(100) NULL,
    MatKhau VARCHAR(50) NULL,
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
    Ngay DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT PK_GioHang PRIMARY KEY (MaDH),
    CONSTRAINT FK_DonHang_TK FOREIGN KEY (MaTK) REFERENCES TK(MaTK),
	    FOREIGN KEY (KH) REFERENCES KhachHang(MaKH)

)
go

create table ChiTietDonHang
(
	KH INT,
	MaCTDH varchar(10) not null,
	MaDH varchar(10) not null,
	MaSP varchar(10) not null,
	SoLuong integer not null,
	TenSP nvarchar(50) not null,
	DuongDan varchar(100) not null,
	Gia float not null,
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
-- foreign key

alter table SanPham 
add constraint FK_SP_Loai foreign key (MaLoai) references Loai(MaLoai)
go
alter table SanPham 
add constraint FK_SP_Size foreign key (MaNhom) references Nhom(MaNhom)
go
alter table ChiTietDonHang
add constraint FK_GH_SP foreign key (MaSP) references SanPham(MaSP)
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
('1','ALB'),
('2','SSG'),
('3','Bluray&CD'),
('4','MD'),
('5','FM')
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

('ASPALB01',N'Aespa Album Bouquet Ver','Content/items/aespa/alb/BouquetVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
('ASPALB02',N'Aespa Album Karina Ver','Content/items/aespa/alb/KARINAVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
('ASPALB03',N'Aespa Album Winter Ver','Content/items/aespa/alb/WINTERVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
('ASPALB04',N'Aespa Album Ningning Ver','Content/items/aespa/alb/NINGNINGVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
('ASPALB05',N'Aespa Album Giselle Ver','Content/items/aespa/alb/GISELLEVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
('IUALBLP',N'IU Album Love Poem','Content/items/iu/alb/albLovePoem.png',200000,N'Album Love Poem','1','IU','13/04/2004','13/04/2004',0,50),
('IU29Doc',N'IU Documentary Pieces','Content/items/iu/md/29th.png',1600000,N'Winter of 29th Year Old','4','IU','13/04/2004','13/04/2004',0,50),
('BTSALBprf',N'BTS Album Proof','Content/items/bts/alb/proof.png',1200000,N'Album Proof','1','BTS','13/04/2004','13/04/2004',0,50),
('ILITReal1',N'ILLIT Album Super Real','Content/items/illit/alb/spReal.png',420000,N'Album Super Real','1','ILLIT','13/04/2004','13/04/2004',0,50)

--('ASPALB01',N'Aespa Album Bouquet Ver','Content/items/aespa/alb/BouquetVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
--('ASPALB02',N'Aespa Album Karina Ver','Content/items/aespa/alb/KARINAVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
--('ASPALB03',N'Aespa Album Winter Ver','Content/items/aespa/alb/WINTERVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
--('ASPALB04',N'Aespa Album Ningning Ver','Content/items/aespa/alb/NINGNINGVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
--('ASPALB05',N'Aespa Album Giselle Ver','Content/items/aespa/alb/GISELLEVer_750x.png',300000,N'Album Bouquet Ver','1','AESPA','13/04/2004','13/04/2004',0,50),
--('IUALBLP',N'IU Album Love Poem','Content/items/iu/alb/albLovePoem.png',200000,N'Album Love Poem','1','IU','13/04/2004','13/04/2004',0,50),
--('IU29Doc',N'IU Documentary Pieces','Content/items/iu/md/29th.png',1600000,N'Winter of 29th Year Old','4','IU','13/04/2004','13/04/2004',0,50),
--('BTSALBprf',N'BTS Album Proof','Content/items/bts/alb/proof.png',500000,N'Album Proof','1','BTS','13/04/2004','13/04/2004',0,50),
--('ILITReal1',N'ILLIT Album Super Real','Content/items/illit/alb/spReal.png',420000,N'Album Super Real','1','ILLIT','13/04/2004','13/04/2004',0,50)

--('TSTCDH',N'Trà Sữa Trân Châu Đường Hổ','Content/img/TSTCDH.jpg',25000,N'Trân Châu Đường Hổ, Size M','1','1'),
--('TSPMT',N'Trà Sữa Phô Mai Tươi','Content/img/TSPMT.jpg',40000,N'Phô Mai Tươi, Size M','1','1'),
--('TSTCHG',N'Trà Sữa Trân Châu Hoàng Gia','Content/img/TSTCHG.jpg',25000,N'Trân Châu Hoàng Gia, Size M','1','1'),
--('TS3AE',N'Trà Sữa Ba Anh Em','Content/img/TS3AE.jpg',25000,N'Tình Anh Em Chí Cốt, Size M','1','1'),
--('TSTCS',N'Trà Sữa Trân Châu Sợi','Content/img/TSTCS.jpg',25000,N'Mới Lạ Mời Bạn Mua Nha, Size M','1','1'),
--('TSKCD',N'Trà Sữa Kim Cương Đen Okinawa','Content/img/TSKCD.jpg',25000,N'Kim Cương Thật Đó, Size M','1','1'),
--('TSSocola',N'Trà Sữa Socola','Content/img/TSSocola.jpg',25000,N'Trân Châu Hoàng Gia, Size M','1','1'),
--('TSOL',N'Trà Sữa Ô Long','Content/img/TSOL.jpg',25000,N'Trà Sữa Ô Long, Size M','1','1'),
--('TXSVN',N'Trà Xanh Sữa Vị Nhài','Content/img/TXSVN.jpg',25000,N'Trà Xanh Sữa Vị Nhài, Size M','1','1'),
--('HTKPM',N'Hồng Trà Kem Phô Mai','Content/img/HTKPM.jpg',25000,N'Hồng Trà Kem Phô Mai, Size M','3','1'),
--('TSDT',N'Trà Sữa Dâu Tây','Content/img/TSDT.jpg',25000,N'Trà Sữa Dâu Tây, Size M','1','1'),
--('TXKPM',N'Trà Xanh Kem Phô Mai','Content/img/TXKPM.jpg',25000,N'Trà Xanh Kem Phô Mai, Size M','3','1'),
--('DTKPM',N'Dâu Tầm Kem Phô Mai','Content/img/DTKPM.jpg',40000,N'Dâu Tầm Kem Phô Mai, Size M','3','1'),
--('OLKPM',N'Ô Long Kem Phô Mai','Content/img/OLKPM.jpg',25000,N'Ô Long Kem Phô Mai, Size M','3','1'),
--('OLMKPM',N'Ô Long Mận Kem Phô Mai','Content/img/OLMKPM.jpg',25000,N'Ô Long Mận Kem Phô Mai, Size M','3','1'),
--('BPlanS',N'Bánh Plan Socola','Content/img/BPlanS.jpg',5000,N'Làm Từ Socola Và Trứng','6','1'),
--('BPlanT',N'Bánh Plan','Content/img/BPlanT.jpg',5000,N'Làm Từ Trứng','6','1'),
--('TCDen',N'Trân Châu Đen','Content/img/TCDen.jpg',5000,N'Đen Huyền Bí','6','1'),
--('TCXanh',N'Trân Châu Xanh','Content/img/TCXanh.jpg',5000,N'Xanh Của Thiên Nhiên','6','1'),
--('TRCSocola',N'Thạch Rau Câu Socola','Content/img/TRCSocola.jpg',5000,N'Thạch Socola','6','1'),
--('TRCXanh',N'Thạch Rau Câu Xanh','Content/img/TRCXanh.jpg',5000,N'Thạch Xanh','6','1'),
--('CKTCHK',N'Cafe Kem Trân Châu Hoàng Kim','Content/img/CKTCHK.jpg',25000,N'Kem Cà Phê Trân Châu Hoàng Kim','4','1'),
--('KTCHK',N'Kem Trân Châu Hoàng Kim','Content/img/KTCHK.jpg',25000,N'Kem Trân Châu Hoàng Kim','4','1'),
--('KDS',N'Kem Ly Dâu Sữa','Content/img/KDS.jpg',25000,N'Ly Kem Dâu Sữa','4','1'),
--('KVD',N'Kem Ly Vani Dâu','Content/img/KVD.jpg',25000,N'Ly Kem Vani Dâu','4','1'),
--('CPDD',N'Cà Phê Đen Đá','Content/img/CPDD.jpg',18000,N'Cà Phê Đen Tỉnh Táo Ngày Dài','2','1'),
--('CPSD',N'Cà Phê Sữa Đá','Content/img/CPSD.jpg',18000,N'Cà Phê Sữa Thơm Ngon','2','1'),
--('JMC',N'Jelly Milk Coffee','Content/img/JMC.jpg',22000,N'Cà Phê Sữa Thạch','2','1'),
--('GJMC',N'Grass Jelly Milk Coffee','Content/img/GJMC.jpg',22000,N'Cà Phê Sữa Thạch Cỏ','2','1'),

--('TSNCL',N'Trà Sữa Ngũ Cốc','Content/img/TSNC.jpg',35000,N'Ô Long Sữa Trân Châu Ngũ Cốc, Size L','1','2'),
--('TSTCDHL',N'Trà Sữa Trân Châu Đường Hổ','Content/img/TSTCDH.jpg',35000,N'Trân Châu Đường Hổ, Size L','1','2'),
--('TSPMTL',N'Trà Sữa Phô Mai Tươi','Content/img/TSPMT.jpg',50000,N'Phô Mai Tươi, Size L','1','2'),
--('TSTCHGL',N'Trà Sữa Trân Châu Hoàng Gia','Content/img/TSTCHG.jpg',35000,N'Trân Châu Hoàng Gia, Size L','1','2'),
--('TS3AEL',N'Trà Sữa Ba Anh Em','Content/img/TS3AE.jpg',35000,N'Tình Anh Em Chí Cốt, Size L','1','2'),
--('TSTCSL',N'Trà Sữa Trân Châu Sợi','Content/img/TSTCS.jpg',35000,N'Mới Lạ Mời Bạn Mua Nha, Size L','1','2'),
--('TSKCDL',N'Trà Sữa Kim Cương Đen Okinawa','Content/img/TSKCD.jpg',35000,N'Kim Cương Thật Đó, Size L','1','2'),
--('TSSocolaL',N'Trà Sữa Socola','Content/img/TSSocola.jpg',35000,N'Trân Châu Hoàng Gia, Size L','1','2'),
--('TSOLL',N'Trà Sữa Ô Long','Content/img/TSOL.jpg',35000,N'Trà Sữa Ô Long, Size L','1','2'),
--('TXSVNL',N'Trà Xanh Sữa Vị Nhài','Content/img/TXSVN.jpg',35000,N'Trà Xanh Sữa Vị Nhài, Size L','1','2'),
--('HTKPML',N'Hồng Trà Kem Phô Mai','Content/img/HTKPM.jpg',35000,N'Hồng Trà Kem Phô Mai, Size L','3','2'),
--('TSDTL',N'Trà Sữa Dâu Tây','Content/img/TSDT.jpg',35000,N'Trà Sữa Dâu Tây, Size L','1','2'),
--('TXKPML',N'Trà Xanh Kem Phô Mai','Content/img/TXKPM.jpg',35000,N'Trà Xanh Kem Phô Mai, Size L','3','2'),
--('DTKPML',N'Dâu Tầm Kem Phô Mai','Content/img/DTKPM.jpg',50000,N'Dâu Tầm Kem Phô Mai, Size L','3','2'),
--('OLKPML',N'Ô Long Kem Phô Mai','Content/img/OLKPM.jpg',35000,N'Ô Long Kem Phô Mai, Size L','3','2'),
--('OLMKPML',N'Ô Long Mận Kem Phô Mai','Content/img/OLMKPM.jpg',35000,N'Ô Long Mận Kem Phô Mai, Size L','3','2')


go

insert into SanPhamData
values
('ASPALB01','Content/items/aespa/alb/BouquetVer_750x.png','','','','',''),
('ASPALB02','Content/items/aespa/alb/KARINAVer_750x.png','','','','',''),
('ASPALB03','Content/items/aespa/alb/WINTERVer_750x.png','','','','',''),
('ASPALB04','Content/items/aespa/alb/NINGNINGVer_750x.png','','','','',''),
('ASPALB05','Content/items/aespa/alb/GISELLEVer_750x.png','','','','',''),
('IUALBLP','Content/items/iu/alb/albLovePoem.png','Content/items/iu/alb/albLovePoem1.png','','','','Content/items/iu/alb/albLovePoemNote2.png'),
('IU29Doc','Content/items/iu/md/29th.png','Content/items/iu/md/29th1.png','Content/items/iu/md/29th2.png','Content/items/iu/md/29th3.png','',''),
('BTSALBprf','Content/items/bts/alb/proof.png','Content/items/bts/alb/proof1.png','','','','Content/items/bts/alb/proofNote2.png'),
('ILITReal1','Content/items/illit/alb/spReal.png','Content/items/illit/alb/spReal1.png','','','','')

go
INSERT INTO ChiNhanh (MaCN, TenCN, DiaChiCN) 
VALUES 
    ('CN1', N'Hà Nội', N'Số 4B Phố Hàng Bài, P. Tràng Tiền, Q. Hoàn Kiếm, Hà Nội'),
    ('CN2', N'Hồ Chí Minh', N'Số 172 Đường Số 1 Q.Bình Tân');  

go
INSERT INTO TK(Email, MatKhau,TrangThai,Quyen) 
VALUES 
    (N'Admin', 'Admin', 0,'Admin');
   

go

CREATE PROCEDURE Product_Add 
    @MaSP varchar(10), 
    @TenSP nvarchar(50), 
    @DuongDan varchar(100), 
    @Gia float, 
    @MoTa nvarchar(255), 
    @MaLoai varchar(10),
    @MaNhom varchar(10),
    @NgaySX datetime, -- Thêm tham số này
    @NgayNhap datetime, -- Thêm tham số này
    @DoanhSo int, -- Thêm tham số này
    @SoLuongKho int -- Thêm tham số này
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
               ,[NgaySX] -- Thêm cột này vào INSERT
               ,[NgayNhap] -- Thêm cột này vào INSERT
               ,[DoanhSo] -- Thêm cột này vào INSERT
               ,[SoLuongKho]) -- Thêm cột này vào INSERT
    VALUES 
     ( @MaSP,
      @TenSP,
      @DuongDan,
      @Gia,
      @MoTa,
      @MaLoai,
      @MaNhom,
      @NgaySX, -- Thêm giá trị này vào VALUES
      @NgayNhap, -- Thêm giá trị này vào VALUES
      @DoanhSo, -- Thêm giá trị này vào VALUES
      @SoLuongKho) -- Thêm giá trị này vào VALUES
END
GO


CREATE PROCEDURE ProductData_Add 
    @MaSP varchar(10), 
    @DuongDan1 varchar(100), 
    @DuongDan2 varchar(100), 
    @DuongDan3 varchar(100), 
    @DuongDan4 varchar(100), 
    @DuongDan5 varchar(100),
    @AnhNote varchar(100)
AS
BEGIN
    INSERT INTO [dbo].[SanPhamData]
           ([MaSP]
           ,[DuongDan1]
           ,[DuongDan2]
           ,[DuongDan3]
           ,[DuongDan4]
           ,[DuongDan5]
           ,[AnhNote])
    VALUES 
    ( @MaSP,
      @DuongDan1,
      @DuongDan2,
      @DuongDan3,
      @DuongDan4,
      @DuongDan5,
      @AnhNote)
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
