--DROP TABLE Transactions
IF (NOT EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Transactions'))
BEGIN
	CREATE TABLE Transactions
	(
		[Id] INT CONSTRAINT PK_Transactions PRIMARY KEY IDENTITY(500000001,1),
		[AccountId] INT CONSTRAINT FK_Transactions_AccountId FOREIGN KEY REFERENCES Account(Id) NOT NULL,
		[TransactionType] VARCHAR(500) NOT NULL,
		[Amount] MONEY NOT NULL,
		[TransactionTime] DATETIME NOT NULL,
		[CreatedDate] DATETIME NOT NULL,
		[UpdatedDate] DATETIME NOT NULL
	);
END