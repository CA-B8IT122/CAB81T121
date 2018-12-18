CREATE TABLE [dbo].[tblCustomer] (
    [Email]         VARCHAR (30)  NOT NULL,
    [Name]          VARCHAR (30)  NOT NULL,
    [StreetAddress] VARCHAR (100) NOT NULL,
    [City]          VARCHAR (20)  NOT NULL,
    [Password]      VARCHAR (10)  NOT NULL,
    [Phone]         VARCHAR (10)  NOT NULL,
    [Gender]        VARCHAR (10)  NOT NULL,
    [MailList]      VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);

