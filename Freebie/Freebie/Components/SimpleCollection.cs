using Haka.Core;
using Kasay.BindableProperty;
using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Freebie.Components
{
    public class SimpleCollection : ContentView
    {
        [Bind] public IEnumerable ItemsSource { get; set; }

        public string OnItemSelected { get; set; }

        public DataTemplate ItemTemplate { get; set; }

        public Action<object> ItemSelected { get; set; }

        public SimpleCollection()
        {
            this.RegisterMethodParam(nameof(OnItemSelected), nameof(ItemSelected));

            var stack = new StackLayout();
            var scrollView = new ScrollView
            {
                Content = stack
            };

            Content = scrollView;

            this.OnChanged(_ => _.ItemsSource, OnItemsSourceChanged);

            void OnItemsSourceChanged()
            {
                stack.Children.Clear();

                ItemsSource.Cast<object>()?.ForEach(item =>
                {
                    var itemView = (View)ItemTemplate
                       .Assert("ItemTemplate is null.")
                       .CreateContent();

                    itemView.BindingContext = item;
                    stack.Children.Add(itemView);

                    itemView.OnTapped(() => ItemSelected?.Invoke(item));
                });
            }
        }
    }
}
