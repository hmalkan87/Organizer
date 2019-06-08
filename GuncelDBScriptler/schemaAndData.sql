USE [Organizer]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 01.06.2019 04:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[CategoryID] [int] NULL,
	[ApplicationDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Picture] [nvarchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 01.06.2019 04:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [int] NOT NULL,
	[ReceiverID] [int] NOT NULL,
	[MessageText] [nvarchar](max) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEvent]    Script Date: 01.06.2019 04:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_UserEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.06.2019 04:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (1, N'Piknik', 1, 3, CAST(N'2001-03-03T00:00:00.000' AS DateTime), NULL, CAST(N'2001-03-03T00:00:00.000' AS DateTime), N'h', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (2, N'Gezi', 1, 10, CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL, CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Belgrad Ormanı', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (3, N'Mangal', 2, 16, CAST(N'2019-07-07T00:00:00.000' AS DateTime), NULL, CAST(N'2019-06-07T00:00:00.000' AS DateTime), N'Mangala düşücez', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (1002, N'İftar', 1, 8, CAST(N'2019-05-30T00:00:00.000' AS DateTime), NULL, CAST(N'2019-05-29T00:00:00.000' AS DateTime), N'Hep beraber iftara ne dersiniz?', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (2002, N'counter', 1, 1, CAST(N'2019-05-31T00:00:00.000' AS DateTime), NULL, CAST(N'2019-05-31T00:00:00.000' AS DateTime), N'deneme', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (2003, N'counter2', 1, 1, CAST(N'2019-05-31T00:00:00.000' AS DateTime), NULL, CAST(N'2019-01-31T00:00:00.000' AS DateTime), N'deneme', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (2004, N'counter3', 1, 1, CAST(N'2019-05-31T00:00:00.000' AS DateTime), NULL, CAST(N'2019-05-31T00:00:00.000' AS DateTime), N'deneme', NULL)
INSERT [dbo].[Events] ([ID], [Name], [OwnerID], [Capacity], [EventDate], [CategoryID], [ApplicationDate], [Description], [Picture]) VALUES (2005, N'counter4', 1, 3, CAST(N'2019-05-31T00:00:00.000' AS DateTime), NULL, CAST(N'2019-05-31T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[UserEvent] ON 

INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1, 1, 1)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (2, 1, 2)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1002, 1, 2002)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1003, 1, 2003)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1004, 1, 2004)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1005, 1002, 2002)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1006, 1, 2005)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1007, 1002, 2005)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1008, 1002, 2004)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1009, 1002, 2003)
INSERT [dbo].[UserEvent] ([ID], [UserID], [EventID]) VALUES (1010, 1002, 1002)
SET IDENTITY_INSERT [dbo].[UserEvent] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (1, N'Hasan', N'hasan@gmail.com', N'123')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (2, N'Fatih', N'fatih@gmail.com', N'123')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (1002, N'Ahmet', N'ahmet@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([SenderID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users1] FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users1]
GO
ALTER TABLE [dbo].[UserEvent]  WITH CHECK ADD  CONSTRAINT [FK_UserEvent_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[UserEvent] CHECK CONSTRAINT [FK_UserEvent_Events]
GO
ALTER TABLE [dbo].[UserEvent]  WITH CHECK ADD  CONSTRAINT [FK_UserEvent_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserEvent] CHECK CONSTRAINT [FK_UserEvent_Users]
GO
