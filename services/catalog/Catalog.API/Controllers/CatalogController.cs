using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class CatalogController : BaseApiController
    {
        private readonly IMediator mediator;

        public CatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{Id}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(string Id)
        {
            var query = new GetProductByIdQuery(Id);
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
