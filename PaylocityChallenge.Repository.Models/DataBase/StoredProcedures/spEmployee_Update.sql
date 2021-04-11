USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Update]    Script Date: 4/11/2021 3:08:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployee_Update]
    @EmployeeId int,
	@FirstName nvarchar(50),
    @LastName nvarchar(50),
	@EmailId nvarchar(50)

AS
begin
    set nocount on;
	UPDATE [dbo].[Employees]
   SET [FirstName] =@FirstName
      ,[LastName] = @LastName
      ,[EmailID] = @EmailId
	  ,[DateUpdated] = GETDATE()
 WHERE EmployeeID = @EmployeeId

end

GO


