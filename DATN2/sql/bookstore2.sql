USE [BookStore2]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phone] [nchar](12) NULL,
	[email] [nchar](100) NULL,
	[password] [nchar](50) NULL,
	[salt] [nchar](6) NULL,
	[active] [bit] NOT NULL,
	[name] [nchar](100) NULL,
	[roleId] [int] NULL,
	[lastLogin] [date] NULL,
	[createDate] [date] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[author]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[story] [nvarchar](500) NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[description] [nvarchar](max) NULL,
	[parentId] [int] NULL,
	[levels] [int] NULL,
	[odering] [int] NULL,
	[published] [bit] NOT NULL,
	[thums] [nvarchar](100) NULL,
	[title] [nvarchar](100) NULL,
	[cover] [nvarchar](100) NULL,
	[alias] [nvarchar](50) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
	[birthDay] [date] NULL,
	[avatar] [nvarchar](50) NULL,
	[address] [nvarchar](500) NULL,
	[email] [varchar](500) NULL,
	[phone] [nchar](12) NULL,
	[createDate] [date] NULL,
	[password] [nvarchar](50) NULL,
	[satl] [nchar](10) NULL,
	[lastLogin] [date] NULL,
	[active] [bit] NOT NULL,
	[locationId] [int] NULL,
	[district] [int] NULL,
	[ward] [int] NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[location]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[NameWithType] [nvarchar](50) NULL,
	[PathWithType] [nvarchar](50) NULL,
	[ParentCode] [int] NULL,
	[Level] [int] NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NULL,
	[orderDate] [date] NULL,
	[shipDate] [date] NULL,
	[statusId] [int] NULL,
	[deleted] [bit] NULL,
	[paid] [bit] NULL,
	[payDate] [date] NULL,
	[payId] [int] NULL,
	[note] [nvarchar](500) NULL,
	[address] [nvarchar](50) NULL,
	[locationId] [int] NULL,
	[district] [int] NULL,
	[ward] [int] NULL,
	[totalMoney] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderDetail]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NULL,
	[produceId] [int] NULL,
	[orderNumber] [int] NULL,
	[quantity] [int] NULL,
	[discount] [int] NULL,
	[total] [int] NULL,
	[shipDate] [date] NULL,
	[amount] [int] NULL,
	[totalMoney] [int] NULL,
	[createDate] [date] NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_orderDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produce]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produce](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[desciption] [nvarchar](500) NULL,
	[catId] [int] NULL,
	[autId] [int] NULL,
	[price] [int] NULL,
	[discount] [int] NULL,
	[thumb] [nvarchar](50) NULL,
	[bestSell] [bit] NOT NULL,
	[homeFlag] [bit] NOT NULL,
	[active] [bit] NOT NULL,
	[tag] [nvarchar](500) NULL,
	[unitslnStock] [int] NULL,
	[datecreate] [date] NULL,
	[alias] [nvarchar](50) NULL,
	[nhaXB] [nvarchar](100) NULL,
 CONSTRAINT [PK_produce] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transitionStatus]    Script Date: 15/05/2023 06:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transitionStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_transitionStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 

INSERT [dbo].[accounts] ([id], [phone], [email], [password], [salt], [active], [name], [roleId], [lastLogin], [createDate]) VALUES (15, N'0355555555  ', N'nhanvien2@gmail.com                                                                                 ', N'c7398666f17bbdd193fc43017c6d5a15                  ', N't:@a5 ', 1, N'Nhân viên 2                                                                                         ', 2, CAST(N'2023-05-14' AS Date), NULL)
INSERT [dbo].[accounts] ([id], [phone], [email], [password], [salt], [active], [name], [roleId], [lastLogin], [createDate]) VALUES (16, N'0355555666  ', N'admin@gmail.com                                                                                     ', N'0ba0788a330ec86dcc98125384ee3248                  ', N'1]l@c ', 1, N'Admin                                                                                               ', 1, CAST(N'2023-05-15' AS Date), NULL)
INSERT [dbo].[accounts] ([id], [phone], [email], [password], [salt], [active], [name], [roleId], [lastLogin], [createDate]) VALUES (17, N'035444888   ', N'admin2@gmail.com                                                                                    ', N'b22456452f855177aedd2216f618b6db                  ', N'9x}%b ', 1, N'Admin 2                                                                                             ', 1, CAST(N'2023-05-14' AS Date), NULL)
INSERT [dbo].[accounts] ([id], [phone], [email], [password], [salt], [active], [name], [roleId], [lastLogin], [createDate]) VALUES (18, N'123456      ', N'nhanvien1@gmail.com                                                                                 ', N'8f5e1f187c181d5c6bc40de25c766c06                  ', N')v!fz ', 1, N'Nhân viên 1                                                                                         ', 2, CAST(N'2023-05-14' AS Date), NULL)
INSERT [dbo].[accounts] ([id], [phone], [email], [password], [salt], [active], [name], [roleId], [lastLogin], [createDate]) VALUES (19, N'033322555   ', N'admin1@gmail.com                                                                                    ', N'9d862305c64e3179982616a9f5268234                  ', N'aowa6 ', 1, N'Admin 1                                                                                             ', 1, CAST(N'2023-05-14' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[author] ON 

INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (9, N'Miêu Công Tử', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (10, N'Gege Akutami', N'Đức', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (11, N'José Mauro de Vasconcelos', N'Pháp', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (12, N'Paulo Coelho', N'Anh', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (13, N'Tatsuki Fujimoto', N'Nhật Bản', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (14, N'Muneyuki Kaneshiro', N'Nhật bản', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (15, N'Atsushi Ohkubo', N'Nhật Bản', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (16, N'Lâu Vũ Tình', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (17, N'Thương Thái Vi', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (18, N'Bạch Lạc Mai', N'Trung Quốc', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (19, N'Diệp Lạc', N'Bắc Kinh - Trung Quốc', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (20, N'Daniel Howarth', N'Anh', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (21, N'Antoine De Saint-Exupéry', N'Pháp', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (22, N'Phùng Quán', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (23, N'Khotudien', N'Việt Nam', N'Một hai ba bốn năm')
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (24, N'Lân', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (25, N'Hubert Seipel', N'Nga', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (26, N'Công ty Phan Thị', N'Việt Nam', NULL)
INSERT [dbo].[author] ([id], [name], [address], [story]) VALUES (27, N'Thanh Anh', N'Việt Nam', NULL)
SET IDENTITY_INSERT [dbo].[author] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (12, N'Ngôn Tình', N'Ngôn tình', 1, 1, 1, 1, N'ngon-tinh.jpg', N'1', N'1', N'ngon-tinh')
INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (13, N'Manga', N'Manga', 1, 1, 1, 1, N'manga.jpg', N'1', N'1', N'manga')
INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (14, N'Tiểu Thuyết', N'Tiểu thuyết', 1, 1, 1, 1, N'tieu-thuyet.jpg', N'1', N'1', N'tieu-thuyet')
INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (15, N'Thiếu Nhi', N'Thiếu nhi', 1, 1, 1, 1, N'thieu-nhi.jpg', N'1', N'1', N'thieu-nhi')
INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (17, N'Chính Trị', N'Chính trị', 1, 1, 1, 1, N'chinh-tri.jpg', N'1', N'1', N'chinh-tri')
INSERT [dbo].[category] ([id], [name], [description], [parentId], [levels], [odering], [published], [thums], [title], [cover], [alias]) VALUES (18, N'Truyện Ngắn', N'Truyện ngắn', 1, 1, 1, 1, N'truyen-ngan.jpg', N'1', N'1', N'truyen-ngan')
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (9, N'Chu Bá Hưởng 2', NULL, NULL, N'Bắc ninh', N'chubahuongltkka@gmail.com', N'55555       ', CAST(N'2023-04-30' AS Date), N'd56917c4ec63d0f983d5fff44514682a', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (10, N'Chu Bá Hưởng', NULL, NULL, N'Xóm Bãi đa - xã Quảng Minh - huyện Việt Yên tỉnh Bắc Giang', N'chubahuongltkka2@gmail.com', N'12345       ', CAST(N'2023-04-30' AS Date), N'd3fbba59d2298a28f5314914ec905130', N'h}3eo     ', NULL, 1, 0, 0, 0)
INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (13, N'Phạm Quốc Hòa', NULL, NULL, N'Thanh Xuân-Hà Nội', N'hoapham@gmail.com', N'035557778   ', CAST(N'2023-05-11' AS Date), N'114791abffb2671d4596db16aaa5335f', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (16, N'Phạm Quốc Hòa', NULL, NULL, N'Quảng Minh-Việt Yên-Bắc Giang', N'hoapham2@gmail.com', N'23423132412 ', CAST(N'2023-05-13' AS Date), N'30c878918728792673ff94493101157e', N'5h~^x     ', NULL, 1, 0, 0, 0)
INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (17, N'Nguyễn Ngọc Hưng', NULL, NULL, N'Cây xăng - Làng Lát thượng- Tiên Sơn- Việt Yên- Bắc Giang', N'hungnguyen@gmail.com', N'0321445556  ', CAST(N'2023-05-14' AS Date), N'3e19f174a2b4cd240ca482f57dcbaec7', N'bi~&~     ', NULL, 1, 0, 0, 0)
INSERT [dbo].[customer] ([id], [name], [birthDay], [avatar], [address], [email], [phone], [createDate], [password], [satl], [lastLogin], [active], [locationId], [district], [ward]) VALUES (18, N'Nguyễn Minh Trường', NULL, NULL, N'Minh Khai Hà Nội', N'truongnguyen@gmail.com', N'0989999666  ', CAST(N'2023-05-15' AS Date), N'0189fe367c3ed5cb16c55c460d5232dc', N'w&!5j     ', NULL, 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[location] ON 

INSERT [dbo].[location] ([Id], [Name], [Type], [Slug], [NameWithType], [PathWithType], [ParentCode], [Level]) VALUES (1, N'Bắc Giang', N'1', N'1', N'1', N'1', 1, 1)
INSERT [dbo].[location] ([Id], [Name], [Type], [Slug], [NameWithType], [PathWithType], [ParentCode], [Level]) VALUES (2, N'Việt Yên', N'1', N'1', N'1', N'1', 1, 2)
INSERT [dbo].[location] ([Id], [Name], [Type], [Slug], [NameWithType], [PathWithType], [ParentCode], [Level]) VALUES (3, N'Quảng Minh', N'1', N'1', N'1', N'1', 1, 3)
SET IDENTITY_INSERT [dbo].[location] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (13, 9, CAST(N'2023-04-30' AS Date), CAST(N'2023-05-01' AS Date), 4, 1, 1, CAST(N'2023-05-07' AS Date), NULL, NULL, N'Bắc ninh', 0, 0, 0, 129000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (14, 10, CAST(N'2023-04-30' AS Date), NULL, 4, 1, 1, NULL, NULL, NULL, N'Pháp', 0, 0, 0, 58000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (15, 10, CAST(N'2023-04-30' AS Date), NULL, 4, 0, 1, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 116000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (16, 9, CAST(N'2023-04-30' AS Date), NULL, 1, 0, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 58000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (17, 9, CAST(N'2023-04-30' AS Date), NULL, 5, 1, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 385000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (18, 9, CAST(N'2023-04-30' AS Date), CAST(N'2023-05-01' AS Date), 4, 0, 1, CAST(N'2023-05-01' AS Date), NULL, NULL, N'Bắc ninh', 0, 0, 0, 150000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (19, 9, CAST(N'2023-04-30' AS Date), CAST(N'2023-05-01' AS Date), 3, 0, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 862000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (20, 10, CAST(N'2023-05-05' AS Date), NULL, 4, 0, 1, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 90000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (21, 10, CAST(N'2023-05-07' AS Date), NULL, 1, 0, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 59000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (22, 10, CAST(N'2023-05-11' AS Date), CAST(N'2023-05-11' AS Date), 4, 0, 1, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 30000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (23, 13, CAST(N'2023-05-11' AS Date), CAST(N'2023-05-11' AS Date), 4, 0, 1, NULL, NULL, NULL, NULL, 0, 0, 0, 544000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (24, 10, CAST(N'2023-05-12' AS Date), CAST(N'2023-05-12' AS Date), 4, 0, 1, CAST(N'2023-05-12' AS Date), NULL, NULL, N'Bắc ninh', 0, 0, 0, 578000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (25, 10, CAST(N'2023-05-12' AS Date), NULL, 5, 1, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 201000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (26, 10, CAST(N'2023-05-12' AS Date), NULL, 5, 1, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 852000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (27, 16, CAST(N'2023-05-13' AS Date), CAST(N'2023-05-13' AS Date), 4, 0, 1, NULL, NULL, NULL, NULL, 0, 0, 0, 218000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (28, 17, CAST(N'2023-05-14' AS Date), CAST(N'2023-05-14' AS Date), 4, 0, 1, NULL, NULL, NULL, NULL, 0, 0, 0, 142000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (29, 10, CAST(N'2023-05-14' AS Date), NULL, 2, 0, 0, NULL, NULL, NULL, N'Bắc ninh', 0, 0, 0, 78000)
INSERT [dbo].[order] ([id], [customerId], [orderDate], [shipDate], [statusId], [deleted], [paid], [payDate], [payId], [note], [address], [locationId], [district], [ward], [totalMoney]) VALUES (30, 18, CAST(N'2023-05-15' AS Date), CAST(N'2023-05-15' AS Date), 4, 0, 1, NULL, NULL, NULL, NULL, 0, 0, 0, 296000)
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[orderDetail] ON 

INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (1, 13, 24, NULL, 1, NULL, NULL, NULL, 1, 129000, CAST(N'2023-04-30' AS Date), 129000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (2, 14, 92, NULL, 1, NULL, NULL, NULL, 1, 58000, CAST(N'2023-04-30' AS Date), 58000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (3, 15, 92, NULL, 1, NULL, NULL, NULL, 1, 116000, CAST(N'2023-04-30' AS Date), 58000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (4, 15, 94, NULL, 1, NULL, NULL, NULL, 1, 116000, CAST(N'2023-04-30' AS Date), 58000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (5, 16, 92, NULL, 1, NULL, NULL, NULL, 1, 58000, CAST(N'2023-04-30' AS Date), 58000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (6, 17, 23, NULL, 1, NULL, NULL, NULL, 1, 385000, CAST(N'2023-04-30' AS Date), 59000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (7, 17, 49, NULL, 3, NULL, NULL, NULL, 3, 385000, CAST(N'2023-04-30' AS Date), 26000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (8, 17, 22, NULL, 2, NULL, NULL, NULL, 2, 385000, CAST(N'2023-04-30' AS Date), 81000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (9, 18, 58, NULL, 4, NULL, NULL, NULL, 4, 120000, CAST(N'2023-04-30' AS Date), 27000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (10, 18, 34, NULL, 1, NULL, NULL, NULL, 1, 30000, CAST(N'2023-04-30' AS Date), 26000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (11, 19, 23, NULL, 5, NULL, NULL, NULL, 5, 295000, CAST(N'2023-04-30' AS Date), 59000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (12, 19, 22, NULL, 7, NULL, NULL, NULL, 7, 567000, CAST(N'2023-04-30' AS Date), 81000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (13, 20, 93, NULL, 3, NULL, NULL, NULL, 3, 90000, CAST(N'2023-05-05' AS Date), 30000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (14, 21, 23, NULL, 1, NULL, NULL, NULL, 1, 59000, CAST(N'2023-05-07' AS Date), 59000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (15, 22, 93, NULL, 1, NULL, NULL, NULL, 1, 30000, CAST(N'2023-05-08' AS Date), 30000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (16, 23, 35, NULL, 4, NULL, NULL, NULL, 4, 108000, CAST(N'2023-05-11' AS Date), 27000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (17, 23, 24, NULL, 4, NULL, NULL, NULL, 4, 436000, CAST(N'2023-05-11' AS Date), 109000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (18, 24, 24, NULL, 4, NULL, NULL, NULL, 4, 436000, CAST(N'2023-05-12' AS Date), 109000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (19, 24, 81, NULL, 1, NULL, NULL, NULL, 1, 142000, CAST(N'2023-05-12' AS Date), 142000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (20, 25, 93, NULL, 4, NULL, NULL, NULL, 4, 120000, CAST(N'2023-05-12' AS Date), 30000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (21, 25, 22, NULL, 1, NULL, NULL, NULL, 1, 81000, CAST(N'2023-05-12' AS Date), 81000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (22, 26, 81, NULL, 6, NULL, NULL, NULL, 6, 852000, CAST(N'2023-05-12' AS Date), 142000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (23, 27, 24, NULL, 2, NULL, NULL, NULL, 2, 218000, CAST(N'2023-05-13' AS Date), 109000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (24, 28, 71, NULL, 1, NULL, NULL, NULL, 1, 142000, CAST(N'2023-05-14' AS Date), 142000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (25, 29, 34, NULL, 3, NULL, NULL, NULL, 3, 78000, CAST(N'2023-05-14' AS Date), 26000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (26, 30, 101, NULL, 2, NULL, NULL, NULL, 2, 60000, CAST(N'2023-05-15' AS Date), 30000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (27, 30, 80, NULL, 3, NULL, NULL, NULL, 3, 177000, CAST(N'2023-05-15' AS Date), 59000)
INSERT [dbo].[orderDetail] ([id], [orderId], [produceId], [orderNumber], [quantity], [discount], [total], [shipDate], [amount], [totalMoney], [createDate], [price]) VALUES (28, 30, 79, NULL, 1, NULL, NULL, NULL, 1, 59000, CAST(N'2023-05-15' AS Date), 59000)
SET IDENTITY_INSERT [dbo].[orderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[produce] ON 

INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (11, N'Fire Force - Tập 2', N'Fire Force - Tập 2 ', 13, 15, 40000, 37000, N'fire-force-tap-2.jpg', 0, 0, 1, NULL, 12, NULL, N'fire-force-tap-2', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (12, N'Chainsaw Man - Tập 9', N'Chainsaw Man - Tập 9', 13, 13, 30000, 27000, N'chainsaw-man-tap-9.jpg', 0, 0, 1, NULL, 9, CAST(N'2023-04-21' AS Date), N'chainsaw-man-tap-9', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (13, N'BlueLock - Tập 4', N'BlueLock - Tập 4', 13, 14, 35000, 30000, N'bluelock-tap-4.jpg', 0, 0, 1, NULL, 23, CAST(N'2023-04-21' AS Date), N'bluelock-tap-4', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (22, N'Cây Cam Ngọt Của Tôi', N'Cây Cam Ngọt Của Tôi', 14, 11, 108000, 81000, N'cay-cam-ngot-cua-toi.jpg', 1, 1, 1, NULL, 3, NULL, N'cay-cam-ngot-cua-toi', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (23, N'Nhà Giả Kim Tập 1', N'Nhà Giả Kim Tập 1', 14, 12, 79000, 59000, N'nha-gia-kim-tap-1.jpg', 0, 1, 1, NULL, 6, NULL, N'nha-gia-kim-tap-1', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (24, N'999 Lá Thư Gửi Cho Chính Mình', N'Bắt đầu từ hôm nay, mỗi ngày hãy luôn nở nụ cười trên môi, trên đời này ngoài sinh tử ra mọi sự đều là chuyện nhỏ. Cho dù gặp phải chuyện phiền lòng cũng đừng tự làm khó mình; bất luận hôm nay xảy ra bao nhiêu chuyện đen đủi, đều không nên cảm thấy bi thương. Hôm nay là ngày bạn trẻ nhất trong những ngày tháng sau này, vì còn có ngày mai, hôm nay mãi chỉ là bước khởi đầu của con đường tương lai.', 12, 9, 129000, 109000, N'999-la-thu-gui-cho-chinh-minh.jpg', 1, 1, 1, NULL, 52, NULL, N'999-la-thu-gui-cho-chinh-minh', NULL)
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (25, N'Nếu Không Là Tình Yêu', N'Nếu Không Là Tình Yêu (Tái Bản 2019)', 12, 19, 132000, 95000, N'neu-khong-la-tinh-yeu.png', 0, 0, 1, NULL, 5, CAST(N'2023-04-21' AS Date), N'neu-khong-la-tinh-yeu', N'NXB Văn Học')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (26, N'Gặp Lại Chốn Hồng Trần Sâu Nhất', N'Gặp Lại Chốn Hồng Trần Sâu Nhất - Tái Bản 2019', 12, 18, 119000, 99000, N'gap-lai-chon-hong-tran-sau-nhat.jpg', 0, 0, 1, NULL, 21, CAST(N'2023-04-21' AS Date), N'gap-lai-chon-hong-tran-sau-nhat', N'NXB Lao Động')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (27, N'Bến Xe - Tập 1', N'Bến Xe (Tái Bản 2020)', 12, 17, 86000, 53000, N'ben-xe-tap-1.png', 0, 0, 1, NULL, 14, NULL, N'ben-xe-tap-1', N'NXB Văn Học')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (28, N'Thất Tịch Không Mưa', N'Thất Tịch Không Mưa', 12, 16, 86000, 60000, N'that-tich-khong-mua.png', 0, 0, 1, NULL, 30, CAST(N'2023-04-21' AS Date), N'that-tich-khong-mua', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (30, N'Những Lời Yêu Thương Của Con Trẻ', N'Những Lời Yêu Thương Của Con Trẻ', 12, 20, 25000, 21000, N'nhung-loi-yeu-thuong-cua-con-tre.jpg', 0, 0, 1, NULL, 20, NULL, N'nhung-loi-yeu-thuong-cua-con-tre', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (31, N'Hoàng Tử Bé', N'Hoàng Tử Bé', 15, 21, 35000, 33000, N'hoang-tu-be.jpg', 1, 1, 1, NULL, 21, NULL, N'hoang-tu-be', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (32, N'Tuổi Thơ Dữ Dội - Tập 2', N'Tuổi Thơ Dữ Dội - Tập 2 (Tái Bản 2019)', 15, 22, 90000, 68000, N'tuoi-tho-du-doi-tap-2.jpg', 0, 0, 1, NULL, 15, CAST(N'2023-04-21' AS Date), N'tuoi-tho-du-doi-tap-2', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (33, N'Tuổi Thơ Dữ Dội - Tập 3 ', N'Tuổi Thơ Dữ Dội - Tập 2 (Tái Bản 2019)', 15, 22, 30000, 26000, N'tuoi-tho-du-doi-tap-3.jpg', 0, 0, 1, NULL, 12, CAST(N'2023-04-21' AS Date), N'tuoi-tho-du-doi-tap-3', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (34, N'Tuổi Thơ Dữ Dội - Tập 1', N'Tuổi Thơ Dữ Dội - Tập 1(Tái Bản 2019)', 15, 22, 30000, 26000, N'tuoi-tho-du-doi-tap-1.jpg', 1, 1, 1, NULL, 9, NULL, N'tuoi-tho-du-doi-tap-1', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (35, N'Fire Force - Tập 1', N'Fire Force - Tập 1', 13, 13, 30000, 27000, N'fire-force-tap-1.jpg', 1, 1, 1, NULL, 19, NULL, N'fire-force-tap-1', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (36, N'Bến Xe - Tập 2', N'Bến Xe - Tập 2', 12, 17, 86000, 53000, N'ben-xe-tap-2.png', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'ben-xe-tap-2', N'NXB Văn Học')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (37, N'Bến Xe - Tập 3', N'Bến Xe - Tập 3', 12, 17, 86000, 53000, N'ben-xe-tap-3.png', 0, 0, 1, NULL, 32, CAST(N'2023-04-21' AS Date), N'ben-xe-tap-3', N'NXB Văn Học')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (38, N'BlueLock - Tập 1', N'BlueLock - Tập 1', 13, 14, 35000, 30000, N'bluelock-tap-1.jpg', 1, 1, 1, NULL, 23, NULL, N'bluelock-tap-1', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (39, N'BlueLock - Tập 2', N'BlueLock - Tập 2', 13, 14, 35000, 30000, N'bluelock-tap-2.jpg', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'bluelock-tap-2', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (40, N'BlueLock - Tập 3', N'BlueLock - Tập 3', 13, 14, 35000, 30000, N'bluelock-tap-3.jpg', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'bluelock-tap-3', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (47, N'Chú Thuật Hồi Chiến - Tập 1', N'Chú Thuật Hồi Chiến - Tập 1', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-1.jpg', 0, 0, 1, NULL, 12, NULL, N'chu-thuat-hoi-chien-tap-1', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (48, N'Chú Thuật Hồi Chiến - Tập 4', N'Chú thuật hồi chiến - Tập 4', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-4.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-4', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (49, N'Chú Thuật Hồi Chiến - Tập 5', N'Chú thuật hồi chiến - Tập 5', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-5.jpg', 1, 1, 1, NULL, 12, NULL, N'chu-thuat-hoi-chien-tap-5', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (50, N'Chú Thuật Hồi Chiến - Tập 6', N'Chú thuật hồi chiến - Tập 6', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-6.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-6', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (51, N'Chú Thuật Hồi Chiến - Tập 7', N'Chú thuật hồi chiến - Tập 7', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-7.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-7', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (52, N'Chú Thuật Hồi Chiến - Tập 8', N'Chú thuật hồi chiến - Tập 8', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-8.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-8', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (53, N'Chú Thuật Hồi Chiến - Tập 9', N'Chú thuật hồi chiến - Tập 9', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-9.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-9', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (54, N'Chú Thuật Hồi Chiến - Tập 10', N'Chú thuật hồi chiến - Tập 10', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-10.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-10', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (55, N'Chú Thuật Hồi Chiến - Tập 11', N'Chú thuật hồi chiến - Tập 11', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-11.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-11', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (56, N'Chú Thuật Hồi Chiến - Tập 3', N'Chú thuật hồi chiến - Tập 3', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-3.jpg', 0, 0, 1, NULL, 15, NULL, N'chu-thuat-hoi-chien-tap-3', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (58, N'Chainsaw Man - Tập 1', N'Chainsaw Man - Tập 1', 13, 13, 30000, 27000, N'chainsaw-man-tap-1.jpg', 1, 1, 1, NULL, 11, NULL, N'chainsaw-man-tap-1', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (59, N'Chainsaw Man - Tập 2', N'Chainsaw Man - Tập 2', 13, 13, 30000, 27000, N'chainsaw-man-tap-2.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-2', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (60, N'Chainsaw Man - Tập 3', N'Chainsaw Man - Tập 3', 13, 13, 30000, 27000, N'chainsaw-man-tap-3.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-3', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (61, N'Chainsaw Man - Tập 4', N'Chainsaw Man - Tập 4', 13, 13, 30000, 27000, N'chainsaw-man-tap-4.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-4', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (62, N'Chainsaw Man - Tập 5', N'Chainsaw Man - Tập 5', 13, 13, 30000, 27000, N'chainsaw-man-tap-5.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-5', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (63, N'Chainsaw Man - Tập 6', N'Chainsaw Man - Tập 6', 13, 13, 30000, 27000, N'chainsaw-man-tap-6.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-6', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (64, N'Chainsaw Man - Tập 7', N'Chainsaw Man - Tập 7', 13, 13, 30000, 27000, N'chainsaw-man-tap-7.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-7', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (65, N'Chainsaw Man - Tập 8', N'Chainsaw Man - Tập 8', 13, 13, 30000, 27000, N'chainsaw-man-tap-8.jpg', 0, 0, 1, NULL, 15, NULL, N'chainsaw-man-tap-8', N'Trẻ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (67, N'Chú Thuật Hồi Chiến - Tập 2', N'Chú thuật hồi chiến - Tập 2', 13, 10, 30000, 26000, N'chu-thuat-hoi-chien-tap-2.jpg', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'chu-thuat-hoi-chien-tap-2', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (68, N'Từ Điển Tiếng “Em”', N'Từ Điển Tiếng “Em” - Tái Bản 2021', 18, 23, 69000, 51000, N'tu-dien-tieng-em.jpg', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'tu-dien-tieng-em', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (69, N'Tôi Có Triệu Chứng Cứ Yêu Em', N'Tôi Có Triệu Chứng Cứ Yêu Em', 18, 23, 84000, 76000, N'toi-co-trieu-chung-cu-yeu-em.jpg', 0, 0, 1, NULL, 13, CAST(N'2023-04-21' AS Date), N'toi-co-trieu-chung-cu-yeu-em', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (70, N'Lê La Từ Nhà Ra Ngõ Tập 1', N'Lê La Từ Nhà Ra Ngõ Tập 1', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo-tap-1.jpg', 0, 0, 1, NULL, 23, NULL, N'le-la-tu-nha-ra-ngo-tap-1', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (71, N'Putin - Logic Của Quyền Lực Tập 1', N'Putin - Logic Của Quyền Lực Tập 1', 17, 25, 168000, 142000, N'putin-logic-cua-quyen-luc-tap-1.jpg', 0, 0, 1, NULL, 22, NULL, N'putin-logic-cua-quyen-luc-tap-1', N'NXB Tổng Hợp TPHCM')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (75, N'Nhà Giả Kim Tập 2', N'Nhà Giả Kim Tập 2', 14, 12, 70000, 59000, N'nha-gia-kim-tap-2.jpg', 0, 0, 1, NULL, 18, NULL, N'nha-gia-kim-tap-2', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (76, N'Nhà Giả Kim Tập 3', N'Nhà Giả Kim Tập 3', 14, 12, 70000, 59000, N'nha-gia-kim.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'nha-gia-kim-tap-3', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (77, N'Nhà Giả Kim Tập 4', N'Nhà Giả Kim Tập 4', 14, 12, 70000, 59000, N'nha-gia-kim.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'nha-gia-kim-tap-4', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (78, N'Nhà Giả Kim Tập 5', N'Nhà Giả Kim Tập 5', 14, 12, 70000, 59000, N'nha-gia-kim.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'nha-gia-kim-tap-5', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (79, N'Nhà Giả Kim Tập 6', N'Nhà Giả Kim Tập 6', 14, 12, 70000, 59000, N'nha-gia-kim.jpg', 0, 0, 1, NULL, 17, CAST(N'2023-04-21' AS Date), N'nha-gia-kim-tap-6', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (80, N'Nhà Giả Kim Tập 7', N'Nhà Giả Kim Tập 7', 14, 12, 70000, 59000, N'nha-gia-kim.jpg', 0, 0, 1, NULL, 15, CAST(N'2023-04-21' AS Date), N'nha-gia-kim-tap-7', N'NXB Hội Nhà Văn')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (81, N'Putin - Logic Của Quyền Lực Tập 2', N'Putin - Logic Của Quyền Lực Tập 2', 17, 25, 168000, 142000, N'putin-logic-cua-quyen-luc.jpg', 0, 0, 1, NULL, 11, CAST(N'2023-04-21' AS Date), N'putin-logic-cua-quyen-luc-tap-2', N'NXB Tổng Hợp TPHCM')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (82, N'Putin - Logic Của Quyền Lực Tập 3', N'Putin - Logic Của Quyền Lực Tập 3', 17, 25, 168000, 142000, N'putin-logic-cua-quyen-luc.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'putin-logic-cua-quyen-luc-tap-3', N'NXB Tổng Hợp TPHCM')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (83, N'Putin - Logic Của Quyền Lực Tập 4', N'Putin - Logic Của Quyền Lực Tập 4', 17, 25, 168000, 142000, N'putin-logic-cua-quyen-luc.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'putin-logic-cua-quyen-luc-tap-4', N'NXB Tổng Hợp TPHCM')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (84, N'Putin - Logic Của Quyền Lực Tập 5', N'Putin - Logic Của Quyền Lực Tập 5', 17, 25, 168000, 142000, N'putin-logic-cua-quyen-luc.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'putin-logic-cua-quyen-luc-tap-5', N'NXB Tổng Hợp TPHCM')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (85, N'Lê La Từ Nhà Ra Ngõ Tập 2', N'Lê La Từ Nhà Ra Ngõ Tập 2', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-2', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (86, N'Lê La Từ Nhà Ra Ngõ Tập 7', N'Lê La Từ Nhà Ra Ngõ Tập 7', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-7', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (87, N'Lê La Từ Nhà Ra Ngõ Tập 3', N'Lê La Từ Nhà Ra Ngõ Tập 3', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-3', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (88, N'Lê La Từ Nhà Ra Ngõ Tập 4', N'Lê La Từ Nhà Ra Ngõ Tập 4', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-4', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (89, N'Lê La Từ Nhà Ra Ngõ Tập 5', N'Lê La Từ Nhà Ra Ngõ Tập 5', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-5', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (90, N'Lê La Từ Nhà Ra Ngõ Tập 6', N'Lê La Từ Nhà Ra Ngõ Tập 6', 18, 24, 89000, 69000, N'le-la-tu-nha-ra-ngo.jpg', 0, 0, 1, NULL, 18, CAST(N'2023-04-21' AS Date), N'le-la-tu-nha-ra-ngo-tap-6', N'Phụ nữ')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (92, N'Bác Hồ Sống Mãi Tập 1', N'Sinh thời, Chủ tịch Hồ Chí Minh luôn dành cho các cháu thiếu niên, nhi đồng – Mầm non tương lai của đất nước, tình thương yêu vô bờ bến. Dù bận trăm công, nghìn việc nhưng Bác luôn dành thời gian thăm và trò chuyện cùng các cháu thiếu niên, nhi đồng ở trại trẻ mồ côi, ở trường học, ở nhà. Bác thường xuyên viết thư thăm hỏi, động viên các cháu trong dịp khai trường, tết trung thu, tết thiếu nhi,... Tình thương bác dành cho nhi đồng Việt Nam ', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-1.jpg', 0, 1, 1, NULL, 12, NULL, N'bac-ho-song-mai-tap-1', N'Kim đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (93, N'Mẹ Hỏi Bé Trả Lời Tập 1', N'Mẹ Hỏi Bé Trả Lời Tập 1', 15, 27, 36000, 30000, N'me-hoi-be-tra-loi-tap-1.jpg', 0, 0, 1, NULL, 7, CAST(N'2023-04-22' AS Date), N'me-hoi-be-tra-loi-tap-1', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (94, N'Bác Hồ Sống Mãi Tập 2', N'Sinh thời, Chủ tịch Hồ Chí Minh luôn dành cho các cháu thiếu niên, nhi đồng – Mầm non tương lai của đất nước, tình thương yêu vô bờ bến. Dù bận trăm công, nghìn việc nhưng Bác luôn dành thời gian thăm và trò chuyện cùng các cháu thiếu niên, nhi đồng ở trại trẻ mồ côi, ở trường học, ở nhà. Bác thường xuyên viết thư thăm hỏi, động viên các cháu trong dịp khai trường, tết trung thu, tết thiếu nhi,... Tình thương bác dành cho nhi đồng Việt Nam', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-2.jpg', 1, 1, 1, NULL, 34, NULL, N'bac-ho-song-mai-tap-2', N'Kim đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (95, N'Bác Hồ Sống Mãi Tập 3', N'Bác Hồ Sống Mãi Tập 3', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-3.jpg', 0, 0, 1, NULL, 35, NULL, N'bac-ho-song-mai-tap-3', NULL)
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (96, N'Bác Hồ Sống Mãi Tập 4', N'Bác Hồ Sống Mãi Tập 4', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'bac-ho-song-mai-tap-4', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (97, N'Bác Hồ Sống Mãi Tập 5', N'Bác Hồ Sống Mãi Tập 5', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'bac-ho-song-mai-tap-5', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (98, N'Bác Hồ Sống Mãi Tập 6', N'Bác Hồ Sống Mãi Tập 6', 15, 26, 58000, 49000, N'bac-ho-song-mai-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'bac-ho-song-mai-tap-6', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (99, N'Mẹ Hỏi Bé Trả Lời Tập 2', N'Mẹ Hỏi Bé Trả Lời Tập 2', 15, 27, 38000, 30000, N'me-hoi-be-tra-loi-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'me-hoi-be-tra-loi-tap-2', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (100, N'Mẹ Hỏi Bé Trả Lời Tập 3', N'Mẹ Hỏi Bé Trả Lời Tập 3', 15, 27, 38000, 30000, N'me-hoi-be-tra-loi-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'me-hoi-be-tra-loi-tap-3', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (101, N'Mẹ Hỏi Bé Trả Lời Tập 4', N'Mẹ Hỏi Bé Trả Lời Tập 4', 15, 27, 38000, 30000, N'me-hoi-be-tra-loi-tap-1.jpg', 0, 0, 1, NULL, 33, CAST(N'2023-04-22' AS Date), N'me-hoi-be-tra-loi-tap-4', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (102, N'Mẹ Hỏi Bé Trả Lời Tập 5', N'Mẹ Hỏi Bé Trả Lời Tập 5', 15, 27, 38000, 30000, N'me-hoi-be-tra-loi-tap-5.jpg', 0, 1, 1, NULL, 35, NULL, N'me-hoi-be-tra-loi-tap-5', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (103, N'Mẹ Hỏi Bé Trả Lời Tập 6', N'Mẹ Hỏi Bé Trả Lời Tập 6', 15, 27, 38000, 30000, N'me-hoi-be-tra-loi-tap-1.jpg', 0, 0, 1, NULL, 35, CAST(N'2023-04-22' AS Date), N'me-hoi-be-tra-loi-tap-6', N'Kim Đồng')
INSERT [dbo].[produce] ([id], [name], [desciption], [catId], [autId], [price], [discount], [thumb], [bestSell], [homeFlag], [active], [tag], [unitslnStock], [datecreate], [alias], [nhaXB]) VALUES (110, N'Sách 1', N'Sách 1', 15, 19, 60000, 54000, N'sach-1.jpg', 1, 1, 1, NULL, 23, CAST(N'2023-05-15' AS Date), N'sach-1', N'Kim đồng')
SET IDENTITY_INSERT [dbo].[produce] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [name], [description]) VALUES (1, N'Admin', N'Người quản trị')
INSERT [dbo].[role] ([id], [name], [description]) VALUES (2, N'Staff', N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[transitionStatus] ON 

INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (1, N'Chờ xác nhận', N'Đang được người bán xác nhận đơn hàng')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (2, N'Chờ lấy hàng', N'Đã xác nhận đơn và đang soạn hàng')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (3, N'Đang giao', N'Đơn hàng đã được gửi đi')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (4, N'Đã giao thành công', N'Đơn hàng đã được giao đến người mua')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (5, N'Đã hủy', N'Đơn hàng đã được hủy')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (6, N'Trả hàng', N'Đơn hàng đã được hoàn trả')
INSERT [dbo].[transitionStatus] ([id], [status], [description]) VALUES (7, N'Đã xóa', N'Đơn hàng đã xóa')
SET IDENTITY_INSERT [dbo].[transitionStatus] OFF
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_role] FOREIGN KEY([roleId])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_role]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_customer]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_transitionStatus] FOREIGN KEY([statusId])
REFERENCES [dbo].[transitionStatus] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_transitionStatus]
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_orderDetail_order] FOREIGN KEY([orderId])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [FK_orderDetail_order]
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_orderDetail_produce] FOREIGN KEY([produceId])
REFERENCES [dbo].[produce] ([id])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [FK_orderDetail_produce]
GO
ALTER TABLE [dbo].[produce]  WITH CHECK ADD  CONSTRAINT [FK_produce_author] FOREIGN KEY([autId])
REFERENCES [dbo].[author] ([id])
GO
ALTER TABLE [dbo].[produce] CHECK CONSTRAINT [FK_produce_author]
GO
ALTER TABLE [dbo].[produce]  WITH CHECK ADD  CONSTRAINT [FK_produce_category] FOREIGN KEY([catId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[produce] CHECK CONSTRAINT [FK_produce_category]
GO
