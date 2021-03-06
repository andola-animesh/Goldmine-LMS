USE [GoldmineLMS]
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 07/25/2014 12:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [char](1) NULL,
 CONSTRAINT [PK_UserTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserTbl] ON
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (3, N'Iti', N'itun@gmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (5, N'akash', N'akash@hotmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (11, N'Nitu', N'nitu@yahoo.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (12, N'Riku', N'riku@gmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (14, N'John', N'john.doe@gmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (15, N'Woo', N'john.woo@gmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserTbl] ([Id], [Name], [EmailId], [Password], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (16, N'Jim', N'jim.woo@gmail.com', N'123456', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserTbl] OFF
/****** Object:  Table [dbo].[NoteTbl]    Script Date: 07/25/2014 12:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NoteTbl](
	[NoteId] [int] IDENTITY(1,1) NOT NULL,
	[LeadId] [int] NOT NULL,
	[Attachment] [varchar](100) NOT NULL,
	[Comment] [varchar](200) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [char](1) NULL,
 CONSTRAINT [PK_NoteTbl] PRIMARY KEY CLUSTERED 
(
	[NoteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NoteTbl] ON
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (1, 2, N'Desert.jpg', N'Note for Crm', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (3, 3, N'Hydrangeas.jpg', N'Note for ROR project', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (4, 4, N'Tulips.jpg', N'Note for hrd', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (5, 4, N'Chrysanthemum.jpg', N'Note1 for hrd', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (6, 5, N'bike.png', N'Note of ROR', NULL, NULL, 3, CAST(0x0000A37200FE2F40 AS DateTime), NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (8, 1, N'Lighthouse.jpg', N'Note for .net proj', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (9, 1, N'5668814NSDLXXXXXX51.pdf', N'testing upload', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NoteTbl] ([NoteId], [LeadId], [Attachment], [Comment], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (10, 2, N'211087_217008398333434_5819521_n.jpg', N'Note for lead CRM', 3, CAST(0x0000A37300C29343 AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NoteTbl] OFF
/****** Object:  Table [dbo].[LeadTbl]    Script Date: 07/25/2014 12:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeadTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[ContactPerson] [varchar](100) NULL,
	[EmailId] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NULL,
	[Value] [int] NULL,
	[AssignUser] [int] NULL,
	[Status] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [char](1) NULL,
 CONSTRAINT [PK_LeadTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LeadTbl] ON
INSERT [dbo].[LeadTbl] ([Id], [Title], [ContactPerson], [EmailId], [ContactNo], [Value], [AssignUser], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (1, N'DotNet Project with Knockout.js', N'John Doe', N'john@name.com', N'983245678', 100000, 0, N'New', NULL, NULL, 15, CAST(0x0000A37200FFBE33 AS DateTime), NULL)
INSERT [dbo].[LeadTbl] ([Id], [Title], [ContactPerson], [EmailId], [ContactNo], [Value], [AssignUser], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (2, N'CRM', N'Prakash', N'prs@gmail.com', N'87845456', 4500, 11, N'Win', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LeadTbl] ([Id], [Title], [ContactPerson], [EmailId], [ContactNo], [Value], [AssignUser], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (3, N'RoR Project', N'Jim Doe', N'jim@name.com', N'2343432', 20000, 12, N'Lost', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LeadTbl] ([Id], [Title], [ContactPerson], [EmailId], [ContactNo], [Value], [AssignUser], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (4, N'Hrd', N'Sasmita', N'sas@yahoo.com', N'94397543', 7400, 12, N'In-progress', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LeadTbl] ([Id], [Title], [ContactPerson], [EmailId], [ContactNo], [Value], [AssignUser], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (5, N'ROR', N'Lalit', N'lalit@gmail.com', N'9439692210', 3000, 11, N'New', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LeadTbl] OFF
