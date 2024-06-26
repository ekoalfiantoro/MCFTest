Create database TestEkoAlfiantoro
GO

USE [TestEkoAlfiantoro]
GO
/****** Object:  Table [dbo].[ms_storage_location]    Script Date: 21/05/2024 00:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [varchar](10) NOT NULL,
	[location_name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ms_user]    Script Date: 21/05/2024 00:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] NOT NULL,
	[user_name] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tr_bpkb]    Script Date: 21/05/2024 00:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tr_bpkb](
	[agreement_number] [varchar](100) NOT NULL,
	[bpkb_no] [varchar](100) NULL,
	[branch_id] [varchar](10) NULL,
	[bpkb_date] [datetime] NULL,
	[faktur_no] [varchar](100) NULL,
	[faktur_date] [datetime] NULL,
	[location_id] [varchar](10) NULL,
	[police_no] [varchar](20) NULL,
	[bpkb_date_in] [datetime] NULL,
	[created_by] [varchar](20) NULL,
	[created_on] [datetime] NULL,
	[last_updated_by] [varchar](20) NULL,
	[last_updated_on] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[agreement_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (N'1', N'HO')
GO
INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (1, N'eko', N'eko', 1)
GO
ALTER TABLE [dbo].[tr_bpkb]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[ms_storage_location] ([location_id])
GO
