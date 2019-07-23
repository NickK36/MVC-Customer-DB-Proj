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
	('Nick', 'Konopka', '10138 Peachtree Drive', '440-212-0376', 'Strongsville')
	DECLARE @NickID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Paul', 'Konopka', '2135 Greenbriar Drive', '440-212-0376', 'Strongsville')
	DECLARE @PaulID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Steve', 'Silverson', '1236 State Road', '440-212-0376', 'Cleveland')
	DECLARE @SteveID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Rick', 'Johnson', '1234 Fair Road', '440-212-0376', 'Berea')
	DECLARE @RickID int = (SELECT @@IDENTITY);
INSERT INTO Customer (FirstName, LastName, Address, PhoneNumber, City)
	VALUES 
	('Jack', 'Obek', '2136 Broadview Road', '440-212-0376', 'Cleveland')
	DECLARE @JackID int = (SELECT @@IDENTITY);

	
-- Insert a bunch of test data into the payment table	
--INSERT INTO Payment (CustomerID, AmountSpent)
--	VALUES
--	(@NickID, 20000),
--	(@PaulID, 10000),
--	(@SteveID, 295000),
--	(@RickID, 2651),
--	(@JackID, 23000)


--ALTER TABLE Customer ADD CONSTRAINT fk_Customer_PaymentID
--	FOREIGN KEY (ID) REFERENCES Payment(ID)
-- Finish transaction
COMMIT TRANSACTION
GO

--DELETE FROM Customer WHERE name = '@name';
SELECT * FROM Customer;
SELECT * FROM Job;
--SELECT * FROM Payment
--USE master
--DROP DATABASE Jobs
DELETE FROM Job WHERE JobTitle = 'test'