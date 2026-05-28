using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{

    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(CatalogSpecParams spec)
        {
            var filter = Builders<Product>.Filter;
            var sort = Builders<Product>.Sort;

            if (!string.IsNullOrEmpty(spec.BrandId))
                AddFilter(filter.Eq(x => x.Brand.Id, spec.BrandId));

            if (!string.IsNullOrEmpty(spec.TypeId))
                AddFilter(filter.Eq(x => x.Type.Id, spec.TypeId));

            if (!string.IsNullOrEmpty(spec.Search))
            {
                AddFilter(filter.Text(spec.Search));
                ApplySort(sort.MetaTextScore("textScore"));
            }
            else
                ApplySort(spec.Sort switch
                {
                    "priceAsc" => sort.Ascending(x => x.Price),
                    "priceDesc" => sort.Descending(x => x.Price),
                    "nameAsc" => sort.Ascending(x => x.Name),
                    "nameDesc" => sort.Descending(x => x.Name),
                    _ => sort.Ascending(x => x.Name)
                });

            ApplyPaging(
                (spec.PageIndex - 1) * spec.PageSize,
                spec.PageSize
            );
        }
    }
}
