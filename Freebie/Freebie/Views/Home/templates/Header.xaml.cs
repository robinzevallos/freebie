using Xamarin.Forms;

namespace Freebie.Views.Home
{
    public partial class Header : FlexLayout
    {
        public string OnMenu
        {
            get => menu.OnTap;
            set => menu.OnTap = value;
        }

        public string OnSearch
        {
            get => search.OnTap;
            set => search.OnTap = value;
        }

        public Header()
        {
            InitializeComponent();
        }
    }
}