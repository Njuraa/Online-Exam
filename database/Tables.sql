CREATE Database [examMaha]
GO
USE [examMaha]
GO
CREATE TABLE [dbo].[Answer](
	[AnswerId] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[Answer] [varchar](250) NOT NULL,
	[IsRight] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[AnswerType]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AnswerType](
	[AnswerTypeId] [int] IDENTITY(1,1) NOT NULL,
	[AnswerType] [varchar](100) NOT NULL,
	[Description] [varchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[CourseMaster]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CourseMaster](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](100) NULL,
	[Description] [varchar](250) NULL,
	[Eligibility] [varchar](150) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[ExamTimes]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ExamTimes](
	[ExamTimesId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExamTime] [varchar](30) NOT NULL,
	[Description] [varchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExamTimesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[FeesMaster]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FeesMaster](
	[FeesId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[Description] [varchar](250) NULL,
	[Offer] [varchar](150) NULL,
	[Amount] [decimal](12, 2) NULL,
	[SGST] [decimal](12, 2) NULL,
	[CGST] [decimal](12, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[QuestionAnswer]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestionAnswer](
	[QuestionAnswerId] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionId] [bigint] NULL,
	[AnswerId] [bigint] NULL,
	[StudentExamId] [bigint] NULL,
	[StudentId] [bigint] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[CourseId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionAnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[QuestionMaster]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuestionMaster](
	[QuestionId] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Question] [varchar](250) NOT NULL,
	[AnswerTypeId] [int] NOT NULL,
	[Marks] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[StudentDetails]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentDetails](
	[StudentId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentUniqueId] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[MobileNo] [varchar](20) NULL,
	[EmailId] [varchar](50) NULL,
	[UserTypeId] [int] NULL,
	[IsActive] [char](1) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[StudentExams]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentExams](
	[StudentExamId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Description] [varchar](300) NULL,
	[ExamTimeId] [bigint] NULL,
	[ExamDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsExpired] [bit] NULL,
	[ExamResult] [varchar](50) NULL,
	[IsAppeared] [bit] NULL,
	[Fees] [decimal](10, 2) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[UserMaster]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserMaster](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserPassword] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[MobileNo] [varchar](20) NULL,
	[EmailId] [varchar](50) NULL,
	[UserTypeId] [int] NULL,
	[IsActive] [char](1) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[ProfilePicPath] [varchar](100) NULL,
	[UniqueId] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT INTO [dbo].[UserMaster](UserPassword,FirstName,LastName,MobileNo,EmailId,UserTypeId,IsActive,CreatedBy,CreatedDate,UniqueId)
VALUES ('123456','Super','Admin','9123456789','admin@gmail.com',1,1,1,GETDATE(),NEWID())
INSERT INTO [dbo].[UserMaster](UserPassword,FirstName,LastName,MobileNo,EmailId,UserTypeId,IsActive,CreatedBy,CreatedDate,UniqueId)
VALUES ('123456','Student','Name','9123456780','student@gmail.com',3,1,1,GETDATE(),NEWID())
GO
SET ANSI_PADDING OFF
GO

USE [ablegals_examMaha]
GO

/****** Object:  Table [dbo].[UserTypeMaster]    Script Date: 01/19/2020 17:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserTypeMaster](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](50) NULL,
	[IsActive] [char](1) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT INTO UserTypeMaster(UserType,IsActive,CreatedBy,CreatedDate)VALUES('Super Admin',1,1,GETDATE())
INSERT INTO UserTypeMaster(UserType,IsActive,CreatedBy,CreatedDate)VALUES('Branch Manager',1,1,GETDATE())
INSERT INTO UserTypeMaster(UserType,IsActive,CreatedBy,CreatedDate)VALUES('Student',1,1,GETDATE())
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Answer] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[AnswerType] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[ExamTimes] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[QuestionMaster] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[StudentExams] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[UserMaster] ADD  DEFAULT (newid()) FOR [UniqueId]
GO


