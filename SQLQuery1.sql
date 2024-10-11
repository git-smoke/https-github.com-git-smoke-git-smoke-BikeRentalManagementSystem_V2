CREATE DATABASE BikeRentalManagement ;
GO

USE BikeRentalManagement;
GO

CREATE TABLE Bikes(
	BikeId NVARCHAR(50) PRIMARY KEY,
	Brand NVARCHAR(100),
	Model NVARCHAR(100),
	RentalPrice DECIMAL(10,2)
);
GO

INSERT INTO Bikes(BikeId, Brand, Model, RentalPrice) VALUES
('BIKE_001','Honda','CB-Shine',5.00);
GO

SELECT  * FROM Bikes;
GO