-- Switch to the system (aka master) database
USE master;
GO

-- Delete the World Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='CustomerJobDB')
DROP DATABASE CustomerJobDB;
GO

-- Create a new World Database
CREATE DATABASE CustomerJobDB;
GO

-- Switch to the World Database
USE CustomerJobDB;
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION

-- Create a customer table to hold basic information
CREATE TABLE Customer (
    ID int IDENTITY(1,1),
    FirstName varchar(100) NOT NULL,
	LastName varchar (100) NOT NULL,
    Address varchar(64) NOT NULL,
	City varchar(64) NOT NULL,
    PhoneNumber varchar(64) NOT NULL
   
    
	
	CONSTRAINT pk_Customer_ID PRIMARY KEY (ID),
);


CREATE TABLE Job (
	ID int IDENTITY(1,1),
	JobTitle varchar(100) NOT NULL,
	JobDescription varchar(1000) NOT NULL,
	CustomerID int NOT NULL,
	Finished bit NOT NULL,
	DepositPayed bit NOT NULL,
	DateStarted DateTime NOT NULL,
	DateFinished DateTime,
	Worth decimal,

	CONSTRAINT pk_Job_ID PRIMARY KEY (ID),
	CONSTRAINT fk_Customer_Job  FOREIGN KEY (CustomerID) REFERENCES Customer(ID)
	);
-- Create a payment table to show how much each customer has spent with the company
--CREATE TABLE Payment(
--	ID int IDENTITY,
--	CustomerID int,
--	AmountSpent int,
	
	
--	CONSTRAINT pk_Payment_ID PRIMARY KEY (ID),
--	CONSTRAINT fk_Payment_CustomerID FOREIGN KEY (ID) REFERENCES Customer(ID)
--);

-- Insert a bunch of test data into the customer table
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Nick', 'Shellman', '1 testStreet Road', 'XXX-XXX-XXXX', 'Strongsville')
	DECLARE @NickID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Paul', 'Bronson', '2 testStreet Drive', 'XXX-XXX-XXXX', 'Strongsville')
	DECLARE @PaulID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Steve', 'Harris', '3 testStreet Ave', 'XXX-XXX-XXXX', 'Cleveland')
	DECLARE @SteveID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Rick', 'Harris', '4 testStreet Blvd', 'XXX-XXX-XXXX', 'Berea')
	DECLARE @RickID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Jack', 'Stevson', '5 testStreet Ln', 'XXX-XXX-XXXX', 'Cleveland')
	DECLARE @JackID int = (SELECT @@IDENTITY);

COMMIT TRANSACTION
GO

