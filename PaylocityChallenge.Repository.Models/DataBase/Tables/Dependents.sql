USE [EmployeeBenefits]
GO

/****** Object:  Table [dbo].[Dependents]    Script Date: 4/11/2021 3:05:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dependents](
	[DependentID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DependentType] [int] NULL,
	[IsActive] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_Dependents] PRIMARY KEY CLUSTERED 
(
	[DependentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dependents]  WITH CHECK ADD  CONSTRAINT [FK_Dependents_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[Dependents] CHECK CONSTRAINT [FK_Dependents_Employees]
GO


