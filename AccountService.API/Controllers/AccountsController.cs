
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJP.Application.Features.Accounts.Commands;
using RJP.Application.Features.Accounts.Queries;
using System.Threading.Tasks;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAccountsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAccountByIdQuery { Id = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountsByCustomerId(int customerId)
        {
            return Ok(await Mediator.Send(new GetAllAccountsByCustomerIdQuery { CustomerId = customerId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAccountCommand command)
        {
            if (id != command.AccountDto.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, DeleteAccountByIdCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
