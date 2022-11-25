using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exeptions;
using Server.Application.Interfaces;
using Server.Application.Notes.Queries.GetNoteDetails;
using Server.Domain;

namespace Server.Application.User.Queries.GetAccountDetails
{
    public class GetAccountDetailsQueryHandler
        : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
    {
        private readonly IAccountsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAccountDetailsQueryHandler(IAccountsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request,
            CancellationToken cancellationToken)
        {

            var entity = await _dbContext.Accounts
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }

            return _mapper.Map<AccountDetailsVm>(entity);
        }

    }
}
