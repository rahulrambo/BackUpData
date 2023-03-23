DECLARE @Account AS TABLE
(
		[Id] INT CONSTRAINT PK_Account PRIMARY KEY IDENTITY(2000000001,1),
		[CustomerId] INT CONSTRAINT FK_Account_CustomerId FOREIGN KEY REFERENCES Customer(Id) NOT NULL,
		[BankId] INT CONSTRAINT FK_Account_BankId FOREIGN KEY REFERENCES Bank(Id) NOT NULL,
		[BranchId] INT CONSTRAINT FK_Account_BranchId FOREIGN KEY REFERENCES BankBranch(Id) NOT NULL,
		[AccountType] VARCHAR(500) NOT NULL,
		[IsActive] BIT NOT NULL,
		[Balance] MONEY NOT NULL
);
INSERT INTO @Account(CustomerId,BankId,BranchId,AccountType,IsActive,Balance)
VALUES
	(1000000001, 1, 1, 'Salary', 1, 5000),
	(1000000002, 1, 1, 'Saving', 0,500),
	(1000000003, 1, 1, 'NRI', 1, 5500),
	(1000000004, 1, 1, 'Salary', 0, 8000),
	(1000000005, 1, 1, 'Saving', 1, 2000),
	(1000000006, 1, 2, 'Saving', 1, 6000),
	(1000000007, 1, 1, 'Salary', 1, 3000),
	(1000000008, 2, 2, 'Saving', 0, 400),
	(1000000009, 3, 2, 'NRI', 1, 5010),
	(1000000010, 1, 2, 'Salary', 0, 8500),
	(1000000011, 1, 1, 'Saving', 1, 15000),
	(1000000012, 1, 2, 'Saving', 1, 6500),
	(1000000013, 1, 1, 'Salary', 1, 3100),
	(1000000014, 2, 2, 'Saving', 0, 4200),
	(1000000015, 3, 2, 'NRI', 1, 5400),
	(1000000016, 1, 2, 'Salary', 0, 8300),
	(1000000017, 1, 1, 'Saving', 1, 1030),
	(1000000018, 1, 1, 'Saving', 1, 6100),
	(1000000019, 1, 2, 'Saving', 1, 6300),
	(1000000019, 1, 1, 'Saving', 1, 900),
	(1000000019, 2, 1, 'Saving', 1, 900),
	(1000000019, 3, 1, 'Saving', 1, 900),
	(1000000019, 4, 1, 'Saving', 1, 900),
	(1000000020, 1, 1, 'Saving', 1, 6200)

MERGE Account AS TARGET
USING @Account AS SOURCE
ON SOURCE.Id=TARGET.Id
--For insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT(CustomerId,BankId,BranchId,AccountType,IsActive,Balance,CreatedDate,UpdatedDate)
	VALUES(SOURCE.CustomerId,SOURCE.BankId,SOURCE.BranchId,SOURCE.AccountType,SOURCE.IsActive,SOURCE.Balance,GETDATE(), GETDATE())

--For Update
WHEN MATCHED THEN UPDATE SET
	TARGET.CustomerId=SOURCE.CustomerId,
	TARGET.BankId=SOURCE.BankId,
	TARGET.BranchId=SOURCE.BranchId,
	TARGET.AccountType=SOURCE.AccountType,
	TARGET.IsActive=SOURCE.IsActive,
	TARGET.Balance=SOURCE.Balance,
	TARGET.CreatedDate=GETDATE(),
	TARGET.UpdatedDate=GETDATE()

--For Delete
WHEN NOT MATCHED BY SOURCE THEN
DELETE;