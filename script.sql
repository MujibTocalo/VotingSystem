USE [master]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 3/1/2023 12:46:18 AM ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 3/1/2023 12:46:18 AM ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/1/2023 12:46:18 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[ConcurrencyStamp] [varchar](255) NULL,
	[NormalizedName] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[Firstname] [varchar](45) NULL,
	[Lastname] [varchar](45) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/1/2023 12:46:19 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ballots]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ballots](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[votersId] [int] NULL,
	[candidateId] [int] NULL,
	[positionId] [int] NULL,
	[organizationId] [int] NULL,
	[name] [nvarchar](max) NULL,
	[course] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ballots] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[positionId] [int] NULL,
	[organizationId] [int] NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[organizationId] [int] NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voters]    Script Date: 3/1/2023 12:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[organizationId] [int] NULL,
	[password] [nvarchar](45) NULL,
 CONSTRAINT [PK_Voters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228162711_NewUserRegistrationCols', N'3.1.32')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [ConcurrencyStamp], [NormalizedName]) VALUES (N'', N'test', N'edd404a1-ef1a-495f-b3c5-693c98a8b7cf', N'TEST')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [ConcurrencyStamp], [NormalizedName]) VALUES (N'005ee2e3-b4bc-4612-9f67-917c93eaedaa', N'Voters', N'eb3aceb1-86f2-478b-864c-40e570712c69', N'VOTERS')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [ConcurrencyStamp], [NormalizedName]) VALUES (N'e5f574fb-80c6-49b9-b4a7-933477db24f4', N'Admin', N'26fff7b3-819b-419f-b403-0c45d4ec0eba', N'ADMIN')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'1bdd1f30-aafe-4ea1-aee8-553a457cbea2', N'test@Voters.com', 0, N'AQAAAAEAACcQAAAAEIF7wgOcc6uaH8v5ZCavuWtXa5uYJUlBQuTFHF1UNKzWcQiyxixaWuj/6dfo9lJs+A==', N'YU6SEKVBLSUCN2WWUDFQTL73GRTODBBX', NULL, 0, 0, NULL, 1, 0, N'test@Voters.com', N'93188ded-e021-4024-a455-675b0cce0d9a', N'TEST@VOTERS.COM', NULL, N'TEST@VOTERS.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'3f98e5a3-97cf-42d5-90d4-136978c26ae1', N'asdaseqw@gmail.com', 0, N'AQAAAAEAACcQAAAAEKUs1kWeF8ou5Y1pMKWW1C9792e+D7A0o8kFaBAo146cBIhj5V+a4ob2FjGgsJtqZw==', N'JMXJC5ADOEHMZTJCJJJ74N5J4WUK6PE7', NULL, 0, 0, NULL, 1, 0, N'asdaseqw@gmail.com', N'f38fc6f3-183f-4505-8838-474328534554', N'ASDASEQW@GMAIL.COM', NULL, N'ASDASEQW@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'636c5a9d-5e28-4999-b1ee-e1c590b3c8b8', N'asdm@gmail.com', 0, N'AQAAAAEAACcQAAAAEKpNVEtG7lwXbOmeb8+i+WV/Yk2MsgXV4AllgGAUVlKF60jCmYzwfHTU8O4A5mp7Zg==', N'RXL4DDBLSRBZHY67HMZEKIOAC543VN4S', NULL, 0, 0, NULL, 1, 0, N'asdm@gmail.com', N'2bf00d30-a0be-4067-839a-9ceacdf1f5e0', N'ASDM@GMAIL.COM', NULL, N'ASDM@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'8729b358-1b06-4ace-906d-e4916ea8988f', N'testVoters@gmail.com', 0, N'AQAAAAEAACcQAAAAENP9jHCOvE7BcW/lEZL/mqmpnkxSnS+KZ85vbvoPDEaIYsYhhQ7SLmsqpyNDwX0OOg==', N'WS3KHWS7KDPAOANLIRBN7H3PF722WGAJ', NULL, 0, 0, NULL, 1, 0, N'testVoters@gmail.com', N'28f6785d-bd14-4ad3-af5e-158ea0c9994c', N'TESTVOTERS@GMAIL.COM', NULL, N'TESTVOTERS@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'9e781b43-4289-42c7-b747-82bc5da6daf0', N'norhassansarip@gmail.com', 1, N'AQAAAAEAACcQAAAAEFnc6Ml/1ltcARm7ok5sk/QzoLo3RO3CUbk0qzlu7y4jDfgF/xhkv0v1hapu9xg8LQ==', N'JC6HDUQVOUVXZGHFURC42WXAUE34VZJ3', N'09633149103', 0, 0, NULL, 1, 0, N'norhassansarip@gmail.com', N'476503de-ead5-438b-8a02-3cefc97ad49f', N'NORHASSANSARIP@GMAIL.COM', NULL, N'NORHASSANSARIP@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'9f5f06a1-3dc0-4711-aa51-58802eb827fe', N'testVoters@gmail.com2', 0, N'AQAAAAEAACcQAAAAEFUMIAQClc7rEZkZfj0AeiGmcxSw8HuvPfBA98vHuotFCAIm5Z99yU43ZFoqzxbRJQ==', N'AZ5CRZQIYKHKZIO2Z7VVXB65M3QWYJIQ', NULL, 0, 0, NULL, 1, 0, N'testVoters@gmail.com2', N'02b6f1bc-426e-496e-9485-e8a1f448eeff', N'TESTVOTERS@GMAIL.COM2', NULL, N'TESTVOTERS@GMAIL.COM2', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'ab3ac31c-c992-4c6c-b8d2-ccc3ed642213', N'Mujibtocalo@admin.com', 0, N'AQAAAAEAACcQAAAAEAwn9koXRGA4xa5uJudxGh2ySSvq5N0vRapMYgumPYjQE6I0mThPia/bm2VK2Ckf+g==', N'APJSOGLC3NYVWC5VFIJMOP5UU3HHKTRF', NULL, 0, 0, NULL, 1, 0, N'Mujibtocalo@admin.com', N'24165d5e-3f31-41b5-89e6-95abbf1192ae', N'MUJIBTOCALO@ADMIN.COM', NULL, N'MUJIBTOCALO@ADMIN.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'acbed7ea-ff51-4f16-990c-d182dfed0cdf', N'testingLang@gmail.com', 0, N'AQAAAAEAACcQAAAAEMAjemszG8AFaFucPaujjdqU+mYCAutlMAwqSq7DBlNYDdAo8H3HfZ4WTo4qCkD5bQ==', N'W2LMBTXVFVYPOU3KSAKX6272T35EEPDI', NULL, 0, 0, NULL, 1, 0, N'testingLang@gmail.com', N'98c057b2-984d-4eca-8a3e-f42bbaabaae0', N'TESTINGLANG@GMAIL.COM', NULL, N'TESTINGLANG@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'adf4d034-7ad5-402f-bcff-cb413a069511', N'sarip.nm55@s.msumain.edu.ph', 0, N'AQAAAAEAACcQAAAAEJ3f+V7zHu1bf8iz5VuvD85xOfGY1guXyTjDMdNinti5v6s5zJ753Tmq0StRUbQPOg==', N'NGH667M56BZ33KYPQDRNVO7J2BLAPHVZ', NULL, 0, 0, NULL, 1, 0, N'sarip.nm55@s.msumain.edu.ph', N'5e86dc42-d24d-4bc2-8941-2970f24461b6', N'SARIP.NM55@S.MSUMAIN.EDU.PH', NULL, N'SARIP.NM55@S.MSUMAIN.EDU.PH', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'b1c7dd7b-e107-4385-9d9c-3fb74675f572', N'Mohdrayaaan@gmail.com', 0, N'AQAAAAEAACcQAAAAEDyEFksfskayZgO+1fANGKsHB4NWI00zxzO+DYA6JqOTvqkvTgKxqXHFgvj19uXZnw==', N'WZ35D5LGTVKHGQE6FIGQMDN6M5MF4MVJ', NULL, 0, 0, NULL, 1, 0, N'Mohdrayaaan@gmail.com', N'd1912f96-89e9-42d2-8e84-1436f0d28d8c', N'MOHDRAYAAAN@GMAIL.COM', NULL, N'MOHDRAYAAAN@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'c04b6a1e-29ee-401e-91e1-744b7f2ea85a', N'norhassansarip16032@gmail.com', 0, N'AQAAAAEAACcQAAAAEFfmbw5Aox9D68Pw4s8n93VjLA/3gv8K3XN3giKA2lZhp6jz1Ia+yDR9QPb9fQmMQQ==', N'2JM2EMAZ4DOT24CV3W6LRGMIDATXQBRT', NULL, 0, 0, NULL, 1, 0, N'norhassansarip16032@gmail.com', N'685f6441-efe1-4c93-8873-30bd257f518a', N'NORHASSANSARIP16032@GMAIL.COM', NULL, N'NORHASSANSARIP16032@GMAIL.COM', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [ConcurrencyStamp], [NormalizedUserName], [LockoutEnd], [NormalizedEmail], [Firstname], [Lastname]) VALUES (N'd1c18abc-6539-4131-b555-15d77cc0c12f', N'test2@gmail.com', 0, N'AQAAAAEAACcQAAAAEPI7i6QMkcA9W3IbrxqSow3RPYQAl5XYjWD9BarjM+0dJm+JKKywqYq92wKMUGLUGQ==', N'NZB3ZDVV7H7WXER4CQXHLK3BYIYGCWOU', NULL, 0, 0, NULL, 1, 0, N'test2@gmail.com', N'74d4663a-a282-49f1-88d9-effefa09361a', N'TEST2@GMAIL.COM', NULL, N'TEST2@GMAIL.COM', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Ballots] ON 

INSERT [dbo].[Ballots] ([id], [votersId], [candidateId], [positionId], [organizationId], [name], [course]) VALUES (1, 1, 1, 1, 1, NULL, NULL)
INSERT [dbo].[Ballots] ([id], [votersId], [candidateId], [positionId], [organizationId], [name], [course]) VALUES (2, 1, 1, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Ballots] OFF
GO
SET IDENTITY_INSERT [dbo].[Candidates] ON 

INSERT [dbo].[Candidates] ([id], [name], [positionId], [organizationId]) VALUES (1, N'Asnainah', 1, 1)
INSERT [dbo].[Candidates] ([id], [name], [positionId], [organizationId]) VALUES (2, N'acrmana', 1, 1)
SET IDENTITY_INSERT [dbo].[Candidates] OFF
GO
SET IDENTITY_INSERT [dbo].[Organizations] ON 

INSERT [dbo].[Organizations] ([id], [name]) VALUES (1, N'Department of Information and Technology')
INSERT [dbo].[Organizations] ([id], [name]) VALUES (2, N'Department of Computer Science')
INSERT [dbo].[Organizations] ([id], [name]) VALUES (3, N'Department of Information System')
SET IDENTITY_INSERT [dbo].[Organizations] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([id], [name], [organizationId]) VALUES (1, N'President', 1)
INSERT [dbo].[Positions] ([id], [name], [organizationId]) VALUES (2, N'Vice President', 1)
INSERT [dbo].[Positions] ([id], [name], [organizationId]) VALUES (3, N'Secretary', 1)
INSERT [dbo].[Positions] ([id], [name], [organizationId]) VALUES (4, N'President', 2)
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Voters] ON 

INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (1, N'HINE', N'Ryan Acraman', 1, NULL)
INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (2, N'asd', N'asd', NULL, NULL)
INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (1002, N'Abdulhalim', N'Mautin', NULL, NULL)
INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (2002, N'b1c7dd7b-e107-4385-9d9c-3fb74675f572', N'Praying', NULL, N'okij_2654VP')
INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (2003, N'adf4d034-7ad5-402f-bcff-cb413a069511', N'Sarip', NULL, N'uxnr_7378BW')
INSERT [dbo].[Voters] ([id], [user], [name], [organizationId], [password]) VALUES (2004, N'ab3ac31c-c992-4c6c-b8d2-ccc3ed642213', N'Mujib Tocalo', NULL, N'gewn_9812KU')
SET IDENTITY_INSERT [dbo].[Voters] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/1/2023 12:46:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Ballots]  WITH CHECK ADD  CONSTRAINT [FK_Ballots_Candidates] FOREIGN KEY([candidateId])
REFERENCES [dbo].[Candidates] ([id])
GO
ALTER TABLE [dbo].[Ballots] CHECK CONSTRAINT [FK_Ballots_Candidates]
GO
ALTER TABLE [dbo].[Ballots]  WITH CHECK ADD  CONSTRAINT [FK_Ballots_Organizations] FOREIGN KEY([organizationId])
REFERENCES [dbo].[Organizations] ([id])
GO
ALTER TABLE [dbo].[Ballots] CHECK CONSTRAINT [FK_Ballots_Organizations]
GO
ALTER TABLE [dbo].[Ballots]  WITH CHECK ADD  CONSTRAINT [FK_Ballots_Positions] FOREIGN KEY([positionId])
REFERENCES [dbo].[Positions] ([id])
GO
ALTER TABLE [dbo].[Ballots] CHECK CONSTRAINT [FK_Ballots_Positions]
GO
ALTER TABLE [dbo].[Ballots]  WITH CHECK ADD  CONSTRAINT [FK_Ballots_Voters] FOREIGN KEY([votersId])
REFERENCES [dbo].[Voters] ([id])
GO
ALTER TABLE [dbo].[Ballots] CHECK CONSTRAINT [FK_Ballots_Voters]
GO
ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [FK_Candidates_Organizations] FOREIGN KEY([organizationId])
REFERENCES [dbo].[Organizations] ([id])
GO
ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [FK_Candidates_Organizations]
GO
ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [FK_Candidates_Positions] FOREIGN KEY([positionId])
REFERENCES [dbo].[Positions] ([id])
GO
ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [FK_Candidates_Positions]
GO
ALTER TABLE [dbo].[Positions]  WITH CHECK ADD  CONSTRAINT [FK_Positions_Organizations] FOREIGN KEY([organizationId])
REFERENCES [dbo].[Organizations] ([id])
GO
ALTER TABLE [dbo].[Positions] CHECK CONSTRAINT [FK_Positions_Organizations]
GO
ALTER TABLE [dbo].[Voters]  WITH CHECK ADD  CONSTRAINT [FK_Voters_Organizations] FOREIGN KEY([organizationId])
REFERENCES [dbo].[Organizations] ([id])
GO
ALTER TABLE [dbo].[Voters] CHECK CONSTRAINT [FK_Voters_Organizations]
GO
