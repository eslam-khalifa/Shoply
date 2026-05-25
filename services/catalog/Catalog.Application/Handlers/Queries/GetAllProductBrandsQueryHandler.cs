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
    public class GetAllProductBrandsQueryHandler : IRequestHandler<GetAllProductBrandsQuery, IList<ProductBrandResponseDto>>
    {
        private readonly IProductBrandRepository productBrandRepository;

        public GetAllProductBrandsQueryHandler(IProductBrandRepository productBrandRepository)
        {
            this.productBrandRepository = productBrandRepository;
        }

        public async Task<IList<ProductBrandResponseDto>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
        {
            var productBrands = await productBrandRepository.GetAllAsync();
            return productBrands.Select(pb => pb.ToProductBrandResponseDto()).ToList();
        }
    }
}
