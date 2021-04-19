using Haka;
using Xamarin.Forms;

namespace Freebie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = SinglePage
               .CreateBuilder()
               .SetHeaderTemplateType<HeaderTemplate>()
               .UseStartup<Startup>()
               .Build();

            MainPage.Padding = new Thickness(0, 30, 0, 0);
        }
    }
}
