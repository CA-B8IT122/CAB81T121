CREATE PROC usp_VerifyLogin
@Email varchar (30)
AS
SELECT Name, Password, CustType FROM tblCustomer
WHERE Email = @Email

EXEC usp_VerifyLogin @email = "mtforster74@gmail.com"