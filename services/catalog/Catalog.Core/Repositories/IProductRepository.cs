using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(string id);
        Task<IEnumerable<Product>> GetAllByName(string name);
        Task<IEnumerable<Product>> GetAllByBrand(string name);
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
