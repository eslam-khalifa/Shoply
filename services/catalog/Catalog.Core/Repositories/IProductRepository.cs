using Catalog.Core.Entities;
using Catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<IEnumerable<Product>> GetAllByNameAsync(string name);
        Task<IEnumerable<Product>> GetAllByBrandNameAsync(string name);
        Task<Product> CreateAsync(Product product);
        Task<bool?> UpdateAsync(Product product);
        Task<bool?> DeleteAsync(string id);
    }
}
