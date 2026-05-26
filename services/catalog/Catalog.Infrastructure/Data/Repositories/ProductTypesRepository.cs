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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductTypeRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await catalogContext.ProductTypes.Find(_ => true).ToListAsync();
        }
    }
}
