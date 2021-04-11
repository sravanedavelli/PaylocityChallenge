USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployeeBenefitCost_Update]    Script Date: 4/11/2021 3:08:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeBenefitCost_Update]
	@EmployeeID int,
    @PayCheckSalary decimal(10,2),
    @PayCheckBenefitCost decimal(10,2),
	@YearlySalary decimal(10,2),
	@YearlyBenefitCost decimal(10,2)

AS
begin
    set nocount on;

UPDATE [dbo].[EmployeeBenefitsCost]
   SET [PayCheckSalary] = @PayCheckSalary
      ,[PayCheckBenefitCost] = @PayCheckBenefitCost
      ,[YearlySalary] =@YearlySalary
      ,[YearlyBenefitCost] = @YearlyBenefitCost
      ,[DateUpdated] = GETDATE()
 WHERE EmployeeID = @EmployeeID


end
GO


