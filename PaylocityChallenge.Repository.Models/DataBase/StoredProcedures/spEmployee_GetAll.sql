USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_GetAll]    Script Date: 4/11/2021 3:07:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployee_GetAll]
@SearchTerm nvarchar(50) = null
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
  FROM [EmployeeBenefits].[dbo].[Employees] E LEFT OUTER JOIN [EmployeeBenefits].[dbo].[EmployeeBenefitsCost] EBC 
  ON E.EmployeeID = EBC.EmployeeID
  WHERE FirstName = CASE WHEN @SearchTerm IS NULL THEN FirstName ELSE @SearchTerm END
  ORDER BY FirstName
end
GO


