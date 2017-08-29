USE [BrandxStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/08/2017 19:30:59 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 29/08/2017 19:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 29/08/2017 19:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 29/08/2017 19:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 29/08/2017 19:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[UserGameLevel] [int] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Client]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntryTime] [datetime2](7) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[GameLevel] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Game]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntryTime] [datetime2](7) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[ImageUrl] [nvarchar](300) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Message]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntryTime] [datetime2](7) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Text] [nvarchar](max) NULL,
	[SendOn] [datetime2](7) NULL,
	[TargetClientID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Moderator]    Script Date: 29/08/2017 19:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moderator](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntryTime] [datetime2](7) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Moderator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'1.1.2')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'5816842b-e10e-4a49-9526-11633454555c
', NULL, N'Moderator', N'Add')
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'e1b98651-5887-43e6-b6b0-724244cc0bf5
', NULL, N'Client', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d6a99ce-8780-458b-a000-e45963573666', N'5816842b-e10e-4a49-9526-11633454555c
')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe386e71-bc2e-402e-8ccd-d6d202b5d95a', N'e1b98651-5887-43e6-b6b0-724244cc0bf5
')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UserGameLevel]) VALUES (N'0d6a99ce-8780-458b-a000-e45963573666', 0, N'16678b12-6049-4e67-83ef-960d35d50104', N'keith.a.gri@gmail.com', 0, 1, NULL, N'KEITH.A.GRI@GMAIL.COM', N'KEITH.A.GRI@GMAIL.COM', N'AQAAAAEAACcQAAAAEN72kCKQECj8yWnlZ1lvXScnS4obyC7+fOfIHPfqSlJ3h7Co2+al2ALqH3p/qkM7xQ==', NULL, 0, N'4c452161-a6c7-44c3-b556-7554b4405a65', 0, N'keith.a.gri@gmail.com', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UserGameLevel]) VALUES (N'60ff1a9f-2818-4bbe-8739-5bce8cce1423', 0, N'09233a92-79d4-44c1-831b-e8daf7e5380d', N'test@test.com', 0, 1, NULL, N'TEST@TEST.COM', N'TEST@TEST.COM', N'AQAAAAEAACcQAAAAEA6mw63rpchXM/+FpkScDhQOiO3jVbNGncZGnLZWWW5SOSVamHxVGZVXIxPj9CdADA==', NULL, 0, N'0d7115f2-ebc2-458c-813f-a9526538399a', 0, N'test@test.com', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UserGameLevel]) VALUES (N'ca6fc6c3-a8f3-4f67-94e5-2add6eb2598f', 0, N'ea1c2a89-ade5-4e64-8358-262961f01a4b', N'keith.c.gri@gmail.com', 0, 1, NULL, N'KEITH.C.GRI@GMAIL.COM', N'KEITH.C.GRI@GMAIL.COM', N'AQAAAAEAACcQAAAAEAsdnL3iWlXLtDl+Uq66bv8xKFQlMDmOfGk/1p6RaspQZjqmXgvfXvj7ho0KV5KYEQ==', NULL, 0, N'07801dfb-55a5-4fb1-a14d-64dcc7e547ab', 0, N'keith.c.gri@gmail.com', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UserGameLevel]) VALUES (N'f72cd6aa-a6da-4327-8825-78ecefde4b4e', 0, N'263fa14a-bb2c-415c-87e0-c5ea35ccc5ec', N'keith.b.gri@gmail.com', 0, 1, NULL, N'KEITH.B.GRI@GMAIL.COM', N'KEITH.B.GRI@GMAIL.COM', N'AQAAAAEAACcQAAAAEIQbEg31RdhedGxoiHAHlViffCWbLXs3KdaMmXuP99Z9v1EuC2+jZRN/os4L9AIEiQ==', NULL, 0, N'ac55c5a0-912d-4129-81b7-f2d5fafe682a', 0, N'keith.b.gri@gmail.com', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UserGameLevel]) VALUES (N'fe386e71-bc2e-402e-8ccd-d6d202b5d95a', 0, N'1dd018e1-af3e-4f03-b7d2-a2dd3dcabc36', N'keith.client@gmail.com', 0, 1, NULL, N'KEITH.CLIENT@GMAIL.COM', N'KEITH.CLIENT@GMAIL.COM', N'AQAAAAEAACcQAAAAEJXBmCLwJjSyvBlBeRv82FyJASII1v/dstmimU7VOOcsrp1xYH3vWrhittdv3kaPXg==', NULL, 0, N'a0dc2269-ba77-4c53-91ea-638c73986331', 0, N'keith.client@gmail.com', NULL)
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (4, CAST(N'2017-08-25T07:12:27.4636805' AS DateTime2), N'Fruit Machines', N'Fruit Machines Info', N'http://www.pubfruitmachines.me.uk/wp-content/uploads/ladbrokesgame.jpg', 1)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (5, CAST(N'2017-08-25T07:12:27.4636805' AS DateTime2), N'BlackJack21', N'BlackJack info', N'https://www.ammazzacasino.com/en/wp-content/uploads/2014/10/online-blackjack.jpg', 0)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (6, CAST(N'2017-08-25T07:12:27.4636805' AS DateTime2), N'HoldemPoker', N'HoldemPoker information', N'https://pnimg.net/w/articles/0/521/e0dfeabc4a.jpg', 1)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (48, CAST(N'2017-08-28T18:57:59.2297860' AS DateTime2), N'Live Betting', N'Live Betting Info', N'http://www.jackpotbetonline.com/wp-content/uploads/2016/11/How-to-place-bets-in-Sports-Betting-games.png', 0)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (51, CAST(N'2017-08-29T08:05:34.5276832' AS DateTime2), N'RandomGame', N'Random Game Information', N'http://vegas-betting-lines.info/wp-content/uploads/online-games.jpg', 1)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (54, CAST(N'2017-08-29T08:09:24.7512439' AS DateTime2), N'Roulette', N'Roulette Info', N'https://www.roulettephysics.com/wp-content/uploads/2015/11/fj.jpg', 1)
GO
INSERT [dbo].[Game] ([ID], [EntryTime], [Code], [Description], [ImageUrl], [IsActive]) VALUES (66, CAST(N'2017-08-29T12:37:22.2567217' AS DateTime2), N'FreeGameCoupon2017', N'FreeGameCoupon2017 Description', N'https://www.sportsbook.ag/static/SBK/www.sportsbook.ag/100MatchBet-SB.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

GO
INSERT [dbo].[Message] ([ID], [EntryTime], [Title], [Text], [SendOn], [TargetClientID]) VALUES (21, CAST(N'2017-08-29T13:43:03.8668830' AS DateTime2), N'New Game!', N'A new game Lotto2018 has been added!', NULL, NULL)
GO
INSERT [dbo].[Message] ([ID], [EntryTime], [Title], [Text], [SendOn], [TargetClientID]) VALUES (22, CAST(N'2017-08-29T13:43:35.1229312' AS DateTime2), N'Free Coupon', N'You have been given a coupon. Use ASDHSD on your next game!', NULL, NULL)
GO
INSERT [dbo].[Message] ([ID], [EntryTime], [Title], [Text], [SendOn], [TargetClientID]) VALUES (23, CAST(N'2017-08-29T13:44:40.0728067' AS DateTime2), N'Poker9000', N'Poker9000 is back! Try your luck!', NULL, NULL)
GO
INSERT [dbo].[Message] ([ID], [EntryTime], [Title], [Text], [SendOn], [TargetClientID]) VALUES (24, CAST(N'2017-08-29T14:05:20.2381968' AS DateTime2), N'Recruit a friend!', N'Recruit a friend scheme active! ', NULL, NULL)
GO
INSERT [dbo].[Message] ([ID], [EntryTime], [Title], [Text], [SendOn], [TargetClientID]) VALUES (25, CAST(N'2017-08-29T14:05:59.4040435' AS DateTime2), N'Jackpot won!', N'User GBP999 has won this week''s jackpot!', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
