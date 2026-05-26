using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class ProductTypesMappers
    {
        public static ProductTypeResponseDto? ToProductTypeResponseDto(this ProductType productType)
        {
            if (productType is null)
                return null;

            return new ProductTypeResponseDto
            {
                Id = productType.Id,
                Name = productType.Name
            };
        }
    }
}
