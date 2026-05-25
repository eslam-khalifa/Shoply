using Catalog.Application.Commands;
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

        public static Product ToProduct(this CreateProductCommand createProductCommandtDto)
        {
            return new Product
            {
                Name = createProductCommandtDto.Name,
                Description = createProductCommandtDto.Description,
                Summary = createProductCommandtDto.Summary,
                ImageFile = createProductCommandtDto.ImageFile,
                Price = createProductCommandtDto.Price,
                Brand = createProductCommandtDto.Brand,
                Type = createProductCommandtDto.Type
            };
        }

        public static Product ToProduct(this UpdateProductCommand updateProductCommandtDto)
        {
            return new Product
            {
                Id = updateProductCommandtDto.Id,
                Name = updateProductCommandtDto.Name,
                Description = updateProductCommandtDto.Description,
                Summary = updateProductCommandtDto.Summary,
                ImageFile = updateProductCommandtDto.ImageFile,
                Price = updateProductCommandtDto.Price,
                Brand = updateProductCommandtDto.Brand,
                Type = updateProductCommandtDto.Type
            };
        }
    }
}
