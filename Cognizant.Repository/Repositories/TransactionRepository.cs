using System.Collections.Generic;
using System.Linq;
using Cognizant.Domain.Models;
using Cognizant.Repository.Context;
using Cognizant.Repository.Contracts;

namespace Cognizant.Repository.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public Account NewTransaction(Transaction transaction)
        {
            Account account = _context.Accounts.FirstOrDefault(x => x.Id == transaction.AccountId);

            double amount = transaction.Amount;
            double balance = account.Balance;

            account.Balance = transaction.Type == TransactionType.Debit ? balance + amount : balance - amount;

            _context.Accounts.Update(account);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return account;
        }
    }
}