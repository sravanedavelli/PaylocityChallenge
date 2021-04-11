USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployeeBenefitCost_Insert]    Script Date: 4/11/2021 3:08:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--exec [spEmployeeBenefitCost_Insert] @EmployeeID= 11
CREATE PROCEDURE [dbo].[spEmployeeBenefitCost_Insert]
	@EmployeeID int,
    @PayCheckSalary decimal(10,2) null,
    @PayCheckBenefitCost decimal(10,2) null,
	@YearlySalary decimal(10,2) null,
	@YearlyBenefitCost decimal(10,2) null

AS
begin
    set nocount on;

INSERT INTO [dbo].[EmployeeBenefitsCost]
           ([EmployeeID]
           ,[PayCheckSalary]
           ,[PayCheckBenefitCost]
           ,[YearlySalary]
           ,[YearlyBenefitCost]
           ,[DateCreated])
     VALUES
           (@EmployeeID
           ,@PayCheckSalary
           ,@PayCheckBenefitCost 
           ,@YearlySalary 
           ,@YearlyBenefitCost 
           ,GETDATE())


end
GO


