USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spDependent_Insert]    Script Date: 4/11/2021 3:06:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDependent_Insert]
	@EmployeeID int,
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
	@DependentType int,
	@IsActive bit

AS
begin
    set nocount on;

INSERT INTO [dbo].[Dependents]
           ([EmployeeID]
           ,[FirstName]
           ,[LastName]
           ,[DependentType]
		   ,[IsActive]
		   ,[DateCreated])
     VALUES
           (@EmployeeID
           ,@FirstName
           ,@LastName
           ,@DependentType
		   ,@IsActive
		   ,GETDATE())
end

GO


