using Freebie.Models;
using System.Threading.Tasks;

namespace Freebie.Services
{
    public interface IProductService
    {
        Task<CategoryModel[]> GetCategories();

        ProductModel[] GetProducts();

        ProductModel[] GetProductsByCategory(CategoryModel category);
    }
}
