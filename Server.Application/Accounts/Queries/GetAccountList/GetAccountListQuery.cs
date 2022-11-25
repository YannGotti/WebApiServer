using MediatR;

namespace Server.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQuery : IRequest<AccountListVm>
    {
        public Guid Id { get; set; }
    }
}
