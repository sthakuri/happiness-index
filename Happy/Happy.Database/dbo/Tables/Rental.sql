CREATE TABLE [dbo].[Rental]
(
	RentalID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	MonthlyRental INT NOT NULL,	

	CONSTRAINT FK_Rental_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID) ON DELETE CASCADE
)
GO