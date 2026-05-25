using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class ProductMappers
    {
        public static ProductResponseDto ToProductResponseDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Summary = product.Summary,
                ImageFile = product.ImageFile,
                Price = product.Price,
                Brand = product.Brand,
                Type = product.Type
            };
        }
    }
}
