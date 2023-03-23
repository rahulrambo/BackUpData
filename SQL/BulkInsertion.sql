CREATE TABLE [User] 
(
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Email VARCHAR(50) CONSTRAINT Uk_Email UNIQUE
)

CREATE TYPE UserTableType AS TABLE
(
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Email VARCHAR(50) UNIQUE
)

CREATE PROC sp_User
@UserTableType UserTableType READONLY
AS 
BEGIN
	INSERT INTO [User]
	SELECT * FROM @UserTableType
END

DECLARE @User UserTableType
INSERT INTO @User VALUES('Rahul','Kumar','rk@1230@gmail.com')

EXEC sp_User @User

SELECT * FROM [User]
truncate table [User]

drop procedure [<sp_User>];
Go
drop type UserTableType
















CREATE TYPE BankTableType AS TABLE
(	
	[Name] VARCHAR(500) NOT NULL,
	Code VARCHAR(500) NOT NULL,
	CreatedDate DATETIME NOT NULL,
	UpdatedDate DATETIME NOT NULL
)

CREATE PROC spBank
@BankTableType BankTableType READONLY
AS 
BEGIN
	INSERT INTO Bank
	SELECT * FROM @BankTableType
END

DECLARE @Bank BankTableType
INSERT INTO @Bank VALUES('TestBanks','TSBE',GETDATE(),GETDATE())

EXEC spBank @Bank

select * from Bank


IF EXISTS(SELECT 1 FROM sys.types WHERE name = 'UserTableType' AND is_table_type = 1 AND schema_id = SCHEMA_ID('VAB'))
DROP TYPE VAB.Person;
go
CREATE TYPE VAB.Person AS TABLE
(    PersonID               INT
    ,FirstName              VARCHAR(255)
    ,MiddleName             VARCHAR(255)
    ,LastName               VARCHAR(255)
    ,PreferredName          VARCHAR(255)
);

IF (NOT EXISTS (SELECT *
           FROM   [sys].[table_types]
           WHERE  user_type_id = Type_id(N'[dbo].[BankTableType]')))
BEGIN
    CREATE TYPE BankTableType AS TABLE
	(	
	[Name] VARCHAR(500) NOT NULL,
	Code VARCHAR(500) UNIQUE NOT NULL,
	CreatedDate DATETIME NOT NULL,
	UpdatedDate DATETIME NOT NULL
	)
END 

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE name='SelectAllAccounts')) BEGIN
    print 'exists'  -- or watever you want
END ELSE BEGIN
    print 'doesn''texists'   -- or watever you want
END

IF NOT EXISTS (
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[spBank]')
    )
BEGIN
  EXEC sp_executesql N'CREATE PROCEDURE [dbo].[spBank] AS select 1'
END
GO

ALTER PROCEDURE [dbo].[spBank] 
    @BankTableType BankTableType READONLY
AS 
BEGIN
	INSERT INTO Bank
	SELECT * FROM @BankTableType
END

DECLARE @Bank BankTableType
INSERT INTO @Bank VALUES('Abc','SBE',GETDATE(),GETDATE())

EXEC spBank @Bank