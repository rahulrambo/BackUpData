DROP DATABASE DigitalBank
USE DigitalBank

--DROP TABLE Bank;
IF (EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Bank'))
Begin
	CREATE TABLE Bank
	(
		Id INT CONSTRAINT PK_Bank PRIMARY KEY IDENTITY(1,1),
		[Name] VARCHAR(500) not null,
		Code VARCHAR(500) Not Null,
		CONSTRAINT UQ_Bank_Code UNIQUE(Code),
		CreatedDate DATETIME Not Null,
		UpdatedDate DATETIME Not Null
	);
END

INSERT INTO Bank ([Name], Code, CreatedDate, UpdatedDate) VALUES
	('State Bank of India', 'SBI', '1992-10-10', '2021-12-12'),
	('Bank of India', 'BOI', '1998-05-02', '2019-03-01'),
	('Central Bank of India', 'CBI', '1996-09-19', '2022-10-11'),
	('Union Bank of India', 'UBI', '1991-02-17', '2020-03-05'),
	('Canara Bank', 'CB', '1993-10-29', '2021-12-21')
--select * from Bank

--DROP TABLE BankBranch;
IF (EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'BankBranch'))
BEGIN
	CREATE TABLE BankBranch
	(
		Id INT CONSTRAINT PK_BankBranch PRIMARY KEY IDENTITY(1,1),
		Code VARCHAR(500) CONSTRAINT UQ_BankBranch_Code UNIQUE(Code) Not Null,
		Address1 VARCHAR(1000) Not Null,
		Address2 VARCHAR(1000),
		City VARCHAR(500) Not Null,
		District VARCHAR(500) Not Null,
		[State] VARCHAR(500) Not Null,
		ZipCode VARCHAR(10) Not Null,
		BankId INT CONSTRAINT FK_BankBranch_BankId FOREIGN KEY REFERENCES Bank(Id) Not Null,
		CreatedDate DATETIME Not Null,
		UpdatedDate DATETIME Not Null
	);
END

INSERT INTO BankBranch(Code,Address1,City,District,[State],ZipCode,BankId,CreatedDate,UpdatedDate) VALUES 
	('SBIN0018186', 'Akimpet', 'Medchal', 'Hyderabad', 'Telangana', '500014', '1', '1998-10-19', '2020-12-13'),
	('BKID0008600', 'AnandBagh', 'Malkajgiri', 'Hyderabad', 'Telangana', '500095', '2', '1999-11-29', '2021-11-03'),
	('CBIN0281048', 'Hanuman Nagar Main Road', 'Boduppal', 'Hyderabad', 'Telangana', '500092', '3', '1993-06-21', '2022-02-10'),
	('UBIN0575208.', 'AnandBagh', 'Malkajgiri', 'Hyderabad', 'Telangana', '500095', '4', '1991-10-19', '2022-10-13'),
	('CNRB0001825', 'Hanuman Nagar Main Road', 'Boduppal', 'Hyderabad', 'Telangana', '500092', '5', '1999-06-22', '2022-12-02'),
	('SBIN0018187', 'Begampet', 'Madhapur', 'Hyderabad', 'Telangana', '500017', '1', '1995-11-09', '2022-10-23'),
	('SBIN0018189', 'Durgam Cheruvu', 'Madhapur', 'Hyderabad', 'Telangana', '500016', '1', '1990-12-09', '2021-08-12')

--SELECT * FROM BankBranch;

