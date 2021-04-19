using Freebie.Models;
using Kasay.PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freebie.ViewModels
{
    public class ProductSearcherViewModel : BaseViewModel
    {
        bool isSearching;
        IEnumerable<ProductModel> products;

        [Notify] public IEnumerable<ProductModel> Products { get; set; }

        [Notify] public string Searcher { get; set; }

        public ProductSearcherViewModel(IEnumerable<ProductModel> products)
        {
            this.OnChanged(_ => _.Searcher, Search);

            this.products = products;
            Products = products;
        }

        async void Search()
        {
            if (isSearching) return;

            isSearching = true;
            await Task.Delay(250);

            Products = string.IsNullOrEmpty(Searcher)
                ? products
                : Products.Where(_ => $"{_.Title} {_.Description}"
                    .ToLower()
                    .Contains(Searcher.ToLower()));

            isSearching = false;
        }

        public void Clean()
        {
            Searcher = null;
        }

        public async void OnProductSelected(ProductModel model)
        {
            await Navigator.NavigateTo<ProductViewModel>(model);
        }
    }
}
