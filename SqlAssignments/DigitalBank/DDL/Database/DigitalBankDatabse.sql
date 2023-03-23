--DROP DATABASE DigitalBank
IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
     WHERE name = 'DigitalBank'
    )
BEGIN
    SELECT 'DigitalBank Database already Exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE [DigitalBank]
    SELECT 'DigitalBank Database is Created' As Message
END

USE DigitalBank