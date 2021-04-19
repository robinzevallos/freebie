using Freebie.Models;
using Kasay.PropertyChanged;
using System;

namespace Freebie.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductModel Model { get; set; }

        [Notify] public int Value { get; set; }

        public ProductViewModel(ProductModel model)
        {
            Model = model;
            Value = 1;
        }

        public void OnPlus()
        {
            Value++;
        }

        public void OnLess()
        {
            if (Value > 1)
            {
                Value--;
            }
        }

        public void OnGrid()
        {
            Console.WriteLine("OnGrid");
        }

        public void OnTag()
        {
            Console.WriteLine("OnTag");
        }

        public void OnShppingCart()
        {
            Console.WriteLine("OnShppingCart");
        }

        public void OnSettings()
        {
            Console.WriteLine("OnSettings");
        }

        public void OnBack()
        {
            Navigator.Back();
        }

        public void OnStart()
        {
            Console.WriteLine("OnStart");
        }
    }
}
