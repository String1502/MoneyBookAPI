using MoneyBookAPI.Database;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Routing;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using MoneyBookAPI.DTOs;
using System.Data.Common;
using System;

namespace MoneyBookAPI.Controllers
{
    public class ServiceController : ApiController
    {
        #region Icons

        #region POST

        // GET api/ServiceController/CreateIcon
        [Route("api/ServiceController/CreateIcon")]
        [HttpPost]
        public IHttpActionResult CreateIcon(DTOs.Icon icon)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateIcon(icon.Name, icon.Code, icon.ImageUrl);
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllIcons
        [Route("api/ServiceController/GetAllIcons")]
        [HttpGet]
        public IHttpActionResult GetAllIcons()
        {
            IList<PROC_GetAllIcons_Result> icons = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    icons = context.PROC_GetAllIcons().ToList();
                }

                return Ok(icons);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetIconById
        [Route("api/ServiceController/GetIconById")]
        [HttpGet]
        public IHttpActionResult GetIconById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    var icon = context.PROC_GetIconById(id).FirstOrDefault();
                    return Ok(icon);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetIconByCode
        [Route("api/ServiceController/GetIconByCode")]
        [HttpGet]
        public IHttpActionResult GetIconByCodeGetIconByCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                    return BadRequest("Not a valid code");

