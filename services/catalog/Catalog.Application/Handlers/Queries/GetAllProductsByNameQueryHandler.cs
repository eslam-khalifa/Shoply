using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllProductsByNameQueryHandler : IRequestHandler<GetAllProductsByNameQuery, IList<ProductResponseDto>>
    {
        private readonly IProductRepository productRepository;

        public GetAllProductsByNameQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IList<ProductResponseDto>> Handle(GetAllProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllByNameAsync(request.Name);
            return products.Select(p => p.ToProductResponseDto()).ToList();
        }
    }
}
