using Freebie.Models;
using Haka.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Freebie.Services
{
    class ProductService : IProductService
    {
        CategoryModel[] categories;
        ProductModel[] products;

        async Task LocalFetch()
        {
            await Task.Delay(1000);

            var content = LocalResource.GetContent("product-by-category.json");
            var listProductByCategory = JsonSerializer.Deserialize<ProductByCategory[]>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var _categories = new List<CategoryModel> { new() { Name = "All" } };
            _categories.AddRange(listProductByCategory.Select(_ => new CategoryModel { Name = _.Category }));
            
            categories = _categories.ToArray();

            products = listProductByCategory
                .SelectMany(_ => _.Products
                .Select(product => new ProductModel
                {
                    Title = product.Title,
                    Summary = product.Summary,
                    Description = product.Description,
                    Price = $"${product.Price:N2}",
                    UrlImage = product.UrlImage,
                    Order = product.Order,
                    Category = _.Category,
                    CategoryTag = _.Category.ToUpper(),
                }))
                .OrderBy(_ => _.Order)
                .ToArray();
        }

        public async Task<CategoryModel[]> GetCategories()
        {
            await LocalFetch();

            return categories;
        }

        public ProductModel[] GetProducts()
        {
            return products;
        }

        public ProductModel[] GetProductsByCategory(CategoryModel category)
        {
            return category.Name == "All"
                ? products.ToArray()
                : products.Where(_ => _.Category == category.Name).ToArray();
        }

        struct ProductByCategory
        {
            public string Category { get; set; }
            public Product[] Products { get; init; }

            public struct Product
            {
                public string Title { get; init; }
                public string Summary { get; init; }
                public string Description { get; init; }
                public float Price { get; init; }
                public string UrlImage { get; init; }
                public int Order { get; init; }
            }
        }
    }
}
