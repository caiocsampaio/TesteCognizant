using System.Collections.Generic;
using Cognizant.Domain.Models;
using Cognizant.MVC.Models;

namespace Cognizant.MVC.DAL
{
    public interface IIndexDAL
    {
        List<Account> GetAccountsList();
        Account CreateAccount(CreateAccountRequest request);
        Account NewTransaction(TransactionRequest request);
        int RemoveAccount(int accountId);
    }
}