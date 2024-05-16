-- Create the database
CREATE DATABASE GestionVoyage;
GO

-- Use the database
USE GestionVoyage;
GO

-- Create Arrivals table
CREATE TABLE Arrivees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomNavire NVARCHAR(100) NOT NULL,
    DateHeureArrivee DATETIME NOT NULL,
    PortOrigine NVARCHAR(100) NOT NULL,
    Terminal NVARCHAR(100) NOT NULL, 
	TypeCargaison NVARCHAR(100)
);
GO

-- Create Departures table
CREATE TABLE Departs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomNavire NVARCHAR(100) NOT NULL,
    DateHeureDepart DATETIME NOT NULL,
    PortDestination NVARCHAR(100) NOT NULL,
    Quai NVARCHAR(100) NOT NULL, 
	TypeCargaison NVARCHAR(100)
);
GO
