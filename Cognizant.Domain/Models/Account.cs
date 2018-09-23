using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cognizant.Domain.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccNumber { get; set; }
        public int AccAgency { get; set; }
        public double Balance { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}