CREATE TABLE [dbo].[Population]
(
	PopulationID INT IDENTITY(1,1) PRIMARY KEY,
	ZipCode VARCHAR(10) NOT NULL,
	PopulationCount INT NOT NULL,	

	CONSTRAINT UQ_PopulationCount_ZipCode UNIQUE (PopulationCount, ZipCode)
)
GO

-- Non-unique index on ZipCode for faster lookups
CREATE NONCLUSTERED INDEX [IX_Population_ZipCode]
	ON [dbo].[Population] ([ZipCode] ASC);
GO