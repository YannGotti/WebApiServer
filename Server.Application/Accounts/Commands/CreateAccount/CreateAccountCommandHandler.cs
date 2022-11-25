using MediatR;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.User.Commands.CreateAccount
{
    public class CreateAccountCommandHandler
        : IRequestHandler<CreateAccountCommand, Guid>
    {

        private readonly IAccountsDbContext _dbContext;

        public CreateAccountCommandHandler(IAccountsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var user = new Account
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now
            };

            await _dbContext.Accounts.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

    }
}
