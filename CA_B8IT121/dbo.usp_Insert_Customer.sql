CREATE PROC usp_Insert_Customer
@Email varchar(100),
@Name varchar (30),
@StreetAddress varchar (100),
@City varchar (20),
@Password varchar (10),
@Phone varchar (10),
@Gender varchar (10),
@MailList varchar (4),
@CustType varchar (20)
AS
INSERT INTO tblCustomer VALUES(@Email, @Name, @StreetAddress, @City, @Password, @Phone, @Gender, @MailList, @CustType)