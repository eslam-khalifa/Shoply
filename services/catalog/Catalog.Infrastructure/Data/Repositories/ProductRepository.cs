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

        public async Task<bool> DeleteAsync(string id)
        {
            var deleteProductResult = await catalogContext.Products.DeleteOneAsync(p => p.Id == id);
            // is acknowledged means that mongodb understood the delete command and processed it
            return deleteProductResult.IsAcknowledged && deleteProductResult.DeletedCount > 0;
        }

        // repsoitories returns ienumerable because it is a type of abstraction and flexibility
        // any preprocessing method should return ienumerable
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await catalogContext.Products.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByBrandNameAsync(string name)
        {
            return await catalogContext.Products.Find(p => p.Brand.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByNameAsync(string name)
        {
            return await catalogContext.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var updateProductResult = await catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateProductResult.IsAcknowledged && updateProductResult.ModifiedCount > 0;
        }
    }
}
