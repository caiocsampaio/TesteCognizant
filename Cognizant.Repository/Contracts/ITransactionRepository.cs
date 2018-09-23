using System.Collections.Generic;
using Cognizant.Domain.Models;

namespace Cognizant.Repository.Contracts
{
    public interface ITransactionRepository
    {
        Account NewTransaction(Transaction transaction);
    }
}