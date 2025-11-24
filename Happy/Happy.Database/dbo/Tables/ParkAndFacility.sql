CREATE TABLE [dbo].[ParkAndFacility]
(
	ParkAndFacilityID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	FacilityCount INT NOT NULL,	
	Score DECIMAL(2,1) NULL,

	CONSTRAINT FK_ParkAndFacility_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID) ON DELETE CASCADE
)
GO