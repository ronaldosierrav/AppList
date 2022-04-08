using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AppList.Models;
using Xamarin.Forms;

namespace AppList.ViewModels
{
    public class ViewInfoProducts
    {
        public ObservableCollection<Products> ItemList { get; set; }

        public ViewInfoProducts()
        {
            ItemList = new ObservableCollection<Products>();
            ItemList.Add(new Products() { ProductId = 1, ProductName = "Pizza", PriceProduct = 9000, QuantyProduct = 8, Description = "Pizza Hawaina" });
            MessagingCenter.Subscribe<AddOrUpdateProducts, Products>(this, "AddOrUpdateProduct", (page, products) =>
            {
                if (products.ProductId==0)
                {
                    products.ProductId = ItemList.Count + 1;
                 ItemList.Add(products);
                }
                else
                {
                    Products productsEdit =
                        ItemList.Where(produ => produ.ProductId == products.ProductId).FirstOrDefault();
                    int newIndex = ItemList.IndexOf(productsEdit);
                    ItemList.Remove(productsEdit);
                    ItemList.Add(products);
                    int oldIndex = ItemList.IndexOf(products);
                    ItemList.Move(oldIndex, newIndex);
                }
            });
        }

    }
}
 

