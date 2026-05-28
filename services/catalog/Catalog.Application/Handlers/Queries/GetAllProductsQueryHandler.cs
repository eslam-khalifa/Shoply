using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResult<ProductResponseDto>>
    {
        private readonly IProductRepository productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<PagedResult<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync(request.Spec);
            return new PagedResult<ProductResponseDto>
            {
                PageIndex = products.PageIndex,
                PageSize = products.PageSize,
                TotalCount = products.TotalCount,
                Data = products.Data.Select(p => p.ToProductResponseDto()).ToList()
            };
        }
    }
}
