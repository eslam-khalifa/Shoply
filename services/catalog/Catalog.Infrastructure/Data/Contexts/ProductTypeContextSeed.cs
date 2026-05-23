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
    public static class ProductTypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> productTypeCollection)
        {
            var hasProductTypes = await productTypeCollection.Find(_ => true).AnyAsync();
            if (hasProductTypes)
                return;
            var filePath = Path.Combine("Data", "SeededData", "types.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} does not exist.");
                return;
            }
            var productTypeData = await File.ReadAllTextAsync(filePath);
            var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
            if (productTypes!.Any() is true)
            {
                await productTypeCollection.InsertManyAsync(productTypes);
            }
        }
    }
}
