USE Dijital_ERP
GO

/****** Object:  Table [dbo].[Users]    Script Date: 16.04.2025 17:14:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TCKNO] [nchar](11) NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone1] [nvarchar](20) NULL,
	[Phone2] [nvarchar](20) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[DepartmentId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[StartDate] [nvarchar](50) NULL,
	[DepartureDate] [nvarchar](50) NULL,
	[RolName] [nvarchar](50) NULL,
	[RolId] [int] NULL,
	[Cinsiyet] [nvarchar](20) NULL,
	[Personel_Id] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


