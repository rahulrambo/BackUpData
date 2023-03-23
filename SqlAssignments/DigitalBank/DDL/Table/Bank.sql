--DROP TABLE Bank;
IF (NOT EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Bank'))
Begin
	CREATE TABLE Bank
	(
		Id INT CONSTRAINT PK_Bank PRIMARY KEY IDENTITY(1,1),
		[Name] VARCHAR(500) NOT NULL,
		Code VARCHAR(500) NOT NULL,
		CONSTRAINT UQ_Bank_Code UNIQUE(Code),
		CreatedDate DATETIME NOT NULL,
		UpdatedDate DATETIME NOT NULL
	);
END