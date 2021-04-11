USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_GetById]    Script Date: 4/11/2021 3:07:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployee_GetById]
    @Id int
AS
begin
    set nocount on;
SELECT E.[EmployeeID],
	   [FirstName],
	   [LastName],
	   [EmailID],
	   [PayCheckSalary]
      ,[PayCheckBenefitCost]
      ,[YearlySalary]
      ,[YearlyBenefitCost]
  FROM [EmployeeBenefits].[dbo].[Employees] E INNER JOIN [EmployeeBenefits].[dbo].[EmployeeBenefitsCost] EBC 
  ON E.EmployeeID = EBC.EmployeeID
	where E.[EmployeeID] = @Id;
end

GO


