CREATE TABLE [dbo].[Income]
(
	IncomeID INT IDENTITY(1,1) PRIMARY KEY,
	NeighborhoodID INT NOT NULL,
	MedianIncome INT NOT NULL,	

	CONSTRAINT FK_Income_NeighborhoodID FOREIGN KEY (NeighborhoodID) REFERENCES dbo.Neighborhood(NeighborhoodID) ON DELETE CASCADE
)
GO