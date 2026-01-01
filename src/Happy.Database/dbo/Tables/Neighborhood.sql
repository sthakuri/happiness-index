CREATE TABLE [dbo].[Neighborhood]
(
	NeighborhoodID INT IDENTITY(1,1) PRIMARY KEY,
	ZipCode VARCHAR(10) NOT NULL,
	NeighborhoodName NVARCHAR(50) NOT NULL,	

	CONSTRAINT UQ_NeighborhoodName_ZipCode UNIQUE (NeighborhoodName, ZipCode)
)
GO

-- Non-unique index on ZipCode for faster lookups
CREATE NONCLUSTERED INDEX [IX_Neighborhood_ZipCode]
	ON [dbo].[Neighborhood] ([ZipCode] ASC);
GO