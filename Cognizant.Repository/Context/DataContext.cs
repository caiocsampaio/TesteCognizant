using Cognizant.Domain.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Cognizant.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}