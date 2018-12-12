CREATE PROC usp_VerifyLogin
@Email varchar (30),
@Name varchar (30),
@Password varchar (10)
AS
SELECT Name, Password FROM tblCustomer
WHERE Email = @Email