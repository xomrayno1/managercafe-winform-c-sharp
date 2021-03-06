USE [master]
GO
/****** Object:  Database [OrderCoffe]    Script Date: 24/12/2019 8:51:32 PM ******/
CREATE DATABASE [OrderCoffe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderCoffe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OrderCoffe.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OrderCoffe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OrderCoffe_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OrderCoffe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderCoffe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderCoffe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderCoffe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderCoffe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderCoffe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderCoffe] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderCoffe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderCoffe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderCoffe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderCoffe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderCoffe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderCoffe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderCoffe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderCoffe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderCoffe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderCoffe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderCoffe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderCoffe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderCoffe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderCoffe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderCoffe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderCoffe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderCoffe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderCoffe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderCoffe] SET  MULTI_USER 
GO
ALTER DATABASE [OrderCoffe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderCoffe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderCoffe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderCoffe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OrderCoffe] SET DELAYED_DURABILITY = DISABLED 
GO
USE [OrderCoffe]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dateOrder] [datetime] NULL,
	[totalOrder] [int] NULL,
	[sales] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrdersDetail]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[totalprice] [int] NULL,
	[idOrder] [int] NULL,
	[idProduct] [int] NULL,
 CONSTRAINT [PK_OrdersDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [int] NULL,
	[describe] [nvarchar](50) NULL,
	[idcategory] [int] NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[ghichu] [nvarchar](150) NULL,
	[name] [nvarchar](50) NULL,
	[roles] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Nước Ngọt')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Thức Ăn Nhanh')
