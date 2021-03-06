USE [master]
GO
/****** Object:  Database [EShop]    Script Date: 09/19/2017 10:10:28 PM ******/
CREATE DATABASE [EShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EShop', FILENAME = N'C:\Database\DATA\EShop.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EShop_log', FILENAME = N'C:\Database\DATA\EShop_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EShop] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [EShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EShop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EShop] SET  MULTI_USER 
GO
ALTER DATABASE [EShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EShop]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Advertisement_ID] [int] IDENTITY(1,1) NOT NULL,
	[Advertisement_NameVN] [nvarchar](50) NOT NULL,
	[Advertisement_NameEN] [nvarchar](50) NOT NULL,
	[Advertisement_UrlOut] [nvarchar](255) NULL,
	[Advertisement_Rewrite] [nvarchar](255) NOT NULL,
	[Advertisement_SearchVN] [varchar](50) NULL,
	[Advertisement_SearchEN] [varchar](50) NULL,
	[Advertisement_ContentVN] [nvarchar](max) NULL,
	[Advertisement_ContentEN] [nvarchar](max) NULL,
	[Advertisement_DescriptionVN] [nvarchar](max) NULL,
	[Advertisement_DescriptionEN] [nvarchar](max) NULL,
	[Advertisement_Img] [varchar](255) NULL,
	[Img_Width] [int] NULL,
	[Img_Unit_Width] [varchar](10) NULL,
	[Img_Height] [int] NULL,
	[Img_Unit_Height] [varchar](10) NULL,
	[Keyword_Titile] [nvarchar](50) NULL,
	[Keyword_Content] [nvarchar](max) NULL,
	[Keyword_Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
	[Is_TopPage] [bit] NULL,
	[Is_LeftPage] [bit] NULL,
	[Is_RightPage] [bit] NULL,
	[Is_BottomPage] [bit] NULL,
	[Display_Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Advertisement_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Parent_ID] [int] NOT NULL,
	[Category_NameVN] [nvarchar](50) NOT NULL,
	[Category_NameEN] [nvarchar](50) NOT NULL,
	[Category_UrlOut] [nvarchar](255) NULL,
	[Category_Rewrite] [nvarchar](255) NOT NULL,
	[Category_SearchVN] [varchar](50) NULL,
	[Category_SearchEN] [varchar](50) NULL,
	[Category_Icon] [varchar](255) NULL,
	[Category_Img] [varchar](255) NULL,
	[Keyword_Titile] [nvarchar](50) NULL,
	[Keyword_Content] [nvarchar](max) NULL,
	[Keyword_Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
	[Is_HomePage] [bit] NULL,
	[Is_TopMenu] [bit] NULL,
	[Is_BottomMenu] [bit] NULL,
	[Display_Order] [int] NULL,
 CONSTRAINT [PK__Category__6DB38D4EDE2D7FF8] PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[Contact_ID] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Name] [nvarchar](50) NOT NULL,
	[Contact_CellPhone] [varchar](50) NULL,
	[Contact_Email] [varchar](50) NULL,
	[Contact_Address] [nvarchar](max) NULL,
	[Contact_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NULL,
 CONSTRAINT [PK__Contact__82ACC1CD8AEBE90C] PRIMARY KEY CLUSTERED 
(
	[Contact_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Menu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_ID] [int] NULL,
	[Menu_Name] [nvarchar](50) NULL,
	[Display_Order] [int] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Menu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderMaster_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Quanlity] [int] NOT NULL,
	[Amout] [float] NOT NULL,
	[OrderDetail_Date] [datetime] NOT NULL,
	[OrderDetail_Status] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderMaster]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderMaster](
	[OrderMaster_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserProfile_ID] [int] NOT NULL,
	[Payment_ID] [int] NULL,
	[Provice_ID] [int] NULL,
	[OrderMaster_Code] [varchar](50) NOT NULL,
	[PriceShip] [float] NULL,
	[VAT] [float] NULL,
	[Total] [float] NULL,
	[Note] [nvarchar](max) NULL,
	[OrderMaster_Date] [datetime] NOT NULL,
	[OrderMaster_Status] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderMaster_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PageSetting]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageSetting](
	[PageSetting_ID] [int] IDENTITY(1,1) NOT NULL,
	[PageSetting_NameVN] [nvarchar](50) NOT NULL,
	[PageSetting_NameEN] [nvarchar](50) NOT NULL,
	[PageSetting_UrlOut] [nvarchar](255) NULL,
	[PageSetting_Rewrite] [nvarchar](255) NOT NULL,
	[PageSetting_SearchVN] [varchar](50) NULL,
	[PageSetting_SearchEN] [varchar](50) NULL,
	[PageSetting_Img] [varchar](255) NULL,
	[Img_Width] [int] NULL,
	[Img_Unit_Width] [varchar](10) NULL,
	[Img_Height] [int] NULL,
	[Img_Unit_Height] [varchar](10) NULL,
	[Keyword_Titile] [nvarchar](50) NULL,
	[Keyword_Content] [nvarchar](max) NULL,
	[Keyword_Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
	[Is_TopPage] [bit] NULL,
	[Is_LeftPage] [bit] NULL,
	[Is_RightPage] [bit] NULL,
	[Is_BottomPage] [bit] NULL,
	[Display_Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PageSetting_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Code] [varchar](50) NULL,
	[Category_Parent_ID] [int] NOT NULL,
	[Currency_ID] [int] NULL,
	[Product_NameVN] [nvarchar](50) NOT NULL,
	[Product_NameEN] [nvarchar](50) NOT NULL,
	[Product_UrlOut] [nvarchar](255) NULL,
	[Product_Rewrite] [nvarchar](255) NULL,
	[Product_SearchVN] [varchar](50) NOT NULL,
	[Product_SearchEN] [varchar](50) NOT NULL,
	[Product_ContentVN] [nvarchar](max) NULL,
	[Product_ContentEN] [nvarchar](max) NULL,
	[Product_DescriptionVN] [nvarchar](max) NULL,
	[Product_DescriptionEN] [nvarchar](max) NULL,
	[Product_Price] [float] NULL,
	[Product_Discount] [float] NULL,
	[Product_Img] [varchar](255) NULL,
	[Img_Width] [int] NULL,
	[Img_Unit_Width] [varchar](10) NULL,
	[Img_Height] [int] NULL,
	[Img_Unit_Height] [varchar](10) NULL,
	[Keyword_Titile] [nvarchar](50) NULL,
	[Keyword_Content] [nvarchar](max) NULL,
	[Keyword_Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Product_View] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
	[Is_HomePage] [bit] NULL,
	[Is_TopMenu] [bit] NULL,
	[Is_BottomMenu] [bit] NULL,
	[Display_Order] [int] NULL,
 CONSTRAINT [PK__Product__9834FB9AB6411B32] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promotion](
	[Promotion_ID] [int] IDENTITY(1,1) NOT NULL,
	[Promotion_NameVN] [nvarchar](50) NOT NULL,
	[Promotion_NameEN] [nvarchar](50) NOT NULL,
	[Promotion_UrlOut] [nvarchar](255) NULL,
	[Promotion_Rewrite] [nvarchar](255) NOT NULL,
	[Promotion_SearchVN] [varchar](50) NULL,
	[Promotion_SearchEN] [varchar](50) NULL,
	[Promotion_ContentVN] [nvarchar](max) NULL,
	[Promotion_ContentEN] [nvarchar](max) NULL,
	[Promotion_DescriptionVN] [nvarchar](max) NULL,
	[Promotion_DescriptionEN] [nvarchar](max) NULL,
	[Promotion_Img] [varchar](255) NULL,
	[Img_Width] [int] NULL,
	[Img_Unit_Width] [varchar](10) NULL,
	[Img_Height] [int] NULL,
	[Img_Unit_Height] [varchar](10) NULL,
	[Keyword_Titile] [nvarchar](50) NULL,
	[Keyword_Content] [nvarchar](max) NULL,
	[Keyword_Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
	[Is_LeftPage] [bit] NULL,
	[Is_RightPage] [bit] NULL,
	[Display_Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Promotion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Roles_ID] [int] IDENTITY(1,1) NOT NULL,
	[Roles_Name] [nvarchar](20) NOT NULL,
	[Is_Active] [bit] NULL,
	[Display_Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Roles_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserProfile_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserProfile_LastName] [nvarchar](50) NOT NULL,
	[UserProfile_FirstName] [nvarchar](50) NOT NULL,
	[UserProfile_FullName] [nvarchar](255) NOT NULL,
	[UserProfile_Birth_Day] [int] NOT NULL,
	[UserProfile_Birth_Month] [int] NOT NULL,
	[UserProfile_Birth_Year] [int] NOT NULL,
	[UserProfile_Age] [int] NULL,
	[UserProfile_Gender] [nvarchar](10) NOT NULL,
	[UserProfile_Phone] [varchar](20) NOT NULL,
	[UserProfile_Email] [varchar](50) NOT NULL,
	[UserProfile_Pass] [varchar](50) NOT NULL,
	[UserProfile_About_Me] [nvarchar](max) NULL,
	[UserProfile_Avatar] [varchar](500) NULL,
	[UserProfile_ConnectID] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Lock] [int] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserProfile_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 09/19/2017 10:10:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoles_ID] [int] IDENTITY(1,1) NOT NULL,
	[Roles_ID] [int] NULL,
	[UserProfile_ID] [int] NULL,
	[Is_Active] [bit] NULL,
	[Display_Order] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoles_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((1)) FOR [Is_TopPage]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((0)) FOR [Is_LeftPage]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((0)) FOR [Is_RightPage]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((1)) FOR [Is_BottomPage]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Create__3A81B327]  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Update__3B75D760]  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Lock__3C69FB99]  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Is_Act__3D5E1FD2]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Is_HomePage]  DEFAULT ((1)) FOR [Is_HomePage]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Is_TopMenu]  DEFAULT ((0)) FOR [Is_TopMenu]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Is_BottomMenu]  DEFAULT ((1)) FOR [Is_BottomMenu]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Display_Order]  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact__Contact__756D6ECB]  DEFAULT (sysdatetime()) FOR [Contact_Date]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact__Is_Acti__76619304]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT (sysdatetime()) FOR [OrderDetail_Date]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [OrderDetail_Status]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[OrderMaster] ADD  DEFAULT ((0)) FOR [Total]
