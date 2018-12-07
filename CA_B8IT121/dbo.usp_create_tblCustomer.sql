CREATE PROC usp_create_tblCustomer
AS
CREATE TABLE tblCustomer
(
Email varchar (30) NOT NULL PRIMARY KEY,
Name varchar (30),
StreetAddress varchar (100),
City varchar (20),
Password varchar (10),
Phone varchar (10),
Gender varchar (10),
MailList varchar (10)
)
