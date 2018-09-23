using Cognizant.Domain.Models;

namespace Cognizant.MVC.Models
{
    public class TransactionRequest
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}