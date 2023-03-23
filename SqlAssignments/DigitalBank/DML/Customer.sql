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