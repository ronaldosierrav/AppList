using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppList.Models;
using AppList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        public ObservableCollection<Products> ItemList { get; set; }
        public ProductList()
        {
            InitializeComponent();
            ItemList = new ObservableCollection<Products>();
            ItemList.Add(new Products(){ProductId=1,ProductName="Pizza", PriceProduct=9000, QuantyProduct=8,Description="Pizza Hawaina"});

        }

        private async void ItemAdd_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrUpdateProducts());
        }

        private void TapEdit_OnTapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs) e;
            Products products = ((ViewInfoProducts) BindingContext).ItemList.Where(product =>
                product.ProductId == (int) tappedEventArgs.Parameter).FirstOrDefault();

            Navigation.PushAsync(new AddOrUpdateProducts(products));
            ListProducts.ItemsSource = ((ViewInfoProducts)BindingContext).ItemList;
        }

        private async void TapDelete_OnTapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            Products products = ((ViewInfoProducts)BindingContext).ItemList.Where(product =>
                product.ProductId == (int)tappedEventArgs.Parameter).FirstOrDefault();

            var actionSheet = await DisplayActionSheet("Desea eliminar el producto?", "Cancelar", null,
                "SI", "NO");

            switch (actionSheet)
            {
                case "Cancel":

                    // Que ocurrira cuando el boton respectivo "Cancel" sea presionado
                    //Se quiebra el metodo

                    break;

                case "SI":
                    //Que ocurrira cuando el boton respectivo "SI" sea presionado
                    //Se ejecutara:
                    ((ViewInfoProducts)BindingContext).ItemList.Remove(products);
                    ListProducts.ItemsSource = ((ViewInfoProducts)BindingContext).ItemList;

                    break;

                case "NO":

                    // Que ocurrira cuando el boton respectivo "NO" sea presionado
                    //Se quiebra el metodo

                    break;

            }
        }

        private void TapDetails_OnTapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            Products products = ((ViewInfoProducts)BindingContext).ItemList.Where(product =>
                product.ProductId == (int)tappedEventArgs.Parameter).FirstOrDefault();

            Navigation.PushAsync(new DetailsProduct(products));
            ListProducts.ItemsSource = ((ViewInfoProducts)BindingContext).ItemList;
        }

        private void Bar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ListProducts.ItemsSource = ((ViewInfoProducts)BindingContext).ItemList.Where(product => product.ProductName.StartsWith(e.NewTextValue));
        }

        private async void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            ListProducts.ItemsSource = ((ViewInfoProducts) BindingContext).ItemList;
            Reload.IsRefreshing = false;
        }
    }
    }
