GO
CREATE DATABASE BDTestProduct
GO
CREATE SCHEMA [CatalogProducts]
GO
/****** Object:  Table [CatalogProducts].[Products]    Script Date: 27/10/2022 09:01:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CatalogProducts].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[ImgUrl] [nvarchar](max) NULL,
	[CreationDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CatalogProducts].[ProductCategory]    Script Date: 27/10/2022 09:01:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CatalogProducts].[ProductCategory](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [CatalogProducts].[ViewProductsCatalog]    Script Date: 27/10/2022 09:01:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [CatalogProducts].[ViewProductsCatalog]
AS
SELECT        CatalogProducts.ProductCategory.CategoryName, CatalogProducts.Products.ProductName, CatalogProducts.Products.Description, CatalogProducts.Products.ProductId
FROM            CatalogProducts.ProductCategory INNER JOIN
                         CatalogProducts.Products ON CatalogProducts.ProductCategory.ProductCategoryId = CatalogProducts.Products.CategoryId
GO
ALTER TABLE [CatalogProducts].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY([CategoryId])
REFERENCES [CatalogProducts].[ProductCategory] ([ProductCategoryId])
GO
ALTER TABLE [CatalogProducts].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory]
GO
