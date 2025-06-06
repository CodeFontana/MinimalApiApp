﻿CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Created] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[Updated] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[UpdatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME()
)
