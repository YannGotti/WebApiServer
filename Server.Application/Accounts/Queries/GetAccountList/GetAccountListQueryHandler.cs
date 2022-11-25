using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQueryHandler
        : IRequestHandler<GetAccountListQuery, AccountListVm>
    {
        private readonly IAccountsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAccountListQueryHandler(IAccountsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AccountListVm> Handle(GetAccountListQuery request,
            CancellationToken cancellationToken)
        {
            var accountsQuery = await _dbContext.Accounts
                .Where(account => account.Id == request.Id)
                .ProjectTo<AccountLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AccountListVm { Accounts = accountsQuery };
        }
    }
}
