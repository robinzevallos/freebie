using Haka.Renderers;
using Xamarin.Forms;

namespace Freebie.Views.Home
{
    public partial class ProductItem : FrameRipple
    {
        public ProductItem()
        {
            InitializeComponent();
            Scale = 0.8;
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (widthConstraint > 0 && !double.IsInfinity(widthConstraint))
            {
                OnAppearring();
            }

            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        void OnAppearring()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await this.ScaleTo(1, 200);
            });
        }
    }
}