--DROP TABLE Customer;
IF (EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Customer'))
BEGIN
	CREATE TABLE Customer
	(
		Id INT CONSTRAINT Pk_Customer PRIMARY KEY IDENTITY(1000000001,1),
		FirstName VARCHAR(1000) Not Null,
		MiddleName VARCHAR(1000),
		LastName VARCHAR(1000) Not Null,
		Address1 VARCHAR(1000) Not Null,
		Address2 VARCHAR(1000),
		City VARCHAR(500) Not Null,
		District VARCHAR(500) Not Null,
		[State] VARCHAR(500) Not Null,
		ZipCode VARCHAR(10) Not Null,
		CreatedDate datetime Not Null,
		UpdatedDate datetime Not Null
	);
END

INSERT INTO Customer(FirstName,LastName,Address1,City,District,[State],ZipCode,CreatedDate,UpdatedDate) VALUES
	('Rahul','Kumar','Piro','Ara','Bhojpur','Bihar','802202','12-Mar-2020','12-Jun-2022'),
	('Dharmendra','Kumar','Bettiah','Patna','Bettiah','Bihar','802105','22-Mar-2019','12-Jun-2021'),
	('Samvid','Mokirala','Hyderabad','Begampet','Guntur','Telangana','500012','12-Mar-2005','22-Jan-2021'),
	('Jagan','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602001','12-Mar-2004','12-Feb-2016'),
	('Vijay','Pottabattini','Hyderabad','Hitech-City','Guntur','Telangana','500015','02-Apr-2002','05-Oct-2021'),
	('Sunil','Desai','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802201','22-Jan-2019','22-Dec-2022'),
	('Jay','Paswan','Piro','Ara','Bhojpur','Bihar','802202','02-Feb-2015','22-Apr-2022'),
	('Bharat','Kumar','Dumraon','Ara','Patna','Bihar','802103','20-Mar-2016','12-Jun-2022'),
	('Sunny','Kumar','Buxar','Buxar','Buxar','Bihar','802216','25-Aug-2019','10-Jan-2022'),
	('Bhim','Kumar','Hyderabad','Begampet','Guntur','Telangana','500016','12-Mar-2015','22-Jan-2022'),
	('Ravi','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602010','12-Mar-2014','12-Feb-2022'),
	('Mohan','Kumar','Hyderabad','Hitech-City','Guntur','Telangana','500018','02-Apr-2012','05-Oct-2022'),
	('Raj','Prakash','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802112','22-Jan-2021','02-Dec-2022'),
	('Shambhu','Paswan','Piro','Ara','Bhojpur','Bihar','802202','02-Feb-2015','22-Apr-2022'),
	('Sonu','Kumar','Piro','Ara','Bhojpur','Bihar','802202','12-Mar-2001','12-Nov-2022'),
	('Sohan','Kumar','Bhubaneswar','Jagannath puri','Bhubaneswar','Odisa','602001','12-Mar-2014','12-Feb-2019'),
	('Santosh','Pottabattini','Hyderabad','Hitech-City','Guntur','Telangana','500015','02-Apr-2012','25-Oct-2022'),
	('Rohan','Desai','Hazaribagh','Hazaribagh','Ranchi','Jharkhand','802201','22-Jan-2020','12-Dec-2022'),
	('Lalan','Paswan','Piro','Ara','Bhojpur','Bihar','802202','02-Feb-2005','22-Apr-2021'),
	('Sanjay','Mokirala','Hyderabad','Begampet','Guntur','Telangana','500012','12-Mar-2008','28-Jan-2021')	

update Customer set MiddleName='Kumar' where FirstName='Vijay'
update Customer set MiddleName='Kumar' where FirstName='Sunil'
update Customer set MiddleName='Prakash' where FirstName='Jay'

--SELECT * FROM Customer

--DROP TABLE Account;
IF (EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Account'))
BEGIN
	CREATE TABLE Account
	(
		[Id] INT CONSTRAINT PK_Account PRIMARY KEY IDENTITY(2000000001,1),
		[CustomerId] INT CONSTRAINT FK_Account_CustomerId FOREIGN KEY REFERENCES Customer(Id) Not Null,
		[BankId] INT CONSTRAINT FK_Account_BankId FOREIGN KEY REFERENCES Bank(Id) Not Null,
		[BranchId] INT CONSTRAINT FK_Account_BranchId FOREIGN KEY REFERENCES BankBranch(Id) Not Null,
		[AccountType] VARCHAR(500) Not Null,
		[IsActive] BIT Not Null,
		[Balance] MONEY Not Null,
		[CreatedDate] DATETIME Not Null,
		[UpdatedDate] DATETIME Not Null
	);
END

INSERT INTO Account(CustomerId,BankId,BranchId,AccountType,IsActive,Balance,CreatedDate,UpdatedDate) VALUES
	(1000000001, 1, 1, 'Salary', 1, 5000, '10-Dec-2021', '05-Oct-2022'),
	(1000000002, 1, 1, 'Saving', 0,500, '01-Mar-2022', '05-Nov-2022'),
	(1000000003, 1, 1, 'NRI', 1, 5500, '25-Feb-2020', '02-Aug-2022'),
	(1000000004, 1, 1, 'Salary', 0, 8000, '05-Jan-2019', '02-Oct-2021'),
	(1000000005, 1, 1, 'Saving', 1, 2000, '30-Dec-2002', '15-Oct-2020'),
	(1000000006, 1, 2, 'Saving', 1, 6000, '10-Mar-2020', '25-Oct-2022'),
	(1000000007, 1, 1, 'Salary', 1, 3000, '10-Dec-2021', '05-Oct-2022'),
	(1000000008, 2, 2, 'Saving', 0, 400, '01-Mar-2022', '05-Nov-2022'),
	(1000000009, 3, 2, 'NRI', 1, 5010, '25-Feb-2020', '02-Aug-2022'),
	(1000000010, 1, 2, 'Salary', 0, 8500, '05-Jan-2019', '02-Oct-2021'),
	(1000000011, 1, 1, 'Saving', 1, 15000, '30-Dec-2002', '15-Oct-2020'),
	(1000000012, 1, 2, 'Saving', 1, 6500, '10-Mar-2020', '25-Oct-2022'),
	(1000000013, 1, 1, 'Salary', 1, 3100, '10-Dec-2021', '05-Oct-2022'),
	(1000000014, 2, 2, 'Saving', 0, 4200, '01-Mar-2022', '05-Nov-2022'),
	(1000000015, 3, 2, 'NRI', 1, 5400, '25-Feb-2020', '02-Aug-2022'),
	(1000000016, 1, 2, 'Salary', 0, 8300, '05-Jan-2019', '02-Oct-2021'),
	(1000000017, 1, 1, 'Saving', 1, 1030, '30-Dec-2002', '15-Oct-2020'),
	(1000000018, 1, 1, 'Saving', 1, 6100, '10-Mar-2020', '25-Oct-2022'),
	(1000000019, 1, 2, 'Saving', 1, 6300, '30-Dec-2002', '15-Oct-2020'),
	(1000000019, 1, 1, 'Saving', 1, 900, '30-Dec-2002', '15-Oct-2020'),
	(1000000019, 2, 1, 'Saving', 1, 900, '30-Dec-2002', '15-Oct-2020'),
	(1000000019, 3, 1, 'Saving', 1, 900, '30-Dec-2002', '15-Oct-2020'),
	(1000000019, 4, 1, 'Saving', 1, 900, '30-Dec-2002', '15-Oct-2020'),
	(1000000020, 1, 1, 'Saving', 1, 6200, '10-Mar-2020', '25-Oct-2022')

--SELECT * FROM Account

--DROP TABLE Transactions
IF (EXISTS (SELECT 1 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Transactions'))
BEGIN
	CREATE TABLE Transactions
	(
		[Id] INT CONSTRAINT PK_Transactions PRIMARY KEY IDENTITY(500000001,1),
		[AccountId] INT CONSTRAINT FK_Transactions_AccountId FOREIGN KEY REFERENCES Account(Id) Not Null,
		[TransactionType] VARCHAR(500) Not Null,
		[Amount] MONEY Not Null,
		[TransactionTime] DATETIME Not Null,
		[CreatedDate] DATETIME Not Null,
		[UpdatedDate] DATETIME Not Null
	);
END

INSERT INTO Transactions(AccountId,TransactionType,Amount,TransactionTime,CreatedDate,UpdatedDate) VALUES
	(2000000001, 'Deposit', 6500, '30-Oct-2021', '12-Oct-2000', '10-Dec-2022'),
	(2000000002, 'Withdraw', 3400, '20-Mar-2020', '02-Mar-2008', '12-Nov-2022'),
	(2000000003, 'Checks', 2300, '18-Nov-2021', '01-Jul-2005', '28-Nov-2022'),
	(2000000004, 'Deposit', 2500, '10-Oct-2022', '02-Mar-2009', '12-Nov-2022'),
	(2000000005, 'Withdraw', 10000, '19-Feb-2020', '12-Dec-2001', '22-Nov-2021'),
	(2000000006, 'Deposit', 4000, '30-Oct-2021', '12-Oct-2000', '10-Dec-2022'),
	(2000000007, 'Withdraw', 7000, '20-Mar-2020', '02-Mar-2008', '12-Nov-2022'),
	(2000000008, 'Checks', 2000, '18-Nov-2021', '01-Jul-2005', '28-Nov-2022'),
	(2000000009, 'Deposit', 5000, '10-Oct-2022', '02-Mar-2009', '12-Nov-2022'),
	(2000000010, 'Withdraw', 1000, '19-Feb-2020', '12-Dec-2001', '22-Nov-2021'),
	(2000000011, 'Deposit', 1500, '30-Oct-2021', '12-Oct-2000', '10-Dec-2022'),
	(2000000012, 'Withdraw', 1700, '20-Mar-2020', '02-Mar-2008', '12-Nov-2022'),
	(2000000013, 'Checks', 2000, '18-Nov-2021', '01-Jul-2005', '28-Nov-2022'),
	(2000000014, 'Deposit', 3000, '10-Oct-2022', '02-Mar-2009', '12-Nov-2022'),
	(2000000015, 'Withdraw', 3100, '19-Feb-2020', '12-Dec-2001', '22-Nov-2021'),
	(2000000016, 'Deposit', 4200, '30-Oct-2021', '12-Oct-2000', '10-Dec-2022'),
	(2000000017, 'Withdraw', 4500, '20-Mar-2020', '02-Mar-2008', '12-Nov-2022'),
	(2000000018, 'Checks', 5200, '18-Nov-2021', '01-Jul-2005', '28-Nov-2022'),
	(2000000019, 'Deposit', 5400, '10-Oct-2022', '02-Mar-2009', '12-Nov-2022'),
	(2000000020, 'Withdraw', 6200, '19-Feb-2020', '12-Dec-2001', '22-Nov-2021'),
	(2000000021, 'Deposit', 6300, '30-Oct-2021', '12-Oct-2000', '10-Dec-2022'),
	(2000000022, 'Withdraw', 7000, '20-Mar-2020', '02-Mar-2008', '12-Nov-2022'),
	(2000000023, 'Checks', 8000, '18-Nov-2021', '01-Jul-2005', '28-Nov-2022'),
	(2000000024, 'Deposit', 10000, '10-Oct-2022', '02-Mar-2009', '12-Nov-2022')	

--SELECT * FROM Transactions


-------1.Get all customers of a bank, bank code or id is the input-------- 
declare @BankCode varchar(250) = 'SBI'
select a.BankId, b.Name, c.FirstName 
from Bank as b
inner join Account as a on a.BankId=b.Id  
inner join Customer as c on a.CustomerId=c.Id
where b.Code = @BankCode


-------2.Get Highest balance customer of every bank--------

-- Using Temp Table
select b.Name,c.FirstName, Max(a.Balance) as MaxBalance, dense_rank() over(partition by b.Name order by Max(a.Balance) DESC) as rank1
INTO #TempBank
from Bank as b
inner join Account as a on a.BankId=b.Id  
inner join Customer as c on a.CustomerId=c.Id
group by b.Name,c.FirstName
DECLARE @MaximumBalance VARCHAR(1000) ='SELECT Name, FirstName, MaxBalance FROM #TempBank
                                  WHERE 1=1 AND rank1 = 1';
EXEC (@MaximumBalance)
DROP TABLE #TempBank

-- Using With clause
with TempBank AS
(
	select b.Name,c.FirstName, Max(a.Balance) as MaxBalance, dense_rank() over(partition by b.Name order by Max(a.Balance) DESC) as rank1
	from Bank as b
	inner join Account as a on a.BankId=b.Id  
	inner join Customer as c on a.CustomerId=c.Id
	group by b.Name,c.FirstName
)
select Name, FirstName, MaxBalance from TempBank
where rank1 = 1


-----3.Get second highest customer of every bank-----
with TempBank AS
(
	select b.Name,c.FirstName, Max(a.Balance) as MaxBalance, dense_rank() over(partition by b.Name order by Max(a.Balance) DESC) as rank1
	from Bank as b
	inner join Account as a on a.BankId=b.Id  
	inner join Customer as c on a.CustomerId=c.Id
	group by b.Name,c.FirstName
)
select Name, FirstName, MaxBalance from TempBank
where rank1 = 2


-------4.Get customers who has more than one bank account in same bank--------
select b.Name,c.FirstName
from Bank as b
inner join Account as a on a.BankId=b.Id
inner join Customer as c on c.Id=a.CustomerId
group by b.Name,c.FirstName
HAVING COUNT(a.BankId)>1

-----5.Get customers who has more than three accounts in different banks------
with CustomerBankAccounts AS
(select a.CustomerId, a.BankId, count(1) as accountcount from Account a
group by a.CustomerId, a.BankId),
CustomersHavingMoreThanTwoDiff AS
(Select c.CustomerId, count(1) as TotalAccounts from CustomerBankAccounts c
group by c.CustomerId
having count(1) > 2
)
select c.*, ca.TotalAccounts
from CustomersHavingMoreThanTwoDiff ca
inner join Customer c on c.Id = ca.CustomerId


--with tempData as
--(
--	select b.Name,c.Firstname,dense_rank() over(partition by b.Name order by c.FirstName)as rank3
--	from Bank as b
--	inner join Account as a on a.BankId=b.Id
--	inner join Customer as c on c.Id=a.CustomerId
--	group by b.Name,c.FirstName
--	HAVING COUNT(a.BankId)>3
--)
--select Name,Firstname from tempData
--where rank1 = 2

--select b.Name,COUNT(b.Id)
--from Bank as b
--inner join Account as a on a.BankId=b.Id
--inner join Customer as c on c.Id=a.CustomerId
--group by b.Name
--having COUNT(b.Id)>3


-----6.Get banks which has all customers balance more than 1000--------
select b.Name,c.FirstName,a.Balance
from Bank as b
inner join Account as a on a.BankId=b.Id
inner join Customer as c on a.CustomerId=c.Id
where a.Balance>1000

-----7.Get customers whose name starts with 'Rah'-------
select * from Customer where FirstName like('Rah%')

-----8.Get customers whose has middle name as 'kumar'------
select * from Customer where MiddleName='kumar'

-----9.Get customers whose name(first name, middle name or last name) contains 'jay'-------
select * from Customer where FirstName like('%jay%') or MiddleName like('%jay%') or LastName like('%jay%')

-----10.Get branches of banks which has more than 10 customers------
select br.Code,br.BankId
from BankBranch as br
inner join Account as a on a.BranchId=br.Id
inner join Customer as c on c.Id=a.CustomerId
group by br.Code,br.BankId
having COUNT(br.BankId)>10

-----11.Get branches of bank which has no customers------
select bb.* from BankBranch bb
left join Account a on a.BranchId = bb.Id and a.IsActive = 1
where a.BranchId is null
