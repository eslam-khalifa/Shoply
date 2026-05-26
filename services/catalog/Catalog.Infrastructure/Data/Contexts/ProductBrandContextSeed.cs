using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class ProductBrandContextSeed
    {
        // sql server vs. mongodb
        // database    database
        // table       collection
        // row         document
        // column      field
        public static async Task SeedDataAsync(IMongoCollection<ProductBrand> productBrandCollection)
        {
            // Find here means find all documents in the collection
            var hasProductBrands = await productBrandCollection.Find(_ => true).AnyAsync();
            if (hasProductBrands)
                return;
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "SeededData", "brands.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} does not exist.");
                return;
            }
            var brandData = await File.ReadAllTextAsync(filePath);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
            if (brands?.Any() is true)
            {
                // InsertManyAsync is used to insert multiple documents into the collection at once, which is more efficient than inserting them one by one.
                await productBrandCollection.InsertManyAsync(brands);
            }
        }
    }
}