                using (var context = new MoneyBookApiEntities())
                {
                    var icon = context.PROC_GetIconByCode(code).FirstOrDefault();
                    return Ok(icon);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateIcon
        [Route("api/ServiceController/UpdateIcon")]
        [HttpPut]
        public IHttpActionResult UpdateIcon(DTOs.Icon icon)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingIcon = ctx.PROC_GetIconById(icon.Id).FirstOrDefault();

                if (existingIcon is null)
                    return NotFound();

                ctx.PROC_UpdateIcon(icon.Id, icon.Name, icon.Code, icon.ImageUrl);
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteIcon
        [Route("api/ServiceController/DeleteIcon")]
        [HttpDelete]
        public IHttpActionResult DeleteIcon(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid icon id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteIcon(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Currencies

        #region POST

        // GET api/ServiceController/CreateCurrency
        [Route("api/ServiceController/CreateCurrency")]
        [HttpPost]
        public IHttpActionResult CreateCurrency(DTOs.Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateCurrency(currency.Name, currency.Code);
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllCurrencies
        [Route("api/ServiceController/GetAllCurrencies")]
        [HttpGet]
        public IHttpActionResult GetAllCurrencies()
        {
            IList<PROC_GetAllCurrencies_Result> currencies = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    currencies = context.PROC_GetAllCurrencies().ToList();
                }

                return Ok(currencies);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetCurrencyById
        [Route("api/ServiceController/GetCurrencyById")]
        [HttpGet]
        public IHttpActionResult GetCurrencyById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid currency id");

                using (var context = new MoneyBookApiEntities())
                {
                    var currency = context.PROC_GetCurrencyById(id).FirstOrDefault();
                    return Ok(currency);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetCurrencyByCode
        [Route("api/ServiceController/GetCurrencyByCode")]
        [HttpGet]
        public IHttpActionResult GetCurrencyByCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                    return BadRequest("Not a valid currency code");

                using (var context = new MoneyBookApiEntities())
                {
                    var currency = context.PROC_GetCurrencyByCode(code).FirstOrDefault();
                    return Ok(currency);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateCurrency
        [Route("api/ServiceController/UpdateCurrency")]
        [HttpPut]
        public IHttpActionResult UpdateCurrency(DTOs.Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingCurrency = ctx.PROC_GetCurrencyById(currency.Id).FirstOrDefault();

                if (existingCurrency is null)
                    return NotFound();

                ctx.PROC_UpdateCurrency(currency.Id, currency.Name, currency.Code);
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteCurrency
        [Route("api/ServiceController/DeleteCurrency")]
        [HttpDelete]
        public IHttpActionResult DeleteCurrency(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid currency id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteCurrency(id);
            }

            return Ok();
        }

        #endregion

        #endregion
        
        #region Accounts

        #region POST

        // GET api/ServiceController/CreateAccount
        [Route("api/ServiceController/CreateAccount")]
        [HttpPost]
        public IHttpActionResult CreateAccount(DTOs.Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateAccount(
                        account.Username,
                        account.Password,
                        account.Name,
                        account.Phone,
                        account.Email,
                        account.Birth);
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET


        // GET api/ServiceController/LoginAccountIn
        [Route("api/ServiceController/LoginAccountIn")]
        [HttpGet]
        public IHttpActionResult LoginAccountIn(string username, string password)
        {
            IList<PROC_LoginAccountIn_Result> accounts = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    accounts = context.PROC_LoginAccountIn(username, password).ToList();
                }

                return Ok(accounts);
            }
            catch
            {
                return NotFound();
            }
        }


        // GET api/ServiceController/GetAllAccounts
        [Route("api/ServiceController/GetAllAccounts")]
        [HttpGet]
        public IHttpActionResult GetAllAccounts()
        {
            IList<PROC_GetAllAccounts_Result> accounts = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    accounts = context.PROC_GetAllAccounts().ToList();
                }

                return Ok(accounts);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAccountById
        [Route("api/ServiceController/GetAccountById")]
        [HttpGet]
        public IHttpActionResult GetAccountById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    var account = context.PROC_GetAccountById(id).FirstOrDefault();
                    return Ok(account);
                }
            }
            catch
            {
                return NotFound();
            }
        }
        
        // GET api/ServiceController/GetAccountByUsername
        [Route("api/ServiceController/GetAccountByUsername")]
        [HttpGet]
        public IHttpActionResult GetAccountByUsername(string username)
        {
            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    var account = context.PROC_GetAccountByUsername(username).FirstOrDefault();
                    return Ok(account);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateAccount
        [Route("api/ServiceController/UpdateAccount")]
        [HttpPut]
        public IHttpActionResult UpdateAccount(DTOs.Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingAccount = ctx.PROC_GetAccountById(account.Id).FirstOrDefault();

                if (existingAccount is null)
                    return NotFound();

                ctx.PROC_UpdateAccount(
                        account.Id,
                        account.Password,
                        account.Name,
                        account.Phone,
                        account.Email,
                        account.Birth);
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteAccount
        [Route("api/ServiceController/DeleteAccount")]
        [HttpDelete]
        public IHttpActionResult DeleteAccount(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid account id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteAccount(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Wallets

        #region POST

        // GET api/ServiceController/CreateWallet
        [Route("api/ServiceController/CreateWallet")]
        [HttpPost]
        public IHttpActionResult CreateWallet(DTOs.Wallet wallet)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateWallet(
                        wallet.CurrencyId, 
                        wallet.AccountId,
                        wallet.IconId,
                        wallet.Name, 
                        wallet.Balance
                        );
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllWallets
        [Route("api/ServiceController/GetAllWallets")]
        [HttpGet]
        public IHttpActionResult GetAllWallets()
        {
            IList<PROC_GetAllWallets_Result> wallets = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    wallets = context.PROC_GetAllWallets().ToList();
                }

                return Ok(wallets);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetWalletById
        [Route("api/ServiceController/GetWalletById")]
        [HttpGet]
        public IHttpActionResult GetWalletById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    var wallet = context.PROC_GetWalletById(id).FirstOrDefault();
                    return Ok(wallet);
                }
            }
            catch
            {
                return NotFound();
            }
        }
        
        // GET api/ServiceController/GetWalletsByAccount
        [Route("api/ServiceController/GetWalletsByAccount")]
        [HttpGet]
        public IHttpActionResult GetWalletsByAccount(int accountId)
        {
            IList<PROC_GetWalletsByAccount_Result> wallets = null;

            try
            {
                if (accountId <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    wallets = context.PROC_GetWalletsByAccount(accountId).ToList();

                    return Ok(wallets);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateWallet
        [Route("api/ServiceController/UpdateWallet")]
        [HttpPut]
        public IHttpActionResult UpdateWallet(DTOs.Wallet wallet)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingWallet = ctx.PROC_GetWalletById(wallet.Id).FirstOrDefault();

                if (existingWallet is null)
                    return NotFound();

                ctx.PROC_UpdateWallet(
                        wallet.Id,
                        wallet.CurrencyId,
                        wallet.AccountId,
                        wallet.IconId,
                        wallet.Name,
                        wallet.Balance
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteWallet
        [Route("api/ServiceController/DeleteWallet")]
        [HttpDelete]
        public IHttpActionResult DeleteWallet(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid wallet id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteWallet(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region TransactionTypes

        #region POST

        // GET api/ServiceController/CreateTransactionType
        [Route("api/ServiceController/CreateTransactionType")]
        [HttpPost]
        public IHttpActionResult CreateTransactionType(DTOs.TransactionType transactionType)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateTransactionType(
                        transactionType.AccountId,
                        transactionType.IconId,
                        transactionType.Name,
                        transactionType.IsExpense ? 1 : 0,
                        transactionType.IsDefault ? 1 : 0,
                        transactionType.Tag
                        );
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllTransactionTypes
        [Route("api/ServiceController/GetAllTransactionTypes")]
        [HttpGet]
        public IHttpActionResult GetAllTransactionTypes()
        {
            IList<PROC_GetAllTransactionTypes_Result> transactionTypes = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    transactionTypes = context.PROC_GetAllTransactionTypes().ToList();
                }

                return Ok(transactionTypes);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetTransactionTypeById
        [Route("api/ServiceController/GetTransactionTypeById")]
        [HttpGet]
        public IHttpActionResult GetTransactionTypeById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    var type = context.PROC_GetTransactionTypeById(id).FirstOrDefault();
                    return Ok(type);
                }
            }
            catch
            {
                return NotFound();
            }
        }
        
        // GET api/ServiceController/GetTransactionTypesByAccount
        [Route("api/ServiceController/GetTransactionTypesByAccount")]
        [HttpGet]
        public IHttpActionResult GetTransactionTypesByAccount(int accountId)
        {
            try
            {
                IList<PROC_GetTransactionTypesByAccount_Result> transactionTypes = null;
                
                if (accountId <= 0)
                    return BadRequest("Not a valid account id");

                using (var context = new MoneyBookApiEntities())
                {
                    transactionTypes = context.PROC_GetTransactionTypesByAccount(accountId).ToList();

                }

                return Ok(transactionTypes);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetDefaultTransactionTypes
        [Route("api/ServiceController/GetDefaultTransactionTypes")]
        [HttpGet]
        public IHttpActionResult GetDefaultTransactionTypes()
        {
            try
            {
                IList<PROC_GetDefaultTransactionTypes_Result> transactionTypes = null;

                using (var context = new MoneyBookApiEntities())
                {
                    transactionTypes = context.PROC_GetDefaultTransactionTypes().ToList();

                }

                return Ok(transactionTypes);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetPersonalTransactionTypesByAccount
        [Route("api/ServiceController/GetPersonalTransactionTypesByAccount")]
        [HttpGet]
        public IHttpActionResult GetPersonalTransactionTypesByAccount(int accountId)
        {
            try
            {
                IList<PROC_GetPersonalTransactionTypesByAccount_Result> transactionTypes = null;

                if (accountId <= 0)
                    return BadRequest("Not a valid account id");

                using (var context = new MoneyBookApiEntities())
                {
                    transactionTypes = context.PROC_GetPersonalTransactionTypesByAccount(accountId).ToList();

                }

                return Ok(transactionTypes);
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateTransactionType
        [Route("api/ServiceController/UpdateTransactionType")]
        [HttpPut]
        public IHttpActionResult UpdateTransactionType(DTOs.TransactionType transactionType)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingType = ctx.PROC_GetTransactionTypeById(transactionType.Id).FirstOrDefault();

                if (existingType is null)
                    return NotFound();

                ctx.PROC_UpdateTransactionType(
                        transactionType.Id,
                        transactionType.IconId,
                        transactionType.Name,
                        transactionType.IsExpense ? 1 : 0
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteTransactionType
        [Route("api/ServiceController/DeleteTransactionType")]
        [HttpDelete]
        public IHttpActionResult DeleteTransactionType(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid transaction id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteTransactionTypes(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Acquaintances

        #region POST

        // GET api/ServiceController/CreateAcquaintance
        [Route("api/ServiceController/CreateAcquaintance")]
        [HttpPost]
        public IHttpActionResult CreateAcquaintance(DTOs.Acquaintance acquaintance)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateAcquaintance(
                        acquaintance.AccountId,
                        acquaintance.Name
                        );
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllAcquaintances
        [Route("api/ServiceController/GetAllAcquaintances")]
        [HttpGet]
        public IHttpActionResult GetAllAcquaintances()
        {
            IList<PROC_GetAllAcquaintances_Result> acquaintances = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    acquaintances = context.PROC_GetAllAcquaintances().ToList();
                }

                return Ok(acquaintances);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAcquaintanceById
        [Route("api/ServiceController/GetAcquaintanceById")]
        [HttpGet]
        public IHttpActionResult GetAcquaintanceById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid icon id");

                using (var context = new MoneyBookApiEntities())
                {
                    var acquaintances = context.PROC_GetAcquaintanceById(id).FirstOrDefault();
                    return Ok(acquaintances);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAcquaintancesByAccount
        [Route("api/ServiceController/GetAcquaintancesByAccount")]
        [HttpGet]
        public IHttpActionResult GetAcquaintancesByAccount(int accountId)
        {
            try
            {
                if (accountId <= 0)
                    return BadRequest("Not a valid icon id");

                IList<PROC_GetAcquaintancesByAccount_Result> acquaintances = null;

                using (var context = new MoneyBookApiEntities())
                {
                    acquaintances = context.PROC_GetAcquaintancesByAccount(accountId).ToList();
                }

                return Ok(acquaintances);
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateAcquaintance
        [Route("api/ServiceController/UpdateAcquaintance")]
        [HttpPut]
        public IHttpActionResult UpdateAcquaintance(DTOs.Acquaintance acquaintance)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingAcquaintance = ctx.PROC_GetAcquaintanceById(acquaintance.Id).FirstOrDefault();

                if (existingAcquaintance is null)
                    return NotFound();

                ctx.PROC_UpdateAcquaintance(
                        acquaintance.Id,
                        acquaintance.AccountId,
                        acquaintance.Name
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteAcquaintance
        [Route("api/ServiceController/DeleteAcquaintance")]
        [HttpDelete]
        public IHttpActionResult DeleteAcquaintance(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid acquaintance id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteAcquaintance(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Transactions

        #region POST

        // GET api/ServiceController/CreateTransaction
        [Route("api/ServiceController/CreateTransaction")]
        [HttpPost]
        public IHttpActionResult CreateTransaction(DTOs.Transaction transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new MoneyBookApiEntities())
            {
                var erTransaction = new Database.Transaction()
                {
                    Amount = transaction.Amount,
                    TypeId = transaction.TypeId,
                    EventId = transaction.EventId,
                    WalletId = transaction.WalletId,
                    Note = transaction.Note,
                    Date = transaction.Date,
                    Created = DateTime.Now,
                    IsDeleted = 0
                };

                ctx.Transactions.Add(erTransaction);

                ctx.SaveChanges();
                return Ok(erTransaction.EventId);
            }

        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllTransactions
        [Route("api/ServiceController/GetAllTransactions")]
        [HttpGet]
        public IHttpActionResult GetAllTransactions()
        {
            IList<PROC_GetAllTransactions_Result> transactions = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    transactions = context.PROC_GetAllTransactions().ToList();
                }

                return Ok(transactions);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAllTransactionsId
        [Route("api/ServiceController/GetAllTransactionsId")]
        [HttpGet]
        public IHttpActionResult GetAllTransactionsId()
        {
            IList<int?> transactions = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    transactions = context.PROC_GetAllTransactionsId().ToList();
                }

                return Ok(transactions);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetTransactionById
        [Route("api/ServiceController/GetTransactionById")]
        [HttpGet]
        public IHttpActionResult GetTransactionById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid transaction id");

                using (var context = new MoneyBookApiEntities())
                {
                    var transaction = context.PROC_GetTransactionById(id).FirstOrDefault();
                    return Ok(transaction);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetTransactionsByWallet
        [Route("api/ServiceController/GetTransactionsByWallet")]
        [HttpGet]
        public IHttpActionResult GetTransactionsByWallet(int walletId)
        {
            try
            {
                if (walletId <= 0)
                    return BadRequest("Not a valid account id");

                IList<PROC_GetTransactionsByWallet_Result> transactions = null;

                using (var context = new MoneyBookApiEntities())
                {
                    transactions = context.PROC_GetTransactionsByWallet(walletId).ToList();
                    return Ok(transactions);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetTransactionsIdByWallet
        [Route("api/ServiceController/GetTransactionsIdByWallet")]
        [HttpGet]
        public IHttpActionResult GetTransactionsIdByWallet(int walletId)
        {
            try
            {
                if (walletId <= 0)
                    return BadRequest("Not a valid account id");

                IList<int?> transactions = null;

                using (var context = new MoneyBookApiEntities())
                {
                    transactions = context.PROC_GetTransactionsIdByWallet(walletId).ToList();
                    return Ok(transactions);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateTransaction
        [Route("api/ServiceController/UpdateTransaction")]
        [HttpPut]
        public IHttpActionResult UpdateTransaction(DTOs.Transaction transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingTransaction = ctx.PROC_GetTransactionById(transaction.Id).FirstOrDefault();

                if (existingTransaction is null)
                    return NotFound();

                ctx.PROC_UpdateTransaction(
                        transaction.Id,
                        transaction.WalletId,
                        transaction.TypeId,
                        transaction.EventId,
                        transaction.Amount,
                        transaction.Note,
                        transaction.Date
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteTransaction
        [Route("api/ServiceController/DeleteTransaction")]
        [HttpDelete]
        public IHttpActionResult DeleteTransaction(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid transaction id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteTransaction(id);
            }

            return Ok();
        }

        // DELETE api/ServiceController/DeleteTransactionAll
        [Route("api/ServiceController/DeleteTransactionAll")]
        [HttpDelete]
        public IHttpActionResult DeleteTransactionAll(int walletId)
        {
            if (walletId <= 0)
                return BadRequest("Not a valid transaction id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteTransactionAll(walletId);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Events

        #region POST

        // GET api/ServiceController/CreateEvent
        [Route("api/ServiceController/CreateEvent")]
        [HttpPost]
        public IHttpActionResult CreateEvent(DTOs.Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateEvent(
                        @event.AccountId,
                        @event.IconId,
                        @event.Name,
                        @event.ExpiredDate
                        );
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllEvents
        [Route("api/ServiceController/GetAllEvents")]
        [HttpGet]
        public IHttpActionResult GetAllEvents()
        {
            IList<PROC_GetAllEvents_Result> events = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    events = context.PROC_GetAllEvents().ToList();
                }

                return Ok(events);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetEventById
        [Route("api/ServiceController/GetEventById")]
        [HttpGet]
        public IHttpActionResult GetEventById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid event id");

                using (var context = new MoneyBookApiEntities())
                {
                    var @event = context.PROC_GetEventById(id).FirstOrDefault();
                    return Ok(@event);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetEventsByAccount
        [Route("api/ServiceController/GetEventsByAccount")]
        [HttpGet]
        public IHttpActionResult GetEventsByAccount(int accountId)
        {
            try
            {
                if (accountId <= 0)
                    return BadRequest("Not a valid account id");

                IList<PROC_GetEventsByAccount_Result> events = null;

                using (var context = new MoneyBookApiEntities())
                {
                    events = context.PROC_GetEventsByAccount(accountId).ToList();
                    return Ok(events);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateEvent
        [Route("api/ServiceController/UpdateEvent")]
        [HttpPut]
        public IHttpActionResult UpdateEvent(DTOs.Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingEvent = ctx.PROC_GetEventById(@event.Id).FirstOrDefault();

                if (existingEvent is null)
                    return NotFound();

                ctx.PROC_UpdateEvent(
                        @event.Id,
                        @event.AccountId,
                        @event.IconId,
                        @event.Name,
                        @event.ExpiredDate
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteEvent
        [Route("api/ServiceController/DeleteEvent")]
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid event id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteEvent(id);
            }

            return Ok();
        }

        #endregion

        #endregion

        #region Acquaintance_Transaction

        #region POST

        // GET api/ServiceController/CreateAcquaintance_Transaction
        [Route("api/ServiceController/CreateAcquaintance_Transaction")]
        [HttpPost]
        public IHttpActionResult CreateAcquaintance_Transaction(
            DTOs.Acquaintance_Transaction acquaintance_transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    context.PROC_CreateAcquaintance_Transaction(
                            acquaintance_transaction.AcquaintanceId,
                            acquaintance_transaction.TransactionId
                        );
                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region GET

        // GET api/ServiceController/GetAllAcquaintance_TransactionId
        [Route("api/ServiceController/GetAllAcquaintance_TransactionId")]
        [HttpGet]
        public IHttpActionResult GetAllAcquaintance_TransactionId()
        {
            IList<int?> acquaintance_transaction = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    acquaintance_transaction = context.PROC_GetAllAcquaintance_TransactionId().ToList();
                }

                return Ok(acquaintance_transaction);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAllAcquaintance_Transaction
        [Route("api/ServiceController/GetAllAcquaintance_Transaction")]
        [HttpGet]
        public IHttpActionResult GetAllAcquaintance_Transaction()
        {
            IList<PROC_GetAllAcquaintance_Transaction_Result> acquaintance_transaction = null;

            try
            {
                using (var context = new MoneyBookApiEntities())
                {
                    acquaintance_transaction = context.PROC_GetAllAcquaintance_Transaction().ToList();
                }

                return Ok(acquaintance_transaction);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAcquaintance_TransactionById
        [Route("api/ServiceController/GetAcquaintance_TransactionById")]
        [HttpGet]
        public IHttpActionResult GetAcquaintance_TransactionById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid acquaintance_transaction id");

                using (var context = new MoneyBookApiEntities())
                {
                    var acquaintance_transaction = context.PROC_GetAcquaintanceById(id).FirstOrDefault();
                    return Ok(acquaintance_transaction);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAcquaintance_TransactionByTransaction
        [Route("api/ServiceController/GetAcquaintance_TransactionByTransaction")]
        [HttpGet]
        public IHttpActionResult GetAcquaintance_TransactionByTransaction(int transactionId)
        {
            try
            {
                if (transactionId <= 0)
                    return BadRequest("Not a valid transaction id");

                IList<PROC_GetAcquaintance_TransactionByTransactionId_Result> acquaintance_transaction_s = null;

                using (var context = new MoneyBookApiEntities())
                {
                    acquaintance_transaction_s = context
                        .PROC_GetAcquaintance_TransactionByTransactionId(transactionId).ToList();
                    return Ok(acquaintance_transaction_s);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetAcquaintance_TransactionIdByTransaction
        [Route("api/ServiceController/GetAcquaintance_TransactionIdByTransaction")]
        [HttpGet]
        public IHttpActionResult GetAcquaintance_TransactionIdByTransaction(int transactionId)
        {
            try
            {
                if (transactionId <= 0)
                    return BadRequest("Not a valid transaction id");

                IList<int?> acquaintance_transaction_s = null;

                using (var context = new MoneyBookApiEntities())
                {
                    acquaintance_transaction_s = context
                        .PROC_GetAcquaintance_TransactionIdByTransactionId(transactionId).ToList();
                    return Ok(acquaintance_transaction_s);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        #endregion

        #region PUT

        // PUT api/ServiceController/UpdateAcquaintance_Transaction
        [Route("api/ServiceController/UpdateAcquaintance_Transaction")]
        [HttpPut]
        public IHttpActionResult UpdateEvUpdateAcquaintance_Transactionent(DTOs.Acquaintance_Transaction acquaintance_transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MoneyBookApiEntities())
            {
                var existingAcquaintance_Transaction =
                    ctx.PROC_GetAcquaintance_TransactionById(acquaintance_transaction.Id).FirstOrDefault();

                if (existingAcquaintance_Transaction is null)
                    return NotFound();

                ctx.PROC_UpdateAcquaintance_Transaction(
                            acquaintance_transaction.Id,
                            acquaintance_transaction.AcquaintanceId,
                            acquaintance_transaction.TransactionId
                        );
            }

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE api/ServiceController/DeleteAcquaintance_Transaction
        [Route("api/ServiceController/DeleteAcquaintance_Transaction")]
        [HttpDelete]
        public IHttpActionResult DeleteAcquaintance_Transaction(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid deleteAcquaintance_Transaction id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteAcquaintance_Transaction(id);
            }

            return Ok();
        }

        // DELETE api/ServiceController/DeleteAcquaintance_TransactionAll
        [Route("api/ServiceController/DeleteAcquaintance_TransactionAll")]
        [HttpDelete]
        public IHttpActionResult DeleteAcquaintance_TransactionAll(int transactionId)
        {
            if (transactionId <= 0)
                return BadRequest("Not a valid deleteAcquaintance_Transaction id");

            using (var ctx = new MoneyBookApiEntities())
            {
                ctx.PROC_DeleteAcquaintance_Transaction_All(transactionId);
            }

            return Ok();
        }

        #endregion

        #endregion
    }
}
