using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("Data/SeedData/brands.json");
                    var brands = System.Text.Json.JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.ProductTypes.Any())
                {
                    var typessData = File.ReadAllText("Data/SeedData/types.json");
                    var types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(typessData);

                    foreach (var item in types)
                    {
                        storeContext.ProductTypes.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.Products.Any())
                {
                    var productsData = File.ReadAllText("Data/SeedData/products.json");
                    var products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        storeContext.Products.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
