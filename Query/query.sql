CREATE DATABASE MONEY_BOOK_API
GO

USE MONEY_BOOK_API
GO

-- Creating tables

CREATE TABLE Icons (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(255),
	Code VARCHAR(32),
	ImageUrl VARCHAR(128),
	Created DATETIME2(3) 
		CONSTRAINT DF_Icons_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Currencies (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(255),
	Code VARCHAR(16),
	Created DATETIME2(3) 
		CONSTRAINT DF_Currencies_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Accounts (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Username  VARCHAR(255),
	Password VARCHAR(255),
	Name NVARCHAR(255) NULL,
	Phone VARCHAR(16) NULL,
	Email VARCHAR(255) NULL,
	Birth DATE NULL,
	Created DATETIME2(3) 
		CONSTRAINT DF_Accounts_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Wallets (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CurrencyId INT,
	AccountId INT,
	IconId INT,
	Name NVARCHAR(255),
	Balance INT,
	Created DATETIME2(3) 
		CONSTRAINT DF_Wallets_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE TransactionTypes (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AccountId INT,
	IconId INT,
	Name NVARCHAR(255),
	IsExpense INT,
	IsDefault INT,
	Tag NVARCHAR(128),
	Created DATETIME2(3) 
		CONSTRAINT DF_TransactionTypes_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Acquaintances (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AccountId INT,
	Name NVARCHAR(255),
	Created DATETIME2(3) 
		CONSTRAINT DF_Acquaintances_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Transactions (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	WalletId INT,
	TypeId INT,
	EventId INT NULL,
	Amount INT,
	Note NVARCHAR(2048),
	Date Date,
	Created DATETIME2(3) 
		CONSTRAINT DF_Transactions_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

--alter table transactions drop column IconId
--alter table transactions drop constraint FK_Transactions_Icon

CREATE TABLE Events (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AccountId INT,
	IconId INT,
	Name NVARCHAR(255),
	ExpiredDate Date,
	IsActive BIT DEFAULT 1,
	Created DATETIME2(3) 
		CONSTRAINT DF_Events_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

CREATE TABLE Acquaintance_Transaction (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AcquaintanceId INT,
	TransactionId INT,
	Created DATETIME2(3) 
		CONSTRAINT DF_Acquaintance_Transaction_Created DEFAULT (SYSDATETIME()),
	Modified DATETIME2(3),
	IsDeleted INT DEFAULT 0
)
GO

-- Adding constraints

-- ICONS

ALTER TABLE Icons
ADD CONSTRAINT UNIQUE_Icons_Code UNIQUE (Code)
GO

-- CURRENCIES

ALTER TABLE Currencies
ADD CONSTRAINT UNIQUE_Currencies_Code
UNIQUE (Code)
GO

-- ACCOUNTS
-- UNIQUE

ALTER TABLE Accounts
ADD CONSTRAINT UNIQUE_Accounts_Username
UNIQUE (Username)
GO

-- WALLETS
-- FOREIGN KEYS

ALTER TABLE Wallets
ADD CONSTRAINT FK_Wallets_Currency
FOREIGN KEY (CurrencyId) REFERENCES Currencies(Id)
GO

ALTER TABLE Wallets
ADD CONSTRAINT FK_Wallets_Account
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
GO

ALTER TABLE Wallets
ADD CONSTRAINT FK_Wallets_Icon
FOREIGN KEY (IconId) REFERENCES Icons(Id)
GO

-- TRANSACTIONTYPES
-- FOREIGN KEYS

ALTER TABLE TransactionTypes
ADD CONSTRAINT FK_TransactionTypes_Icon
FOREIGN KEY (IconId) REFERENCES Icons(Id)
GO

ALTER TABLE TransactionTypes
ADD CONSTRAINT FK_TransactionTypes_Account
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
GO

-- ACQUAINTANCES
-- FOREIGN KEYS

ALTER TABLE Acquaintances
ADD CONSTRAINT FK_Acquaintances_Account
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
GO

-- TRANSACTIONS
-- FOREIGN KEYS

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Wallet
FOREIGN KEY (WalletId) REFERENCES Wallets(Id)
GO

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Type
FOREIGN KEY (TypeId) REFERENCES TransactionTypes(Id)
GO

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Event
FOREIGN KEY (EventId) REFERENCES Events(Id)
GO

--ALTER TABLE Transactions
--ADD CONSTRAINT FK_Transactions_Icon
--FOREIGN KEY (IconId) REFERENCES Icons(Id)
--GO

-- EVENTS
-- FOREIGN KEYS

ALTER TABLE Events
ADD CONSTRAINT FK_Events_Account
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
GO

ALTER TABLE Events
ADD CONSTRAINT FK_Events_Icon
FOREIGN KEY (IconId) REFERENCES Icons(Id)
GO

-- ACQUAINTANCE_TRANSACTION
-- FOREIGN KEYS

ALTER TABLE Acquaintance_Transaction
ADD CONSTRAINT FK_Acquaintance_Transaction_Acquaintance
FOREIGN KEY (AcquaintanceId) REFERENCES Acquaintances(Id)
GO

ALTER TABLE Acquaintance_Transaction
ADD CONSTRAINT FK_Acquaintance_Transaction_Transaction
FOREIGN KEY (TransactionId) REFERENCES Transactions(Id)
GO

-- TRIGGERS
CREATE TRIGGER TRG_UpdateModified_Icons
ON Icons
AFTER UPDATE 
AS
   UPDATE Icons
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Icons.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Currencies
ON Currencies
AFTER UPDATE 
AS
   UPDATE Currencies
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Currencies.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Accounts
ON Accounts
AFTER UPDATE 
AS
   UPDATE Accounts
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Accounts.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Wallets
ON Wallets
AFTER UPDATE 
AS
   UPDATE Wallets
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Wallets.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_TransactionTypes
ON TransactionTypes
AFTER UPDATE 
AS
   UPDATE TransactionTypes
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE TransactionTypes.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Acquaintances
ON Acquaintances
AFTER UPDATE 
AS
   UPDATE Acquaintances
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Acquaintances.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Transactions
ON Transactions
AFTER UPDATE 
AS
   UPDATE Transactions
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Transactions.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Events
ON Events
AFTER UPDATE 
AS
   UPDATE Events
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Events.Id= i.Id
GO

CREATE TRIGGER TRG_UpdateModified_Acquaintance_Transaction
ON Acquaintance_Transaction
AFTER UPDATE 
AS
   UPDATE Acquaintance_Transaction
   SET Modified = SYSDATETIME()
   FROM Inserted i
   WHERE Acquaintance_Transaction.Id= i.Id
GO

ALTER TRIGGER TRG_UpdateWalletBalance
ON Transactions
AFTER UPDATE, INSERT
AS
   DECLARE @positive INT = 0, @negative INT = 0, @walletId INT

   SELECT @walletId=WalletId
   FROM inserted

   SELECT @positive=ISNULL(SUM(Amount), 0)
   FROM Transactions, TransactionTypes
   WHERE WalletId=@walletId AND
		 Transactions.IsDeleted=0 AND 
		 Transactions.TypeId=TransactionTypes.Id AND
		 IsExpense=0
		 
   SELECT @negative=ISNULL(SUM(Amount), 0)
   FROM Transactions, TransactionTypes
   WHERE WalletId=@walletId AND 
		 Transactions.IsDeleted=0 AND 
		 transactions.TypeId=TransactionTypes.Id AND
		 IsExpense=1

	PRINT(@positive)
	PRINT(@negative)

	UPDATE Wallets
	SET Balance=@positive-@negative
	WHERE Id=@walletId
GO
