using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartResponse))]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);
            var response = await mediator.Send(query);
            return Ok(response);
        }

        // in mediatr, send the command "the parameter" to the mediatr directly in case we accept a command
        [HttpPost]
        [Route("[action]", Name = "CreateOrUpdateBasket")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartResponse))]
        public async Task<ActionResult<ShoppingCartResponse>> CreateOrUpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {
            var response = await mediator.Send(createShoppingCartCommand);
            return Ok(response);
        }

        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteBasketByUserName(string userName)
        {
            var command = new DeleteBasketByUserNameCommand(userName);
            await mediator.Send(command);
            return Ok();
        }
    }
}
