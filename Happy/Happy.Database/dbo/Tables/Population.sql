CREATE TABLE [dbo].[Population]
(
	PopulationID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	PopulationCount INT NOT NULL,	

	CONSTRAINT FK_Population_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID)
)
GO