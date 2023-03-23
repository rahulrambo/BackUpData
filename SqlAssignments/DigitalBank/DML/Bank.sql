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