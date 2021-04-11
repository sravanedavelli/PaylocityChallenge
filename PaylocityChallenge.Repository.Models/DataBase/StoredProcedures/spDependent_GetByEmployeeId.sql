USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spDependent_GetByEmployeeId]    Script Date: 4/11/2021 3:06:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDependent_GetByEmployeeId]
    @EmployeeId int
AS
begin
    set nocount on;
Select [DependentID]
      ,[EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[DependentType]
	  ,[IsActive]
  FROM [EmployeeBenefits].[dbo].[Dependents]
	where [EmployeeID] = @EmployeeId;
end

GO


