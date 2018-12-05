
CREATE PROC  uspCREATE_TABLE
AS
CREATE TABLE Members
(
Email varchar (100) NOT NULL,
Name varchar (30),
Address varchar (100),
Password varchar (10),
CONSTRAINT pkMember PRIMARY KEY(Email)
)
EXEC uspCREATE_TABLE

