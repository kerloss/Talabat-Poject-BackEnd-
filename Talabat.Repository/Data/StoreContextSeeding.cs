using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Order_Aggregate;

namespace Talabat.Repository.Data
{
	public static class StoreContextSeeding
	{
        public static async Task SeedAsync(StoreContext _dbContext)
        {
            //Brand
            var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            //to void error of repeating Id
            //brands = brands.Select(B => new ProductBrand()
            //{
            //	Name = B.Name
            //}).ToList();

            //to avoid data add at every run we need to check in DB if contain Data or not
            if (_dbContext.ProductBrands.Count() == 0) //If no data
            {
                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            //Category
            var CategoryData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoryData);

            if (_dbContext.ProductCategories.Count() == 0)
            {
                if (categories?.Count > 0)
                {
                    foreach (var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            //Product
            var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
            var Products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (_dbContext.Products.Count() == 0)
            {
                if (Products?.Count > 0)
                {
                    foreach (var product in Products)
                    {
                        _dbContext.Set<Product>().Add(product);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            //Delivery
            var deliverysData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/delivery.json");
            var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliverysData);

            if (_dbContext.DeliveryMethods.Count() == 0) {
                if (deliveryMethods?.Count > 0)
                {
                    foreach (var delivery in deliveryMethods)
                    {
                        _dbContext.Set<DeliveryMethod>().Add(delivery);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
	}
}
