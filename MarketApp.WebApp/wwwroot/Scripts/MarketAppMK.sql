USE [MarketApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](40) NOT NULL,
	[MasterCategoryId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[ImageDescription] [nvarchar](max) NULL,
	[CreatTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[ProductDescirption] [nvarchar](max) NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[ImageId] [int] NULL,
	[TaxId] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NOT NULL,
	[UnitPrice] [money] NULL,
	[MSRP] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[Discontinued] [bit] NOT NULL,
	[ProductionTime] [datetime2](7) NOT NULL,
	[ExpirationTime] [datetime2](7) NOT NULL,
	[CreatTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taxs]    Script Date: 1.07.2022 14:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taxs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaxType] [nvarchar](100) NOT NULL,
	[TaxValue] [decimal](18, 2) NOT NULL,
	[CreatTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Taxs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629184417_InitDb', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629184520_InitDb2', N'6.0.6')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (1, N'Yiyecek', 0, N'Ana Kategori', CAST(N'2022-06-29T23:32:14.1766667' AS DateTime2), CAST(N'2022-06-29T23:32:14.1766667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (2, N'Unlu Mamuller', 1, N'Alt Kategori', CAST(N'2022-06-29T23:32:45.1733333' AS DateTime2), CAST(N'2022-06-29T23:32:45.1733333' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (5, N'Dondurulmuş Ürünler', 1, N'Alt Kategori', CAST(N'2022-06-29T23:34:16.7200000' AS DateTime2), CAST(N'2022-06-29T23:34:16.7200000' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (6, N'Süt Ürünleri', 1, N'Alt Kategori', CAST(N'2022-06-29T23:34:40.3000000' AS DateTime2), CAST(N'2022-06-29T23:34:40.3000000' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (7, N'Hazır Yemek', 1, N'Alt Kategori', CAST(N'2022-06-29T23:35:31.9766667' AS DateTime2), CAST(N'2022-06-29T23:35:31.9766667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (8, N'Konserve', 1, N'Alt Kategori', CAST(N'2022-06-29T23:35:52.8733333' AS DateTime2), CAST(N'2022-06-29T23:35:52.8733333' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (9, N'Tatlı', 1, N'Alt Kategori', CAST(N'2022-06-29T23:36:22.9400000' AS DateTime2), CAST(N'2022-06-29T23:36:22.9400000' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (10, N'İçecek', 0, N'Ana Kategori', CAST(N'2022-06-29T23:36:59.0400000' AS DateTime2), CAST(N'2022-06-29T23:36:59.0400000' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (11, N'Gazlı İçecek', 10, N'Alt Kategori', CAST(N'2022-06-29T23:37:23.8566667' AS DateTime2), CAST(N'2022-06-29T23:37:23.8566667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (12, N'Maden Suyu', 10, N'Alt Kategori', CAST(N'2022-06-29T23:37:50.9933333' AS DateTime2), CAST(N'2022-06-29T23:37:50.9933333' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (13, N'Çay', 10, N'Alt Kategori', CAST(N'2022-06-29T23:38:04.0466667' AS DateTime2), CAST(N'2022-06-29T23:38:04.0466667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (14, N'Kahve', 10, N'Alt Kategori', CAST(N'2022-06-29T23:38:18.9366667' AS DateTime2), CAST(N'2022-06-29T23:38:18.9366667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (15, N'Meyve Suyu', 10, N'Alt Kategori', CAST(N'2022-06-29T23:38:39.0966667' AS DateTime2), CAST(N'2022-06-29T23:38:39.0966667' AS DateTime2))
INSERT [dbo].[Categories] ([Id], [CategoryName], [MasterCategoryId], [Description], [CreatTime], [UpdateTime]) VALUES (16, N'Enerji İçeceği', 10, N'Alt Kategori', CAST(N'2022-06-29T23:38:58.7766667' AS DateTime2), CAST(N'2022-06-29T23:38:58.7766667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [SKU], [ProductName], [ProductDescirption], [SupplierID], [CategoryID], [ImageId], [TaxId], [QuantityPerUnit], [UnitPrice], [MSRP], [UnitsInStock], [Discontinued], [ProductionTime], [ExpirationTime], [CreatTime], [UpdateTime]) VALUES (1, NULL, N'Makarna', N'Unlu Mamul', 1, 2, NULL, 3, N'500 gr 1 paket', 8.0000, 8.0000, 100, 1, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-29T23:41:51.3200000' AS DateTime2), CAST(N'2022-06-29T23:41:51.3200000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [SKU], [ProductName], [ProductDescirption], [SupplierID], [CategoryID], [ImageId], [TaxId], [QuantityPerUnit], [UnitPrice], [MSRP], [UnitsInStock], [Discontinued], [ProductionTime], [ExpirationTime], [CreatTime], [UpdateTime]) VALUES (9, N'1515SKU2359', N'Kola', N'Gazlı İçecek', 4, 11, NULL, 4, N'2,5 lt 1 adet', 500.0000, 500.0000, 12, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [SKU], [ProductName], [ProductDescirption], [SupplierID], [CategoryID], [ImageId], [TaxId], [QuantityPerUnit], [UnitPrice], [MSRP], [UnitsInStock], [Discontinued], [ProductionTime], [ExpirationTime], [CreatTime], [UpdateTime]) VALUES (11, N'1515SKU2359', N'Nescafe', N'Kahve', 4, 14, NULL, 2, N'1 Paket 1 Adet', 10.0000, 10.0000, 501, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [SKU], [ProductName], [ProductDescirption], [SupplierID], [CategoryID], [ImageId], [TaxId], [QuantityPerUnit], [UnitPrice], [MSRP], [UnitsInStock], [Discontinued], [ProductionTime], [ExpirationTime], [CreatTime], [UpdateTime]) VALUES (13, N'1515SKU2359', N'Çay', N'Çay', 3, 13, NULL, 3, N'2,5 lt 1 adet', 10.0000, 10.0000, 500, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [CompanyName], [CreatTime], [UpdateTime]) VALUES (1, N'Tedarikcim', CAST(N'2022-06-29T23:29:41.0066667' AS DateTime2), CAST(N'2022-06-29T23:29:41.0066667' AS DateTime2))
INSERT [dbo].[Suppliers] ([Id], [CompanyName], [CreatTime], [UpdateTime]) VALUES (2, N'Gıda Deposu', CAST(N'2022-06-29T23:29:52.7400000' AS DateTime2), CAST(N'2022-06-29T23:29:52.7400000' AS DateTime2))
INSERT [dbo].[Suppliers] ([Id], [CompanyName], [CreatTime], [UpdateTime]) VALUES (3, N'Herşey Burada', CAST(N'2022-06-29T23:30:47.0500000' AS DateTime2), CAST(N'2022-06-29T23:30:47.0500000' AS DateTime2))
INSERT [dbo].[Suppliers] ([Id], [CompanyName], [CreatTime], [UpdateTime]) VALUES (4, N'HemenGetir', CAST(N'2022-06-29T23:31:09.2633333' AS DateTime2), CAST(N'2022-06-29T23:31:09.2633333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Taxs] ON 

INSERT [dbo].[Taxs] ([Id], [TaxType], [TaxValue], [CreatTime], [UpdateTime]) VALUES (2, N'KDV', CAST(0.18 AS Decimal(18, 2)), CAST(N'2022-06-29T23:26:21.7400000' AS DateTime2), CAST(N'2022-06-29T23:26:21.7400000' AS DateTime2))
INSERT [dbo].[Taxs] ([Id], [TaxType], [TaxValue], [CreatTime], [UpdateTime]) VALUES (3, N'KDV*', CAST(0.01 AS Decimal(18, 2)), CAST(N'2022-06-29T23:28:11.9666667' AS DateTime2), CAST(N'2022-06-29T23:28:11.9666667' AS DateTime2))
INSERT [dbo].[Taxs] ([Id], [TaxType], [TaxValue], [CreatTime], [UpdateTime]) VALUES (4, N'ÖTV', CAST(0.15 AS Decimal(18, 2)), CAST(N'2022-06-29T23:29:01.8766667' AS DateTime2), CAST(N'2022-06-29T23:29:01.8766667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Taxs] OFF
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Images] ADD  CONSTRAINT [DF_Images_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[Images] ADD  CONSTRAINT [DF_Images_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Taxs] ADD  CONSTRAINT [DF_Taxs_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[Taxs] ADD  CONSTRAINT [DF_Taxs_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Images_ImageId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Taxs_TaxId] FOREIGN KEY([TaxId])
REFERENCES [dbo].[Taxs] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Taxs_TaxId]
GO
