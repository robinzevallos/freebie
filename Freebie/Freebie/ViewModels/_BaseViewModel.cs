using Haka.Abstractions;
using Kasay.PropertyChanged;
using System.Threading.Tasks;

namespace Freebie.ViewModels
{
    public class BaseViewModel : Notifiable
    {
        public INavigator Navigator { get; } = Startup.Service.Navigator;
        
        public Task<object> NavigateTo<T>(params object[] parameters) 
            => Navigator.NavigateTo<T>(parameters);
    }
}
