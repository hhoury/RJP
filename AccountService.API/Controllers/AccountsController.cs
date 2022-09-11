
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJP.Application.DTOs;
using RJP.Application.Features.Accounts.Commands;
using RJP.Application.Features.Accounts.Queries;
using RJP.Application.Features.Customers.Commands;
using RJP.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllAccountsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetAccountByIdQuery { Id = id }));
        }

        [HttpGet]
        [Route("customer/{customerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetByCustomerId(int customerId)
        {
            return Ok(await _mediator.Send(new GetAllAccountsByCustomerIdQuery { CustomerId = customerId }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAccountDto account)
        {
            var command = new CreateAccountCommand { CreateAccountDto = account };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] AccountDto account)
        {
            var command = new UpdateAccountCommand { AccountDto = account };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteAccountByIdCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteByCustomerId(int customerId)
        {
            var command = new DeleteAccountsByCustomerIdCommand { CustomerId = customerId};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