INSERT [dbo].[Category] ([id], [name]) VALUES (1003, N'Trà')
INSERT [dbo].[Category] ([id], [name]) VALUES (1004, N'Thuốc Lá')
INSERT [dbo].[Category] ([id], [name]) VALUES (1005, N'Bia,Rượu')
INSERT [dbo].[Category] ([id], [name]) VALUES (1006, N'Sữa')
INSERT [dbo].[Category] ([id], [name]) VALUES (1012, N'Trà Sữa')
INSERT [dbo].[Category] ([id], [name]) VALUES (1018, N'Sinh Tố')
INSERT [dbo].[Category] ([id], [name]) VALUES (1019, N'Chè')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (1, CAST(N'2019-12-21 01:48:32.273' AS DateTime), 120000, 20)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (2, CAST(N'2019-12-21 13:30:54.347' AS DateTime), 65000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (3, CAST(N'2019-12-21 13:34:13.393' AS DateTime), 180000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (4, CAST(N'2019-11-21 13:34:13.393' AS DateTime), 180000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (5, CAST(N'2019-12-21 14:43:40.303' AS DateTime), 35000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (6, CAST(N'2019-12-21 15:02:36.927' AS DateTime), 30000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (7, CAST(N'2019-12-21 15:04:47.887' AS DateTime), 87000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (8, CAST(N'2019-12-21 15:21:48.110' AS DateTime), 15000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (9, CAST(N'2019-12-21 15:22:20.230' AS DateTime), 15000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (10, CAST(N'2019-12-21 15:23:04.597' AS DateTime), 25000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (11, CAST(N'2019-12-21 15:30:27.280' AS DateTime), 15000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (12, CAST(N'2019-12-21 15:34:56.143' AS DateTime), 27000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (13, CAST(N'2019-12-21 15:35:48.957' AS DateTime), 15000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (14, CAST(N'2019-12-21 15:36:37.893' AS DateTime), 30000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (15, CAST(N'2019-12-21 21:18:34.130' AS DateTime), 42000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (16, CAST(N'2019-12-21 21:19:34.157' AS DateTime), 90000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (17, CAST(N'2019-12-21 21:22:52.120' AS DateTime), 30000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (18, CAST(N'2019-12-21 21:28:53.950' AS DateTime), 87000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (19, CAST(N'2019-12-21 21:34:24.330' AS DateTime), 107000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (20, CAST(N'2019-12-21 21:35:46.757' AS DateTime), 15000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (21, CAST(N'2019-12-21 21:38:46.560' AS DateTime), 112000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (22, CAST(N'2019-12-21 21:54:15.130' AS DateTime), 89600, 20)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (23, CAST(N'2019-12-21 22:02:51.843' AS DateTime), 120000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (24, CAST(N'2019-12-21 22:11:50.857' AS DateTime), 135000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (25, CAST(N'2019-12-22 11:40:13.157' AS DateTime), 120000, 20)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (26, CAST(N'2019-12-22 12:19:55.460' AS DateTime), 172000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (27, CAST(N'2019-12-22 22:05:22.943' AS DateTime), 125000, 0)
INSERT [dbo].[Orders] ([id], [dateOrder], [totalOrder], [sales]) VALUES (28, CAST(N'2019-12-23 16:07:48.913' AS DateTime), 72000, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[OrdersDetail] ON 

INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (1, 5, 75000, 1, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (2, 5, 75000, 1, 1008)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (3, 2, 30000, 2, 1009)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (4, 1, 15000, 2, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (5, 2, 20000, 2, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (6, 6, 90000, 3, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (7, 9, 90000, 3, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (8, 6, 90000, 4, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (9, 9, 90000, 4, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (10, 2, 20000, 5, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (11, 1, 15000, 5, 1009)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (12, 1, 15000, 6, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (13, 1, 15000, 6, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (14, 1, 15000, 7, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (15, 1, 15000, 7, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (16, 1, 12000, 7, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (17, 3, 45000, 7, 1009)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (18, 1, 15000, 8, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (19, 1, 15000, 9, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (20, 1, 10000, 10, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (21, 1, 15000, 10, 1008)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (22, 1, 15000, 11, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (23, 1, 15000, 12, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (24, 1, 12000, 12, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (25, 1, 15000, 13, 2)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (26, 1, 15000, 14, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (27, 1, 15000, 14, 1011)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (28, 1, 15000, 15, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (29, 1, 12000, 15, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (30, 1, 15000, 15, 1008)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (31, 1, 15000, 16, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (32, 5, 75000, 16, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (33, 1, 15000, 17, 2)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (34, 1, 15000, 17, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (35, 1, 15000, 18, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (36, 1, 12000, 18, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (37, 3, 45000, 18, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (38, 1, 15000, 18, 1011)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (39, 1, 15000, 19, 2)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (40, 1, 12000, 19, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (41, 1, 15000, 19, 1009)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (42, 1, 15000, 19, 1025)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (43, 5, 50000, 19, 1028)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (44, 1, 15000, 20, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (45, 1, 15000, 21, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (46, 1, 10000, 21, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (47, 6, 72000, 21, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (48, 1, 15000, 21, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (49, 1, 15000, 22, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (50, 1, 10000, 22, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (51, 6, 72000, 22, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (52, 1, 15000, 22, 1008)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (53, 1, 10000, 23, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (54, 1, 15000, 23, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (55, 1, 20000, 23, 1019)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (56, 4, 60000, 23, 1024)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (57, 1, 15000, 23, 1025)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (58, 1, 15000, 24, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (59, 1, 15000, 24, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (60, 1, 15000, 24, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (61, 3, 75000, 24, 1015)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (62, 1, 15000, 24, 1018)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (63, 1, 15000, 25, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (64, 1, 10000, 25, 3)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (65, 1, 15000, 25, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (66, 1, 15000, 25, 1008)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (67, 1, 20000, 25, 1019)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (68, 3, 75000, 25, 1020)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (69, 1, 15000, 26, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (70, 2, 30000, 26, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (71, 1, 12000, 26, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (72, 1, 10000, 26, 1028)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (73, 1, 15000, 26, 1021)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (74, 3, 45000, 26, 1022)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (75, 3, 45000, 26, 1025)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (76, 2, 30000, 27, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (77, 3, 45000, 27, 1005)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (78, 5, 50000, 27, 1028)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (79, 1, 15000, 28, 1)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (80, 1, 15000, 28, 1002)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (81, 1, 12000, 28, 1007)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (82, 1, 15000, 28, 1009)
INSERT [dbo].[OrdersDetail] ([id], [quantity], [totalprice], [idOrder], [idProduct]) VALUES (83, 1, 15000, 28, 1011)
SET IDENTITY_INSERT [dbo].[OrdersDetail] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1, N'Bò Húc', 15000, N'Nước Uống Tăng lực có gas', 1, N'Lon')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (2, N'Bạc Sĩu', 15000, N'sữa cafe ', 1, N'Ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (3, N'Bánh Tráng Trộn', 10000, N'bánh tráng trộn với cái gì đó ', 2, N'Dĩa')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1002, N'0 Độ', 15000, N'Chai Không Độ Không Gas', 1, N'Chai')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1005, N'Dr.Thanh', 15000, N'Chai Nước', 1, N'Chai')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1007, N'Sũa Vinamilk', 12000, N'Ngon vcl', 1006, N'Hộp')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1008, N'Trà Tranh', 15000, N'Trà Tranh', 1003, N'Ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1009, N'Trà Đào', 15000, N'Ly Trà Đào', 1003, N'Ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1011, N'Mì Tôm Trứng', 15000, N'Ngon Vcl', 2, N'Tô')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1014, N'Thuốc Cotab', 15000, N'Hút Thuốc Có Nguy Cơ Ung Thư Phổi', 1004, N'Gói')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1015, N'Thuốc Ngựa', 25000, N'Hút Thuốc Có Nguy Cơ Ung Thư Phổi', 1004, N'Gói')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1016, N'Thuốc Jes', 22000, N'Hút Thuốc Có Nguy Cơ Ung Thư Phổi', 1004, N'Gói')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1017, N'Thuốc 555', 35000, N'Hút Thuốc Có Nguy Cơ Ung Thư Phổi', 1004, N'Gói')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1018, N'Bia 333', 15000, N'Uống Bia Không Được Lái Xe', 1005, N'Lon')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1019, N'Bia Tiger', 20000, N'Uống Bia Không Lái Xe', 1005, N'Lon')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1020, N'Bia Heneiken', 25000, N'Uống Bia Không Lái Xe', 1005, N'Lon')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1021, N'Trà Gừng', 15000, N'Bỏ Gừng 2 trái', 1003, N'Ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1022, N'Trà Thiết Quan Âm', 15000, N'Quan Âm Bồ Tát', 1003, N'ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1024, N'Sinh Tố Bơ', 15000, N'bơ bơ', 1018, N'ly')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1025, N'Chè Đậu Xanh', 15000, N'Chè Đậu Xanh Rất xanh', 1019, N'Chén')
INSERT [dbo].[Products] ([id], [name], [price], [describe], [idcategory], [type]) VALUES (1028, N'Nước Suối', 10000, N'Nước lọc', 1, N'CHai')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password], [ghichu], [name], [roles], [email]) VALUES (1, N'xomrayno5', N'12345', N'ac admin', N'Nguyễn Chí Tâm', N'ROLE_ADMIN', N'')
INSERT [dbo].[Users] ([id], [username], [password], [ghichu], [name], [roles], [email]) VALUES (1008, N'xomrayno1', N'123456', N'ABCC', N'Nguyễn Tâm', N'ROLE_EMPLOYEE', N'xomrayno1@gmail.com')
INSERT [dbo].[Users] ([id], [username], [password], [ghichu], [name], [roles], [email]) VALUES (1010, N'xomrayno2', N'12345', N'ABCCC', N'Nguyễn Chí Tâm', N'ROLE_EMPLOYEE', N'xomrayno2@gmail.com')
INSERT [dbo].[Users] ([id], [username], [password], [ghichu], [name], [roles], [email]) VALUES (1011, N'xomrayno3', N'12345', N'abcc', N'Nguyễn Tâm', N'ROLE_EMPLOYEE', N'xomrayno3@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetail_Orders] FOREIGN KEY([idOrder])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[OrdersDetail] CHECK CONSTRAINT [FK_OrdersDetail_Orders]
GO
ALTER TABLE [dbo].[OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetail_Products] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[OrdersDetail] CHECK CONSTRAINT [FK_OrdersDetail_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMuc] FOREIGN KEY([idcategory])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_SanPham_DanhMuc]
GO
/****** Object:  StoredProcedure [dbo].[ChiTietBanHangMonth]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChiTietBanHangMonth](@month int,@year int)
as
begin
if(@month = 0)
begin
select p.id,p.name,p.type,sum(odd.quantity) as 'SL' from Orders od 
inner join OrdersDetail odd   on od.id = odd.idOrder
inner join Products p on odd.idProduct = p.id
where YEar(od.dateOrder) = @year
group by p.id,p.name,p.type
order by SL desc
return
end
select p.id,p.name,p.type,sum(odd.quantity) as 'SL' from Orders od 
inner join OrdersDetail odd   on od.id = odd.idOrder
inner join Products p on odd.idProduct = p.id
where MONTH(od.dateOrder) = @month and YEar(od.dateOrder) = @year
group by p.id,p.name,p.type
order by SL desc

end

GO
/****** Object:  StoredProcedure [dbo].[DOANHTHUREPORT]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DOANHTHUREPORT](@year int ,@month int)
as
begin
if(@month = 0)
begin
select od.id as 'ID',od.dateOrder as 'date', od.totalOrder as 'totalPrice', od.sales as 'sale',count(*) as 'SSP',sum(odd.quantity) as 'TSLSP' from orders od 
inner join OrdersDetail odd on od.id = odd.idOrder
where  YEAR(od.dateOrder)= @year
group by od.id,dateOrder,totalOrder,sales
return;
end
select od.id as 'ID',od.dateOrder as 'date', od.totalOrder as 'totalPrice', od.sales as 'sale',count(*) as 'SSP',sum(odd.quantity) as 'TSLSP' from orders od 
inner join OrdersDetail odd on od.id = odd.idOrder
where Month(od.dateOrder) = @month and YEAR(od.dateOrder)= @year
group by od.id,dateOrder,totalOrder,sales

end
GO
/****** Object:  StoredProcedure [dbo].[HoaDon]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[HoaDon](@idorder int)
as
begin
select p.name as 'Name',odd.quantity as 'SL',odd.totalprice as 'TT',p.price as 'G'  from Orders od 
inner join OrdersDetail odd on od.id = odd.idOrder
inner join Products p on p.id = odd.idProduct
where od.id = @idorder
end

GO
/****** Object:  StoredProcedure [dbo].[ThongKeMonth]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ThongKeMonth](@month int)
as
begin
select * from Orders where  MONTH(dateOrder)  = @month
end
GO
/****** Object:  StoredProcedure [dbo].[ThongKeYear]    Script Date: 24/12/2019 8:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ThongKeYear](@Year int)
as
begin
select * from Orders where  Year(dateOrder)  = @Year
end
GO
USE [master]
GO
ALTER DATABASE [OrderCoffe] SET  READ_WRITE 
GO
