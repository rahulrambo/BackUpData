DECLARE @Bank AS TABLE
(
		Id INT CONSTRAINT PK_Bank PRIMARY KEY IDENTITY(1,1),
		[Name] VARCHAR(500) NOT NULL,
		Code VARCHAR(500) NOT NULL,
		CONSTRAINT UQ_Bank_Code UNIQUE(Code)
);
INSERT INTO @Bank(Name,Code)
VALUES
	('State Bank of India', 'SBI'),
	('Bank of India', 'BOI'),
	('Central Bank of India', 'CBI'),
	('Union Bank of India', 'UBI'),
	('Canara Bank', 'CB')

MERGE Bank AS TARGET
USING @Bank AS SOURCE
ON SOURCE.Id=TARGET.Id

--For insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT(Name,Code,CreatedDate,UpdatedDate)
	VALUES(SOURCE.Name,SOURCE.Code,GETDATE(), GETDATE())

--For Update
WHEN MATCHED THEN UPDATE SET
	TARGET.Name=SOURCE.Name,
	TARGET.Code=SOURCE.Code,
	TARGET.CreatedDate=GETDATE(),
	TARGET.UpdatedDate=GETDATE()

--For Delete
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


DECLARE @BankBranch AS TABLE
(
		Id INT CONSTRAINT PK_BankBranch PRIMARY KEY IDENTITY(1,1),
		Code VARCHAR(500) CONSTRAINT UQ_BankBranch_Code UNIQUE(Code) NOT NULL,
		Address1 VARCHAR(1000) NOT NULL,
		Address2 VARCHAR(1000),
		City VARCHAR(500) NOT NULL,
		District VARCHAR(500) NOT NULL,
		[State] VARCHAR(500) NOT NULL,
		ZipCode VARCHAR(10) NOT NULL,
		BankId INT CONSTRAINT FK_BankBranch_BankId FOREIGN KEY REFERENCES Bank(Id) NOT NULL
);
INSERT INTO @BankBranch(Code,Address1,City,District,[State],ZipCode,BankId)
VALUES
	('SBIN0018186', 'Akimpet', 'Medchal', 'Hyderabad', 'Telangana', '500014', '1'),
	('BKID0008600', 'AnandBagh', 'Malkajgiri', 'Hyderabad', 'Telangana', '500095', '2'),
	('CBIN0281048', 'Hanuman Nagar Main Road', 'Boduppal', 'Hyderabad', 'Telangana', '500092', '3'),
	('UBIN0575208.', 'AnandBagh', 'Malkajgiri', 'Hyderabad', 'Telangana', '500095', '4'),
	('CNRB0001825', 'Hanuman Nagar Main Road', 'Boduppal', 'Hyderabad', 'Telangana', '500092', '5'),
	('SBIN0018187', 'Begampet', 'Madhapur', 'Hyderabad', 'Telangana', '500017', '1'),
	('SBIN0018189', 'Durgam Cheruvu', 'Madhapur', 'Hyderabad', 'Telangana', '500016', '1')

MERGE BankBranch AS TARGET
USING @BankBranch AS SOURCE
ON SOURCE.Id=TARGET.Id
--For insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT(Code,Address1,City,District,[State],ZipCode,BankId,CreatedDate,UpdatedDate)
	VALUES(SOURCE.Code,SOURCE.Address1,SOURCE.City,SOURCE.District,SOURCE.State,SOURCE.ZipCode,SOURCE.BankId,GETDATE(), GETDATE())

--For Update
WHEN MATCHED THEN UPDATE SET
	TARGET.Code=SOURCE.Code,
	TARGET.Address1=SOURCE.Address1,
	TARGET.City=SOURCE.City,
	TARGET.District=SOURCE.District,
	TARGET.State=SOURCE.State,
	TARGET.ZipCode=SOURCE.ZipCode,
	TARGET.BankId=SOURCE.BankId,
	TARGET.CreatedDate=GETDATE(),
	TARGET.UpdatedDate=GETDATE()

--For Delete
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


DECLARE @Customer AS TABLE
(
		Id INT CONSTRAINT Pk_Customer PRIMARY KEY IDENTITY(1000000001,1),
		FirstName VARCHAR(1000) NOT NULL,
		MiddleName VARCHAR(1000),
		LastName VARCHAR(1000) NOT NULL,
		Address1 VARCHAR(1000) NOT NULL,
		Address2 VARCHAR(1000),
		City VARCHAR(500) NOT NULL,
		District VARCHAR(500) NOT NULL,
		[State] VARCHAR(500) NOT NULL,
		ZipCode VARCHAR(10) NOT NULL
);
INSERT INTO @Customer(FirstName,LastName,Address1,City,District,[State],ZipCode)
VALUES
	('Rahul','Kumar','Piro','Ara','Bhojpur','Bihar','802202'),
	('Dharmendra','Kumar','Bettiah','Patna','Bettiah','Bihar','802105'),
	('Samvid','Mokirala','Hyderabad','Begampet','Guntur','Telangana','500012'),
	('Jagan','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602001'),
	('Vijay','Pottabattini','Hyderabad','Hitech-City','Guntur','Telangana','500015'),
	('Sunil','Desai','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802201'),
	('Jay','Paswan','Piro','Ara','Bhojpur','Bihar','802202'),
	('Bharat','Kumar','Dumraon','Ara','Patna','Bihar','802103'),
	('Sunny','Kumar','Buxar','Buxar','Buxar','Bihar','802216'),
	('Bhim','Kumar','Hyderabad','Begampet','Guntur','Telangana','500016'),
	('Ravi','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602010'),
	('Mohan','Kumar','Hyderabad','Hitech-City','Guntur','Telangana','500018'),
	('Raj','Prakash','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802112'),
	('Shambhu','Paswan','Piro','Ara','Bhojpur','Bihar','802202'),
	('Sonu','Kumar','Piro','Ara','Bhojpur','Bihar','802202'),
	('Sohan','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602001'),
	('Santosh','Pottabattini','Hyderabad','Hitech-City','Guntur','Telangana','500015'),
	('Rohan','Desai','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802201'),
	('Lalan','Paswan','Piro','Ara','Bhojpur','Bihar','802202'),
	('Sanjay','Mokirala','Hyderabad','Begampet','Guntur','Telangana','500012')	

UPDATE Customer SET MiddleName='Kumar' WHERE FirstName='Vijay'
UPDATE Customer SET MiddleName='Kumar' WHERE FirstName='Sunil'
UPDATE Customer SET MiddleName='Prakash' WHERE FirstName='Jay'

MERGE Customer AS TARGET
USING @Customer AS SOURCE
ON SOURCE.Id=TARGET.Id
--For insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT(FirstName,LastName,Address1,City,District,[State],ZipCode,CreatedDate,UpdatedDate)
	VALUES(SOURCE.FirstName,SOURCE.LastName,SOURCE.Address1,SOURCE.City,SOURCE.District,SOURCE.State,SOURCE.ZipCode,GETDATE(), GETDATE())

--For Update
WHEN MATCHED THEN UPDATE SET
	TARGET.FirstName=SOURCE.FirstName,
	TARGET.LastName=SOURCE.LastName,
	TARGET.Address1=SOURCE.Address1,
	TARGET.City=SOURCE.City,
	TARGET.District=SOURCE.District,
	TARGET.State=SOURCE.State,
	TARGET.ZipCode=SOURCE.ZipCode,
	TARGET.CreatedDate=GETDATE(),
	TARGET.UpdatedDate=GETDATE()

--For Delete
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


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