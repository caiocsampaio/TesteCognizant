using System.Collections.Generic;
using Cognizant.Domain.Models;

namespace Cognizant.Repository.Contracts
{
    public interface IAccountRepository
    {
        List<Account> GetAccountsList();
        Account GetAccount(int id);
        Account GetAccount(int accNumber, int accAgency);
        Account CreateAccount(Account accountToCreate);
        int RemoveAccount(int accountId);
    }
}