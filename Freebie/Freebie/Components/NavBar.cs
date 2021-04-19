using Haka.Core;
using Haka.Core.Test;
using Kasay.BindableProperty;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Freebie.Components
{
    public class NavBar : ScrollView
    {
        readonly Dictionary<View, View> allItems = new();

        [Bind] public IEnumerable ItemsSource { get; set; }

        public string OnItemSelected { get; set; }

        public DataTemplate ItemTemplate { get; set; }

        public DataTemplate ItemSelectedTemplate { get; set; }

        public Action<object> ItemSelected { get; set; }

        public int IndexSelected { get; set; }

        public NavBar()
        {
            this.RegisterMethodParam(nameof(OnItemSelected), nameof(ItemSelected));

            var layout = new FlexLayout();

            Orientation = ScrollOrientation.Horizontal;
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never;
            Content = layout;

            void onItemsSourceChanged()
            {
                ItemsSource.Cast<object>()?.ForEach(item =>
                {
                    var itemContainer = new StackLayout();

                    var itemView = (View)ItemTemplate
                        .Assert("ItemTemplate is null.")
                        .CreateContent();

                    itemView.BindingContext = item;

                    itemContainer.Children.Add(itemView);
                    layout.Children.Add(itemContainer);

                    if (ItemSelectedTemplate is null)
                    {
                        itemContainer.OnTapped(() =>
                        {
                            ItemSelected?.Invoke(item);
                        });
                    }
                    else
                    {
                        var itemSelected = (View)ItemSelectedTemplate.CreateContent();
                        itemSelected.BindingContext = item;
                        itemSelected.IsVisible = false;

                        allItems.Add(itemView, itemSelected);

                        itemContainer.OnTapped(() =>
                        {
                            allItems.Keys.ForEach(_ => _.IsVisible = true);
                            allItems.Values.ForEach(_ => _.IsVisible = false);

                            var currentItem = itemContainer.Children[0];
                            var currentItemSelected = itemContainer.Children[1];

                            currentItem.IsVisible = false;
                            currentItemSelected.IsVisible = true;

                            ItemSelected?.Invoke(item);
                        });

                        itemContainer.Children.Add(itemSelected);
                    }
                });

                layout.Children[IndexSelected].PerformTap();
            }

            this.OnChanged(_ => _.ItemsSource, onItemsSourceChanged);
        }
    }
}
