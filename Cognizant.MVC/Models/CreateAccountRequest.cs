using Cognizant.Domain.Models;

namespace Cognizant.MVC.Models
{
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public int Agency { get; set; }
        public int Account { get; set; }
        public ClientType Type { get; set; }
    }
}