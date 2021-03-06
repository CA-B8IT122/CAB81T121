USE [master]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/12/2018 11:15:13 ******/
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
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [products_pk] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (1, N'Laurent Perrier Rose Champagne', N'France', N'Rose', N'Fruity', N'Chardonnay', N'\Content\Images\laurent.jpg', CAST(25.50 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (2, N'Ramon Bilbao Lalomba', N'Spain', N'Rose', N'Fruity', N'Tempranillo', N'\Content\Images\ramon.jpg', CAST(156.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (3, N'Alpha Zeta Rosato', N'Italy', N'Rose', N'Fruity', N'Corvina', N'\Content\Images\alpha.jpg', CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (4, N'Innocent Bystander', N'Australia', N'Rose', N'Fruity', N'Moscato', N'\Content\Images\innocent.jpg', CAST(32.50 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (5, N'Balnaves Connawarra', N'Australia', N'Red', N'Acidity', N'Carbernet Sauvignon', N'\Content\Images\Balnaves.jpg', CAST(18.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (6, N'Baron Badassiere Syrah', N'France', N'Red', N'Buttery', N'Syrah', N'\Content\Images\baron.jpg', CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (7, N'Allegrini Valpolicella Classico', N'Italy', N'Red', N'Cassis', N'Corvina', N'\Content\Images\allegrini.jpg', CAST(65.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (8, N'Casa Lapostolle Cuvee Alexandre', N'Chile', N'Red', N'Crisp', N'Cabernet Sauvignon', N'\Content\Images\casa.jpg', CAST(25.50 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (9, N'Babington Brook', N'Australia', N'White', N'Dense', N'Chardonnay', N'\Content\Images\babington.jpg', CAST(28.50 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (10, N'Banfi La Pettegola', N'Italy', N'White', N'Dry', N'Vermentino', N'\Content\Images\banfi.jpg', CAST(23.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (11, N'Veltiner', N'Austria', N'White', N'Dry', N'Gruner Veltliner', N'\Content\Images\veltiner.jpg', CAST(32.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (12, N'Dreissigacker Bechtheimer Riesling', N'Germany', N'White', N'Dry', N'Riesling', N'\Content\Images\dress.jpg', CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (13, N'Galanti Prosecco', N'Italy', N'Prosecco', N'Fruity', N'Prosecco', N'\Content\Images\galanti.jpg', CAST(18.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (14, N'San Zeno', N'Italy', N'Prosecco', N'Fruity', N'Prosecco', N'\Content\Images\san zeno.jpg', CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [ProductCountry], [ProductType], [ProductDescription], [Grape], [ImageSrc], [Price]) VALUES (15, N'Riondo Rose Prosecco', N'Italy', N'Prosecco', N'Fruity', N'Prosecco', N'\Content\Images\Riondo.jpg', CAST(36.00 AS Decimal(18, 2)))
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 11/12/2018 11:15:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProduct] @ProductID int
as
select * from Products where ProductID = @ProductID
GO
/****** Object:  StoredProcedure [dbo].[ShowAllProducts]    Script Date: 11/12/2018 11:15:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ShowAllProducts]
as
Select * FROM PRODUCTS
go;
GO
/****** Object:  StoredProcedure [dbo].[WinesbyCountry]    Script Date: 11/12/2018 11:15:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[WinesbyCountry] @ProductCountry varchar(255)
as
Select * from Products where ProductCountry = @ProductCountry
GO
/****** Object:  StoredProcedure [dbo].[WinesbyGrape]    Script Date: 11/12/2018 11:15:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[WinesbyGrape] @Grape varchar(255)
as
Select * from Products where Grape = @Grape
GO
