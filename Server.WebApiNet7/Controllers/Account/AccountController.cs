using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Accounts.Queries.GetAccountList;
using Server.Application.Notes.Queries.GetNoteList;
using Server.Application.User.Commands.CreateAccount;
using Server.Application.User.Queries.GetAccountDetails;
using Server.WebApiNet7.Models;

namespace Server.WebApiNet7.Controllers.Account
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        public async Task<ActionResult<AccountListVm>> GetAllAccounts()
        {
            var query = new GetAccountListQuery
            {
                Id = AccountId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetailsVm>> GetAccounts(Guid id)
        {
            var query = new GetAccountDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            var command = _mapper.Map<CreateAccountCommand>(createAccountDto);
            command.Id = AccountId;
            var accountId = await Mediator.Send(command);
            return CreatedAtAction(nameof(accountId), new { id = AccountId }, accountId);
        }
    }
}
