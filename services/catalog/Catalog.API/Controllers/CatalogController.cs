using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
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
        public async Task<ActionResult<ProductResponseDto>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{productBrandName}", Name = "GetAllProductsByProductBrandName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductResponseDto>>> GetAllProductsByProductBrandName(string productBrandName)
        {
            var query = new GetAllProductsByBrandNameQuery(productBrandName);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{productName}", Name = "GetAllProductsByProductName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductResponseDto>>> GetAllProductsByProductName(string productName)
        {
            var query = new GetAllProductsByNameQuery(productName);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductResponseDto>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllProductBrands")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductBrand>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductBrand>>> GetAllProductBrands()
        {
            var query = new GetAllProductBrandsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllProductTypes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductType>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductType>>> GetAllProductTypes()
        {
            var query = new GetAllProductTypesQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]", Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await mediator.Send<ProductResponseDto>(createProductCommand);
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await mediator.Send<bool?>(updateProductCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{productId}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteProduct(string productId)
        {
            var command = new DeleteProductCommand(productId);
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
