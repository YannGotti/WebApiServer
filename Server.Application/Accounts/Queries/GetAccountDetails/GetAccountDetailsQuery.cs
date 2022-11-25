using MediatR;

namespace Server.Application.User.Queries.GetAccountDetails
{
    public class GetAccountDetailsQuery : IRequest<AccountDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
