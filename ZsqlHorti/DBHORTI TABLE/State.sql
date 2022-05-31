﻿USE [DBHORTI]
GO

/****** OBJECT:  TABLE [DBO].[STATE]    SCRIPT DATE: 23/10/2019 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

EXEC P_REMOVE_FK N'STATE'
GO

IF OBJECT_ID('DBO.STATE', 'U') IS NOT NULL
	DROP TABLE DBO.STATE;

CREATE TABLE [DBO].[STATE](
	[ID_COUNTRY] [VARCHAR](5) NOT NULL,
	[ID_STATE] [INT] NOT NULL,
	[DS_STATE] [NVARCHAR](200) NULL,
	[DS_UF] [VARCHAR](50) NULL,
	CONSTRAINT [PK_STATE] PRIMARY KEY CLUSTERED	(	[ID_COUNTRY], [ID_STATE] ASC	)
	
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO