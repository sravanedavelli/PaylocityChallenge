USE [EmployeeBenefits]
GO

/****** Object:  Table [dbo].[EmployeeBenefitsCost]    Script Date: 4/11/2021 3:05:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeBenefitsCost](
	[EmployeeBenefitsCostID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[PayCheckSalary] [decimal](10, 2) NULL,
	[PayCheckBenefitCost] [decimal](10, 2) NULL,
	[YearlySalary] [decimal](10, 2) NULL,
	[YearlyBenefitCost] [decimal](10, 2) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_EmployeeBenefitsCost] PRIMARY KEY CLUSTERED 
(
	[EmployeeBenefitsCostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeBenefitsCost]  WITH CHECK ADD  CONSTRAINT [FK_Employees_EmployeeBenefitsCost] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeeBenefitsCost] CHECK CONSTRAINT [FK_Employees_EmployeeBenefitsCost]
GO


