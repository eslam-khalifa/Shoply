using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> ProductBrands { get; } 

        public IMongoCollection<ProductType> ProductTypes { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:ProductsCollectionName"]);
            ProductBrands = database.GetCollection<ProductBrand>(configuration["DatabaseSettings:ProductBrandsCollectionName"]);
            ProductTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypesCollectionName"]);

            _ = CatalogContextSeed.SeedDataAsync(Products);
            _ = ProductBrandContextSeed.SeedDataAsync(ProductBrands);
            _ = ProductTypeContextSeed.SeedDataAsync(ProductTypes);
        }
    }
}
