IF NOT EXISTS (
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].[spBank]')
    )
BEGIN
  EXEC sp_executesql N'CREATE PROCEDURE [dbo].[spBank] AS select 1'
END
GO

ALTER PROCEDURE [dbo].[spBank] 
    @BankTableType BankTableType READONLY
AS 
BEGIN
	INSERT INTO Bank
	SELECT [Name],Code,CreatedDate,UpdatedDate FROM @BankTableType
END


--DECLARE @Bank BankTableType
--INSERT INTO @Bank VALUES('Odisha Bank','ODB',GETDATE(),GETDATE())

--EXEC spBank @Bank