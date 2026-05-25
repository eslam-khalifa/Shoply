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

    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IList<ProductTypeResponseDto>>
    {
        private readonly IProductTypeRepository productTypeRepository;

        public GetAllProductTypesQueryHandler(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }

        public async Task<IList<ProductTypeResponseDto>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            var productTypes = await productTypeRepository.GetAllAsync();
            return productTypes.Select(pt => pt.ToProductTypeResponseDto()).ToList();
        }
    }
}
