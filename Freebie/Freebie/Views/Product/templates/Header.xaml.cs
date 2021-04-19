using Xamarin.Forms;

namespace Freebie.Views.Product
{
    public partial class Header : FlexLayout
    {
        public string OnBack
        {
            get => back.OnTap;
            set => back.OnTap = value;
        }

        public string OnStart
        {
            get => start.OnTap;
            set => start.OnTap = value;
        }

        public Header()
        {
            InitializeComponent();
        }
    }
}