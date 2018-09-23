using System.Collections.Generic;
using System.Linq;
using Cognizant.Domain.Models;
using Cognizant.Repository.Contracts;
using Cognizant.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Cognizant.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public Account CreateAccount(Account acc)
        {
            _context.Accounts.Add(acc);
            _context.SaveChanges();
            return acc;
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account GetAccount(int accNumber, int accAgency)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccNumber == accNumber && x.AccAgency == accAgency);
        }

        public List<Account> GetAccountsList()
        {
            return _context.Accounts.Include(x => x.Client).ToList();
        }

        public int RemoveAccount(int accountId)
        {
            Account account = _context.Accounts.FirstOrDefault(x => x.Id == accountId);
            _context.Remove(account);
            return _context.SaveChanges();
        }
    }
}