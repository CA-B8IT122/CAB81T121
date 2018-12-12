CREATE PROC usp_VerifyLogin
@Email varchar (30)
AS
SELECT * FROM tblCustomer 
WHERE Email = @Email
EXEC usp_VerifyLogin @Email = "admin@mail.com"