using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJP.Application.DTOs;
using RJP.Application.Features.Customers.Commands;
using RJP.Application.Features.Transactions.Commands;
using RJP.Application.Features.Transactions.Queries;
using RJP.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllTransactionsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetTransactionsByIdQuery { Id = id }));
        }
        [HttpGet]
        [Route("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetByAccountId(int accountId)
        {
            return Ok(await _mediator.Send(new GetTransactionsByAccountIdQuery { AccountId = accountId }));
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody] TransactionDto transaction)
        {
            var command = new CreateTransactionCommand { TransacionDto = transaction};
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] TransactionDto transaction)
        {
            var command = new UpdateTransactionCommand { TransactionDto = transaction};
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTransactionByIdCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("account/{accountId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteByAccountId(int accountId)
        {
            var command = new DeleteTransactionsByAccountId { AccountId = accountId};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
