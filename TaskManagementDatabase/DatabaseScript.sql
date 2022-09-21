SET XACT_ABORT ON;
BEGIN TRANSACTION;
GO


IF NOT EXISTS (SELECT * FROM sys.databases 
WHERE name = 'TaskManagementDB')
CREATE DATABASE ProductsDB  
ON   
( NAME =Products_dat,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER_2019\MSSQL\DATA\taskmanagementdbdat.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = Products_log,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER_2019\MSSQL\DATA\taskmanagementdblog.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
GO  

IF NOT EXISTS (SELECT * FROM sys.tables
WHERE name = N'TaskStatus' AND type = 'U')
BEGIN
 CREATE TABLE [TaskManagementDB].[dbo].[TaskStatus]
	           (
			   [Id] int Identity(1,1) NOT NULL,
			   [Status] nvarchar(50) NOT NULL,
			   [Deleted] int NOT NULL,
			   CONSTRAINT PK_TaskStatus_Id PRIMARY KEY ([Id])
			   )
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables
WHERE name = N'DeletedReason' AND type = 'U')
BEGIN
 CREATE TABLE [TaskManagementDB].[dbo].[DeletedReason]
	           (
			   [Id] int Identity(1,1) NOT NULL,
			   [Reason] nvarchar(50) NOT NULL,
			   [Deleted] int NOT NULL,
			   CONSTRAINT PK_DeletedReason_Id PRIMARY KEY ([Id])
			   )
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables
WHERE name = N'TaskPriority' AND type = 'U')
BEGIN
 CREATE TABLE [TaskManagementDB].[dbo].[TaskPriority]
	           (
			   [Id] int Identity(1,1) NOT NULL,
			   [Priority] nvarchar(50) NOT NULL,
			   [Deleted] int NOT NULL,
			   CONSTRAINT PK_TaskPriority_Id PRIMARY KEY ([Id])
			   )
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables
WHERE name = N'Task' AND type = 'U')
BEGIN
    CREATE TABLE [TaskManagementDB].[dbo].[Task]
	           (
			   [Id] int Identity(1,1) NOT NULL,
			   [Name] nvarchar(50) NOT NULL,
			   [Description] nvarchar(255) NOT NULL,
			   [PriorityId] int NOT NULL,
			   [StatusId] int NOT NULL,
			   [StartDateUTC] datetime2 NOT NULL,
			   [EndDateUTC] datetime2 NOT NULL,
			   [CreatedDateUTC] datetime2 NOT NULL,
			   [LastModifiedDateUTC] datetime2 NOT NULL,
			   CONSTRAINT PK_Task_Id PRIMARY KEY ([Id]),
			   CONSTRAINT [FK_Priority_PriorityId] FOREIGN KEY
						 (	
						 	[PriorityId] 
						 ) REFERENCES [TaskManagementDB].[dbo].[TaskPriority] (Id),
			   CONSTRAINT [FK_Status_StatusId] FOREIGN KEY
						 (	
						 	[StatusId] 
						 ) REFERENCES [TaskManagementDB].[dbo].[TaskStatus] (Id)
				)
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables
WHERE name = N'DeletedTask' AND type = 'U')
BEGIN
	 CREATE TABLE [TaskManagementDB].[dbo].[DeletedTask]
	           (
			   [Id] int Identity(1,1) NOT NULL,
			   [DeletedTaskId]  int NOT NULL,
			   [ReasonForDeletionId] int NOT NULL,
			   [DeletionComment] int NOT NULL,
			   [DeletedDateUTC] datetime2 NOT NULL,
			   CONSTRAINT PK_DeletedTask_Id PRIMARY KEY ([Id]),
			   CONSTRAINT [FK_Task_DeletedTaskId] FOREIGN KEY
						 (	
						 	[DeletedTaskId] 
						 ) REFERENCES [TaskManagementDB].[dbo].[Task] (Id),
			   CONSTRAINT [FK_DeletedReason_DeletedReasonId] FOREIGN KEY
						 (	
						 	[ReasonForDeletionId] 
						 ) REFERENCES [TaskManagementDB].[dbo].[DeletedReason] (Id)
				)
END
GO


