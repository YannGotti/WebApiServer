using Microsoft.EntityFrameworkCore;
using Server.Domain;

namespace Server.Application.Interfaces
{
    public interface IAccountsDbContext
    {
        DbSet<Account> Accounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
