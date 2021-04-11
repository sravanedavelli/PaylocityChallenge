USE [EmployeeBenefits]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Insert]    Script Date: 4/11/2021 3:07:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployee_Insert]
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
	@Email nvarchar(50),
	@Id int Output

AS
begin
    set nocount on;

INSERT INTO [dbo].[Employees]
           ([FirstName]
           ,[LastName]
           ,[EmailID]
		   ,[DateCreated])
     VALUES
           (@FirstName
           ,@LastName
           ,@Email
		   ,GETDATE())
SELECT @Id =  SCOPE_IDENTITY()
end
GO


