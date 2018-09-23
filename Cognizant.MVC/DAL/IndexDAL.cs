using System.Collections.Generic;
using Cognizant.Domain.Models;
using Cognizant.MVC.Models;
using Cognizant.Repository.Contracts;

namespace Cognizant.MVC.DAL
{
    public class IndexDAL : IIndexDAL
    {
        private readonly IAccountRepository _acc;
        private readonly ITransactionRepository _trans;

        public IndexDAL(IAccountRepository acc, ITransactionRepository trans)
        {
            _acc = acc;
            _trans = trans;
        }

        public List<Account> GetAccountsList()
        {
            return _acc.GetAccountsList();
        }

        public Account CreateAccount(CreateAccountRequest request)
        {
            Account account = new Account{
                AccAgency = request.Agency,
                AccNumber = request.Account,
                Balance = 0,
                Client = new Client{
                    Name = request.Name,
                    Type = request.Type
                },
            };

            _acc.CreateAccount(account);

            return account;
        }

        public Account NewTransaction(TransactionRequest request)
        {
            Transaction transaction = new Transaction {
                AccountId = request.AccountId,
                Amount = request.Amount,
                Type = request.Type
            };

            Account balance = _trans.NewTransaction(transaction);

            return balance;
        }

        public int RemoveAccount(int accountId)
        {
            int success = _acc.RemoveAccount(accountId);

            return success;
        }
    }
}