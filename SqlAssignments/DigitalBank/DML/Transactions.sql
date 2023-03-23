DECLARE @Transactions AS TABLE
(
		[Id] INT CONSTRAINT PK_Transactions PRIMARY KEY IDENTITY(500000001,1),
		[AccountId] INT CONSTRAINT FK_Transactions_AccountId FOREIGN KEY REFERENCES Account(Id) NOT NULL,
		[TransactionType] VARCHAR(500) NOT NULL,
		[Amount] MONEY NOT NULL,
		[TransactionTime] DATETIME NOT NULL
);
INSERT INTO @Transactions(AccountId,TransactionType,Amount,TransactionTime)
VALUES
	(2000000001, 'Deposit', 6500, '30-Oct-2021'),
	(2000000002, 'Withdraw', 3400, '20-Mar-2020'),
	(2000000003, 'Checks', 2300, '18-Nov-2021'),
	(2000000004, 'Deposit', 2500, '10-Oct-2022'),
	(2000000005, 'Withdraw', 10000, '19-Feb-2020'),
	(2000000006, 'Deposit', 4000, '30-Oct-2021'),
	(2000000007, 'Withdraw', 7000, '20-Mar-2020'),
	(2000000008, 'Checks', 2000, '18-Nov-2021'),
	(2000000009, 'Deposit', 5000, '10-Oct-2022'),
	(2000000010, 'Withdraw', 1000, '19-Feb-2020'),
	(2000000011, 'Deposit', 1500, '30-Oct-2021'),
	(2000000012, 'Withdraw', 1700, '20-Mar-2020'),
	(2000000013, 'Checks', 2000, '18-Nov-2021'),
	(2000000014, 'Deposit', 3000, '10-Oct-2022'),
	(2000000015, 'Withdraw', 3100, '19-Feb-2020'),
	(2000000016, 'Deposit', 4200, '30-Oct-2021'),
	(2000000017, 'Withdraw', 4500, '20-Mar-2020'),
	(2000000018, 'Checks', 5200, '18-Nov-2021'),
	(2000000019, 'Deposit', 5400, '10-Oct-2022'),
	(2000000020, 'Withdraw', 6200, '19-Feb-2020'),
	(2000000021, 'Deposit', 6300, '30-Oct-2021'),
	(2000000022, 'Withdraw', 7000, '20-Mar-2020'),
	(2000000023, 'Checks', 8000, '18-Nov-2021'),
	(2000000024, 'Deposit', 10000, '10-Oct-2022')	

MERGE Transactions AS TARGET
USING @Transactions AS SOURCE
ON SOURCE.Id=TARGET.Id
--For insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT(AccountId,TransactionType,Amount,TransactionTime,CreatedDate,UpdatedDate)
	VALUES(SOURCE.AccountId,SOURCE.TransactionType,SOURCE.Amount,SOURCE.TransactionTime,GETDATE(), GETDATE())

--For Update
WHEN MATCHED THEN UPDATE SET
	TARGET.AccountId=SOURCE.AccountId,
	TARGET.TransactionType=SOURCE.TransactionType,
	TARGET.Amount=SOURCE.Amount,
	TARGET.TransactionTime=SOURCE.TransactionTime,
	TARGET.CreatedDate=GETDATE(),
	TARGET.UpdatedDate=GETDATE()

--For Delete
WHEN NOT MATCHED BY SOURCE THEN
DELETE;