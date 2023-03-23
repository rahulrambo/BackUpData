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