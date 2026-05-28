using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await catalogContext.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
                return null;
            var deleteProductResult = await catalogContext.Products.DeleteOneAsync(p => p.Id == id);
            // is acknowledged means that mongodb understood the delete command and processed it
            return deleteProductResult.IsAcknowledged && deleteProductResult.DeletedCount > 0;
        }

        // repsoitories returns ienumerable because it is a type of abstraction and flexibility
        // any preprocessing method should return ienumerable
        public async Task<PagedResult<Product>> GetAllAsync(CatalogSpecParams catalogSpecParams)
        {
            var spec = new ProductSpecification(catalogSpecParams);
            var query = SpecificationEvaluator<Product>.GetQuery(catalogContext.Products, spec);
            var count = await catalogContext.Products.CountDocumentsAsync(_ => true);
            var items = await query.ToListAsync();
            return new PagedResult<Product>{
                PageIndex = catalogSpecParams.PageIndex,
                PageSize = catalogSpecParams.PageSize,
                TotalCount = (int)count,
                Data = items
            };
        }

        public async Task<IEnumerable<Product>> GetAllByBrandNameAsync(string name)
        {
            return await catalogContext.Products.Find(p => p.Brand.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByNameAsync(string name)
        {
            return await catalogContext.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
                return null;
            return await catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> UpdateAsync(Product product)
        {
            if (!ObjectId.TryParse(product.Id, out _))
                return null;
            var updateProductResult = await catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateProductResult.IsAcknowledged && updateProductResult.ModifiedCount > 0;
        }
    }
}
