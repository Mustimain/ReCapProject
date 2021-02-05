CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColourId] INT NOT NULL, 
    [ModelYear] INT NOT NULL, 
    [DailyPrice] DECIMAL NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [ColourName] NVARCHAR(50) NOT NULL, 
    [BrandName] NVARCHAR(50) NOT NULL 
)
