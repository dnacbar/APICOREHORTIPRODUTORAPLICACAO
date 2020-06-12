﻿USE [DBHORTI]
GO

/****** OBJECT:  TABLE [DBO].[UNITY]    SCRIPT DATE: 23/10/2019 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

EXEC P_REMOVE_FK N'UNIT'
GO

IF OBJECT_ID('DBO.UNIT', 'U') IS NOT NULL
	DROP TABLE DBO.UNIT;

CREATE TABLE [DBO].[UNIT](
	[ID_UNIT] [TINYINT] NOT NULL IDENTITY (1, 1),
	[DS_UNIT] [NVARCHAR](50) NULL,
	[DS_ABREVIATION] [VARCHAR](4) NULL,
	[DT_CREATION] [DATETIME2](3) NOT NULL,
	[DT_ATUALIZATION] [DATETIME2](3) NOT NULL,
	CONSTRAINT [PK_UNIT] PRIMARY KEY CLUSTERED	(	[ID_UNIT] ASC	)
	
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE [DBO].[UNIT] ADD  CONSTRAINT [C_UNIT_DT_ATUALIZATION]  DEFAULT GETDATE() FOR [DT_ATUALIZATION]
GO