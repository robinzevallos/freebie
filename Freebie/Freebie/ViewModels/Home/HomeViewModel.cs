using Freebie.Models;
using Freebie.Services;
using Kasay.PropertyChanged;
using System;

namespace Freebie.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        readonly IProductService homeService;
        ProductModel[] allProducts;

        [Notify] public CategoryModel[] Categories { get; set; }

        [Notify] public ProductModel[] ProductsByCategory { get; set; }

        public HomeViewModel(IProductService homeService)
        {
            this.homeService = homeService;

            Initialize();
        }

        async void Initialize()
        {
            Categories = await homeService.GetCategories();
            allProducts = homeService.GetProducts();
        }

        public void OnCategorySelected(CategoryModel categoty)
        {
            ProductsByCategory = homeService.GetProductsByCategory(categoty);
        }

        public async void OnProductSelected(ProductModel model)
        {
            await NavigateTo<ProductViewModel>(model);
        }

        public async void OnSearch()
        {
            await NavigateTo<ProductSearcherViewModel>(allProducts);
        }

        public void OnMenu()
        {
            Console.WriteLine("OnMenu");
        }
    }
}
