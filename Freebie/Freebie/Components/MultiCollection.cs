using Haka.Core;
using Haka.Renderers;
using Kasay.BindableProperty;
using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Freebie.Components
{
    public class MultiCollection : Grid
    {
        [Bind] public IEnumerable ItemsSource { get; set; }

        public string OnItemSelected { get; set; }

        public DataTemplate ItemTemplate { get; set; }

        public DataTemplate PromotionItemTemplate { get; set; }

        public Action<object> ItemSelected { get; set; }

        public Action<object> ItemPromotionSelected { get; set; }

        public MultiCollection()
        {
            this.RegisterMethodParam(nameof(OnItemSelected), nameof(ItemSelected));

            var leftStack = new StackLayout { Spacing = 0 };
            var rightStack = new StackLayout { Spacing = 0 };

            SetColumn(leftStack, 0);
            SetColumn(rightStack, 1);

            ColumnSpacing = 0;       

            void OnItemsSourceChanged()
            {
                int temp = 0;

                if (PromotionItemTemplate is not null)
                {
                    var itemPromotion = (View)PromotionItemTemplate.CreateContent();

                    rightStack.Children.Clear();
                    leftStack.Children.Clear();
                    Children.Clear();

                    Children.Add(leftStack);
                    Children.Add(rightStack);

                    rightStack.Children.Add(itemPromotion);

                    itemPromotion.OnTapped(() =>
                    {
                        ItemPromotionSelected?.Invoke(null);
                    });
                }

                ItemsSource.Cast<object>()?.ForEach(item =>
                {
                    var itemView = (View)ItemTemplate
                       .Assert("ItemTemplate is null.")
                       .CreateContent();

                    itemView.BindingContext = item;

                    var isEven = temp++ % 2 == 0;

                    if (isEven)
                    {
                        leftStack.Children.Add(itemView);
                    }
                    else
                    {
                        rightStack.Children.Add(itemView);
                    }

                    (itemView as FrameRipple).Tap = () =>
                    {
                        ItemSelected?.Invoke(item);
                    };
                });
            }

            this.OnChanged(_ => _.ItemsSource, OnItemsSourceChanged);
        }
    }
}
