USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spDependent_Update]    Script Date: 4/11/2021 3:06:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDependent_Update]
    @Dependentid int,
	@FirstName nvarchar(50),
    @LastName nvarchar(50),
	@DependentType int,
	@IsActive bit

AS
begin
    set nocount on;
UPDATE [dbo].[Dependents]
   SET 
       [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[DependentType] = @DependentType
	  ,[IsActive] = @IsActive
	  ,[DateUpdated] = GETDATE()
 WHERE DependentID = @Dependentid

end

GO


