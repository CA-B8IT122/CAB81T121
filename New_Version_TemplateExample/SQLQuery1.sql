Create proc uspCreateBook
AS
Create Table Book
(
ISBN Varchar(30) NOT NULL Primary Key,
Title Varchar(100),
Publisher Varchar(30),
DatePublished Date,
Price Decimal(7,2)
)

EXEC uspCreateBook

INSERT INTO Book VALUES ('34783749','Web Programmng','ORielly','2017-09-08',45)
