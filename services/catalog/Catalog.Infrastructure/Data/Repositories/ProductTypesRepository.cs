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
    internal class ProductTypesRepository : IProductTypeRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductTypesRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await catalogContext.ProductTypes.Find(_ => true).ToListAsync();
        }
    }
}
