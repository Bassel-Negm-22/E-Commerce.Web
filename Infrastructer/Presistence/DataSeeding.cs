using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Presistence.Data;

namespace Presistence
{
    public class DataSeeding(StoreDbContext _dbcontext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                var pendingMigrations = await _dbcontext.Database.GetPendingMigrationsAsync();

                if (pendingMigrations.Any())
                {await _dbcontext.Database.MigrateAsync(); }

                if (!_dbcontext.ProductBrands.Any())
                {
                   // var productBrandData = await File.ReadAllTextAsync(@"..\Infrastructer\Presistence\DataSeed\brands.json");
                    var productBrandData = File.OpenRead(@"..\Infrastructer\Presistence\DataSeed\brands.json");
                    var productBrand = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandData);

                    if (productBrand is not null && productBrand.Any())
                    {
                       await _dbcontext.ProductBrands.AddRangeAsync(productBrand);
                    }
                }
                if (!_dbcontext.ProductTypes.Any())
                {
                    var productTypesData = File.OpenRead(@"..\Infrastructer\Presistence\DataSeed\types.json");
                    var productType = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);

                    if (productType is not null && productType.Any())
                    {
                        await _dbcontext.ProductTypes.AddRangeAsync(productType);
                    }
                }
                if (!_dbcontext.Products.Any())
                {
                    var productData = File.OpenRead(@"..\Infrastructer\Presistence\DataSeed\Products.json");
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);

                    if (products is not null && products.Any())
                    {
                      await  _dbcontext.Products.AddRangeAsync(products);
                    }
                }
               await _dbcontext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //Todo
            }
        }
    }
}
