--DROP TABLE Customer;
IF (NOT EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Customer'))
BEGIN
	CREATE TABLE Customer
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
		ZipCode VARCHAR(10) NOT NULL,
		CreatedDate datetime NOT NULL,
		UpdatedDate datetime NOT NULL
	);
END