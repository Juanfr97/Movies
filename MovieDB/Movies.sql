CREATE TABLE [dbo].[Movies]
(
	[MovieId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[ISAN] NVARCHAR(50) NOT NULL , 
    [Name] NVARCHAR(MAX) NULL, 
    [Category] NVARCHAR(MAX) NULL, 
    [Year] INT NULL, 
    [Month] INT NULL CHECK([Month]<=12 AND [Month]>0),
    [Image] NVARCHAR(MAX) NULL, 
    [Duration] NVARCHAR(MAX) NULL, 
    [Summary] NVARCHAR(MAX) NULL
)
