-- https:// 
-- docs.microsoft.com/en-us/sql/ssms/tutorials/connect-query-sql-server?view=sql-server-2017

USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'TutorialDB'
)
CREATE DATABASE [TutorialDB] 
GO

Alter DATABASE [TutorialDB] SET QUERY_STORE=ON
GO
