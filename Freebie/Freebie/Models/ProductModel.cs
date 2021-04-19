using Xamarin.Forms;

namespace Freebie.Models
{
    public struct ProductModel
    {
        public string Title { get; init; }

        public string Summary { get; init; }

        public string Description { get; init; }

        public string Price { get; init; }

        public string UrlImage { get; init; }

        public int Order { get; init; }

        public string Category { get; init; }

        public string CategoryTag { get; init; }

        public ImageSource Image
        { 
            get 
            {
                var source = $"Freebie.Assets.img.{UrlImage}";
                var assembly = typeof(ProductModel).Assembly;
                var imageSource = ImageSource.FromResource(source, assembly);

                return imageSource;
            } 
        }
    }
}
