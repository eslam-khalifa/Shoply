using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductBrandRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllAsync()
        {
            return await catalogContext.ProductBrands.Find(_ => true).ToListAsync();
        }
    }
}
