using Xamarin.Forms;

namespace Freebie.Views.Product
{
    public partial class TapBar : ContentView
    {
        public string OnGrid
        {
            get => grid.OnTap;
            set => grid.OnTap = value;
        }

        public string OnTag
        {
            get => tag.OnTap;
            set => tag.OnTap = value;
        }

        public string OnShppingCart
        {
            get => shoppingCart.OnTap;
            set => shoppingCart.OnTap = value;
        }

        public string OnSettings 
        { 
            get => settings.OnTap; 
            set => settings.OnTap = value; 
        }

        public TapBar()
        {
            InitializeComponent();
        }
    }
}