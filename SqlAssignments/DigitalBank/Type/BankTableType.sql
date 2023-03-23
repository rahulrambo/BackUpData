IF (NOT EXISTS (SELECT *
           FROM   [sys].[table_types]
           WHERE  user_type_id = Type_id(N'[dbo].[BankTableType]')))
BEGIN
    CREATE TYPE BankTableType AS TABLE
	(	
	[Name] VARCHAR(500) NOT NULL,
	Code VARCHAR(500) UNIQUE NOT NULL,
	CreatedDate DATETIME NOT NULL,
	UpdatedDate DATETIME NOT NULL
	)
END