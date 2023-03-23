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

----The above question can be solved by the below way also.--------
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
