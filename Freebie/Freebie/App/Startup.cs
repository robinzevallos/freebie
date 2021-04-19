using Freebie.Services;
using Freebie.ViewModels;
using Freebie.Views;
using Haka;

namespace Freebie
{
    public class Startup : BaseStartup
    {
        public Startup()
        {
            Service.Navigator.NavigateTo<HomeViewModel>();
        }

        protected override void OnViewModelWithViewRegister(ViewModelWithViewBuilder builder)
        {
            base.OnViewModelWithViewRegister(builder);

            builder
                .Register<HomeViewModel, HomeView>()
                .Register<ProductViewModel, ProductView>()
                .Register<ProductSearcherViewModel, ProductSearcherView>()
                ;
        }

        protected override void OnServiceRegister(ServiceBuilder builder)
        {
            base.OnServiceRegister(builder);

            builder
                .Register<IProductService>()
                ;
        }
    }
}
