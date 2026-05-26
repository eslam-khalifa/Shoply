using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class ProductBrandMappers
    {
        public static ProductBrandResponseDto? ToProductBrandResponseDto(this ProductBrand productBrand)
        {
            if (productBrand is null)
                return null;

            return new ProductBrandResponseDto
            {
                Id = productBrand.Id,
                Name = productBrand.Name
            };
        }
    }
}