---------------------------Manual Inserts to the DB---------------------
DECLARE @DeletedReason table
(
	[Id] int NOT NULL,
	[Reason] nvarchar(50) NOT NULL,
	[Deleted] bit NOT NULL
	PRIMARY KEY CLUSTERED ([Id])
);

SET IDENTITY_INSERT [TaskManagementDB].[dbo].[DeletedReason] ON; 


INSERT INTO @DeletedReason ([Id], [Reason],[Deleted]) -- must declare table
VALUES
 (1, N'Task already exists',0), 
 (2, N'Task not needed',0)

 DELETE [T]
FROM [TaskManagementDB].[dbo].[DeletedReason] AS [T]
 LEFT OUTER JOIN @DeletedReason AS [S]
  ON [S].[Id] = [T].[Id]
 WHERE [S].[Id] IS NULL;

MERGE INTO [TaskManagementDB].[dbo].[DeletedReason] AS [T]
USING @DeletedReason AS [S]
 ON [S].[Id] = [T].[Id]
 WHEN MATCHED 
   THEN UPDATE 
		SET [T].[Deleted] = 0    
  WHEN NOT MATCHED BY TARGET
   THEN INSERT ([Id], [Reason],[Deleted])
     VALUES([S].[Id], [S].[Reason], [S].[Deleted]);
	 SET IDENTITY_INSERT [TaskManagementDB].[dbo].[DeletedReason] OFF; 

---------------------------------------------------------------------
DECLARE @TaskPriority table
(
	[Id] int NOT NULL,
	[Priority] nvarchar(50) NOT NULL,
	[Deleted] bit NOT NULL
	PRIMARY KEY CLUSTERED ([Id])
);
	
SET IDENTITY_INSERT [TaskManagementDB].[dbo].[TaskPriority] ON; 



INSERT INTO @TaskPriority ([Id], [Priority],[Deleted]) -- must declare table
VALUES
 (1, N'Low',0), 
 (2, N'Medium',0),
 (3, N'High',0),
 (4, N'Medium',0)

 DELETE [T]
FROM [TaskManagementDB].[dbo].[TaskPriority] AS [T]
 LEFT OUTER JOIN @TaskPriority AS [S]
  ON [S].[Id] = [T].[Id]
 WHERE [S].[Id] IS NULL;


MERGE INTO [TaskManagementDB].[dbo].[TaskPriority] AS [T]
USING @TaskPriority AS [S]
 ON [S].[Id] = [T].[Id]
 WHEN MATCHED 
   THEN UPDATE 
		SET [T].[Deleted] = 0    
  WHEN NOT MATCHED BY TARGET
   THEN INSERT ([Id], [Priority],[Deleted])
     VALUES([S].[Id], [S].[Priority], [S].[Deleted]);
	 SET IDENTITY_INSERT [TaskManagementDB].[dbo].[TaskPriority] OFF; 
----------------------------------------------------------------
DECLARE @TaskStatus table
(
	[Id] int NOT NULL,
	[Status] nvarchar(50) NOT NULL,
	[Deleted] bit NOT NULL
	PRIMARY KEY CLUSTERED ([Id])
);
	
SET IDENTITY_INSERT [TaskManagementDB].[dbo].[TaskStatus] ON; 


INSERT INTO @TaskStatus ([Id], [Status],[Deleted]) -- must declare table
VALUES
 (1, N'Pending',0), 
 (2, N'In Progress',0),
 (3, N'Done',0),
 (4, N'Removed',0)

 DELETE [T]
FROM [TaskManagementDB].[dbo].[TaskStatus] AS [T]
 LEFT OUTER JOIN @TaskStatus AS [S]
  ON [S].[Id] = [T].[Id]
 WHERE [S].[Id] IS NULL;


MERGE INTO [TaskManagementDB].[dbo].[TaskStatus] AS [T]
USING @TaskStatus AS [S]
 ON [S].[Id] = [T].[Id]
 WHEN MATCHED 
   THEN UPDATE 
		SET [T].[Deleted] = 0    
  WHEN NOT MATCHED BY TARGET
   THEN INSERT ([Id], [Status],[Deleted])
     VALUES([S].[Id], [S].[Status], [S].[Deleted]);

 SET IDENTITY_INSERT [TaskManagementDB].[dbo].[TaskStatus] OFF; 

COMMIT TRANSACTION;
GO