GO
ALTER TABLE [dbo].[OrderMaster] ADD  DEFAULT (sysdatetime()) FOR [OrderMaster_Date]
GO
ALTER TABLE [dbo].[OrderMaster] ADD  DEFAULT ((0)) FOR [OrderMaster_Status]
GO
ALTER TABLE [dbo].[OrderMaster] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[OrderMaster] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((1)) FOR [Is_TopPage]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((0)) FOR [Is_LeftPage]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((0)) FOR [Is_RightPage]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((1)) FOR [Is_BottomPage]
GO
ALTER TABLE [dbo].[PageSetting] ADD  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__CreateD__534D60F1]  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__UpdateD__5441852A]  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Product__5535A963]  DEFAULT ((0)) FOR [Product_View]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Lock__5629CD9C]  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Is_Acti__571DF1D5]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Is_HomePage]  DEFAULT ((1)) FOR [Is_HomePage]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Is_TopMenu]  DEFAULT ((0)) FOR [Is_TopMenu]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Is_BottomMenu]  DEFAULT ((1)) FOR [Is_BottomMenu]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Display_Order]  DEFAULT ((0)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [Is_LeftPage]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [Is_RightPage]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((0)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[UserProfile] ADD  DEFAULT (sysdatetime()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[UserProfile] ADD  DEFAULT (sysdatetime()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[UserProfile] ADD  DEFAULT ((0)) FOR [Lock]
GO
ALTER TABLE [dbo].[UserProfile] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[UserRoles] ADD  DEFAULT ((0)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[UserRoles] ADD  DEFAULT ((1)) FOR [Display_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_OrderMaster] FOREIGN KEY([OrderMaster_ID])
REFERENCES [dbo].[OrderMaster] ([OrderMaster_ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_OrderMaster]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([Product_ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[OrderMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderMaster_UserProfile] FOREIGN KEY([UserProfile_ID])
REFERENCES [dbo].[UserProfile] ([UserProfile_ID])
GO
ALTER TABLE [dbo].[OrderMaster] CHECK CONSTRAINT [FK_OrderMaster_UserProfile]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category_Parent_ID])
REFERENCES [dbo].[Category] ([Category_ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([Roles_ID])
REFERENCES [dbo].[Roles] ([Roles_ID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_UserProfile] FOREIGN KEY([UserProfile_ID])
REFERENCES [dbo].[UserProfile] ([UserProfile_ID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_UserProfile]
GO
USE [master]
GO
ALTER DATABASE [EShop] SET  READ_WRITE 
GO
