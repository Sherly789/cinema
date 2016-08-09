USE [cinema]
GO
/****** Object:  Table [dbo].[movies]    Script Date: 8/9/2016 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NULL,
	[rating] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movies_theaters]    Script Date: 8/9/2016 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movies_theaters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NULL,
	[theater_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orders]    Script Date: 8/9/2016 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[showing_id] [int] NULL,
	[quantity] [int] NULL,
	[user_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[theaters]    Script Date: 8/9/2016 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[theaters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[location] [varchar](255) NULL,
	[date_time] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 8/9/2016 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
