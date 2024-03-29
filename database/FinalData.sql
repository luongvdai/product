USE [master]
GO
/****** Object:  Database [clothesManager]    Script Date: 3/24/2023 9:25:03 PM ******/
CREATE DATABASE [clothesManager]
GO
ALTER DATABASE [clothesManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [clothesManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [clothesManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [clothesManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [clothesManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [clothesManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [clothesManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [clothesManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [clothesManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [clothesManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [clothesManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [clothesManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [clothesManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [clothesManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [clothesManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [clothesManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [clothesManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [clothesManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [clothesManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [clothesManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [clothesManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [clothesManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [clothesManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [clothesManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [clothesManager] SET RECOVERY FULL 
GO
ALTER DATABASE [clothesManager] SET  MULTI_USER 
GO
ALTER DATABASE [clothesManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [clothesManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [clothesManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [clothesManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [clothesManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [clothesManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'clothesManager', N'ON'
GO
ALTER DATABASE [clothesManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [clothesManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [clothesManager]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Customer Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[UserName] [nchar](10) NOT NULL,
	[Password] [nchar](10) NOT NULL,
	[Role] [bit] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK__Order__C3905BAFC25D9197] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 3/24/2023 9:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NULL,
	[PurchasePrice] [decimal](10, 2) NULL,
	[Quantity] [int] NULL,
	[PurchaseDate] [date] NULL,
	[ProductName] [nvarchar](50) NULL,
	[SalePrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK__Purchase__B40CC6EDCB974578] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [Customer Name], [Phone]) VALUES (1, N'Khách hàng 1', N'0987654321')
INSERT [dbo].[Customer] ([CustomerID], [Customer Name], [Phone]) VALUES (2, N'Khách hàng 2', N'0218574193')
INSERT [dbo].[Customer] ([CustomerID], [Customer Name], [Phone]) VALUES (5, N'Khách hàng 3', N'0218574193')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Manager] ([UserName], [Password], [Role]) VALUES (N'admin     ', N'admin     ', 1)
INSERT [dbo].[Manager] ([UserName], [Password], [Role]) VALUES (N'user      ', N'123       ', 0)
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerId]) VALUES (34, CAST(N'2023-03-24' AS Date), 2)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerId]) VALUES (35, CAST(N'2023-03-24' AS Date), 1)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerId]) VALUES (36, CAST(N'2023-03-24' AS Date), 5)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [ProductID], [Quantity]) VALUES (27, 34, 3, 2)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [ProductID], [Quantity]) VALUES (28, 35, 5, 3)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [ProductID], [Quantity]) VALUES (29, 36, 8, 3)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [Address]) VALUES (1, N'Nhà cung cấp 1', N'China')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [Address]) VALUES (2, N'Nhà cung cấp 2', N'Việt Nam')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [Address]) VALUES (5, N'Nhà cung cấp 3', N'Việt Nam')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [Address]) VALUES (11, N'Nhà cung cấp 4', N'Việt Nam')
SET IDENTITY_INSERT [dbo].[Provider] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (1, 2, CAST(50.00 AS Decimal(10, 2)), 20, CAST(N'2022-04-01' AS Date), N'T-Shirt', CAST(60000 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (2, 1, CAST(30.00 AS Decimal(10, 2)), 49, CAST(N'2022-05-01' AS Date), N'Quần Jeans', CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (3, NULL, CAST(20.00 AS Decimal(10, 2)), 18, CAST(N'2022-06-01' AS Date), N'Socks', CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (4, 2, CAST(15.00 AS Decimal(10, 2)), 6, CAST(N'2022-07-01' AS Date), N'Hat', CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (5, NULL, CAST(40.00 AS Decimal(10, 2)), 1, CAST(N'2022-08-01' AS Date), N'Dress', CAST(55 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (7, 1, CAST(20.00 AS Decimal(10, 2)), 11, CAST(N'2022-10-01' AS Date), N'Shirt', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (8, NULL, CAST(20.00 AS Decimal(10, 2)), 9, CAST(N'2022-10-01' AS Date), N'Shirt', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[Purchase] ([ProductID], [ProviderId], [PurchasePrice], [Quantity], [PurchaseDate], [ProductName], [SalePrice]) VALUES (9, NULL, CAST(20.00 AS Decimal(10, 2)), 9, CAST(N'2022-10-01' AS Date), N'Áo thun', CAST(30 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Purchase] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Purchase] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Purchase] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Purchase]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Provider]
GO
USE [master]
GO
ALTER DATABASE [clothesManager] SET  READ_WRITE 
GO
