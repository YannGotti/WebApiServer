using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;
using Server.Persistance.EntityTypeConfigurations;

namespace Server.Persistance
{
    public class AccountsDbContext : DbContext, IAccountsDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
