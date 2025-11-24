CREATE TABLE [dbo].[Crime]
(
	CrimeID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	IncidentCount INT NOT NULL,	
	Score DECIMAL(2,1) NULL,

	CONSTRAINT FK_Crime_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID) ON DELETE CASCADE
)
GO