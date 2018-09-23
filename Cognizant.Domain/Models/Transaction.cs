using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cognizant.Domain.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
    }

    public enum TransactionType 
    {
        Debit = 1,
        Withdraw = 2
    }
}