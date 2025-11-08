CREATE TABLE [dbo].[Transportation]
(
	TransportationID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	MuniStops INT NOT NULL,	

	CONSTRAINT FK_Transportation_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID) ON DELETE CASCADE
)
GO