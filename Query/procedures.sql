USE MONEY_BOOK_API
GO

-- ICONS

CREATE PROCEDURE PROC_CreateIcon
	@name NVARCHAR(255),
	@code VARCHAR(32),
	@imageUrl VARCHAR(128)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Icons(Name, Code, ImageUrl) VALUES
		(@name, @code, @imageUrl)
END
GO

CREATE PROCEDURE PROC_GetAllIcons
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Icons
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetIconById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Icons
	WHERE Id=@id AND IsDeleted=0
END
GO


CREATE PROCEDURE PROC_GetIconByCode
	-- Add the parameters for the stored procedure here
	@code VARCHAR(32)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Icons
	WHERE Code=@code AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateIcon
	@id INT,
	@name NVARCHAR(255),
	@code VARCHAR(32),
	@imageUrl VARCHAR(128)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Icons
   SET
		Name=@name,
		Code=@code,
		ImageUrl=@imageUrl
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteIcon
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE ICONS
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- CURRENCY

CREATE PROCEDURE PROC_CreateCurrency
	@name NVARCHAR(255),
	@code VARCHAR(32)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Currencies(Name, Code) VALUES
		(@name, @code)
END
GO

CREATE PROCEDURE PROC_GetAllCurrencies
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Currencies
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetCurrencyById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Currencies
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetCurrencyByCode
	-- Add the parameters for the stored procedure here
	@code VARCHAR(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Currencies
	WHERE Code=@code AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateCurrency
	@id INT,
	@name NVARCHAR(255),
	@code VARCHAR(32)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Currencies
   SET
		Name=@name,
		Code=@code
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteCurrency
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Currencies
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- ACCOUNTS

CREATE PROCEDURE PROC_CreateAccount
	@username  VARCHAR(255),
	@password VARCHAR(255),
	@name NVARCHAR(255),
	@phone VARCHAR(32),
	@email VARCHAR(255),
	@birth DATE
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Accounts(Username, Password, Name, Phone, Email, Birth) VALUES
		(@username, @password, @name, @phone, @email, @birth)
END
GO

CREATE PROCEDURE PROC_LoginAccountIn
	@username VARCHAR(255), @password VARCHAR(255)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Accounts
   WHERE Username=@username AND Password=@password
END
GO

CREATE PROCEDURE PROC_GetAllAccounts
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Accounts
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAccountById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Accounts
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAccountByUsername
	-- Add the parameters for the stored procedure here
	@username VARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Accounts
	WHERE Username=@username AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateAccount
	@id INT,
	@password VARCHAR(255),
	@name NVARCHAR(255),
	@phone VARCHAR(32),
	@email VARCHAR(255),
	@birth DATE
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Accounts
   SET
		Password=@password,
		Name=@name,
		Phone=@phone,
		Email=@email,
		Birth=@birth
END
GO

CREATE PROCEDURE PROC_DeleteAccount
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Accounts
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- WALLETS

CREATE PROCEDURE PROC_CreateWallet
	@currencyId INT,
	@accountId INT,
	@iconId INT,
	@name NVARCHAR(255),
	@balance INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Wallets(CurrencyId, AccountId, IconId, Name, Balance) VALUES
		(@currencyId,
		 @accountId,
		 @iconId ,
		 @name,
		 @balance)
END		 
GO

CREATE PROCEDURE PROC_GetAllWallets
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Wallets
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetWalletById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Wallets
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetWalletsByAccount
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Wallets
	WHERE AccountId=@id AND IsDeleted=0

END
GO

CREATE PROCEDURE PROC_UpdateWallet
	@id INT,
	@currencyId INT,
	@accountId INT,
	@iconId INT,
	@name NVARCHAR(255),
	@balance INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Wallets
   SET
		CurrencyId=@currencyId,
		AccountId=@accountId,
		IconId=@iconId,
		Name=@name,
		Balance=@balance
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteWallet
	@walletId INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE Wallets
	SET IsDeleted=1
	WHERE Id=@walletId
END
GO

-- TRANSACTION TYPES

CREATE PROCEDURE PROC_CreateTransactionType
	@accountId INT,
	@iconId INT,
	@name NVARCHAR(255),
	@isExpense INT,
	@isDefault INT,
	@tag NVARCHAR(255)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO TransactionTypes(AccountId, IconId, Name, IsExpense, IsDefault, Tag) VALUES
		(@accountId, @iconid, @name, @isExpense, @isDefault, @tag)
END		 
GO

CREATE PROCEDURE PROC_GetAllTransactionTypes
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM TransactionTypes
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetTransactionTypeById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM TransactionTypes
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetTransactionTypesByAccount
	-- Add the parameters for the stored procedure here
	@accountId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM TransactionTypes
	WHERE AccountId=@accountId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetPersonalTransactionTypesByAccount
	-- Add the parameters for the stored procedure here
	@accountId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM TransactionTypes
	WHERE AccountId=@accountId AND IsDefault=0
END
GO

CREATE PROCEDURE PROC_GetDefaultTransactionTypes
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM TransactionTypes
	WHERE IsDefault=1 AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateTransactionType
	@id INT,
	@iconId INT,
	@name NVARCHAR(255),
	@isExpense INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE TransactionTypes
   SET
		IconId=@iconId,
		Name=@name,
		IsExpense=@isExpense
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteTransactionTypes
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE TransactionTypes
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- Acquaintance

CREATE PROCEDURE PROC_CreateAcquaintance
	@accountId INT,
	@name NVARCHAR(255)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Acquaintances(AccountId, Name) VALUES
		(@accountId, @name)
END		 
GO

CREATE PROCEDURE PROC_GetAllAcquaintances
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Acquaintances
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAcquaintanceById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Acquaintances
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAcquaintancesByAccount
	-- Add the parameters for the stored procedure here
	@accountId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Acquaintances
	WHERE AccountId=@accountId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateAcquaintance
	@id INT,
	@accountId INT,
	@name NVARCHAR(255)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Acquaintances
   SET
		AccountId=@accountId,
		Name=@name
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteAcquaintance
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Acquaintances
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- TRANSACTIONS

CREATE PROCEDURE PROC_CreateTransaction
	@walletId INT,
	@typeId INT,
	@eventId INT,
	@amount INT,
	@note NVARCHAR(2048),
	@date Date
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Transactions(
		WalletId,
		TypeId,
		EventId,
		Amount,
		Note,
		Date 
   )
   VALUES
		(@walletId, @typeId, @eventId, @amount, @note, @date)
END		 
GO

CREATE PROCEDURE PROC_GetAllTransactions
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Transactions
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAllTransactionsId
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT Id
   FROM Transactions
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetTransactionById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Transactions
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetTransactionsByWallet
	-- Add the parameters for the stored procedure here
	@walletId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Transactions
	WHERE WalletId=@walletId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetTransactionsIdByWallet
	-- Add the parameters for the stored procedure here
	@walletId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id
	FROM Transactions
	WHERE WalletId=@walletId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateTransaction
	@id INT,
	@walletId INT,
	@typeId INT,
	@eventId INT,
	@amount INT,
	@note NVARCHAR(2048),
	@date Date
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Transactions
   SET
		WalletId=@walletId,
		TypeId=@typeId,
		EventId=@eventId,
		Amount=@amount,
		Note=@note,
		Date=@date
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteTransaction
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Transactions
	SET IsDeleted=1
	WHERE Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteTransactionAll
	@walletId INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Transactions
	SET IsDeleted=1
	WHERE WalletId=@walletId
END
GO

-- EVENTS

CREATE PROCEDURE PROC_CreateEvent
	@accountId INT,
	@iconId INT,
	@name NVARCHAR(255),
	@expiredDate Date
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Events(
		AccountId,
		IconId,
		Name,
		ExpiredDate
   )
   VALUES
		(@accountId,
		 @iconId,
		 @name,
		 @expiredDate)
END		 
GO

CREATE PROCEDURE PROC_GetAllEvents
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Events
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetEventById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Events
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetEventsByAccount
	-- Add the parameters for the stored procedure here
	@accountId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Events
	WHERE AccountId=@accountId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateEvent
	@id INT,
	@accountId INT,
	@iconId INT,
	@name NVARCHAR(255),
	@expiredDate Date
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Events
   SET
		AccountId=@accountId,
		IconId=@iconId,
		Name=@name,
		ExpiredDate=@expiredDate
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_UpdateEventStatus
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Events
   SET
		IsActive=1
	WHERE
		ExpiredDate >= GETDATE()

   UPDATE Events
   SET
		IsActive=0
	WHERE
		ExpiredDate < GETDATE()
END
GO

EXEC PROC_UpdateEventStatus

select * from accounts

CREATE PROCEDURE PROC_DeleteEvent
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Events
	SET IsDeleted=1
	WHERE Id=@id
END
GO

-- ACQUAINTANCE_TRANSACTION

CREATE PROCEDURE PROC_CreateAcquaintance_Transaction
	@acquaintanceId INT,
	@transactionId INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   INSERT INTO Acquaintance_Transaction(
		AcquaintanceId,
		TransactionId
   )
   VALUES (@acquaintanceId, @transactionId)
END		 
GO

CREATE PROCEDURE PROC_GetAllAcquaintance_Transaction
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT *
   FROM Acquaintance_Transaction
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAllAcquaintance_TransactionId
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   SELECT 
   FROM Acquaintance_Transaction
   WHERE IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAcquaintance_TransactionById
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Acquaintance_Transaction
	WHERE Id=@id AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAcquaintance_TransactionByTransactionId
	-- Add the parameters for the stored procedure here
	@transactionId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Acquaintance_Transaction
	WHERE TransactionId=@transactionId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_GetAcquaintance_TransactionIdByTransactionId
	-- Add the parameters for the stored procedure here
	@transactionId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id
	FROM Acquaintance_Transaction
	WHERE TransactionId=@transactionId AND IsDeleted=0
END
GO

CREATE PROCEDURE PROC_UpdateAcquaintance_Transaction
	@id INT,
	@acquaintanceId INT,
	@transactionId INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
   UPDATE Acquaintance_Transaction
   SET
		AcquaintanceId=@acquaintanceId,
		TransactionId=@transactionId
	WHERE
		Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteAcquaintance_Transaction
	@id INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Acquaintance_Transaction
	SET IsDeleted=1
	WHERE Id=@id
END
GO

CREATE PROCEDURE PROC_DeleteAcquaintance_Transaction_All
	@transactionId INT
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
 
    -- Insert statements for procedure here
	UPDATE Acquaintance_Transaction
	SET IsDeleted=1
	WHERE TransactionId=@transactionId
END
GO



