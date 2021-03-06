USE [master]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 20/12/2018 15:39:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Email] [varchar](30) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[StreetAddress] [varchar](100) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Phone] [varchar](10) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[MailList] [varchar](10) NOT NULL,
	[CustType] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [varchar](100) NOT NULL,
	[CustomerId] [varchar](100) NOT NULL,
	[ProductType] [varchar](25) NULL,
	[ProductName] [varchar](25) NULL,
	[ProductCountry] [varchar](50) NULL,
	[Grape] [varchar](50) NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] NOT NULL,
	[ProductName] [varchar](255) NULL,
	[ProductCountry] [varchar](255) NULL,
	[ProductType] [varchar](255) NULL,
	[ProductDescription] [varchar](255) NULL,
	[Grape] [varchar](255) NULL,
	[ImageSrc] [nvarchar](150) NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [products_pk] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order](
	[orderID] [varchar](100) NOT NULL,
	[customerID] [varchar](100) NOT NULL,
	[productType] [varchar](25) NULL,
	[productName] [varchar](25) NULL,
	[country] [varchar](50) NULL,
	[grape] [varchar](50) NULL,
	[price] [decimal](18, 0) NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProduct]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetProduct] @ProductID int
as
select * from Products where ProductID = @ProductID
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCustomer]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCustomer] 
@email varchar(30), @Name varchar(30), @StreetAddress varchar(30), @City varchar(30), @Password varchar(MAX), @Phone varchar(10),@Gender varchar(10),
@MailList varchar(10), @CustType varchar(30)
as
begin
insert into Customer (email, name, StreetAddress, city, password, phone, gender, maillist, custtype)
values(@email, @name, @streetaddress, @city, @password, @phone, @gender, @maillist, @custtype)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProduct]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertProduct] @ProductID int, @ProductName varchar(255), @ProductCountry varchar(255), @ProductType varchar(255), @ProductDescription varchar(255), 
@grape varchar(255), @ImageSrc nvarchar(150), @Price decimal(18,2)

as
begin
	insert into Products (ProductID, ProductName, ProductCountry, ProductType, ProductDescription, Grape, ImageSrc, Price)
	values (@ProductID, @ProductName, @ProductCountry, @ProductType, @ProductCountry, @grape, @ImageSrc, @Price)
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_ShowAllProducts]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_ShowAllProducts]
as
Select * FROM PRODUCTS
go;
GO
/****** Object:  StoredProcedure [dbo].[usp_WinesbyCountry]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_WinesbyCountry] @ProductCountry varchar(255)
as
Select * from Products where ProductCountry = @ProductCountry
GO
/****** Object:  StoredProcedure [dbo].[usp_WinesbyGrape]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_WinesbyGrape] @Grape varchar(255)
as
Select * from Products where Grape = @Grape
GO
/****** Object:  StoredProcedure [dbo].[uspCreate_tbl_order]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[uspCreate_tbl_order]
AS
CREATE TABLE tbl_order(
orderID VARCHAR(100) NOT NULL PRIMARY KEY,
customerID VARCHAR(100) NOT NULL,
productType VARCHAR(25),
productName VARCHAR(25),
country VARCHAR(50),
grape VARCHAR(50),
price DECIMAL NOT NULL,
quantity INT
)
GO
/****** Object:  StoredProcedure [dbo].[uspInsert_tbl_order]    Script Date: 20/12/2018 15:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[uspInsert_tbl_order]
@order VARCHAR(100),
@customer VARCHAR(100),
@type VARCHAR(25),
@name VARCHAR(25),
@country VARCHAR(50),
@grape VARCHAR(50),
@price DECIMAL,
@quantity INT
AS INSERT INTO tbl_order VALUES(@order, @customer, @type, @name, @country, @grape, @price, @quantity)
GO
